using System;
using System.Data;

/// <summary>
/// 系统参数对象
/// </summary>
public class MDataBase : Stone.Data.SqlClient
{
    public MDataBase(string strConn)
    {
        base._connectionString = strConn;
    }

    /// <summary>
    /// 实现分页的查询语句
    /// </summary>
    /// <param name="sql">原查询语句</param>
    /// <param name="PK">主键</param>
    /// <param name="Count">总记录数</param>
    /// <param name="PageSize">每页记录数</param>
    /// <param name="PageIndex">当前页</param>
    /// <returns></returns>
    public string SelectWithPage(string sql,string PK,int Count,int PageSize,int PageIndex)
    {
        //
        // 改造分页sql
        //
        // 参考:SELECT TOP m-n+1 * FROM publish WHERE (id NOT IN (SELECT TOP n-1 id FROM publish))        
       
        // 取开始记录数
        int intPageIndex = Math.Min(Count /PageSize - 1, PageIndex);
        int intStartIndex = Math.Max((intPageIndex * PageSize), 0);

        
        string strTmpSql = sql.Substring(sql.IndexOf(" FROM"));
        strTmpSql = "SELECT TOP " + intStartIndex.ToString() + " " + PK + strTmpSql;
        sql = "SELECT TOP " + PageSize + " * FROM (" + sql + ") AS  TableName  WHERE (" + PK + " NOT IN (" + strTmpSql + "))";
        return sql;
    }
}
