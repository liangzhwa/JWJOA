<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DutyRegister.aspx.cs" Inherits="Dutyregister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>勤务登记页面</title>
     <script type="text/javascript" src="../js/calendar1.js"></script>
         <script type="text/javascript" language="javascript">    
       
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
          function PopWindow5()
        {
            var StaffId5 = window.showModalDialog('../EmployeeManager/IsStaffOnline.aspx','员工选择页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(StaffId != "") 
            {
                var hf5 = document.getElementById("hfStaffId5");
                hf5.value = StaffId5;
            }
        }
          function PopWindow6()
        {
            var StaffId6 = window.showModalDialog('../EmployeeManager/IsStaffOnline.aspx','员工选择页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(StaffId6 != "") 
            {
                var hf6 = document.getElementById("hfStaffId6");
                hf6.value = StaffId6;
            }
        }
          function PopWindow7()
        {
            var StaffId7 = window.showModalDialog('../EmployeeManager/IsStaffOnline.aspx','员工选择页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(StaffId7 != "") 
            {
                var hf7 = document.getElementById("hfStaffId7");
                hf7.value = StaffId7;
            }
        }
          function PopWindow8()
        {
            var StaffId8 = window.showModalDialog('../EmployeeManager/IsStaffOnline.aspx','员工选择页面','height=250, width=600, top='+(screen.AvailHeight-250)/2+', left='+ (screen.availWidth-600)/2 +', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
            if(StaffId8 != "") 
            {
                var hf8 = document.getElementById("hfStaffId8");
                hf8.value = StaffId8;
            }
        }
        
    </script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
       <table width="85%">
            <tr>
              <td style="width: 100%">
                  <table width="100%">
                    <tr>
                        <td align="center">警卫勤务报告单</td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="ButtonReturn" runat="server" Height="0px" OnClick="ButtonReturn_Click" Text="Button"
                                Width="0px" />勤务编号：<asp:Label ID="lblOrder_ID" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
              </td>
            </tr>
            <tr>
            <td>
             <div runat="server" id = "divXS" style="overflow: auto">
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
             </div>
            </td>
           </tr>
            <tr>
              <td style="width: 100%">
                  <asp:Panel ID="panelDJ" runat="server" Width="100%" Visible="false" >
    　　　　　     <table width="100%">
                <tr>
                    <td colspan="6"  align="left" style="background-color: #ffcc99">来电登记</td>
                </tr>
             
                <tr>
                    <td align="right" style="width: 20%">来电时间：</td>
                    <td colspan="3"  width="50%">
                        <asp:TextBox ID="txtTelRTime" runat="server"  onclick="calendar()"></asp:TextBox>
                        <asp:DropDownList ID="drpTelSTime" runat="server" Width="47px">
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
                        </asp:DropDownList>时<asp:TextBox ID="txtTelFTime" runat="server" Width="29px" Text = "00"></asp:TextBox>分</td>
                   
                      <td align="right" style="width: 20%">接收方式：</td>
                    <td align="left"  width="16%">
                        <asp:DropDownList ID="drpInceptMode" runat="server" Width="150px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                     <td align="right" style="width: 20%">
                         <asp:Label ID="Label1" runat="server" Text="勤务名称："></asp:Label></td>
                    <td width="75%" colspan="5">
                        <asp:TextBox ID="txtOrder_Name" runat="server" Width="98%"></asp:TextBox></td>
                </tr>
                <tr>
                     <td align="right" style="width: 20%">
                         <asp:Label ID="Label2" runat="server" Text="勤务规格："></asp:Label></td>
                    <td style="width: 16%"><asp:DropDownList ID="drpOrderSpec" runat="server" Width="99%">
                    </asp:DropDownList></td>
                     <td align="right" style="width: 21%">
                         <asp:Label ID="Label3" runat="server" Text="勤务类别："></asp:Label></td>
                    <td width="16%"><asp:DropDownList ID="drpOrderSort" runat="server" Width="99%">
                    </asp:DropDownList></td>
                    <td align="right" style="width: 17%">
                        <asp:Label ID="Label4" runat="server" Text="密级："></asp:Label></td>
                    <td width="16%"><asp:DropDownList ID="drpSecretDis" runat="server" Width="99%">
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%">来电人：</td>
                    <td align="right" style="width: 16%">
                        <asp:TextBox ID="txtTelCom" runat="server" Width="120px"></asp:TextBox></td>
                    <td align="right" style="width: 21%">接电人：</td>
                    <td align="right" width="16%"> <asp:TextBox ID="txtTelMeet" runat="server" Width="132px"></asp:TextBox></td>
                    <td align="right" style="width: 17%"></td>
                    <td align="right" width="16%"></td>
                </tr>
                 <tr>
                     <td align="right" style="width: 20%; height: 11px;">来电单位：</td>
                    <td width="75%" colspan="5" style="height: 11px">
                        <asp:TextBox ID="txtTelUnit" runat="server" Width="98%"></asp:TextBox></td>
                </tr>
                  <tr>
                     <td align="right" style="width: 20%; height: 34px;">主要内容：</td>
                    <td width="75%" colspan="5" style="height: 34px">
                        <asp:TextBox ID="txtMostlyContent" runat="server" Width="98%" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">附件：</td>
                    <td colspan="5">
                        <asp:GridView ID="GVAbjunctOne"  runat="server"　AutoGenerateColumns="False" OnRowCancelingEdit="GVAbjunctOne_RowCancelingEdit" Width="90%" >
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
                            <asp:FileUpload ID="FileOne" runat="server" /></td>
                        <td colspan="3" align="right"> <asp:Button ID="btnUpOne" runat="server" Text="上传" OnClick="BtnUpOne_Click"  /></td>
                    </tr>
            </table>
               </asp:Panel>         
              </td>
            </tr>
            <tr>
                <td>
            　     <asp:Panel ID="panelSY" runat="server" Width="100%"  Visible="false">
                     <table  width="100%">
                        <tr>
                            <td colspan="2"  align="left" style="background-color: #ffcc99">办公室审阅</td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                             <td align="right">
                             <asp:Button ID="BtnOK" runat="server" Text="同意" OnClick="BtnOK_Click" />
                            </td>
                            
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
                        <td align="left" colspan="2" style="background-color: #ffcc99; height: 20px;">
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
                     <asp:Panel ID="panelAP" runat="server" Width="100%"  Visible="false">
                     <table width="100%">
                        <tr>
                        <td align="left" colspan="4" style="background-color: #ffcc99">
                            勤务分配
                        </td>
                     </tr>
                        <tr>
                           <td align="right" style="width: 119px">日期时间从：</td>
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
                          <td align="right" style="width: 119px">
                              勤务地点：</td>
                           <td colspan="3">
                               <asp:TextBox ID="txtOrder_locus" runat="server" Width="98%"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                          <td align="right" style="width: 119px">
                              接待单位：</td>
                           <td colspan="3">
                               <asp:TextBox ID="txtReceiveUnit" runat="server" Width="98%"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                          <td align="right" style="width: 119px">
                              活动日程：</td>
                           <td colspan="3">
                               <asp:TextBox ID="txtOrder_Calendar" runat="server" Rows="5" TextMode="MultiLine" Width="98%"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                          <td align="right" style="width: 119px">
                              工作要求：</td>
                           <td colspan="3">
                               <asp:TextBox ID="txtwork_Request" runat="server" Rows="5" TextMode="MultiLine" Width="98%"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                            <td style="width: 119px">附件：</td>
                            <td colspan="3">
                                 <asp:GridView ID="GVAbjunctTwo"  runat="server"　AutoGenerateColumns="False" OnRowCancelingEdit="GVAbjunctTwo_RowCancelingEdit" Width="90%" >
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
                            <td style="width: 119px"></td>
                            <td colspan="2">
                                <input id="FileTwo" type="file" runat="server" /> 
                            </td>
                            <td align="right">
                                &nbsp;<asp:Button ID="BtnUpTwo" runat="server" Text="上传" OnClick="btnUpTwo_Click" />
                            </td>
                        </tr>
                          <tr>
                              <td align="right" style="width: 119px">
                                联系方式：</td>
                          <td align="left" colspan="3">
                                <asp:TextBox ID="txtLinkFashion" runat="server" Width="90%"></asp:TextBox>
                            </td>
                             
                        </tr>
                        <tr>
                              <td align="right" style="width: 119px">
                                总指挥：</td>
                          <td align="left">
                             <input id="txtZCompere" type="text"  runat = "server"/>
                              <input id="btnZCompere" runat="server" onclick="PopWindow1()" type="button" value="选择人员" />
                            </td>
                              <td align="right">
                                副指挥：
                            </td>
                              <td align="left">
                                <input id="txtFCompere" type="text"  runat = "server"/>
                                  <input id="btnFCompere" runat="server" onclick="PopWindow2()" type="button" value="选择人员" /></td>
                        </tr>
                          <tr>
                             <td align="right" style="width: 119px">
                                随卫负责人：
                            </td>
                             <td align="left">
                               <input id="txtSWPrincipal" type="text"  runat = "server"/>
                                 <input id="btnSWPrincipal" runat="server" onclick="PopWindow3()" type="button" value="选择人员" /></td>
                            <td align="right">
                                随卫人员：</td>
                           <td align="left">
                            <input id="txtSWMan" type="text"  runat = "server"/>
                               <input id="btnSWMan" runat="server" onclick="PopWindow4()" type="button" value="选择人员" /></td>
                        </tr>
                        
                          <tr>
                              <td align="right" style="width: 119px">
                                现场负责人：
                            </td>
                            <td align="left">
                               <input id="txtXCPrincipal" type="text"  runat = "server"/>
                                <input id="btnXCPrincipal" runat="server" onclick="PopWindow5()" type="button" value="选择人员" /></td>
                              <td align="right">
                                现场人员：
                            </td>
                             <td align="left">
                              <input id="txtXCMan" type="text"  runat = "server"/>
                                 <input id="btnXCMan" runat="server" onclick="PopWindow6()" type="button" value="选择人员" /></td>
                        </tr>
                           <tr>
                              <td align="right" style="width: 119px">
                                住地负责人：
                            </td>
                            <td align="left">
                             <input id="txtZDPrincipal" type="text"  runat = "server"/>
                                <input id="btnZDPrincipal" runat="server" onclick="PopWindow7()" type="button" value="选择人员" /></td>
                             <td align="right">
                                住地人员：
                            </td>
                             <td align="left">
                              <input id="txtZDMan" type="text"  runat = "server"/>
                                 <input id="btnZDMan" runat="server" onclick="PopWindow8()" type="button" value="选择人员" /></td>
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
                         <td align="left" colspan="4" style="background-color: #ffcc99; height: 1px;">
                            勤务安排
                        </td>
                     </tr>
                        <tr>
                            <td align="right" style="width: 16%" >
                                方案编写：
                            </td>
                             <td colspan="1" align="left" style="width: 16%" >
                                 <asp:CheckBox ID="CheckBox1" runat="server" />
                                 </td>  
                                  <td colspan="2" align="left" style="height: 20px">
                                   <asp:Button ID="Button1" runat="server" Text="新增" />
                                 <asp:Panel ID="Panel1" runat="server" Height="90%" Width="100%">
                                    １<asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink></asp:Panel>
                             </td>      
                        </tr>
                         <tr>
                            <td align="right" style="height: 64px">
                                   枪支编写：
                            </td>
                             <td colspan="1" align="left" style="width: 16%;" >
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                                 </td>
                                  <td colspan="2" align="left">
                                   <asp:Button ID="Button2" runat="server" Text="新增" />
                                 <asp:Panel ID="Panel2" runat="server" Height="90%" Width="100%">
                                     １１<asp:HyperLink ID="HyperLink2" runat="server">HyperLink</asp:HyperLink></asp:Panel>
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
                                    <asp:Button ID="Button3" runat="server" Text="新增" />
                                 <asp:Panel ID="Panel3" runat="server" Height="90%" Width="100%">
                                     １<asp:HyperLink ID="HyperLink3" runat="server">HyperLink</asp:HyperLink></asp:Panel>
                             </td>       
                        </tr>
                         <tr>
                            <td align="right" style="height: 39px">
                                   车辆编写：
                            </td>
                             <td colspan="1" align="left" style="width: 16%;" >
                                <asp:CheckBox ID="CheckBox4" runat="server" />
                                 </td>
                                  <td colspan="2" align="left" >
                                    <asp:Button ID="Button4" runat="server" Text="新增" />
                                 <asp:Panel ID="Panel4" runat="server" Height="90%" Width="100%">
                                     １<asp:HyperLink ID="HyperLink4" runat="server">HyperLink</asp:HyperLink></asp:Panel>
                                
                             </td>   
                            
                        </tr>
                         <tr>
                            <td align="right">随卫勤务安排：
                            </td>
                             <td colspan="1" align="left" style="width: 16%" >
                                 <asp:CheckBox ID="CheckBox5" runat="server" />
                                 </td>
                             <td colspan="2" align="left" style="height: 20px">
                               <asp:Button ID="Button5" runat="server" Text="新增" OnClick="Button5_Click" />
                                 <asp:Panel ID="Panel5" runat="server" Height="90%" Width="100%">
                                    <asp:GridView ID="GV5" runat="server"　AutoGenerateColumns="False" Width="90%" >
                                      <Columns>
                                          <asp:BoundField DataField="Order_ID" HeaderText="勤务编号" Visible="False" />
                                           <asp:BoundField DataField="OrderArrange_Guid" HeaderText="编号" Visible="False" />
                                           <asp:BoundField DataField="CreatedBy" HeaderText="创建人" />
                                          <asp:HyperLinkField Text="链接" HeaderText="链接" DataNavigateUrlFields="Order_ID,OrderArrange_Guid" DataNavigateUrlFormatString="DutyArrange.aspx?Order_ID={0}&amp;type='1'&amp;OrderArrange_Guid={1}" />
                                     </Columns>
                                    </asp:GridView>
                                 </asp:Panel>
                             </td>   
                        </tr>
                         <tr>
                            <td align="right">现场勤务安排：
                            </td>
                             <td colspan="1" align="left" style="width: 16%" >
                                <asp:CheckBox ID="CheckBox6" runat="server" />
                                 </td>
                             <td colspan="2" align="left" style="height: 20px">
                               <asp:Button ID="Button6" runat="server" Text="新增" OnClick="Button6_Click" />
                                 <asp:Panel ID="Panel6" runat="server" Height="90%" Width="100%">
                                     <asp:GridView ID="GV6" runat="server"　AutoGenerateColumns="False" Width="90%" >
                                         <Columns>
                                             <asp:BoundField DataField="Order_ID" HeaderText="勤务编号" Visible="False" />
                                             <asp:BoundField DataField="OrderArrange_Guid" HeaderText="编号" Visible="False" />
                                             <asp:BoundField DataField="CreatedBy" HeaderText="创建人" />
                                             <asp:HyperLinkField Text="链接" HeaderText="链接" DataNavigateUrlFields="Order_ID,OrderArrange_Guid" DataNavigateUrlFormatString="DutyArrange.aspx?Order_ID={0}&amp;type='2'&amp;OrderArrange_Guid={1}" />
                                         </Columns>
                                     </asp:GridView>
                                 </asp:Panel>
                             </td>   
                        </tr>
                         <tr>
                            <td align="right">住地勤务安排：
                            </td>
                             <td colspan="1" align="left" style="width: 16%" >
                                <asp:CheckBox ID="CheckBox7" runat="server" />
                                 </td>
                             <td colspan="2" align="left" style="height: 20px">
                               <asp:Button ID="Button7" runat="server" Text="新增" OnClick="Button7_Click" />
                                 <asp:Panel ID="Panel7" runat="server" Height="90%" Width="100%">
                                     <asp:GridView ID="GV7" runat="server"　AutoGenerateColumns="False" Width="90%" >
                                         <Columns>
                                             <asp:BoundField DataField="Order_ID" HeaderText="勤务编号" Visible="False" />
                                             <asp:BoundField DataField="OrderArrange_Guid" HeaderText="编号" Visible="False" />
                                             <asp:BoundField DataField="CreatedBy" HeaderText="创建人" />
                                             <asp:HyperLinkField Text="链接" HeaderText="链接" DataNavigateUrlFields="Order_ID,OrderArrange_Guid" DataNavigateUrlFormatString="DutyArrange.aspx?Order_ID={0}&amp;type='3'&amp;OrderArrange_Guid={1}" />
                                         </Columns>
                                     </asp:GridView>
                                 </asp:Panel>
                             </td>   
                        </tr>
                     </table>
                 </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID = "panelLD" runat="server" Width="100%">
                        <table width="100%">
                        <tr>
                            <td colspan="4" align="left" style="background-color: #ffcc99">来电记录</td>
                        </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    来电人：
                                </td>
                                 <td align="left" style="width: 35%">
                                     <asp:TextBox ID="txtLTelName" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" style="width: 15%">
                                  来电号码：
                                </td>
                                <td align="left" style="width: 35%">
                                 <asp:TextBox ID="txtLTNumber" runat="server" Width="90%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                 <td align="right" style="width: 15%">
                                  接电人：
                                </td>
                                <td>
                                  <asp:TextBox ID="txtJTelName" runat="server" Width="90%"></asp:TextBox>
                                </td>
                              <td align="right" style="width: 15%">
                                  来电时间：
                                </td>
                                <td align="left" style="width: 35%" >
                                   <asp:TextBox ID="txtLTelTime" runat="server" Width="126px"  onclick="calendar()"></asp:TextBox>
                                    <asp:DropDownList ID="DropDownList8" runat="server" Width="50px">
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
                                    </asp:DropDownList>时<asp:TextBox ID="TextBox32" runat="server" Width="26px"></asp:TextBox>分</td>
                             </tr>
              
                               <tr>
                                <td align="right" style="width: 15%">
                                  情况：
                                </td>
                                 <td align="left" style="width: 85%" colspan="3">
                                     <asp:TextBox ID="txtCircs" runat="server" Width="90%"></asp:TextBox></td>
                               
                            </tr>
                             <tr>
                                
                                 <td align="right" style="height: 26px">
                                  来电地址：
                                </td>
                                 <td align="left" colspan="3" style="height: 26px">
                                  <asp:TextBox ID="txtAddress" runat="server" Width="90%"></asp:TextBox>
                                </td>
                                
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID = "panelQD" runat="server" Width="100%">
                        <table width="100%">
                        <tr>
                            <td colspan="4" align="left" style="background-color: #ffcc99">去电记录</td>
                        </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    去电人：
                                </td>
                                 <td align="left" style="width: 35%">
                                     <asp:TextBox ID="txtQTelName" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" style="width: 15%">
                                    接电人：
                                </td>
                                <td align="left" style="width: 36%">
                                 <asp:TextBox ID="txtDJTelName" runat="server" Width="90%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                               
                                <td align="right" style="width: 15%">
                                  去电时间：
                                </td>
                                <td align="left" style="width: 35%" colspan="3">
                                    <asp:TextBox ID="txtQTelTime" runat="server" Width="126px"  onclick="calendar()"></asp:TextBox>
                                    <asp:DropDownList ID="DropDownList9" runat="server" Width="50px">
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
                                    </asp:DropDownList>时<asp:TextBox ID="TextBox35" runat="server" Width="26px"></asp:TextBox>分</td>
                            </tr>
                            <tr>
                                 <td align="right" style="width: 15%">
                                  情况：
                                </td>
                                 <td align="left" style="width: 85%" colspan="3">
                                     <asp:TextBox ID="txtCircsOne" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID = "panelXG" runat="server" Width="100%">
                        <table width="100%">
                        <tr>
                            <td colspan="4" align="left" style="background-color: #ffcc99">勤务地点修改</td>
                        </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                  勤务地点：
                                </td>
                                 <td align="left" style="width: 85%"  colspan="3">
                                     <asp:TextBox ID="txtlocus" runat="server" Width="90%"></asp:TextBox></td>
                                
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
                                <td colspan="4" align="right" style="height: 26px">
                                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /><asp:Button ID="btnNext" runat="server"
                                        Text="下送" OnClick="btnNext_Click" />&nbsp;<asp:Button ID="btnQX" runat="server" Text="取消勤务" OnClick="btnQX_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
       </table>
     </div>  
      <asp:HiddenField ID="hfStaffId1" runat="server" />
        <asp:HiddenField ID="hfStaffId2" runat="server" />
         <asp:HiddenField ID="hfStaffId3" runat="server" />
          <asp:HiddenField ID="hfStaffId4" runat="server" />
           <asp:HiddenField ID="hfStaffId5" runat="server" />
        <asp:HiddenField ID="hfStaffId6" runat="server" />
         <asp:HiddenField ID="hfStaffId7" runat="server" />
          <asp:HiddenField ID="hfStaffId8" runat="server" />
    </form>
</body>
</html>
