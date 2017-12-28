using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Registration
{
    public partial class ucUnCancel : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucUnCancel()
        {
            InitializeComponent();

            this.fpSpread1.KeyDown += new KeyEventHandler(fpSpread1_KeyDown);
            this.txtRecipeNo.KeyDown += new KeyEventHandler(txtRecipeNo_KeyDown);
            this.txtCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNo_KeyDown);

            this.Init();
        }

        #region 域
        /// <summary>
        /// 挂号管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Register regMgr = new Neusoft.HISFC.BizLogic.Registration.Register();
        private Neusoft.HISFC.BizLogic.Registration.Schema schMgr = new Neusoft.HISFC.BizLogic.Registration.Schema();
        /// <summary>
        /// 控制管理类
        /// </summary>
        private Neusoft.FrameWork.Management.ControlParam ctlMgr = new Neusoft.FrameWork.Management.ControlParam();
        /// <summary>
        /// 可打印挂号发票天数
        /// </summary>
        private int PermitDays = 0;
        private ArrayList al = new ArrayList();

        #endregion
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            string Days = this.ctlMgr.QueryControlerInfo("400006");

            if (Days == null || Days == "" || Days == "-1")
            {
                this.PermitDays = 1;
            }
            else
            {
                this.PermitDays = int.Parse(Days);
            }
            this.txtCardNo.Focus();
            return 0;
        }

        /// <summary>
        /// 根据病历号检索患者挂号信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCardNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cardNo = this.txtCardNo.Text.Trim();
                if (cardNo == "")
                {
                    MessageBox.Show("病历号不能为空!", "提示");
                    this.txtCardNo.Focus();
                    return;
                }

                cardNo = cardNo.PadLeft(10, '0');
                this.txtCardNo.Text = cardNo;

                DateTime permitDate = this.regMgr.GetDateTimeFromSysDateTime().AddDays(-this.PermitDays).Date;
                //检索患者作废号
                this.al = this.regMgr.QueryCancel(cardNo, permitDate);
                if (this.al == null)
                {
                    MessageBox.Show("检索患者挂号信息时出错!" + this.regMgr.Err, "提示");
                    return;
                }

                if (this.al.Count == 0)
                {
                    MessageBox.Show("该患者没有作废号!", "提示");
                    this.txtCardNo.Focus();
                    return;
                }
                else
                {
                    this.addRegister(al);

                    this.fpSpread1.Focus();
                    this.fpSpread1_Sheet1.SetActiveCell(0, 2, false);
                }
            }
        }


        /// <summary>
        /// 处方号回车,根据处方号检索患者挂号信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRecipeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string recipeNo = this.txtRecipeNo.Text.Trim();
                if (recipeNo == "")
                {
                    MessageBox.Show("处方号不能为空!", "提示");
                    this.txtRecipeNo.Focus();
                    return;
                }

                DateTime permitDate = this.regMgr.GetDateTimeFromSysDateTime().AddDays(-this.PermitDays).Date;

                //检索患者挂号
                this.al = this.regMgr.QueryByRecipe(recipeNo);
                if (this.al == null)
                {
                    MessageBox.Show("检索患者挂号信息时出错!" + this.regMgr.Err, "提示");
                    return;
                }

                ArrayList alRegCollection = new ArrayList();

                ///移除超过限定时间的挂号信息
                ///
                foreach (Neusoft.HISFC.Models.Registration.Register obj in this.al)
                {
                    if (obj.DoctorInfo.SeeDate.Date < permitDate.Date) continue;

                    alRegCollection.Add(obj);
                }

                if (alRegCollection.Count == 0)
                {
                    MessageBox.Show("该患者没有作废号!", "提示");
                    this.txtRecipeNo.Focus();
                    return;
                }
                else
                {
                    this.addRegister(alRegCollection);

                    this.fpSpread1.Focus();
                    this.fpSpread1_Sheet1.SetActiveCell(0, 2, false);
                }
            }
        }
        /// <summary>
        /// 添加患者挂号明细
        /// </summary>
        /// <param name="registers"></param>
        private void addRegister(ArrayList registers)
        {
            if (this.fpSpread1_Sheet1.RowCount > 0)
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.RowCount);

            Neusoft.HISFC.Models.Registration.Register obj;

            for (int i = registers.Count - 1; i >= 0; i--)
            {
                obj = (Neusoft.HISFC.Models.Registration.Register)registers[i];
                this.addRegister(obj);
            }
        }
        /// <summary>
        /// add a record to farpoint
        /// </summary>
        /// <param name="reg"></param>
        private void addRegister(Neusoft.HISFC.Models.Registration.Register reg)
        {
            this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);

            int cnt = this.fpSpread1_Sheet1.RowCount - 1;

            this.fpSpread1_Sheet1.SetValue(cnt, 0, reg.Name, false);
            this.fpSpread1_Sheet1.SetValue(cnt, 1, reg.Sex.Name, false);
            this.fpSpread1_Sheet1.SetValue(cnt, 2, reg.DoctorInfo.SeeDate, false);
            this.fpSpread1_Sheet1.SetValue(cnt, 3, reg.DoctorInfo.Templet.Dept.Name, false);
            this.fpSpread1_Sheet1.SetValue(cnt, 4, reg.DoctorInfo.Templet.RegLevel.Name, false);
            this.fpSpread1_Sheet1.SetValue(cnt, 5, reg.DoctorInfo.Templet.Doct.Name, false);
            this.fpSpread1_Sheet1.SetValue(cnt, 6, reg.RegLvlFee.RegFee , false);
            this.fpSpread1_Sheet1.SetValue(cnt, 7, reg.RegLvlFee.OwnDigFee + reg.RegLvlFee.OthFee + reg.RegLvlFee.ChkFee, false);
            this.fpSpread1_Sheet1.Rows[cnt].Tag = reg;

            if (reg.IsSee)
            {
                this.fpSpread1_Sheet1.Rows[cnt].BackColor = Color.Cyan;
            }
            if (reg.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Back||
                reg.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Cancel)
            {
                this.fpSpread1_Sheet1.Rows[cnt].BackColor = Color.Red;
            }
        }
        
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        private int save()
        {
            #region 验证
            if (this.fpSpread1_Sheet1.RowCount == 0)
            {
                MessageBox.Show("没有挂号记录!", "提示");
                return -1;
            }

            int row = this.fpSpread1_Sheet1.ActiveRowIndex;

            //实体
            Neusoft.HISFC.Models.Registration.Register reg;

            reg = this.regMgr.GetByClinic((this.fpSpread1_Sheet1.Rows[row].Tag as Neusoft.HISFC.Models.Registration.Register).ID);
            if (reg == null || reg.ID == null || reg.ID == "")
            {
                //t.RollBack() ;
                MessageBox.Show("没有该挂号信息!" + this.regMgr.Err, "提示");
                return -1;
            }

            if (reg.Status != Neusoft.HISFC.Models.Base.EnumRegisterStatus.Cancel)
            {
                //t.RollBack() ;
                MessageBox.Show("该挂号信息不是作废号,不能取消作废!", "提示");
                return -1;
            }

            if (reg.BalanceOperStat.IsCheck)
            {
                MessageBox.Show("该挂号信息已经日结,不能取消作废!", "提示");
                return -1;
            }

            //恢复原来排班限额
            //如果原来更新限额,那么恢复限额
            if (reg.DoctorInfo.Templet.ID != null && reg.DoctorInfo.Templet.ID != "")
            {
                //现场号、预约号、特诊号


                bool IsReged = false, IsTeled = false, IsSped = false;

                if (reg.RegType == Neusoft.HISFC.Models.Base.EnumRegType.Pre)
                {
                    IsTeled = true; //预约号
                }
                else if (reg.RegType == Neusoft.HISFC.Models.Base.EnumRegType.Reg)
                {
                    IsReged = true;//现场号
                }
                else
                {
                    IsSped = true;//特诊号
                }

                int rtn = this.schMgr.AddLimit(reg.DoctorInfo.Templet.ID, IsReged, false, IsTeled, IsSped);
                if (rtn == -1)
                {
                   // t.RollBack();
                    MessageBox.Show(this.schMgr.Err, "提示");
                    return -1;
                }

                if (rtn == 0)
                {
                    //t.RollBack();
                    MessageBox.Show("已无排班信息,无法恢复限额!", "提示");
                    return -1;
                }
            }

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(regMgr.con);
            //SQLCA.BeginTransaction();

            try
            {
                this.regMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.regMgr.Update(Neusoft.HISFC.BizLogic.Registration.EnumUpdateStatus.Uncancel, reg) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("取消作废出错!" + this.regMgr.Err, "提示");
                    return -1;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return -1;
            }

            MessageBox.Show("取消作废成功!", "提示");

            this.Clear();

            return 0;
        }
        /// <summary>
        /// 清屏
        /// </summary>
        private void Clear()
        {
            if (this.fpSpread1_Sheet1.RowCount > 0)
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.RowCount);

            this.txtCardNo.Focus();
        }

        /// <summary>
        /// 处理快捷键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.S.GetHashCode())
            {
                this.save();

                return true;
            }
            else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.X.GetHashCode())
            {
                this.FindForm().Close();
            }
            else if (keyData == Keys.Escape)
            {
                this.FindForm().Close();
            }

            return base.ProcessDialogKey(keyData);
        }
        /// <summary>
        /// fp回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.save();
            }
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.save();

            return base.OnSave(sender, neuObject);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtRecipeNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
