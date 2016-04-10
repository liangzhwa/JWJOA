<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DutyDisposal.aspx.cs" Inherits="DutyDisposal_" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>勤务查询页面</title>
    <script type="text/javascript" src="../js/calendar1.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
        <table>
          <tr>
                <td colspan="4" align="left">查询条件</td>
            </tr>
            <tr>
                <td align="right">
                    勤务编号：
                </td>
                <td align="left">
                    <asp:DropDownList ID="dropOrder" runat="server" Width="155px">
                    </asp:DropDownList></td>
                <td align="right">
                    勤务名称：
                </td>
                <td align="left">
                     <asp:TextBox ID="txtOrderName" runat="server"></asp:TextBox>
                </td>
              
            </tr>
            <tr>
                <td align="right">
                    勤务时间从：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTelRTime" runat="server" onclick="calendar()"></asp:TextBox>
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
                        </asp:DropDownList>时<asp:TextBox ID="txtTelFTime" runat="server" Width="29px">00</asp:TextBox>分  
                </td>
                <td align="right">
                    到：
                </td>
                <td align="left">
                      <asp:TextBox ID="TextBox1" runat="server" onclick="calendar()"></asp:TextBox>
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="47px">
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
                        </asp:DropDownList>时<asp:TextBox ID="TextBox2" runat="server" Width="29px">00</asp:TextBox>分 
                </td>
                   
            </tr>
               <tr>
                 <td align="right">
                    勤务状态：
                </td>
                <td align="left">
                    <asp:DropDownList ID="dropZT" runat="server" Width="86px">
                        <asp:ListItem Value="-1">请选择</asp:ListItem>
                        <asp:ListItem Value="1">待办</asp:ListItem>
                        <asp:ListItem Value="2">在办</asp:ListItem>
                        <asp:ListItem Value="4">完结</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right" colspan="2">
                   <asp:Button ID="txtCX" runat="server" Text="查询" OnClick="txtCX_Click" />
                </td>    
            </tr>
            <tr>
                <td colspan="4" align="left">查询结果</td>
            </tr>
              <tr>
                <td colspan="4">
                    <asp:GridView ID="GVOrder" runat="server"　AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" Width="90%" >
                      <Columns>
                            <asp:ButtonField CommandName="Cancel" HeaderText="选择" ShowHeader="True"　Text="□">
                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="Order_ID" HeaderText="勤务编号" />
                            <asp:BoundField DataField="Order_Name" HeaderText="勤务名称"  />
                            <asp:BoundField DataField="CreatedDate" HeaderText="创建日期"  />
                            <asp:BoundField DataField="StatusId" HeaderText="勤务状态"  />
                     </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
