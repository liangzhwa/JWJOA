//================================================================================
// 模块类别:数据对象模块
// 模块名称:SSysStaff数据对象
// 模块版本:1.0.0
// 开发人员:liang
// 最后日期:2008年04月02日
// 创建日期:2008年04月02日
// 相关模块:
// 模块说明:
//================================================================================

	using System;
	using System.Data;

	/// <summary>
	/// SSysStaff业务实体对象
	/// </summary>
public class CSSysStaff
{
    /// <summary>
    /// CSSysStaff构造函数
    /// </summary>
    public CSSysStaff()
    {
        // 初始化
    }

    public CSSysStaff(string DBConn)
    {
        // 初始化
        _DBConn = DBConn;
    }


    public string DBConn
    {
        get { return _DBConn; }
        set { _DBConn = value; }
    }


    #region 私有属性
    protected string _DBConn;
    protected string _Staff_Id;
    protected string _Name;
    protected string _Username;
    protected string _Password;
    protected DateTime _PasswordDate;
    #region 处理PasswordDate时间区间
    protected DateTime _PasswordDateStart;
    protected DateTime _PasswordDateEnd;
    public DateTime PasswordDateStart
    {
        get { return _PasswordDateStart; }
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
        get { return _PasswordDateEnd; }
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
    protected string _Superior_Id;
    protected string _Dept_Id;
    protected int _GenderId;
    protected DateTime _Birthday;
    #region 处理Birthday时间区间
    protected DateTime _BirthdayStart;
    protected DateTime _BirthdayEnd;
    public DateTime BirthdayStart
    {
        get { return _BirthdayStart; }
        set
        {
            if (_blnBirthdayStartChanged == false)
            {
                if (_BirthdayStart.CompareTo(value) != 0)
                    _blnBirthdayStartChanged = true;
            }
            _BirthdayStart = value;
        }
    }
    public DateTime BirthdayEnd
    {
        get { return _BirthdayEnd; }
        set
        {
            if (_blnBirthdayEndChanged == false)
            {
                if (_BirthdayEnd.CompareTo(value) != 0)
                    _blnBirthdayEndChanged = true;
            }
            _BirthdayEnd = value;
        }
    }
    #endregion
    protected string _EMail;
    protected int _IsMonitor;
    protected int _WorkStatusId;
    protected int _InUse;
    protected int _LoginTimes;
    protected DateTime _LastLoginTime;
    #region 处理LastLoginTime时间区间
    protected DateTime _LastLoginTimeStart;
    protected DateTime _LastLoginTimeEnd;
    public DateTime LastLoginTimeStart
    {
        get { return _LastLoginTimeStart; }
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
        get { return _LastLoginTimeEnd; }
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
        get { return _LastLogoutTimeStart; }
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
        get { return _LastLogoutTimeEnd; }
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
    protected int _OrderIndex;
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
    protected string _StringField1;
    protected string _StringField2;
    protected string _StringField3;
    protected string _StringField4;
    protected string _StringField5;
    protected string _StringField6;
    protected string _StringField7;
    protected string _StringField8;
    protected string _StringField9;
    protected DateTime _StringField10;
    #region 处理StringField10时间区间
    protected DateTime _StringField10Start;
    protected DateTime _StringField10End;
    public DateTime StringField10Start
    {
        get { return _StringField10Start; }
        set
        {
            if (_blnStringField10StartChanged == false)
            {
                if (_StringField10Start.CompareTo(value) != 0)
                    _blnStringField10StartChanged = true;
            }
            _StringField10Start = value;
        }
    }
    public DateTime StringField10End
    {
        get { return _StringField10End; }
        set
        {
            if (_blnStringField10EndChanged == false)
            {
                if (_StringField10End.CompareTo(value) != 0)
                    _blnStringField10EndChanged = true;
            }
            _StringField10End = value;
        }
    }
    #endregion
    protected string _StringField11;
    protected DateTime _StringField12;
    #region 处理StringField12时间区间
    protected DateTime _StringField12Start;
    protected DateTime _StringField12End;
    public DateTime StringField12Start
    {
        get { return _StringField12Start; }
        set
        {
            if (_blnStringField12StartChanged == false)
            {
                if (_StringField12Start.CompareTo(value) != 0)
                    _blnStringField12StartChanged = true;
            }
            _StringField12Start = value;
        }
    }
    public DateTime StringField12End
    {
        get { return _StringField12End; }
        set
        {
            if (_blnStringField12EndChanged == false)
            {
                if (_StringField12End.CompareTo(value) != 0)
                    _blnStringField12EndChanged = true;
            }
            _StringField12End = value;
        }
    }
    #endregion
    protected string _StringField13;
    protected string _StringField14;
    protected string _StringField15;
    protected string _StringField16;
    protected string _StringField17;
    protected string _StringField18;
    protected string _StringField19;
    protected string _StringField20;
    // 属性更新状态
    protected bool _blnStaff_IdChanged = false;
    protected bool _blnNameChanged = false;
    protected bool _blnUsernameChanged = false;
    protected bool _blnPasswordChanged = false;
    protected bool _blnPasswordDateChanged = false;
    protected bool _blnPasswordDateStartChanged = false;
    protected bool _blnPasswordDateEndChanged = false;
    protected bool _blnSuperior_IdChanged = false;
    protected bool _blnDept_IdChanged = false;
    protected bool _blnGenderIdChanged = false;
    protected bool _blnBirthdayChanged = false;
    protected bool _blnBirthdayStartChanged = false;
    protected bool _blnBirthdayEndChanged = false;
    protected bool _blnEMailChanged = false;
    protected bool _blnIsMonitorChanged = false;
    protected bool _blnWorkStatusIdChanged = false;
    protected bool _blnInUseChanged = false;
    protected bool _blnLoginTimesChanged = false;
    protected bool _blnLastLoginTimeChanged = false;
    protected bool _blnLastLoginTimeStartChanged = false;
    protected bool _blnLastLoginTimeEndChanged = false;
    protected bool _blnLastLogoutTimeChanged = false;
    protected bool _blnLastLogoutTimeStartChanged = false;
    protected bool _blnLastLogoutTimeEndChanged = false;
    protected bool _blnTotalUseTimeChanged = false;
    protected bool _blnOrderIndexChanged = false;
    protected bool _blnCreatedByChanged = false;
    protected bool _blnCreatedDateChanged = false;
    protected bool _blnCreatedDateStartChanged = false;
    protected bool _blnCreatedDateEndChanged = false;
    protected bool _blnModifiedByChanged = false;
    protected bool _blnModifiedDateChanged = false;
    protected bool _blnModifiedDateStartChanged = false;
    protected bool _blnModifiedDateEndChanged = false;
    protected bool _blnStatusIdChanged = false;
    protected bool _blnStringField1Changed = false;
    protected bool _blnStringField2Changed = false;
    protected bool _blnStringField3Changed = false;
    protected bool _blnStringField4Changed = false;
    protected bool _blnStringField5Changed = false;
    protected bool _blnStringField6Changed = false;
    protected bool _blnStringField7Changed = false;
    protected bool _blnStringField8Changed = false;
    protected bool _blnStringField9Changed = false;
    protected bool _blnStringField10Changed = false;
    protected bool _blnStringField10StartChanged = false;
    protected bool _blnStringField10EndChanged = false;
    protected bool _blnStringField11Changed = false;
    protected bool _blnStringField12Changed = false;
    protected bool _blnStringField12StartChanged = false;
    protected bool _blnStringField12EndChanged = false;
    protected bool _blnStringField13Changed = false;
    protected bool _blnStringField14Changed = false;
    protected bool _blnStringField15Changed = false;
    protected bool _blnStringField16Changed = false;
    protected bool _blnStringField17Changed = false;
    protected bool _blnStringField18Changed = false;
    protected bool _blnStringField19Changed = false;
    protected bool _blnStringField20Changed = false;
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
    public DateTime Birthday
    {
        get
        {
            return _Birthday;
        }
        set
        {
            if (_blnBirthdayChanged == false)
            {
                if (_Birthday.CompareTo(value) != 0)
                    _blnBirthdayChanged = true;
            }
            _Birthday = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string EMail
    {
        get
        {
            return _EMail;
        }
        set
        {
            if (_blnEMailChanged == false)
            {
                if (_EMail == null && value != null)
                    _blnEMailChanged = true;
                if (_EMail != null && _EMail.CompareTo(value) != 0)
                    _blnEMailChanged = true;
            }
            _EMail = value;
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
                //if (_IsMonitor.CompareTo(value) != -2)
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
                //if (_WorkStatusId.CompareTo(value) != -2)
                    _blnWorkStatusIdChanged = true;
            }
            _WorkStatusId = value;
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
                if (_LoginTimes.CompareTo(value) != -1)
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
                if (_TotalUseTime.CompareTo(value) != -1)
                    _blnTotalUseTimeChanged = true;
            }
            _TotalUseTime = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int OrderIndex
    {
        get
        {
            return _OrderIndex;
        }
        set
        {
            if (_blnOrderIndexChanged == false)
            {
                if (_OrderIndex.CompareTo(value) != 0)
                    _blnOrderIndexChanged = true;
            }
            _OrderIndex = value;
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
                //if (_StatusId.CompareTo(value) != 0)
                    _blnStatusIdChanged = true;
            }
            _StatusId = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField1
    {
        get
        {
            return _StringField1;
        }
        set
        {
            if (_blnStringField1Changed == false)
            {
                if (_StringField1 == null && value != null)
                    _blnStringField1Changed = true;
                if (_StringField1 != null && _StringField1.CompareTo(value) != 0)
                    _blnStringField1Changed = true;
            }
            _StringField1 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField2
    {
        get
        {
            return _StringField2;
        }
        set
        {
            if (_blnStringField2Changed == false)
            {
                if (_StringField2 == null && value != null)
                    _blnStringField2Changed = true;
                if (_StringField2 != null && _StringField2.CompareTo(value) != 0)
                    _blnStringField2Changed = true;
            }
            _StringField2 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField3
    {
        get
        {
            return _StringField3;
        }
        set
        {
            if (_blnStringField3Changed == false)
            {
                if (_StringField3 == null && value != null)
                    _blnStringField3Changed = true;
                if (_StringField3 != null && _StringField3.CompareTo(value) != 0)
                    _blnStringField3Changed = true;
            }
            _StringField3 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField4
    {
        get
        {
            return _StringField4;
        }
        set
        {
            if (_blnStringField4Changed == false)
            {
                if (_StringField4 == null && value != null)
                    _blnStringField4Changed = true;
                if (_StringField4 != null && _StringField4.CompareTo(value) != 0)
                    _blnStringField4Changed = true;
            }
            _StringField4 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField5
    {
        get
        {
            return _StringField5;
        }
        set
        {
            if (_blnStringField5Changed == false)
            {
                if (_StringField5 == null && value != null)
                    _blnStringField5Changed = true;
                if (_StringField5 != null && _StringField5.CompareTo(value) != 0)
                    _blnStringField5Changed = true;
            }
            _StringField5 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField6
    {
        get
        {
            return _StringField6;
        }
        set
        {
            if (_blnStringField6Changed == false)
            {
                if (_StringField6 == null && value != null)
                    _blnStringField6Changed = true;
                if (_StringField6 != null && _StringField6.CompareTo(value) != 0)
                    _blnStringField6Changed = true;
            }
            _StringField6 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField7
    {
        get
        {
            return _StringField7;
        }
        set
        {
            if (_blnStringField7Changed == false)
            {
                if (_StringField7 == null && value != null)
                    _blnStringField7Changed = true;
                if (_StringField7 != null && _StringField7.CompareTo(value) != 0)
                    _blnStringField7Changed = true;
            }
            _StringField7 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField8
    {
        get
        {
            return _StringField8;
        }
        set
        {
            if (_blnStringField8Changed == false)
            {
                if (_StringField8 == null && value != null)
                    _blnStringField8Changed = true;
                if (_StringField8 != null && _StringField8.CompareTo(value) != 0)
                    _blnStringField8Changed = true;
            }
            _StringField8 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField9
    {
        get
        {
            return _StringField9;
        }
        set
        {
            if (_blnStringField9Changed == false)
            {
                if (_StringField9 == null && value != null)
                    _blnStringField9Changed = true;
                if (_StringField9 != null && _StringField9.CompareTo(value) != 0)
                    _blnStringField9Changed = true;
            }
            _StringField9 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public DateTime StringField10
    {
        get
        {
            return _StringField10;
        }
        set
        {
            if (_blnStringField10Changed == false)
            {
                if (_StringField10.CompareTo(value) != 0)
                    _blnStringField10Changed = true;
            }
            _StringField10 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField11
    {
        get
        {
            return _StringField11;
        }
        set
        {
            if (_blnStringField11Changed == false)
            {
                if (_StringField11 == null && value != null)
                    _blnStringField11Changed = true;
                if (_StringField11 != null && _StringField11.CompareTo(value) != 0)
                    _blnStringField11Changed = true;
            }
            _StringField11 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public DateTime StringField12
    {
        get
        {
            return _StringField12;
        }
        set
        {
            if (_blnStringField12Changed == false)
            {
                if (_StringField12.CompareTo(value) != 0)
                    _blnStringField12Changed = true;
            }
            _StringField12 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField13
    {
        get
        {
            return _StringField13;
        }
        set
        {
            if (_blnStringField13Changed == false)
            {
                if (_StringField13 == null && value != null)
                    _blnStringField13Changed = true;
                if (_StringField13 != null && _StringField13.CompareTo(value) != 0)
                    _blnStringField13Changed = true;
            }
            _StringField13 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField14
    {
        get
        {
            return _StringField14;
        }
        set
        {
            if (_blnStringField14Changed == false)
            {
                if (_StringField14 == null && value != null)
                    _blnStringField14Changed = true;
                if (_StringField14 != null && _StringField14.CompareTo(value) != 0)
                    _blnStringField14Changed = true;
            }
            _StringField14 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField15
    {
        get
        {
            return _StringField15;
        }
        set
        {
            if (_blnStringField15Changed == false)
            {
                if (_StringField15 == null && value != null)
                    _blnStringField15Changed = true;
                if (_StringField15 != null && _StringField15.CompareTo(value) != 0)
                    _blnStringField15Changed = true;
            }
            _StringField15 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField16
    {
        get
        {
            return _StringField16;
        }
        set
        {
            if (_blnStringField16Changed == false)
            {
                if (_StringField16 == null && value != null)
                    _blnStringField16Changed = true;
                if (_StringField16 != null && _StringField16.CompareTo(value) != 0)
                    _blnStringField16Changed = true;
            }
            _StringField16 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField17
    {
        get
        {
            return _StringField17;
        }
        set
        {
            if (_blnStringField17Changed == false)
            {
                if (_StringField17 == null && value != null)
                    _blnStringField17Changed = true;
                if (_StringField17 != null && _StringField17.CompareTo(value) != 0)
                    _blnStringField17Changed = true;
            }
            _StringField17 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField18
    {
        get
        {
            return _StringField18;
        }
        set
        {
            if (_blnStringField18Changed == false)
            {
                if (_StringField18 == null && value != null)
                    _blnStringField18Changed = true;
                if (_StringField18 != null && _StringField18.CompareTo(value) != 0)
                    _blnStringField18Changed = true;
            }
            _StringField18 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField19
    {
        get
        {
            return _StringField19;
        }
        set
        {
            if (_blnStringField19Changed == false)
            {
                if (_StringField19 == null && value != null)
                    _blnStringField19Changed = true;
                if (_StringField19 != null && _StringField19.CompareTo(value) != 0)
                    _blnStringField19Changed = true;
            }
            _StringField19 = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string StringField20
    {
        get
        {
            return _StringField20;
        }
        set
        {
            if (_blnStringField20Changed == false)
            {
                if (_StringField20 == null && value != null)
                    _blnStringField20Changed = true;
                if (_StringField20 != null && _StringField20.CompareTo(value) != 0)
                    _blnStringField20Changed = true;
            }
            _StringField20 = value;
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

    #region executeInsert
    /// <summary>
    /// SSysStaff对象Insert方法
    /// </summary>
    private bool executeInsert()
    {
        bool blnFirstField = true;
        string sql = "insert into SSysStaff(";
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
        // (Birthday)字段
        if (_blnBirthdayChanged == true)
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
            sql += "Birthday";
            sqlTmp += "'" + _Birthday.ToString() + "'";
        }
        // (EMail)字段
        if (_blnEMailChanged == true)
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
            sql += "EMail";
            sqlTmp += "'" + _EMail + "'";
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
        // (OrderIndex)字段
        if (_blnOrderIndexChanged == true)
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
            sql += "OrderIndex";
            sqlTmp += _OrderIndex.ToString();
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
        // (StringField1)字段
        if (_blnStringField1Changed == true)
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
            sql += "StringField1";
            sqlTmp += "'" + _StringField1 + "'";
        }
        // (StringField2)字段
        if (_blnStringField2Changed == true)
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
            sql += "StringField2";
            sqlTmp += "'" + _StringField2 + "'";
        }
        // (StringField3)字段
        if (_blnStringField3Changed == true)
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
            sql += "StringField3";
            sqlTmp += "'" + _StringField3 + "'";
        }
        // (StringField4)字段
        if (_blnStringField4Changed == true)
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
            sql += "StringField4";
            sqlTmp += "'" + _StringField4 + "'";
        }
        // (StringField5)字段
        if (_blnStringField5Changed == true)
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
            sql += "StringField5";
            sqlTmp += "'" + _StringField5 + "'";
        }
        // (StringField6)字段
        if (_blnStringField6Changed == true)
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
            sql += "StringField6";
            sqlTmp += "'" + _StringField6 + "'";
        }
        // (StringField7)字段
        if (_blnStringField7Changed == true)
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
            sql += "StringField7";
            sqlTmp += "'" + _StringField7 + "'";
        }
        // (StringField8)字段
        if (_blnStringField8Changed == true)
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
            sql += "StringField8";
            sqlTmp += "'" + _StringField8 + "'";
        }
        // (StringField9)字段
        if (_blnStringField9Changed == true)
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
            sql += "StringField9";
            sqlTmp += "'" + _StringField9 + "'";
        }
        // (StringField10)字段
        if (_blnStringField10Changed == true)
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
            sql += "StringField10";
            sqlTmp += "'" + _StringField10.ToString() + "'";
        }
        // (StringField11)字段
        if (_blnStringField11Changed == true)
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
            sql += "StringField11";
            sqlTmp += "'" + _StringField11 + "'";
        }
        // (StringField12)字段
        if (_blnStringField12Changed == true)
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
            sql += "StringField12";
            sqlTmp += "'" + _StringField12.ToString() + "'";
        }
        // (StringField13)字段
        if (_blnStringField13Changed == true)
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
            sql += "StringField13";
            sqlTmp += "'" + _StringField13 + "'";
        }
        // (StringField14)字段
        if (_blnStringField14Changed == true)
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
            sql += "StringField14";
            sqlTmp += "'" + _StringField14 + "'";
        }
        // (StringField15)字段
        if (_blnStringField15Changed == true)
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
            sql += "StringField15";
            sqlTmp += "'" + _StringField15 + "'";
        }
        // (StringField16)字段
        if (_blnStringField16Changed == true)
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
            sql += "StringField16";
            sqlTmp += "'" + _StringField16 + "'";
        }
        // (StringField17)字段
        if (_blnStringField17Changed == true)
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
            sql += "StringField17";
            sqlTmp += "'" + _StringField17 + "'";
        }
        // (StringField18)字段
        if (_blnStringField18Changed == true)
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
            sql += "StringField18";
            sqlTmp += "'" + _StringField18 + "'";
        }
        // (StringField19)字段
        if (_blnStringField19Changed == true)
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
            sql += "StringField19";
            sqlTmp += "'" + _StringField19 + "'";
        }
        // (StringField20)字段
        if (_blnStringField20Changed == true)
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
            sql += "StringField20";
            sqlTmp += "'" + _StringField20 + "'";
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
    /// SSysStaff对象Delete方法
    /// </summary>
    private bool executeDelete()
    {
        bool blnFirstField = true;
        string sql = "delete from SSysStaff where ";
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
        // (Birthday)字段
        if (_blnBirthdayChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "Birthday = '" + _Birthday.ToString() + "'";
        }
        // (EMail)字段
        if (_blnEMailChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "EMail = '" + _EMail + "'";
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
        // (OrderIndex)字段
        if (_blnOrderIndexChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "OrderIndex = " + _OrderIndex.ToString();
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
        // (StringField1)字段
        if (_blnStringField1Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField1 = '" + _StringField1 + "'";
        }
        // (StringField2)字段
        if (_blnStringField2Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField2 = '" + _StringField2 + "'";
        }
        // (StringField3)字段
        if (_blnStringField3Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField3 = '" + _StringField3 + "'";
        }
        // (StringField4)字段
        if (_blnStringField4Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField4 = '" + _StringField4 + "'";
        }
        // (StringField5)字段
        if (_blnStringField5Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField5 = '" + _StringField5 + "'";
        }
        // (StringField6)字段
        if (_blnStringField6Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField6 = '" + _StringField6 + "'";
        }
        // (StringField7)字段
        if (_blnStringField7Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField7 = '" + _StringField7 + "'";
        }
        // (StringField8)字段
        if (_blnStringField8Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField8 = '" + _StringField8 + "'";
        }
        // (StringField9)字段
        if (_blnStringField9Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField9 = '" + _StringField9 + "'";
        }
        // (StringField10)字段
        if (_blnStringField10Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField10 = '" + _StringField10.ToString() + "'";
        }
        // (StringField11)字段
        if (_blnStringField11Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField11 = '" + _StringField11 + "'";
        }
        // (StringField12)字段
        if (_blnStringField12Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField12 = '" + _StringField12.ToString() + "'";
        }
        // (StringField13)字段
        if (_blnStringField13Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField13 = '" + _StringField13 + "'";
        }
        // (StringField14)字段
        if (_blnStringField14Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField14 = '" + _StringField14 + "'";
        }
        // (StringField15)字段
        if (_blnStringField15Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField15 = '" + _StringField15 + "'";
        }
        // (StringField16)字段
        if (_blnStringField16Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField16 = '" + _StringField16 + "'";
        }
        // (StringField17)字段
        if (_blnStringField17Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField17 = '" + _StringField17 + "'";
        }
        // (StringField18)字段
        if (_blnStringField18Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField18 = '" + _StringField18 + "'";
        }
        // (StringField19)字段
        if (_blnStringField19Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField19 = '" + _StringField19 + "'";
        }
        // (StringField20)字段
        if (_blnStringField20Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField20 = '" + _StringField20 + "'";
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
    /// SSysStaff对象Update方法
    /// </summary>
    private bool executeUpdate()
    {
        bool blnFirstField = true;
        string sql = "update SSysStaff set ";
        string sqlPK = " where ";
        // (Staff_Id)字段
        sqlPK += "Staff_Id = '" + _Staff_Id + "'";
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
        // (Birthday)字段
        if (_blnBirthdayChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "Birthday = '" + _Birthday.ToString() + "'";
        }
        // (EMail)字段
        if (_blnEMailChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "EMail = '" + _EMail + "'";
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
        // (OrderIndex)字段
        if (_blnOrderIndexChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "OrderIndex = " + _OrderIndex.ToString();
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
        // (StringField1)字段
        if (_blnStringField1Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField1 = '" + _StringField1 + "'";
        }
        // (StringField2)字段
        if (_blnStringField2Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField2 = '" + _StringField2 + "'";
        }
        // (StringField3)字段
        if (_blnStringField3Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField3 = '" + _StringField3 + "'";
        }
        // (StringField4)字段
        if (_blnStringField4Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField4 = '" + _StringField4 + "'";
        }
        // (StringField5)字段
        if (_blnStringField5Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField5 = '" + _StringField5 + "'";
        }
        // (StringField6)字段
        if (_blnStringField6Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField6 = '" + _StringField6 + "'";
        }
        // (StringField7)字段
        if (_blnStringField7Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField7 = '" + _StringField7 + "'";
        }
        // (StringField8)字段
        if (_blnStringField8Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField8 = '" + _StringField8 + "'";
        }
        // (StringField9)字段
        if (_blnStringField9Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField9 = '" + _StringField9 + "'";
        }
        // (StringField10)字段
        if (_blnStringField10Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField10 = '" + _StringField10.ToString() + "'";
        }
        // (StringField11)字段
        if (_blnStringField11Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField11 = '" + _StringField11 + "'";
        }
        // (StringField12)字段
        if (_blnStringField12Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField12 = '" + _StringField12.ToString() + "'";
        }
        // (StringField13)字段
        if (_blnStringField13Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField13 = '" + _StringField13 + "'";
        }
        // (StringField14)字段
        if (_blnStringField14Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField14 = '" + _StringField14 + "'";
        }
        // (StringField15)字段
        if (_blnStringField15Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField15 = '" + _StringField15 + "'";
        }
        // (StringField16)字段
        if (_blnStringField16Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField16 = '" + _StringField16 + "'";
        }
        // (StringField17)字段
        if (_blnStringField17Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField17 = '" + _StringField17 + "'";
        }
        // (StringField18)字段
        if (_blnStringField18Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField18 = '" + _StringField18 + "'";
        }
        // (StringField19)字段
        if (_blnStringField19Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField19 = '" + _StringField19 + "'";
        }
        // (StringField20)字段
        if (_blnStringField20Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
            }
            else
            {
                sql += ",";
            }
            sql += "StringField20 = '" + _StringField20 + "'";
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
    /// SSysStaff对象GetInfo方法
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
        // (Birthday)字段
        if (_blnBirthdayChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "Birthday = '" + _Birthday.ToString() + "'";
        }
        // (EMail)字段
        if (_blnEMailChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "EMail = '" + _EMail + "'";
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
        // (OrderIndex)字段
        if (_blnOrderIndexChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "OrderIndex = " + _OrderIndex.ToString();
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
        // (StringField1)字段
        if (_blnStringField1Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField1 = '" + _StringField1 + "'";
        }
        // (StringField2)字段
        if (_blnStringField2Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField2 = '" + _StringField2 + "'";
        }
        // (StringField3)字段
        if (_blnStringField3Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField3 = '" + _StringField3 + "'";
        }
        // (StringField4)字段
        if (_blnStringField4Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField4 = '" + _StringField4 + "'";
        }
        // (StringField5)字段
        if (_blnStringField5Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField5 = '" + _StringField5 + "'";
        }
        // (StringField6)字段
        if (_blnStringField6Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField6 = '" + _StringField6 + "'";
        }
        // (StringField7)字段
        if (_blnStringField7Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField7 = '" + _StringField7 + "'";
        }
        // (StringField8)字段
        if (_blnStringField8Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField8 = '" + _StringField8 + "'";
        }
        // (StringField9)字段
        if (_blnStringField9Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField9 = '" + _StringField9 + "'";
        }
        // (StringField10)字段
        if (_blnStringField10Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField10 = '" + _StringField10.ToString() + "'";
        }
        // (StringField11)字段
        if (_blnStringField11Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField11 = '" + _StringField11 + "'";
        }
        // (StringField12)字段
        if (_blnStringField12Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField12 = '" + _StringField12.ToString() + "'";
        }
        // (StringField13)字段
        if (_blnStringField13Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField13 = '" + _StringField13 + "'";
        }
        // (StringField14)字段
        if (_blnStringField14Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField14 = '" + _StringField14 + "'";
        }
        // (StringField15)字段
        if (_blnStringField15Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField15 = '" + _StringField15 + "'";
        }
        // (StringField16)字段
        if (_blnStringField16Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField16 = '" + _StringField16 + "'";
        }
        // (StringField17)字段
        if (_blnStringField17Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField17 = '" + _StringField17 + "'";
        }
        // (StringField18)字段
        if (_blnStringField18Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField18 = '" + _StringField18 + "'";
        }
        // (StringField19)字段
        if (_blnStringField19Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField19 = '" + _StringField19 + "'";
        }
        // (StringField20)字段
        if (_blnStringField20Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField20 = '" + _StringField20 + "'";
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
                _Name = dr["Name"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _Username = dr["Username"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _Password = dr["Password"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _PasswordDate = Convert.ToDateTime(dr["PasswordDate"]);
            }
            catch (Exception err)
            { }
            try
            {
                _Superior_Id = dr["Superior_Id"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _Dept_Id = dr["Dept_Id"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _GenderId = Convert.ToInt32(dr["GenderId"]);
            }
            catch (Exception err)
            { }
            try
            {
                _Birthday = Convert.ToDateTime(dr["Birthday"]);
            }
            catch (Exception err)
            { }
            try
            {
                _EMail = dr["EMail"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _IsMonitor = Convert.ToInt32(dr["IsMonitor"]);
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
                _InUse = Convert.ToInt32(dr["InUse"]);
            }
            catch (Exception err)
            { }
            try
            {
                _LoginTimes = Convert.ToInt32(dr["LoginTimes"]);
            }
            catch (Exception err)
            { }
            try
            {
                _LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
            }
            catch (Exception err)
            { }
            try
            {
                _LastLogoutTime = Convert.ToDateTime(dr["LastLogoutTime"]);
            }
            catch (Exception err)
            { }
            try
            {
                _TotalUseTime = Convert.ToInt32(dr["TotalUseTime"]);
            }
            catch (Exception err)
            { }
            try
            {
                _OrderIndex = Convert.ToInt32(dr["OrderIndex"]);
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
            try
            {
                _StringField1 = dr["StringField1"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField2 = dr["StringField2"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField3 = dr["StringField3"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField4 = dr["StringField4"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField5 = dr["StringField5"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField6 = dr["StringField6"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField7 = dr["StringField7"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField8 = dr["StringField8"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField9 = dr["StringField9"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField10 = Convert.ToDateTime(dr["StringField10"]);
            }
            catch (Exception err)
            { }
            try
            {
                _StringField11 = dr["StringField11"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField12 = Convert.ToDateTime(dr["StringField12"]);
            }
            catch (Exception err)
            { }
            try
            {
                _StringField13 = dr["StringField13"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField14 = dr["StringField14"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField15 = dr["StringField15"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField16 = dr["StringField16"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField17 = dr["StringField17"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField18 = dr["StringField18"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField19 = dr["StringField19"].ToString();
            }
            catch (Exception err)
            { }
            try
            {
                _StringField20 = dr["StringField20"].ToString();
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
    /// SSysStaff对象GetDataTable方法
    /// </summary>
    private DataTable executeGetDataTable()
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
            sql += "Staff_Id like '%" + _Staff_Id + "%'";
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
        // (Birthday)字段
        if (_blnBirthdayChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "Birthday = '" + _Birthday.ToString() + "'";
        }
        // (EMail)字段
        if (_blnEMailChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "EMail like '%" + _EMail + "%'";
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
        // (OrderIndex)字段
        if (_blnOrderIndexChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "OrderIndex = " + _OrderIndex.ToString();
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
        // (StringField1)字段
        if (_blnStringField1Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField1 like '%" + _StringField1 + "%'";
        }
        // (StringField2)字段
        if (_blnStringField2Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField2 like '%" + _StringField2 + "%'";
        }
        // (StringField3)字段
        if (_blnStringField3Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField3 like '%" + _StringField3 + "%'";
        }
        // (StringField4)字段
        if (_blnStringField4Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField4 like '%" + _StringField4 + "%'";
        }
        // (StringField5)字段
        if (_blnStringField5Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField5 like '%" + _StringField5 + "%'";
        }
        // (StringField6)字段
        if (_blnStringField6Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField6 like '%" + _StringField6 + "%'";
        }
        // (StringField7)字段
        if (_blnStringField7Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField7 like '%" + _StringField7 + "%'";
        }
        // (StringField8)字段
        if (_blnStringField8Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField8 like '%" + _StringField8 + "%'";
        }
        // (StringField9)字段
        if (_blnStringField9Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField9 like '%" + _StringField9 + "%'";
        }
        // (StringField10)字段
        if (_blnStringField10Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField10 = '" + _StringField10.ToString() + "'";
        }
        // (StringField11)字段
        if (_blnStringField11Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField11 like '%" + _StringField11 + "%'";
        }
        // (StringField12)字段
        if (_blnStringField12Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField12 = '" + _StringField12.ToString() + "'";
        }
        // (StringField13)字段
        if (_blnStringField13Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField13 like '%" + _StringField13 + "%'";
        }
        // (StringField14)字段
        if (_blnStringField14Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField14 like '%" + _StringField14 + "%'";
        }
        // (StringField15)字段
        if (_blnStringField15Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField15 like '%" + _StringField15 + "%'";
        }
        // (StringField16)字段
        if (_blnStringField16Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField16 like '%" + _StringField16 + "%'";
        }
        // (StringField17)字段
        if (_blnStringField17Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField17 like '%" + _StringField17 + "%'";
        }
        // (StringField18)字段
        if (_blnStringField18Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField18 like '%" + _StringField18 + "%'";
        }
        // (StringField19)字段
        if (_blnStringField19Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField19 like '%" + _StringField19 + "%'";
        }
        // (StringField20)字段
        if (_blnStringField20Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField20 like '%" + _StringField20 + "%'";
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
    /// SSysStaff对象GetDataTable方法
    /// </summary>
    private DataTable executeGetDataTableLike()
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
            sql += "Staff_Id like '%" + _Staff_Id + "%'";
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
        // (Birthday)字段
        if ((_blnBirthdayStartChanged == true) || (_blnBirthdayEndChanged == true))
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "Birthday BETWEEN '" + _BirthdayStart.ToString() + "' AND '" + _BirthdayEnd.ToString() + "'";
        }
        // (EMail)字段
        if (_blnEMailChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "EMail like '%" + _EMail + "%'";
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
        // (OrderIndex)字段
        if (_blnOrderIndexChanged == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "OrderIndex = " + _OrderIndex.ToString();
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
        // (StringField1)字段
        if (_blnStringField1Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField1 like '%" + _StringField1 + "%'";
        }
        // (StringField2)字段
        if (_blnStringField2Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField2 like '%" + _StringField2 + "%'";
        }
        // (StringField3)字段
        if (_blnStringField3Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField3 like '%" + _StringField3 + "%'";
        }
        // (StringField4)字段
        if (_blnStringField4Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField4 like '%" + _StringField4 + "%'";
        }
        // (StringField5)字段
        if (_blnStringField5Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField5 like '%" + _StringField5 + "%'";
        }
        // (StringField6)字段
        if (_blnStringField6Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField6 like '%" + _StringField6 + "%'";
        }
        // (StringField7)字段
        if (_blnStringField7Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField7 like '%" + _StringField7 + "%'";
        }
        // (StringField8)字段
        if (_blnStringField8Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField8 like '%" + _StringField8 + "%'";
        }
        // (StringField9)字段
        if (_blnStringField9Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField9 like '%" + _StringField9 + "%'";
        }
        // (StringField10)字段
        if ((_blnStringField10StartChanged == true) || (_blnStringField10EndChanged == true))
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField10 BETWEEN '" + _StringField10Start.ToString() + "' AND '" + _StringField10End.ToString() + "'";
        }
        // (StringField11)字段
        if (_blnStringField11Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField11 like '%" + _StringField11 + "%'";
        }
        // (StringField12)字段
        if ((_blnStringField12StartChanged == true) || (_blnStringField12EndChanged == true))
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField12 BETWEEN '" + _StringField12Start.ToString() + "' AND '" + _StringField12End.ToString() + "'";
        }
        // (StringField13)字段
        if (_blnStringField13Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField13 like '%" + _StringField13 + "%'";
        }
        // (StringField14)字段
        if (_blnStringField14Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField14 like '%" + _StringField14 + "%'";
        }
        // (StringField15)字段
        if (_blnStringField15Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField15 like '%" + _StringField15 + "%'";
        }
        // (StringField16)字段
        if (_blnStringField16Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField16 like '%" + _StringField16 + "%'";
        }
        // (StringField17)字段
        if (_blnStringField17Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField17 like '%" + _StringField17 + "%'";
        }
        // (StringField18)字段
        if (_blnStringField18Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField18 like '%" + _StringField18 + "%'";
        }
        // (StringField19)字段
        if (_blnStringField19Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField19 like '%" + _StringField19 + "%'";
        }
        // (StringField20)字段
        if (_blnStringField20Changed == true)
        {
            if (blnFirstField == true)
            {
                blnFirstField = false;
                sql += " WHERE ";
            }
            else
            {
                sql += " AND ";
            }
            sql += "StringField20 like '%" + _StringField20 + "%'";
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