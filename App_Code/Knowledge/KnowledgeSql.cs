using System;
using System.Collections.Generic;
using System.Text;

public class KnowledgeSql
{
    private string sql;

    public string InsertKnowledgeSql(string KBaseTreeGuid, string ParentKBaseTree_Guid, string NodeTitle, string NodeDetail, string CreatedBy)
    {//newid()
        sql = "insert into SKbsKBaseTree (KBaseTree_Guid,ParentKBaseTree_Guid,NodeTitle,NodeDetail,CreatedBy,CreatedDate,StatusId) VALUES('" + KBaseTreeGuid + "','" + ParentKBaseTree_Guid + "','" + NodeTitle + "' ,'" + NodeDetail + "','" + CreatedBy + "',getdate(),'0')";
        return sql;
    }

    public string UpdateKnowlegeAticleSql(string KBaseArticle_Guid, string KBaseTreeGuid)
    {
        sql = "update SKbsArticle set KBaseTree_Guid='" + KBaseTreeGuid + "' where KBaseArticle_Guid='" + KBaseArticle_Guid + "'";
        return sql;
    }

    public string UpdateKnowledgeSql(string KBaseTreeGuid, string ParentKBaseTree_Guid, string NodeTitle, string NodeDetail, string KBaseArticle_Guid, string ModifiedBy)
    {
        sql = "update SKbsKBaseTree set ParentKBaseTree_Guid='" + ParentKBaseTree_Guid + "',NodeTitle='" + NodeTitle + "',NodeDetail='" + NodeDetail + "',ModifiedBy='" + ModifiedBy + "',ModifiedDate=getdate() where KBaseTree_Guid='" + KBaseTreeGuid + "'";
        return sql;
    }

    public string DeleteKnowledgeSql(string KBaseTreeGuid)
    {
        sql = "delete from  SKbsKBaseTree where KBaseTree_Guid='" + KBaseTreeGuid + "'";
        return sql;
    }

    public string GetInfoFGuidSql(string KBaseTreeGuid)
    {
        sql = "SELECT * FROM SKbsKBaseTree WHERE KBaseTree_Guid='" + KBaseTreeGuid + "'";
        return sql;
    }

    public string SearchInfoSql(string SearchType, string SearchContent)
    {
        sql = "SELECT A.KBaseArticle_Guid,(case when len(A.ArticleTitle) >15 then substring(A.ArticleTitle,1,15) +'...' else A.ArticleTitle end) as ArticleTitle ,B.ArticleLevelName FROM SKbsArticle A LEFT OUTER JOIN SCKbs_ArticleLevel B on A.ArticleLevel_Id =B.ArticleLevel_Id where  A.KBaseArticle_Guid<>'0'";

        if (SearchType == "1")
        {
            sql += " and A. ArticleTitle like '%" + SearchContent + "%' ";      //文章标题
        }
        else if (SearchType == "2")
        {
            sql += " and A. ArticleContent like '%" + SearchContent + "%' ";    //文章的内容
        }
        return sql;
    }
}
