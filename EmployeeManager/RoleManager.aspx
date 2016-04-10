<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleManager.aspx.cs" Inherits="EmployeeManager_RoleManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>角色管理页面</title>
    <script type="text/javascript" language="javascript">
        function PopWindow()
        {
            var sRet = window.showModalDialog('../EmployeeManager/PopPage/RoleAdd.aspx','角色添加页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=auto, resizable=no,location=no, status=no');
            if(sRet == "refresh") 
            {
                window.location.reload();
            }
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
        
        //修改按钮调用函数
        function GetSelected()
        {
            var selectDeptId,selectDay;
            var selectCount=0;
            var dgList = document.all("grvRole");
            var intCount = dgList.rows.length, chbSelect, hfSelect;
            for (var intIndex=0; intIndex<intCount; intIndex++)
            {
                if(intIndex <8)
                {
                    chbSelect = document.all( "grvRole_ctl0" + (intIndex + 2) + "_cbSelectItem");
                }
                else
                {
                    chbSelect = document.all( "grvRole_ctl" + (intIndex + 2) + "_cbSelectItem");
                }                
                
                if (chbSelect != null && chbSelect.checked == true)
                {
                    if(intIndex <8)
                    {
                        hfSelect = document.all( "grvRole_ctl0" + (intIndex + 2) + "_hfID");
                    }
                    else
                    {
                        hfSelect = document.all( "grvRole_ctl" + (intIndex + 2) + "_hfID");
                    }
                    selectDeptId=hfSelect.value;
                    selectCount++;
                }                
            }
            if(selectCount == 0)
            {
                alert("请选择要修改的记录！");
            }
            else if(selectCount > 1)
            {
                alert("只能选择一条记录进行修改！");
            }
            else
            {
                var sRet = window.showModalDialog('../EmployeeManager/PopPage/RoleAdd.aspx?RoleId='+ selectDeptId +'','角色修改页面','height=220, width=300, top='+(screen.AvailHeight-220)/2+', left='+ (screen.availWidth-300)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
                if(sRet == "refresh") 
                {
                    window.location.reload();
                }
            }
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>角色维护</center>
        <center>
            &nbsp;</center>
        <table border="0" style="width: 610px">
            <tr>
                <td colspan="2">
        <button id="btnAdd" style="height:23px;width:57px;" onclick="PopWindow()">
            添加</button>
        &nbsp; &nbsp; &nbsp;
        <asp:Button ID="btnDelete" runat="server" Text=" 删除 " OnClick="btnDelete_Click" />
        &nbsp; &nbsp; &nbsp;
        <input type="button" value=" 修改 " onclick="GetSelected()" />
        <asp:Button ID="btnModify" runat="server" Text=" 修改 " Visible="false" OnClick="btnModify_Click" />
        &nbsp; &nbsp; &nbsp;
        <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" /><br />
                </td>
            </tr>
            <tr>
                <td colspan="2">
        角色名称：<asp:TextBox ID="txtRoleName"
            runat="server" Width="115px"></asp:TextBox>
                    <asp:TextBox ID="txtRoleID" runat="server" Width="115px" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
        <asp:GridView ID="grvRole" runat="server" Width="610px" OnRowDataBound="grvRole_RowDataBound" AllowPaging="True" PageSize="5" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <headertemplate>
                        <input id="cbSelectAll " onclick="javascript:SelectAllCheckboxes(this); " type="checkbox" />
                    </headerTemplate>  
                    <ItemTemplate>                        
                            <asp:CheckBox ID="cbSelectItem" runat="server" />
                                    <asp:HiddenField   ID= "hfID"   Value= ' <%#  Eval( "Role_Id")   %> '   runat= "server" /> 
                            <headerstyle   width= "20px " />                        
                    </ItemTemplate>                    
                    <HeaderStyle Width="20px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="角色名称" >
                    <ItemStyle Width="295px" />
                </asp:BoundField>
                <asp:BoundField DataField="CreatedDate" HeaderText="角色创建时间" >
                    <ItemStyle Width="295px" />
                </asp:BoundField>
            </Columns>
            <PagerSettings Visible="False" />
            <PagerStyle BorderStyle="None" />
        </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
        共有<asp:Label ID="lblRecordeSum" runat="server" Text="**"></asp:Label>条记录/共<asp:Label
            ID="lblPageSum" runat="server" Text="**"></asp:Label>页&nbsp; 第<asp:Label ID="lblCurrentPage"
                runat="server" Text="**"></asp:Label>页</td>
                <td align="right">
        <asp:HiddenField ID="CurrentPage" runat="server" Value="0"/>

        <asp:Button ID="FirstPage" runat="server" Text="首页" CommandArgument="first" OnClick="PagerButton_Click"/>
        <asp:Button ID="ForwardPage" runat="server" Text="上一页" CommandArgument="prev" OnClick="PagerButton_Click"/>
        <asp:Button ID="NextPage" runat="server" Text="下一页" CommandArgument="next" OnClick="PagerButton_Click"/>
        <asp:Button ID="LastPage" runat="server" Text="尾页" CommandArgument="last" OnClick="PagerButton_Click"/></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
