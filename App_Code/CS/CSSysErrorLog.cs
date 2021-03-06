//================================================================================
// 模块类别:数据对象模块
// 模块名称:SSysErrorLog数据对象
// 模块版本:1.0.0
// 开发人员:
// 最后日期:2007年06月21日
// 创建日期:2007年06月21日
// 相关模块:
// 模块说明:
//================================================================================

using System;
using System.Data;
using System.Diagnostics;

/// <summary>
/// SSysErrorLog业务实体对象
/// </summary>
public class CSSysErrorLog
{
	/// <summary>
	/// CSSysErrorLog构造函数
	/// </summary>
	public CSSysErrorLog()
	{
		// 初始化
	}

	#region 私有属性
    private string _DBConn;
	protected string _ID;
	protected string _Message;
	protected string _Src;
	protected DateTime _CreatedDate;
	#region 处理CreatedDate时间区间
	protected DateTime _CreatedDateStart;
	protected DateTime _CreatedDateEnd;
	public DateTime CreatedDateStart
	{
		get { return _CreatedDateStart;}
		set
		{
			if (_blnCreatedDateStartChanged == false)
			{
				if (_CreatedDateStart.CompareTo(value) != 0)
					_blnCreatedDateStartChanged = true;
			}
			_CreatedDateStart = value;
		}
	}
	public DateTime CreatedDateEnd
	{
		get { return _CreatedDateEnd;}
		set
		{
			if (_blnCreatedDateEndChanged == false)
			{
				if (_CreatedDateEnd.CompareTo(value) != 0)
					_blnCreatedDateEndChanged = true;
			}
			_CreatedDateEnd = value;
		}
	}
	#endregion
	protected string _Staff_Id;
	// 属性更新状态
	protected bool _blnIDChanged = false;
	protected bool _blnMessageChanged = false;
	protected bool _blnSrcChanged = false;
	protected bool _blnCreatedDateChanged = false;
	protected bool _blnCreatedDateStartChanged = false;
	protected bool _blnCreatedDateEndChanged = false;
	protected bool _blnStaff_IdChanged = false;
	#endregion

    public string DBConn
    {
        get { return _DBConn; }
    }

	/// <summary>
	/// 
	/// </summary>
	public string ID
	{
		get
		{
			return _ID;
		}
		set
		{
			if (_blnIDChanged == false)
			{
				if (_ID == null && value != null)
					_blnIDChanged = true;
				if (_ID != null && _ID.CompareTo(value) != 0)
					_blnIDChanged = true;
			}
			_ID = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string Message
	{
		get
		{
			return _Message;
		}
		set
		{
			if (_blnMessageChanged == false)
			{
				if (_Message == null && value != null)
					_blnMessageChanged = true;
				if (_Message != null && _Message.CompareTo(value) != 0)
					_blnMessageChanged = true;
			}
			_Message = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string Src
	{
		get
		{
			return _Src;
		}
		set
		{
			if (_blnSrcChanged == false)
			{
				if (_Src == null && value != null)
					_blnSrcChanged = true;
				if (_Src != null && _Src.CompareTo(value) != 0)
					_blnSrcChanged = true;
			}
			_Src = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public DateTime CreatedDate
	{
		get
		{
			return _CreatedDate;
		}
		set
		{
			if (_blnCreatedDateChanged == false)
			{
				if (_CreatedDate.CompareTo(value) != 0)
					_blnCreatedDateChanged = true;
			}
			_CreatedDate = value;
		}
	}

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
	/// 对象更新操作状态
	/// </summary>
	private string _updateStatus;

	/// <summary>
	/// 取SSysErrorLog对象主键的值
	/// </summary>
	public object GetKeyValue()
	{
		return _ID;
	}

	/// <summary>
	/// SSysErrorLog对象主键赋值
	/// </summary>
	public bool SetKeyValue(object obj)
	{
		try
		{
			_ID = (string)obj;
			return true;
		}
		catch (Exception err)
		{
            eventLog(err);
            return false;
		}
	}

	/// <summary>
	/// SSysErrorLog对象Insert方法
	/// </summary>
	public bool Insert()
	{
		return executeInsert();
    }

    #region 
    ///// <summary>
    ///// SSysErrorLog对象Delete方法
    ///// </summary>
    //public bool Delete()
    //{
    //    return executeDelete();
    //}

    ///// <summary>
    ///// SSysErrorLog对象Update方法
    ///// </summary>
    //public bool Update()
    //{
    //    return executeUpdate();
    //}

    ///// <summary>
    ///// 取SSysErrorLog对象信息方法
    ///// 通过对象属性得到方法返回值
    ///// </summary>
    //public bool GetInfo()
    //{
    //    return executeGetInfo();
    //}

    ///// <summary>
    ///// SSysErrorLog对象查询数据表方法
    ///// </summary>
    //public DataTable GetDataTable()
    //{
    //    return executeGetDataTable();
    //}

    ///// <summary>
    ///// SSysErrorLog对象查询数据表方法
    ///// </summary>
    //public DataTable GetDataTable(bool blnLike)
    //{
    //    if (blnLike == true)
    //    {
    //        return executeGetDataTableLike();
    //    }
    //    else
    //    {
    //        return executeGetDataTable();
    //    }
    //}
    #endregion
    #region executeInsert
    /// <summary>
	/// SSysErrorLog对象Insert方法
	/// </summary>
	private bool executeInsert()
	{
		bool blnFirstField = true;
		string sql = "insert into SSysErrorLog(";
		string sqlTmp = " values(";
		// (ID)字段
		if (_blnIDChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
				sqlTmp += ",";
			}
			sql += "ID";
			sqlTmp += "'" + _ID + "'";
		}
		// (Message)字段
		if (_blnMessageChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
				sqlTmp += ",";
			}
			sql += "Message";
			sqlTmp += "'" + _Message + "'";
		}
		// (Src)字段
		if (_blnSrcChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
				sqlTmp += ",";
			}
			sql += "Src";
			sqlTmp += "'" + _Src + "'";
		}
		// (CreatedDate)字段
		if (blnFirstField == true)
		{
			blnFirstField = false;
		}
		else
		{
			sql += ",";
			sqlTmp += ",";
		}
		sql += "CreatedDate";
		sqlTmp += "GETDATE()";
		// (Staff_Id)字段
		if (_blnStaff_IdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
				sqlTmp += ",";
			}
			sql += "Staff_Id";
			sqlTmp += "'" + _Staff_Id + "'";
		}
		sql += ")" + sqlTmp + ")";
		try
		{
            MDataBase db = new MDataBase(_DBConn);
			db.executeInsert(sql);

			return true;
		}
		catch(Exception err)
		{
            eventLog(err);
			return false;
		}
	}
	#endregion

    private void eventLog(Exception err)
    {
        try
        {
            EventLog eventLogObj = new EventLog("Application");
            eventLogObj.Source = "Interface Application";
            eventLogObj.WriteEntry(
                "Error Message:" + err.Message + "\r\n" +
                "Error Source:" + err.Source + "\r\n" +
                "Error StackTrace:" + err.StackTrace + "\r\n" +
                "Error TargetSite:" + err.TargetSite + "\r\n"
                );
            eventLogObj.Close();
        }
        catch
        {
            return;
        }
    }
    #region 无用
    //#region executeDelete
    ///// <summary>
    ///// SSysErrorLog对象Delete方法
    ///// </summary>
    //private bool executeDelete()
    //{
    //    bool blnFirstField = true;
    //    string sql = "delete from SSysErrorLog where ";
    //    // (ID)字段
    //    if (_blnIDChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "ID = '" + _ID + "'";
    //    }
    //    // (Message)字段
    //    if (_blnMessageChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "Message = '" + _Message + "'";
    //    }
    //    // (Src)字段
    //    if (_blnSrcChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "Src = '" + _Src + "'";
    //    }
    //    // (CreatedDate)字段
    //    if (_blnCreatedDateChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "CreatedDate = '" + _CreatedDate.ToString() + "'";
    //    }
    //    // (Staff_Id)字段
    //    if (_blnStaff_IdChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "Staff_Id = '" + _Staff_Id + "'";
    //    }
    //    try
    //    {
    //        MDataBase db = new MDataBase(Config.ConnetionString);
    //        db.executeDelete(sql);

    //        return true;
    //    }
    //    catch(Exception err)
    //    {
    //        throw;
    //        return false;
    //    }
    //}
    //#endregion

    //#region executeUpdate
    ///// <summary>
    ///// SSysErrorLog对象Update方法
    ///// </summary>
    //private bool executeUpdate()
    //{
    //    bool blnFirstField = true;
    //    string sql = "update SSysErrorLog set ";
    //    string sqlPK = " where ";
    //    // (ID)字段
    //        sqlPK += "ID = '" + _ID + "'";
    //    // (Message)字段
    //    if (_blnMessageChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //        }
    //        else
    //        {
    //            sql += ",";
    //        }
    //        sql += "Message = '" + _Message + "'";
    //    }
    //    // (Src)字段
    //    if (_blnSrcChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //        }
    //        else
    //        {
    //            sql += ",";
    //        }
    //        sql += "Src = '" + _Src + "'";
    //    }
    //    // (Staff_Id)字段
    //    if (_blnStaff_IdChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //        }
    //        else
    //        {
    //            sql += ",";
    //        }
    //        sql += "Staff_Id = '" + _Staff_Id + "'";
    //    }
    //    sql += sqlPK;
    //    try
    //    {
    //        MDataBase db = new MDataBase(Config.ConnetionString);
    //        int intCount = db.executeUpdate(sql);

    //        return true;
    //    }
    //    catch(Exception err)
    //    {
    //        throw;
    //        return false;
    //    }
    //}
    //#endregion

    //#region executeGetInfo
    ///// <summary>
    ///// SSysErrorLog对象GetInfo方法
    ///// </summary>
    //private bool executeGetInfo()
    //{
    //    bool blnFirstField = true;
    //    string sql = "select * from SSysErrorLog";
    //    // (ID)字段
    //    if (_blnIDChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "ID = '" + _ID + "'";
    //    }
    //    // (Message)字段
    //    if (_blnMessageChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "Message = '" + _Message + "'";
    //    }
    //    // (Src)字段
    //    if (_blnSrcChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "Src = '" + _Src + "'";
    //    }
    //    // (CreatedDate)字段
    //    if (_blnCreatedDateChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "CreatedDate = '" + _CreatedDate.ToString() + "'";
    //    }
    //    // (Staff_Id)字段
    //    if (_blnStaff_IdChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "Staff_Id = '" + _Staff_Id + "'";
    //    }

    //    try
    //    {
    //        MDataBase db = new MDataBase(Config.ConnetionString);
    //        DataRow dr;
    //        bool blnReturnCode = db.GetDataRow(sql,out dr);
    //        if (blnReturnCode == false || dr == null)
    //        {
    //            return false;
    //        }

    //        // 对属性赋值
    //        try
    //        {
    //            _ID = dr["ID"].ToString();
    //        }
    //        catch(Exception err)
    //        {}
    //        try
    //        {
    //            _Message = dr["Message"].ToString();
    //        }
    //        catch(Exception err)
    //        {}
    //        try
    //        {
    //            _Src = dr["Src"].ToString();
    //        }
    //        catch(Exception err)
    //        {}
    //        try
    //        {
    //            _CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
    //        }
    //        catch(Exception err)
    //        {}
    //        try
    //        {
    //            _Staff_Id = dr["Staff_Id"].ToString();
    //        }
    //        catch(Exception err)
    //        {}

    //        return true;
    //    }
    //    catch(Exception err)
    //    {
    //        throw;
    //        return false;
    //    }
    //}
    //#endregion

    //#region executeGetDataTable
    ///// <summary>
    ///// SSysErrorLog对象GetDataTable方法
    ///// </summary>
    //private DataTable executeGetDataTable()
    //{
    //    bool blnFirstField = true;
    //    string sql = "select * from SSysErrorLog";
    //    // (ID)字段
    //    if (_blnIDChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "ID like '%" + _ID + "%'";
    //    }
    //    // (Message)字段
    //    if (_blnMessageChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "Message like '%" + _Message + "%'";
    //    }
    //    // (Src)字段
    //    if (_blnSrcChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "Src like '%" + _Src + "%'";
    //    }
    //    // (CreatedDate)字段
    //    if (_blnCreatedDateChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "CreatedDate = '" + _CreatedDate.ToString() + "'";
    //    }
    //    // (Staff_Id)字段
    //    if (_blnStaff_IdChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "Staff_Id like '%" + _Staff_Id + "%'";
    //    }

    //    try
    //    {
    //        MDataBase db = new MDataBase(Config.ConnetionString);
    //        DataTable dt;
    //        bool blnReturnCode = db.GetDataTable(sql,out dt);
    //        if (blnReturnCode == false || dt == null)
    //        {
    //            return null;
    //        }

    //        return dt;
    //    }
    //    catch(Exception err)
    //    {
    //        throw;
    //        return null;
    //    }
    //}
    //#endregion

    //#region executeGetDataTableLike
    ///// <summary>
    ///// SSysErrorLog对象GetDataTable方法
    ///// </summary>
    //private DataTable executeGetDataTableLike()
    //{
    //    bool blnFirstField = true;
    //    string sql = "select * from SSysErrorLog";
    //    // (ID)字段
    //    if (_blnIDChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "ID like '%" + _ID + "%'";
    //    }
    //    // (Message)字段
    //    if (_blnMessageChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "Message like '%" + _Message + "%'";
    //    }
    //    // (Src)字段
    //    if (_blnSrcChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "Src like '%" + _Src + "%'";
    //    }
    //    // (CreatedDate)字段
    //    if ((_blnCreatedDateStartChanged == true) || (_blnCreatedDateEndChanged == true))
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        if (_CreatedDateStart.ToString().Trim() != "")
    //            sql += "CreatedDate >='" + _CreatedDateStart.ToString().Trim() + "'";
    //        if (_CreatedDateEnd.ToString().Trim() != "")
    //            sql += "CreatedDate <='" + _CreatedDateEnd.ToString().Trim() + "'";
    //    }
    //    // (Staff_Id)字段
    //    if (_blnStaff_IdChanged == true)
    //    {
    //        if (blnFirstField == true)
    //        {
    //            blnFirstField = false;
    //            sql += " WHERE ";
    //        }
    //        else
    //        {
    //            sql += " AND ";
    //        }
    //        sql += "Staff_Id like '%" + _Staff_Id + "%'";
    //    }

    //    try
    //    {
    //        MDataBase db = new MDataBase(Config.ConnetionString);
    //        DataTable dt;
    //        bool blnReturnCode = db.GetDataTable(sql,out dt);
    //        if (blnReturnCode == false || dt == null)
    //        {
    //            return null;
    //        }

    //        return dt;
    //    }
    //    catch(Exception err)
    //    {
    //        throw;
    //        return null;
    //    }
    //}
    //#endregion
    #endregion
}
