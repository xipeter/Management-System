using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.HealthRecord.Case
{
    /// <summary>
    /// ucCabinet<br></br>
    /// [功能描述: 病案柜管理]<br></br>
    /// [创 建 者: 赫一阳]<br></br>
    /// [创建时间: 2007-08-29]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucCabinet : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCabinet()
        {
            InitializeComponent();

            this.Init();
        }

        #region 变量

        /// <summary>
        /// 病案管理业务层对象
        /// </summary>
        Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseCabinet cabinetMrg = new Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseCabinet();

        /// <summary>
        /// 工具栏
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion

        #region 事件

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("新增", "新增加一条病案柜信息", 1, true, false, null);
           
            return toolBarService;
        
        }

        /// <summary>
        /// 工具栏的单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "新增")
            {
                this.Clear();
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            if (this.Save() < 0) return -1;

            MessageBox.Show("保存成功！", "提示");
            this.Clear();
            this.ShowFpInfo();

            return base.OnSave(sender, neuObject);
        }

        /// <summary>
        /// 回车焦点转移
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 病案信息双击调入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1Cabinet_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet caseCabinet = new Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet();
            int currRow = this.SpCabinet.ActiveRowIndex;

            caseCabinet = this.SpCabinet.Rows[currRow].Tag as Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet;

            if (caseCabinet.IsValid)
                this.radioValid.Checked = true;
            else
                this.radioInvalid.Checked = true;

            this.txtStoreNO.Text = caseCabinet.Store.ID;
            this.txtCabinetNO.Text = caseCabinet.ID;
            this.txtCabinetNO.Enabled = false;
            this.txtGridCount.Text = caseCabinet.GridCount.ToString();
            this.txtMemo.Text = caseCabinet.Memo;
            this.txtOper.Text = caseCabinet.OperEnv.Name;
            this.txtOperTime.Text = caseCabinet.OperEnv.OperTime.ToString();
        }

        #endregion

        #region 函数

        /// <summary>
        /// 初始化函数
        /// </summary>
        protected void Init()
        {
            this.txtOper.Text = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Name;
            this.txtOperTime.Text = DateTime.Now.ToString();

            this.ShowFpInfo();
        }

        /// <summary>
        /// 初始化 显示farpoint数据
        /// </summary>
        private void ShowFpInfo()
        {
            ArrayList cabinetList = null;
            Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseCabinet cabinetMrg = new Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseCabinet();

            try
            {
                cabinetList = cabinetMrg.QueryAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取数据出错！ " + ex.Message, "错误");
                return;
            }

            if (cabinetList.Count > 0)
            {
                this.SetFpValue(cabinetList);
            }
        }

        /// <summary>
        /// farpoint赋值
        /// </summary>
        /// <param name="arrayList">对象列表</param>
        private void SetFpValue(ArrayList arrayList)
        {
            Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet cabinetObj = new Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet();
            this.SpCabinet.RowCount = arrayList.Count;

            for (int i = 0; i < arrayList.Count; i++)
            {
                cabinetObj = arrayList[i] as Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet;

                this.SpCabinet.Rows[i].Tag = cabinetObj;
                this.SpCabinet.Cells[i, 0].Text = cabinetObj.Store.ID;
                this.SpCabinet.Cells[i, 1].Text = cabinetObj.ID;
                this.SpCabinet.Cells[i, 2].Text = cabinetObj.GridCount.ToString();
                if (cabinetObj.IsValid)
                {
                    this.SpCabinet.Cells[i, 3].Text = "是";
                    this.SpCabinet.Rows[i].BackColor = Color.White;
                }
                else
                {
                    this.SpCabinet.Cells[i, 3].Text = "否";
                    this.SpCabinet.Rows[i].BackColor = Color.HotPink;
                }
                this.SpCabinet.Cells[i, 4].Text = cabinetObj.OperEnv.Name;
                this.SpCabinet.Cells[i, 5].Text = cabinetObj.OperEnv.OperTime.ToString();
                this.SpCabinet.Cells[i, 6].Text = cabinetObj.Memo;
            }
        }

        /// <summary>
        /// 有效性验证
        /// </summary>
        /// <returns>1 保存成功, -1 保存失败</returns>
        private int Valid()
        {
            if (this.txtStoreNO.Text.Trim() == string.Empty)
            {
                MessageBox.Show("病案库号不能为空！", "提示");
                this.txtStoreNO.Focus();
                return -1;
            }

            if (this.txtCabinetNO.Text.Trim() == string.Empty)
            {
                MessageBox.Show("病案柜号不能为空！", "提示");
                this.txtCabinetNO.Focus();
                return -1;
            }

            if (this.txtGridCount.Text.Trim() == string.Empty)
            {
                MessageBox.Show("病案柜格数不能为空！", "提示");
                this.txtGridCount.Focus();
                return -1;
            }

            try
            {
                int j =(Convert.ToInt32(this.txtGridCount.Text)) / 2;
            }
            catch
            {
                MessageBox.Show("格数输入数据非法：必须为数字", "提示");
                this.txtGridCount.Focus();
                this.txtGridCount.SelectAll();

                return -1;
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtStoreNO.Text, 50))
            {
                MessageBox.Show("输入的病案库号过长！", "提示");
                this.txtStoreNO.Focus();
                this.txtStoreNO.SelectAll();
                return -1;
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtCabinetNO.Text, 50))
            {
                MessageBox.Show("输入的病案柜号过长！", "提示");
                this.txtCabinetNO.Focus();
                this.txtCabinetNO.SelectAll();
                return -1;
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtMemo.Text, 200))
            {
                MessageBox.Show("输入的备注信息过长！", "提示");
                this.txtMemo.Focus();
                this.txtMemo.SelectAll();
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 保存病案柜信息
        /// </summary>
        /// <returns>-1 失败　1 成功</returns>
        protected int Save()
        {
            Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet cabinet = new Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet();

            if (this.Valid() < 0) return -1;

            //读取要保存的数据
            cabinet.Store.ID = this.txtStoreNO.Text.Trim();
            cabinet.ID = this.txtCabinetNO.Text.Trim();
            cabinet.GridCount = NConvert.ToInt32(this.txtGridCount.Text.Trim());
            cabinet.Memo = this.txtMemo.Text.Trim();
            cabinet.IsValid = this.radioValid.Checked;
            cabinet.OperEnv.ID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).ID;
            cabinet.OperEnv.OperTime = NConvert.ToDateTime(this.txtOperTime.Text);

            //保存数据
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.cabinetMrg.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.txtCabinetNO.Enabled) //新增加的记录
            {
                if (this.cabinetMrg.Insert(cabinet) < 0)
                {
                    MessageBox.Show("保存失败！ " + this.cabinetMrg.Err, "提示");
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
            }
            else //对现有数据都修改
            {
                if (this.cabinetMrg.Update(cabinet) < 0)
                {
                    MessageBox.Show("保存失败！ " + this.cabinetMrg.Err, "提示");
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            return 1;
        }

        /// <summary>
        /// 将界面上的信息清空
        /// </summary>
        protected void Clear()
        {
            this.txtCabinetNO.Enabled = true;

            this.txtStoreNO.Text = string.Empty;
            this.txtCabinetNO.Text = string.Empty;
            this.txtGridCount.Text = string.Empty;
            this.radioValid.Checked = true;
            this.txtMemo.Text = string.Empty;
            this.txtOper.Text = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Name;
            this.txtOperTime.Text = DateTime.Now.ToString();
        }

        #endregion

    }
}
