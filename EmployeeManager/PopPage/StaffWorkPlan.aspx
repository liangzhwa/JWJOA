<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffWorkPlan.aspx.cs" Inherits="EmployeeManager_PopPage_StaffWorkPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>工作日程</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grvWorkPlan" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Day" HeaderText="工作日期" />
                <asp:BoundField DataField="Address" HeaderText="工作地点" />
                <asp:BoundField DataField="Job" HeaderText="工作内容" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
