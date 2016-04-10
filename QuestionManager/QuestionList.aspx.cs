/*----------------------------------------------------------------
// Copyright (C) 2008 南京环智科技有限公司
// 版权所有。 
//
// 文件名： QuestionList.aspx.cs
// 文件功能描述：警卫局网上考试题库查询
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


public partial class ExamManager_QuestionList : System.Web.UI.Page
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
            ViewState["Question_Guid"] = hfdGv.Value;
            this.QuestionTypeDataBind();
            BindDataGv();
            btnDelete.Attributes.Add("onclick", "return confirm('确认删除？');");
            if (gvQuestion.PageCount == 1)
            {
                btnFirstPage.Visible = false;
                btnForwardPage.Visible = false;
                btnNextPage.Visible = false;
                btnLastPage.Visible = false;
            }
            else if (gvQuestion.PageCount > 1)
            {
                btnFirstPage.Visible = true;
                btnForwardPage.Visible = true;
                btnNextPage.Visible = true;
                btnLastPage.Visible = true;
            }
        }

        //config = (Config)Session["Config"];
    }
    /// <summary>
    /// 试题增加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Server.Transfer(@"../ExamManager/QuestionAdd.aspx");
    }

    /// <summary>
    /// 绑定sql查询到的数据到数据表
    /// </summary>
    /// <param name="sql"></param>
    //双空查询,显示全部信息
    private void BindDataGv()
    {
        string sql = "select a.Question_Guid,a.Question,substring(Question,1,15),a.QuestionType_Id,b.QuestionTypeName,a.CreatedBy from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id=b.QuestionType_Id";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);  
        db.GetDataTable(sql, out dt);
        ViewState["dataSource"] = dt;
        if (dt.Rows.Count == 0)
        {
            btnFirstPage.Visible = false;
            btnForwardPage.Visible = false;
            btnNextPage.Visible = false;
            btnLastPage.Visible = false;
            this.lblCount.Visible = false;
            lblPage.ForeColor = Color.Red;
            lblPage.Text = "对不起，没有查询到相关信息！";
            gvQuestion.Visible = false;
            btnChange.Visible = false;
            btnDelete.Visible = false;
            this.lblCurrentPage.Visible = false;
        }
        else
        {
            this.lblCount.Visible = true;
            this.lblCurrentPage.Visible = true;
            btnFirstPage.Visible = true;
            btnForwardPage.Visible = true;
            btnNextPage.Visible = true;
            btnLastPage.Visible = true;
            gvQuestion.Visible = true;
            btnChange.Visible = true;
            btnDelete.Visible = true;
            gvQuestion.PageSize = 50;
            gvQuestion.DataSource = dt;
            gvQuestion.DataBind();
            //如果GV就一页，翻页按钮不显示
            if (gvQuestion.PageCount == 1)
            {
                btnFirstPage.Visible = false;
                btnForwardPage.Visible = false;
                btnNextPage.Visible = false;
                btnLastPage.Visible = false;
            }
            //显示搜索到的全部条数
            this.lblCount.Text = "共有" + (dt.Rows.Count).ToString()+ "条记录";
            //显示GridView的页数
            lblPage.ForeColor = Color.Black;
            lblPage.Text = "/共"+(gvQuestion.PageCount).ToString()+"页";
            //显示GV是第几页
            lblCurrentPage.Text = "第"+(gvQuestion.PageIndex + 1).ToString()+"页";
        }
    }
    //字段“题目”查询
    private void Question()
    {
        string sql = "select a.Question_Guid,a.Question,substring(Question,1,15),a.QuestionType_Id,b.QuestionTypeName,a.CreatedBy from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id=b.QuestionType_Id and a.Question like '%" + txtQuestion.Text + "%'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        ViewState["dataSource"] = dt;
        if (dt.Rows.Count == 0)
        {
            btnFirstPage.Visible = false;
            btnForwardPage.Visible = false;
            btnNextPage.Visible = false;
            btnLastPage.Visible = false;
            this.lblCount.Visible = false;
            lblPage.ForeColor = Color.Red;
            lblPage.Text = "对不起，没有查询到相关信息！";
            gvQuestion.Visible = false;
            btnChange.Visible = false;
            btnDelete.Visible = false;
            this.lblCurrentPage.Visible = false;
        }
        else
        {
            this.lblCount.Visible = true;
            this.lblCurrentPage.Visible = true;
            btnFirstPage.Visible = true;
            btnForwardPage.Visible = true;
            btnNextPage.Visible = true;
            btnLastPage.Visible = true;
            gvQuestion.Visible = true;
            btnChange.Visible = true;
            btnDelete.Visible = true;
            gvQuestion.PageSize = 50;
            gvQuestion.DataSource = dt;
            gvQuestion.DataBind();
            if (gvQuestion.PageCount == 1)
            {
                btnFirstPage.Visible = false;
                btnForwardPage.Visible = false;
                btnNextPage.Visible = false;
                btnLastPage.Visible = false;
            }
            //显示搜索到的全部条数
            this.lblCount.Text = "共有" + (dt.Rows.Count).ToString() + "条记录";
            //显示GridView的页数
            lblPage.ForeColor = Color.Black;
            lblPage.Text = "/共" + (gvQuestion.PageCount).ToString() + "页";
            //显示GV是第几页
            lblCurrentPage.Text = "第" + (gvQuestion.PageIndex + 1).ToString() + "页";
        }
    }
    //字段“题目类型”查询
    private void QuestionId()
    {
        string sql = "select a.Question_Guid,a.Question,substring(Question,1,15),a.QuestionType_Id,b.QuestionTypeName,a.CreatedBy from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id=b.QuestionType_Id and b.QuestionTypeName = '" + sltQuestionTypeName.Text + "'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        ViewState["dataSource"] = dt;
        if (dt.Rows.Count == 0)
        {
            btnFirstPage.Visible = false;
            btnForwardPage.Visible = false;
            btnNextPage.Visible = false;
            btnLastPage.Visible = false;
            this.lblCount.Visible = false;
            lblPage.ForeColor = Color.Red;
            lblPage.Text = "对不起，没有查询到相关信息！";
            gvQuestion.Visible = false;
            btnChange.Visible = false;
            btnDelete.Visible = false;
            this.lblCurrentPage.Visible = false;
        }
        else
        {
            this.lblCount.Visible = true;
            this.lblCurrentPage.Visible = true;
            btnFirstPage.Visible = true;
            btnForwardPage.Visible = true;
            btnNextPage.Visible = true;
            btnLastPage.Visible = true;
            gvQuestion.Visible = true;
            btnChange.Visible = true;
            btnDelete.Visible = true;
            gvQuestion.PageSize = 50;
            gvQuestion.DataSource = dt;
            gvQuestion.DataBind();
            if (gvQuestion.PageCount == 1)
            {
                btnFirstPage.Visible = false;
                btnForwardPage.Visible = false;
                btnNextPage.Visible = false;
                btnLastPage.Visible = false;
            }
            //显示搜索到的全部条数
            this.lblCount.Text = "共有" + (dt.Rows.Count).ToString() + "条记录";
            //显示GridView的页数
            lblPage.ForeColor = Color.Black;
            lblPage.Text = "/共" + (gvQuestion.PageCount).ToString() + "页";
            //显示GV是第几页
            lblCurrentPage.Text = "第" + (gvQuestion.PageIndex + 1).ToString() + "页";
        }
    }
    //双字段模糊查询
    private void All()
    {
        string sql = "select a.Question_Guid,a.Question,substring(Question,1,15),a.QuestionType_Id,a.CreatedBy from SExmQuestion a,SC_QuestionType b where a.QuestionType_Id=b.QuestionType_Id and b.QuestionTypeName = '" + sltQuestionTypeName.Text + "' and a.Question like '%" + txtQuestion.Text + "%'";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        ViewState["dataSource"] = dt;
        if (dt.Rows.Count == 0)
        {
            btnFirstPage.Visible = false;
            btnForwardPage.Visible = false;
            btnNextPage.Visible = false;
            btnLastPage.Visible = false;
            this.lblCount.Visible = false;
            lblPage.ForeColor = Color.Red;
            lblPage.Text = "对不起，没有查询到相关信息！";
            gvQuestion.Visible = false;
            btnChange.Visible = false;
            btnDelete.Visible = false;
            this.lblCurrentPage.Visible = false;
        }
        else
        {
            this.lblCount.Visible = true;
            this.lblCurrentPage.Visible = true;
            btnFirstPage.Visible = true;
            btnForwardPage.Visible = true;
            btnNextPage.Visible = true;
            btnLastPage.Visible = true;
            gvQuestion.Visible = true;
            btnChange.Visible = true;
            btnDelete.Visible = true;
            gvQuestion.PageSize = 50;
            gvQuestion.DataSource = dt;
            gvQuestion.DataBind();
            if (gvQuestion.PageCount == 1)
            {
                btnFirstPage.Visible = false;
                btnForwardPage.Visible = false;
                btnNextPage.Visible = false;
                btnLastPage.Visible = false;
            }
            //显示搜索到的全部条数
            this.lblCount.Text = "共有" + (dt.Rows.Count).ToString() + "条记录";
            //显示GridView的页数
            lblPage.ForeColor = Color.Black;
            lblPage.Text = "/共" + (gvQuestion.PageCount).ToString() + "页";
            //显示GV是第几页
            lblCurrentPage.Text = "第" + (gvQuestion.PageIndex + 1).ToString() + "页";
        }
    }
    //下拉菜单数据绑定
    private void QuestionTypeDataBind()
    {
        string sql = "select QuestionTypeName from SC_QuestionType";
        DataTable dt = new DataTable();
        db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dt);
        //添加一个Item项
        sltQuestionTypeName.Items.Add(new ListItem("全部","全部"));
        //
        sltQuestionTypeName.DataSource = dt.DefaultView;
        sltQuestionTypeName.DataValueField = "QuestionTypeName";
        sltQuestionTypeName.DataTextField = "QuestionTypeName";
        sltQuestionTypeName.DataBind();
    }

    /// <summary>
    /// 查询事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //如果2个查询项都为空，则显示所有数据
        if (sltQuestionTypeName.Text == "全部" && txtQuestion.Text.Trim() == "")
        {
            BindDataGv();
        }
        if (sltQuestionTypeName.Text == "全部" && txtQuestion.Text.Trim() != "")
        {
            Question();
        }
        if (sltQuestionTypeName.Text != "全部" && txtQuestion.Text.Trim() == "")
        {
            QuestionId();
        }
        if (sltQuestionTypeName.Text != "全部" && txtQuestion.Text.Trim() != "")
        {
            All();
        }
    }
    //跳转修改页面
    protected void btnChange_Click(object sender, EventArgs e)
    {
        ArrayList list = GetSelectedKeyValues();
        //判断是否单选
        if (list.Count == 1)
        {
            Response.Redirect("QuestionChange.aspx?QuestionGuid=" + list[0].ToString(), false);
        }
        else if (list.Count == 0)
        {
            Response.Write("<script type='text/javascript'>alert('请选择一条数据！');window.location.href=window.location.href;</script>");
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('1次只能修改一条数据！');window.location.href=window.location.href;</script>");
        }
        
    }

    /// <summary>
    /// 删除代码逻辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        
        ArrayList list = GetSelectedKeyValues();
        //循环删除数据
        if (list != null)
        {
            string sql = "DELETE FROM SExmQuestion WHERE Question_Guid in (";
            string strIndex = "";
            for (int i = 0; i < list.Count; i++)
            {
                strIndex += "'" + list[i].ToString() + "',";
            }
            sql = sql + strIndex.TrimEnd(',') + ")";
            //数据操作
            try
            {
                db = new MDataBase(config.DBConn);
                db.executeDelete(sql);
                Response.Write("<script type='text/javascript'>alert('删除成功！');window.location.href=window.location.href;</script>");
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                Response.Write("<script type='text/javascript'>alert('删除失败！');window.location.href=window.location.href;</script>");
            }
        }
    }

    //取得GV所有的checkbox选中状态的值
    public ArrayList GetSelectedKeyValues()
    {
        ArrayList selectedRows = new ArrayList();

        for (int i = 0; i < gvQuestion.Rows.Count; i++)
        {
            if (gvQuestion.Rows[i].RowType != DataControlRowType.Header)
            {
                //取得checkbox的状态
                bool isChecked = ((CheckBox)gvQuestion.Rows[i].Cells[0].Controls[1]).Checked;
                //如果checkbox选中
                if (isChecked)
                {
                    //把checkbox的tooltip值赋给selectedRows
                    selectedRows.Add(((CheckBox)gvQuestion.Rows[i].Cells[0].Controls[1]).ToolTip);
                }
            }
        }
        return selectedRows;
    }

    /// <summary>
    /// GV翻页代码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void PagerButton_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["dataSource"];

        //取得当前页的索引
        int pageIndx = Convert.ToInt32(CurrentPage.Value);

        //取得数据总条数
        int totals = dt.Rows.Count;

        //取得每页的大小
        int pageSize = gvQuestion.PageSize;

        //取得总页数
        int pages = gvQuestion.PageCount;

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
        gvQuestion.PageIndex = pageIndx;

        lblCurrentPage.Text = (pageIndx + 1).ToString();
        gvQuestion.DataSource = (DataTable)ViewState["dataSource"];
        gvQuestion.DataBind();
    }
}
