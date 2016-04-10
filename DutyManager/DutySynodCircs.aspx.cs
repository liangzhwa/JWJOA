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

public partial class DutyManager_DutySynodCircs : System.Web.UI.Page
{
    MDataBase db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            txtCreatedBy.Text = "";  //从登录得到用户名

            txtCreatedBy.Enabled = false;
        
            ControlDataBind drp = new ControlDataBind(ConfigurationManager.ConnectionStrings["OA"].ToString());
            drp.DropDownListBind(drpGuardSpec, "SOrdSpec", "SpecName", "SpecID", 1, "", txtCreatedBy.Text.Trim());
            drp.DropDownListBind(drpOrder_ID, "SOrdEstate", "Order_ID", "Order_ID", 4, "StatusId = 4", txtCreatedBy.Text.Trim());　　　//完结状态的勤务
            lblEnregisterTime.Text = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() +
                "-" + System.DateTime.Now.Day.ToString();//得到当前的时间

            if (Request.QueryString["Order_ID"] == null || Request.QueryString["Order_ID"].ToString() == "") //勤务编号
            {
                ViewState["State"] = "Insert";
            }
            else
            {
                //  string Order_ID = Request.QueryString["Order_ID"].ToString();
                string Order_ID = "200842001";
                ViewState["Order_ID"] = Order_ID;
                ViewState["State"] = "Update";
                string selectSql = " SELECT [Order_ID],[EnregisterTime],[GuardSpec],[MoveDate],[MoveTomeFrom],[MoveTomeTo],[FrontUnit]," +
                    "[AppearedFugle],[CalendarArrange],[Principal],[Roster],[Remark],[Perform],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[StatusId] " +
                    " FROM SOrdSynodBenregister where Order_ID = '" + Order_ID + "'";
                DataRow selectRow = db.GetDataRow(selectSql);
                ViewState["Order_ID"] = selectRow[0];
                drpOrder_ID.SelectedValue = selectRow[0].ToString();   //勤务编号
                drpOrder_ID.Enabled = false;

                this.lblEnregisterTime.Text = selectRow[1].ToString();  //登记时间
                drpGuardSpec.SelectedValue = selectRow[2].ToString();  ///警卫规格

                
                txtMoveDate.Text = selectRow[3].ToString();  ///活动天数

                txtMoveTomeFrom1.Text = GetDate(selectRow[4].ToString()); //得到日期
                drpMoveTomeFrom2.SelectedValue = GetHour(selectRow[4].ToString()); //时
                txtMoveTomeFrom3.Text =  GetMinute(selectRow[4].ToString()); //分

                txtMoveTomeTo1.Text = GetDate(selectRow[5].ToString()); //得到日期
                drpMoveTomeTo2.SelectedValue = GetHour(selectRow[5].ToString()); //时
                txtMoveTomeTo3.Text =  GetMinute(selectRow[5].ToString()); //分
               
                
                txtFrontUnit.Text = selectRow[6].ToString();     //主办单位
                txtAppearedFugle.Text = selectRow[7].ToString();  //  省陪同领导：   
                txtCalendarArrange.Text = selectRow[8].ToString();// 活动日程：


                txtPrincipal.Text = selectRow[9].ToString();  // 负责人：
                txtRoster.Text = selectRow[10].ToString(); //      值勤人员：
                txtPerform.Text = selectRow[12].ToString();   //　　情况

                txtRemark.Text = selectRow[11].ToString();  //  备注


            }



        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (drpOrder_ID.SelectedValue == "0")
        {
            WebWindow.alert("请选择要操作的勤务的编号");
            return;
        }


        string Order_ID = drpOrder_ID.SelectedValue; //勤务编号
        string EnregisterTime = this.lblEnregisterTime.Text.Trim() ;

        string GuardSpec = drpGuardSpec.SelectedValue;  //警卫规格：
        string MoveDate = txtMoveDate.Text.Trim();
      
        try
        {
            Convert.ToInt32(MoveDate);
        }
        catch
        {
            WebWindow.alert("抵达天数请输入日期型");
            return;
        }

        if(txtMoveTomeFrom3.Text == "")
        {
            txtMoveTomeFrom3.Text = "00";
        }
        string MoveTomeFrom = txtMoveTomeFrom1.Text.Trim() + " " + drpMoveTomeFrom2.Text.Trim() +":" + txtMoveTomeFrom3.Text.Trim() + ":00";  //日期加小时加分秒
        try
        {
            Convert.ToDateTime(MoveTomeFrom);
        }
        catch
        {
            WebWindow.alert("活动日期从请输入日期型");
            return;
        }
    
        if(txtMoveTomeTo3.Text == "")
        {
            txtMoveTomeTo3.Text = "00";
        }
        string MoveTomeTo = txtMoveTomeTo1.Text.Trim() + " " + drpMoveTomeTo2.Text.Trim() + ":" + txtMoveTomeTo3.Text.Trim() + ":00";  //日期加小时加分秒
        try
        {
            Convert.ToDateTime(MoveTomeTo);
        }
        catch
        {
            WebWindow.alert("活动日期从请输入日期型");
            return;
        }

        string FrontUnit = txtFrontUnit.Text.Trim();  //      主持或主办单位：  
        string AppearedFugle = txtAppearedFugle.Text.Trim(); //      出席的主要领导：

        string CalendarArrange = txtCalendarArrange.Text.Trim();   //  活动日程

        string Principal = txtPrincipal.Text.Trim(); //      负责人：
        string Roster = txtRoster.Text.Trim();  //      值勤人员：
        string Perform = txtPerform.Text.Trim();
        string Remark = txtRemark.Text.Trim(); //      备注：    
        string CreatedBy = txtCreatedBy.Text.Trim();//      填表人：



        if (ViewState["State"] == null || ViewState["State"].ToString() == null)
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            if (ViewState["State"].ToString() == "Insert")
            {
                string Insert = "INSERT INTO SOrdSynodBenregister([Order_ID],[EnregisterTime],[GuardSpec] ,[MoveDate] ,[MoveTomeFrom] ,[MoveTomeTo], " +
                                " [FrontUnit] ,[AppearedFugle] ,[CalendarArrange] ,[Principal] ,[Roster] ,[Remark] ,[Perform],[CreatedBy] ," +
                               " [CreatedDate]) VALUES('" + Order_ID + "','" + EnregisterTime + "','" +GuardSpec + "','" +MoveDate + "','" + 
                               MoveTomeFrom + "','" + MoveTomeTo + "','" + FrontUnit + "','" + AppearedFugle + "','" + CalendarArrange + "','" + Principal + "','" + 
                               Roster + "','" + Remark +  "','" + Perform +  "','" + CreatedBy + "',getdate()) ";


                try
                {
                    db.executeInsert(Insert);
                    WebWindow.alert("保存成功");
                }
                catch (Exception er)
                {
                    WebWindow.alert(er.Message);
                }
            }
            else if (ViewState["State"].ToString() == "Update")
            {
                if (ViewState["Order_ID"] == null || ViewState["Order_ID"].ToString() == "")
                {
                    Response.Redirect("error2.htm");
                }
                string ModifiedBy = "";
                string Update = "UPDATE SOrdSynodBenregister set " +
                            "[EnregisterTime] = '" +  EnregisterTime + "'," +
                            "[GuardSpec] = '" +  GuardSpec + "'," +
                            "[MoveDate] = '" +  MoveDate + "'," +
                            "[MoveTomeFrom] = '" +  MoveTomeFrom + "'," +
                            "[MoveTomeTo] = '" +  MoveTomeTo + "'," +
                            "[FrontUnit] = '" + FrontUnit + "'," +
                            "[AppearedFugle] = '" +  AppearedFugle + "'," +
                            "[CalendarArrange] = '" +  CalendarArrange + "'," +
                            "[Principal] = '" +  Principal + "'," +
                            "[Roster] = '" +  Roster + "'," +
                            "[Remark] = '" +  Remark  + "'," +
                            "[Perform] = '" + Perform + "'," +
                            "[ModifiedBy] = '" +  ModifiedBy  + "'," +
                            "[ModifiedDate] = getdate() WHERE Order_ID = '" + Order_ID + "'";


                try
                {
                    db.executeUpdate(Update);
                    WebWindow.alert("修改成功");
                }
                catch (Exception er)
                {
                    WebWindow.alert(er.Message);
                }
            }
        }

    }
  
    #region 日期截取

    private string GetDate(string time)
    {
        if (time.Length == 16)
        {
            return time.Substring(0, 8);
        }
        else if (time.Length == 17)
        {
            return time.Substring(0, 9);
        }
        else if (time.Length == 18)
        {
            return time.Substring(0, 10);
        }
        return "";
    }

    private string GetHour(string time)
    {
        if (time.Length == 16)
        {
            return time.Substring(8, 2);
        }
        else if (time.Length == 17)
        {
            return time.Trim().Substring(9, 2);
        }
        else if (time.Length == 18)
        {
            return time.Trim().Substring(10, 2);
        }
        return "";
    }

    private string GetMinute(string time)
    {
        if (time.Length == 16)
        {
            return time.Trim().Substring(11, 2);
        }
        else if (time.Length == 17)
        {
            return time.Trim().Substring(12, 2);
        }
        else if (time.Length == 18)
        {
            return time.Trim().Substring(13, 2);
        }
        return "";
    }

    #endregion
}
