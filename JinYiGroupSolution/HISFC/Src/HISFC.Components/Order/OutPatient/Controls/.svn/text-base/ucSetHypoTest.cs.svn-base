using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.OutPatient.Controls
{
    /// <summary>
    /// 功    能：填写皮试结果
    /// 编 写 人：牛鑫元
    /// 编写时间：2010-6-11
    /// </summary>
    public partial class ucSetHypoTest : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSetHypoTest()
        {
            InitializeComponent();
        }

        #region 变量域
        /// <summary>
        /// 门诊医嘱业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Order.OutPatient.Order orderBizLogic = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();

        /// <summary>
        /// 挂号综合业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        ///综合管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 科室帮助类
        /// </summary>
        Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();


        #endregion

        #region 属性

        #endregion

        #region 方法
        /// <summary>
        /// 查询有皮试的且没有收费和作废的挂号记录
        /// </summary>
        /// <returns></returns>
        protected virtual int QueryHytoRecord(string cardNO, string beginDtime, string endTime)
        {
            List<Neusoft.FrameWork.Models.NeuObject> personList = this.orderBizLogic.QueryHytoRecord(cardNO, beginDtime, endTime);
            if (personList == null)
            {
                MessageBox.Show("查询皮试患者信息出错" + this.orderBizLogic.Err);
                return -1;
            }

            //显示患者基本信息
            //添加树
            this.tvRegRecord.Nodes.Clear();

            if (personList.Count == 0)
            {
                return -1;
            }

            //根节点
            TreeNode rootNode = new TreeNode("挂号信息",0,0);
            //rootNode.Text = "挂号信息";
            rootNode.Tag = "AAAA";
            //循环添加挂号信息
            foreach (Neusoft.FrameWork.Models.NeuObject item in personList)
            {
                TreeNode secondNode = new TreeNode(item.ID + "/" + item.Memo, 2, 4) ;
                //secondNode.Text = item.ID + "/" + item.Memo;
                secondNode.Tag = item;

                rootNode.Nodes.Add(secondNode);
            }

            rootNode.ExpandAll();

            this.tvRegRecord.Nodes.Add(rootNode);

            

            return 1;

        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        /// <param name="cardNO"></param>
        /// <returns></returns>
        protected virtual int ShowPatientInfo(string cardNO)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.radtIntegrate.QueryComPatientInfo(cardNO);
            if (patientInfo == null)
            {
                MessageBox.Show("查询患者信息出错" + this.radtIntegrate.Err);
                return -1;
            }

            this.txtName.Text = patientInfo.Name;
            this.txtSex.Text = patientInfo.Sex.Name;
            this.txtBirthday.Text = patientInfo.Birthday.ToShortDateString();

            
            return 1;
        }
        

        /// <summary>
        /// 显示医嘱信息
        /// </summary>
        /// <param name="cardNO"></param>
        /// <param name="clinicNO"></param>
        /// <returns></returns>
        protected virtual int ShowOutpatientOrder(string cardNO, string clinicNO)
        {
            this.neuSpread1_Sheet1.Rows.Count = 0; 

            ArrayList alOrder = this.orderBizLogic.QueryOrderByCardNOClinicNO(cardNO, clinicNO);

            if (alOrder == null)
            {
                MessageBox.Show("查询医嘱信息失败");
                return 1;
            }

            //Neusoft.HISFC.Components.Common.Classes.Function.ShowOrder(this.neuSpread1_Sheet1, alOrder, Neusoft.HISFC.Models.Base.ServiceTypes.C);

            for (int i = 0; i < alOrder.Count; i++)
            {
                Neusoft.HISFC.Models.Order.OutPatient.Order order = alOrder[i] as Neusoft.HISFC.Models.Order.OutPatient.Order;
                this.neuSpread1_Sheet1.AddRows(0, 1);

                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.SEE_NO].Text = order.SeeNO.ToString();
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.SEQUENCE_NO].Text = order.ID;
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.CLINIC_CODE].Text = order.Patient.ID;
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.CARD_NO].Text = order.Patient.PID.CardNO;
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.REG_DATE].Text = order.RegTime.ToString();
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.DEPT_CODE].Text = this.deptHelper.GetName(order.ReciptDept.ID);
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.ITEM_NAME].Text = order.Item.Name;
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.SPECS].Text = order.Item.Specs;
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.FEE_CODE].Text = order.Item.MinFee.ID;
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.UNIT_PRICE].Text = order.Item.Price.ToString();
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.QTY].Text = order.Qty.ToString();
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.ONCE_DOSE].Text = order.DoseOnce.ToString();
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.ONCE_UNIT].Text = order.DoseUnit;
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.FREQUENCY_NAME].Text = order.Frequency.Name;
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.USAGE_NAME].Text = order.Usage.Name;
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.HYPOTEST].Text = this.GetHyteName(order.HypoTest);
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.DOCT_NAME].Text = order.ReciptDoctor.Name;
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.DOCT_DPCD].Text = this.deptHelper.GetName(order.ReciptDept.ID);
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.OPER_DATE].Text = order.MOTime.ToString();
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.EMC_FLAG].Value = order.IsEmergency;
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.ITEM_UNIT].Text = order.Unit;
                this.neuSpread1_Sheet1.Cells[0, (int)EnumColumn.EXEC_DPNM].Text = this.deptHelper.GetName(order.ExeDept.ID);
                if (order.HypoTest == 3)
                {
                    this.neuSpread1_Sheet1.Rows[0].ForeColor = Color.Red;
                }
                else
                {
                    this.neuSpread1_Sheet1.Rows[0].ForeColor = Color.Black;
                }
                this.neuSpread1_Sheet1.Rows[0].Tag = order;



            }
            

            return 1;

        }

        /// <summary>
        /// 设置表可编辑性
        /// </summary>
        protected virtual void SetFarpointFarmat()
        {
            for (int i = 1; i < this.neuSpread1_Sheet1.ColumnCount; i++)
            {
                this.neuSpread1_Sheet1.Columns[i].Locked = true;

            }

            this.neuSpread1_Sheet1.Columns[(int)EnumColumn.SEE_NO].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)EnumColumn.SEQUENCE_NO].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)EnumColumn.FEE_CODE].Visible = false;
        }

        /// <summary>
        /// 初始化信息
        /// </summary>
        /// <returns></returns>
        private int InitInfo()
        {
            ArrayList alDept = this.managerIntegrate.GetDepartment();

            if (alDept == null)
            {
                MessageBox.Show("查询科室信出错");
                return -1;
            }

            this.deptHelper.ArrayObject = alDept;

            this.tvRegRecord.ImageList = this.tvRegRecord.groupImageList;
            return 1;
 
        }

        /// <summary>
        /// 清空
        /// </summary>
        protected virtual void Clear()
        {
            this.tvRegRecord.Nodes.Clear();

            this.neuSpread1_Sheet1.Rows.Count = 0;

            this.txtBirthday.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtSex.Text = string.Empty;
        }

        /// <summary>
        /// 皮试代码转名称
        /// </summary>
        /// <param name="HyteID"></param>
        /// <returns></returns>
        private string GetHyteName(int HyteID)
        {
            string hyteName = string.Empty;
            switch (HyteID)
            {
                case 1:
                    {
                        hyteName = "不需要皮试";
                        break;
                    }
                case 2:
                    {
                        hyteName = "需皮试";
                        break;
                    }
                case 3:
                    {
                        hyteName = "皮试阳性";
                        break;
                    }
                case 4:
                    {
                        hyteName = "皮试阴性";
                        break;
                    }
                default:
                    break;
            }
            return hyteName;
        }

        protected virtual int ModifyHytoResult()
        {
            int count = 0;
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                bool isSelected = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value);
                if (isSelected)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                MessageBox.Show("请选择要修改的医嘱信息");
                return -1;
            }

            Forms.frmHypoTest frmHypoTest = new Neusoft.HISFC.Components.Order.OutPatient.Forms.frmHypoTest();

            frmHypoTest.rb1.Enabled = false;
            //frmHypoTest.rb3.Enabled = false;
            //frmHypoTest.rb4.Checked = true;
            DialogResult r = frmHypoTest.ShowDialog();

            string hytoResult = frmHypoTest.Hypotest.ToString();

            Neusoft.FrameWork.Models.NeuObject obj = this.tvRegRecord.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;

            if (obj == null)
            {
                return -1;
            }



            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                bool isSelected = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value);
                if (isSelected)
                {
                    int intHytoResult = Neusoft.FrameWork.Function.NConvert.ToInt32(hytoResult);

                    Neusoft.HISFC.Models.Order.OutPatient.Order order = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;


                    //校验医嘱有效性 防止并发

                    ArrayList alNowOrder = this.orderBizLogic.QueryOrderByKey(order.SeeNO, order.ID);

                    if (alNowOrder == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("查询医嘱当前状态出错");
                        this.ShowOutpatientOrder(obj.ID, obj.Name);
                        return -1;
                    }

                    if (alNowOrder.Count == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("没有查询到要修改皮试结果的医嘱信息");
                        this.ShowOutpatientOrder(obj.ID, obj.Name);
                        return -1;
                    }

                    //转换当前医嘱信息
                    Neusoft.HISFC.Models.Order.OutPatient.Order nowOrder = alNowOrder[0] as Neusoft.HISFC.Models.Order.OutPatient.Order;
                    if (order.Status != 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("待修改医嘱中有的不是开立状态");
                        this.ShowOutpatientOrder(obj.ID, obj.Name);
                        return -1;
                    }

                    int returnValue = this.orderBizLogic.UpdateOrderHyTest(hytoResult, this.GetHyteName(intHytoResult), order.ID, order.SeeNO);

                    if (returnValue < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("本次操作没有成功：更新医嘱[" + order.Item.Name + "]的皮试结果失败！" + this.orderBizLogic.Err);
                        this.ShowOutpatientOrder(obj.ID, obj.Name);
                        return -1;
                    }

                    if (returnValue == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("本次操作没有成功：更新医嘱[" + order.Item.Name + "]的皮试结果失败！" + this.orderBizLogic.Err);
                        this.ShowOutpatientOrder(obj.ID, obj.Name);
                        return -1;
                    }
                    //order.HypoTest = intHytoResult;
                    //order.Memo = this.GetHyteName(intHytoResult);

                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("修改成功");
            this.ShowOutpatientOrder(obj.ID, obj.Name);


            return 1;
        }

        /// <summary>
        /// 设置选择状态
        /// </summary>
        /// <param name="isSelect"></param>
        protected virtual void AllSelect(bool isSelect)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Value = isSelect;
            }
        }
        #endregion

        #region 事件
        private void txtCardNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Clear();
                this.neuSpread1_Sheet1.Rows.Count = 0;
                 
                string cardNO = this.txtCardNO.Text.Trim();

                if (string.IsNullOrEmpty(cardNO))
                {
                    MessageBox.Show("病历号不能为空");

                    this.txtCardNO.Focus();
                    return;
                }

                cardNO = cardNO.PadLeft(10, '0');
                this.txtCardNO.Text = cardNO;

                this.ShowPatientInfo(cardNO);
                //起始时间
                string beginDtime = this.dtpBegin.Value.Date.ToString();

                string endDtime = this.dtpEndTime.Value.Date.ToShortDateString() + " 23:59:59";
                int returnValue = this.QueryHytoRecord(cardNO, beginDtime, endDtime);

                if (returnValue < 0)
                {
                    return;
                }

            }
        }

        private void tvRegRecord_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                this.neuSpread1_Sheet1.RowCount = 0;

            }
            else
            {
                Neusoft.FrameWork.Models.NeuObject obj = e.Node.Tag as Neusoft.FrameWork.Models.NeuObject;

                if (obj == null)
                {
                    return;
                }
                this.ShowOutpatientOrder(obj.ID, obj.Name);

            }

        }

        protected override void OnLoad(EventArgs e)
        {
            this.InitInfo();
            this.SetFarpointFarmat();
            base.OnLoad(e);
        }

        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("皮试记录", "修改皮试记录", Neusoft.FrameWork.WinForms.Classes.EnumImageList.P盘点开始, true, false, null);
            this.toolBarService.AddToolButton("全选", "全选", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全选, true, false, null);
            this.toolBarService.AddToolButton("全不选", "全不选", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全不选, true, false, null);
            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "皮试记录":
                    {
                        this.ModifyHytoResult();
                        break;
                    }
                case "全选":
                    {
                        this.AllSelect(true);
                        break;
                    }
                case "全不选":
                    {
                        this.AllSelect(false);
                        break;
                    }
                default:
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.txtCardNO_KeyDown(sender,new KeyEventArgs(Keys.Enter));
            return base.OnQuery(sender, neuObject);
        }
        #endregion

        #region 枚举
        private enum EnumColumn
        {
            SEE_NO = 1,
            SEQUENCE_NO,
            CLINIC_CODE,
            CARD_NO,
            ITEM_NAME,
            HYPOTEST,
            SPECS,
            FEE_CODE,
            UNIT_PRICE,
            QTY,
            ITEM_UNIT,
            FREQUENCY_NAME,
            USAGE_NAME,
            ONCE_DOSE,
            ONCE_UNIT,
            EXEC_DPNM,
            REG_DATE,
            DEPT_CODE,
            DOCT_NAME,
            DOCT_DPCD,
            OPER_DATE,
            EMC_FLAG,


        }
        #endregion


    }
}

