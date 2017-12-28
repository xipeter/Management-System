using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse.Inject
{
    /// <summary>
    /// [功能描述: 注射登记]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007-08-20]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary> 
    public partial class ucInject : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 注射项目分解
        /// </summary>
        private Neusoft.HISFC.BizLogic.Nurse.InjectManager.Decompound decompound = new Neusoft.HISFC.BizLogic.Nurse.InjectManager.Decompound();
        /// <summary>
        /// 注射过程管理
        /// </summary>
        private Neusoft.HISFC.BizLogic.Nurse.InjectManager.InjectRecordMgr irManager = new Neusoft.HISFC.BizLogic.Nurse.InjectManager.InjectRecordMgr();

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            //HIS 5.0 重构移植 该功能屏蔽
            //toolBarService.AddToolButton("床位划价", "床位划价", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.H划价保存, true, false, null);

            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "床位划价":
                    //HIS 5.0 重构移植 该功能屏蔽
                    this.BedFee();
                    break;
                default :
                    break;
            }
        }

        private void BedFee()
        {
            //HIS 5.0 重构移植 该功能屏蔽

            //Neusoft.HISFC.Components.OutpatientFee.Controls.ucCharge charge = new Neusoft.HISFC.Components.OutpatientFee.Controls.ucCharge();

            //Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(charge);
        }

        private Neusoft.HISFC.Models.Registration.Register patient;

        public ucInject()
        {
            InitializeComponent();            
        }

        protected override int OnSave(object sender, object neuObject)
        {
            List<Neusoft.HISFC.Models.Nurse.InjectInfo> itemList = this.GetAlreadyPrecontractInfos();
            if (itemList == null || itemList.Count == 0)
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //trans.BeginTransaction();

            this.decompound.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.decompound.InsertPrecontractInejctItem(itemList) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存失败"));
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功"));

            this.ClearNeuspread1();
            this.ClearNeuspread2();
            this.InitNeuspread1();
            this.InitNeuspread2();
            this.ucPatientInfo1.ClearPatientPanel();
            return 1;
        }

        private void ucPatientInfo1_PatientEvent(Neusoft.HISFC.Models.Registration.Register register)
        {
            if (register == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("Register参数错误"));
                return;
            }

            this.patient = register;

            List<Neusoft.HISFC.Models.Nurse.InjectInfo> itemList = this.decompound.QueryItemListByCardNoAndClinicCode(register.PID.CardNO, register.ID);
            if (itemList == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取患者注射信息失败"));
                return;
            }

            this.ClearNeuspread1();
            this.FillFarPoint1(itemList);
            this.DrowCombo();
        }

        /// <summary>
        /// 清空FarPoint1
        /// </summary>
        private void ClearNeuspread1()
        {
            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.Rows.Count);
            }
        }

        private void FillFarPoint1(List<Neusoft.HISFC.Models.Nurse.InjectInfo> injectInfos)
        {
            foreach (Neusoft.HISFC.Models.Nurse.InjectInfo injectInfo in injectInfos)
            {
                int rowIndex = this.neuSpread1_Sheet1.Rows.Count;
                this.neuSpread1_Sheet1.Rows.Add(rowIndex, 1);

                this.neuSpread1_Sheet1.SetText(rowIndex, 0, injectInfo.Order.ReciptNO);
                this.neuSpread1_Sheet1.SetText(rowIndex, 1, injectInfo.Order.SequenceNO.ToString());
                this.neuSpread1_Sheet1.SetText(rowIndex, 2, injectInfo.Order.ID);
                this.neuSpread1_Sheet1.SetText(rowIndex, 3, injectInfo.Order.Combo.ID);
                this.neuSpread1_Sheet1.SetText(rowIndex, 4, injectInfo.Order.Item.ID);
                this.neuSpread1_Sheet1.SetText(rowIndex, 5, injectInfo.Order.Item.Name);

                this.neuSpread1_Sheet1.SetText(rowIndex, 7, injectInfo.Order.Item.Specs);
                this.neuSpread1_Sheet1.SetText(rowIndex, 8, injectInfo.Order.Item.Qty.ToString());
                this.neuSpread1_Sheet1.SetText(rowIndex, 9, injectInfo.Quality.Name);
                this.neuSpread1_Sheet1.SetText(rowIndex, 10, injectInfo.Dosage.Name);
                this.neuSpread1_Sheet1.SetText(rowIndex, 11, injectInfo.Order.Frequency.ID);
                this.neuSpread1_Sheet1.SetText(rowIndex, 12, injectInfo.Order.Frequency.Name);
                this.neuSpread1_Sheet1.SetText(rowIndex, 13, injectInfo.Order.Usage.ID);
                this.neuSpread1_Sheet1.SetText(rowIndex, 14, injectInfo.Order.Usage.Name);
                this.neuSpread1_Sheet1.SetText(rowIndex, 15, injectInfo.Order.InjectCount.ToString());
                this.neuSpread1_Sheet1.SetText(rowIndex, 16, injectInfo.Order.DoseOnce.ToString());
                this.neuSpread1_Sheet1.SetText(rowIndex, 17, injectInfo.Order.DoseUnit.ToString());

                this.neuSpread1_Sheet1.SetText(rowIndex, 18, injectInfo.BaseDose.ToString());
                this.neuSpread1_Sheet1.SetText(rowIndex, 19, injectInfo.Order.Item.PackQty.ToString());
                this.neuSpread1_Sheet1.SetText(rowIndex, 20, (injectInfo.IsMainDrug ? "是" : "否"));
                this.neuSpread1_Sheet1.SetText(rowIndex, 21, injectInfo.GlassNum.ToString());

                this.neuSpread1_Sheet1.Rows[rowIndex].Tag = injectInfo;
                //this.neuSpread1_Sheet1.SetTag(rowIndex, 0, injectInfo);
            }
        }

        private void DrowCombo()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
            {
                return;
            }

            Neusoft.HISFC.Components.Common.Classes.Function.DrawCombo(this.neuSpread1_Sheet1, 3, 6);
        }

        private void neuSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            this.SelectionChanged(1);
        }

        /// <summary>
        /// 选择变化
        /// </summary>
        private void SelectionChanged(int which)
        {
            if (which == 1)
            {
                int rowIndex = this.neuSpread1_Sheet1.ActiveRowIndex;
                int start = 0;
                int end = 0;
                string strComboNo = this.neuSpread1_Sheet1.GetText(rowIndex, 3).Trim();
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    if (this.neuSpread1_Sheet1.GetText(i, 3).Trim().Equals(strComboNo))
                    {
                        start = i;
                        break;
                    }
                }
                end = start;
                for (int t = start; t < this.neuSpread1_Sheet1.Rows.Count; t++)
                {
                    if (!this.neuSpread1_Sheet1.GetText(t, 3).Trim().Equals(strComboNo))
                    {
                        end = t;
                        break;
                    }
                    end++;
                }
                this.neuSpread1_Sheet1.AddSelection(start, -1, end - start, 0);


            }
            else
            {
                int rowIndex = this.neuSpread2_Sheet1.ActiveRowIndex;
                int start = 0;
                int end = 0;
                string strComboNo = this.neuSpread2_Sheet1.GetText(rowIndex, 4).Trim();
                for (int i = 0; i < this.neuSpread2_Sheet1.Rows.Count; i++)
                {
                    if (this.neuSpread2_Sheet1.GetText(i, 4).Trim().Equals(strComboNo))
                    {
                        start = i;
                        break;
                    }
                }
                end = start;
                for (int t = start; t < this.neuSpread2_Sheet1.Rows.Count; t++)
                {
                    if (!this.neuSpread2_Sheet1.GetText(t, 4).Trim().Equals(strComboNo))
                    {
                        end = t;
                        break;
                    }
                    end++;
                }
                this.neuSpread2_Sheet1.AddSelection(start, -1, end - start, 0);
            }
        }



        private void InitNeuspread1()
        {
            this.neuSpread1_Sheet1.Columns[0].Visible = false;
            this.neuSpread1_Sheet1.Columns[1].Visible = false;
            this.neuSpread1_Sheet1.Columns[2].Visible = false;
            this.neuSpread1_Sheet1.Columns[3].Visible = false;
            this.neuSpread1_Sheet1.Columns[4].Visible = false;
            this.neuSpread1_Sheet1.Columns[11].Visible = false;
            this.neuSpread1_Sheet1.Columns[13].Visible = false;
            this.neuSpread1_Sheet1.Columns[18].Visible = false;
            this.neuSpread1_Sheet1.Columns[19].Visible = false;
        }

        private void InitNeuspread2()
        {
            this.neuSpread2_Sheet1.Columns[0].Visible = false;
            this.neuSpread2_Sheet1.Columns[1].Visible = false;

            this.neuSpread2_Sheet1.Columns[4].Locked = true;
            this.neuSpread2_Sheet1.Columns[7].Locked = true;
            this.neuSpread2_Sheet1.Columns[8].Locked = true;
            this.neuSpread2_Sheet1.Columns[9].Locked = true;
            this.neuSpread2_Sheet1.Columns[10].Locked = true;
            this.neuSpread2_Sheet1.Columns[11].Locked = true;
            this.neuSpread2_Sheet1.Columns[12].Locked = true;
            this.neuSpread2_Sheet1.Columns[13].Locked = true;
            this.neuSpread2_Sheet1.Columns[14].Locked = true;
            this.neuSpread2_Sheet1.Columns[15].Locked = true;
        }

        private void ucInject_Load(object sender, EventArgs e)
        {
            this.InitNeuspread1();
            this.InitNeuspread2();
        }


        private List<Neusoft.HISFC.Models.Nurse.InjectInfo> GetPrecontractInjectInfos()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
            {
                return null;
            }

            List<Neusoft.HISFC.Models.Nurse.InjectInfo> itemList = new List<Neusoft.HISFC.Models.Nurse.InjectInfo>();
            string strCombo = this.neuSpread1_Sheet1.GetText(this.neuSpread1_Sheet1.ActiveRowIndex, 3).Trim();
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.GetText(i, 3).Trim().Equals(strCombo))
                {
                    itemList.Add(this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Nurse.InjectInfo);
                }
            }
            return itemList;
        }

        private int GeneratePrecontractInjectInfos(List<Neusoft.HISFC.Models.Nurse.InjectInfo> itemList)
        {
            if (itemList == null || itemList.Count == 0)
            {
                return -1;
            }
            int k1 = 0;
            int k2 = 0;

            for (int i = 1; i <= itemList[0].Order.InjectCount; i++)
            {
                foreach (Neusoft.HISFC.Models.Nurse.InjectInfo inject in itemList)
                {
                    this.FillNeuspread2(inject, i, itemList[0].Order.InjectCount);
                    k1++;
                }
                this.neuSpread2_Sheet1.Cells[k2, 2].RowSpan = k1;
                this.neuSpread2_Sheet1.Cells[k2, 3].RowSpan = k1;
                this.neuSpread2_Sheet1.Cells[k2, 4].RowSpan = k1;
                this.neuSpread2_Sheet1.Cells[k2, 5].RowSpan = k1;
                this.neuSpread2_Sheet1.Cells[k2, 6].RowSpan = k1;

                k2 += k1;
                k1 = 0;
            }



            //暂时写死了，合并第二列,预约时间
            //合并第五列，注射类型
            //合并第六列，编号
            //this.neuSpread2_Sheet1.Cells[0, 2].RowSpan = itemList[0].Order.InjectCount;
            //this.neuSpread2_Sheet1.Cells[0, 3].RowSpan = itemList[0].Order.InjectCount;
            //this.neuSpread2_Sheet1.Cells[0, 4].RowSpan = itemList[0].Order.InjectCount;
            //this.neuSpread2_Sheet1.Cells[0, 5].RowSpan = itemList[0].Order.InjectCount;
            //this.neuSpread2_Sheet1.Cells[0, 6].RowSpan = itemList[0].Order.InjectCount;
            
            //for (int i = 0; i < itemList[0].Order.InjectCount; i++)
            //{
            //    //this.neuSpread2_Sheet1.Cells[0 + itemList[0].Order.InjectCount, 2].RowSpan = itemList[0].Order.InjectCount;
            //    //this.neuSpread2_Sheet1.Cells[0 + itemList[0].Order.InjectCount, 3].RowSpan = itemList[0].Order.InjectCount;
            //    //this.neuSpread2_Sheet1.Cells[0 + itemList[0].Order.InjectCount, 4].RowSpan = itemList[0].Order.InjectCount;
            //    //this.neuSpread2_Sheet1.Cells[0 + itemList[0].Order.InjectCount, 5].RowSpan = itemList[0].Order.InjectCount;
            //    //this.neuSpread2_Sheet1.Cells[0 + itemList[0].Order.InjectCount, 6].RowSpan = itemList[0].Order.InjectCount;
            //    this.neuSpread2_Sheet1.Cells[i + itemList[0].Order.InjectCount, 2].RowSpan = itemList[0].Order.InjectCount;
            //    this.neuSpread2_Sheet1.Cells[i + itemList[0].Order.InjectCount, 3].RowSpan = itemList[0].Order.InjectCount;
            //    this.neuSpread2_Sheet1.Cells[i + itemList[0].Order.InjectCount, 4].RowSpan = itemList[0].Order.InjectCount;
            //    this.neuSpread2_Sheet1.Cells[i + itemList[0].Order.InjectCount, 5].RowSpan = itemList[0].Order.InjectCount;
            //    this.neuSpread2_Sheet1.Cells[i + itemList[0].Order.InjectCount, 6].RowSpan = itemList[0].Order.InjectCount;

            //}

            return 0;
        }

        private void ClearNeuspread2()
        {
            if (this.neuSpread2_Sheet1.Rows.Count > 0)
            {
                this.neuSpread2_Sheet1.Rows.Remove(0, this.neuSpread2_Sheet1.Rows.Count);
            }
        }

        private void FillNeuspread2(Neusoft.HISFC.Models.Nurse.InjectInfo inject, int number, int rowspan)
        {
            if (inject == null)
            {
                return;
            }
            int rowIndex = this.neuSpread2_Sheet1.Rows.Count;

            this.neuSpread2_Sheet1.Rows.Add(rowIndex, 1);
            this.neuSpread2_Sheet1.SetText(rowIndex, 0, "");//ID
            this.neuSpread2_Sheet1.SetText(rowIndex, 1, "");//注射单号

            this.neuSpread2_Sheet1.SetText(rowIndex, 4, number.ToString());//注射次数

            this.neuSpread2_Sheet1.SetText(rowIndex, 7, inject.Order.Item.Name);//项目名称
            this.neuSpread2_Sheet1.SetText(rowIndex, 9, inject.Order.Item.Specs.ToString());//规格
            this.neuSpread2_Sheet1.SetText(rowIndex, 10, inject.Order.Item.Qty.ToString());//数量
            this.neuSpread2_Sheet1.SetText(rowIndex, 11, inject.Order.Frequency.Name);//频次名称
            this.neuSpread2_Sheet1.SetText(rowIndex, 12, inject.Order.Usage.Name);//用法名称
            this.neuSpread2_Sheet1.SetText(rowIndex, 13, inject.Order.InjectCount.ToString());//院注次数
            this.neuSpread2_Sheet1.SetText(rowIndex, 14, inject.Order.DoseOnce.ToString());//一次用量
            this.neuSpread2_Sheet1.SetText(rowIndex, 15, inject.Order.DoseUnit);//一次用量单位

            //每行的第0列存放对象

            this.neuSpread2_Sheet1.Rows[rowIndex].Tag = inject;

            //this.neuSpread2_Sheet1.SetTag(rowIndex, 0, inject);
        }

        private void btnDetach_Click(object sender, EventArgs e)
        {
            this.ClearNeuspread2();

            if (this.GeneratePrecontractInjectInfos(this.GetPrecontractInjectInfos()) == 0)
            {
                Neusoft.HISFC.Components.Common.Classes.Function.DrawCombo(this.neuSpread2_Sheet1, 4, 8);
            }
        }

        private void neuSpread2_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            //this.SelectionChanged(2);
        }

        /// <summary>
        /// 得到所有已经预约的信息neuspread2_sheet1控件
        /// </summary>
        /// <returns></returns>
        private List<Neusoft.HISFC.Models.Nurse.InjectInfo> GetAlreadyPrecontractInfos()
        {
            List<Neusoft.HISFC.Models.Nurse.InjectInfo> itemList = new List<Neusoft.HISFC.Models.Nurse.InjectInfo>();

            string strDatetime = this.neuSpread2_Sheet1.GetText(0, 2);
            string strPreNumber = this.neuSpread2_Sheet1.GetText(0, 3);
            string strInjectType = this.neuSpread2_Sheet1.GetText(0, 5);
            string strInjectNumber = this.neuSpread2_Sheet1.GetText(0, 6);

            Neusoft.HISFC.Models.Nurse.InjectInfo inject;

            for (int i = 0; i < this.neuSpread2_Sheet1.Rows.Count; i++)
            {
                //inject = new Neusoft.HISFC.Models.Nurse.InjectInfo();
                inject = this.neuSpread2_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Nurse.InjectInfo;
                //inject = this.neuSpread2_Sheet1.GetTag(i, 0) as Neusoft.HISFC.Models.Nurse.InjectInfo;
                /*
                 * //暂时写死了，合并第二列,预约时间
                   //合并第五列，注射类型
                   //合并第六列，编号
                 this.neuSpread2_Sheet1.Cells[0, 2].RowSpan = itemList[0].Order.InjectCount;                
                 this.neuSpread2_Sheet1.Cells[0, 5].RowSpan = itemList[0].Order.InjectCount;
                 this.neuSpread2_Sheet1.Cells[0, 6].RowSpan = itemList[0].Order.InjectCount;                 
                 */
                if (this.neuSpread2_Sheet1.GetText(i, 3).ToString().Trim().Equals(""))
                {
                    inject.PrecontractOrder = strPreNumber;//预约注射序号
                }
                else
                {
                    inject.PrecontractOrder = this.neuSpread2_Sheet1.GetText(i, 3);//预约注射序号
                    strPreNumber = this.neuSpread2_Sheet1.GetText(i, 3);//预约注射序
                }
                //inject.PrecontractOrder = this.neuSpread2_Sheet1.GetText(i, 3);//预约注射序号

                inject.Name = this.neuSpread2_Sheet1.GetText(i, 4);//注射次数,没地方了，用Name属性

                if (this.neuSpread2_Sheet1.GetText(i, 2).ToString().Equals(""))
                {
                    inject.PrecontractDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(strDatetime);
                }
                else
                {
                    inject.PrecontractDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread2_Sheet1.GetText(i, 2));
                    strDatetime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread2_Sheet1.GetText(i, 2)).ToString();
                }
                //inject.PrecontractDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread2_Sheet1.GetText(i, 2));
                if (this.neuSpread2_Sheet1.GetText(i, 5).Trim().Equals(""))
                {
                    switch (strInjectType)
                    {
                        case "床位":
                            inject.InjectType = "1";
                            break;
                        case "座位":
                            inject.InjectType = "2";
                            break;
                        case "其他":
                            inject.InjectType = "3";
                            break;
                        default:
                            inject.InjectType = "";
                            break;
                    }
                }
                else
                {

                    switch (this.neuSpread2_Sheet1.GetText(i, 5).Trim())
                    {
                        case "床位":
                            inject.InjectType = "1";
                            strInjectType = "床位";
                            break;
                        case "座位":
                            inject.InjectType = "2";
                            strInjectType = "座位";
                            break;
                        case "其他":
                            inject.InjectType = "3";
                            strInjectType = "其他";
                            break;
                        default:
                            inject.InjectType = "";
                            break;
                    }
                }
                if (this.neuSpread2_Sheet1.GetText(i, 6).ToString().Trim().Equals(""))
                {
                    inject.InjectTypeNumber = strInjectNumber;//预约注射序号
                }
                else
                {
                    inject.InjectTypeNumber = this.neuSpread2_Sheet1.GetText(i, 6);//预约注射序号
                    strInjectNumber = this.neuSpread2_Sheet1.GetText(i, 6);//预约注射序
                }
                //inject.InjectTypeNumber = this.neuSpread2_Sheet1.GetText(i, 6);

                inject.Order.Patient.Name = this.patient.Name;//患者姓名
                inject.Order.Patient.Sex.Name = this.patient.Sex.Name;//患者性别
                inject.Order.Patient.Birthday = this.patient.Birthday;//出生日期

                inject.Order.Patient.PID.CaseNO = this.patient.ID;//门诊流水号
                inject.Order.Patient.PID.CardNO = this.patient.PID.CardNO;//病历号

                inject.Order.RegTime = this.patient.DoctorInfo.SeeDate;//挂号日期
                //挂号科室编码
                //挂号科室名称
                inject.Order.ReciptDept.ID = this.patient.DoctorInfo.Templet.Dept.ID;//看诊科室编码
                inject.Order.ReciptDept.Name = this.patient.DoctorInfo.Templet.Dept.Name;//看诊科室名称
                inject.Order.ReciptDoctor.ID = this.patient.DoctorInfo.Templet.Doct.ID;//看诊科室名称
                inject.Order.ReciptDoctor.Name = this.patient.DoctorInfo.Templet.Doct.Name;//看诊医生名称

                inject.OperEnv.ID = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).ID;
                inject.OperEnv.Name = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).Name;
                inject.OperEnv.OperTime = this.decompound.GetDateTimeFromSysDateTime();

                this.neuSpread2_Sheet1.Rows[i].Tag = inject;
                //this.neuSpread2_Sheet1.SetTag(i, 0, inject);

                itemList.Add(inject.Clone());
            }
            return itemList;
        }

        private void neuSpread2_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            //(this.neuSpread2_Sheet1.GetTag(e.Row,e.Column) as Neusoft.HISFC.Models.Nurse.InjectInfo).PrecontractDate =             
        }
    }
}