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
using System.IO;

public partial class DutyManager_Abjunct : System.Web.UI.Page
{
    MDataBase db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!this.IsPostBack)
        {
            string AttachmentBatch_Guid = "56e24e8a-3380-4ca8-827e-1fc17574978b";
      

            string StrselectFile = "SELECT  max(AttachmentBatch_Guid) as AttachmentBatch_Guid, FileName,max (CreatedDate) as CreatedDate " +
             " FROM SSysAttachment where AttachmentBatch_Guid = '" + AttachmentBatch_Guid + "'  Group by FileName";

            

            DataTable AbjunctTable = db.GetDataTable(StrselectFile);
            GVAbjunct.DataSource = AbjunctTable;
            GVAbjunct.DataBind();
        }
        
      
    }
    //下载
    protected void GVAbjunct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        int i = e.RowIndex;
        GVAbjunct.Rows[i].Cells[0].Text = "√";             //将选定行标记成√
        string AttachmentBatch_Guid = GVAbjunct.Rows[i].Cells[1].Text.Trim();  //勤务编号
        string FileName =  GVAbjunct.Rows[i].Cells[2].Text.Trim();  //名称
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
  
    
}
