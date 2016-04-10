<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DutyNetSend.aspx.cs" Inherits="DutyManager_DutyNetSend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>下送选择</title>
      <script type="text/javascript" language="javascript">     
        

         function PopWindow()
        {
            var StaffId = window.showModalDialog('../EmployeeManager/IsStaffOnline.aspx','员工选择页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
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
    <div>
         <table>
                <tr>
                    <td colspan="2" align="left">
                   　 下步执行人员配置
                    </td>
                </tr>
                 
                  <tr>
                    <td>
                        下步操作执行人员：
                    </td>
                     <td style="width: 69px">
                          <input id="btnMan" type="button" value="选择人员" onclick="PopWindow()"/>
                    </td>
                </tr>
                 <tr>
                    <td colspan="2" align="right">
                        <input id="txt1" type="text" runat="server" style="width: 0px; height: 0px" />
                        <asp:Button ID="btnOK" runat="server" Text="确定" OnClick="btnOK_Click" Width="71px" />
                    </td> 
                </tr>
            </table>
    </div>
      <asp:HiddenField ID="hfStaffId" runat="server" />
    </form>
</body>
</html>
