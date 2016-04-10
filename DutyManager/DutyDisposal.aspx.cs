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

public partial class DutyDisposal_ : System.Web.UI.Page
{

    MDataBase db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
  
    protected void Page_Load(object sender, EventArgs e)
    {
        Config Config = (Config)Session["Config"];
        if (!this.IsPostBack)
        {

            //判断用户的角色
        //    string staff_Id = Config.Staff.Staff_Id;　//得到登录的用户名
         //   string Role = Config.LoginRole.ToString();  //得到登录角色

        //    string selectRole = db.GetDataScalar("SELECT Name FROM SSysRole WHERE (Role_Id = '" + Role + "')");     //根据传来的角色ID得到角色的名称
            string staff_Id = "00000001";
            string selectRole = "";     //！！！！！ 先写死办公室值班室

            ViewState["staff_Id"] = staff_Id;  //用户名
            ViewState["Role"] = selectRole;  //角色

            ControlDataBind drp = new ControlDataBind(ConfigurationManager.ConnectionStrings["OA"].ToString());

            if (selectRole == "值班室")
            {  
                drp.DropDownListBind(dropOrder, "SOrdEstate", "Order_ID", "Order_ID", 4, "StatusId in ('1','2','4')", staff_Id);
            }
            else   //如果不等于值班室，只能查看和自己相关的勤务
            {

                //查找该用户名做的所有勤务
                //在流程表中查找下部执行人有该登录名的
                DataTable OrderTable = new DataTable();
                string staffOne = "select distinct Order_ID from SordFlow where PExecute = '" + staff_Id + "'" +
                                   " UNION " +
                                   "select distinct Order_ID from SOrdFlow  left join SOrdArrangeMan on SOrdFlow.NExecute = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'" +
                                     " UNION " +
                                    " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.ZCompere = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'" +
                                     " UNION " +
                                    " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.FCompere = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'" +
                                     " UNION " +
                                    " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.SWPrincipal = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'" +
                                     " UNION " +
                                    " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.SWMan = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'" +
                                     " UNION " +
                                    " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.XCPrincipal = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'" +
                                     " UNION " +
                                    " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.ZDPrincipal = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'" +
                                     " UNION " +
                                    " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.XCMan = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'" +
                                     " UNION " +
                                    " select distinct Order_ID from SOrdZArrange left join SOrdArrangeMan on SOrdZArrange.ZDMan = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'" +
                                     " UNION " +
                                    " select distinct Order_ID from SOrdCArrange left join SOrdArrangeMan on SOrdCArrange.ZCompere = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'" +
                                     " UNION " +
                                    " select distinct Order_ID from SOrdCArrange left join SOrdArrangeMan on SOrdCArrange.Principal = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'" +
                                     " UNION " +
                                    " select distinct Order_ID from SOrdCArrange left join SOrdArrangeMan on SOrdCArrange.FCompere = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'" +
                                     " UNION " +
                                    " select distinct Order_ID from SOrdCArrange left join SOrdArrangeMan on SOrdCArrange.XGMan = SOrdArrangeMan.Guid where Man = '" + staff_Id + "'";
               
                                    
                OrderTable = db.GetDataTable(staffOne);
                DataRow dr = OrderTable.NewRow();
                dr["Order_ID"] = "0";
                OrderTable.Rows.InsertAt(dr, 0); 

                dropOrder.DataSource = OrderTable;
                dropOrder.DataValueField = "Order_ID";
                dropOrder.DataTextField = "Order_ID";
                dropOrder.DataBind();
            }
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        int i = e.RowIndex;
        GVOrder.Rows[i].Cells[0].Text = "√";             //将选定行标记成√
        string Order_ID = GVOrder.Rows[i].Cells[1].Text.Trim();  //勤务编号

        string Role = "";
        if (ViewState["Role"] != null && ViewState["Role"].ToString() != "")
        {
            Role = ViewState["Role"].ToString();
        }
       
        if(Role == "值班室")    //如果角色为值班室，转到一个页面
        {
            Response.Redirect("DutyTransmit.aspx?Order_ID=" + Order_ID);
        }
        else
        { 
             Response.Redirect("DutyRegister.aspx?Order_ID=" + Order_ID);
        }
    }
    protected void txtCX_Click(object sender, EventArgs e)
    {
        StringBuilder strSql = new StringBuilder("select Order_ID,Order_Name,CreatedDate,StatusId from SOrdEstate where 1=1");

        if (dropOrder.SelectedValue != "0")
        {
            strSql.Append(" and Order_ID = '" + dropOrder.SelectedValue + "'");
        }
        else
        {
            for (int i = 0; i < dropOrder.Items.Count; i++)
            {
                if (dropOrder.Items.Count == 1)
                {
                    strSql.Append(" and 1 = 2");
                }
                else
                {
                    if (dropOrder.Items[i].Text == "0")
                    {
                        continue;
                    }
                    if (i == 1)
                    {
                        strSql.Append(" and Order_ID = '" + dropOrder.Items[i].Text.Trim() + "'");
                    }
                    else
                    {
                         strSql.Append(" or Order_ID = '" + dropOrder.Items[i].Text.Trim() + "'");
                    }

                  
                }
            }
        }
        if (txtOrderName.Text != "")
        {
            strSql.Append(" and Order_Name like '%" + txtOrderName.Text.Trim() + "%'");
        }
        if (txtTelRTime.Text != "" && TextBox1.Text != "")
        {
            if (txtTelFTime.Text == "")
            {
                txtTelFTime.Text = "00";
            }
            if (TextBox2.Text == "")
            {
                TextBox2.Text = "00";
            }
            string timefrom = txtTelRTime.Text + " " + drpTelSTime.SelectedValue + ":" + txtTelFTime.Text + ":00";
            string timeto = TextBox1.Text + " " + DropDownList1.SelectedValue + ":" + TextBox2.Text + ":00";

             strSql.Append(" and (CreatedDate >= '" + timefrom + "' and CreatedDate <= '" + timeto + "')");
        }
        if (dropZT.SelectedItem.Text != "请选择")
        {
            strSql.Append(" and StatusId = '" + dropZT.SelectedItem.Value + "'");
        }
       

        this.GVOrder.DataSource = db.GetDataTable(strSql.ToString());
        this.GVOrder.DataBind(); 
        
    }
}
