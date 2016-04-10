<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionList.aspx.cs" Inherits="ExamManager_QuestionList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>题库维护</title>
    <link href="../Script/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function PopWindow()
        {
            window.open('../ExamManager/PopPage/DepartmentAdd.aspx','部门添加页面','height=220, width=300, top='+(screen.AvailHeight-220)/2+', left='+ (screen.availWidth-300)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');            
        }
        
        function   SelectAllCheckboxes(spanChk)
        { 
            var oItem = spanChk.children; 
            var theBox=(spanChk.type== "checkbox")?spanChk:spanChk.children.item[0]; 
            xState=theBox.checked; 
            table = theBox.parentNode.parentNode.parentNode; 
            elm1=table.childNodes; 
            for(j=0;j <elm1.length;j++) 
            { 
                    elm2 = elm1[j].childNodes; 
                    for(m=0;m <elm2.length;m++) 
                    { 
                            elm = elm2[m].childNodes; 
                            for(i=0;i <elm.length;i++) 
                            { 
                                    if(elm[i].type== "checkbox" && elm[i].id!=theBox.id) 
                                    { 
                                            if(elm[i].checked!=xState) 
                                            elm[i].click(); 
                                            break; 
                                    } 
                            } 
                    } 
              } 
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table border="0" cellspacing="0" cellpadding="3" width="100%">
      <tr align="left">
        <th align="left" class="titlebar" style="text-align: center">
            <span style="font-size: 14pt; color: black; font-family: 宋体">
            题库维护</span></th>
      </tr>
    </table>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="新 增" OnClick="btnAdd_Click" />
        <asp:Button ID="btnChange" runat="server" Text="修 改" OnClick="btnChange_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="删 除" OnClick="btnDelete_Click" />
        <asp:Button ID="btnSearch" runat="server" Text="查 询" OnClick="btnSearch_Click" /><asp:Panel ID="palSearch" runat="server" GroupingText="查询信息" Height="50px" Width="100%" BackColor="White">
            题目类型：<asp:DropDownList ID="sltQuestionTypeName" runat="server" AppendDataBoundItems="True">
            </asp:DropDownList>
            &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; 题目：<asp:TextBox ID="txtQuestion" runat="server" Columns="50"></asp:TextBox><br />
        </asp:Panel>
    </div>
    <table width="100%">
    <tr><td colspan="2" >
        <asp:GridView ID="gvQuestion" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkGv" runat="server" ToolTip='<%# Eval("Question_Guid") %>' />
                       
                    </ItemTemplate>
                    <ItemStyle CssClass="item" />
                    <HeaderStyle CssClass="label" Width="25px" />
                    <HeaderTemplate>
                        <input id="cbSelectAll " onclick="javascript:SelectAllCheckboxes(this); " type="checkbox" />
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="题目" DataField="Question" >
                    <ItemStyle CssClass="item" />
                    <HeaderStyle CssClass="label" />
                </asp:BoundField>
                <asp:BoundField HeaderText="题目类型" DataField="QuestionTypeName">
                    <ControlStyle BackColor="Cyan" />
                    <ItemStyle CssClass="item" />
                    <HeaderStyle CssClass="label" Width="15%" />
                </asp:BoundField>
                <asp:BoundField HeaderText="创建人" DataField="CreatedBy">
                    <ControlStyle BackColor="Cyan" />
                    <ItemStyle CssClass="item" />
                    <HeaderStyle CssClass="label" Width="15%" />
                </asp:BoundField>
            </Columns>
            <PagerSettings Visible="False" />
        </asp:GridView>
    </td></tr>
    <tr><td style="width: 80%">
        <asp:Label ID="lblCount" runat="server"></asp:Label><asp:Label
            ID="lblPage" runat="server"></asp:Label><asp:Label ID="lblCurrentPage" runat="server"></asp:Label></td><td>
                &nbsp;
          <asp:Button ID="btnFirstPage" runat="server" CommandArgument="first" OnClick="PagerButton_Click"
              Text="首 页" />&nbsp;
          <asp:Button ID="btnForwardPage" runat="server" CommandArgument="prev" OnClick="PagerButton_Click"
              Text="上一页" />&nbsp;
          <asp:Button ID="btnNextPage" runat="server" CommandArgument="next" OnClick="PagerButton_Click"
              Text="下一页" />&nbsp;
          <asp:Button ID="btnLastPage" runat="server" CommandArgument="last" OnClick="PagerButton_Click"
              Text="尾 页" /></td></tr>
    </table>
        <asp:HiddenField ID="hfdGv" runat="server" />
        <asp:HiddenField ID="CurrentPage" runat="server" />
    </form>
</body>
</html>
