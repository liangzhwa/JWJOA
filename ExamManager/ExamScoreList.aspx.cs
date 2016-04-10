/*----------------------------------------------------------------
// Copyright (C) 2008 南京环智科技有限公司
// 版权所有。 
//
// 文件名： ScoreEnquiry.aspx.cs
// 文件功能描述：警卫局网上考试(成绩)查询
//
// 
// 创建标识：汤君 2008-03-28
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

public partial class ExamManager_ExamScoreList : System.Web.UI.Page
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
            lblError.Visible = false;
            this.btnScoreDetail.Visible = false;
            this.btnFirstPageScore.Visible = false;
            this.btnForwardPageScore.Visible = false;
            this.btnNextPageScore.Visible = false;
            this.btnLastPageScore.Visible = false;
            this.lblCountScore.Visible = false;
            this.lblCountPageScore.Visible = false;
            this.lblPageScore.Visible = false;
            this.gvScore.Visible = false;
            BindDataGv();
        }
         //config = (Config)Session["Config"];
    }
    //考试查询逻辑
    protected void btnSearchExam_Click(object sender, EventArgs e)
    {
        //开始时间为空，结束时间不为空
        if(txtTimeStart.Text.Trim() == ""&&txtTimeEnd.Text.Trim()!="")
        {
            lblError.Visible = true;
            lblError.Text = "错误信息：开始时间没有填写";
            return;
        }
        //双空判断
        if (txtExamName.Text.Trim() == "" && txtTimeStart.Text.Trim() == "")
        {
            BindDataGv();
        }
        //时间判空
        if (txtExamName.Text.Trim() != "" && txtTimeStart.Text.Trim() == "")
        {
            ScoreName();
        }
        //名称判空,开始时间与结束时候都不为空
        if (txtExamName.Text.Trim() == "" && txtTimeStart.Text.Trim() != "")
        {
            //开始时间不为空，结束时间为空
            if (txtTimeEnd.Text.Trim() == "")
            {
                DateTime dtNow = DateTime.Now;
                txtTimeEnd.Text = dtNow.ToString();
            }
            Time();
        }     
    }
    //为空查询
    private void BindDataGv()
    {
        string sql = "select Exam_Id,ExamName,ExamEmploees,Average from SExmExam";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        ViewState["dataSource"] = dt;
        if (dt.Rows.Count == 0)
        {
            this.btnSearchScore.Visible = false;
            this.btnFirstPage.Visible = false;
            this.btnForwardPage.Visible = false;
            this.btnNextPage.Visible = false;
            this.btnLastPage.Visible = false;
            this.lblCount.Visible = false;
            this.lblCurrentPage.Visible = false;
            lblPage.ForeColor = Color.Red;
            this.lblPage.Text = "对不起，没有查询到相关信息！";
            this.gvExam.Visible = false;            
        }
        else
        {
            this.btnSearchScore.Visible = true;
            this.lblCount.Visible = true;
            this.lblCurrentPage.Visible = true;
            this.btnFirstPage.Visible = true;
            this.btnForwardPage.Visible = true;
            this.btnNextPage.Visible = true;
            this.btnLastPage.Visible = true;
            this.gvExam.Visible = true;
            gvExam.PageSize = 50;
            gvExam.DataSource = dt;
            gvExam.DataBind();
            //显示搜索到的全部条数
            this.lblCount.Text = "共有" + (dt.Rows.Count).ToString() + "条记录";
            //显示GridView的页数
            lblPage.ForeColor = Color.Black;
            lblPage.Text = "/共" + (gvExam.PageCount).ToString() + "页";
            //显示GV是第几页
            lblCurrentPage.Text = "第" + (gvExam.PageIndex + 1).ToString() + "页";
            //GV中的radiobutton默认选定第一条
            RadioButton rbtn = ((RadioButton)(gvExam.Rows[0].Cells[0].FindControl("rdtExam")));
            rbtn.Checked = true;
        }
    }
    //根据考试名称查询
    private void ExamName()
    {
        string sql = "select Exam_Id,ExamName,ExamEmploees,Average from SExmExam where ExamName like '%" + txtExamName.Text + "%'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        ViewState["dataSource"] = dt;
        if (dt.Rows.Count == 0)
        {
            this.btnSearchScore.Visible = false;
            this.btnFirstPage.Visible = false;
            this.btnForwardPage.Visible = false;
            this.btnNextPage.Visible = false;
            this.btnLastPage.Visible = false;
            this.lblCount.Visible = false;
            this.lblCurrentPage.Visible = false;
            lblPage.ForeColor = Color.Red;
            this.lblPage.Text = "对不起，没有查询到相关信息！";
            this.gvExam.Visible = false;
        }
        else
        {
            this.btnSearchScore.Visible = true;
            this.lblCount.Visible = true;
            this.lblCurrentPage.Visible = true;
            this.btnFirstPage.Visible = true;
            this.btnForwardPage.Visible = true;
            this.btnNextPage.Visible = true;
            this.btnLastPage.Visible = true;
            this.gvExam.Visible = true;
            gvExam.PageSize = 50;
            gvExam.DataSource = dt;
            gvExam.DataBind();
            //显示搜索到的全部条数
            this.lblCount.Text = "共有" + (dt.Rows.Count).ToString() + "条记录";
            //显示GridView的页数
            lblPage.ForeColor = Color.Black;
            lblPage.Text = "/共" + (gvExam.PageCount).ToString() + "页";
            //显示GV是第几页
            lblCurrentPage.Text = "第" + (gvExam.PageIndex + 1).ToString() + "页";
            //GV中的radiobutton默认选定第一条
            RadioButton rbtn = ((RadioButton)(gvExam.Rows[0].Cells[0].FindControl("rdtExam")));
            rbtn.Checked = true;
        }
    }
    //根据时间段查询
    private void Time()
    {
        string sql = "select Exam_Id,ExamName,ExamEmploees,Average from SExmExam where BeginTime between '" + txtTimeStart.Text + "' and '" + txtTimeEnd.Text + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        ViewState["dataSource"] = dt;
        if (dt.Rows.Count == 0)
        {
            this.btnSearchScore.Visible = false;
            this.btnFirstPage.Visible = false;
            this.btnForwardPage.Visible = false;
            this.btnNextPage.Visible = false;
            this.btnLastPage.Visible = false;
            this.lblCount.Visible = false;
            this.lblCurrentPage.Visible = false;
            lblPage.ForeColor = Color.Red;
            this.lblPage.Text = "对不起，没有查询到相关信息！";
            this.gvExam.Visible = false;
        }
        else
        {
            this.btnSearchScore.Visible = true;
            this.lblCount.Visible = true;
            this.lblCurrentPage.Visible = true;
            this.btnFirstPage.Visible = true;
            this.btnForwardPage.Visible = true;
            this.btnNextPage.Visible = true;
            this.btnLastPage.Visible = true;
            this.gvExam.Visible = true;
            gvExam.PageSize = 50;
            gvExam.DataSource = dt;
            gvExam.DataBind();
            //显示搜索到的全部条数
            this.lblCount.Text = "共有" + (dt.Rows.Count).ToString() + "条记录";
            //显示GridView的页数
            lblPage.ForeColor = Color.Black;
            lblPage.Text = "/共" + (gvExam.PageCount).ToString() + "页";
            //显示GV是第几页
            lblCurrentPage.Text = "第" + (gvExam.PageIndex + 1).ToString() + "页";
            //GV中的radiobutton默认选定第一条
            RadioButton rbtn = ((RadioButton)(gvExam.Rows[0].Cells[0].FindControl("rdtExam")));
            rbtn.Checked = true;
        }
    }
    //双字段查询
    private void ScoreName()
    {
        string sql = "select Exam_Id,ExamName,ExamEmploees,Average from SExmExam where ExamName like '%" + txtExamName.Text + "%'" + " and BeginTime between '" + txtTimeStart.Text + "' and '" + txtTimeEnd.Text + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        ViewState["dataSource"] = dt;
        if (dt.Rows.Count == 0)
        {
            this.btnSearchScore.Visible = false;
            this.btnFirstPage.Visible = false;
            this.btnForwardPage.Visible = false;
            this.btnNextPage.Visible = false;
            this.btnLastPage.Visible = false;
            this.lblCount.Visible = false;
            this.lblCurrentPage.Visible = false;
            lblPage.ForeColor = Color.Red;
            this.lblPage.Text = "对不起，没有查询到相关信息！";
            this.gvExam.Visible = false;
        }
        else
        {
            this.btnSearchScore.Visible = true;
            this.lblCount.Visible = true;
            this.lblCurrentPage.Visible = true;
            this.btnFirstPage.Visible = true;
            this.btnForwardPage.Visible = true;
            this.btnNextPage.Visible = true;
            this.btnLastPage.Visible = true;
            this.gvExam.Visible = true;
            gvExam.PageSize = 50;
            gvExam.DataSource = dt;
            gvExam.DataBind();
            //显示搜索到的全部条数
            this.lblCount.Text = "共有" + (dt.Rows.Count).ToString() + "条记录";
            //显示GridView的页数
            lblPage.ForeColor = Color.Black;
            lblPage.Text = "/共" + (gvExam.PageCount).ToString() + "页";
            //显示GV是第几页
            lblCurrentPage.Text = "第" + (gvExam.PageIndex + 1).ToString() + "页";
            //GV中的radiobutton默认选定第一条
            RadioButton rbtn = ((RadioButton)(gvExam.Rows[0].Cells[0].FindControl("rdtExam")));
            rbtn.Checked = true;
        }
    }
    //gvExam翻页事件
    protected void PagerButton_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["dataSource"];

        //取得当前页的索引
        int pageIndx = Convert.ToInt32(CurrentPage.Value);

        //取得数据总条数
        int totals = dt.Rows.Count;

        //取得每页的大小
        int pageSize = gvExam.PageSize;

        //取得总页数
        int pages = gvExam.PageCount;

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
        CurrentPage.Value = pageIndx.ToString();
        gvExam.PageIndex = pageIndx;

        lblCurrentPage.Text = (pageIndx + 1).ToString();
        gvExam.DataSource = (DataTable)ViewState["dataSource"];
        gvExam.DataBind();

    }
    //跳转到考试信息详细页面
    protected void btnExamDetail_Click(object sender, EventArgs e)
    {
        //判断gvExam的RadioButton选中的值
        for (int i = 0; i < gvExam.Rows.Count; i++)
        {
            if (((RadioButton)gvExam.Rows[i].Cells[0].FindControl("rbtExam")).Checked == true)
            {
                hfdGv.Value = ((RadioButton)gvExam.Rows[i].Cells[0].Controls[1]).ToolTip;
            }
        }
        Response.Redirect("ExamDetail.aspx?ExamId=" + hfdGv.Value, false);
    }
    //gvScore翻页事件
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
    //参考人员信息查询条件
    protected void btnSearchScore_Click(object sender, EventArgs e)
    {
        //判断gvExam的RadioButton选中的值
        for (int i = 0; i < gvExam.Rows.Count; i++)
        {
            if (((RadioButton)gvExam.Rows[i].Cells[0].FindControl("rbtExam")).Checked == true)
            {
                hfdGv.Value = ((RadioButton)gvExam.Rows[i].Cells[0].Controls[1]).ToolTip;
            }
        }
        DataBindGvScore();
    }
    //gvScore绑值事件
    private void DataBindGvScore()
    {
        string sql = "select b.Staff_Id,b.Score,a.Average b.Gradation from SExmExam a,SExmScore b where a.Exam_Id = b.Exam_Id and b.Exam_Id = '" + hfdGv.Value + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        ViewState["dataSourceScore"] = dt;
        if (dt.Rows.Count == 0)
        {
            this.btnScoreDetail.Visible = false;
            this.btnFirstPageScore.Visible = false;
            this.btnForwardPageScore.Visible = false;
            this.btnNextPageScore.Visible = false;
            this.btnLastPageScore.Visible = false;
            this.lblCountScore.Visible = false;
            this.lblCountPageScore.Visible = false;
            this.lblPageScore.Visible = true;
            this.lblPageScore.ForeColor = Color.Red;
            this.lblPageScore.Text = "对不起，没有查询到相关信息！";
            this.gvScore.Visible = false;
        }
        else
        {
            this.btnScoreDetail.Visible = true;
            this.lblCountScore.Visible = true;
            this.lblCountPageScore.Visible = true;
            this.btnFirstPageScore.Visible = true;
            this.btnForwardPageScore.Visible = true;
            this.btnNextPageScore.Visible = true;
            this.btnLastPageScore.Visible = true;
            this.gvScore.Visible = true;
            gvExam.PageSize = 50;
            gvExam.DataSource = dt;
            gvExam.DataBind();
            //显示搜索到的全部条数
            this.lblCountScore.Text = "共有" + (dt.Rows.Count).ToString() + "条记录";
            //显示GridView的页数
            this.lblPageScore.Visible = true;
            this.lblPageScore.ForeColor = Color.Black;
            this.lblPageScore.Text = "/共" + (gvExam.PageCount).ToString() + "页";
            //显示GV是第几页
            this.lblCountPageScore.Text = "第" + (gvExam.PageIndex + 1).ToString() + "页";
            //GV中的radiobutton默认选定第一条
            RadioButton rbn = ((RadioButton)(gvScore.Rows[0].Cells[0].FindControl("rbnScore")));
            rbn.Checked = true;
        }
    }
    //跳转到参考人员详细信息页面
    protected void btnScoreDetail_Click(object sender, EventArgs e)
    {
        //判断gvScore的RadioButton选中的值
        for (int i = 0; i < gvScore.Rows.Count; i++)
        {
            if (((RadioButton)gvScore.Rows[i].Cells[0].FindControl("rbnScore")).Checked == true)
            {
                hfdGvScore.Value = ((RadioButton)gvScore.Rows[i].Cells[0].Controls[1]).ToolTip;
            }
        }
        Server.Transfer("ExamScoreDetail.aspx?ScoreGuid=" + hfdGvScore.Value);
    }
}
