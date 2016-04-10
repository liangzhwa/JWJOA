<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WatchManager.aspx.cs" Inherits="EmployeeManager_WatchManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>值班人员管理页面</title>
    <script type="text/javascript" language="javascript">
        function PopWindow()
        {
            window.open('../EmployeeManager/PopPage/WatchAdd.aspx','值班人员添加页面','height=250, width=350, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-350)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            值班人员管理</center><br />
            <table style="width: 616px" border="0">
            <tr>
                <td colspan="2">
        <button id="btnAdd" style="height:23px;width:57px;" onclick="PopWindow()">
            添加</button>
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text=" 删除 " />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnModify" runat="server" Text=" 修改 " />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " /><br />
                </td>
            </tr>
            <tr>
                <td style="width: 307px">
                    值班日期从：<asp:DropDownList ID="ddlOndutyStartDate" runat="server" Width="85px">
                    </asp:DropDownList>
                    到
                    <asp:DropDownList ID="ddlOndutyEndDate" runat="server" Width="85px">
                    </asp:DropDownList></td>
                <td align="right">
                    <asp:Button ID="btnSearch2" runat="server" Text=" 查询 " />&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" valign="bottom">
        <asp:GridView ID="gdvLeave" runat="server" Width="607px" Height="189px">
        </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 307px">
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