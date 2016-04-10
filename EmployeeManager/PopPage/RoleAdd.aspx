<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleAdd.aspx.cs" Inherits="EmployeeManager_PopPage_RoleAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
<META HTTP-EQUIV="pragma" CONTENT="no-cache"/>
<META HTTP-EQUIV="Cache-Control" CONTENT="no-cache, must-revalidate"/>
<META HTTP-EQUIV="expires" CONTENT="Mon, 23 Jan 1978 20:52:30 GMT"/>
    <title>角色添加页面</title>
    <base target="_self"></base>
    <script type="text/javascript" language="javascript">
        function closeWin()
        {        
            window.returnValue = "refresh";            
            window.close();
        }
    
    </script>
</head>
<body style="text-align: center;overflow:auto;">
    <form id="form1" runat="server">
   
    <div >
    <center>
        <asp:Label ID="lblCaption" runat="server" Text="Label"></asp:Label></center>
        <center>
            <br />
        <table border="0" cellpadding="0" cellspacing="5" width="700" style="height: 314px">
            <tr>
                <td align="right">
                    <asp:Label ID="lblRoleName" runat="server" Text="角色名称："></asp:Label>&nbsp;</td>
                <td style="width: 191px; height: 29px">
                    <asp:TextBox ID="txtRoleName" runat="server" Width="100%"></asp:TextBox></td>
                <td rowspan="3" valign="top" align="right" style="width: 100px">
                    <asp:Label ID="lblFunctionSelect" runat="server" Text="功能选择："></asp:Label>
                </td>
                <td rowspan="3" valign="top" style="width: 257px" align="left">
                    <asp:CheckBoxList ID="cblFunctionSelect" runat="server" Height="100%" Width="100%">
                    </asp:CheckBoxList>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    <asp:Label ID="lblRoleNote" runat="server" Text="角色说明："></asp:Label>&nbsp;</td>
                <td valign="top" style="width: 191px">
                    <asp:TextBox ID="txtRoleNote" runat="server" Height="169px" TextMode="MultiLine" Width="99%"></asp:TextBox>&nbsp;</td>
            </tr>            
            <tr>
                <td valign="top" align="right" colspan="2">
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
            <td colspan="3" >
            </td >
                <td align="left">
                    <asp:Button ID="btnSave" runat="server" Text=" 保存 " OnClick="btnSave_Click" />
                    &nbsp;&nbsp;
                    <input id="btnCancel" onclick="window.close();" type="button" value=" 取消 " />&nbsp;</td>
            </tr>
        </table>
        </center>
    </div>
        <asp:HiddenField ID="hfIsUpdate" runat="server" />
    </form>
</body>
</html>
