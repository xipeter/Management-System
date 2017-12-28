using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    public partial class ucDrugQualityManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable
    {
        public ucDrugQualityManager()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 药品性质常数类别
        /// </summary>
        private string operTypeCode = "DRUGQUALITY";

        /// <summary>
        /// 常数业务操作类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Constant constantManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

        /// <summary>
        /// 拼音码帮助类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Spell spellManager = new Neusoft.HISFC.BizLogic.Manager.Spell();

        /// <summary>
        /// 系统药品性质
        /// </summary>
        private ArrayList alSysQuality = new ArrayList();
    
        /// <summary>
        /// 初始化
        /// </summary>
        protected int InitData()
        {
            try
            {
                FarPoint.Win.Spread.InputMap im;
                im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
                im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);

                ///初始化枚举显示
                Neusoft.HISFC.Models.Pharmacy.DrugQualityEnumService qualityEnumService = new Neusoft.HISFC.Models.Pharmacy.DrugQualityEnumService();

                this.alSysQuality = Neusoft.HISFC.Models.Pharmacy.DrugQualityEnumService.List();
                if (this.alSysQuality == null)
                {
                    MessageBox.Show(Language.Msg("获取系统药品性质发生错误"));
                    return -1;
                }

                this.SetCol();
            }
            catch (Exception e)
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="type"></param>
        protected void QueryConsData(string type)
        {
            ArrayList alCons = this.constantManager.GetAllList(type);
            if (alCons == null)
            {
                MessageBox.Show(Language.Msg("查询常数类别发生错误") + this.constantManager.Err);
                return;
            }
            if (alCons.Count > 0)
            {
                this.AddConstsToFp(alCons);
            }

            this.SetCol();           
        }

        /// <summary>
        /// 将常数数据加入Fp
        /// </summary>
        /// <param name="list"></param>
        private void AddConstsToFp(ArrayList list)
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;

            int iCount = 0;

            foreach (Neusoft.HISFC.Models.Base.Const cons in list)
            {
                this.neuSpread1_Sheet1.Rows.Add(iCount, 1);

                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColID].Text = cons.ID;

                foreach (Neusoft.FrameWork.Models.NeuObject info in this.alSysQuality)
                {
                    if (cons.ID.Substring(0,1) == info.ID.ToString())
                    {
                        this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColSysType].Text = info.ID + info.Name;
                        break;
                    }
                }

                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColName].Text = cons.Name;
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColMemo].Text = cons.Memo;
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColSpellCode].Text = cons.SpellCode;
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColWBCode].Text = cons.WBCode;
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColValid].Value = cons.IsValid;
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColSort].Text = cons.SortID.ToString();
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColOperCode].Text = cons.OperEnvironment.ID;
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColOperTime].Text = cons.OperEnvironment.OperTime.ToString();
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColFlag].Text = "Old";

                this.neuSpread1_Sheet1.Rows[iCount].Tag = cons;

                iCount++;
            }
        }

        /// <summary>
        /// 由数据表内获取数据
        /// </summary>
        /// <param name="row"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Base.Const GetConstFromFp(int iIndex)
        {
            Neusoft.HISFC.Models.Base.Const cons = new Neusoft.HISFC.Models.Base.Const();

            cons.ID = this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColID].Text;
            cons.Name = this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColName].Text;
            cons.SpellCode = this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColSpellCode].Text;
            cons.Memo = this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColMemo].Text;
            cons.WBCode = this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColWBCode].Text;
            cons.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColValid].Value);
            cons.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColSort].Text);

            return cons;
        }

        /// <summary>
        /// Fp格式化
        /// </summary>
        private void SetCol()
        {
            FarPoint.Win.Spread.CellType.ComboBoxCellType cel = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            ArrayList alQuality = Neusoft.HISFC.Models.Pharmacy.DrugQualityEnumService.List();
            //定义字符串数组，保存系统药品性质
            string[] item = new string[alQuality.Count];
            int index = 0;
            //取药品性质列表，保存在字符串数组中
            foreach (Neusoft.FrameWork.Models.NeuObject info in alQuality)
            {
                item[index] = (info.ID + info.Name);
                index++;
            }

            cel.Items = item;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColSysType].CellType = cel;

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColFlag].Text == "Old")
                {
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColID].Locked = true;
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColSysType].Locked = true;
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColID].Locked = false;
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColSysType].Locked = false;
                }
            }
        }

        public void Closeing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (this.Changed())
            //{
            //    DialogResult result = MessageBox.Show(Language.Msg("数据已经被修改，是否要保存？"), "保存", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            //    if (result == DialogResult.Yes)
            //    {
            //        if (this.Save() == -1)
            //        {
            //            e.Cancel = true;
            //        }
            //    }
            //    else if (result == DialogResult.Cancel)
            //    {
            //        e.Cancel = true;
            //    }
            //    else if (result == DialogResult.No)
            //    {

            //    }

            //}
        }

        /// <summary>
        /// 有效性判断
        /// </summary>
        /// <returns></returns>
        private bool Valid()
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                #region 编码有效性判断

                string tempID = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColID].Text.ToString();
                if (tempID.ToString() == "")
                {
                    MessageBox.Show(Language.Msg("编号不能为空！"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (tempID.IndexOf("'") >= 0)
                {
                    MessageBox.Show(Language.Msg("编号不能出现特殊字符,比如 ' "), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(tempID, 2))
                {
                    MessageBox.Show(Language.Msg("编号不能超过20个字符!"));
                    return false;
                }

                #endregion

                #region 名称有效性判断

                string tempName = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColName].Text.ToString();
                if (tempName.ToString() == "")
                {
                    MessageBox.Show(Language.Msg("名称不能为空！"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (tempName.IndexOf("'") >= 0)
                {
                    MessageBox.Show(Language.Msg("名称不能出现特殊字符,比如 ' "), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(tempName, 50))
                {
                    MessageBox.Show(Language.Msg("名称不能超过20个字符!"));
                    return false;
                }

                #endregion

                #region 系统类别有效性判断

                string tmepSysType = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColSysType].Text;
                if (tmepSysType.ToString() != "")
                {
                    if (!tempID.Substring(0, 1).Equals(tmepSysType.Substring(0, 1)))
                    {
                        int j = i + 1;
                        MessageBox.Show(Language.Msg("第" + j.ToString() + "行编码设置错误"));
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("请选择系统代码");
                    return false;
                }

                #endregion
            }

            return true;
        }

        /// <summary>
        /// 数据保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            int countNum = this.neuSpread1_Sheet1.RowCount;

            #region 有效性判断

            if (!this.Valid())
            {
                return -1;
            }

            #endregion

            this.neuSpread1.StopCellEditing();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.constantManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);     

            try
            {
                DateTime sysTime = this.constantManager.GetDateTimeFromSysDateTime();

                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    Neusoft.HISFC.Models.Base.Const cons = this.GetConstFromFp(i);
                    if (cons == null)                    
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("保存发生错误。由Fp内获取数据失败" ));
                        return -1;
                    }

                    cons.OperEnvironment.ID = this.constantManager.Operator.ID;
                    cons.OperEnvironment.OperTime = sysTime;

                    if (this.constantManager.SetConstant(this.operTypeCode, cons) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("保存发生错误" + this.constantManager.Err));
                        return -1;
                    }
                }
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                if (e.Message == "编号重复,请重新录入")
                {                    
                    MessageBox.Show(Language.Msg("编号重复,请重新录入"));
                }
                else
                {
                    MessageBox.Show(Language.Msg("数据保存失败！" + e.Message), "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("保存成功!"));

            this.QueryConsData(this.operTypeCode);

            this.SetCol();

            this.isDirty = false;

            return 0;
        }

        private void fpSpread1_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            if (e.Column == (int)ColumnSet.ColName)
            {
                Neusoft.HISFC.Models.Base.Spell spCode = new Neusoft.HISFC.Models.Base.Spell();

                spCode = (Neusoft.HISFC.Models.Base.Spell)this.spellManager.Get(this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColName].Text.ToString());

                if (spCode == null)
                {
                    return;
                }
                if (spCode.SpellCode == null || spCode.SpellCode == "")
                {
                    return;
                }

                this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColSpellCode].Value = spCode.SpellCode;
                this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColWBCode].Value = spCode.WBCode;
            }
        }

        private void fpSpread1_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            this.isDirty = true;
        }

        private void fpSpread1_ComboSelChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == (int)ColumnSet.ColSysType)
            {
                //取所选择的系统代码
                string text = ((FarPoint.Win.FpCombo)e.EditingControl).SelectedItem.ToString();

                string idnum = this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColID].Text;

                if (idnum.ToString() == "")
                {
                    this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColID].Text = text.Substring(0, 1);
                }
                else
                {
                    string ls = this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColID].Text;

                    this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColID].Text = text.Substring(0, 1) + ls.Substring(ls.Length - 1, 1);
                }
            }
        }

        #region IMaintenanceControlable 成员

        private bool isDirty = false;

        /// <summary>
        /// 增加 
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            this.isDirty = true;

            int index = this.neuSpread1_Sheet1.RowCount;

            this.neuSpread1_Sheet1.Rows.Add(index, 1);

            this.neuSpread1_Sheet1.Cells[index - 1, (int)ColumnSet.ColID].Locked = false;
            this.neuSpread1_Sheet1.Cells[index - 1, (int)ColumnSet.ColFlag].Text = "New";
            this.neuSpread1_Sheet1.Cells[index - 1, (int)ColumnSet.ColSort].Value = index++;
            this.neuSpread1_Sheet1.Cells[index - 1, (int)ColumnSet.ColOperCode].Text = this.constantManager.Operator.ID.ToString();
            this.neuSpread1_Sheet1.Cells[index - 1, (int)ColumnSet.ColValid].Value = true;

            this.neuSpread1_Sheet1.SetActiveCell(neuSpread1_Sheet1.Rows.Count - 1, 0);

            return 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Del()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
            {
                return 0;
            }

            this.isDirty = true;

            if (MessageBox.Show(Language.Msg("删除该条数据"), "删除", System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = this.neuSpread1_Sheet1.ActiveRowIndex;

                string code = this.neuSpread1_Sheet1.Cells[index, (int)ColumnSet.ColID].Text.Trim();
                string name = this.neuSpread1_Sheet1.Cells[index, (int)ColumnSet.ColName].Text.Trim();
                string ifNew = this.neuSpread1_Sheet1.Cells[index, (int)ColumnSet.ColFlag].Text.Trim();

                int flag = this.constantManager.CanDeleteCons(this.operTypeCode, code);

                switch (flag)
                {
                    case 1:
                        if (ifNew == "Old")
                        {
                            MessageBox.Show(Language.Msg(name + "不可以删除修改!"));
                            return 0;
                        }
                        break;
                    case 0:
                        if (flag == 0)
                        {
                            MessageBox.Show(Language.Msg(name + "在数据库中已经存在不能删除"));
                            return 0;
                        }
                        break;
                    case 2:
                        if (flag == 2)
                        {
                            MessageBox.Show(Language.Msg("该类项目不可以删除!"));
                            return 0;
                        }
                        break;
                }

                if (ifNew != "New")
                {
                    if (this.constantManager.DelConstant(this.operTypeCode, code) == -1)
                    {
                        MessageBox.Show(Language.Msg("删除项目失败!") + this.constantManager.Err);
                        return -1;
                    }
                }

                this.neuSpread1_Sheet1.Rows[index].Remove();
            }

            return 0;
        }

        public int Copy()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Cut()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Delete()
        {
            return this.Del();
        }

        public int Export()
        {
            if (this.neuSpread1.Export() != -1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }

            return 1;
        }

        int Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable.Import()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Init()
        {
            if (this.InitData() == -1)
            {
                return -1;
            }

            this.QueryConsData(this.operTypeCode);

            return 0;
        }

        public bool IsDirty
        {
            get
            {
                return this.isDirty;
            }
            set
            {
                this.isDirty = value;
            }
        }

        public int Modify()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int NextRow()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Paste()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PreRow()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Print()
        {
            // TODO:  添加 ConstantManager.Print 实现
            return 1;
        }

        public int PrintConfig()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PrintPreview()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Query()
        {
            this.QueryConsData(this.operTypeCode);

            return 1;
        }

        public Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm QueryForm
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            /// <summary>
            /// 编码
            /// </summary>
            ColID,
            /// <summary>
            /// 名称
            /// </summary>
            ColName,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo,
            /// <summary>
            /// 拼音码
            /// </summary>
            ColSpellCode,
            /// <summary>
            /// 五笔码
            /// </summary>
            ColWBCode,
            /// <summary>
            /// 系统类别
            /// </summary>
            ColSysType,
            /// <summary>
            /// 有效性
            /// </summary>
            ColValid,
            /// <summary>
            /// 序列号
            /// </summary>
            ColSort,
            /// <summary>
            /// 操作员
            /// </summary>
            ColOperCode,
            /// <summary>
            /// 操作时间
            /// </summary>
            ColOperTime,
            /// <summary>
            /// 标志
            /// </summary>
            ColFlag
        }
    }
}
