using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;

public class KnowledgeRule
{
    //private static string ConnStr;
    MDataBase db;
    GetInformation GetInformation;
    public KnowledgeRule(string ConnetionString)
    {
        //ConnStr = ConnetionString;
        db = new MDataBase(ConnetionString);
        GetInformation = new GetInformation(ConnetionString);
    }

    KnowledgeArticleSql KnowledgeArticleSql = new KnowledgeArticleSql();
     
    private string sql;
    private DataSet _Sds;
    public DataSet Sds
    {
        get { return _Sds; }
        set
        {
            _Sds = value;
        }
    }

    public void Search(string Title, string Writer, string Id, DataGrid DGrid, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast,Label Messge, string Str, Label totalPage, string SessionID)
    {
        try
        {
            sql = KnowledgeArticleSql.SearchAticleSql(Title, Writer, Id);
            _Sds = db.GetDataSet(sql);
            DGrid.CurrentPageIndex = 0;
            DGrid.SelectedIndex = -1;
            ControlDataBind.DataGridDSBind(DGrid, _Sds, btnFirst, btnPrevious, btnNext, btnLast,Messge, Str, totalPage, SessionID);
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/KnowledgeBase/KnowledgeRule", SessionID);
            return;
        }
    }

    public void DeleteBCheckBox(string SessionID, DataGrid DGrid, string DataTable, string DataFieldText, string CheckBoxID, string InputID)
    {
        if (GetInformation.DeleteBCheckBox(DGrid, DataTable, DataFieldText, CheckBoxID, InputID, SessionID))
        {
            WebWindow.alert("删除成功!");
            WebWindow.Refresh("KnowledgeUI.aspx?Staff_Id=" + SessionID + "");
        }
        else
        {
            WebWindow.alert("请选择一条记录!");
        }
    }

    //public void DeleteByStatus(string SessionID, DataGrid DGrid, string DataTable, string DataFieldText, string CheckBoxID, string InputID,Label message)
    //{
    //    if (GetInformation.DeleteByStatus(DGrid, DataTable, DataFieldText, CheckBoxID, InputID, SessionID))
    //    {
    //        message.Text="删除成功!";
    //        Response.Redirect("KnowledgeUI.aspx?Staff_Id=" + SessionID + "");
    //    }
    //    else
    //    {
    //        message.Text="请选择记录!";
    //    }
    //}

    public void btnGo(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label message, string Str, Label totalPage, string SessionID)
    {
        ControlDataBind.DataGridDSBind(DGrid, _Sds, btnFirst, btnPrevious, btnNext, btnLast,message, Str, totalPage, SessionID);
    }

    public void btnFirst(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label message, string Str, Label totalPage, string SessionID)
    {
        ControlDataBind.btnFirst(DGrid, Sds, btnFirst, btnPrevious, btnNext, btnLast,message, Str, totalPage, SessionID);
    }

    public void btnPrevious(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label message, string Str, Label totalPage, string SessionID)
    {
        ControlDataBind.btnPrevious(DGrid, Sds, btnFirst, btnPrevious, btnNext, btnLast, message, Str, totalPage, SessionID);
    }

    public void btnNext(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label message, string Str, Label totalPage, string SessionID)
    {
        ControlDataBind.btnNext(DGrid, Sds, btnFirst, btnPrevious, btnNext, btnLast, message, Str, totalPage, SessionID);
    }

    public void btnLast(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label message, string Str, Label totalPage, string SessionID)
    {
        ControlDataBind.btnLast(DGrid, Sds, btnFirst, btnPrevious, btnNext, btnLast, message, Str, totalPage, SessionID);
    }

    
}
