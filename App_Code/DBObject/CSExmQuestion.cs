//================================================================================
// 模块类别:数据对象模块
// 模块名称:SExmQuestion数据对象
// 模块版本:1.0.0
// 开发人员:汤君
// 最后日期:2008年03月28日
// 创建日期:2008年03月28日
// 相关模块:
// 模块说明:
//================================================================================

	using System;
	using System.Data;

	/// <summary>
	/// SExmQuestion业务实体对象
	/// </summary>
	public class CSExmQuestion
	{
		/// <summary>
		/// CSExmQuestion构造函数
		/// </summary>
		public CSExmQuestion(string DBConn)
		{
			// 初始化
            _DBConn = DBConn;
		}

		#region 私有属性
        protected string _DBConn;
		protected string _Question_Guid;
		protected string _QuestionType_Id;
		protected string _Question;
		protected string _AnswerA;
		protected string _AnswerB;
		protected string _AnswerC;
		protected string _AnswerD;
		protected string _AnswerE;
		protected string _Answer;
		protected int _Times;
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
		protected int _StatusId;
		// 属性更新状态
		protected bool _blnQuestion_GuidChanged = false;
		protected bool _blnQuestionType_IdChanged = false;
		protected bool _blnQuestionChanged = false;
		protected bool _blnAnswerAChanged = false;
		protected bool _blnAnswerBChanged = false;
		protected bool _blnAnswerCChanged = false;
		protected bool _blnAnswerDChanged = false;
		protected bool _blnAnswerEChanged = false;
		protected bool _blnAnswerChanged = false;
		protected bool _blnTimesChanged = false;
		protected bool _blnCreatedByChanged = false;
		protected bool _blnCreatedDateChanged = false;
		protected bool _blnCreatedDateStartChanged = false;
		protected bool _blnCreatedDateEndChanged = false;
		protected bool _blnModifiedByChanged = false;
		protected bool _blnModifiedDateChanged = false;
		protected bool _blnModifiedDateStartChanged = false;
		protected bool _blnModifiedDateEndChanged = false;
		protected bool _blnStatusIdChanged = false;
		#endregion

        public string DBConn
        {
            get { return _DBConn; }
        }


		/// <summary>
		/// 
		/// </summary>
		public string Question_Guid
		{
			get
			{
				return _Question_Guid;
			}
			set
			{
				if (_blnQuestion_GuidChanged == false)
				{
					if (_Question_Guid == null && value != null)
						_blnQuestion_GuidChanged = true;
					if (_Question_Guid != null && _Question_Guid.CompareTo(value) != 0)
						_blnQuestion_GuidChanged = true;
				}
				_Question_Guid = value;
			}
		}

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
		public string Question
		{
			get
			{
				return _Question;
			}
			set
			{
				if (_blnQuestionChanged == false)
				{
					if (_Question == null && value != null)
						_blnQuestionChanged = true;
					if (_Question != null && _Question.CompareTo(value) != 0)
						_blnQuestionChanged = true;
				}
				_Question = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string AnswerA
		{
			get
			{
				return _AnswerA;
			}
			set
			{
				if (_blnAnswerAChanged == false)
				{
					if (_AnswerA == null && value != null)
						_blnAnswerAChanged = true;
					if (_AnswerA != null && _AnswerA.CompareTo(value) != 0)
						_blnAnswerAChanged = true;
				}
				_AnswerA = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string AnswerB
		{
			get
			{
				return _AnswerB;
			}
			set
			{
				if (_blnAnswerBChanged == false)
				{
					if (_AnswerB == null && value != null)
						_blnAnswerBChanged = true;
					if (_AnswerB != null && _AnswerB.CompareTo(value) != 0)
						_blnAnswerBChanged = true;
				}
				_AnswerB = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string AnswerC
		{
			get
			{
				return _AnswerC;
			}
			set
			{
				if (_blnAnswerCChanged == false)
				{
					if (_AnswerC == null && value != null)
						_blnAnswerCChanged = true;
					if (_AnswerC != null && _AnswerC.CompareTo(value) != 0)
						_blnAnswerCChanged = true;
				}
				_AnswerC = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string AnswerD
		{
			get
			{
				return _AnswerD;
			}
			set
			{
				if (_blnAnswerDChanged == false)
				{
					if (_AnswerD == null && value != null)
						_blnAnswerDChanged = true;
					if (_AnswerD != null && _AnswerD.CompareTo(value) != 0)
						_blnAnswerDChanged = true;
				}
				_AnswerD = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string AnswerE
		{
			get
			{
				return _AnswerE;
			}
			set
			{
				if (_blnAnswerEChanged == false)
				{
					if (_AnswerE == null && value != null)
						_blnAnswerEChanged = true;
					if (_AnswerE != null && _AnswerE.CompareTo(value) != 0)
						_blnAnswerEChanged = true;
				}
				_AnswerE = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Answer
		{
			get
			{
				return _Answer;
			}
			set
			{
				if (_blnAnswerChanged == false)
				{
					if (_Answer == null && value != null)
						_blnAnswerChanged = true;
					if (_Answer != null && _Answer.CompareTo(value) != 0)
						_blnAnswerChanged = true;
				}
				_Answer = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Times
		{
			get
			{
				return _Times;
			}
			set
			{
				if (_blnTimesChanged == false)
				{
					if (_Times.CompareTo(value) != 0)
						_blnTimesChanged = true;
				}
				_Times = value;
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
		/// 取SExmQuestion对象主键的值
		/// </summary>
		public object GetKeyValue()
		{
			return _Question_Guid;
		}

		/// <summary>
		/// SExmQuestion对象主键赋值
		/// </summary>
		public bool SetKeyValue(object obj)
		{
			try
			{
				_Question_Guid = (string)obj;
				return true;
			}
			catch (Exception err)
			{
				throw;
			}
		}

		/// <summary>
		/// SExmQuestion对象Insert方法
		/// </summary>
		public bool Insert()
		{
			return executeInsert();
		}

		/// <summary>
		/// SExmQuestion对象Delete方法
		/// </summary>
		public bool Delete()
		{
			return executeDelete();
		}

		/// <summary>
		/// SExmQuestion对象Update方法
		/// </summary>
		public bool Update()
		{
			return executeUpdate();
		}

		/// <summary>
		/// 取SExmQuestion对象信息方法
		/// 通过对象属性得到方法返回值
		/// </summary>
		public bool GetInfo()
		{
			return executeGetInfo();
		}

		/// <summary>
		/// SExmQuestion对象查询数据表方法
		/// </summary>
		public DataTable GetDataTable()
		{
			return executeGetDataTable();
		}

		/// <summary>
		/// SExmQuestion对象查询数据表方法
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
		/// SExmQuestion对象Insert方法
		/// </summary>
		private bool executeInsert()
		{
			bool blnFirstField = true;
			string sql = "insert into SExmQuestion(";
			string sqlTmp = " values(";
			// (Question_Guid)字段
			if (_blnQuestion_GuidChanged == true)
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
				sql += "Question_Guid";
				sqlTmp += "'" + _Question_Guid + "'";
			}
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
			// (Question)字段
			if (_blnQuestionChanged == true)
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
				sql += "Question";
				sqlTmp += "'" + _Question + "'";
			}
			// (AnswerA)字段
			if (_blnAnswerAChanged == true)
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
				sql += "AnswerA";
				sqlTmp += "'" + _AnswerA + "'";
			}
			// (AnswerB)字段
			if (_blnAnswerBChanged == true)
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
				sql += "AnswerB";
				sqlTmp += "'" + _AnswerB + "'";
			}
			// (AnswerC)字段
			if (_blnAnswerCChanged == true)
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
				sql += "AnswerC";
				sqlTmp += "'" + _AnswerC + "'";
			}
			// (AnswerD)字段
			if (_blnAnswerDChanged == true)
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
				sql += "AnswerD";
				sqlTmp += "'" + _AnswerD + "'";
			}
			// (AnswerE)字段
			if (_blnAnswerEChanged == true)
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
				sql += "AnswerE";
				sqlTmp += "'" + _AnswerE + "'";
			}
			// (Answer)字段
			if (_blnAnswerChanged == true)
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
				sql += "Answer";
				sqlTmp += "'" + _Answer + "'";
			}
			// (Times)字段
			if (_blnTimesChanged == true)
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
				sql += "Times";
				sqlTmp += _Times.ToString();
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
		/// SExmQuestion对象Delete方法
		/// </summary>
		private bool executeDelete()
		{
			bool blnFirstField = true;
			string sql = "delete from SExmQuestion where ";
			// (Question_Guid)字段
			if (_blnQuestion_GuidChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += " AND ";
				}
				sql += "Question_Guid = '" + _Question_Guid + "'";
			}
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
			// (Question)字段
			if (_blnQuestionChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += " AND ";
				}
				sql += "Question = '" + _Question + "'";
			}
			// (AnswerA)字段
			if (_blnAnswerAChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += " AND ";
				}
				sql += "AnswerA = '" + _AnswerA + "'";
			}
			// (AnswerB)字段
			if (_blnAnswerBChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += " AND ";
				}
				sql += "AnswerB = '" + _AnswerB + "'";
			}
			// (AnswerC)字段
			if (_blnAnswerCChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += " AND ";
				}
				sql += "AnswerC = '" + _AnswerC + "'";
			}
			// (AnswerD)字段
			if (_blnAnswerDChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += " AND ";
				}
				sql += "AnswerD = '" + _AnswerD + "'";
			}
			// (AnswerE)字段
			if (_blnAnswerEChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += " AND ";
				}
				sql += "AnswerE = '" + _AnswerE + "'";
			}
			// (Answer)字段
			if (_blnAnswerChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += " AND ";
				}
				sql += "Answer = '" + _Answer + "'";
			}
			// (Times)字段
			if (_blnTimesChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += " AND ";
				}
				sql += "Times = " + _Times.ToString();
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
		/// SExmQuestion对象Update方法
		/// </summary>
		private bool executeUpdate()
		{
			bool blnFirstField = true;
			string sql = "update SExmQuestion set ";
			string sqlPK = " where ";
			// (Question_Guid)字段
				sqlPK += "Question_Guid = '" + _Question_Guid + "'";
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
				}
				sql += "QuestionType_Id = '" + _QuestionType_Id + "'";
			}
			// (Question)字段
			if (_blnQuestionChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += ",";
				}
				sql += "Question = '" + _Question + "'";
			}
			// (AnswerA)字段
			if (_blnAnswerAChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += ",";
				}
				sql += "AnswerA = '" + _AnswerA + "'";
			}
			// (AnswerB)字段
			if (_blnAnswerBChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += ",";
				}
				sql += "AnswerB = '" + _AnswerB + "'";
			}
			// (AnswerC)字段
			if (_blnAnswerCChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += ",";
				}
				sql += "AnswerC = '" + _AnswerC + "'";
			}
			// (AnswerD)字段
			if (_blnAnswerDChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += ",";
				}
				sql += "AnswerD = '" + _AnswerD + "'";
			}
			// (AnswerE)字段
			if (_blnAnswerEChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += ",";
				}
				sql += "AnswerE = '" + _AnswerE + "'";
			}
			// (Answer)字段
			if (_blnAnswerChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += ",";
				}
				sql += "Answer = '" + _Answer + "'";
			}
			// (Times)字段
			if (_blnTimesChanged == true)
			{
				if (blnFirstField == true)
				{
					blnFirstField = false;
				}
				else
				{
					sql += ",";
				}
				sql += "Times = " + _Times.ToString();
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
		/// SExmQuestion对象GetInfo方法
		/// </summary>
		private bool executeGetInfo()
		{
			bool blnFirstField = true;
			string sql = "select * from SExmQuestion";
			// (Question_Guid)字段
			if (_blnQuestion_GuidChanged == true)
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
				sql += "Question_Guid = '" + _Question_Guid + "'";
			}
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
			// (Question)字段
			if (_blnQuestionChanged == true)
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
				sql += "Question = '" + _Question + "'";
			}
			// (AnswerA)字段
			if (_blnAnswerAChanged == true)
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
				sql += "AnswerA = '" + _AnswerA + "'";
			}
			// (AnswerB)字段
			if (_blnAnswerBChanged == true)
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
				sql += "AnswerB = '" + _AnswerB + "'";
			}
			// (AnswerC)字段
			if (_blnAnswerCChanged == true)
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
				sql += "AnswerC = '" + _AnswerC + "'";
			}
			// (AnswerD)字段
			if (_blnAnswerDChanged == true)
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
				sql += "AnswerD = '" + _AnswerD + "'";
			}
			// (AnswerE)字段
			if (_blnAnswerEChanged == true)
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
				sql += "AnswerE = '" + _AnswerE + "'";
			}
			// (Answer)字段
			if (_blnAnswerChanged == true)
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
				sql += "Answer = '" + _Answer + "'";
			}
			// (Times)字段
			if (_blnTimesChanged == true)
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
				sql += "Times = " + _Times.ToString();
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
					_Question_Guid = dr["Question_Guid"].ToString();
				}
				catch(Exception err)
				{}
				try
				{
					_QuestionType_Id = dr["QuestionType_Id"].ToString();
				}
				catch(Exception err)
				{}
				try
				{
					_Question = dr["Question"].ToString();
				}
				catch(Exception err)
				{}
				try
				{
					_AnswerA = dr["AnswerA"].ToString();
				}
				catch(Exception err)
				{}
				try
				{
					_AnswerB = dr["AnswerB"].ToString();
				}
				catch(Exception err)
				{}
				try
				{
					_AnswerC = dr["AnswerC"].ToString();
				}
				catch(Exception err)
				{}
				try
				{
					_AnswerD = dr["AnswerD"].ToString();
				}
				catch(Exception err)
				{}
				try
				{
					_AnswerE = dr["AnswerE"].ToString();
				}
				catch(Exception err)
				{}
				try
				{
					_Answer = dr["Answer"].ToString();
				}
				catch(Exception err)
				{}
				try
				{
					_Times = Convert.ToInt32(dr["Times"]);
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
		/// SExmQuestion对象GetDataTable方法
		/// </summary>
		private DataTable executeGetDataTable()
		{
			bool blnFirstField = true;
			string sql = "select * from SExmQuestion";
			// (Question_Guid)字段
			if (_blnQuestion_GuidChanged == true)
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
				sql += "Question_Guid like '%" + _Question_Guid + "%'";
			}
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
			// (Question)字段
			if (_blnQuestionChanged == true)
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
				sql += "Question like '%" + _Question + "%'";
			}
			// (AnswerA)字段
			if (_blnAnswerAChanged == true)
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
				sql += "AnswerA like '%" + _AnswerA + "%'";
			}
			// (AnswerB)字段
			if (_blnAnswerBChanged == true)
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
				sql += "AnswerB like '%" + _AnswerB + "%'";
			}
			// (AnswerC)字段
			if (_blnAnswerCChanged == true)
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
				sql += "AnswerC like '%" + _AnswerC + "%'";
			}
			// (AnswerD)字段
			if (_blnAnswerDChanged == true)
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
				sql += "AnswerD like '%" + _AnswerD + "%'";
			}
			// (AnswerE)字段
			if (_blnAnswerEChanged == true)
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
				sql += "AnswerE like '%" + _AnswerE + "%'";
			}
			// (Answer)字段
			if (_blnAnswerChanged == true)
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
				sql += "Answer like '%" + _Answer + "%'";
			}
			// (Times)字段
			if (_blnTimesChanged == true)
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
				sql += "Times = " + _Times.ToString();
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
		/// SExmQuestion对象GetDataTable方法
		/// </summary>
		private DataTable executeGetDataTableLike()
		{
			bool blnFirstField = true;
			string sql = "select * from SExmQuestion";
			// (Question_Guid)字段
			if (_blnQuestion_GuidChanged == true)
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
				sql += "Question_Guid like '%" + _Question_Guid + "%'";
			}
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
			// (Question)字段
			if (_blnQuestionChanged == true)
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
				sql += "Question like '%" + _Question + "%'";
			}
			// (AnswerA)字段
			if (_blnAnswerAChanged == true)
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
				sql += "AnswerA like '%" + _AnswerA + "%'";
			}
			// (AnswerB)字段
			if (_blnAnswerBChanged == true)
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
				sql += "AnswerB like '%" + _AnswerB + "%'";
			}
			// (AnswerC)字段
			if (_blnAnswerCChanged == true)
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
				sql += "AnswerC like '%" + _AnswerC + "%'";
			}
			// (AnswerD)字段
			if (_blnAnswerDChanged == true)
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
				sql += "AnswerD like '%" + _AnswerD + "%'";
			}
			// (AnswerE)字段
			if (_blnAnswerEChanged == true)
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
				sql += "AnswerE like '%" + _AnswerE + "%'";
			}
			// (Answer)字段
			if (_blnAnswerChanged == true)
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
				sql += "Answer like '%" + _Answer + "%'";
			}
			// (Times)字段
			if (_blnTimesChanged == true)
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
				sql += "Times = " + _Times.ToString();
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
