<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" EnableEventValidation="false" ValidateRequest ="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系统登录</title>    
    <link href="style/style.css" rel="stylesheet" type="text/css" />
	<script language="JavaScript" type="text/javascript">
	   
		function SetFocus()
		{
			document.getElementById("txtLoginName").focus();
		}
		
		function LoginSystem()
		{
			
		}
		function FillSelect(SelectId)
        {
            var Select=new Array(); 
            var Str1=new Array();
            var StrSelect=GetRole();
            Select=StrSelect.split("#");
            var i;
            for(i=0;i<Select.length;i++)
            {
                var SSelect=new Array();
                SSelect=Select[i].split("*");
                SelectId.options[i]=new Option(SSelect[1],SSelect[0]);
            }
            SelectId.options[0].selected=true;
            SelectId.length=i-1;
            document.getElementById("HiRole").value=(Select[0].split("*"))[0];
        }
		
		function SelectLayer(Select)
		{
		    document.getElementById("HiRole").value=Select.value;
		}
		
		function GetRole()
		{
			var url = "Login_GetRole.aspx?txtLoginName="+Form1.txtLoginName.value;
			var objxml = new ActiveXObject("Microsoft.XMLHttp");
			objxml.open("get",url,false);
			objxml.send();
			retInfo=objxml.responseText;
			if (objxml.status=="200")
			{
			    return retInfo;
			}
			else
			{
				alert('请与管理员联系,WebService返回错误代码:' + objxml.status);
				return false;
			}
		}
		

	</script>
  
	</head>
	<body onload="javascript:SetFocus();">
		<form id="Form1" method="post" runat="server">
            <table height="425" cellspacing="0" cellpadding="0" width="100%" border="0" id="TABLE1" onclick="return TABLE1_onclick()">
				<tr>
					<td align="center">
					<fieldset style="WIDTH: 260px; COLOR: #000000; HEIGHT: 70px; align: center; background-color: gainsboro;"><LEGEND align="left"><font color="green">用户登录</font></LEGEND>
						<table border="0" cellspacing="2" cellpadding="0" width="100%">														
							
							<tr>
								<td align="right"  style="width: 30%; height: 21px;">用户名：</td>
								<td align="left" style="height: 21px"><asp:textbox id="txtLoginName" runat="server" onfocusout="JavaScript:FillSelect(document.Form1.SelectSelect);" CssClass="xu" Width="130px"></asp:textbox>&nbsp;																					</td>
							</tr>
						    <tr>
								<td align="right" >密码：</td>
								<td align="left"><asp:textbox id="txtPwd" runat="server" TextMode="Password" Width="130px" CssClass="xu"></asp:textbox>&nbsp;
								</td>
							</tr>
							<tr>
								<td align="right" >登录角色：</td>
								<td align="left">
                                    <select id="SelectSelect" runat="server" class="ddl" onchange="javascript:SelectLayer(document.Form1.SelectSelect);" style="width: 130px">
                                      <option selected="selected">
                                      </option>
                                    </select>
								</td>
							</tr>
						</table>
					    <table width="241" border="0" cellspacing="0" cellpadding="0" style="width: 100%; height: 1px;">
							<tr>
								<td align="center" valign="middle" style="height: 20px">
									<asp:button id="LogButton" runat="server" Text="登录" CssClass="signinbtn2" OnClick="LogButton_Click"></asp:button>&nbsp;&nbsp;<INPUT id="Reset1" type="reset" value="重置" name="Reset1" runat="server" Class="signinbtn2">
								</td>
							</tr>
						</table>
					</fieldset>
						<FONT face="宋体"></FONT>
						</td>
				</tr>				
				<tr>
					<td align="right">
                           <input id="HiRole" runat="server" type="hidden" />
                    </td>
				</tr>
			</table>
		</form>	
	</body>
</html>
