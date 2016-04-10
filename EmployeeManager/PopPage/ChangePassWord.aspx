<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassWord.aspx.cs" Inherits="EmployeeManager_PopPage_ChangePassWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>密码修改页面</title>
    <base target="_self"></base>
    <script type="text/javascript" language="javascript">
        function closeWin()
        {
            window.returnValue = "refresh";
            window.close();
        }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <center>密码修改</center>
        <center>
            &nbsp;</center>
        <center>
            <table style="width: 263px">
                <tr>
                    <td align="right">
                        原密码：</td>
                    <td align="left" style="width: 158px">
                        <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">
                        新密码：</td>
                    <td align="left" style="width: 158px">
                        <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="height: 21px">
                        确认密码：</td>
                    <td align="left" style="width: 158px; height: 21px">
                        <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="height: 21px">
                    </td>
                    <td align="right" style="width: 158px; height: 21px">
                        <br />
                        <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text=" 确认 " /></td>
                </tr>
            </table>
        </center>
    
    </div>
    </form>
</body>
</html>
