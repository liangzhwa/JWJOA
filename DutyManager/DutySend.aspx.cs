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
using System.Text;

public partial class DutyPigeonhole : System.Web.UI.Page
{
    MDataBase db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string PFunction = "";

            if (Request.QueryString["PFunction"] == null || Request.QueryString["PFunction"].ToString() == "") //编码
            {
                Response.Redirect("error2.htm");
            }
            else
            {
                PFunction = Request.QueryString["PFunction"].ToString();
            }

            ControlDataBind drp = new ControlDataBind(ConfigurationManager.ConnectionStrings["OA"].ToString());
            string Sql = "";

            if (PFunction == "1")  //如果上步骤是电话登记，下步骤肯定是办公室审批
            {
                Sql = "select * from SOrdConfig where FunctionID = 2";

            }
            else if (PFunction == "2")  //如果上步骤是办公室审批，下步骤肯定是领导批示
            {
                Sql = "select * from SOrdConfig where FunctionID = 3";
            }
            else if (PFunction == "3")  //如果上步骤是领导批示，下步骤可能是领导批示可能是勤务安排还有可能是勤务分配
            {
                Sql = "select * from SOrdConfig where FunctionID = 3 or FunctionID = 4 or FunctionID = 5";
            }
            else if (PFunction == "4")  //如果上步骤是勤务安排，下步骤肯定是领导批示
            {
                Sql = "select * from SOrdConfig where FunctionID = 3";
            }

            DropDownList1.DataSource = db.GetDataTable(Sql);
            DropDownList1.DataTextField = "FunctionName";
            DropDownList1.DataValueField = "FunctionID";
            DropDownList1.DataBind();
         
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        txt1.Value = hfStaffId.Value.TrimEnd(',');

        string Order_ID = "";
      
        string Number = "";

        if (Request.QueryString["Order_ID"] == null || Request.QueryString["Order_ID"].ToString() == "") //编码
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            Order_ID = Request.QueryString["Order_ID"].ToString();
        }

        if (Request.QueryString["Number"] == null || Request.QueryString["Number"].ToString() == "") //编码
        {
            Response.Redirect("error2.htm");
        }
        else
        {
            Number = Request.QueryString["Number"].ToString();
        }

        string NFunction = DropDownList1.SelectedItem.Value.Trim();         //下步骤功能

        string NExecute = txt1.Value.Trim();        //下步骤执行人

        if (NFunction == "")
        {
            WebWindow.alert("请选择下步骤功能");
            return;
        }
        if (NExecute == "")
        {
            WebWindow.alert("请选择下步骤执行人");
            return;
        }

        string[] splitNExecute = NExecute.Split(',');

        string[] Update = new string[splitNExecute.Length + 1];  //定义保存数据库的数组

        string ZCompereGUID = Guid.NewGuid().ToString();

        Update[0] = "update SOrdFlow set NFunction ='" + NFunction + "' , NExecute  ='" + ZCompereGUID + "' , OperateStep = '2'" +
           " where Order_ID = '" + Order_ID + "' and Number = '" + Number + "' and (NFunction is null or NFunction = '')";

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
