using System;
using System.Configuration;
using System.Collections;
using System.Data;

/// <summary>
/// 系统参数对象
/// </summary>
public class Config
{
    /// <summary>
    /// 数据库链接字串
    /// </summary>

    private CSSysStaff _Staff;
    private string _DBConn;
    private DateTime _LoginTime;
    private string _ErrMessage;
    private string _LoginRole;
    private string _ProjectId;
    private string _IsMonitor;
    private Hashtable _htParameter;
    private bool _IsCommission;


    /// <summary>
    /// Config构造函数
    /// </summary>
    public Config(string DBConn)
    {
        _DBConn = DBConn;
    }

    public Config()
    {
        
    }

    /// <summary>
    /// 职员对象
    /// </summary>
    public CSSysStaff Staff
    {
        get { return _Staff; }
        set { _Staff = value; }
    }

    /// <summary>
    /// 数据库链接字
    /// </summary>
    public string DBConn
    {
        get { return _DBConn; }
    }

    /// <summary>
    /// 登录时间
    /// </summary>
    public DateTime LoginTime
    {
        get { return _LoginTime; }
        set { _LoginTime = value; }
    }

    /// <summary>
    /// 错误信息
    /// </summary>
    public string ErrMessage
    {
        get { return _ErrMessage; }
    }

    /// <summary>
    /// 登录角色
    /// </summary>
    public string LoginRole
    {
        get { return _LoginRole; }
        set { _LoginRole = value; }
    }

    /// <summary>
    /// 项目编码
    /// </summary>
    public string ProjectId
    {
        get { return _ProjectId; }
        set { _ProjectId = value; }
    }

    /// <summary>
    /// 系统参数
    /// </summary>
    public Hashtable htParameter
    {
        get { return _htParameter; }
    }

    /// <summary>
    /// 判断当前登录角色是否为代理角色  如果是代理，则可以通过代理表查得委托人。
    /// </summary>
    public bool IsCommission
    {
        get { return _IsCommission; }
        set { _IsCommission = value; }
    }

    public bool GetParameter(string strConnStrings)
    {
        try
        {
            //数据库链接            
            _DBConn = ConfigurationManager.ConnectionStrings[strConnStrings].ToString();

            string sql = "select ParameterName,ParameterValue from SSysRunParameter";
            try
            {
                MDataBase db = new MDataBase(_DBConn);
                DataTable dt;
                bool blnReturnCode = db.GetDataTable(sql, out dt);
                if (blnReturnCode == false)
                {
                    ErrorLog.LogInsert("不能正常读取系统参数SSysRunParameter", "Config.GetParameter", "");
                    _ErrMessage = "不能正常读取系统参数SSysRunParameter";
                    return false;
                }

                _htParameter = new Hashtable();
                foreach (DataRow dr in dt.Rows)
                {
                    _htParameter.Add(dr["ParameterName"].ToString(), dr["ParameterValue"].ToString());
                }
            }
            catch (Exception err)
            {
                ErrorLog.LogInsert(err.Message, "Config.GetParameter", "");
                _ErrMessage = err.Message;
                return false;
            }

            return true;
        }
        catch (Exception err)
        {
            _ErrMessage = err.Message;
            return false;
        }
    }
}