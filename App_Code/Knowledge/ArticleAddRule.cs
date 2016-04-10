using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;

public class ArticleAddRule
{
    private static string ConnStr;
    MDataBase db;
    ControlDataBind ControlDBind;
    public ArticleAddRule(string ConnetionString)
    {
        ConnStr = ConnetionString;
        db = new MDataBase(ConnStr);
        ControlDBind = new ControlDataBind(ConnStr);
    }

    public string sql;
    KnowledgeArticleSql KnowledgeArticleSql = new KnowledgeArticleSql();
    public void DDLArticleTypeBind(DropDownList DDList,string SessionID)
    {
        ControlDBind.DropDownListBind(DDList, "SCKbs_ArticleType order by OrderIndex", "ArticleTypeName", "ArticleType_Id", 1, "", SessionID);
    }

    public void DDLArticleLevelBind(DropDownList DDList, string SessionID)
    {
        ControlDBind.DropDownListBind(DDList, "SCKbs_ArticleLevel order by OrderIndex", "ArticleLevelName", "ArticleLevel_Id", 1, "", SessionID);
    }

    public void AddArticle(string KBaseArticleGuid,string KBaseArticleId,string ArticleTitle,string ArticleWriter,string ArticleType, string ArticleLevel, string ArticleContent,string ArticlePoint,string Keyword1,string Keyword2,string Keyword3,string StartDate,string AbolishDate,string StaffId)
    {
        try
        {
            //string StrDateTime = GetInformation.GetCurrentDataTime();
            sql = KnowledgeArticleSql.AddAticleSql(KBaseArticleGuid, KBaseArticleId, ArticleTitle, ArticleWriter, ArticleType, ArticleLevel, ArticleContent, ArticlePoint, Keyword1, Keyword2, Keyword3, StartDate, AbolishDate, StaffId);
            db.executeInsert(sql);
            WebWindow.alert("文章添加成功!");
            WebWindow.Close();
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/KnowledgeBase/ArticleAddRule", StaffId);
            WebWindow.alert("文章内容过多!");
            return;
        }
    }

    public void ReturnData(string FileName, Label Content,Label Message)
    {
        string FName = FileName;
        if (!FName.EndsWith(".htm") && !FName.EndsWith(".html") && !FName.EndsWith(".txt"))//&& !FName.EndsWith(".doc"))
        {
            Message.Text = "导入文件只能是.htm/.html/.txt格式!";//.doc
            return;
        }
        //System.IO.FileInfo FileInfoobj = new System.IO.FileInfo(FileInput.Value);
        //StreamReader sr = FileInfoobj.OpenText();
        //TxtArticleContent.Text = sr.ReadToEnd().ToString();
        //LabelMessage.Text = "";
        //sr.Dispose();

        FileStream m_FileStream = new FileStream(FName, FileMode.Open, FileAccess.Read);
        StreamReader m_StreamReader = new StreamReader(m_FileStream, Encoding.Default);
        //m_StreamReader.BaseStream.Seek(0, SeekOrigin.Begin);
        string Returnstring = m_StreamReader.ReadToEnd();
        //if (!FName.EndsWith(".txt"))
        //{
        //Returnstring = GetInformation.ReturnHtmlStr(Returnstring);
        //}
        //Session["Content"] = Returnstring;
        //TxtArticleContent.Text = Returnstring;//m_StreamReader.ReadToEnd();
        Content.Text = "<iframe frameborder='0' marginheight='0' marginwidth='0' width='100%' scrolling='auto' src='Article.aspx'></iframe>";
        m_FileStream.Close();
    }
}
