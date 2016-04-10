<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>菜单显示</title>
	<link href="style/style.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color:#EDF4FF;">
    <form id="form1" runat="server">
    <div style="height:90; text-align: center;OVERFLOW:auto;HEIGHT:100%">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
