using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Index : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Config Config = (Config)Session["Config"];
            if (Config == null || Config.Staff == null)
            {
                WebWindow.RefreshParent("error2.htm");
                return;
            }

            //保存用户名和工程名
            Session["StaffId"] = Config.Staff.Staff_Id;
            Session["ProjectId"] = Config.ProjectId;
            Session["Name"] = Config.Staff.Name;

            this.lblLoginStaff.Text = "管理员:" + Config.Staff.Name + " 在线 " + DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss");


            #region 生成控件
            try
            {
                MDataBase db = new MDataBase(Config.DBConn);
                string strHTML = "", sql = "",url="";

                //取得页面的一级菜单
                sql = "SELECT  C.Menu_Id,C.Caption, D.Content, C.Parent_Id, C.Function1_Id,D.Kind_Id,D.Params FROM dbo.V_SSysRoleMenu B INNER JOIN dbo.SSysStaffProjectRole A ON B.Role_Id = A.Role_Id INNER JOIN dbo.SSysMenu C ON B.Menu_Id = C.Menu_Id LEFT OUTER JOIN dbo.SSysFunction D ON C.Function1_Id = D.Function_Id where A.Staff_Id='" + Config.Staff.Staff_Id + "' and A.Role_Id='" + Config.LoginRole + "'  and C.Parent_Id='0' order by C.Orderindex";

                DataTable dt = db.GetDataTable(sql);
                int i = 1;

                ///////
                //strHTML = "<table cellspacing='0' cellpadding='0' ><tr>";
                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    //取得跳转页面的地址
                    if (dt.Rows[a]["Kind_Id"].ToString().Trim() == "1")//网页类型
                    {
                        url = dt.Rows[a]["Content"] == null ? "#" : dt.Rows[a]["Content"].ToString();
                    }
                    else if (dt.Rows[a]["Kind_Id"].ToString().Trim() == "3")//动态页面类型
                    {
                        url = dt.Rows[a]["Content"].ToString();
                    }

                    //拼接显示一级菜单的字符串 <td valign='top'>
                    strHTML += "<table cellspacing='0' cellpadding='0' width='80' align='center' class ='p12' ID='Table2'><tr>";
                    if (dt.Rows[a]["Function1_Id"].ToString() != "-1")//直接的链接
                    {
                        //如果没有子菜单，则直接跳转
                        strHTML += "<td class=\"menu_title\" id=\"menuTitle1\" onmouseover=\"this.className='menu_title2';\" onclick=\"top.Main.location='" + url + "'\" onmouseout=\"this.className='menu_title';\" style=\"cursor:hand\" background=\"images/admin_left_2.gif\" height=\"25\">";
                    }
                    else if (dt.Rows[a]["Function1_Id"].ToString() == "-1")   //有子菜单
                    {
                        //如果有子菜单，则点击显示子菜单
                        strHTML += "<td class=\"menu_title\" id=\"menuTitle1\" onmouseover=\"this.className='menu_title2';\" onclick=\"showsubmenu(" + i.ToString() + ")\" onmouseout=\"this.className='menu_title';\" style=\"cursor:hand\" background=\"images/admin_left_8.gif\" height=\"25\">";
                    }
                    strHTML += "<span>&nbsp;&nbsp;" + ((dt.Rows[a]["Caption"] == null || dt.Rows[a]["Caption"].ToString() == "") ? "#" : dt.Rows[a]["Caption"].ToString()) + "</span> </td></tr><tr><td id=\"submenu" + i.ToString() + "\" style=\"DISPLAY: none\">";

                    //取得相应菜单下的子菜单
                    sql = "SELECT  C.Menu_Id,C.Caption, D.Content, C.Parent_Id, C.Function1_Id,D.Kind_Id,D.Params FROM dbo.V_SSysRoleMenu B INNER JOIN dbo.SSysStaffProjectRole A ON B.Role_Id = A.Role_Id INNER JOIN dbo.SSysMenu C ON B.Menu_Id = C.Menu_Id LEFT OUTER JOIN dbo.SSysFunction D ON C.Function1_Id = D.Function_Id where A.Staff_Id='" + Config.Staff.Staff_Id + "'and A.Role_Id='" + Config.LoginRole + "' and C.Parent_Id='" + dt.Rows[a]["Menu_Id"].ToString() + "' order by C.OrderIndex";
                    DataTable dt2 = db.GetDataTable(sql);
                    if (dt2.Rows.Count > 0)
                    {
                        //拼接显示子菜单的字符串
                        strHTML += "<div class=\"sec_menu\" style=\"WIDTH: 80px\"><table cellspacing=\"0\" cellpadding=\"0\" width=\"80\" align=\"center\" class =\"p12\" ID=\"Table3\">";
                        for (int b = 0; b < dt2.Rows.Count; b++)
                        {
                            if (dt2.Rows[b]["Kind_Id"].ToString().Trim() == "1")
                            {
                                url = (dt2.Rows[b]["Content"] == null || dt2.Rows[b]["Content"].ToString() == "") ? "#" : dt2.Rows[b]["Content"].ToString();
                            }
                            else if (dt2.Rows[b]["Kind_Id"].ToString().Trim() == "3")
                            {
                                url = dt2.Rows[b]["Content"].ToString();
                            }
                            strHTML += "<tr><td height=\"22\">&nbsp;&nbsp;&nbsp;&nbsp;<a target=\"Main\" href=\"" + url + "\"><font color=\"000000\">" + ((dt2.Rows[b]["Caption"] == null || dt2.Rows[b]["Caption"].ToString() == "") ? "#" : dt2.Rows[b]["Caption"].ToString()) + "</font></a></td></tr>";
                        }
                        strHTML += "</table></div>";
                    }
                    i++;
                    //strHTML += "</td></tr></table></td>";
                    strHTML += "</td></tr></table>";
                }
                //strHTML += "</tr></table><br></div>";
                strHTML += "<br></div>";

                //在页面上显示菜单
                LabelLogin.Text = strHTML;
                #endregion

                //如果是初次登录，则弹出页面让用户修改密码
                if (Config.Staff.LoginTimes == 0)
                {
                    //弹出修改页面
                    Response.Write("<script type='text/javascript'>window.showModleDialog('PopPage/ChangePassWord.aspx','密码修改页面','height=200, width=200, top='+(screen.AvailHeight-200)/2+', left='+ (screen.availWidth-200)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');</script>");
                }
            }
            catch (Exception Err)
            {
                ErrorLog.LogInsert(Err.Message, "IndexMenu.Page_Load", Session["StaffId"].ToString());
            }
        }
    }
}
