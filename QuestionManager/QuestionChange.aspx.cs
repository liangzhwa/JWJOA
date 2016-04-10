/*----------------------------------------------------------------
// Copyright (C) 2008 南京环智科技有限公司

// 版权所有。 
//
// 文件名： QuestionChange.aspx.cs
// 文件功能描述：警卫局网上考试题库修改
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

public partial class QuestionChange : System.Web.UI.Page
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
            lblAnswerError.Visible = false;            
            lblAnswerE.Visible = false;
            lblError.Visible = false;
            ViewState["Question_Guid"] = Request.QueryString["QuestionGuid"];
            //赋值
            this.GetQuestionInfo();
            //DorpDownList装载
            this.QuestionTypeDataBind();
        }             
    }

    //赋值
    private void GetQuestionInfo()
    {
        string sql = "select a.Question,a.QuestionType_Id,b.QuestionTypeName,a.Answer,a.AnswerA,a.AnswerB,a.AnswerC,a.AnswerD,a.AnswerE from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id=b.QuestionType_Id and a.Question_Guid = '" + ViewState["Question_Guid"].ToString() + "'";
        DataRow drQuestion;
        db = new MDataBase(config.DBConn);
        bool blnRtnCode = db.GetDataRow(sql, out drQuestion);
        if (blnRtnCode == false || drQuestion == null)
        {
            // 错误
            return;
        }
        this.txtQuestionChange.Text = HttpUtility.HtmlDecode(drQuestion["Question"].ToString());
        this.sltQuestionTypeId.Text = HttpUtility.HtmlDecode(drQuestion["QuestionType_Id"].ToString());
        this.lblAnswer.Text = drQuestion["Answer"].ToString();
        //如果答案里包括A，ckbAnswerA钩上
        if (lblAnswer.Text.IndexOf("A") != -1)
        {
            ckbAnswerA.Checked = true;
        }
        //如果答案里包括B，ckbAnswerB钩上
        if (lblAnswer.Text.IndexOf("B") != -1)
        {
            ckbAnswerB.Checked = true;
        }
        //如果答案里包括C，ckbAnswerC钩上
        if (lblAnswer.Text.IndexOf("C") != -1)
        {
            ckbAnswerC.Checked = true;
        }
        //如果答案里包括D，ckbAnswerD钩上
        if (lblAnswer.Text.IndexOf("D") != -1)
        {
            ckbAnswerD.Checked = true;
        }
        //如果答案里包括E，ckbAnswerE钩上
        if (lblAnswer.Text.IndexOf("E") != -1)
        {
            ckbAnswerE.Checked = true;
        }
        this.txtAnswerA.Text = HttpUtility.HtmlDecode(drQuestion["AnswerA"].ToString());
        this.txtAnswerB.Text = HttpUtility.HtmlDecode(drQuestion["AnswerB"].ToString());
        this.txtAnswerC.Text = HttpUtility.HtmlDecode(drQuestion["AnswerC"].ToString());
        this.txtAnswerD.Text = HttpUtility.HtmlDecode(drQuestion["AnswerD"].ToString());
        this.txtAnswerE.Text = HttpUtility.HtmlDecode(drQuestion["AnswerE"].ToString());
    }
    //判断问题是否重复
    private void Question()
    {
        string sql = "select Question from SExmQuestion where Question = '" + txtQuestionChange.Text + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        if (dt.Rows.Count > 0)
        {
            lblError.Visible = true;
            return;
        }
        else
        {
            lblError.Visible = false;
        }
    }

    /// <summary>
    /// 保存按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //判断是否钩选了正确答案
        if (lblAnswer.Text == "")
        {
            lblAnswerError.Visible = true;
            return;
        }
        lblAnswerError.Visible = false;
        //判断问题是否重复
        Question();
        //判断是否没填答案D就填答案E
        if (txtAnswerD.Text.Trim() == "" && txtAnswerE.Text.Trim() != "")
        {
            lblAnswerE.Visible = true;
            return;
        }
        lblAnswerE.Visible = false;
        //数据库连接
        CSExmQuestion exm = new CSExmQuestion(config.DBConn);
        exm.Question_Guid = ViewState["Question_Guid"].ToString();
        exm.Question = HttpUtility.HtmlEncode(this.txtQuestionChange.Text);
        exm.QuestionType_Id = this.sltQuestionTypeId.SelectedValue;
        //遍历页面所有checkbox并把钩选为true的checkbox的值截取字母拼到arrList里
        string arrList = GetSelectedKeyValues();
        exm.Answer = arrList;
        //exm.Answer = HttpUtility.HtmlEncode(this.lblAnswer.Text);
        exm.AnswerA = HttpUtility.HtmlEncode(this.txtAnswerA.Text);
        exm.AnswerB = HttpUtility.HtmlEncode(this.txtAnswerB.Text);
        exm.AnswerC = HttpUtility.HtmlEncode(this.txtAnswerC.Text);
        exm.AnswerD = HttpUtility.HtmlEncode(this.txtAnswerD.Text);
        exm.AnswerE = HttpUtility.HtmlEncode(this.txtAnswerE.Text);
        exm.ModifiedBy = "";//config.Staff.Staff_Id;

        try
        {
            exm.Update();
            //弹出对话框 
            Response.Write("<Script Langage='JavaScript'>");
            Response.Write("alert('修改成功！');");
            Response.Write("window.location='QuestionList.aspx';");
            Response.Write("</Script>");
        }
        catch
        { }
        finally
        {
            Response.Write("<script type='text/javascript'>alert('题目修改失败');window.location.href=window.location.href;</script>"); 
        }
    }
    //取得所有的checkbox选中状态的值
    public string GetSelectedKeyValues()
    {
        //定义一个字符串
        string arrList = "";
        //遍历页面所有控件
        foreach (Control ct in palQuestionChange.Controls)
        {
            //如果发现checkbox
            if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
            {
                CheckBox cb = (CheckBox)ct;
                //如果checkbox为选中状态
                if (cb.Checked == true)
                {
                    //将checkbox的值，截取字母存入数组selectedRows中
                    arrList += cb.Text.Substring(2, 1);
                }
            }
        }
        return arrList;
    }

    //下拉菜单数据绑定
    protected void QuestionTypeDataBind()
    {
        string sql = "select QuestionTypeName,QuestionType_Id from SC_QuestionType";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        sltQuestionTypeId.DataSource = dt.DefaultView;
        sltQuestionTypeId.DataValueField = "QuestionType_Id";
        sltQuestionTypeId.DataTextField = "QuestionTypeName";
        sltQuestionTypeId.DataBind();
    }

    //跳转查询页面
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Server.Transfer(@"../ExamManager/QuestionList.aspx");
    }
    //答案E钩选事件
    protected void ckbAnswerE_CheckedChanged(object sender, EventArgs e)
    {
        //判空
        if (txtAnswerE.Text.Trim() == "")
        {
            Response.Write("<script type='text/javascript'>alert('无答案E');window.location.href=window.location.href;</script>");
        }
        else
        {
            //判断钩选事件是打钩还是取消打钩
            if (ckbAnswerC.Checked == true)
            {
                lblAnswerShow.Visible = true;
                lblAnswer.Text += "E";
            }
            else
            {
                //截断第1个E
                lblAnswer.Text = lblAnswer.Text.Replace("E", "");
            }
        }
    }
    //答案A钩选事件
    protected void ckbAnswerA_CheckedChanged(object sender, EventArgs e)
    {
        //判断钩选事件是打钩还是取消打钩
        if (ckbAnswerA.Checked == true)
        {
            lblAnswerShow.Visible = true;
            lblAnswer.Text += "A";
        }
        else
        {
            //截断第1个A
            lblAnswer.Text = lblAnswer.Text.Replace("A", "");
        }
    }
    //答案B钩选事件
    protected void ckbAnswerB_CheckedChanged(object sender, EventArgs e)
    {
        //判断钩选事件是打钩还是取消打钩
        if (ckbAnswerB.Checked == true)
        {
            lblAnswerShow.Visible = true;
            lblAnswer.Text += "B";
        }
        else
        {
            //截断第1个B
            lblAnswer.Text = lblAnswer.Text.Replace("B", "");
        }
    }
    //答案C钩选事件
    protected void ckbAnswerC_CheckedChanged(object sender, EventArgs e)
    {
        //判断钩选事件是打钩还是取消打钩
        if (ckbAnswerC.Checked == true)
        {
            lblAnswerShow.Visible = true;
            lblAnswer.Text += "C";
        }
        else
        {
            //截断第1个C
            lblAnswer.Text = lblAnswer.Text.Replace("C", "");
        }
    }
    //答案D钩选事件
    protected void ckbAnswerD_CheckedChanged(object sender, EventArgs e)
    {
        //判空
        if (txtAnswerD.Text.Trim() == "")
        {
            Response.Write("<script type='text/javascript'>alert('无答案D');window.location.href=window.location.href;</script>");
        }
        else
        {
            //判断钩选事件是打钩还是取消打钩
            if (ckbAnswerC.Checked == true)
            {
                lblAnswerShow.Visible = true;
                lblAnswer.Text += "D";
            }
            else
            {
                //截断D
                lblAnswer.Text = lblAnswer.Text.Replace("D", "");
            }
        }
    }
}
