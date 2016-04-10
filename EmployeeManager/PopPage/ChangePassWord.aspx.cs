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

public partial class EmployeeManager_PopPage_ChangePassWord : System.Web.UI.Page
{
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());
    CSSysStaff staff;

    protected void Page_Load(object sender, EventArgs e)
    {
        staff = new CSSysStaff(config.DBConn);
        staff.Password = "123";
        config.Staff = staff;

        if (!IsPostBack)
        { 
            if(Request.QueryString["oldPwd"] != null)
            {
                string strOldPwd = Request.QueryString["oldPwd"].ToString();
                txtOldPwd.Text = strOldPwd;
            }
        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (txtOldPwd.Text == "")
        {
            Response.Write("<script type='text/javascript'>alert('请输入旧密码！')</script>");
        }
        else if(txtOldPwd.Text != staff.Password)
        {
            Response.Write("<script type='text/javascript'>alert('您输入的旧密码不正确，请重新输入！')</script>");
        }
        else if (txtNewPwd.Text == "" || txtConfirmPwd.Text == "")
        {
            Response.Write("<script type='text/javascript'>alert('密码和确认密码不能为空！')</script>");
        }
        else if (txtNewPwd.Text != txtConfirmPwd.Text)
        {
            Response.Write("<script type='text/javascript'>alert('输入的两次密码不一致，请重新输入！')</script>");
        }
        else
        {
            try
            {
                staff.Staff_Id = config.Staff.Staff_Id;
                staff.Password = txtNewPwd.Text;
                staff.Update();
                Response.Write("<script type='text/javascript'>alert('密码修改成功，下次登录时请使用新密码！')</script>");

            }
            catch (Exception exc)
            {
                Response.Write("<script type='text/javascript'>alert('密码修改失败！')</script>");

            }
        }
    }
}
