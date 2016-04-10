<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FirstLogin.aspx.cs" Inherits="EmployeeManager_PopPage_FirstLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<META HTTP-EQUIV="pragma" CONTENT="no-cache"/>
<META HTTP-EQUIV="Cache-Control" CONTENT="no-cache, must-revalidate"/>
<META HTTP-EQUIV="expires" CONTENT="Mon, 23 Jan 1978 20:52:30 GMT"/>
    <title>首次登录人员信息维护页面</title>
    
    <script type="text/javascript" language="javascript"><!--#INCLUDE VIRTUAL="../../js/calendar1.js"--></script>
    
    <base target="_self"></base>
    <script type="text/javascript" language="javascript">
        function closeWin()
        {
            window.returnValue = "refresh";
            window.close();
        }
    
        function SelectRole()
        {
            var RoleId = window.showModalDialog('RoleSelect.aspx','角色选择页面','height=400, width=600, top='+(screen.AvailHeight-400)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(RoleId != "undefined") 
            {
                var hf = document.getElementById("hfSelectRole");
                hf.value = RoleId;
            }
        }
    </script>
</head>
<body style="text-align: center">
    <form id="StaffForm" runat="server">
    
    <table border="0"><tr><td style="width: 617px">
        <center>
        <fieldset style="width:200" align="left"><legend style="border:0px;background-color:white";>基本信息</legend>
        <table border="0">
          <tr>
            <td align="right" style="color: red">
                *<asp:Label ID="lblUserName" runat="server" Text="用户名：" ForeColor="Black"></asp:Label>
            </td>
              <td align="left" >
            <asp:TextBox ID="txtUserName" runat="server" Enabled="False" Width="150px"></asp:TextBox></td>
            <td align="right" style="width: 121px; color: red;">
                *<asp:Label ID="lblName" runat="server" Text="姓名：" ForeColor="Black"></asp:Label></td>
              <td style="width: 158px" align="left" >
            <asp:TextBox ID="txtName" runat="server" Enabled="False" Width="150px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="color: red">
                *<asp:Label ID="Label1" runat="server" ForeColor="Black" Text="密码："></asp:Label></td>
            <td align="left" >
                &nbsp;<asp:TextBox ID="txtPwd" runat="server"></asp:TextBox></td>
            <td align="right" style="width: 121px">
                <asp:Label ID="lblBirthday" runat="server" Text="出生日期："></asp:Label></td>
            <td style="width: 158px" align="left" >
                &nbsp;<asp:TextBox ID="txtBirthday" runat="server" Enabled="False" Width="110px"></asp:TextBox>  
            <input class="zzd" onclick="calendar(document.StaffForm.txtBirthday)" style="width: 32px; height: 21px" type="button" value="日历" id="btnBirthday" name="btnBirthday" /></td>
        </tr>
            <tr>
                <td align="right">
                    担任角色：</td>
                <td align="left" colspan="3">
            <asp:TextBox ID="txtRole" runat="server" Width="106px" ReadOnly="True"></asp:TextBox>
                    <asp:Button ID="btnRoleSelect" runat="server" Text="选择"/></td>
            </tr>
            <tr>
                <td align="right">
                    籍贯：</td>
                <td align="left">
                    <asp:TextBox ID="txtNativePlace" runat="server" Width="150px"></asp:TextBox></td>
                <td align="right" style="width: 121px">
                    学历：</td>
                <td style="width: 158px" align="left">
                    <asp:TextBox ID="txtEducation" runat="server" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    政治面貌：</td>
                <td align="left">
                    <asp:TextBox ID="txtGroup" runat="server" Width="150px"></asp:TextBox></td>
                <td align="right" style="width: 121px">
                    婚否：</td>
                <td style="width: 158px" align="left">
                    <asp:DropDownList ID="ddlIsMarray" runat="server" Width="150px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">
                    配偶工作地点：</td>
                <td align="left">
                    <asp:TextBox ID="txtMateWorkPlace" runat="server" Width="150px"></asp:TextBox></td>
                <td align="right" style="width: 121px">
                    子女出生时间：</td>
                <td style="width: 158px" align="left">
                    <asp:TextBox ID="txtChildBirth" runat="server" Enabled="False" Width="110px"></asp:TextBox>
                    <input class="zzd" onclick="calendar(document.StaffForm.txtChildBirth)" style="width: 32px; height: 21px" type="button" value="日历" id="btnChildBirthday" name="btnChildBirthday" /></td>
            </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblBusiness" runat="server" Text="职务："></asp:Label></td>
            <td align="left">
            <asp:TextBox ID="txtBusiness" runat="server" Width="150px"></asp:TextBox></td>
            <td align="right" style="width: 121px">
                警官证号：</td>
            <td style="width: 158px" align="left" >
                <asp:TextBox ID="txtPoliceId" runat="server" Width="150px"></asp:TextBox></td>
        </tr>
            <tr>
                <td align="right">
                <asp:Label ID="lblMilitary" runat="server" Text="衔级："></asp:Label></td>
                <td align="left">
                    <asp:DropDownList ID="ddlMilitary" runat="server" Width="150px">
                    </asp:DropDownList></td>
                <td align="right" style="width: 121px">
                    职级：</td>
                <td style="width: 158px" align="left">
                    <asp:DropDownList ID="ddlPosition" runat="server" Width="150px">
                    </asp:DropDownList></td>
            </tr>
        <tr>
            <td align="right" style="color: red">
                *<asp:Label ID="lblDepartment" runat="server" Text="部门：" ForeColor="Black"></asp:Label></td>
            <td align="left" >
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="150px">
                </asp:DropDownList></td>
            <td align="right" style="width: 121px; color: red;">
                *<asp:Label ID="lblIsManager" runat="server" Text="是否主管：" ForeColor="Black"></asp:Label></td>
            <td style="width: 158px" align="left" >
                <asp:DropDownList ID="ddlIsManager" runat="server" Width="150px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblWorkTimes" runat="server" Text="工作时间："></asp:Label></td>
            <td align="left" >
                <asp:TextBox ID="txtWorkDate" runat="server" Enabled="False" Width="110px"></asp:TextBox>
                <input class="zzd" onclick="calendar(document.StaffForm.txtWorkDate)" style="width: 32px; height: 21px" type="button" value="日历" id="btnWorkDate" name="btnWorkDate" /></td>
            <td align="right" style="width: 121px">
                <asp:Label ID="lblEnrollment" runat="server" Text="入伍时间："></asp:Label></td>
            <td style="width: 158px" align="left" >
                <asp:TextBox ID="txtEnrollment" runat="server" Enabled="False" Width="110px"></asp:TextBox>
                <input class="zzd" onclick="calendar(document.StaffForm.txtEnrollment)" style="width: 32px; height: 21px" type="button" value="日历" id="btnEnrollment" name="btnEnrollment" /></td>
        </tr>
        </table>
        </fieldset>
        </center>
        </td></tr>
        <tr><td style="width: 617px">
        <center>
        <fieldset style="width:200" align="left"><legend style="border:0px;background-color:white";>电话信息</legend>
        <table border="0">
          <tr>
            <td align="right">
            <asp:Label ID="lblOfficeTel" runat="server" Text="办公电话："></asp:Label>
            </td>
              <td align="left" >
            <asp:TextBox ID="txtOfficeTel" runat="server" Width="150px"></asp:TextBox></td>
            <td align="right" style="width: 121px">
                <asp:Label ID="lblOfficeTel2" runat="server" Text="办公电话二："></asp:Label></td>
              <td style="width: 158px" align="left" >
            <asp:TextBox ID="txtOfficeTel2" runat="server" Width="150px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblHomeTel" runat="server" Text="住宅电话："></asp:Label></td>
            <td align="left" >
            <asp:TextBox ID="txtHomeTel" runat="server" Width="150px"></asp:TextBox></td>
            <td align="right" style="width: 121px">
               <asp:Label ID="lblMobileTel" runat="server" Text="移动电话："></asp:Label></td>
            <td style="width: 158px" align="left" >
            <asp:TextBox ID="txtMobileTel" runat="server" Width="150px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblSMSCode" runat="server" Text="短信号码："></asp:Label></td>
            <td align="left">
            <asp:TextBox ID="txtSMSCode" runat="server" Width="150px"></asp:TextBox></td>
            <td align="right" style="width: 121px">
                <asp:Label ID="lblShortTel" runat="server" Text="电话短号："></asp:Label></td>
            <td style="width: 158px" align="left" >
                <asp:TextBox ID="txtShortTel" runat="server" Width="150px"></asp:TextBox></td>
        </tr>
        </table>
        </fieldset>
        </center>
        </td></tr>
        
        <tr><td style="width: 617px">
        <center>
        <fieldset style="width:200" align="left"><legend style="border:0px;background-color:white";>联系方式</legend>
        <table border="0">
          <tr>
            <td align="right" style="width: 82px">
            <asp:Label ID="lblAddress" runat="server" Text="家庭住址："></asp:Label>
            </td>
              <td colspan="3" style="width: 442px" align="left">
            <asp:TextBox ID="txtAddress" runat="server" Width="375px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 82px">
                <asp:Label ID="lblEmail" runat="server" Text="电子邮箱："></asp:Label></td>
            <td colspan="3" style="width: 442px" align="left">
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
        </table>
        </fieldset>
        </center>
        </td></tr>
        
        <tr><td align="right" style="width: 617px">
            <asp:Button ID="btnSave" runat="server" Text=" 保存 " OnClick="btnSave_Click" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <button id="btnAdd" style="height:24px;width:57px;" onclick="window.close();">取消</button>
        
        </td></tr>
        </table>
        <asp:HiddenField ID="hfIsUpdate" runat="server" />
        <asp:HiddenField ID="hfRole" runat="server" />
        <asp:HiddenField ID="hfSelectRole" runat="server" />
    </form>
</body>
</html>
