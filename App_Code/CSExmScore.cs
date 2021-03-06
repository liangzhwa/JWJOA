//================================================================================
// 模块类别:数据对象模块
// 模块名称:SExmScore数据对象
// 模块版本:1.0.0
// 开发人员:汤君
// 最后日期:2008年04月08日
// 创建日期:2008年04月08日
// 相关模块:
// 模块说明:
//================================================================================

	using System;
	using System.Data;

	/// <summary>
	/// SExmScore业务实体对象
	/// </summary>
public class CSExmScore
{
    /// <summary>
    /// CSExmScore构造函数
    /// </summary>
    public CSExmScore(string DBConn)
    {
        // 初始化
        _DBConn = DBConn;
    }

    #region 私有属性
    protected string _DBConn;
    protected string _Score_Guid;
    protected string _Exam_Id;
    protected string _Staff_Id;
    protected DateTime _StartTime;
    #region 处理StartTime时间区间
    protected DateTime _StartTimeStart;
    protected DateTime _StartTimeEnd;
    public DateTime StartTimeStart
    {
        get { return _StartTimeStart; }
        set
        {
            if (_blnStartTimeStartChanged == false)
            {
                if (_StartTimeStart.CompareTo(value) != 0)
                    _blnStartTimeStartChanged = true;
            }
            _StartTimeStart = value;
        }
    }
    public DateTime StartTimeEnd
    {
        get { return _StartTimeEnd; }
        set
        {
            if (_blnStartTimeEndChanged == false)
            {
                if (_StartTimeEnd.CompareTo(value) != 0)
                    _blnStartTimeEndChanged = true;
            }
            _StartTimeEnd = value;
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
    protected int _RightCount;
    protected int _WrongCount;
    protected int _UnfinishCount;
    protected float _Score;
    protected int _Gradation;
    // 属性更新状态
    protected bool _blnScore_GuidChanged = false;
    protected bool _blnExam_IdChanged = false;
    protected bool _blnStaff_IdChanged = false;
    protected bool _blnStartTimeChanged = false;
    protected bool _blnStartTimeStartChanged = false;
    protected bool _blnStartTimeEndChanged = false;
    protected bool _blnEndTimeChanged = false;
    protected bool _blnEndTimeStartChanged = false;
    protected bool _blnEndTimeEndChanged = false;
    protected bool _blnRightCountChanged = false;
    protected bool _blnWrongCountChanged = false;
    protected bool _blnUnfinishCountChanged = false;
    protected bool _blnScoreChanged = false;
    protected bool _blnGradationChanged = false;
    #endregion

    /// <summary>
    /// 
    /// </summary>
    public string Score_Guid
    {
        get
        {
            return _Score_Guid;
        }
        set
        {
            if (_blnScore_GuidChanged == false)
            {
                if (_Score_Guid == null && value != null)
                    _blnScore_GuidChanged = true;
                if (_Score_Guid != null && _Score_Guid.CompareTo(value) != 0)
                    _blnScore_GuidChanged = true;
            }
            _Score_Guid = value;
        }
    }

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
    public DateTime StartTime
    {
        get
        {
            return _StartTime;
        }
        set
        {
            if (_blnStartTimeChanged == false)
            {
                if (_StartTime.CompareTo(value) != 0)
                    _blnStartTimeChanged = true;
            }
            _StartTime = value;
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
    public int RightCount
    {
        get
        {
            return _RightCount;
        }
        set
        {
            if (_blnRightCountChanged == false)
            {
                if (_RightCount.CompareTo(value) != 0)
                    _blnRightCountChanged = true;
            }
            _RightCount = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int WrongCount
    {
        get
        {
            return _WrongCount;
        }
        set
        {
            if (_blnWrongCountChanged == false)
            {
                if (_WrongCount.CompareTo(value) != 0)
                    _blnWrongCountChanged = true;
            }
            _WrongCount = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int UnfinishCount
    {
        get
        {
            return _UnfinishCount;
        }
        set
        {
            if (_blnUnfinishCountChanged == false)
            {
                if (_UnfinishCount.CompareTo(value) != 0)
                    _blnUnfinishCountChanged = true;
            }
            _UnfinishCount = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public float Score
    {
        get
        {
            return _Score;
        }
        set
        {
            if (_blnScoreChanged == false)
            {
                if (_Score.CompareTo(value) != 0)
                    _blnScoreChanged = true;
            }
            _Score = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int Gradation
    {
        get
        {
            return _Gradation;
        }
        set
        {
            if (_blnGradationChanged == false)
            {
                if (_Gradation.CompareTo(value) != 0)
                    _blnGradationChanged = true;
            }
            _Gradation = value;
        }
    }

    /// <summary>
    /// 对象更新操作状态
    /// </summary>
    private string _updateStatus;

    /// <summary>
    /// 取SExmScore对象主键的值
    /// </summary>
    public object GetKeyValue()
    {
        return _Score_Guid;
    }

    /// <summary>
    /// SExmScore对象主键赋值
    /// </summary>
    public bool SetKeyValue(object obj)
    {
        try
        {
            _Score_Guid = (string)obj;
            return true;
        }
        catch (Exception err)
        {
            throw;
        }
    }

    /// <summary>
    /// SExmScore对象Insert方法
    /// </summary>
    public bool Insert()
    {
        return executeInsert();
    }

    /// <summary>
    /// SExmScore对象Delete方法
    /// </summary>
    public bool Delete()
    {
        return executeDelete();
    }

    /// <summary>
    /// SExmScore对象Update方法
    /// </summary>
    public bool Update()
    {
        return executeUpdate();
    }

    /// <summary>
    /// 取SExmScore对象信息方法
    /// 通过对象属性得到方法返回值
    /// </summary>
    public bool GetInfo()
    {
        return executeGetInfo();
    }

    /// <summary>
    /// SExmScore对象查询数据表方法
    /// </summary>
    public DataTable GetDataTable()
    {
        return executeGetDataTable();
    }

    /// <summary>
    /// SExmScore对象查询数据表方法
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
    /// SExmScore对象Insert方法
    /// </summary>
    private bool executeInsert()
    {
        bool blnFirstField = true;
        string sql = "insert into SExmScore(";
        string sqlTmp = " values(";
        // (Score_Guid)字段
        if (_blnScore_GuidChanged == true)
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
            sql += "Score_Guid";
            sqlTmp += "'" + _Score_Guid + "'";
        }
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
        // (StartTime)字段
        if (_blnStartTimeChanged == true)
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
            sql += "StartTime";
            sqlTmp += "'" + _StartTime.ToString() + "'";
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
        // (RightCount)字段
        if (_blnRightCountChanged == true)
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
            sql += "RightCount";
            sqlTmp += _RightCount.ToString();
        }
        // (WrongCount)字段
        if (_blnWrongCountChanged == true)
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
            sql += "WrongCount";
            sqlTmp += _WrongCount.ToString();
        }
        // (UnfinishCount)字段
        if (_blnUnfinishCountChanged == true)
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
            sql += "UnfinishCount";
            sqlTmp += _UnfinishCount.ToString();
        }
        // (Score)字段
        if (_blnScoreChanged == true)
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
            sql += "Score";
            sqlTmp += _Score.ToString();
        }
        // (Gradation)字段
        if (_blnGradationChanged == true)
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
            sql += "Gradation";
            sqlTmp += _Gradation.ToString();
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
    /// SExmScore对象Delete方法
    /// </summary>
    private bool executeDelete()
    {
        bool blnFirstField = true;
        string sql = "delete from SExmScore where ";
        // (Score_Guid)字段
        if (_blnScore_GuidChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Score_Guid = '" + _Score_Guid + "'";
        }
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
        // (StartTime)字段
        if (_blnStartTimeChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StartTime = '" + _StartTime.ToString() + "'";
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
        // (RightCount)字段
        if (_blnRightCountChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "RightCount = " + _RightCount.ToString();
        }
        // (WrongCount)字段
        if (_blnWrongCountChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "WrongCount = " + _WrongCount.ToString();
        }
        // (UnfinishCount)字段
        if (_blnUnfinishCountChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "UnfinishCount = " + _UnfinishCount.ToString();
        }
        // (Score)字段
        if (_blnScoreChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Score = " + _Score.ToString();
        }
        // (Gradation)字段
        if (_blnGradationChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Gradation = " + _Gradation.ToString();
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
    /// SExmScore对象Update方法
    /// </summary>
    private bool executeUpdate()
    {
        bool blnFirstField = true;
        string sql = "update SExmScore set ";
        string sqlPK = " where ";
        // (Score_Guid)字段
        sqlPK += "Score_Guid = '" + _Score_Guid + "'";
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
            }
            sql += "Exam_Id = '" + _Exam_Id + "'";
        }
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
            }
            sql += "Staff_Id = '" + _Staff_Id + "'";
        }
        // (StartTime)字段
        if (_blnStartTimeChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StartTime = '" + _StartTime.ToString() + "'";
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
        // (RightCount)字段
        if (_blnRightCountChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "RightCount = " + _RightCount.ToString();
        }
        // (WrongCount)字段
        if (_blnWrongCountChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "WrongCount = " + _WrongCount.ToString();
        }
        // (UnfinishCount)字段
        if (_blnUnfinishCountChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "UnfinishCount = " + _UnfinishCount.ToString();
        }
        // (Score)字段
        if (_blnScoreChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "Score = " + _Score.ToString();
        }
        // (Gradation)字段
        if (_blnGradationChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "Gradation = " + _Gradation.ToString();
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
    /// SExmScore对象GetInfo方法
    /// </summary>
    private bool executeGetInfo()
    {
        bool blnFirstField = true;
        string sql = "select * from SExmScore";
        // (Score_Guid)字段
        if (_blnScore_GuidChanged == true)
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
            sql += "Score_Guid = '" + _Score_Guid + "'";
        }
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
        // (StartTime)字段
        if (_blnStartTimeChanged == true)
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
            sql += "StartTime = '" + _StartTime.ToString() + "'";
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
        // (RightCount)字段
        if (_blnRightCountChanged == true)
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
            sql += "RightCount = " + _RightCount.ToString();
        }
        // (WrongCount)字段
        if (_blnWrongCountChanged == true)
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
            sql += "WrongCount = " + _WrongCount.ToString();
        }
        // (UnfinishCount)字段
        if (_blnUnfinishCountChanged == true)
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
            sql += "UnfinishCount = " + _UnfinishCount.ToString();
        }
        // (Score)字段
        if (_blnScoreChanged == true)
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
            sql += "Score = " + _Score.ToString();
        }
        // (Gradation)字段
        if (_blnGradationChanged == true)
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
            sql += "Gradation = " + _Gradation.ToString();
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
                _Score_Guid = dr["Score_Guid"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _Exam_Id = dr["Exam_Id"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _Staff_Id = dr["Staff_Id"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StartTime = Convert.ToDateTime(dr["StartTime"]);
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
                _RightCount = Convert.ToInt32(dr["RightCount"]);
            }
            catch (Exception err)
            { }
            try
            {
                _WrongCount = Convert.ToInt32(dr["WrongCount"]);
            }
            catch (Exception err)
            { }
            try
            {
                _UnfinishCount = Convert.ToInt32(dr["UnfinishCount"]);
            }
            catch (Exception err)
            { }
            try
            {
                _Score = Convert.ToSingle(dr["Score"]);
            }
            catch (Exception err)
            { }
            try
            {
                _Gradation = Convert.ToInt32(dr["Gradation"]);
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
    /// SExmScore对象GetDataTable方法
    /// </summary>
    private DataTable executeGetDataTable()
    {
        bool blnFirstField = true;
        string sql = "select * from SExmScore";
        // (Score_Guid)字段
        if (_blnScore_GuidChanged == true)
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
            sql += "Score_Guid like '%" + _Score_Guid + "%'";
        }
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
        // (StartTime)字段
        if (_blnStartTimeChanged == true)
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
            sql += "StartTime = '" + _StartTime.ToString() + "'";
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
        // (RightCount)字段
        if (_blnRightCountChanged == true)
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
            sql += "RightCount = " + _RightCount.ToString();
        }
        // (WrongCount)字段
        if (_blnWrongCountChanged == true)
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
            sql += "WrongCount = " + _WrongCount.ToString();
        }
        // (UnfinishCount)字段
        if (_blnUnfinishCountChanged == true)
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
            sql += "UnfinishCount = " + _UnfinishCount.ToString();
        }
        // (Score)字段
        if (_blnScoreChanged == true)
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
            sql += "Score = " + _Score.ToString();
        }
        // (Gradation)字段
        if (_blnGradationChanged == true)
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
            sql += "Gradation = " + _Gradation.ToString();
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
    /// SExmScore对象GetDataTable方法
    /// </summary>
    private DataTable executeGetDataTableLike()
    {
        bool blnFirstField = true;
        string sql = "select * from SExmScore";
        // (Score_Guid)字段
        if (_blnScore_GuidChanged == true)
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
            sql += "Score_Guid like '%" + _Score_Guid + "%'";
        }
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
        // (StartTime)字段
        if ((_blnStartTimeStartChanged == true) || (_blnStartTimeEndChanged == true))
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
            sql += "StartTime BETWEEN '" + _StartTimeStart.ToString() + "' AND '" + _StartTimeEnd.ToString() + "'";
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
        // (RightCount)字段
        if (_blnRightCountChanged == true)
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
            sql += "RightCount = " + _RightCount.ToString();
        }
        // (WrongCount)字段
        if (_blnWrongCountChanged == true)
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
            sql += "WrongCount = " + _WrongCount.ToString();
        }
        // (UnfinishCount)字段
        if (_blnUnfinishCountChanged == true)
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
            sql += "UnfinishCount = " + _UnfinishCount.ToString();
        }
        // (Score)字段
        if (_blnScoreChanged == true)
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
            sql += "Score = " + _Score.ToString();
        }
        // (Gradation)字段
        if (_blnGradationChanged == true)
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
            sql += "Gradation = " + _Gradation.ToString();
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
