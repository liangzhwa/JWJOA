<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="EmployeeManager_PopPage_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/jscript">
    function onload()
    {
        var fw = window.dialogArguments;
        var va = fw.value;
        
        alert(va);
        var dd = document.getElementById("Label1");
        dd.value = va;
        
    }
    </script>
</head>
<body onload="onload()">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
    </form>
</body>
</html>
