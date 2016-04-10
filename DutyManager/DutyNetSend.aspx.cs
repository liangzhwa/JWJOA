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

public partial class DutyManager_DutyNetSend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
          
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        MDataBase db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
        txt1.Value = hfStaffId.Value.TrimEnd(',');

        string state = "";
        string Order_ID = "";
        string Net_Guid = "";
        if (Request.QueryString["state"] == null || Request.QueryString["state"].ToString() == "") //得到状态
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            state = Request.QueryString["state"].ToString();
        }
        if (Request.QueryString["Order_ID"] == null || Request.QueryString["Order_ID"].ToString() == "") //得到勤务编号
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            Order_ID = Request.QueryString["Order_ID"].ToString();
        }
        if (Request.QueryString["Net_Guid"] == null || Request.QueryString["Net_Guid"].ToString() == "") //得到单子编号
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            Net_Guid = Request.QueryString["Net_Guid"].ToString();
        }

    

        string NExecute = txt1.Value.Trim();        //下步骤执行人

       
        if (NExecute == "")
        {
            WebWindow.alert("请选择下步骤执行人");
            return;
        }


        string[] splitNExecute = NExecute.Split(',');

        string[] Update = new string[splitNExecute.Length + 1];  //定义保存数据库的数组

        string ZCompereGUID = Guid.NewGuid().ToString();


        state = Request.QueryString["state"].ToString();  //得到状态
        if (state == "2")  //在办公室审批状态的，改为领导状态
        {
            Update[0] = "update SOrdNet set StatusId = '3',nextPer = '" + ZCompereGUID +
                "' where Order_ID = '" + Order_ID + "'";            //状态改成2
           
        }
        else if (state == "3")
        {
            Update[0] = "update SOrdNetAuditing set StatusId = '2', nextPer = '" + ZCompereGUID +
                "'where Net_Guid = '" + Net_Guid + "' and StatusId = '1'";
         
        }
      
        for (int i = 0; i < splitNExecute.Length; i++)
        {
            Update[i + 1] = "insert into SOrdArrangeMan (Arrange_Guid,Guid,Man) values('" + Guid.NewGuid().ToString() + "','" + ZCompereGUID + "','" + splitNExecute[i] + "')";
        }


        if (db.runTransaction(Update) == true)
        {
            WebWindow.alert("下送成功");
            btnOK.Visible = false;
        }

    }
}
