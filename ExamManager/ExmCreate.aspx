<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExmCreate.aspx.cs" Inherits="ExamManager_ExamCreat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>考试创建</title>
    <link href="../Script/style.css" rel="stylesheet" type="text/css"/>
     <script language="javascript" type="text/javascript"><!--#INCLUDE VIRTUAL="../js/Mcalendar.js"--></script>
     <script type="text/javascript" language="javascript">
        function showModalDialog11()
        {
          var sRet = window.showModalDialog('../EmployeeManager/IsStaffOnline.aspx','角色添加页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
          if (sRet!=null)
            {
                document.all.txtStaff.value = sRet.substring(0,sRet.length-1);
            }  
        }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
            <tr align="left">
                <th align="left" class="titlebar" style="text-align: center">
                    <span style="font-size: 14pt; color: black; font-family: 宋体">
                        <asp:Label ID="lblHead" runat="server"></asp:Label></span></th>
            </tr>
        </table>
        <br />
        考试名称：<asp:TextBox ID="txtExamName" runat="server"></asp:TextBox>
        <br />
        <br />
        分配人员：<asp:TextBox ID="txtStaff" runat="server"></asp:TextBox>
        <input type="button" value="分配人员" onclick="showModalDialog11();" />
        &nbsp; &nbsp; &nbsp; &nbsp;评分类型：<asp:DropDownList ID="sltScoreType" runat="server">
            <asp:ListItem Value="0">当时评分</asp:ListItem>
            <asp:ListItem Value="1">统一评分</asp:ListItem>
        </asp:DropDownList><br />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label><asp:RegularExpressionValidator
            ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtTimeHourStart"
            ErrorMessage="必须输入小于24的正整数" ValidationExpression="^(0|[0-9]{1,2}|24)+$"></asp:RegularExpressionValidator><br />
        <asp:Panel ID="palCategories" runat="server" BackColor="White" GroupingText="题目分类"
            Height="50px" Width="100%">
            <table style="width: 100%">
                <tr>
                    <td style="width: 50%">
                        题目类别一：<asp:DropDownList ID="sltQuestionTypeIdOne" runat="server">
                        </asp:DropDownList><asp:TextBox ID="txtPercentageOne" runat="server" Columns="1"></asp:TextBox>条<asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPercentageOne"
                            ErrorMessage="必须输入正整数" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator></td>
                    <td style="width: 50%">
                        题目类别二：<asp:DropDownList ID="sltQuestionTypeIdTwo" runat="server">
                        </asp:DropDownList><asp:TextBox ID="txtPercentageTwo" runat="server" Columns="1"></asp:TextBox>条<asp:RegularExpressionValidator
                            ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPercentageTwo"
                            ErrorMessage="必须输入正整数" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 50%;">
                        题目类别三：<asp:DropDownList ID="sltQuestionTypeIdThree" runat="server">
                        </asp:DropDownList><asp:TextBox ID="txtPercentageThree" runat="server" Columns="1"></asp:TextBox>条<asp:RegularExpressionValidator
                            ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPercentageThree"
                            ErrorMessage="必须输入正整数" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator></td>
                    <td style="width: 50%">
                        题目类别四：<asp:DropDownList ID="sltQuestionTypeIdFour" runat="server">
                        </asp:DropDownList><asp:TextBox ID="txtPercentageFour" runat="server" Columns="1"></asp:TextBox>条<asp:RegularExpressionValidator
                            ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPercentageFour"
                            ErrorMessage="必须输入正整数" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 50%;">
                        题目类别五：<asp:DropDownList ID="sltQuestionTypeIdFive" runat="server">
                        </asp:DropDownList><asp:TextBox ID="txtPercentageFive" runat="server" Columns="1"></asp:TextBox>条<asp:RegularExpressionValidator
                            ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPercentageFive"
                            ErrorMessage="必须输入正整数" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator></td>
                    <td style="width: 50%">
                        题目类别六：<asp:DropDownList ID="sltQuestionTypeIdSix" runat="server">
                        </asp:DropDownList><asp:TextBox ID="txtPercentageSix" runat="server" Columns="1"></asp:TextBox>条<asp:RegularExpressionValidator
                            ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtPercentageSix"
                            ErrorMessage="必须输入正整数" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator></td>
                </tr>
            </table>
        </asp:Panel>
    </div><table style="width: 100%">
        <tr>
            <td style="width: 50%">
        开始日期：<asp:TextBox ID="txtTimeStart" runat="server" Columns="15"></asp:TextBox><input class="zzd" onclick="calendar(document.form1.txtTimeStart)" style="width: 30px;
            height: 18px" type="button" value="日历" />
                <asp:TextBox ID="txtTimeHourStart" runat="server" Columns="1"></asp:TextBox>时<asp:TextBox ID="txtMinStart" runat="server" Columns="1" ValidationGroup="1"></asp:TextBox>分</td>
            <td style="width: 50%">
                &nbsp; &nbsp; &nbsp; 到
        <asp:TextBox ID="txtTimeEnd" runat="server" Columns="15"></asp:TextBox><input class="zzd" onclick="calendar(document.form1.txtTimeEnd)" style="width: 30px;
            height: 18px" type="button" value="日历" />
        <asp:TextBox ID="txtTimeHourEnd" runat="server" Columns="1" ValidationGroup="1"></asp:TextBox>时<asp:TextBox ID="txtMinEnd" runat="server" Columns="1" ValidationGroup="1"></asp:TextBox>分</td>
        </tr>
        <tr>
            <td style="width: 50%">
        题目数量：<asp:TextBox ID="txtQuestionCount" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="rfvQuestionCount" runat="server" ControlToValidate="txtQuestionCount"
            ErrorMessage="必须输入正整数" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
            </td>
            <td style="width: 50%">
                考试时间：<asp:TextBox ID="txtQuestionTime" runat="server"></asp:TextBox>分钟</td>
        </tr>
    </table>
        &nbsp;<br />
        <br />
        <table style="width: 100%">
            <tr>
                <td style="width: 80%">
                </td>
                <td style="width: 20%">
        <asp:Button ID="btnDist" runat="server" OnClick="btnDist_Click" Text="分　配" />
                    <input type="button" value="返　回" onclick="history.go(-1)" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
