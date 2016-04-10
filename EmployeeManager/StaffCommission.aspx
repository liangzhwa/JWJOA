<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffCommission.aspx.cs" Inherits="EmployeeManager_StaffCommission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>人员委托</title>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset style="text-align:center; vertical-align:text-bottom"> <legend>委托信息</legend>
        <table style="width: 92%">
            <tr>
                <td style="width: 102px" align="right">
                    委托人：</td>
                <td style="width: 437px" align="left">
                    <asp:TextBox ID="txtCommiser" runat="server" Width="275px"></asp:TextBox>
                    <input id="btnSelect1" type="button" value="选择人员" /></td>
            </tr>
            <tr>
                <td style="width: 102px" align="right">
                    被委托人：</td>
                <td style="width: 437px" align="left">
                    <asp:TextBox ID="txtCommised" runat="server" Width="277px"></asp:TextBox>
                    <input id="btnSelect2" type="button" value="选择人员" /></td>
            </tr>
            <tr>
                <td style="width: 102px" align="right" valign="top">
                    委托原因：</td>
                <td align="left">
                    <asp:TextBox ID="txtCommissionReason" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 102px" align="right">
                    委托日期：</td>
                <td align="left">
                    <asp:TextBox ID="txtDateStart" runat="server"></asp:TextBox>到<asp:TextBox ID="txtDateEnd"
                        runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 102px">
                </td>
                <td align="right">
                    <asp:Button ID="btnSave" runat="server" Text=" 保存 " /></td>
            </tr>
        </table>
    </fieldset>
    <fieldset style="text-align:right"><legend>被委托人核实</legend>
        <asp:Button ID="btnOK" runat="server" Text=" 同意 " />
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="btnNO" runat="server" Text="不同意" /></fieldset>
    </form>
</body>
</html>
