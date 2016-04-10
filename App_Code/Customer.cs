using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Customer 的摘要说明
/// </summary>
public class Customer
{
    /// <summary>
    /// 取消敏感
    /// </summary>
    /// <param name="Mobile"></param>
    public void CanCleSensitive(string DBConn, string Mobile)
    {
        try
        {
            CCustomerSensitive cs = new CCustomerSensitive(DBConn);
            cs.Mobile = Mobile;
            cs.GetInfo();

            cs.SenEndTime = DateTime.Now.AddHours(Convert.ToDouble(-1));
            cs.SenPeriod = 1;
            cs.Update();
            //string sql = "update Customer set IsSensitive=0 where Customer_Guid='" + ViewState["Customer_Guid"].ToString() + "'";
            //    //db.executeUpdate(sql);
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "App_Code/Customer.CanCleSensitive", "");
        }
    }
}
