//================================================================================
// 模块类别:数据对象模块
// 模块名称:SSysStaffProjectRole数据对象
// 模块版本:1.0.0
// 开发人员:liang
// 最后日期:2008年04月14日
// 创建日期:2008年04月14日
// 相关模块:
// 模块说明:
//================================================================================

	using System;
	using System.Data;

	/// <summary>
	/// SSysStaffProjectRole业务实体对象
	/// </summary>
public class CSSysStaffProjectRole
{
    /// <summary>
    /// CSSysStaffProjectRole构造函数
    /// </summary>
    public CSSysStaffProjectRole()
    {
        // 初始化
    }

    public CSSysStaffProjectRole(string DBConn)
    {
        _DBConn = DBConn;
        // 初始化
    }

    public string DBConn
    {
        get { return _DBConn; }
        set { _DBConn = value; }
    }

    #region 私有属性
    protected string _DBConn;
    protected string _Staff_Id;
    protected string _Project_Id;
    protected string _Role_Id;
    protected int _IsDefault;
    // 属性更新状态
    protected bool _blnStaff_IdChanged = false;
    protected bool _blnProject_IdChanged = false;
    protected bool _blnRole_IdChanged = false;
    protected bool _blnIsDefaultChanged = false;
    #endregion

    /// <summary>
    /// 
    /// </summary>
    public string Staff_Id
    {
        get
        {
            return _Staff_Id;
        }
        set
        {
            if (_blnStaff_IdChanged == false)
            {
                if (_Staff_Id == null && value != null)
                    _blnStaff_IdChanged = true;
                if (_Staff_Id != null && _Staff_Id.CompareTo(value) != 0)
                    _blnStaff_IdChanged = true;
            }
            _Staff_Id = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Project_Id
    {
        get
        {
            return _Project_Id;
        }
        set
        {
            if (_blnProject_IdChanged == false)
            {
                if (_Project_Id == null && value != null)
                    _blnProject_IdChanged = true;
                if (_Project_Id != null && _Project_Id.CompareTo(value) != 0)
                    _blnProject_IdChanged = true;
            }
            _Project_Id = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Role_Id
    {
        get
        {
            return _Role_Id;
        }
        set
        {
            if (_blnRole_IdChanged == false)
            {
                if (_Role_Id == null && value != null)
                    _blnRole_IdChanged = true;
                if (_Role_Id != null && _Role_Id.CompareTo(value) != 0)
                    _blnRole_IdChanged = true;
            }
            _Role_Id = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int IsDefault
    {
        get
        {
            return _IsDefault;
        }
        set
        {
            if (_blnIsDefaultChanged == false)
            {
                //if (_IsDefault.CompareTo(value) != 0)
                _blnIsDefaultChanged = true;
            }
            _IsDefault = value;
        }
    }

    /// <summary>
    /// 对象更新操作状态
    /// </summary>
    private string _updateStatus;

    /// <summary>
    /// SSysStaffProjectRole对象Insert方法
    /// </summary>
    public bool Insert()
    {
        return executeInsert();
    }

    /// <summary>
    /// SSysStaffProjectRole对象Delete方法
    /// </summary>
    public bool Delete()
    {
        return executeDelete();
    }

    /// <summary>
    /// SSysStaffProjectRole对象Update方法
    /// </summary>
    public bool Update()
    {
        return executeUpdate();
    }

    /// <summary>
    /// 取SSysStaffProjectRole对象信息方法
    /// 通过对象属性得到方法返回值
    /// </summary>
    public bool GetInfo()
    {
        return executeGetInfo();
    }

    /// <summary>
    /// SSysStaffProjectRole对象查询数据表方法
    /// </summary>
    public DataTable GetDataTable()
    {
        return executeGetDataTable();
    }

    /// <summary>
    /// SSysStaffProjectRole对象查询数据表方法
    /// </summary>
    public DataTable GetDataTable(bool blnLike)
    {
        if (blnLike == true)
        {
            return executeGetDataTableLike();
        }
        else
        {
            return executeGetDataTable();
        }
    }

    #region executeInsert
    /// <summary>
    /// SSysStaffProjectRole对象Insert方法
    /// </summary>
    private bool executeInsert()
    {
        throw new Exception("The method or operation is not implemented.");
    }
    #endregion

    #region executeDelete
    /// <summary>
    /// SSysStaffProjectRole对象Delete方法
    /// </summary>
    private bool executeDelete()
    {
        bool blnFirstField = true;
        string sql = "delete from SSysStaffProjectRole where ";
        // (Staff_Id)字段
        if (_blnStaff_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Staff_Id = '" + _Staff_Id + "'";
        }
        // (Project_Id)字段
        if (_blnProject_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Project_Id = '" + _Project_Id + "'";
        }
        // (Role_Id)字段
        if (_blnRole_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Role_Id = '" + _Role_Id + "'";
        }
        // (IsDefault)字段
        if (_blnIsDefaultChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "IsDefault = " + _IsDefault.ToString();
        }
        try
        {
            MDataBase db = new MDataBase(_DBConn);
            db.executeDelete(sql);

            return true;
        }
        catch (Exception err)
        {
            throw;
            return false;
        }
    }
    #endregion

    #region executeUpdate
    /// <summary>
    /// SSysStaffProjectRole对象Update方法
    /// </summary>
    private bool executeUpdate()
    {
        throw new Exception("The method or operation is not implemented.");
    }
    #endregion

    #region executeGetInfo
    /// <summary>
    /// SSysStaffProjectRole对象GetInfo方法
    /// </summary>
    private bool executeGetInfo()
    {
        bool blnFirstField = true;
        string sql = "select * from SSysStaffProjectRole";
        // (Staff_Id)字段
        if (_blnStaff_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "Staff_Id = '" + _Staff_Id + "'";
        }
        // (Project_Id)字段
        if (_blnProject_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "Project_Id = '" + _Project_Id + "'";
        }
        // (Role_Id)字段
        if (_blnRole_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "Role_Id = '" + _Role_Id + "'";
        }
        // (IsDefault)字段
        if (_blnIsDefaultChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "IsDefault = " + _IsDefault.ToString();
        }

        try
        {
            MDataBase db = new MDataBase(_DBConn);
            DataRow dr;
            bool blnReturnCode = db.GetDataRow(sql, out dr);
            if (blnReturnCode == false || dr == null)
            {
                return false;
            }

            // 对属性赋值
            try
            {
                _Staff_Id = dr["Staff_Id"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _Project_Id = dr["Project_Id"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _Role_Id = dr["Role_Id"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _IsDefault = Convert.ToInt32(dr["IsDefault"]);
            }
            catch (Exception err)
            { }

            return true;
        }
        catch (Exception err)
        {
            throw;
            return false;
        }
    }
    #endregion

    #region executeGetDataTable
    /// <summary>
    /// SSysStaffProjectRole对象GetDataTable方法
    /// </summary>
    private DataTable executeGetDataTable()
    {
        bool blnFirstField = true;
        string sql = "select * from SSysStaffProjectRole";
        // (Staff_Id)字段
        if (_blnStaff_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "Staff_Id like '%" + _Staff_Id + "%'";
        }
        // (Project_Id)字段
        if (_blnProject_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "Project_Id like '%" + _Project_Id + "%'";
        }
        // (Role_Id)字段
        if (_blnRole_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "Role_Id like '%" + _Role_Id + "%'";
        }
        // (IsDefault)字段
        if (_blnIsDefaultChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "IsDefault = " + _IsDefault.ToString();
        }

        try
        {
            MDataBase db = new MDataBase(_DBConn);
            DataTable dt;
            bool blnReturnCode = db.GetDataTable(sql, out dt);
            if (blnReturnCode == false || dt == null)
            {
                return null;
            }

            return dt;
        }
        catch (Exception err)
        {
            throw;
            return null;
        }
    }
    #endregion

    #region executeGetDataTableLike
    /// <summary>
    /// SSysStaffProjectRole对象GetDataTable方法
    /// </summary>
    private DataTable executeGetDataTableLike()
    {
        bool blnFirstField = true;
        string sql = "select * from SSysStaffProjectRole";
        // (Staff_Id)字段
        if (_blnStaff_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "Staff_Id like '%" + _Staff_Id + "%'";
        }
        // (Project_Id)字段
        if (_blnProject_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "Project_Id like '%" + _Project_Id + "%'";
        }
        // (Role_Id)字段
        if (_blnRole_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "Role_Id like '%" + _Role_Id + "%'";
        }
        // (IsDefault)字段
        if (_blnIsDefaultChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "IsDefault = " + _IsDefault.ToString();
        }

        try
        {
            MDataBase db = new MDataBase(_DBConn);
            DataTable dt;
            bool blnReturnCode = db.GetDataTable(sql, out dt);
            if (blnReturnCode == false || dt == null)
            {
                return null;
            }

            return dt;
        }
        catch (Exception err)
        {
            throw;
            return null;
        }
    }
    #endregion

}