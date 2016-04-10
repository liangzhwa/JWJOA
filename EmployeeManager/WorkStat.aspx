<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkStat.aspx.cs" Inherits="EmployeeManager_WorkStat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>工作统计页面</title>
    <base target="_self"></base>
    <script type="text/javascript" language="javascript"><!--#INCLUDE VIRTUAL="../js/calendar1.js"--></script>
    <script type="text/javascript" language="javascript">        
        function PopWindow()
        {
            var StaffId = window.showModalDialog('IsStaffOnline.aspx','员工选择页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(StaffId != "") 
            {
                var hf = document.getElementById("hfStaffId");
                hf.value = StaffId;
            }
        }
    </script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="width: 700px; text-align: center">
            <tr>
                <td align="left" style="width: 261px">
                    工作时间从：<asp:TextBox ID="txtBeginDate" runat="server" Width="119px"></asp:TextBox>
                    <input class="zzd" onclick="calendar(document.form1.txtBeginDate)" style="width: 32px; height: 21px" type="button" value="日历" id="btnWorkDate" name="btnWorkDate" /></td>
                <td align="right" colspan="2">
                    员工姓名：<asp:TextBox ID="txtSelect" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:Button ID="btnSelect" runat="server" Text="选择" /></td>
            </tr>
            <tr>
                <td align="left" style="width: 261px">
                    工作时间到：<asp:TextBox ID="txtEndDate" runat="server" Width="119px"></asp:TextBox>
                    <input class="zzd" onclick="calendar(document.form1.txtEndDate)" style="width: 32px; height: 21px" type="button" value="日历" id="Button1" name="btnWorkDate" /></td>
                <td align="right" colspan="2">
                    部门：<asp:DropDownList ID="ddlDept" runat="server" Width="195px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 261px">
                </td>
                <td style="width: 149px" align="right">
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text=" 查询 " /></td>
                <td align="right">
                    <asp:Button ID="btnStat" runat="server" Text=" 统计 " OnClick="btnStat_Click" /></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="grvWorkStat" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="没有符合条件的数据！" PageSize="5">
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="用户名" >
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="人员名称" >
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Day" HeaderText="日期" >
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Address" HeaderText="地点" >
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StatusName" HeaderText="工作状态" >
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Job" HeaderText="事件" >
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 261px">
                    共有<asp:Label ID="lblRecordeSum" runat="server" Text="**"></asp:Label>条记录/共<asp:Label
                        ID="lblPageSum" runat="server" Text="**"></asp:Label>页&nbsp; 第<asp:Label ID="lblCurrentPage"
                            runat="server" Text="**"></asp:Label>页</td>
                <td align="right" colspan="2">
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
                <td align="left" style="width: 261px">
                </td>
                <td align="right" colspan="2">
                </td>
            </tr>
            <tr>
                <td align="left" colspan="3">
                    <asp:GridView ID="grvStatics" runat="server" Width="100%" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="OnlineTimes" HeaderText="在线时间" >
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="WorkTimes" HeaderText="出勤次数" >
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OutTimes" HeaderText="外出次数" >
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LeaveTimes" HeaderText="请假次数" >
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LeaveDays" HeaderText="请假天数" >
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="WeekEndWorkDays" HeaderText="周末工作天数" >
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 261px">
                </td>
                <td align="right" colspan="2">
                </td>
            </tr>
        </table>
    
    </div>
        <asp:HiddenField ID="hfStaffId" runat="server" />
    </form>
</body>
</html>
