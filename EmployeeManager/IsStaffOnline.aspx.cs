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
using System.Drawing;

public partial class EmployeeManager_IsStaffOnline : System.Web.UI.Page
{
    MDataBase db;
    Config config = new Config(ConfigurationManager.ConnectionStrings["OA"].ToString());


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //////////////////
            CSSysStaff staff = new CSSysStaff();
            config.Staff = staff;
            staff.Staff_Id = "00000001";
            //////////////////

            //判断权限
            string strPower = Function.CheckStaff(config);

            //得到所有员工姓名、部门、是否在线等信息
            db = new MDataBase(config.DBConn);
            DataTable dt = new DataTable();
            string sql = "select a.Staff_Id,a.Name,b.Name AS Department,a.IsMonitor,LastLoginTime - LastLogoutTime AS IsOnline,a.Dept_Id From SSysStaff a Left Join SSysdepartment b on a.Dept_Id = b.Dept_Id Where a.StatusId=0 ORDER BY b.Name,a.IsMonitor DESC";
            db.GetDataTable(sql, out dt);

            TableRow tr1;
            TableCell tcJob;

            ////插入第一行
            //tr1 = new TableRow();
            //tcJob = new TableCell();
            //tcJob.Text = "局长";
            //tcJob.HorizontalAlign = HorizontalAlign.Right;
            //tcJob.Width = 50;
            //tr1.Cells.Add(tcJob);
            //tlbIsOnline.Rows.Add(tr1);

            ////插入局长名字及在线状态
            //tr1 = new TableRow();
            //tcJob = new TableCell();
            //tcJob.Text = "  ";
            //tcJob.Width = 50;
            //tr1.Cells.Add(tcJob);

            //tcJob = new TableCell();
            //tcJob.Text = "***" + " ●";
            ////根据条件判断应该经什么颜色显示
            //tcJob.ForeColor = Color.Red;
            //tcJob.Width = 50;
            //tr1.Cells.Add(tcJob);
            //tlbIsOnline.Rows.Add(tr1);

            ////插入第三行
            //tr1 = new TableRow();
            //tcJob = new TableCell();
            //tcJob.Text = "副局长";
            //tcJob.HorizontalAlign = HorizontalAlign.Right;
            //tcJob.Width = 50;
            //tr1.Cells.Add(tcJob);
            //tlbIsOnline.Rows.Add(tr1);

            //插入副局长的名字


            //插入各部门
            //得到各个部门
            db = new MDataBase(config.DBConn);
            DataTable dtDept = new DataTable();
            string strDeptSql = "select b.Name AS Department,b.Dept_Id As DeptId,MIN(b.OrderIndex) AS [Index] From SSysStaff a Left Join SSysdepartment b on a.Dept_Id = b.Dept_Id Where a.StatusId=0 And b.Name!='' Group by b.Name,b.Dept_Id Order by [Index]";
            db.GetDataTable(strDeptSql, out dtDept);

            for (int i = 0; i < dtDept.Rows.Count; i++)
            {
                //添加部门行
                tr1 = new TableRow();
                tcJob = new TableCell();
                tcJob.ColumnSpan = 2;
                CheckBox cbf = new CheckBox();
                cbf.Text = dtDept.Rows[i][0].ToString();
                cbf.ID = dtDept.Rows[i][1].ToString();
                tcJob.Controls.Add(cbf);

                //判断权限确定能够选择哪些员工
                if (strPower == "Yes")
                {
                    cbf.Enabled = true;
                }
                else if (strPower == dtDept.Rows[i][1].ToString())
                {
                    cbf.Enabled = true;
                }
                else
                {
                    cbf.Enabled = false;
                }
                cbf.InputAttributes.Add("onclick", "AllSelect('tlb" + cbf.ID + "');");

                //tcJob.Text = dtDept.Rows[i][0].ToString();
                tcJob.HorizontalAlign = HorizontalAlign.Left;
                tcJob.Width = 50;
                tr1.Cells.Add(tcJob);
                tlbIsOnline.Rows.Add(tr1);


                //添加部门人员行
                //得到相应部门的员工
                DataRow[] dr = dt.Select("Department='" + dtDept.Rows[i][0].ToString() + "'","IsMonitor");
                if (dr.Length > 0)
                {

                    tr1 = new TableRow();
                    tr1.Width = 600;
                    TableCell tcBlank = new TableCell();
                    tcBlank.Width = 50;
                    tr1.Cells.Add(tcBlank);

                    TableCell tc1 = new TableCell();
                    tc1.Width = 600;


                    //新建个表，存放员工信息
                    Table tab = new Table();                    
                    tab.ID = "tlb" + dtDept.Rows[i][1].ToString();

                    //创建新表的行
                    TableRow tr2 = new TableRow();

                    //如果没有主官，则首个单元格为空
                    if ((dt.Select("Department='" + dtDept.Rows[i][0].ToString() + "' And IsMonitor='0'")).Length < 0)
                    {
                        tcJob = new TableCell();
                        tcJob.Width = 50;
                        tcJob.Text = "";
                        tr2.Cells.Add(tcJob);
                    }
                    for (int j = dr.Length -1; j >= 0; j--)
                    {
                        //如果是三的整倍，则换行
                        if (tr2.Cells.Count > 3 || tr2.Cells.Count == 0)
                        {
                            tr2 = new TableRow();

                            //只有该部门有主官，或者是第一行，才要加空单元格
                            if ((dt.Select("Department='" + dtDept.Rows[i][0].ToString() + "' And IsMonitor='0'")).Length > 0 && j == (dr.Length - 1))
                            {
                                
                            }
                            else
                            {
                                tcJob = new TableCell();
                                tcJob.Width =50;
                                tcJob.Text = "";
                                tr2.Cells.Add(tcJob);
                            }
                        }

                        tcJob = new TableCell();                       
                        tcJob.HorizontalAlign = HorizontalAlign.Left;
                        tcJob.Width = 140;
                                          

                        //显示复选框，使员工可以多选
                        CheckBox cb = new CheckBox();
                        cb.Text = dr[j][1].ToString() + "●   ";
                        cb.ID = dr[j][0].ToString();
                        tcJob.Controls.Add(cb);
                        cb.LabelAttributes.Add("onclick", "return window.showModalDialog( 'PopPage/StaffWorkPlan.aspx?StaffId=" + dr[j][0].ToString() + "','工作日程页面','dialogHeight=450, dialogWidth=600, top='+(screen.AvailHeight-450)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')");
                        cb.LabelAttributes.Add("onmouseover", "return this.style.cursor='hand'");

                        //判断权限确定能够选择哪些员工
                        if (strPower == "Yes")
                        {
                            cb.Enabled = true;
                        }
                        else if (strPower == dtDept.Rows[i][1].ToString())
                        {
                            cb.Enabled = true;
                        }
                        else
                        {
                            cb.Enabled = false;
                        }

                        string s = dr[j][4].ToString();
                        if (dr[j][4].ToString() != "")
                        {
                            if (Convert.ToDateTime(dr[j][4]) < Convert.ToDateTime("1900-1-1"))
                            {
                                tcJob.ForeColor = Color.Red;
                            }
                            else
                            {
                                tcJob.ForeColor = Color.Silver;
                            }
                        }
                        tr2.Cells.Add(tcJob);
                        tab.Rows.Add(tr2);

                        tc1.Controls.Add(tab);
                        
                        tr1.Cells.Add(tc1);
                        tlbIsOnline.Rows.Add(tr1);
                    }
                }
            }
        }

        
    }
}
