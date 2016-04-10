using System;
using System.Web;

public class WebWindow
{
    /// <summary>
    /// 在客户端浏览器输出window.Open()方法
    /// </summary>	

    public static void Open(string toPage, string pageName, int pageWidth, int pageHeight)
    {
        System.Web.HttpContext.Current.Response.Write("<Script language='JavaScript'>");
        System.Web.HttpContext.Current.Response.Write("window.open('" + toPage + "','" + pageName + "','width=" + pageWidth.ToString() + ",height=" + pageHeight.ToString() + ",top=0,left=0,menubar=no,scrollbars=yes,resizable=no');");
        System.Web.HttpContext.Current.Response.Write("</Script>");
    }

    /// <summary>
    /// 在客户端浏览器输出window.Open()方法
    /// </summary>
    /// <param name="toPage"></param>
    /// <param name="pageName"></param>
    public static void Open(string toPage, string pageName)
    {
        System.Web.HttpContext.Current.Response.Write("<Script language='JavaScript'>");
        System.Web.HttpContext.Current.Response.Write("window.open('" + toPage + "','" + pageName + "','top=0,left=0,menubar=no,scrollbars=yes,resizable=no');");
        System.Web.HttpContext.Current.Response.Write("</Script>");
    }

    /// <param name="pageName"></param>
    public static void Openn(string toPage, string pageName)
    {
        System.Web.HttpContext.Current.Response.Write("<Script language='JavaScript'>");
        System.Web.HttpContext.Current.Response.Write("if(newWin!=null){newWin.window.close();} newWin=window.open('" + toPage + "','" + pageName + "','top=0,left=0,menubar=no,scrollbars=yes,resizable=no');");
        System.Web.HttpContext.Current.Response.Write("</Script>");
    }

    /// <summary>
    /// 在客户端浏览器输出window.close()方法
    /// </summary>
    public static void Close()
    {
        System.Web.HttpContext.Current.Response.Write("<Script language='JavaScript'>");
        System.Web.HttpContext.Current.Response.Write("window.close();");
        System.Web.HttpContext.Current.Response.Write("</Script>");
    }

    /// <summary>
    /// 在客户端浏览器输出window.close()方法，并刷新refreshPage页
    /// </summary>
    /// <param name="refreshPage"></param>
    public static void Close(string refreshPage)
    {
        System.Web.HttpContext.Current.Response.Write("<Script language='JavaScript'>");
        System.Web.HttpContext.Current.Response.Write("window.opener.location.href('" + refreshPage + "');");
        System.Web.HttpContext.Current.Response.Write("window.close();");
        System.Web.HttpContext.Current.Response.Write("</Script>");
    }

    public static void RefreshTop(string refreshPage)
    {
        System.Web.HttpContext.Current.Response.Write("<Script language='JavaScript'>");
        System.Web.HttpContext.Current.Response.Write("top.location='" + refreshPage + "'");
        System.Web.HttpContext.Current.Response.Write("</Script>");
    }

    public static void RefreshParent(string refreshPage)
    {
        System.Web.HttpContext.Current.Response.Write("<Script language='JavaScript'>");
        System.Web.HttpContext.Current.Response.Write("window.parent.location='" + refreshPage + "'");
        System.Web.HttpContext.Current.Response.Write("</Script>");
    }

    public static void RefreshParent2(string refreshPage)
    {
        System.Web.HttpContext.Current.Response.Write("<Script language='JavaScript'>");
        System.Web.HttpContext.Current.Response.Write("window.parent.parent.location='" + refreshPage + "'");
        System.Web.HttpContext.Current.Response.Write("</Script>");
    }

    public static void Refresh(string refreshPage)
    {
        System.Web.HttpContext.Current.Response.Write("<Script language='JavaScript'>");
        System.Web.HttpContext.Current.Response.Write("window.location.href='" + refreshPage + "'");
        System.Web.HttpContext.Current.Response.Write("</Script>");
    }

    /// <summary>
    /// 在屏幕上显示一下警告框
    /// </summary>
    /// <param name="str">提示信息</param>
    public static void alert(string str)
    {
        str = str.Replace("'", "\\'");
        System.Web.HttpContext.Current.Response.Write("<Script language='JavaScript'>");
        System.Web.HttpContext.Current.Response.Write("alert('" + System.Web.HttpUtility.HtmlEncode(str) + "')");
        System.Web.HttpContext.Current.Response.Write("</Script>");
    }

    public static void OpenIframe(string IframeId,string Src)
    {
        System.Web.HttpContext.Current.Response.Write("<Script language='JavaScript'>");
        System.Web.HttpContext.Current.Response.Write("document.getElementById(\"" + IframeId + "\").src=\"" + Src + "\"");
        System.Web.HttpContext.Current.Response.Write("</Script>");
    }

    public static void Replace(string replacePage)
    {
        System.Web.HttpContext.Current.Response.Write("<Script language=\"JavaScript\">");
        System.Web.HttpContext.Current.Response.Write("window.location.replace='" + replacePage + "'");
        System.Web.HttpContext.Current.Response.Write("</Script>");
    }
}

