using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述: 特殊单位维护]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// <说明>
    ///     待测试
    /// </说明>
    /// </summary>
    public partial class ucSpeUnitManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSpeUnitManager()
        {
            InitializeComponent();
        }

        public delegate void SaveDataHander(object data);

        public event SaveDataHander SaveDataEvent;

        private string drugInfo = "药品名称：{0} 规格：{1} 包装单位：{2} 包装数量：{3} 最小单位：{4}";

        #region 域变量

        /// <summary>
        /// 类别单元格
        /// </summary>
        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbTypeCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();

        /// <summary>
        /// 单位单位格
        /// </summary>
        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbUnitCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();

        /// <summary>
        /// 存储已维护的药品
        /// </summary>
        private System.Collections.Hashtable hsItem = new Hashtable();

        /// <summary>
        /// 本次操作药品信息
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item tempItem;

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 药品帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper drugDataHelper;

        /// <summary>
        /// 类别帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper unitTypeHelper;

        /// <summary>
        /// 药品信息
        /// </summary>
        private ArrayList alDrugData = new ArrayList();

        #endregion

        #region 属性

        /// <summary>
        /// 本次操作药品信息
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.Item Item
        {
            set
            {
                this.tempItem = value;
                if (value != null)
                {
                    this.lbDrugInfo.Text = string.Format(drugInfo, value.Name, value.Specs, value.PackUnit, value.PackQty.ToString(), value.MinUnit);
                    string[] strUnits = { value.MinUnit, value.PackUnit };

                    FarPoint.Win.Spread.CellType.ComboBoxCellType cmbBaseUnitCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    cmbBaseUnitCellType.Items = strUnits;
                    //基本单位 最小单位/包装单位
                    this.neuSpread1_Sheet1.Columns[3].CellType = cmbBaseUnitCellType;
                }
                else
                {
                    this.lbDrugInfo.Text = this.drugInfo;
                    this.Clear();
                }
            }
        }

        /// <summary>
        /// 存储已维护的药品
        /// </summary>
        public System.Collections.Hashtable HsItem
        {
            get
            {
                return this.hsItem;
            }
            set
            {
                this.hsItem = value;
            }
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Constant constMgr = new Neusoft.HISFC.BizLogic.Manager.Constant();

            #region 类别设置

            ArrayList alUnitType = constMgr.GetList("SpeUnitType");
            if (alUnitType == null)
            {
                MessageBox.Show(Language.Msg("获取类别常数列表发生错误" + constMgr.Err));
                return;
            }
            if (alUnitType.Count == 0)
            {
                #region 基础常数 未找到数据时暂时使用该数据

                Neusoft.FrameWork.Models.NeuObject info1 = new Neusoft.FrameWork.Models.NeuObject();
                info1.ID = "Clinic";
                info1.Name = "门诊发药";
                alUnitType.Add(info1);

                Neusoft.FrameWork.Models.NeuObject info2 = new Neusoft.FrameWork.Models.NeuObject();
                info2.ID = "Inpatient";
                info2.Name = "住院摆药";
                alUnitType.Add(info2);

                Neusoft.FrameWork.Models.NeuObject info3 = new Neusoft.FrameWork.Models.NeuObject();
                info3.ID = "InOut";
                info3.Name = "大包装入出库";
                alUnitType.Add(info3);

                #endregion
            }

            string[] strUnitType = new string[alUnitType.Count];
            int iUnit = 0;
            foreach (Neusoft.FrameWork.Models.NeuObject unitType in alUnitType)
            {
                strUnitType[iUnit] = unitType.Name;
                iUnit++;
            }            

            this.unitTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper(alUnitType);

            this.cmbUnitCellType.Items = strUnitType;

            FarPoint.Win.Spread.CellType.ComboBoxCellType splitTypeCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            splitTypeCell.Items = strUnitType;

            this.neuSpread1_Sheet1.Columns[0].CellType = splitTypeCell;

            #endregion

            #region 获取单位集合

            ArrayList alPackUnit = constMgr.GetList(Neusoft.HISFC.Models.Base.EnumConstant.PACKUNIT);
            if (alPackUnit == null)
            {
                MessageBox.Show(Language.Msg("获取包装单位发生错误" + constMgr.Err));
                return;
            }
            ArrayList alMinUnit = constMgr.GetList(Neusoft.HISFC.Models.Base.EnumConstant.MINUNIT);
            if (alMinUnit == null)
            {
                MessageBox.Show(Language.Msg("获取最小单位发生错误" + constMgr.Err));
                return;
            }

            alPackUnit.AddRange(alMinUnit);

            string[] strUnit = new string[alPackUnit.Count];
            int i = 0;
            foreach (Neusoft.HISFC.Models.Base.Const cons in alPackUnit)
            {
                strUnit[i] = cons.Name;
                i++;
            }

            this.cmbUnitCellType.Items = strUnit;
            //特殊单位
            this.neuSpread1_Sheet1.Columns[1].CellType = this.cmbUnitCellType;
            this.neuSpread1_Sheet1.Columns[3].CellType = this.cmbUnitCellType;

            #endregion

            #region 获取药品信息

            List<Neusoft.HISFC.Models.Pharmacy.Item> itemCollection = this.itemManager.QueryItemList(true);
            if (itemCollection == null)
            {
                MessageBox.Show(Language.Msg("获取药品信息发生错误" + this.itemManager.Err));
                return;
            }

            this.alDrugData = new ArrayList(itemCollection.ToArray());

            foreach (Neusoft.HISFC.Models.Pharmacy.Item info in alDrugData)
            {
                info.Memo = info.Specs;
            }

            this.drugDataHelper = new Neusoft.FrameWork.Public.ObjectHelper(this.alDrugData);

            #endregion
        }

        #endregion

        /// <summary>
        /// 清屏
        /// </summary>
        private void Clear()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;

                this.lbDrugInfo.Text = this.drugInfo;
        }

        /// <summary>
        /// 设置焦点
        /// </summary>
        private void SetFocus()
        {
            if (this.neuSpread1_Sheet1.Rows.Count == 0)
            {
                this.neuSpread1_Sheet1.Rows.Count = 1;
            }
            
            this.neuSpread1_Sheet1.ActiveColumnIndex = 0;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void Close()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        /// <summary>
        /// 有效性
        /// </summary>
        /// <returns>满足条件返回True 否则False</returns>
        private bool Valid()
        {
            if (this.tempItem == null)
            {
                MessageBox.Show(Language.Msg("请设置维护的药品"));
                return false;
            }
            Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit info;
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                info = this.GetSpeUnit(i);
                if (info == null)
                {
                    MessageBox.Show(Language.Msg("请选择类别"));
                    return false;
                }
                //{170D63B3-8252-4488-8675-B006283D9E41}
                if (string.IsNullOrEmpty(info.UnitType.Name))
                {
                    MessageBox.Show(Language.Msg("请选择类别"));
                    return false;
                }
                if (string.IsNullOrEmpty(info.Unit))
                {
                    MessageBox.Show(Language.Msg("请选择单位"));
                    return false;
                }
                //{170D63B3-8252-4488-8675-B006283D9E41}
                if (info.Unit == this.tempItem.PackUnit || info.Unit == this.tempItem.MinUnit)
                {
                    MessageBox.Show(Language.Msg("特殊单位不能等于包装单位或最小单位"));
                    return false;
                }
                if (this.neuSpread1_Sheet1.Cells[i, 2].Text == "")
                {
                    MessageBox.Show(Language.Msg("请维护参照数量"));
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 根据药品基本信息设置特殊单位信息
        /// </summary>
        /// <param name="item">药品基本信息</param>
        public void SetSpeUnit(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            this.Item = item;

            ArrayList al = this.itemManager.QuerySpeUnit(item.ID);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取已维护的特殊单位信息发生错误" + this.itemManager.Err));
                return;
            }
            if (al.Count > 0)
            {
                Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit info;
                this.neuSpread1_Sheet1.Rows.Count = al.Count;
                for (int i = 0; i < al.Count; i++)
                {
                    info = al[i] as Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit;

                    this.neuSpread1_Sheet1.Cells[i, 0].Text = info.UnitType.Name;
                    this.neuSpread1_Sheet1.Cells[i, 1].Text = info.Unit;

                    if (info.UnitFlag == "0")
                    {
                        this.neuSpread1_Sheet1.Cells[i, 3].Text = info.Item.MinUnit;
                        this.neuSpread1_Sheet1.Cells[i, 2].Text = info.Qty.ToString();
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.Cells[i, 3].Text = info.Item.PackUnit;
                        this.neuSpread1_Sheet1.Cells[i, 2].Text = (info.Qty / info.Item.PackQty).ToString();
                    }

                    this.neuSpread1_Sheet1.Rows[i].Tag = info;
                }

            }

        }

        /// <summary>
        /// 保存
        /// </summary>
        public void SaveSpeUnit()
        {
            if (!this.Valid())
            {
                return;
            }

            DateTime sysDate = this.itemManager.GetDateTimeFromSysDateTime();

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.itemManager.DeleteSpeUnit(this.tempItem.ID) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("删除该药品已维护的特殊单位信息时发生错误" + this.itemManager.Err));
                return;
            }

            Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit info;
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                info = this.GetSpeUnit(i);

                decimal num = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 2].Text);
                string unit = this.neuSpread1_Sheet1.Cells[i, 3].Text;

                info.Item = this.tempItem;

                if (unit == this.tempItem.MinUnit)
                {
                    info.UnitFlag = "0";
                    info.Qty = num;
                }
                else
                {
                    info.UnitFlag = "1";
                    info.Qty = num * this.tempItem.PackQty;
                }

                info.Oper.ID = this.itemManager.Operator.ID;
                info.Oper.OperTime = sysDate;

                if (this.itemManager.InsertSpeUnit(info) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();

                    if (this.itemManager.DBErrCode == 1)
                    {
                        MessageBox.Show("存在重复数据 请重新检查后再进行保存操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Language.Msg("保存失败" + this.itemManager.Err));
                    }
                    return;
                }
            }

            if (!this.hsItem.ContainsKey(this.tempItem.ID))
            {
                this.hsItem.Add(this.tempItem.ID, this.tempItem);
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            if (this.SaveDataEvent != null)
            {
                this.SaveDataEvent(this.tempItem);
            }

            MessageBox.Show(Language.Msg("保存成功"));

            if (!this.chkContinue.Checked)
            {
                this.Close();
            }

            this.Item = null;
        }

        /// <summary>
        /// 行、列跳转
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        private int JumpColumn()
        {
            int i = this.neuSpread1_Sheet1.ActiveColumnIndex;

            if (this.neuSpread1_Sheet1.ActiveColumnIndex == 3)
            {
                if (this.neuSpread1_Sheet1.ActiveRowIndex == this.neuSpread1_Sheet1.Rows.Count - 1)
                {
                    this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.Rows.Count, 1);
                    this.neuSpread1_Sheet1.ActiveRowIndex++;
                }
                else
                {
                    this.neuSpread1_Sheet1.ActiveRowIndex++;
                }

                this.neuSpread1_Sheet1.ActiveColumnIndex = 0;
            }
            else
            {
                this.neuSpread1_Sheet1.ActiveColumnIndex++;
            }
            return 1;
        }

        /// <summary>
        /// 增加
        /// </summary>
        private void Add()
        {
            this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.Rows.Count, 1);

            this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.Rows.Count - 1;
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Del()
        {
            int i = this.neuSpread1_Sheet1.ActiveRowIndex;

            Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit info;
            if (this.neuSpread1_Sheet1.Rows[i].Tag == null)
            {
                this.neuSpread1_Sheet1.Rows.Remove(i, 1);
            }
            else
            {
                info = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit;
                if (info == null)
                {
                    this.neuSpread1_Sheet1.Rows.Remove(i, 1);
                }

                else
                {
                    //定义事务
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                    //t.BeginTransaction();

                    this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    if (this.itemManager.DeleteSpeUnit(info) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("删除失败"));
                        return;
                    }
                    this.neuSpread1_Sheet1.Rows.Remove(i, 1);

                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                }
            }
        }

        /// <summary>
        /// 新增药品
        /// </summary>
        private void AddItem()
        {
            Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alDrugData, ref info) == 0)
            {
                return;
            }
            else
            {
                Neusoft.HISFC.Models.Pharmacy.Item item = info as Neusoft.HISFC.Models.Pharmacy.Item;

                if (this.hsItem.ContainsKey(item.ID))
                {
                    MessageBox.Show(Language.Msg("该药品已维护过多级单位"));
                    return;
                }               

                this.Clear();

                this.Item = item;

                this.SetFocus();
            }
        }

        /// <summary>
        /// 获取特殊单位信息
        /// </summary>
        /// <param name="iRowIndex">指定行索引</param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit GetSpeUnit(int iRowIndex)
        {
            Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit info = null;
            if (this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag != null)
            {
                info = this.neuSpread1_Sheet1.Rows[iRowIndex].Tag as Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit;
            }

            if (info == null)
            {
                info = new Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit();
            }
            //类别
            info.UnitType.Name = this.neuSpread1_Sheet1.Cells[iRowIndex, 0].Text;       
            info.UnitType.ID = this.unitTypeHelper.GetID(info.UnitType.Name);
            //单位
            info.Unit = this.neuSpread1_Sheet1.Cells[iRowIndex, 1].Text;
            //参照数量
            info.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[iRowIndex, 2].Text);

            return info;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveSpeUnit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Add();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.Del();
        }

        private void lnbDrug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.AddItem();
        }
    }
}
