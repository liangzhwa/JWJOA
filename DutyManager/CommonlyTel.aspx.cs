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

public partial class DutyManager_CommonlyTel : System.Web.UI.Page
{
    MDataBase db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
    static string Tel_ID = "";   //全局的勤务编号
    static StringBuilder str;  //显示区域用来放动态的table

    protected void Page_Load(object sender, EventArgs e)
    {


        Config Config = (Config)Session["Config"];
        //   string staff_Id = Config.Staff.Staff_Id;　//得到登录的用户名
        string staff_Id = "00000003";
        ViewState["Satff_Id"] = staff_Id;
        //    string Role = Config.LoginRole.ToString();  //得到登录角色

        // string selectRole = db.GetDataScalar("SELECT Name FROM SSysRole WHERE (Role_Id = '" + Role + "')");     //根据传来的角色ID得到角色的名称
        string selectRole = "";
        if (!this.IsPostBack)
        {


            if (Request.QueryString["Tel_ID"] == null || Request.QueryString["Tel_ID"].ToString() == "") //编码
            {
                Tel_ID = "";  //
            }
            else
            {
                Tel_ID = Request.QueryString["Tel_ID"].ToString();
            }

            ControlDataBind drp = new ControlDataBind(ConfigurationManager.ConnectionStrings["OA"].ToString());
            drp.DropDownListBind(dropTelNotion, "SSFugleideaConfig", "IdeaContent", "IdeaID", 1, "", staff_Id);
            drp.DropDownListBind(drpInceptMode, "SOrdInceptFashion", "FashionName", "FashionID", 1, "", staff_Id);

        }

        if (Tel_ID == "")
        {
            if (this.lblTel_ID.Text == "")
            {
                #region 编辑电话编号为空，就是首次登记的时候

                //获取今天的年+月+日
                string Day = System.DateTime.Today.Year.ToString() + System.DateTime.Today.Month.ToString() +
                    System.DateTime.Today.Day.ToString();

                //查找出数据库中该天电话记录的最大的编号
                string Sql = "select top 1 Tel_ID from STelEnrol where Tel_ID like '" + Day + "%' order by Tel_ID desc";

                try
                {
                    Day = db.GetDataScalar(Sql);  //得到最大的ID
                    Tel_ID = Convert.ToString(Convert.ToInt32(Day) + 1);   //在最大ID的基础上加1,确定本次勤务的编号，该编号贯彻真个程序
                }
                catch   //报错说明查不到值
                {
                    Tel_ID = Convert.ToString(Convert.ToInt32(Day) + "001");
                }


                PanelVisibleFalse();   //设置全部模板不可见
                this.panelDJ.Visible = true;   //登记
                this.panelAN.Visible = true;   //按钮

                //电话登记的时候往流程表里写一条记录

                string Number = Guid.NewGuid().ToString();           //该步骤编号,要在保存里用到　
                ViewState["Number"] = Number;             //保存住这个值，在功能保存中要用到

                ViewState["PFunction"] = "1";            //新建的勤务默认为电话登记功能    
                string SY = "insert into STelFlow(TelFlow_Guid,Tel_ID,Number,PFunction,PExecute,CreatedBy,CreatedDate,OperateStep) " +
                    " values('" + Number + "','" + Tel_ID + "','" + Number + "',1,'" + staff_Id + "','" + staff_Id + "',getdate(),1)";         //Insert语句
                try
                {
                    db.executeInsert(SY);
                }
                catch
                {
                }

                #endregion
            }

            lblTel_ID.Text = Tel_ID;  //显示勤务编号  
        }
        else
        {
            #region 勤务编号不为空
            //不显示勤务编号说明虽然不是新建的勤务，但是是第一次打开该勤务单
            //用来控制显示的页面
            if (this.lblTel_ID.Text == "")
            {

                string Number = Guid.NewGuid().ToString();           //该步骤编号,要在保存里用到　
                ViewState["Number"] = Number;             //保存住这个值，在功能保存中要用到

                PanelVisibleFalse();  //所有panel不可见

                EditPanel();　　　//其他人员操作调用方法

                if (selectRole != "办公室" || (ViewState["XS"] != null && ViewState["XS"].ToString() == "TRUE"))   //如果角色是办公室或者办公室还没有对来电记录进行审批
                {
                    panelXS.Visible = true;   //用来显示的panel可见
                    XSTable();　//设置上面显示的table//只显示到下送过的，如果保存没有下送的不显示
                }

            }

            lblTel_ID.Text = Tel_ID;  //显示勤务编号  
            #endregion
        }

    }

    #region panel隐藏
    private void PanelVisibleFalse()
    {
        this.panelAN.Visible = false;   //按钮    
        this.panelXS.Visible = false;   //显示区域       
        this.panelDJ.Visible = false;   //登记  
        this.panelPS.Visible = false;   //领导批示
        this.panelSY.Visible = false;   //办公室审阅

    }
    #endregion 

    private void XSTable()
    {
        str = new StringBuilder();
        lblXS.Text = "";

        //按日期排序，查找出当前状态为已完成的勤务流程各步骤的功能类型,功能记录的GUID
        string XSSql = "select PFunction,Number,NFunction from STelFlow where Tel_ID = '" + Tel_ID
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
          

        }

        str.Append("</table>");      //定义表结束

        lblXS.Text = str.ToString();
    }

    private void EditPanel()
    {
        //查找没有下送时的修改情况
        string XSSqlOne = "SELECT top 1 Number, PFunction, PExecute FROM STelFlow WHERE (Tel_ID = '" + Tel_ID +
            "') AND (OperateStep = '1') order by CreatedDate DESC";

        DataRow XSRowOne = db.GetDataRow(XSSqlOne);
        string staff_Id = ViewState["Satff_Id"].ToString();   //登录人的编号

        if (XSRowOne != null)
        {
            //修改保存但是没有下送的信息
            //权限验证 
            XSRowOne[2].ToString();　　　//操作人的编号

            if (XSRowOne[2].ToString().Trim() != staff_Id )
            {
                ViewState["XS"] = "TRUE";
                return;
            }
            ViewState["Number"] = XSRowOne[0].ToString();


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
                this.Button5.Visible = false;    //只能有一步的领导审批 ,所以按扭置为不可见
                this.btnNext.Visible = false; 
                btnSave.Visible = false;
                XGEditPS(XSRowOne[0].ToString());
                
                return;
            }
          
        }

        #region

        string TelFlow_Guid = Guid.NewGuid().ToString();   //编号，随便生成一个新的　
        //string Number = Guid.NewGuid().ToString();           //该步骤编号,要在保存里用到　
        //ViewState["Number"] = Number;             //保存住这个值，在功能保存中要用到
        string PFunction = "";                    //该步骤的功能

        string SY = "";                           //Insert语句


        //查找下步执行功能和下步执行人,标记是已经完成
        string XSSql = "select  top 1 NFunction,NExecute from STelFlow where Tel_ID = '" + Tel_ID +
            "' and OperateStep = '2' and (NExecute <> '' or NExecute <> null) order by CreatedDate DESC";
        DataRow XSRow = db.GetDataRow(XSSql);
        //XSRow[1].ToString()为上步指派的操作人员
        //判断该操作人员是不是属于上步指派的操作人员,如果不是退出AAA


        //查找该人员编号在不在上步指定的人员编号中，在可以查看该步功能，否则只能查看已经做过的功能
        string strYZ = "select Count(*) from ( " +
                    " select top 1 * from STelFlow  where   Tel_ID = '" + Tel_ID + "' and OperateStep = '2' Order by STelFlow.CreatedDate Desc)  as STelFlow " +
                   " left join SOrdArrangeMan on STelFlow.NExecute = SOrdArrangeMan.Guid   where  Man  = '" + staff_Id + "'";

        string  YZ = db.GetDataScalar(strYZ);

        if (YZ == "0")
        {
            ViewState["XS"] = "TRUE";
            return;
        }

        ViewState["PFunction"] = XSRow[0].ToString();   //为当前步骤（没有下送前的新增情况）
        if (XSRow[0].ToString() == "2")　　　//办公室审阅
        {
            //电话登记部分的显示,办公室是可以修改的   AAA
            panelDJ.Visible = true;
            panelSY.Visible = true;
            XGEditDJ("");     //办公室人员操作时要能对值班室登记的信息进行修改
            //往流程表STelFlow里加一条记录,写进去　编号TelFlow_Guid 勤务编号Tel_ID 
            //该步骤编号Number　该步骤的功能PFunction　　该步骤执行人员PExecute
            PFunction = "2";
            SY = "insert into STelFlow(TelFlow_Guid,Tel_ID,Number,PFunction,PExecute,CreatedBy,CreatedDate,OperateStep) " +
                " values('" + TelFlow_Guid + "','" + Tel_ID + "','" + ViewState["Number"].ToString() + "','" + PFunction + "','" + staff_Id + "','" + staff_Id + "',getdate(),1)";
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
            SY = "insert into STelFlow(TelFlow_Guid,Tel_ID,Number,PFunction,PExecute,CreatedBy,CreatedDate,OperateStep) " +
                " values('" + TelFlow_Guid + "','" + Tel_ID + "','" + ViewState["Number"].ToString() + "','" + PFunction + "','" + ViewState["Satff_Id"].ToString() + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),1)";
            db.executeInsert(SY);
            this.panelAN.Visible = true;   //按钮
            return;
        }
       
        #endregion


    }

    //显示电话登记的页面,传进来勤务编号和电话登记的GUID
    private void XSDJ(string GUID)
    {
        str = new StringBuilder();  //yao shan 
        string Tel_ID = "2008412001";
        string SqlTelEnrol = "select Tel_TelTime,FashionName ,TelCom,TelMeet, TelUnit,MostlyContent,Abjunct " +
                               " from STelEnrol left join SOrdInceptFashion on STelEnrol.InceptMode = SOrdInceptFashion.FashionID" +
                               " where Tel_ID = '" + Tel_ID + "' and GUID = '" + GUID + "'";

        try
        {
            DataRow TelEnrolRow = db.GetDataRow(SqlTelEnrol);  //查找内容

            #region 完成table的拼接

            str.Append("<tr>" +
                            "<td colspan=\"6\"  align=\"left\" style=\"background-color: #ffcc99\">来电登记</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td align=\"right\" style=\"width: 20%\">来电时间：</td>" +
                            "<td colspan=\"3\"  width=\"40%\" align=\"left\" >" +  //来电时间
                                  TelEnrolRow[0].ToString() +
                                "<td align=\"right\" style=\"width: 20%\">接收方式：</td>" +
                                "<td align=\"left\"  width=\"26%\" align=\"left\">" + //接收方式
                                   TelEnrolRow[1].ToString() +
                                "</td>" +
                        "</tr><tr>" +
                "<td align=\"right\" style=\"width: 20%\">来电人：</td>" +
                "<td align=\"left\" style=\"width: 16%\">" + //来电人
                    TelEnrolRow[2].ToString() +
                "</td>" +
                "<td align=\"right\" style=\"width: 21%\">接电人：</td>" +
                "<td align=\"left\" width=\"16%\">" +      //接电人
                    TelEnrolRow[3].ToString() +
                "</td>" +
                "<td align=\"right\" style=\"width: 17%\"></td>" +
                "<td align=\"right\" width=\"16%\"></td>" +
            "</tr>" +
             "<tr>" +
                 "<td align=\"right\" style=\"width: 20%; height: 11px;\">来电单位：</td>" +
                "<td width=\"75%\" colspan=\"5\" style=\"height: 11px\"  align=\"left\" >" +   //来电单位
                    TelEnrolRow[4].ToString() +
                  "</td>" +
            "</tr>" +
              "<tr>" +
                 "<td align=\"right\" style=\"width: 20%; height: 34px;\">主要内容：</td>" +
                "<td width=\"75%\" colspan=\"5\" style=\"height: 34px\"  align=\"left\" >" + //主要内容
                    TelEnrolRow[5].ToString() +
                  "</td>" +
            "</tr>" +
            "<tr>" +
                "<td align=\"right\">附件：</td>" +
                "<td colspan=\"5\">");

          //  str.Append("<iframe  width=\"90%\" src = \"Abjunct.aspx?AttachmentBatch_Guid='" + TelEnrolRow[6].ToString()+ "'></iframe>");
            str.Append("<iframe  style=\"overflow: auto; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 550px; height: 120px;\"   src = \"Abjunct.aspx?AttachmentBatch_Guid='" + TelEnrolRow[6].ToString() + "'\"></iframe>");
                   
            str.Append("</td></tr>");


            #endregion

          
            lblXS.Text = str.ToString();  //yaoshan
        }
        catch(Exception er)
        {
        }


    }



    //显示办公室审阅的页面,传进来勤务编号和电话登记的GUID
    private void XSSY(string GUID)
    {
        string SqlSY = "select Personnel from STelEnrol where Tel_ID = '" + Tel_ID + "' and GUID = '" + GUID + "'";
        string StrSY = db.GetDataScalar(SqlSY);
        str.Append("<tr>" +
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
        string SqlPS = "select TelNotion,PerNumber from STelAuditing where Tel_ID = '" + Tel_ID + "' and GUID = '" + GUID + "'";
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


    //值班室电话登记保存
    private string SaveDJ()
    {
        string GUID = "";
        if (ViewState["Number"] != null && ViewState["Number"].ToString() != "")   //得到前面生成的GUID
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


       
        string InsertDJ = "insert into STelEnrol(GUID,Tel_ID,Tel_TelTime,InceptMode,TelCom,TelMeet,TelUnit,MostlyContent,Abjunct,CreatedBy,CreatedDate,Note_ID)" +
                "values('" + GUID + "','" + Tel_ID + "','" + time + "','" + InceptMode +  "','" + TelCom + "','" +
                TelMeet + "','" + TelUnit + "','" + MostlyContent + "','" + GVAbjunctOne + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),0)";
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

    //办公室保存
    private string SaveSY()
    {
        string GUID = "";
        if (ViewState["Number"] != null && ViewState["Number"].ToString() != "")   //得到前面生成的GUID
        {
            GUID = ViewState["Number"].ToString();
        }


        string selectSql = "select top 1 Tel_TelTime,InceptMode,TelCom,TelMeet,TelUnit," +
            " MostlyContent,Abjunct from STelEnrol where Tel_ID = '" + Tel_ID + "' order by CreatedDate";
        DataRow selectRow = db.GetDataRow(selectSql);

     
        //来电时间  
        if (txtTelFTime.Text == "")
        {
            txtTelFTime.Text = "00";
        }
        string time = txtTelRTime.Text + " " + drpTelSTime.SelectedValue + ":" + txtTelFTime.Text + ":00";
        //接收方式  
        string InceptMode = drpInceptMode.SelectedIndex.ToString();
      
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




        if (selectRow[1].ToString() != InceptMode         //对比接收方式是否一致 
            || selectRow[2].ToString() != TelCom                //对比来电人是否一致
            || selectRow[3].ToString() != TelMeet               //对比接电人是否一致
            || selectRow[4].ToString() != TelUnit               //对比来电单位是否一致
            || selectRow[5].ToString() != MostlyContent)         //对比主要内容是否一致
                    //对比附件是否一致  || selectRow[9].ToString() != GVAbjunctOne
        {

            string InsertDJ = "";

            if (ViewState["QZ"] != null && ViewState["QZ"].ToString() != "" && ViewState["QZ"].ToString() == "True")
            {
                InsertDJ = "insert into STelEnrol(GUID,Tel_ID,Tel_TelTime,InceptMode,TelCom,TelMeet,TelUnit,MostlyContent,Abjunct,Personnel,CreatedBy,CreatedDate,Note_ID)" +
                       "values('" + GUID + "','" + Tel_ID + "','" + time + "','" + InceptMode + "','" + TelCom + "','" + TelMeet + "','" + TelUnit + "','" + MostlyContent + "','" + GVAbjunctOne + "','" + ViewState["Satff_Id"].ToString() + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),1)";

                ViewState["QZ"] = "";
            }
            else
            {
                InsertDJ = "insert into STelEnrol(GUID,Tel_ID,Tel_TelTime,InceptMode,TelCom,TelMeet,TelUnit,MostlyContent,Abjunct,CreatedBy,CreatedDate,Note_ID)" +
                      "values('" + GUID + "','" + Tel_ID + "','" + time + "','" + InceptMode + "','" + TelCom + "','" + TelMeet + "','" + TelUnit + "','" + MostlyContent + "','" + GVAbjunctOne + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),1)";

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
            string UpdateDJ = "Update STelEnrol set Personnel = '" + ViewState["Satff_Id"].ToString() + "' where Tel_Id = '" + Tel_ID + "'";   //更新签名
            try
            {
                db.executeUpdate(UpdateDJ);
                GUID = db.GetDataScalar("select GUID from STelEnrol  where Tel_Id = '" + Tel_ID + "'");
                string Update = "Update  STelFlow set Number = '" + GUID + "' where Tel_ID = '" + Tel_ID + "' and operateStep = '1'";
                db.executeUpdate(Update);
                ViewState["Number"] = GUID;   //如果没有更新要把原来的编号付值回去
                return "审批成功";
            }
            catch (Exception er)
            {
                return er.Message;
            }
       }
    }

    //领导同意批示保存
    private string SaveTYPS()
    {
        string GUID = "";
        if (ViewState["Number"] != null && ViewState["Number"].ToString() != "")   //得到前面生成的GUID
        {
            GUID = ViewState["Number"].ToString();
        }

        string TelNotion = txtTelNotion.Text.Trim();  //领导意见

        string Insert = "insert into STelAuditing(GUID,Tel_ID,TelNotion,PerNumber,IsPer,CreatedBy,CreatedDate,StatusId) " +
                            " values('" + GUID + "','" + Tel_ID + "','" + TelNotion + "','" + ViewState["Satff_Id"].ToString() + "',1,'" + ViewState["Satff_Id"].ToString() + "',getdate(),0)";


        try
        {
           db.executeInsert(Insert);
            return "保存成功";
           
        }
        catch (Exception er)
        {
            return er.Message;
        }
    }

    //显示电话登记的页面,传进来勤务编号和电话登记的GUID
    private void XGEditDJ(string GUID)
    {
        //查找勤务名称
      
        string SqlTelEnrol = "";
        if (GUID == "")
        {
            SqlTelEnrol = "select  top 1 Tel_TelTime,FashionID ,TelCom,TelMeet, TelUnit,MostlyContent,Abjunct,GUID" +
                           " from STelEnrol left join SOrdInceptFashion on STelEnrol.InceptMode = SOrdInceptFashion.FashionID" +
                           " where Tel_ID = '" + Tel_ID  + "' order by CreatedDate";
        }
        else
        {
            SqlTelEnrol = "select top 1 Tel_TelTime,FashionID ,TelCom,TelMeet, TelUnit,MostlyContent,Abjunct,GUID " +
                      " from STelEnrol left join SOrdInceptFashion on STelEnrol.InceptMode = SOrdInceptFashion.FashionID" +
                      " where Tel_ID = '" + Tel_ID + "' and GUID = '" + GUID + "' order by CreatedDate";
        }

        DataRow TelEnrolRow = db.GetDataRow(SqlTelEnrol);  //查找内容

        #region 读取数据库表中电话登记数据

        //来电时间   2008-01-04 08:28:14.000
        string time = TelEnrolRow[0].ToString();

        txtTelRTime.Text = GetDate(time);
        drpTelSTime.SelectedItem.Text = GetHour(time);
        txtTelFTime.Text = GetMinute(time);


        //接收方式  
        drpInceptMode.SelectedValue = TelEnrolRow[1].ToString();

      
        //来电人
        txtTelCom.Text = TelEnrolRow[2].ToString();

        //接电人
        txtTelMeet.Text = TelEnrolRow[3].ToString();

        //来电单位
        txtTelUnit.Text = TelEnrolRow[4].ToString();

        //主要内容
        txtMostlyContent.Text = TelEnrolRow[5].ToString();

        //附件：AAA
        XSFile(TelEnrolRow[6].ToString());

        if (ViewState["Number"] == null || ViewState["Number"].ToString() == "")
        {
            ViewState["Number"] = TelEnrolRow[7].ToString();
        }
        #endregion

    }

    //领导批示修改
    public void XGEditPS(string GUID)
    {
        string SqlPS = "select TelNotion,GUID  from STelAuditing where Tel_ID = '" + Tel_ID + "' and GUID = '" + GUID + "'";
        DataRow row = db.GetDataRow(SqlPS);
        txtTelNotion.Text = row[0].ToString().Trim();
        if (ViewState["Number"] == null || ViewState["Number"].ToString() == "")
        {
            ViewState["Number"] = row[1].ToString().Trim();
        }
    }
   

    private string EditDJ()
    {
        //来电时间  
        if (txtTelFTime.Text == "")
        {
            txtTelFTime.Text = "00";
        }
        string time = txtTelRTime.Text + " " + drpTelSTime.SelectedValue + ":" + txtTelFTime.Text + ":00";
        //接收方式  
        string InceptMode = drpInceptMode.SelectedIndex.ToString();
       
        //来电人
        string TelCom = txtTelCom.Text.Trim();
        //接电人
        string TelMeet = txtTelMeet.Text.Trim();

        //来电单位
        string TelUnit = txtTelUnit.Text.Trim();

        //主要内容
        string MostlyContent = txtMostlyContent.Text.Trim();

        //附件：AAA
        string GVAbjunctOne = Guid.NewGuid().ToString(); //要改的　

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


        string sql = "UPDATE STelEnrol set [Tel_TelTime] = '" + time + "',[InceptMode] =  '" + InceptMode + "',[TelCom] =  '" +
            TelCom + "',[TelMeet] =  '" + TelMeet
            + "',[TelUnit] =  '" + TelUnit + "',[MostlyContent] =  '" + MostlyContent
             + "',[Abjunct] =  '',[ModifiedBy] =  '" + ViewState["Satff_Id"].ToString() + "',[ModifiedDate] = getdate() " +
             " WHERE Tel_ID = '" + Tel_ID + "'";

        try
        {
            db.executeUpdate(sql);
            return "修改成功";
        }
        catch
        {
            return "修改失败";
        }


    }


    //领导同意批示保存
    private string EditTYPS()
    {
        string XSSqlOne = "SELECT top 1 Number, PExecute FROM STelFlow WHERE (Tel_ID = '" + Tel_ID +
            "') AND (OperateStep = '1') order by CreatedDate DESC";
        string GUID = db.GetDataScalar(XSSqlOne);

        string TelNotion = txtTelNotion.Text.Trim();  //领导意见


        string UpdateNotion = "UPDATE STelAuditing set [TelNotion] = '" + TelNotion + "',[IsPer] = ''," +
            " [ModifiedBy] = '" + ViewState["Satff_Id"].ToString() + "',[ModifiedDate] = getdate() WHERE Tel_ID = '" + Tel_ID + "' and  GUID = '" + GUID + "'";
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
        string strMan = "select Man from STelArrangeMan where Guid = '" + GUIDMan + "'";  //找到该GUID对应的用户名称
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


    protected void btnSave_Click(object sender, EventArgs e)
    {
        string XSSql = "";
        XSSql = "select top 1 PFunction from STelFlow where Tel_ID = '" + Tel_ID + "'and OperateStep = '1' order by CreatedDate desc";

        try
        {
            string PFunction = db.GetDataScalar(XSSql);
            if (PFunction == "1")   //电话登记的验证和保存
            {
                if (db.GetDataScalar("select Count(*) from STelEnrol where Tel_ID = '" + Tel_ID + "'") == "0")
                {
                    WebWindow.alert(SaveDJ());
                }
                else
                {
                    WebWindow.alert(EditDJ());
                }
                this.btnSave.Visible = false;
            }
            else if (PFunction == "2")  //办公室审批的验证和保存
            {
                WebWindow.alert(SaveSY());
                this.btnSave.Visible = false;
            }
            //else if (PFunction == "3")  //领导批示的验证和保存
            //{
            //    if (db.GetDataScalar("select Count(*) from STelAuditing where Tel_ID = '" + Tel_ID + "'") == "0")
            //    {
            //        WebWindow.alert(SaveBTYPS());
            //    }
            //    else
            //    {
            //        WebWindow.alert(UpdatePS());
            //    }
            //    this.btnSave.Visible = false;
            //}
        }
        catch
        {

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

        string TelNotion = txtTelNotion.Text.Trim();  //领导意见


        string[] Insert = new string[2];
        Insert[0] = "insert into STelAuditing(GUID,Tel_ID,TelNotion,PerNumber,IsPer,CreatedBy,CreatedDate,StatusId) " +
                            " values('" + GUID + "','" + Tel_ID + "','" + TelNotion + "','" + ViewState["Satff_Id"].ToString() + "',1,'" + ViewState["Satff_Id"].ToString() + "',getdate(),0)";

        Insert[1] = "update STelFlow set OperateStep = '2' where PFunction = '3' and Tel_ID = '" + Tel_ID + "'";


        try
        {
           db.runTransaction(Insert);
           return "保存成功";
          
        }
        catch (Exception er)
        {
            return er.Message;
        }
    }

    //领导不同意批示保存
    private string UpdatePS()
    {
     
        string TelNotion = txtTelNotion.Text.Trim();  //领导意见


        string Update = "";
        Update = "Update STelAuditing set TelNotion = '" + TelNotion + "' where Tel_ID = '" + Tel_ID  + "'";


        try
        {
            db.executeUpdate(Update);
            return "保存成功";

        }
        catch (Exception er)
        {
            return er.Message;
        }
    }




    protected void btnNext_Click(object sender, EventArgs e)
    {
        this.btnSave.Visible = false;
        txt1.Value = hfStaffId.Value.TrimEnd(',');

        if (txt1.Value == "")
        {
            WebWindow.alert("选择要下送的人员");
            return;
        }

        string[] splitNExecute = txt1.Value.Split(',');

        string[] Update = new string[splitNExecute.Length + 1];  //定义保存数据库的数组

        string ZCompereGUID = Guid.NewGuid().ToString();

        string XSSql = "select top 1 PFunction from STelFlow where Tel_ID = '" + Tel_ID + "'and OperateStep = '1' order by CreatedDate desc";

        try
        {
            string PFunction = db.GetDataScalar(XSSql);
            if (PFunction == "1")   //电话登记的验证和保存
            {

                Update[0] = "update STelFlow set NFunction ='2' , NExecute  ='" + ZCompereGUID + "' , OperateStep = '2'" +
                   " where Tel_ID = '" + Tel_ID + "' and Number = '" + ViewState["Number"].ToString() + "' and (NFunction is null or NFunction = '')";
            }
            else if (PFunction == "2")   //电话登记的验证和保存
            {
                Update[0] = "update STelFlow set NFunction ='3' , NExecute  ='" + ZCompereGUID + "' , OperateStep = '2'" +
                 " where Tel_ID = '" + Tel_ID + "' and Number = '" + ViewState["Number"].ToString() + "' and (NFunction is null or NFunction = '')";
            }

            for (int i = 0; i < splitNExecute.Length; i++)
            {
                Update[i + 1] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + ZCompereGUID + "','" + splitNExecute[i] + "')";
            }

            if (db.runTransaction(Update) == true)
            {
                WebWindow.alert("下送成功");
                btnNext.Visible = false;
                PanelVisibleFalse();
                this.panelXS.Visible = true;
                XSTable();
                

            }

        }
        catch
        {

        }
     
        
    }
    protected void btnPerNumber_Click(object sender, EventArgs e)
    {
        if (db.GetDataScalar("select Count(*) from STelAuditing where Tel_ID = '" + Tel_ID + "'") == "0")
        {
            WebWindow.alert(SaveBTYPS());
        }
        else
        {
            WebWindow.alert(UpdatePS());
        }
    }
    protected void dropTelNotion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtTelNotion.Text = dropTelNotion.SelectedItem.Text.Trim();
    }


    #region  附件

    protected void btnFile_Click(object sender, EventArgs e)
    {
        string AttachmentBatch_Guid = "";   //附件批次  一批附件一个批次
        if (ViewState["AttachmentBatch_Guid"] == null || ViewState["AttachmentBatch_Guid"].ToString() == "")  
        {
            AttachmentBatch_Guid = Guid.NewGuid().ToString();
            ViewState["AttachmentBatch_Guid"] = AttachmentBatch_Guid;
        }
        else   //添加多个附件或者在修改附件的情况下
        {
            AttachmentBatch_Guid = ViewState["AttachmentBatch_Guid"].ToString();
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
        string Folder = "E://File/Order/CommonlyTel/" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() +
            System.DateTime.Now.Day.ToString() + "/";  //路径


        if (Directory.Exists(Folder) == false)  //测试路径存不存在
        {
            Directory.CreateDirectory(Folder);  //创建路径 
        }

        string lstrFileNamePath = Folder +  SaveFileName;
        //得到上传目录及文件名称
        FileOne.PostedFile.SaveAs(lstrFileNamePath);
        //上传文件到服务器

        //string Insert = "Insert into SSysAttachment(Attachment_Guid,AttachmentBatch_Guid,Folder,FileName,ExtensionName,SaveFileName, " +
        //     " CreatedBy,CreatedDate) values( '" + Attachment_Guid + "','" + AttachmentBatch_Guid + "','" + Folder + "','" + FileNameQQ + "','" + 
        //     ExtensionName + "','" + SaveFileName + "','" + ViewState["Satff_Id"].ToString() + "',getdate())";

        string Insert = "Insert into SSysAttachment(Attachment_Guid,AttachmentBatch_Guid,Folder,FileName,ExtensionName,SaveFileName, " +
            " CreatedBy,CreatedDate) values( '" + Attachment_Guid + "','" + AttachmentBatch_Guid + "','" + Folder + "','" + FileNameQQ + "','" +
            ExtensionName + "','" + SaveFileName + "',00000001,getdate())";

        try
        {
            db.executeInsert(Insert);
            WebWindow.alert("保存成功");
        }
        catch(Exception er)
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

    //下载
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

    //依据批次去查询
    private void XSFile(string AttachmentBatch_Guid)
    {
        string StrselectFile = "SELECT  max(AttachmentBatch_Guid) as AttachmentBatch_Guid, FileName,max (CreatedDate) as CreatedDate " +
            " FROM SSysAttachment where AttachmentBatch_Guid = '" + AttachmentBatch_Guid + "'  Group by FileName";

        DataTable AbjunctTable = db.GetDataTable(StrselectFile);
        GVAbjunct.DataSource = AbjunctTable;
        GVAbjunct.DataBind();
    }


    #endregion
}
