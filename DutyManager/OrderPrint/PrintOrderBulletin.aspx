<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintOrderBulletin.aspx.cs" Inherits="DutyManager_OrderPrint_PrintOrderBulletin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns:v="urn:schemas-microsoft-com:vml"
xmlns:o="urn:schemas-microsoft-com:office:office"
xmlns:w="urn:schemas-microsoft-com:office:word"
xmlns="http://www.w3.org/TR/REC-html40">

<head>
<meta http-equiv=Content-Type content="text/html; charset=gb2312">
<meta name=ProgId content=Word.Document>
<meta name=Generator content="Microsoft Word 11">
<meta name=Originator content="Microsoft Word 11">
<link rel=File-List href="新建%20Microsoft%20Word%20文档.files/filelist.xml">
<title>机 密</title>
<!--[if gte mso 9]><xml>
 <o:DocumentProperties>
  <o:Author>xnn</o:Author>
  <o:LastAuthor>xnn</o:LastAuthor>
  <o:Revision>4</o:Revision>
  <o:TotalTime>177</o:TotalTime>
  <o:Created>2008-04-14T05:31:00Z</o:Created>
  <o:LastSaved>2008-04-14T05:32:00Z</o:LastSaved>
  <o:Pages>1</o:Pages>
  <o:Words>37</o:Words>
  <o:Characters>216</o:Characters>
  <o:Company>family</o:Company>
  <o:Lines>1</o:Lines>
  <o:Paragraphs>1</o:Paragraphs>
  <o:CharactersWithSpaces>252</o:CharactersWithSpaces>
  <o:Version>11.5606</o:Version>
 </o:DocumentProperties>
</xml><![endif]--><!--[if gte mso 9]><xml>
 <w:WordDocument>
  <w:View>Print</w:View>
  <w:SpellingState>Clean</w:SpellingState>
  <w:GrammarState>Clean</w:GrammarState>
  <w:PunctuationKerning/>
  <w:DrawingGridVerticalSpacing>7.8 磅</w:DrawingGridVerticalSpacing>
  <w:DisplayHorizontalDrawingGridEvery>0</w:DisplayHorizontalDrawingGridEvery>
  <w:DisplayVerticalDrawingGridEvery>2</w:DisplayVerticalDrawingGridEvery>
  <w:ValidateAgainstSchemas/>
  <w:SaveIfXMLInvalid>false</w:SaveIfXMLInvalid>
  <w:IgnoreMixedContent>false</w:IgnoreMixedContent>
  <w:AlwaysShowPlaceholderText>false</w:AlwaysShowPlaceholderText>
  <w:Compatibility>
   <w:SpaceForUL/>
   <w:BalanceSingleByteDoubleByteWidth/>
   <w:DoNotLeaveBackslashAlone/>
   <w:ULTrailSpace/>
   <w:DoNotExpandShiftReturn/>
   <w:AdjustLineHeightInTable/>
   <w:BreakWrappedTables/>
   <w:SnapToGridInCell/>
   <w:WrapTextWithPunct/>
   <w:UseAsianBreakRules/>
   <w:DontGrowAutofit/>
   <w:UseFELayout/>
  </w:Compatibility>
  <w:BrowserLevel>MicrosoftInternetExplorer4</w:BrowserLevel>
 </w:WordDocument>
</xml><![endif]--><!--[if gte mso 9]><xml>
 <w:LatentStyles DefLockedState="false" LatentStyleCount="156">
  <w:LsdException Locked="false" Name="Default Paragraph Font"/>
 </w:LatentStyles>
</xml><![endif]-->
<style>
<!--
 /* Font Definitions */
 @font-face
	{font-family:宋体;
	panose-1:2 1 6 0 3 1 1 1 1 1;
	mso-font-alt:SimSun;
	mso-font-charset:134;
	mso-generic-font-family:auto;
	mso-font-pitch:variable;
	mso-font-signature:3 135135232 16 0 262145 0;}
@font-face
	{font-family:楷体_GB2312;
	panose-1:2 1 6 9 3 1 1 1 1 1;
	mso-font-charset:134;
	mso-generic-font-family:modern;
	mso-font-pitch:fixed;
	mso-font-signature:1 135135232 16 0 262144 0;}
@font-face
	{font-family:Tahoma;
	panose-1:2 11 6 4 3 5 4 4 2 4;
	mso-font-charset:0;
	mso-generic-font-family:swiss;
	mso-font-pitch:variable;
	mso-font-signature:1627421319 -2147483648 8 0 66047 0;}
@font-face
	{font-family:"\@宋体";
	panose-1:2 1 6 0 3 1 1 1 1 1;
	mso-font-charset:134;
	mso-generic-font-family:auto;
	mso-font-pitch:variable;
	mso-font-signature:3 135135232 16 0 262145 0;}
@font-face
	{font-family:"\@楷体_GB2312";
	panose-1:2 1 6 9 3 1 1 1 1 1;
	mso-font-charset:134;
	mso-generic-font-family:modern;
	mso-font-pitch:fixed;
	mso-font-signature:1 135135232 16 0 262144 0;}
 /* Style Definitions */
 p.MsoNormal, li.MsoNormal, div.MsoNormal
	{mso-style-parent:"";
	margin:0cm;
	margin-bottom:.0001pt;
	text-align:justify;
	text-justify:inter-ideograph;
	mso-pagination:none;
	font-size:10.5pt;
	mso-bidi-font-size:12.0pt;
	font-family:"Times New Roman";
	mso-fareast-font-family:宋体;
	mso-font-kerning:1.0pt;}
p.MsoDocumentMap, li.MsoDocumentMap, div.MsoDocumentMap
	{mso-style-noshow:yes;
	margin:0cm;
	margin-bottom:.0001pt;
	text-align:justify;
	text-justify:inter-ideograph;
	mso-pagination:none;
	background:navy;
	font-size:10.5pt;
	mso-bidi-font-size:12.0pt;
	font-family:"Times New Roman";
	mso-fareast-font-family:宋体;
	mso-font-kerning:1.0pt;}
p.Char, li.Char, div.Char
	{mso-style-name:" Char";
	mso-style-update:auto;
	mso-style-parent:文档结构图;
	mso-style-link:默认段落字体;
	margin:0cm;
	margin-bottom:.0001pt;
	text-indent:22.7pt;
	mso-pagination:widow-orphan;
	background:navy;
	font-size:10.5pt;
	font-family:Tahoma;
	mso-fareast-font-family:宋体;}
 /* Page Definitions */
 @page
	{mso-page-border-surround-header:no;
	mso-page-border-surround-footer:no;}
@page Section1
	{size:595.3pt 841.9pt;
	margin:72.0pt 89.85pt 72.0pt 89.85pt;
	mso-header-margin:42.55pt;
	mso-footer-margin:49.6pt;
	mso-paper-source:0;
	layout-grid:15.6pt;}
div.Section1
	{page:Section1;}
-->
</style>
<!--[if gte mso 10]>
<style>
 /* Style Definitions */
 table.MsoNormalTable
	{mso-style-name:普通表格;
	mso-tstyle-rowband-size:0;
	mso-tstyle-colband-size:0;
	mso-style-noshow:yes;
	mso-style-parent:"";
	mso-padding-alt:0cm 5.4pt 0cm 5.4pt;
	mso-para-margin:0cm;
	mso-para-margin-bottom:.0001pt;
	mso-pagination:widow-orphan;
	font-size:10.0pt;
	font-family:"Times New Roman";
	mso-ansi-language:#0400;
	mso-fareast-language:#0400;
	mso-bidi-language:#0400;}
table.MsoTableGrid
	{mso-style-name:网格型;
	mso-tstyle-rowband-size:0;
	mso-tstyle-colband-size:0;
	border:solid windowtext 1.0pt;
	mso-border-alt:solid windowtext .5pt;
	mso-padding-alt:0cm 5.4pt 0cm 5.4pt;
	mso-border-insideh:.5pt solid windowtext;
	mso-border-insidev:.5pt solid windowtext;
	mso-para-margin:0cm;
	mso-para-margin-bottom:.0001pt;
	text-align:justify;
	text-justify:inter-ideograph;
	mso-pagination:none;
	font-size:10.0pt;
	font-family:"Times New Roman";
	mso-ansi-language:#0400;
	mso-fareast-language:#0400;
	mso-bidi-language:#0400;}
</style>
<![endif]--><!--[if gte mso 9]><xml>
 <o:shapedefaults v:ext="edit" spidmax="2050"/>
</xml><![endif]--><!--[if gte mso 9]><xml>
 <o:shapelayout v:ext="edit">
  <o:idmap v:ext="edit" data="1"/>
 </o:shapelayout></xml><![endif]-->
</head>

<body lang=ZH-CN style='tab-interval:21.0pt;text-justify-trim:punctuation'>

<div class=Section1 style='layout-grid:15.6pt'>

<p class=MsoNormal style="text-align: center" ><b><span>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<INPUT 
style="BORDER-BOTTOM-WIDTH: 1px; WIDTH: 48px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none" 
id="Text9" type=text runat="server" /></span></b><b style='mso-bidi-font-weight:normal'><span
lang=EN-US style='font-size:22.0pt'><o:p></o:p></span></b></p>


<p class=MsoNormal style='margin-top:0cm;margin-right:-16.4pt;margin-bottom:
0cm;margin-left:82.95pt;margin-bottom:.0001pt;mso-para-margin-top:0cm;
mso-para-margin-right:-1.56gd;mso-para-margin-bottom:0cm;mso-para-margin-left:
7.9gd;mso-para-margin-bottom:.0001pt;text-indent:42.85pt;mso-char-indent-count:
1.94'><b style='mso-bidi-font-weight:normal'><span style='font-size:22.0pt;
font-family:宋体;mso-ascii-font-family:"Times New Roman";mso-hansi-font-family:
"Times New Roman"'>警卫勤务报告单</span></b><b style='mso-bidi-font-weight:normal'><span
lang=EN-US style='font-size:22.0pt'><o:p></o:p></span></b></p>

<p class=MsoNormal align=center style='text-align:center'><span lang=EN-US><o:p>&nbsp;</o:p></span></p>

<table class=MsoTableGrid border=1 cellspacing=0 cellpadding=0
 style="border-collapse:collapse;border:none;mso-border-alt:double windowtext 1.5pt;
 mso-yfti-tbllook:480;mso-padding-alt:0cm 5.4pt 0cm 5.4pt; width: 572px;">
 <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes'>
  <td width=105 colspan=2 valign=top style='width:78.65pt;border-top:double 1.5pt;
  border-left:double 1.5pt;border-bottom:solid 1.0pt;border-right:solid 1.0pt;
  border-color:windowtext;mso-border-top-alt:double 1.5pt;mso-border-left-alt:
  double 1.5pt;mso-border-bottom-alt:solid .5pt;mso-border-right-alt:solid .5pt;
  mso-border-color-alt:windowtext;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:12.0pt;font-family:宋体'>来电单位<span lang=EN-US><o:p></o:p></span></span></p>
  </td>
  <td width=250 valign=top style='width:187.75pt;border-top:double windowtext 1.5pt;
  border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;
  mso-border-top-alt:double windowtext 1.5pt;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal><span lang=EN-US><o:p>&nbsp;<input id="txtCustName" runat="server" style="width: 216px; border-top-style: none;
          border-bottom: 1px; border-right-style: none; border-left-style: none" type="text" /></o:p></span></p>
  </td>
  <td valign=top style="width:91px;border-top:double windowtext 1.5pt;
  border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;
  mso-border-top-alt:double windowtext 1.5pt;padding:0cm 5.4pt 0cm 5.4pt">
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:"Times New Roman";
  mso-hansi-font-family:"Times New Roman"'>联</span><span style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:
  "Times New Roman";mso-hansi-font-family:"Times New Roman"'>系</span><span style='font-size:12.0pt;font-family:
  宋体;mso-ascii-font-family:"Times New Roman";mso-hansi-font-family:"Times New Roman"'>人</span><span
  lang=EN-US style='font-size:12.0pt'><o:p></o:p></span></p>
  </td>
  <td valign=top style="width:150px;border-top:double windowtext 1.5pt;
  border-left:none;border-bottom:solid windowtext 1.0pt;border-right:double windowtext 1.5pt;
  mso-border-left-alt:solid windowtext .5pt;mso-border-top-alt:double 1.5pt;
  mso-border-left-alt:solid .5pt;mso-border-bottom-alt:solid .5pt;mso-border-right-alt:
  double 1.5pt;mso-border-color-alt:windowtext;padding:0cm 5.4pt 0cm 5.4pt">
  <p class=MsoNormal><span lang=EN-US><o:p>&nbsp;<input id="Text4" runat="server" style="width: 106px; border-top-style: none;
          border-bottom: 1px; border-right-style: none; border-left-style: none" type="text" /></o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:1'>
  <td width=105 colspan=2 valign=top style='width:78.65pt;border-top:none;
  border-left:double windowtext 1.5pt;border-bottom:solid windowtext 1.0pt;
  border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;
  mso-border-alt:solid windowtext .5pt;mso-border-left-alt:double windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:12.0pt;font-family:宋体'>来电时间<span lang=EN-US><o:p></o:p></span></span></p>
  </td>
  <td width=250 valign=top style='width:187.75pt;border-top:none;border-left:
  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;
  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal><span lang=EN-US><o:p>&nbsp;<input id="Text1" runat="server" style="width: 169px; border-top-style: none;
          border-bottom: 1px; border-right-style: none; border-left-style: none" type="text" /></o:p></span></p>
  </td>
  <td valign=top style="width:91px;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;
  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt">
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:"Times New Roman";
  mso-hansi-font-family:"Times New Roman"'>接</span><span style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:
  "Times New Roman";mso-hansi-font-family:"Times New Roman"'>电</span><span style='font-size:12.0pt;font-family:
  宋体;mso-ascii-font-family:"Times New Roman";mso-hansi-font-family:"Times New Roman"'>人</span><span
  lang=EN-US style='font-size:12.0pt'><o:p></o:p></span></p>
  </td>
  <td valign=top style="width:150px;border-top:none;border-left:
  none;border-bottom:solid windowtext 1.0pt;border-right:double windowtext 1.5pt;
  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;
  mso-border-alt:solid windowtext .5pt;mso-border-right-alt:double windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt">
  <p class=MsoNormal><span lang=EN-US><o:p>&nbsp;<input id="Text5" runat="server" style="width: 107px; border-top-style: none;
          border-bottom: 1px; border-right-style: none; border-left-style: none" type="text" /></o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:2'>
  <td width=105 colspan=2 valign=top style="width:78.65pt;border-top:none;
  border-left:double windowtext 1.5pt;border-bottom:solid windowtext 1.0pt;
  border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;
  mso-border-alt:solid windowtext .5pt;mso-border-left-alt:double windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt; height: 22px;">
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:12.0pt;font-family:宋体'>接收方式<span lang=EN-US><o:p></o:p></span></span></p>
  </td>
  <td width=250 valign=top style="width:187.75pt;border-top:none;border-left:
  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;
  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt; height: 22px;">
  <p class=MsoNormal><span lang=EN-US><o:p>&nbsp;<input id="Text2" runat="server" style="width: 181px; border-top-style: none;
          border-bottom: 1px; border-right-style: none; border-left-style: none" type="text" /></o:p></span></p>
  </td>
  <td valign=top style="width:91px;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;
  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt; height: 22px;">
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:"Times New Roman";
  mso-hansi-font-family:"Times New Roman"'>勤务类别</span><span lang=EN-US
  style='font-size:12.0pt'><o:p></o:p></span></p>
  </td>
  <td valign=top style="width:150px;border-top:none;border-left:
  none;border-bottom:solid windowtext 1.0pt;border-right:double windowtext 1.5pt;
  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;
  mso-border-alt:solid windowtext .5pt;mso-border-right-alt:double windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt; height: 22px;">
  <p class=MsoNormal><span lang=EN-US><o:p>&nbsp;<input id="Text6" runat="server" style="width: 102px; border-top-style: none;
          border-bottom: 1px; border-right-style: none; border-left-style: none" type="text" /></o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:3'>
  <td width=105 colspan=2 valign=top style="width:78.65pt;border-top:none;
  border-left:double windowtext 1.5pt;border-bottom:solid windowtext 1.0pt;
  border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;
  mso-border-alt:solid windowtext .5pt;mso-border-left-alt:double windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt; height: 28px;">
 <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:12.0pt;font-family:宋体'>勤务规格</span><span lang=EN-US
  style='font-size:12.0pt'></span></p>
  </td>
  <td valign=top style="width:150px;border-top:none;border-left:
  none;border-bottom:solid windowtext 1.0pt;border-right:double windowtext 1.5pt;
  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;
  mso-border-alt:solid windowtext .5pt;mso-border-right-alt:double windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt; height: 22px;" colspan="3">
  <p class=MsoNormal><span lang=EN-US><o:p>&nbsp;<input id="Text3" runat="server" style="width: 127px; border-top-style: none;
          border-bottom: 1px; border-right-style: none; border-left-style: none" type="text" /></o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:4;page-break-inside:avoid;height:2.0cm'>
  <td width=569 colspan=5 style='width:426.4pt;border-top:none;border-left:
  double windowtext 1.5pt;border-bottom:solid windowtext 1.0pt;border-right:
  double windowtext 1.5pt;mso-border-top-alt:solid windowtext .5pt;mso-border-top-alt:
  solid .5pt;mso-border-left-alt:double 1.5pt;mso-border-bottom-alt:solid .5pt;
  mso-border-right-alt:double 1.5pt;mso-border-color-alt:windowtext;padding:
  0cm 5.4pt 0cm 5.4pt;height:2.0cm'>
  <p class=MsoNormal style='text-indent:12.0pt;mso-char-indent-count:1.0'><span
  style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:"Times New Roman";
  mso-hansi-font-family:"Times New Roman"'>主要内容：</span><span lang=EN-US
  style='font-size:12.0pt'><o:p></o:p></span></p>
  <p class=MsoNormal><span lang=EN-US><o:p></o:p></span><span lang=EN-US><o:p><asp:Label ID="txtText" runat="server" Height="240px"
      Width="594px"></asp:Label>&nbsp;</o:p></span><span lang=EN-US><o:p>&nbsp;</o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:5;page-break-inside:avoid;height:2.0cm'>
  <td style="width:69px;border-top:none;border-left:double windowtext 1.5pt;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;
  mso-border-left-alt:double windowtext 1.5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:2.0cm">
  <p class=MsoNormal align=center style='margin-top:0cm;margin-right:10.5pt;
  margin-bottom:0cm;margin-left:10.5pt;margin-bottom:.0001pt;text-align:center'><span
  style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:"Times New Roman";
  mso-hansi-font-family:"Times New Roman"'>局</span></p>
      <p align="center" class="MsoNormal" style="margin: 0cm 10.5pt 0pt; text-align: center">
          <span style="font-size: 12pt; font-family: 宋体; mso-ascii-font-family: 'Times New Roman';
              mso-hansi-font-family: 'Times New Roman'"></span><span
  style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:"Times New Roman";
  mso-hansi-font-family:"Times New Roman"'>拟</span></p>
      <p align="center" class="MsoNormal" style="margin: 0cm 10.5pt 0pt; text-align: center">
          <span style="font-size: 12pt; font-family: 宋体; mso-ascii-font-family: 'Times New Roman';
              mso-hansi-font-family: 'Times New Roman'"></span><span
  style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:"Times New Roman";
  mso-hansi-font-family:"Times New Roman"'>办</span></p>
      <p align="center" class="MsoNormal" style="margin: 0cm 10.5pt 0pt; text-align: center">
          <span style="font-size: 12pt; font-family: 宋体; mso-ascii-font-family: 'Times New Roman';
              mso-hansi-font-family: 'Times New Roman'"></span><span
  style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:"Times New Roman";
  mso-hansi-font-family:"Times New Roman"'>意</span></p>
      <p align="center" class="MsoNormal" style="margin: 0cm 10.5pt 0pt; text-align: center">
          <span style="font-size: 12pt; font-family: 宋体; mso-ascii-font-family: 'Times New Roman';
              mso-hansi-font-family: 'Times New Roman'"></span><span
  style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:"Times New Roman";
  mso-hansi-font-family:"Times New Roman"'>见</span><span lang=EN-US
  style='font-size:12.0pt'><o:p></o:p></span></p>
  </td>
  <td width=510 colspan=4 valign=top style='width:382.6pt;border-top:none;
  border-left:none;border-bottom:solid windowtext 1.0pt;border-right:double windowtext 1.5pt;
  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;
  mso-border-alt:solid windowtext .5pt;mso-border-right-alt:double windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:2.0cm'>
  <p class=MsoNormal><span lang=EN-US><o:p></o:p></span><span lang=EN-US><o:p><asp:Label ID="Label1" runat="server" Height="234px"
      Width="520px"></asp:Label></o:p></span><span
  lang=EN-US><span style='mso-spacerun:yes'>&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
      &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
      &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
      &nbsp; &nbsp;&nbsp; </span></span><span
  lang=EN-US style='font-size:12.0pt'><span
  style='mso-spacerun:yes'>&nbsp;</span></span><span style='font-size:12.0pt;
  font-family:宋体;mso-ascii-font-family:"Times New Roman";mso-hansi-font-family:
  "Times New Roman"'>签名：
      <input id="Text7" runat="server" style="width: 126px; border-top-style: none;
          border-bottom: 1px; border-right-style: none; border-left-style: none" type="text" /></span><span lang=EN-US style='font-size:12.0pt'><span
  style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  </span></span></p>
      <p class="MsoNormal" style="text-indent: 5cm; mso-char-indent-count: 13.5">
          &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <span lang="EN-US"
              style="font-size: 12pt"><span style="mso-spacerun: yes"></span><span style='mso-spacerun:yes'>&nbsp;</span></span><span
  style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:"Times New Roman";
  mso-hansi-font-family:"Times New Roman"'>时间：</span><span lang=EN-US
  style='font-size:12.0pt'><span style='mso-spacerun:yes'>&nbsp; <input id="Text8" runat="server" style="width: 126px; border-top-style: none;
          border-bottom: 1px; border-right-style: none; border-left-style: none" type="text" /></span><o:p></o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:6;mso-yfti-lastrow:yes;page-break-inside:avoid;
  height:42.4pt'>
  <td style="width:69px;border-top:none;border-left:double windowtext 1.5pt;
  border-bottom:double windowtext 1.5pt;border-right:solid windowtext 1.0pt;
  mso-border-top-alt:solid windowtext .5pt;mso-border-top-alt:solid .5pt;
  mso-border-left-alt:double 1.5pt;mso-border-bottom-alt:double 1.5pt;
  mso-border-right-alt:solid .5pt;mso-border-color-alt:windowtext;padding:0cm 5.4pt 0cm 5.4pt;
  height:42.4pt">
  <p class=MsoNormal align=center style='margin-top:0cm;margin-right:10.5pt;
  margin-bottom:0cm;margin-left:10.5pt;margin-bottom:.0001pt;text-align:center'><span
  style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:"Times New Roman";
  mso-hansi-font-family:"Times New Roman"'>备</span><span
  style='font-size:12.0pt;font-family:宋体;mso-ascii-font-family:"Times New Roman";
  mso-hansi-font-family:"Times New Roman"'>注</span><span lang=EN-US
  style='font-size:12.0pt'><o:p></o:p></span></p>
  </td>
  <td width=510 colspan=4 valign=top style='width:382.6pt;border-top:none;
  border-left:none;border-bottom:double windowtext 1.5pt;border-right:double windowtext 1.5pt;
  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:42.4pt'>
  <p class=MsoNormal><span lang=EN-US><o:p></o:p></span><span lang=EN-US><o:p><asp:Label ID="Label2" runat="server" Height="61px"
      Width="520px"></asp:Label>&nbsp; 
      </o:p></span></p>
  </td>
 </tr>
 <![if !supportMisalignedColumns]><tr height=0>
  <td style="border:none; width: 69px;"></td>
  <td width=46 style='border:none'></td>
  <td width=250 style='border:none'></td>
  <td style="border:none; width: 91px;"></td>
  <td style="border:none; width: 150px;"></td>
 </tr>
 <![endif]></table>

<p class=MsoNormal style='margin-right:-43.35pt;mso-para-margin-right:-4.13gd'><span
style='font-size:12.0pt;font-family:楷体_GB2312;mso-ascii-font-family:"Times New Roman"'>核稿：</span><span
lang=EN-US style='font-size:12.0pt;mso-fareast-font-family:楷体_GB2312'><span
style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span
style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span
style='mso-spacerun:yes'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; </span></span><span
style='font-size:12.0pt;font-family:楷体_GB2312;mso-ascii-font-family:"Times New Roman"'>江苏省公安厅警卫局制</span><span
lang=EN-US style='font-size:14.0pt;mso-fareast-font-family:楷体_GB2312'><o:p></o:p></span></p>

<p class=MsoNormal><span lang=EN-US style='font-size:14.0pt'><o:p>&nbsp;</o:p></span></p>

</div>

</body>

</html>