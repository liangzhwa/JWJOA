using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "", strHTML = "";

        ////从数据库中读取一级菜单和二级菜单

        //StringBuilder sbMenu = new StringBuilder();
        //DataSet dsMenu = new DataSet();
        //DataTable dtMenu = new DataTable();
        //dtMenu = dsMenu.Tables[0];


        if (Request.QueryString["MenuId"] != null && Request.QueryString["MenuId"].ToString().Trim() != "")
        {
            string MenuId = Request.QueryString["MenuId"].ToString().Trim();
            
            ////根据取得的一级菜单，得到它的二级菜单。

            //StringBuilder sbMenu2 = new StringBuilder();
            //DataSet dsMenu2 = new DataSet();
            //DataTable dtMenu2 = new DataTable();
            //dtMenu2 = dsMenu2.Tables[0];

            //sbMenu2.Append("");
            //for (int i = 0; i < dtMenu2.Rows.Count; i++)
            //{
            //    sbMenu2.Append(" <table border='0' cellpadding='0' cellspacing='0' style='height:100%'><tr><td align='center' class='tdMenu2' ><a href='DepartmentManager.aspx' target='Main' class='link'><img id='Img1'  src='images/部门管理.jpg' border='0'/></a></td><td align='center' class='tdMenu2' ><a href='RoleManager.aspx' target='Main' class='link'><img id='Img2'  src='images/角色管理.jpg'  border='0'/></a></td><td align='center' class='tdMenu2' ><a href='PasswordChanged.aspx' target='Main' class='link'><img id='Img3'  src='images/密码修改.jpg'  border='0'/></a></td><td align='center' class='tdMenu2' > <a href='WorkStat.aspx' target='Main' class='link'><img id='Img4'  src='images/工作统计.jpg'  border='0'/></a></td></tr></table>");
            //}
            //sbMenu2.Append("");

            #region 无用
            switch (MenuId)
            {
                case "1":
                    strHTML = " <table border='0' cellpadding='0' cellspacing='0' style='height:100%'><tr><td align='center' class='tdMenu2' ><a href='DepartmentManager.aspx' target='Main' class='link'><img id='Img1'  src='images/部门管理.jpg' border='0'/></a></td><td align='center' class='tdMenu2' ><a href='RoleManager.aspx' target='Main' class='link'><img id='Img2'  src='images/角色管理.jpg'  border='0'/></a></td><td align='center' class='tdMenu2' ><a href='PasswordChanged.aspx' target='Main' class='link'><img id='Img3'  src='images/密码修改.jpg'  border='0'/></a></td><td align='center' class='tdMenu2' > <a href='WorkStat.aspx' target='Main' class='link'><img id='Img4'  src='images/工作统计.jpg'  border='0'/></a></td></tr></table>";
                    break;
                case "2":
                    strHTML = " <table border='0' cellpadding='0' cellspacing='0' style='height:100%'><tr><td align='center' class='tdMenu2' ><a href='DutyRegister.aspx' target='Main' class='link'><img id='Img1'  src='images/勤务登记.jpg'  border='0'/></a></td><td align='center' class='tdMenu2' ><a href='DutyTransmit.aspx' target='Main' class='link'><img id='Img2'  src='images/勤务转发.jpg'  border='0'/></a></td><td align='center' class='tdMenu2' ><a href='DutyDisposal.aspx'target='Main' class='link'><img id='Img3'  src='images/勤务处理.jpg'  border='0'/></a></td><td align='center' class='tdMenu2' ><a href='DutyPigeonhole.aspx' target='Main' class='link'><img id='Img4' src='images/勤务归档.jpg'  border='0'/></a></td></tr></table>";
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    //strHTML = " <table border='0' cellpadding='0' cellspacing='0' style='height:100%'><tr><td align='center' class='tdMenu2' ><a href='#'  class='link'><img id='Img1'  src='images/物资相关数据维护.jpg'  border='0'/></a></td><td align='center' class='tdMenu2' ><a href='#'  class='link'><img id='Img2'  src='images/物资入库.jpg'  border='0'/></a></td><td align='center' class='tdMenu2' ><a href='#' class='link'><img id='Img3'  src='images/物资申领.jpg'  border='0'/></a></td><td align='center' class='tdMenu2' ><a href='#'  class='link'><img id='Img4' src='images/查询统计.jpg'  border='0'/></a></td></tr></table>";
                    break;
                case "6":
                    break;
                case "7":
                    break;
                case "8":
                    break;
            }
            #endregion
            Label1.Text = strHTML;
        }
    }
}
