<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DutyStat.aspx.cs" Inherits="DutyManager_DutyStat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server"  type="checkbox"  >
    <title>无标题页</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server"  type="checkbox"  >
    <div>
        <table width="100%">
          <tr>
                <td style="width: 99px ">
                    勤务编号</td> 
                <td colspan="13" align="left">
                    <asp:DropDownList ID="drpOrder_ID" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr >
                <td style="width: 80px;">
                　　单位
                </td>
                 <td >南京警卫处
                </td>
                 <td style="height: 92px">
                    徐州警卫处
                </td>
                 <td style="height: 92px">
                    无锡警卫处
                </td>
                 <td style="height: 92px">
                    常州警卫处
                </td>
                 <td style="height: 92px">
                    苏州警卫处
                </td>
                 <td style="height: 92px">
                    南通警卫处
                </td>
                 <td style="height: 92px">
                    连云港警卫处
                </td>
                 <td style="height: 92px">
                    淮安警卫处
                </td>
                 <td style="height: 92px">
                    镇江警卫处
                </td>
                 <td style="height: 92px">
                    泰州警卫处
                </td>
                 <td style="height: 92px">
                    宿迁警卫处
                </td>
               　<td style="height: 92px; width: 65px;">
                    盐城警卫处
                </td>
                <td style="height: 92px">
                    扬州警卫处
                </td>
            </tr>
               <tr>
                <td style="width: 99px">
                    方案制作</td>
                 <td align="center">
                     <input id="Chknj1" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkxz1" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkwx1" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkcz1" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksz1" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chknt1" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chklyg1" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkha1" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkzj1" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chktz1" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksq1" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkyc1" runat="server"  type="checkbox"  /></td>
                  <td align="center">
                      <input id="Chkyz1" runat="server"  type="checkbox"  /></td>
            </tr>
               <tr>
                <td style="width: 99px">
                    前站工作</td>
                 <td align="center">
                     <input id="Chknj2" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkxz2" runat="server"  type="checkbox"  />
                </td>
                 <td align="center">
                     <input id="Chkwx2" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkcz2" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksz2" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chknt2" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chklyg2" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkha2" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkzj2" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chktz2" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksq2" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkyc2" runat="server"  type="checkbox"  /></td>
                  <td align="center">
                      <input id="Chkyz2" runat="server"  type="checkbox"  /></td>
            </tr>
               <tr>
                <td style="width: 99px; height: 21px;">
                    人员审查</td>
                 <td align="center">
                     <input id="Chknj3" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                    <input id="Chkxz3" runat="server"  type="checkbox"  />
                </td>
                 <td align="center">
                     <input id="Chkwx3" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkcz3" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksz3" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chknt3" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chklyg3" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkha3" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkzj3" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chktz3" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksq3" runat="server"  type="checkbox"  /></td>
                <td align="center">
                     <input id="Chkyc3" runat="server"  type="checkbox"  /></td>
                  <td align="center">
                      <input id="Chkyz3" runat="server"  type="checkbox"  /></td>
            </tr>
               <tr>
                <td style="width: 99px; height: 20px;">
                    安全检查</td>
                 <td align="center">
                     <input id="Chknj4" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                  <input id="Chkxz4" runat="server"  type="checkbox"  />
                </td>
                 <td align="center">
                     <input id="Chkwx4" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkcz4" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksz4" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chknt4" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chklyg4" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkha4" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkzj4" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chktz4" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksq4" runat="server"  type="checkbox"  /></td>
                <td align="center">
                     <input id="Chkyc4" runat="server"  type="checkbox"  /></td>
                  <td align="center">
                      <input id="Chkyz4" runat="server"  type="checkbox"  /></td>
            </tr>
               <tr>
                <td style="width: 99px; height: 21px;">
                    证件管理</td>
                 <td align="center">
                     <input id="Chknj5" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkxz5" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkwx5" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkcz5" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksz5" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chknt5" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chklyg5" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkha5" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkzj5" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chktz5" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksq5" runat="server"  type="checkbox"  /></td>
                <td align="center">
                     <input id="Chkyc5" runat="server"  type="checkbox"  /></td>
                  <td align="center">
                      <input id="Chkyz5" runat="server"  type="checkbox"  /></td>
            </tr>
               <tr>
                <td style="width: 99px; height: 21px;">
                    随卫警卫</td>
                 <td align="center">
                     <input id="Chknj6" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkxz6" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkwx6" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkcz6" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksz6" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chknt6" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chklyg6" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkha6" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkzj6" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chktz6" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksq6" runat="server"  type="checkbox"  /></td>
                <td align="center">
                     <input id="Chkyc6" runat="server"  type="checkbox"  /></td>
                  <td align="center">
                      <input id="Chkyz6" runat="server"  type="checkbox"  /></td>
            </tr>
               <tr>
                <td style="width: 99px">
                    住地警卫</td>
                 <td align="center">
                     <input id="Chknj7" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkxz7" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkwx7" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkcz7" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksz7" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chknt7" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chklyg7" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkha7" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkzj7" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chktz7" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksq7" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkyc7" runat="server"  type="checkbox"  /></td>
                  <td align="center">
                      <input id="Chkyz7" runat="server"  type="checkbox"  /></td>
            </tr>
               <tr>
                 <td style="width: 99px">
                     路线警卫</td>
                 <td align="center">
                     <input id="Chknj8" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkxz8" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkwx8" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkcz8" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksz8" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chknt8" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chklyg8" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkha8" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkzj8" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chktz8" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksq8" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                      <input id="Chkyc8" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkyz8" runat="server"  type="checkbox"  /></td>
            </tr>
               <tr>
                <td style="width: 99px">
                    现场警卫</td>
                 <td align="center">
                     <input id="Chknj9" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkxz9" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkwx9" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkcz9" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksz9" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chknt9" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chklyg9" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkha9" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkzj9" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chktz9" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksq9" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkyc9" runat="server"  type="checkbox"  /></td>
                  <td align="center">
                      <input id="Chkyz9" runat="server"  type="checkbox"  /></td>
            </tr>
               <tr>
                <td style="width: 99px; height: 21px;">
                    警卫形式</td>
                 <td align="center">
                     <input id="Chknj10" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkxz10" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkwx10" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkcz10" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksz10" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chknt10" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chklyg10" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkha10" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkzj10" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chktz10" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksq10" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkyc10" runat="server"  type="checkbox"  /></td>
                  <td align="center">
                      <input id="Chkyz10" runat="server"  type="checkbox"  /></td>
            </tr>
               <tr>
                <td style="width: 99px">
                    联络协调</td>
                 <td align="center">
                     <input id="Chknj11" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkxz11" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkwx11" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkcz11" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksz11" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chknt11" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chklyg11" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkha11" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkzj11" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chktz11" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksq11" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkyc11" runat="server"  type="checkbox"  /></td>
                  <td align="center">
                      <input id="Chkyz11" runat="server"  type="checkbox"  /></td>
            </tr>
               <tr>
                <td style="width: 99px">
                    突发情况处理</td>
                 <td align="center">
                     <input id="Chknj12" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkxz12" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkwx12" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkcz12" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksz12" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chknt12" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chklyg12" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkha12" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkzj12" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chktz12" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chksq12" runat="server"  type="checkbox"  /></td>
                 <td align="center">
                     <input id="Chkyc12" runat="server"  type="checkbox"  /></td>
                  <td align="center">
                      <input id="Chkyz12" runat="server"  type="checkbox"  /></td>
            </tr>
               <tr>
                <td style="width: 99px">
                    备注</td>
                <td colspan="13">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
            </tr>
              <tr>
                <td style="width: 99px">
                </td> 
                <td colspan="13" align="right">
                    <asp:Button ID="btnSave" runat="server" Text="Button" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
