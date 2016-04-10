<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IsEmployeeOnline.aspx.cs" Inherits="EmployeeManager_PopPage_IsEmployeeOnline" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>人员在线情况监控</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        取用户表中的‘最后登录时间’字段和‘最后登出时间’字段进行比较，<br />
        如果‘最后登录时间’大于‘最后登出时间’，则表明此人在线。</div>
    </form>
</body>
</html>
