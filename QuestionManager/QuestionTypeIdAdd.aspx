<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionTypeIdAdd.aspx.cs" Inherits="ExamManager_QuestionTypeIdAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>题型增加</title>
    <link href="../Script/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
            <tr align="left">
                <th align="left" class="titlebar" style="text-align: center">
                    <span style="font-size: 14pt; color: black; font-family: 宋体">题型增加</span></th>
            </tr>
        </table>
        <br />
        <asp:Panel ID="palQuestionType" runat="server" BackColor="White" GroupingText="题型" Height="50px"
            Width="600px">
            <table>
                <tr>
                    <td>
                        类型ID：</td>
                    <td style="width: 1px">
                        <asp:TextBox ID="txtQuestionTypeId" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvQuestionTypeId" runat="server" ErrorMessage="类型ID不能为空" ControlToValidate="txtQuestionTypeId" Width="108px"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblQuestionTypeId" runat="server" ForeColor="Red" Text="类型ID已经存在"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        类型名称：</td>
                    <td style="width: 1px">
                        <asp:TextBox ID="txtQuestionTypeName" runat="server"></asp:TextBox></td>
                    <td style="width: 1px">
                        <asp:RequiredFieldValidator ID="rfvQuestionTypeName" runat="server" ErrorMessage="类型名趁不能为空" ControlToValidate="txtQuestionTypeName" Width="120px"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblQuestionTypeName" runat="server" ForeColor="Red" Text="该类型已经存在" Width="105px"></asp:Label></td>
                </tr>
            </table>
            &nbsp;<br />
            <asp:Button ID="btnOK" runat="server" Text="保 存" OnClick="btnOK_Click" />&nbsp;&nbsp;<asp:Button
                ID="btnQuestionAdd" runat="server" Text="返 回" CausesValidation="False" OnClick="btnQuestionAdd_Click" />
            <br />
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
