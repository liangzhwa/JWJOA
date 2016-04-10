using System;
using System.Data;
using System.Web.UI.WebControls;

public class KnowledgeInterfaceRule
{
    private static string ConnStr;
    MDataBase db;
    ArticleViewRule ArticleViewRule;
    public KnowledgeInterfaceRule(string ConnetionString)
    {
        ConnStr = ConnetionString;
        db = new MDataBase(ConnStr);
        ArticleViewRule = new ArticleViewRule(ConnStr);
    }

    KnowledgeSql KnowledgeSql = new KnowledgeSql();
    public string sql;
    private DataSet _Sds;
    public DataSet Sds
    {
        get { return _Sds; }
        set
        {
            _Sds = value;
        }
    }

    public void Search(string SearchType, string SearchContent, DataGrid DGrid, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast,Label message, string Str, Label totalPage, string SessionID)
    {
        try
        {
            sql = KnowledgeSql.SearchInfoSql(SearchType, SearchContent);
            _Sds = db.GetDataSet(sql);
            DGrid.CurrentPageIndex = 0;
            DGrid.SelectedIndex = -1;
            ControlDataBind.DataGridDSBind(DGrid, _Sds, btnFirst, btnPrevious, btnNext, btnLast, message, Str, totalPage, SessionID);
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "UI/Sys/Sysrepwd_Button1_Click", SessionID);
            return;
        }
    }

    public void btnGo(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label message, string Str, Label totalPage, string SessionID)
    {
        ControlDataBind.DataGridDSBind(DGrid, _Sds, btnFirst, btnPrevious, btnNext, btnLast, message, Str, totalPage, SessionID);
    }

    public void btnFirst(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label message, string Str, Label totalPage, string SessionID)
    {
        ControlDataBind.btnFirst(DGrid, Sds, btnFirst, btnPrevious, btnNext, btnLast, message, Str, totalPage, SessionID);
    }

    public void btnPrevious(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label message, string Str, Label totalPage, string SessionID)
    {
        ControlDataBind.btnPrevious(DGrid, Sds, btnFirst, btnPrevious, btnNext, btnLast,message, Str, totalPage, SessionID);
    }

    public void btnNext(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label message, string Str, Label totalPage, string SessionID)
    {
        ControlDataBind.btnNext(DGrid, Sds, btnFirst, btnPrevious, btnNext, btnLast, message, Str, totalPage, SessionID);
    }

    public void btnLast(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label message, string Str, Label totalPage, string SessionID)
    {
        ControlDataBind.btnLast(DGrid, Sds, btnFirst, btnPrevious, btnNext, btnLast, message, Str, totalPage, SessionID);
    }

 

    public void InsertVisited(string KBaseArticle_Guid,string SessionID)
    {
        string VisitedGuid = Guid.NewGuid().ToString();
        sql = "insert into SKbsVisited(Visited_Guid,KBaseArticle_Guid,Staff_Id,CreatedDate) values('" + VisitedGuid + "','" + KBaseArticle_Guid + "','" + SessionID + "',getdate())";
        db.executeInsert(sql);
    }
}
