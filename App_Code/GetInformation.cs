//================================================================================
// 模块名称:获取信息类
// 开发人员:ZNN
// 创建日期:2007年05月9日
// 模块说明:SqlServer
//================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;


public class GetInformation
{
    private static string ConnStr;
    public GetInformation(string ConnetionString)
    {
        ConnStr = ConnetionString;
        db = new MDataBase(ConnStr);
    }
    private static MDataBase db;


    private string sql, StrCount="0";
    /// <summary>
    /// 获取系统当前日期
    /// </summary>
    /// <returns>返回当前日期</returns>
    public static string GetCurrentDate()
    {
        //return System.DateTime.Now.Date.ToShortDateString();
        return System.DateTime.Now.ToShortDateString();
    }

    /// <summary>
    /// 获取系统当前日期时间
    /// </summary>
    /// <returns>返回当前日期时间</returns>
    public static string GetCurrentDataTime()
    {
        return System.DateTime.Now.ToString();
    }

    public static int GetCheckBoxValue(CheckBox CheBox)
    {
        int IntValue = 0;
        if (CheBox.Checked == true)
        {
            IntValue = 0;
        }
        else if (CheBox.Checked == false)
        {
            IntValue = 1;
        }
        return IntValue;
    }

    public static int GetInputCheckBoxValue(HtmlInputCheckBox CheBox)
    {
        int IntValue = 0;
        if (CheBox.Checked)
        {
            IntValue = 0;
        }
        else
        {
            IntValue = 1;
        }
        return IntValue;
    }

    public static bool GetCheckBoxStatu(Int32 IntValue)
    {
        if (IntValue==0)
        {
            return true;
        }
        else if (IntValue == 1)
        {
            return false;
        }
        return false;
    }

    /// <summary>
    /// 获取系统当前时间
    /// </summary>
    /// <returns>返回当前时间</returns>
    public static string GetCurrentTime()
    {
        return System.DateTime.Now.ToShortTimeString();
        //return System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() +
        //                                                  ":" + System.DateTime.Now.Second.ToString();
    }

    /// <summary>
    /// 获取yyyy-MM-dd格式日期
    /// </summary>
    /// <returns>返回yyyy-MM-dd格式日期</returns>
    public static string GetShortDate(string StrDate)
    {
        try
        {
            string Date = Convert.ToDateTime(StrDate).ToString("yyyy-MM-dd");
            string IntDate = Convert.ToDateTime("1900-1-1").ToString("yyyy-MM-dd");
            if (Date != IntDate)
            {
                return Date;
            }
            else
            {
                return "";
            }
        }
        catch (Exception Err)
        {
            //ErrorLog.LogInsert(Err.Message, "CS/GetInformation", SessionID.ToString());
            return "";
        }
    }

    public static bool IsDateTime(string StrDate)
    {
        try
        {
            if (StrDate != "")
            {
                DateTime Ddt = Convert.ToDateTime(StrDate);
                return true;
            }
            return true;
        }
        catch (Exception Err)
        {
            return false;
        }
    }

    public static bool IsNumber(string StrNumber)
    {
        try
        {
            if (StrNumber != "")
            {

                Double dt = Convert.ToDouble(StrNumber);
                return true;
            }
            return true;
        }
        catch (Exception Err)
        {
            return false;
        }
    }

    public static bool CheckISNum(string StrText)
    {
        string strMatch = @"^[0-9]*[1-9][0-9]*$";
        return Regex.IsMatch(StrText, strMatch);
    }

    /// <summary>
    /// 获取最大值序号
    /// </summary>
    /// <param name="DataTable"></param>
    /// <param name="MaxFieldText"></param>
    /// <param name="FieldText"></param>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public string GetMaxValue(string DataTable, string MaxFieldText, string FieldText, string FieldValue)
    {
        try
        {
            sql = GetInfomationSql.GetMaxValueSql(DataTable, MaxFieldText, FieldText, FieldValue);
            string StrMaxValue = db.GetDataScalar(sql).ToString();
            if (StrMaxValue == null || StrMaxValue == "")
            {
                StrMaxValue = "-1";
            }
            return StrMaxValue;
        }
        catch (Exception Err)
        {
            //ErrorLog.LogInsert(Err.Message, "CS/GetInformation", StaffID);
            return "";
        }
    }

    /// <summary>
    /// 获取总数
    /// </summary>
    /// <param name="DataTable"></param>
    /// <param name="MaxFieldText"></param>
    /// <param name="FieldText"></param>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public int GetIntCount(string DataTable, string FieldText, string FieldValue, string SessionID)
    {
        try
        {
            sql = GetInfomationSql.GetIntCountSql(DataTable, FieldText, FieldValue);
            StrCount = db.GetDataScalar(sql);
            return Convert.ToInt32(StrCount);
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/GetInformation", SessionID);
            return 0;
        }
    }

    /// <summary>
    /// 获取总数
    /// </summary>
    /// <param name="DataTable"></param>
    /// <param name="MaxFieldText"></param>
    /// <param name="FieldText"></param>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public int GetIntCount(string DataTable, string FieldText, string FieldValue,string StrCondition,string SessionID)
    {
        try
        {
            sql = GetInfomationSql.GetIntCountSql(DataTable, FieldText, FieldValue, StrCondition);
            StrCount = db.GetDataScalar(sql);
            return Convert.ToInt32(StrCount);
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/GetInformation", SessionID);
            return 0;
        }
    }

    /// <summary>
    /// 判断某页面是否具有浏览权限
    /// </summary>
    /// <param name="StaffId">登陆Id</param>
    /// <param name="FunctionOrgGuid">页面设定</param>
    /// <returns></returns>
    public bool GetStaffQX(string StaffId,string FunctionOrgId)
    {
        try
        {
            sql = "SELECT count(*) FROM SCtiRoleMenu B INNER JOIN SCtiStaffProjectRole A ON B.Role_Id = A.Role_Id INNER JOIN SCtiMenus C ON B.Menu_Id = C.Menu_Id WHERE A.Staff_Id='" + StaffId + "' and  (C.Function1_Id = '" + FunctionOrgId + "') OR (C.Function2_Id ='" + FunctionOrgId + "') OR (C.Function3_Id = '" + FunctionOrgId + "') OR (C.Function4_Id = '" + FunctionOrgId + "')";
            StrCount = db.GetDataScalar(sql);
            if (Convert.ToInt32(StrCount) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception Err)
        {
            //ErrorLog.LogInsert(Err.Message, "CS/GetInformation", SessionID.ToString());
            return false;
        }
    }

    /// <summary>
    /// 根据选中CheckBox来删除记录，获取true/false
    /// </summary>
    /// <param name="DGrid"></param>
    /// <param name="DataTable"></param>
    /// <param name="DataFieldText"></param>
    /// <param name="CheckBoxID"></param>
    /// <param name="InputID"></param>
    public bool DeleteBCheckBox(DataGrid DGrid, string DataTable, string DataFieldText, string CheckBoxID, string InputID, string SessionID)
    {
        try
        {
            System.Web.UI.WebControls.CheckBox chkExport;
            string sID = "";
            bool result = false;
            foreach (DataGridItem oDataGridItem in DGrid.Items)
            {
                chkExport = (CheckBox)oDataGridItem.FindControl(CheckBoxID);
                if (chkExport.Checked)
                {
                    sql = GetInfomationSql.DeleteBCheckBoxSql(DataTable, DataFieldText, ((HtmlInputHidden)oDataGridItem.FindControl(InputID)).Value);
                    db.executeDelete(sql);
                    sID = ((HtmlInputHidden)oDataGridItem.FindControl(InputID)).Value;
                    sID += sID;
                    result = true;
                }
            }
            if (sID.Length < 1)
            {
                result = false;
            }
            return result;
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/GetInformation", SessionID);
            return false;
        }
    }

    public bool DeleteByStatus(DataGrid DGrid, string DataTable, string DataFieldText, string CheckBoxID, string InputID, string SessionID)
    {
        try
        {
            System.Web.UI.WebControls.CheckBox chkExport;
            string sID = "";
            bool result = false;
            foreach (DataGridItem oDataGridItem in DGrid.Items)
            {
                chkExport = (CheckBox)oDataGridItem.FindControl(CheckBoxID);
                if (chkExport.Checked)
                {
                    sql = GetInfomationSql.DeleteBStatusSql(DataTable, DataFieldText, ((HtmlInputHidden)oDataGridItem.FindControl(InputID)).Value);
                    db.executeDelete(sql);
                    sID = ((HtmlInputHidden)oDataGridItem.FindControl(InputID)).Value;
                    sID += sID;
                    result = true;
                }
            }
            if (sID.Length < 1)
            {
                result = false;
            }
            return result;
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/GetInformation", SessionID);
            return false;
        }
    }

    /// <summary>
    /// 根据数据字段FieldText删除表DataTable内数据
    /// </summary>
    /// <param name="DataTable"></param>
    /// <param name="FieldText"></param>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public bool DelTableDate(string DataTable, string FieldText, string FieldValue, string SessionID)
    {
        try
        {
            sql = "delete from " + DataTable + " where " + FieldText + "='" + FieldValue + "'";
            db.executeDelete(sql);
            return true;
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/GetInformation", SessionID);
            return false;
        }
    }

    public bool DelTableDateByStatus(string DataTable, string FieldText, string FieldValue, string SessionID)
    {
        try
        {
            sql = "update " + DataTable + " set StatusID='1' where " + FieldText + "='" + FieldValue + "'";
            db.executeDelete(sql);
            return true;
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/GetInformation", SessionID);
            return false;
        }
    }

    public string StrMax(string DataTable, string MaxFieldText)
    {
        string Sql = "select max(" + MaxFieldText + ")+1 from " + DataTable + "";
        string StrMaxValue = db.GetDataScalar(Sql).ToString();
        if (StrMaxValue == null || StrMaxValue == "")
        {
            StrMaxValue = "0";
        }
        return StrMaxValue;
    }

    //有问题，<和>运算符号，暂时不用
    public static string ReturnStr(string StrHtml)
    {
        int i, StartI, EndI, bodyI;
        string sTag = "";
        string[] LineTags = new string[] { "</P>", "<BR>", "</TR>", "<LI>", "</OL>", "</UL>", "</H1>", "</H2>", "</H3>", "</H4>", "</H5>", "</H6>", "</H7>" };
        StrHtml = RemoveStyle(StrHtml);
        StrHtml = RemoveScript(StrHtml);

        int l = StrHtml.Length;
        bodyI = StrHtml.IndexOf("<body");
        if (bodyI == -1)
            bodyI = 0;
        bodyI = StrHtml.IndexOf("<BODY");
        if (bodyI == -1)
            bodyI = 0;
        for (i = bodyI; i < l; i++)
        {
            if (StrHtml[i].ToString() == "<")
            {
                StartI = i;
                EndI = StrHtml.IndexOf(">", StartI);
                if (EndI == -1)
                    EndI = l;
                //EndI = 0;

                //if (!Char.IsNumber(StrHtml, i + 1))//如何判断?是否为html常用标记
                //{
                    //EndI2 = StrHtml.IndexOf("<");
                    //if (EndI < EndI2)
                    //{
                    for (int j = 0; j < LineTags.Length; j++)
                    {
                        if ((StrHtml.Substring(StartI, EndI - StartI)).IndexOf(LineTags[j]) >= 0)
                        {
                            sTag += "\n";
                        }
                        //    sTag = sTag.Replace(StrHtml.Substring(StartI, EndI - StartI), "");
                    }
                    i += EndI - StartI;
                //}
                //else 
                //{
                //    sTag += StrHtml.Substring(StartI-1, EndI - StartI);
                //    i += EndI - StartI;
                //}
                //}
            }
            else
                sTag += StrHtml[i].ToString();
        }
        sTag = sTag.Replace("\r", "");//处理\r
        sTag = sTag.Replace("\t", "");//处理\r
        sTag = sTag.Replace("&nbsp;", "");//处理\r
        sTag = sTag.TrimStart('\n');//处理前面\n
        sTag = sTag.TrimEnd('\n');//处理后面\n

        if (sTag.IndexOf("\n\n\n") >= 0)
            sTag = sTag.Replace("\n\n\n", "\n");
        if (sTag.IndexOf("\n\n\n") >= 0)
            sTag = sTag.Replace("\n\n\n", "\n");
        //int c = sTag.Length;
        //for (int j = 0; j < c; j++)
        //{
        //    if (sTag.IndexOf("\n\n") >= 0)
        //    {
        //        sTag = sTag.Replace("\n\n", "\n");
        //    }
        //    j++;
        //}
            return sTag;
        //(/n: 换行符,/s:空格,/r:回车符)
    }

    public static string ReturnHtmlStr(string StrHtml)
    { 
        string sTag="<iframe id='RH'  frameborder='0'scrolling='auto'>"+StrHtml+"</iframe>";
        return sTag;
    }

    private static int styleI1 = 0, styleI2 = 0,  scriptI1 = 0, scriptI2 = 0;
    private static string RemoveStyle(string StrHtml)
    {
        int b = 20;
        for (int i = 0; i < b; i++)
        {
            styleI1 = StrHtml.IndexOf("<style");
            styleI2 = StrHtml.IndexOf("</style>");
            if (styleI1 != -1 && styleI2 != -1)
                StrHtml = StrHtml.Substring(0, styleI1) + StrHtml.Substring(styleI2 + 8);
            else
                break;
            i++;
        }
        for (int i = 0; i < b; i++)
        {
            styleI1 = StrHtml.IndexOf("<STYLE");
            styleI2 = StrHtml.IndexOf("</STYLE>");
            if (styleI1 != -1 && styleI2 != -1)
                StrHtml = StrHtml.Substring(0, styleI1) + StrHtml.Substring(styleI2 + 8);
            else
                break;
            i++;
        }
        return StrHtml;
    }

    private static string RemoveScript(string StrHtml)
    {
        int b = 100;
        for(int i=0;i<b;i++)
        {
            scriptI1 = StrHtml.IndexOf("<SCRIPT");
            scriptI2 = StrHtml.IndexOf("</SCRIPT>");
            if (scriptI1 != -1 && scriptI2 != -1)
                StrHtml = StrHtml.Substring(0, scriptI1) + StrHtml.Substring(scriptI2 + 9);
            else
                break;
            i++;
        }
        for (int i = 0; i < b; i++)
        {
            scriptI1 = StrHtml.IndexOf("<script");
            scriptI2 = StrHtml.IndexOf("</script>");
            if (scriptI1 != -1 && scriptI2 != -1)
                StrHtml = StrHtml.Substring(0, scriptI1) + StrHtml.Substring(scriptI2 + 9);
            else
                break;
            i++;
        }
        return StrHtml;
    }
}

