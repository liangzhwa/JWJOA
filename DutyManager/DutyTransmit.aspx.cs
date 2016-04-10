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

public partial class DutyTransmit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MDataBase db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
        if (!this.IsPostBack)
        {
            string Order_ID = "";
            if (Request.QueryString["Order_ID"] == null || Request.QueryString["Order_ID"].ToString() == "") 
            {
                Response.Redirect("error2.htm");
            }
            else
            {
                Order_ID = Request.QueryString["Order_ID"].ToString();  //得到勤务编号
            }

            string selectOrderFlowCount = db.GetDataScalar
                ("select Count(*) from SOrdFlow where Order_Id = '" + Order_ID + "'and OperateStep = '1'");

            string selectOrderFlowCountOne = db.GetDataScalar
                ("select Count(*) from SOrdFlow where Order_Id = '" + Order_ID + "'");
            
            //如果只有一条记录，并且状态等于一说明是在电话登记的阶段，
            //可以对登记的内容进行修改,否则该按扭不可见
            if (selectOrderFlowCount == "1" && selectOrderFlowCountOne == "1")  
            {
                Button1.Visible = true;
            }
            else
            {
                Button1.Visible = false;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ToPage("1");
    }

    private void ToPage(string sign)
    {
        string Order_ID = "";
        if (Request.QueryString["Order_ID"] == null || Request.QueryString["Order_ID"].ToString() == "")
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            Order_ID = Request.QueryString["Order_ID"].ToString();  //得到勤务编号
        }

        Response.Redirect("DutyRegister.aspx?Order_ID=" + Order_ID +"&sign=" + sign);

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ToPage("2");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        ToPage("3");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        ToPage("4");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        ToPage("5");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        ToPage("6");
    }
}
