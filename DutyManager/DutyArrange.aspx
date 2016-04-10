<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DutyArrange.aspx.cs" Inherits="DutyManager_DutyArrange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>勤务子安排</title>
     <script type="text/javascript" src="../js/calendar1.js"></script>
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
         function PopWindow1()
        {
            var StaffId1 = window.showModalDialog('../EmployeeManager/IsStaffOnline.aspx','员工选择页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(StaffId1 != "") 
            {
                var hf1 = document.getElementById("hfStaffId1");
                hf1.value = StaffId1; 
            }
        }
         function PopWindow2()
        {
            var StaffId2 = window.showModalDialog('../EmployeeManager/IsStaffOnline.aspx','员工选择页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(StaffId2 != "") 
            {
                var hf2 = document.getElementById("hfStaffId2");
                hf2.value = StaffId2;
            }
        }
         function PopWindow3()
        {
            var StaffId3 = window.showModalDialog('../EmployeeManager/IsStaffOnline.aspx','员工选择页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(StaffId3 != "") 
            {
                var hf3 = document.getElementById("hfStaffId3");
                hf3.value = StaffId3;
            }
        }
         function PopWindow4()
        {
            var StaffId4 = window.showModalDialog('../EmployeeManager/IsStaffOnline.aspx','员工选择页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(StaffId4 != "") 
            {
                var hf4 = document.getElementById("hfStaffId4");
                hf4.value = StaffId4;
            }
        }
        
    </script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
        <table width = "90%">
         <tr>
            <td>
             
                 <asp:Panel ID="panelXS" runat="server" width="100%" BorderStyle="None">
                  <table width="100%">
                     <tr>
                        <td>
                            <asp:Label ID="lblXS" runat="server" Text="" Width="100%" Height="100%">
                            
                            </asp:Label>
                        </td>
                    </tr>
                 </table>
              </asp:Panel>
             
            </td>
           </tr>
            <tr>
                <td>
                       <asp:Panel ID="panelAP" runat="server" Width="100%"  Visible="false">
                     <table width="100%">
                        <tr>
                        <td align="left" colspan="4" style="background-color: #ffcc99">
                            勤务分配
                        </td>
                     </tr>
                        <tr>
                           <td width="15%" align="right">日期时间从：</td>
                           <td width="35%" align="left">
                               <asp:TextBox ID="txtFromRTime" runat="server" Width="126px"  onclick="calendar()"></asp:TextBox>
                               <asp:DropDownList ID="drpFromSTime" runat="server" Width="50px">
                                <asp:ListItem>01</asp:ListItem>
                                <asp:ListItem>02</asp:ListItem>
                                <asp:ListItem>03</asp:ListItem>
                                <asp:ListItem>04</asp:ListItem>
                                <asp:ListItem>05</asp:ListItem>
                                <asp:ListItem>06</asp:ListItem>
                                <asp:ListItem>07</asp:ListItem>
                                <asp:ListItem>08</asp:ListItem>
                                <asp:ListItem>09</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>16</asp:ListItem>
                                <asp:ListItem>17</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>19</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>22</asp:ListItem>
                                <asp:ListItem>23</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                               </asp:DropDownList>时<asp:TextBox ID="txtFromFTime" runat="server" Width="26px" Text = "00"></asp:TextBox>分</td>
                           <td align="right" style="width: 15%">到</td>
                           <td width="35%" align="left">
                               <asp:TextBox ID="txtToRTime" runat="server" Width="106px"  onclick="calendar()"></asp:TextBox>
                               <asp:DropDownList ID="drpToSTime" runat="server" Width="48px" >
                                <asp:ListItem>01</asp:ListItem>
                                <asp:ListItem>02</asp:ListItem>
                                <asp:ListItem>03</asp:ListItem>
                                <asp:ListItem>04</asp:ListItem>
                                <asp:ListItem>05</asp:ListItem>
                                <asp:ListItem>06</asp:ListItem>
                                <asp:ListItem>07</asp:ListItem>
                                <asp:ListItem>08</asp:ListItem>
                                <asp:ListItem>09</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>16</asp:ListItem>
                                <asp:ListItem>17</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>19</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>22</asp:ListItem>
                                <asp:ListItem>23</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                               </asp:DropDownList>时<asp:TextBox ID="txtToFTime" runat="server" Width="33px" Text = "00"></asp:TextBox>分</td>
                        </tr>
                        <tr>
                          <td width="15%" align="right">
                              勤务地点：</td>
                           <td colspan="3">
                               <asp:TextBox ID="txtOrder_locus" runat="server" Width="98%"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                          <td width="15%" align="right">
                              接待单位：</td>
                           <td colspan="3">
                               <asp:TextBox ID="txtReceiveUnit" runat="server" Width="98%"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                          <td width="15%" align="right">
                              活动日程：</td>
                           <td colspan="3">
                               <asp:TextBox ID="txtOrder_Calendar" runat="server" Rows="5" TextMode="MultiLine" Width="98%"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                          <td width="15%" align="right">
                              工作要求：</td>
                           <td colspan="3">
                               <asp:TextBox ID="txtwork_Request" runat="server" Rows="5" TextMode="MultiLine" Width="98%"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                            <td>附件：</td>
                            <td colspan="3">
                                 <asp:GridView ID="GVAbjunct" runat="server"　AutoGenerateColumns="False" OnRowCancelingEdit="GVAbjunct_RowCancelingEdit" Width="90%" >
                             <Columns>
                                    <asp:ButtonField CommandName="Cancel" HeaderText="选择" ShowHeader="True"　Text="□">
                                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:ButtonField>
                                     <asp:BoundField DataField="AttachmentBatch_Guid" HeaderText="GUID" Visible= "false" />
                                    <asp:BoundField DataField="FileName" HeaderText="原文件名" />
                                
                             </Columns>
                    </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2">
                                <input id="FileTwo" type="file" runat="server" /> 
                            </td>
                            <td align="right">
                                &nbsp;<asp:Button ID="btnUp" runat="server" Text="上传" OnClick="btnUp_Click" />
                            </td>
                        </tr>
                          <tr>
                              <td align="right">
                                联系方式：</td>
                          <td align="left" colspan="3">
                                <asp:TextBox ID="txtLinkFashion" runat="server" Width="90%"></asp:TextBox>
                            </td>
                             
                        </tr>
                        <tr>
                              <td align="right">
                                总指挥：</td>
                          <td align="left">
                              
                              <input id="txtZCompere" type="text" runat="server"/>
                               <asp:Button ID="btnZCompere" runat="server" Text="Button" /></td>
                              <td align="right">
                                副指挥：
                            </td>
                              <td align="left">
                             
                                 <input id="txtFCompere" type="text"  runat = "server" />
                                   <asp:Button ID="btnFCompere" runat="server" Text="Button" /></td>
                        </tr>
                          <tr>
                             <td align="right">
                                 负责人：
                            </td>
                             <td align="left">
                             <input id="txtPrincipal" type="text"  runat = "server" />
                             <asp:Button ID="btnPrincipal" runat="server" Text="Button" />
                               
                            <td align="right">
                                相关人员：</td>
                           <td align="left">
                             
                                  <input id="txtXGMan" type="text"  runat = "server"/>
                                <asp:Button ID="btnXGMan" runat="server" Text="Button" /></td>
                        </tr>
                      
                     </table>
                 </asp:Panel>

                </td>
            </tr>
             <tr>
                <td>
                       <asp:Panel ID="panelPS" runat="server" Width="100%"  Visible="false">
                     <table width="100%">
                     <tr>
                        <td align="left" colspan="2" style="background-color: #ffcc99">
                            领导批示
                        </td>
                     </tr>
                        <tr>
                            <td align="right" style="width: 13%">意见：</td>
                            <td width="85%" align="left">
                                <asp:DropDownList ID="dropOrderNotion" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="dropOrderNotion_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                         <tr>
                            <td align="right" style="width: 13%"></td>
                            <td width="85%" align="left">
                                <asp:TextBox ID="txtOrderNotion" runat="server" Rows="5" TextMode="MultiLine" Width="98%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                             <td align="right">
                             <asp:Button ID="btnPerNumber" runat="server" Text="签名" OnClick="btnPerNumber_Click" />
                            </td>
                            
                        </tr>
                     </table>
                 </asp:Panel>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Panel ID="panelAP1" runat="server" Width="100%"  Visible="false">
                     <table width="100%">
                        <tr>
                        <td align="left" colspan="4" style="background-color: #ffcc99; height: 20px;">
                            勤务安排
                        </td>
                     </tr>
                        <tr>
                            <td align="right" style="width: 16%; height: 11px;" >
                                方案编写：
                            </td>
                             <td colspan="1" align="left" style="width: 16%; height: 11px;" >
                                 <asp:CheckBox ID="CheckBox1" runat="server" />
                             </td>  
                             <td colspan="2" align="left" style="height: 11px">
                               <asp:Button ID="Button1" runat="server" Text="Button" />
                                 <asp:Panel ID="Panel1" runat="server" Height="90%" Width="100%">
                                     １</asp:Panel>
                               </td>   
                        </tr>
                         <tr>
                            <td align="right">
                                   枪支编写：
                            </td>
                              <td colspan="1" align="left" style="width: 16%" >
                                 <asp:CheckBox ID="CheckBox2" runat="server" />
                             </td>  
                             <td colspan="2" align="left" style="height: 20px">
                              <asp:Button ID="Button2" runat="server" Text="Button" />
                                 <asp:Panel ID="Panel2" runat="server" Height="90%" Width="100%">
                                     １１</asp:Panel>
                             </td>    
                        </tr>
                         <tr>
                            <td align="right">
                                   徽章编写：
                            </td>
                             <td colspan="1" align="left" style="width: 16%" >
                                 <asp:CheckBox ID="CheckBox3" runat="server" />
                             </td>  
                              <td colspan="2" align="left" style="height: 20px">
                               <asp:Button ID="Button3" runat="server" Text="Button" />
                                 <asp:Panel ID="Panel3" runat="server" Height="90%" Width="100%">
                                     １</asp:Panel>
                             </td>     
                        </tr>
                         <tr>
                            <td align="right">
                                   车辆编写：
                            </td>
                              <td colspan="1" align="left" style="width: 16%" >
                                 <asp:CheckBox ID="CheckBox4" runat="server" />
                             </td>  
                              <td colspan="2" align="left" style="height: 20px">
                               <asp:Button ID="Button4" runat="server" Text="Button" />
                                 <asp:Panel ID="Panel4" runat="server" Height="90%" Width="100%">
                                     １</asp:Panel>
                             </td>   
                        </tr>
                     </table>
                 </asp:Panel>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Panel ID = "panelAN" runat="server" Width="100%">
                        <table width="100%">
                            <tr>
                                <td colspan="4" align="right">
                                    <input id="txt1" type="text"  runat = "server" style="width: 0px; height: 0px"/>
                                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                                    <input id="Button5" type="button" value="选择人员" runat="server" onclick="PopWindow()"/>
                                    <asp:Button ID="btnNext" runat="server" Text="下送" OnClick="btnNext_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
      <asp:HiddenField ID="hfStaffId" runat="server" />
       <asp:HiddenField ID="hfStaffId1" runat="server" />
        <asp:HiddenField ID="hfStaffId2" runat="server" />
         <asp:HiddenField ID="hfStaffId3" runat="server" />
          <asp:HiddenField ID="hfStaffId4" runat="server" />
    </form>
</body>
</html>
