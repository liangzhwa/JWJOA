using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Stone.Data;
using System.Text;

public partial class EmployeeManager_DepartmentManager : System.Web.UI.Page
{
    MDataBase db;
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());


    //判断列表中的数据是否可以删除（部门是否有子部门）
    bool isDelete = true;

    //存放选中的数据
    ArrayList alSelected = new ArrayList();

    //存放数据总数
    static int intCount;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //数据绑定
            BindData("");

            //添加删除确认事件
            this.btnDelete.Attributes.Add("onclick", "return confirm('您确认要删除所有选中的记录吗？');");

            //显示当前页索引
            lblCurrentPage.Text = "1";
        }
    }

    /// <summary>
    /// 根据条件查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string strSql = "select a.*, (CASE WHEN b.Name IS NULL THEN '无' ELSE b.Name END) AS parentName, 1 AS [Index] from SSysDepartment a LEFT OUTER JOIN SSysDepartment b ON a.Parent_Id = b.Dept_Id where (a.StatusId=0)";
        if (txtDepartmentID.Text != "")
        {
            strSql += " and a.Dept_Id like'%" + txtDepartmentID.Text + "%'";
        }
        if (txtDepartmentName.Text != "")
        {
            strSql += " and a.Name like '%" + txtDepartmentName.Text + "%'";
        }

        strSql += " order by a.Parent_Id,a.OrderIndex";
        BindData(strSql);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        
        db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
        ArrayList list = GetSelectedKeyValues(out isDelete);

        //判断是否为父部门，如果为父部门则不能删除
        if (isDelete)
        {            
            //删除选中的部门
            if (list.Count != 0)
            {
                string sql = "UPDATE SSysDepartment SET StatusId=-1 WHERE Dept_Id in (";
                string strIndex = "";
                for (int i = 0; i < list.Count; i++)
                {
                    strIndex += "'" + list[i].ToString() + "',";
                }
                sql = sql + strIndex.TrimEnd(',') + ")";
                try
                {
                    db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
                    db.executeDelete(sql);
                    Response.Write("<script type='text/javascript'>alert('删除成功！');window.location.href=window.location.href;</script>");
                    BindData("");
                }
                catch (Exception exc)
                {

                }
                finally
                {
                    Response.Write("<script type='text/javascript'>alert('删除失败！');window.location.href=window.location.href;</script>");
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('请选择要删除的部门！');</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('选择的部门中包含父部门，请先删除子部门！');</script>");
        }
    }

    /// <summary>
    /// 取得要删除的行
    /// </summary>
    /// <returns></returns>
    public ArrayList GetSelectedKeyValues(out bool delete)
    {
        DataTable dt = (DataTable)ViewState["dataSource"];
        ArrayList selectedRows = new ArrayList();
        bool canDelete = true;

        for (int i = 0; i < grvDepartment.Rows.Count; i++)
        {
            if (grvDepartment.Rows[i].RowType != DataControlRowType.Header)
            {
                bool isChecked = ((CheckBox)grvDepartment.Rows[i].Cells[0].Controls[1]).Checked;
                if (isChecked)
                { 
                    DataRow[] dr = dt.Select("Dept_Id='" + ((HiddenField)grvDepartment.Rows[i].Cells[0].Controls[3]).Value + "'");
                    selectedRows.Add(dr[0]["Dept_Id"].ToString());

                    //判断是否有子部门，如果有，则返回 false ，表示不能删除
                    DataRow[] dr1 = dt.Select("Parent_Id='" + dr[0]["Dept_Id"].ToString() + "'");
                    if (dr1.Length != 0)
                    {
                        canDelete = false;
                    }                   
                }               
            }            
        }
        delete = canDelete;
        return selectedRows;
    }

    /// <summary>
    /// 实现换页功能
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void PagerButton_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["dataSource"];

        //取得当前页的索引
        int pageIndx = Convert.ToInt32(CurrentPage.Value);

        //取得数据总条数
        int totals = dt.Rows.Count;

        //取得每页的大小
        int pageSize = grvDepartment.PageSize;

        //取得总页数
        int pages = grvDepartment.PageCount;
        //int pages = (totals % pageSize) == 0 ? (totals / pageSize) : (totals / pageSize + 1);

        string arg = ((Button)sender).CommandArgument.ToString().ToLower();
        switch (arg)
        {
            case "prev":
                if (pageIndx > 0)
                {
                    pageIndx -= 1;
                }
                break;
            case "next":
                if (pageIndx < pages - 1)
                {
                    pageIndx += 1;
                }
                break;
            case "last":
                pageIndx = pages - 1;
                break;
            default:
                pageIndx = 0;
                break;
        }
        CurrentPage.Value = pageIndx.ToString();
        grvDepartment.PageIndex = pageIndx;

        lblCurrentPage.Text = (pageIndx + 1).ToString();
        grvDepartment.DataSource = (DataTable)ViewState["dataSource"];
        grvDepartment.DataBind();
    }


    /// <summary>
    /// 绑定sql查询到的数据到数据表
    /// </summary>
    /// <param name="sql"></param>
    private void BindData(string sql)
    {
        if (sql == "")
        {
            sql = "SELECT a.*, (CASE WHEN b.Name IS NULL THEN '无' ELSE b.Name END) AS parentName, 1 as [Index] FROM SSysDepartment a LEFT OUTER JOIN SSysDepartment b ON a.Parent_Id = b.Dept_Id where (a.StatusId=0) Order By a.Parent_Id, a.OrderIndex";
        }
        try
        {
            DataTable dt;
            db = new MDataBase(config.DBConn);
            MDataBase db1 = new MDataBase(config.DBConn);
            bool a = db.GetDataTable(sql, out dt);
            string b = db.ErrMessage;
            
            ViewState["dataSource"] = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Index"] = (int)dt.Rows[i]["Index"] + i;
            }
            intCount = dt.Rows.Count;
            grvDepartment.DataSource = dt;
            grvDepartment.DataBind();

            PageSum.Text = grvDepartment.PageCount.ToString();
            RecordeSum.Text = dt.Rows.Count.ToString();
        }
        catch (Exception exc)
        {
            throw exc;
        }
    }

    /// <summary>
    /// 修改选中的部门
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnModify_Click(object sender, EventArgs e)
    {
        ArrayList list = GetSelectedKeyValues(out isDelete);

        //修改数据
        if (list.Count == 1)
        {
            HiddenField1.Value = list[0].ToString();
            //Response.Write("<script type='text/javascript'>window.showModalDialog('../EmployeeManager/PopPage/DepartmentAdd.aspx?Department=" + list[0].ToString() + "',window,'部门添加页面','height=220, width=300, top='+(screen.AvailHeight-220)/2+', left='+ (screen.availWidth-300)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');</script>");            
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('请选择一个要修改的部门！');</script>");
        }
    }
}
