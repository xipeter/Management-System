using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FarPoint.Win.Spread;

namespace Neusoft.UFC.Material.Base
{
    /// <summary>		
    /// ucMatKind的摘要说明。
    /// [功能描述: 物资科目维护]
    /// [创 建 者: 李超]
    /// [创建时间: 2007-03-28]
    /// </summary>
    public partial class ucMatKind : UserControl
    {
        public ucMatKind()
        {
            InitializeComponent();
        }

        #region 变量

        private DataView myDataView;

        private DataSet myDataSet = new DataSet();

        private string filePath = "\\MatKind.xml";

        private string myType = "";

        /// <summary>
        /// 物资科目类
        /// </summary>
        private Neusoft.HISFC.Management.Material.Baseset baseset = new Neusoft.HISFC.Management.Material.Baseset();

        private string kindLevel;

        /// <summary>
        /// 上级科目编码
        /// </summary>
        private string kindPreID;

        /// <summary>
        /// 编辑状态
        /// </summary>
        private string state;

        #endregion

        #region 属性

        /// <summary>
        /// 科目级别
        /// </summary>
        public string KindLevel
        {
            get
            {
                return this.kindLevel;
            }
            set
            {
                this.kindLevel = value;
            }
        }

        /// <summary>
        /// 上级科目编码
        /// </summary>
        public string KindPreID
        {
            get
            {
                return this.kindPreID;
            }
            set
            {
                this.kindPreID = value;
            }
        }

        /// <summary>
        /// 编辑状态
        /// </summary>
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }


        #endregion

        #region 方法

        /// <summary>
        /// 将传入数组中的数据显示在fpKind_Sheet1中
        /// </summary>
        public void ShowData(string type)
        {
            //初始化DataSet
            this.InitDataSet();
            //清空数据
            //			this.myDataSet.Tables[0].Rows.Clear();

            //取科目信息
            ArrayList alObject = this.baseset.QueryKindAll();

            if (alObject == null)
            {
                MessageBox.Show(this.baseset.Err);
                return;
            }

            Neusoft.HISFC.Object.Material.MaterialKind metKind;

            for (int i = 0; i < alObject.Count; i++)
            {
                metKind = alObject[i] as Neusoft.HISFC.Object.Material.MaterialKind;
                this.myDataSet.Tables[0].Rows.Add(new Object[] {																	
																		//科目级别
																		metKind.Kgrade,
				
																		//科目编码
																		metKind.ID,

																		//上级编码
																		metKind.SuperKind,

																		//科目名称
																		metKind.Name,

																		//拼音码
																		metKind.SpellCode.ToString(),

																		//五笔码
																		metKind.WBCode,

																		//最末级标识
																		metKind.EndGrade,

																		//需要卡片
																		metKind.IsCardNeed,//.ToString(),

																		//批次管理
																		metKind.IsBatch,//.ToString(),

																		//有效期管理
																		metKind.IsValidcon,//.ToString(),

																		//财务科目编码
																		metKind.AccountCode.ToString(),

																		//财务科目名称
																		metKind.AccountName.ToString(),

																		//操作员
																		//metKind.Oper.ID,

																		//操作日期
																		//metKind.OperateDate.ToString(),

																		//预计残值率
																		metKind.LeftRate.ToString(),

																		//是否固定资产
																		metKind.IsFixedAssets,//.ToString(),

																		//排列序号
																		metKind.OrderNo.ToString(),																		

																		//对应成本核算项目类别
																		metKind.StatCode,

																		//是否加价卫材
																		metKind.IsAddFlag//.ToString()
																	});
            }

            //提交DataSet中的变化。
            this.myDataSet.Tables[0].AcceptChanges();
            this.fpKind_Sheet1.Columns[0].Visible = false;
            this.fpKind_Sheet1.Columns[2].Visible = false;

        }


        /// <summary>
        ///  初始化DataSet,并与fpKind_Sheet1绑定
        /// </summary>
        private void InitDataSet()
        {
            this.myDataSet.Tables.Clear();
            this.myDataSet.Tables.Add();
            this.myDataView = new DataView(this.myDataSet.Tables[0]);
            this.myDataView.AllowEdit = true;
            this.myDataView.AllowNew = true;
            this.fpKind.DataSource = this.myDataView;


            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBool = System.Type.GetType("System.Boolean");

            //在myDataTable中添加列
            this.myDataSet.Tables[0].Columns.AddRange(new DataColumn[] {
																			new DataColumn("科目级别",   dtStr),
																			new DataColumn("科目编码",   dtStr),
																			new DataColumn("上级编码",   dtStr),
																			new DataColumn("科目名称",   dtStr),
																			new DataColumn("拼音码",   dtStr),
																			new DataColumn("五笔码",     dtStr),
																			new DataColumn("末级标识",   dtBool),
																			new DataColumn("需要卡片",   dtBool),
																			new DataColumn("批次管理",   dtBool),
																			new DataColumn("效期管理",   dtBool),
																			new DataColumn("财务科目编码",   dtStr),
																			new DataColumn("财务科目名称",   dtStr),																			
																			new DataColumn("预计残值率",    dtStr),
																			new DataColumn("固定资产",    dtBool),
																			new DataColumn("排列序号",    dtStr),																			
																			new DataColumn("核算类别",     dtStr),
																			new DataColumn("加价卫材",   dtBool)																			
																		});


        }


        /// <summary>
        /// 清空数据
        /// </summary>
        public void ClearData()
        {
            this.fpKind_Sheet1.Rows.Count = 0;
        }


        /// <summary>
        /// 删除记录
        /// </summary>
        public void DeleteData()
        {
            string kindID = "";

            kindID = this.fpKind_Sheet1.Cells[this.fpKind_Sheet1.ActiveRowIndex, 1].Value.ToString();

            int kindRowCount = this.baseset.GetKindRowCount(kindID);

            if (kindRowCount > 0)
            {
                MessageBox.Show("此科目下存在物品字典信息，请先删除字典信息再执行此操作!", "删除提示");
                return;
            }

            if(kindRowCount < 0)
            {
                MessageBox.Show("获取该科目下项目字典总条数出错");
                return;
            }

            System.Windows.Forms.DialogResult dr;
            dr = MessageBox.Show("确定要删除此科目吗?", "提示!", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            Neusoft.NFC.Management.PublicTrans.BeginTransaction();

            //Neusoft.NFC.Management.Transaction t = new Neusoft.NFC.Management.Transaction(Neusoft.NFC.Management.Connection.Instance);
            //t.BeginTransaction();

            baseset.SetTrans(Neusoft.NFC.Management.PublicTrans.Trans);

            if (this.baseset.DeleteMetKind(kindID) == -1)
            {
                Neusoft.NFC.Management.PublicTrans.RollBack();
                MessageBox.Show(this.baseset.Err);
                return;
            }

            Neusoft.NFC.Management.PublicTrans.Commit();

            this.fpKind_Sheet1.Rows.Remove(this.fpKind_Sheet1.ActiveRowIndex, 1);

            MessageBox.Show("删除成功！");

        }


        /// <summary>
        /// 通过输入的查询码，过滤数据列表
        /// </summary>
        public void ChangeItem(string treeFilter)
        {
            if (this.myDataSet.Tables[0].Rows.Count == 0) return;

            try
            {
                string queryCode = "";

                queryCode = "%" + this.txtQueryCode.Text.Trim() + "%";

                string filter = "(拼音码 LIKE '" + queryCode + "') OR " +
                    "(五笔码 LIKE '" + queryCode + "') OR " +
                    "(科目名称 LIKE '" + queryCode + "') ";

                //设置过滤条件
                if (treeFilter == "0")
                {
                    this.myDataView.RowFilter = filter;
                }
                else
                {
                    this.myDataView.RowFilter = "((上级编码 = '" + treeFilter + "')or" + "(科目编码='" + treeFilter + "'))and (" + filter + ")";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        public int Save()
        {
            this.fpKind.StopCellEditing();
            //有效性判断
            if (valid())
            {
                return -1;
            };

            //定义数据库处理事务
            Neusoft.NFC.Management.PublicTrans.BeginTransaction();

            //Neusoft.NFC.Management.Transaction t = new Neusoft.NFC.Management.Transaction(Neusoft.NFC.Management.Connection.Instance);
            //t.BeginTransaction();

            baseset.SetTrans(Neusoft.NFC.Management.PublicTrans.Trans);
            bool isUpdate = false; //判断是否更新或者删除过数据

            //取修改和增加的数据
            DataSet dataChanges = this.myDataSet.GetChanges(DataRowState.Modified | DataRowState.Added);
            if (dataChanges != null)
            {
                foreach (DataRow row in dataChanges.Tables[0].Rows)
                {
                    Neusoft.HISFC.Object.Material.MaterialKind metKind = new Neusoft.HISFC.Object.Material.MaterialKind();
                    //科目级别
                    metKind.Kgrade = row["科目级别"].ToString();

                    //科目编码
                    metKind.ID = row["科目编码"].ToString();

                    //上级编码
                    metKind.SuperKind = row["上级编码"].ToString();

                    //科目名称
                    metKind.Name = row["科目名称"].ToString();

                    //拼音码
                    metKind.SpellCode = row["拼音码"].ToString();

                    //五笔码
                    metKind.WBCode = row["五笔码"].ToString();

                    //最末级标识
                    metKind.EndGrade = Neusoft.NFC.Function.NConvert.ToBoolean(row["末级标识"].ToString());

                    //需要卡片
                    metKind.IsCardNeed = Neusoft.NFC.Function.NConvert.ToBoolean(row["需要卡片"].ToString());

                    //批次管理
                    metKind.IsBatch = Neusoft.NFC.Function.NConvert.ToBoolean(row["批次管理"].ToString());

                    //有效期管理
                    metKind.IsValidcon = Neusoft.NFC.Function.NConvert.ToBoolean(row["效期管理"].ToString());

                    //财务科目编码
                    metKind.AccountCode.ID = row["财务科目编码"].ToString();

                    //财务科目名称
                    metKind.AccountName.Name = row["财务科目名称"].ToString();

                    //					//操作员
                    //					metKind.Oper.ID = row[10].ToString();
                    //
                    //					//操作日期
                    //					metKind.OperateDate = Convert.ToDateTime(row[11].ToString());

                    //预计残值率
                    metKind.LeftRate = Neusoft.NFC.Function.NConvert.ToDecimal(row["预计残值率"].ToString());

                    //是否固定资产
                    metKind.IsFixedAssets = Neusoft.NFC.Function.NConvert.ToBoolean(row["固定资产"].ToString());

                    //排列序号
                    metKind.OrderNo = Neusoft.NFC.Function.NConvert.ToInt32(row["排列序号"].ToString());

                    //对应成本核算项目类别
                    metKind.StatCode = row["核算类别"].ToString();

                    //是否加价卫材
                    metKind.IsAddFlag = Neusoft.NFC.Function.NConvert.ToBoolean(row["加价卫材"].ToString());

                    //执行更新操作，先更新，如果没有成功则插入新数据
                    if (this.baseset.SetKind(metKind) == -1)
                    {
                        Neusoft.NFC.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.baseset.Err);

                        return 0;
                    }
                }
                dataChanges.AcceptChanges();
                isUpdate = true;
            }

            //取删除的数据
            //			dataChanges = this.myDataSet.GetChanges(DataRowState.Deleted);
            //			if(dataChanges != null)	 
            //			{
            //				dataChanges.RejectChanges();
            //				foreach(DataRow row in dataChanges.Tables[0].Rows) 
            //				{ 
            //					string metKindID   = row[0].ToString();        		
            //					//执行删除操作
            //					if (this.baseset.DeleteMetKind(metKindID)==-1) 
            //					{
            //						Neusoft.NFC.Management.PublicTrans.RollBack();
            //						MessageBox.Show(this.baseset.Err );
            //						return 0;
            //					}
            //				}
            //				dataChanges.AcceptChanges();
            //				isUpdate = true;
            //			}
            Neusoft.NFC.Management.PublicTrans.Commit();

            //刷新数据
            this.ShowData(this.myType);

            if (isUpdate) MessageBox.Show("保存成功！");
            return 1;
        }

        public void New()
        {
            try
            {
                string kindID = this.baseset.GetMaxKindID(this.KindPreID);

                ArrayList al = new ArrayList();

                if (this.KindPreID == "0")
                {
                    this.myDataSet.Tables[0].Rows.Add(new Object[] { "1", kindID.ToString(), "0", "", "", "", 1, 1, 1, 1, "", "", "", 1, "", "", 1 });
                }
                else
                {
                    al = this.baseset.QueryKindAllByID(this.KindPreID);
                    Neusoft.HISFC.Object.Material.MaterialKind metKind;
                    metKind = al[0] as Neusoft.HISFC.Object.Material.MaterialKind;
                    this.myDataSet.Tables[0].Rows.Add(new Object[] { (Convert.ToInt32(metKind.Kgrade) + 1).ToString(), kindID.ToString(), metKind.ID.ToString(), "", "", "", 1, 1, 1, 1, "", "", "", 1, "", "", 1 });
                }

                this.fpKind_Sheet1.ActiveRowIndex = this.fpKind_Sheet1.RowCount - 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        /// <summary>
        ///  有效性判断 
        /// </summary>	
        private bool valid()
        {
            for (int i = 0; i < this.fpKind_Sheet1.RowCount; i++)
            {

                if (this.fpKind_Sheet1.Cells[i, 1].Text == "" || this.fpKind_Sheet1.Cells[i, 1] == null)
                {
                    MessageBox.Show("第" + i.ToString() + "行科目名称不能为空");
                    return true;
                }

            }
            return false;
        }


        #endregion

        #region 事件

        private void ucMatKind_Load(object sender, System.EventArgs e)
        {
            this.txtQueryCode.TextChanged += new EventHandler(txtQueryCode_TextChanged);
            this.txtQueryCode.KeyUp += new KeyEventHandler(txtQueryCode_KeyUp);
            //			this.InitDataSet();
            this.ShowData(this.myType);

            InputMap im;

            im = this.fpKind.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }


        private void txtQueryCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                Neusoft.NFC.Interface.Classes.CustomerFp.SaveColumnProperty(this.fpKind_Sheet1, this.filePath);

        }


        private void txtQueryCode_TextChanged(object sender, EventArgs e)
        {
            this.ChangeItem("0");
        }


        private void fpKind_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            if (e.Column == 3)
            {
                if (fpKind_Sheet1.Cells[e.Row, 3].Text.ToString() == "")
                    return;
                Neusoft.HISFC.Object.Base.Spell spCode = new Neusoft.HISFC.Object.Base.Spell();
                Neusoft.HISFC.Management.Manager.Spell mySpell = new Neusoft.HISFC.Management.Manager.Spell();

                spCode = (Neusoft.HISFC.Object.Base.Spell)mySpell.Get(fpKind_Sheet1.Cells[e.Row, 3].Text.ToString());

                if (spCode.SpellCode.Length > 10)
                    spCode.SpellCode = spCode.SpellCode.Substring(0, 10);
                if (spCode.WBCode.Length > 10)
                    spCode.WBCode = spCode.WBCode.Substring(0, 10);

                this.fpKind_Sheet1.Cells[e.Row, 4].Value = spCode.SpellCode;
                this.fpKind_Sheet1.Cells[e.Row, 5].Value = spCode.WBCode;
            }
        }


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.fpKind.ContainsFocus)
            {
                if (keyData == Keys.Enter)
                {
                    if (this.fpKind_Sheet1.ActiveColumnIndex == 3)
                    {
                        Neusoft.HISFC.Object.Base.Spell spCode = new Neusoft.HISFC.Object.Base.Spell();
                        Neusoft.HISFC.Management.Manager.Spell mySpell = new Neusoft.HISFC.Management.Manager.Spell();

                        spCode = (Neusoft.HISFC.Object.Base.Spell)mySpell.Get(fpKind_Sheet1.Cells[this.fpKind_Sheet1.ActiveRowIndex, 3].Text.ToString());

                        if (spCode.SpellCode.Length > 10)
                            spCode.SpellCode = spCode.SpellCode.Substring(0, 10);
                        if (spCode.WBCode.Length > 10)
                            spCode.WBCode = spCode.WBCode.Substring(0, 10);

                        this.fpKind_Sheet1.Cells[this.fpKind_Sheet1.ActiveRowIndex, 4].Value = spCode.SpellCode;
                        this.fpKind_Sheet1.Cells[this.fpKind_Sheet1.ActiveRowIndex, 5].Value = spCode.WBCode;
                    }

                    this.fpKind_Sheet1.ActiveColumnIndex++;
                }

            }
            return base.ProcessDialogKey(keyData);
        }


        #endregion	
        
        #region IConstManager 成员
        /*
        public int Add()
        {
            // TODO:  添加 ucCompanyManager.Add 实现
            this.myDataView.AddNew();
            this.fpKind_Sheet1.ActiveRowIndex = this.fpKind_Sheet1.RowCount - 1;
            return 0;
        }

        public int Del()
        {
            // TODO:  添加 ucCompanyManager.Del 实现
            this.DeleteData();
            return 0;
        }

        public int Retrieve()
        {
            // TODO:  添加 ucCompanyManager.Retrieve 实现
            return 0;
        }

        public int Retrieve(string typeCode)
        {
            // TODO:  添加 ucCompanyManager.Pharmacy.IConstManager.Retrieve 实现
            if (typeCode == null) return 0;
            this.myType = typeCode;

            this.ShowData(typeCode);
            return 0;
        }

        public int Pre()
        {
            // TODO:  添加 ucCompanyManager.Pre 实现
            return 0;
        }

        public int Next()
        {
            // TODO:  添加 ucCompanyManager.Next 实现
            return 0;
        }

        public int Search()
        {
            // TODO:  添加 ucCompanyManager.Search 实现
            return 0;
        }

        public int Print()
        {
            // TODO:  添加 ucCompanyManager.Print 实现
            return 0;
        }

        public int Help()
        {
            // TODO:  添加 ucCompanyManager.Help 实现
            return 0;
        }

        public int Exit()
        {
            // TODO:  添加 ucCompanyManager.Exit 实现
            return 0;
        }

        public ToolBarButton AddButton
        {
            get
            {
                // TODO:  添加 ucCompanyManager.AddButton getter 实现
                return null;
            }
        }

        public ToolBarButton DelButton
        {
            get
            {
                // TODO:  添加 ucCompanyManager.DelButton getter 实现
                return null;
            }
        }

        public ToolBarButton SaveButton
        {
            get
            {
                // TODO:  添加 ucCompanyManager.SaveButton getter 实现
                return null;
            }
        }

        public ToolBarButton RetrieveButton
        {
            get
            {
                // TODO:  添加 ucCompanyManager.RetrieveButton getter 实现
                return null;
            }
        }

        public ToolBarButton SearchButton
        {
            get
            {
                // TODO:  添加 ucCompanyManager.SearchButton getter 实现
                return null;
            }
        }

        public ToolBarButton AuditingButton
        {
            get
            {
                // TODO:  添加 ucCompanyManager.AuditingButton getter 实现
                return null;
            }
        }

        public ToolBarButton PreButton
        {
            get
            {
                // TODO:  添加 ucCompanyManager.PreButton getter 实现
                return null;
            }
        }

        public ToolBarButton NextButton
        {
            get
            {
                // TODO:  添加 ucCompanyManager.NextButton getter 实现
                return null;
            }
        }

        public ToolBarButton PrintButton
        {
            get
            {
                // TODO:  添加 ucCompanyManager.PrintButton getter 实现
                return null;
            }
        }
        */
        #endregion
    }
}
