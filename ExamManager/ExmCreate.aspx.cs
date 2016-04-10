/*----------------------------------------------------------------
// Copyright (C) 2008 南京环智科技有限公司

// 版权所有。 
//
// 文件名： ExamCreat.aspx.cs
// 文件功能描述：警卫局网上考试考试管理
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
using System.Drawing;
using System.Web.UI.MobileControls;
using System.Data.SqlClient;

public partial class ExamManager_ExamCreat : System.Web.UI.Page
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
            //DropDownList绑值
            sltDataBind(sltQuestionTypeIdOne);
            sltDataBind(sltQuestionTypeIdTwo);
            sltDataBind(sltQuestionTypeIdThree);
            sltDataBind(sltQuestionTypeIdFour);
            sltDataBind(sltQuestionTypeIdFive);
            sltDataBind(sltQuestionTypeIdSix);
            //判断是否是修改按钮的链接
            string str = Request.QueryString["ID"].Substring(0,1);
            if (str == "2")
            {
                lblHead.Text = "考试修改";
                //赋值
                ViewState["ExamId"] = Request.QueryString["ID"].Substring(1);
                selectExam();
            }
            if (str == "1")
            {
                lblHead.Text = "考试增加";
            }
        }
    }
    //查询考试信息方法
    private void selectExam()
    {
        string sql = "select a.ExamName,b.Staff_Id,b.QuestionTypeIdOne,b.QuestionTypeIdTwo,b.QuestionTypeIdThree,b.QuestionTypeIdFour,b.QuestionTypeIdFive,b.QuestionTypeIdSix,b.OneCount,b.TwoCount,b.ThreeCount,b.FourCount,b.FiveCount,b.SixCount,a.ScoreType,a.StartTime,a.EndTime,a.Times,a.Count from SExmExam a,tmp" + ViewState["ExamId"] + " b where a.Exam_Id=b.Exam_Id and a.Exam_Id='" + ViewState["ExamId"] + "'";
        DataRow drQuestion;
        db = new MDataBase(config.DBConn);
        bool blnRtnCode = db.GetDataRow(sql, out drQuestion);
        if (blnRtnCode == false || drQuestion == null)
        {
            //错误
            return;
        }
        //赋值
        this.txtExamName.Text = HttpUtility.HtmlDecode(drQuestion["ExamName"].ToString());
        this.txtStaff.Text = HttpUtility.HtmlDecode(drQuestion["Staff_Id"].ToString());
        if (drQuestion["ScoreType"].ToString() == "0")
        {
            sltScoreType.Text = "当时评分";
        }
        else
        {
            sltScoreType.Text = "统一评分";
        }
        this.sltQuestionTypeIdOne.Text = drQuestion["QuestionTypeIdOne"].ToString();
        this.sltQuestionTypeIdTwo.Text = drQuestion["QuestionTypeIdTwo"].ToString();
        this.sltQuestionTypeIdThree.Text = drQuestion["QuestionTypeIdThree"].ToString();
        this.sltQuestionTypeIdFour.Text = drQuestion["QuestionTypeIdFour"].ToString();
        this.sltQuestionTypeIdFive.Text = drQuestion["QuestionTypeIdFive"].ToString();
        this.sltQuestionTypeIdSix.Text = drQuestion["QuestionTypeIdSix"].ToString();
        this.txtPercentageOne.Text = drQuestion["OneCount"].ToString();
        this.txtPercentageTwo.Text = drQuestion["TwoCount"].ToString();
        this.txtPercentageThree.Text = drQuestion["ThreeCount"].ToString();
        this.txtPercentageFour.Text = drQuestion["FourCount"].ToString();
        this.txtPercentageFive.Text = drQuestion["FiveCount"].ToString();
        this.txtPercentageSix.Text = drQuestion["SixCount"].ToString();
        this.txtTimeStart.Text = drQuestion["StartTime"].ToString();
        this.txtTimeEnd.Text = drQuestion["EndTime"].ToString();
        this.txtQuestionCount.Text = drQuestion["Count"].ToString();
        this.txtQuestionTime.Text = drQuestion["Times"].ToString();
    }
    
    //下拉菜单数据绑定方法
    private void sltDataBind(DropDownList slt)
    {
        string sql = "select QuestionTypeName from SC_QuestionType";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        //给各DropDownList添加一个空白Item项
        slt.AppendDataBoundItems = true;
        slt.Items.Add(new ListItem("", ""));
        slt.DataSource = dt.DefaultView;
        slt.DataValueField = "QuestionTypeName";
        slt.DataTextField = "QuestionTypeName";
        slt.DataBind();
    }
    ////判断是否存在重复题目类别
    //protected void sltQuestionTypeIdTwo_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //判断题目类型一是否没写就想写题目类型二
    //    if (txtPercentageOne.Text.Trim() != "" && sltQuestionTypeIdOne.Text != "")
    //    {
    //        btnDist.Visible = true;
    //        //判断DropDownList是否不为空
    //        if (sltQuestionTypeIdTwo.Text != "")
    //        {
    //            txtPercentageTwo.ReadOnly = false;
    //            btnDist.Visible = true;
    //            //判断2个下拉框内容是否重复
    //            if (sltQuestionTypeIdTwo.Text == sltQuestionTypeIdOne.Text)
    //            {
    //                //如果重复，报错，确认按钮隐藏
    //                lblError.Visible = true;
    //                lblError.Text = "已存在此题目类别";
    //                return;
    //            }
    //            else
    //            {
    //                //确认按钮显示，报错信息隐藏
    //                lblError.Visible = false;
    //                btnDist.Visible = true;
    //            }
    //        }
    //        else
    //        {
    //            txtPercentageTwo.ReadOnly = true;
    //            txtPercentageTwo.Text = "0";
    //            lblError.Visible = true;
    //            lblError.Text = "请选择题目类别";
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        lblError.Visible = true;
    //        lblError.Text = "请先选择题目类型一";
    //        return;
    //    }
    //}
    ////同上
    //protected void sltQuestionTypeIdThree_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //判断题目类型二是否没写就想写题目类型三
    //    if (txtPercentageTwo.Text.Trim() != "" && sltQuestionTypeIdTwo.Text != "")
    //    {
    //        btnDist.Visible = true;
    //        //判断DropDownList是否不为空
    //        if (sltQuestionTypeIdThree.Text != "")
    //        {
    //            txtPercentageThree.ReadOnly = false;
    //            btnDist.Visible = true;
    //            //判断下拉框内容是否重复
    //            if (sltQuestionTypeIdThree.Text == sltQuestionTypeIdOne.Text || sltQuestionTypeIdThree.Text == sltQuestionTypeIdTwo.Text)
    //            {
    //                //如果重复，报错，确认按钮隐藏
    //                lblError.Visible = true;
    //                lblError.Text = "已存在此题目类别";
    //                return;
    //            }
    //            else
    //            {
    //                //确认按钮显示，报错信息隐藏
    //                lblError.Visible = false;
    //                btnDist.Visible = true;
    //            }
    //        }
    //        else
    //        {
    //            txtPercentageThree.ReadOnly = true;
    //            txtPercentageThree.Text = "0";
    //            lblError.Visible = true;
    //            lblError.Text = "请选择题目类别";
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        lblError.Visible = true;
    //        lblError.Text = "请先选择题目类型二";
    //        return;
    //    }
    //}
    ////同上
    //protected void sltQuestionTypeIdFour_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //判断题目类型三是否没写就想写题目类型四
    //    if (txtPercentageThree.Text.Trim() != "" && sltQuestionTypeIdThree.Text != "")
    //    {
    //        //判断DropDownList是否不为空
    //        if (sltQuestionTypeIdFour.Text != "")
    //        {
    //            txtPercentageFour.ReadOnly = false;
    //            btnDist.Visible = true;
    //            //判断下拉框内容是否重复
    //            if (sltQuestionTypeIdFour.Text == sltQuestionTypeIdOne.Text || sltQuestionTypeIdFour.Text == sltQuestionTypeIdTwo.Text || sltQuestionTypeIdFour.Text == sltQuestionTypeIdThree.Text)
    //            {
    //                //如果重复，报错，确认按钮隐藏
    //                lblError.Visible = true;
    //                lblError.Text = "已存在此题目类别";
    //                return;
    //            }
    //            else
    //            {
    //                //确认按钮显示，报错信息隐藏
    //                lblError.Visible = false;
    //                btnDist.Visible = true;
    //            }
    //        }
    //        else
    //        {
    //            lblError.Visible = true;
    //            lblError.Text = "请选择题目类别";
    //            txtPercentageFour.ReadOnly = true;
    //            txtPercentageFour.Text = "0";
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        lblError.Visible = true;
    //        lblError.Text = "请先选择题目类型三";
    //        return;
    //    }
    //}
    ////同上
    //protected void sltQuestionTypeIdFive_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //判断题目类型四是否没写就想写题目类型五
    //    if (txtPercentageFour.Text.Trim() != "" && sltQuestionTypeIdFour.Text != "")
    //    {
    //        //判断DropDownList是否不为空
    //        if (sltQuestionTypeIdFive.Text != "")
    //        {
    //            txtPercentageFive.ReadOnly = false;
    //            btnDist.Visible = true;
    //            //判断下拉框内容是否重复
    //            if (sltQuestionTypeIdFive.Text == sltQuestionTypeIdOne.Text || sltQuestionTypeIdFive.Text == sltQuestionTypeIdTwo.Text || sltQuestionTypeIdFive.Text == sltQuestionTypeIdThree.Text || sltQuestionTypeIdFive.Text == sltQuestionTypeIdFour.Text)
    //            {
    //                //如果重复，报错，确认按钮隐藏
    //                lblError.Visible = true;
    //                lblError.Text = "已存在此题目类别";
    //                return;
    //            }
    //            else
    //            {
    //                //确认按钮显示，报错信息隐藏
    //                lblError.Visible = false;
    //                btnDist.Visible = true;
    //            }
    //        }
    //        else
    //        {
    //            lblError.Visible = true;
    //            lblError.Text = "请选择题目类别";
    //            txtPercentageFive.ReadOnly = true;
    //            txtPercentageFive.Text = "0";
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        lblError.Visible = true;
    //        lblError.Text = "请先选择题目类型四";
    //        return;
    //    }
    //}
    ////同上
    //protected void sltQuestionTypeIdSix_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //判断题目类型五是否没写就想写题目类型六
    //    if (txtPercentageFive.Text.Trim() != "" && sltQuestionTypeIdFive.Text != "")
    //    {
    //        //判断DropDownList是否不为空
    //        if (sltQuestionTypeIdSix.Text != "")
    //        {
    //            txtPercentageSix.ReadOnly = false;
    //            btnDist.Visible = true;
    //            //判断下拉框内容是否重复
    //            if (sltQuestionTypeIdSix.Text == sltQuestionTypeIdOne.Text || sltQuestionTypeIdSix.Text == sltQuestionTypeIdTwo.Text || sltQuestionTypeIdSix.Text == sltQuestionTypeIdThree.Text || sltQuestionTypeIdSix.Text == sltQuestionTypeIdFour.Text || sltQuestionTypeIdSix.Text == sltQuestionTypeIdFive.Text)
    //            {
    //                //如果重复，报错，确认按钮隐藏
    //                lblError.Visible = true;
    //                lblError.Text = "已存在此题目类别";
    //                return;
    //            }
    //            else
    //            {
    //                //确认按钮显示，报错信息隐藏
    //                lblError.Visible = false;
    //                btnDist.Visible = true;
    //            }
    //        }
    //        else
    //        {
    //            lblError.Visible = true;
    //            lblError.Text = "请选择题目类别";
    //            txtPercentageSix.ReadOnly = true;
    //            txtPercentageSix.Text = "0";
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        lblError.Visible = true;
    //        lblError.Text = "请先选择题目类型五";
    //        return;
    //    }
    //}
    /// <summary>
    /// 确认按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDist_Click(object sender, EventArgs e)
    {
        //判断考试名称是否为空
        if (txtExamName.Text.Trim() == "")
        {
            lblError.Visible = true;
            lblError.Text = "考试名称不能为空";
            return;
        }
        //判断题目类别一是否为空
        if (sltQuestionTypeIdOne.Text == "")
        {
            lblError.Visible = true;
            lblError.Text = "请选择题目类别一";
            return;
        }
        //判断参与条数是否为空
        if (txtPercentageOne.Text.Trim() == "")
        {
            lblError.Visible = true;
            lblError.Text = "请填写题目类别一参与条数";
            return;
        }
        lblError.Visible = false;
        //统计分配条数是否与分配总数相等
        int conn = 0;
        if (txtPercentageTwo.Text.Trim() != "")
        {         
            conn = Convert.ToInt32(txtPercentageOne.Text) + Convert.ToInt32(txtPercentageTwo.Text);
        }
        if (txtPercentageThree.Text.Trim() != "")
        {
            conn += Convert.ToInt32(txtPercentageThree.Text);
        }
        if (txtPercentageFour.Text.Trim() != "")
        {
            conn += Convert.ToInt32(txtPercentageFour.Text);
        }
        if (txtPercentageFive.Text.Trim() != "")
        {
            conn += Convert.ToInt32(txtPercentageFive.Text);
        }
        if (txtPercentageSix.Text.Trim() != "")
        {
            conn += Convert.ToInt32(txtPercentageSix.Text);
        }
        if (conn != Convert.ToInt32(txtQuestionCount.Text))
        {
            lblError.Visible = true;
            lblError.Text = "分配总和大于分配总数";
            return;
        }
        lblError.Visible = false;
        //判空
        if (txtTimeHourStart.Text.Trim() == "" || txtTimeHourStart.Text == "")
        {
            lblError.Visible = true;
            lblError.Text = "开始时间必须填写";
            return;
        }
        lblError.Visible = false;
        if (txtTimeEnd.Text.Trim() == "" || txtTimeHourEnd.Text == "")
        {
            lblError.Visible = true;
            lblError.Text = "结束时间必须填写";
            return;
        }
        lblError.Visible = false;
        if (txtQuestionCount.Text.Trim() == "" || txtQuestionCount.Text == "0")
        {
            lblError.Visible = true;
            lblError.Text = "考题数量必须填写";
            return;
        }
        lblError.Visible = false;
        //判断类型有相同的存在
        ArrayList arr = new ArrayList();
        //将值加进数组arr
        if (sltQuestionTypeIdOne.Text != "")
        {
            arr.Add(sltQuestionTypeIdOne.Text);
        }
        if (sltQuestionTypeIdTwo.Text != "")
        {
            arr.Add(sltQuestionTypeIdTwo.Text);
        }
        if (sltQuestionTypeIdThree.Text != "")
        {
            arr.Add(sltQuestionTypeIdThree.Text);
        }
        if (sltQuestionTypeIdFour.Text != "")
        {
            arr.Add(sltQuestionTypeIdFour.Text);
        }
        if (sltQuestionTypeIdFive.Text != "")
        {
            arr.Add(sltQuestionTypeIdFive.Text);
        }
        if (sltQuestionTypeIdSix.Text != "")
        {
            arr.Add(sltQuestionTypeIdSix.Text);
        }
        //循环遍历数组，有重复的，提示
        for (int i = 0; i < arr.Count - 1; i++)
        {
            for (int j = i + 1; j < arr.Count; j++)
            {
                if (arr[i].ToString() == arr[j].ToString())
                {
                    lblError.Visible = true;
                    lblError.Text = "分配重复题型！";
                    return;
                }
            }
        }
        //如果分不填，默认为0
        if (txtMinStart.Text.Trim() == "")
        {
            txtMinStart.Text = "00";
        }
        if (txtMinEnd.Text.Trim() == "")
        {
            txtMinEnd.Text = "00";
        }
        //对时间输入验证
        if (Convert.ToInt32(txtTimeHourStart.Text) > 24 || Convert.ToInt32(txtMinStart.Text) > 60 || Convert.ToInt32(txtTimeHourEnd.Text) > 24 || Convert.ToInt32(txtMinEnd.Text) > 60)
        {
            lblError.Visible = true;
            lblError.Text = "时间格式错误";
            return;
        }
        lblError.Visible = false;
        //判断数据库内是否有足够的题目总数
        selectQuestionCount();
        lblError.Visible = false;
        //判断数据库内是否有足够的题目类型一
        selectQuestionOne();
        lblError.Visible = false;
        //判断从题目类型2开始，是否为空
        if (sltQuestionTypeIdTwo.Text != "" && txtPercentageTwo.Text != "")
        {
            //判断数据库内是否有足够的题目类型二
            selectQuestionTwo();
        }
        lblError.Visible = false;
        if (sltQuestionTypeIdThree.Text != "" && txtPercentageThree.Text != "")
        {
            //判断数据库内是否有足够的题目类型三
            selectQuestionThree();
        }
        lblError.Visible = false;
        if (sltQuestionTypeIdFour.Text != "" && txtPercentageFour.Text != "")
        {
            //判断数据库内是否有足够的题目类型四
            selectQuestionFour();
        }
        lblError.Visible = false;
        if (sltQuestionTypeIdFive.Text != "" && txtPercentageFive.Text != "")
        {
            //判断数据库内是否有足够的题目类型五
            selectQuestionFive();
        }
        lblError.Visible = false;
        if (sltQuestionTypeIdSix.Text != "" && txtPercentageSix.Text != "")
        {
            //判断数据库内是否有足够的题目类型五六
            selectQuestionSix();
        }
        lblError.Visible = false;

        //给时间赋值
        DateTime t1 = Convert.ToDateTime(txtTimeStart.Text + " " + txtTimeHourStart.Text + ":" + txtMinStart.Text);
        DateTime t2 = Convert.ToDateTime(txtTimeEnd.Text + " " + txtTimeHourEnd.Text + ":" + txtMinEnd.Text);
        if (t1 >= t2)
        {
            lblError.Visible = true;
            lblError.Text = "结束时间必须晚于开始时间";
            return;
        }
        lblError.Visible = false;

        //取得开始时间和结束时间之前的间隔
        TimeSpan ts = t2 - t1;

        //如果考试时长不登记时，自动将考试开始时间到考试结束时间的时间间隔记入txtQuestionTime
        if (txtQuestionTime.Text.Trim() == "")
        {
            txtQuestionTime.Text = Convert.ToString(ts.Hours * 60 + ts.Minutes);
        }
        //写入数据库,考试表
        CSExmExam exm = new CSExmExam(config.DBConn);
        exm.Exam_Id = Guid.NewGuid().ToString().Substring(0, 8);
        exm.ExamName = this.txtExamName.Text.ToString();
        exm.ScoreType = Convert.ToInt32(sltScoreType.SelectedValue);
        exm.BeginTime = t1;
        exm.EndTime = t2;
        exm.Times = Convert.ToInt32(txtQuestionTime.Text);
        exm.Count = Convert.ToInt32(txtQuestionCount.Text);
        string[] st = txtStaff.Text.Split(',');
        exm.ExamEmploees = st.Length;
        exm.CreatedBy = "";        // 测试修改config.Staff.Staff_Id;
        try
        {
            exm.Insert();
            //赋值，下页面调用
            Session["Guid"] = exm.Exam_Id;
            ViewState["Guid"] = exm.Exam_Id;
            Session["ScoreType"] = sltScoreType.SelectedValue;
            Session["Count"] = txtQuestionCount.Text;
            Response.Write("<script type='text/javascript'>alert('试卷定义成功');window.location='ExmExam.aspx';</script>");
            //Session["QuestionTypeIdOne"] = sltQuestionTypeIdOne.Text;
            //Session["QuestionTypeIdTwo"] = sltQuestionTypeIdTwo.Text;
            //Session["QuestionTypeIdThree"] = sltQuestionTypeIdThree.Text;
            //Session["QuestionTypeIdFour"] = sltQuestionTypeIdFour.Text;
            //Session["QuestionTypeIdFive"] = sltQuestionTypeIdFive.Text;
            //Session["QuestionTypeIdSix"] = sltQuestionTypeIdSix.Text;
            //Session["PercentageOne"] = txtPercentageOne.Text;
            //Session["PercentageTwo"] = txtPercentageTwo.Text;
            //Session["PercentageThree"] = txtPercentageThree.Text;
            //Session["PercentageFour"] = txtPercentageFour.Text;
            //Session["PercentageFive"] = txtPercentageFive.Text;
            //Session["PercentageSix"] = txtPercentageSix.Text;           
        }
        catch (Exception err)
        {
            throw err;
        }
        finally
        {
            Response.Write("<script type='text/javascript'>alert(试卷定义失败');window.location.href=window.location.href;</script>");
        }
        string str = Request.QueryString["ID"].Substring(0, 1);
        if (str == "1")
        {
            //调用建临时表
            createTmp();
            //如果是增加页面，执行Insert方法
            tmpInsert();
        }
        if (str == "2")
        {
            //如果是修改页面，执行Updata方法
            tmpUpdata();
        }
    }
     //更新临时考试表方法
    private void tmpUpdata()
    {
        string sql = "UPDATE tmp" + ViewState["ExamId"].ToString() + "set staff='" + txtStaff.Text + "',QuestionTypeIdOne='" + sltQuestionTypeIdOne.Text + "',QuestionTypeIdTwo='" + sltQuestionTypeIdTwo.Text + "',QuestionTypeIdThree='" + sltQuestionTypeIdThree.Text + "',QuestionTypeIdFour='" + sltQuestionTypeIdFour.Text + "',QuestionTypeIdFive='" + sltQuestionTypeIdFive.Text + "',QuestionTypeIdSix='" + sltQuestionTypeIdSix.Text + "',OneCount='" + txtPercentageOne.Text + "',TwoCount='" + txtPercentageTwo.Text + "',ThreeCount='" + txtPercentageThree.Text + "',FourCount='" + txtPercentageFour.Text + "',FiveCount='" + txtPercentageFive.Text + "',SixCount='" + txtPercentageSix.Text + "'";
        SqlCommand cmd = new SqlCommand(sql);
        SqlConnection con = new SqlConnection(config.DBConn);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    //创建临时考试表方法
    private void createTmp()
    {
        string sql = "create table tmp" + ViewState["Guid"].ToString() + "(Exam_Id varchar(8) PRIMARY KEY,staff varchar(36),QuestionTypeIdOne nvarchar(20),OneCount int,QuestionTypeIdTwo nvarchar(20),QuestionTypeIdThree nvarchar(20),QuestionTypeIdFour nvarchar(20),QuestionTypeIdFive nvarchar(20),QuestionTypeIdSix nvarchar(20),TwoCount int,ThreeCount int,FourCount int,FiveCount int,SixCount int,)";//测试用数据insert into " + Session["Guid"].ToString + "(Staff_Id)
        SqlCommand cmd = new SqlCommand(sql);
        SqlConnection con = new SqlConnection(config.DBConn);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    //插入数据进临时表
    private void tmpInsert()
    {
        string str = "";
        string conn = "";
        if (txtPercentageTwo.Text.Trim() != "" && sltQuestionTypeIdTwo.Text != "")
        {
            str = ",QuestionTypeIdTwo,TwoCount";
            conn = ",'" + sltQuestionTypeIdTwo.Text + "','" + txtPercentageTwo.Text + "'";
        }
        if (txtPercentageThree.Text.Trim() != "" && sltQuestionTypeIdThree.Text != "")
        {
            str += ",QuestionTypeIdThree,ThreeCount";
            conn += ",'" + sltQuestionTypeIdThree.Text + "','" + txtPercentageThree.Text + "'";
        }
        if (txtPercentageFour.Text.Trim() != "" && sltQuestionTypeIdFour.Text != "")
        {
            str += ",QuestionTypeIdFour,FourCount";
            conn += ",'" + sltQuestionTypeIdFour.Text + "','" + txtPercentageFour.Text + "'";
        }
        if (txtPercentageFive.Text.Trim() != "" && sltQuestionTypeIdFive.Text != "")
        {
            str += ",QuestionTypeIdFive,FiveCount";
            conn += ",'" + sltQuestionTypeIdFive.Text + "','" + txtPercentageFive.Text + "'";
        }
        if (txtPercentageSix.Text.Trim() != "" && sltQuestionTypeIdSix.Text != "")
        {
            str += ",QuestionTypeIdSix,SixCount";
            conn += ",'" + sltQuestionTypeIdSix.Text + "','" + txtPercentageSix.Text + "'";
        }
        string sql = "Insert Into tmp" + ViewState["Guid"].ToString() + "(Exam_Id,staff,QuestionTypeIdOne,OneCount" + str + ") values('" + ViewState["Guid"].ToString() + "','" + txtStaff.Text + "','" + sltQuestionTypeIdOne.Text + "','" + txtPercentageOne.Text + "'" + conn + ")";
        SqlCommand cmd = new SqlCommand(sql);
        SqlConnection con = new SqlConnection(config.DBConn);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    //检索数据库题目总数的方法
    private void selectQuestionCount()
    {
        string sql = "select Question_Guid from SExmQuestion";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        if (dt.Rows.Count < int.Parse(txtQuestionCount.Text))
        {
            lblError.Visible = true;
            lblError.Text = "题库内题目数量不足";
            return;
        }
    }
    //判断类型一题目数量是否足够
    private void selectQuestionOne()
    {
        string sql = "select b.QuestionTypeName from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id = b.QuestionType_Id and b.QuestionTypeName = '" + sltQuestionTypeIdOne.Text + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        if (dt.Rows.Count < int.Parse(txtPercentageOne.Text))
        {
            lblError.Visible = true;
            lblError.Text = "题库内" + sltQuestionTypeIdOne.Text + "题目数量不足";
            return;
        }
    }
    //判断类型二题目数量是否足够
    private void selectQuestionTwo()
    {
        string sql = "select b.QuestionTypeName from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id = b.QuestionType_Id and b.QuestionTypeName = '" + sltQuestionTypeIdTwo.Text + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        if (dt.Rows.Count < int.Parse(txtPercentageTwo.Text))
        {
            lblError.Visible = true;
            lblError.Text = "题库内" + sltQuestionTypeIdTwo.Text + "题目数量不足";
            return;
        }
    }
    //判断类型三题目数量是否足够
    private void selectQuestionThree()
    {
        string sql = "select b.QuestionTypeName from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id = b.QuestionType_Id and b.QuestionTypeName = '" + sltQuestionTypeIdThree.Text + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        if (dt.Rows.Count < int.Parse(txtPercentageThree.Text))
        {
            lblError.Visible = true;
            lblError.Text = "题库内" + sltQuestionTypeIdThree.Text + "题目数量不足";
            return;
        }
    }
    //判断类型四题目数量是否足够
    private void selectQuestionFour()
    {
        string sql = "select b.QuestionTypeName from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id = b.QuestionType_Id and b.QuestionTypeName = '" + sltQuestionTypeIdFour.Text + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        if (dt.Rows.Count < int.Parse(txtPercentageTwo.Text))
        {
            lblError.Visible = true;
            lblError.Text = "题库内" + sltQuestionTypeIdFour.Text + "题目数量不足";
            return;
        }
    }
    //判断类型五题目数量是否足够
    private void selectQuestionFive()
    {
        string sql = "select b.QuestionTypeName from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id = b.QuestionType_Id and b.QuestionTypeName = '" + sltQuestionTypeIdFive.Text + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        if (dt.Rows.Count < int.Parse(txtPercentageFive.Text))
        {
            lblError.Visible = true;
            lblError.Text = "题库内" + sltQuestionTypeIdFive.Text + "题目数量不足";
            return;
        }
    }
    //判断类型六题目数量是否足够
    private void selectQuestionSix()
    {
        string sql = "select b.QuestionTypeName from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id = b.QuestionType_Id and b.QuestionTypeName = '" + sltQuestionTypeIdSix.Text + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        if (dt.Rows.Count < int.Parse(txtPercentageSix.Text))
        {
            lblError.Visible = true;
            lblError.Text = "题库内" + sltQuestionTypeIdSix.Text + "题目数量不足";
            return;
        }
    }
}
