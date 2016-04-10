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

public partial class EmployeeManager_PopPage_RoleAdd : System.Web.UI.Page
{
    //定义全局变量
    MDataBase db;
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());
    
    protected void Page_Load(object sender, EventArgs e)
    {
        config.ProjectId = "00000001";

        if (!IsPostBack)
        {           

            //取得所有功能选项
            DataTable dt = new DataTable();
            db = new MDataBase(config.DBConn);
            db.GetDataTable("select * from SSysFunction", out dt);

            cblFunctionSelect.DataSource = dt.DefaultView;
            cblFunctionSelect.DataTextField = "Name";
            cblFunctionSelect.DataValueField = "Function_Id";
            cblFunctionSelect.DataBind();

            //添加关闭本页面的事件
            btnSave.Attributes.Add("onclick", "closeWin();");


            if (Request.QueryString["RoleId"] != null)
            {
                //保存角色信息
                DataTable dtRole;

                //保存角色功能关系信息
                DataTable dtRoleFunction;

                string strRole = Request.QueryString["RoleId"].ToString();
                db = new MDataBase(config.DBConn);

                //取得角色信息
                db.GetDataTable("select * from SSysRole where Role_Id='" + strRole + "'", out dtRole);

                //取得角色功能关系信息
                db.GetDataTable("select * from SSysRoleFunction where Role_Id='" + strRole + "'", out dtRoleFunction);
                txtRoleName.Text = dtRole.Rows[0]["Name"].ToString();

                for (int i = 0; i < cblFunctionSelect.Items.Count; i++)
                {
                    if ((dtRoleFunction.Select("Function_Id='" + cblFunctionSelect.Items[i].Value + "'").Length) != 0)
                    {
                        cblFunctionSelect.Items[i].Selected = true;
                    }
                }
                hfIsUpdate.Value = strRole;
                lblCaption.Text = "角色修改";
            }
            else
            {
                hfIsUpdate.Value = "Insert";
                lblCaption.Text = "角色添加";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //得到要插入的新的角色编号
        string strId = Guid.NewGuid().ToString().Substring(0, 8);

        string supId = cblFunctionSelect.SelectedValue;
        string name = txtRoleName.Text;
        string comment = txtRoleNote.Text;

        if (name == "")
        {
            //当没有输入角色名称时，弹出警告窗口
            Response.Write("<script type='text/javascript'>alert('请输入角色名称！')</script>");
        }
        else
        {
            db = new MDataBase(config.DBConn);

            //向数据库中插入新角色
            if (hfIsUpdate.Value == "Insert")
            {
                //向数据库中插入新角色
                string strRoleSql = "INSERT INTO SSysRole (Role_Id,Project_Id, Name, CreatedDate, StatusId) values('" + strId + "','" + config.ProjectId + "','" + name + "','" + DateTime.Now + "','0')";
                db.executeInsert(strRoleSql);

                //向数据库中插入角色功能关系 
                for (int i = 0; i < cblFunctionSelect.Items.Count; i++)
                {
                    if (cblFunctionSelect.Items[i].Selected)
                    {
                        string strRoleFuncSql = "Insert Into SSysRoleFunction values('" + strId + "','" + cblFunctionSelect.Items[i].Value + "')";
                        db.executeInsert(strRoleFuncSql);
                    }
                }                               
            }
            else
            {
                //更新角色数据
                string sqlUpdate = "UPDATE SSysRole SET Project_Id='" + config.ProjectId + "',Name='" + name + "',ModifiedDate='" + DateTime.Now + "' WHERE Role_Id='" + hfIsUpdate.Value + "'";
                db.executeUpdate(sqlUpdate);

                //先删除相关角色功能关系
                string sqlDelete = "Delete from SSysRoleFunction Where Role_Id='" + hfIsUpdate.Value + "'";
                db.executeDelete(sqlDelete);

                //向数据库中插入角色功能关系 
                for (int i = 0; i < cblFunctionSelect.Items.Count; i++)
                {
                    if (cblFunctionSelect.Items[i].Selected)
                    {
                        string strRoleFuncSql = "Insert Into SSysRoleFunction values('" + hfIsUpdate.Value + "','" + cblFunctionSelect.Items[i].Value + "')";
                        db.executeInsert(strRoleFuncSql);
                    }
                }

                Response.Write("<script>window.dialogArguments.reload();</script>");
            }
        }

        
    }
}
