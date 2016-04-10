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

public partial class EmployeeManager_EmployeeManager : System.Web.UI.Page
{
    MDataBase db;
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());

    //判断列表中的数据是否可以删除
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

            //添加密码初始化警告
            this.btnPwdInit.Attributes.Add("onclick", "return confirm('您确定要进行密码初始化操作吗？')");

            //显示当前页索引
            lblCurrentPage.Text = "1";
        }

        RecordeSum.Text = intCount.ToString();
        //lblCurrentPage.Text = grvEmployee.PageIndex.ToString();
        PageSum.Text = grvEmployee.PageCount.ToString();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        
        ArrayList list = GetSelectedKeyValues(out isDelete);

        //循环删除数据
        if (list.Count != 0)
        {
            string sql = "UPDATE SSysStaff SET StatusId=-1 WHERE Staff_Id in (";
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string strSql = "select a.*, b.Name AS deptName from SSysStaff a LEFT JOIN SSysDepartment b ON a.Dept_Id = b.Dept_Id where (a.StatusId=0)";
        if (this.txtDepartment.Text != "")
        {
            strSql += " and b.Name like '%" + txtDepartment.Text + "%'";
        }
        if (this.txtEmployeeName.Text != "")
        {
            strSql += " and a.Name like '%" + txtEmployeeName.Text + "%'";
        }
        strSql += " Order By a.OrderIndex";
        BindData(strSql);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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

    /// <summary>
    /// 取得要删除的行
    /// </summary>
    /// <returns></returns>
    public ArrayList GetSelectedKeyValues(out bool delete)
    {
        DataTable dt = (DataTable)ViewState["dataSource"];
        ArrayList selectedRows = new ArrayList();
        bool canDelete = true;

        for (int i = 0; i < grvEmployee.Rows.Count; i++)
        {
            if (grvEmployee.Rows[i].RowType != DataControlRowType.Header)
            {
                bool isChecked = ((CheckBox)grvEmployee.Rows[i].Cells[0].Controls[1]).Checked;
                if (isChecked)
                {
                    DataRow[] dr = dt.Select("Staff_Id='" + ((HiddenField)grvEmployee.Rows[i].Cells[0].Controls[3]).Value + "'");
                    selectedRows.Add(dr[0]["Staff_Id"].ToString());

                    ////判断是否有子部门，如果有，则返回 false ，表示不能删除
                    //DataRow[] dr1 = dt.Select("Parent_Id=" + dr[0]["Dept_Id"].ToString());
                    //if (dr1.Length != 0)
                    //{
                    //    canDelete = false;
                    //}
                }
            }
        }
        delete = canDelete;
        return selectedRows;
    }


    protected void PagerButton_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["dataSource"];

        //取得当前页的索引
        int pageIndx = Convert.ToInt32(CurrentPage.Value);

        //取得数据总条数
        int totals = dt.Rows.Count;

        //取得每页的大小
        int pageSize = grvEmployee.PageSize;

        //取得总页数
        int pages = grvEmployee.PageCount;
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
        grvEmployee.PageIndex = pageIndx;

        lblCurrentPage.Text = (pageIndx + 1).ToString();
        grvEmployee.DataSource = (DataTable)ViewState["dataSource"];
        grvEmployee.DataBind();
    }

    /// <summary>
    /// 绑定sql查询到的数据到数据表
    /// </summary>
    /// <param name="sql"></param>
    private void BindData(string sql)
    {
        if (sql == "")
        {
            sql = "select a.*, b.Name AS deptName from SSysStaff a LEFT JOIN SSysDepartment b ON a.Dept_Id = b.Dept_Id WHERE a.StatusId=0";
        }
        try
        {
            DataTable dt = new DataTable();
            db = new MDataBase(config.DBConn);
            db.GetDataTable(sql, out dt);
            ViewState["dataSource"] = dt;
            intCount = dt.Rows.Count;
            grvEmployee.DataSource = dt;
            grvEmployee.DataBind();
        }
        catch (Exception exc)
        {
            throw exc;
        }
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        ArrayList list = GetSelectedKeyValues(out isDelete);

        //修改数据
        if (list.Count == 1)
        {
            Response.Write("<script type='text/javascript'>window.open('../EmployeeManager/PopPage/FirstLogin.aspx?StaffId=" + list[0].ToString() + "','员工修改页面','dialogHeight=450, dialogWidth=600, top='+(screen.AvailHeight-450)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');</script>");
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('请选择一个要修改的员工！');</script>");
        }
    }
    protected void btnPwdInit_Click(object sender, EventArgs e)
    {
        //取得选中的数据
        ArrayList list = GetSelectedKeyValues(out isDelete);

        //修改数据
        if (list.Count == 1)
        {
            //进行密码的修改
            try
            {
                string strNewPwd = Guid.NewGuid().ToString().Substring(0, 6);
                CSSysStaff Modistaff = new CSSysStaff(config.DBConn);
                Modistaff.Staff_Id = list[0].ToString();
                Modistaff.Password = strNewPwd;
                Modistaff.Update();
                Response.Write("<script type='text/javascript'>alert('员工" + Function.GetStaffNameById(list[0].ToString(),config) + "初始化密码成功，新密码为 " + strNewPwd + "！');</script>");
            }
            catch (Exception exc)
            {
                Response.Write("<script type='text/javascript'>alert('初始化密码失败！');</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('请选择一个要初始化密码的员工！');</script>");
        }
        
    }
}
