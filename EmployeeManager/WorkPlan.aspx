<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkPlan.aspx.cs" Inherits="EmployeeManager_WorkPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <script type="text/javascript" language="javascript"><!--#INCLUDE VIRTUAL="../js/calendar1.js"--></script>

    <title>工作时间表管理</title>
    <script type="text/javascript" language="javascript">
        function PopWindow()
        {
            var sRet = window.showModalDialog('../EmployeeManager/PopPage/WorkPlanAdd.aspx','工作日程添加页面','height=220, width=300, top='+(screen.AvailHeight-220)/2+', left='+ (screen.availWidth-300)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');            
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
        
        function GetSelected()
        {
            
        }
        
        function SelectStaff()
        {
            var StaffId = window.showModalDialog('IsStaffOnline.aspx','员工选择页面','height=400, width=600, top='+(screen.AvailHeight-400)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(StaffId != "undefined") 
            {
                var hf = document.getElementById("hfStaff");
                hf.value = StaffId;
            }
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 495px">
            <tr>
                <td>
                    <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>工作日程</td>
                <td>
                </td>
            </tr>
            <tr>
                
                <td align="left">
                    <button id="btnAdd" style="height:23px;width:57px;" onclick="PopWindow()">
            添加</button>
                    &nbsp; &nbsp; &nbsp;&nbsp;<asp:Button ID="btnModify" runat="server" OnClick="btnModify_Click"
                        Text=" 修改 " />
                    &nbsp;&nbsp; &nbsp;
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text=" 删除 " />
                </td>
                <td align="right">
                    </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td align="right">
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="grvWorkPlan" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" EmptyDataText="没有相应记录！">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="20px" />
                                <headertemplate>
                                    <input id="cbSelectAll " onclick="javascript:SelectAllCheckboxes(this); " type="checkbox" />
                                </headerTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbSelectItem" runat="server" />
                                    <asp:HiddenField ID="hfID" runat="server" Value=' <%#  Eval( "WorkTime_Guid")   %> ' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="StaffName" HeaderText="员工姓名" />
                            <asp:BoundField DataField="Address" HeaderText="工作地点" />
                            <asp:BoundField DataField="Job" HeaderText="工作内容" />
                            <asp:BoundField DataField="StatusName" HeaderText="工作状态" />
                            <asp:BoundField DataField="Day" HeaderText="工作时间" />
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    共有<asp:Label ID="RecordeSum" runat="server" Text="**"></asp:Label>条记录/共<asp:Label
                        ID="PageSum" runat="server" Text="**"></asp:Label>页&nbsp; 第<asp:Label ID="lblCurrentPage"
                            runat="server" Text="**"></asp:Label>页</td>
                <td align="right" >
                    <asp:HiddenField ID="CurrentPage" runat="server" Value="0" />
                    <asp:Button ID="FirstPage" runat="server" CommandArgument="first" OnClick="PagerButton_Click"
                        Text="首页" />
                    <asp:Button ID="ForwardPage" runat="server" CommandArgument="prev" OnClick="PagerButton_Click"
                        Text="上一页" />
                    <asp:Button ID="NextPage" runat="server" CommandArgument="next" OnClick="PagerButton_Click"
                        Text="下一页" />
                    <asp:Button ID="LastPage" runat="server" CommandArgument="last" OnClick="PagerButton_Click"
                        Text="尾页" /></td>
            </tr>
            <tr>
                <td colspan="2">
                <br />
                <fieldset><legend>工作日程查询</legend>
                    <table style="width: 100%">
                        <tr>
                            <td align="right">
                                部门：</td>
                            <td style="width: 118px">
                                <asp:DropDownList ID="ddlDept" runat="server">
                                </asp:DropDownList></td>
                            <td align="right">
                                人员：</td>
                            <td>
                                <asp:TextBox ID="txtStaff" runat="server" ReadOnly="True" Width="66%"></asp:TextBox>
                                <asp:Button ID="btnSelect" runat="server" Text="选择" /></td>
                        </tr>
                        <tr>
                            <td align="right">
                                时间：</td>
                            <td style="width: 118px">
                                <asp:TextBox ID="txtDay" runat="server" Width="55%"></asp:TextBox>
                                <input class="zzd" onclick="calendar(document.form1.txtDay)" style="width: 32px; height: 21px" type="button" value="日历" id="btnBirthday" name="btnBirthday" /></td>
                            <td align="right">
                                地点：</td>
                            <td>
                                <asp:TextBox ID="txtAddress" runat="server" Width="187px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="height: 26px" align="right">
                                事件：</td>
                            <td style="height: 26px" colspan="3">
                                <asp:TextBox ID="txtJob" runat="server" Width="90%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 26px">
                            </td>
                            <td align="center" colspan="3" style="height: 26px">
                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text=" 查询 " /></td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hfStaff" runat="server" />
                    <asp:HiddenField ID="hfPower" runat="server" />
                </fieldset>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
