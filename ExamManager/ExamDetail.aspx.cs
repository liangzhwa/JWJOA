/*----------------------------------------------------------------
// Copyright (C) 2008 南京环智科技有限公司
// 版权所有。 
//
// 文件名： ExamDetail.aspx.cs
// 文件功能描述：警卫局网上考试系统试卷详细信息页面
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

public partial class ExamManager_ExamDetail : System.Web.UI.Page
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
            ViewState["ExamId"] = Request.QueryString["ExamId"];
            selectExam();
        }
    }
    //查询考试信息方法
    private void selectExam()
    {
        string sql = "select Exam_Id,ExamName,ScoreType,StartTime,EndTime,Times,Count,ExamEmploees,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate from SExmExam where Exam_Id ='" + ViewState["ExamId"].ToString() + "'";
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
        this.lblScoreType.Text = HttpUtility.HtmlDecode(drQuestion["ScoreType"].ToString());
        this.lblStartTime.Text = drQuestion["StartTime"].ToString();
        this.lblEndTime.Text = drQuestion["EndTime"].ToString();
        this.lblTimes.Text = drQuestion["Times"].ToString();
        this.lblCount.Text = HttpUtility.HtmlDecode(drQuestion["Count"].ToString());
        this.lblEmploeesCount.Text = HttpUtility.HtmlDecode(drQuestion["ExamEmploees"].ToString());
        this.lblExamEmploees.Text = HttpUtility.HtmlDecode(drQuestion["ExamEmploees"].ToString());
        this.lblRatio.Text = Convert.ToString(Convert.ToSingle(lblExamEmploees.Text) * 100 / Convert.ToSingle(lblEmploeesCount.Text)) + "%";
        this.lblCreatedBy.Text = HttpUtility.HtmlDecode(drQuestion["CreatedBy"].ToString());
        this.lblCreatedDate.Text = HttpUtility.HtmlDecode(drQuestion["CreatedDate"].ToString());
        this.lblModifiedBy.Text = HttpUtility.HtmlDecode(drQuestion["ModifiedBy"].ToString());
        this.lblModifiedDate.Text = HttpUtility.HtmlDecode(drQuestion["ModifiedDate"].ToString());
    }
}
