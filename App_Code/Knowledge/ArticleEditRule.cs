using System;
using System.Collections.Generic;
using System.Text;

public class ArticleEditRule
{
    private static string ConnStr;
    MDataBase db;
    public ArticleEditRule(string ConnetionString)
    {
        ConnStr = ConnetionString;
        db = new MDataBase(ConnStr);
    }

    private string sql;
    KnowledgeArticleSql KnowledgeArticleSql = new KnowledgeArticleSql();

    public void UpdateArticle(string KBaseArticleGuid, string KBaseArticleId, string ArticleTitle, string ArticleWriter, string ArticleType, string ArticleLevel, string ArticleContent, string ArticlePoint, string Keyword1, string Keyword2, string Keyword3, string StartDate, string AbolishDate, string SessionID)
    {
        try
        {
            sql = KnowledgeArticleSql.UpdateAticleSql(KBaseArticleGuid, KBaseArticleId, ArticleTitle, ArticleWriter, ArticleType, ArticleLevel, ArticleContent, ArticlePoint, Keyword1, Keyword2, Keyword3, StartDate, AbolishDate, SessionID);
            db.executeInsert(sql);
            WebWindow.alert("文章修改成功!");
            WebWindow.Close();
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/KnowledgeBase/ArticleEditRule", SessionID);
            return;
        }
    }
}
