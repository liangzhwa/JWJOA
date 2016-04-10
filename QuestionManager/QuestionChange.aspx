<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionChange.aspx.cs" Inherits="QuestionChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>题库增加</title>
    <link href="../Script/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="3" cellspacing="0" width="100%">
            <tr align="left">
                <th align="left" class="titlebar" style="text-align: center">
                    <span style="font-size: 14pt; color: black; font-family: 宋体">题库修改</span></th>
            </tr>
        </table>
        <br />
        <asp:Panel ID="palQuestionChange" runat="server" BackColor="White" GroupingText="题目" Height="50px"
            Width="730px">
            <table>
                <tr>
                    <td style="width: 80px">
                        题目：</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtQuestionChange" runat="server" Columns="51" TextMode="MultiLine" Height="60px" Width="422px"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" ControlToValidate="txtQuestionChange"
                            ErrorMessage="题目不能为空"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblError" runat="server" Text="该题已经存在" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 80px">
                        题目类型：</td>
                    <td colspan="3">
                        <asp:DropDownList ID="sltQuestionTypeId" runat="server" Width="100px" >
                        </asp:DropDownList></td>
                    <td colspan="1">
                    </td>
                </tr>
                <tr>
                    <td style="width: 80px">
                        <asp:Label ID="lblAnswerShow" runat="server" Text="正确答案："></asp:Label></td>
                    <td colspan="3">
                        <asp:Label ID="lblAnswer" runat="server"></asp:Label>
                        <asp:Label ID="lblAnswerError" runat="server" Text="未钩选正确答案！" ForeColor="Red"></asp:Label></td>
                    <td colspan="1">
                    </td>
                </tr>
                <tr>
                    <td style="width: 80px">
                        <asp:CheckBox ID="ckbAnswerA" runat="server" AutoPostBack="True" OnCheckedChanged="ckbAnswerA_CheckedChanged"
                            Text="答案A:" /></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAnswerA" runat="server" Columns="80"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:RequiredFieldValidator ID="rfvAnswerA" runat="server" ControlToValidate="txtAnswerA"
                            ErrorMessage="答案A不能为空"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 80px">
                        <asp:CheckBox ID="ckbAnswerB" runat="server" AutoPostBack="True" OnCheckedChanged="ckbAnswerB_CheckedChanged"
                            Text="答案B:" /></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAnswerB" runat="server" Columns="80"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:RequiredFieldValidator ID="rfvAnswerB" runat="server" ControlToValidate="txtAnswerB"
                            ErrorMessage="答案B不能为空"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 80px">
                        <asp:CheckBox ID="ckbAnswerC" runat="server" AutoPostBack="True" OnCheckedChanged="ckbAnswerC_CheckedChanged"
                            Text="答案C:" />&nbsp;</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAnswerC" runat="server" Columns="80"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:RequiredFieldValidator ID="rfvAnswerC" runat="server" ControlToValidate="txtAnswerC"
                            ErrorMessage="答案C不能为空"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 80px">
                        <asp:CheckBox ID="ckbAnswerD" runat="server" AutoPostBack="True" OnCheckedChanged="ckbAnswerD_CheckedChanged"
                            Text="答案D:" /></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAnswerD" runat="server" Columns="80"></asp:TextBox></td>
                    <td colspan="1">
                    </td>
                </tr>
                <tr>
                    <td style="width: 80px; height: 20px">
                        <asp:CheckBox ID="ckbAnswerE" runat="server" AutoPostBack="True" OnCheckedChanged="ckbAnswerE_CheckedChanged"
                            Text="答案E:" /></td>
                    <td colspan="3" style="height: 20px">
                        <asp:TextBox ID="txtAnswerE" runat="server" Columns="80"></asp:TextBox></td>
                    <td colspan="1" style="height: 20px">
                        <asp:Label ID="lblAnswerE" runat="server" ForeColor="Red" Text="请先填答案D"></asp:Label></td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Button ID="btnOK" runat="server" Text="保 存" OnClick="btnOK_Click" />&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="返 回" CausesValidation="False" OnClick="btnSearch_Click" /></div>
    </form>
</body>
</html>
