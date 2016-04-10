using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public class ArticleViewRule
{
    private static string ConnStr;
    MDataBase db;
    public ArticleViewRule(string ConnetionString)
    {
        ConnStr = ConnetionString;
        db = new MDataBase(ConnStr);
    }

    private string sql;
    KnowledgeArticleSql KnowledgeArticleSql = new KnowledgeArticleSql();
    public DataRow GetInfoDataRow(string KBaseArticleGuid,string SessionID)
    {
        try
        {
            sql = KnowledgeArticleSql.GetInfoFGuidSql(KBaseArticleGuid);
            DataRow dataRow = db.GetDataRow(sql);
            return dataRow;
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/KnowledgeBase/ArticleViewRule", SessionID);
            return null;
        }
    }
}
