using System;
using System.Configuration;
using System.Collections;
using System.Data;

/// <summary>
/// 系统参数对象
/// </summary>
public class LoginParam
{
	/// <summary>
	/// 数据库链接字串
	/// </summary>
    private DateTime _LoginTime;
    private string _LPhone;

	/// <summary>
	/// 登录时间
	/// </summary>
	public DateTime LoginTime
	{
		get { return _LoginTime; }
		set { _LoginTime = value; }
	}
}