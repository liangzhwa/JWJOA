<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamList.aspx.cs" Inherits="ExamManager_ExamList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>考试管理</title>
     <link href="../Script/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="3" cellspacing="0" width="100%">
            <tr align="left">
                <th align="left" class="titlebar" style="text-align: center">
                    <span style="font-size: 14pt; color: black; font-family: 宋体">考试管理</span></th>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新 增" />&nbsp;<asp:Button
            ID="btnChange" runat="server" OnClick="btnChange_Click" Text="修 改" />&nbsp;<asp:Button
                ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="删 除" />&nbsp;<asp:Button
                    ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查 询" /><br />
        <asp:Panel ID="palSearch" runat="server" BackColor="White" GroupingText="查询信息" Height="50px"
            Width="100%">
            <table style="width: 80%">
                <tr>
                    <td>
                        考试ID：</td>
                    <td>
                        <asp:TextBox ID="txtExamId" runat="server"></asp:TextBox></td>
                    <td>
                        考试名称：</td>
                    <td>
                        <asp:TextBox ID="txtExamName" runat="server" Columns="20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        评分类型：</td>
                    <td>
                        <asp:DropDownList ID="sltQuestionTypeName" runat="server" AppendDataBoundItems="True">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="1">统一评分</asp:ListItem>
                            <asp:ListItem Value="0">当时评分</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        创建人：</td>
                    <td>
                        <asp:TextBox ID="txtCreatedBy" runat="server"></asp:TextBox></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
        <table width="100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvExam" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        Width="100%" OnRowDataBound="gvExam_RowDataBound">
                        <PagerSettings Visible="False" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle CssClass="item" />
                                <HeaderStyle CssClass="label" Width="25px" />
                                <ItemTemplate>
                                    <asp:RadioButton ID="jrbSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Exam_Id" HeaderText="考试ID">
                                <ItemStyle CssClass="item" />
                                <HeaderStyle CssClass="label" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ExamName" HeaderText="考试名称">
                                <ControlStyle BackColor="Cyan" />
                                <ItemStyle CssClass="item" />
                                <HeaderStyle CssClass="label" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="contidion" HeaderText="评分类型" HtmlEncode="False">
                                <ItemStyle CssClass="item" />
                                <HeaderStyle CssClass="label" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BeginTime" HeaderText="开始时间">
                                <ItemStyle CssClass="item" />
                                <HeaderStyle CssClass="label" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EndTime" HeaderText="结束时间">
                                <ItemStyle CssClass="item" />
                                <HeaderStyle CssClass="label" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreatedBy" HeaderText="创建人">
                                <ItemStyle CssClass="item" />
                                <HeaderStyle CssClass="label" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 80%">
                    <asp:Label ID="lblCount" runat="server"></asp:Label><asp:Label ID="lblPage" runat="server"></asp:Label><asp:Label
                        ID="lblCountPage" runat="server"></asp:Label></td>
                <td>
                    &nbsp;
                    <asp:Button ID="btnFirstPage" runat="server" CommandArgument="first" OnClick="PagerButton_Click"
                        Text="首 页" />&nbsp;
                    <asp:Button ID="btnForwardPage" runat="server" CommandArgument="prev" OnClick="PagerButton_Click"
                        Text="上一页" />&nbsp;
                    <asp:Button ID="btnNextPage" runat="server" CommandArgument="next" OnClick="PagerButton_Click"
                        Text="下一页" />&nbsp;
                    <asp:Button ID="btnLastPage" runat="server" CommandArgument="last" OnClick="PagerButton_Click"
                        Text="尾 页" /></td>
            </tr>
        </table>
        <asp:HiddenField ID="hfdGv" runat="server" />
        <asp:HiddenField ID="CurrentPage" runat="server" />
    </form>
</body>
</html>
