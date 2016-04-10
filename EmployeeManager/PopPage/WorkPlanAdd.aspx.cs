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

public partial class EmployeeManager_PopPage_WorkPlanAdd : System.Web.UI.Page
{
    //定义全局变量
    MDataBase db;
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //////////////////
            CSSysStaff staff = new CSSysStaff();
            config.Staff = staff;
            staff.Staff_Id = "00000001";
            //////////////////


            //如果是管理员，则让其选择员工，如果是普通员工则不能选择
            if (config.Staff.IsMonitor == 0)
            {
                btnSelect.Attributes.Add("onclick", "PopWindow();");
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
                txtSelected.Text = config.Staff.Name;
            }

            //为工作状态下拉框添加选项
            db = new MDataBase(config.DBConn);
            string strWorkStatus = "Select * From SC_WorkStatus Where IsSystemStatus=-1";
            DataTable dtWorkStatus = new DataTable();
            db.GetDataTable(strWorkStatus, out dtWorkStatus);
            ddlWordStatus.DataSource = dtWorkStatus.DefaultView;
            ddlWordStatus.DataTextField = "Name";
            ddlWordStatus.DataValueField = "WorkStatusId";
            ddlWordStatus.DataBind();

            //添加关闭本页面的事件
            btnWorkPlanSave.Attributes.Add("onclick", "closeWin();");

            if (Request.QueryString["WorkTimeId"] != null)
            {
                //保存上个页面传来的ID值,表示进行更新操作
                hfWorkTime.Value = Request.QueryString["WorkTimeId"].ToString();

                lblDayKey.Enabled = true;
                lblDayValue.Enabled = true;  

                //加载页面中的各项值
                db = new MDataBase(config.DBConn);
                DataTable dt = new DataTable();
                db.GetDataTable("Select * from SPsnWorkTime Where StatusId=0 And WorkTime_Guid='"+hfWorkTime.Value+"'", out dt);
                txtStart.Enabled = false;
                txtEnd.Enabled = false;
                btnSelect.Enabled = false;

                //显示工作日期
                lblDayValue.Text = dt.Rows[0]["Day"].ToString();

                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtJob.Text = dt.Rows[0]["Job"].ToString();
                for (int i = 0; i < ddlWordStatus.Items.Count; i++)
                {
                    if (ddlWordStatus.Items[i].Value == dt.Rows[0]["WorkStatusId"].ToString())
                    {
                        ddlWordStatus.SelectedIndex = i;
                    }
                }

            }
            else
            {
                //表示进行插入操作
                hfWorkTime.Value = "Insert";
                lblDayKey.Enabled = false;
                lblDayValue.Enabled = false;                
            }
        }

        txtSelected.Text = Function.GetStaffNameById(hfStaffId.Value,config).TrimEnd(',');
        if (txtSelected.Text.Contains(","))
        {
            Response.Write("<script type='text/javascript'>alert('只能选择一个人员进行添加！'); </script>");
            txtSelected.Text = "";
        }
    }

    protected void btnWorkPlanSave_Click(object sender, EventArgs e)
    {
        CSPsnWorkTime workTime = new CSPsnWorkTime(config.DBConn);
        if (hfWorkTime.Value == "Insert")
        {
            if (txtStart.Text == "" || txtEnd.Text == "")
            {
                Response.Write("<script type='text/javascript'>alert('请输入开始和结束时间！'); </script>");
                return;
            }

            TimeSpan span = Convert.ToDateTime(txtEnd.Text) - Convert.ToDateTime(txtStart.Text);
            int intDays = span.Days;

            try
            {

                //hfStaffId中的值是用来存放要添加日程的员工的ID
                if (txtSelected.Text != "")
                {
                    string[] strStaff = txtSelected.Text.Split(',');

                    //循环为每个人插入日程
                    for (int i = 0; i < strStaff.Length; i++)
                    {
                        string strStaffId = strStaff[i];

                        //循环为一个人的每天插入日程
                        for (int j = 0; j <= intDays; j++)
                        {
                            workTime.Staff_Id = strStaffId;

                            //得到要插入的新的工作日程编号
                            workTime.WorkTime_Guid = Guid.NewGuid().ToString();

                            //得到日期
                            DateTime strDay = Convert.ToDateTime(txtStart.Text).AddDays(j);

                            //得到工作状态
                            int intWorkStatus = Int32.Parse(ddlWordStatus.SelectedValue);

                            //得到事件
                            workTime.Job = txtJob.Text;
                            workTime.Day = strDay;
                            workTime.WorkStatusId = intWorkStatus;
                            workTime.Address = txtAddress.Text;
                            workTime.CreatedDate = DateTime.Now;
                            workTime.Insert();

                        }

                    }
                }
            }
            catch (Exception exc)
            {

            }            
        }
        else
        {
            try
            {
                workTime.WorkTime_Guid = hfWorkTime.Value;
                workTime.Job = txtJob.Text;
                workTime.Address = txtAddress.Text;
                workTime.WorkStatusId = Int32.Parse(ddlWordStatus.SelectedValue);
                workTime.Update();
            }
            catch (Exception exc)
            {

            }           
        }
    }
}
