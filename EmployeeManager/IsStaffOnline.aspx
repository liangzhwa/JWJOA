<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IsStaffOnline.aspx.cs" Inherits="EmployeeManager_IsStaffOnline" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>人员在线状态监控</title>
    
    <script type="text/javascript" language="javascript">
        function GetValue()
        {
            var all="";
            var i=0;
            var objs= document.getElementsByTagName("input");
            for(i=0;i<objs.length;i++)
            {
                if(objs[i].type=='checkbox')
                {
                    if(objs[i].checked == true)
                    {
                        all+= objs[i].id + ',';
                    }
                }
            }
            if(all != "")
            {
                var idtext = document.getElementById("hfPower");
                idtext.value =all;
                window.returnValue = all;
                window.close();
            }
            else
            {
                alert('请选择员工！');
                return false;
            }
        }
        
        function AllSelect(deptId)
        {             
            var chks = document.all(deptId).getElementsByTagName("input");
            for(i=0;i<chks.length;i++)
            {
                if(chks[i].type=='checkbox')
                {
                    chks[i].click();                   
                }
            }
       }
       
    </script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
        &nbsp;<br />
        &nbsp;</div>
        <table style="width: 533px" border="1" rules="rows">
            <tr>
                <td align="left" style="height: 46px; width: 60%;">
        <asp:Table ID="tlbIsOnline" runat="server">
        </asp:Table>
                    <br />
                    <input id="btn" type="button" value="确定"  onclick="GetValue();"/></td>
                <td align="left" valign="bottom">
                    <table border="2" style="width: 156px" rules="none">
                        <tr>
                            <td align="left" colspan="2" style="height: 20px">
                                图例：</td>
                        </tr>
            <tr>
                <td style="width: 30px; height: 20px;">
                    <asp:Label ID="lbl1" runat="server" ForeColor="Red" Text="●"></asp:Label></td>
                <td style="color: #000000; height: 20px" align="left">
                    &nbsp;
                    在线</td>
            </tr>
            <tr>
                <td style="width: 30px; height: 23px;">
                    <asp:Label ID="lbl2" runat="server" ForeColor="Silver" Text="●"></asp:Label></td>
                <td align="left">
                    &nbsp;
                    离线</td>
            </tr>
            <tr>
                <td style="width: 30px">
                    <asp:Label ID="lbl3" runat="server" ForeColor="Lime" Text="●"></asp:Label></td>
                <td align="left">
                    &nbsp;
                    离开</td>
            </tr>
        </table>
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 74px" valign="top" colspan="2">
                    </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfPower" runat="server" />
    </form>
</body>
</html>
