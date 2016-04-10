<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DutyTransmit.aspx.cs" Inherits="DutyTransmit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>勤务确认</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    值班人员操作选择(选择您要对该勤务进行的操作)
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="修改首次电话登记" Width="345px" OnClick="Button1_Click" /></td>
            </tr>
             <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="补充电话登记" Width="345px" OnClick="Button2_Click" /></td>
            </tr>
             <tr>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="勤务中接到电话登记" Width="345px" OnClick="Button3_Click" /></td>
            </tr>
              <tr>
                <td style="height: 21px">
                    <asp:Button ID="Button4" runat="server" Text="勤务完成去电登记" Width="345px" OnClick="Button4_Click" /></td>
            </tr>
              <tr>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="修改勤务地点" Width="345px" OnClick="Button5_Click" /></td>
            </tr>
             <tr>
                <td>
                    <asp:Button ID="Button6" runat="server" Text="查看勤务" Width="345px" OnClick="Button6_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
