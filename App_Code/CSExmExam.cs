//================================================================================
// 模块类别:数据对象模块
// 模块名称:SExmExam数据对象
// 模块版本:1.0.0
// 开发人员:汤君
// 最后日期:2008年04月03日
// 创建日期:2008年04月03日
// 相关模块:
// 模块说明:
//================================================================================

	using System;
	using System.Data;

	/// <summary>
	/// SExmExam业务实体对象
	/// </summary>
public class CSExmExam
{
    /// <summary>
    /// CSExmExam构造函数
    /// </summary>
    public CSExmExam(string DBConn)
    {
        // 初始化
        _DBConn = DBConn;
    }

    #region 私有属性
    protected string _DBConn;
    protected string _Exam_Id;
    protected string _ExamName;
    protected int _ScoreType;
    protected DateTime _BeginTime;
    #region 处理BeginTime时间区间
    protected DateTime _BeginTimeStart;
    protected DateTime _BeginTimeEnd;
    public DateTime BeginTimeStart
    {
        get { return _BeginTimeStart; }
        set
        {
            if (_blnBeginTimeStartChanged == false)
            {
                if (_BeginTimeStart.CompareTo(value) != 0)
                    _blnBeginTimeStartChanged = true;
            }
            _BeginTimeStart = value;
        }
    }
    public DateTime BeginTimeEnd
    {
        get { return _BeginTimeEnd; }
        set
        {
            if (_blnBeginTimeEndChanged == false)
            {
                if (_BeginTimeEnd.CompareTo(value) != 0)
                    _blnBeginTimeEndChanged = true;
            }
            _BeginTimeEnd = value;
        }
    }
    #endregion
    protected DateTime _EndTime;
    #region 处理EndTime时间区间
    protected DateTime _EndTimeStart;
    protected DateTime _EndTimeEnd;
    public DateTime EndTimeStart
    {
        get { return _EndTimeStart; }
        set
        {
            if (_blnEndTimeStartChanged == false)
            {
                if (_EndTimeStart.CompareTo(value) != 0)
                    _blnEndTimeStartChanged = true;
            }
            _EndTimeStart = value;
        }
    }
    public DateTime EndTimeEnd
    {
        get { return _EndTimeEnd; }
        set
        {
            if (_blnEndTimeEndChanged == false)
            {
                if (_EndTimeEnd.CompareTo(value) != 0)
                    _blnEndTimeEndChanged = true;
            }
            _EndTimeEnd = value;
        }
    }
    #endregion
    protected int _Times;
    protected int _Count;
    protected int _ExamEmploees;
    protected float _Average;
    protected string _CreatedBy;
    protected DateTime _CreatedDate;
    #region 处理CreatedDate时间区间
    protected DateTime _CreatedDateStart;
    protected DateTime _CreatedDateEnd;
    public DateTime CreatedDateStart
    {
        get { return _CreatedDateStart; }
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
        get { return _CreatedDateEnd; }
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
        get { return _ModifiedDateStart; }
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
        get { return _ModifiedDateEnd; }
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
    protected bool _blnExam_IdChanged = false;
    protected bool _blnExamNameChanged = false;
    protected bool _blnScoreTypeChanged = false;
    protected bool _blnBeginTimeChanged = false;
    protected bool _blnBeginTimeStartChanged = false;
    protected bool _blnBeginTimeEndChanged = false;
    protected bool _blnEndTimeChanged = false;
    protected bool _blnEndTimeStartChanged = false;
    protected bool _blnEndTimeEndChanged = false;
    protected bool _blnTimesChanged = false;
    protected bool _blnCountChanged = false;
    protected bool _blnExamEmploeesChanged = false;
    protected bool _blnAverageChanged = false;
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

    /// <summary>
    /// 
    /// </summary>
    public string Exam_Id
    {
        get
        {
            return _Exam_Id;
        }
        set
        {
            if (_blnExam_IdChanged == false)
            {
                if (_Exam_Id == null && value != null)
                    _blnExam_IdChanged = true;
                if (_Exam_Id != null && _Exam_Id.CompareTo(value) != 0)
                    _blnExam_IdChanged = true;
            }
            _Exam_Id = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string ExamName
    {
        get
        {
            return _ExamName;
        }
        set
        {
            if (_blnExamNameChanged == false)
            {
                if (_ExamName == null && value != null)
                    _blnExamNameChanged = true;
                if (_ExamName != null && _ExamName.CompareTo(value) != 0)
                    _blnExamNameChanged = true;
            }
            _ExamName = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int ScoreType
    {
        get
        {
            return _ScoreType;
        }
        set
        {
            if (_blnScoreTypeChanged == false)
            {
               // if (_ScoreType.CompareTo(value) != 0)
                    _blnScoreTypeChanged = true;
            }
            _ScoreType = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public DateTime BeginTime
    {
        get
        {
            return _BeginTime;
        }
        set
        {
            if (_blnBeginTimeChanged == false)
            {
                if (_BeginTime.CompareTo(value) != 0)
                    _blnBeginTimeChanged = true;
            }
            _BeginTime = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public DateTime EndTime
    {
        get
        {
            return _EndTime;
        }
        set
        {
            if (_blnEndTimeChanged == false)
            {
                if (_EndTime.CompareTo(value) != 0)
                    _blnEndTimeChanged = true;
            }
            _EndTime = value;
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
    public int Count
    {
        get
        {
            return _Count;
        }
        set
        {
            if (_blnCountChanged == false)
            {
                if (_Count.CompareTo(value) != 0)
                    _blnCountChanged = true;
            }
            _Count = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int ExamEmploees
    {
        get
        {
            return _ExamEmploees;
        }
        set
        {
            if (_blnExamEmploeesChanged == false)
            {
                if (_ExamEmploees.CompareTo(value) != 0)
                    _blnExamEmploeesChanged = true;
            }
            _ExamEmploees = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public float Average
    {
        get
        {
            return _Average;
        }
        set
        {
            if (_blnAverageChanged == false)
            {
                if (_Average.CompareTo(value) != 0)
                    _blnAverageChanged = true;
            }
            _Average = value;
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
    /// 取SExmExam对象主键的值
    /// </summary>
    public object GetKeyValue()
    {
        return _Exam_Id;
    }

    /// <summary>
    /// SExmExam对象主键赋值
    /// </summary>
    public bool SetKeyValue(object obj)
    {
        try
        {
            _Exam_Id = (string)obj;
            return true;
        }
        catch (Exception err)
        {
            throw;
        }
    }

    /// <summary>
    /// SExmExam对象Insert方法
    /// </summary>
    public bool Insert()
    {
        return executeInsert();
    }

    /// <summary>
    /// SExmExam对象Delete方法
    /// </summary>
    public bool Delete()
    {
        return executeDelete();
    }

    /// <summary>
    /// SExmExam对象Update方法
    /// </summary>
    public bool Update()
    {
        return executeUpdate();
    }

    /// <summary>
    /// 取SExmExam对象信息方法
    /// 通过对象属性得到方法返回值
    /// </summary>
    public bool GetInfo()
    {
        return executeGetInfo();
    }

    /// <summary>
    /// SExmExam对象查询数据表方法
    /// </summary>
    public DataTable GetDataTable()
    {
        return executeGetDataTable();
    }

    /// <summary>
    /// SExmExam对象查询数据表方法
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
    /// SExmExam对象Insert方法
    /// </summary>
    private bool executeInsert()
    {
        bool blnFirstField = true;
        string sql = "insert into SExmExam(";
        string sqlTmp = " values(";
        // (Exam_Id)字段
        if (_blnExam_IdChanged == true)
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
            sql += "Exam_Id";
            sqlTmp += "'" + _Exam_Id + "'";
        }
        // (ExamName)字段
        if (_blnExamNameChanged == true)
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
            sql += "ExamName";
            sqlTmp += "'" + _ExamName + "'";
        }
        // (ScoreType)字段
        if (_blnScoreTypeChanged == true)
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
            sql += "ScoreType";
            sqlTmp += _ScoreType.ToString();
        }
        // (BeginTime)字段
        if (_blnBeginTimeChanged == true)
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
            sql += "BeginTime";
            sqlTmp += "'" + _BeginTime.ToString() + "'";
        }
        // (EndTime)字段
        if (_blnEndTimeChanged == true)
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
            sql += "EndTime";
            sqlTmp += "'" + _EndTime.ToString() + "'";
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
        // (Count)字段
        if (_blnCountChanged == true)
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
            sql += "Count";
            sqlTmp += _Count.ToString();
        }
        // (ExamEmploees)字段
        if (_blnExamEmploeesChanged == true)
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
            sql += "ExamEmploees";
            sqlTmp += _ExamEmploees.ToString();
        }
        // (Average)字段
        if (_blnAverageChanged == true)
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
            sql += "Average";
            sqlTmp += _Average.ToString();
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
        catch (Exception err)
        {
            throw;
            return false;
        }
    }
    #endregion

    #region executeDelete
    /// <summary>
    /// SExmExam对象Delete方法
    /// </summary>
    private bool executeDelete()
    {
        bool blnFirstField = true;
        string sql = "delete from SExmExam where ";
        // (Exam_Id)字段
        if (_blnExam_IdChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Exam_Id = '" + _Exam_Id + "'";
        }
        // (ExamName)字段
        if (_blnExamNameChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "ExamName = '" + _ExamName + "'";
        }
        // (ScoreType)字段
        if (_blnScoreTypeChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "ScoreType = " + _ScoreType.ToString();
        }
        // (BeginTime)字段
        if (_blnBeginTimeChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "BeginTime = '" + _BeginTime.ToString() + "'";
        }
        // (EndTime)字段
        if (_blnEndTimeChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "EndTime = '" + _EndTime.ToString() + "'";
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
        // (Count)字段
        if (_blnCountChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Count = " + _Count.ToString();
        }
        // (ExamEmploees)字段
        if (_blnExamEmploeesChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "ExamEmploees = " + _ExamEmploees.ToString();
        }
        // (Average)字段
        if (_blnAverageChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Average = " + _Average.ToString();
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
        catch (Exception err)
        {
            throw;
            return false;
        }
    }
    #endregion

    #region executeUpdate
    /// <summary>
    /// SExmExam对象Update方法
    /// </summary>
    private bool executeUpdate()
    {
        bool blnFirstField = true;
        string sql = "update SExmExam set ";
        string sqlPK = " where ";
        // (Exam_Id)字段
        sqlPK += "Exam_Id = '" + _Exam_Id + "'";
        // (ExamName)字段
        if (_blnExamNameChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "ExamName = '" + _ExamName + "'";
        }
        // (ScoreType)字段
        if (_blnScoreTypeChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "ScoreType = " + _ScoreType.ToString();
        }
        // (BeginTime)字段
        if (_blnBeginTimeChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "BeginTime = '" + _BeginTime.ToString() + "'";
        }
        // (EndTime)字段
        if (_blnEndTimeChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "EndTime = '" + _EndTime.ToString() + "'";
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
        // (Count)字段
        if (_blnCountChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "Count = " + _Count.ToString();
        }
        // (ExamEmploees)字段
        if (_blnExamEmploeesChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "ExamEmploees = " + _ExamEmploees.ToString();
        }
        // (Average)字段
        if (_blnAverageChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "Average = " + _Average.ToString();
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
        catch (Exception err)
        {
            throw;
            return false;
        }
    }
    #endregion

    #region executeGetInfo
    /// <summary>
    /// SExmExam对象GetInfo方法
    /// </summary>
    private bool executeGetInfo()
    {
        bool blnFirstField = true;
        string sql = "select * from SExmExam";
        // (Exam_Id)字段
        if (_blnExam_IdChanged == true)
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
            sql += "Exam_Id = '" + _Exam_Id + "'";
        }
        // (ExamName)字段
        if (_blnExamNameChanged == true)
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
            sql += "ExamName = '" + _ExamName + "'";
        }
        // (ScoreType)字段
        if (_blnScoreTypeChanged == true)
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
            sql += "ScoreType = " + _ScoreType.ToString();
        }
        // (BeginTime)字段
        if (_blnBeginTimeChanged == true)
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
            sql += "BeginTime = '" + _BeginTime.ToString() + "'";
        }
        // (EndTime)字段
        if (_blnEndTimeChanged == true)
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
            sql += "EndTime = '" + _EndTime.ToString() + "'";
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
        // (Count)字段
        if (_blnCountChanged == true)
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
            sql += "Count = " + _Count.ToString();
        }
        // (ExamEmploees)字段
        if (_blnExamEmploeesChanged == true)
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
            sql += "ExamEmploees = " + _ExamEmploees.ToString();
        }
        // (Average)字段
        if (_blnAverageChanged == true)
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
            sql += "Average = " + _Average.ToString();
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
            bool blnReturnCode = db.GetDataRow(sql, out dr);
            if (blnReturnCode == false || dr == null)
            {
                return false;
            }

            // 对属性赋值
            try
            {
                _Exam_Id = dr["Exam_Id"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _ExamName = dr["ExamName"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _ScoreType = Convert.ToInt32(dr["ScoreType"]);
            }
            catch (Exception err)
            { }
            try
            {
                _BeginTime = Convert.ToDateTime(dr["BeginTime"]);
            }
            catch (Exception err)
            { }
            try
            {
                _EndTime = Convert.ToDateTime(dr["EndTime"]);
            }
            catch (Exception err)
            { }
            try
            {
                _Times = Convert.ToInt32(dr["Times"]);
            }
            catch (Exception err)
            { }
            try
            {
                _Count = Convert.ToInt32(dr["Count"]);
            }
            catch (Exception err)
            { }
            try
            {
                _ExamEmploees = Convert.ToInt32(dr["ExamEmploees"]);
            }
            catch (Exception err)
            { }
            try
            {
                _Average = Convert.ToSingle(dr["Average"]);
            }
            catch (Exception err)
            { }
            try
            {
                _CreatedBy = dr["CreatedBy"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            }
            catch (Exception err)
            { }
            try
            {
                _ModifiedBy = dr["ModifiedBy"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            }
            catch (Exception err)
            { }
            try
            {
                _StatusId = Convert.ToInt32(dr["StatusId"]);
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
    /// SExmExam对象GetDataTable方法
    /// </summary>
    private DataTable executeGetDataTable()
    {
        bool blnFirstField = true;
        string sql = "select * from SExmExam";
        // (Exam_Id)字段
        if (_blnExam_IdChanged == true)
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
            sql += "Exam_Id like '%" + _Exam_Id + "%'";
        }
        // (ExamName)字段
        if (_blnExamNameChanged == true)
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
            sql += "ExamName like '%" + _ExamName + "%'";
        }
        // (ScoreType)字段
        if (_blnScoreTypeChanged == true)
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
            sql += "ScoreType = " + _ScoreType.ToString();
        }
        // (BeginTime)字段
        if (_blnBeginTimeChanged == true)
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
            sql += "BeginTime = '" + _BeginTime.ToString() + "'";
        }
        // (EndTime)字段
        if (_blnEndTimeChanged == true)
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
            sql += "EndTime = '" + _EndTime.ToString() + "'";
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
        // (Count)字段
        if (_blnCountChanged == true)
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
            sql += "Count = " + _Count.ToString();
        }
        // (ExamEmploees)字段
        if (_blnExamEmploeesChanged == true)
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
            sql += "ExamEmploees = " + _ExamEmploees.ToString();
        }
        // (Average)字段
        if (_blnAverageChanged == true)
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
            sql += "Average = " + _Average.ToString();
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
    /// SExmExam对象GetDataTable方法
    /// </summary>
    private DataTable executeGetDataTableLike()
    {
        bool blnFirstField = true;
        string sql = "select * from SExmExam";
        // (Exam_Id)字段
        if (_blnExam_IdChanged == true)
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
            sql += "Exam_Id like '%" + _Exam_Id + "%'";
        }
        // (ExamName)字段
        if (_blnExamNameChanged == true)
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
            sql += "ExamName like '%" + _ExamName + "%'";
        }
        // (ScoreType)字段
        if (_blnScoreTypeChanged == true)
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
            sql += "ScoreType = " + _ScoreType.ToString();
        }
        // (BeginTime)字段
        if ((_blnBeginTimeStartChanged == true) || (_blnBeginTimeEndChanged == true))
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
            sql += "BeginTime BETWEEN '" + _BeginTimeStart.ToString() + "' AND '" + _BeginTimeEnd.ToString() + "'";
        }
        // (EndTime)字段
        if ((_blnEndTimeStartChanged == true) || (_blnEndTimeEndChanged == true))
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
            sql += "EndTime BETWEEN '" + _EndTimeStart.ToString() + "' AND '" + _EndTimeEnd.ToString() + "'";
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
        // (Count)字段
        if (_blnCountChanged == true)
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
            sql += "Count = " + _Count.ToString();
        }
        // (ExamEmploees)字段
        if (_blnExamEmploeesChanged == true)
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
            sql += "ExamEmploees = " + _ExamEmploees.ToString();
        }
        // (Average)字段
        if (_blnAverageChanged == true)
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
            sql += "Average = " + _Average.ToString();
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
