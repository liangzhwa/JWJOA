//================================================================================
// 模块类别:数据对象模块
// 模块名称:CustomerSensitive数据对象
// 模块版本:1.0.0
// 开发人员:Stone
// 最后日期:2007年09月18日
// 创建日期:2007年09月18日
// 相关模块:
// 模块说明:
//================================================================================

using System;
using System.Data;

/// <summary>
/// CustomerSensitive业务实体对象
/// </summary>
public class CCustomerSensitive
{
	/// <summary>
	/// CCustomerSensitive构造函数
	/// </summary>
	public CCustomerSensitive(string DBConn)
	{
		_DBConn = DBConn;
	}

	#region 私有属性
	protected string _DBConn;

	protected string _SenCustomer_Guid;
	protected string _Mobile;
	protected int _SenPeriod;
	protected DateTime _SenEndTime;
	#region 处理SenEndTime时间区间
	protected DateTime _SenEndTimeStart;
	protected DateTime _SenEndTimeEnd;
	public DateTime SenEndTimeStart
	{
		get { return _SenEndTimeStart;}
		set
		{
			if (_blnSenEndTimeStartChanged == false)
			{
				if (_SenEndTimeStart.CompareTo(value) != 0)
					_blnSenEndTimeStartChanged = true;
			}
			_SenEndTimeStart = value;
		}
	}
	public DateTime SenEndTimeEnd
	{
		get { return _SenEndTimeEnd;}
		set
		{
			if (_blnSenEndTimeEndChanged == false)
			{
				if (_SenEndTimeEnd.CompareTo(value) != 0)
					_blnSenEndTimeEndChanged = true;
			}
			_SenEndTimeEnd = value;
		}
	}
	#endregion
	protected string _CreatedBy;
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
	protected string _ModifiedBy;
	protected DateTime _ModifiedDate;
	#region 处理ModifiedDate时间区间
	protected DateTime _ModifiedDateStart;
	protected DateTime _ModifiedDateEnd;
	public DateTime ModifiedDateStart
	{
		get { return _ModifiedDateStart;}
		set
		{
			if (_blnModifiedDateStartChanged == false)
			{
				if (_ModifiedDateStart.CompareTo(value) != 0)
					_blnModifiedDateStartChanged = true;
			}
			_ModifiedDateStart = value;
		}
	}
	public DateTime ModifiedDateEnd
	{
		get { return _ModifiedDateEnd;}
		set
		{
			if (_blnModifiedDateEndChanged == false)
			{
				if (_ModifiedDateEnd.CompareTo(value) != 0)
					_blnModifiedDateEndChanged = true;
			}
			_ModifiedDateEnd = value;
		}
	}
	#endregion
	// 属性更新状态
	protected bool _blnSenCustomer_GuidChanged = false;
	protected bool _blnMobileChanged = false;
	protected bool _blnSenPeriodChanged = false;
	protected bool _blnSenEndTimeChanged = false;
	protected bool _blnSenEndTimeStartChanged = false;
	protected bool _blnSenEndTimeEndChanged = false;
	protected bool _blnCreatedByChanged = false;
	protected bool _blnCreatedDateChanged = false;
	protected bool _blnCreatedDateStartChanged = false;
	protected bool _blnCreatedDateEndChanged = false;
	protected bool _blnModifiedByChanged = false;
	protected bool _blnModifiedDateChanged = false;
	protected bool _blnModifiedDateStartChanged = false;
	protected bool _blnModifiedDateEndChanged = false;
	#endregion

	/// <summary>
	/// 
	/// </summary>
	public string SenCustomer_Guid
	{
		get
		{
			return _SenCustomer_Guid;
		}
		set
		{
			if (_blnSenCustomer_GuidChanged == false)
			{
				if (_SenCustomer_Guid == null && value != null)
					_blnSenCustomer_GuidChanged = true;
				if (_SenCustomer_Guid != null && _SenCustomer_Guid.CompareTo(value) != 0)
					_blnSenCustomer_GuidChanged = true;
			}
			_SenCustomer_Guid = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string Mobile
	{
		get
		{
			return _Mobile;
		}
		set
		{
			if (_blnMobileChanged == false)
			{
				if (_Mobile == null && value != null)
					_blnMobileChanged = true;
				if (_Mobile != null && _Mobile.CompareTo(value) != 0)
					_blnMobileChanged = true;
			}
			_Mobile = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public int SenPeriod
	{
		get
		{
			return _SenPeriod;
		}
		set
		{
			if (_blnSenPeriodChanged == false)
			{
				if (_SenPeriod.CompareTo(value) != 0)
					_blnSenPeriodChanged = true;
			}
			_SenPeriod = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public DateTime SenEndTime
	{
		get
		{
			return _SenEndTime;
		}
		set
		{
			if (_blnSenEndTimeChanged == false)
			{
				if (_SenEndTime.CompareTo(value) != 0)
					_blnSenEndTimeChanged = true;
			}
			_SenEndTime = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string CreatedBy
	{
		get
		{
			return _CreatedBy;
		}
		set
		{
			if (_blnCreatedByChanged == false)
			{
				if (_CreatedBy == null && value != null)
					_blnCreatedByChanged = true;
				if (_CreatedBy != null && _CreatedBy.CompareTo(value) != 0)
					_blnCreatedByChanged = true;
			}
			_CreatedBy = value;
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
	public string ModifiedBy
	{
		get
		{
			return _ModifiedBy;
		}
		set
		{
			if (_blnModifiedByChanged == false)
			{
				if (_ModifiedBy == null && value != null)
					_blnModifiedByChanged = true;
				if (_ModifiedBy != null && _ModifiedBy.CompareTo(value) != 0)
					_blnModifiedByChanged = true;
			}
			_ModifiedBy = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public DateTime ModifiedDate
	{
		get
		{
			return _ModifiedDate;
		}
		set
		{
			if (_blnModifiedDateChanged == false)
			{
				if (_ModifiedDate.CompareTo(value) != 0)
					_blnModifiedDateChanged = true;
			}
			_ModifiedDate = value;
		}
	}

	/// <summary>
	/// 对象更新操作状态
	/// </summary>
	private string _updateStatus;

	/// <summary>
	/// 取CustomerSensitive对象主键的值
	/// </summary>
	public object GetKeyValue()
	{
		return _SenCustomer_Guid;
	}

	/// <summary>
	/// CustomerSensitive对象主键赋值
	/// </summary>
	public bool SetKeyValue(object obj)
	{
		try
		{
			_SenCustomer_Guid = (string)obj;
			return true;
		}
		catch (Exception err)
		{
			throw;
		}
	}

	/// <summary>
	/// CustomerSensitive对象Insert方法
	/// </summary>
	public bool Insert()
	{
		return executeInsert();
	}

	/// <summary>
	/// CustomerSensitive对象Delete方法
	/// </summary>
	public bool Delete()
	{
		return executeDelete();
	}

	/// <summary>
	/// CustomerSensitive对象Update方法
	/// </summary>
	public bool Update()
	{
		return executeUpdate();
	}

	/// <summary>
	/// 取CustomerSensitive对象信息方法
	/// 通过对象属性得到方法返回值
	/// </summary>
	public bool GetInfo()
	{
		return executeGetInfo();
	}

	/// <summary>
	/// CustomerSensitive对象查询数据表方法
	/// </summary>
	public DataTable GetDataTable()
	{
		return executeGetDataTable();
	}

	/// <summary>
	/// CustomerSensitive对象查询数据表方法
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
	/// CustomerSensitive对象Insert方法
	/// </summary>
	private bool executeInsert()
	{
		bool blnFirstField = true;
		string sql = "insert into CustomerSensitive(";
		string sqlTmp = " values(";
		// (SenCustomer_Guid)字段
		if (_blnSenCustomer_GuidChanged == true)
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
			sql += "SenCustomer_Guid";
			sqlTmp += "'" + _SenCustomer_Guid + "'";
		}
		// (Mobile)字段
		if (_blnMobileChanged == true)
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
			sql += "Mobile";
			sqlTmp += "'" + _Mobile + "'";
		}
		// (SenPeriod)字段
		if (_blnSenPeriodChanged == true)
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
			sql += "SenPeriod";
			sqlTmp += _SenPeriod.ToString();
		}
		// (SenEndTime)字段
		if (_blnSenEndTimeChanged == true)
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
			sql += "SenEndTime";
			sqlTmp += "'" + _SenEndTime.ToString() + "'";
		}
		// (CreatedBy)字段
		if (_blnCreatedByChanged == true)
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
			sql += "CreatedBy";
			sqlTmp += "'" + _CreatedBy + "'";
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
		sql += ")" + sqlTmp + ")";
		try
		{
			MDataBase db = new MDataBase(_DBConn);
			db.executeInsert(sql);

			return true;
		}
		catch(Exception err)
		{
			throw;
			return false;
		}
	}
	#endregion

	#region executeDelete
	/// <summary>
	/// CustomerSensitive对象Delete方法
	/// </summary>
	private bool executeDelete()
	{
		bool blnFirstField = true;
		string sql = "delete from CustomerSensitive where ";
		// (SenCustomer_Guid)字段
		if (_blnSenCustomer_GuidChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "SenCustomer_Guid = '" + _SenCustomer_Guid + "'";
		}
		// (Mobile)字段
		if (_blnMobileChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "Mobile = '" + _Mobile + "'";
		}
		// (SenPeriod)字段
		if (_blnSenPeriodChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "SenPeriod = " + _SenPeriod.ToString();
		}
		// (SenEndTime)字段
		if (_blnSenEndTimeChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "SenEndTime = '" + _SenEndTime.ToString() + "'";
		}
		// (CreatedBy)字段
		if (_blnCreatedByChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "CreatedBy = '" + _CreatedBy + "'";
		}
		// (CreatedDate)字段
		if (_blnCreatedDateChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "CreatedDate = '" + _CreatedDate.ToString() + "'";
		}
		// (ModifiedBy)字段
		if (_blnModifiedByChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "ModifiedBy = '" + _ModifiedBy + "'";
		}
		// (ModifiedDate)字段
		if (_blnModifiedDateChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "ModifiedDate = '" + _ModifiedDate.ToString() + "'";
		}
		try
		{
			MDataBase db = new MDataBase(_DBConn);
			db.executeDelete(sql);

			return true;
		}
		catch(Exception err)
		{
			throw;
			return false;
		}
	}
	#endregion

	#region executeUpdate
	/// <summary>
	/// CustomerSensitive对象Update方法
	/// </summary>
	private bool executeUpdate()
	{
		bool blnFirstField = true;
		string sql = "update CustomerSensitive set ";
		string sqlPK = " where ";
		// (SenCustomer_Guid)字段
			sqlPK += "SenCustomer_Guid = '" + _SenCustomer_Guid + "'";
		// (Mobile)字段
		if (_blnMobileChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "Mobile = '" + _Mobile + "'";
		}
		// (SenPeriod)字段
		if (_blnSenPeriodChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "SenPeriod = " + _SenPeriod.ToString();
		}
		// (SenEndTime)字段
		if (_blnSenEndTimeChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "SenEndTime = '" + _SenEndTime.ToString() + "'";
		}
		// (ModifiedBy)字段
		if (_blnModifiedByChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "ModifiedBy = '" + _ModifiedBy + "'";
		}
		// (ModifiedDate)字段
		if (blnFirstField == true)
		{
			blnFirstField = false;
		}
		else
		{
			sql += ",";
		}
		sql += "ModifiedDate=GETDATE()";
		sql += sqlPK;
		try
		{
			MDataBase db = new MDataBase(_DBConn);
			int intCount = db.executeUpdate(sql);

			return true;
		}
		catch(Exception err)
		{
			throw;
			return false;
		}
	}
	#endregion

	#region executeGetInfo
	/// <summary>
	/// CustomerSensitive对象GetInfo方法
	/// </summary>
	private bool executeGetInfo()
	{
		bool blnFirstField = true;
		string sql = "select * from CustomerSensitive";
		// (SenCustomer_Guid)字段
		if (_blnSenCustomer_GuidChanged == true)
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
			sql += "SenCustomer_Guid = '" + _SenCustomer_Guid + "'";
		}
		// (Mobile)字段
		if (_blnMobileChanged == true)
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
			sql += "Mobile = '" + _Mobile + "'";
		}
		// (SenPeriod)字段
		if (_blnSenPeriodChanged == true)
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
			sql += "SenPeriod = " + _SenPeriod.ToString();
		}
		// (SenEndTime)字段
		if (_blnSenEndTimeChanged == true)
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
			sql += "SenEndTime = '" + _SenEndTime.ToString() + "'";
		}
		// (CreatedBy)字段
		if (_blnCreatedByChanged == true)
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
			sql += "CreatedBy = '" + _CreatedBy + "'";
		}
		// (CreatedDate)字段
		if (_blnCreatedDateChanged == true)
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
			sql += "CreatedDate = '" + _CreatedDate.ToString() + "'";
		}
		// (ModifiedBy)字段
		if (_blnModifiedByChanged == true)
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
			sql += "ModifiedBy = '" + _ModifiedBy + "'";
		}
		// (ModifiedDate)字段
		if (_blnModifiedDateChanged == true)
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
			sql += "ModifiedDate = '" + _ModifiedDate.ToString() + "'";
		}

		try
		{
			MDataBase db = new MDataBase(_DBConn);
			DataRow dr;
			bool blnReturnCode = db.GetDataRow(sql,out dr);
			if (blnReturnCode == false || dr == null)
			{
				return false;
			}

			// 对属性赋值
			try
			{
				_SenCustomer_Guid = dr["SenCustomer_Guid"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_Mobile = dr["Mobile"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_SenPeriod = Convert.ToInt32(dr["SenPeriod"]);
			}
			catch(Exception err)
			{}
			try
			{
				_SenEndTime = Convert.ToDateTime(dr["SenEndTime"]);
			}
			catch(Exception err)
			{}
			try
			{
				_CreatedBy = dr["CreatedBy"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
			}
			catch(Exception err)
			{}
			try
			{
				_ModifiedBy = dr["ModifiedBy"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
			}
			catch(Exception err)
			{}

			return true;
		}
		catch(Exception err)
		{
			throw;
			return false;
		}
	}
	#endregion

	#region executeGetDataTable
	/// <summary>
	/// CustomerSensitive对象GetDataTable方法
	/// </summary>
	private DataTable executeGetDataTable()
	{
		bool blnFirstField = true;
		string sql = "select * from CustomerSensitive";
		// (SenCustomer_Guid)字段
		if (_blnSenCustomer_GuidChanged == true)
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
			sql += "SenCustomer_Guid like '%" + _SenCustomer_Guid + "%'";
		}
		// (Mobile)字段
		if (_blnMobileChanged == true)
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
			sql += "Mobile like '%" + _Mobile + "%'";
		}
		// (SenPeriod)字段
		if (_blnSenPeriodChanged == true)
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
			sql += "SenPeriod = " + _SenPeriod.ToString();
		}
		// (SenEndTime)字段
		if (_blnSenEndTimeChanged == true)
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
			sql += "SenEndTime = '" + _SenEndTime.ToString() + "'";
		}
		// (CreatedBy)字段
		if (_blnCreatedByChanged == true)
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
			sql += "CreatedBy like '%" + _CreatedBy + "%'";
		}
		// (CreatedDate)字段
		if (_blnCreatedDateChanged == true)
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
			sql += "CreatedDate = '" + _CreatedDate.ToString() + "'";
		}
		// (ModifiedBy)字段
		if (_blnModifiedByChanged == true)
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
			sql += "ModifiedBy like '%" + _ModifiedBy + "%'";
		}
		// (ModifiedDate)字段
		if (_blnModifiedDateChanged == true)
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
			sql += "ModifiedDate = '" + _ModifiedDate.ToString() + "'";
		}

		try
		{
			MDataBase db = new MDataBase(_DBConn);
			DataTable dt;
			bool blnReturnCode = db.GetDataTable(sql,out dt);
			if (blnReturnCode == false || dt == null)
			{
				return null;
			}

			return dt;
		}
		catch(Exception err)
		{
			throw;
			return null;
		}
	}
	#endregion

	#region executeGetDataTableLike
	/// <summary>
	/// CustomerSensitive对象GetDataTable方法
	/// </summary>
	private DataTable executeGetDataTableLike()
	{
		bool blnFirstField = true;
		string sql = "select * from CustomerSensitive";
		// (SenCustomer_Guid)字段
		if (_blnSenCustomer_GuidChanged == true)
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
			sql += "SenCustomer_Guid like '%" + _SenCustomer_Guid + "%'";
		}
		// (Mobile)字段
		if (_blnMobileChanged == true)
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
			sql += "Mobile like '%" + _Mobile + "%'";
		}
		// (SenPeriod)字段
		if (_blnSenPeriodChanged == true)
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
			sql += "SenPeriod = " + _SenPeriod.ToString();
		}
		// (SenEndTime)字段
		if ((_blnSenEndTimeStartChanged == true) || (_blnSenEndTimeEndChanged == true))
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
			sql += "SenEndTime BETWEEN '" + _SenEndTimeStart.ToString() + "' AND '" + _SenEndTimeEnd.ToString() + "'";
		}
		// (CreatedBy)字段
		if (_blnCreatedByChanged == true)
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
			sql += "CreatedBy like '%" + _CreatedBy + "%'";
		}
		// (CreatedDate)字段
		if ((_blnCreatedDateStartChanged == true) || (_blnCreatedDateEndChanged == true))
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
			sql += "CreatedDate BETWEEN '" + _CreatedDateStart.ToString() + "' AND '" + _CreatedDateEnd.ToString() + "'";
		}
		// (ModifiedBy)字段
		if (_blnModifiedByChanged == true)
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
			sql += "ModifiedBy like '%" + _ModifiedBy + "%'";
		}
		// (ModifiedDate)字段
		if ((_blnModifiedDateStartChanged == true) || (_blnModifiedDateEndChanged == true))
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
			sql += "ModifiedDate BETWEEN '" + _ModifiedDateStart.ToString() + "' AND '" + _ModifiedDateEnd.ToString() + "'";
		}

		try
		{
			MDataBase db = new MDataBase(_DBConn);
			DataTable dt;
			bool blnReturnCode = db.GetDataTable(sql,out dt);
			if (blnReturnCode == false || dt == null)
			{
				return null;
			}

			return dt;
		}
		catch(Exception err)
		{
			throw;
			return null;
		}
	}
	#endregion

}
