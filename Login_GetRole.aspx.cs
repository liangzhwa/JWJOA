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

public partial class Login_GetRole : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //测试调用情况
        //Response.Write(this.Request.RawUrl);

        Config config = (Config)Session["Config"];

        string strUsername = Request["txtLoginName"].ToString();
        DataTable dtStaffRole;
        DataTable dtDelegateRole;
        string sql = "";
        string sql2 = "";
        string ReturnCode = "";
        //string strStaffId;

        CSSysStaff staff = new CSSysStaff(config.DBConn);
        staff.Username = strUsername;
        staff.GetInfo();

        //得到登录者所拥有的角色
        sql = "SELECT B.Name, B.Role_Id AS Id FROM SSysStaffProjectRole A LEFT OUTER JOIN SSysRole B ON A.Role_Id = B.Role_Id WHERE  A.Staff_Id = '" + staff.Staff_Id + "' AND A.Project_Id= '" + config.ProjectId + "' AND B.StatusId = 0";        
        MDataBase db = new MDataBase(config.DBConn);
        db.GetDataTable(sql, out dtStaffRole);
        for (int i = 0; i < dtStaffRole.Rows.Count; i++)
        {
            ReturnCode += dtStaffRole.Rows[i][1] + "*" + dtStaffRole.Rows[i][0] + "#";
        }

        //得到登录者所代理的角色
        if (config.IsCommission)
        {
            sql2 = "";
            db.GetDataTable(sql2, out dtDelegateRole);
            for (int i = 0; i < dtDelegateRole.Rows.Count; i++)
            {
                ReturnCode += "(delegate)" + dtDelegateRole.Rows[i][1] + "*" + dtDelegateRole.Rows[i][0] + "#";
            }
        }

        Response.ContentType = "text/plain";
        Response.Write(ReturnCode);
        Response.End();

        //if (dtStaffRole != null)
        //{
        //    ReturnCode += "<select name='sltRole' id='sltRole' style='width:130px;'>";
        //    bool IsFrist = true;
        //    foreach (DataRow dr in dtStaffRole.Rows)
        //    {
        //        if (IsFrist == true)
        //        {
        //            ReturnCode += "<option selected=\"selected\" value=\"";
        //            IsFrist = false;
        //        }
        //        else
        //        {
        //            ReturnCode += "<option value=\"";
        //        }
        //        ReturnCode += dr["Id"].ToString() + "\">" + dr["Name"].ToString() + "</option>";
        //        ReturnCode += "</select>";
        //    }
        //}

        ////<option selected="selected" value="Value1">Text1</option>
        ////<option value="Value2">Text2</option>
        //Response.Write(ReturnCode);
    }
}
