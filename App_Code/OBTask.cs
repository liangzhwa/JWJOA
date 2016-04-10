//================================================================================
// 模块类别:功能模块
// 模块名称:取任务功能
// 模块版本:1.3.071212
// 开发人员:stone
// 最后日期:2007年12月12日
// 创建日期:
// 相关模块:
// 模块说明:利用任务容器，提供系统中所有的取任务功能
//================================================================================

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Threading;

/// <summary>
/// 任务类
/// 用于取任务
/// </summary>
public class OBTask
{
	public OBTask(Config conConfig)
	{
		#region 初始化参数
		config = conConfig;

		// 预约任务容器池的时间(默认4小时)
		if (config.htParameter != null && config.htParameter.ContainsKey("RespeakTime") == true)
		{
			try
			{
				RespeakTime = Math.Max(0,Convert.ToInt32(config.htParameter["RespeakTime"]));
			}
			catch { }
		}

		// 个人任务容器池的大小(默认100条记录)
		if (config.htParameter != null && config.htParameter.ContainsKey("SelfTasks") == true)
		{
			try
			{
                SelfTasks = Math.Max(10, Convert.ToInt32(config.htParameter["SelfTasks"]));
			}
			catch { }
		}

		// 抢占任务容器池大小(默认200条记录)
		if (config.htParameter != null && config.htParameter.ContainsKey("RobTasks") == true)
		{
			try
			{
                RobTasks = Math.Max(10, Convert.ToInt32(config.htParameter["RobTasks"]));
			}
			catch { }
		}
		#endregion

		_RespeakTaskPool = new Hashtable();
		_SelfTaskPool = new Hashtable();
		_RobTaskPool = new Hashtable();
	}

	#region 运行参数
	/// <summary>
	/// 系统参数
	/// </summary>
	private static Config config;

	/// <summary>
	/// 预约任务容器池的时间
	/// 单位:小时
	/// </summary>
	private static int RespeakTime = 4;

	/// <summary>
	/// 个人任务容器池的大小
	/// </summary>
	private static int SelfTasks = 100;

	/// <summary>
	/// 抢占任务容器池的大小
	/// </summary>
	private static int RobTasks = 200;
	#endregion

	/// <summary>
	/// 预约任务空器
	///   key:职员编码Staff_Id;
	/// value:该职员的预约任务容器_RespeakTaskPoolByStaff
	/// </summary>
	private static Hashtable _RespeakTaskPool;

	/// <summary>
	/// 个人任务容器
	///   key:职员编码Staff_Id;
	/// value:该职员的任务容器_SelfTaskPoolByStaff
	/// </summary>
	private static Hashtable _SelfTaskPool;

	/// <summary>
	/// 抢占任务容器
	///   key:策略编码StrategyId
	/// value:该策略相关的任务容器_RobTaskPoolByStrategy
	/// </summary>
	private static Hashtable _RobTaskPool;

	#region 注释性容器定义,实际程序运行中不使用
	/*
	/// <summary>
	/// 个人预约任务(4小时内的记录)
	///   key:任务时间
	/// value:任务记录的TableRow
	/// </summary>
	private static Hashtable _RespeakTaskPoolByStaff;

	/// <summary>
	/// 个人任务器(最大100条记录)
	///   key:任务编码
	/// value:任务记录的TableRow
	/// </summary>
	private static Hashtable _SelfTaskPoolByStaff;

	/// <summary>
	/// 指定策略的抢占任务容器(最大200条记录)
	///   key:任务编码
	/// value:任务记录的TableRow
	/// </summary>
	private static Hashtable _RobTaskPoolByStrategy;
	 */
	#endregion

	/// <summary>
	/// 取任务进程标记
	/// 0:空闲中
	/// 1:从数据库取任务中
	/// </summary>
	private static int _GetTaskFromDBStatus;

	/// <summary>
	/// 取任务标记
	/// 0:空闲中
	/// 1:职员取任务中
	/// </summary>
	private static int _GetTaskStatus;

	/// <summary>
	/// 预约任务最后更新时间
	/// </summary>
	private static DateTime _RespeakLastRefresh;

	/// <summary>
	/// 个人任务最后更新记录
	///   key:职员编码Staff_Id;
	/// value:上次取出的记录数
	/// </summary>
	private static Hashtable _SelfLastRefresh;

	/// <summary>
	/// 抢占任务最后更新时间
	///   key:策略编码StrategyId
	/// value:上次取出的记录数
	/// </summary>
	private static Hashtable _RobLastRefresh;

	#region 公共属性
	/// <summary>
	/// 预约任务容器
	///   key:职员编码Staff_Id;
	/// value:该职员的预约任务容器_RespeakTaskPoolByStaff
	/// </summary>
	public static Hashtable RespeakTaskPool
	{
		get { return _RespeakTaskPool; }
	}

	/// <summary>
	/// 个人任务容器
	///   key:职员编码Staff_Id;
	/// value:该职员的任务容器_SelfTaskPoolByStaff
	/// </summary>
	public static Hashtable SelfTaskPool
	{
		get { return _SelfTaskPool; }
	}

	/// <summary>
	/// 抢占任务容器
	///   key:策略编码StrategyId
	/// value:该策略相关的任务容器_RobTaskPoolByStrategy
	/// </summary>
	public static Hashtable RobTaskPool
	{
		get { return _RobTaskPool; }
	}

	/// <summary>
	/// 预约任务最后更新时间
	/// </summary>
	public static DateTime RespeakLastRefresh
	{
		get { return _RespeakLastRefresh; }
		set { _RespeakLastRefresh = value; }
	}

	/// <summary>
	/// 个人任务最后更新记录
	///   key:职员编码Staff_Id;
	/// value:上次取出的记录数
	/// </summary>
	public static Hashtable SelfLastRefresh
	{
		get { return _SelfLastRefresh; }
		set { _SelfLastRefresh = value; }
	}

	/// <summary>
	/// 抢占任务最后更新时间
	///   key:策略编码StrategyId
	/// value:上次取出的记录数
	/// </summary>
	public static Hashtable RobLastRefresh
	{
		get { return _RobLastRefresh; }
		set { _RobLastRefresh = value; }
	}
	#endregion

	/// <summary>
	/// 取外呼任务
	/// </summary>
	/// <param name="StaffId">单个职员编码</param>
	/// <param name="StrategyId">单个组策略编码</param>
	/// <returns></returns>
	public static DataTable GetOBTask(string StaffId,string StrategyId)
	{
		while (_GetTaskStatus != 0 || _GetTaskFromDBStatus != 0)
		{
			Thread.Sleep(100);
		}

		_GetTaskStatus = 1;
		DataTable dtReturn = null;
		string sql;
		MDataBase db = new MDataBase(config.DBConn);
		db.Open();
		try
		{
			// 刷新所有外呼任务
			// 如果不需要刷新,则不刷新
			RefreshOBTask(StaffId,StrategyId);

			// 取预约任务
			if (_RespeakTaskPool.ContainsKey(StaffId) == true)
			{
				// 从_RespeakTaskPool取自已的最早的预约任务
				Hashtable ht = (Hashtable)_RespeakTaskPool[StaffId];
				DateTime nowTime = DateTime.Now;	//当前时间
				DateTime newTime = nowTime;			//最小的预约时间
				DataRow dr = null;
				foreach (DictionaryEntry de in ht)
				{
					if (Convert.ToDateTime(de.Key) < newTime)
					{
						// 小于最小的预约时间
						newTime = Convert.ToDateTime(de.Key);
						dr = (DataRow)de.Value;
					}
				}
				if (newTime != nowTime)
				{
					DataTable dt;
					dt = new DataTable();
					DataColumn column = new DataColumn();
					column.DataType = typeof(string);
					column.Caption = "Task_Guid";
					column.ColumnName = "Task_Guid";
					dt.Columns.Add(column);
					DataColumn column2 = new DataColumn();
					column2.DataType = typeof(string);
					column2.Caption = "Customer_Guid";
					column2.ColumnName = "Customer_Guid";
					dt.Columns.Add(column2);
					DataColumn column3 = new DataColumn();
					column3.DataType = typeof(string);
					column3.Caption = "ItemName";
					column3.ColumnName = "ItemName";
					dt.Columns.Add(column3);

					dt.ImportRow(dr);

					dtReturn = dt;
					sql = "update SDrmTasks set Lock=0,LockTime=getDate(),ExecuteBy='" + StaffId + "' where Task_Guid='" + dt.Rows[0]["Task_Guid"].ToString() + "'";
					int intCount = db.executeUpdate(sql);
					if (intCount > 0)
					{
                        string tmp = newTime.ToString();
                        ht.Remove(tmp);
					}
				}
			}
			// 取个人任务
			if (dtReturn == null && _SelfTaskPool.ContainsKey(StaffId) == true)
			{
				// 从_SelfTaskPool取个人任务
				Hashtable ht = (Hashtable)_SelfTaskPool[StaffId];
				DataTable dt;
				GetOnce(db, StaffId,ht, out dt);
				dtReturn = dt;
			}
			// 取抢占任务
			if (dtReturn == null && (_RobTaskPool.ContainsKey(StrategyId) == true))
			{
				// 从_RobTaskPool取抢占任务
				Hashtable ht = (Hashtable)_RobTaskPool[StrategyId];
				DataTable dt;
				GetOnce(db, StaffId,ht, out dt);
				dtReturn = dt;
			}
		}
		catch(Exception err)
		{
			//err.Message;
		}
		db.Close();

		_GetTaskStatus = 0;
		return dtReturn;
	}

	/// <summary>
	/// 从Hashtable容器中取一条记录并转换为DataTable类型
	/// </summary>
	/// <param name="StaffId">操作员编码</param>
	/// <param name="ht">Hashtable容器</param>
	/// <param name="dt">包含一条记录的DataTable,失败返回Null</param>
	private static void GetOnce(MDataBase db, string StaffId,Hashtable ht, out DataTable dt)
	{
		dt = null;
		if (ht != null && ht.Count > 0)
		{
			dt = new DataTable();
			DataColumn column = new DataColumn();
			column.DataType = typeof(string);
			column.Caption = "Task_Guid";
			column.ColumnName = "Task_Guid";
			dt.Columns.Add(column);
			DataColumn column2 = new DataColumn();
			column2.DataType = typeof(string);
			column2.Caption = "Customer_Guid";
			column2.ColumnName = "Customer_Guid";
			dt.Columns.Add(column2);
			DataColumn column3 = new DataColumn();
			column3.DataType = typeof(string);
			column3.Caption = "ItemName";
			column3.ColumnName = "ItemName";
			dt.Columns.Add(column3);

			DataRow dr = null;
			foreach (DictionaryEntry de in ht)
			{
				dr = (DataRow)de.Value;
				break;
			}
			if (dr != null)
			{
				
				dt.ImportRow(dr);
				string TaskGuid = dr["Task_Guid"].ToString();
				string sql = "update SDrmTasks set Lock=0,LockTime=getDate(),ExecuteBy='" + StaffId + "' where Task_Guid='" + TaskGuid + "'";
				int intCount = db.executeUpdate(sql);
				if (intCount > 0)
				{
					ht.Remove(TaskGuid);
				}
			}
		}
	}

	/// <summary>
	/// 取4小时内的预约任务
	/// </summary>
	private static void GetRespeakTaskFromDB()
	{
		try
		{
			DateTime Now = DateTime.Now.AddHours(Convert.ToDouble(RespeakTime));
			string sql = "SELECT A.Task_Guid, A.Customer_Guid, B.ItemName, A.Staff_Id, A.StartTime FROM SDrmTasks A LEFT OUTER JOIN SDrmItems B ON A.Item_Id = B.Item_Id WHERE A.StartTime is not null and A.StartTime<='" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "' and A.Lock is null and A.Finish_Id is null and (B.BeginTime <= GETDATE()) AND (B.EndTime >= GETDATE()) AND (B.TaskLocation = 0) AND (B.WorkStatusId = 0) AND (B.StatusId = 0) order by A.StartTime";
			MDataBase db = new MDataBase(config.DBConn);
			_RespeakTaskPool = new Hashtable();
			db.Open();
			DataTable dt;
			bool blnReturnCode = db.GetDataTable(sql, out dt);
			if (blnReturnCode == true)
			{
                //foreach (DataRow dr in dt.Rows)
                //{
                //    Hashtable ht;
                //    if (_RespeakTaskPool.ContainsKey(dr["Staff_Id"].ToString()) == true)
                //    {
                //        ht = (Hashtable)_RespeakTaskPool[dr["Staff_Id"].ToString()];
                //        ht.Add(dr["StartTime"].ToString(), dr);
                //    }
                //    else
                //    {
                //        ht = new Hashtable();
                //        ht.Add(dr["StartTime"].ToString(), dr);
                //        _RespeakTaskPool.Add(dr["Staff_Id"].ToString(), ht);
                //    }
                //}

                foreach (DataRow dr in dt.Rows)
                {
                    Hashtable ht;
                    if (_RespeakTaskPool.ContainsKey(dr["Staff_Id"].ToString()) == true)
                    {
                        ht = (Hashtable)_RespeakTaskPool[dr["Staff_Id"].ToString()];
                        bool blnOnce = false;
                        DateTime StartTime = Convert.ToDateTime(dr["StartTime"]);
                        while (blnOnce == false)
                        {
                            if (ht.ContainsKey(StartTime) == true)
                            {
                                StartTime = StartTime.AddSeconds(1);
                            }
                            else
                            {
                                ht.Add(StartTime, dr);
                                blnOnce = true;
                            }
                        }
                    }
                    else
                    {
                        ht = new Hashtable();
                        ht.Add(dr["StartTime"].ToString(), dr);
                        _RespeakTaskPool.Add(dr["Staff_Id"].ToString(), ht);
                    }
                }

			}
			db.Close();

			_RespeakLastRefresh = DateTime.Now;
		}
        catch (Exception err) 
        {
            //string tmp = err.Message;
            ErrorLog.LogInsert(err.Message, "App_Code/OBTask","");
        }
	}

	/// <summary>
	/// 取个人任务
	/// </summary>
	private static void GetSelfTaskFromDB(string StaffId)
	{
		try
		{
			string sql = "SELECT TOP " + SelfTasks.ToString() + " A.Task_Guid, A.Customer_Guid, B.ItemName FROM SDrmTasks A LEFT OUTER JOIN SDrmItems B ON A.Item_Id = B.Item_Id WHERE StartTime is null and A.Lock is null and A.Staff_Id='" + StaffId + "' and A.Finish_Id is null and (B.BeginTime <= GETDATE()) AND (B.EndTime >= GETDATE()) AND (B.TaskLocation = 0) AND (B.WorkStatusId = 0) AND (B.StatusId = 0)";
			MDataBase db = new MDataBase(config.DBConn);
			Hashtable ht = new Hashtable();
			if (_SelfTaskPool == null)
			{
				_SelfTaskPool = new Hashtable();
			}
			db.Open();
			DataTable dt;
			bool blnReturnCode = db.GetDataTable(sql, out dt);
			if (blnReturnCode == true)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ht.Add(dr["Task_Guid"].ToString(), dr);
				}
			}
			db.Close();

			// 记录更新的记录
			if (_SelfTaskPool.ContainsKey(StaffId) == true)
			{
				_SelfTaskPool.Remove(StaffId);
			}
			_SelfTaskPool.Add(StaffId, ht);

			// 更新标记
			if (_SelfLastRefresh == null)
			{
				_SelfLastRefresh = new Hashtable();
			}
			if (_SelfLastRefresh.ContainsKey(StaffId) == true)
			{
				_SelfLastRefresh[StaffId] = ht.Count;
			}
			else
			{
				_SelfLastRefresh.Add(StaffId, ht.Count);
			}
		}
		catch { }
	}

	/// <summary>
	/// 取抢占任务
	/// 包括前期加锁未外呼的任务(即Lock=0,Finish_Id is null,LockTime为40分钟前的任务)
	/// </summary>
	/// <param name="StrategyId">单个组策略编码</param>
	private static void GetRobTaskFromDB(string StrategyId)
	{
		try
		{
			string sql = "SELECT TOP " + RobTasks.ToString() + " A.Task_Guid, A.Customer_Guid, B.ItemName FROM SDrmTasks A LEFT OUTER JOIN SDrmItems B ON A.Item_Id = B.Item_Id WHERE A.Strategy_Id='" + StrategyId + "' and A.StartTime is null and A.Lock is null and A.Finish_Id is null and (B.BeginTime <= GETDATE()) AND (B.EndTime >= GETDATE()) AND (B.TaskLocation = 0) AND (B.WorkStatusId = 0) AND (B.StatusId = 0)";
			MDataBase db = new MDataBase(config.DBConn);
			Hashtable ht = new Hashtable();
			if (_RobTaskPool == null)
			{
				_RobTaskPool = new Hashtable();
			}
			db.Open();
			DataTable dt;
			bool blnReturnCode = db.GetDataTable(sql, out dt);
			if (blnReturnCode == true)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ht.Add(dr["Task_Guid"].ToString(), dr);
				}

				// 如果抢占任务完成或快要完成,则取前期加锁未外呼的任务
				if (dt.Rows.Count < RobTasks / 2)
				{
					//SELECT TOP 1 Task_Guid FROM SDrmTasks where " + strStrategyId + "  and Finish_Id is null and Lock=0 and LockTime<=DATEADD(mi,30,getdate()) order by StartTime
					sql = "SELECT TOP " + Convert.ToString(RobTasks - dt.Rows.Count) + " A.Task_Guid, A.Customer_Guid, B.ItemName FROM SDrmTasks A LEFT OUTER JOIN SDrmItems B ON A.Item_Id = B.Item_Id WHERE A.Strategy_Id='" + StrategyId + "' AND A.Finish_Id is null AND A.Lock = 0 AND A.LockTime<=DATEADD(mi,-45,getdate()) AND (B.BeginTime <= GETDATE()) AND (B.EndTime >= GETDATE()) AND (B.TaskLocation = 0) AND (B.WorkStatusId = 0) AND (B.StatusId = 0) order by A.LockTime";
					blnReturnCode = db.GetDataTable(sql, out dt);
					if (blnReturnCode == true)
					{
						foreach (DataRow dr in dt.Rows)
						{
							ht.Add(dr["Task_Guid"].ToString(), dr);
						}
					}
				}
			}
			db.Close();

			// 记录更新的记录
			if (_RobTaskPool.ContainsKey(StrategyId) == true)
			{
				_RobTaskPool.Remove(StrategyId);
			}
			_RobTaskPool.Add(StrategyId, ht);

			// 更新标记
			if (_RobLastRefresh == null)
			{
				_RobLastRefresh = new Hashtable();
			}
			if (_RobLastRefresh.ContainsKey(StrategyId) == true)
			{
				_RobLastRefresh[StrategyId] = ht.Count;
			}
			else
			{
				_RobLastRefresh.Add(StrategyId, ht.Count);
			}
		}
		catch { }
	}

	/// <summary>
	/// 刷新外呼任务
	/// </summary>
	/// <param name="StaffId">单个职员编码</param>
	/// <param name="StrategyId">单个组策略编码</param>
	public static void RefreshOBTask(string StaffId, string StrategyId)
	{
		_GetTaskFromDBStatus = 1;
		try
		{
			// 刷新4小时内的预约任务
			RefreshRespeakTaskPool();
			// 刷新个人任务
			RefreshSelfTaskPool(StaffId);
			// 刷新抢占任务
			RefreshRobTaskPool(StrategyId);
		}
		catch(Exception err)
		{
			
		}
		_GetTaskFromDBStatus = 0;
	}

	#region 判断是否需要刷新
	private static void RefreshRespeakTaskPool()
	{
		if (_RespeakLastRefresh == null || _RespeakLastRefresh <= DateTime.Now.AddHours(-RespeakTime))
		{
			GetRespeakTaskFromDB();
		}
	}

	private static void RefreshSelfTaskPool(string StaffId)
	{
		bool blnNessdRefresh = false;

		if (_SelfTaskPool.ContainsKey(StaffId) == false)
		{
			blnNessdRefresh = true;
		}
		else if (((Hashtable)_SelfTaskPool[StaffId]).Count < Convert.ToInt32(_SelfLastRefresh[StaffId]) / 10)
		{
			// 容器中的数据小于上次更新时的数据的十分之一
			blnNessdRefresh = true;
		}

		if (blnNessdRefresh == true)
		{
			GetSelfTaskFromDB(StaffId);
		}
	}

	private static void RefreshRobTaskPool(string StrategyId)
	{
		bool blnNessdRefresh = false;

		if (_RobTaskPool.ContainsKey(StrategyId) == false)
		{
			blnNessdRefresh = true;
		}
		else if (((Hashtable)_RobTaskPool[StrategyId]).Count < Convert.ToInt32(_RobLastRefresh[StrategyId]) / 10)
		{
			// 容器中的数据小于上次更新时的数据的十分之一
			blnNessdRefresh = true;
		}

		if (blnNessdRefresh == true)
		{
			GetRobTaskFromDB(StrategyId);
		}
	}
	#endregion
}