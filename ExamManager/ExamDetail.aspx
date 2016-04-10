<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamDetail.aspx.cs" Inherits="ExamManager_ExamDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>试卷详细信息页面</title>
     <link href="../Script/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellspacing="0" cellpadding="3" width="100%">
      <tr align="left">
        <th align="left" class="titlebar" style="text-align: center">
            <span style="font-size: 14pt; color: black; font-family: 宋体">
            试卷详细信息</span></th>
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
                    评分类型：</td>
                <td>
                    <asp:Label ID="lblScoreType" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    开始时间：</td>
                <td>
                    <asp:Label ID="lblStartTime" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    结束时间：</td>
                <td>
                    <asp:Label ID="lblEndTime" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    考试时长：</td>
                <td>
                    <asp:Label ID="lblTimes" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    题目数量：</td>
                <td>
                    <asp:Label ID="lblCount" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    报名人数：</td>
                <td>
                    <asp:Label ID="lblEmploeesCount" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    参考人数：</td>
                <td>
                    <asp:Label ID="lblExamEmploees" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    参考率：</td>
                <td>
                    <asp:Label ID="lblRatio" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    创建人：</td>
                <td>
                    <asp:Label ID="lblCreatedBy" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    创建时间：</td>
                <td>
                    <asp:Label ID="lblCreatedDate" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    修改人：</td>
                <td>
                    <asp:Label ID="lblModifiedBy" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    修改时间：</td>
                <td>
                    <asp:Label ID="lblModifiedDate" runat="server"></asp:Label></td>
            </tr>
        </table>
    </div>
        <br />
        <input onclick="history.go(-1)" type="button" value="返 回" />
    </form>
</body>
</html>
