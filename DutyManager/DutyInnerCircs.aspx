<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DutyInnerCircs.aspx.cs" Inherits="DutyManager_DutyInnerCircs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <script type="text/javascript" src="../js/calendar1.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
        <table width="95%">
            <tr>
              <td colspan="6" align="center">
              内/外宾警卫勤务安排执行情况登记表
              </td>
               
            </tr>
               <tr>
               <td colspan="6" align="right">
                登记日期：<asp:Label ID="lblEnregisterTime" runat="server" Width="100px"></asp:Label>
              </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                勤务编号：
                </td>
                <td colspan="2" align="left" style="width: 35%">
                    <asp:DropDownList ID="drpOrder_ID" runat="server" Width="151px" AutoPostBack="True" OnSelectedIndexChanged="drpOrder_ID_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td align="right" style="width: 156px">
                警卫规格：
                </td>
                 <td colspan="2"align="left" style="width: 35%">
                     <asp:DropDownList ID="drpGuardSpec" runat="server" Width="85px">
                     </asp:DropDownList></td>
            </tr>
            <tr>
                 <td align="right" style="width: 15%">
                任务名称：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="txtTaskName" runat="server" Width="90%"></asp:TextBox>
                </td>
            </tr>
             <tr>
                 <td align="right" style="width: 15%">
                抵达情况：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="txtDayNumber" runat="server" Width="17%"></asp:TextBox>
                    天
                </td>
            </tr>
            <tr>
                <td style="height: 26px" >
                
                </td>
                  <td style="width: 118px; height: 26px;" >
                      <asp:TextBox ID="txtArrivalTime1" runat="server" onclick="calendar()"></asp:TextBox></td>
                  <td style="height: 26px" >
                      <asp:DropDownList ID="drpArrivalTime2" runat="server">
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
                      </asp:DropDownList>时
                </td>
                  <td style="height: 26px">
                      自<asp:TextBox ID="txtFromArea" runat="server" Width="105px" ></asp:TextBox></td>
                  <td style="height: 26px"  >
                      乘<asp:TextBox ID="txtRiteVehicle" runat="server" Width="95px" ></asp:TextBox></td>
                  <td style="height: 26px" >
                      抵<asp:TextBox ID="txtArrivalArea" runat="server" Width="100px" ></asp:TextBox></td>
                
            </tr>
              <tr>
                <td >
                
                </td>
                  <td style="width: 118px" >
                      <asp:TextBox ID="txtArrivalTimeTwo1" runat="server" onclick="calendar()"></asp:TextBox></td>
                  <td >
                      <asp:DropDownList ID="drpArrivalTimeTwo2" runat="server">
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
                      </asp:DropDownList>时
                </td>
                  <td >
                      自<asp:TextBox ID="txtFromAreaTwo" runat="server" Width="105px"></asp:TextBox></td>
                  <td  >
                      乘<asp:TextBox ID="txtRiteVehicleTwo" runat="server" Width="95px" ></asp:TextBox></td>
                  <td >
                      抵<asp:TextBox ID="txtArrivalAreaTwo" runat="server" Width="99px" ></asp:TextBox></td>
                
            </tr>
             <tr>
                 <td align="right" style="width: 15%">
                接待单位：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="txtReceiveArea" runat="server" Width="90%"></asp:TextBox>
                </td>
            </tr>
              <tr>
                 <td align="right" style="width: 15%">
                省陪同领导：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="txtAccompanyFugle" runat="server" Width="90%"></asp:TextBox>
                </td>
            </tr>
             <tr>
                 <td align="right" style="width: 15%">
                活动日程：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="txtMoveDate" runat="server" Width="90%" Height="67px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
              <tr>
                 <td align="right" style="width: 15%">
                 随行人员(姓名/职务)：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="txtAccompanyPeo" runat="server" Width="90%" Height="67px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr>
                 <td align="right" style="width: 15%">
                警卫对象生活习惯：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="txtGuardCuston" runat="server" Width="90%" Height="67px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr>
                 <td align="left" colspan="6">
                警务完成情况：
                </td>
            </tr>
            <tr>
                 <td align="right" style="width: 15%">
                负责人：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="txtPrincipal" runat="server" Width="90%"></asp:TextBox></td>
            </tr>
            <tr>
                 <td align="right" style="width: 15%; height: 40px;">
                值勤人员：
                </td>
                <td colspan="5" style="height: 40px">
                    <asp:TextBox ID="txtRoster" runat="server" Width="90%" Height="47px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5">
                    <asp:TextBox ID="txtPerform" runat="server" Height="67px" TextMode="MultiLine" Width="90%"></asp:TextBox></td>
            </tr>
             <tr>
                 <td align="right" style="width: 15%">
                备注：
                </td>
                <td colspan="5">
                    <asp:TextBox ID="txtRemark" runat="server" Width="90%" Height="67px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr>
                 <td align="right" style="width: 15%">
                填表人：
                </td>
                <td colspan="5">
                    &nbsp;<asp:TextBox ID="txtCreatedBy" runat="server" Width="22%"></asp:TextBox></td>
            </tr>
              <tr>
                
                <td colspan="5">
                  </td>
               <td align="left" style="width: 15%">
                   <asp:Button ID="BtnSave" runat="server" Text="保存" OnClick="BtnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
