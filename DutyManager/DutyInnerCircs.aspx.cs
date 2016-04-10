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

public partial class DutyManager_DutyInnerCircs : System.Web.UI.Page
{
    MDataBase db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            txtCreatedBy.Text = "";  //从登录得到用户名

            txtCreatedBy.Enabled = false;
            txtTaskName.Enabled = false;    //勤务名称不能修改
             ControlDataBind drp = new ControlDataBind(ConfigurationManager.ConnectionStrings["OA"].ToString());
            drp.DropDownListBind(drpGuardSpec, "SOrdSpec", "SpecName", "SpecID", 1, "", txtCreatedBy.Text.Trim());
            drp.DropDownListBind(drpOrder_ID, "SOrdEstate", "Order_ID", "Order_ID", 4, "StatusId = 4", txtCreatedBy.Text.Trim());　　　//完结状态的勤务
            lblEnregisterTime.Text = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + 
                "-" + System.DateTime.Now.Day.ToString() ;//得到当前的时间

            if (Request.QueryString["Order_ID"] == null || Request.QueryString["Order_ID"].ToString() == "") //勤务编号
            {
                ViewState["State"] = "Insert";
            }
            else
            {
                string Order_ID = Request.QueryString["Order_ID"].ToString();
              
                ViewState["Order_ID"] = Order_ID;
                ViewState["State"] = "Update";
                string selectSql = " SELECT [Order_ID],[EnregisterTime],[GuardSpec],[DayNumber],[ArrivalTime],[FromArea],[RiteVehicle]," +
                    " [ArrivalArea],[ArrivalTimeTwo],[FromAreaTwo],[RiteVehicleTwo],[ArrivalAreaTwo],[ReceiveArea],[AccompanyFugle],[MoveDate], " +
                    " [AccompanyPeo],[GuardCuston],[Principal],[Roster],[Perform],[Remark],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate]," +
                    " [StatusId]  FROM SOrdNWBenregister where Order_ID = '" + Order_ID  + "'";
                DataRow selectRow = db.GetDataRow(selectSql);
                ViewState["Order_ID"] = selectRow[0]; 
                drpOrder_ID.SelectedValue = selectRow[0].ToString();   //勤务编号
                drpOrder_ID.Enabled = false;
               
                this.lblEnregisterTime.Text = selectRow[1].ToString();  //登记时间
                drpGuardSpec.SelectedValue = selectRow[2].ToString();  ///警卫规格
                   
                if (drpOrder_ID.SelectedValue != "0")  //勤务名称
                {
                    string Sql = "select Order_Name from SOrdEstate where Order_ID = '" + selectRow[0].ToString() + "'";
                    try
                    {
                        string Order_Name = db.GetDataScalar(Sql);
                        txtTaskName.Text = Order_Name;
                    }
                    catch { }
                }

                txtDayNumber.Text = selectRow[3].ToString();  ///警卫规格

                txtArrivalTime1.Text = GetDate(selectRow[4].ToString()); //得到日期
                drpArrivalTime2.SelectedValue = GetHour(selectRow[4].ToString()); //时

                txtFromArea.Text =  selectRow[5].ToString();         //  自
                txtRiteVehicle.Text = selectRow[6].ToString();       //  乘
                txtArrivalArea.Text = selectRow[7].ToString();       //  抵

                txtArrivalTimeTwo1.Text = GetDate(selectRow[8].ToString()); //得到日期
                drpArrivalTimeTwo2.SelectedValue = GetHour(selectRow[8].ToString()); //时
                txtFromAreaTwo.Text =  selectRow[9].ToString();         //  自
                txtRiteVehicleTwo.Text = selectRow[10].ToString();      //  乘
                txtArrivalAreaTwo.Text = selectRow[11].ToString();      //  抵        

                txtReceiveArea.Text = selectRow[12].ToString();  // 接待单位：
                txtAccompanyFugle.Text = selectRow[13].ToString();    //  省陪同领导：
                txtMoveDate.Text = selectRow[14].ToString();  // 活动日程：
                txtAccompanyPeo.Text = selectRow[15].ToString();   // 随行人员(姓名/职务)：
                txtGuardCuston.Text = selectRow[16].ToString();  //  警卫对象生活习惯：


                txtPrincipal.Text = selectRow[17].ToString();  // 负责人：
                txtRoster.Text = selectRow[18].ToString(); //      值勤人员：
                txtPerform.Text = selectRow[19].ToString();   //　　情况

                txtRemark.Text = selectRow[20].ToString();  //  备注
                

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
        string EnregisterTime = this.lblEnregisterTime.Text.Trim() + " 00:00:00";
        
        string GuardSpec = drpGuardSpec.SelectedValue;  //警卫规格：
        string TaskName = txtTaskName.Text.Trim();      //警卫名称

        string DayNumber = txtDayNumber.Text.Trim();     // 抵达情况：
        try
        {
            Convert.ToInt32(txtDayNumber.Text.Trim());
        }
        catch
        {
            WebWindow.alert("抵达天数请输入日期型");
            return;
        }
        string ArrivalTime = txtArrivalTime1.Text.Trim() + " " + drpArrivalTime2.Text.Trim() + ":00:00";  //日期加小时加分秒
        try
        {
            Convert.ToDateTime(ArrivalTime);
        }
        catch
        {
            WebWindow.alert("抵达时间请输入日期型");
            return;
        }
        string FromArea = txtFromArea.Text.Trim(); //自
        string RiteVehicle = txtRiteVehicle.Text.Trim(); //   乘
        string ArrivalArea = txtArrivalArea.Text.Trim();  //抵

        string ArrivalTimeTwo = txtArrivalTimeTwo1.Text.Trim() + " " + this.drpArrivalTimeTwo2.Text.Trim() + ":00:00";  //日期加小时加分秒       
         try
        {
            Convert.ToDateTime(ArrivalTimeTwo);
        }
        catch
        {
            WebWindow.alert("抵达时间请输入日期型");
            return;
        }
        string FromAreaTwo = txtFromAreaTwo.Text.Trim(); //自
        string RiteVehicleTwo = txtRiteVehicleTwo.Text.Trim(); //   乘
        string ArrivalAreaTwo = txtArrivalAreaTwo.Text.Trim();  //抵

        string ReceiveArea = txtReceiveArea.Text.Trim();   //      接待单位：
        string AccompanyFugl = txtAccompanyFugle.Text.Trim();  //      省陪同领导：
        string MoveDate = txtMoveDate.Text.Trim(); //      活动日程：

        string AccompanyPeo = txtAccompanyPeo.Text.Trim();   //  随行人员(姓名/职务)：
        string GuardCuston = txtGuardCuston.Text.Trim();    //   警卫对象生活习惯：       

        string Principal = txtPrincipal.Text.Trim(); //      负责人：
        string Roster = txtRoster.Text.Trim();  //      值勤人员：
        string Perform = txtPerform.Text.Trim();
         
        string Remark = txtRemark.Text.Trim(); //      备注：    
        string CreatedBy =  txtCreatedBy.Text.Trim();//      填表人：


       
        if(ViewState["State"] == null || ViewState["State"].ToString() == null)
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            if(ViewState["State"].ToString() == "Insert")
            {
                   string Insert = "INSERT INTO SOrdNWBenregister ([Order_ID] ,[EnregisterTime] ,[GuardSpec] ,[DayNumber] ,[ArrivalTime] ,[FromArea] ,[RiteVehicle] ," +
                 "[ArrivalArea] ,[ArrivalTimeTwo] ,[FromAreaTwo] ,[RiteVehicleTwo] ,[ArrivalAreaTwo] ,[ReceiveArea] ,[AccompanyFugle] ,[MoveDate] ," +
                 "[AccompanyPeo] ,[GuardCuston] ,[Principal] ,[Roster] ,[Perform] ,[Remark] ,[CreatedBy] ,[CreatedDate]) VALUES " +
                 "('" + Order_ID + "','" + EnregisterTime + "','" +GuardSpec + "','" +DayNumber + "','" +ArrivalTime + "','" +FromArea + "','" +RiteVehicle + "','" +ArrivalArea + "','" +ArrivalTimeTwo + "','" +
                 FromAreaTwo + "','" + RiteVehicleTwo + "','" + ArrivalAreaTwo + "','" + ReceiveArea + "','" + AccompanyFugl + "','" + MoveDate + "','" + AccompanyPeo + "','" + GuardCuston + "','" +
                 Principal + "','" + Roster + "','" + Perform + "','" + Remark + "','" + CreatedBy + "',getdate())";

                try
                {
                    db.executeInsert(Insert);
                    WebWindow.alert("保存成功");
                }
                catch(Exception er)
                {
                    WebWindow.alert(er.Message);
                }
            }
            else if(ViewState["State"].ToString() == "Update")
            {
                if (ViewState["Order_ID"] == null || ViewState["Order_ID"].ToString() == "")
                {
                    Response.Redirect("error2.htm");
                }
                string ModifiedBy = "";
                string Update =  "UPDATE SOrdNWBenregister set [GuardSpec] = '" + GuardSpec + "',[DayNumber] = '" + DayNumber + "',[ArrivalTime]= '" + ArrivalTime + "',[FromArea] = '" +
                    FromArea + "',[RiteVehicle]  = '" + RiteVehicle + "',[ArrivalArea] = '" + ArrivalArea + "', [ArrivalTimeTwo] = '" + ArrivalTimeTwo + 
                        "',[FromAreaTwo] = '" + FromAreaTwo + "',[RiteVehicleTwo] = '" + RiteVehicleTwo + "',[ArrivalAreaTwo] = '" + ArrivalAreaTwo +
                        "',[ReceiveArea] = '" + ReceiveArea + "',[AccompanyFugle] = '" + AccompanyFugl + "',[MoveDate] = '" + MoveDate + "',[AccompanyPeo] = '" + AccompanyPeo + "',[GuardCuston] = '" +
                        GuardCuston + "',[Principal] = '" +Principal + "',[Roster] = '" +Roster + "',[Perform]= '" +Perform + "',[Remark] = '" +
                        Remark + "',[ModifiedBy] = '" + ModifiedBy + "',[ModifiedDate] = getdate() WHERE Order_ID = '" + ViewState["Order_ID"].ToString() + "'";

                try
                {
                    db.executeUpdate(Update);
                    WebWindow.alert("修改成功");
                }
                catch(Exception er)
                {
                    WebWindow.alert(er.Message);
                }
            }
        }

    }
    protected void  drpOrder_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpOrder_ID.SelectedValue != "0")
        {
            string Sql = "select Order_Name from SOrdEstate where Order_ID = '" + drpOrder_ID.SelectedValue + "'";
            try
            {
                string Order_Name = db.GetDataScalar(Sql);
                txtTaskName.Text = Order_Name;
            }
            catch { }
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
