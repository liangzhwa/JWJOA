/*----------------------------------------------------------------
// Copyright (C) 2008 南京环智科技有限公司
// 版权所有。 
//
// 文件名： ExamList.aspx.cs
// 文件功能描述：警卫局网上考试系统试考试查询
//
// 
// 创建标识：汤君 2008-04-16
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
using System.Data.SqlClient;

public partial class ExamManager_ExamList : System.Web.UI.Page
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
            //GV数据装载
            BindDataGv();
        }

    }
    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //按查询条件检索并装载GV
        selectBindData();
    }
    //查询方法
    private void selectBindData()
    {
        //拼SQL前半截
        string sql = "select Exam_Id,ExamName,ScoreType,BeginTime,EndTime,CreatedBy,(case ScoreType when '0' then '当时评分' else '1' end) as contidion from SExmExam";
        //拼SQL后半截
        string con = "";
        if (txtExamId.Text.Trim() != "")
        {
            con = con + " and Exam_Id like '%" + txtExamId.Text + "%'";
        }
        if (txtExamName.Text.Trim() != "")
        {
            con = con + " and ExamName like '%" + txtExamName.Text + "%'";
        }
        if (sltQuestionTypeName.Text != "")
        {
            con = con + " and ScoreType='" + sltQuestionTypeName.SelectedValue + "'";
        }
        if (txtCreatedBy.Text != "")
        {
            con = con + " and CreatedBy like '%" + txtCreatedBy.Text + "%'";
        }
        if (con != "")
        {
            //截断第1个and
            con = con.Substring(con.IndexOf("and") + 4);
            //拼成完整SQL
            sql = sql + " where " + con;
        }
        //代入数据库查询
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        //如果查询结果为空
        if (dt.Rows.Count == 0)
        {
            //隐藏控件
            btnFirstPage.Visible = false;
            btnForwardPage.Visible = false;
            btnNextPage.Visible = false;
            btnLastPage.Visible = false;
            this.lblCount.Visible = false;
            lblPage.ForeColor = Color.Red;
            lblPage.Text = "对不起，没有查询到相关信息！";
            gvExam.Visible = false;
            btnChange.Visible = false;
            btnDelete.Visible = false;
            this.lblCountPage.Visible = false;
        }
        else
        {
            //重新显示控件
            this.lblCount.Visible = true;
            this.lblCountPage.Visible = true;
            btnFirstPage.Visible = true;
            btnForwardPage.Visible = true;
            btnNextPage.Visible = true;
            btnLastPage.Visible = true;
            gvExam.Visible = true;
            btnChange.Visible = true;
            btnDelete.Visible = true;
            gvExam.PageSize = 20;
            gvExam.DataSource = dt;
            gvExam.DataBind();
            //显示搜索到的全部条数
            this.lblCount.Text = "共有" + (dt.Rows.Count).ToString() + "条记录";
            //显示GridView的页数
            lblPage.ForeColor = Color.Black;
            lblPage.Text = "/共" + (gvExam.PageCount).ToString() + "页";
            //显示GV是第几页
            lblCountPage.Text = "第" + (gvExam.PageIndex + 1).ToString() + "页";
            //GV中的radiobutton默认选定第一条
            RadioButton rbtn = ((RadioButton)(gvExam.Rows[0].Cells[0].FindControl("jrbSelect")));
            rbtn.Checked = true;
        }
        //如果查询条件全都为空
        if (con == "")
        {
            BindDataGv();
        }
    }
    //装载页面Gv绑定
    private void BindDataGv()
    {
        string sql = "select Exam_Id,ExamName,ScoreType,BeginTime,EndTime,CreatedBy,(case ScoreType when '0' then '当时评分' else '1' end) as contidion from SExmExam";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        if (dt.Rows.Count == 0)
        {
            btnFirstPage.Visible = false;
            btnForwardPage.Visible = false;
            btnNextPage.Visible = false;
            btnLastPage.Visible = false;
            this.lblCount.Visible = false;
            lblPage.ForeColor = Color.Red;
            lblPage.Text = "对不起，没有查询到相关信息！";
            gvExam.Visible = false;
            btnChange.Visible = false;
            btnDelete.Visible = false;
            this.lblCountPage.Visible = false;
        }
        else
        {
            this.lblCount.Visible = true;
            this.lblCountPage.Visible = true;
            btnFirstPage.Visible = true;
            btnForwardPage.Visible = true;
            btnNextPage.Visible = true;
            btnLastPage.Visible = true;
            gvExam.Visible = true;
            btnChange.Visible = true;
            btnDelete.Visible = true;
            gvExam.PageSize = 20;
            gvExam.DataSource = dt;
            gvExam.DataBind();
            //显示搜索到的全部条数
            this.lblCount.Text = "共有" + (dt.Rows.Count).ToString() + "条记录";
            //显示GridView的页数
            lblPage.ForeColor = Color.Black;
            lblPage.Text = "/共" + (gvExam.PageCount).ToString() + "页";
            //显示GV是第几页
            lblCountPage.Text = "第" + (gvExam.PageIndex + 1).ToString() + "页";
            //GV中的radiobutton默认选定第一条
            RadioButton rbtn = ((RadioButton)(gvExam.Rows[0].Cells[0].FindControl("jrbSelect")));
            rbtn.Checked = true;
        }
    }
    /// <summary>
    /// 翻页事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void PagerButton_Click(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 跳转到Create页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Server.Transfer("ExmCreate.aspx?Id=1" + hfdGv.Value);
    }
    /// <summary>
    /// 跳转到Create页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnChange_Click(object sender, EventArgs e)
    {
        //取得考试结束时间，如果晚于系统时间，则不可修改
         //判断radioButton选定的目标
        for (int i = 0; i < gvExam.Rows.Count; i++)
        {
            if (((RadioButton)gvExam.Rows[i].Cells[0].FindControl("jrbSelect")).Checked == true)
            {
                hfdGv.Value = gvExam.Rows[i].Cells[1].Text;
            }
        }
        //根据取到的值执行查询
        selectTime();
    }
    //查询考试结束时间
    private void selectTime()
    {
        string sql = "select BeginTime from SExmExam where Exam_Id='" + hfdGv.Value + "'";
        DataRow drQuestion;
        db = new MDataBase(config.DBConn);
        bool blnRtnCode = db.GetDataRow(sql, out drQuestion);
        if (blnRtnCode == false || drQuestion == null)
        {
            // 错误
            return;
        }
        //取系统时间
        DateTime dtNow = DateTime.Now;
        //如果系统时间大于考试开始时间，不给修改试卷
        if (DateTime.Compare(dtNow,Convert.ToDateTime(drQuestion["BeginTime"])) > 0)
        {
            Response.Write("<script type='text/javascript'>alert('考试已经开始!');window.location.href=window.location.href;</script>");
        }
        else
        {
            Server.Transfer("ExmCreate.aspx?Id=2" + hfdGv.Value);
        }
    }
    /// <summary>
    /// 删除逻辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //判断radioButton选定的目标
        for (int i = 0; i < gvExam.Rows.Count; i++)
        {
            if (((RadioButton)gvExam.Rows[i].Cells[0].FindControl("jrbSelect")).Checked == true)
            {
                hfdGv.Value = gvExam.Rows[i].Cells[1].Text;
            }
            CSExmExam exm = new CSExmExam(config.DBConn);
            exm.Exam_Id = hfdGv.Value;
            try
            {
                exm.Delete();
                //删除临时表
                deleteTmp();
                Response.Write("<script type='text/javascript'>alert('删除成功');window.location.href=window.location.href;</script>");
            }
            catch (Exception Err)
            {
                throw Err;
            }
            finally
            {
                Response.Write("<script type='text/javascript'>alert('删除失败');window.location.href=window.location.href;</script>");
            }
        }
    }
    //删除临时表
    private void deleteTmp()
    {
        string sql = "Drop table tmp" + hfdGv.Value;
        SqlCommand cmd = new SqlCommand(sql);
        SqlConnection con = new SqlConnection(config.DBConn);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    //数据绑定时，修改评分类型的显示方式
    protected void gvExam_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}
