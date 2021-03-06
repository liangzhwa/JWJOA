//================================================================================
// 模块类别:数据对象模块
// 模块名称:SSysRunParameter数据对象
// 模块版本:1.0.0
// 开发人员:Stone
// 最后日期:2007年09月17日
// 创建日期:2007年09月17日
// 相关模块:
// 模块说明:
//================================================================================

using System;
using System.Data;

/// <summary>
/// SSysRunParameter业务实体对象
/// </summary>
public class CSSysRunParameter
{
	/// <summary>
	/// CSSysRunParameter构造函数
	/// </summary>
	public CSSysRunParameter(string DBConn)
	{
		_DBConn = DBConn;
	}

	#region 私有属性
	protected string _DBConn;

	protected string _Parameter_Guid;
	protected string _ParameterName;
	protected string _ParameterValue;
	protected string _Detail;
	protected int _IsUser;
	// 属性更新状态
	protected bool _blnParameter_GuidChanged = false;
	protected bool _blnParameterNameChanged = false;
	protected bool _blnParameterValueChanged = false;
	protected bool _blnDetailChanged = false;
	protected bool _blnIsUserChanged = false;
	#endregion

	/// <summary>
	/// 
	/// </summary>
	public string Parameter_Guid
	{
		get
		{
			return _Parameter_Guid;
		}
		set
		{
			if (_blnParameter_GuidChanged == false)
			{
				if (_Parameter_Guid == null && value != null)
					_blnParameter_GuidChanged = true;
				if (_Parameter_Guid != null && _Parameter_Guid.CompareTo(value) != 0)
					_blnParameter_GuidChanged = true;
			}
			_Parameter_Guid = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string ParameterName
	{
		get
		{
			return _ParameterName;
		}
		set
		{
			if (_blnParameterNameChanged == false)
			{
				if (_ParameterName == null && value != null)
					_blnParameterNameChanged = true;
				if (_ParameterName != null && _ParameterName.CompareTo(value) != 0)
					_blnParameterNameChanged = true;
			}
			_ParameterName = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string ParameterValue
	{
		get
		{
			return _ParameterValue;
		}
		set
		{
			if (_blnParameterValueChanged == false)
			{
				if (_ParameterValue == null && value != null)
					_blnParameterValueChanged = true;
				if (_ParameterValue != null && _ParameterValue.CompareTo(value) != 0)
					_blnParameterValueChanged = true;
			}
			_ParameterValue = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public string Detail
	{
		get
		{
			return _Detail;
		}
		set
		{
			if (_blnDetailChanged == false)
			{
				if (_Detail == null && value != null)
					_blnDetailChanged = true;
				if (_Detail != null && _Detail.CompareTo(value) != 0)
					_blnDetailChanged = true;
			}
			_Detail = value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public bool IsUser
	{
		get
		{
			if (_IsUser == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		set
		{
			if (_blnIsUserChanged == false)
			{
				if (_IsUser.CompareTo(value) != 0)
					_blnIsUserChanged = true;
			}
			if (value == true)
			{
				_IsUser = 1;
			}
			else
			{
				_IsUser = 0;
			}
		}
	}

	/// <summary>
	/// 对象更新操作状态
	/// </summary>
	private string _updateStatus;

	/// <summary>
	/// 取SSysRunParameter对象主键的值
	/// </summary>
	public object GetKeyValue()
	{
		return _Parameter_Guid;
	}

	/// <summary>
	/// SSysRunParameter对象主键赋值
	/// </summary>
	public bool SetKeyValue(object obj)
	{
		try
		{
			_Parameter_Guid = (string)obj;
			return true;
		}
		catch (Exception err)
		{
			throw;
		}
	}

	/// <summary>
	/// SSysRunParameter对象Insert方法
	/// </summary>
	public bool Insert()
	{
		return executeInsert();
	}

	/// <summary>
	/// SSysRunParameter对象Delete方法
	/// </summary>
	public bool Delete()
	{
		return executeDelete();
	}

	/// <summary>
	/// SSysRunParameter对象Update方法
	/// </summary>
	public bool Update()
	{
		return executeUpdate();
	}

	/// <summary>
	/// 取SSysRunParameter对象信息方法
	/// 通过对象属性得到方法返回值
	/// </summary>
	public bool GetInfo()
	{
		return executeGetInfo();
	}

	/// <summary>
	/// SSysRunParameter对象查询数据表方法
	/// </summary>
	public DataTable GetDataTable()
	{
		return executeGetDataTable();
	}

	/// <summary>
	/// SSysRunParameter对象查询数据表方法
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
	/// SSysRunParameter对象Insert方法
	/// </summary>
	private bool executeInsert()
	{
		bool blnFirstField = true;
		string sql = "insert into SSysRunParameter(";
		string sqlTmp = " values(";
		// (Parameter_Guid)字段
		if (_blnParameter_GuidChanged == true)
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
			sql += "Parameter_Guid";
			sqlTmp += "'" + _Parameter_Guid + "'";
		}
		// (ParameterName)字段
		if (_blnParameterNameChanged == true)
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
			sql += "ParameterName";
			sqlTmp += "'" + _ParameterName + "'";
		}
		// (ParameterValue)字段
		if (_blnParameterValueChanged == true)
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
			sql += "ParameterValue";
			sqlTmp += "'" + _ParameterValue + "'";
		}
		// (Detail)字段
		if (_blnDetailChanged == true)
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
			sql += "Detail";
			sqlTmp += "'" + _Detail + "'";
		}
		// (IsUser)字段
		if (_blnIsUserChanged == true)
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
			sql += "IsUser";
			sqlTmp += _IsUser.ToString();
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
	/// SSysRunParameter对象Delete方法
	/// </summary>
	private bool executeDelete()
	{
		bool blnFirstField = true;
		string sql = "delete from SSysRunParameter where ";
		// (Parameter_Guid)字段
		if (_blnParameter_GuidChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "Parameter_Guid = '" + _Parameter_Guid + "'";
		}
		// (ParameterName)字段
		if (_blnParameterNameChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "ParameterName = '" + _ParameterName + "'";
		}
		// (ParameterValue)字段
		if (_blnParameterValueChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "ParameterValue = '" + _ParameterValue + "'";
		}
		// (Detail)字段
		if (_blnDetailChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "Detail = '" + _Detail + "'";
		}
		// (IsUser)字段
		if (_blnIsUserChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += " AND ";
			}
			sql += "IsUser = " + _IsUser.ToString();
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
	/// SSysRunParameter对象Update方法
	/// </summary>
	private bool executeUpdate()
	{
		bool blnFirstField = true;
		string sql = "update SSysRunParameter set ";
		string sqlPK = " where ";
		// (Parameter_Guid)字段
			sqlPK += "Parameter_Guid = '" + _Parameter_Guid + "'";
		// (ParameterName)字段
		if (_blnParameterNameChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "ParameterName = '" + _ParameterName + "'";
		}
		// (ParameterValue)字段
		if (_blnParameterValueChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "ParameterValue = '" + _ParameterValue + "'";
		}
		// (Detail)字段
		if (_blnDetailChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "Detail = '" + _Detail + "'";
		}
		// (IsUser)字段
		if (_blnIsUserChanged == true)
		{
			if (blnFirstField == true)
			{
				blnFirstField = false;
			}
			else
			{
				sql += ",";
			}
			sql += "IsUser = " + _IsUser.ToString();
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
	/// SSysRunParameter对象GetInfo方法
	/// </summary>
	private bool executeGetInfo()
	{
		bool blnFirstField = true;
		string sql = "select * from SSysRunParameter";
		// (Parameter_Guid)字段
		if (_blnParameter_GuidChanged == true)
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
			sql += "Parameter_Guid = '" + _Parameter_Guid + "'";
		}
		// (ParameterName)字段
		if (_blnParameterNameChanged == true)
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
			sql += "ParameterName = '" + _ParameterName + "'";
		}
		// (ParameterValue)字段
		if (_blnParameterValueChanged == true)
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
			sql += "ParameterValue = '" + _ParameterValue + "'";
		}
		// (Detail)字段
		if (_blnDetailChanged == true)
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
			sql += "Detail = '" + _Detail + "'";
		}
		// (IsUser)字段
		if (_blnIsUserChanged == true)
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
			sql += "IsUser = " + _IsUser.ToString();
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
				_Parameter_Guid = dr["Parameter_Guid"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_ParameterName = dr["ParameterName"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_ParameterValue = dr["ParameterValue"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_Detail = dr["Detail"].ToString();
			}
			catch(Exception err)
			{}
			try
			{
				_IsUser = Convert.ToInt32(dr["IsUser"]);
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
	/// SSysRunParameter对象GetDataTable方法
	/// </summary>
	private DataTable executeGetDataTable()
	{
		bool blnFirstField = true;
		string sql = "select * from SSysRunParameter";
		// (Parameter_Guid)字段
		if (_blnParameter_GuidChanged == true)
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
			sql += "Parameter_Guid like '%" + _Parameter_Guid + "%'";
		}
		// (ParameterName)字段
		if (_blnParameterNameChanged == true)
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
			sql += "ParameterName like '%" + _ParameterName + "%'";
		}
		// (ParameterValue)字段
		if (_blnParameterValueChanged == true)
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
			sql += "ParameterValue like '%" + _ParameterValue + "%'";
		}
		// (Detail)字段
		if (_blnDetailChanged == true)
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
			sql += "Detail like '%" + _Detail + "%'";
		}
		// (IsUser)字段
		if (_blnIsUserChanged == true)
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
			sql += "IsUser = " + _IsUser.ToString();
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
	/// SSysRunParameter对象GetDataTable方法
	/// </summary>
	private DataTable executeGetDataTableLike()
	{
		bool blnFirstField = true;
		string sql = "select * from SSysRunParameter";
		// (Parameter_Guid)字段
		if (_blnParameter_GuidChanged == true)
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
			sql += "Parameter_Guid like '%" + _Parameter_Guid + "%'";
		}
		// (ParameterName)字段
		if (_blnParameterNameChanged == true)
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
			sql += "ParameterName like '%" + _ParameterName + "%'";
		}
		// (ParameterValue)字段
		if (_blnParameterValueChanged == true)
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
			sql += "ParameterValue like '%" + _ParameterValue + "%'";
		}
		// (Detail)字段
		if (_blnDetailChanged == true)
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
			sql += "Detail like '%" + _Detail + "%'";
		}
		// (IsUser)字段
		if (_blnIsUserChanged == true)
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
			sql += "IsUser = " + _IsUser.ToString();
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
