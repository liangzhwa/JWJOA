<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveRequisition.aspx.cs" Inherits="EmployeeManager_LeaveRequisition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>请销假管理页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>干部休（请）假报告单</center>
        <br />
        <table style="width: 672px" border="0">
            <tr>
                <td align="right">
                    编号：</td>
                <td style="width: 101px">
                    <asp:TextBox ID="txtLeaveID" runat="server" Width="110px"></asp:TextBox></td>
                <td align="right" colspan="4">
                    填表日期：<asp:DropDownList ID="ddlRequestDate" runat="server" Width="90px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">
                    姓名：</td>
                <td style="width: 101px">
                    <asp:TextBox ID="txtRequisitionName" runat="server" Width="110px"></asp:TextBox></td>
                <td align="right">
                    处室：</td>
                <td>
                    <asp:DropDownList ID="ddlDepartment" runat="server" Width="110px">
                    </asp:DropDownList></td>
                <td align="right" colspan="2">
                    出生年月：<asp:DropDownList ID="ddlBirthday" runat="server" Width="90px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">
                    工作年月：</td>
                <td colspan="5">
                    <asp:DropDownList ID="ddlWorkDate" runat="server" Width="110px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    休(请)假原因：</td>
                <td colspan="5" align="right">
                    <asp:TextBox ID="txtLeaveReason" runat="server" TextMode="MultiLine" Width="540px" Height="75px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    假期年月：</td>
                <td colspan="5">
                    <asp:DropDownList ID="LeaveStart" runat="server" Width="110px">
                    </asp:DropDownList>
                    &nbsp; &nbsp; &nbsp; &nbsp; 至<asp:DropDownList ID="LeaveEnd" runat="server" Width="110px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">
                    休(请)假地点：</td>
                <td style="width: 101px">
                    <asp:TextBox ID="txtToPlace" runat="server" Width="110px"></asp:TextBox></td>
                <td align="right" colspan="4">
                    年内已休天数：<asp:TextBox ID="txtLeaveDays" runat="server" Width="120px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    处室意见：</td>
                <td colspan="5" align="right">
                    <asp:TextBox ID="txtDepartmentOpinion" runat="server" TextMode="MultiLine" Width="540px" Height="75px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    批示领导：</td>
                <td colspan="5" align="left">
                    <asp:TextBox ID="txtLeaderOpinion" runat="server" TextMode="MultiLine" Width="540px" Height="75px"></asp:TextBox><br />
                    备注：探亲假不含路程往返时间</td>
            </tr>
            <tr>
                <td style="width: 115px">
                </td>
                <td align="right" colspan="5">
                    <br />
                    <asp:Button ID="btnSave" runat="server" Text=" 保存 " />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
