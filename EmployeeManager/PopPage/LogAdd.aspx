<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogAdd.aspx.cs" Inherits="EmployeeManager_PopPage_LogAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 566px">
            <tr>
                <td align="right" style="width: 25%">
                    <asp:Label ID="lblDate" runat="server" Text="日期："></asp:Label></td>
                <td style="width: 75%">
                    <asp:DropDownList ID="ddlDate" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlHour" runat="server">
                    </asp:DropDownList>
                    时
                    <asp:TextBox ID="txtMin" runat="server" Width="25px"></asp:TextBox>
                    分</td>
            </tr>
            <tr>
                <td align="right" >
                    <asp:Label ID="lblLogSubject" runat="server" Text="日志主题："></asp:Label></td>
                <td >
                    <asp:TextBox ID="txtLogSubject" runat="server" Width="440px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" valign="top" >
                    <asp:Label ID="lblLogContent" runat="server" Text="日志内容："></asp:Label></td>
                <td >
                    <asp:TextBox ID="txtLogContent" runat="server" Height="100px" TextMode="MultiLine" Width="440px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" >
                    <asp:Label ID="lblNoticeTime" runat="server" Text="提前多久通知：" Width="120px"></asp:Label></td>
                <td >
                    <asp:TextBox ID="txtNoticeTime" runat="server" Width="42px"></asp:TextBox>
                    分</td>
            </tr>
            <tr>
                <td >
                </td>
                <td align="right" >
                    <asp:Button ID="btnSaveLog" runat="server" Text=" 保存 " /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
