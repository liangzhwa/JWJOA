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

public partial class DutyManager_DutyNet : System.Web.UI.Page
{
    MDataBase db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
    static StringBuilder str;  //显示区域用来放动态的table

　
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.CheckNet1.Checked = false;
            this.CheckNet2.Checked = false;
            this.CheckNet3.Checked = false;

            this.radType1.Checked = false;
            this.radType2.Checked = false;
            this.radType3.Checked = false;
            this.radType4.Checked = false;

            Config Config = (Config)Session["Config"];
         //   string staff_Id = Config.Staff.Staff_Id;　//得到登录的用户名
            string Satff_ID = "00000001";
            ViewState["Satff_Id"] = Satff_ID;
         //   string Role = Config.LoginRole.ToString();  //得到登录角色

        //    string selectRole = db.GetDataScalar("SELECT Name FROM SSysRole WHERE (Role_Id = '" + Role + "')");     //根据传来的角色ID得到角色的名称

            string selectRole = "";
            

            ControlDataBind drp = new ControlDataBind(ConfigurationManager.ConnectionStrings["OA"].ToString());
            drp.DropDownListBind(drpOrder_ID, "SOrdEstate", "Order_ID", "Order_ID", 4, "StatusId = 4", Satff_ID);　　　//完结状态的勤务
            drp.DropDownListBind(dropOrderNotion, "SSFugleideaConfig", "IdeaContent", "IdeaID", 1, "", Satff_ID);

             if (Request.QueryString["Order_ID"] == null || Request.QueryString["Order_ID"].ToString() == "") //勤务编号
             {
                  ViewState["State"] = "Insert";
               
                  PanelYC();
                  this.panelsr.Visible = true;  //显示panel
                  this.lblMan.Text = "";  //根据传来的编号显示姓名
                  this.lblTime.Text = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() +
                 "-" + System.DateTime.Now.Day.ToString();//得到当前的时间
                  btnPersonnel.Visible = false;
             }
             else
             {
           //      ViewState["Order_ID"] = Request.QueryString["Order_ID"].ToString();
                 ViewState["Order_ID"] = "2008410001";
                 ViewState["Net_Guid"] = db.GetDataScalar("select Net_Guid from SOrdNet where Order_ID = '" + ViewState["Order_ID"].ToString() + "'");  //得到编号

                 string Count = db.GetDataScalar("select Count(*) from SOrdNet where StatusId = '3' and Order_ID = '" + ViewState["Order_ID"].ToString() + "'");  //编号为3说明到了领导处可
                 
                 if(Count != "0")   //领导审批阶段
                 {

                     PanelYC();
                     XS();
                     this.panelxs.Visible = true;
                     this.btnSave.Visible = false;

                     if (db.GetDataScalar("select Count(*) from SOrdNetAuditing where Net_Guid = '" +
                         ViewState["Net_Guid"].ToString() + "' and StatusId = '1'") != "0")   //修改阶段　　
                     {

                         string Count5 = db.GetDataScalar("select Count(*) from SOrdNetAuditing where StatusId = '1' and Net_Guid  = '"
                             + ViewState["Net_Guid"].ToString() + "' and Per_ID = '" + ViewState["Satff_Id"].ToString() + "'");   //看看现在登录人是不是这步的操作人
                         if (Count5 != "0")
                         {
                             UpdateLDXG();
                             Label1.Text = "LDXG";
                         }
                         else
                         {             
                             return;  //不是，退出
                         }
                     }
                     else
                     {


                         string Count1 = db.GetDataScalar("select Count(*) from SOrdNet  left join SOrdArrangeMan on SOrdNet.nextPer = SOrdArrangeMan.Guid where " +
                               " SOrdArrangeMan.Man  = '" + ViewState["Satff_Id"].ToString() + "' and  Order_ID = '" + ViewState["Order_ID"].ToString() + "'");

                         if (Count1 != "0")
                         {
                             this.panel1.Visible = true;  //领导审批的页面显示

                         }
                         else  //如果不一致
                         {
                             string Count2 = db.GetDataScalar("select Count(*) from (select top 1 A.* from SOrdNetAuditing A left join SOrdNet B on A.Net_Guid = B.Net_Guid " +
                                                " where B.Order_ID = '" + ViewState["Order_ID"].ToString() + "'  order by A.CreatedDate DESC)  as C  left join SOrdArrangeMan on SOrdNet.nextPer = SOrdArrangeMan.Guid where " +
                                                " Man  = '" + ViewState["Satff_Id"].ToString() + "'");

                             if (Count1 != "0")  //如果领导审批表中有记录　　　　//权限验证
                             {
                                 this.panel1.Visible = true;  //领导审批的页面显示　
                             }
                         }
                     }

                     
                 }
                 else　　　//填写人修改，或者办公室部门核稿件
                 {
                      string Count3  = db.GetDataScalar("select StatusId from SOrdNet where Order_ID = '" + ViewState["Order_ID"].ToString() +  "'");  //判断状态

                      drpOrder_ID.SelectedValue = ViewState["Order_ID"].ToString();   //勤务编号
                      drpOrder_ID.Enabled = false;

                      if (Count3 == "1") //填写人的修改状态
                      {
                          ViewState["State"] = "Update";
                          PanelYC();
                          this.panelsr.Visible = true;
                          EditSR();
                          btnPersonnel.Visible = false;
                      }
                      else if (Count3 == "2")  //等待办公室审批
                      {
                          if (selectRole == "办公室")
                          {
                              PanelYC();
                              this.panelsr.Visible = true;
                              ViewState["State"] = "Update";
                              EditSR();
                          }
                          else
                          {
                              XS();
                          }
                      }
                      else if (Count3 == "4")  //办公室审批完毕
                      {
                          PanelYC();
                          this.panelxs.Visible = true;
                          XS();
                      } 
                 }
             }

        }
    }

    #region  panel隐藏

    private void PanelYC()
    {
        this.panel1.Visible = false;
        this.panelsr.Visible = false;
        this.panelxs.Visible = false;

    }
    #endregion

    #region  显示已经有的信息

    private void XS()
    {
        str = new StringBuilder();
        lblxs.Text = "";
        str.Append("<table width=\"100%\">");   //定义表开始
        string strSOrdNet = "select Order_ID,Title,Net,Type,Content,Unit,Man,Time,Adjunct,Personnel,Net_Guid from" +
                    " SOrdNet where Order_ID = '" + ViewState["Order_ID"].ToString() + "'";
        DataRow SOrdNetRow = db.GetDataRow(strSOrdNet);
        
        str.Append(" <tr> <td colspan=\"4\" align=\"center\">   警卫局网站信息报送审批表 </td> </tr>" +
             "<tr> <td  align=\"center\" style=\"width: 25%\"> 勤务编号</td> <td colspan=\"3\"> " +
                    SOrdNetRow[0].ToString().Trim() + "</td></tr> " +
            "<tr><td  align=\"center\" style=\"width: 25%\"> 信息标题</td><td colspan=\"3\"> " +
                    SOrdNetRow[1].ToString().Trim() + "</td></tr> " +
            "<tr><td  align=\"center\" style=\"width: 25%\">拟发网站</td><td  align=\"center\" style=\"width: 25%\"> " +
                    SOrdNetRow[2].ToString().Trim() + "</td> <td  align=\"center\" style=\"width: 25%\">栏目</td>" +
                    SOrdNetRow[3].ToString().Trim() + "</td> </tr>" +
             "<tr><td colspan=\"4\" align=\"center\">内容</td></tr>" +
             "<tr><td colspan=\"4\" align=\"center\"> " +
                   SOrdNetRow[4].ToString().Trim() + "</td> </tr> " +
                "<tr> <td align=\"center\">附件：</td><td colspan=\"3\"> ");
        str.Append("<iframe  style=\"overflow: auto; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 550px; height: 120px;\"   src = \"Abjunct.aspx?AttachmentBatch_Guid='" + SOrdNetRow[8].ToString().Trim() + "'\"></iframe>");
                   
                str.Append("</td></tr> " +
               "<tr> <td align=\"center\">承办单位</td>" +
                "<td>" + SOrdNetRow[5].ToString().Trim() + "</td>" +
               "<td>拟稿人</td> <td style=\"width: 189px\">" +
                    SOrdNetRow[6].ToString().Trim() + "</td> </tr>" +
                "<tr> <td align=\"center\">拟稿时间</td>" +
                "<td>" + SOrdNetRow[7].ToString().Trim() + "</td> " +
                "<td>  部门拟稿</td> <td style=\"width: 189px\">" +
                    SOrdNetRow[9].ToString().Trim() + "</td></tr> ");


        string strSOrdNetAuditing = "select OrderNotion,PerNumber from SOrdNetAuditing where Net_Guid = '" + SOrdNetRow[10].ToString().Trim() + "' and StatusId <> '1'";
        DataTable SOrdNetAuditingtable = db.GetDataTable(strSOrdNetAuditing);
        for (int i = 0; i < SOrdNetAuditingtable.Rows.Count; i++)
        {
             str.Append(" <tr> <td align=\"center\" style=\"width=25%; height: 51px;\">领导意见</td> " +
                       "  <td align=\"left\" style=\"width=75%; height: 51px;\"> " +
                           SOrdNetAuditingtable.Rows[i][0].ToString() + "</td></tr> " +
                    "<tr> <td style=\"height: 4px\"></td> " +
                        "<td align=\"right\" style=\"width=75%; height: 4px;\"> " +
                             SOrdNetAuditingtable.Rows[i][1].ToString() + "</td> </tr>");
        }

        str.Append("</table>");
        lblxs.Text = str.ToString();
    }


    private void EditSR()
    {
        string strSOrdNet = "select Order_ID,Title,Net,Type,Content,Unit,Man,Time,Adjunct,Personnel,Net_Guid from" +
                  " SOrdNet where Order_ID = '" + ViewState["Order_ID"].ToString() + "'";
        DataRow SOrdNetRow = db.GetDataRow(strSOrdNet);

        this.txtTitle.Text = SOrdNetRow["Title"].ToString();  //标题
        if (SOrdNetRow["Net"].ToString().Trim() == "八局网站")　　//拟发网站
        {
            this.CheckNet1.Checked = true;
            this.CheckNet2.Checked = false;
            this.CheckNet3.Checked = false;
        }
        else if (SOrdNetRow["Net"].ToString().Trim() == "省厅网站")
        {
            this.CheckNet1.Checked = false;
            this.CheckNet2.Checked = true;
            this.CheckNet3.Checked = false;
        }
        else if (SOrdNetRow["Net"].ToString().Trim() == "省局网站")
        {
            this.CheckNet1.Checked = false;
            this.CheckNet2.Checked = false;
            this.CheckNet3.Checked = true;
        }

        if (SOrdNetRow["Type"].ToString().Trim() == "发布栏目")　　//栏目
        {
            this.radType1.Checked = true;
        }
        else if (SOrdNetRow["Type"].ToString().Trim() == "发布子栏目")
        {
            this.radType2.Checked = true;
        }
        else if (SOrdNetRow["Type"].ToString().Trim() == "勤务信息")
        {
            this.radType3.Checked = true;
        }
        else if (SOrdNetRow["Type"].ToString().Trim() == "现场勤务")
        {
            this.radType4.Checked = true;
        }

        this.txtContent.Text = SOrdNetRow["Content"].ToString().Trim();  //内容
        XSFile(SOrdNetRow["Adjunct"].ToString());
        this.txtUnit.Text = SOrdNetRow["Unit"].ToString().Trim();    //承办单位
        this.lblMan.Text = SOrdNetRow["Man"].ToString().Trim();    //拟稿人
        this.lblTime.Text = SOrdNetRow["Time"].ToString().Trim();    //拟稿时间
        
    }

    private void UpdateLDXG()
    {
        string OrderNotion = db.GetDataScalar("select OrderNotion from SOrdNetAuditing where StatusId = '1' and Net_Guid  = '"
                             + ViewState["Net_Guid"].ToString() + "'");
        this.txtOrderNotion.Text = OrderNotion;
    }

    #endregion

    private string SaveNet(string Personnel)
    {
        if (drpOrder_ID.SelectedValue == "0")
        {
            return "请选择要操作的勤务的编号";
        }
        string Net_Guid = Guid.NewGuid().ToString();
        if(ViewState["Net_Guid"] == null || ViewState["Net_Guid"].ToString() == "")
        {
            ViewState["Net_Guid"] = Net_Guid;  //得到编号
        }
        string Title = this.txtTitle.Text.Trim();  //标题　
      
        string Net = "";
        if (CheckNet1.Checked == true)
        {
            Net = "八局网站";
        }
        else if (CheckNet2.Checked == true)
        {
            Net = "省厅网站";
        }
        else if (CheckNet3.Checked == true)
        {
            Net = "省局网站";
        }

        string Type = "";
        if (radType1.Checked == true)
        {
            Type = "发布栏目";
        }
        else if (radType2.Checked == true)
        {
            Type = "发布子栏目";
        }
        else if (radType3.Checked == true)
        {
            Type = "勤务信息";
        }
        else if (radType4.Checked == true)
        {
            Type = "现场勤务";
        }
        string Unit1 = this.txtUnit.Text.Trim();  //单位
        string Content  = this.txtContent.Text.Trim();  //内容

        string Man = "";  //得到当前的用户名ID
        string Time = this.lblTime.Text.Trim();   //时间
        string Adjunct = "";
        if (ViewState["AttachmentBatch_Guid"] == null || ViewState["AttachmentBatch_Guid"].ToString() == "")
        {

        }
        else
        {
            Adjunct = ViewState["AttachmentBatch_Guid"].ToString(); //要改的　
        }
      
        if (ViewState["State"].ToString() == "Insert")　　
        {
            string Insert = "INSERT INTO SOrdNet([Order_ID],[Net_Guid],[Title],[Net],[Type],[Content],[Unit],[Man] ,[Time] ,[Adjunct] ,[CreatedBy]," +
                "[CreatedDate] ,[StatusId] ) VALUES ('" + drpOrder_ID.SelectedValue + "','" + ViewState["Net_Guid"].ToString() + "','" + Title + "','" + Net + "','" + Type + "','" + Content + "','" +
                Unit1 + "','" + ViewState["Satff_Id"].ToString() + "','" + Time + "','" + Adjunct + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),1)";
            try
            {
                db.executeInsert(Insert);
                return "保存成功";
            }
            catch(Exception er)
            {
                return er.Message;
            }

        }
        else if (ViewState["State"].ToString() == "Update")
        {


            string Update = "UPDATE SOrdNet set " +
            "[Net_Guid] = '" +  Net_Guid+ "'," +
            "[Title] = '" +  Title+ "'," +
            "[Net] = '" +  Net+ "'," +
            "[Type] = '" +  Type+ "'," +
            "[Content] = '" +  Content+ "'," +
            "[Unit] = '" +  Unit1 + "'," +
            "[Man] = '" +  Man+ "'," +
            "[Time] = '" +  Time+ "'," +
            "[Adjunct] = '" +  Adjunct+ "'," +
            "[Personnel] = '" +  Personnel+ "'," +
            "[ModifiedBy] = '" + ViewState["Satff_Id"].ToString() + "'," +
            "[ModifiedDate] = getdate() WHERE Order_ID = '" + ViewState["Order_ID"].ToString() + "'";

            try
            {
                db.executeUpdate(Update);
                return "修改成功";
            }
            catch (Exception er)
            {
                return er.Message;
            }
        }
        return "";
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (ViewState["State"] == null || ViewState["State"].ToString() == "")
        {
            Response.Redirect("DutyNetSend.aspx?state=3&Order_ID=" + ViewState["Order_ID"].ToString() + "&Net_Guid=" + ViewState["Net_Guid"].ToString());
        }
        else
        {
            if (ViewState["State"].ToString() == "Insert")   //第一次填写填写
            {
                string Update = "update SOrdNet set StatusId = '2' where Order_ID = '" + ViewState["Order_ID"].ToString() + "'";  //状态改成2
                db.executeUpdate(Update);
            }
            else if (ViewState["State"].ToString() == "Update")
            {
                string state = db.GetDataScalar("select StatusId from SOrdNet where  Order_ID = '" + ViewState["Order_ID"].ToString() + "'");
                if (state == "1")
                {
                    string Update = "update SOrdNet set StatusId = '2' where Order_ID = '" + ViewState["Order_ID"].ToString() + "'";  //状态改成2
                    db.executeUpdate(Update);
                }
                else
                {
                    Response.Redirect("DutyNetSend.aspx?state=" + state + "&Order_ID=" + ViewState["Order_ID"].ToString() + "&Net_Guid=" + ViewState["Net_Guid"].ToString());
                }

            }
         
        }
    }

    //办公室签名
    protected void btnPersonnel_Click(object sender, EventArgs e)
    {
        string Personnel = "审批通过";
        ViewState["State"] = "Update";
        WebWindow.alert(SaveNet(Personnel));　//办公室审批
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
         WebWindow.alert(SaveNet(""));　
    }

    //领导审批
    protected void btnPerNumber_Click(object sender, EventArgs e)
    {
        string PerNumber = "通过";
        if (Label1.Text == "LDXG")   //修改保存记录 
        {
            string Update = "Update SOrdNetAuditing set OrderNotion = '" + this.txtOrderNotion.Text.Trim() + "',ModifiedBy = '" + ViewState["Satff_Id"].ToString() + "',ModifiedDate = getdate() where Net_Guid = '" +
                ViewState["Net_Guid"].ToString() + "' and StatusId = '1'";
           
            try
            {
                db.executeUpdate(Update);
                WebWindow.alert("审批修改成功");
            }
            catch (Exception er)
            {
                WebWindow.alert(er.Message);
            }
        }
        else   //添加记录
        {
            string Insert = "insert into SOrdNetAuditing(Guid,Net_Guid,Per_ID,OrderNotion,PerNumber,CreatedBy,CreatedDate,StatusId)" +
           " values ('" + Guid.NewGuid().ToString() + "','" + ViewState["Net_Guid"].ToString() + "','" + ViewState["Satff_Id"].ToString() + "','" +
           this.txtOrderNotion.Text.Trim() + "','" + PerNumber + "','" + ViewState["Satff_Id"].ToString() + "',getdate(),1)";
            try
            {
                db.executeInsert(Insert);
                WebWindow.alert("审批成功");
            }
            catch (Exception er)
            {
                WebWindow.alert(er.Message);
            }
        }
  
    }


    protected void dropOrderNotion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtOrderNotion.Text = dropOrderNotion.SelectedItem.Text.Trim();

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

    //依据批次去查询
    private void XSFile(string AttachmentBatch_Guid)
    {
        string StrselectFile = "SELECT  max(AttachmentBatch_Guid) as AttachmentBatch_Guid, FileName,max (CreatedDate) as CreatedDate " +
            " FROM SSysAttachment where AttachmentBatch_Guid = '" + AttachmentBatch_Guid + "'  Group by FileName";

        DataTable AbjunctTable = db.GetDataTable(StrselectFile);
        GVAbjunct.DataSource = AbjunctTable;
        GVAbjunct.DataBind();
    }

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
        string Folder = "E://File/Order/DutyNet/" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() +
            System.DateTime.Now.Day.ToString() + "/";  //路径


        if (Directory.Exists(Folder) == false)  //测试路径存不存在
        {
            Directory.CreateDirectory(Folder);  //创建路径 
        }

        string lstrFileNamePath = Folder + SaveFileName;
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
