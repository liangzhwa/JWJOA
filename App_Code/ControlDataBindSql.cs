using System;
using System.Collections.Generic;
using System.Text;

public class ControlDataBindSql
{
    private static string sql;

    public static string DropDownListBindSql(string DataTable, string DataName, string DataId, string StrCondition)
    {
        sql = "select " + DataName + "," + DataId + " from " + DataTable + "";
        if (StrCondition != "")
        {
            sql += " where " + StrCondition + "";
        }
        return sql;
    }

    public static string AddNodesSql(string DataTable, string ParentGuid, string PidValue, string StrCondition, string OrderFieldText)
    {
        sql = "select * from " + DataTable + "  where " + ParentGuid + "='" + PidValue + "' and StatusID='0'";
        if (StrCondition != "")
        {
            sql += " and " + StrCondition + "";
        }
        if (OrderFieldText != "")
        {
            sql += " Order by " + OrderFieldText + "";
        }
        return sql;
    }

     public static string AddPNodesSql(string DataTable,string StrCondition, string OrderFieldText)
    {
        sql = "select * from " + DataTable + "  where StatusID = 0";
        if (StrCondition != "")
        {
            sql += " and " + StrCondition + "";
        }
        if (OrderFieldText != "")
        {
            sql += " Order by " + OrderFieldText + "";
        }
        return sql;
    }

    public static string AddSNodesSql(string DataTable, string ParentGuid, string PidValue, string StrCondition, string OrderFieldText)
    {
        sql = "select * from " + DataTable + "  where " + ParentGuid + "='" + PidValue + "' and StatusID=0";
        if (StrCondition != "")
        {
            sql += " and " + StrCondition + "";
        }
        if (OrderFieldText != "")
        {
            sql += " Order by " + OrderFieldText + "";
        }
        return sql;
    }

    public static string AddArticleSql(string KBaseTreeGuid)
    {
        sql = "SELECT KBaseArticle_Guid, ArticleTitle FROM SKbsArticle where KBaseTree_Guid='" + KBaseTreeGuid + "' and StatusID='0'";
        return sql;
    }
}

