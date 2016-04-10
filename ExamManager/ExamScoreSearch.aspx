<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamScoreSearch.aspx.cs" Inherits="ExamManager_ExamScoreSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>个人成绩查看页面</title>
    <link href="../Script/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellspacing="0" cellpadding="3" width="100%">
      <tr align="left">
        <th align="left" class="titlebar" style="text-align: center">
            <span style="font-size: 14pt; color: black; font-family: 宋体">
            个人成绩查看</span></th>
      </tr>
    </table>
        <br />
        <asp:Panel ID="palScore" runat="server" BackColor="White" GroupingText="个人考试信息" Height="50px"
            Width="100%">
            &nbsp;考试名称：<asp:TextBox ID="txtExamName" runat="server"></asp:TextBox>
            &nbsp; &nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="查 询" OnClick="btnSearch_Click" /><br />
            <table style="width: 100%">
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvScore" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True">
                            <Columns>
                                <asp:BoundField DataField="ExamName" HeaderText="考试名称">
                                    <ItemStyle CssClass="item" />
                                    <HeaderStyle CssClass="label" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StartTime" HeaderText="考试日期">
                                    <ItemStyle CssClass="item" />
                                    <HeaderStyle CssClass="label" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Score" HeaderText="分数">
                                    <ItemStyle CssClass="item" />
                                    <HeaderStyle CssClass="label" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Average" HeaderText="平均分">
                                    <ItemStyle CssClass="item" />
                                    <HeaderStyle CssClass="label" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Gradation" HeaderText="名次">
                                    <ItemStyle CssClass="item" />
                                    <HeaderStyle CssClass="label" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCountScore" runat="server"></asp:Label><asp:Label ID="lblPageScore"
                            runat="server"></asp:Label><asp:Label ID="lblCountPageScore" runat="server"></asp:Label></td>
                    <td style="text-align: right">
                        &nbsp;<asp:Button ID="btnFirstPageScore" runat="server" CommandArgument="first" OnClick="PagerButtonScore_Click"
                            Text="首 页" />&nbsp;<asp:Button ID="btnForwardPageScore" runat="server" CommandArgument="prev"
                                OnClick="PagerButtonScore_Click" Text="上 页" />&nbsp;<asp:Button ID="btnNextPageScore"
                                    runat="server" CommandArgument="next" OnClick="PagerButtonScore_Click" Text="下 页" />&nbsp;<asp:Button
                                        ID="btnLastPageScore" runat="server" CommandArgument="last" OnClick="PagerButtonScore_Click"
                                        Text="尾 页" /></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:HiddenField ID="CurrentPageScore" runat="server" />
    </div>
    </form>
</body>
</html>
