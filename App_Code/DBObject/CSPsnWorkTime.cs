//================================================================================
// 模块类别:数据对象模块
// 模块名称:SPsnWorkTime数据对象
// 模块版本:1.0.0
// 开发人员:liang
// 最后日期:2008年04月08日
// 创建日期:2008年04月08日
// 相关模块:
// 模块说明:
//================================================================================


	using System;
	using System.Data;

	/// <summary>
	/// SPsnWorkTime业务实体对象
	/// </summary>
public class CSPsnWorkTime
{
    /// <summary>
    /// CSPsnWorkTime构造函数
    /// </summary>
    public CSPsnWorkTime()
    {
        // 初始化
    }

    public CSPsnWorkTime(string DBConn)
    {        
        // 初始化
        _DBConn = DBConn;
    }

    public string DBConn
    {
        get { return _DBConn;}
        set { _DBConn = value; }
    }

    #region 私有属性
    protected string _DBConn;
    protected string _WorkTime_Guid;
    protected string _Staff_Id;
    protected DateTime _Day;
    #region 处理Day时间区间
    protected DateTime _DayStart;
    protected DateTime _DayEnd;
    public DateTime DayStart
    {
        get { return _DayStart; }
        set
        {
            if (_blnDayStartChanged == false)
            {
                if (_DayStart.CompareTo(value) != 0)
                    _blnDayStartChanged = true;
            }
            _DayStart = value;
        }
    }
    public DateTime DayEnd
    {
        get { return _DayEnd; }
        set
        {
            if (_blnDayEndChanged == false)
            {
                if (_DayEnd.CompareTo(value) != 0)
                    _blnDayEndChanged = true;
            }
            _DayEnd = value;
        }
    }
    #endregion
    protected int _WorkStatusId;
    protected string _Job;
    protected string _Address;
    protected string _Remark;
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
    protected bool _blnWorkTime_GuidChanged = false;
    protected bool _blnStaff_IdChanged = false;
    protected bool _blnDayChanged = false;
    protected bool _blnDayStartChanged = false;
    protected bool _blnDayEndChanged = false;
    protected bool _blnWorkStatusIdChanged = false;
    protected bool _blnJobChanged = false;
    protected bool _blnAddressChanged = false;
    protected bool _blnRemarkChanged = false;
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
    public string WorkTime_Guid
    {
        get
        {
            return _WorkTime_Guid;
        }
        set
        {
            if (_blnWorkTime_GuidChanged == false)
            {
                if (_WorkTime_Guid == null && value != null)
                    _blnWorkTime_GuidChanged = true;
                if (_WorkTime_Guid != null && _WorkTime_Guid.CompareTo(value) != 0)
                    _blnWorkTime_GuidChanged = true;
            }
            _WorkTime_Guid = value;
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
    public DateTime Day
    {
        get
        {
            return _Day;
        }
        set
        {
            if (_blnDayChanged == false)
            {
                if (_Day.CompareTo(value) != 0)
                    _blnDayChanged = true;
            }
            _Day = value;
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
                //if (_WorkStatusId.CompareTo(value) != -2)
                    _blnWorkStatusIdChanged = true;
            }
            _WorkStatusId = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Job
    {
        get
        {
            return _Job;
        }
        set
        {
            if (_blnJobChanged == false)
            {
                if (_Job == null && value != null)
                    _blnJobChanged = true;
                if (_Job != null && _Job.CompareTo(value) != 0)
                    _blnJobChanged = true;
            }
            _Job = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Address
    {
        get
        {
            return _Address;
        }
        set
        {
            if (_blnAddressChanged == false)
            {
                if (_Address == null && value != null)
                    _blnAddressChanged = true;
                if (_Address != null && _Address.CompareTo(value) != 0)
                    _blnAddressChanged = true;
            }
            _Address = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Remark
    {
        get
        {
            return _Remark;
        }
        set
        {
            if (_blnRemarkChanged == false)
            {
                if (_Remark == null && value != null)
                    _blnRemarkChanged = true;
                if (_Remark != null && _Remark.CompareTo(value) != 0)
                    _blnRemarkChanged = true;
            }
            _Remark = value;
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
    /// 取SPsnWorkTime对象主键的值
    /// </summary>
    public object GetKeyValue()
    {
        return _WorkTime_Guid;
    }

    /// <summary>
    /// SPsnWorkTime对象主键赋值
    /// </summary>
    public bool SetKeyValue(object obj)
    {
        try
        {
            _WorkTime_Guid = (string)obj;
            return true;
        }
        catch (Exception err)
        {
            throw;
        }
    }

    /// <summary>
    /// SPsnWorkTime对象Insert方法
    /// </summary>
    public bool Insert()
    {
        return executeInsert();
    }

    /// <summary>
    /// SPsnWorkTime对象Delete方法
    /// </summary>
    public bool Delete()
    {
        return executeDelete();
    }

    /// <summary>
    /// SPsnWorkTime对象Update方法
    /// </summary>
    public bool Update()
    {
        return executeUpdate();
    }

    /// <summary>
    /// 取SPsnWorkTime对象信息方法
    /// 通过对象属性得到方法返回值
    /// </summary>
    public bool GetInfo()
    {
        return executeGetInfo();
    }

    /// <summary>
    /// SPsnWorkTime对象查询数据表方法
    /// </summary>
    public DataTable GetDataTable()
    {
        return executeGetDataTable();
    }

    /// <summary>
    /// SPsnWorkTime对象查询数据表方法
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
    /// SPsnWorkTime对象Insert方法
    /// </summary>
    private bool executeInsert()
    {
        bool blnFirstField = true;
        string sql = "insert into SPsnWorkTime(";
        string sqlTmp = " values(";
        // (WorkTime_Guid)字段
        if (_blnWorkTime_GuidChanged == true)
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
            sql += "WorkTime_Guid";
            sqlTmp += "'" + _WorkTime_Guid + "'";
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
        // (Day)字段
        if (_blnDayChanged == true)
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
            sql += "Day";
            sqlTmp += "'" + _Day.ToString() + "'";
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
        // (Job)字段
        if (_blnJobChanged == true)
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
            sql += "Job";
            sqlTmp += "'" + _Job + "'";
        }
        // (Address)字段
        if (_blnAddressChanged == true)
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
            sql += "Address";
            sqlTmp += "'" + _Address + "'";
        }
        // (Remark)字段
        if (_blnRemarkChanged == true)
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
            sql += "Remark";
            sqlTmp += "'" + _Remark + "'";
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
    /// SPsnWorkTime对象Delete方法
    /// </summary>
    private bool executeDelete()
    {
        bool blnFirstField = true;
        string sql = "delete from SPsnWorkTime where ";
        // (WorkTime_Guid)字段
        if (_blnWorkTime_GuidChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "WorkTime_Guid = '" + _WorkTime_Guid + "'";
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
        // (Day)字段
        if (_blnDayChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Day = '" + _Day.ToString() + "'";
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
        // (Job)字段
        if (_blnJobChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Job = '" + _Job + "'";
        }
        // (Address)字段
        if (_blnAddressChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Address = '" + _Address + "'";
        }
        // (Remark)字段
        if (_blnRemarkChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Remark = '" + _Remark + "'";
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
    /// SPsnWorkTime对象Update方法
    /// </summary>
    private bool executeUpdate()
    {
        bool blnFirstField = true;
        string sql = "update SPsnWorkTime set ";
        string sqlPK = " where ";
        // (WorkTime_Guid)字段
        sqlPK += "WorkTime_Guid = '" + _WorkTime_Guid + "'";
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
        // (Day)字段
        if (_blnDayChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "Day = '" + _Day.ToString() + "'";
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
        // (Job)字段
        if (_blnJobChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "Job = '" + _Job + "'";
        }
        // (Address)字段
        if (_blnAddressChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "Address = '" + _Address + "'";
        }
        // (Remark)字段
        if (_blnRemarkChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "Remark = '" + _Remark + "'";
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
    /// SPsnWorkTime对象GetInfo方法
    /// </summary>
    private bool executeGetInfo()
    {
        bool blnFirstField = true;
        string sql = "select * from SPsnWorkTime";
        // (WorkTime_Guid)字段
        if (_blnWorkTime_GuidChanged == true)
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
            sql += "WorkTime_Guid = '" + _WorkTime_Guid + "'";
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
        // (Day)字段
        if (_blnDayChanged == true)
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
            sql += "Day = '" + _Day.ToString() + "'";
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
        // (Job)字段
        if (_blnJobChanged == true)
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
            sql += "Job = '" + _Job + "'";
        }
        // (Address)字段
        if (_blnAddressChanged == true)
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
            sql += "Address = '" + _Address + "'";
        }
        // (Remark)字段
        if (_blnRemarkChanged == true)
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
            sql += "Remark = '" + _Remark + "'";
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
                _WorkTime_Guid = dr["WorkTime_Guid"].ToString();
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
                _Day = Convert.ToDateTime(dr["Day"]);
            }
            catch (Exception err)
            { }
            try
            {
                _WorkStatusId = Convert.ToInt32(dr["WorkStatusId"]);
            }
            catch (Exception err)
            { }
            try
            {
                _Job = dr["Job"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _Address = dr["Address"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _Remark = dr["Remark"].ToString();
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
    /// SPsnWorkTime对象GetDataTable方法
    /// </summary>
    private DataTable executeGetDataTable()
    {
        bool blnFirstField = true;
        string sql = "select * from SPsnWorkTime";
        // (WorkTime_Guid)字段
        if (_blnWorkTime_GuidChanged == true)
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
            sql += "WorkTime_Guid like '%" + _WorkTime_Guid + "%'";
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
        // (Day)字段
        if (_blnDayChanged == true)
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
            sql += "Day = '" + _Day.ToString() + "'";
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
        // (Job)字段
        if (_blnJobChanged == true)
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
            sql += "Job like '%" + _Job + "%'";
        }
        // (Address)字段
        if (_blnAddressChanged == true)
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
            sql += "Address like '%" + _Address + "%'";
        }
        // (Remark)字段
        if (_blnRemarkChanged == true)
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
            sql += "Remark like '%" + _Remark + "%'";
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
    /// SPsnWorkTime对象GetDataTable方法
    /// </summary>
    private DataTable executeGetDataTableLike()
    {
        bool blnFirstField = true;
        string sql = "select * from SPsnWorkTime";
        // (WorkTime_Guid)字段
        if (_blnWorkTime_GuidChanged == true)
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
            sql += "WorkTime_Guid like '%" + _WorkTime_Guid + "%'";
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
        // (Day)字段
        if ((_blnDayStartChanged == true) || (_blnDayEndChanged == true))
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
            sql += "Day BETWEEN '" + _DayStart.ToString() + "' AND '" + _DayEnd.ToString() + "'";
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
        // (Job)字段
        if (_blnJobChanged == true)
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
            sql += "Job like '%" + _Job + "%'";
        }
        // (Address)字段
        if (_blnAddressChanged == true)
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
            sql += "Address like '%" + _Address + "%'";
        }
        // (Remark)字段
        if (_blnRemarkChanged == true)
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
            sql += "Remark like '%" + _Remark + "%'";
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