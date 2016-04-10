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
/// StaffOper 的摘要说明
/// </summary>
public class StaffOper
{

    private static string _DBConn;

    public string DBConn
    {
        get { return _DBConn; }
    }

	public StaffOper()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public StaffOper(string DBConn)
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
        _DBConn = DBConn;
    }

    /// <summary>
    /// 权限判断
    /// </summary>
    /// <param name="strid"></param>
    /// <returns></returns>
    public static bool UserPower(string StaffId, string FunctionOrgId)
    {
        MDataBase db = new MDataBase(_DBConn);
        string sql;
        try
        {
            sql = "SELECT count(*) FROM SCtiRoleMenu B INNER JOIN SCtiStaffProjectRole A ON B.Role_Id = A.Role_Id INNER JOIN SCtiMenus C ON B.Menu_Id = C.Menu_Id WHERE A.Staff_Id='" + StaffId + "' and  (C.Function1_Id = '" + FunctionOrgId + "') OR (C.Function2_Id ='" + FunctionOrgId + "') OR (C.Function3_Id = '" + FunctionOrgId + "') OR (C.Function4_Id = '" + FunctionOrgId + "')";
            string StrCount = db.GetDataScalar(sql);
            if (Convert.ToInt32(StrCount) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "StaffOper.cs/UserPower", StaffId);
            return false;
        }
    }
}
