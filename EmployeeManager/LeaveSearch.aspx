<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveSearch.aspx.cs" Inherits="EmployeeManager_LeaveSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>请假查询页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>干部休（请）假报告单</center><br />
        <table style="width: 616px">
            <tr>
                <td colspan="2">
        <asp:Button ID="btnAdd" runat="server" Text=" 添加 " />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text=" 删除 " />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnModify" runat="server" Text=" 修改 " />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " /></td>
            </tr>
            <tr>
                <td style="width: 205px">
                    姓名：<asp:TextBox ID="txtRequisitionName" runat="server" Width="115px"></asp:TextBox>
        &nbsp; &nbsp;</td>
                <td align="right">
                    填表日期从：<asp:DropDownList ID="ddlRequestStartDate" runat="server" Width="85px">
                    </asp:DropDownList>
                    到
                    <asp:DropDownList ID="ddlRequestEndDate" runat="server" Width="85px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" valign="bottom">
        <asp:GridView ID="gdvLeave" runat="server" Width="613px" Height="189px">
        </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 205px">
        共有<asp:Label ID="RecordeSum" runat="server" Text="**"></asp:Label>条记录/共<asp:Label
            ID="PageSum" runat="server" Text="**"></asp:Label>页&nbsp; 第<asp:Label ID="CurrentPage"
                runat="server" Text="**"></asp:Label>页</td>
                <td align="right">
                    &nbsp;<asp:Button ID="FirstPage" runat="server" Text="首页" />
        <asp:Button ID="ForwardPage" runat="server" Text="上一页" />
        <asp:Button ID="NextPage" runat="server" Text="下一页" />
        <asp:Button ID="LastPage" runat="server" Text="尾页" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
