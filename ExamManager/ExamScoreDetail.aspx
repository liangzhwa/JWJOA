<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamScoreDetail.aspx.cs" Inherits="ExamManager_ExamScoreDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>参考人员详细信息页面</title>
    <link href="../Script/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellspacing="0" cellpadding="3" width="100%">
      <tr align="left">
        <th align="left" class="titlebar" style="text-align: center">
            <span style="font-size: 14pt; color: black; font-family: 宋体">
            参考人员详细信息</span></th>
      </tr>
    </table>
        <br />
        <table>
            <tr>
                <td>
                    考试ID：</td>
                <td>
                    <asp:Label ID="lblExamId" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    考试名称：</td>
                <td>
                    <asp:Label ID="lblExamName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    考试人：</td>
                <td>
                    <asp:Label ID="lblstaff" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    开始时间：</td>
                <td>
                    <asp:Label ID="lblStartTime" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    交卷时间：</td>
                <td>
                    <asp:Label ID="lblEndTime" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    正确题数：</td>
                <td>
                    <asp:Label ID="lblRightCount" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    错误题数：</td>
                <td>
                    <asp:Label ID="lblWrongCount" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    未做题数：</td>
                <td>
                    <asp:Label ID="lblUnfinishCount" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    分数：</td>
                <td>
                    <asp:Label ID="lblScore" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    平均分：</td>
                <td>
                    <asp:Label ID="lblAverage" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    名次：</td>
                <td>
                    <asp:Label ID="lblGradation" runat="server"></asp:Label></td>
            </tr>
        </table>
        <br />
        <input type="button" value="返 回" onclick="history.go(-1)" /></div>
    </form>
</body>
</html>
