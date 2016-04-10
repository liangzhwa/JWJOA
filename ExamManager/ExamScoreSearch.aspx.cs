/*----------------------------------------------------------------
// Copyright (C) 2008 南京环智科技有限公司
// 版权所有。 
//
// 文件名： ExamScoreSearch.aspx.cs
// 文件功能描述：警卫局网上考试(成绩)个人查询
//
// 
// 创建标识：汤君 2008-04-02
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Stone.Data;
using System.Text;
using Stone;
using System.Drawing;
using System.Web.UI.MobileControls;

public partial class ExamManager_ExamScoreSearch : System.Web.UI.Page
{
    MDataBase db;
    Config config;
    /// <summary>
    /// 页面加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        config = (Config)Session["Config"];
        if (!IsPostBack)
        {
            this.btnFirstPageScore.Visible = false;
            this.btnForwardPageScore.Visible = false;
            this.btnNextPageScore.Visible = false;
            this.btnLastPageScore.Visible = false;
            this.lblCountScore.Visible = false;
            this.lblCountPageScore.Visible = false;
            this.lblPageScore.Visible = false;
        }
        //config = (Config)Session["Config"];config.Staff.Staff_Id;
    }
    /// <summary>
    /// 查询事件逻辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //如果考试名称为空，则显示所有考试
        if (txtExamName.Text.Trim() == "")
        {
            BindDataGvAll();
        }
        //考试名不为空
        else
        {
            BindDataGv();
        }
    }
    //考试名为空Gv绑定方法
    private void BindDataGvAll()
    {
        string sql = "select a.ExamName,b.StartTime,b.Score,a.Average,b.Gradation from SExmExam a,SExmScore b where a.Exam_Id=b.Exam_Id and b.Staff_Id = '" + "" + "'";// 测试数据config.Staff.Staff_Id
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        ViewState["dataSource"] = dt;
        if (dt.Rows.Count == 0)
        {
            this.btnFirstPageScore.Visible = false;
            this.btnForwardPageScore.Visible = false;
            this.btnNextPageScore.Visible = false;
            this.btnLastPageScore.Visible = false;
            this.lblCountScore.Visible = false;
            this.lblCountPageScore.Visible = false;
            this.lblPageScore.ForeColor = Color.Red;
            this.lblPageScore.Visible = true;
            this.lblPageScore.Text = "对不起，没有查询到相关信息！";
            this.gvScore.Visible = false;
        }
        else
        {
            this.lblCountScore.Visible = true;
            this.lblCountPageScore.Visible = true;
            this.btnFirstPageScore.Visible = true;
            this.btnForwardPageScore.Visible = true;
            this.btnNextPageScore.Visible = true;
            this.btnLastPageScore.Visible = true;
            this.gvScore.Visible = true;
            gvScore.PageSize = 50;
            gvScore.DataSource = dt;
            gvScore.DataBind();
            //显示搜索到的全部条数
            this.lblCountScore.Text = "共有" + (dt.Rows.Count).ToString() + "条记录";
            //显示GridView的页数
            this.lblPageScore.Visible = true;
            lblPageScore.ForeColor = Color.Black;
            lblPageScore.Text = "/共" + (gvScore.PageCount).ToString() + "页";
            //显示GV是第几页
            lblCountPageScore.Text = "第" + (gvScore.PageIndex + 1).ToString() + "页";
        }
    }
    //考试名不为空Gv绑定方法
    private void BindDataGv()
    {
        string sql = "select a.ExamName,b.StartTime,b.Score,a.Average,b.Gradation from SExmExam a,SExmScore b where a.Exam_Id=b.Exam_Id and a.ExamName like '%"+txtExamName.Text.Trim() + "%' and b.Staff_Id = '" + "" + "'";// 测试数据config.Staff.Staff_Id
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        ViewState["dataSource"] = dt;
        if (dt.Rows.Count == 0)
        {
            this.btnFirstPageScore.Visible = false;
            this.btnForwardPageScore.Visible = false;
            this.btnNextPageScore.Visible = false;
            this.btnLastPageScore.Visible = false;
            this.lblCountScore.Visible = false;
            this.lblCountPageScore.Visible = false;
            lblPageScore.ForeColor = Color.Red;
            this.lblPageScore.Text = "对不起，没有查询到相关信息！";
            this.gvScore.Visible = false;
        }
        else
        {
            this.lblCountScore.Visible = true;
            this.lblCountPageScore.Visible = true;
            this.btnFirstPageScore.Visible = true;
            this.btnForwardPageScore.Visible = true;
            this.btnNextPageScore.Visible = true;
            this.btnLastPageScore.Visible = true;
            this.gvScore.Visible = true;
            gvScore.PageSize = 50;
            gvScore.DataSource = dt;
            gvScore.DataBind();
            //显示搜索到的全部条数
            this.lblCountScore.Text = "共有" + (dt.Rows.Count).ToString() + "条记录";
            //显示GridView的页数
            lblPageScore.ForeColor = Color.Black;
            lblPageScore.Text = "/共" + (gvScore.PageCount).ToString() + "页";
            //显示GV是第几页
            lblCountPageScore.Text = "第" + (gvScore.PageIndex + 1).ToString() + "页";
        }
    }
    //翻页查询功能
    protected void PagerButtonScore_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["dataSourceScore"];

        //取得当前页的索引
        int pageIndx = Convert.ToInt32(CurrentPageScore.Value);

        //取得数据总条数
        int totals = dt.Rows.Count;

        //取得每页的大小
        int pageSize = gvScore.PageSize;

        //取得总页数
        int pages = gvScore.PageCount;

        string arg = ((Button)sender).CommandArgument.ToString().ToLower();
        switch (arg)
        {
            case "prev":
                if (pageIndx > 0)
                {
                    pageIndx -= 1;
                }
                break;
            case "next":
                if (pageIndx < pages - 1)
                {
                    pageIndx += 1;
                }
                break;
            case "last":
                pageIndx = pages - 1;
                break;
            default:
                pageIndx = 0;
                break;
        }
        CurrentPageScore.Value = pageIndx.ToString();
        gvScore.PageIndex = pageIndx;

        lblCountPageScore.Text = (pageIndx + 1).ToString();
        gvScore.DataSource = (DataTable)ViewState["dataSourceScore"];
        gvScore.DataBind();
    }
}
