using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.BlackList;
using Neusoft.HISFC.BizLogic.Fee;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Account.Controls
{
    public partial class ucBlackList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucBlackList()
        {
            InitializeComponent();
        }
        #region 变量
        /// <summary>
        /// 工具栏
        /// </summary>
        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        /// <summary>
        /// 黑名单业务层
        /// </summary>
        PBlackList pBlackList = new PBlackList();
        /// <summary>
        /// 黑名单实体
        /// </summary>
        PatientBlackList pbl = null;
        /// <summary>
        /// 黑名单明细实体
        /// </summary>
        PatientBlackListDetail pbld = null;
        /// <summary>
        /// 入出转业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        private bool IsEnable = false;
        #endregion

        #region 方法
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("加入黑名单", "将患者加入黑名单", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("排除黑名单", "将患者从黑名单中排除", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);
            return toolBarService;
        }

        /// <summary>
        /// 根据病历号查找数据
        /// </summary>
        /// <returns></returns>
        protected virtual void QueryData()
        {
            string cardNo = this.txtCardNo.Text.Trim();
            if (cardNo == string.Empty)
            {
                MessageBox.Show(Language.Msg("请输入病历号！"), Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsEnable = false;
                return;
            }
            //{D7742D35-6162-4b30-8F60-1F22E48C271D}
            //cardNo = cardNo.PadLeft(HISFC.BizProcess.Integrate.Common.ControlParam.GetCardNOLen(), '0');
            //cardNo = cardNo.PadLeft(HISFC.BizProcess.Integrate.Common.ControlParam.GetCardNOLen(), '0');
            cardNo = cardNo.PadLeft(10, '0');
            this.txtCardNo.Text=cardNo;
            //根据病历号判断是否存在患者信息
            Neusoft.HISFC.Models.RADT.PatientInfo p = radtIntegrate.QueryComPatientInfo(cardNo);
            if (p.PID.CardNO == null || p.PID.CardNO == string.Empty)
            {
                IsEnable = false;
                MessageBox.Show(Language.Msg("该病历号") + cardNo + Language.Msg("不存在患者信息！"), Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.ucRegPatientInfo1.CardNO = cardNo;
            int result = 0;
            result = pBlackList.GetBlackList(cardNo,ref pbl);
            if (result == -1)
            {
                IsEnable = false;
                MessageBox.Show(Language.Msg("查找黑名单数据失败！"), Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ckState.Checked = pbl.BlackListValid;
            this.SetBlackListDetail(pbl);
            IsEnable = true;
        }

        /// <summary>
        ///　显示黑名单明细数据
        /// </summary>
        /// <param name="pbl"></param>
        private void SetBlackListDetail(PatientBlackList pbl)
        {
            List<PatientBlackListDetail> list = pbl.BlackListDetail;
            int count=list.Count;
            this.neuSpread1_Sheet1.Rows.Count = count;
            for (int i = 0; i < count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Text = pbl.CardNO;
                this.neuSpread1_Sheet1.Cells[i, 1].Text = list[i].BlackListValid.ToString();
                this.neuSpread1_Sheet1.Cells[i, 2].Text = list[i].Memo;
                this.neuSpread1_Sheet1.Cells[i, 3].Text = list[i].Oper.Name;
                this.neuSpread1_Sheet1.Cells[i, 4].Text = list[i].Oper.OperTime.ToString();
            }
        }
        /// <summary>
        /// 获取黑名单实体
        /// </summary>
        /// <param name="bl">true:加入黑名单 false从黑名单中排除</param>
        /// <returns></returns>
        private void GetPatientBlackList(bool bl)
        {
            pbl = new PatientBlackList();
            //主表实体
            pbl.CardNO = this.txtCardNo.Text;
            pbl.BlackListValid = bl;
            //明细
            pbld = new PatientBlackListDetail();
            pbld.SeqNO = pBlackList.GetBlackListSeqNo();
            pbld.Memo = this.txtMemo.Text;
            pbld.Oper.ID = pBlackList.Operator.ID;
            pbld.Oper.OperTime = pBlackList.GetDateTimeFromSysDateTime();
            pbld.BlackListValid = bl;
            pbl.BlackListDetail.Clear();
            pbl.BlackListDetail.Add(pbld);
        }

        /// <summary>
        /// 将患者加入黑名单
        /// </summary>
        /// <returns></returns>
        protected virtual void AddBlackList()
        {
            if (!IsEnable)
            {
                MessageBox.Show(Language.Msg("请输入病历号，并回车确认！"), Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ckState.Checked)
            {
                MessageBox.Show(Language.Msg("该患者已在黑名单中，不能再次加入黑名单！"), Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //得到患者黑名单实体
            this.GetPatientBlackList(true);
            //事物
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Transaction(Connection.Instance);
            //trans.BeginTransaction();

            pBlackList.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //保存主表数据
            int resultValue= pBlackList.SaveBlackList(pbl);
            if (resultValue == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(pBlackList.Err);
                return;
            }
            //保存明细数据
            resultValue = pBlackList.AddBlackListDetail(pbl);
            if (resultValue == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(pBlackList.Err);
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Language.Msg("加入黑名单成功！"),Language.Msg("提示"),MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.QueryData();
            this.txtCardNo.Text = string.Empty;
            this.txtCardNo.Focus();
            IsEnable = false;
        }

        /// <summary>
        /// 将患者从黑名单中排除
        /// </summary>
        /// <returns></returns>
        protected virtual void CancelBlackList()
        {
            if (!IsEnable)
            {
                MessageBox.Show(Language.Msg("请输入病历号，并回车确认！"), Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //得到患者黑名单实体
            this.GetPatientBlackList(false);

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Transaction(Connection.Instance);
            //trans.BeginTransaction();

            pBlackList.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //更新主表数据
            int resultValue = pBlackList.UpdateBlackList(pbl);
            if (resultValue == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(pBlackList.Err);
                return;
            }

            //{E8D9B53F-9C12-4f6e-8F7C-A94FB6B9D173}
            if (resultValue == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("该人员不在黑名单里！");
                return;
            }

            //保存明细数据
            resultValue = pBlackList.AddBlackListDetail(pbl);
            if (resultValue == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(pBlackList.Err);
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Language.Msg("排除黑名单成功！"), Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.QueryData();
            this.txtCardNo.Text = string.Empty;
            this.txtCardNo.Focus();
            IsEnable = false;
        }

        #endregion

        #region 事件
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "加入黑名单":
                    {
                        this.AddBlackList();
                        break;
                    }
                case "排除黑名单":
                    {
                        this.CancelBlackList();
                        break;
                    }
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.QueryData();
            }
        }

        #endregion
    }
}
