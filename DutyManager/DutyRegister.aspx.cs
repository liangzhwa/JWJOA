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

//AAA为以后还要修改的地方
public partial class Dutyregister : System.Web.UI.Page
{
    MDataBase db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
    static string Order_ID = "";   //全局的勤务编号
    static StringBuilder str;  //显示区域用来放动态的table
    static string sign = "";
    

    #region  page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
        Config Config = (Config)Session["Config"];
        string staff_Id = Config.Staff.Staff_Id;　//得到登录的用户名
     //   string staff_Id = "00000001";
        ViewState["Satff_Id"] = staff_Id;
        string Role = Config.LoginRole.ToString();  //得到登录角色

        string selectRole = db.GetDataScalar("SELECT Name FROM SSysRole WHERE (Role_Id = '" + Role + "')");     //根据传来的角色ID得到角色的名称

     //   string selectRole = "";  //办公室

        //如果前个页面传过来一个勤务编号,就直接将该编号付值给Order_ID,没有就生成一个新的
        #region 首次加载
        if (!this.IsPostBack)
        {
            if (Request.QueryString["Order_ID"] == null || Request.QueryString["Order_ID"].ToString() == "") //编码
            {
                Order_ID = "";
            }
            else
            {
                Order_ID = Request.QueryString["Order_ID"].ToString();
            }
            if (Request.QueryString["sign"] == null || Request.QueryString["sign"].ToString() == "") //标识
            {
                sign = "";
            }
            else
            {
                sign = Request.QueryString["sign"].ToString();
            }

            ControlDataBind drp = new ControlDataBind(ConfigurationManager.ConnectionStrings["OA"].ToString());
            drp.DropDownListBind(drpInceptMode, "SOrdInceptFashion", "FashionName", "FashionID", 1, "", staff_Id);
            drp.DropDownListBind(drpOrderSpec, "SOrdSpec", "SpecName", "SpecID", 1, "", staff_Id);
            drp.DropDownListBind(drpOrderSort, "SOrdSort", "SortName", "SortID", 1, "", staff_Id);
            drp.DropDownListBind(drpSecretDis, "SOrdSecret", "SecretName", "SecretID", 1, "", staff_Id);
            drp.DropDownListBind(dropOrderNotion, "SSFugleideaConfig", "IdeaContent", "IdeaID", 1, "", staff_Id);

            string StataeSql = "select StatusId from SOrdEstate where Order_ID = '" + Order_ID + "'";
            try
            {
                string state = db.GetDataScalar(StataeSql);
                if (state == "3")
                {
                    XSTable();　//如果勤务为取消，则只能查看，不能进行其他操作
                    PanelVisibleFalse();   //设置全部模板不可见
                    return;
                }
            }
            catch
            { }
        }
        #endregion

        if (Order_ID == "")
        {
            if (this.lblOrder_ID.Text == "")
            {
                #region 编辑勤务编号为空，就是首次登记的时候

                //获取今天的年+月+日
                string Day = System.DateTime.Today.Year.ToString() + System.DateTime.Today.Month.ToString() +
                    System.DateTime.Today.Day.ToString();

                //查找出数据库中该天勤务的最大的编号
                string Sql = "select top 1 Order_ID from SOrdEstate where Order_ID like '" + Day + "%' order by Order_ID desc";

                try
                {
                    Day = db.GetDataScalar(Sql);  //得到最大的ID
                    Order_ID = Convert.ToString(Convert.ToInt32(Day) + 1);   //在最大ID的基础上加1,确定本次勤务的编号，该编号贯彻真个程序
                }
                catch   //报错说明查不到值
                {
                    Order_ID = Convert.ToString(Convert.ToInt32(Day) + "001");
                }

                lblOrder_ID.Text = Order_ID;  //显示勤务编号  

                PanelVisibleFalse();   //设置全部模板不可见
                this.panelDJ.Visible = true;   //登记
                this.panelAN.Visible = true;   //按钮

                //电话登记的时候往流程表里写一条记录

                string Number = Guid.NewGuid().ToString();           //该步骤编号,要在保存里用到　
                ViewState["Number"] = Number;             //保存住这个值，在功能保存中要用到

                ViewState["PFunction"] = "1";            //新建的勤务默认为电话登记功能    
                string SY = "insert into SOrdFlow(OrderFlow_Guid,Order_ID,Number,PFunction,PExecute,CreatedBy,CreatedDate,OperateStep) " +
                    " values('" + Number + "','" + Order_ID + "','" + Number + "',1,'" + staff_Id + "','" + staff_Id + "',getdate(),1)";         //Insert语句
                try
                {
                    db.executeInsert(SY);
                }
                catch
                {
                }
                #endregion
            }
        }
        else 　 //说明不是新建的勤务
        {
            #region 勤务编号不为空
            //不显示勤务编号说明虽然不是新建的勤务，但是是第一次打开该勤务单
            //用来控制显示的页面
            if (lblOrder_ID.Text == "")   //新打开一个页面先不给勤务的textbox付值，付值后不让页面再加载数据
            {
                string OrderFlow_Guid = Guid.NewGuid().ToString();   //编号，随便生成一个新的　
                string Number = Guid.NewGuid().ToString();           //该步骤编号,要在保存里用到　
                ViewState["Number"] = Number;             //保存住这个值，在功能保存中要用到
                if (sign != "")   //值班室操作，前个页面传值
                {
                    ViewState["PFunction"] = sign;
                    PanelVisibleFalse();  //所有panel不可见 
                    if (sign == "1")   //修改首次电话登记
                    {
                        string GUID = "select GUID from SOrdEnrol where Order_ID = '" + Order_ID + "'";
                        this.panelDJ.Visible = true;  //电话登记可见
                        this.panelAN.Visible = true;

                        XGEditDJ(db.GetDataScalar(GUID));

                    }
                    else if (sign == "2")　　//补充电话登记
                    {
                        panelXS.Visible = true;   //用来显示的panel可见
                        this.panelDJ.Visible = true;  //电话登记可见
                        this.panelAN.Visible = true;
                        string SY = "insert into SOrdFlow(OrderFlow_Guid,Order_ID,Number,PFunction,PExecute,CreatedBy,CreatedDate,OperateStep) " +
                         " values('" + OrderFlow_Guid + "','" + Order_ID + "','" + Number + "',1,'" + staff_Id + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),2)";
                        try
                        {
                            db.executeInsert(SY);
                            Label1.Visible = false;
                            txtOrder_Name.Visible = false;
                            Label2.Visible = false;
                            drpOrderSpec.Visible = false;
                            Label3.Visible = false;
                            drpOrderSort.Visible = false;
                            Label4.Visible = false;
                            drpSecretDis.Visible = false;

                        }
                        catch
                        {

                        }

                        XSTable();　//设置上面显示的table//只显示到下送过的，如果保存没有下送的不显示
                        this.btnNext.Visible = false;
                    }
                    else if (sign == "3")　　//勤务中接到电话登记
                    {
                        panelXS.Visible = true;   //用来显示的panel可见
                        this.panelLD.Visible = true;  //接到电话登记可见
                        this.panelAN.Visible = true;
                        string SY = "insert into SOrdFlow(OrderFlow_Guid,Order_ID,Number,PFunction,PExecute,CreatedBy,CreatedDate,OperateStep) " +
                       " values('" + OrderFlow_Guid + "','" + Order_ID + "','" + Number + "',6,'" + ViewState["Satff_Id"].ToString() + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),2)";
                        try
                        {
                            db.executeInsert(SY);
                        }
                        catch
                        {
                        }

                        XSTable();　//设置上面显示的table//只显示到下送过的，如果保存没有下送的不显示
                        this.btnNext.Visible = false;
                    }
                    else if (sign == "4")　　//勤务完成去电登记
                    {
                        panelXS.Visible = true;   //用来显示的panel可见
                        this.panelQD.Visible = true;  //去电话登记可见
                        this.panelAN.Visible = true;
                        string SY = "insert into SOrdFlow(OrderFlow_Guid,Order_ID,Number,PFunction,PExecute,CreatedBy,CreatedDate,OperateStep) " +
                       " values('" + OrderFlow_Guid + "','" + Order_ID + "','" + Number + "',7,'" + ViewState["Satff_Id"].ToString() + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),2)";
                        try
                        {
                            db.executeInsert(SY);
                        }
                        catch { }

                        XSTable();　//设置上面显示的table//只显示到下送过的，如果保存没有下送的不显示
                        this.btnNext.Visible = false;
                    }
                    else if (sign == "5")　　//修改勤务地点
                    {
                        panelXS.Visible = true;   //用来显示的panel可见
                        this.panelXG.Visible = true;  //修改勤务地点登记可见
                        this.panelAN.Visible = true;
                        string SY = "insert into SOrdFlow(OrderFlow_Guid,Order_ID,Number,PFunction,PExecute,CreatedBy,CreatedDate,OperateStep) " +
                        " values('" + OrderFlow_Guid + "','" + Order_ID + "','" + Number + "',8,'" + ViewState["Satff_Id"].ToString() + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),2)";
                        try
                        {
                            db.executeInsert(SY);
                        }
                        catch { }
                        XSTable();　//设置上面显示的table//只显示到下送过的，如果保存没有下送的不显示\
                        this.btnNext.Visible = false;
                    }
                    else if (sign == "6")　　//显示查看
                    {
                        panelXS.Visible = true;   //用来显示的panel可见

                        XSTable();　//设置上面显示的table//只显示到下送过的，如果保存没有下送的不显示
                    }

                    //显示操作的页面
                }
                else
                {
                    PanelVisibleFalse();  //所有panel不可见

                    EditPanel();　　　//其他人员操作调用方法

                    if (selectRole != "办公室" || (ViewState["XS"] != null && ViewState["XS"].ToString() == "TRUE"))   //如果角色是办公室或者办公室还没有对来电记录进行审批
                    {
                        panelXS.Visible = true;   //用来显示的panel可见
                        XSTable();　//设置上面显示的table//只显示到下送过的，如果保存没有下送的不显示
                    }

                    btnZCompere.Attributes.Add("onclick", "PopWindow1();");
                    btnFCompere.Attributes.Add("onclick", "PopWindow2();");
                    btnSWPrincipal.Attributes.Add("onclick", "PopWindow3();");
                    btnSWMan.Attributes.Add("onclick", "PopWindow4();");

                    btnXCPrincipal.Attributes.Add("onclick", "PopWindow1();");
                    btnXCMan.Attributes.Add("onclick", "PopWindow2();");
                    btnZDPrincipal.Attributes.Add("onclick", "PopWindow3();");
                    btnZDMan.Attributes.Add("onclick", "PopWindow4();");

                }
                lblOrder_ID.Text = Order_ID;  //显示勤务编号  

            }
            #endregion
        }


        txtZCompere.Value = hfStaffId1.Value.TrimEnd(',');
        txtFCompere.Value = hfStaffId2.Value.TrimEnd(',');
        txtSWPrincipal.Value = hfStaffId3.Value.TrimEnd(',');
        txtSWMan.Value = hfStaffId4.Value.TrimEnd(',');
        txtXCPrincipal.Value = hfStaffId5.Value.TrimEnd(',');
        txtXCMan.Value = hfStaffId6.Value.TrimEnd(',');
        txtZDPrincipal.Value = hfStaffId7.Value.TrimEnd(',');
        txtZDMan.Value = hfStaffId8.Value.TrimEnd(',');


    }

    #endregion

    #region panel隐藏
    private void PanelVisibleFalse()
    {
        this.panelAN.Visible = false;   //按钮
        this.panelLD.Visible = false;   //来电记录
        this.panelQD.Visible = false;   //去电登记
        this.panelXG.Visible = false;   //勤务地点修改
        this.panelXS.Visible = false;   //显示区域

        this.panelAP.Visible = false;   //勤务安排
        this.panelDJ.Visible = false;   //登记  
        this.panelPS.Visible = false;   //领导批示
        this.panelSY.Visible = false;   //办公室审阅
        
    }
    #endregion 

    #region button隐藏

    private void ButtonVisible()
    {
        this.Button1.Visible = false;
        this.Button2.Visible = false;
        this.Button3.Visible = false;
        this.Button4.Visible = false;
        this.Button5.Visible = false;
        this.Button6.Visible = false;
        this.Button7.Visible = false;
    }

    #endregion

    #region 根据数据库的记录显示不可修改的table

    private void XSTable()
    {
        str = new StringBuilder();
        lblXS.Text = "";
       
        //按日期排序，查找出当前状态为已完成的勤务流程各步骤的功能类型,功能记录的GUID
        string XSSql = "select PFunction,Number,NFunction from SOrdFlow where Order_ID = '" + Order_ID
                + "' AND OperateStep = '2' order by CreatedDate";
       
        DataTable XSTable = db.GetDataTable(XSSql);

         str.Append("<table width=\"100%\">");   //定义表开始
       
         for (int i = 0; i < XSTable.Rows.Count; i++)   //表共有多少条记录
         {
             if (XSTable.Rows[i][0].ToString() == "1")   //电话登记
             {
                 XSDJ(XSTable.Rows[i][1].ToString());
             }
             else if (XSTable.Rows[i][0].ToString() == "2")  //办公室审阅
             {
                 XSSY(XSTable.Rows[i][1].ToString());
             }
             else if (XSTable.Rows[i][0].ToString() == "3")  //领导批示
             {
                 XSPS(XSTable.Rows[i][1].ToString());
             }
             else if (XSTable.Rows[i][0].ToString() == "4")  //勤务安排
             {
                 XSAP(XSTable.Rows[i][1].ToString());
                 XSAP2(XSTable.Rows[i][1].ToString());
             }
             else if (XSTable.Rows[i][0].ToString() == "5")  //勤务安排2
             {
                 XSAP1(XSTable.Rows[i][1].ToString());
             }
             else if (XSTable.Rows[i][0].ToString() == "6")  //来电登记
             {
                 XSLD(XSTable.Rows[i][1].ToString());
             }
             else if (XSTable.Rows[i][0].ToString() == "7")  //去电登记
             {
                 XSQD(XSTable.Rows[i][1].ToString());
             }
          
         }

         str.Append("</table>");      //定义表结束

         lblXS.Text = str.ToString();  
    }

    //显示电话登记的页面,传进来勤务编号和电话登记的GUID
    private void XSDJ(string GUID)
    {
         //查找勤务名称
        string SqlName = "select Order_Name from SOrdEstate where Order_ID = '" + Order_ID + "'";  
        string Order_Name = db.GetDataScalar(SqlName);

        string SqlOrderEnrol = "select Order_TelTime,FashionName ,SpecName,SortName,SecretName,TelCom,TelMeet, TelUnit,MostlyContent,Abjunct " +
                               " from SOrdEnrol left join SOrdInceptFashion on SOrdEnrol.InceptMode = SOrdInceptFashion.FashionID" +
                               " left join SOrdSpec on SOrdEnrol.OrderSpec = SOrdSpec.SpecID" +
                               " left join SOrdSort on SOrdEnrol.OrderSort = SOrdSort.SortID" +
                               " left join SOrdSecret on SOrdEnrol.SecretDis = SOrdSecret.SecretID" +
                               " where Order_ID = '" + Order_ID + "' and GUID = '" + GUID + "'";

        try
        {
            DataRow OrderEnrolRow = db.GetDataRow(SqlOrderEnrol);  //查找内容

            #region 完成table的拼接

            str.Append("<tr>" +
                            "<td colspan=\"6\"  align=\"left\" style=\"background-color: #ffcc99\">来电登记</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td align=\"right\" style=\"width: 20%\">来电时间：</td>" +
                            "<td colspan=\"3\"  width=\"40%\" align=\"left\" >" +  //来电时间
                                  OrderEnrolRow[0].ToString() +
                                "<td align=\"right\" style=\"width: 20%\">接收方式：</td>" +
                                "<td align=\"left\"  width=\"26%\" align=\"left\">" + //接收方式
                                   OrderEnrolRow[1].ToString() +
                                "</td>" +
                        "</tr>");
                        if(Order_Name != "")
                        {
                              str.Append("<tr>" +
                                 "<td align=\"right\" style=\"width: 20%\">勤务名称：</td>" +
                               " <td width=\"75%\" colspan=\"5\" align=\"left\">" + Order_Name + 　//勤务名称   
                               "</td>" +
                            "</tr>" );
                         }
                        if(OrderEnrolRow[2].ToString() != null && OrderEnrolRow[3].ToString() != null && OrderEnrolRow[4].ToString() != null)
                        {
                            str.Append("<tr>" +
                             "<td align=\"right\" style=\"width: 20%\">勤务规格：</td>" +
                            "<td style=\"width: 16%\" align=\"left\">" +  //勤务规格
                                 OrderEnrolRow[2].ToString() +
                             "</td>" +
                             "<td align=\"right\" style=\"width: 21%\">勤务类别：</td>" +
                            "<td width=\"16%\" align=\"left\">" + //勤务类别
                                  OrderEnrolRow[3].ToString() +
                            "</td>" +
                            "<td align=\"right\" style=\"width: 17%\">密级：</td>" +
                            "<td width=\"16%\" align=\"left\">" +  //密级
                                  OrderEnrolRow[4].ToString() +
                            "</td>" +
                        "</tr>");
                        }

                        str.Append("<tr>" +
                            "<td align=\"right\" style=\"width: 20%\">来电人：</td>" +
                            "<td align=\"left\" style=\"width: 16%\">" + //来电人
                                OrderEnrolRow[5].ToString() +
                            "</td>" +
                            "<td align=\"right\" style=\"width: 21%\">接电人：</td>" +
                            "<td align=\"left\" width=\"16%\">" +      //接电人
                                OrderEnrolRow[6].ToString() +
                            "</td>" +
                            "<td align=\"right\" style=\"width: 17%\"></td>" +
                            "<td align=\"right\" width=\"16%\"></td>" +
                        "</tr>" +
                         "<tr>" +
                             "<td align=\"right\" style=\"width: 20%; height: 11px;\">来电单位：</td>" +
                            "<td width=\"75%\" colspan=\"5\" style=\"height: 11px\"  align=\"left\" >" +   //来电单位
                                OrderEnrolRow[7].ToString() +
                              "</td>" +
                        "</tr>" +
                          "<tr>" +
                             "<td align=\"right\" style=\"width: 20%; height: 34px;\">主要内容：</td>" +
                            "<td width=\"75%\" colspan=\"5\" style=\"height: 34px\"  align=\"left\" >" + //主要内容
                                OrderEnrolRow[8].ToString() +
                              "</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td align=\"right\">附件：</td>" +
                            "<td colspan=\"5\">");

                        str.Append("<iframe  style=\"overflow: auto; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 550px; height: 120px;\"   src = \"Abjunct.aspx?AttachmentBatch_Guid='" + OrderEnrolRow[9].ToString() + "'\"></iframe>");
                   

            str.Append("</td></tr>");

            #endregion
        }
        catch
        {
        }

      
    }

   

    //显示办公室审阅的页面,传进来勤务编号和电话登记的GUID
    private void XSSY(string GUID)
    {
        string SqlSY = "select Personnel from SOrdEnrol where Order_ID = '" + Order_ID + "' and GUID = '" + GUID + "'";
        string StrSY = db.GetDataScalar(SqlSY);
        str.Append("<tr>"  +
                   "<td colspan=\"6\"  align=\"left\" style=\"background-color: #ffcc99\">办公室审阅</td>" +
                   "</tr><tr>" +
                    "<td colspan=\"3\"></td>" +
                    "<td colspan=\"3\" align=\"right\">" +
                       StrSY +       //办公室审批人员的签名
                    "</td></tr>");

    }



    //显示领导批示的页面，传进来勤务编号和批示的编号
    private void XSPS(string GUID)
    {
        string SqlPS = "select OrderNotion,PerNumber from SOrdAuditing where Order_ID = '" + Order_ID + "' and GUID = '" + GUID + "'";
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
    }

    //显示勤务安排的页面，传进来勤务编号和勤务安排的编号
    private void XSAP(string GUID)
    {
        string SqlAP = "SELECT FromTime, FromTo, Order_locus, ReceiveUnit, Order_Calendar, work_Request," +
                         " Abjunct, LinkFashion,ZCompere, FCompere, SWPrincipal, SWMan, XCPrincipal, " +
                         " XCMan,ZDPrincipal,  ZDMan,  Archives, Badge, Gun, Car " +
                         " FROM SOrdZArrange where Order_ID = '" + Order_ID + "' and GUID = '" + GUID  + "'";   //113
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
                       GetMan(SYRow[8].ToString())  +//总指挥
                 "</td>" +
                   "<td align=\"right\">副指挥：</td>" +
                   "<td align=\"left\" colspan=\"2\">" +
                       GetMan(SYRow[9].ToString()) +//副指挥
                 "</td></tr>" +
               "<tr>" +
                  "<td align=\"right\">  随卫负责人：</td>" +
                  "<td align=\"left\" colspan=\"2\">" +
                      GetMan(SYRow[10].ToString()) + //随卫负责人
                 "</td>" +
                 "<td align=\"right\">随卫人员：</td>" +
                "<td align=\"left\" colspan=\"2\">" +
                     GetMan(SYRow[11].ToString()) +//随卫人员
                 "</td></tr>" +
               "<tr>" +
                   "<td align=\"right\"> 现场负责人：</td>" +
                 "<td align=\"left\" colspan=\"2\">" +
                     GetMan(SYRow[12].ToString()) +//现场负责人
                 "</td>" +
                   "<td align=\"right\"> 现场人员：</td>" +
                  "<td align=\"left\" colspan=\"2\">" +
                       GetMan(SYRow[13].ToString()) +//现场人员
                 "</td>" +
             "</tr>" +
                "<tr>" +
                   "<td align=\"right\"> 住地负责人：</td>" +
                 "<td align=\"left\" colspan=\"2\">" +
                       GetMan(SYRow[14].ToString()) + //住地负责人
                 "</td>" +
                  "<td align=\"right\"> 住地人员：</td>" +
                  "<td align=\"left\" colspan=\"2\">" +
                     GetMan(SYRow[15].ToString()) +//住地人员
                 "</td></tr>");
    }

  

    //显示勤务安排的页面，传进来勤务编号和勤务安排的编号
    private void XSAP1(string GUID)
    {
        string SqlAP = "SELECT FromTime, FromTo, Order_locus, ReceiveUnit, Order_Calendar, work_Request," +
                         " Abjunct, LinkFashion,ZCompere, FCompere, SWPrincipal, SWMan, XCPrincipal, ZDPrincipal, " +
                         " XCMan, ZDMan,  Archives, Badge, Gun, Car " +
                         " FROM SOrdZArrange where Order_ID = '" + Order_ID + "' and GUID = '" + GUID + "'";   //113
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

            str.Append("</td></tr><tr>" +
               "<td align=\"right\">随卫勤务安排：</td>" +
                "<td colspan=\"5\" align=\"left\">");

            string StrZArrange1 = "select OrderArrange_Guid,Order_ID,Name as CreatedBy  from SOrdCArrange left join SSysStaff on " +
          " SOrdCArrange.CreatedBy = SSysStaff.Staff_Id where Order_ID = '" + Order_ID + "' and DutyPlan = '随卫勤务'";  //得到该勤务下的子勤务的类别和编号

            DataTable ZArrangeTable1 = db.GetDataTable(StrZArrange1);

            str.Append("<tr>");
                str.Append("<td>");
                    str.Append("编号");
                str.Append("</td>");

                str.Append("<td>");
                    str.Append("创建人");
                str.Append("</td>");

                str.Append("<td>");
                    str.Append("链接");
                str.Append("</td>");              
            for (int i = 0; i < ZArrangeTable1.Rows.Count; i++)
            {
                str.Append("<td>");
                    str.Append(ZArrangeTable1.Rows[i][0]);
                str.Append("</td>");


                str.Append("<td>");
                    str.Append(ZArrangeTable1.Rows[i][2]);
                str.Append("</td>");


                str.Append("<td>");
                str.Append("<a href href=\"DutyArrange.aspx?Order_ID='" + Order_ID + "'&type=1&OrderArrange_Guid='" + ZArrangeTable1.Rows[i][0].ToString() + "'></a>");
                str.Append("</td>");
            }
            str.Append("</tr>");

            str.Append("随卫勤务安排的链接");

            str.Append("</td></tr><tr>" +
              "<td align=\"right\">现场勤务安排：</td>" +
               "<td colspan=\"5\" align=\"left\">");



            string StrZArrange2 = "select OrderArrange_Guid,Order_ID,Name as CreatedBy  from SOrdCArrange left join SSysStaff on " +
              " SOrdCArrange.CreatedBy = SSysStaff.Staff_Id where Order_ID = '" + Order_ID + "' and DutyPlan = '现场勤务'";  //得到该勤务下的子勤务的类别和编号

            DataTable ZArrangeTable2 = db.GetDataTable(StrZArrange1);

            str.Append("<tr>");
            str.Append("<td>");
            str.Append("编号");
            str.Append("</td>");

            str.Append("<td>");
            str.Append("创建人");
            str.Append("</td>");

            str.Append("<td>");
            str.Append("链接");
            str.Append("</td>");
            for (int i = 0; i < ZArrangeTable2.Rows.Count; i++)
            {
                str.Append("<td>");
                str.Append(ZArrangeTable2.Rows[i][0]);
                str.Append("</td>");


                str.Append("<td>");
                str.Append(ZArrangeTable2.Rows[i][2]);
                str.Append("</td>");


                str.Append("<td>");
                str.Append("<a href href=\"DutyArrange.aspx?Order_ID='" + Order_ID + "'&type=2&OrderArrange_Guid='" + ZArrangeTable2.Rows[i][0].ToString() + "'></a>");
                str.Append("</td>");
            }
            str.Append("</tr>");


            str.Append("现场勤务安排的链接");

            str.Append("</td></tr><tr>" +
                    "<td align=\"right\">住地勤务安排：</td>" +
                     "<td colspan=\"5\" align=\"left\">");



            string StrZArrange3 = "select OrderArrange_Guid,Order_ID,Name as CreatedBy  from SOrdCArrange left join SSysStaff on " +
           " SOrdCArrange.CreatedBy = SSysStaff.Staff_Id where Order_ID = '" + Order_ID + "' and DutyPlan = '住地勤务'";  //得到该勤务下的子勤务的类别和编号

            DataTable ZArrangeTable3 = db.GetDataTable(StrZArrange1);

            str.Append("<tr>");
            str.Append("<td>");
            str.Append("编号");
            str.Append("</td>");

            str.Append("<td>");
            str.Append("创建人");
            str.Append("</td>");

            str.Append("<td>");
            str.Append("链接");
            str.Append("</td>");
            for (int i = 0; i < ZArrangeTable3.Rows.Count; i++)
            {
                str.Append("<td>");
                str.Append(ZArrangeTable3.Rows[i][0]);
                str.Append("</td>");


                str.Append("<td>");
                str.Append(ZArrangeTable3.Rows[i][2]);
                str.Append("</td>");


                str.Append("<td>");
                str.Append("<a href href=\"DutyArrange.aspx?Order_ID='" + Order_ID + "'&type=3&OrderArrange_Guid='" + ZArrangeTable3.Rows[i][0].ToString() + "'></a>");
                str.Append("</td>");
            }
            str.Append("</tr>");


            str.Append("住地勤务安排的链接");

            str.Append("</td></tr>");
        }
        catch
        {
        }
    }

    //显示勤务安排的页面，显示勾选的信息
    private void XSAP2(string GUID)
    {
        string SqlAP = "SELECT Archives, Badge, Gun, ReceiveUnit, Car, SWOrder,XCOrder,ZDOrder" +
                         " FROM SOrdZArrange where Order_ID = '" + Order_ID + "' and GUID = '" + GUID + "'";   //113
        try
        {
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

            if (SYRow[4].ToString() == "1")
            {
                str.Append("</td></tr><tr>" +
                   "<td align=\"right\">随卫勤务安排</td>" +
                    "<td colspan=\"5\" align=\"left\">");

            }


            if (SYRow[5].ToString() == "1")
            {
                str.Append("</td></tr><tr>" +
                  "<td align=\"right\">现场勤务安排</td>" +
                   "<td colspan=\"5\" align=\"left\">");

            }

            if (SYRow[5].ToString() == "6")
            {

                str.Append("</td></tr><tr>" +
                        "<td align=\"right\">住地勤务安排</td>" +
                         "<td colspan=\"5\" align=\"left\">");

            }

            str.Append("</td></tr>");
        }
        catch
        {
        }
    }

    //显示来电登记的页面，传进来勤务编号和来电话的编号
    private void XSLD(string GUID)
    {
        string SqlLD = "select LTelName,JTelName,LTelAddress,LTNumber,LTime,Circs from SOrdLTel where Order_ID = '" + 
            Order_ID + "' and JTel_Guid ='" + GUID + "'";
        try
        {
            DataRow LDRow = db.GetDataRow(SqlLD);

            str.Append("<tr>" +
                            "<td colspan=\"6\" align=\"left\" style=\"background-color: #ffcc99\">来电记录</td>" +
                        "</tr>" +
                            "<tr>" +
                                "<td align=\"right\" style=\"width: 15%\">来电人：</td>" +
                                 "<td align=\"left\" style=\"width: 35%\" colspan=\"2\">" +
                                   LDRow[0].ToString() +
                                     "</td>" +
                                "<td align=\"right\" style=\"width: 15%\"> 来电号码：</td>" +
                                "<td align=\"left\" style=\"width: 35%\" colspan=\"2\">" +
                                  LDRow[3].ToString() +
                                "</td>" +
                             "</tr>" +
                             "<tr>" +
                                  "<td align=\"right\" style=\"width: 15%\">接电人： </td>" +
                                 "<td colspan=\"2\">" +
                                    LDRow[1].ToString() +
                                 "</td>" +
                               "<td align=\"right\" style=\"width: 15%\">来电时间： </td>" +
                                 "<td align=\"left\" style=\"width: 35%\" colspan=\"2\">" +
                                  LDRow[4].ToString() +
                                 " </td>" +
                              "</tr>" +
                                "<tr>" +
                                 "<td align=\"right\" style=\"width: 15%\"> 情况：</td>" +
                                 " <td align=\"left\" style=\"width: 85%\" colspan=\"5\">" +
                                     LDRow[5].ToString() +
                                 " </td>" +
                             "</tr>" +
                              "<tr>" +
                                  "<td align=\"right\" style=\"height: 26px\"> 来电地址：</td>" +
                                  "<td align=\"left\" colspan=\"5\" style=\"height: 26px\">" +
                                  LDRow[2].ToString() +
                                " </td> " +
                         " </tr>");
        }
        catch
        {
        }
    }

    //显示去电登记的页面，传进来勤务编号和去电话的编号
    private void XSQD(string GUID)
    {
        string SqlQD = "select QTelName,JTelName,Number,Time,Circs from SOrdQTel where Order_ID ='" +
                     Order_ID + "' and QTel_Guid ='" + GUID + "'";

        try
        {
            DataRow QDRow = db.GetDataRow(SqlQD);

            str.Append("<tr>" +
                                "<td colspan=\"4\" align=\"left\" style=\"background-color: #ffcc99\">去电记录</td>" +
                            "</tr>" +
                                "<tr>" +
                                    "<td align=\"right\" style=\"width: 15%\">去电人： </td>" +
                                     "<td align=\"left\" style=\"width: 35%\">" +
                                           QDRow[0].ToString() +
                                       "</td>" +
                                    "<td align=\"right\" style=\"width: 15%\">接电人：</td>" +
                                   " <td align=\"left\" style=\"width: 36%\">" +
                                      QDRow[1].ToString() +
                                    "</td>" +
                                " </tr>" +
                                 "<tr>" +

                                     "<td align=\"right\" style=\"width: 15%\"> 去电时间：</td>" +
                                     "<td align=\"left\" style=\"width: 35%\" colspan=\"3\">" +
                                         QDRow[3].ToString() +
                                      " </td>" +
                                 "</tr>" +
                                 "<tr>" +
                                     " <td align=\"right\" style=\"width: 15%\"> 情况：</td>" +
                                      "<td align=\"left\" style=\"width: 85%\" colspan=\"3\">" +
                                         QDRow[4].ToString() +
                                         " </td>" +
                                 "</tr>");
        }
        catch
        {

        }
    }



    #endregion

    #region  显示要编辑的panel

    private void EditPanel()
    { 
        //查找没有下送时的修改情况
        string XSSqlOne = "SELECT top 1 Number, PFunction, PExecute FROM SOrdFlow WHERE (Order_ID = '" + Order_ID +
            "') AND (OperateStep = '1') order by CreatedDate DESC";
  
        DataRow XSRowOne = db.GetDataRow(XSSqlOne);
        string staff_Id = ViewState["Satff_Id"].ToString();   //登录人的编号

        if (XSRowOne != null)
        {
            //修改保存但是没有下送的信息
            //权限验证 
            XSRowOne[2].ToString();　　　//操作人的编号

            if (XSRowOne[2].ToString().Trim() != staff_Id || XSRowOne[1].ToString().Trim() == "1")
            {
                ViewState["XS"] = "TRUE";
                return;
            }

            ViewState["PFunction"] = XSRowOne[1].ToString();   //为当前步骤（没有下送前的修改情况）
            if (XSRowOne[1].ToString() == "1")          //电话登记
            {
                PanelVisibleFalse();
                this.panelDJ.Visible = true;
                this.panelAN.Visible = true;   //按钮
                XGEditDJ(XSRowOne[0].ToString());
                return;
            }
            else if (XSRowOne[1].ToString() == "2")　　　//办公室审阅
            {
                PanelVisibleFalse();
                this.panelDJ.Visible = true;
                this.panelSY.Visible = true;
                this.panelAN.Visible = true;   //按钮

                XGEditDJ(XSRowOne[0].ToString());
                return;
            }
            else if (XSRowOne[1].ToString() == "3")　　　　//领导批示
            {
                PanelVisibleFalse();
                this.panelPS.Visible = true;
                this.panelAN.Visible = true;   //按钮
                btnSave.Visible = false;
                XGEditPS(XSRowOne[0].ToString());
                return;
            }
            else if (XSRowOne[1].ToString() == "4")　　　//勤务安排
            {
                PanelVisibleFalse();
                this.panelAP.Visible = true;
                this.panelAP1.Visible = true;
                this.panelAN.Visible = true;   //按钮
                ButtonVisible();
                XGEditAP(XSRowOne[0].ToString());

                return;
            }
            else if (XSRowOne[1].ToString() == "5")　　　//勤务安排
            {
                PanelVisibleFalse();
                this.panelAP1.Visible = true;
                this.panelAN.Visible = true;   //按钮
                btnNext.Visible = false;  //下送按扭不能用
                XSAP2Edit();
                //查找有多少已经安排的子勤务
                FindZArrange();
                return;
            }
        }
      
        #region

        string OrderFlow_Guid = Guid.NewGuid().ToString();   //编号，随便生成一个新的　
        //string Number = Guid.NewGuid().ToString();           //该步骤编号,要在保存里用到　
        //ViewState["Number"] = Number;             //保存住这个值，在功能保存中要用到
        string PFunction = "";                    //该步骤的功能
       
        string SY = "";                           //Insert语句


        //查找下步执行功能和下步执行人,标记是已经完成
        string XSSql = "select  top 1 NFunction,NExecute from SOrdFlow where Order_ID = '" + Order_ID +
            "' and OperateStep = '2' and (NExecute <> '' or NExecute <> null) order by CreatedDate DESC";
        DataRow XSRow = db.GetDataRow(XSSql);
        //XSRow[1].ToString()为上步指派的操作人员
        //判断该操作人员是不是属于上步指派的操作人员,如果不是退出AAA


        //查找该人员编号在不在上步指定的人员编号中，在可以查看该步功能，否则只能查看已经做过的功能
        string strYZ = "select Count(*) from ( " +
                    " select top 1 * from SOrdFlow  where Order_ID = '" + Order_ID + "' and OperateStep = '2' Order by SOrdFlow.CreatedDate Desc)  as SOrdFlow " +
                   " left join SOrdArrangeMan on SOrdFlow.NExecute = SOrdArrangeMan.Guid   where  Man  = '" + staff_Id + "'";

        string YZ = db.GetDataScalar(strYZ);


        if (XSRow[0].ToString() == "5")  //如果是勤务分配的功能阶段
        {
            string staffOne = "select distinct Order_ID from SordFlow where PExecute = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                " UNION " +
                                 "select distinct Order_ID from SOrdFlow  left join SOrdArrangeMan on SOrdFlow.NExecute = SOrdArrangeMan.Guid where  Man  = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                  " UNION " +
                                 " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.ZCompere = SOrdArrangeMan.Guid where Man  = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                  " UNION " +
                                 " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.FCompere = SOrdArrangeMan.Guid where Man  = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                  " UNION " +
                                 " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.SWPrincipal = SOrdArrangeMan.Guid where Man = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                  " UNION " +
                                 " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.SWMan = SOrdArrangeMan.Guid where Man = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                  " UNION " +
                                 " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.XCPrincipal = SOrdArrangeMan.Guid where Man = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                  " UNION " +
                                 " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.ZDPrincipal = SOrdArrangeMan.Guid where Man  = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                  " UNION " +
                                 " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.XCMan = SOrdArrangeMan.Guid where Man  = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                  " UNION " +
                                 " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.ZDMan = SOrdArrangeMan.Guid where Man  = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                  " UNION " +
                                 " select distinct Order_ID from SOrdCArrange left join SOrdArrangeMan on SOrdCArrange.ZCompere = SOrdArrangeMan.Guid where Man  = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                  " UNION " +
                                 " select distinct Order_ID from SOrdCArrange left join SOrdArrangeMan on SOrdCArrange.Principal = SOrdArrangeMan.Guid where Man  = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                  " UNION " +
                                 " select distinct Order_ID from SOrdCArrange left join SOrdArrangeMan on SOrdCArrange.FCompere = SOrdArrangeMan.Guid where Man  = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID + "'" +
                                  " UNION " +
                                 " select distinct Order_ID from SOrdCArrange left join SOrdArrangeMan on SOrdCArrange.XGMan = SOrdArrangeMan.Guid where Man  = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + Order_ID +"'";


            DataTable OrderTable = db.GetDataTable(staffOne);
            if (OrderTable.Rows.Count == 0)
            {
                ViewState["XS"] = "TRUE";
                return;
            }

        }
        else
        {

            if (YZ == "0")
            {
                ViewState["XS"] = "TRUE";
                return;
            }
        }



        ViewState["PFunction"] = XSRow[0].ToString();   //为当前步骤（没有下送前的新增情况）
        if (XSRow[0].ToString() == "2")　　　//办公室审阅
        {
            //电话登记部分的显示,办公室是可以修改的   AAA
            panelDJ.Visible = true;
            panelSY.Visible = true;
            XGEditDJ("");     //办公室人员操作时要能对值班室登记的信息进行修改
            //往流程表SOrdFlow里加一条记录,写进去　编号OrderFlow_Guid 勤务编号Order_ID 
            //该步骤编号Number　该步骤的功能PFunction　　该步骤执行人员PExecute
            PFunction = "2";
            SY = "insert into SOrdFlow(OrderFlow_Guid,Order_ID,Number,PFunction,PExecute,CreatedBy,CreatedDate,OperateStep) " +
                " values('" + OrderFlow_Guid + "','" + Order_ID + "','" + ViewState["Number"].ToString() + "','" + PFunction + "','" + ViewState["Satff_Id"].ToString() + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),1)";
            db.executeInsert(SY);
            this.panelAN.Visible = true;   //按钮
            return;
        }
        else if (XSRow[0].ToString() == "3")　　　　//领导批示
        {
            //权限判断　AAA
            panelPS.Visible = true;
            btnSave.Visible = false;
            PFunction = "3";
            SY = "insert into SOrdFlow(OrderFlow_Guid,Order_ID,Number,PFunction,PExecute,CreatedBy,CreatedDate,OperateStep) " +
                " values('" + OrderFlow_Guid + "','" + Order_ID + "','" + ViewState["Number"].ToString() + "','" + PFunction + "','" + ViewState["Satff_Id"].ToString() + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),1)";
            db.executeInsert(SY);
            this.panelAN.Visible = true;   //按钮
            return;
        }
        else if (XSRow[0].ToString() == "4")　　　//勤务分配
        {
            //权限判断　AAA
            panelAP.Visible = true;
            panelAP1.Visible = true;
            PFunction = "4";
            SY = "insert into SOrdFlow(OrderFlow_Guid,Order_ID,Number,PFunction,PExecute,CreatedBy,CreatedDate,OperateStep) " +
                " values('" + OrderFlow_Guid + "','" + Order_ID + "','" + ViewState["Number"].ToString() + "','" + PFunction + "','" + ViewState["Satff_Id"].ToString() + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),1)";
            db.executeInsert(SY);
            ButtonVisible();
            this.panelAN.Visible = true;   //按钮
            return;
        }
        else if (XSRow[0].ToString() == "5")　　　//勤务安排
        {
            //权限判断　AAA
            panelAP1.Visible = true;
            PFunction = "5";
            SY = "insert into SOrdFlow(OrderFlow_Guid,Order_ID,Number,PFunction,PExecute,CreatedBy,CreatedDate,OperateStep) " +
                " values('" + OrderFlow_Guid + "','" + Order_ID + "','" + ViewState["Number"].ToString() + "','" + PFunction + "','" + ViewState["Satff_Id"].ToString() + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),2)";
            db.executeInsert(SY);
            this.panelAN.Visible = false;   //按钮
            this.btnSave.Visible = true;
            XSAP2Edit();
            //查找有多少已经安排的子勤务
            FindZArrange();

            return;
        }

        #endregion

       
    }

    public void XGEditAP(string GUID)   //勤务安排
    {
        string SqlAP = "SELECT FromTime, FromTo, Order_locus, ReceiveUnit, Order_Calendar, work_Request," +
                        " Abjunct, LinkFashion,ZCompere, FCompere, SWPrincipal, SWMan, XCPrincipal, XCMan,ZDPrincipal, " +
                        "  ZDMan,GUID,Archives,Badge,Gun,Car,SWOrder,XCOrder,ZDOrder  FROM SOrdZArrange where Order_ID = '" + Order_ID + "' and GUID = '" + GUID + "'";   //113
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

    
            //附件：AAA
            XSFile(APRow[6].ToString(), GVAbjunctTwo);

            //联系方式
            string LinkFashion = APRow[6].ToString();
            txtLinkFashion.Text = LinkFashion;
            //总指挥
            string ZCompere = APRow[8].ToString();
            txtZCompere.Value = GetMan(ZCompere);

            //副指挥
            string FCompere = APRow[9].ToString();
            txtFCompere.Value = GetMan(FCompere); 

            //随卫负责人
            string SWPrincipal = APRow[10].ToString();
            txtSWPrincipal.Value = GetMan(SWPrincipal); 

            //随卫人员
            string SWMan = APRow[11].ToString();
            txtSWMan.Value = GetMan(SWMan); 

            //现场负责人
            string XCPrincipal = APRow[12].ToString();
            btnXCPrincipal.Value = GetMan(XCPrincipal);

            //现场人员
            string XCMa = APRow[13].ToString();
            txtXCMan.Value = GetMan(XCMa); 

            //住地负责人
            string ZDPrincipal = APRow[14].ToString();
            txtZDPrincipal.Value = GetMan(ZDPrincipal);

            //住地人员
            string ZDMan = APRow[15].ToString();
            txtZDMan.Value = GetMan(ZDMan);


            if (APRow[17].ToString().Trim() == "1")
            {
                this.CheckBox1.Checked = true;
            }
            else
            {
                this.CheckBox1.Checked = false;
            }
            if (APRow[18].ToString().Trim() == "1")
            {
                this.CheckBox2.Checked = true;
            }
            else
            {
                this.CheckBox2.Checked = false;
            }
            if (APRow[19].ToString().Trim() == "1")
            {
                this.CheckBox3.Checked = true;
            }
            else
            {
                this.CheckBox3.Checked = false;
            }
            if (APRow[20].ToString().Trim() == "1")
            {
                this.CheckBox4.Checked = true;
            }
            else
            {
                this.CheckBox4.Checked = false;
            }
            if (APRow[21].ToString().Trim() == "1")
            {
                this.CheckBox5.Checked = true;
            }
            else
            {
                this.CheckBox5.Checked = false;
            }
            if (APRow[22].ToString().Trim() == "1")
            {
                this.CheckBox6.Checked = true;
            }
            else
            {
                this.CheckBox6.Checked = false;
            }
            if (APRow[23].ToString().Trim() == "1")
            {
                this.CheckBox7.Checked = true;
            }
            else
            {
                this.CheckBox7.Checked = false;
            }

            if (ViewState["Number"] == null || ViewState["Number"].ToString() == "")
            {
                ViewState["Number"] = APRow[16].ToString().Trim();
            }

        }
        catch
        {

        }


        


    }
  
    //显示电话登记的页面,传进来勤务编号和电话登记的GUID
    private void XGEditDJ(string GUID)
    {
        //查找勤务名称
        string SqlName = "select Order_Name from SOrdEstate where Order_ID = '" + Order_ID + "'";
        string Order_Name = db.GetDataScalar(SqlName);
        string SqlOrderEnrol = "";
        if (GUID == "")
        {
            SqlOrderEnrol = "select top 1 Order_TelTime,FashionName ,OrderSpec,OrderSort,SecretDis,TelCom,TelMeet, TelUnit,MostlyContent,GUID,InceptMode,Abjunct " +
                                   " from SOrdEnrol left join SOrdInceptFashion on SOrdEnrol.InceptMode = SOrdInceptFashion.FashionID" +
                                   " left join SOrdSpec on SOrdEnrol.OrderSpec = SOrdSpec.SpecID" +
                                   " left join SOrdSort on SOrdEnrol.OrderSort = SOrdSort.SortID" +
                                   " left join SOrdSecret on SOrdEnrol.SecretDis = SOrdSecret.SecretID" +
                                   " where Order_ID = '" + Order_ID + "' order by CreatedDate";
        }
        else
        {
            SqlOrderEnrol = "select top 1 Order_TelTime,FashionName ,OrderSpec,OrderSort,SecretDis,TelCom,TelMeet, TelUnit,MostlyContent,GUID,InceptMode,Abjunct " +
                                   " from SOrdEnrol left join SOrdInceptFashion on SOrdEnrol.InceptMode = SOrdInceptFashion.FashionID" +
                                   " left join SOrdSpec on SOrdEnrol.OrderSpec = SOrdSpec.SpecID" +
                                   " left join SOrdSort on SOrdEnrol.OrderSort = SOrdSort.SortID" +
                                   " left join SOrdSecret on SOrdEnrol.SecretDis = SOrdSecret.SecretID" +
                                   " where Order_ID = '" + Order_ID + "' and GUID = '" + GUID + "' order by CreatedDate";
        }

        DataRow OrderEnrolRow = db.GetDataRow(SqlOrderEnrol);  //查找内容

        #region 读取数据库表中电话登记数据

        //来电时间   2008-01-04 08:28:14.000
        string time = OrderEnrolRow[0].ToString();

        txtTelRTime.Text = GetDate(time);
        drpTelSTime.SelectedItem.Text = GetHour(time);
        txtTelFTime.Text = GetMinute(time);


        //接收方式  
        drpInceptMode.SelectedValue = OrderEnrolRow[10].ToString();

        //勤务名称
        txtOrder_Name.Text = Order_Name;

        //勤务规格
        drpOrderSpec.SelectedValue = OrderEnrolRow[2].ToString();


        //勤务类别
        drpOrderSort.SelectedValue = OrderEnrolRow[3].ToString();

        //密级
        drpSecretDis.SelectedValue = OrderEnrolRow[4].ToString();

        //来电人
        txtTelCom.Text = OrderEnrolRow[5].ToString();

        //接电人
        txtTelMeet.Text = OrderEnrolRow[6].ToString();

        //来电单位
        txtTelUnit.Text = OrderEnrolRow[7].ToString();

        //主要内容
        txtMostlyContent.Text = OrderEnrolRow[8].ToString();

        //附件：AAA
        XSFile(OrderEnrolRow[10].ToString(), GVAbjunctOne);
        
        if (ViewState["Number"] == null || ViewState["Number"].ToString() == "")
        {
            ViewState["Number"] = OrderEnrolRow[9].ToString();
        }
        #endregion

    }

    //领导批示修改
    public void XGEditPS(string GUID)    
    {
        string SqlPS = "select OrderNotion,GUID  from SOrdAuditing where Order_ID = '" + Order_ID + "' and GUID = '" + GUID + "'"; 
        DataRow row = db.GetDataRow(SqlPS);
        txtOrderNotion.Text = row[0].ToString().Trim();
        ViewState["Number"] = row[1].ToString().Trim();
       
    }
   

    #endregion 

    #region 保存的细节
    //值班室电话登记保存
    private string SaveDJ()
    {
        string GUID = "";  
        if(ViewState["Number"] != null && ViewState["Number"].ToString() != "")   //得到前面生成的GUID
        {
            GUID = ViewState["Number"].ToString();  
        }
        //来电时间  
        if (txtTelFTime.Text == "")
        {
            txtTelFTime.Text = "00";
        }
        string time = txtTelRTime.Text + " " + drpTelSTime.SelectedValue + ":" + txtTelFTime.Text + ":00";
        //接收方式  
        string InceptMode = drpInceptMode.SelectedIndex.ToString();
        //勤务名称
        string Order_Name = txtOrder_Name.Text.Trim();
        //勤务规格
        string OrderSpec = drpOrderSpec.SelectedIndex.ToString();
        //勤务类别
        string OrderSort = drpOrderSort.SelectedIndex.ToString();
        //密级
        string SecretDis = drpSecretDis.SelectedIndex.ToString();
        //来电人
        string TelCom = txtTelCom.Text.Trim();
        //接电人
        string TelMeet = txtTelMeet.Text.Trim();

        //来电单位
        string TelUnit = txtTelUnit.Text.Trim();

        //主要内容
        string MostlyContent = txtMostlyContent.Text.Trim();

        //附件：AAA
     
        string GVAbjunctOne = "";
        if (ViewState["AttachmentBatch_Guid"] == null || ViewState["AttachmentBatch_Guid"].ToString() == "")
        {

        }
        else
        {
            GVAbjunctOne = ViewState["AttachmentBatch_Guid"].ToString(); //要改的　
        }

        //验证
        try
        {
            Convert.ToDateTime(time);
        }
        catch
        {
            return "日期的格式不正确,请重新输入";
        }

        if (InceptMode == "")
        {
            return "请选择接收方式";
        }
        //if (Order_Name == "")
        //{
        //    return  "请输入勤务名称";
        //}
        //if (OrderSpec == "")
        //{
        //    return "请选择勤务规格";
        //}
        //if (OrderSort == "")
        //{
        //    return "请选择勤务类别";
        //}
        //if (SecretDis == "")
        //{
        //    return "请选择密级";
        //}
        if (TelCom == "")
        {
            return "请输入来电人";
        }
        if (TelMeet == "")
        {
            return "请输入接电人";
        }
        if (TelUnit == "")
        {
            return "请输入来电单位";
        }
       

        if(db.GetDataTable("select * from SOrdEstate where Order_ID = '" + Order_ID + "'").Rows.Count  == 0)   //如果主表没有记录
        {
            string ZInsert = "Insert into SOrdEstate(Order_ID,Order_Name,CreatedBy,CreatedDate,Operator,OperatorMan,StatusId) values('" + Order_ID + "','" +
                   Order_Name + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),'" + ViewState["Satff_Id"].ToString() + "',1,1)";

            db.executeInsert(ZInsert);
        }
        

        string InsertDJ =  "insert into SOrdEnrol(GUID,Order_ID,Order_TelTime,InceptMode,OrderSpec," +
                "OrderSort,SecretDis,TelCom,TelMeet,TelUnit,MostlyContent,Abjunct,CreatedBy,CreatedDate,Note_ID)" +
                "values('" + GUID + "','" + Order_ID + "','" + time + "','" + InceptMode + "','" + OrderSpec + "','" + OrderSort + "','" +
                SecretDis + "','" + TelCom + "','" + TelMeet + "','" + TelUnit + "','" + MostlyContent + "','" + GVAbjunctOne + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),0)";
        try
        {
            db.executeInsert(InsertDJ);
            return "保存成功";
        }
        catch (Exception er)
        {
            return er.Message;
        }

        string Sql = "Update SOrdEstate set Operator = '3',OperatorMan = '" + ViewState["Satff_Id"].ToString() + "' where Order_ID = '" + Order_ID + "'";
        try
        {
            db.executeUpdate(Sql);  
        }
        catch (Exception er)
        {
            return er.Message;
        }

    }

    //办公室保存
    private string SaveSY()
    {
        string GUID = "";
        if (ViewState["Number"] != null && ViewState["Number"].ToString() != "")   //得到前面生成的GUID
        {
            GUID = ViewState["Number"].ToString();
        }


        string selectSql = "select top 1 Order_TelTime,InceptMode,OrderSpec,OrderSort,SecretDis,TelCom,TelMeet,TelUnit," +
            " MostlyContent,Abjunct from SOrdEnrol where Order_ID = '" + Order_ID + "' order by CreatedDate";
        DataRow selectRow = db.GetDataRow(selectSql);

        string selectName = "select Order_Name from SOrdEstate where Order_ID = '" + Order_ID  + "'";
        string OrderName = db.GetDataScalar(selectName);
      
        //来电时间  
        if (txtTelFTime.Text == "")
        {
            txtTelFTime.Text = "00";
        }
        string time = txtTelRTime.Text + " " + drpTelSTime.SelectedValue + ":" + txtTelFTime.Text + ":00";
        //接收方式  
        string InceptMode = drpInceptMode.SelectedItem.Value.ToString();
        //勤务名称
        string Order_Name = txtOrder_Name.Text.Trim();
        //勤务规格
        string OrderSpec = drpOrderSpec.SelectedItem.Value.ToString();
        //勤务类别
        string OrderSort = drpOrderSort.SelectedItem.Value.ToString();
        //密级
        string SecretDis = drpSecretDis.SelectedItem.Value.ToString();
        //来电人
        string TelCom = txtTelCom.Text.Trim();
        //接电人
        string TelMeet = txtTelMeet.Text.Trim();

        //来电单位
        string TelUnit = txtTelUnit.Text.Trim();

        //主要内容
        string MostlyContent = txtMostlyContent.Text.Trim();

        //附件：AAA
     
        string GVAbjunctOne = "";
        if (ViewState["AttachmentBatch_Guid"] == null || ViewState["AttachmentBatch_Guid"].ToString() == "")
        {

        }
        else
        {
            GVAbjunctOne = ViewState["AttachmentBatch_Guid"].ToString(); //要改的　
        }

        //验证
        try
        {
            Convert.ToDateTime(time);
        }
        catch
        {
            return "日期的格式不正确,请重新输入";
        }

        if (InceptMode == "")
        {
            return "请选择接收方式";
        }
        if (Order_Name == "")
        {
            return "请输入勤务名称";
        }
        if (OrderSpec == "")
        {
            return "请选择勤务规格";
        }
        if (OrderSort == "")
        {
            return "请选择勤务类别";
        }
        if (SecretDis == "")
        {
            return "请选择密级";
        }
        if (TelCom == "")
        {
            return "请输入来电人";
        }
        if (TelMeet == "")
        {
            return "请输入接电人";
        }
        if (TelUnit == "")
        {
            return "请输入来电单位";
        }
       
        
       

        if ( OrderName != Order_Name 　　　　　　　            //对比勤务名称是否一致
            || (selectRow[1].ToString() != InceptMode &&   InceptMode!= "-1")         //对比接收方式是否一致
            || (selectRow[2].ToString() != OrderSpec   &&   OrderSpec!= "-1")              //对比勤务规格是否一致
            || (selectRow[3].ToString() != OrderSort    &&   OrderSort!= "-1")             //对比勤务类别是否一致
            || (selectRow[4].ToString() != SecretDis    &&   SecretDis!= "-1")             //对比秘级是否一致
            || selectRow[5].ToString() != TelCom                //对比来电人是否一致
            || selectRow[6].ToString() != TelMeet               //对比接电人是否一致
            || selectRow[7].ToString() != TelUnit               //对比来电单位是否一致
            || selectRow[8].ToString() != MostlyContent         //对比主要内容是否一致
          )          //对比附件是否一致  || selectRow[9].ToString() != GVAbjunctOne
        {
         
                string InsertDJ = "";

                if (ViewState["QZ"] != null && ViewState["QZ"].ToString() != "" && ViewState["QZ"].ToString() == "True")
                {
                    InsertDJ = "insert into SOrdEnrol(GUID,Order_ID,Order_TelTime,InceptMode,OrderSpec," +
                           "OrderSort,SecretDis,TelCom,TelMeet,TelUnit,MostlyContent,Abjunct,Personnel,CreatedBy,CreatedDate,Note_ID)" +
                           "values('" + GUID + "','" + Order_ID + "','" + time + "','" + InceptMode + "','" + OrderSpec + "','" + OrderSort + "','" +
                           SecretDis + "','" + TelCom + "','" + TelMeet + "','" + TelUnit + "','" + MostlyContent + "','" + GVAbjunctOne + "','" + ViewState["Satff_Id"].ToString() + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),1)";

                    ViewState["QZ"] = "";
                }
                else
                {
                    InsertDJ = "insert into SOrdEnrol(GUID,Order_ID,Order_TelTime,InceptMode,OrderSpec," +
                          "OrderSort,SecretDis,TelCom,TelMeet,TelUnit,MostlyContent,Abjunct,CreatedBy,CreatedDate,Note_ID)" +
                          "values('" + GUID + "','" + Order_ID + "','" + time + "','" + InceptMode + "','" + OrderSpec + "','" + OrderSort + "','" +
                          SecretDis + "','" + TelCom + "','" + TelMeet + "','" + TelUnit + "','" + MostlyContent + "','" + GVAbjunctOne + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),1)";

                }


                try
                {
                    db.executeInsert(InsertDJ);
                    return "保存成功";
                }
                catch (Exception er)
                {
                    return er.Message;
                }

        }
        else
        {
            //只要点保存就默认同意
            string UpdateDJ = "Update SOrdEnrol set Personnel = '" + ViewState["Satff_Id"].ToString() + "' where Order_Id = '" + Order_ID + "'";   //更新签名
            try
            {
                db.executeUpdate(UpdateDJ);
                GUID = db.GetDataScalar("select GUID from SOrdEnrol  where Order_Id = '" + Order_ID + "'");
                string Update = "Update  SOrdFlow set Number = '" + GUID + "' where Order_ID = '" + Order_ID + "' and operateStep = '1'";
                db.executeUpdate(Update);
                ViewState["Number"] = GUID;   //如果没有更新要把原来的编号付值回去
                return "审批成功";
            }
            catch (Exception er)
            {
                return er.Message;
            }
            
        
            
        }


        string Sql = "Update SOrdEstate set Operator = '3',OperatorMan = '" + ViewState["Satff_Id"].ToString() + "' where Order_ID = '" + Order_ID + "'";
        try
        {
            db.executeUpdate(Sql); 
        }
        catch (Exception er)
        {
            return er.Message;
        }

       
        return "无更新";

    }
    
    //领导同意批示保存
    private string SaveTYPS()
    {
        string GUID = "";
        if (ViewState["Number"] != null && ViewState["Number"].ToString() != "")   //得到前面生成的GUID
        {
            GUID = ViewState["Number"].ToString();
        }

        string OrderNotion = txtOrderNotion.Text.Trim();  //领导意见
     


        string[] Insert = new string[2];

        if (db.GetDataScalar("select count(*) from SOrdAuditing where Order_ID = '" + Order_ID + "' and GUID = '" + GUID + "'") == "0")
        {
            Insert[0] = "insert into SOrdAuditing(GUID,Order_ID,OrderNotion,PerNumber,IsPer,CreatedBy,CreatedDate,StatusId) " +
                                " values('" + GUID + "','" + Order_ID + "','" + OrderNotion + "','" + ViewState["Satff_Id"].ToString() + "',1,'" + ViewState["Satff_Id"].ToString() + "',getdate(),0)";
        }
        else
        {
            Insert[0] = "UPDATE SOrdAuditing set [OrderNotion] = '" + OrderNotion + "',[IsPer] = ''," +
            " [ModifiedBy] = '" + ViewState["Satff_Id"].ToString() + "',[ModifiedDate] = getdate() WHERE Order_ID = '" + Order_ID + "' and  GUID = '" + GUID + "'";
        }

        Insert[1] = "Update SOrdEstate set Operator = '3',OperatorMan = '" + ViewState["Satff_Id"].ToString() + "' where Order_ID = '" + Order_ID + "'";
        try
        {
            if (db.runTransaction(Insert))
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

    //领导不同意批示保存
    private string SaveBTYPS()
    {
        string GUID = "";
        if (ViewState["Number"] != null && ViewState["Number"].ToString() != "")   //得到前面生成的GUID
        {
            GUID = ViewState["Number"].ToString();
        }

        string OrderNotion = txtOrderNotion.Text.Trim();  //领导意见

     
        string[] Insert = new string[2];
        Insert[0] =  "insert into SOrdAuditing(GUID,Order_ID,OrderNotion,PerNumber,IsPer,CreatedBy,CreatedDate,StatusId) " +
                            " values('" + GUID + "','" + Order_ID + "','" + OrderNotion + "','" + ViewState["Satff_Id"].ToString() + "',1,'" + ViewState["Satff_Id"].ToString() + "',getdate(),0)";


        Insert[1] = "Update SOrdEstate set Operator = '3',OperatorMan = '" + ViewState["Satff_Id"].ToString() + "' where Order_ID = '" + Order_ID + "'";
        try
        {
            if (db.runTransaction(Insert))
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


    //勤务安排
    private string SaveAP()
    {
        string GUID = "";  
        if(ViewState["Number"] != null && ViewState["Number"].ToString() != "")   //得到前面生成的GUID
        {
            GUID = ViewState["Number"].ToString();  
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
        //附件
        string Abjunct = "";
        if (ViewState["AttachmentBatch_Guid"] == null || ViewState["AttachmentBatch_Guid"].ToString() == "")
        {

        }
        else
        {
            Abjunct = ViewState["AttachmentBatch_Guid"].ToString(); //要改的　
        }
        //联系方式
        string LinkFashion = txtLinkFashion.Text.Trim();
        //总指挥
        string ZCompere = txtZCompere.Value.Trim();
        string[] ZCompere1 = ZCompere.Split(',');
        //副指挥
        string FCompere = txtFCompere.Value.Trim();
        string[] FCompere1 = FCompere.Split(',');
        //随卫负责人
        string SWPrincipal = txtSWPrincipal.Value.Trim();
        string[] SWPrincipal1 = SWPrincipal.Split(',');
        //随卫人员
        string SWMan = txtSWMan.Value.Trim();
        string[] SWMan1 = SWMan.Split(',');
        //现场负责人
        string XCPrincipal = txtXCPrincipal.Value.Trim();
        string[] XCPrincipal1 = XCPrincipal.Split(',');
        //现场人员
        string XCMa = txtXCMan.Value.Trim();
        string[] XCMa1 = XCMa.Split(',');
        //住地负责人
        string ZDPrincipal = txtZDPrincipal.Value.Trim();
        string[] ZDPrincipal1 = ZDPrincipal.Split(',');
        //住地人员
        string ZDMan = txtZDMan.Value.Trim();
        string[] ZDMan1 = ZDMan.Split(',');

        int Length = ZCompere1.Length + FCompere1.Length + SWPrincipal1.Length + SWMan1.Length + XCPrincipal1.Length +
            XCMa1.Length + ZDPrincipal1.Length + ZDMan1.Length;

        string[] InterSql = new string[Length + 2];


        //总指挥
        string ZCompereGUID = Guid.NewGuid().ToString();
    
        //副指挥
        string FCompereGUID = Guid.NewGuid().ToString();
 
        //随卫负责人
        string SWPrincipalGUID = Guid.NewGuid().ToString();
    
        //随卫人员
        string SWManGUID = Guid.NewGuid().ToString();
 
        //现场负责人
        string XCPrincipalGUID = Guid.NewGuid().ToString();

        //现场人员
        string XCMaGUID = Guid.NewGuid().ToString();
   
        //住地负责人
        string ZDPrincipalGUID = Guid.NewGuid().ToString();
    
        //住地人员
        string ZDManGUID = Guid.NewGuid().ToString();

        string Archives = "";
        string Badge = "";
        string Gun = "";
        string Car = "";
        string SWOrder = "";
        string XCOrder = "";
        string ZDOrder = "";


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
        if (this.CheckBox5.Checked == true)
        {
            SWOrder = "1";
        }
        if (this.CheckBox6.Checked == true)
        {
            XCOrder = "1";
        }
        if (this.CheckBox7.Checked == true)
        {
            ZDOrder = "1";
        }

    


        InterSql[0] = "INSERT INTO SOrdZArrange(GUID,Order_ID,FromTime,FromTo,Order_locus,ReceiveUnit,Order_Calendar,work_Request," +
            " Abjunct,LinkFashion,ZCompere,FCompere,SWPrincipal,SWMan,XCPrincipal,ZDPrincipal,XCMan,ZDMan,Archives,Badge,Gun,Car,SWOrder,XCOrder,ZDOrder,CreatedBy,CreatedDate,StatusId,Approve" +
            ")VALUES('" + GUID　+ "','" + Order_ID　+ "','" + timeFrom + "','" + timeTo + "','" + Order_locus + "','" + ReceiveUnit + "','" +
            Order_Calendar + "','" + work_Request + "','" + Abjunct + "','" + LinkFashion + "','" + ZCompereGUID + "','" + FCompereGUID + "','" +
            SWPrincipalGUID + "','" + SWManGUID + "','" + XCPrincipalGUID + "','" + XCMaGUID + "','" + ZDPrincipalGUID + "','" + ZDManGUID + "','" + Archives + "','" + Badge + "','" + Gun + "','" + Car + "','" + SWOrder + "','" + XCOrder + "','" + ZDOrder  + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),0,0)";

        for (int i = 1; i <= ZCompere1.Length; i++)
        {
            InterSql[i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + ZCompereGUID + "','" + ZCompere1[i - 1] + "')";
        }

        for (int i = 0; i < FCompere1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + FCompereGUID + "','" + FCompere1[i] + "')";
        }

        for (int i = 0; i < SWPrincipal1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + SWPrincipalGUID + "','" + SWPrincipal1[i] + "')";
        }

        for (int i = 0; i < SWMan1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + SWPrincipal1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + SWManGUID + "','" + SWMan1[i] + "')";
        }
        for (int i = 0; i < XCPrincipal1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + SWPrincipal1.Length + SWMan1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + XCPrincipalGUID + "','" + XCPrincipal1[i] + "')";
        }

        for (int i = 0; i < XCMa1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + SWPrincipal1.Length + SWMan1.Length + XCPrincipal1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + XCMaGUID + "','" + XCMa1[i] + "')";
        }
        for (int i = 0; i < ZDPrincipal1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + SWPrincipal1.Length + SWMan1.Length + XCPrincipal1.Length + XCMa1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + ZDPrincipalGUID + "','" + ZDPrincipal1[i] + "')";
        }
        for (int i = 0; i < ZDPrincipal1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + SWPrincipal1.Length + SWMan1.Length + XCPrincipal1.Length + XCMa1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + ZDPrincipalGUID + "','" + ZDPrincipal1[i] + "')";
        }

        for (int i = 0; i < ZDMan1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + SWPrincipal1.Length + SWMan1.Length + XCPrincipal1.Length + XCMa1.Length + ZDPrincipal1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + ZDManGUID + "','" + ZDMan1[i][i] + "')";
        }


        InterSql[InterSql.Length - 1] = "Update SOrdEstate set StatusId = 1,Operator = '4',OperatorMan = '" + ViewState["Satff_Id"].ToString() + "' where Order_ID = '" + Order_ID + "'";
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

    //来电登记
    private string SaveLD()
    {
        string GUID = "";
        if (ViewState["Number"] != null && ViewState["Number"].ToString() != "")   //得到前面生成的GUID
        {
            GUID = ViewState["Number"].ToString();
        }

        string LTelName = txtLTelName.Text.Trim();  //来电人
        string LTNumber = txtLTNumber.Text.Trim();  //来电号码：
        string JTelName = txtJTelName.Text.Trim();  //接电人：
        string time = txtLTelTime.Text + " " + DropDownList8.SelectedValue + ":" + TextBox32.Text + ":00";   //来电时间
        string Circs = txtCircs.Text.Trim();        //情况
        string Address = txtAddress.Text.Trim();    //来电地址 


        try
        {
            Convert.ToDateTime(time);
        }
        catch
        {
            return "来电时间请输入日期型";
        }
        string[] Insert = new string[2];
        Insert[0] = "INSERT INTO SOrdLTel ( [JTel_Guid] ,[Order_ID] ,[LTelName] ,[JTelName] ,[LTelAddress] ,[LTNumber] ,[LTime] ," +
                        "[Circs] ,[CreatedBy] ,[CreatedDate]) VALUES " +
                        " ('" + GUID + "','" + Order_ID + "','" + LTelName + "','" + JTelName + "','" + Address + "','" +
                        LTNumber + "','" + time + "','" + Circs + "','" + ViewState["Satff_Id"].ToString() + "',getdate())";

        Insert[1] = "Update SOrdEstate set StatusId = 2,Operator = '6',OperatorMan = '" + ViewState["Satff_Id"].ToString() + "' where Order_ID = '" + Order_ID + "'";
        try
        {
            if (db.runTransaction(Insert))
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

    //去电登记
    private string SaveQD()
    {
        string GUID = "";
        if (ViewState["Number"] != null && ViewState["Number"].ToString() != "")   //得到前面生成的GUID
        {
            GUID = ViewState["Number"].ToString();
        }
        string QTelName = txtQTelName.Text.Trim();  //去电人
        string DJTelName = txtDJTelName.Text.Trim();　　//接电人
        string time = txtQTelTime.Text + " " + DropDownList9.SelectedValue + ":" + TextBox35.Text + ":00";   //去电时间
        string CircsOne = txtCircsOne.Text.Trim();       //情况

        try
        {
            Convert.ToDateTime(time);
        }
        catch
        {
            return "来电时间请输入日期型";
        }
       
       
        


        string[] Insert = new string[2];
        Insert[0] = "INSERT INTO SOrdQTel ([QTel_Guid] ,[Order_ID] ,[QTelName] ,[JTelName]  ,[Time] ,[Circs] ,[CreatedBy] ,[CreatedDate]) VALUES " +
            "('" + GUID + "','" + Order_ID + "','" + QTelName + "','" + DJTelName + "','" + time + "','" + CircsOne + "','" + ViewState["Satff_Id"].ToString() + "',getdate())";

        Insert[1] = "Update SOrdEstate set StatusId = 4,Operator = '7',OperatorMan = '" + ViewState["Satff_Id"].ToString() + "' where Order_ID = '" + Order_ID + "'";  //表示该勤务为完结状态
        try
        {
            if (db.runTransaction(Insert))
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

    //修改勤务安排地点
    private string SaveXG()
    {
        string locus = txtlocus.Text.Trim();

        string[] Insert = new string[2];
        Insert[0] =  "Update SOrdZArrange set Order_locus = '" + locus + "' where Order_ID = '" + Order_ID + "'";
        Insert[1] = "Update SOrdEstate set Operator = '8',OperatorMan = '" + ViewState["Satff_Id"].ToString() + "' where Order_ID = '" + Order_ID + "'";
        try
        {
            if (db.runTransaction(Insert))
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
    #endregion


    #region  修改细节
    //值班室电话登记保存
    private string EditDJ(string GUID)
    {
        //来电时间  
        if (txtTelFTime.Text == "")
        {
            txtTelFTime.Text = "00";
        }
        string time = txtTelRTime.Text + " " + drpTelSTime.SelectedValue + ":" + txtTelFTime.Text + ":00";
        //接收方式  
        string InceptMode = drpInceptMode.SelectedIndex.ToString();
        //勤务名称
        string Order_Name = txtOrder_Name.Text.Trim();
        //勤务规格
        string OrderSpec = drpOrderSpec.SelectedIndex.ToString();
        //勤务类别
        string OrderSort = drpOrderSort.SelectedIndex.ToString();
        //密级
        string SecretDis = drpSecretDis.SelectedIndex.ToString();
        //来电人
        string TelCom = txtTelCom.Text.Trim();
        //接电人
        string TelMeet = txtTelMeet.Text.Trim();

        //来电单位
        string TelUnit = txtTelUnit.Text.Trim();

        //主要内容
        string MostlyContent = txtMostlyContent.Text.Trim();

       
        //附件
        string GVAbjunctOne = "";
        if (ViewState["AttachmentBatch_Guid"] == null || ViewState["AttachmentBatch_Guid"].ToString() == "")
        {

        }
        else
        {
            GVAbjunctOne = ViewState["AttachmentBatch_Guid"].ToString(); //要改的　
        }
        //验证
        try
        {
            Convert.ToDateTime(time);
        }
        catch
        {
            return "日期的格式不正确,请重新输入";
        }

        if (InceptMode == "")
        {
            return "请选择接收方式";
        }
        if (Order_Name == "")
        {
            return "请输入勤务名称";
        }
        if (OrderSpec == "")
        {
            return "请选择勤务规格";
        }
        if (OrderSort == "")
        {
            return "请选择勤务类别";
        }
        if (SecretDis == "")
        {
            return "请选择密级";
        }
        if (TelCom == "")
        {
            return "请输入来电人";
        }
        if (TelMeet == "")
        {
            return "请输入接电人";
        }
        if (TelUnit == "")
        {
            return "请输入来电单位";
        }
        string CreatedBy = "";  //修改者

        string[] sql = new string[2];
        sql[0] = "UPDATE SOrdEstate set [Order_Name] = '" + Order_Name + "',[ModifiedBy] = '" + CreatedBy + "',[ModifiedDate] = getdate(),[Operator] ='" +
            CreatedBy + "' WHERE Order_ID = '" + Order_ID + "'";

        sql[1] = "UPDATE SOrdEnrol set [Order_TelTime] = '" + time + "',[InceptMode] =  '" + InceptMode + "',[OrderSpec] = '" + OrderSpec +
            "',[OrderSort] = '" + OrderSort + "',[SecretDis] =  '" + SecretDis + "',[TelCom] =  '" + TelCom + "',[TelMeet] =  '" + TelMeet
            + "',[TelUnit] =  '" + TelUnit + "',[MostlyContent] =  '" + MostlyContent
             + "',[Abjunct] =  '',[ModifiedBy] =  '" + ViewState["Satff_Id"].ToString() + "',[ModifiedDate] = getdate() " +
             " WHERE Order_ID = '" + Order_ID + "'and GUID = '" + GUID + "'";

        if (db.runTransaction(sql) == true)
        {
            return "修改成功";
        }
        else
        {
            return "修改失败";
        }


    }

    //勤务修改
    private string EditAP()
    {

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
        //附件
        string Abjunct = "";
        if (ViewState["AttachmentBatch_Guid"] == null || ViewState["AttachmentBatch_Guid"].ToString() == "")
        {

        }
        else
        {
            Abjunct = ViewState["AttachmentBatch_Guid"].ToString(); //要改的　
        }
        //联系方式
        string LinkFashion = txtLinkFashion.Text.Trim();
        //总指挥
        string ZCompere = txtZCompere.Value.Trim();
        string[] ZCompere1 = ZCompere.Split(',');
        //副指挥
        string FCompere = txtFCompere.Value.Trim();
        string[] FCompere1 = FCompere.Split(',');
        //随卫负责人
        string SWPrincipal = txtSWPrincipal.Value.Trim();
        string[] SWPrincipal1 = SWPrincipal.Split(',');
        //随卫人员
        string SWMan = txtSWMan.Value.Trim();
        string[] SWMan1 = SWMan.Split(',');
        //现场负责人
        string XCPrincipal = txtXCPrincipal.Value.Trim();
        string[] XCPrincipal1 = XCPrincipal.Split(',');
        //现场人员
        string XCMa = txtXCMan.Value.Trim();
        string[] XCMa1 = XCMa.Split(',');
        //住地负责人
        string ZDPrincipal = txtZDPrincipal.Value.Trim();
        string[] ZDPrincipal1 = ZDPrincipal.Split(',');
        //住地人员
        string ZDMan = txtZDMan.Value.Trim();
        string[] ZDMan1 = ZDMan.Split(',');

        int Length = ZCompere1.Length + FCompere1.Length + SWPrincipal1.Length + SWMan1.Length + XCPrincipal1.Length +
            XCMa1.Length + ZDPrincipal1.Length + ZDMan1.Length;

        string[] InterSql = new string[Length + 1];


        //总指挥
        string ZCompereGUID = Guid.NewGuid().ToString();

        //副指挥
        string FCompereGUID = Guid.NewGuid().ToString();

        //随卫负责人
        string SWPrincipalGUID = Guid.NewGuid().ToString();

        //随卫人员
        string SWManGUID = Guid.NewGuid().ToString();

        //现场负责人
        string XCPrincipalGUID = Guid.NewGuid().ToString();

        //现场人员
        string XCMaGUID = Guid.NewGuid().ToString();

        //住地负责人
        string ZDPrincipalGUID = Guid.NewGuid().ToString();

        //住地人员
        string ZDManGUID = Guid.NewGuid().ToString();

        string Archives = "";
        string Badge = "";
        string Gun = "";
        string Car = "";
        string SWOrder = "";
        string XCOrder = "";
        string ZDOrder = "";
        
      
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
        if (this.CheckBox5.Checked == true)
        {
            SWOrder = "1";
        }
        if (this.CheckBox6.Checked == true)
        {
            XCOrder = "1";
        }
        if (this.CheckBox7.Checked == true)
        {
            ZDOrder = "1";
        }



        InterSql[0] = "UPDATE SOrdZArrange set  [FromTime] = '" + timeFrom + "',[FromTo] = '" + timeTo + "', [Order_locus] = '" + Order_locus +
                       "',[ReceiveUnit] = '" + ReceiveUnit + "',[Order_Calendar] = '" + Order_Calendar + "',[work_Request] = '" +
                         work_Request + "',[Abjunct] = '" + Abjunct + "', [ZCompere] = '" + ZCompereGUID + "', [FCompere] = '" + FCompereGUID + "', [SWPrincipal] = '" +
                         SWPrincipalGUID + "',[SWMan] = '" + SWManGUID + "', [XCPrincipal] = '" + XCPrincipalGUID + "',[ZDPrincipal] = '" + ZDPrincipalGUID + "',[XCMan] = '" + XCMaGUID + "',[ZDMan] = '" + ZDManGUID 
                         + "',[Archives] = '" + Archives + "',[Badge] = '" + Badge + "', [Gun] = '" + Gun + "',Car = '" + Car + "', SWOrder = '" + SWOrder  + "',XCOrder = '" + XCOrder + "', ZDOrder = '" + ZDOrder 
                         + "',[LinkFashion] = '" + LinkFashion + "',[ModifiedBy] = '" + ViewState["Satff_Id"].ToString() + "', [ModifiedDate] = GetDate() " +
                          " WHERE Order_ID = '" + Order_ID + "'";



        for (int i = 1; i <= ZCompere1.Length; i++)
        {
            InterSql[i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + ZCompereGUID + "','" + ZCompere1[i - 1] + "')";
        }

        for (int i = 0; i < FCompere1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + FCompereGUID + "','" + FCompere1[i] + "')";
        }

        for (int i = 0; i < SWPrincipal1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + SWPrincipalGUID + "','" + SWPrincipal1[i] + "')";
        }

        for (int i = 0; i < SWMan1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + SWPrincipal1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + SWManGUID + "','" + SWMan1[i] + "')";
        }
        for (int i = 0; i < XCPrincipal1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + SWPrincipal1.Length + SWMan1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + XCPrincipalGUID + "','" + XCPrincipal1[i] + "')";
        }

        for (int i = 0; i < XCMa1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + SWPrincipal1.Length + SWMan1.Length + XCPrincipal1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + XCMaGUID + "','" + XCMa1[i] + "')";
        }
        for (int i = 0; i < ZDPrincipal1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + SWPrincipal1.Length + SWMan1.Length + XCPrincipal1.Length + XCMa1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + ZDPrincipalGUID + "','" + ZDPrincipal1[i] + "')";
        }
        for (int i = 0; i < ZDPrincipal1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + SWPrincipal1.Length + SWMan1.Length + XCPrincipal1.Length + XCMa1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + ZDPrincipalGUID + "','" + ZDPrincipal1[i] + "')";
        }

        for (int i = 0; i < ZDMan1.Length; i++)
        {
            InterSql[ZCompere1.Length + 1 + FCompere1.Length + SWPrincipal1.Length + SWMan1.Length + XCPrincipal1.Length + XCMa1.Length + ZDPrincipal1.Length + i] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + ZDManGUID + "','" + ZDMan1[i] + "')";
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

    //领导同意批示保存
    private string EditTYPS()
    {
        string XSSqlOne = "SELECT top 1 Number, PExecute FROM SOrdFlow WHERE (Order_ID = '" + Order_ID +
            "') AND (OperateStep = '1') order by CreatedDate DESC";
         string GUID = db.GetDataScalar(XSSqlOne);

        string OrderNotion = txtOrderNotion.Text.Trim();  //领导意见


        string UpdateNotion = "UPDATE SOrdAuditing set [OrderNotion] = '" + OrderNotion + "',[IsPer] = ''," +
            " [ModifiedBy] = '" + ViewState["Satff_Id"].ToString() + "',[ModifiedDate] = getdate() WHERE Order_ID = '" + Order_ID + "' and  GUID = '" + GUID + "'";
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


    #endregion

    #region 按扭事件

    //领导审批
    protected void btnPerNumber_Click(object sender, EventArgs e)
    {
        WebWindow.alert(SaveTYPS());
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (sign == "")   //值班室操作，前个页面传值
        {
            //查找最近一条的记录，得到该功能的功能编号
            string XSSql = "";
            XSSql = "select top 1 PFunction from SOrdFlow where Order_ID = '" + Order_ID + "'and OperateStep = '1' order by CreatedDate desc";

            try
            {
                string PFunction = db.GetDataScalar(XSSql);
                if (PFunction == "1")   //电话登记的验证和保存
                {
                    WebWindow.alert(SaveDJ());
                }
                else if (PFunction == "2")  //办公室审批的验证和保存
                {
                    WebWindow.alert(SaveSY());
                }
                else if (PFunction == "3")  //领导批示的验证和保存
                {
                    WebWindow.alert(SaveBTYPS());
                }
                else if (PFunction == "4")  //勤务安排的验证和保存
                {
                    string CountSql = "select * from SOrdZArrange where Order_ID = '" + Order_ID + "'";
                    if (db.GetDataTable(CountSql).Rows.Count > 0)
                    {
                        WebWindow.alert(EditAP());
                    }
                    else
                    {
                        WebWindow.alert(SaveAP());
                    }
                }
              
            }
            catch
            {

            }


            XSSql = "select top 1 PFunction from SOrdFlow where Order_ID = '" + Order_ID +
                "'and OperateStep = '2' and (NFunction is null or NFunction = '') order by CreatedDate desc";
             try
            {
                string PFunction = db.GetDataScalar(XSSql);
              
                if (PFunction == "5")  //勤务安排的验证和保存
                {
                    WebWindow.alert(SaveAP1());
                }
               
            }
            catch
            {

            }
        }
        else
        {
            if (sign == "1")   //修改首次电话登记
            {
                string GUID = db.GetDataScalar("select GUID from SOrdEnrol where Order_ID = '" + Order_ID + "'");
                WebWindow.alert(EditDJ(GUID));
            }
            else if (sign == "2")   //修改首次电话登记
            {
                WebWindow.alert(SaveDJ());
            }
            else if (sign == "3")  //来电登记的验证和保存
            {
                WebWindow.alert(SaveLD());
            }
            else if (sign == "4")  //去电登记的验证和保存
            {
                WebWindow.alert(SaveQD());
            }
            else if (sign == "5")  //修改勤务地点的验证和保存
            {
                WebWindow.alert(SaveXG());
            }
        }
    }

    //下送
    protected void btnNext_Click(object sender, EventArgs e)
    {
        //勤务编号和当前步骤//当前功能编号
        if (ViewState["PFunction"] == null &&  ViewState["Number"].ToString() == "")
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            Response.Redirect("DutySend.aspx?Order_ID=" + Order_ID + "&PFunction=" +
              ViewState["PFunction"].ToString() + "&Number=" + ViewState["Number"].ToString());
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


    //办公事签字
    protected void BtnOK_Click(object sender, EventArgs e)
    {
        ViewState["QZ"] = "True";
    }

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
    protected void btnQX_Click(object sender, EventArgs e)
    {
        string Sql = "Update SOrdEstate set StatusId = '3' where Order_ID = '" + Order_ID  + "'";
        try
        {
            db.executeUpdate(Sql);
            WebWindow.alert("取消成功");
        }
        catch (Exception er)
        {
            WebWindow.alert(er.Message);
        }
    }


  

    protected void ButtonReturn_Click(object sender, EventArgs e)
    {
        if (ViewState["OpenArrange"] == null || ViewState["OpenArrange"].ToString() == "")
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            string OpenArrange = ViewState["OpenArrange"].ToString();
            if (OpenArrange == "1")
            {
                
            }
            else if (OpenArrange == "2")
            {

            }
            else if (OpenArrange == "3")
            {

            }
        }
    }


  //根据勤务安排中的选择要操作的事项来显示按扭
     private void XSAP2Edit()
    {
        string SqlAP = "SELECT Archives, Badge, Gun, ReceiveUnit, Car, SWOrder,XCOrder,ZDOrder" +
                         " FROM SOrdZArrange where Order_ID = '" + Order_ID + "'";   
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

            if (SYRow[4].ToString() == "1")
            {
                this.Button5.Visible = true;
            }
            else
            {
                this.Button5.Visible = false;
            }

            if (SYRow[5].ToString() == "1")
            {
                this.Button6.Visible = true;
            }
            else
            {
                this.Button6.Visible = false;
            }

            if (SYRow[6].ToString() == "1")
            {
                this.Button7.Visible = true;
            }
            else
            {
                this.Button7.Visible = false;
            }

        }
        catch
        {
        }
    }
    protected void dropOrderNotion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtOrderNotion.Text = dropOrderNotion.SelectedItem.Text.Trim();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        OpenArrange("1", "");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        OpenArrange("2", "");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        OpenArrange("3", "");
    }

    #region  子勤务安排

    private void OpenArrange(string type, string OrderArrange_Guid)//子勤务类型  //类型
    {
        //用来弹出小页面的脚本　添加的时候   //传过去子勤务类型和勤务编号和状态
        Response.Redirect("DutyArrange.aspx?Order_ID=" + Order_ID + "&type=" + type + "&OrderArrange_Guid=" + OrderArrange_Guid);
    }

    //显示已经有的子勤务安排的链接
    private void FindZArrange()
    {
        //随卫勤务
        string StrZArrange1 = "select OrderArrange_Guid,Order_ID,Name as CreatedBy  from SOrdCArrange left join SSysStaff on " +
            " SOrdCArrange.CreatedBy = SSysStaff.Staff_Id where Order_ID = '" + Order_ID + "' and DutyPlan = '随卫勤务'";  //得到该勤务下的子勤务的类别和编号

        DataTable ZArrangeTable1 = db.GetDataTable(StrZArrange1);

        GV5.DataSource = ZArrangeTable1;
        GV5.DataBind();

        //现场勤务
        string StrZArrange2 = "select OrderArrange_Guid,Order_ID,Name as CreatedBy  from SOrdCArrange left join SSysStaff on " +
         " SOrdCArrange.CreatedBy = SSysStaff.Staff_Id where Order_ID = '" + Order_ID + "'  and DutyPlan = '现场勤务'";  //得到该勤务下的子勤务的类别和编号

        DataTable ZArrangeTable2 = db.GetDataTable(StrZArrange2);

        GV6.DataSource = ZArrangeTable2;
        GV6.DataBind();


        //住地勤务
        string StrZArrange3 = "select OrderArrange_Guid,Order_ID,Name as CreatedBy  from SOrdCArrange left join SSysStaff on " +
         " SOrdCArrange.CreatedBy = SSysStaff.Staff_Id where Order_ID = '" + Order_ID + "'  and DutyPlan = '住地勤务'";  //得到该勤务下的子勤务的类别和编号

        DataTable ZArrangeTable3 = db.GetDataTable(StrZArrange3);

        GV7.DataSource = ZArrangeTable3;
        GV7.DataBind();

       
 
    }


    #endregion

    protected void GVAbjunctOne_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        int i = e.RowIndex;
        GVAbjunctOne.Rows[i].Cells[0].Text = "√";             //将选定行标记成√
        string AttachmentBatch_Guid = GVAbjunctOne.Rows[i].Cells[1].Text.Trim();  //勤务编号
        string FileName = GVAbjunctOne.Rows[i].Cells[2].Text.Trim();  //名称
        string CreatedDate = GVAbjunctOne.Rows[i].Cells[3].Text.Trim();  //创建日期

        string selectSql = "select  replace(Folder  + SaveFileName, '/', '\\') from SSysAttachment where FileName = '" +
            FileName + "' and AttachmentBatch_Guid = '" + AttachmentBatch_Guid + "' Order by CreatedDate desc ";
        string FullFileName = db.GetDataScalar(selectSql);


        SetFileDownload(FullFileName, FileName);
    }

    //依据批次去查询
    private void XSFile(string AttachmentBatch_Guid, GridView GVAbjunct)
    {
        string StrselectFile = "SELECT  max(AttachmentBatch_Guid) as AttachmentBatch_Guid, FileName,max (CreatedDate) as CreatedDate " +
            " FROM SSysAttachment where AttachmentBatch_Guid = '" + AttachmentBatch_Guid + "'  Group by FileName";

        DataTable AbjunctTable = db.GetDataTable(StrselectFile);
        GVAbjunct.DataSource = AbjunctTable;
        GVAbjunct.DataBind();
    }
    protected void GVAbjunctTwo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        int i = e.RowIndex;
        GVAbjunctTwo.Rows[i].Cells[0].Text = "√";             //将选定行标记成√
        string AttachmentBatch_Guid = GVAbjunctTwo.Rows[i].Cells[1].Text.Trim();  //勤务编号
        string FileName = GVAbjunctTwo.Rows[i].Cells[2].Text.Trim();  //名称
        string CreatedDate = GVAbjunctTwo.Rows[i].Cells[3].Text.Trim();  //创建日期

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
    protected void BtnUpOne_Click(object sender, EventArgs e)
    {
        string AttachmentBatch_Guid = "";   //附件批次  一批附件一个批次
        if (ViewState["AttachmentBatch_GuidOne"] == null || ViewState["AttachmentBatch_GuidOne"].ToString() == "")
        {
            AttachmentBatch_Guid = Guid.NewGuid().ToString();
            ViewState["AttachmentBatch_GuidOne"] = AttachmentBatch_Guid;
        }
        else   //添加多个附件或者在修改附件的情况下
        {
            AttachmentBatch_Guid = ViewState["AttachmentBatch_GuidOne"].ToString();
        }
        string Attachment_Guid = Guid.NewGuid().ToString();　　　//文件编号，一次一个


        string FileNameQ = FileOne.PostedFile.FileName;  //注： loFile.PostedFile.FileName 返回的是通过文件对话框选择的文件名，
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
        FileOne.PostedFile.SaveAs(lstrFileNamePath);
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
    protected void btnUpTwo_Click(object sender, EventArgs e)
    {
        string AttachmentBatch_Guid = "";   //附件批次  一批附件一个批次
        if (ViewState["AttachmentBatch_GuidTwo"] == null || ViewState["AttachmentBatch_GuidTwo"].ToString() == "")
        {
            AttachmentBatch_Guid = Guid.NewGuid().ToString();
            ViewState["AttachmentBatch_GuidTwo"] = AttachmentBatch_Guid;
        }
        else   //添加多个附件或者在修改附件的情况下
        {
            AttachmentBatch_Guid = ViewState["AttachmentBatch_GuidTwo"].ToString();
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
        FileOne.PostedFile.SaveAs(lstrFileNamePath);
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