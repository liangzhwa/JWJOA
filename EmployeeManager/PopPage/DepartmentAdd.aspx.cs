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

public partial class EmployeeManager_PopPage_DepartmentAdd : System.Web.UI.Page
{
    //定义全局变量
    MDataBase db;
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            config.ProjectId = "00000001";

            //取得所有部门，作为新部门的父部门
            DataTable dt = new DataTable();
            db = new MDataBase(config.DBConn);
            db.GetDataTable("select * from SSysDepartment", out dt);
            ddlSupDepartment.Items.Clear();

            //当新部门没有父部门时的选项
            ddlSupDepartment.Items.Add(new ListItem("无","0"));
            ddlSupDepartment.AppendDataBoundItems = true;

            //绑定新部门的父部门
            ddlSupDepartment.DataSource = dt.DefaultView;
            ddlSupDepartment.DataTextField = "Name";
            ddlSupDepartment.DataValueField = "Dept_Id";
            ddlSupDepartment.DataBind();

            //添加关闭本页面的事件
            btnSave.Attributes.Add("onclick", "closeWin();");

            if (Request.QueryString["Department"] != null)
            {
                DataTable dtDept;
                string strDept = Request.QueryString["Department"].ToString();
                db = new MDataBase(config.DBConn);
                db.GetDataTable("select * from SSysDepartment where Dept_Id='" + strDept + "' Order By Parent_Id,OrderIndex", out dtDept);
                txtDepartmentName.Text = dtDept.Rows[0]["Name"].ToString();
                for (int i = 0; i < ddlSupDepartment.Items.Count; i++)
                {
                    if (ddlSupDepartment.Items[i].Value == dtDept.Rows[0]["Parent_Id"].ToString())
                    {
                        ddlSupDepartment.SelectedIndex = i;
                    }
                }
                hfIsUpdate.Value = strDept;
                lblCaption.Text = "部门修改";
            }
            else
            {
                hfIsUpdate.Value = "Insert";
                lblCaption.Text = "部门添加";
            }
            
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    { 
        Save();
        //Response.Write("<script>window.dialogArguments.location.reload(); window.close();</script>");
    }

    //保存数据到数据库
    public void Save()
    {
        //得到要插入的新的部门编号
        string strId = Guid.NewGuid().ToString().Substring(0,8);
        string supId = ddlSupDepartment.SelectedValue;
        string name = txtDepartmentName.Text;
        string comment = txtDepartmentNote.Text;
        string sql = "";

        if (name == "")
        {
            //当没有输入部门名称时，弹出警告窗口
            Response.Write("<script type='text/javascript'>alert('请输入部门名称！')</script>");
        }
        else
        {
            db = new MDataBase(config.DBConn);

            //向数据库中插入新部门
            if (hfIsUpdate.Value == "Insert")
            {
                sql = "INSERT INTO SSysDepartment (Dept_Id, Parent_Id, Name, Comment,CreatedDate, StatusId) values('" + strId + "','" + supId + "','" + name + "','" + comment + "','" + DateTime.Now + "','0')";
            }
            else
            {
                sql = "UPDATE SSysDepartment SET Parent_Id ='" + supId + "',Comment='" + comment + "',Name='" + name + "',ModifiedDate='" + DateTime.Now + "' WHERE Dept_Id='" + hfIsUpdate.Value + "'";
            }
                        
            db.executeInsert(sql);

            //插入新部门后关闭部门添加页面
            //Response.Write("<script type='text/javascript'>window.opener.location.href=window.opener.location.href; this.window.close();</script>");
        }
    }

}
