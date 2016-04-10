<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogSearch.aspx.cs" Inherits="EmployeeManager_LogSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>个人日志查询页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>个人日志查询</center>
        <br />
        <table style="width: 561px" id="TABLE1" onclick="return TABLE1_onclick()">
            <tr>
                <td colspan="3" >
        <asp:Button ID="btnAdd" runat="server" Text=" 添加 " />
        &nbsp; &nbsp; &nbsp;
        <asp:Button ID="btnDelete" runat="server" Text=" 删除 " />
        &nbsp; &nbsp; &nbsp;
        <asp:Button ID="btnModify" runat="server" Text=" 修改 " />
        &nbsp; &nbsp; &nbsp;
        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " /><br /></td>
            </tr>
            <tr>
                <td>
                    日志主题：<asp:TextBox ID="txtLogSubject" runat="server" Width="115px"></asp:TextBox></td>
                <td colspan="2">
                    日志时间从：<asp:TextBox ID="txtDateBegin" runat="server" Width="115px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="2">
                    日志时间到：<asp:TextBox ID="txtDateEnd" runat="server" Width="115px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" valign="bottom">
        <asp:GridView ID="GridView1" runat="server" Width="556px">
        </asp:GridView>
        </td>
            </tr>
            <tr>
                <td colspan="2">
        共有<asp:Label ID="RecordeSum" runat="server" Text="**"></asp:Label>条记录/共<asp:Label
            ID="PageSum" runat="server" Text="**"></asp:Label>页&nbsp; 第<asp:Label ID="CurrentPage"
                runat="server" Text="**"></asp:Label>页 </td><td align="right">
        <asp:Button ID="FirstPage" runat="server" Text="首页" />
        <asp:Button ID="ForwardPage" runat="server" Text="上一页" />
        <asp:Button ID="NextPage" runat="server" Text="下一页" />
        <asp:Button ID="LastPage" runat="server" Text="尾页" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
