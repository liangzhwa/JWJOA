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

public partial class EmployeeManager_RoleManager : System.Web.UI.Page
{

    MDataBase db;
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());

    //判断列表中的角色是否可以删除（是否为系统管理员）
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
            this.lblCurrentPage.Text = "1";

            //添加修改事件
            this.btnModify.Attributes.Add("onclick", "return PopWindowForModi();");
        }

        

        //lblRecordeSum.Text = intCount.ToString();
        //lblCurrentPage.Text = grvDepartment.PageIndex.ToString();        
    }

    /// <summary>
    /// 角色删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ArrayList list = GetSelectedKeyValues(out isDelete);

        
        //循环删除数据
        if (list.Count != 0)
        {
            //将角色表中的对应记录，标记为不可用
            string sql = "UPDATE SSysRole SET StatusId=-1 WHERE Role_Id in (";

            //将与该Role_Id对应的SSysRoleFunction表中的记录删除
            string sqlDelete = "Delete from SSysRoleFunction Where Role_Id in(";

            string strIndex = "";
            for (int i = 0; i < list.Count; i++)
            {                
                strIndex += "'" + list[i].ToString() + "',";
            }
            sql = sql + strIndex.TrimEnd(',') + ")";

            sqlDelete = sqlDelete + strIndex.TrimEnd(',') + ")";

            try
            {
                db = new MDataBase(config.DBConn);
                db.executeUpdate(sql);
                db.executeDelete(sqlDelete);
                Response.Write("<script type='text/javascript'>alert('删除成功！');window.location.href=window.location.href;</script>");
            }
            catch (Exception exc)
            {

            }
            finally
            {
                Response.Write("<script type='text/javascript'>window.location.href=window.location.href;</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('请选择要删除的部门！');</script>");
        }
    }


    //取得要删除的行
    public ArrayList GetSelectedKeyValues(out bool delete)
    {
        DataTable dt = (DataTable)ViewState["dataSource"];
        ArrayList selectedRows = new ArrayList();

        bool canDelete = true;

        for (int i = 0; i < grvRole.Rows.Count; i++)
        {
            if (grvRole.Rows[i].RowType != DataControlRowType.Header)
            {
                bool isChecked = ((CheckBox)grvRole.Rows[i].Cells[0].Controls[1]).Checked;
                if (isChecked)
                {
                    DataRow[] dr = dt.Select("Role_Id='" + ((HiddenField)grvRole.Rows[i].Cells[0].Controls[3]).Value +"'");
                    selectedRows.Add(dr[0]["Role_Id"].ToString());

                    //判断是否为系统管理员，如果是，则返回 false ，表示不能删除                    
                    if (grvRole.Rows[i].Cells[1].Text == "系统管理员")
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
    /// 实现翻页功能
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
        int pageSize = grvRole.PageSize;

        //取得总页数
        int pages = grvRole.PageCount;
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
        grvRole.PageIndex = pageIndx;

        lblCurrentPage.Text = (pageIndx + 1).ToString();
        grvRole.DataSource = (DataTable)ViewState["dataSource"];
        grvRole.DataBind();        
    }


    /// <summary>
    /// 绑定sql查询到的数据到数据表
    /// </summary>
    /// <param name="sql"></param>
    private void BindData(string sql)
    {
        if (sql == "")
        {
            sql = "select * from SSysRole where StatusId=0";
        }
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        if (dt != null)
        {
            ViewState["dataSource"] = dt;
            intCount = dt.Rows.Count;
            grvRole.DataSource = dt;
            grvRole.DataBind();
            lblPageSum.Text = this.grvRole.PageCount.ToString();
            lblRecordeSum.Text = dt.Rows.Count.ToString();
        }
        else
        {
            lblPageSum.Text = "0";
            Response.Write("<script type='text/javascript'>alert('没有您查找的角色！');</script>");
        }
    }
    protected void grvRole_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ///通过下面的处理在每次翻页时也能把之前的选中情况回显出来   
        if (e.Row.RowIndex > -1 && ViewState["mylist"] != null)
        {
            ArrayList list = (ArrayList)ViewState["mylist"];

            DataRowView tmp = (DataRowView)e.Row.DataItem;
            string aaa = tmp["field1"].ToString();
            if (list.Contains(aaa))
            {
                CheckBox cbox = (CheckBox)e.Row.Cells[0].FindControl("checkbox");
                cbox.Checked = true;
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string strSql = "select * from SSysRole where (StatusId=0)";
        if (this.txtRoleID.Text != "")
        {
            strSql += " and Role_Id like '%" + txtRoleID.Text + "%'";
        }
        if (this.txtRoleName.Text != "")
        {
            strSql += " and Name like '%" + txtRoleName.Text + "%'";
        }
        BindData(strSql);
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        ArrayList list = GetSelectedKeyValues(out isDelete);

        //修改数据
        if (list.Count == 1)
        {
            Response.Write("<script type='text/javascript'>window.showModalDialog('../EmployeeManager/PopPage/RoleAdd.aspx?RoleId=" + list[0].ToString() + "',window,'部门添加页面','height=300, width=500, top='+(screen.AvailHeight-300)/2+', left='+ (screen.availWidth-500)/2 +', toolbar=no, menubar=no, scrollbars=auto, resizable=no,location=no, status=no');</script>");
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('请选择一个要修改的角色！');</script>");
        }
    }
}
