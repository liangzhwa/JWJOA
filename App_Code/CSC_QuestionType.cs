//================================================================================
// 模块类别:数据对象模块
// 模块名称:SC_QuestionType数据对象
// 模块版本:1.0.0
// 开发人员:汤君
// 最后日期:2008年03月31日
// 创建日期:2008年03月31日
// 相关模块:
// 模块说明:
//================================================================================

	using System;
	using System.Data;

	/// <summary>
	/// SC_QuestionType业务实体对象
	/// </summary>
	public class CSC_QuestionType
	{
		/// <summary>
		/// CSC_QuestionType构造函数
		/// </summary>
		public CSC_QuestionType(string DBConn)
		{
			// 初始化
            _DBConn = DBConn;
		}

		#region 私有属性
        protected string _DBConn;
		protected string _QuestionType_Id;
		protected string _QuestionTypeName;
		// 属性更新状态
		protected bool _blnQuestionType_IdChanged = false;
		protected bool _blnQuestionTypeNameChanged = false;
		#endregion

		/// <summary>
		/// 
		/// </summary>
		public string QuestionType_Id
		{
			get
			{
				return _QuestionType_Id;
			}
			set
			{
				if (_blnQuestionType_IdChanged == false)
				{
					if (_QuestionType_Id == null && value != null)
						_blnQuestionType_IdChanged = true;
					if (_QuestionType_Id != null && _QuestionType_Id.CompareTo(value) != 0)
						_blnQuestionType_IdChanged = true;
				}
				_QuestionType_Id = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string QuestionTypeName
		{
			get
			{
				return _QuestionTypeName;
			}
			set
			{
				if (_blnQuestionTypeNameChanged == false)
				{
					if (_QuestionTypeName == null && value != null)
						_blnQuestionTypeNameChanged = true;
					if (_QuestionTypeName != null && _QuestionTypeName.CompareTo(value) != 0)
						_blnQuestionTypeNameChanged = true;
				}
				_QuestionTypeName = value;
			}
		}

		/// <summary>
		/// 对象更新操作状态
		/// </summary>
		private string _updateStatus;

		/// <summary>
		/// 取SC_QuestionType对象主键的值
		/// </summary>
		public object GetKeyValue()
		{
			return _QuestionType_Id;
		}

		/// <summary>
		/// SC_QuestionType对象主键赋值
		/// </summary>
		public bool SetKeyValue(object obj)
		{
			try
			{
				_QuestionType_Id = (string)obj;
				return true;
			}
			catch (Exception err)
			{
				throw;
			}
		}

		/// <summary>
		/// SC_QuestionType对象Insert方法
		/// </summary>
		public bool Insert()
		{
			return executeInsert();
		}

		/// <summary>
		/// SC_QuestionType对象Delete方法
		/// </summary>
		public bool Delete()
		{
			return executeDelete();
		}

		/// <summary>
		/// SC_QuestionType对象Update方法
		/// </summary>
		public bool Update()
		{
			return executeUpdate();
		}

		/// <summary>
		/// 取SC_QuestionType对象信息方法
		/// 通过对象属性得到方法返回值
		/// </summary>
		public bool GetInfo()
		{
			return executeGetInfo();
		}

		/// <summary>
		/// SC_QuestionType对象查询数据表方法
		/// </summary>
		public DataTable GetDataTable()
		{
			return executeGetDataTable();
		}

		/// <summary>
		/// SC_QuestionType对象查询数据表方法
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
		/// SC_QuestionType对象Insert方法
		/// </summary>
		private bool executeInsert()
		{
			bool blnFirstField = true;
			string sql = "insert into SC_QuestionType(";
			string sqlTmp = " values(";
			// (QuestionType_Id)字段
			if (_blnQuestionType_IdChanged == true)
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
				sql += "QuestionType_Id";
				sqlTmp += "'" + _QuestionType_Id + "'";
			}
			// (QuestionTypeName)字段
			if (_blnQuestionTypeNameChanged == true)
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
				sql += "QuestionTypeName";
				sqlTmp += "'" + _QuestionTypeName + "'";
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
		/// SC_QuestionType对象Delete方法
		/// </summary>
		private bool executeDelete()
		{
			bool blnFirstField = true;
			string sql = "delete from SC_QuestionType where ";
			// (QuestionType_Id)字段
			if (_blnQuestionType_IdChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += " AND ";
				}
				sql += "QuestionType_Id = '" + _QuestionType_Id + "'";
			}
			// (QuestionTypeName)字段
			if (_blnQuestionTypeNameChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += " AND ";
				}
				sql += "QuestionTypeName = '" + _QuestionTypeName + "'";
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
		/// SC_QuestionType对象Update方法
		/// </summary>
		private bool executeUpdate()
		{
			bool blnFirstField = true;
			string sql = "update SC_QuestionType set ";
			string sqlPK = " where ";
			// (QuestionType_Id)字段
				sqlPK += "QuestionType_Id = '" + _QuestionType_Id + "'";
			// (QuestionTypeName)字段
			if (_blnQuestionTypeNameChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += ",";
				}
				sql += "QuestionTypeName = '" + _QuestionTypeName + "'";
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
		/// SC_QuestionType对象GetInfo方法
		/// </summary>
		private bool executeGetInfo()
		{
			bool blnFirstField = true;
			string sql = "select * from SC_QuestionType";
			// (QuestionType_Id)字段
			if (_blnQuestionType_IdChanged == true)
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
				sql += "QuestionType_Id = '" + _QuestionType_Id + "'";
			}
			// (QuestionTypeName)字段
			if (_blnQuestionTypeNameChanged == true)
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
				sql += "QuestionTypeName = '" + _QuestionTypeName + "'";
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
					_QuestionType_Id = dr["QuestionType_Id"].ToString();
				}
				catch(Exception err)
				{}
				try
				{
					_QuestionTypeName = dr["QuestionTypeName"].ToString();
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
		/// SC_QuestionType对象GetDataTable方法
		/// </summary>
		private DataTable executeGetDataTable()
		{
			bool blnFirstField = true;
			string sql = "select * from SC_QuestionType";
			// (QuestionType_Id)字段
			if (_blnQuestionType_IdChanged == true)
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
				sql += "QuestionType_Id like '%" + _QuestionType_Id + "%'";
			}
			// (QuestionTypeName)字段
			if (_blnQuestionTypeNameChanged == true)
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
				sql += "QuestionTypeName like '%" + _QuestionTypeName + "%'";
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
		/// SC_QuestionType对象GetDataTable方法
		/// </summary>
		private DataTable executeGetDataTableLike()
		{
			bool blnFirstField = true;
			string sql = "select * from SC_QuestionType";
			// (QuestionType_Id)字段
			if (_blnQuestionType_IdChanged == true)
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
				sql += "QuestionType_Id like '%" + _QuestionType_Id + "%'";
			}
			// (QuestionTypeName)字段
			if (_blnQuestionTypeNameChanged == true)
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
				sql += "QuestionTypeName like '%" + _QuestionTypeName + "%'";
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
