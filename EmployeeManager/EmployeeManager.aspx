<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeManager.aspx.cs" Inherits="EmployeeManager_EmployeeManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>人员管理页面</title>
    <script type="text/javascript" language="javascript">
        function PopWindow()
        {
            window.open('../EmployeeManager/PopPage/FirstLogin.aspx','人员添加页面','dialogHeight=600, dialogWidth=800, top='+(screen.AvailHeight-600)/2+', left='+ (screen.availWidth-800)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
//            if(sRet == "refresh") 
//            {
//                window.location.reload();
//            }
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
            var selectId;
            var selectCount=0;
            var dgList = document.all("grvEmployee");
            var intCount = dgList.rows.length, chbSelect, hfSelect;
            for (var intIndex=0; intIndex<intCount; intIndex++)
            {
                if(intIndex <8)
                {
                    chbSelect = document.all( "grvEmployee_ctl0" + (intIndex + 2) + "_cbSelectItem");
                }
                else
                {
                    chbSelect = document.all( "grvEmployee_ctl" + (intIndex + 2) + "_cbSelectItem");
                }                
                
                if (chbSelect != null && chbSelect.checked == true)
                {
                    if(intIndex <8)
                    {
                        hfSelect = document.all( "grvEmployee_ctl0" + (intIndex + 2) + "_hfID");
                    }
                    else
                    {
                        hfSelect = document.all( "grvEmployee_ctl" + (intIndex + 2) + "_hfID");
                    }
                    selectId=hfSelect.value;
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
                var sRet = window.showModalDialog('../EmployeeManager/PopPage/FirstLogin.aspx?StaffId='+ selectId +'','部门修改页面','height=220, width=300, top='+(screen.AvailHeight-220)/2+', left='+ (screen.availWidth-300)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
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
        <div>
            <center>人员维护</center>
            
        </div>
        <br />
        <table border="0" style="width: 636px">
            <tr>
                <td colspan="2">
            <button id="btnAdd" style="height:24px;width:57px;" onclick="PopWindow()">
            添加</button>
            &nbsp; &nbsp; &nbsp;
            <asp:Button ID="btnDelete" runat="server" Text=" 离职 " OnClick="btnDelete_Click" />
            &nbsp; &nbsp; &nbsp;
            <input type="button" value=" 修改 " onclick="GetSelected()" />
            <asp:Button ID="btnModify" runat="server" Text=" 修改 " Visible="false" OnClick="btnModify_Click" />
            &nbsp; &nbsp; &nbsp;
            <asp:Button ID="btnSearch" runat="server" Text=" 查询 " OnClick="btnSearch_Click" />
                    <br />
            </td>
            <td align="right" valign="top">
                 <asp:Button ID="btnPwdInit" runat="server" Text="密码初始化" OnClick="btnPwdInit_Click" />
            </td>
            </tr>
            <tr>
                <td colspan="3">
            姓名：<asp:TextBox ID="txtEmployeeName" runat="server"
                Width="85px"></asp:TextBox>
            &nbsp; &nbsp; &nbsp;部门：<asp:TextBox ID="txtDepartment"
                runat="server" Width="85px"></asp:TextBox>
            <asp:TextBox ID="txtEmployeeID" runat="server" Width="85px" Visible ="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3">
            <asp:GridView ID="grvEmployee" runat="server" Width="640px" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="无" OnRowDataBound="GridView1_RowDataBound" PageSize="5">
                <PagerSettings Visible="False" />
                <Columns>
                    <asp:TemplateField>
                        <headertemplate>
                            <input id="cbSelectAll " onclick="javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </headerTemplate> 
                        <ItemTemplate>
                            <asp:CheckBox ID="cbSelectItem" runat="server" />
                            <asp:HiddenField ID="hfID" runat="server" Value=' <%#  Eval( "Staff_Id")   %> ' />
                        </ItemTemplate>
                        <HeaderStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="姓名" >
                        <ItemStyle Width="154px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="deptName" HeaderText="部门" >
                        <ItemStyle Width="154px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StringField5" HeaderText="移动电话" >
                        <ItemStyle Width="154px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StringField3" HeaderText="办公电话">
                        <ItemStyle Width="154px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StringField7" HeaderText="电话短号">
                        <ItemStyle Width="154px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
        共有<asp:Label ID="RecordeSum" runat="server" Text="**"></asp:Label>条记录/共<asp:Label
            ID="PageSum" runat="server" Text="**"></asp:Label>页&nbsp; 第<asp:Label ID="lblCurrentPage"
                runat="server" Text="**"></asp:Label>页 
                </td>
                <td align="right" colspan="2">
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