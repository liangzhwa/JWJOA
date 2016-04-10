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

public partial class EmployeeManager_WorkStat : System.Web.UI.Page
{

    MDataBase db;
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());

    //存放数据总数
    static int intCount;

    protected void Page_Load(object sender, EventArgs e)
    {
        //////////////
        CSSysStaff staff = new CSSysStaff(config.DBConn);
        staff.Staff_Id = "00000001";
        config.Staff = staff;
        //////////////

        if (!IsPostBack)
        {

            //添加弹出选择人员页面的属性
            btnSelect.Attributes.Add("onclick", "PopWindow();");
            
            //根据权限判断加载哪些记录
            if (Function.CheckStaff(config) == "Yes")//为系统管理员
            {
                BindData("");

                //加载部门下拉框数据
                db = new MDataBase(config.DBConn);
                string strDept = "Select * from SSysDepartment Where StatusId=0";
                DataTable dtDept = new DataTable();
                db.GetDataTable(strDept, out dtDept);
                ddlDept.Items.Clear();
                ddlDept.Items.Add(new ListItem("全部", "0"));
                ddlDept.AppendDataBoundItems = true;
                ddlDept.DataSource = dtDept;
                ddlDept.DataTextField = "Name";
                ddlDept.DataValueField = "Dept_Id";
                ddlDept.DataBind();

                //可以选择员工和部门
                ddlDept.Enabled = true;
                btnSelect.Enabled = true;
            }
            else if (Function.CheckStaff(config) == "No")//不是管理员
            {
                BindData("select a.*,b.UserName As UserName,b.Name As Name,c.Name AS StatusName from SPsnWorkTime a INNER JOIN  SC_WorkStatus c ON a.WorkStatusId = c.WorkStatusId Left Join SSysStaff b On a.Staff_Id=b.Staff_Id Where a.StatusId=0 And Staff_Id='" + config.Staff.Staff_Id + "' And a.Day Between '" + DateTime.Now.AddDays(-7) + "' And '" + DateTime.Now + "'");

                //不可以选择
                btnSelect.Enabled = false;
                ddlDept.Enabled = false;
            }
            else//是部门的管理员
            {
                //得到其所属的员工staff_Id
                db = new MDataBase(config.DBConn);
                string sqlStaff = "Select Staff_Id From SSysStaff Where Dept_Id='" + Function.CheckStaff(config) + "'";
                DataTable dtStaff = new DataTable();
                db.GetDataTable(sqlStaff, out dtStaff);
                string strStaffs = "";
                for (int i = 0; i < dtStaff.Rows.Count; i++)
                {
                    strStaffs += dtStaff.Rows[i][0].ToString() + "','";
                }
                strStaffs = strStaffs.TrimEnd('\'').TrimEnd(',');

                BindData("select a.*,b.UserName As UserName,b.Name As Name,c.Name AS StatusName from SPsnWorkTime a INNER JOIN  SC_WorkStatus c ON a.WorkStatusId = c.WorkStatusId Left Join SSysStaff b On a.Staff_Id=b.Staff_Id Where a.StatusId=0 And a.Staff_Id in('" + strStaffs + ") And a.Day Between '" + DateTime.Now.AddDays(-7) + "' And '" + DateTime.Now + "'");

                //可以选择其所属部门员工
                btnSelect.Enabled = true;
                ddlDept.Enabled = false;
            }
            lblCurrentPage.Text = "1";

        }

        txtSelect.Text = Function.GetStaffNameById(hfStaffId.Value.TrimEnd(','),config);
    }

    /// <summary>
    /// 绑定sql查询到的数据到数据表
    /// </summary>
    /// <param name="sql"></param>
    private void BindData(string sql)
    {
        try
        {
            if (sql == "")
            {
                sql = "select a.*,b.UserName As UserName,b.Name As Name,c.Name AS StatusName from SPsnWorkTime a INNER JOIN  SC_WorkStatus c ON a.WorkStatusId = c.WorkStatusId Left Join SSysStaff b On a.Staff_Id=b.Staff_Id where a.StatusId=0  And a.Day Between '" + DateTime.Now.AddDays(-7) + "' And '" + DateTime.Now + "'";
            }
            DataTable dt = new DataTable();
            db = new MDataBase(config.DBConn);
            bool isw = db.GetDataTable(sql, out dt);
            string strs = db.ErrMessage;
            if (dt != null)
            {
                ViewState["dataSource"] = dt;
                intCount = dt.Rows.Count;
                grvWorkStat.DataSource = dt;
                grvWorkStat.DataBind();
                lblPageSum.Text = this.grvWorkStat.PageCount.ToString();
                lblRecordeSum.Text = dt.Rows.Count.ToString();
            }
            else
            {
                lblPageSum.Text = "0";
                //Response.Write("<script type='text/javascript'>alert('没有找到！');</script>");
            }
        }
        catch (Exception exc)
        {
            throw exc;
        }
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
        int pageSize = grvWorkStat.PageSize;

        //取得总页数
        int pages = grvWorkStat.PageCount;
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
        grvWorkStat.PageIndex = pageIndx;

        lblCurrentPage.Text = (pageIndx + 1).ToString();
        grvWorkStat.DataSource = (DataTable)ViewState["dataSource"];
        grvWorkStat.DataBind();
    }
    protected void btnStat_Click(object sender, EventArgs e)
    {
        /////////以下对每个人循环,每个人生成一行数据（如果不是管理员，则只能看到自已的，如果是部门管理员，则可以看到本部门的，如果是系统管理员，则可以看到全部的）
        //计算总在线时间（在历史表中得到）
        db = new MDataBase(config.DBConn);
        DataTable dtAllStaff = new DataTable();
        string strGetStaff = "";
        if (Function.CheckStaff(config) == "Yes")//系统管理员
        {
            strGetStaff = "Select Staff_Id,Name From SSysStaff";
        }
        else if (Function.CheckStaff(config) == "No")//不是管理员
        {
            strGetStaff = "Select Staff_Id,Name From SSysStaff Where Staff_Id='" + config.Staff.Staff_Id + "'";
        }
        else//部门管理员
        {
            strGetStaff = "Select Staff_Id,Name From SSysStaff Where Dept_Id='" + Function.CheckStaff(config) + "'";
        }
        db.GetDataTable(strGetStaff, out dtAllStaff);

        if (dtAllStaff.Rows.Count > 0)
        {
            //得到日程表中的数据
            DataTable dtAllWorkTime = (DataTable)ViewState["dataSource"];

            if (dtAllWorkTime != null)
            {
                //存放统计数据
                DataTable dtWorkStat = new DataTable();
                DataColumn dc3 = new DataColumn("OnlineTimes");
                DataColumn dc4 = new DataColumn("WorkTimes");
                DataColumn dc5 = new DataColumn("OutTimes");
                DataColumn dc6 = new DataColumn("LeaveTimes");
                DataColumn dc7 = new DataColumn("LeaveDays");
                DataColumn dc8 = new DataColumn("WeekEndWorkDays");
                dtWorkStat.Columns.Add(dc3);
                dtWorkStat.Columns.Add(dc4);
                dtWorkStat.Columns.Add(dc5);
                dtWorkStat.Columns.Add(dc6);
                dtWorkStat.Columns.Add(dc7);
                dtWorkStat.Columns.Add(dc8);

                //创建一行新数据
                DataRow dr = dtWorkStat.NewRow();

                //存放统计数据
                int intOnlineTimes = 0, intWorkTimes = 0, intOutTimes = 0, intLeaveTimes = 0, intLeaveDays = 0, intWeekEndWorkDays = 0;

                for (int i = 0; i < dtAllStaff.Rows.Count; i++)
                {
                    db = new MDataBase(config.DBConn);
                    string strTimesCount = "";
                    db.GetDataScalar("Select sum(DATEDIFF(hour, LoginTime, LogoutTime)) AS TimesCount From SSysLoginHistory Where Staff_Id='" + dtAllStaff.Rows[i][0].ToString() + "'", ref strTimesCount);
                    if (strTimesCount != "")
                    {
                        intOnlineTimes += Int32.Parse(strTimesCount);
                    }

                    //得到出勤次数（在作计划表中，状态为“出勤”的记录数）
                    intWorkTimes += (dtAllWorkTime.Select("Staff_Id='" + dtAllStaff.Rows[i][0].ToString() + "' And WorkStatusId='6'")).Length;

                    //得到外出办事次数（在作计划表中，状态为“外出”的记录数）
                    intOutTimes += (dtAllWorkTime.Select("Staff_Id='" + dtAllStaff.Rows[i][0].ToString() + "' And WorkStatusId='7'")).Length;

                    //得到请假次数（在作计划表中，状态为“请假”的记录数）?????(一次请几天假的情况)
                    intLeaveTimes += (dtAllWorkTime.Select("Staff_Id='" + dtAllStaff.Rows[i][0].ToString() + "' And WorkStatusId='8'")).Length;

                    //得到请假天数（暂为0）
                    intLeaveDays += 0;

                    //得到周末工作天数（暂为0）
                    intWeekEndWorkDays += 0;
                }

                dr["OnlineTimes"] = intOnlineTimes;
                dr["WorkTimes"] = intWorkTimes;
                dr["OutTimes"] = intOutTimes;
                dr["LeaveTimes"] = intLeaveTimes;
                dr["LeaveDays"] = intLeaveDays;
                dr["WeekEndWorkDays"] = intWeekEndWorkDays;
                dtWorkStat.Rows.Add(dr);
                grvStatics.DataSource = dtWorkStat;
                grvStatics.DataBind();
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strSearch = "select a.*,b.UserName As UserName,b.Name As Name,c.Name AS StatusName from SPsnWorkTime a INNER JOIN  SC_WorkStatus c ON a.WorkStatusId = c.WorkStatusId Left Join SSysStaff b On a.Staff_Id=b.Staff_Id where a.StatusId=0";
        
        //拼写查询条件
        if (txtSelect.Enabled == true && txtSelect.Text != "")//取选中人员
        {
            strSearch += " And a.Staff_Id In ('" + hfStaffId.Value.TrimEnd(',').Replace(",","','") + "')";
        }
        if (ddlDept.Enabled == true)//取相应部门的人员
        {
            strSearch += " And a.Staff_Id In " + Function.GetStaffByDept(ddlDept.SelectedValue,config);
        }
        
        if(txtBeginDate.Text != "")
        {
            DateTime start = Convert.ToDateTime(txtBeginDate.Text);
            strSearch += " And a.Day >= '" + start + "'";
        }

        if(txtEndDate.Text != "")
        {        
            DateTime end = Convert.ToDateTime(txtEndDate.Text);
            strSearch += " And a.Day <= '" + end + "'" ;
        }

        if (txtBeginDate.Text == "" && txtEndDate.Text == "")
        {
            strSearch += " And a.Day Between '" + DateTime.Now.AddDays(-7) + "' And '" + DateTime.Now + "'";
        }

        BindData(strSearch);
        //db = new MDataBase(config.DBConn);
        //DataTable dtSearch = new DataTable();
        //db.GetDataTable(strSearch, out dtSearch);
        //ViewState["dataSource"] = dtSearch;
        //grvWorkStat.DataSource = dtSearch;
        //grvWorkStat.DataBind();
    }
}
