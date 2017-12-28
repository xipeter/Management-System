using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
namespace Neusoft.HISFC.Components.Common.Controls
{
    public partial class ucQuery : UserControl
    {
        public ucQuery()
        {
            InitializeComponent();
        }

        #region  全局变量
        #region 字符串代表的含意
        //		INT 
        //		BOOL  
        //		DATETIME 日期
        //		DEPARTMENT 部门
        //		MARI   婚姻
        //		OPERATOR  操作员
        //           SEX 性别
        #endregion
        private int iRowBlank = 15;
        /// <summary>
        /// 空白宽度
        /// </summary>
        protected int iBlankWidth = 10;
        /// <summary>
        /// 当前行
        /// </summary>
        protected int iCurrentRow = 0;
        protected System.Windows.Forms.Button btnDefault;
        protected enuDirection myDirection = enuDirection.H;
        /// <summary>
        /// 管理查询条件
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Manager.QueryCondition managerCondition = new Neusoft.HISFC.BizLogic.Manager.QueryCondition();
        #endregion

        #region 初始化
        private void groupBox1_Enter(object sender, System.EventArgs e)
        {

        }

        private void ucQuery_Load(object sender, System.EventArgs e)
        {
            try
            {
                //初始化 操作符
                this.initOperations();
                //初始化连接条件
                this.initRelations();
                // 刷新列表
                this.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        protected int iTab = 10;
        protected ArrayList alOperations = null;
        /// <summary>
        /// 初始化操作符
        /// </summary>
        protected void initOperations()
        {
            this.alOperations = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "=";
            obj.Name = "等于";
            obj.Memo = "dy";

            this.alOperations.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = ">";
            obj.Name = "大于";
            obj.Memo = "dy";
            this.alOperations.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "<";
            obj.Name = "小于";
            obj.Memo = "xy";
            this.alOperations.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "like";
            obj.Name = "包含";
            obj.Memo = "dy";
            this.alOperations.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "<=";
            obj.Name = "小于等于";
            obj.Memo = "xy";
            this.alOperations.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = ">=";
            obj.Name = "大于等于";
            obj.Memo = "xy";
            this.alOperations.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "<>";
            obj.Name = "不等于";
            obj.Memo = "bdy";
            this.alOperations.Add(obj);
        }
        protected ArrayList alRelations = null;
        /// <summary>
        /// 初始化连接条件
        /// </summary>
        protected void initRelations()
        {
            this.alRelations = new ArrayList();

            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "";
            obj.Name = "无";
            obj.Memo = "w";
            this.alRelations.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "AND";
            obj.Name = "和";
            obj.Memo = "h";
            this.alRelations.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "OR";
            obj.Name = "或";
            obj.Memo = "h";
            this.alRelations.Add(obj);
        }
        #endregion

        #region IQuery 成员
        /// <summary>
        /// 当前控件方向
        /// </summary>
        public enuDirection Direction
        {
            get
            {
                return this.myDirection;
            }
            set
            {
                this.myDirection = value;
            }
        }
        private int iConditionWidth = 150;
        /// <summary>
        /// 条件框宽度 
        /// </summary>
        public int ConditionWidth
        {
            get
            {
                // TODO:  添加 ucQuery.ConditionWidth getter 实现
                return this.iConditionWidth;
            }
            set
            {
                // TODO:  添加 ucQuery.ConditionWidth setter 实现
                this.iConditionWidth = value;
                this.RefreshList();
            }
        }
        private int iValueWidth = 150;
        /// <summary>
        /// 数值框宽度
        /// </summary>
        public int ValueWidth
        {
            get
            {
                // TODO:  添加 ucQuery.ValueWidth getter 实现
                return this.iValueWidth;
            }
            set
            {
                // TODO:  添加 ucQuery.ValueWidth setter 实现
                this.iValueWidth = value;
                this.RefreshList();
            }
        }

        /// <summary>
        /// 行宽度
        /// </summary>
        public int RowBlank
        {
            get
            {
                // TODO:  添加 ucQuery.RowBlank getter 实现
                return this.iRowBlank;
            }
            set
            {
                // TODO:  添加 ucQuery.RowBlank setter 实现
                this.iRowBlank = value;
                this.RefreshList();
            }
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        public System.Windows.Forms.Button ButtonOK
        {
            get
            {
                return this.btnOK;
            }
            set
            {
                this.btnOK = value;
            }
        }
        /// <summary>
        /// 退出按钮
        /// </summary>
        public System.Windows.Forms.Button ButtonExit
        {
            get
            {
                return this.btnExit;
            }
            set
            {
                this.btnExit = value;
            }
        }
        /// <summary>
        /// 恢复按钮
        /// </summary>
        public System.Windows.Forms.Button ButtonReset
        {
            get
            {
                return this.btnReset;
            }
            set
            {
                this.btnReset = value;
            }
        }
        /// <summary>
        /// 默认按钮
        /// </summary>
        public System.Windows.Forms.Button ButtonDefault
        {
            get
            {
                return this.btnDefault;
            }
            set
            {
                this.btnDefault = value;
            }
        }

        protected ArrayList alConditions = null;
        /// <summary>
        /// 初始化界面--必须一
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public int InitCondition(ArrayList conditions)
        {
            // TODO:  添加 ucQuery.InitCondition 实现
            if (conditions.Count <= 0)
            {
                Neusoft.FrameWork.Models.NeuObject objTemp = new Neusoft.FrameWork.Models.NeuObject();
                conditions.Add(objTemp);
            }

            Neusoft.FrameWork.Models.NeuObject o = conditions[0] as Neusoft.FrameWork.Models.NeuObject;
            if (o == null)
            {
                MessageBox.Show("传入的条件必须继承于neuObject.");
                return -1;
            }
            alConditions = conditions;
            return this.RefreshList();
        }
        /// <summary>
        /// 初始化界面-dataset
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int InitCondition(DataSet ds)
        {
            return 0;
        }

        /// <summary>
        /// 初始化界面 - sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int InitCondition(string sql)
        {
            return 0;
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <returns></returns>
        public int RefreshList()
        {
            if (this.alConditions == null || this.alConditions.Count <= 0)
            {
                this.alConditions = new ArrayList();
                Neusoft.FrameWork.Models.NeuObject objTemp = new Neusoft.FrameWork.Models.NeuObject();
                objTemp.ID = "";
                objTemp.Name = "列名";
                alConditions.Add(objTemp);
            }
            iCurrentRow = -1;
            this.ClearAll();
            AddNewRow();

            this.ReadCondition();
            return 0;
        }
        /// <summary>
        /// 删除全部
        /// </summary>
        public void ClearAll()
        {
            for (int i = this.panel1.Controls.Count - 1; i >= 0; i--)
            {
                Control c = this.panel1.Controls[i];
                try
                {
                    if (c.GetType() != typeof(Button))
                    {
                        this.panel1.Controls.RemoveAt(i);
                        c.Dispose();
                    }
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// 清除一行
        /// </summary>
        /// <param name="iRow"></param>
        public void ClearRow(int iRow)
        {
            if (iRow < 0) return;
            for (int i = this.panel1.Controls.Count - 1; i >= 0; i--)
            {
                Control c = this.panel1.Controls[i];
                try
                {
                    if (Neusoft.FrameWork.Function.NConvert.ToInt32(c.Name.Substring(c.Name.Length - 2)) == iRow
                        && c.GetType() != typeof(Button))
                    {
                        this.panel1.Controls.RemoveAt(i);
                        c.Dispose();
                    }
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="iRow"></param>
        /// <param name="iExceptType"></param>
        public void ClearRow(int iRow, int iExceptType)
        {
            if (iRow < 0) return;
            for (int i = this.panel1.Controls.Count - 1; i >= 0; i--)
            {
                Control c = this.panel1.Controls[i];
                try
                {
                    if (iExceptType == 0)
                    {
                        if (Neusoft.FrameWork.Function.NConvert.ToInt32(c.Name.Substring(c.Name.Length - 2)) == iRow
                            && (c.Name.Substring(0, 5) == "opera" || c.Name.Substring(0, 5) == "value") && c.GetType() != typeof(Button))
                        {
                            this.panel1.Controls.RemoveAt(i);
                            c.Dispose();
                        }
                    }
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// 插入一新行
        /// </summary>
        public void AddNewRow()
        {
            iCurrentRow++;
            this.insertConditionBox();
            this.insertRelationBox();
        }
        public void AddNewRow(int iRow)
        {
            iCurrentRow = iRow;
            this.insertConditionBox();
            this.insertRelationBox();
        }
        /// <summary>
        /// 条件字段， 如 住院号，姓名
        /// </summary>
        protected void insertConditionBox()
        {
            foreach (Control c in this.panel1.Controls)
            {
                if (c.Name == "condition" + iCurrentRow.ToString().PadLeft(2, '0'))
                {
                    return;
                }
            }
            Neusoft.FrameWork.WinForms.Controls.NeuComboBox combox = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            combox.Width = this.iConditionWidth;
            if (this.myDirection == enuDirection.H)
            {
                combox.Location = new Point(iBlankWidth, iCurrentRow * 21 + (iCurrentRow + 1) * iRowBlank);
            }
            else
            {
                combox.Location = new Point(iBlankWidth, (iCurrentRow) * 21 + (iCurrentRow + 1) * (iRowBlank * 3));
                combox.ForeColor = Color.Blue;
            }
            //combox.IsShowCustomerList = true;
            combox.Visible = true;
            combox.TabIndex = iCurrentRow * 10 + 1;
            combox.Name = "condition" + iCurrentRow.ToString().PadLeft(2, '0');
            combox.AddItems(this.alConditions);
            combox.SelectedIndexChanged += new EventHandler(combox_SelectedIndexChanged);
            combox.KeyPress += new KeyPressEventHandler(combox_KeyPress);
            combox.SelectedIndex = 0;
            this.panel1.Controls.Add(combox);
        }
        protected void insertOperationBox(string type)
        {
            if (this.alOperations == null) this.initOperations();
            if (this.alOperations == null)
            {
                MessageBox.Show("获取操作符失败");
                return;
            }
            Neusoft.FrameWork.WinForms.Controls.NeuComboBox combox = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            combox.Width = 50;
            if (this.myDirection == enuDirection.H)
            {
                combox.Location = new Point(iBlankWidth * 2 + this.iConditionWidth, iCurrentRow * 21 + (iCurrentRow + 1) * iRowBlank);
            }
            else
            {
                combox.Location = new Point(iBlankWidth * 2 + this.iConditionWidth, (iCurrentRow) * 21 + (iCurrentRow + 1) * (iRowBlank * 3));
                combox.ForeColor = Color.Blue;
            }
            //combox.IsShowCustomerList = true;
            combox.Visible = true;
            combox.TabIndex = iCurrentRow * 10 + 2;
            combox.Name = "operation" + iCurrentRow.ToString().PadLeft(2, '0');
            combox.KeyPress += new KeyPressEventHandler(combox_KeyPress);
            combox.IsListOnly = true;
            try
            {
                ArrayList al = this.alOperations.Clone() as ArrayList;
                if (type == "INT")
                {
                    al.RemoveAt(3);//去掉包含
                }
                else if (type == "BOOL")
                {
                    al = new ArrayList();
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = "=";
                    obj.Name = "等于";
                    obj.Memo = "dy";
                    al.Add(obj);
                }
                else if (type == "DATETIME")
                {
                    al.RemoveAt(3);//去掉包含
                }

                else//字符串
                {
                    //					al = new ArrayList();
                    //					Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    //					obj.ID = "=";
                    //					obj.Name = "等于";
                    //					obj.Memo = "dy";
                    //					al.Add(obj);
                    //
                    //					obj = new Neusoft.FrameWork.Models.NeuObject();
                    //					obj.ID = "like";
                    //					obj.Name = "包含";
                    //					obj.Memo = "bh";
                    //					al.Add(obj);
                    //
                    //					obj = new Neusoft.FrameWork.Models.NeuObject();
                    //					obj.ID = "<>";
                    //					obj.Name = "不等于";
                    //					obj.Memo = "bdy";
                    //					al.Add(obj);
                }
                combox.AddItems(al);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //判断下拉列表里的选项
            if (combox.Items.Count > 0)
            {
                combox.SelectedIndex = 0;
            }
            this.panel1.Controls.Add(combox);
        }
        Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
        Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();

        /// <summary>
        /// 根据输入的类型，显示不同的输入控件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="defaultValue"></param>
        protected void insertValueBox(string type, string defaultValue)
        {
            //Neusoft.FrameWork.WinForms.Controls.NeuComboBox combox = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            Control combox = null;
            if (type == "INT")
            {
                combox = new Neusoft.FrameWork.WinForms.Controls.ValidatedTextBox1();
                ((Neusoft.FrameWork.WinForms.Controls.ValidatedTextBox1)combox).TextFormatType = (Neusoft.FrameWork.WinForms.Controls.ValidatedTextBox1.TextFormatTypes)1;
            }
            else if (type == "BOOL")
            {
                combox = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
                ArrayList al = new ArrayList();
                Neusoft.FrameWork.Models.NeuObject objtrue = new Neusoft.FrameWork.Models.NeuObject();
                objtrue.ID = "1";
                objtrue.Name = "是";
                objtrue.Memo = "true";
                al.Add(objtrue);

                Neusoft.FrameWork.Models.NeuObject objfalse = new Neusoft.FrameWork.Models.NeuObject();
                objfalse.ID = "0";
                objfalse.Name = "否";
                objfalse.Memo = "false";
                al.Add(objfalse);
                ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)combox).AddItems(al);
            }
            else if (type == "DATETIME")
            {
                combox = new DateTimePicker();
                ((DateTimePicker)combox).CustomFormat = "yyyy-MM-dd HH:mm";
                ((DateTimePicker)combox).Format = DateTimePickerFormat.Custom;
            }
            else if (type == "DEPARTMENT")//科室
            {
                combox = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
                ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)combox).AddItems(deptManager.GetDeptmentAll());
            }
            else if (type == "SEX")//性别
            {
                combox = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
                ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)combox).AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());
            }
            else if (type == "MARI")//婚姻状况
            {
                combox = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
                ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)combox).AddItems(Neusoft.HISFC.Models.RADT.MaritalStatusEnumService.List());
            }
            else if (type == "OPERATOR")//人员
            {
                combox = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
                ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)combox).AddItems(personManager.GetEmployeeAll());
            }
            else if (type == "STRING")//字符串
            {
                combox = new TextBox();
            }
            else//其它用户定义
            {
                combox = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
                ArrayList alList = new ArrayList();
                string[] s = type.Split(',');
                try
                {
                    for (int iList = 0; iList < s.Length; iList++)
                    {
                        Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                        obj.ID = s[iList].Split(' ')[0];
                        obj.Name = s[iList].Split(' ')[1];
                        alList.Add(obj);
                    }
                }
                catch { }
                ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)combox).AddItems(alList);
            }

            if (this.myDirection == enuDirection.H)
            {
                combox.Location = new Point(iBlankWidth * 3 + 50 + iConditionWidth, iCurrentRow * 21 + (iCurrentRow + 1) * iRowBlank);
            }
            else
            {
                combox.Location = new Point(iBlankWidth + 10, iRowBlank * 2 + iCurrentRow * 21 + (iCurrentRow + 1) * (iRowBlank * 3));
                combox.ForeColor = Color.Red;
            }
            try
            {
                //((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)combox).IsShowCustomerList = true;
            }
            catch { }
            combox.TabIndex = iCurrentRow * 10 + 3;
            combox.Width = this.ValueWidth;
            //combox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right |System.Windows.Forms.AnchorStyles.Left )));
            combox.KeyPress += new KeyPressEventHandler(combox_KeyPress);

            combox.Visible = true;
            combox.Name = "value" + iCurrentRow.ToString().PadLeft(2, '0');

            this.panel1.Controls.Add(combox);
        }
        /// <summary>
        /// 关系  大于 等于 不等于
        /// </summary>
        protected void insertRelationBox()
        {
            if (this.alRelations == null) this.initRelations();
            Neusoft.FrameWork.WinForms.Controls.NeuComboBox combox = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            combox.Width = 50;
            //combox.Location = new Point(this.ButtonOK.Left - iBlankWidth -50,iCurrentRow * 21+(iCurrentRow+1)*iRowBlank +10);
            //combox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            if (this.myDirection == enuDirection.H)
            {
                combox.Location = new Point(iBlankWidth * 4 + 50 + this.iConditionWidth + this.iValueWidth, iCurrentRow * 21 + (iCurrentRow + 1) * iRowBlank);
            }
            else
            {
                combox.Location = new Point(iBlankWidth * 2 + 10 + this.iValueWidth, iRowBlank * 2 + iCurrentRow * 21 + (iCurrentRow + 1) * (iRowBlank * 3));
            }
            //combox.IsShowCustomerList = true;
            combox.Visible = true;
            combox.TabIndex = iCurrentRow * 10 + 4;
            combox.Name = "relation" + iCurrentRow.ToString().PadLeft(2, '0');
            combox.AddItems(this.alRelations);
            combox.SelectedIndex = 0;
            combox.IsListOnly = true;
            combox.SelectedIndexChanged += new EventHandler(comboxRelation_SelectedIndexChanged);
            combox.KeyPress += new KeyPressEventHandler(combox_KeyPress);

            this.panel1.Controls.Add(combox);
        }

        #endregion

        #region 变化
        /// <summary>
        /// 查询条件 住院号 姓名性别等变化时引发的事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void combox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)sender).SelectedItem.Memo;
            //如果类型为空 则 默认为 字符串  
            if (type == "") type = "STRING";
            type = type.ToUpper();
            //获取当前的行 
            this.iCurrentRow = this.getControlRow(sender);
            //删除当前行
            this.ClearRow(iCurrentRow, 0);
            //插入新的操作符 选择框 
            this.insertOperationBox(type);
            //插入新的值选择框 
            this.insertValueBox(type, "");

        }
        /// <summary>
        /// 当关系运算    无，和，或 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void comboxRelation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)sender).Tag.ToString().Trim() == "")
            {
                //当运算符为 “无” 的时候 删除当前行以下的所有行
                for (int i = this.getControlRow(sender) + 1; i < 20; i++)
                {
                    this.ClearRow(i);
                }
            }
            else
            {
                this.AddNewRow(this.getControlRow(sender) + 1);
                //System.Windows.Forms.SendKeys.Send("{tab}");
            }
        }
        /// <summary>
        /// 获得控件所在行
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        protected int getControlRow(object sender)
        {
            return Neusoft.FrameWork.Function.NConvert.ToInt32(((Control)sender).Name.Substring(((Control)sender).Name.Length - 2));
        }

        protected void btnExit_Click(object sender, System.EventArgs e)
        {
            try
            {
                CancelEvent(sender, null);
            }
            catch
            {
                //如果没有找到代理事件，关闭当前窗口
                this.FindForm().Close();
            }
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        /// <returns></returns>
        public string GetWhereString()
        {
            string strWhere = " ";
            for (int i = 0; i < 20; i++)
            {
                string sCondition = "", sOperation = "", sValue = "", sRelation = "";
                string sType = "";
                for (int j = 0; j < 4; j++)
                {
                    Control c = this.getControl(j, i) as Control;
                    if (c == null)
                    {
                        this.SaveCondtion();
                        return strWhere;
                    }

                    switch (j)
                    {
                        case 0:
                            sType = ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)c).SelectedItem.Memo;
                            sCondition = ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)c).SelectedItem.ID;
                            break;
                        case 1:
                            sOperation = ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)c).SelectedItem.ID;
                            break;
                        case 2:
                            try
                            {
                                if (c.GetType() == typeof(DateTimePicker))
                                {
                                    sValue = ((DateTimePicker)c).Value.ToString();
                                }
                                else if (c.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuComboBox)) //&&(sType =="MARI" ||sType =="SEX"))
                                {
                                    sValue = ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)c).SelectedItem.ID;
                                }
                                else
                                {
                                    sValue = c.Text;
                                }
                            }
                            catch { }
                            break;
                        case 3:
                            try
                            {
                                sRelation = ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)c).SelectedItem.ID;
                            }
                            catch { }
                            break;
                        default:
                            break;
                    }
                }
                string stemp = "";
                //获得条件
                if (sType == "INT")
                {
                    if (sValue.Trim() == "") sValue = "0";
                    stemp = " {0} {1} {2} {3}";
                }
                else if (sType == "BOOL")
                {
                    stemp = " {0} {1} '{2}' {3}";
                }
                else if (sType == "DATETIME")
                {
                    stemp = " {0} {1} to_date('{2}','yyyy-mm-dd HH24:mi:ss') {3}";
                }
                else//字符串
                {
                    stemp = " {0} {1} '{2}' {3}";
                }
                if (sOperation.ToUpper() == "LIKE")
                {
                    if (sValue.Trim() == "")
                        sValue = "%";
                    else
                        sValue = "%" + sValue + "%";
                }

                Neusoft.FrameWork.Public.String.FormatString(stemp, out stemp, sCondition, sOperation, sValue, sRelation);
                strWhere += stemp;
            }
            this.SaveCondtion();
            return strWhere;
        }
        /// <summary>
        /// 获得控件
        /// </summary>
        /// <param name="iType"></param>
        /// <param name="iRow"></param>
        /// <returns></returns>
        protected object getControl(int iType, int iRow)
        {
            for (int i = this.panel1.Controls.Count - 1; i >= 0; i--)
            {
                Control c = this.panel1.Controls[i];
                try
                {
                    string s = "condi";
                    if (iType == 1)
                    {
                        s = "opera";
                    }
                    else if (iType == 2)
                    {
                        s = "value";
                    }
                    else if (iType == 3)
                    {
                        s = "relat";
                    }
                    else
                    {
                        s = "condi";
                    }
                    if (c.Name.Substring(0, 5) == s && Neusoft.FrameWork.Function.NConvert.ToInt32(c.Name.Substring(c.Name.Length - 2)) == iRow)
                    {
                        return c;
                    }

                }
                catch
                {
                }
            }
            return null;
        }

        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.OKEvent(this.GetWhereString(), null);
            }
            catch { }
        }

        public void btnReset_Click(object sender, System.EventArgs e)
        {
            this.RefreshList();
        }
        #endregion

        private void combox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{tab}");
                e.Handled = true;
            }
        }

        #region 操作保存条件
        /// <summary>
        /// 读取条件
        /// </summary>
        public void ReadCondition()
        {

            string s = "";
            if (this.FindForm() == null) return;
            try
            {
                s = this.managerCondition.GetQueryCondtion(this.FindForm().Name);
            }
            catch { return; }
            if (s == "-1")
            {
                MessageBox.Show(this.managerCondition.Err);
                return;
            }
            if (s == "")
                s = this.managerCondition.GetQueryCondtion(this.FindForm().Name, true);

            if (s == "") return;

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            XmlNodeList nodes = doc.SelectNodes("setting/row");

            this.ResetText();
            int iRow = 0;
            foreach (XmlNode node in nodes)
            {
                try
                {
                    ((Control)this.getControl(0, iRow)).Text = node.ChildNodes[0].InnerText;
                    ((Control)this.getControl(1, iRow)).Text = node.ChildNodes[1].InnerText;
                    ((Control)this.getControl(2, iRow)).Text = node.ChildNodes[2].InnerText;
                    ((Control)this.getControl(3, iRow)).Text = node.ChildNodes[3].InnerText;
                }
                catch { }
                iRow++;
            }

        }
        /// <summary>
        /// 保存条件
        /// </summary>
        public void SaveCondtion()
        {
            string s = this._SaveCondition();
            if (this.managerCondition.SetQueryCondition(this.FindForm().Name, s) == -1)
            {
                MessageBox.Show(managerCondition.Err);
            }
        }

        protected string _SaveCondition()
        {
            Neusoft.FrameWork.Xml.XML myXml = new Neusoft.FrameWork.Xml.XML();
            XmlDocument doc = new XmlDocument();
            XmlElement eRoot = myXml.CreateRootElement(doc, "setting");
            for (int i = 0; i < 20; i++)
            {
                XmlElement eRow = null;
                eRow = myXml.AddXmlNode(doc, eRoot, "row", "");
                for (int j = 0; j < 4; j++)
                {
                    Control c = this.getControl(j, i) as Control;
                    if (c == null) break;
                    myXml.AddXmlNode(doc, eRow, "column", c.Text);
                }
            }
            return doc.OuterXml;
        }
        /// <summary>
        /// 保存默认条件
        /// </summary>
        public void SaveDefaultCondition()
        {
            string s = this._SaveCondition();
            if (this.managerCondition.SetQueryCondition(this.FindForm().Name, s, true) == -1)
            {
                MessageBox.Show(managerCondition.Err);
            }
            else
            {
                MessageBox.Show("条件模板保存成功！");
            }
        }

        private void btnDefault_Click(object sender, System.EventArgs e)
        {
            string s = this.managerCondition.GetQueryCondtion(this.FindForm().Name, true);

            if (s == "") return;

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            XmlNodeList nodes = doc.SelectNodes("setting/row");

            this.ResetText();
            int iRow = 0;
            foreach (XmlNode node in nodes)
            {
                try
                {
                    ((Control)this.getControl(0, iRow)).Text = node.ChildNodes[0].InnerText;
                    ((Control)this.getControl(1, iRow)).Text = node.ChildNodes[1].InnerText;
                    ((Control)this.getControl(2, iRow)).Text = node.ChildNodes[2].InnerText;
                    ((Control)this.getControl(3, iRow)).Text = node.ChildNodes[3].InnerText;
                }
                catch { }
                iRow++;
            }

        }
        #endregion

        #region 彩旦
        //private int iLoop = 0;
        private void panel1_DoubleClick(object sender, System.EventArgs e)
        {
            //if (iLoop > 10)
            //{
            this.SaveDefaultCondition();
            //}
            //iLoop++;
        }
        #endregion
    }
    /// <summary>
    /// 方向
    /// </summary>
    public enum enuDirection
    {
        /// <summary>
        /// 横
        /// </summary>
        H = 0,
        /// <summary>
        /// 立
        /// </summary>
        V = 1
    }
}
