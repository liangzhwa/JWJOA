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

public partial class EmployeeManager_WorkPlan : System.Web.UI.Page
{
    MDataBase db;
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());
    CSSysStaff staff;
    //判断列表中的数据是否可以删除
    bool isDelete = true;

    //存放选中的数据
    ArrayList alSelected = new ArrayList();

    //存放数据总数
    static int intCount;

    protected void Page_Load(object sender, EventArgs e)
    {
        string strStaffId = "";
        if (!IsPostBack)
        {
            //config = (Config)Session["Config"];

            /////////测试 
            CSSysStaff staff = new CSSysStaff(config.DBConn);
            staff.Staff_Id = "38b47ee3";
            config.Staff = staff;
            /////////
                  
            hfPower.Value = Function.CheckStaff(config);
          

            //取得前个页面传过来的值
            if (Request.QueryString["StaffId"] != null)
            {
                strStaffId = Request.QueryString["StaffId"].ToString();
            }

            //根据StaffId取得相应的工作日程( 时间条件待补 )
            db = new MDataBase(config.DBConn);
            //数据绑定
            BindData("");

            //添加删除确认事件
            this.btnDelete.Attributes.Add("onclick", "return confirm('您确认要删除所有选中的记录吗？');");

            //显示当前页索引
            lblCurrentPage.Text = "1";
            //取得该日程的所属人
            //lblEmployeeName.Text = dtWorkPlan.Rows[0]["Name"].ToString();

            //加载部门下拉框
            Function.BindDeptToDdl(ddlDept, config);

            //选择人员
            btnSelect.Attributes.Add("onclick", "SelectStaff();");

        }

        txtStaff.Text = Function.GetStaffNameById(hfStaff.Value,config).TrimEnd(',');
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        ArrayList list = GetSelectedKeyValues(out isDelete);

        //修改数据
        if (list.Count == 2)
        {
            if (Convert.ToDateTime(list[1])>= DateTime.Now)
            {
                Response.Write("<script type='text/javascript'>window.showModalDialog('../EmployeeManager/PopPage/WorkPlanAdd.aspx?WorkTimeId=" + list[0].ToString() + "','部门添加页面','height=600, width=800, top='+(screen.AvailHeight-600)/2+', left='+ (screen.availWidth-800)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('该日程已过期，不能修改！');</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('请选择一个要修改的工作日程！');</script>");
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

        for (int i = 0; i < grvWorkPlan.Rows.Count; i++)
        {
            if (grvWorkPlan.Rows[i].RowType != DataControlRowType.Header)
            {
                bool isChecked = ((CheckBox)grvWorkPlan.Rows[i].Cells[0].Controls[1]).Checked;
                if (isChecked)
                {
                    DataRow[] dr = dt.Select("WorkTime_Guid='" + ((HiddenField)grvWorkPlan.Rows[i].Cells[0].Controls[3]).Value + "'");
                    selectedRows.Add(dr[0]["WorkTime_Guid"].ToString());
                    selectedRows.Add(dr[0]["Day"].ToString());
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
        int pageSize = grvWorkPlan.PageSize;

        //取得总页数
        int pages = grvWorkPlan.PageCount;

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
        grvWorkPlan.PageIndex = pageIndx;

        lblCurrentPage.Text = (pageIndx + 1).ToString();
        grvWorkPlan.DataSource = (DataTable)ViewState["dataSource"];
        grvWorkPlan.DataBind();
    }


    /// <summary>
    /// 绑定sql查询到的数据到数据表
    /// </summary>
    /// <param name="sql"></param>
    private void BindData(string sql)
    {
        if (sql == "")
        {
            if (hfPower.Value == "Yes")
            {
                sql = "Select a.*,b.Name as StaffName,c.Name AS StatusName from SPsnWorkTime a INNER JOIN  SC_WorkStatus c ON a.WorkStatusId = c.WorkStatusId Left Join SSysStaff b On a.Staff_Id=b.Staff_Id Where a.StatusId=0";

            }
            else if (hfPower.Value == "No")
            {
                sql = "Select a.*,b.Name as StaffName,c.Name AS StatusName from SPsnWorkTime a INNER JOIN  SC_WorkStatus c ON a.WorkStatusId = c.WorkStatusId Left Join SSysStaff b On a.Staff_Id=b.Staff_Id Where a.StatusId=0 And a.Staff_Id='" + config.Staff.Staff_Id + "'";

            }
            else
            {
                sql = "Select a.*,b.Name as StaffName,c.Name AS StatusName from SPsnWorkTime a INNER JOIN  SC_WorkStatus c ON a.WorkStatusId = c.WorkStatusId Left Join SSysStaff b On a.Staff_Id=b.Staff_Id Where a.StatusId=0 And a.Staff_Id in('" + Function.GetStaffByDept(config.Staff.Staff_Id, config) + "')";
            }
        }
        try
        {
            DataTable dt;
            db = new MDataBase(config.DBConn);
            bool a = db.GetDataTable(sql, out dt);
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    Response.Write("<script type='text/javascript'>alert('没有相应记录！');window.location.href=window.location.href;</script>");
                }
                else
                {
                    ViewState["dataSource"] = dt;
                    intCount = dt.Rows.Count;
                    grvWorkPlan.DataSource = dt;
                    grvWorkPlan.DataBind();

                    PageSum.Text = grvWorkPlan.PageCount.ToString();
                    RecordeSum.Text = dt.Rows.Count.ToString();
                }
            }
            else
            {
                grvWorkPlan.DataSource = null;
                grvWorkPlan.DataBind();
                PageSum.Text = "0";
                RecordeSum.Text = "0";
                lblCurrentPage.Text = "0";
            }
        }
        catch (Exception exc)
        {
            throw exc;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        db = new MDataBase(config.DBConn);
        ArrayList list = GetSelectedKeyValues(out isDelete);

        //判断能否删除
        if (isDelete)
        {
            //删除选中的部门
            if (list.Count != 0)
            {
                string sql = "UPDATE SpsnWorkTime SET StatusId=-1 WHERE WorkTime_Guid in ('";
                string strIndex = "";
                for (int i = 0; i < list.Count; i++)
                {
                    if (Convert.ToDateTime(list[i + 1]) > DateTime.Now)
                    {
                        strIndex += list[i].ToString() + "','";
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('不能删除已过时的日程，删除失败！');window.location.href=window.location.href;</script>");
                    }
                    i++;
                }
                sql = sql + strIndex.Trim('\'').TrimEnd(',') + ")";
                try
                {
                    db = new MDataBase(config.DBConn);
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
                Response.Write("<script type='text/javascript'>alert('请选择要删除的工作日程！');</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('无法删除！');</script>");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strSearch = "";

        if (hfPower.Value == "Yes")
        {
            strSearch = "Select a.*,b.Name as StaffName,c.Name AS StatusName from SPsnWorkTime a INNER JOIN  SC_WorkStatus c ON a.WorkStatusId = c.WorkStatusId Left Join SSysStaff b On a.Staff_Id=b.Staff_Id Where a.StatusId=0";

        }
        else if (hfPower.Value == "No")
        {
            strSearch = "Select a.*,b.Name as StaffName,c.Name AS StatusName from SPsnWorkTime a INNER JOIN  SC_WorkStatus c ON a.WorkStatusId = c.WorkStatusId Left Join SSysStaff b On a.Staff_Id=b.Staff_Id Where a.StatusId=0 And a.Staff_Id='" + config.Staff.Staff_Id + "'";

        }
        else
        {
            strSearch = "Select a.*,b.Name as StaffName,c.Name AS StatusName from SPsnWorkTime a INNER JOIN  SC_WorkStatus c ON a.WorkStatusId = c.WorkStatusId Left Join SSysStaff b On a.Staff_Id=b.Staff_Id Where a.StatusId=0 And a.Staff_Id in('" + Function.GetStaffByDept(config.Staff.Staff_Id,config) + "')";
        }

        if (ddlDept.SelectedIndex != 0)
        {
            strSearch += " And a.Staff_Id in ('" + Function.GetAllStaffByDepts(ddlDept.SelectedValue, config) + "'";
        }

        if (txtStaff.Text != "")
        {
            strSearch += " And a.Staff_Id in ('" + hfStaff.Value + "'";
        }
        if (txtDay.Text != "")
        {
            strSearch += " And a.Day='" + txtDay.Text + "'";
        }
        if (txtAddress.Text != "")
        {
            strSearch += " And a.Address like '%" + txtAddress.Text + "%'";
        }
        if (txtJob.Text != "")
        {
            strSearch += " And a.Job like '%" + txtJob.Text + "%'";
        }
        try
        {
            BindData(strSearch);
        }
        catch (Exception exc)
        {
            Response.Write("<script type='text/javascript'>alert('" +exc.Message+"');window.location.href=window.location.href;</script>");
        }
    }
}
