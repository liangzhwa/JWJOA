<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommonlyTel.aspx.cs" Inherits="DutyManager_CommonlyTel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>一般电话登记</title>
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
    </script>
</head>
<body style="text-align: center">
    <form id="form1"  enctype="multipart/form-data" runat="server"> 
    <div>
        <table width="95%">
            <tr>
                <td>
                 <table width="100%">
                    <tr>
                        <td align="center">普通电话登记</td>
                    </tr>
                    <tr>
                        <td align="right">
                            登记编号：<asp:Label ID="lblTel_ID" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                </td>
            </tr>
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
                <td style="height: 440px">
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
                        <td colspan="3">
                            <input id="FileOne" type="file" style="width: 227px" runat="server" />
                            </td>
                        <td colspan="2" align="right"> 
                            <asp:Button ID="btnFile" runat="server" OnClick="btnFile_Click" Text="上传" />&nbsp;</td>
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
                            <td colspan="2"  align="left" style="background-color: #ffcc99; height: 20px;">办公室审阅</td>
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
                        <td align="left" colspan="2" style="background-color: #ffcc99">
                            领导批示
                        </td>
                     </tr>
                        <tr>
                            <td align="right" style="width: 13%">意见：</td>
                            <td width="85%" align="left">
                                <asp:DropDownList ID="dropTelNotion" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="dropTelNotion_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                         <tr>
                            <td align="right" style="width: 13%"></td>
                            <td width="85%" align="left">
                                <asp:TextBox ID="txtTelNotion" runat="server" Rows="5" TextMode="MultiLine" Width="98%"></asp:TextBox></td>
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
                   <asp:Panel ID = "panelAN" runat="server" Width="100%">
                        <table width="100%">
                            <tr>
                                <td colspan="4" align="right" style="height: 26px">
                                 <input id="txt1" type="text"  runat = "server" style="width: 0px; height: 0px"/>
                                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                                    <input id="Button5" runat="server" onclick="PopWindow()" type="button" value="选择人员" />
                                    <asp:Button  ID="btnNext" runat="server" OnClick="btnNext_Click" Text="下送" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField id="hfStaffId" runat="server"></asp:HiddenField>
    </form>
</body>
</html>
