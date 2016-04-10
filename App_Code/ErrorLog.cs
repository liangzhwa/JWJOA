using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// ErrorLog 的摘要说明
/// </summary>
public class ErrorLog
{
	public ErrorLog()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static bool LogInsert(string message, string src, string Staff_Id) 
    {
        CSSysErrorLog ErrorLogWrite = new CSSysErrorLog();
        ErrorLogWrite.ID = Guid.NewGuid().ToString();
        ErrorLogWrite.Message = message.Replace("'","''");
        ErrorLogWrite.Src = src.Replace("'", "''");
        ErrorLogWrite.Staff_Id = Staff_Id;
        bool BoolReturn=ErrorLogWrite.Insert();
        return BoolReturn;
    }
}
