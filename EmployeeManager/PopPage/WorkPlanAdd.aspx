<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkPlanAdd.aspx.cs" Inherits="EmployeeManager_PopPage_WorkPlanAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>工作日程添加页面</title>
    <base target="_self"></base>
        <script type="text/javascript" language="javascript"><!--#INCLUDE VIRTUAL="../../js/calendar1.js"--></script>
    <script type="text/javascript" language="javascript">
        function closeWin()
        {
            window.returnValue = "refresh";
            window.close();
        }
         
        function PopWindow()
        {
            var StaffId = window.showModalDialog('../IsStaffOnline.aspx','员工选择页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
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
        &nbsp;<table style="width: 479px" border="0">
            <tr>
                <td colspan="2" style="height: 168px">
                <fieldset > <legend>细节描述</legend>
                <br />
                    <table style="width: 464px" border="0">
                        <tr>
                            <td align="right" style="width: 107px">
                                选择员工：</td>
                            <td>
                                <asp:TextBox ID="txtSelected" runat="server" Width="85%" ReadOnly="True"></asp:TextBox>                                
                                <asp:Button ID="btnSelect" runat="server" Text="选择" Width="10%" /></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 107px">
                                工作时间从：</td>
                            <td align="left">
                                <asp:TextBox ID="txtStart" runat="server" Width="50%"></asp:TextBox>
                                <input class="zzd" onclick="calendar(document.form1.txtStart)" style="width: 32px; height: 21px" type="button" value="日历" id="Button2" name="btnBirthday" /></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 107px">
                                到：</td>
                            <td align="left">
                                <asp:TextBox ID="txtEnd" runat="server" Width="50%"></asp:TextBox>
                                <input class="zzd" onclick="calendar(document.form1.txtEnd)" style="width: 32px; height: 21px" type="button" value="日历" id="Button3" name="btnBirthday" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 107px">
                                <asp:Label ID="lblDayKey" runat="server">工作时间：</asp:Label></td>
                            <td align="left">
                                <asp:Label ID="lblDayValue" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 107px">
                                工作地点：</td>
                            <td>
                                <asp:TextBox ID="txtAddress" runat="server" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 107px">
                                工作状态：</td>
                            <td>
                                <asp:DropDownList ID="ddlWordStatus" runat="server" Width="100%">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" style="width: 107px">
                                事件：</td>
                            <td>
                                <asp:TextBox ID="txtJob" runat="server" Height="104px" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                        </tr>
                    </table>
                
                
                
                </fieldset>
                
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="right">
                    <asp:Button ID="btnWorkPlanSave" runat="server" Text=" 保存 " OnClick="btnWorkPlanSave_Click" /></td>
            </tr>
        </table>
    
    </div>
        <asp:HiddenField ID="hfWorkTime" runat="server" />
        <asp:HiddenField ID="hfStaffId" runat="server" />
    </form>
</body>
</html>
