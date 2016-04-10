<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DutyNet.aspx.cs" Inherits="DutyManager_DutyNet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>警卫局网站信息报送审批表</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
       <table  style="width: 90%">
       <tr>
        <td>
            <asp:Panel ID ="panelxs" runat="server"  Width="90%">
                <asp:Label ID="lblxs" runat="server" Text=""  Width="100%"></asp:Label>
            </asp:Panel>
        </td>
       </tr>
        <tr>
            <td>
              <asp:Panel ID ="panelsr" runat ="server" Width="90%">
                   <table style="width: 100%">
            <tr>
                <td colspan="4" align="center">
                    警卫局网站信息报送审批表
                </td>
            </tr>
              <tr>
                <td  align="center" style="width: 25%">
                    勤务编号</td>
                  <td colspan="3">
                      <asp:DropDownList ID="drpOrder_ID" runat="server" Width="172px">
                      </asp:DropDownList></td>
            </tr>
             <tr>
                <td  align="center" style="width: 25%">
                    信息标题</td>
                  <td colspan="3">
                      <asp:TextBox ID="txtTitle" runat="server" TextMode="MultiLine" Height="60px" Width="98%"></asp:TextBox></td>
                      
            </tr>
              <tr>
                  <td rowspan="3"  align="center" style="width: 25%">
                      拟发网站</td>
                <td style="width: 25%">
                    <asp:CheckBox ID="CheckNet1" runat="server" Text="八局网站" /></td>
                <td style="width: 25%">
                    <asp:RadioButton ID="radType1" runat="server" GroupName="znn" Text="发布栏目" Width="85%" /></td>
                <td style="width: 189px">
                    <asp:RadioButton ID="radType2" runat="server" GroupName="znn" Text="发布子栏目" Width="85%" /></td>
               
              </tr>
                 <tr>
                <td>
                    <asp:CheckBox ID="CheckNet2" runat="server" Text="省厅网站" /></td>
                  <td>
                    
                </td>
                  <td style="width: 189px">
                    
                </td>
              </tr>
                <tr>
                <td>
                    <asp:CheckBox ID="CheckNet3" runat="server" Text="省局网站" />
                    
                </td>
                 <td>
                     <asp:RadioButton ID="radType3" runat="server" GroupName="znn" Text="勤务信息" /></td>
                  <td style="width: 189px">
                      <asp:RadioButton ID="radType4" runat="server" GroupName="znn" Text="现场勤务" /></td>
              </tr>
              <tr>
                <td colspan="4" align="center">
                    内<asp:Label ID="Label1" runat="server" Width="318px" Visible = false></asp:Label>容
                </td>
              </tr>
              <tr>
                <td></td>
                <td colspan="3" align="center">
                    <asp:TextBox ID="txtContent" runat="server" Width="98%" Height="186px" TextMode="MultiLine"></asp:TextBox>
                </td>
              </tr>
               <tr>
                    <td align="center">附件：</td>
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
                    <td>
                        </td>
                    <td colspan="3" align="right"> 
                        <input id="FileOne" type="file"  runat="server"/>
                        <asp:Button ID="btnFile" runat="server" Text="上传" OnClick="btnFile_Click" /></td>
                </tr>
              <tr>
                <td align="center">
                    承办单位</td>
                 <td>
                     <asp:TextBox ID="txtUnit" runat="server"></asp:TextBox></td>
                <td>
                    拟稿人</td>
                <td style="width: 189px">
                     <asp:Label ID="lblMan" runat="server"></asp:Label></td>
              </tr>
                 <tr>
                <td align="center">
                    拟稿时间</td>
                 <td>
                     <asp:Label ID="lblTime" runat="server"></asp:Label></td>
                      <td>
                    部门拟稿</td>
                <td style="width: 189px">
                     <asp:Button ID="btnPersonnel" runat="server" Text="办公室签名" OnClick="btnPersonnel_Click" /></td>
              </tr>
       </table>
              </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="panel1" runat="server" Width="100%"  Visible="false">
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
            <td align="right">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                <asp:Button ID="btnNext" runat="server" Text="下送" OnClick="btnNext_Click" />
            </td>
        </tr>
       </table>
    </div>
    </form>
</body>
</html>
