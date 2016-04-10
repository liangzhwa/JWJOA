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

public partial class DutyManager_DutyStat : System.Web.UI.Page
{
    MDataBase db = new MDataBase(ConfigurationManager.ConnectionStrings["OA"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            ControlDataBind drp = new ControlDataBind(ConfigurationManager.ConnectionStrings["OA"].ToString());
            string CreatedBy = "";
            drp.DropDownListBind(drpOrder_ID, "SOrdEstate", "Order_ID", "Order_ID", 4, "StatusId = 4", CreatedBy);　　　//完结状态的勤务

            if (Request.QueryString["Order_ID"] == null || Request.QueryString["Order_ID"].ToString() == "") //勤务编号
            {
                ViewState["State"] = "Insert";
            }
            else
            {
                ViewState["State"] = "Update";
             //   string Order_ID = Request.QueryString["Order_ID"].ToString();
                string Order_ID = "200842001";
                ViewState["Order_ID"] = Order_ID;
                drpOrder_ID.SelectedValue = Order_ID;
                drpOrder_ID.Enabled = false;
                string Strselect = "SELECT [NJGuard],[XVGuard],[WXGuard],[CZGuard],[SZGuard],[NTGuard],[LYGGuard],[HAGuard],[ZJGuard],[TZGuard],[SQGuard],[YCGuard],[YZGuard],[Remark]" +
                " FROM SOrdSummarize where Order_ID = '" + ViewState["Order_ID"].ToString() + "'";

                DataRow row = db.GetDataRow(Strselect);
                SetCheck(row[0].ToString(), Chknj1, Chknj2, Chknj3, Chknj4, Chknj5, Chknj6, Chknj7, Chknj8, Chknj9, Chknj10, Chknj11, Chknj12);
                SetCheck(row[1].ToString(), Chkxz1, Chkxz2, Chkxz3, Chkxz4, Chkxz5, Chkxz6, Chkxz7, Chkxz8, Chkxz9, Chkxz10, Chkxz11, Chkxz12);
                SetCheck(row[2].ToString(), Chkwx1, Chkwx2, Chkwx3, Chkwx4, Chkwx5, Chkwx6, Chkwx7, Chkwx8, Chkwx9, Chkwx10, Chkwx11, Chkwx12);
                SetCheck(row[3].ToString(), Chkcz1, Chkcz2, Chkcz3, Chkcz4, Chkcz5, Chkcz6, Chkcz7, Chkcz8, Chkcz9, Chkcz10, Chkcz11, Chkcz12);
                SetCheck(row[4].ToString(), Chksz1, Chksz2, Chksz3, Chksz4, Chksz5, Chksz6, Chksz7, Chksz8, Chksz9, Chksz10, Chksz11, Chksz12);
                SetCheck(row[5].ToString(), Chknt1, Chknt2, Chknt3, Chknt4, Chknt5, Chknt6, Chknt7, Chknt8, Chknt9, Chknt10, Chknt11, Chknt12);
                SetCheck(row[6].ToString(), Chklyg1, Chklyg2, Chklyg3, Chklyg4, Chklyg5, Chklyg6, Chklyg7, Chklyg8, Chklyg9, Chklyg10, Chklyg11, Chklyg12);
                SetCheck(row[7].ToString(), Chkha1, Chkha2, Chkha3, Chkha4, Chkha5, Chkha6, Chkha7, Chkha8, Chkha9, Chkha10, Chkha11, Chkha12);
                SetCheck(row[8].ToString(), Chkzj1, Chkzj2, Chkzj3, Chkzj4, Chkzj5, Chkzj6, Chkzj7, Chkzj8, Chkzj9, Chkzj10, Chkzj11, Chkzj12);
                SetCheck(row[9].ToString(), Chktz1, Chktz2, Chktz3, Chktz4, Chktz5, Chktz6, Chktz7, Chktz8, Chktz9, Chktz10, Chktz11, Chktz12);
                SetCheck(row[10].ToString(), Chksq1, Chksq2, Chksq3, Chksq4, Chksq5, Chksq6, Chksq7, Chksq8, Chksq9, Chksq10, Chksq11, Chksq12);
                SetCheck(row[11].ToString(), Chkyc1, Chkyc2, Chkyc3, Chkyc4, Chkyc5, Chkyc6, Chkyc7, Chkyc8, Chkyc9, Chkyc10, Chkyc11, Chkyc12);
                SetCheck(row[12].ToString(), Chkyz1, Chkyz2, Chkyz3, Chkyz4, Chkyz5, Chkyz6, Chkyz7, Chkyz8, Chkyz9, Chkyz10, Chkyz11, Chkyz12);

                TextBox1.Text = row[13].ToString();
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (drpOrder_ID.SelectedValue == "0")
        {
            WebWindow.alert("请选择要操作的勤务的编号");
            return;
        }
        string Order_ID = drpOrder_ID.SelectedValue.ToString();
        string NJGuard = Getstring(Chknj1, Chknj2, Chknj3, Chknj4, Chknj5, Chknj6, Chknj7, Chknj8, Chknj9, Chknj10, Chknj11, Chknj12);
        string XVGuard = Getstring(Chkxz1, Chkxz2, Chkxz3, Chkxz4, Chkxz5, Chkxz6, Chkxz7, Chkxz8, Chkxz9, Chkxz10, Chkxz11, Chkxz12);
        string WXGuard = Getstring(Chkwx1, Chkwx2, Chkwx3, Chkwx4, Chkwx5, Chkwx6, Chkwx7, Chkwx8, Chkwx9, Chkwx10, Chkwx11, Chkwx12);
        string CZGuard = Getstring(Chkcz1, Chkcz2, Chkcz3, Chkcz4, Chkcz5, Chkcz6, Chkcz7, Chkcz8, Chkcz9, Chkcz10, Chkcz11, Chkcz12);
        string SZGuard = Getstring(Chksz1, Chksz2, Chksz3, Chksz4, Chksz5, Chksz6, Chksz7, Chksz8, Chksz9, Chksz10, Chksz11, Chksz12);
        string NTGuard = Getstring(Chknt1, Chknt2, Chknt3, Chknt4, Chknt5, Chknt6, Chknt7, Chknt8, Chknt9, Chknt10, Chknt11, Chknt12);
        string LYGGuard = Getstring(Chklyg1, Chklyg2, Chklyg3, Chklyg4, Chklyg5, Chklyg6, Chklyg7, Chklyg8, Chklyg9, Chklyg10, Chklyg11, Chklyg12);
        string HAGuard = Getstring(Chkha1, Chkha2, Chkha3, Chkha4, Chkha5, Chkha6, Chkha7, Chkha8, Chkha9, Chkha10, Chkha11, Chkha12);
        string ZJGuard = Getstring(Chkzj1, Chkzj2, Chkzj3, Chkzj4, Chkzj5, Chkzj6, Chkzj7, Chkzj8, Chkzj9, Chkzj10, Chkzj11, Chkzj12);
        string TZGuard = Getstring(Chktz1, Chktz2, Chktz3, Chktz4, Chktz5, Chktz6, Chktz7, Chktz8, Chktz9, Chktz10, Chktz11, Chktz12);
        string SQGuard = Getstring(Chksq1, Chksq2, Chksq3, Chksq4, Chksq5, Chksq6, Chksq7, Chksq8, Chksq9, Chksq10, Chksq11, Chksq12);
        string YCGuard = Getstring(Chkyc1, Chkyc2, Chkyc3, Chkyc4, Chkyc5, Chkyc6, Chkyc7, Chkyc8, Chkyc9, Chkyc10, Chkyc11, Chkyc12);
        string YZGuard = Getstring(Chkyz1, Chkyz2, Chkyz3, Chkyz4, Chkyz5, Chkyz6, Chkyz7, Chkyz8, Chkyz9, Chkyz10, Chkyz11, Chkyz12);
                
        string Remark = this.TextBox1.Text.Trim();
        string CreatedBy = "";


        if (ViewState["State"].ToString() == "Insert")
        {
            string Insert = "INSERT INTO SOrdSummarize([Order_ID] ,[NJGuard] ,[XVGuard],[WXGuard],[CZGuard],[SZGuard],[NTGuard],[LYGGuard]," +
                        "[HAGuard],[ZJGuard],[TZGuard],[SQGuard],[YCGuard], [YZGuard],[Remark],[CreatedBy],[CreatedDate] " +
                        " ) VALUES ('" + Order_ID + "','" + NJGuard + "','" + XVGuard + "','" + WXGuard + "','" + CZGuard + "','" +
                        SZGuard + "','" + NTGuard + "','" + LYGGuard + "','" + HAGuard + "','" + ZJGuard + "','" + TZGuard + "','" +
                        SQGuard + "','" + YCGuard + "','" + YZGuard + "','" + Remark + "','" + CreatedBy + "',getdate())";
     
            try
            {
                db.executeInsert(Insert);
                WebWindow.alert("保存成功");
            }
            catch(Exception er)
            {
                WebWindow.alert(er.Message);
            }

        }
        else if (ViewState["State"].ToString() == "Update")
        {
            string update = "UPDATE SOrdSummarize set " +
                    " [NJGuard] = '" + NJGuard + "'," +
                    " [XVGuard] = '" + XVGuard+ "'," +
                    " [WXGuard] = '" + WXGuard+ "'," +
                    " [CZGuard] = '" + CZGuard+ "'," +
                    " [SZGuard] = '" + SZGuard+ "'," +
                    " [NTGuard] = '" + NTGuard+ "'," +
                    " [LYGGuard] = '" + LYGGuard+ "'," +
                    " [HAGuard] = '" + HAGuard+ "'," +
                    " [ZJGuard] = '" + ZJGuard+ "'," +
                    " [TZGuard] = '" + TZGuard+ "'," +
                    " [SQGuard] = '" + SQGuard+ "'," +
                    " [YCGuard] = '" + YCGuard+ "'," +
                    " [YZGuard] = '" + YZGuard+ "'," +
                    " [Remark] = '" + Remark + "'," +
                    " [ModifiedBy] = '" + CreatedBy + "'," +
                    " [ModifiedDate] = getdate() WHERE Order_ID = '" + drpOrder_ID.SelectedValue.ToString() + "'";
            
            try
            {
                db.executeUpdate(update);
                WebWindow.alert("修改成功");
            }
            catch(Exception er)
            {
                WebWindow.alert(er.Message);
            }
        }






    }

    private string Getstring(HtmlInputCheckBox check1,HtmlInputCheckBox check2,HtmlInputCheckBox check3,
        HtmlInputCheckBox check4,HtmlInputCheckBox check5,HtmlInputCheckBox check6,HtmlInputCheckBox check7,
        HtmlInputCheckBox check8,HtmlInputCheckBox check9,HtmlInputCheckBox check10,HtmlInputCheckBox check11,
        HtmlInputCheckBox check12)  //返回储存的字段
    {
        StringBuilder str = new StringBuilder();
        if (check1.Checked == true)
        {
            str.Append("1");
        }
        else
        {
            str.Append("0");
        }
        if (check2.Checked == true)
        {
            str.Append("1");
        }
        else
        {
            str.Append("0");
        }
        if (check3.Checked == true)
        {
            str.Append("1");
        }
        else
        {
            str.Append("0");
        }
        if (check4.Checked == true)
        {
            str.Append("1");
        }
        else
        {
            str.Append("0");
        }
        if (check5.Checked == true)
        {
            str.Append("1");
        }
        else
        {
            str.Append("0");
        }
        if (check6.Checked == true)
        {
            str.Append("1");
        }
        else
        {
            str.Append("0");
        }
        if (check7.Checked == true)
        {
            str.Append("1");
        }
        else
        {
            str.Append("0");
        }
        if (check8.Checked == true)
        {
            str.Append("1");
        }
        else
        {
            str.Append("0");
        }
        if (check9.Checked == true)
        {
            str.Append("1");
        }
        else
        {
            str.Append("0");
        }
        if (check10.Checked == true)
        {
            str.Append("1");
        }
        else
        {
            str.Append("0");
        }
        if (check11.Checked == true)
        {
            str.Append("1");
        }
        else
        {
            str.Append("0");
        }
        if (check12.Checked == true)
        {
            str.Append("1");
        }
        else
        {
            str.Append("0");
        }

        return str.ToString();
    }


    private void SetCheck(string value,HtmlInputCheckBox check1,HtmlInputCheckBox check2,HtmlInputCheckBox check3,
        HtmlInputCheckBox check4,HtmlInputCheckBox check5,HtmlInputCheckBox check6,HtmlInputCheckBox check7,
        HtmlInputCheckBox check8,HtmlInputCheckBox check9,HtmlInputCheckBox check10,HtmlInputCheckBox check11,
        HtmlInputCheckBox check12)
    {
        if (value.Substring(0, 1) == "1")
        {
            check1.Checked = true;
        }
        else
        {
            check1.Checked = false;
        }

        if (value.Substring(1, 1) == "1")
        {
            check2.Checked = true;
        }
        else
        {
            check2.Checked = false;
        }
        if (value.Substring(2, 1) == "1")
        {
            check3.Checked = true;
        }
        else
        {
            check3.Checked = false;
        }

        if (value.Substring(3, 1) == "1")
        {
            check4.Checked = true;
        }
        else
        {
            check4.Checked = false;
        }
        if (value.Substring(4, 1) == "1")
        {
            check5.Checked = true;
        }
        else
        {
            check5.Checked = false;
        }
        if (value.Substring(5, 1) == "1")
        {
            check6.Checked = true;
        }
        else
        {
            check6.Checked = false;
        }
        if (value.Substring(6, 1) == "1")
        {
            check7.Checked = true;
        }
        else
        {
            check7.Checked = false;
        }
        if (value.Substring(7, 1) == "1")
        {
            check8.Checked = true;
        }
        else
        {
            check8.Checked = false;
        }
        if (value.Substring(8, 1) == "1")
        {
            check9.Checked = true;
        }
        else
        {
            check9.Checked = false;
        }
        if (value.Substring(9, 1) == "1")
        {
            check10.Checked = true;
        }
        else
        {
            check10.Checked = false;
        }
        if (value.Substring(10, 1) == "1")
        {
            check11.Checked = true;
        }
        else
        {
            check11.Checked = false;
        }
        if (value.Substring(11, 1) == "1")
        {
            check12.Checked = true;
        }
        else
        {
            check12.Checked = false;
        }
 
    }

}
