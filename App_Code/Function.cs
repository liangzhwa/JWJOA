using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Function 的摘要说明
/// </summary>
public class Function
{
	public Function()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 判断当前登录角色是否具有某个功能（参数中指定）
    /// </summary>
    /// <param name="FunctionId">要判断的功能ID</param>
    /// <param name="config">当前登录人的信息</param>
    /// <returns></returns>
    public static bool CheckRole(string FunctionId, Config config)
    {
        //根据登录角色得到功能
        string strGetFunction = "Select Function_Id From SSysRoleFunction Where Role_Id ='" + config.LoginRole + "'";

        bool isHave = false;
        try
        {
            MDataBase db = new MDataBase(config.DBConn);
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

    /// <summary>
    /// 根据员工编码判断该员工是不是管理员，如果是系统管理员，则返回“Yes”，如果是某个部门的管理员，则返回该部门的编码，如果不是管理员，则返回“No”
    /// </summary>
    /// <param name="config"></param>
    /// <returns></returns>
    public static string CheckStaff(Config config)
    {
        if (config.Staff.IsMonitor == 0)
        {
            string strGetDept = "Select Dept_Id From SSysStaff Where Staff_Id= '" + config.Staff.Staff_Id + "'";
            MDataBase db = new MDataBase(config.DBConn);
            DataTable dt = new DataTable();
            db.GetDataTable(strGetDept, out dt);
            if (dt.Rows[0][0].ToString() != "0")
            {
                return dt.Rows[0]["Dept_Id"].ToString();
            }
            else
            {
                return "Yes";
            }
        }
        else
        {
            return "No";
        }
    }

    /// <summary>
    /// 根据部门ID得到属于此部门的员工的集合,如果部门ID是0则返回全部员工
    /// </summary>
    /// <param name="DeptId"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static string GetStaffByDept(string DeptId,Config config)
    {
        try
        {
            string strReturn = "('";
            MDataBase db = new MDataBase(config.DBConn);
            DataTable dtStaff = new DataTable();
            string strStaff = "";
            if (DeptId == "0")
            {
                strStaff = "Select * From SSysStaff";
            }
            else
            {
                strStaff = "Select * From SSysStaff Where Dept_Id='" + DeptId + "'";
            }
            db.GetDataTable(strStaff, out dtStaff);
            if (dtStaff.Rows.Count > 0)
            {
                for (int i = 0; i < dtStaff.Rows.Count; i++)
                {
                    strReturn += dtStaff.Rows[i]["Staff_Id"].ToString() + "','";
                }
                strReturn = strReturn.TrimEnd('\'').TrimEnd(',').TrimEnd('\'');
            }            
            strReturn += "')";

            return strReturn;
        }
        catch (Exception exc)
        {
            throw exc;        
        }
    }

    /// <summary>
    /// 根据员工编号得到员工姓名
    /// </summary>
    /// <param name="id"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static string GetStaffNameById(string id,Config config)
    {
        try
        {
            string strReturnNames = "";
            if (id != "undefined")            
            {                
                id = id.Replace(",", "','");
                string strName = "Select Name From SSysStaff Where Staff_Id in ('" + id + "')";
                MDataBase db = new MDataBase(config.DBConn);
                DataTable dtName = new DataTable();
                db.GetDataTable(strName, out dtName);
                if (dtName.Rows.Count > 0)
                {
                    for (int i = 0; i < dtName.Rows.Count; i++)
                    {
                        strReturnNames += dtName.Rows[i]["Name"].ToString() + ",";
                    }
                    strReturnNames = strReturnNames.TrimEnd(',');
                }                
            }
            return strReturnNames;
        }
        catch (Exception exc)
        {
            throw exc;
        }

    }

    /// <summary>
    /// 根据部门编号得到部门姓名
    /// </summary>
    /// <param name="id"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static string GetDeptNameById(string id, Config config)
    {
        try
        {
            string strReturnNames = "";
            if (id != "undefined")
            {                
                id = id.Replace(",", "','");

                string strName = "Select Name From SSysDepartment Where Dept_Id in ('" + id + "')";
                MDataBase db = new MDataBase(config.DBConn);
                DataTable dtName = new DataTable();
                db.GetDataTable(strName, out dtName);
                if (dtName.Rows.Count > 0)
                {
                    for (int i = 0; i < dtName.Rows.Count; i++)
                    {
                        strReturnNames += dtName.Rows[i]["Name"].ToString() + ",";
                    }
                    strReturnNames = strReturnNames.TrimEnd(',');
                }                
            }
            return strReturnNames;
        }
        catch (Exception exc)
        {
            throw exc;
        }

    }

    /// <summary>
    /// 根据部门ID集得到属于这些部门的员工的集合
    /// </summary>
    /// <param name="DeptIds">字符串如［***,***,***］</param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static string GetAllStaffByDepts(string DeptIds, Config config)
    {
        try
        {
            DeptIds = DeptIds.Replace(",", "','");
            string strReturn = "('";
            MDataBase db = new MDataBase(config.DBConn);
            DataTable dtStaff = new DataTable();
            string strStaff = "";

            strStaff = "Select * From SSysStaff Where Dept_Id in ('" + DeptIds + "')";
          
            db.GetDataTable(strStaff, out dtStaff);
            if (dtStaff.Rows.Count > 0)
            {
                for (int i = 0; i < dtStaff.Rows.Count; i++)
                {
                    strReturn += dtStaff.Rows[i]["Staff_Id"].ToString() + "','";
                }
                strReturn = strReturn.TrimEnd('\'').TrimEnd(',').TrimEnd('\'');
            }
            strReturn += "')";

            return strReturn;
        }
        catch (Exception exc)
        {
            throw exc;
        }
    }

    /// <summary>
    /// 根据角色编号得到角色姓名
    /// </summary>
    /// <param name="id"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static string GetRoleNameById(string id, Config config)
    {
        try
        {
            string strReturnNames = "";
            if (id != "undefined")
            {
                id = id.Replace(",", "','");
                string strName = "Select Name From SSysRole Where Role_Id in ('" + id + "')";
                MDataBase db = new MDataBase(config.DBConn);
                DataTable dtName = new DataTable();
                db.GetDataTable(strName, out dtName);
                if (dtName.Rows.Count > 0)
                {
                    for (int i = 0; i < dtName.Rows.Count; i++)
                    {
                        strReturnNames += dtName.Rows[i]["Name"].ToString() + ",";
                    }
                    strReturnNames = strReturnNames.TrimEnd(',');
                }
            }
            return strReturnNames;
        }
        catch (Exception exc)
        {
            throw exc;
        }

    }

    public static void BindDeptToDdl(DropDownList ddlId, Config config)
    {
        try
        {
            string strDept = "select * from SSysDepartment order by Parent_Id,OrderIndex";
            MDataBase db = new MDataBase(config.DBConn);
            DataTable dtDept = new DataTable();
            db.GetDataTable(strDept, out dtDept);

            if (dtDept != null)
            {
                ddlId.DataSource = dtDept;
                ddlId.DataTextField = "Name";
                ddlId.DataValueField = "Dept_Id";
                ddlId.DataBind();
            }
        }
        catch (Exception exc)
        {
            throw exc;
        }
    }
}
