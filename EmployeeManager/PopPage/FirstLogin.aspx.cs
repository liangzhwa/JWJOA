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

public partial class EmployeeManager_PopPage_FirstLogin : System.Web.UI.Page
{
    //定义全局变量
    MDataBase db;
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            config.LoginRole = "7040c194";
            config.ProjectId = "00000001";

            btnRoleSelect.Attributes.Add("onclick", "SelectRole();");

            //加载部门到部门下拉框
            DataTable dt = new DataTable();
            db = new MDataBase(config.DBConn);
            db.GetDataTable("select * from SSysDepartment", out dt);
            ddlDepartment.Items.Clear();
            ddlDepartment.Items.Add(new ListItem("无", "0"));
            ddlDepartment.AppendDataBoundItems = true;

            //自动生成密码
            txtPwd.Text = Guid.NewGuid().ToString().Substring(0, 6);


            //绑定部门
            ddlDepartment.DataSource = dt.DefaultView;
            ddlDepartment.DataTextField = "Name";
            ddlDepartment.DataValueField = "Dept_Id";
            ddlDepartment.DataBind();

            //向是否为主管下拉框中添加项目
            ddlIsManager.Items.Add(new ListItem("是","0"));
            ddlIsManager.Items.Add(new ListItem("否", "-1"));

            //向婚否下拉框中添加项目
            ddlIsManager.Items.Add(new ListItem("未选择","-1"));
            ddlIsMarray.Items.Add(new ListItem("是", "0"));
            ddlIsMarray.Items.Add(new ListItem("否", "1"));

            //取得父页面传的值
            if (Request.QueryString["StaffId"] != null)
            {
                DataTable dtStaff;
                string strStaff = Request.QueryString["StaffId"].ToString();

                //保存员工号
                hfIsUpdate.Value = strStaff;

                //加载员工所在的部门
                db = new MDataBase(config.DBConn);
                db.GetDataTable("select * from SSysStaff where Staff_Id='" + strStaff + "'", out dtStaff);                
                for (int i = 0; i < ddlDepartment.Items.Count; i++)
                {
                    if (ddlDepartment.Items[i].Value == dtStaff.Rows[0]["Dept_Id"].ToString())
                    {
                        ddlDepartment.SelectedIndex = i;
                    }
                }
                

                //加载选中人员的信息
                txtUserName.Text = dtStaff.Rows[0]["UserName"].ToString();
                txtName.Text = dtStaff.Rows[0]["Name"].ToString();
                txtBirthday.Text = dtStaff.Rows[0]["Birthday"].ToString();

                //if (dtStaff.Rows[0]["Birthday"].ToString() != "")
                //{
                //    txtAge.Text = Convert.ToString((DateTime.Now.Year - Convert.ToDateTime(dtStaff.Rows[0]["Birthday"].ToString()).Year));
                //}
                txtBusiness.Text = dtStaff.Rows[0]["StringField1"].ToString();//职务
                ddlMilitary.SelectedIndex = 0;//衔级
                txtOfficeTel.Text = dtStaff.Rows[0]["StringField3"].ToString();//办公电话1
                txtOfficeTel2.Text = dtStaff.Rows[0]["StringField4"].ToString();//办公电话2
                txtShortTel.Text = dtStaff.Rows[0]["StringField7"].ToString();//电话短号
                txtSMSCode.Text = dtStaff.Rows[0]["StringField18"].ToString();//短信号码
                txtWorkDate.Text = dtStaff.Rows[0]["StringField19"].ToString();//工作时间
                txtWorkDate.Text = dtStaff.Rows[0]["WorkStatusId"].ToString();//工作状态
                txtNativePlace.Text = dtStaff.Rows[0]["StringField16"].ToString();//籍贯
                txtAddress.Text = dtStaff.Rows[0]["StringField8"].ToString();//家庭住址
                txtEmail.Text = dtStaff.Rows[0]["EMail"].ToString();//电子信箱
                txtMobileTel.Text = dtStaff.Rows[0]["StringField5"].ToString();//移动电话
                txtEducation.Text = dtStaff.Rows[0]["StringField15"].ToString();//学历
                txtGroup.Text = dtStaff.Rows[0]["StringField14"].ToString();//政治面貌
                ddlIsMarray.SelectedIndex = 0;//婚否
                txtMateWorkPlace.Text = dtStaff.Rows[0]["StringField13"].ToString();//配偶工作地点
                txtChildBirth.Text = dtStaff.Rows[0]["StringField12"].ToString();//子女出生日期
                txtPoliceId.Text = dtStaff.Rows[0]["StringField17"].ToString();//警官证号
                ddlPosition.SelectedIndex = 0;//职级
                ddlIsManager.SelectedIndex = 0;//是否主管
                txtEnrollment.Text = dtStaff.Rows[0]["StringField10"].ToString();//入伍时间
                txtHomeTel.Text = dtStaff.Rows[0]["StringField6"].ToString();//住宅电话
                
            }
            else
            {
                //表明要在这个页面中进行插入操作
                hfIsUpdate.Value = "Insert";
                
            }


            //将所有输入都为不可写
            for (int i = 0; i < this.StaffForm.Controls.Count; i++)
            {
                if (this.StaffForm.Controls[i] is TextBox)
                {
                    ((TextBox)this.StaffForm.Controls[i]).Enabled = false; 
                }
                else if (this.StaffForm.Controls[i] is DropDownList)
                {
                    ((DropDownList)this.StaffForm.Controls[i]).Enabled = false;
                }
            }
            //根据权限确定哪些内容可以编辑
            //如果有添加用户权限
            if (Function.CheckRole("00000005", config))
            {
                txtUserName.Enabled = true;
                //ddlDepartment.Enabled = true;
                ddlIsManager.Enabled = true;

                //测试时用
                txtName.Enabled = true;

                hfRole.Value = "Adder";
            }
            //如果有修改基本信息权限
            else if (Function.CheckRole("00000006", config))
            {
                txtName.Enabled = true;
                txtHomeTel.Enabled = true;
                txtEmail.Enabled = true;
                txtAddress.Enabled = true;
                txtBirthday.Enabled = true;
                txtOfficeTel.Enabled = true;
                txtOfficeTel2.Enabled = true;
                txtShortTel.Enabled = true;
                txtSMSCode.Enabled = true;
                ddlIsMarray.Enabled = true;
                txtChildBirth.Enabled = true;
                txtMateWorkPlace.Enabled = true;
                txtEducation.Enabled = true;
                txtNativePlace.Enabled = true;
                txtSMSCode.Enabled = true;
                

                hfRole.Value = "Self";
            }
            //如果有修改政治信息权限
            else if (Function.CheckRole("00000007", config))
            {
                txtBusiness.Enabled = true;
                //txtMilitary.Enabled = true;
                txtEnrollment.Enabled = true;
                txtGroup.Enabled = true;
                txtPoliceId.Enabled = true;
                ddlPosition.Enabled = true;

                hfRole.Value = "Polity";
            }
            //如果是系统管理员
            else if (Function.CheckRole("00000008", config))
            {
                //将所有输入都为可写
                for (int i = 0; i < this.StaffForm.Controls.Count; i++)
                {
                    if (this.StaffForm.Controls[i] is TextBox)
                    {
                        ((TextBox)this.StaffForm.Controls[i]).Enabled = true;
                    }
                    else if (this.StaffForm.Controls[i] is DropDownList)
                    {
                        ((DropDownList)this.StaffForm.Controls[i]).Enabled = true;
                    }
                }

                //部门不允许修改
                ddlDepartment.Enabled = false;

                hfRole.Value = "Manager";
            }

            //如果为添加员工，则可以编辑部门
            if (hfIsUpdate.Value == "Insert")
            {
                ddlDepartment.Enabled = true;
            }

            //添加关闭本页面的事件
            btnSave.Attributes.Add("onclick", "closeWin();");
        }

        txtRole.Text = Function.GetRoleNameById(hfSelectRole.Value.TrimEnd(','),config);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CSSysStaff staff = new CSSysStaff(config.DBConn);
        
        if (hfIsUpdate.Value == "Insert")//执行插入操作
        {
            //设置部门为可写
            ddlDepartment.Enabled = true;

            //得到要插入的新的员工编号
            string strId = Guid.NewGuid().ToString().Substring(0, 8);

            try
            {
                staff.Staff_Id = strId;
                staff.Username = txtUserName.Text;
                staff.Password = txtPwd.Text;
                staff.Name = txtName.Text;
                staff.Dept_Id = ddlDepartment.SelectedValue;
                staff.IsMonitor = Int32.Parse(ddlIsManager.SelectedValue);
                //staff.Name = "";
                staff.LoginTimes = 0;
                staff.StatusId = 0;
                staff.TotalUseTime = 0;
                staff.WorkStatusId = 0;
                staff.PasswordDate = DateTime.Now;
                staff.Insert();

                string[] strRole = hfSelectRole.Value.TrimEnd(',').Split(',');
                db = new MDataBase(config.DBConn);
                    
                for(int i = 0;i<strRole.Length;i++)
                {
                    string strInsert = "insert into SSysStaffProjectRole values('" + strId + "','" + config.ProjectId + "','" + strRole[i] + "'," + 0 + ")";
                    db.executeInsert(strInsert);
                }
                
                Response.Write("<script type='text/javascript'>alert('添加成功！'); </script>");
            }
            catch (Exception exc)
            {
                Response.Write("<script type='text/javascript'>alert('添加失败！');</script>");
            }
        }
        else //执行更新操作
        {
            try
            {
                //设置更新条件
                staff.Staff_Id = hfIsUpdate.Value;

                if (hfRole.Value == "Adder") //
                {
                    //重置密码
                    //staff.Password = "123";

                    //修改部门
                    //staff.Dept_Id = ddlDepartment.SelectedValue;

                    //修改是否为主管
                    staff.IsMonitor = Int32.Parse(ddlIsManager.SelectedValue);


                    //进行更新
                    staff.Update();
                }
                else if (hfRole.Value == "Self")
                {
                    //更改姓名
                    if (txtName.Text != "")
                    {
                        staff.Name = txtName.Text;
                    }

                    //更改生日
                    if (txtBirthday.Text != "")
                    {
                        staff.Birthday = Convert.ToDateTime(txtBirthday.Text);
                    }

                    //更改家庭电话
                    if (txtHomeTel.Text != "")
                    {
                        staff.StringField6 = txtHomeTel.Text;
                    }

                    //更改移动电话
                    if (txtMobileTel.Text != "")
                    {
                        staff.StringField5 = txtMobileTel.Text;
                    }

                    //更改家庭住址
                    if (txtAddress.Text != "")
                    {
                        staff.StringField8 = txtAddress.Text;
                    }

                    //更改办公电话1
                    if (txtOfficeTel.Text != "")
                    {
                        staff.StringField3 = txtOfficeTel.Text;
                    }

                    //更改办公电话2
                    if (txtOfficeTel.Text != "")
                    {
                        staff.StringField4 = txtOfficeTel2.Text;
                    }

                    //更改电话短号
                    if (txtShortTel.Text != "")
                    {
                        staff.StringField7 = txtShortTel.Text;
                    }

                    //更改短信号码
                    if (txtSMSCode.Text != "")
                    {
                        staff.StringField18 = txtSMSCode.Text;
                    }

                    //进行更新
                    staff.Update();
                }
                else if (hfRole.Value == "Polity")
                {
                    //修改职务
                    if (txtBusiness.Text != "")
                    {
                        staff.StringField1 = txtBusiness.Text;
                    }

                    //修改军衔
                    //if (txtMilitary.Text != "")
                    //{
                    //    staff.StringField2 = txtMilitary.Text;
                    //}

                    //修改入伍时间
                    if (txtEnrollment.Text != "")
                    {
                        staff.StringField10 = Convert.ToDateTime(txtEnrollment.Text);
                    }

                    //进行更新
                    staff.Update();
                }
                else if (hfRole.Value == "Manager") //修改所有记录（密码不能修改）
                {

                    //重置密码
                    staff.Password = "123";

                    //修改部门
                    //staff.Dept_Id = ddlDepartment.SelectedValue;

                    //修改是否为主管
                    staff.IsMonitor = Int32.Parse(ddlIsManager.SelectedValue);
                    //更改姓名
                    if (txtName.Text != "")
                    {
                        staff.Name = txtName.Text;
                    }

                    //更改生日
                    if (txtBirthday.Text != "")
                    {
                        staff.Birthday = Convert.ToDateTime(txtBirthday.Text);
                    }

                    //更改家庭电话
                    if (txtHomeTel.Text != "")
                    {
                        staff.StringField6 = txtHomeTel.Text;
                    }

                    //更改移动电话
                    if (txtMobileTel.Text != "")
                    {
                        staff.StringField5 = txtMobileTel.Text;
                    }

                    //更改家庭住址
                    if (txtAddress.Text != "")
                    {
                        staff.StringField8 = txtAddress.Text;
                    }

                    //更改办公电话1
                    if (txtOfficeTel.Text != "")
                    {
                        staff.StringField3 = txtOfficeTel.Text;
                    }

                    //更改办公电话2
                    if (txtOfficeTel.Text != "")
                    {
                        staff.StringField4 = txtOfficeTel2.Text;
                    }

                    //更改电话短号
                    if (txtShortTel.Text != "")
                    {
                        staff.StringField7 = txtShortTel.Text;
                    }

                    //更改短信号码
                    if (txtSMSCode.Text != "")
                    {
                        staff.StringField18 = txtSMSCode.Text;
                    }

                    //修改职务
                    if (txtBusiness.Text != "")
                    {
                        staff.StringField1 = txtBusiness.Text;
                    }

                    ////修改军衔
                    //if (txtMilitary.Text != "")
                    //{
                    //    staff.StringField2 = txtMilitary.Text;
                    //}

                    //修改入伍时间
                    if (txtEnrollment.Text != "")
                    {
                        staff.StringField10 = Convert.ToDateTime(txtEnrollment.Text);
                    }

                    //进行更新
                    staff.Update();
                }
                Response.Write("<script type='text/javascript'>alert('更新成功！'); </script>");
            }
            catch (Exception exc)
            {
                Response.Write("<script type='text/javascript'>alert('更新失败！'); </script>");
            }

        }
    }

    /// <summary>
    /// 判断当前登录角色是否具有某个功能（参数中指定）
    /// </summary>
    /// <param name="FunctionId">要判断的功能ID</param>
    /// <param name="config">当前登录人的信息</param>
    /// <returns></returns>
    public bool CheckRole(string FunctionId,Config config)
    {       
        //根据登录角色得到功能
        string strGetFunction = "Select Function_Id From SSysRoleFunction Where Role_Id ='" + config.LoginRole  + "'";

        bool isHave = false;
        try
        {
            db = new MDataBase(config.DBConn);
            DataTable dt = new DataTable();
            db.GetDataTable(strGetFunction, out dt);

            //判断登录角色的功能中是否有指定功能
            if ((dt.Select("Function_Id='" + FunctionId + "'")).Length != 0)
            {
                isHave = true;
            }
        }
        catch (Exception exc)
        {
            throw exc;
        }
        return isHave;        
    }
}
