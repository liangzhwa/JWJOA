<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExmExam.aspx.cs" Inherits="ExamManager_ExamAnswer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>考试页面</title>
    <link href="../Script/style.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
var CallTimeLen = "0";
var timer1 = null;

function DoCallTimer()
{  
  var minute="0";
     var second="0";
  CallTimeLen = parseInt(CallTimeLen)+1;
  minute = parseInt(CallTimeLen/60);
  second = CallTimeLen%60;
  if(minute=="0")
  {
   document.frmtimer.thzt.innerText =second+"秒";
  }
  else
  {
   document.frmtimer.thzt.innerText =minute+"分"+second+"秒";
  }
  window.timer1 = window.setTimeout("DoCallTimer()",1000);
}
function stop()
{
 clearTimeout(window.timer1);
}
function dopost()
{   
 var btn = document.getElementById("btnOK");   
 btn.click();   
} 
</script>
</head>
<body>

    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
            <tr align="left">
                <th align="left" class="titlebar" style="text-align: center">
                    <span style="font-size: 14pt; color: black; font-family: 宋体">考试试卷</span></th>
            </tr>
        </table>
        <br />
        <asp:Panel ID="palQuestionAdd" runat="server" Height="40px" Width="100%">
            <asp:Button ID="btnShow" runat="server" Text="随即生成试卷" OnClick="btnShow_Click" CausesValidation="False" />
            <asp:Label ID="lblExamCount" runat="server"></asp:Label></asp:Panel>
        <br />
        <asp:Panel ID="palExamInformation" runat="server" Height="50px" Width="100%">
            <table width="100%">
                <tr>
                    <td style="width: 11%; height: 20px;">
                        <asp:Label ID="lblStart" runat="server" Text="开始时间："></asp:Label></td>
                    <td style="width: 22%; height: 20px;">
                        <asp:Label ID="lblStartTime" runat="server"></asp:Label></td>
                    <td style="width: 11%; height: 20px;">
                        <asp:Label ID="lblEnd" runat="server" Text="结束时间："></asp:Label></td>
                    <td style="width: 22%; height: 20px;">
                        <asp:Label ID="lblEndTime" runat="server"></asp:Label></td>
                    <td style="width: 11%; height: 20px;">
                        <asp:Label ID="lblCount" runat="server" Text="考试进度："></asp:Label></td>
                    <td colspan="2" style="width: 22%; height: 20px;">
                        <asp:Label ID="lblQuestionCount" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 11%; height: 7px">
                        <asp:Label ID="lblUseTime" runat="server" Text="使用时间："></asp:Label></td>
                    <td style="height: 7px"><form name="frmtimer" action="" method="post">
<input type="text" name="thzt1" id="Text2"></form></td>
                    <td style="width: 11%; height: 7px">
                        <asp:Label ID="lblSurplus" runat="server" Text="距离交卷："></asp:Label></td>
                    <td style="width: 22%; height: 7px"><form name="frmtimer" action="" method="post">
<input type="text" name="thzt2" id="Text1"></form>
                        </td>
                    <td colspan="3" style="width: 33%; height: 7px">
            <asp:Label ID="lblTip" runat="server"></asp:Label></td>
                </tr>
            </table>
            <br />
            <asp:HiddenField ID="hfdTimes" runat="server" />
            &nbsp;
        </asp:Panel>
        <br />
        <asp:Panel ID="palQuestion" runat="server" GroupingText="题目" Height="50px" Width="100%" BackColor="White">
            题号：<asp:Label ID="lblQuestionId" runat="server"></asp:Label><br />
            题目：<asp:Label ID="lblQuestion" runat="server"></asp:Label><br />
            <asp:Label ID="lblAnswerShow" runat="server" Text="答案："></asp:Label><asp:Label ID="lblAnswer" runat="server"></asp:Label><br />
            <asp:CheckBox ID="chkAnswerA" runat="server" Text="A" OnCheckedChanged="chkAnswerA_CheckedChanged" AutoPostBack="True" />&nbsp;
            <asp:Label ID="lblAnwerA" runat="server"></asp:Label><br />
            <asp:CheckBox ID="chkAnswerB" runat="server" Text="B" OnCheckedChanged="chkAnswerB_CheckedChanged" AutoPostBack="True" />&nbsp;
            <asp:Label ID="lblAnwerB" runat="server"></asp:Label><br />
            <asp:CheckBox ID="chkAnswerC" runat="server" Text="C" OnCheckedChanged="chkAnswerC_CheckedChanged" AutoPostBack="True" />&nbsp;
            <asp:Label ID="lblAnwerC" runat="server"></asp:Label><br />
            <asp:CheckBox ID="chkAnswerD" runat="server" Text="D" OnCheckedChanged="chkAnswerD_CheckedChanged" AutoPostBack="True" />&nbsp;
            <asp:Label ID="lblAnwerD" runat="server"></asp:Label><br />
            <asp:CheckBox ID="chkAnswerE" runat="server" Text="E" OnCheckedChanged="chkAnswerE_CheckedChanged" AutoPostBack="True" />&nbsp;
            <asp:Label ID="lblAnwerE" runat="server"></asp:Label>
            <asp:HiddenField ID="hfdQuestionGuid" runat="server" /><asp:HiddenField ID="hfdState" runat="server" />
            <br />
            <br />
            <asp:Label ID="lblAnswerOver" runat="server" Text="如果答错，评分后正确答案显示区域"></asp:Label></asp:Panel>
        &nbsp;<br />
        &nbsp;
        <table style="width: 100%">
            <tr>
                <td style="width: 15%; height: 20px;">
        <asp:Label ID="lblScore" runat="server" Text="成绩显示区域"></asp:Label></td>
                <td colspan="3" style="width: 25%; height: 20px;">
                    <asp:Button ID="btnFrist" runat="server" Text="第一题" OnClick="btnFrist_Click" />
                    <asp:Button ID="btnprev" runat="server" Text="上一题" OnClick="btnprev_Click" />
                    <asp:Button ID="btnNext" runat="server" Text="下一题" OnClick="btnNext_Click" /></td>
                <td style="width: 60%; text-align: right; height: 20px;">
        <asp:Button ID="btnOK" runat="server" Text="提交试卷" OnClick="btnOK_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
