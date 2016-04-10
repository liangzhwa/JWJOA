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

public partial class EmployeeManager_PopPage_RoleSelect : System.Web.UI.Page
{
    MDataBase db;
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //////////////////
            CSSysStaff staff = new CSSysStaff();
            config.Staff = staff;
            staff.Staff_Id = "00000001";
            //////////////////


            db = new MDataBase(config.DBConn);
            string strDept = "Select * From SSysRole";
            DataTable dtDept = new DataTable();

            db.GetDataTable(strDept, out dtDept);

            //动态创建表来显示部门
            TableRow tr = new TableRow();
            for (int i = 0; i < dtDept.Rows.Count; i++)
            {
                if (i % 3 == 0)
                {
                    tr = new TableRow();
                }
                TableCell tc = new TableCell();
                CheckBox cb = new CheckBox();
                cb.Text = dtDept.Rows[i]["Name"].ToString();
                cb.ID = dtDept.Rows[i]["Role_Id"].ToString();
                tc.Controls.Add(cb);
                tc.Width = 100;
                tr.Cells.Add(tc);
                tabDept.Rows.Add(tr);
            }
        }   
    }
}
