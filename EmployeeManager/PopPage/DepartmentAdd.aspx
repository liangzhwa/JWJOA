<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartmentAdd.aspx.cs" Inherits="EmployeeManager_PopPage_DepartmentAdd" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<META HTTP-EQUIV="pragma" CONTENT="no-cache"/>
<META HTTP-EQUIV="Cache-Control" CONTENT="no-cache, must-revalidate"/>
<META HTTP-EQUIV="expires" CONTENT="Mon, 23 Jan 1978 20:52:30 GMT"/>
    <title>部门添加页面</title>

    <base target="_self"></base>
    <script type="text/javascript" language="javascript">
        function closeWin()
        {
            window.returnValue = "refresh";
            //window.dialogArguments.location.reload();
            window.close();
        }
         
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <asp:Label ID="lblCaption" runat="server"></asp:Label></center>
    <table border ="0" cellpadding="0" cellspacing ="5">
        <tr> 
        <td>       
        <asp:Label ID="lblDepartmentName" runat="server" Text="部门名称："></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtDepartmentName" runat="server" Width="175px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="lblSupDepartment" runat="server" Text="上级部门："></asp:Label>
        </td>
        <td>
        <asp:DropDownList ID="ddlSupDepartment" runat="server" Width="180px"></asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td valign="top">
        <asp:Label ID="lblDepartmentNote" runat="server" Text="部门说明："></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtDepartmentNote" runat="server" Height="63px" TextMode="MultiLine"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td valign="top">
            </td>
        <td align="right">
            <input id="btnCancel" type="button" value=" 取消 " onclick="window.close();"/>
            &nbsp; &nbsp;<asp:Button ID="btnSave" runat="server" Text=" 保存 " OnClick="btnSave_Click" /></td>
        </tr>
    </table>
        <asp:HiddenField ID="hfIsUpdate" runat="server" />
    </form>
</body>
</html>
