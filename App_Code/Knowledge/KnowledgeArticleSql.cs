using System;
using System.Collections.Generic;
using System.Text;

public class KnowledgeArticleSql
{
    private string sql;

    public string AddAticleSql(string KBaseArticleGuid, string KBaseArticleId, string ArticleTitle, string ArticleWriter, string ArticleType, string ArticleLevel, string ArticleContent, string ArticlePoint, string Keyword1, string Keyword2, string Keyword3, string StartDate, string AbolishDate, string Creater_Id)
    {//getDate() sql语句中的时间
        sql = "insert into SKbsArticle(KBaseArticle_Guid,KBaseArticleId,ArticleTitle,ArticleWriter,ArticleType_Id,ArticleLevel_Id,ArticleContent,ArticlePoint,Keyword1,Keyword2,Keyword3,StartDate,AbolishDate,CreatedBy,CreatedDate,StatusId) values('" + KBaseArticleGuid + "','" + KBaseArticleId + "','" + ArticleTitle + "','" + ArticleWriter + "','" + ArticleType + "','" + ArticleLevel + "','" + ArticleContent + "','" + ArticlePoint + "','" + Keyword1 + "','" + Keyword2 + "','" + Keyword3 + "','" + StartDate + "','" + AbolishDate + "','" + Creater_Id + "',getdate(),'0')";
        return sql;
    }

    public string UpdateAticleSql(string KBaseArticleGuid, string KBaseArticleId, string ArticleTitle, string ArticleWriter, string ArticleType, string ArticleLevel, string ArticleContent, string ArticlePoint, string Keyword1, string Keyword2, string Keyword3, string StartDate, string AbolishDate, string Modifier_Id)
    {//getDate() sql语句中的时间
        sql = "update SKbsArticle set KBaseArticleId='" + KBaseArticleId + "',ArticleTitle='" + ArticleTitle + "',ArticleWriter='" + ArticleWriter + "',ArticleType_Id='" + ArticleType + "',ArticleLevel_Id='" + ArticleLevel + "',ArticleContent='" + ArticleContent + "',ArticlePoint='" + ArticlePoint + "',Keyword1='" + Keyword1 + "',Keyword2='" + Keyword2 + "',Keyword3='" + Keyword3 + "',StartDate='" + StartDate + "',AbolishDate='" + AbolishDate + "',ModifiedBy='" + Modifier_Id + "',ModifiedDate=getdate() where KBaseArticle_Guid='" + KBaseArticleGuid + "'";
        return sql;
    }

    public string SearchAticleSql(string ArticleTitle, string ArticleWriter, string KBaseArticleId)
    {
        sql = "SELECT A.KBaseArticle_Guid,A.KBaseArticleId,case SUBSTRING(A.ArticleTitle, 0, 25) when A.ArticleTitle then A.ArticleTitle else (SUBSTRING(A.ArticleTitle, 0, 22) + '...') end as ArticleTitle,A.ArticleWriter,B.ArticleTypeName,A.StartDate,A.ArticleContent from SKbsArticle A LEFT OUTER JOIN SCKbs_ArticleType B ON A.ArticleType_Id = B.ArticleType_Id where A.StatusID='0' and A.KBaseArticle_Guid<>'0'";
        if (ArticleTitle != "")
        {
            sql += " AND A.ArticleTitle Like '%" + ArticleTitle.Trim().Replace("'", "''") + "%'";
        }
        if (ArticleWriter != "")
        {
            sql += " AND A.ArticleWriter Like '%" + ArticleWriter.Trim().Replace("'", "''") + "%'";
        }
        if (KBaseArticleId != "")
        {
            sql += " AND A.KBaseArticleId = '" + KBaseArticleId.Trim().Replace("'", "''") + "'";
        }
        return sql;
    }

    public string GetInfoFGuidSql(string KBaseArticleGuid)
    {
        sql = "SELECT A.KBaseArticleId, A.ArticleTitle, A.ArticleWriter, A.ArticleType_Id,A.ArticleLevel_Id,B.ArticleTypeName,C.ArticleLevelName, A.ArticleContent, A.ArticlePoint, A.Keyword1, A.Keyword2, A.Keyword3, A.StartDate, A.AbolishDate FROM SKbsArticle A LEFT OUTER JOIN SCKbs_ArticleType B ON A.ArticleType_Id =B.ArticleType_Id LEFT OUTER JOIN SCKbs_ArticleLevel C ON A.ArticleLevel_Id =C.ArticleLevel_Id where KBaseArticle_Guid='" + KBaseArticleGuid + "'";
        return sql;
    }
}