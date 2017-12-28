using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Registration
{
    public partial class ucChangeDeptInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucChangeDeptInfo()
        {
            InitializeComponent();
        }
        #region 域
        /// <summary>
        /// 挂号管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Register regMgr = new Neusoft.HISFC.BizLogic.Registration.Register();
        /// <summary>
        /// 控制管理类
        /// </summary>
        private Neusoft.FrameWork.Management.ControlParam ctlMgr = new Neusoft.FrameWork.Management.ControlParam();

        /// <summary>
        /// 排班管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Schema schMgr = new Neusoft.HISFC.BizLogic.Registration.Schema();
        /// <summary>
        /// 费用
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        /// <summary>
        /// 分诊管理类
        /// </summary>
        //private Neusoft.HISFC.BizProcess.Integrate assMgr = new Neusoft.HISFC.BizLogic.Management.Nurse.Assign();
        /// <summary>
        /// 可退号天数
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

            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                this.neuSpread1_Sheet1.Columns[i].Locked = true;
            }

            #region 其他费处理
            ///其它费类型0：空调费1病历本费2：其他费
            /////{E9A82E01-222A-4455-B5DD-B7AE7CB731AA}
            string rtn = this.ctlMgr.QueryControlerInfo("400027");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "1";

            switch (rtn)
            {
                case "0":
                    {
                        //广州用
                        this.neuSpread1_Sheet1.Columns[8].Label = "床费";
                        break;
                    }
                case "1": //病历本费
                    {
                        this.neuSpread1_Sheet1.Columns[8].Label = "病历本费";
                        break;
                    }
                case "2": //其他费
                    {

                        this.neuSpread1_Sheet1.Columns[8].Label = "其他费";
                        break;

                    }
                default:
                    break;
            }
            #endregion
            


            return 0;
        }

        /// <summary>
        /// 添加患者挂号明细
        /// </summary>
        /// <param name="registers"></param>
        private void addRegister(ArrayList registers)
        {
            if (this.neuSpread1_Sheet1.RowCount > 0)
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.RowCount);

            Neusoft.HISFC.Models.Registration.Register obj;

            for (int i = registers.Count - 1; i >= 0; i--)
            {
                obj = (Neusoft.HISFC.Models.Registration.Register)registers[i];
                this.addRegister(obj);
            }
        }
        /// <summary>
        /// 不允许使用直接收费生成的号再进行挂号
        /// </summary>
        /// <param name="CardNO"></param>
        /// <returns></returns>
        private int ValidCardNO(string CardNO)
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParams = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            string cardRule = controlParams.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.NO_REG_CARD_RULES, false, "9");
            if (CardNO != "" && CardNO != string.Empty)
            {
                if (CardNO.Substring(0, 1) == cardRule)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("此号段为直接收费使用，不可以换科"), Neusoft.FrameWork.Management.Language.Msg("提示"));
                    return -1;
                }
            }
            return 1;
        }
        /// <summary>
        /// add a record to farpoint
        /// </summary>
        /// <param name="reg"></param>
        private void addRegister(Neusoft.HISFC.Models.Registration.Register reg)
        {
            this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.RowCount, 1);

            int cnt = this.neuSpread1_Sheet1.RowCount - 1;

            this.neuSpread1_Sheet1.SetValue(cnt, 0, reg.Name, false);
            this.neuSpread1_Sheet1.SetValue(cnt, 1, reg.Sex.Name, false);
            this.neuSpread1_Sheet1.SetValue(cnt, 2, reg.DoctorInfo.SeeDate.ToString(), false);
            this.neuSpread1_Sheet1.SetValue(cnt, 3, reg.DoctorInfo.Templet.Dept.Name, false);
            this.neuSpread1_Sheet1.SetValue(cnt, 4, reg.DoctorInfo.Templet.RegLevel.Name, false);
            this.neuSpread1_Sheet1.SetValue(cnt, 5, reg.DoctorInfo.Templet.Doct.Name, false);
            this.neuSpread1_Sheet1.SetValue(cnt, 6, reg.RegLvlFee.RegFee, false);
            //{E9A82E01-222A-4455-B5DD-B7AE7CB731AA}
            //this.neuSpread1_Sheet1.SetValue(cnt, 7, reg.RegLvlFee.OwnDigFee + reg.RegLvlFee.ChkFee + reg.RegLvlFee.OthFee, false);
            this.neuSpread1_Sheet1.SetValue(cnt, 7, reg.RegLvlFee.OwnDigFee + reg.RegLvlFee.ChkFee, false);
            this.neuSpread1_Sheet1.SetValue(cnt, 8, reg.RegLvlFee.OthFee, false);
            this.neuSpread1_Sheet1.SetValue(cnt, 9, Neusoft.FrameWork.Function.NConvert.ToInt32(reg.IsSee));
            this.neuSpread1_Sheet1.Rows[cnt].Tag = reg;

            if (reg.IsSee)
            {
                this.neuSpread1_Sheet1.Rows[cnt].BackColor = Color.LightCyan;
            }
            if (reg.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Back ||
                reg.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Cancel)
            {
                this.neuSpread1_Sheet1.Rows[cnt].BackColor = Color.MistyRose;
            }
        }

        protected virtual ArrayList GetRegedInfo(ref string errText)
        {
            ArrayList alRegcollection = new ArrayList();
            switch (this.neuLabel1.Text)
            {
                //    case "流水号":
                //        {
                //            // GetByClinic
                //            string clinicNo = this.txtCardNo.Text.Trim();
                //            if (clinicNo == "")
                //            {
                //                errText = "流水号不能为空!";
                //                this.txtCardNo.Focus();
                //                return null;
                //            }
                //            //{D7742D35-6162-4b30-8F60-1F22E48C271D}
                //            //cardNo = cardNo.PadLeft(HISFC.Integrate.Common.ControlParam.GetCardNOLen(), '0');
                //            //this.txtCardNo.Text = cardNo;

                //            DateTime permitDate = this.regMgr.GetDateTimeFromSysDateTime().AddDays(-this.PermitDays).Date;
                //            //检索患者有效号
                //            ArrayList almy = this.regMgr.QueryPatientList(clinicNo, "ALL");

                //            if (almy == null)
                //            {
                //                errText = "检索患者挂号信息时出错!" + this.regMgr.Err;
                //                return null;
                //            }

                //            ///移除超过限定时间的挂号信息

                //            foreach (Neusoft.HISFC.Models.Registration.Register obj in almy)
                //            {
                //                if (obj.DoctorInfo.SeeDate.Date < permitDate.Date) continue;

                //                alRegcollection.Add(obj);
                //            }



                //            break;
                //        }
                case "病历号":
                    {
                        string cardNo = this.txtCardNo.Text.Trim();
                        if (cardNo == "")
                        {
                            errText = "病历号不能为空!";
                            this.txtCardNo.Focus();
                            return null;
                        }
                        //{D7742D35-6162-4b30-8F60-1F22E48C271D}
                        cardNo = cardNo.PadLeft(10, '0');
                        this.txtCardNo.Text = cardNo;
                        
                        DateTime permitDate = this.regMgr.GetDateTimeFromSysDateTime().AddDays(-this.PermitDays).Date;
                        //检索患者有效号
                        alRegcollection = this.regMgr.QueryUnionNurse(cardNo, permitDate);

                        if (alRegcollection == null)
                        {
                            errText = "检索患者挂号信息时出错!" + this.regMgr.Err;
                            return null;
                        }

                        break;
                    }
                //    case "处方号":
                //        {
                //            ArrayList almy = new ArrayList();
                //            string recipeNo = this.txtCardNo.Text.Trim();
                //            if (recipeNo == "")
                //            {
                //                errText = "处方号不能为空!";
                //                this.txtCardNo.Focus();
                //                return null;
                //            }

                //            DateTime permitDate = this.regMgr.GetDateTimeFromSysDateTime().AddDays(-this.PermitDays).Date;
                //            //检索患者有效号
                //            almy = this.regMgr.QueryByRecipe(recipeNo);
                //            if (almy == null)
                //            {
                //                errText = "检索患者挂号信息时出错!" + this.regMgr.Err;
                //                return null;
                //            }


                //            ///移除超过限定时间的挂号信息
                //            ///
                //            foreach (Neusoft.HISFC.Models.Registration.Register obj in almy)
                //            {
                //                if (obj.DoctorInfo.SeeDate.Date < permitDate.Date) continue;

                //                alRegcollection.Add(obj);
                //            }


                //            break;
                //        }
                default:
                    {
                        break;
                    }

            }
            return alRegcollection;
        }

        /// <summary>
        /// 专科
        /// </summary>
        /// <param name="regObj">挂号实体</param>
        /// <returns></returns>
        protected virtual int ChangDept()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0) return -1;

            Neusoft.HISFC.Models.Registration.Register regObj = new Neusoft.HISFC.Models.Registration.Register();
            regObj = this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Registration.Register;

            if (regObj != null)
            {
                #region 屏蔽专家专科号不能操作{795CDDA4-8257-4868-B6FB-52CA4281A53E} by guanyx
                //if (!string.IsNullOrEmpty(regObj.DoctorInfo.Templet.ID))
                //{
                //    MessageBox.Show("专家或专科号不允许换科,请进行退号重新挂号操作");
                //    return -1;
                //}
                #endregion
                if (regObj.IsSee)
                {
                    MessageBox.Show("该患者已经看诊,不能进行换科,请核实");
                    return -1;
                }

                if (regObj.IsTriage)
                {
                    MessageBox.Show("该患者已经分诊,请到护士台直接转科", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
                if (regObj.Status != Neusoft.HISFC.Models.Base.EnumRegisterStatus.Valid)
                {
                    MessageBox.Show("该该号已经退了,不能换科");
                    return -1;
                }

            }

            Forms.frmChangeDept frmChangeDept = new Neusoft.HISFC.Components.Registration.Forms.frmChangeDept();
            frmChangeDept.ChangeDeptEvent += new EventHandler(frmChangeDept_ChangeDeptEvent);
            frmChangeDept.MyRegObj = regObj;
            DialogResult result = frmChangeDept.ShowDialog();
            //if (result == DialogResult.OK)
            //{ 
            //}
            return 1;
        }
        /// <summary>
        /// 界面赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmChangeDept_ChangeDeptEvent(object sender, EventArgs e)
        {
            ArrayList al = sender as ArrayList;
            Neusoft.FrameWork.Models.NeuObject myDept = al[0] as Neusoft.FrameWork.Models.NeuObject;
            Neusoft.FrameWork.Models.NeuObject myDoct = al[1] as Neusoft.FrameWork.Models.NeuObject;
            Neusoft.HISFC.Models.Registration.Register regObj = this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Registration.Register;
            regObj.DoctorInfo.Templet.Dept = myDept;
            regObj.DoctorInfo.Templet.Doct = myDoct;
            this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag = regObj;
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 3].Text = myDept.Name;
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 5].Text = myDoct.Name;

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
                int rowCount = neuSpread1_Sheet1.RowCount;
                if (rowCount > 0)
                {
                    this.neuSpread1_Sheet1.Rows.Remove(0, rowCount);
                }

                string errText = string.Empty;
                this.al = this.GetRegedInfo(ref errText);
                if (this.al == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(errText));
                    return;
                }

                if (this.al.Count == 0)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("该患者没有可换科号!"));
                    this.txtCardNo.Focus();
                    return;
                }
                else
                {
                    this.addRegister(al);


                    this.neuSpread1.Focus();
                    this.neuSpread1_Sheet1.ActiveRowIndex = 0;
                    //this.neuSpread1_Sheet1.AddSelection(0, 0, 1, 0);
                }
            }
        }
        /// <summary>
        /// 双击专科
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.neuSpread1_Sheet1.ActiveRowIndex >= 0)
            {
                //Neusoft.HISFC.Models.Registration.Register regObj = new Neusoft.HISFC.Models.Registration.Register();
                //regObj = this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Registration.Register;
                ////if (regObj != null)
                //{
                //    if (!string.IsNullOrEmpty( regObj.DoctorInfo.Templet.ID))
                //    {
                //        MessageBox.Show("专家或专科号不允许换科,请进行退号重新挂号操作");
                //        return;
                //    }

                //    if (regObj.IsSee)
                //    {
                //        MessageBox.Show("该患者已经看诊,不能进行换科,请核实");
                //        return;
                //    }
                //    if (regObj.Status != Neusoft.HISFC.Models.Base.EnumRegisterStatus.Valid)
                //    {
                //        MessageBox.Show("该该号已经退了,不能换科");
                //        return;
                //    }

                //}
                if (this.ChangDept() < 0)
                {
                    return;
                }
            }
        }

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        private event EventHandler ReadCardEvent;
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("换科", "换科", (int)(int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.K科室, true, false, null);
            ReadCardEvent += new EventHandler(ucChangeDeptInfo_ReadCardEvent);
            toolBarService.AddToolButton("读卡", "读院内卡", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找人员, true, false, this.ReadCardEvent);
            return toolBarService;
        }

        private string cardno = "";
        private bool isNewCard = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();
        /// <summary>
        /// 读卡操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucChangeDeptInfo_ReadCardEvent(object sender, EventArgs e)
        {
            if (icreader.GetConnect())
            {
                cardno = icreader.ReaderICCard();
                if (cardno == "0000000000")
                {
                    isNewCard = true;
                    MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                }
                else
                {
                    this.txtCardNo.Text = cardno;
                    this.txtCardNo_KeyDown(this.txtCardNo, new KeyEventArgs(Keys.Enter));
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
            }
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "换科":
                    {
                        this.ChangDept();
                        break;
                    }
                default:
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }
    }
}
