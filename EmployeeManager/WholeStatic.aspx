<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WholeStatic.aspx.cs" Inherits="EmployeeManager_WholeStatic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>工作统计页面</title>
    <base target="_self"></base>
    <script type="text/javascript" language="javascript"><!--#INCLUDE VIRTUAL="../js/calendar1.js"--></script>
    <script type="text/javascript" language="javascript">        
        function PopWindow()
        {
            var StaffId = window.showModalDialog('IsStaffOnline.aspx','员工选择页面','height=400, width=600, top='+(screen.AvailHeight-400)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(StaffId != "undefined") 
            {
                var hf = document.getElementById("hfStaffId");
                hf.value = StaffId;
            }
        }
        
        function SelectDept()
        {
            var DeptId = window.showModalDialog('PopPage/DeptSelect.aspx','部门选择页面','height=400, width=600, top='+(screen.AvailHeight-400)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(DeptId != "undefined") 
            {
                var hf = document.getElementById("hfDeptId");
                hf.value = DeptId;
            }
        }
    </script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center" id="mian">
        <table style="width: 720px; text-align: center">
            <tr>
                <td style="height: 27px">
                    工作时间从：<asp:TextBox ID="txtBeginDate" runat="server"></asp:TextBox>
                    <input class="zzd" onclick="calendar(document.form1.txtBeginDate)" style="width: 32px; height: 21px" type="button" value="日历" id="btnBirthday" name="btnBirthday" /></td>
                <td align="right" style="height: 27px; width: 356px;">
                    员工姓名：<asp:TextBox ID="txtSelect" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:Button ID="btnSelect" runat="server" Text="选择" /></td>
            </tr>
            <tr>
                <td>
                    工作时间到：<asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                    <input class="zzd" onclick="calendar(document.form1.txtEndDate)" style="width: 32px; height: 21px" type="button" value="日历" id="Button1" name="btnBirthday" /></td>
                <td align="right" style="width: 356px">
                    选择部门：<asp:TextBox ID="txtDepartment" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:Button ID="btnSelectDepartment" runat="server" Text="选择" />                
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="right" style="width: 356px">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text=" 查询 " />
                    &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="btnStat" runat="server" OnClick="btnStat_Click" Text=" 统计 " /></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 21px">
                    <asp:GridView ID="grvStatics" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="5" Width="100%">
                        <PagerSettings Visible="False" />
                        <Columns>
                            <asp:BoundField DataField="Stat_Id" HeaderText="编号" >
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Staff_Name" HeaderText="人员名称" >
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OnlineTimes" HeaderText="在线时间" >
                                <ItemStyle Width="12.5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="WorkTimes" HeaderText="出勤次数" >
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OutTimes" HeaderText="外出次数" >
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LeaveTimes" HeaderText="请假次数" >
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LeaveDays" HeaderText="请假天数" >
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="WeekEndWorkDays" HeaderText="周末工作天数" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left">
                    共有<asp:Label ID="lblRecordeSum" runat="server" Text="**"></asp:Label>条记录/共<asp:Label
                        ID="lblPageSum" runat="server" Text="**"></asp:Label>页&nbsp; 第<asp:Label ID="lblCurrentPage"
                            runat="server" Text="**"></asp:Label>页</td>
                <td align="right" style="width: 356px">
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
                    &nbsp;<asp:GridView ID="grvWholeStat" runat="server" AutoGenerateColumns="False"
                        Width="100%">
                        <Columns>
                            <asp:BoundField DataField="OnlineTimes" HeaderText="在线时间" >
                                <ItemStyle Width="16.5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="WorkTimes" HeaderText="出勤次数" >
                                <ItemStyle Width="16.5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OutTimes" HeaderText="外出次数" >
                                <ItemStyle Width="16.5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LeaveTimes" HeaderText="请假次数" >
                                <ItemStyle Width="16.5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LeaveDays" HeaderText="请假天数" >
                                <ItemStyle Width="16.5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="WeekEndWorkDays" HeaderText="周末工作天数" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
        <asp:HiddenField ID="hfStaffId" runat="server" />
        <asp:HiddenField ID="hfDeptId" runat="server" />
    </form>
</body>
</html>
