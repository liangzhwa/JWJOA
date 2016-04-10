/*----------------------------------------------------------------
// Copyright (C) 2008 南京环智科技有限公司
// 版权所有。 
//
// 文件名： ExmExam.aspx.cs
// 文件功能描述：警卫局网上考试答题功能
//
// 
// 创建标识：汤君 2008-04-03
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
using System.Data.SqlClient;

public partial class ExamManager_ExamAnswer : System.Web.UI.Page
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
            palQuestion.Visible = false;
            btnFrist.Visible = false;
            btnprev.Visible = false;
            btnNext.Visible = false;
            btnOK.Visible = false;
            lblStart.Visible = false;
            lblEnd.Visible = false;
            lblCount.Visible = false;
            lblSurplus.Visible = false;
            lblUseTime.Visible = false;
            lblAnswerShow.Visible = false;
            //添加交卷提示
            btnOK.Attributes.Add("onclick", "return confirm('确认交卷？');");
        }
    }
    /// <summary>
    /// 生成试卷按钮逻辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShow_Click(object sender, EventArgs e)
    {
        lblUseTime.Visible = true;
        palQuestion.Visible = true;
        btnFrist.Visible = true;
        btnprev.Visible = true;
        btnNext.Visible = true;
        btnOK.Visible = true;
        lblStart.Visible = true;
        lblEnd.Visible = true;
        lblCount.Visible = true;
        lblSurplus.Visible = true;
        //生成临时考试表
        ExmExamProvisional();
        //插入考试数据到临时表
        ExmExamInsertOne();
        //插入考试数据到临时表
        ExmExamInsertTwo();
        //插入考试数据到临时表
        ExmExamInsertThree();
        //插入考试数据到临时表
        ExmExamInsertFour();
        //插入考试数据到临时表
        ExmExamInsertFive();
        //插入考试数据到临时表
        ExmExamInsertSix();
        //从考试表查询出考试信息并赋值
        ExmExam();
        //显示开始时间
        DateTime dtNow = DateTime.Now;
        this.lblStartTime.Text = dtNow.ToString();
        //开始时间+考试时长
        DateTime dt = Convert.ToDateTime(Convert.ToString(Convert.ToInt32(hfdTimes.Value) / 60) + ":" + Convert.ToString(Convert.ToInt32(hfdTimes.Value) % 60) + ":00");
        DateTime newDateTime = Convert.ToDateTime(lblStartTime.Text).AddHours(dt.Hour);
        newDateTime = newDateTime.AddMinutes(dt.Minute);
        //显示结束时间
        this.lblEndTime.Text = newDateTime.ToString();
        lblEndTime.ToolTip = lblEndTime.Text.Substring(9, 9) + " " + lblEndTime.Text.Substring(5, 1) + "/" + lblEndTime.Text.Substring(7, 2) + "/" + lblEndTime.Text.Substring(0, 4);
        //计时开始计时
        Page.RegisterStartupScript("ggg", "<script>DoCallTimer();</script >");
        //倒计时
        Response.Write("<script language='JavaScript' type='text/JavaScript'>");
        Response.Write("var dDateHead = new Date('" + lblEndTime.ToolTip + "');"); //时间倒计时
        Response.Write("function showTimeLimit(){");
        Response.Write("setTimeout('showTimeLimit()',1000);");
        Response.Write("var dNowDay = new Date();");
        Response.Write("iTimeLimit = dDateHead.getTime()-dNowDay.getTime();");
        Response.Write("msSec = 1000;"); //一秒毫秒数
        Response.Write("msMin = 60*msSec;"); //一分钟毫秒数
        Response.Write("msHour = 60*msMin;"); //一小时毫秒数
        Response.Write("iHour=Math.floor(iTimeLimit/msHour);");
        Response.Write("iMin=Math.floor((iTimeLimit-iHour*msHour)/msMin);");
        Response.Write("iSec=Math.floor((iTimeLimit-iHour*msHour-iMin*msMin)/msSec);");
        Response.Write("iHour = iHour>=24?Math.floor(iHour%24):iHour;");
        Response.Write("iHour = iHour<10&&iHour>0?'0'+iHour:iHour;");
        Response.Write("iMin = iMin<10?'0'+iMin:iMin;");
        Response.Write("iSec = iSec<10?'0'+iSec:iSec;");
        Response.Write("document.frmtimer.thzt2.innerText=iHour+':'+iMin+':'+iSec;}");
        Response.Write("showTimeLimit();");
        Response.Write("</script>");
        //装载题目数据
        selectExmQuestion();
        //开始计时，考试时间结束，自动提交试卷
        Response.Write("<script language='javascript'>");
        Response.Write("function dopost(){");
        Response.Write("var btn = document.getElementById('btnOK');");
        Response.Write("btn.click();}");
        Response.Write("setTimeout('dopost()'," + hfdTimes.Value + ")");
        Response.Write("</Script>");
    }
    //查询考试表
    private void ExmExam()
    {
        string sql = "select Count,ExamName,Times from SExmExam where Exam_Id = '" + Session["Guid"] + "'";
        DataRow drQuestion;
        db = new MDataBase(config.DBConn);
        bool blnRtnCode = db.GetDataRow(sql, out drQuestion);
        if (blnRtnCode == false || drQuestion == null)
        {
            //错误
            return;
        }
        //赋值
        this.lblExamCount.Text = "已生成试卷，共" + drQuestion["Count"].ToString() + "条题目";
        this.lblQuestionCount.Text = "共" + drQuestion["Count"].ToString() + "题，现在是第" + lblQuestionId.Text + "题";
        this.hfdTimes.Value = drQuestion["Times"].ToString();
        ViewState["Count"] = drQuestion["Count"];
    }
    //创建临时考试表方法
    private void ExmExamProvisional()
    {
        string sql = "create table temp" + config.Staff.Username + "(Question_Id int PRIMARY KEY identity(1,1),Question_Guid char(36),Question nvarchar(200),Answer nvarchar(20),QuestionState int,Staff_Id varchar(8))";//测试用数据insert into " + Session["Guid"].ToString + "(Staff_Id)
        SqlCommand cmd = new SqlCommand(sql);
        SqlConnection con = new SqlConnection(config.DBConn);        
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    //插入数据类型一
    private void ExmExamInsertOne()
    {
        //查询临时表tmp
        string str = "select QuestionTypeIdOne,OneCount from tmp" + Session["Guid"].ToString() + " where Exam_Id='" + Session["Guid"].ToString() + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(str, out dt);
        string QuestionTypeIdOne = dt.Rows[0]["QuestionTypeIdOne"].ToString();
        string OneCount = dt.Rows[0]["OneCount"].ToString();
        string sql = "Insert Into temp" + config.Staff.Username + "(Question_Guid,Question) select top " + OneCount + " a.Question_Guid,a.Question from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id=b.QuestionType_Id and b.QuestionTypeName = '" + QuestionTypeIdOne + "'" + "order by newid()";
        SqlCommand cmd = new SqlCommand(sql);
        SqlConnection con = new SqlConnection(config.DBConn);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    //插入数据类型二
    private void ExmExamInsertTwo()
    {
        //查询临时表tmp
        string str = "select QuestionTypeIdTwo,TwoCount from tmp" + Session["Guid"].ToString() + " where Exam_Id='" + Session["Guid"].ToString() + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(str, out dt);
        if (dt.Rows.Count != 0)
        {
            string QuestionTypeIdTwo = dt.Rows[0]["QuestionTypeIdTwo"].ToString();
            string TwoCount = dt.Rows[0]["TwoCount"].ToString();
            //插数据
            string sql = "Insert Into temp" + config.Staff.Username + "(Question_Guid,Question) select top " + TwoCount + " a.Question_Guid,a.Question from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id=b.QuestionType_Id and b.QuestionTypeName = '" + QuestionTypeIdTwo + "'" + "order by newid()";
            SqlCommand cmd = new SqlCommand(sql);
            SqlConnection con = new SqlConnection(config.DBConn);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    //插入数据类型三
    private void ExmExamInsertThree()
    {
        //查询临时表tmp
        string str = "select QuestionTypeIdThree,ThreeCount from tmp" + Session["Guid"].ToString() + " where Exam_Id='" + Session["Guid"].ToString() + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(str, out dt);
        if (dt.Rows.Count != 0)
        {
            string QuestionTypeIdThree = dt.Rows[0]["QuestionTypeIdThree"].ToString();
            string ThreeCount = dt.Rows[0]["ThreeCount"].ToString();
            string sql = "Insert Into temp" + config.Staff.Username + "(Question_Guid,Question) select top " + ThreeCount + " a.Question_Guid,a.Question from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id=b.QuestionType_Id and b.QuestionTypeName = '" + QuestionTypeIdThree + "'" + "order by newid()";
            SqlCommand cmd = new SqlCommand(sql);
            SqlConnection con = new SqlConnection(config.DBConn);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    //插入数据类型四
    private void ExmExamInsertFour()
    {
        //查询临时表tmp
        string str = "select QuestionTypeIdFour,FourCount from tmp" + Session["Guid"].ToString() + " where Exam_Id='" + Session["Guid"].ToString() + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(str, out dt);
        if (dt.Rows.Count != 0)
        {
            string QuestionTypeIdFour = dt.Rows[0]["QuestionTypeIdFour"].ToString();
            string FourCount = dt.Rows[0]["FourCount"].ToString();
            string sql = "Insert Into temp" + config.Staff.Username + "(Question_Guid,Question) select top " + FourCount + " a.Question_Guid,a.Question from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id=b.QuestionType_Id and b.QuestionTypeName = '" + QuestionTypeIdFour + "'" + "order by newid()";
            SqlCommand cmd = new SqlCommand(sql);
            SqlConnection con = new SqlConnection(config.DBConn);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    //插入数据类型五
    private void ExmExamInsertFive()
    {
        //查询临时表tmp
        string str = "select QuestionTypeIdFive,FiveCount from tmp" + Session["Guid"].ToString() + " where Exam_Id='" + Session["Guid"].ToString() + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(str, out dt);
        if (dt.Rows.Count != 0)
        {
            string QuestionTypeIdFive = dt.Rows[0]["QuestionTypeIdFive"].ToString();
            string FiveCount = dt.Rows[0]["FiveCount"].ToString();
            string sql = "Insert Into temp" + config.Staff.Username + "(Question_Guid,Question) select top " + FiveCount + " a.Question_Guid,a.Question from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id=b.QuestionType_Id and b.QuestionTypeName = '" + QuestionTypeIdFive + "'" + "order by newid()";
            SqlCommand cmd = new SqlCommand(sql);
            SqlConnection con = new SqlConnection(config.DBConn);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    //插入数据类型六
    private void ExmExamInsertSix()
    {
        //查询临时表tmp
        string str = "select QuestionTypeIdSix,SixCount from tmp" + Session["Guid"].ToString() + " where Exam_Id='" + Session["Guid"].ToString() + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(str, out dt);
        if (dt.Rows.Count != 0)
        {
            string QuestionTypeIdSix = dt.Rows[0]["QuestionTypeIdSix"].ToString();
            string SixCount = dt.Rows[0]["SixCount"].ToString();
            string sql = "Insert Into temp" + config.Staff.Username + "(Question_Guid,Question) select top " + SixCount + " a.Question_Guid,a.Question from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id=b.QuestionType_Id and b.QuestionTypeName = '" + QuestionTypeIdSix + "'" + "order by newid()";
            SqlCommand cmd = new SqlCommand(sql);
            SqlConnection con = new SqlConnection(config.DBConn);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    //试题加载
    private void selectExmQuestion()
    {
        string sql = "select a.Question_Id,a.Question,a.Question_Guid,b.AnswerA,b.AnswerB,b.AnswerC,b.AnswerD,b.AnswerE,a.Answer from temp" + config.Staff.Username + " a,SExmQuestion b where a.Question_Guid=b.Question_Guid and a.Question_Id='1'";
        DataRow drQuestion;
        db = new MDataBase(config.DBConn);
        bool blnRtnCode = db.GetDataRow(sql, out drQuestion);
        if (blnRtnCode == false || drQuestion == null)
        {
            //错误
            return;
        }
        //赋值
        this.lblQuestionId.Text = drQuestion["Question_Id"].ToString();
        this.lblQuestion.Text = drQuestion["Question"].ToString();
        this.lblAnwerA.Text = drQuestion["AnswerA"].ToString();
        this.lblAnwerB.Text = drQuestion["AnswerB"].ToString();
        this.lblAnwerC.Text = drQuestion["AnswerC"].ToString();
        hfdQuestionGuid.Value = drQuestion["Question_Guid"].ToString();
        //如果D答案为空，选项框隐藏
        if (drQuestion["AnswerD"].ToString() != "")
        {
            chkAnswerD.Visible = true;
            this.lblAnwerD.Text = drQuestion["AnswerD"].ToString();
        }
        else
        {
            chkAnswerD.Visible = false;
        }
        //如果E答案为空，选项框隐藏
        if (drQuestion["AnswerE"].ToString() != "")
        {
            chkAnswerE.Visible = true;
            this.lblAnwerE.Text = drQuestion["AnswerE"].ToString();
        }
        else
        {
            chkAnswerE.Visible = false;
        }
        //装载默认为第1题，隐藏第一题和上一题按钮
        btnFrist.Visible = false;
        btnprev.Visible = false;
    }

    //取得所有的checkbox选中状态的值
    public string GetSelectedKeyValues()
    {
        //定义一个字符串
        string arrList = "";
        //遍历页面所有控件
        foreach (Control ct in palQuestion.Controls)
        {
            //如果发现checkbox
            if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
            {
                CheckBox cb = (CheckBox)ct;
                //如果checkbox为选中状态
                if (cb.Checked == true)
                {
                    //将checkbox的值，截取字母存入数组selectedRows中
                    arrList += cb.Text;
                }
            }
        }
        return arrList;
    }

    //返回第一题时的逻辑
    protected void btnFrist_Click(object sender, EventArgs e)
    {
        //调用GetSelectedKeyValues方法获得所选答案
        string arrList = GetSelectedKeyValues();
        //判断答案为空
        if (lblAnswer.Text == "")
        {
            hfdState.Value = "0";
        }
        //如果答案不为空，去数据库与正确答案对比，如果正确，GV取得1，否则取得2
        else
        {
            //检索答案与答题者填写对比，未填GV保存0，正确GV保存1，错误GV保存2
            selectAnswer(arrList);
        }
        //checkbox清空
        chkAnswerA.Checked = false;
        chkAnswerB.Checked = false;
        chkAnswerC.Checked = false;
        chkAnswerD.Checked = false;
        chkAnswerE.Checked = false;
        lblAnswer.Text = "";
        //保存当前题并装载第一题的方法
        selectExmQuestionOne(arrList);
       
        //如果当前是第一题，则上一题和第一题的按钮隐藏
        if (lblQuestionId.Text == "1")
        {
            btnFrist.Visible = false;
            btnprev.Visible = false;
        }
        else
        {
            btnFrist.Visible = true;
            btnprev.Visible = true;
        }

        //如果当前是最后一题，则下一题的按钮隐藏
        if (lblQuestionId.Text == Session["Count"].ToString())
        {
            btnNext.Visible = false;
        }
        else
        {
            btnNext.Visible = true;
        }
        //查询未做题的数量并显示在页面
        selectQuestionState();
        this.lblQuestionCount.Text = "共" + ViewState["Count"].ToString() + "题，现在是第" + lblQuestionId.Text + "题";
    }
    //检索答案与答题者填写对比，未填GV保存0，正确GV保存1，错误GV保存2
    private void selectAnswer(string Answer)
    {
        string sql = "select Answer from SExmQuestion where Question_Guid ='" + hfdQuestionGuid.Value + "'";
        DataRow drQuestion;
        db = new MDataBase(config.DBConn);
        bool blnRtnCode = db.GetDataRow(sql, out drQuestion);
        if (blnRtnCode == false || drQuestion == null)
        {
            //错误
            return;
        }
        //如果答案正确，GV保存为1
        if (Answer == drQuestion["Answer"].ToString())
        {
            hfdState.Value = "1";
        }
        //如果答案错误，GV保存为2
        else
        {
            hfdState.Value = "2";
        }
    }
    //第一题装载方法
    private void selectExmQuestionOne(string Answer)
    {
        //保存当前题目
        string sqlOk = "update temp" + config.Staff.Username + " set QuestionState= '" + hfdState.Value + "',Answer='" + Answer + "' where Question_Id='" + lblQuestionId.Text + "'";
        db = new MDataBase(config.DBConn);
        db.executeUpdate(sqlOk);
        //装载第一题
        string sql = "select a.Question_Id,a.Question,a.Question_Guid,b.AnswerA,b.AnswerB,b.AnswerC,b.AnswerD,b.AnswerE,a.Answer from temp" + config.Staff.Username + " a,SExmQuestion b where a.Question_Guid=b.Question_Guid and a.Question_Id='1'";
        //string sql = "select a.Question_Id,a.Question,a.Question_Guid,b.AnswerA,b.AnswerB,b.AnswerC,b.AnswerD,b.AnswerE a.Answer from temp" + config.Staff.Username + " a,SExmQuestion b where a.Question_Guid=b.Question_Guid and a.Question_Id='1'";
        DataRow drQuestion;
        db = new MDataBase(config.DBConn);
        bool blnRtnCode = db.GetDataRow(sql, out drQuestion);
        if (blnRtnCode == false || drQuestion == null)
        {
            //错误
            return;
        }
        //赋值
        this.lblQuestionId.Text = drQuestion["Question_Id"].ToString();
        this.lblQuestion.Text = drQuestion["Question"].ToString();
        this.lblAnwerA.Text = drQuestion["AnswerA"].ToString();
        this.lblAnwerB.Text = drQuestion["AnswerB"].ToString();
        this.lblAnwerC.Text = drQuestion["AnswerC"].ToString();
        this.lblAnswer.Text = drQuestion["Answer"].ToString();
        hfdQuestionGuid.Value = drQuestion["Question_Guid"].ToString();
        //如果答案里包括A，chkAnswerA钩上
        if (lblAnswer.Text.IndexOf("A") != -1)
        {
            chkAnswerA.Checked = true;
        }
        //如果答案里包括B，chkAnswerB钩上
        if (lblAnswer.Text.IndexOf("B") != -1)
        {
            chkAnswerB.Checked = true;
        }
        //如果答案里包括C，chkAnswerC钩上
        if (lblAnswer.Text.IndexOf("C") != -1)
        {
            chkAnswerC.Checked = true;
        }
        //如果答案里包括D，chkAnswerD钩上
        if (lblAnswer.Text.IndexOf("D") != -1)
        {
            chkAnswerD.Checked = true;
        }
        //如果答案里包括E，chkAnswerE钩上
        if (lblAnswer.Text.IndexOf("E") != -1)
        {
            chkAnswerE.Checked = true;
        }
        //如果D答案为空，选项框隐藏
        if (drQuestion["AnswerD"].ToString() != "")
        {
            chkAnswerD.Visible = true;
            this.lblAnwerD.Text = drQuestion["AnswerD"].ToString();
        }
        else
        {
            lblAnwerD.Text = "";
            chkAnswerD.Visible = false;
        }
        //如果E答案为空，选项框隐藏
        if (drQuestion["AnswerE"].ToString() != "")
        {
            chkAnswerE.Visible = true;
            this.lblAnwerE.Text = drQuestion["AnswerE"].ToString();
        }
        else
        {
            lblAnwerE.Text = "";
            chkAnswerE.Visible = false;
        }
    }
    //下一题按钮逻辑
    protected void btnNext_Click(object sender, EventArgs e)
    {
        //调用GetSelectedKeyValues方法获得所选答案
        string arrList = GetSelectedKeyValues();
        //判断答案为空
        if (lblAnswer.Text == "")
        {
            hfdState.Value = "0";
        }
        //如果答案不为空，去数据库与正确答案对比，如果正确，GV取得1，否则取得2
        else
        {
            selectAnswer(arrList);
        }
        //checkbox清空
        chkAnswerA.Checked = false;
        chkAnswerB.Checked = false;
        chkAnswerC.Checked = false;
        chkAnswerD.Checked = false;
        chkAnswerE.Checked = false;
        lblAnswer.Text = "";
        //保存当前题并装载下一题的方法
        selectExmQuestionNext(arrList);
        //如果当前是第一题，则上一题和第一题的按钮隐藏
        if (lblQuestionId.Text == "1")
        {
            btnFrist.Visible = false;
            btnprev.Visible = false;
        }
        else
        {
            btnFrist.Visible = true;
            btnprev.Visible = true;
        }

        //如果当前是最后一题，则下一题的按钮隐藏
        if (lblQuestionId.Text == Session["Count"].ToString())
        {
            btnNext.Visible = false;
        }
        else
        {
            btnNext.Visible = true;
        }
        //查询未做题的数量并显示在页面
        selectQuestionState();
        this.lblQuestionCount.Text = "共" + ViewState["Count"].ToString() + "题，现在是第" + lblQuestionId.Text + "题";
    }
    //保存当前题目并装载下一题方法
    private void selectExmQuestionNext(string Answer)
    {
        //保存当前题目
        string sqlOk = "update temp" + config.Staff.Username + " set QuestionState= '" + hfdState.Value + "',Answer='" + Answer + "' where Question_Id='" + lblQuestionId.Text + "'";
        db = new MDataBase(config.DBConn);
        db.executeUpdate(sqlOk);
        //装载下一题
        string sql = "select a.Question_Id,a.Question,a.Question_Guid,b.AnswerA,b.AnswerB,b.AnswerC,b.AnswerD,b.AnswerE,a.Answer from temp" + config.Staff.Username + " a,SExmQuestion b where a.Question_Guid=b.Question_Guid and a.Question_Id='" + Convert.ToString(Convert.ToInt32(lblQuestionId.Text) + 1) + "'";
        DataRow drQuestion;
        db = new MDataBase(config.DBConn);
        bool blnRtnCode = db.GetDataRow(sql, out drQuestion);
        if (blnRtnCode == false || drQuestion == null)
        {
            // 错误
            return;
        }
        //赋值
        this.lblQuestionId.Text = drQuestion["Question_Id"].ToString();
        this.lblQuestion.Text = drQuestion["Question"].ToString();
        this.lblAnwerA.Text = drQuestion["AnswerA"].ToString();
        this.lblAnwerB.Text = drQuestion["AnswerB"].ToString();
        this.lblAnwerC.Text = drQuestion["AnswerC"].ToString();
        this.lblAnswer.Text = drQuestion["Answer"].ToString();
        hfdQuestionGuid.Value = drQuestion["Question_Guid"].ToString();
        //如果答案里包括A，chkAnswerA钩上
        if (lblAnswer.Text.IndexOf("A") != -1)
        {
            chkAnswerA.Checked = true;
        }
        //如果答案里包括B，chkAnswerB钩上
        if (lblAnswer.Text.IndexOf("B") != -1)
        {
            chkAnswerB.Checked = true;
        }
        //如果答案里包括C，chkAnswerC钩上
        if (lblAnswer.Text.IndexOf("C") != -1)
        {
            chkAnswerC.Checked = true;
        }
        //如果答案里包括D，chkAnswerD钩上
        if (lblAnswer.Text.IndexOf("D") != -1)
        {
            chkAnswerD.Checked = true;
        }
        //如果答案里包括E，chkAnswerE钩上
        if (lblAnswer.Text.IndexOf("E") != -1)
        {
            chkAnswerE.Checked = true;
        }
        //如果D答案为空，选项框隐藏
        if (drQuestion["AnswerD"].ToString() != "")
        {
            chkAnswerD.Visible = true;
            this.lblAnwerD.Text = drQuestion["AnswerD"].ToString();
        }
        else
        {
            lblAnwerD.Text = "";
            chkAnswerD.Visible = false;
        }
        //如果E答案为空，选项框隐藏
        if (drQuestion["AnswerE"].ToString() != "")
        {
            chkAnswerE.Visible = true;
            this.lblAnwerE.Text = drQuestion["AnswerE"].ToString();
        }
        else
        {
            lblAnwerE.Text = "";
            chkAnswerE.Visible = false;
        }
    }
    //上一题按钮逻辑
    protected void btnprev_Click(object sender, EventArgs e)
    {
        //调用GetSelectedKeyValues方法获得所选答案
        string arrList = GetSelectedKeyValues();
        //判断答案为空
        if (lblAnswer.Text == "")
        {
            hfdState.Value = "0";
        }
        //如果答案不为空，去数据库与正确答案对比，如果正确，GV取得1，否则取得2
        else
        {
            //检索答案与答题者填写对比，未填GV保存0，正确GV保存1，错误GV保存2
            selectAnswer(arrList);
        }
        //checkbox清空
        chkAnswerA.Checked = false;
        chkAnswerB.Checked = false;
        chkAnswerC.Checked = false;
        chkAnswerD.Checked = false;
        chkAnswerE.Checked = false;
        lblAnswer.Text = "";
        //保存当前题并装载上一题的方法
        selectExmQuestioPrev(arrList);
        //执行查询当前考试进度的方法
        ExamProgress();
        //如果当前是第一题，则上一题和第一题的按钮隐藏
        if (lblQuestionId.Text == "1")
        {
            btnFrist.Visible = false;
            btnprev.Visible = false;
        }
        else
        {
            btnFrist.Visible = true;
            btnprev.Visible = true;
        }

        //如果当前是最后一题，则下一题的按钮隐藏
        if (lblQuestionId.Text == Session["Count"].ToString())
        {
            btnNext.Visible = false;
        }
        else
        {
            btnNext.Visible = true;
        }
        //查询未做题的数量并显示在页面
        selectQuestionState();
        this.lblQuestionCount.Text = "共" + ViewState["Count"].ToString() + "题，现在是第" + lblQuestionId.Text + "题";
    }
    //保存当前题并装载上一题的方法
    private void selectExmQuestioPrev(string Answer)
    {
        //保存当前题目
        string sqlOk = "update temp" + config.Staff.Username + " set QuestionState= '" + hfdState.Value + "',Answer='" + Answer + "' where Question_Id='" + lblQuestionId.Text + "'";
        db = new MDataBase(config.DBConn);
        db.executeUpdate(sqlOk);
        //装载下一题
        string sql = "select a.Question_Id,a.Question,a.Question_Guid,b.AnswerA,b.AnswerB,b.AnswerC,b.AnswerD,b.AnswerE,a.Answer from temp" + config.Staff.Username + " a,SExmQuestion b where a.Question_Guid=b.Question_Guid and a.Question_Id='" + Convert.ToString(Convert.ToInt32(lblQuestionId.Text) - 1) + "'";
        DataRow drQuestion;
        db = new MDataBase(config.DBConn);
        bool blnRtnCode = db.GetDataRow(sql, out drQuestion);
        if (blnRtnCode == false || drQuestion == null)
        {
            // 错误
            return;
        }
        //赋值
        this.lblQuestionId.Text = drQuestion["Question_Id"].ToString();
        this.lblQuestion.Text = drQuestion["Question"].ToString();
        this.lblAnwerA.Text = drQuestion["AnswerA"].ToString();
        this.lblAnwerB.Text = drQuestion["AnswerB"].ToString();
        this.lblAnwerC.Text = drQuestion["AnswerC"].ToString();
        this.lblAnswer.Text = drQuestion["Answer"].ToString();
        hfdQuestionGuid.Value = drQuestion["Question_Guid"].ToString();
        //如果答案里包括A，chkAnswerA钩上
        if (lblAnswer.Text.IndexOf("A") != -1)
        {
            chkAnswerA.Checked = true;
        }
        //如果答案里包括B，chkAnswerB钩上
        if (lblAnswer.Text.IndexOf("B") != -1)
        {
            chkAnswerB.Checked = true;
        }
        //如果答案里包括C，chkAnswerC钩上
        if (lblAnswer.Text.IndexOf("C") != -1)
        {
            chkAnswerC.Checked = true;
        }
        //如果答案里包括D，chkAnswerD钩上
        if (lblAnswer.Text.IndexOf("D") != -1)
        {
            chkAnswerD.Checked = true;
        }
        //如果答案里包括E，chkAnswerE钩上
        if (lblAnswer.Text.IndexOf("E") != -1)
        {
            chkAnswerE.Checked = true;
        }
        //如果D答案为空，选项框隐藏
        if (drQuestion["AnswerD"].ToString() != "")
        {
            chkAnswerD.Visible = true;
            this.lblAnwerD.Text = drQuestion["AnswerD"].ToString();
        }
        else
        {
            lblAnwerD.Text = "";
            chkAnswerD.Visible = false;
        }
        //如果E答案为空，选项框隐藏
        if (drQuestion["AnswerE"].ToString() != "")
        {
            chkAnswerE.Visible = true;
            this.lblAnwerE.Text = drQuestion["AnswerE"].ToString();
        }
        else
        {
            lblAnwerE.Text = "";
            chkAnswerE.Visible = false;
        }
    }
    //查询考试进度
    private void ExamProgress()
    {
        string sql = "select QuestionState from temp" + config.Staff.Username + " where QuestionState='0'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        string Count = (dt.Rows.Count).ToString();
    }
    //提交试卷
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //计时器停止
        Page.RegisterStartupScript("ggg", "<script>clearTimeout(window.timer1);</script >"); 
        //取得系统时间（交卷时间）
        DateTime dtNow = DateTime.Now;
        CSExmScore exm = new CSExmScore(config.DBConn);
        exm.Score_Guid = Guid.NewGuid().ToString();
        exm.StartTime = Convert.ToDateTime(lblStartTime.Text);
        exm.EndTime = dtNow;
        exm.Staff_Id = "";//测试用数据
        exm.Exam_Id = Session["Guid"].ToString();
        //保存考题信息（对，错，未做）到成绩表
        QuestionAdd();
        //插入分数到成绩表
        ScoreAdd();
        //插入名次到成绩表的方法
        Gradation();
        //保存考试平均分到考试表
        AverageAdd();
        //关闭临时表
        DropTable();
    }
    //关闭临时表方法
    private void DropTable()
    {
        string sql = "Drop table temp" + config.Staff.Username + "";
        SqlCommand cmd = new SqlCommand(sql);
        SqlConnection con = new SqlConnection(config.DBConn);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    //插入平均分到考试表
    private void AverageAdd()
    {
        string sql = "select avg(score) from SExmScore where Exam_Id='" + Session["Guid"].ToString() + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        float Average = Convert.ToInt32(dt.Rows[0]);
        string sqlin = "UPDATE SExmExam set Average='" + Average + "')";
        db = new MDataBase(config.DBConn);
        db.executeUpdate(sqlin);
    }
    //插入名次到成绩表的方法
    private void Gradation()
    {
        string sql = "select 1 as index,Score from SExmScore where Exam_Id='" + Session["Guid"].ToString() + "' order by Score";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["index"] = Convert.ToInt32(dt.Rows[i]["index"].ToString()) + i;
        }
    }
    //插入分数到成绩表的方法,正确数/总题数
    private void ScoreAdd()
    {
        string sql = "select RightCount from SExmScore where Exam_Id='" + Session["Guid"].ToString() + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        //取得正确题数
        int RightCount = dt.Rows.Count;
        //取得平均分的方法（正确数/总题数）
        float Score = RightCount / Convert.ToInt32(Session["Count"]);
        string sqlin = "UPDATE SExmScore set Score='" + Score + "'";
        db = new MDataBase(config.DBConn);
        db.executeUpdate(sqlin);
    }
    //保存考题信息（对，错，未做）到成绩表
    private void QuestionAdd()
    {
        //先检索临时表，得到考题信息
        string sql = "select QuestionState,count(*) as sum from temp" + config.Staff.Username + " group by QuestionState";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        string aa = dt.Rows[0]["sum"].ToString();
        string bb = dt.Rows[1]["sum"].ToString();
        string cc = dt.Rows[2]["sum"].ToString();
        //插入考题信息
        string sqlin = "update SExmScore set RightCount='" + bb + "',WrongCount='" + cc + "',UnfinishCount='" + aa + "'";
        db = new MDataBase(config.DBConn);
        db.executeUpdate(sqlin);

    }
    //查询未做题的数量
    private void selectQuestionState()
    {
        string sql = "select QuestionState from temp" + config.Staff.Username + " where QuestionState='0'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        this.lblTip.Text = "有" + (dt.Rows.Count).ToString() + "题标记未做题";
    }
    /// <summary>
    /// 答案A钩选事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkAnswerA_CheckedChanged(object sender, EventArgs e)
    {
         //判断钩选事件是打钩还是取消打钩
        if (chkAnswerA.Checked == true)
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
    /// <summary>
    /// 答案B钩选事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkAnswerB_CheckedChanged(object sender, EventArgs e)
    {
        //判断钩选事件是打钩还是取消打钩
        if (chkAnswerB.Checked == true)
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
    /// <summary>
    /// 答案C钩选事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkAnswerC_CheckedChanged(object sender, EventArgs e)
    {
        //判断钩选事件是打钩还是取消打钩
        if (chkAnswerC.Checked == true)
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
    /// <summary>
    /// 答案D钩选事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkAnswerD_CheckedChanged(object sender, EventArgs e)
    {
        //判断钩选事件是打钩还是取消打钩
        if (chkAnswerD.Checked == true)
        {
            lblAnswerShow.Visible = true;
            lblAnswer.Text += "D";
        }
        else
        {
            //截断第1个D
            lblAnswer.Text = lblAnswer.Text.Replace("D", "");
        }
    }
    /// <summary>
    /// 答案E钩选事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkAnswerE_CheckedChanged(object sender, EventArgs e)
    {
        //判断钩选事件是打钩还是取消打钩
        if (chkAnswerE.Checked == true)
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
