using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FarPoint.Win.Spread;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.WinForms.Forms;

namespace Neusoft.HISFC.Components.Material.Base
{
    /// <summary>		
    /// ucMatStorage的摘要说明
    /// [功能描述: 物资仓库维护]
    /// [创 建 者: 李超]
    /// [创建时间: 2007-03-28]
    /// 
    /// [修 改 人:王维]
    ///	 [修改时间:2007-11-27]
    ///	 [修改目的:增加新的业务]
    ///	 [修改描述:实体类字段变更]
    /// </summary>
    public partial class ucMatStorage : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucMatStorage()
        {
            InitializeComponent();
        }

        #region 管理类

        /// <summary>
        /// 科室列表类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();

        /// <summary>
        /// 物资科目类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Baseset basesetManager = new Neusoft.HISFC.BizLogic.Material.Baseset();

        /// <summary>
        /// 替换科室名称
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        #endregion

        #region 变量

        private DataView dv;

        private DataTable dt;

        private ArrayList alDept;

        /// <summary>
        /// 已维护的科室库存列表
        /// </summary>
        private System.Collections.Hashtable hsphaDept = new Hashtable();
        #endregion

        #region 方法

        #region 数据初始化

        /// <summary>
        /// 设置显示格式
        /// </summary>
        private void SetCellType()
        {
            this.fpStorage_Sheet1.Columns[0].Locked = true;

            this.fpStorage_Sheet1.Columns[14].Visible = false;
            this.fpStorage_Sheet1.Columns[15].Visible = false;

            this.fpStorage_Sheet1.Columns[0].Width = 80F;
            this.fpStorage_Sheet1.Columns[1].Width = 80F;
            this.fpStorage_Sheet1.Columns[2].Width = 80F;
            this.fpStorage_Sheet1.Columns[3].Width = 80F;
            this.fpStorage_Sheet1.Columns[4].Width = 80F;
            this.fpStorage_Sheet1.Columns[5].Width = 80F;
            this.fpStorage_Sheet1.Columns[6].Width = 80F;
            this.fpStorage_Sheet1.Columns[7].Width = 80F;
            this.fpStorage_Sheet1.Columns[8].Width = 80F;
            this.fpStorage_Sheet1.Columns[9].Width = 80F;
            this.fpStorage_Sheet1.Columns[10].Width = 80F;
            this.fpStorage_Sheet1.Columns[11].Width = 80F;
            this.fpStorage_Sheet1.Columns[12].Width = 80F;
            this.fpStorage_Sheet1.Columns[13].Width = 80F;
            this.fpStorage_Sheet1.Columns[14].Width = 80F;
            this.fpStorage_Sheet1.Columns[15].Width = 80F;
        }

        protected void AddDataToTable(ArrayList alData, bool isAddKey)
        {
            //物资仓库实例
            Neusoft.HISFC.Models.Material.MaterialStorage storage;

            for (int i = 0; i < alData.Count; i++)
            {
                storage = alData[i] as Neusoft.HISFC.Models.Material.MaterialStorage;

                if (storage.Name == null)
                {
                    storage.Name = deptHelper.GetName(storage.ID);
                }
                if (isAddKey)
                {
                    this.hsphaDept.Add(storage.ID, null);
                }

                this.dt.Rows.Add(new Object[] {		
					                                                storage.ID,	                                  //0仓库编码				
																	storage.Name,                             //1仓库名称 
																	storage.SpellCode,                       //2拼音码
																	storage.WBCode,                         //3五笔码																	 
																	storage.OutStartNO,                     //4出库单起始号
																	storage.InStartNO,                       //5入库单起始号																	
																	storage.PlanStartNO,                    //6申请单起始号
																	storage.IsWithFix,                        //7有无固定资产
																	storage.IsStorage,                       //8是否是仓库
																	storage.IsStoreManage,               //9是否管理库存
																	storage.IsBatchManage,               //10是否管理批次
																	storage.MaxDays,
                                                                    storage.MinDays,
                                                                    storage.ReferenceDays,
                                                                    storage.Oper.ID,                          //14操作员
                                                                    storage.Oper.OperTime                //15操作日期
                                                              });
            }
        }

        /// <summary>
        /// 将传入数组中的数据显示在fpStorage_Sheet1中
        /// </summary>
        public void ShowData()
        {
            //清空farpoint中的数据
            this.ClearData();

            //取物仓库信息
            ArrayList alObject = this.basesetManager.GetStorageInfo();
            if (alObject == null)
            {
                MessageBox.Show(this.basesetManager.Err);
                return;
            }

            this.hsphaDept.Clear();

            this.AddDataToTable(alObject, true);

            this.dt.AcceptChanges();
        }

        /// <summary>
        /// 科室结构信息显示
        /// </summary>
        public void ShowDeptStruct()
        {
            Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager deptStatManager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
            ArrayList alDeptStat = deptStatManager.LoadDepartmentStat("05");
            if (alDeptStat == null)
            {
                MessageBox.Show(Language.Msg("获取科室节点信息失败"));
                return;
            }

            ArrayList al = new ArrayList();

            foreach (Neusoft.HISFC.Models.Base.DepartmentStat deptStat in alDeptStat)
            {
                if (this.hsphaDept.ContainsKey(deptStat.DeptCode))
                {
                    continue;
                }

                if (deptStat.DeptCode.Substring(0, 1) == "S")
                {
                    continue;
                }

                Neusoft.HISFC.Models.Material.MaterialStorage storage = new Neusoft.HISFC.Models.Material.MaterialStorage();

                storage.ID = deptStat.DeptCode;
                storage.Name = this.deptHelper.GetName(deptStat.DeptCode);
                storage.Name = storage.Name;
                storage.ID = deptStat.DeptCode;
                storage.SpellCode = deptStat.SpellCode;
                storage.WBCode = deptStat.WBCode;

                al.Add(storage);
            }

            this.AddDataToTable(al, true);
        }

        /// <summary>
        ///  初始化DataSet,并与fpStorage_Sheet1绑定
        /// </summary>
        private void InitDataSet()
        {
            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtInt = System.Type.GetType("System.Int32");
            System.Type dtBool = System.Type.GetType("System.Boolean");
            System.Type dtDate = System.Type.GetType("System.DateTime");

            //设置CellType
            this.dt = new DataTable();

            //在myDataTable中添加列
            this.dt.Columns.AddRange(new DataColumn[] {
                                                                            new DataColumn("仓库编码",   dtStr),
																			new DataColumn("仓库名称",   dtStr),
																			new DataColumn("拼音码",   dtStr),
																			new DataColumn("五笔码",    dtStr),																			
																			new DataColumn("出库单起始号",   dtInt),
																			new DataColumn("入库单起始号",   dtInt),
																			new DataColumn("申请单起始号",    dtInt),
																			new DataColumn("有无固定资产",   dtBool),																			
																			new DataColumn("是否是仓库",   dtBool),
																			new DataColumn("是否管理库存",   dtBool),
																			new DataColumn("是否管理批次",   dtBool),
                                                                            new DataColumn("库存上限天数",  dtInt),
                                                                            new DataColumn("库存下限天数",  dtInt),
                                                                            new DataColumn("库存参考天数",  dtInt),
                                                                            new DataColumn("操作员",   dtStr),
                                                                            new DataColumn("操作日期",dtDate)						
																		});

            alDept = deptManager.GetDeptmentAllOrderByDeptType();
            this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDept);

            this.dv = new DataView(this.dt);
            this.fpStorage.DataSource = this.dv;

            this.SetCellType();
        }

        #endregion

        /// <summary>
        /// 清空数据
        /// </summary>
        public void ClearData()
        {
            this.dt.Rows.Clear();

            this.fpStorage_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 通过输入的查询码，过滤数据列表
        /// </summary>
        private void ChangeItem()
        {
            if (this.dt.Rows.Count == 0)
            {
                return;
            }

            try
            {
                string queryCode = "";
                queryCode = "%" + this.txtQueryCode.Text.Trim() + "%";

                string filter = "(拼音码 LIKE '" + queryCode + "') OR " +
                    "(五笔码 LIKE '" + queryCode + "') OR " +
                    "(仓库名称 LIKE '" + queryCode + "') ";

                //设置过滤条件
                this.dv.RowFilter = filter;
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
            this.fpStorage.StopCellEditing();
            //有效性判断
            if (Valid())
            {
                return -1;
            };

            //定义数据库处理事务

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            basesetManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            Neusoft.HISFC.Models.Material.MaterialStorage storage = null;
            foreach (DataRow row in this.dt.Rows)
            {
                storage = new Neusoft.HISFC.Models.Material.MaterialStorage();

                storage.ID = row["仓库编码"].ToString();                    //0编码
                storage.Name = row["仓库名称"].ToString();                  //1仓库名称
                storage.SpellCode = row["拼音码"].ToString();              //2拼音码
                storage.WBCode = row["五笔码"].ToString();                  //3五笔码
                storage.OutStartNO = Neusoft.FrameWork.Function.NConvert.ToInt32(row["出库单起始号"]);        //4出库单起始号
                storage.InStartNO = Neusoft.FrameWork.Function.NConvert.ToInt32(row["入库单起始号"]);         //5入库单起始号
                storage.PlanStartNO = Neusoft.FrameWork.Function.NConvert.ToInt32(row["申请单起始号"]);        //6申请单起始号
                storage.IsWithFix = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["有无固定资产"].ToString());      //7有无固定资产
                storage.IsStorage = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["是否是仓库"].ToString());         //8是否是仓库
                storage.IsStoreManage = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["是否管理库存"].ToString());   //9是否管理库存
                storage.IsBatchManage = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["是否管理批次"].ToString());   //10是否管理批次
                storage.MaxDays = Neusoft.FrameWork.Function.NConvert.ToInt32(row["库存上限天数"]);
                storage.MinDays = Neusoft.FrameWork.Function.NConvert.ToInt32(row["库存下限天数"]);
                storage.ReferenceDays = Neusoft.FrameWork.Function.NConvert.ToInt32(row["库存参考天数"]);
                storage.Oper.ID = row["操作员"].ToString();
                storage.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(row["操作日期"].ToString());

                //首先执行更新操作，如果没有成功则插入新数据
                if (this.basesetManager.SetStorage(storage) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.basesetManager.Err);
                    return 0;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            //刷新数据
            this.ShowData();

            MessageBox.Show("保存成功！");
            return 1;
        }

        /// <summary>
        ///  有效性判断 
        /// </summary>	
        private bool Valid()
        {
            for (int i = 0; i < this.fpStorage_Sheet1.RowCount; i++)
            {
                if (this.fpStorage_Sheet1.Cells[i, 1].Text == "" || this.fpStorage_Sheet1.Cells[i, 1] == null)
                {
                    MessageBox.Show("第" + (i+1).ToString() + "行名称不能为空");
                    return true;
                }

            }
            return false;
        }

        #endregion

        #region 事件
        private void ucMatStorage_Load(object sender, EventArgs e)
        {
            this.txtQueryCode.TextChanged += new EventHandler(txtQueryCode_TextChanged);

            this.InitDataSet();

            this.ShowData();

            this.ShowDeptStruct();

            InputMap im;
            im = this.fpStorage.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

        }

        private void txtQueryCode_TextChanged(object sender, EventArgs e)
        {
            this.ChangeItem();
        }

        private void fpStorage_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.fpStorage.ContainsFocus)
            {
                if (keyData == Keys.Enter)
                {
                    if (this.fpStorage_Sheet1.ActiveColumnIndex == 2)
                    {
                        Neusoft.HISFC.Models.Base.Spell spCode = new Neusoft.HISFC.Models.Base.Spell();
                        Neusoft.HISFC.BizLogic.Manager.Spell mySpell = new Neusoft.HISFC.BizLogic.Manager.Spell();

                        spCode = (Neusoft.HISFC.Models.Base.Spell)mySpell.Get(fpStorage_Sheet1.Cells[this.fpStorage_Sheet1.ActiveRowIndex, 2].Text.ToString());

                        if (spCode.SpellCode.Length > 10)
                            spCode.SpellCode = spCode.SpellCode.Substring(0, 10);
                        if (spCode.WBCode.Length > 10)
                            spCode.WBCode = spCode.WBCode.Substring(0, 10);

                        this.fpStorage_Sheet1.Cells[this.fpStorage_Sheet1.ActiveRowIndex, 3].Value = spCode.SpellCode;
                        this.fpStorage_Sheet1.Cells[this.fpStorage_Sheet1.ActiveRowIndex, 4].Value = spCode.WBCode;
                    }

                    this.fpStorage_Sheet1.ActiveColumnIndex++;
                }
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion

        #region 初始化工具栏

        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        protected override ToolBarService OnInit(object sender, object NeuObject, object param)
        {
            toolBarService.AddToolButton("保存", "保存当前物品信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);

            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "保存":
                    this.Save();
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.ShowData();

            return base.OnQuery(sender, neuObject);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();

            return base.OnSave(sender, neuObject);
        }

        private void fpStorage_EditChange(object sender, EditorNotifyEventArgs e)
        {
            Neusoft.FrameWork.Management.DataBaseManger data = new Neusoft.FrameWork.Management.DataBaseManger();
            DateTime date = this.basesetManager.GetDateTimeFromSysDateTime();

            this.fpStorage_Sheet1.Cells[e.Row, 14].Text = ((Neusoft.HISFC.Models.Base.Employee)data.Operator).ID;
            this.fpStorage_Sheet1.Cells[e.Row, 15].Text = date.ToString();
        }
        #endregion
    }
}
