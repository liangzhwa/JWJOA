using System;
using System.Collections.Generic;
using System.Text;

public class GetInfomationSql
{
    private static string sql;

    public static string GetMaxValueSql(string DataTable, string MaxFieldText, string FieldText, string FieldValue)
    {
        sql = "select max(" + MaxFieldText + ") from " + DataTable + " where " + FieldText + " = '" + FieldValue + "'";
        return sql;
    }

    public static string GetIntCountSql(string DataTable, string FieldText, string FieldValue)
    {
        sql = "select count(*) from " + DataTable + " where " + FieldText + "='" + FieldValue + "'";
        return sql;
    }

    public static string GetIntCountSql(string DataTable, string FieldText, string FieldValue,string StrCondition)
    {
        sql = "select count(*) from " + DataTable + " where " + FieldText + "='" + FieldValue + "'";
        if (StrCondition != "")
        {
            sql += " and " + StrCondition + "";
        }
        return sql;
    }

    public static string GetIntCountSql2(string DataTable, string FieldText, string FieldValue, string StrCondition)
    {
        sql = "select count(*) from " + DataTable + " where " + FieldText + "='" + FieldValue + "'";
        if (StrCondition != "")
        {
            sql += " and " + StrCondition + "";
        }
        return sql;
    }

    public static string DeleteBCheckBoxSql(string DataTable, string DataFieldText,string DataFieldValue)
    {
        sql = "delete " + DataTable + " where " + DataFieldText + "='" + DataFieldValue + "'";
        return sql;
    }

    public static string DeleteBStatusSql(string DataTable, string DataFieldText, string DataFieldValue)
    {
        sql = "update " + DataTable + " set StatusID='1' where " + DataFieldText + "='" + DataFieldValue + "'";
        return sql;
    }
}
