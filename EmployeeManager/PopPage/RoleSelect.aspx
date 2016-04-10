<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleSelect.aspx.cs" Inherits="EmployeeManager_PopPage_RoleSelect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>角色选择</title>
    <script type="text/javascript" language="javascript">
     
        //无刷新选择角色
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
                var idtext = document.getElementById("hfRole");
                idtext.value =all;
                window.returnValue = all;
                window.close();
            }
            else
            {
                alert('请选择角色！');
                return false;
            }
        }        
    </script>
</head>
<body>
    <form id="form1" runat="server">
   
    <table style="width: 478px">
            <tr>
                <td colspan="2">
                    &nbsp;<asp:Table ID="tabDept" runat="server">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="btnConfirm" type="button" value=" 确定 " onclick="GetValue();" />
                </td>
                <td>
                    &nbsp;<input id="btnCancle" type="button" value=" 取消 " onclick="window.close();" /></td>
            </tr>
        </table>
        <asp:HiddenField ID="hfRole" runat="server" />
    
    </form>
</body>
</html>
