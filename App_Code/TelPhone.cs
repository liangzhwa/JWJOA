using System;
using System.Configuration;
using System.Collections;
using System.Data;

/// <summary>
/// 系统参数对象
/// </summary>
public class TelPhone
{
	public TelPhone()
	{
		_LoginPhone = false;
	}
	/// <summary>
	/// 数据库链接字串
	/// </summary>
    private DateTime _LoginTime;
    private string _LoginGUID;
    private string _LoginTel;
    private int _LoginSN;
    private string _CallEventGuid;
    private bool _Index;
    public string _OldPhoneStatus;
	private bool _LoginPhone;

	/// <summary>
	/// 登录时间
	/// </summary>
	public DateTime LoginTime
	{
		get { return _LoginTime; }
		set { _LoginTime = value; }
	}

	/// <summary>
	/// 登录编号
	/// </summary>
    public string LoginGUID
	{
        get { return _LoginGUID; }
        set { _LoginGUID = value; }
	}


    /// <summary>
    /// 分机号
    /// </summary>
    public string LoginTel
    {
        get { return _LoginTel; }
        set { _LoginTel = value; }
    }


    /// <summary>
    /// SN
    /// </summary>
    public int LoginSN
    {
        get { return _LoginSN; }
        set { _LoginSN = value; }
    }

    /// <summary>
    /// CallEvent_Guid
    /// </summary>
    public string CallEventGuid
    {
        get { return _CallEventGuid; }
        set { _CallEventGuid = value; }
    }
    public bool Index
    {
        get { return _Index; }
        set { _Index = value; }

    }

    public string OldPhoneStatus
    {
        get { return _OldPhoneStatus; }
        set { _OldPhoneStatus = value; }

    }

	/// <summary>
	/// 是否登录软电话
	/// </summary>
	public bool LoginPhone
	{
		get { return _LoginPhone; }
		set { _LoginPhone = value; }
	}
}