using System;
using System.Data;
using System.Web.UI;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public class ControlDataBind
{
    private string _DBConn;
    private static string ConnStr;


    /// <summary>
    /// 数据库链接字
    /// </summary>
    public string DBConn
    {
        get { return _DBConn; }
    }

    public ControlDataBind(string ConnetionString)
    {
        ConnStr = ConnetionString;
        db = new MDataBase(ConnStr);
    }
    private static MDataBase db;
    private static string sql;

    #region DataGrid
    public void DataGridSqlBind(DataGrid DGrid, string sql,string SessionID,Label Message,string MsgStr)
    {
        try
        {
            DataTable dt = db.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                DGrid.DataSource = dt;
                DGrid.DataBind();
                DGrid.Visible = true;
            }
            else
            {
                Message.Text = MsgStr;
                DGrid.Visible = false;
            }
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/ControlDataBind", SessionID);
            Message.Text = MsgStr;
        }
    }

    public string GridViewSqlBind(GridView DGrid, string sql, string SessionID)
    {
        try
        {
            DataTable dt = db.GetDataTable(sql);
            string Message = "";
            if (dt.Rows.Count > 0)
            {
                DGrid.DataSource = dt;
                DGrid.DataBind();
            }
            else
                Message= "不能存在角色!";
            return Message;
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/ControlDataBind", SessionID);
            return "";
        }
     }


    /// <summary>
    /// DataGrid数据绑定
    /// </summary>
    /// <param name="DGrid"></param>
    /// <param name="ds"></param>
    /// <param name="btnFirst"></param>
    /// <param name="btnPrevious"></param>
    /// <param name="btnNext"></param>
    /// <param name="btnLast"></param>
    /// <param name="Str"></param>
    /// <param name="totalPage"></param>
    public static void DataGridDSBind(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label Message,string Str, Label totalPage, string SessionID)
    {
        try
        {
            DGrid.DataSource = ds.Tables[0];
            DGrid.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                totalPage.Text = "总共" + ds.Tables[0].Rows.Count + "条 第" + (DGrid.CurrentPageIndex + 1) + "页/共" + DGrid.PageCount + "页";
                btnFirst.Visible = true;
                btnPrevious.Visible = true;
                btnNext.Visible = true;
                btnLast.Visible = true;
                DGrid.Visible = true;
                if (DGrid.PageCount <= 1)
                {
                    btnFirst.Enabled = false;
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    if (DGrid.CurrentPageIndex == 0)
                    {
                        btnFirst.Enabled = false;
                        btnPrevious.Enabled = false;
                        btnNext.Enabled = true;
                        btnLast.Enabled = true;
                    }
                    else
                    {
                        btnFirst.Enabled = true;
                        btnPrevious.Enabled = true;
                        if (DGrid.CurrentPageIndex == DGrid.PageCount - 1)
                        {
                            btnNext.Enabled = false;
                            btnLast.Enabled = false;
                        }
                        else
                        {
                            btnNext.Enabled = true;
                            btnLast.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                Message.Text=Str;
                totalPage.Text = "";
                DGrid.Visible = false;
                btnFirst.Visible = false;
                btnPrevious.Visible = false;
                btnNext.Visible = false;
                btnLast.Visible = false;
            }
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/ControlDataBind", SessionID);
        }
    }

    /// <summary>
    /// 首页
    /// </summary>
    /// <param name="DGrid"></param>
    /// <param name="ds"></param>
    /// <param name="btnFirst"></param>
    /// <param name="btnPrevious"></param>
    /// <param name="btnNext"></param>
    /// <param name="btnLast"></param>
    /// <param name="Str"></param>
    /// <param name="totalPage"></param>
    public static void btnFirst(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label Message, string Str, Label totalPage, string SessionID)
    {
        DGrid.CurrentPageIndex = 0;
        DataGridDSBind(DGrid, ds, btnFirst, btnPrevious, btnNext, btnLast, Message,Str, totalPage, SessionID);
    }

    /// <summary>
    /// 前一页
    /// </summary>
    /// <param name="DGrid"></param>
    /// <param name="ds"></param>
    /// <param name="btnFirst"></param>
    /// <param name="btnPrevious"></param>
    /// <param name="btnNext"></param>
    /// <param name="btnLast"></param>
    /// <param name="Str"></param>
    /// <param name="totalPage"></param>
    public static void btnPrevious(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label Message, string Str, Label totalPage, string SessionID)
    {
        DGrid.CurrentPageIndex = Math.Max(DGrid.CurrentPageIndex - 1, 0);
        DataGridDSBind(DGrid, ds, btnFirst, btnPrevious, btnNext, btnLast, Message, Str, totalPage, SessionID);
    }

    /// <summary>
    /// 下一页
    /// </summary>
    /// <param name="DGrid"></param>
    /// <param name="ds"></param>
    /// <param name="btnFirst"></param>
    /// <param name="btnPrevious"></param>
    /// <param name="btnNext"></param>
    /// <param name="btnLast"></param>
    /// <param name="Str"></param>
    /// <param name="totalPage"></param>
    public static void btnNext(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label Message, string Str, Label totalPage, string SessionID)
    {
        DGrid.CurrentPageIndex = Math.Min(DGrid.CurrentPageIndex + 1, DGrid.PageCount - 1);
        DataGridDSBind(DGrid, ds, btnFirst, btnPrevious, btnNext, btnLast, Message, Str, totalPage, SessionID);
    }

    /// <summary>
    /// 末页
    /// </summary>
    /// <param name="DGrid"></param>
    /// <param name="ds"></param>
    /// <param name="btnFirst"></param>
    /// <param name="btnPrevious"></param>
    /// <param name="btnNext"></param>
    /// <param name="btnLast"></param>
    /// <param name="Str"></param>
    /// <param name="totalPage"></param>
    public static void btnLast(DataGrid DGrid, DataSet ds, Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast, Label Message, string Str, Label totalPage, string SessionID)
    {
        DGrid.CurrentPageIndex = DGrid.PageCount - 1;
        DataGridDSBind(DGrid, ds, btnFirst, btnPrevious, btnNext, btnLast, Message, Str, totalPage, SessionID);
    }
    #endregion

    /// <summary>
    /// 下拉列表数据绑定
    /// </summary>
    /// <param name="DDList">绑定控件名称</param>
    /// <param name="DataName">绑定字段名称</param>
    /// <param name="DataId">班定字段Id</param>
    /// <param name="Type">绑定的类型 1为带有"请选择", 2为没有"请选择",3"请选择"的值为空</param>
    public bool DropDownListBind(DropDownList DDList, string DataTable, string DataName, string DataId, int Type, string StrCondition, string SessionID)
    {
        try
        {
            sql = ControlDataBindSql.DropDownListBindSql(DataTable, DataName, DataId, StrCondition);
            DataTable dt = db.GetDataTable(sql);
            DataRow dr = null;
            if (Type == 1)
            {
                dr = dt.NewRow();
                dr[DataName] = "请选择";
                dr[DataId] = "-1";
                dt.Rows.InsertAt(dr, 0);
            }
            else if (Type == 0)
            {
                dr = dt.NewRow();
                dr[DataName] = "";
                dr[DataId] = "-1";
                dt.Rows.InsertAt(dr, 0);
            }
            else if (Type == 3)
            {
                dr = dt.NewRow();
                dr[DataName] = "请选择";
                dr[DataId] = "";
                dt.Rows.InsertAt(dr, 0);
            }
            else if (Type == 4)
            {
                dr = dt.NewRow();
                dr[DataName] = "0";
                dr[DataId] = "0";
                dt.Rows.InsertAt(dr, 0);
            }

            DDList.DataSource = dt;
            DDList.DataTextField = DataName;
            DDList.DataValueField = DataId;
            DDList.DataBind();
            return true;
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/ControlDataBind", SessionID);
            return false;
        }
    }

    public bool DropDownListBindFrDt(DropDownList DDList, DataTable dt, string DataName, string DataId, int Type, string SessionID)
    {
        try
        {
            DataRow dr = null;
            if (Type == 1)
            {
                dr = dt.NewRow();
                dr[DataName] = "请选择";
                dr[DataId] = "-1";
                dt.Rows.InsertAt(dr, 0);
            }
            else if (Type == 0)
            {
                dr = dt.NewRow();
                dr[DataName] = "";
                dr[DataId] = "-1";
                dt.Rows.InsertAt(dr, 0);
            }
            DDList.DataSource = dt;
            DDList.DataTextField = DataName;
            DDList.DataValueField = DataId;
            DDList.DataBind();
            return true;
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/ControlDataBind", SessionID);
            return false;
        }
    }

    /// <summary>
    /// 树的数据绑定，1张表，上级-1；
    /// </summary>
    /// <param name="TView"></param>
    /// <param name="node"></param>
    /// <param name="id"></param>
    /// <param name="DataTable"></param>
    /// <param name="ParentGuid"></param>
    /// <param name="MenuGuid"></param>
    /// <param name="MenuName"></param>
    /// <param name="ConnetionString"></param>
    public void AddNodes(TreeView TView, TreeNode node, string PidValue, string DataTable, string ParentGuid, string MenuGuid, string MenuName, string StrCondition, string OrderField, string SessionID)
    {
        try
        {
            sql = ControlDataBindSql.AddNodesSql(DataTable, ParentGuid, PidValue, StrCondition, OrderField);
            DataSet ds = db.GetDataSet(sql);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)                 //循环子节点集合
            {
                TreeNode nd = new TreeNode();
                nd.Value = dr[MenuGuid].ToString();         //存放节点 ID
                nd.Text = dr[MenuName].ToString();          //设置节点名称//	
                if (node == null || PidValue == "-1")
                {
                    TView.Nodes.Add(nd);                    //添加至根节点		
                }
                else
                {
                    node.ChildNodes.Add(nd);                //添加子节点
                }
                AddNodes(TView, nd, nd.Value, DataTable, ParentGuid, MenuGuid, MenuName, StrCondition, OrderField,SessionID);    //递归，添加该节点的子节点
            }
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "ControlDataBind", SessionID);
        }
    }

    //树的数据绑定，2张表
    public void AddPNodes(TreeView TView, TreeNode node, string PDataTable, string PMenuGuid, string PMenuName, string PMenuUrl,  string PStrCondition,string SDataTable, string SMenuGuid, string SMenuName, string SMenuUrl, string SStrCondition,string ConParentGuid, string OrderField, string SessionID)
    {
        try
        {
            TView.Nodes.Clear();
            sql = ControlDataBindSql.AddPNodesSql(PDataTable, PStrCondition, OrderField);
            DataTable dt = db.GetDataTable(sql);
            foreach (DataRow dr in dt.Rows)                  //循环子节点集合
            {
                TreeNode nd = new TreeNode();
                nd.Value = dr[PMenuGuid].ToString();         //存放节点 ID
                nd.Text = dr[PMenuName].ToString();          //设置节点名称
                nd.Target = "QuestionMain";
                nd.ImageUrl = "../images/Group.gif";
                nd.NavigateUrl = PMenuUrl + "?" + PMenuGuid + "=" + dr[PMenuGuid].ToString();
                TView.Nodes.Add(nd);                         //添加至根节点	

                AddSNodes(TView, nd, nd.Value, SDataTable, ConParentGuid, SMenuGuid, SMenuName, SMenuUrl, SStrCondition, OrderField, SessionID);         //递归，添加该节点的子节点
            }
            TView.DataBind();
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "ControlDataBind", SessionID);
        }
    }

    //树的数据绑定，2张表，子菜单
    private void AddSNodes(TreeView TView, TreeNode node, string ParentValue, string SDataTable, string ConParentGuid, string SMenuGuid, string SMenuName, string SMenuUrl, string SStrCondition, string OrderField, string SessionID)
    {
        try
        {
            sql = ControlDataBindSql.AddNodesSql(SDataTable, ConParentGuid, ParentValue, SStrCondition, OrderField);
            DataTable dt = db.GetDataTable(sql);
            foreach (DataRow dr in dt.Rows)                  //循环子节点集合
            {
                TreeNode nd = new TreeNode();
                nd.Value = dr[SMenuGuid].ToString();         //存放节点 ID
                nd.Text = dr[SMenuName].ToString();          //设置节点名称	
                nd.Target = "QuestionMain";
                nd.NavigateUrl = SMenuUrl + "?" + SMenuGuid + "=" + dr[SMenuGuid].ToString();
                node.ChildNodes.Add(nd);                     //添加子节点
            }
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "ControlDataBind", SessionID);
        }
    }

    /// <summary>
    /// 知识树/文章列表
    /// </summary>
    /// <param name="TView"></param>
    /// <param name="node"></param>
    /// <param name="PidValue"></param>
    /// <param name="DataTable"></param>
    /// <param name="ParentGuid"></param>
    /// <param name="MenuGuid"></param>
    /// <param name="MenuName"></param>
    /// <param name="StrCondition"></param>
    /// <param name="OrderField"></param>
    /// <param name="SessionID"></param>
    public void AddNodesArticle(TreeView TView, TreeNode node, string PidValue, string DataTable, string ParentGuid, string MenuGuid, string MenuName, string StrCondition, string OrderField, string SessionID)
    {
        try
        {
            if (node != null && PidValue != "-1")
            {
                sql = ControlDataBindSql.AddArticleSql(PidValue);
                DataSet ds1 = db.GetDataSet(sql);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
                    {
                        TreeNode nd1 = new TreeNode();
                        //nd1.ShowCheckBox = true;
                        nd1.Text = ds1.Tables[0].Rows[i]["ArticleTitle"].ToString();
                        nd1.Value = ds1.Tables[0].Rows[i]["KBaseArticle_Guid"].ToString();
                        //nd1.ImageUrl = "../images/folder.gif";
                        node.ChildNodes.Add(nd1);
                    }
                }
            }

            sql = ControlDataBindSql.AddNodesSql(DataTable, ParentGuid, PidValue, StrCondition, OrderField);

            DataSet ds = db.GetDataSet(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)                 //循环子节点集合
                {
                    TreeNode nd = new TreeNode();
                    nd.Value = dr[MenuGuid].ToString();         //存放节点 ID
                    nd.Text = dr[MenuName].ToString();          //设置节点名称
                    nd.ImageUrl = "../images/folder.gif";       //图像Url
                    nd.NavigateUrl="#";
                    if (node == null || PidValue == "-1")
                    {
                        TView.Nodes.Add(nd);                    //添加至根节点
                    }
                    else
                    {
                        node.ChildNodes.Add(nd);                //添加子节点
                    }                    
                    
                    AddNodesArticle(TView, nd, nd.Value, DataTable, ParentGuid, MenuGuid, MenuName, StrCondition, OrderField,SessionID);    //递归，添加该节点的子节点
                }                
            }            
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/ControlDataBind", SessionID);
        }
    }

    /// <summary>
    /// 知识树下拉列表"--"
    /// </summary>
    /// <param name="DDList"></param>
    /// <param name="PidValue"></param>
    /// <param name="DataTable"></param>
    /// <param name="ParentGuid"></param>
    /// <param name="MenuGuid"></param>
    /// <param name="MenuName"></param>
    /// <param name="StrCondition"></param>
    /// <param name="OrderField"></param>
    /// <param name="SessionID"></param>
    public void DropDownListAddNodes(DropDownList DDList, string PidValue, string DataTable, string ParentGuid, string MenuGuid, string MenuName, string StrCondition, string OrderField, string SessionID)
    {
        try
        {
            sql = "SELECT " + MenuGuid + "," + MenuName + " FROM " + DataTable + " where " + ParentGuid + "='" + PidValue + "' and StatusID='0'";
            DataSet ds = db.GetDataSet(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string strDeptID = "", strDeptName = "";
                if (PidValue != "-1")
                {
                    strDeptName += "--";
                }
                strDeptID = ds.Tables[0].Rows[i][MenuGuid].ToString().Trim();
                strDeptName += ds.Tables[0].Rows[i][MenuName].ToString().Trim();
                DDList.Items.Add(new ListItem(strDeptName, strDeptID));
                //递归调用
                DropDownListAddNodes(DDList, strDeptID, DataTable, ParentGuid, MenuGuid, MenuName, StrCondition, OrderField,SessionID);
            }
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/ControlDataBind", SessionID);
        }
    }

    //字体颜色绑定
    public static void DropDownListFontColorBind(DropDownList DDLFontColor, string SessionID)
    {
        try
        {
            string[] AllColors = Enum.GetNames(typeof(System.Drawing.KnownColor));
            string[] SystemEnvironmentColors = new string[(typeof(System.Drawing.SystemColors)).GetProperties().Length];

            int index = 0,a=0,b=0;;
            foreach (MemberInfo member in (typeof(System.Drawing.SystemColors)).GetProperties())
            {
                SystemEnvironmentColors[index++] = member.Name;
            }

            ListItemCollection LIC = new ListItemCollection();
            //LIC.Clear();
            ListItem LI = null;

            foreach (string color in AllColors)
            {
                if (Array.IndexOf(SystemEnvironmentColors, color) < 0)
                {
                    LI = new ListItem();
                    LI.Text = color;
                    LI.Value = color;
                    LIC.Add(LI);
                    b++;
                    if (color == "Black")
                        a = b;
                }
            }

            DDLFontColor.DataSource = LIC;
            DDLFontColor.DataBind();
            DDLFontColor.Items[a-1].Selected=true;

            int i;
            for (i = 0; i < DDLFontColor.Items.Count - 1; i++)
            {
                DDLFontColor.Items[i].Attributes.Add("style", "background-color:" + DDLFontColor.Items[i].Value);
                DDLFontColor.BackColor = Color.FromName(DDLFontColor.SelectedItem.Text);//DDLFontColor.Items[i].Value);
            }

        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/ControlDataBind.DropDownListFontColorBind", SessionID);
        }
    }
    
    //系统字体绑定
    public static void DropDownListFontSizeBind(DropDownList DDLFontSize, string SessionID)
    {
        try
        {
            ListItemCollection LIC = new ListItemCollection();
            //LIC.Clear();
            ListItem LI = null;
            InstalledFontCollection IFontC = new InstalledFontCollection();
            FontFamily[] FFonts = IFontC.Families;
            foreach (FontFamily FF in FFonts)
            {
                LI = new ListItem();
                LI.Text = FF.Name.ToString();
                LI.Value = FF.Name.ToString();
                LIC.Add(LI);
            }
            DDLFontSize.DataSource = LIC;
            DDLFontSize.DataBind();
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/ControlDataBind.DropDownListFontSizeBind", SessionID);
        }
    }

    /// <summary>
    /// 获取参数值
    /// </summary>
    /// <param name="ParameterName"></param>
    /// <returns></returns>
    public string GetDGridParameter(string ParameterName)
    {
        try
        {
            MDataBase db = new MDataBase(_DBConn);
            sql = "select ParameterValue from SSysRunParameter where ParameterName='" + ParameterName + "' and IsUser=0";
            return db.GetDataScalar(sql);
        }
        catch (Exception Err)
        {
            ErrorLog.LogInsert(Err.Message, "CS/ControlDataBind.GetDGridParameter", "");
            return "";
        }
    }

}
