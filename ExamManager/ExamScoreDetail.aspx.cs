/*----------------------------------------------------------------
// Copyright (C) 2008 南京环智科技有限公司
// 版权所有。 
//
// 文件名： ExamScoreDetail.aspx.cs
// 文件功能描述：警卫局网上考试系统参考人员详细信息页面
//
// 
// 创建标识：汤君 2008-04-01
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

public partial class ExamManager_ExamScoreDetail : System.Web.UI.Page
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
            selectExamStaff();
            ViewState["ScoreGuid"] = Request.QueryString["ScoreGuid"];
        }
    }
    //查询考试人员信息方法
    private void selectExamStaff()
    {
        string sql = "select a.Exam_Id,a.ExamName,b.Staff_Id,b.StartTime,b.EndTime,b.RightCount,b.WrongCount,b.UnfinishCount,b.Score,a.Average,b.Gradation from SExmExam a,SExmScore b where a.Exam_Id=b.Exam_Id and b.Score_Guid ='" + ViewState["ScoreGuid"] + "'";
        DataRow drQuestion;
        db = new MDataBase(config.DBConn);
        bool blnRtnCode = db.GetDataRow(sql, out drQuestion);
        if (blnRtnCode == false || drQuestion == null)
        {
            //错误
            return;
        }
        //赋值
        this.lblExamId.Text = HttpUtility.HtmlDecode(drQuestion["Exam_Id"].ToString());
        this.lblExamName.Text = HttpUtility.HtmlDecode(drQuestion["ExamName"].ToString());
        this.lblstaff.Text = HttpUtility.HtmlDecode(drQuestion["Staff_Id"].ToString());
        this.lblStartTime.Text = HttpUtility.HtmlDecode(drQuestion["StartTime"].ToString());
        this.lblEndTime.Text = HttpUtility.HtmlDecode(drQuestion["EndTime"].ToString());
        this.lblRightCount.Text = HttpUtility.HtmlDecode(drQuestion["RightCount"].ToString());
        this.lblWrongCount.Text = HttpUtility.HtmlDecode(drQuestion["WrongCount"].ToString());
        this.lblUnfinishCount.Text = HttpUtility.HtmlDecode(drQuestion["UnfinishCount"].ToString());
        this.lblScore.Text = HttpUtility.HtmlDecode(drQuestion["Score"].ToString());
        this.lblAverage.Text = HttpUtility.HtmlDecode(drQuestion["Average"].ToString());
        this.lblGradation.Text = HttpUtility.HtmlDecode(drQuestion["Gradation"].ToString());
    }
}
