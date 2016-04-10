<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WatchAdd.aspx.cs" Inherits="EmployeeManager_PopPage_WatchAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 320px" border="0">
            <tr>
                <td align="right" style="width:30%;">
                    值班日期：</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="110px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">
                    值班领导：</td>
                <td >
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="110px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">
                    值班人：</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
                    <asp:TextBox ID="TextBox5" runat="server" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    值班电话：</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="right">
                    <br />
                    <asp:Button ID="btnSave" runat="server" Text=" 保存 " /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
