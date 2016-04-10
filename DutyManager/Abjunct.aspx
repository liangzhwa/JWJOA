<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abjunct.aspx.cs" Inherits="DutyManager_Abjunct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="width: 520px; height: 20px">
                    <asp:GridView ID="GVAbjunct" runat="server"　AutoGenerateColumns="False" OnRowCancelingEdit="GVAbjunct_RowCancelingEdit" Width="520px" >
                      <Columns>
                             <asp:ButtonField CommandName="Cancel" HeaderText="选择" ShowHeader="True"　Text="□">
                                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                                        <HeaderStyle HorizontalAlign="Center" />
                             </asp:ButtonField>
                             <asp:BoundField DataField="AttachmentBatch_Guid" HeaderText="GUID" />
                             <asp:BoundField DataField="FileName" HeaderText="原文件名" />
                             <asp:BoundField DataField="CreatedDate" HeaderText="路径"  />
                      <%--    <asp:HyperLinkField DataNavigateUrlFields="FolderFileName" DataTextField="na1"  HeaderText="下载附件"> 
                            <HeaderStyle Width="8%" />
                             </asp:HyperLinkField>--%>
            
                       
                     </Columns>
                    </asp:GridView>
                
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
