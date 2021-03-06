//================================================================================
// 模块类别:数据对象模块
// 模块名称:SCtiStaffs数据对象
// 模块版本:1.0.0
// 开发人员:stone
// 最后日期:2007年06月22日
// 创建日期:2007年06月22日
// 相关模块:
// 模块说明:
//================================================================================

using System;
using System.Data;

/// <summary>
/// SCtiStaffs业务实体对象
/// </summary>
public class CSCtiStaffs
{
	/// <summary>
	/// CSCtiStaffs构造函数
	/// </summary>
	public CSCtiStaffs(string DBConn)
	{
		_DBConn = DBConn;
	}

	#region 私有属性
	protected string _DBConn;
	protected string _Staff_Id;
	protected string _Username;
	protected string _Name;
	protected string _Password;
	protected DateTime _PasswordDate;

	#region 处理PasswordDate时间区间
	protected DateTime _PasswordDateStart;
	protected DateTime _PasswordDateEnd;
	public DateTime PasswordDateStart
	{
		get { return _PasswordDateStart;}
		set
		{
			if (_blnPasswordDateStartChanged == false)
			{
				if (_PasswordDateStart.CompareTo(value) != 0)
					_blnPasswordDateStartChanged = true;
			}
			_PasswordDateStart = value;
		}
	}
	public DateTime PasswordDateEnd
	{
		get { return _PasswordDateEnd;}
		set
		{
			if (_blnPasswordDateEndChanged == false)
			{
				if (_PasswordDateEnd.CompareTo(value) != 0)
					_blnPasswordDateEndChanged = true;
			}
			_PasswordDateEnd = value;
		}
	}
	#endregion
	protected int _IsMonitor;
	protected int _WorkStatusId;
	protected string _Creater_Id;
	protected DateTime _CreateDate;

	#region 处理CreateDate时间区间
	protected DateTime _CreateDateStart;
	protected DateTime _CreateDateEnd;
	public DateTime CreateDateStart
	{
		get { return _CreateDateStart;}
		set
		{
			if (_blnCreateDateStartChanged == false)
			{
				if (_CreateDateStart.CompareTo(value) != 0)
					_blnCreateDateStartChanged = true;
			}
			_CreateDateStart = value;
		}
	}
	public DateTime CreateDateEnd
	{
		get { return _CreateDateEnd;}
		set
		{
			if (_blnCreateDateEndChanged == false)
			{
				if (_CreateDateEnd.CompareTo(value) != 0)
					_blnCreateDateEndChanged = true;
			}
			_CreateDateEnd = value;
		}
	}
	#endregion
	protected string _Modifier_Id;
	protected DateTime _ModifyDate;

	#region 处理ModifyDate时间区间
	protected DateTime _ModifyDateStart;
	protected DateTime _ModifyDateEnd;
	public DateTime ModifyDateStart
	{
		get { return _ModifyDateStart;}
		set
		{
			if (_blnModifyDateStartChanged == false)
			{
				if (_ModifyDateStart.CompareTo(value) != 0)
					_blnModifyDateStartChanged = true;
			}
			_ModifyDateStart = value;
		}
	}
	public DateTime ModifyDateEnd
	{
		get { return _ModifyDateEnd;}
		set
		{
			if (_blnModifyDateEndChanged == false)
			{
				if (_ModifyDateEnd.CompareTo(value) != 0)
					_blnModifyDateEndChanged = true;
			}
			_ModifyDateEnd = value;
		}
	}
	#endregion
	protected string _Superior_Id;
	protected string _Dept_Id;
	protected int _GenderId;
	protected string _StrField;
	protected int _IntField;
	protected int _InUse;
	protected string _Server_Id;
	protected int _LoginTimes;
	protected DateTime _LastLoginTime;

	#region 处理LastLoginTime时间区间
	protected DateTime _LastLoginTimeStart;
	protected DateTime _LastLoginTimeEnd;
	public DateTime LastLoginTimeStart
	{
		get { return _LastLoginTimeStart;}
		set
		{
			if (_blnLastLoginTimeStartChanged == false)
			{
				if (_LastLoginTimeStart.CompareTo(value) != 0)
					_blnLastLoginTimeStartChanged = true;
			}
			_LastLoginTimeStart = value;
		}
	}
	public DateTime LastLoginTimeEnd
	{
		get { return _LastLoginTimeEnd;}
		set
		{
			if (_blnLastLoginTimeEndChanged == false)
			{
				if (_LastLoginTimeEnd.CompareTo(value) != 0)
					_blnLastLoginTimeEndChanged = true;
			}
			_LastLoginTimeEnd = value;
		}
	}
	#endregion
	protected DateTime _LastLogoutTime;

	#region 处理LastLogoutTime时间区间
	protected DateTime _LastLogoutTimeStart;
	protected DateTime _LastLogoutTimeEnd;
	public DateTime LastLogoutTimeStart
	{
		get { return _LastLogoutTimeStart;}
		set
		{
			if (_blnLastLogoutTimeStartChanged == false)
			{
				if (_LastLogoutTimeStart.CompareTo(value) != 0)
					_blnLastLogoutTimeStartChanged = true;
			}
			_LastLogoutTimeStart = value;
		}
	}
	public DateTime LastLogoutTimeEnd
	{
		get { return _LastLogoutTimeEnd;}
		set
		{
			if (_blnLastLogoutTimeEndChanged == false)
			{
				if (_LastLogoutTimeEnd.CompareTo(value) != 0)
					_blnLastLogoutTimeEndChanged = true;
			}
			_LastLogoutTimeEnd = value;
		}
	}
	#endregion
	protected int _TotalUseTime;
	protected int _StatusId;

	// 属性更新状态
	protected bool _blnStaff_IdChanged = false;
	protected bool _blnUsernameChanged = false;
	protected bool _blnNameChanged = false;
	protected bool _blnPasswordChanged = false;
	protected bool _blnPasswordDateChanged = false;
	protected bool _blnPasswordDateStartChanged = false;
	protected bool _blnPasswordDateEndChanged = false;
	protected bool _blnIsMonitorChanged = false;
	protected bool _blnWorkStatusIdChanged = false;
	protected bool _blnCreater_IdChanged = false;
	protected bool _blnCreateDateChanged = false;
	protected bool _blnCreateDateStartChanged = false;
	protected bool _blnCreateDateEndChanged = false;
	protected bool _blnModifier_IdChanged = false;
	protected bool _blnModifyDateChanged = false;
	protected bool _blnModifyDateStartChanged = false;
	protected bool _blnModifyDateEndChanged = false;
	protected bool _blnSuperior_IdChanged = false;
	protected bool _blnDept_IdChanged = false;
	protected bool _blnGenderIdChanged = false;
	protected bool _blnStrFieldChanged = false;
	protected bool _blnIntFieldChanged = false;
	protected bool _blnInUseChanged = false;
	protected bool _blnServer_IdChanged = false;
	protected bool _blnLoginTimesChanged = false;
	protected bool _blnLastLoginTimeChanged = false;
	protected bool _blnLastLoginTimeStartChanged = false;
	protected bool _blnLastLoginTimeEndChanged = false;
	protected bool _blnLastLogoutTimeChanged = false;
	protected bool _blnLastLogoutTimeStartChanged = false;
	protected bool _blnLastLogoutTimeEndChanged = false;
	protected bool _blnTotalUseTimeChanged = false;
	protected bool _blnStatusIdChanged = false;
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
	public string Username
	{
		get
		{
			return _Username;
		}
		set
		{
			if (_blnUsernameChanged == false)
			{
				if (_Username == null && value != null)
					_blnUsernameChanged = true;
				if (_Username != null && _Username.CompareTo(value) != 0)
					_blnUsernameChanged = true;
			}
			_Username = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string Name
	{
		get
		{
			return _Name;
		}
		set
		{
			if (_blnNameChanged == false)
			{
				if (_Name == null && value != null)
					_blnNameChanged = true;
				if (_Name != null && _Name.CompareTo(value) != 0)
					_blnNameChanged = true;
			}
			_Name = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string Password
	{
		get
		{
			return _Password;
		}
		set
		{
			if (_blnPasswordChanged == false)
			{
				if (_Password == null && value != null)
					_blnPasswordChanged = true;
				if (_Password != null && _Password.CompareTo(value) != 0)
					_blnPasswordChanged = true;
			}
			_Password = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public DateTime PasswordDate
	{
		get
		{
			return _PasswordDate;
		}
		set
		{
			if (_blnPasswordDateChanged == false)
			{
				if (_PasswordDate.CompareTo(value) != 0)
					_blnPasswordDateChanged = true;
			}
			_PasswordDate = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public int IsMonitor
	{
		get
		{
			return _IsMonitor;
		}
		set
		{
			if (_blnIsMonitorChanged == false)
			{
				if (_IsMonitor.CompareTo(value) != 0)
					_blnIsMonitorChanged = true;
			}
			_IsMonitor = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public int WorkStatusId
	{
		get
		{
			return _WorkStatusId;
		}
		set
		{
			if (_blnWorkStatusIdChanged == false)
			{
				if (_WorkStatusId.CompareTo(value) != 0)
					_blnWorkStatusIdChanged = true;
			}
			_WorkStatusId = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string Creater_Id
	{
		get
		{
			return _Creater_Id;
		}
		set
		{
			if (_blnCreater_IdChanged == false)
			{
				if (_Creater_Id == null && value != null)
					_blnCreater_IdChanged = true;
				if (_Creater_Id != null && _Creater_Id.CompareTo(value) != 0)
					_blnCreater_IdChanged = true;
			}
			_Creater_Id = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public DateTime CreateDate
	{
		get
		{
			return _CreateDate;
		}
		set
		{
			if (_blnCreateDateChanged == false)
			{
				if (_CreateDate.CompareTo(value) != 0)
					_blnCreateDateChanged = true;
			}
			_CreateDate = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string Modifier_Id
	{
		get
		{
			return _Modifier_Id;
		}
		set
		{
			if (_blnModifier_IdChanged == false)
			{
				if (_Modifier_Id == null && value != null)
					_blnModifier_IdChanged = true;
				if (_Modifier_Id != null && _Modifier_Id.CompareTo(value) != 0)
					_blnModifier_IdChanged = true;
			}
			_Modifier_Id = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public DateTime ModifyDate
	{
		get
		{
			return _ModifyDate;
		}
		set
		{
			if (_blnModifyDateChanged == false)
			{
				if (_ModifyDate.CompareTo(value) != 0)
					_blnModifyDateChanged = true;
			}
			_ModifyDate = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string Superior_Id
	{
		get
		{
			return _Superior_Id;
		}
		set
		{
			if (_blnSuperior_IdChanged == false)
			{
				if (_Superior_Id == null && value != null)
					_blnSuperior_IdChanged = true;
				if (_Superior_Id != null && _Superior_Id.CompareTo(value) != 0)
					_blnSuperior_IdChanged = true;
			}
			_Superior_Id = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string Dept_Id
	{
		get
		{
			return _Dept_Id;
		}
		set
		{
			if (_blnDept_IdChanged == false)
			{
				if (_Dept_Id == null && value != null)
					_blnDept_IdChanged = true;
				if (_Dept_Id != null && _Dept_Id.CompareTo(value) != 0)
					_blnDept_IdChanged = true;
			}
			_Dept_Id = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public int GenderId
	{
		get
		{
			return _GenderId;
		}
		set
		{
			if (_blnGenderIdChanged == false)
			{
				if (_GenderId.CompareTo(value) != 0)
					_blnGenderIdChanged = true;
			}
			_GenderId = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string StrField
	{
		get
		{
			return _StrField;
		}
		set
		{
			if (_blnStrFieldChanged == false)
			{
				if (_StrField == null && value != null)
					_blnStrFieldChanged = true;
				if (_StrField != null && _StrField.CompareTo(value) != 0)
					_blnStrFieldChanged = true;
			}
			_StrField = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public int IntField
	{
		get
		{
			return _IntField;
		}
		set
		{
			if (_blnIntFieldChanged == false)
			{
				if (_IntField.CompareTo(value) != 0)
					_blnIntFieldChanged = true;
			}
			_IntField = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public int InUse
	{
		get
		{
			return _InUse;
		}
		set
		{
			if (_blnInUseChanged == false)
			{
				if (_InUse.CompareTo(value) != 0)
					_blnInUseChanged = true;
			}
			_InUse = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string Server_Id
	{
		get
		{
			return _Server_Id;
		}
		set
		{
			if (_blnServer_IdChanged == false)
			{
				if (_Server_Id == null && value != null)
					_blnServer_IdChanged = true;
				if (_Server_Id != null && _Server_Id.CompareTo(value) != 0)
					_blnServer_IdChanged = true;
			}
			_Server_Id = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public int LoginTimes
	{
		get
		{
			return _LoginTimes;
		}
		set
		{
			if (_blnLoginTimesChanged == false)
			{
				if (_LoginTimes.CompareTo(value) != 0)
					_blnLoginTimesChanged = true;
			}
			_LoginTimes = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public DateTime LastLoginTime
	{
		get
		{
			return _LastLoginTime;
		}
		set
		{
			if (_blnLastLoginTimeChanged == false)
			{
				if (_LastLoginTime.CompareTo(value) != 0)
					_blnLastLoginTimeChanged = true;
			}
			_LastLoginTime = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public DateTime LastLogoutTime
	{
		get
		{
			return _LastLogoutTime;
		}
		set
		{
			if (_blnLastLogoutTimeChanged == false)
			{
				if (_LastLogoutTime.CompareTo(value) != 0)
					_blnLastLogoutTimeChanged = true;
			}
			_LastLogoutTime = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public int TotalUseTime
	{
		get
		{
			return _TotalUseTime;
		}
		set
		{
			if (_blnTotalUseTimeChanged == false)
			{
				if (_TotalUseTime.CompareTo(value) != 0)
					_blnTotalUseTimeChanged = true;
			}
			_TotalUseTime = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public int StatusId
	{
		get
		{
			return _StatusId;
		}
		set
		{
			if (_blnStatusIdChanged == false)
			{
				if (_StatusId.CompareTo(value) != 0)
					_blnStatusIdChanged = true;
			}
			_StatusId = value;
		}
	}

	/// <summary>
	/// 对象更新操作状态
	/// </summary>
	private string _updateStatus;

	/// <summary>
	/// 取SCtiStaffs对象主键的值
	/// </summary>
	public object GetKeyValue()
	{
		return _Staff_Id;
	}

	/// <summary>
	/// SCtiStaffs对象主键赋值
	/// </summary>
	public bool SetKeyValue(object obj)
	{
		try
		{
			_Staff_Id = (string)obj;
			return true;
		}
		catch (Exception err)
		{
			throw;
		}
	}

	/// <summary>
	/// SCtiStaffs对象Insert方法
	/// </summary>
	public bool Insert()
	{
		return executeInsert();
	}

	/// <summary>
	/// SCtiStaffs对象Delete方法
	/// </summary>
	public bool Delete()
	{
		return executeDelete();
	}

	/// <summary>
	/// SCtiStaffs对象Update方法
	/// </summary>
	public bool Update()
	{
		return executeUpdate();
	}

	/// <summary>
	/// 取SCtiStaffs对象信息方法
	/// 通过对象属性得到方法返回值
	/// </summary>
	public bool GetInfo()
	{
		return executeGetInfo();
	}

	/// <summary>
	/// SCtiStaffs对象查询数据表方法
	/// </summary>
	public DataTable GetDataTable()
	{
		return executeGetDataTable();
	}

	/// <summary>
	/// SCtiStaffs对象查询数据表方法
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
	/// SCtiStaffs对象Insert方法
	/// </summary>
	private bool executeInsert()
	{
		bool blnFirstField = true;
		string sql = "insert into SCtiStaffs(";
		string sqlTmp = " values(";
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
		// (Username)字段
		if (_blnUsernameChanged == true)
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
			sql += "Username";
			sqlTmp += "'" + _Username + "'";
		}
		// (Name)字段
		if (_blnNameChanged == true)
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
			sql += "Name";
			sqlTmp += "'" + _Name + "'";
		}
		// (Password)字段
		if (_blnPasswordChanged == true)
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
			sql += "Password";
			sqlTmp += "'" + _Password + "'";
		}
		// (PasswordDate)字段
		if (_blnPasswordDateChanged == true)
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
			sql += "PasswordDate";
			sqlTmp += "'" + _PasswordDate.ToString() + "'";
		}
		// (IsMonitor)字段
		if (_blnIsMonitorChanged == true)
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
			sql += "IsMonitor";
			sqlTmp += _IsMonitor.ToString();
		}
		// (WorkStatusId)字段
		if (_blnWorkStatusIdChanged == true)
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
			sql += "WorkStatusId";
			sqlTmp += _WorkStatusId.ToString();
		}
		// (Creater_Id)字段
		if (_blnCreater_IdChanged == true)
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
			sql += "Creater_Id";
			sqlTmp += "'" + _Creater_Id + "'";
		}
		// (CreateDate)字段
		if (_blnCreateDateChanged == true)
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
			sql += "CreateDate";
			sqlTmp += "'" + _CreateDate.ToString() + "'";
		}
		// (Modifier_Id)字段
		if (_blnModifier_IdChanged == true)
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
			sql += "Modifier_Id";
			sqlTmp += "'" + _Modifier_Id + "'";
		}
		// (ModifyDate)字段
		if (_blnModifyDateChanged == true)
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
			sql += "ModifyDate";
			sqlTmp += "'" + _ModifyDate.ToString() + "'";
		}
		// (Superior_Id)字段
		if (_blnSuperior_IdChanged == true)
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
			sql += "Superior_Id";
			sqlTmp += "'" + _Superior_Id + "'";
		}
		// (Dept_Id)字段
		if (_blnDept_IdChanged == true)
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
			sql += "Dept_Id";
			sqlTmp += "'" + _Dept_Id + "'";
		}
		// (GenderId)字段
		if (_blnGenderIdChanged == true)
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
			sql += "GenderId";
			sqlTmp += _GenderId.ToString();
		}
		// (StrField)字段
		if (_blnStrFieldChanged == true)
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
			sql += "StrField";
			sqlTmp += "'" + _StrField + "'";
		}
		// (IntField)字段
		if (_blnIntFieldChanged == true)
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
			sql += "IntField";
			sqlTmp += _IntField.ToString();
		}
		// (InUse)字段
		if (_blnInUseChanged == true)
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
			sql += "InUse";
			sqlTmp += _InUse.ToString();
		}
		// (Server_Id)字段
		if (_blnServer_IdChanged == true)
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
			sql += "Server_Id";
			sqlTmp += "'" + _Server_Id + "'";
		}
		// (LoginTimes)字段
		if (_blnLoginTimesChanged == true)
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
			sql += "LoginTimes";
			sqlTmp += _LoginTimes.ToString();
		}
		// (LastLoginTime)字段
		if (_blnLastLoginTimeChanged == true)
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
			sql += "LastLoginTime";
			sqlTmp += "'" + _LastLoginTime.ToString() + "'";
		}
		// (LastLogoutTime)字段
		if (_blnLastLogoutTimeChanged == true)
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
			sql += "LastLogoutTime";
			sqlTmp += "'" + _LastLogoutTime.ToString() + "'";
		}
		// (TotalUseTime)字段
		if (_blnTotalUseTimeChanged == true)
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
			sql += "TotalUseTime";
			sqlTmp += _TotalUseTime.ToString();
		}
		// (StatusId)字段
		if (_blnStatusIdChanged == true)
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
			sql += "StatusId";
			sqlTmp += _StatusId.ToString();
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
			throw;
			return false;
		}
	}
	#endregion

	#region executeDelete
	/// <summary>
	/// SCtiStaffs对象Delete方法
	/// </summary>
	private bool executeDelete()
	{
		bool blnFirstField = true;
		string sql = "delete from SCtiStaffs where ";
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
		// (Username)字段
		if (_blnUsernameChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "Username = '" + _Username + "'";
		}
		// (Name)字段
		if (_blnNameChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "Name = '" + _Name + "'";
		}
		// (Password)字段
		if (_blnPasswordChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "Password = '" + _Password + "'";
		}
		// (PasswordDate)字段
		if (_blnPasswordDateChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "PasswordDate = '" + _PasswordDate.ToString() + "'";
		}
		// (IsMonitor)字段
		if (_blnIsMonitorChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "IsMonitor = " + _IsMonitor.ToString();
		}
		// (WorkStatusId)字段
		if (_blnWorkStatusIdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "WorkStatusId = " + _WorkStatusId.ToString();
		}
		// (Creater_Id)字段
		if (_blnCreater_IdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "Creater_Id = '" + _Creater_Id + "'";
		}
		// (CreateDate)字段
		if (_blnCreateDateChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "CreateDate = '" + _CreateDate.ToString() + "'";
		}
		// (Modifier_Id)字段
		if (_blnModifier_IdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "Modifier_Id = '" + _Modifier_Id + "'";
		}
		// (ModifyDate)字段
		if (_blnModifyDateChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "ModifyDate = '" + _ModifyDate.ToString() + "'";
		}
		// (Superior_Id)字段
		if (_blnSuperior_IdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "Superior_Id = '" + _Superior_Id + "'";
		}
		// (Dept_Id)字段
		if (_blnDept_IdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "Dept_Id = '" + _Dept_Id + "'";
		}
		// (GenderId)字段
		if (_blnGenderIdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "GenderId = " + _GenderId.ToString();
		}
		// (StrField)字段
		if (_blnStrFieldChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "StrField = '" + _StrField + "'";
		}
		// (IntField)字段
		if (_blnIntFieldChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "IntField = " + _IntField.ToString();
		}
		// (InUse)字段
		if (_blnInUseChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "InUse = " + _InUse.ToString();
		}
		// (Server_Id)字段
		if (_blnServer_IdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "Server_Id = '" + _Server_Id + "'";
		}
		// (LoginTimes)字段
		if (_blnLoginTimesChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "LoginTimes = " + _LoginTimes.ToString();
		}
		// (LastLoginTime)字段
		if (_blnLastLoginTimeChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "LastLoginTime = '" + _LastLoginTime.ToString() + "'";
		}
		// (LastLogoutTime)字段
		if (_blnLastLogoutTimeChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "LastLogoutTime = '" + _LastLogoutTime.ToString() + "'";
		}
		// (TotalUseTime)字段
		if (_blnTotalUseTimeChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "TotalUseTime = " + _TotalUseTime.ToString();
		}
		// (StatusId)字段
		if (_blnStatusIdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "StatusId = " + _StatusId.ToString();
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
	/// SCtiStaffs对象Update方法
	/// </summary>
	private bool executeUpdate()
	{
		bool blnFirstField = true;
		string sql = "update SCtiStaffs set ";
		string sqlPK = " where ";
		// (Staff_Id)字段
			sqlPK += "Staff_Id = '" + _Staff_Id + "'";
		// (Username)字段
		if (_blnUsernameChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "Username = '" + _Username + "'";
		}
		// (Name)字段
		if (_blnNameChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "Name = '" + _Name + "'";
		}
		// (Password)字段
		if (_blnPasswordChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "Password = '" + _Password + "'";
		}
		// (PasswordDate)字段
		if (_blnPasswordDateChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "PasswordDate = '" + _PasswordDate.ToString() + "'";
		}
		// (IsMonitor)字段
		if (_blnIsMonitorChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "IsMonitor = " + _IsMonitor.ToString();
		}
		// (WorkStatusId)字段
		if (_blnWorkStatusIdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "WorkStatusId = " + _WorkStatusId.ToString();
		}
		// (Creater_Id)字段
		if (_blnCreater_IdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "Creater_Id = '" + _Creater_Id + "'";
		}
		// (CreateDate)字段
		if (_blnCreateDateChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "CreateDate = '" + _CreateDate.ToString() + "'";
		}
		// (Modifier_Id)字段
		if (_blnModifier_IdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "Modifier_Id = '" + _Modifier_Id + "'";
		}
		// (ModifyDate)字段
		if (_blnModifyDateChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "ModifyDate = '" + _ModifyDate.ToString() + "'";
		}
		// (Superior_Id)字段
		if (_blnSuperior_IdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "Superior_Id = '" + _Superior_Id + "'";
		}
		// (Dept_Id)字段
		if (_blnDept_IdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "Dept_Id = '" + _Dept_Id + "'";
		}
		// (GenderId)字段
		if (_blnGenderIdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "GenderId = " + _GenderId.ToString();
		}
		// (StrField)字段
		if (_blnStrFieldChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "StrField = '" + _StrField + "'";
		}
		// (IntField)字段
		if (_blnIntFieldChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "IntField = " + _IntField.ToString();
		}
		// (InUse)字段
		if (_blnInUseChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "InUse = " + _InUse.ToString();
		}
		// (Server_Id)字段
		if (_blnServer_IdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "Server_Id = '" + _Server_Id + "'";
		}
		// (LoginTimes)字段
		if (_blnLoginTimesChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "LoginTimes = " + _LoginTimes.ToString();
		}
		// (LastLoginTime)字段
		if (_blnLastLoginTimeChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "LastLoginTime = '" + _LastLoginTime.ToString() + "'";
		}
		// (LastLogoutTime)字段
		if (_blnLastLogoutTimeChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "LastLogoutTime = '" + _LastLogoutTime.ToString() + "'";
		}
		// (TotalUseTime)字段
		if (_blnTotalUseTimeChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "TotalUseTime = " + _TotalUseTime.ToString();
		}
		// (StatusId)字段
		if (_blnStatusIdChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "StatusId = " + _StatusId.ToString();
		}
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
	/// SCtiStaffs对象GetInfo方法
	/// </summary>
	private bool executeGetInfo()
	{
		bool blnFirstField = true;
		string sql = "select * from SSysStaff";
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
		// (Username)字段
		if (_blnUsernameChanged == true)
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
			sql += "Username = '" + _Username + "'";
		}
		// (Name)字段
		if (_blnNameChanged == true)
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
			sql += "Name = '" + _Name + "'";
		}
		// (Password)字段
		if (_blnPasswordChanged == true)
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
			sql += "Password = '" + _Password + "'";
		}
		// (PasswordDate)字段
		if (_blnPasswordDateChanged == true)
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
			sql += "PasswordDate = '" + _PasswordDate.ToString() + "'";
		}
		// (IsMonitor)字段
		if (_blnIsMonitorChanged == true)
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
			sql += "IsMonitor = " + _IsMonitor.ToString();
		}
		// (WorkStatusId)字段
		if (_blnWorkStatusIdChanged == true)
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
			sql += "WorkStatusId = " + _WorkStatusId.ToString();
		}
		// (Creater_Id)字段
		if (_blnCreater_IdChanged == true)
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
			sql += "Creater_Id = '" + _Creater_Id + "'";
		}
		// (CreateDate)字段
		if (_blnCreateDateChanged == true)
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
			sql += "CreateDate = '" + _CreateDate.ToString() + "'";
		}
		// (Modifier_Id)字段
		if (_blnModifier_IdChanged == true)
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
			sql += "Modifier_Id = '" + _Modifier_Id + "'";
		}
		// (ModifyDate)字段
		if (_blnModifyDateChanged == true)
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
			sql += "ModifyDate = '" + _ModifyDate.ToString() + "'";
		}
		// (Superior_Id)字段
		if (_blnSuperior_IdChanged == true)
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
			sql += "Superior_Id = '" + _Superior_Id + "'";
		}
		// (Dept_Id)字段
		if (_blnDept_IdChanged == true)
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
			sql += "Dept_Id = '" + _Dept_Id + "'";
		}
		// (GenderId)字段
		if (_blnGenderIdChanged == true)
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
			sql += "GenderId = " + _GenderId.ToString();
		}
		// (StrField)字段
		if (_blnStrFieldChanged == true)
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
			sql += "StrField = '" + _StrField + "'";
		}
		// (IntField)字段
		if (_blnIntFieldChanged == true)
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
			sql += "IntField = " + _IntField.ToString();
		}
		// (InUse)字段
		if (_blnInUseChanged == true)
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
			sql += "InUse = " + _InUse.ToString();
		}
		// (Server_Id)字段
		if (_blnServer_IdChanged == true)
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
			sql += "Server_Id = '" + _Server_Id + "'";
		}
		// (LoginTimes)字段
		if (_blnLoginTimesChanged == true)
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
			sql += "LoginTimes = " + _LoginTimes.ToString();
		}
		// (LastLoginTime)字段
		if (_blnLastLoginTimeChanged == true)
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
			sql += "LastLoginTime = '" + _LastLoginTime.ToString() + "'";
		}
		// (LastLogoutTime)字段
		if (_blnLastLogoutTimeChanged == true)
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
			sql += "LastLogoutTime = '" + _LastLogoutTime.ToString() + "'";
		}
		// (TotalUseTime)字段
		if (_blnTotalUseTimeChanged == true)
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
			sql += "TotalUseTime = " + _TotalUseTime.ToString();
		}
		// (StatusId)字段
		if (_blnStatusIdChanged == true)
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
			sql += "StatusId = " + _StatusId.ToString();
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
				_Staff_Id = dr["Staff_Id"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_Username = dr["Username"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_Name = dr["Name"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_Password = dr["Password"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_PasswordDate = Convert.ToDateTime(dr["PasswordDate"]);
			}
			catch(Exception err)
			{}
			try
			{
				_IsMonitor = Convert.ToInt32(dr["IsMonitor"]);
			}
			catch(Exception err)
			{}
			try
			{
				_WorkStatusId = Convert.ToInt32(dr["WorkStatusId"]);
			}
			catch(Exception err)
			{}
			try
			{
				_Creater_Id = dr["Creater_Id"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_CreateDate = Convert.ToDateTime(dr["CreateDate"]);
			}
			catch(Exception err)
			{}
			try
			{
				_Modifier_Id = dr["Modifier_Id"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
			}
			catch(Exception err)
			{}
			try
			{
				_Superior_Id = dr["Superior_Id"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_Dept_Id = dr["Dept_Id"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_GenderId = Convert.ToInt32(dr["GenderId"]);
			}
			catch(Exception err)
			{}
			try
			{
				_StrField = dr["StrField"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_IntField = Convert.ToInt32(dr["IntField"]);
			}
			catch(Exception err)
			{}
			try
			{
				_InUse = Convert.ToInt32(dr["InUse"]);
			}
			catch(Exception err)
			{}
			try
			{
				_Server_Id = dr["Server_Id"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_LoginTimes = Convert.ToInt32(dr["LoginTimes"]);
			}
			catch(Exception err)
			{}
			try
			{
				_LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
			}
			catch(Exception err)
			{}
			try
			{
				_LastLogoutTime = Convert.ToDateTime(dr["LastLogoutTime"]);
			}
			catch(Exception err)
			{}
			try
			{
				_TotalUseTime = Convert.ToInt32(dr["TotalUseTime"]);
			}
			catch(Exception err)
			{}
			try
			{
				_StatusId = Convert.ToInt32(dr["StatusId"]);
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
	/// SCtiStaffs对象GetDataTable方法
	/// </summary>
	private DataTable executeGetDataTable()
	{
		bool blnFirstField = true;
		string sql = "select * from SCtiStaffs";
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
		// (Username)字段
		if (_blnUsernameChanged == true)
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
			sql += "Username like '%" + _Username + "%'";
		}
		// (Name)字段
		if (_blnNameChanged == true)
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
			sql += "Name like '%" + _Name + "%'";
		}
		// (Password)字段
		if (_blnPasswordChanged == true)
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
			sql += "Password like '%" + _Password + "%'";
		}
		// (PasswordDate)字段
		if (_blnPasswordDateChanged == true)
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
			sql += "PasswordDate = '" + _PasswordDate.ToString() + "'";
		}
		// (IsMonitor)字段
		if (_blnIsMonitorChanged == true)
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
			sql += "IsMonitor = " + _IsMonitor.ToString();
		}
		// (WorkStatusId)字段
		if (_blnWorkStatusIdChanged == true)
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
			sql += "WorkStatusId = " + _WorkStatusId.ToString();
		}
		// (Creater_Id)字段
		if (_blnCreater_IdChanged == true)
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
			sql += "Creater_Id like '%" + _Creater_Id + "%'";
		}
		// (CreateDate)字段
		if (_blnCreateDateChanged == true)
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
			sql += "CreateDate = '" + _CreateDate.ToString() + "'";
		}
		// (Modifier_Id)字段
		if (_blnModifier_IdChanged == true)
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
			sql += "Modifier_Id like '%" + _Modifier_Id + "%'";
		}
		// (ModifyDate)字段
		if (_blnModifyDateChanged == true)
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
			sql += "ModifyDate = '" + _ModifyDate.ToString() + "'";
		}
		// (Superior_Id)字段
		if (_blnSuperior_IdChanged == true)
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
			sql += "Superior_Id like '%" + _Superior_Id + "%'";
		}
		// (Dept_Id)字段
		if (_blnDept_IdChanged == true)
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
			sql += "Dept_Id like '%" + _Dept_Id + "%'";
		}
		// (GenderId)字段
		if (_blnGenderIdChanged == true)
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
			sql += "GenderId = " + _GenderId.ToString();
		}
		// (StrField)字段
		if (_blnStrFieldChanged == true)
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
			sql += "StrField like '%" + _StrField + "%'";
		}
		// (IntField)字段
		if (_blnIntFieldChanged == true)
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
			sql += "IntField = " + _IntField.ToString();
		}
		// (InUse)字段
		if (_blnInUseChanged == true)
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
			sql += "InUse = " + _InUse.ToString();
		}
		// (Server_Id)字段
		if (_blnServer_IdChanged == true)
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
			sql += "Server_Id like '%" + _Server_Id + "%'";
		}
		// (LoginTimes)字段
		if (_blnLoginTimesChanged == true)
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
			sql += "LoginTimes = " + _LoginTimes.ToString();
		}
		// (LastLoginTime)字段
		if (_blnLastLoginTimeChanged == true)
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
			sql += "LastLoginTime = '" + _LastLoginTime.ToString() + "'";
		}
		// (LastLogoutTime)字段
		if (_blnLastLogoutTimeChanged == true)
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
			sql += "LastLogoutTime = '" + _LastLogoutTime.ToString() + "'";
		}
		// (TotalUseTime)字段
		if (_blnTotalUseTimeChanged == true)
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
			sql += "TotalUseTime = " + _TotalUseTime.ToString();
		}
		// (StatusId)字段
		if (_blnStatusIdChanged == true)
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
			sql += "StatusId = " + _StatusId.ToString();
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
	/// SCtiStaffs对象GetDataTable方法
	/// </summary>
	private DataTable executeGetDataTableLike()
	{
		bool blnFirstField = true;
		string sql = "select * from SCtiStaffs";
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
		// (Username)字段
		if (_blnUsernameChanged == true)
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
			sql += "Username like '%" + _Username + "%'";
		}
		// (Name)字段
		if (_blnNameChanged == true)
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
			sql += "Name like '%" + _Name + "%'";
		}
		// (Password)字段
		if (_blnPasswordChanged == true)
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
			sql += "Password like '%" + _Password + "%'";
		}
		// (PasswordDate)字段
		if ((_blnPasswordDateStartChanged == true) || (_blnPasswordDateEndChanged == true))
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
			sql += "PasswordDate BETWEEN '" + _PasswordDateStart.ToString() + "' AND '" + _PasswordDateEnd.ToString() + "'";
		}
		// (IsMonitor)字段
		if (_blnIsMonitorChanged == true)
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
			sql += "IsMonitor = " + _IsMonitor.ToString();
		}
		// (WorkStatusId)字段
		if (_blnWorkStatusIdChanged == true)
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
			sql += "WorkStatusId = " + _WorkStatusId.ToString();
		}
		// (Creater_Id)字段
		if (_blnCreater_IdChanged == true)
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
			sql += "Creater_Id like '%" + _Creater_Id + "%'";
		}
		// (CreateDate)字段
		if ((_blnCreateDateStartChanged == true) || (_blnCreateDateEndChanged == true))
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
			sql += "CreateDate BETWEEN '" + _CreateDateStart.ToString() + "' AND '" + _CreateDateEnd.ToString() + "'";
		}
		// (Modifier_Id)字段
		if (_blnModifier_IdChanged == true)
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
			sql += "Modifier_Id like '%" + _Modifier_Id + "%'";
		}
		// (ModifyDate)字段
		if ((_blnModifyDateStartChanged == true) || (_blnModifyDateEndChanged == true))
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
			sql += "ModifyDate BETWEEN '" + _ModifyDateStart.ToString() + "' AND '" + _ModifyDateEnd.ToString() + "'";
		}
		// (Superior_Id)字段
		if (_blnSuperior_IdChanged == true)
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
			sql += "Superior_Id like '%" + _Superior_Id + "%'";
		}
		// (Dept_Id)字段
		if (_blnDept_IdChanged == true)
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
			sql += "Dept_Id like '%" + _Dept_Id + "%'";
		}
		// (GenderId)字段
		if (_blnGenderIdChanged == true)
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
			sql += "GenderId = " + _GenderId.ToString();
		}
		// (StrField)字段
		if (_blnStrFieldChanged == true)
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
			sql += "StrField like '%" + _StrField + "%'";
		}
		// (IntField)字段
		if (_blnIntFieldChanged == true)
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
			sql += "IntField = " + _IntField.ToString();
		}
		// (InUse)字段
		if (_blnInUseChanged == true)
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
			sql += "InUse = " + _InUse.ToString();
		}
		// (Server_Id)字段
		if (_blnServer_IdChanged == true)
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
			sql += "Server_Id like '%" + _Server_Id + "%'";
		}
		// (LoginTimes)字段
		if (_blnLoginTimesChanged == true)
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
			sql += "LoginTimes = " + _LoginTimes.ToString();
		}
		// (LastLoginTime)字段
		if ((_blnLastLoginTimeStartChanged == true) || (_blnLastLoginTimeEndChanged == true))
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
			sql += "LastLoginTime BETWEEN '" + _LastLoginTimeStart.ToString() + "' AND '" + _LastLoginTimeEnd.ToString() + "'";
		}
		// (LastLogoutTime)字段
		if ((_blnLastLogoutTimeStartChanged == true) || (_blnLastLogoutTimeEndChanged == true))
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
			sql += "LastLogoutTime BETWEEN '" + _LastLogoutTimeStart.ToString() + "' AND '" + _LastLogoutTimeEnd.ToString() + "'";
		}
		// (TotalUseTime)字段
		if (_blnTotalUseTimeChanged == true)
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
			sql += "TotalUseTime = " + _TotalUseTime.ToString();
		}
		// (StatusId)字段
		if (_blnStatusIdChanged == true)
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
			sql += "StatusId = " + _StatusId.ToString();
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