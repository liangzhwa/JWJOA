<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>江苏省警卫局办公自动化系统</title>
	<link href="style/style.css" rel="stylesheet" type="text/css" />
			<style>BODY { BACKGROUND: #799ae1; MARGIN: 0px; SCROLLBAR-HIGHLIGHT-COLOR: #3f73ad; SCROLLBAR-ARROW-COLOR: #3f73ad; SCROLLBAR-TRACK-COLOR: #1f5da8; SCROLLBAR-DARKSHADOW-COLOR: #ffffff; SCROLLBAR-BASE-COLOR: #799ae1 }
		</style>
		<link href="style/style.css" rel="stylesheet" type="text/css" />
		<script language="javascript" type="text/javascript">
	    function showsubmenu(sid)
	    {
		    whichEl = eval("submenu" + sid);
		    if (whichEl.style.display == "none")
		    {
			    eval("submenu" + sid + ".style.display=\"\";");
		    }
		    else
		    {
			    eval("submenu" + sid + ".style.display=\"none\";");
		    }
	    }
		</script>
</head>
<body bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0" >
    <form id="form1" runat="server">
    <div align="center">
        <table width="1000px" cellpadding="0" cellspacing="0" border="0" id="Table1" style="height:100%" class="table">
            <tr>
                <td valign="top" style="height: 80px">
                    <table border="0" cellpadding="0" cellspacing="0"  class="table0" style="background-image: url(images/top.jpg)">
                        <tr>
                            <td style="width: 900px" >
                            </td>
                            <td  valign="middle"  align="center">
                                <table border="0" cellpadding="0" cellspacing="0" class="tdheight">
                                    <tr>
                                        <td >
                                            <a href="index.aspx" class="link">[返回首页]</a></td>
                                    </tr>
                                    <tr>
                                        <td >
                                            <a href="#" class="link">[密码修改]</a></td>
                                    </tr>
                                    <tr>
                                        <td >
                                            <a href="exit.aspx" class="link">[退出系统]</a></td>
                                    </tr>                                    
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="tdheight"><table border="0" cellpadding="0" cellspacing="0"  class="table0">
                        <tr>
                            <td align="left" style="background-image: url(images/Menubg2.gif); width: 185px;">
                                <table border="0" cellpadding="0" cellspacing="0" style="height:100%">
                                    <tr>
                                        <td align="center" class="tdMenu1">
                                            <%--<asp:Label ID="LabelLogin" runat="server"></asp:Label>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" align="right" style="height:25px; width: 30%; background-image: url(images/Menubg2.gif);">
                                <asp:Label ID="lblLoginStaff" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td >
                <table class="table0" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" align="left" style="height: 92px;display:none;" id="frmMenu">
					            <iframe name="Menu"  frameborder="0" height="100%" marginheight="0" marginwidth="0" src="Menu.aspx?MenuId=1" width="100%" scrolling="auto">
					            </iframe>
				         </td>
				    </tr>
				    <tr>
						<td style="height:10px"  onclick="switchSysBar()" bgcolor="#e0ebfc" align="center"><img id="switchPoint"  src="images/scroll_up.gif" title="关闭/开启菜单栏" />
						</td>	
					</tr>
				</table>	
                </td>
            </tr>
            <tr>
                <td style="height: 100%">
                    <table border="0" cellpadding="0" cellspacing="0" class="table0">
                        <tr>
                        <td align="left" class="tdMenu1" valign="top">
                             <asp:Label ID="LabelLogin" runat="server"></asp:Label>
                        </td>
                        <td style="height: 141px" ><iframe name="Main"  frameborder="0" height="100%" marginheight="0" marginwidth="0" src="main.aspx" width="100%" scrolling="auto"></iframe>
                        </td>                      
                        <td  onclick="switchSysBar2()" bgcolor="#e0ebfc" valign="middle" style="width: 12px; height: 141px;"><img id="switchPoint2"  src="images/scroll_right.gif" title="关闭/开启菜单栏" />
                        </td>
                        <td valign="top" align="left" style="width: 222px;display:block; height: 141px; display:none;" id="frmMenu2">
                            <iframe name="Menu2"  frameborder="0" height="100%" marginheight="0" marginwidth="0" src="Menu2.aspx" width="100%" scrolling="no"></iframe>
                        </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>    
    </div>
    </form>
    <script type="text/javascript">
        function switchSysBar()
	    {
	        if (document.getElementById("frmMenu").style.display=="block")
	        {
	            document.getElementById("switchPoint").src="images/scroll_down.gif";
		        document.getElementById("frmMenu").style.display="none";
	        }
	        else
	        {
		        document.getElementById("switchPoint").src="images/scroll_up.gif";
		        document.getElementById("frmMenu").style.display="block";
		    }
	    }
	    
        function switchSysBar2()
	    {
	        if (document.getElementById("frmMenu2").style.display=="block")
	        {
	            document.getElementById("switchPoint2").src="images/scroll_right.gif";
		        document.getElementById("frmMenu2").style.display="none";
	        }
	        else
	        {
		        document.getElementById("switchPoint2").src="images/scroll_left.gif";
		        document.getElementById("frmMenu2").style.display="block";
		    }
	    }
	    
	    //通过给定的URL打开相应的页面
	    function OpenNewWindow(Url)
	    {
	        window.open(Url,Caption,'height=100, width=400, top=0, left=0, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
	    }
    </script>
</body>
</html>
