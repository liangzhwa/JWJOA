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

public partial class EmployeeManager_PopPage_StaffWorkPlan : System.Web.UI.Page
{
    MDataBase db;
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        string strStaffId = "";

        if (!IsPostBack)
        {
            //取得前个页面传过来的值
            if (Request.QueryString["StaffId"] != null)
            {
                strStaffId = Request.QueryString["StaffId"].ToString();
            }

            //根据StaffId取得相应的工作日程( 时间条件待补 )
            db = new MDataBase(config.DBConn);
            string sqlWorkPlan = "Select * From SPsnWorkTime Where Staff_Id='" + strStaffId + "'";
            DataTable dtWorkPlan = new DataTable();

            db.GetDataTable(sqlWorkPlan, out dtWorkPlan);

            grvWorkPlan.DataSource = dtWorkPlan;
            grvWorkPlan.DataBind();
        }
    }
}
