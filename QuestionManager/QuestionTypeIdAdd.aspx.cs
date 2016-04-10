/*----------------------------------------------------------------
// Copyright (C) 2008 南京环智科技有限公司

// 版权所有。 
//
// 文件名： QuestionTypeIdAdd.aspx.cs
// 文件功能描述：警卫局网上考试题库维护题型增加
//
// 
// 创建标识：汤君 2008-03-29
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

public partial class ExamManager_QuestionTypeIdAdd : System.Web.UI.Page
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
            lblQuestionTypeName.Visible = false;
            lblQuestionTypeId.Visible = false;
        }
    }
    /// <summary>
    /// 确认按钮事件，实际写入数据库
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOK_Click(object sender, EventArgs e)
    {
        QuestionTypeName();
        QuestionTypeId();
        CSC_QuestionType exm = new CSC_QuestionType(config.DBConn);
        exm.QuestionType_Id = this.txtQuestionTypeId.Text;
        exm.QuestionTypeName = this.txtQuestionTypeName.Text;
        exm.Insert();
        Response.Write("<script type='text/javascript'>alert('题型添加成功！');window.location.href=window.location.href;</script>");
    }
    //判断类型ID是否重复
    private void QuestionTypeId()
    {
        string sql = "select QuestionType_Id from SC_QuestionType where QuestionType_Id = '" + txtQuestionTypeId.Text + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        if (dt.Rows.Count > 0)
        {
            lblQuestionTypeId.Visible = true;
            return;
        }
        else
        {
            lblQuestionTypeId.Visible = false;
        } 
    }
    //判断类型是否重复
    private void QuestionTypeName()
    {
        string sql = "select QuestionTypeName from SC_QuestionType where QuestionTypeName = '" + txtQuestionTypeName.Text + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        if (dt.Rows.Count > 0)
        {
            lblQuestionTypeName.Visible = true;
            return;
        }
        else
        {
            lblQuestionTypeName.Visible = false;
        }
    }
    //跳转到题目增加页面
    protected void btnQuestionAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("QuestionAdd.aspx", false);
    }
}
