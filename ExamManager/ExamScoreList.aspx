<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamScoreList.aspx.cs" Inherits="ExamManager_ExamScoreList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>成绩评定</title>
    <link href="../Script/style.css" rel="stylesheet" type="text/css">
     <script language="javascript"><!--#INCLUDE VIRTUAL="../js/Mcalendar.js"--></script>
</head>
<body>
    <form id="form1" runat="server">
    <div> <table border="0" cellspacing="0" cellpadding="3" width="100%">
      <tr align="left">
        <th align="left" class="titlebar" style="text-align: center">
            <span style="font-size: 14pt; color: black; font-family: 宋体">
            成绩评定</span></th>
      </tr>
    </table>
        <br />
        <asp:Panel ID="palExam" runat="server" GroupingText="试卷选择" BackColor="White" Width="100%">
            <asp:Button ID="btnExamDetail" runat="server" Text="详细信息" OnClick="btnExamDetail_Click" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            <table style="width: 100%">
                <tr>
                    <td colspan="2" style="width: 35%">
                        考试名称：<asp:TextBox ID="txtExamName" runat="server"></asp:TextBox></td>
                    <td colspan="2">
                        时间：<asp:TextBox ID="txtTimeStart" runat="server" Columns="15"></asp:TextBox>
                        <input class="zzd" onclick="calendar(document.form1.TxtFromDate)" style="width: 30px;
                            height: 18px" type="button" value="日历" />到<asp:TextBox ID="txtTimeEnd" runat="server" Columns="15"></asp:TextBox>
                        <input class="zzd" onclick="calendar(document.form1.TxtFromDate)" style="width: 30px;
                            height: 18px" type="button" value="日历" /></td>
                    <td style="width: 10%">
                        <asp:Button ID="btnSearchExam" runat="server" Text="查询考试" OnClick="btnSearchExam_Click" /></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="gvExam" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="item" />
                                    <HeaderStyle CssClass="label" />
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rbtExam" runat="server" ToolTip='<%# Eval("Exam_Id") %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ExamName" HeaderText="考试名称">
                                    <ItemStyle CssClass="item" />
                                    <HeaderStyle CssClass="label" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ExamEmploees" HeaderText="考试人数">
                                    <ItemStyle CssClass="item" />
                                    <HeaderStyle CssClass="label" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Average" HeaderText="平均分数">
                                    <ItemStyle CssClass="item" />
                                    <HeaderStyle CssClass="label" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 80%">
                        <asp:Label ID="lblCount"
                            runat="server"></asp:Label><asp:Label
                                ID="lblPage" runat="server"></asp:Label><asp:Label
                                    ID="lblCurrentPage" runat="server"></asp:Label></td>
                    <td colspan="3" style="text-align: right">
                        &nbsp;<asp:Button ID="btnFirstPage" runat="server" CommandArgument="first" OnClick="PagerButton_Click"
                            Text="首 页" />&nbsp;<asp:Button ID="btnForwardPage" runat="server" CommandArgument="prev"
                                OnClick="PagerButton_Click" Text="上 页" />&nbsp;<asp:Button ID="btnNextPage" runat="server"
                                    CommandArgument="next" OnClick="PagerButton_Click" Text="下 页" />&nbsp;<asp:Button
                                        ID="btnLastPage" runat="server" CommandArgument="last" OnClick="PagerButton_Click"
                                        Text="尾 页" /></td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnSearchScore" runat="server" Text="查询参考人员信息" OnClick="btnSearchScore_Click" /></asp:Panel>
        <asp:HiddenField ID="CurrentPage" runat="server" />
        <asp:HiddenField ID="hfdGv" runat="server" />
        <br />
        <asp:Panel ID="palScore" runat="server" BackColor="White" GroupingText="参考人员信息" Height="50px" Width="100%">
            &nbsp;<asp:Button ID="btnScoreDetail" runat="server" Text="详细信息" OnClick="btnScoreDetail_Click" /><br />
            <table style="width: 100%">
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvScore" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="item" />
                                    <HeaderStyle CssClass="label" />
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rbnScore" runat="server" ToopTip='<%# Eval("Score_Guid") %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Staff_Id" HeaderText="考试人">
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
                        <asp:Label ID="lblCountScore"
                            runat="server"></asp:Label><asp:Label
                                ID="lblPageScore" runat="server"></asp:Label><asp:Label
                                    ID="lblCountPageScore" runat="server"></asp:Label></td>
                    <td style="text-align: right">
                        &nbsp;<asp:Button ID="btnFirstPageScore" runat="server" CommandArgument="first" OnClick="PagerButtonScore_Click"
                            Text="首 页" />&nbsp;<asp:Button ID="btnForwardPageScore" runat="server" CommandArgument="prev"
                                OnClick="PagerButtonScore_Click" Text="上 页" />&nbsp;<asp:Button ID="btnNextPageScore" runat="server"
                                    CommandArgument="next" OnClick="PagerButtonScore_Click" Text="下 页" />&nbsp;<asp:Button
                                        ID="btnLastPageScore" runat="server" CommandArgument="last" OnClick="PagerButtonScore_Click"
                                        Text="尾 页" /></td>
                </tr>

            </table>
        </asp:Panel>
        <asp:HiddenField ID="CurrentPageScore" runat="server" />
        <asp:HiddenField ID="hfdGvScore" runat="server" />
    
    </div>
    </form>
</body>
</html>
