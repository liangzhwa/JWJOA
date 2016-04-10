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
using System.Text;
using System.IO;

public partial class DutyManager_DutyArrange : System.Web.UI.Page
{
    //一个子勤务只审批一次
    MDataBase db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {


        Config Config = (Config)Session["Config"];
        string staff_Id = Config.Staff.Staff_Id;　//得到登录的用户名
     //   string staff_Id = "";
        string Order_ID = "";
        string type = "";
        string OrderArrange_Guid = "";
        ViewState["Satff_Id"] = staff_Id;

        if (Request.QueryString["Order_ID"] == null || Request.QueryString["Order_ID"].ToString() == "") //编码
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            Order_ID = Request.QueryString["Order_ID"].ToString();
            ViewState["Order_ID"] = Order_ID;
        }

        if (Request.QueryString["type"] == null || Request.QueryString["type"].ToString() == "") //状态 新建:1 修改:2
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            type = Request.QueryString["type"].ToString();
            ViewState["type"] = type;
        }

        //子勤务编号
        if (Request.QueryString["OrderArrange_Guid"] == null || Request.QueryString["OrderArrange_Guid"].ToString() == "")
        {
            OrderArrange_Guid = "";
        }
        else
        {
            OrderArrange_Guid = Request.QueryString["OrderArrange_Guid"].ToString();
            ViewState["OrderArrange_Guid"] = OrderArrange_Guid;
        }

        if (!this.IsPostBack)
        {
            ControlDataBind drp = new ControlDataBind(ConfigurationManager.ConnectionStrings["OA"].ToString());
            drp.DropDownListBind(dropOrderNotion, "SSFugleideaConfig", "IdeaContent", "IdeaID", 1, "", staff_Id);


            if (OrderArrange_Guid == "")  //新增的情况
            {
                //权限验证
                ButtonVisible();
                Panelvisible();
                this.panelAP.Visible = true;
                this.panelAP1.Visible = true;
                this.panelAN.Visible = true;
                ViewState["state"] = "AP";
                btnZCompere.Attributes.Add("onclick", "PopWindow1();");
                btnFCompere.Attributes.Add("onclick", "PopWindow2();");
                btnPrincipal.Attributes.Add("onclick", "PopWindow3();");
                btnXGMan.Attributes.Add("onclick", "PopWindow4();");
            
            }
            else if (OrderArrange_Guid != "")   //不是新增的情况下　有可能是领导批示／有可能是公文编写等功能
            {
                if (db.GetDataScalar("select Count(*) from SZOrdAuditing where Order_ID = '" +
                    Order_ID + "' and OrderArrange_Guid = '" + OrderArrange_Guid + "'") == "0")   //查不到记录说明是勤务安排的修改阶段
                {

                    //权限验证 得到第一次填写的人
                    string CreatedBy = db.GetDataScalar("select CreatedBy from SOrdCArrange where Order_ID = '" + Order_ID + "' and OrderArrange_Guid = '" + OrderArrange_Guid + "'");

                    if (CreatedBy != staff_Id)
                    {
                        ButtonVisible();     //如果没有权限修改，就只能看
                        Panelvisible();
                        this.panelXS.Visible = true;
                        XSAP(OrderArrange_Guid);
                        XSAP2(OrderArrange_Guid);
                    }
                    else
                    {

                        ButtonVisible();
                        Panelvisible();
                        ViewState["state"] = "EditAP";
                        this.panelAP.Visible = true;
                        this.panelAP1.Visible = true;
                        this.panelAN.Visible = true;
                        XGEditAP(OrderArrange_Guid);
                        XSAP2Edit(OrderArrange_Guid);
                        btnZCompere.Attributes.Add("onclick", "PopWindow1();");
                        btnFCompere.Attributes.Add("onclick", "PopWindow2();");
                        btnPrincipal.Attributes.Add("onclick", "PopWindow3();");
                        btnXGMan.Attributes.Add("onclick", "PopWindow4();");
                    }
                }
                else
                {
                    string StrZOrdAuditing = "select PerNumber,OrderNotion,IsPer,StatusId,Per from SZOrdAuditing where Order_ID = '" +
                    Order_ID + "' and OrderArrange_Guid = '" + OrderArrange_Guid + "'";    //勤务审批信息

                    try
                    {
                        DataRow ZOrdAuditingRow = db.GetDataRow(StrZOrdAuditing);

                        string PerNumber = ZOrdAuditingRow[0].ToString();
                        string OrderNotion = ZOrdAuditingRow[1].ToString();
                        string IsPer = ZOrdAuditingRow[2].ToString();
                        string StatusId = ZOrdAuditingRow[3].ToString();
                        string Per = ZOrdAuditingRow[4].ToString();

                        if ((PerNumber != "" || PerNumber != null) && StatusId == "0")    //审批后修改审批内容的状态
                        {

                            //权限验证 得到第一次填写的人
                            string CreatedBy = db.GetDataScalar("select CreatedBy from SZOrdAuditing where Order_ID = '" + Order_ID + "' and OrderArrange_Guid = '" + OrderArrange_Guid + "'");
                            if (CreatedBy != staff_Id)
                            {
                                ButtonVisible();     //如果没有权限修改，就只能看
                                Panelvisible();
                                this.panelXS.Visible = true;
                                XSAP(OrderArrange_Guid);
                                XSAP2(OrderArrange_Guid);
                            }
                            else
                            {
                                ViewState["state"] = "EditSP";
                                ButtonVisible();
                                Panelvisible();
                                XSAP(OrderArrange_Guid);
                                XSAP2(OrderArrange_Guid);
                                XGEditPS(OrderArrange_Guid);
                                this.panelPS.Visible = true;
                                this.panelAN.Visible = true;
                                this.panelXS.Visible = true;
                                this.btnSave.Visible = false;
                                this.Button5.Visible = false;
                            }

                        }
                        else if (PerNumber == "" || PerNumber == null)  //　第一次审批
                        {
                            //用当前登陆的用户名去上步指定人中去查询，能查到，说名指定了　
                            string CreatBy = "select Count(*) from SZOrdAuditing  left join SOrdArrangeMan on SZOrdAuditing.Per = SOrdArrangeMan.Guid where " +
                                " Man  = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "' and OrderArrange_Guid = '" + OrderArrange_Guid + "'";

                            if (db.GetDataScalar(CreatBy) == "0")
                            {
                                ButtonVisible();     //如果没有权限修改，就只能看勤务安排的内容
                                Panelvisible();
                                this.panelXS.Visible = true;
                                XSAP(OrderArrange_Guid);
                                XSAP2(OrderArrange_Guid);
                            }
                            else
                            {
                                ViewState["state"] = "SP";
                                ButtonVisible();
                                Panelvisible();
                                XSAP(OrderArrange_Guid);
                                XSAP2(OrderArrange_Guid);
                                this.panelPS.Visible = true;
                                this.panelAN.Visible = true;
                                this.panelXS.Visible = true;
                                this.btnSave.Visible = false;
                                this.Button5.Visible = false;
                            }
                        }
                        else if ((PerNumber != "" || PerNumber != null) && StatusId == "1")  //　审批并且下送后
                        {
                            ViewState["state"] = "Write";
                            Panelvisible();
                            XSAP(OrderArrange_Guid);
                            XSAP2(OrderArrange_Guid);
                            XSPS(OrderArrange_Guid);
                            XSAP2Edit(OrderArrange_Guid);
                            this.panelXS.Visible = true;
                            this.panelAP1.Visible = true;
                            this.btnSave.Visible = false;

                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
        txtZCompere.Value = hfStaffId1.Value.TrimEnd(',');
        txtFCompere.Value = hfStaffId2.Value.TrimEnd(',');
        txtPrincipal.Value = hfStaffId3.Value.TrimEnd(',');
        txtXGMan.Value = hfStaffId4.Value.TrimEnd(',');
    }



    private void Panelvisible()
    {
        panelAP.Visible = false;
        panelPS.Visible = false;
        panelAP1.Visible = false;
        panelAN.Visible = false;
        panelXS.Visible = false;
    }
    private void ButtonVisible()
    {
        this.Button1.Visible = false;
        this.Button2.Visible = false;
        this.Button3.Visible = false;
        this.Button4.Visible = false;
    }


    #region  按扭操作

    //领导批示
    protected void btnPerNumber_Click(object sender, EventArgs e)
    {
        EditTYPS(ViewState["OrderArrange_Guid"].ToString());
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ViewState["state"] == null || ViewState["state"].ToString() == "")
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            if (ViewState["state"].ToString() == "AP")
            {
                WebWindow.alert(SaveAP());
            }
            else if (ViewState["state"].ToString() == "EditAP")
            {

                WebWindow.alert(EditAP());
            }
        }
    }

    //下送
    protected void btnNext_Click(object sender, EventArgs e)
    {
        this.btnSave.Visible = false;
        txt1.Value = hfStaffId.Value.TrimEnd(',');
        if (ViewState["state"] == null || ViewState["state"].ToString() == "")
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            if (ViewState["state"].ToString() == "AP")
            {
                 WebWindow.alert(SaveTYPS(ViewState["OrderArrange_Guid"].ToString()));
            }
            else if (ViewState["state"].ToString() == "EditAP")
            {
                 WebWindow.alert(SaveTYPS(ViewState["OrderArrange_Guid"].ToString()));
            }
            else if (ViewState["state"].ToString() == "SP")
            {
                WebWindow.alert(UpdatePSSatet());
            }
            else if(ViewState["state"].ToString() == "EditSP")
            {
                 WebWindow.alert(UpdatePSSatet());
            }
        }
    }
    #endregion



    #region  安排页面的操作
    //显示勤务安排的页面，传进来勤务编号和勤务安排的编号
    private void XSAP(string OrderArrange_Guid)
    {
        lblXS.Text = "";
         StringBuilder str = new StringBuilder();
         if (ViewState["Str"] == null || ViewState["Str"].ToString() == "")
         {
          
         }
         else
         {
             str.Append(ViewState["Str"].ToString());
         }

        string SqlAP = "SELECT FromTime, FromTo, Order_locus, ReceiveUnit, Order_Calendar, work_Request," +
                         " Abjunct, LinkFashion,ZCompere, FCompere,   Principal, XGMan,DutyPlan," +
                         " Archives, Badge, Gun, Car " +
                         " FROM SOrdCArrange where Order_ID = '" + ViewState["Order_ID"].ToString() + "' and OrderArrange_Guid = '" + OrderArrange_Guid + "'"; 
        DataRow SYRow = db.GetDataRow(SqlAP);
        str.Append("<tr> " +
            "<td align=\"left\" colspan=\"6\" style=\"background-color: #ffcc99\"> 勤务分配</td></tr>" +
           
            "<tr>" +
               "<td width=\"15%\" align=\"right\">日期时间从：</td> " +
               "<td width=\"35%\" align=\"left\" colspan=\"2\" > " +   //日期时间从
                    SYRow[0].ToString() +
              "<td align=\"right\" style=\"width: 15%\">到</td> " +
              "<td width=\"35%\" align=\"left\" colspan=\"2\" > " +   //日期时间到
                  SYRow[1].ToString() +
           "</tr> " +
           "<tr> " +
             "<td width=\"15%\" align=\"right\"> 勤务地点：</td> " +
              "<td colspan=\"5\"> " +
                SYRow[2].ToString() +//勤务地点
                 "</td> " +
           "</tr> " +
           "<tr> " +
             "<td width=\"15%\" align=\"right\">  接待单位：</td> " +
              "<td colspan=\"5\"> " +
                 SYRow[3].ToString() +//接待单位
              "</td> </tr> " +
           "<tr> " +
             "<td width=\"15%\" align=\"right\">  活动日程：</td> " +
              "<td colspan=\"5\"> " +
                SYRow[4].ToString() +//活动日程
                 "</td> " +
           "</tr> " +
           "<tr> " +
             "<td width=\"15%\" align=\"right\">工作要求：</td> " +
              "<td colspan=\"5\"> " +
                  SYRow[5].ToString() +//工作要求
                 "</td></tr> " +
             "<tr>" +
            "<td align=\"right\">附件：</td>" +
            "<td colspan=\"5\">");

        str.Append("<iframe  style=\"overflow: auto; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 550px; height: 120px;\"   src = \"Abjunct.aspx?AttachmentBatch_Guid='" + SYRow[6].ToString() + "'\"></iframe>");

        str.Append("<tr>" +
             "<td align=\"right\">联系方式：</td>" +
         "<td align=\"left\" colspan=\"5\">" +
                 SYRow[7].ToString() +//联系方式
           "</td></tr>" +
       "<tr>" +
             "<td align=\"right\">总指挥：</td>" +
         "<td align=\"left\" colspan=\"2\">" +
                 GetMan(SYRow[8].ToString()) +//总指挥
           "</td>" +
             "<td align=\"right\">副指挥：</td>" +
             "<td align=\"left\" colspan=\"2\">" +
                 GetMan(SYRow[9].ToString()) +//副指挥
           "</td></tr>" +
         "<tr>" +
            "<td align=\"right\">  负责人：</td>" +
            "<td align=\"left\" colspan=\"2\">" +
                GetMan(SYRow[10].ToString()) + //负责人
           "</td>");


        ViewState["Str"] = str.ToString();
        lblXS.Text = str.ToString();
    }

    //显示勤务安排的页面，传进来勤务编号和勤务安排的编号
    private void XSAP1(string OrderArrange_Guid)
    {
        lblXS.Text = "";
        StringBuilder str = new StringBuilder();
        if (ViewState["Str"] == null || ViewState["Str"].ToString() == "")
        {

        }
        else
        {
            str.Append(ViewState["Str"].ToString());
        }


        string SqlAP = "SELECT  Archives, Badge, Gun, Car " +
                          " FROM SOrdCArrange where Order_ID = '" + ViewState["Order_ID"].ToString() + "' and OrderArrange_Guid = '" + OrderArrange_Guid + "'";   //113
        try
        {
            DataRow SYRow = db.GetDataRow(SqlAP);
            str.Append("<tr>" +
              "<td align=\"right\">勤务安排</td>" +
              " <td colspan=\"6\" align=\"left\">");
            str.Append("<tr>" +
                "<td align=\"right\">方案编写：</td>" +
                " <td colspan=\"5\" align=\"left\">");

            str.Append("方案编写的链接");

            str.Append("</td>" +
         "</tr>" +
          "<tr>" +
            " <td align=\"right\">枪支编写：</td>" +
             " <td colspan=\"5\" align=\"left\">");

            str.Append("枪支编写的链接");

            str.Append("</td></tr><tr>" +
            " <td align=\"right\">徽章编写：</td>" +
             " <td colspan=\"5\" align=\"left\">");

            str.Append("徽章编写的链接");

            str.Append("</td></tr><tr>" +
            "<td align=\"right\">车辆编写：</td>" +
             "<td colspan=\"5\" align=\"left\">");

            str.Append("车辆编写的链接");
            str.Append("</td></tr>");


            ViewState["Str"] = str.ToString();
            lblXS.Text = str.ToString();
        }
        catch
        {
        }
    }



    //显示勤务安排的页面，显示勾选的信息
    private void XSAP2(string OrderArrange_Guid)
    {
        string SqlAP = "SELECT Archives, Badge, Gun, ReceiveUnit, Car" +
                         " FROM SOrdCArrange where Order_ID = '" + ViewState["Order_ID"].ToString() + "' and OrderArrange_Guid = '" + OrderArrange_Guid + "'";   //113
        try
        {

            lblXS.Text = "";
            StringBuilder str = new StringBuilder();
            if (ViewState["Str"] == null || ViewState["Str"].ToString() == "")
            {

            }
            else
            {
                str.Append(ViewState["Str"].ToString());
            }
            DataRow SYRow = db.GetDataRow(SqlAP);
            str.Append("<tr>" +
              " <td colspan=\"6\" align=\"left\">");

            if (SYRow[0].ToString() == "1")
            {
                str.Append("<tr>" +
                    "<td align=\"right\">允许方案编写</td>" +
                    " <td colspan=\"5\" align=\"left\">");

            }

            if (SYRow[1].ToString() == "1")
            {
                str.Append("</td>" +
             "</tr>" +
              "<tr>" +
                " <td align=\"right\">允许枪支领取</td>" +
                 " <td colspan=\"5\" align=\"left\">");

            }

            if (SYRow[2].ToString() == "1")
            {
                str.Append("</td></tr><tr>" +
                " <td align=\"right\">允许徽章领取</td>" +
                 " <td colspan=\"5\" align=\"left\">");

            }

            if (SYRow[3].ToString() == "1")
            {
                str.Append("</td></tr><tr>" +
                "<td align=\"right\">允许车辆领取</td>" +
                 "<td colspan=\"5\" align=\"left\">");

            }

          

            str.Append("</td></tr>");

            ViewState["Str"] = str.ToString();
            lblXS.Text = str.ToString();
        }
        catch
        {
        }
    }



    public void XGEditAP(string OrderArrange_Guid)   //勤务安排
    {
        string SqlAP = "SELECT FromTime, FromTo, Order_locus, ReceiveUnit, Order_Calendar, work_Request," +
                         " Abjunct, LinkFashion,ZCompere, FCompere,   Principal, XGMan,DutyPlan," +
                         " Archives, Badge, Gun, Car " +
                         " FROM SOrdCArrange where Order_ID = '" + ViewState["Order_ID"].ToString() + "' and OrderArrange_Guid = '" + OrderArrange_Guid + "'";  
        try
        {
            DataRow APRow = db.GetDataRow(SqlAP);

            string time = APRow[0].ToString();

            //日期时间从  
            txtFromRTime.Text = GetDate(time);
            drpFromSTime.SelectedValue = GetHour(time);
            txtFromFTime.Text = GetMinute(time);

            string time1 = APRow[1].ToString();
            //日期时间到  

            txtToRTime.Text = GetDate(time1);
            drpToSTime.SelectedValue = GetHour(time1);
            txtToFTime.Text = GetMinute(time1);
            //勤务地点
            string Order_locus = APRow[2].ToString();
            txtOrder_locus.Text = Order_locus;

            //接待单位
            string ReceiveUnit = APRow[3].ToString();
            txtReceiveUnit.Text = ReceiveUnit;

            //活动日程
            string Order_Calendar = APRow[4].ToString();
            txtOrder_Calendar.Text = Order_Calendar;

            //工作要求
            string work_Request = APRow[5].ToString();
            txtwork_Request.Text = work_Request;

            //附件
            //附件：AAA
            XSFile(APRow[6].ToString());


            //联系方式
            string LinkFashion = APRow[7].ToString();
            txtLinkFashion.Text = LinkFashion;
            //总指挥
            string ZCompere = APRow[8].ToString();
            txtZCompere.Value = GetMan(ZCompere);

            //副指挥
            string FCompere = APRow[9].ToString();
            txtFCompere.Value = GetMan(FCompere);

            //负责人
            string Principal = APRow[10].ToString();
            txtPrincipal.Value = GetMan(Principal);

            //相关人员
            string XGMan = APRow[11].ToString();
            txtXGMan.Value = GetMan(XGMan);

            

            if (APRow[13].ToString().Trim() == "1")
            {
                this.CheckBox1.Checked = true;
            }
            else
            {
                this.CheckBox1.Checked = false;
            }
            if (APRow[14].ToString().Trim() == "1")
            {
                this.CheckBox2.Checked = true;
            }
            else
            {
                this.CheckBox2.Checked = false;
            }
            if (APRow[15].ToString().Trim() == "1")
            {
                this.CheckBox3.Checked = true;
            }
            else
            {
                this.CheckBox3.Checked = false;
            }
            if (APRow[16].ToString().Trim() == "1")
            {
                this.CheckBox4.Checked = true;
            }
            else
            {
                this.CheckBox4.Checked = false;
            }
            
          

        }
        catch
        {

        }





    }

    //勤务安排
    private string SaveAP()
    {
        string type = "";
        if (ViewState["type"].ToString() == "1")
        {
            type = "随卫勤务";
        }
        else if (ViewState["type"].ToString() == "2")
        {
            type = "现场勤务";
        }
        else if (ViewState["type"].ToString() == "3")
        {
            type = "住地勤务";
        }
       
        //日期时间从  
        if (txtFromFTime.Text == "")
        {
            txtFromFTime.Text = "00";
        }
        string timeFrom = txtFromRTime.Text + " " + drpFromSTime.SelectedValue + ":" + txtFromFTime.Text + ":00";
        //日期时间到  
        if (txtToFTime.Text == "")
        {
            txtToFTime.Text = "00";
        }
        string timeTo = txtToRTime.Text + " " + drpToSTime.SelectedValue + ":" + txtToFTime.Text + ":00";
        //勤务地点
        string Order_locus = txtOrder_locus.Text.Trim();
        //接待单位
        string ReceiveUnit = txtReceiveUnit.Text.Trim();
        //活动日程
        string Order_Calendar = txtOrder_Calendar.Text.Trim();
        //工作要求
        string work_Request = txtwork_Request.Text.Trim();
        //附件：AAA
        string GVAbjunctOne = "";
        if (ViewState["AttachmentBatch_Guid"] == null || ViewState["AttachmentBatch_Guid"].ToString() == "")
        {

        }
        else
        {
            GVAbjunctOne = ViewState["AttachmentBatch_Guid"].ToString(); //要改的　
        }
        //联系方式
        string LinkFashion = txtLinkFashion.Text.Trim();
        //总指挥
        string ZCompere = txtZCompere.Value.Trim();
        string[] ZCompere1 = ZCompere.Split(',');
        //副指挥
        string FCompere = txtFCompere.Value.Trim();
        string[] FCompere1 = FCompere.Split(',');
        //负责人
        string Principal = txtPrincipal.Value.Trim();
        string[] Principal1 = Principal.Split(',');
        //随卫人员
        string XGMan = txtXGMan.Value.Trim();
        string[] XGMan1 = XGMan.Split(',');

        int Length = ZCompere1.Length + FCompere1.Length + FCompere1.Length + XGMan1.Length;

        string[] InterSql = new string[Length + 1];

        //总指挥
        string ZCompereGUID = Guid.NewGuid().ToString();

        //副指挥
        string FCompereGUID = Guid.NewGuid().ToString();

        //负责人
        string PrincipalGUID = Guid.NewGuid().ToString();

        //相关人员
        string XGManGUID = Guid.NewGuid().ToString();

        string Archives = "";
        string Badge = "";
        string Gun = "";
        string Car = "";

        if (this.CheckBox1.Checked == true)
        {
            Archives = "1";
        }
        if (this.CheckBox2.Checked == true)
        {
            Badge = "1";
        }
        if (this.CheckBox3.Checked == true)
        {
            Gun = "1";
        }
        if (this.CheckBox4.Checked == true)
        {
            Car = "1";
        }

        InterSql[0] = "INSERT INTO SOrdCArrange(OrderArrange_Guid,Order_ID,DutyPlan,FromTime,FromTo,Order_locus,ReceiveUnit,Order_Calendar,work_Request," +
            " Abjunct,LinkFashion,ZCompere,FCompere,Principal,XGMan,Archives,Badge,Gun,Car,CreatedBy,CreatedDate,StatusId,Approve" +
            ")VALUES('" + Guid.NewGuid().ToString() + "','" + ViewState["Order_ID"].ToString() + "','" + type + "','" +
            timeFrom + "','" + timeTo + "','" + Order_locus + "','" + ReceiveUnit + "','" +
            Order_Calendar + "','" + work_Request + "','" + GVAbjunctOne + "','" + LinkFashion + "','" + ZCompereGUID + "','" + FCompereGUID + "','" +
            PrincipalGUID + "','" + XGManGUID + "','" + Archives + "','" + Badge + "','" + Gun + "','" + Car + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),0,0)";

        for (int i = 1; i <= ZCompere1.Length; i++)
        {
            InterSql[i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + ZCompereGUID + "','" + ZCompere1[i - 1] + "')";
        }

        for (int i = 0; i < FCompere1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + FCompereGUID + "','" + FCompere1[i] + "')";
        }

        for (int i = 0; i < Principal1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + FCompereGUID + "','" + Principal1[i] + "')";
        }

        for (int i = 0; i < XGMan1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + Principal1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + XGManGUID + "','" + XGMan1[i] + "')";
        }
     
     
        try
        {
            if (db.runTransaction(InterSql))
            {
                return "保存成功";
            }
            else
            {
                return "保存失败";
            }
        }
        catch (Exception er)
        {
            return er.Message;
        }
    }

    //枪支等的领取
    private string SaveAP1()
    {
        //分别到各自的表中查找对应的勤务号码有没有记录　有就保存其ID号
        return "";
    }

    //勤务修改
    private string EditAP()
    {
        //string type = "";
        //if (ViewState["type"].ToString() == "1")
        //{
        //    type = "随卫勤务";
        //}
        //else if (ViewState["type"].ToString() == "2")
        //{
        //    type = "现场勤务";
        //}
        //else if (ViewState["type"].ToString() == "3")
        //{
        //    type = "住地勤务";
        //}
       

        //日期时间从  
        if (txtFromFTime.Text == "")
        {
            txtFromFTime.Text = "00";
        }
        string timeFrom = txtFromRTime.Text + " " + drpFromSTime.SelectedValue + ":" + txtFromFTime.Text + ":00";
        //日期时间到  
        if (txtToFTime.Text == "")
        {
            txtToFTime.Text = "00";
        }
        string timeTo = txtToRTime.Text + " " + drpToSTime.SelectedValue + ":" + txtToFTime.Text + ":00";
        //勤务地点
        string Order_locus = txtOrder_locus.Text.Trim();
        //接待单位
        string ReceiveUnit = txtReceiveUnit.Text.Trim();
        //活动日程
        string Order_Calendar = txtOrder_Calendar.Text.Trim();
        //工作要求
        string work_Request = txtwork_Request.Text.Trim();
        //附件：AAA
        string GVAbjunctOne = "";
        if (ViewState["AttachmentBatch_Guid"] == null || ViewState["AttachmentBatch_Guid"].ToString() == "")
        {

        }
        else
        {
            GVAbjunctOne = ViewState["AttachmentBatch_Guid"].ToString(); //要改的　
        }
        //联系方式
        string LinkFashion = txtLinkFashion.Text.Trim();
        //总指挥
        string ZCompere = txtZCompere.Value.Trim();
        string[] ZCompere1 = ZCompere.Split(',');
        //副指挥
        string FCompere = txtFCompere.Value.Trim();
        string[] FCompere1 = FCompere.Split(',');
        //负责人
        string Principal = txtPrincipal.Value.Trim();
        string[] Principal1 = Principal.Split(',');
        //随卫人员
        string XGMan = txtXGMan.Value.Trim();
        string[] XGMan1 = XGMan.Split(',');


        int Length = ZCompere1.Length + FCompere1.Length + FCompere1.Length + XGMan1.Length;

        string[] InterSql = new string[Length + 1];

        //总指挥
        string ZCompereGUID = Guid.NewGuid().ToString();

        //副指挥
        string FCompereGUID = Guid.NewGuid().ToString();

        //负责人
        string PrincipalGUID = Guid.NewGuid().ToString();

        //相关人员
        string XGManGUID = Guid.NewGuid().ToString();

        string Archives = "";
        string Badge = "";
        string Gun = "";
        string Car = "";

        if (this.CheckBox1.Checked == true)
        {
            Archives = "1";
        }
        if (this.CheckBox2.Checked == true)
        {
            Badge = "1";
        }
        if (this.CheckBox3.Checked == true)
        {
            Gun = "1";
        }
        if (this.CheckBox4.Checked == true)
        {
            Car = "1";
        }

        InterSql[0] = "UPDATE SOrdCArrange set  [FromTime] = '" + timeFrom + "',[FromTo] = '" + timeTo + "', [Order_locus] = '" + Order_locus +
                       "',[ReceiveUnit] = '" + ReceiveUnit + "',[Order_Calendar] = '" + Order_Calendar + "',[work_Request] = '" +
                         work_Request + "',[Abjunct] = '" + GVAbjunctOne + "', [ZCompere] = '" + ZCompereGUID + "', [FCompere] = '" + FCompereGUID + "', [Principal] = '" +
                         PrincipalGUID + "',[XGMan] = '" + XGManGUID + "',[Archives] = '" + Archives + "',[Badge] = '" + Badge + "', [Gun] = '" + Gun + "',Car = '" + 
                         Car + "',[LinkFashion] = '" + LinkFashion + "',[ModifiedBy] = '" + ViewState["Satff_Id"].ToString() + "', [ModifiedDate] = getdate() " +
                          " WHERE Order_ID = '" + ViewState["Order_ID"].ToString() + "' and OrderArrange_Guid = '" + ViewState["OrderArrange_Guid"].ToString() + "'";



        for (int i = 1; i <= ZCompere1.Length; i++)
        {
            InterSql[i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + ZCompereGUID + "','" + ZCompere1[i - 1] + "')";
        }

        for (int i = 0; i < FCompere1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + FCompereGUID + "','" + FCompere1[i] + "')";
        }

        for (int i = 0; i < Principal1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + FCompereGUID + "','" + Principal1[i] + "')";
        }

        for (int i = 0; i < XGMan1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + Principal1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + XGManGUID + "','" + XGMan1[i] + "')";
        }
     
        try
        {
            if (db.runTransaction(InterSql))
            {
                return "保存成功";
            }
            return "保存失败";
        }
        catch (Exception er)
        {
            return er.Message;
        }


    }


    //根据勤务安排中的选择要操作的事项来显示按扭
    private void XSAP2Edit(string OrderArrange_Guid)
    {
        string SqlAP = "SELECT Archives, Badge, Gun, ReceiveUnit, Car " +
                         " FROM SOrdCArrange where Order_ID = '" + ViewState["Order_ID"].ToString() + "' and OrderArrange_Guid = '" + OrderArrange_Guid  + "'";
        try
        {
            DataRow SYRow = db.GetDataRow(SqlAP);

            if (SYRow[0].ToString() == "1")
            {
                this.Button1.Visible = true;
            }
            else
            {
                this.Button1.Visible = false;
            }

            if (SYRow[1].ToString() == "1")
            {
                this.Button2.Visible = true;
            }
            else
            {
                this.Button2.Visible = false;
            }

            if (SYRow[2].ToString() == "1")
            {
                this.Button3.Visible = true;
            }
            else
            {
                this.Button3.Visible = false;
            }

            if (SYRow[3].ToString() == "1")
            {
                this.Button4.Visible = true;
            }
            else
            {
                this.Button4.Visible = false;
            }


        }
        catch
        {
        }
    }


    //显示领导批示的页面，传进来勤务编号和批示的编号
    private void XSPS(string OrderArrange_Guid)
    {
        lblXS.Text = "";
        StringBuilder str = new StringBuilder();
        if (ViewState["Str"] == null || ViewState["Str"].ToString() == "")
        {

        }
        else
        {
            str.Append(ViewState["Str"].ToString());
        }

        string SqlPS = "select OrderNotion,PerNumber from SZOrdAuditing where Order_ID = '" +
                        ViewState["Order_ID"].ToString() + "'and OrderArrange_Guid = '" + OrderArrange_Guid + "'";
        DataRow PSRow = db.GetDataRow(SqlPS);
        str.Append("<tr> " +
                        "<td align=\"left\" colspan=\"6\" style=\"background-color: #ffcc99\"> 领导批示</td> " +
                     "</tr>" +
                       " <tr>" +
                           " <td align=\"right\" style=\"width: 13%\">意见：</td>" +
                           " <td Width=\"85%\" align=\"left\"  colspan=\"5\">" +
                               PSRow[0].ToString() +
                       " </tr>" +
                        "<tr>" +
                            "<td>" +
                            "</td>" +
                            " <td align=\"right\"  colspan=\"5\">" +
                               PSRow[1].ToString() +
                            "</td>    " +
                       " </tr>");
        ViewState["Str"] = str.ToString();
        lblXS.Text = str.ToString();

    }



    //领导同意批示保存
    private string EditTYPS(string OrderArrange_Guid)
    {
      
        string OrderNotion = txtOrderNotion.Text.Trim();  //领导意见


        string UpdateNotion = "UPDATE SZOrdAuditing set [OrderNotion] = '" + OrderNotion + "',[IsPer] = '1', PerNumber = '" +
            ViewState["Satff_Id"].ToString() + "', [CreatedBy] = '" + ViewState["Satff_Id"].ToString() + "',[CreatedDate] = getdate(), [ModifiedBy] = '" + ViewState["Satff_Id"].ToString() + "',[ModifiedDate] = getdate() WHERE Order_ID = '" + ViewState["Order_ID"].ToString() + "' and  OrderArrange_Guid = '" + OrderArrange_Guid + "'";
        try
        {
            db.executeUpdate(UpdateNotion);
            return "修改成功";
        }
        catch (Exception er)
        {
            return er.Message;
        }

    }

    //领导批示修改
    public void XGEditPS(string OrderArrange_Guid)
    {
        string SqlPS = "select OrderNotion  from SZOrdAuditing where Order_ID = '" + ViewState["Order_ID"].ToString() + "' and OrderArrange_Guid = '" + OrderArrange_Guid + "'";
        DataRow row = db.GetDataRow(SqlPS);
        txtOrderNotion.Text = row[0].ToString().Trim();

    }


    //领导同意批示保存
    private string SaveTYPS(string OrderArrange_Guid)
    {

        string[] Per = txt1.Value.Trim().Split(',');
        string[] Insert = new string[Per.Length + 1];  //定义保存数据库的数组
        string Per1 = Guid.NewGuid().ToString();

        Insert[0] = "insert into SZOrdAuditing(GUID,Order_ID,OrderArrange_Guid,Per,StatusId) " +
                            " values('" + Guid.NewGuid().ToString() + "','" + ViewState["Order_ID"].ToString() + "','" + OrderArrange_Guid + "','" + Per1 + "',0)";



        for (int i = 0; i < Per.Length; i++)
        {
            Insert[i + 1] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + Per1 + "','" + Per[i] + "')";
        }

        try
        {
            db.runTransaction(Insert);
            this.btnNext.Visible = false;
            return "下送成功";
         
          
        }
        catch (Exception er)
        {
            return "下送失败　" + er.Message;
        }
    }


    private string UpdatePSSatet()
    {
        string Update = "Update SZOrdAuditing set StatusId = '1'  where Order_ID = '" + ViewState["Order_ID"].ToString() + "' and OrderArrange_Guid = '" +
            ViewState["OrderArrange_Guid"].ToString() + "'";

        try
        {
            db.executeUpdate(Update);
            return "更新成功";

        }
        catch (Exception er)
        {
            return "更新失败　" + er.Message;
        }
    }

  

    #endregion


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

    private string GetMan(string GUIDMan)
    {
        string strMan = "select Man from SOrdArrangeMan where Guid = '" + GUIDMan + "'";  //找到该GUID对应的用户名称
        DataTable ManTable = db.GetDataTable(strMan);
        string Man = "";
        for (int i = 0; i < ManTable.Rows.Count; i++)
        {
            if (i != ManTable.Rows.Count - 1)
            {
                Man = Man + ManTable.Rows[i][0].ToString() + ",";
            }
            else
            {
                Man = Man + ManTable.Rows[i][0].ToString();
            }
        }

        return Man;

    }

    protected void dropOrderNotion_SelectedIndexChanged(object sender, EventArgs e)
    {

        this.txtOrderNotion.Text = dropOrderNotion.SelectedItem.Text.Trim();
    }

    //依据批次去查询
    private void XSFile(string AttachmentBatch_Guid)
    {
        string StrselectFile = "SELECT  max(AttachmentBatch_Guid) as AttachmentBatch_Guid, FileName,max (CreatedDate) as CreatedDate " +
            " FROM SSysAttachment where AttachmentBatch_Guid = '" + AttachmentBatch_Guid + "'  Group by FileName";

        DataTable AbjunctTable = db.GetDataTable(StrselectFile);
        GVAbjunct.DataSource = AbjunctTable;
        GVAbjunct.DataBind();
    }
    protected void GVAbjunct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        int i = e.RowIndex;
        GVAbjunct.Rows[i].Cells[0].Text = "√";             //将选定行标记成√
        string AttachmentBatch_Guid = GVAbjunct.Rows[i].Cells[1].Text.Trim();  //勤务编号
        string FileName = GVAbjunct.Rows[i].Cells[2].Text.Trim();  //名称
        string CreatedDate = GVAbjunct.Rows[i].Cells[3].Text.Trim();  //创建日期

        string selectSql = "select  replace(Folder  + SaveFileName, '/', '\\') from SSysAttachment where FileName = '" +
            FileName + "' and AttachmentBatch_Guid = '" + AttachmentBatch_Guid + "' Order by CreatedDate desc ";
        string FullFileName = db.GetDataScalar(selectSql);


      
       SetFileDownload(FullFileName, FileName);
    }


    /// <summary>
    /// 附件下载
    /// </summary>
    /// <param name="FullFileName">附件路径</param>
    /// <param name="FileName">要保存的文件名</param>
    public void SetFileDownload(string FullFileName, string FileName)
    {
        FileInfo DownloadFile = new FileInfo(FullFileName);
        Response.Clear();
        Response.ClearHeaders();
        Response.Buffer = false;
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8));
        Response.AppendHeader("Content-Length", DownloadFile.Length.ToString());
        Response.WriteFile(DownloadFile.FullName);
        Response.Flush();
        Response.End();
    }  

    protected void btnUp_Click(object sender, EventArgs e)
    {
        string AttachmentBatch_Guid = "";   //附件批次  一批附件一个批次
        if (ViewState["AttachmentBatch_Guid"] == null || ViewState["AttachmentBatch_Guid"].ToString() == "")
        {
            AttachmentBatch_Guid = Guid.NewGuid().ToString();
            ViewState["AttachmentBatch_Guid"] = AttachmentBatch_Guid;
        }
        else   //添多个附件或者在修改附件的情况下
        {
            AttachmentBatch_Guid = ViewState["AttachmentBatch_Guid"].ToString();
        }
        string Attachment_Guid = Guid.NewGuid().ToString();　　　//文件编号，一次一个


        string FileNameQ = FileTwo.PostedFile.FileName;  //注： loFile.PostedFile.FileName 返回的是通过文件对话框选择的文件名，
        //这之中包含了文件的目录信息
        FileNameQ = Path.GetFileName(FileNameQ);       //去掉目录信息，返回原文件名
        string[] FileNameQQ = FileNameQ.Split('.');
        string FileName = FileNameQQ[0].ToString();   //原文件名
        string ExtensionName = FileNameQQ[1].ToString().ToLower(); //原文件扩展名  转换成小写
        string SaveFileName = Attachment_Guid + '.' + ExtensionName;  //保存后的文件名

        //路径+当天日期的文件
        string Folder = "E://File/Order/DutyRegister/" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() +
            System.DateTime.Now.Day.ToString() + "/";  //路径


        if (Directory.Exists(Folder) == false)  //测试路径存不存在
        {
            Directory.CreateDirectory(Folder);  //创建路径 
        }

        string lstrFileNamePath = Folder + SaveFileName;
        //得到上传目录及文件名称
        FileTwo.PostedFile.SaveAs(lstrFileNamePath);
        //上传文件到服务器

        string Insert = "Insert into SSysAttachment(Attachment_Guid,AttachmentBatch_Guid,Folder,FileName,ExtensionName,SaveFileName, " +
             " CreatedBy,CreatedDate) values( '" + Attachment_Guid + "','" + AttachmentBatch_Guid + "','" + Folder + "','" + FileNameQQ + "','" +
             ExtensionName + "','" + SaveFileName + "','" + ViewState["Satff_Id"].ToString() + "',getdate())";



        try
        {
            db.executeInsert(Insert);
            WebWindow.alert("保存成功");
        }
        catch (Exception er)
        {
            WebWindow.alert("保存失败 " + er.Message.ToString());
        }
        // SSysAttachment

        //编码	Attachment_Guid	  一次一个新的
        //附件批次	AttachmentBatch_Guid	　　一批一个新的，修改也不变
        //文件目录	Folder	目录相同
        //原文件名	FileName	文件的不版本的该字段相同　比如第一次传的文件名为：abc　　修改后的也是　abc
        //原文件扩展名	ExtensionName		扩展名都是小写  doc/txt  传来的要转换成小写

        //保存的文件名	SaveFileName	Attachment_Guid+扩展名
        //创建者	CreatedBy	
        //创建日期	CreatedDate	　　同一文件的不同版本根据创建日期区分，最大日期为最新的
    }
}
