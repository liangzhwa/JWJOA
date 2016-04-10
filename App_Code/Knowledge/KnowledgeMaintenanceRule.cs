using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public class KnowledgeMaintenanceRule
{
    private static string ConnStr;
    MDataBase db;
    //ControlDataBind ControlDBind;
    public KnowledgeMaintenanceRule(string ConnetionString)
    {
        ConnStr = ConnetionString;
        db = new MDataBase(ConnStr);
        //ControlDBind = new ControlDataBind(ConnStr);
    }

    public string sql;
    
    KnowledgeSql KnowledgeSql = new KnowledgeSql();

    public bool InsertKnowledge(DataGrid DGrid, string KBaseTreeGuid, string ParentKBaseTree_Guid, string NodeTitle, string NodeDetail, string StaffId)// string KBaseArticle_Guid, string StaffId)
    {
        //string StrDateTime = GetInformation.GetCurrentDataTime();
        try
        {
            bool boollReturn = false;
            sql = KnowledgeSql.InsertKnowledgeSql(KBaseTreeGuid, ParentKBaseTree_Guid, NodeTitle, NodeDetail, StaffId);
            //Asql[1] = KnowledgeSql.UpdateKnowlegeAticleSql(KBaseArticle_Guid, KBaseTreeGuid);
            boollReturn = AddGridArticle(DGrid, sql, KBaseTreeGuid);
            return boollReturn;
        }
        catch (Exception Err)
        {
            //WebWindow.alert("输入信息有误，请检查后更新！");
            ErrorLog.LogInsert(Err.Message, "CS/KnowledgeBase/KnowledgeMaintenanceRule", StaffId);
            return false;
        }
    }

    public bool UpdateKnowledge(DataGrid DGrid, string KBaseTreeGuid, string ParentKBaseTree_Guid, string NodeTitle, string NodeDetail, string KBaseArticle_Guid, string StaffId)
    {
        try
        {
            bool boollReturn = false;
            sql = KnowledgeSql.UpdateKnowledgeSql(KBaseTreeGuid, ParentKBaseTree_Guid, NodeTitle, NodeDetail, KBaseArticle_Guid, StaffId);
            boollReturn = AddGridArticle(DGrid, sql, KBaseTreeGuid);
            return boollReturn;
        }
        catch (Exception Err)
        {
            //WebWindow.alert("更新节点时发生不可知错误，请找系统管理员解决！");
            ErrorLog.LogInsert(Err.Message, "CS/KnowledgeBase/KnowledgeMaintenanceRule", StaffId);
            return false;
        }
    }

    public bool DelKnowledge(string KBaseTreeGuid,string StaffId)
    {
        try
        {
            bool boollReturn = false;
            sql = KnowledgeSql.DeleteKnowledgeSql(KBaseTreeGuid);
            boollReturn = DelGridArticle(sql, KBaseTreeGuid);
            return boollReturn;
        }
        catch (Exception Err)
        {
            //WebWindow.alert("更新节点时发生不可知错误，请找系统管理员解决！");
            ErrorLog.LogInsert(Err.Message, "CS/KnowledgeBase/KnowledgeMaintenanceRule", StaffId);
            return false;
        }
    }

    private bool AddGridArticle(DataGrid DGrid, string sql, string KBaseTreeGuid)
    {
        string[] sqlTmp1 = new string[DGrid.Items.Count + 2];
        sqlTmp1[0] = sql;
        sqlTmp1[1] = "update SKbsArticle set KBaseTree_Guid='' where KBaseTree_Guid='" + KBaseTreeGuid + "'";
        int haveSelected = 2;
        for (int i = 0; i < DGrid.Items.Count; i++)
        {
            CheckBox myCheck = (CheckBox)DGrid.Items[i].FindControl("CheckBox1");
            if (myCheck.Checked == true)
            {
                //sqlTmp[haveSelected] = "insert into SCtiRoleMenu(Role_Id,Menu_Id) values('" + Role_Id + "','" + mySelected + "')";
                sqlTmp1[haveSelected] = "update SKbsArticle set KBaseTree_Guid='" + KBaseTreeGuid + "' where KBaseArticle_Guid='" + DGrid.Items[i].Cells[2].Text.Trim() + "'";
                haveSelected++;
            }
        }

        string[] sqlOne = new string[haveSelected];
        for (int i = 0; i < haveSelected; i++)
        {
            sqlOne[i] = sqlTmp1[i];
        }

        bool blnReturnCode = db.runTransaction(sqlOne);
        return blnReturnCode;
    }

    private bool DelGridArticle(string sql, string KBaseTreeGuid)
    {
        string[] sqlOne = new string[2];
        sqlOne[0] = sql;
        sqlOne[1] = "update SKbsArticle set KBaseTree_Guid='' where KBaseTree_Guid='" + KBaseTreeGuid + "'";
        bool blnReturnCode = db.runTransaction(sqlOne);
        return blnReturnCode;
    }

    public DataRow GetInfoDataRow(string KBaseTreeGuid,string SessionID)
    {
        try
        {
            sql = KnowledgeSql.GetInfoFGuidSql(KBaseTreeGuid);
            DataRow dataRow = db.GetDataRow(sql);
            return dataRow;
        }
        catch(Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/KnowledgeBase/KnowledgeMaintenanceRule", SessionID);
            return null;
        }
    }
}
