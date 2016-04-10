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
using System.Net;
using System.IO;
using System.Text;
using Stone.Web;
using Stone;
using Stone.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetConfig();
        }
    }

    protected void Page_Close(object sender, EventArgs e)
    {
        //Application["Login"] = "";
    }

    protected void LogButton_Click(object sender, EventArgs e)
    {
        if (this.txtLoginName.Text.Trim().Length == 0)
        {
            JS.alert("登录名不能为空！");
            return;
        }
       
        bool blnLogin = false;
        try
        {
            if (Session["Config"] == null)
            {
                Response.Redirect("error2.htm");
            }
            Config config = (Config)Session["Config"];
            CSSysStaff staff = new CSSysStaff(config.DBConn);
            staff.Username = this.txtLoginName.Text.Trim();
            staff.GetInfo();


            if (staff.Staff_Id != null)
            {
                if (staff.Password == this.txtPwd.Text.Trim())
                {
                    blnLogin = true;
                    config.Staff = staff;
                    config.LoginTime = DateTime.Now;
                    config.LoginRole = HiRole.Value;//this.sltRole.SelectedValue;

                    //把Application付于Hashtable
                    Hashtable htLoginParam = new Hashtable();
                    Hashtable htLoginParam1 = new Hashtable();
                    bool IsLogin = false;

                    htLoginParam1 = (Hashtable)Application["Hashtable"];
                    if (htLoginParam1 != null)
                    {
                        htLoginParam = htLoginParam1;
                    }

                    //判断是否已登陆
                    if (htLoginParam.Count != 0)
                    {
                        IsLogin = htLoginParam.ContainsKey(config.Staff.Username);
                    }
                    if (IsLogin == true && htLoginParam.Count != 0)
                    {
                        WebWindow.alert("该用户已登陆!");
                        return;
                    }

                    string LoginHistoryGuid = Guid.NewGuid().ToString().ToUpper();

                    #region  
                    
                }
            }
        }
        catch
        {
            Response.Redirect("error2.htm");
            return;
        }

        if (blnLogin == true)
        {
            Response.Redirect("index.aspx");
            return;
        }
        else
        {
            JS.alert("登录名或密码错误,请重输!");
            return;
        }
    }
        

    private void GetConfig()
    {
        Config config = new Config();
        bool blnGet = config.GetParameter("OA");
        if (blnGet == false)
        {
            JS.alert(config.ErrMessage);
            return;
        }
        CSSysStaff staff = new CSSysStaff(config.DBConn);
        staff.Staff_Id = txtLoginName.Text;
        config.LoginTime = DateTime.Now;
        config.Staff = staff;
        config.ProjectId = "00000001";
        Session["Config"] = config;
    }
}
#endregion