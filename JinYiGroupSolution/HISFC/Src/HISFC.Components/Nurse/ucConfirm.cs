using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse
{
    public partial class ucConfirm : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucConfirm()
        {
            InitializeComponent();
        }

        #region 定义
        /// <summary>
        /// 门诊费用管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee patientMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        /// <summary>
        /// 院注管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Nurse.Inject InjMgr = new Neusoft.HISFC.BizLogic.Nurse.Inject();
        private Neusoft.HISFC.BizProcess.Integrate.Pharmacy drugMgr = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
        private Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        private Neusoft.HISFC.BizProcess.Integrate.Manager DeptMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.HISFC.BizProcess.Integrate.Manager PsMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.HISFC.BizProcess.Integrate.Manager conMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.HISFC.BizProcess.Integrate.Manager Constant = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.HISFC.Models.Registration.Register reg = null;

        /// <summary>
        /// 样本集合
        /// </summary>
        private Hashtable htSamples = new Hashtable();
        /// <summary>
        /// 医生集合
        /// </summary>
        private Hashtable htDoctors = new Hashtable();
        private ArrayList al = new ArrayList();
        private ArrayList alConstant = new ArrayList();
        private string formSet;
        //{B89590FC-406F-4ff8-9CFB-C71E990827A1}
        private bool isSave = false;
        #endregion

        #region 初始

        private void Init()
        {
            this.InitDoctor();
            this.InitCareList();
        }
        /// <summary>
        /// 初始化医生
        /// </summary>
        private void InitDoctor()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager doctMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            al = doctMgr.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (al != null)
            {
                foreach (Neusoft.HISFC.Models.Base.Employee p in al)
                {
                    this.htDoctors.Add(p.ID, p.Name);
                }
            }
        }

        private void InitCareList()
        {
            ArrayList alConstant = Constant.QueryConstantList("CLININCON");
        }

        #endregion

        #region 工具条

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("列表", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.M默认, true, false, null);
            this.toolBarService.AddToolButton("全选", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全选, true, false, null);
            this.toolBarService.AddToolButton("取消", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);

            return this.toolBarService;
        }

        protected override int OnSave(object sender, object neuObject)
        {
            //{B89590FC-406F-4ff8-9CFB-C71E990827A1}
            this.isSave = true;
            this.Save();
            return 1;            
        }
        protected override int OnQuery(object sender, object neuObject)
        {
            if (this.txtCardNo.Text.Trim() == "" || this.txtCardNo.Text.Trim() == null)
            {
                this.QueryAll();
            }
            else
            {
                this.Query();
            }
            return 1;
        }
        protected override int OnPrint(object sender, object neuObject)
        {
            this.Print();
            return 1;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "列表":
                    this.SetQueryBar();
                    break;
                case "全选":
                    this.SelectAll(true);
                    break;
                case "取消":
                    this.SelectAll(false);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 确认保存
        /// </summary>
        private int Save()
        {
            this.neuSpread1.StopCellEditing();
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
            {
                MessageBox.Show("没有要保存的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            int selectNum = 0;
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                if (this.neuSpread1_Sheet1.GetValue(i, 0).ToString().ToUpper() == "FALSE" || this.neuSpread1_Sheet1.GetValue(i, 0).ToString() == "")
                {
                    selectNum++;
                }
            }
            if (selectNum >= this.neuSpread1_Sheet1.RowCount)
            {
                MessageBox.Show("请选择数据", "提示");
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //SQLCA.BeginTransaction();

            try
            {
                this.InjMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                DateTime confirmDate = this.InjMgr.GetDateTimeFromSysDateTime();

                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Nurse.Inject info =
                        (Neusoft.HISFC.Models.Nurse.Inject)this.neuSpread1_Sheet1.Rows[i].Tag;

                    info.ID = this.neuSpread1_Sheet1.GetValue(i, 1).ToString();

                    //配药信息
                    info.MixOperInfo.ID = this.neuSpread1_Sheet1.Cells[i, 13].Tag.ToString();
                    info.MixOperInfo.Name = this.neuSpread1_Sheet1.Cells[i, 13].Text;
                    info.MixTime = this.InjMgr.GetDateTimeFromSysDateTime();

                    //注射信息
                    info.InjectOperInfo.ID = this.neuSpread1_Sheet1.Cells[i, 14].Tag.ToString();
                    info.InjectOperInfo.Name = this.neuSpread1_Sheet1.Cells[i, 14].Text;
                    info.InjectTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread1_Sheet1.GetValue(i, 15));
                    string strSpeed = this.neuSpread1_Sheet1.Cells[i, 16].Text;
                    if (strSpeed == null || strSpeed == "") strSpeed = "0";
                    info.InjectSpeed = Neusoft.FrameWork.Function.NConvert.ToInt32(strSpeed);

                    //拔针信息
                    if (this.neuSpread1_Sheet1.Cells[i, 17].Tag != null)
                    {
                        info.StopOper.ID = this.neuSpread1_Sheet1.Cells[i, 17].Tag.ToString();
                    }
                    info.EndTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread1_Sheet1.GetValue(i, 18));
                    info.SendemcTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread1_Sheet1.GetValue(i, 19));
                    info.Memo = this.neuSpread1_Sheet1.Cells[i, 20].Text;

                    //把确认时间更改回最小值
                    if (this.neuSpread1_Sheet1.GetValue(i, 0).ToString().ToUpper() == "FALSE")
                    {
                        info.MixTime = System.DateTime.MinValue;
                        info.InjectTime = System.DateTime.MinValue;
                        info.EndTime = System.DateTime.MinValue;
                    }
                    if (this.formSet == "配药")
                    {
                        if (this.InjMgr.UpdateMix(info) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(this.InjMgr.Err, "提示");
                            return -1;
                        }
                    }
                    if (this.formSet == "注射")
                    {
                        if (this.InjMgr.UpdateInject(info) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(this.InjMgr.Err, "提示");
                            return -1;
                        }
                    }
                    if (this.formSet == "拔针")
                    {
                        if (this.InjMgr.UpdateStop(info) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(this.InjMgr.Err, "提示");
                            return -1;
                        }
                    }
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();

            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return -1;
            }

            MessageBox.Show("保存成功!", "提示");
            
            this.QueryAll();
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Clear()
        {
            if (this.neuSpread1_Sheet1.RowCount > 0)
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.RowCount);
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void Query()
        {
            string cardNo;
            cardNo = this.txtCardNo.Text.Trim().PadLeft(10, '0');
            string orderNo;
            orderNo = this.txtOrder.Text.Trim().ToString();
            bool IsFound = false;
            if (cardNo != null && cardNo != "0000000000" && cardNo != "")
            {
                //按照病例号查询定位
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    if (this.neuSpread1_Sheet1.Cells[i, 3].Tag.ToString() == cardNo)
                    {
                        this.neuSpread1.Focus();
                        this.neuSpread1_Sheet1.AddSelection(i, 0, 1, 1);

                        this.SetPatient(i);
                        IsFound = true;
                        break;
                    }
                }
                if (!IsFound)
                {
                    MessageBox.Show("没有需要确认的医嘱信息!", "提示");
                    this.txtCardNo.Focus();
                    return;
                }
            }
            else if (orderNo != null && orderNo != "")
            {
                //按照队列顺序号查询定位
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    if (this.neuSpread1_Sheet1.GetValue(i, 2).ToString() == orderNo)
                    {
                        this.neuSpread1.Focus();
                        this.neuSpread1_Sheet1.AddSelection(i, 0, 1, 1);

                        this.SetPatient(i);
                        IsFound = true;
                        break;
                    }
                }
                if (!IsFound)
                {
                    MessageBox.Show("没有需要确认的医嘱信息!", "提示");
                    this.txtOrder.Focus();
                    return;
                }
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void QueryAll()
        {
            this.Clear();
            string str = "all";
            //获取所有项目

            al = this.InjMgr.QueryAll(str,
                Neusoft.FrameWork.Function.NConvert.ToDateTime(dtpExec.Value.ToString("yyyy-MM-dd 00:00:00")));
            ArrayList alConfirm = new ArrayList();
            foreach (Neusoft.HISFC.Models.Nurse.Inject detail in al)
            {
                if (this.funcation == Funcations.配药 && (detail.MixOperInfo.ID == "" || detail.MixOperInfo.ID == null))
                {
                    alConfirm.Add(detail);
                }
                //{14EECF9B-FEA3-4bd4-92C5-91E1FE7F7171} 
                else if (this.funcation == Funcations.注射 && (detail.InjectOperInfo.ID == "" || detail.InjectOperInfo.ID == null) && !(detail.MixOperInfo.ID == "" || detail.MixOperInfo.ID == null))
                {
                    alConfirm.Add(detail);
                }
                //{14EECF9B-FEA3-4bd4-92C5-91E1FE7F7171}
                else if (this.funcation == Funcations.拔针 && (detail.StopOper.ID == "" || detail.StopOper.ID == null) && !(detail.InjectOperInfo.ID == "" || detail.InjectOperInfo.ID == null) && !(detail.MixOperInfo.ID == "" || detail.MixOperInfo.ID == null))
                {
                    alConfirm.Add(detail);
                }
            }
            if (al == null || al.Count == 0)
            {
                MessageBox.Show("没有需要确认的医嘱信息!", "提示");
                this.txtCardNo.Focus();
                return;
            }
            this.AddDetail(alConfirm);
            //this.AddDetail(al);
            if (this.neuSpread1_Sheet1.RowCount == 0)
            {

                #region {B89590FC-406F-4ff8-9CFB-C71E990827A1}

                if (!isSave)
                {
                    MessageBox.Show("该时间段内没有患者信息!", "提示");
                }
                else
                {
                    isSave = false;
                }

                #endregion

                //MessageBox.Show("该时间段内没有患者信息!", "提示");
                this.txtCardNo.Focus();
                return;
            }

            this.SetComb();
            this.LessShow();
            this.SetFP();
            this.txtOrder.Focus();
            //this.Query();
        }
        /// <summary>
        /// 设置组合号
        /// </summary>
        private void SetComb()
        {
            int myCount = this.neuSpread1_Sheet1.RowCount;
            int i;
            //第一行
            this.neuSpread1_Sheet1.SetValue(0, 8, "┓");
            //最后行
            this.neuSpread1_Sheet1.SetValue(myCount - 1, 8, "┛");
            //中间行
            for (i = 1; i < myCount - 1; i++)
            {
                int prior = i - 1;
                int next = i + 1;
                string currentRowExecDate = this.neuSpread1_Sheet1.Cells[i, 6].Tag.ToString();
                string currentRowCombNo = this.neuSpread1_Sheet1.Cells[i, 8].Tag.ToString();
                string priorRowExecDate = this.neuSpread1_Sheet1.Cells[prior, 6].Tag.ToString();
                string priorRowCombNo = this.neuSpread1_Sheet1.Cells[prior, 8].Tag.ToString();
                string nextRowExecDate = this.neuSpread1_Sheet1.Cells[next, 6].Tag.ToString();
                string nextRowCombNo = this.neuSpread1_Sheet1.Cells[next, 8].Tag.ToString();

                #region ""
                bool bl1 = true;
                bool bl2 = true;
                if (currentRowExecDate != priorRowExecDate || currentRowCombNo != priorRowCombNo)
                    bl1 = false;
                if (currentRowExecDate != nextRowExecDate || currentRowCombNo != nextRowCombNo)
                    bl2 = false;
                //  ┃
                if (bl1 && bl2)
                {
                    this.neuSpread1_Sheet1.SetValue(i, 8, "┃");
                }
                //  ┛
                if (bl1 && !bl2)
                {
                    this.neuSpread1_Sheet1.SetValue(i, 8, "┛");
                }
                //  ┓
                if (!bl1 && bl2)
                {
                    this.neuSpread1_Sheet1.SetValue(i, 8, "┓");
                }
                //  ""
                if (!bl1 && !bl2)
                {
                    this.neuSpread1_Sheet1.SetValue(i, 8, "");
                }
                #endregion
            }
            //把没有组号的去掉
            for (i = 0; i < myCount; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, 8].Tag.ToString() == "")
                {
                    this.neuSpread1_Sheet1.SetValue(i, 8, "");
                }
            }
            //判断首末行 有组号，且只有自己一组数据的情况
            if (myCount == 1)
            {
                this.neuSpread1_Sheet1.SetValue(0, 8, "");
            }
            //只有首末两行，那么还要判断组号啊
            if (myCount == 2)
            {
                if (this.neuSpread1_Sheet1.Cells[0, 8].Tag.ToString() != this.neuSpread1_Sheet1.Cells[1, 5].Tag.ToString())
                {
                    this.neuSpread1_Sheet1.SetValue(0, 8, "");
                    this.neuSpread1_Sheet1.SetValue(1, 8, "");
                }
            }
            if (myCount > 2)
            {
                if (this.neuSpread1_Sheet1.GetValue(1, 8).ToString() != "┃"
                    && this.neuSpread1_Sheet1.GetValue(1, 8).ToString() != "┛")
                {
                    this.neuSpread1_Sheet1.SetValue(0, 8, "");
                }
                if (this.neuSpread1_Sheet1.GetValue(myCount - 2, 8).ToString() != "┃"
                    && this.neuSpread1_Sheet1.GetValue(myCount - 2, 8).ToString() != "┓")
                {
                    this.neuSpread1_Sheet1.SetValue(myCount - 1, 8, "");
                }
            }
        }

        /// <summary>
        /// 添加项目明细
        /// </summary>
        /// <param name="detail"></param>
        private void AddDetail(ArrayList details)
        {
            if (this.neuSpread1_Sheet1.RowCount > 0) this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.RowCount);

            if (details != null)
            {
                foreach (Neusoft.HISFC.Models.Nurse.Inject detail in details)
                {
                    this.AddDetail(detail);
                }
            }
        }

        /// <summary>
        /// 添加明细
        /// </summary>
        /// <param name="detail"></param>
        private void AddDetail(Neusoft.HISFC.Models.Nurse.Inject info)
        {
            this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.RowCount, 1);
            int row = this.neuSpread1_Sheet1.RowCount - 1;
            this.neuSpread1_Sheet1.Rows[row].Tag = info;

            #region "窗口赋值"
            #region 午别 皮试 时间
            //午别
            string strNoon = this.GetNoon(info.Booker.OperTime);
            if (info.Item.Order.Frequency.ID == "QD")
            {
                strNoon = "全天";
            }
            //皮试
            string strTest = "否";
            if (info.Hypotest == "1")
            {
                strTest = "是";
            }
            if (info.InjectOperInfo.ID == null || info.InjectOperInfo.ID == "")
            {
                info.InjectTime = this.InjMgr.GetDateTimeFromSysDateTime();
            }
            if (info.StopOper.ID == null || info.StopOper.ID == "")
            {
                info.EndTime = this.InjMgr.GetDateTimeFromSysDateTime();
            }
            #endregion
            if (this.formSet == "配药")
            {
                if (info.MixOperInfo.ID == "")
                {
                    this.neuSpread1_Sheet1.SetValue(row, 0, false);
                }
                else
                {
                    this.neuSpread1_Sheet1.SetValue(row, 0, true);
                }
            }
            if (this.formSet == "注射")
            {
                if (info.InjectOperInfo.ID == "")
                {
                    this.neuSpread1_Sheet1.SetValue(row, 0, false);
                }
                else
                {
                    this.neuSpread1_Sheet1.SetValue(row, 0, true);
                }
            }
            if (this.formSet == "拔针")
            {
                if (info.StopOper.ID == "")
                {
                    this.neuSpread1_Sheet1.SetValue(row, 0, false);
                }
                else
                {
                    this.neuSpread1_Sheet1.SetValue(row, 0, true);
                }
            }
            this.neuSpread1_Sheet1.SetValue(row, 1, info.ID, false);//流水号
            this.neuSpread1_Sheet1.SetValue(row, 2, info.OrderNO, false);//队列顺序号
            this.neuSpread1_Sheet1.Cells[row, 2].Tag = info.OrderNO.ToString();//
            this.neuSpread1_Sheet1.SetValue(row, 3, info.Patient.Name.ToString());//患者姓名
            this.neuSpread1_Sheet1.Cells[row, 3].Tag = info.Patient.PID.CardNO.ToString();//病例号
            this.neuSpread1_Sheet1.SetValue(row, 4, this.GetDoctByID(info.Item.Order.Doctor.ID), false);//开单医生
            this.neuSpread1_Sheet1.Cells[row, 4].Tag = info.Item.Order.Doctor.ID.ToString();
            this.neuSpread1_Sheet1.SetValue(row, 5, info.Item.Order.DoctorDept.Name, false);//科别
            this.neuSpread1_Sheet1.Cells[row, 5].Tag = info.Item.Order.DoctorDept.Name.ToString();
            this.neuSpread1_Sheet1.SetValue(row, 6, strNoon, false);//午别
            this.neuSpread1_Sheet1.Cells[row, 6].Tag = info.Booker.OperTime.ToString();
            this.neuSpread1_Sheet1.SetValue(row, 7, info.Item.Name, false);//药品名称
            this.neuSpread1_Sheet1.Cells[row, 8].Tag = info.Item.Order.Combo.ID.ToString();//组合号
            this.neuSpread1_Sheet1.SetValue(row, 9, info.Item.Order.DoseOnce.ToString() + info.Item.Order.DoseUnit, false);//每次量
            this.neuSpread1_Sheet1.SetValue(row, 10, info.Item.Order.Frequency.ID, false);//频次
            this.neuSpread1_Sheet1.SetValue(row, 11, info.Item.Order.Usage.Name, false);//用法
            this.neuSpread1_Sheet1.SetValue(row, 12, strTest, false);//皮试？
            this.neuSpread1_Sheet1.SetValue(row, 13, info.MixOperInfo.Name, false);//配药人
            this.neuSpread1_Sheet1.Cells[row, 13].Tag = info.MixOperInfo.ID.ToString();//配药人代码
            this.neuSpread1_Sheet1.SetValue(row, 14, info.InjectOperInfo.Name, false);//注射人
            this.neuSpread1_Sheet1.Cells[row, 14].Tag = info.InjectOperInfo.ID.ToString();//注射人代码
            this.neuSpread1_Sheet1.SetValue(row, 15, info.InjectTime, false);//注射日期
            this.neuSpread1_Sheet1.SetValue(row, 16, info.InjectSpeed, false);//滴速
            this.neuSpread1_Sheet1.Cells[row, 17].Tag = info.StopOper.ID;//拔针护士代码
            if (info.StopOper.ID != null && info.StopOper.ID != "")
            {
                this.neuSpread1_Sheet1.SetValue(row, 17, this.GetNameByOperID(info.StopOper.ID), false);//拔针人
            }
            this.neuSpread1_Sheet1.SetValue(row, 18, info.EndTime, false);//拔针时间
            if (info.SendemcTime == DateTime.MinValue)
            {
                this.neuSpread1_Sheet1.SetValue(row, 19, null, false);//送急诊时间
            }
            else
            {
                this.neuSpread1_Sheet1.SetValue(row, 19, info.SendemcTime, false);//送急诊时间
            }
            this.neuSpread1_Sheet1.SetValue(row, 20, info.Memo, false);//备注
            #endregion
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.PrintPage(0, 0, this.neuSpread1);
        }

        /// <summary>
        /// 列表
        /// </summary>
        private void SetQueryBar()
        {
            if (!this.panel2.Visible)
            {
                this.panel2.Visible = true;
            }
            else
            {
                this.panel2.Visible = false;
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        private void SelectAll(bool isSelected)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                this.neuSpread1_Sheet1.SetValue(i, 0, isSelected, false);
                int n = 13;
                if (this.formSet == "注射")
                {
                    n++;
                }
                if (this.formSet == "拔针")
                {
                    n = n + 4;
                }
                if (isSelected)
                {
                    if (this.neuSpread1_Sheet1.Cells[i, n].Text == null
                        || this.neuSpread1_Sheet1.Cells[i, n].Text == "")
                    {
                        this.neuSpread1_Sheet1.SetValue(i, n, Neusoft.FrameWork.Management.Connection.Operator.Name /*var.User.Name.ToString()*/);
                        this.neuSpread1_Sheet1.Cells[i, n].Tag = Neusoft.FrameWork.Management.Connection.Operator.ID /*var.User.ID.ToString();*/;
                    }
                }
                else
                {
                    if (this.neuSpread1_Sheet1.Cells[i, n].Text == Neusoft.FrameWork.Management.Connection.Operator.Name /*var.User.Name.ToString()*/)
                    {
                        this.neuSpread1_Sheet1.SetValue(i, n, "");
                        this.neuSpread1_Sheet1.Cells[i, n].Tag = "";
                    }
                }
            }
        }

        #endregion

        #region 公共

        /// <summary>
        /// 根据代码获取医生名称
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string GetDoctByID(string ID)
        {
            IDictionaryEnumerator dict = htDoctors.GetEnumerator();
            while (dict.MoveNext())
            {
                if (dict.Key.ToString() == ID)
                    return dict.Value.ToString();
            }
            return "";
        }

        /// <summary>
        /// 根据人员代码获取人员信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string GetNameByOperID(string ID)
        {
            Neusoft.HISFC.Models.Base.Employee ps = new Neusoft.HISFC.Models.Base.Employee();
            ps = this.PsMgr.GetEmployeeInfo(ID);
            if (ps == null)
            {
                MessageBox.Show("获取人员信息出错!");
            }
            return ps.Name;
        }

        /// <summary>
        /// 设置格式
        /// </summary>
        private void SetFP()
        {
            FarPoint.Win.Spread.CellType.TextCellType txtOnly = new FarPoint.Win.Spread.CellType.TextCellType();
            txtOnly.ReadOnly = true;
            FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            dateType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;


            this.neuSpread1_Sheet1.Columns[1].Visible = false;
            this.neuSpread1_Sheet1.Columns[2].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[3].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[4].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[5].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[6].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[7].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[8].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[9].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[10].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[11].CellType = txtOnly;

            this.neuSpread1_Sheet1.Columns[13].CellType = txtOnly;//配药护士
            this.neuSpread1_Sheet1.Columns[14].CellType = txtOnly;//注射护士
            this.neuSpread1_Sheet1.Columns[17].CellType = txtOnly;//拔针护士
            if (this.formSet == "配药")  //配药确认
            {
                this.neuSpread1_Sheet1.Columns[14].Visible = false;//注射护士
                this.neuSpread1_Sheet1.Columns[15].Visible = false;//注射时间
                this.neuSpread1_Sheet1.Columns[17].Visible = false;//拔针人
                this.neuSpread1_Sheet1.Columns[18].Visible = false;//拔针时间
                this.neuSpread1_Sheet1.Columns[19].Visible = false;//送急诊时间
            }
            if (this.formSet == "注射")  //注射确认
            {
                this.neuSpread1_Sheet1.Columns[13].Visible = false;//配药护士
                this.neuSpread1_Sheet1.Columns[17].Visible = false;//拔针人
                this.neuSpread1_Sheet1.Columns[18].Visible = false;//拔针时间
            }
            if (this.formSet == "拔针")  //拔针确认
            {
                this.neuSpread1_Sheet1.Columns[13].Visible = false;//配药护士
                this.neuSpread1_Sheet1.Columns[14].Visible = false;//注射护士
                this.neuSpread1_Sheet1.Columns[15].Visible = false;//注射时间
                this.neuSpread1_Sheet1.Columns[19].Visible = false;//送急诊时间
            }
            this.neuSpread1_Sheet1.Columns[9].Visible = false;//
            this.neuSpread1_Sheet1.Columns[10].Visible = false;//
            this.neuSpread1_Sheet1.Columns[11].Visible = false;//
            this.neuSpread1_Sheet1.Columns[12].Visible = false;//
            this.neuSpread1_Sheet1.Columns[16].Visible = false;//滴速
        }

        /// <summary>
        /// 获取午别
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetNoon(DateTime dt)
        {
            string strNoon = "上午";
            if (Neusoft.FrameWork.Function.NConvert.ToInt32(dt.ToString("HH")) >= 12)
            {
                strNoon = "下午";
            }
            return strNoon;
        }

        /// <summary>
        /// 压缩显示
        /// </summary>
        private void LessShow()
        {
            //正常情况，压缩显示的时候，可以把四列同时压缩，就不用列循环了
            if (this.neuSpread1_Sheet1.RowCount < 1) return;
            for (int j = 2; j < 4; j++)
            {
                string startValue = this.neuSpread1_Sheet1.Cells[0, j].Tag.ToString();
                int startRow = 0; //起点行
                int endRow = 0;

                for (int i = 1; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    string currentValue = this.neuSpread1_Sheet1.Cells[i, j].Tag.ToString();
                    if (startValue != currentValue)
                    {
                        endRow = i - 1;
                        //1.设置压缩合并
                        if (endRow - startRow > 0)
                        {
                            for (int k = startRow + 1; k <= endRow; k++)
                            {
                                this.neuSpread1_Sheet1.SetValue(k, j, "");
                            }
                            FarPoint.Win.Spread.Model.CellRange cr = new FarPoint.Win.Spread.Model.CellRange(startRow, j, endRow - startRow + 1, 1);
                            this.neuSpread1.ActiveSheet.Models.Span.Add(cr.Row, cr.Column, cr.RowCount, cr.ColumnCount);
                        }
                        //2.设置颜色
                        this.neuSpread1.StopCellEditing();
                        for (int m = startRow; m <= endRow; m++)
                        {
                            if (this.neuSpread1_Sheet1.Rows[startRow - 1].BackColor != System.Drawing.Color.White)
                            {
                                this.neuSpread1_Sheet1.Rows[m].BackColor = System.Drawing.Color.White;
                            }
                            else
                            {
                                this.neuSpread1_Sheet1.Rows[m].BackColor = System.Drawing.Color.Linen;
                            }
                        }
                        startValue = this.neuSpread1_Sheet1.Cells[i, j].Tag.ToString();
                        startRow = i;
                    }
                    //最后收尾
                    if (i == this.neuSpread1_Sheet1.RowCount - 1)
                    {
                        endRow = i - 1;
                        if (i - startRow > 0) //不止一行
                        {
                            for (int k = startRow + 1; k <= i; k++)
                            {
                                this.neuSpread1_Sheet1.SetValue(k, j, "");
                            }
                            FarPoint.Win.Spread.Model.CellRange cr = new FarPoint.Win.Spread.Model.CellRange(startRow, j, endRow - startRow + 2, 1);
                            this.neuSpread1.ActiveSheet.Models.Span.Add(cr.Row, cr.Column, cr.RowCount, cr.ColumnCount);
                        }
                        else //最后一行单列，不需要合并
                        {
                        }
                        //2.设置颜色
                        this.neuSpread1.StopCellEditing();
                        for (int m = startRow; m <= i; m++)
                        {
                            if (this.neuSpread1_Sheet1.Rows[startRow - 1].BackColor != System.Drawing.Color.White)
                            {
                                this.neuSpread1_Sheet1.Rows[m].BackColor = System.Drawing.Color.White;
                            }
                            else
                            {
                                this.neuSpread1_Sheet1.Rows[m].BackColor = System.Drawing.Color.Linen;
                            }
                        }
                    }//end if(i == this.fpSpread1_Sheet1.RowCount-1)
                }
            }//end private void lessShow()
        }

        /// <summary>
        /// 设置病人信息
        /// </summary>
        /// <param name="rowno"></param>
        private void SetPatient(int rowno)
        {
            this.neuSpread1.StopCellEditing();
            if (!this.neuSpread1.Focused || rowno < 0)
            {
                this.txtName.Text = "";
                this.txtSex.Text = "";
                this.txtAge.Text = "";
                this.txtBirthday.Text = "";
                return;
            }
            //设置病人信息
            Neusoft.HISFC.Models.Nurse.Inject info
                = (Neusoft.HISFC.Models.Nurse.Inject)this.neuSpread1_Sheet1.Rows[rowno].Tag;

            if (info == null)
            {
                this.txtName.Text = "";
                this.txtSex.Text = "";
                this.txtAge.Text = "";
                this.txtBirthday.Text = "";
                return;
            }
            this.txtName.Text = info.Patient.Name;

            //Neusoft.HISFC.Models.RADT.Sex se = new Neusoft.HISFC.Models.RADT.Sex();
            //se.ID = info.Patient.Sex.ID;
            this.txtSex.Text = info.Patient.Sex.Name;
            //this.txtAge.Text = this.conMgr.GetAge(info.Patient.Birthday, info.Booker.OperTime);
            this.txtAge.Text = this.InjMgr.GetAge(info.Patient.Birthday, info.Booker.OperTime);
            this.txtBirthday.Text = info.Patient.Birthday.ToString();
        }

        #endregion

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtCardNo.Text.Trim() == "")
                {
                    MessageBox.Show("请输入病历号!", "提示");
                    this.txtCardNo.Focus();
                    return;
                }
                this.Query();
            }
        }

        private void txtOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtOrder.Text.Trim() == "")
                {
                    MessageBox.Show("请输入顺序号!", "提示");
                    this.txtOrder.Focus();
                    return;
                }
                this.txtCardNo.Text = "";
                this.Query();
            }
        }

        private void neuSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                //同组的点中与否同时性
                this.neuSpread1.StopCellEditing();
                if (!this.neuSpread1.Focused || e.Row < 0) return;
                string strTemp = this.neuSpread1_Sheet1.GetValue(e.Row, 0).ToString().ToUpper();
                if (e.Column == 0)
                {
                    //配药
                    int n = 13;
                    //注射
                    if (this.formSet == "注射")
                    {
                        n++;
                    }
                    //拔针
                    if (this.formSet == "拔针")
                    {
                        n = n + 4;
                    }
                    for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                    {
                        //病历号,顺序号,组号,午别
                        if (this.neuSpread1_Sheet1.Cells[i, 2].Tag.ToString() == this.neuSpread1_Sheet1.Cells[e.Row, 2].Tag.ToString()
                            && this.neuSpread1_Sheet1.Cells[i, 3].Tag.ToString() == this.neuSpread1_Sheet1.Cells[e.Row, 3].Tag.ToString()
                            && this.neuSpread1_Sheet1.Cells[i, 6].Tag.ToString() == this.neuSpread1_Sheet1.Cells[e.Row, 6].Tag.ToString()
                            && this.neuSpread1_Sheet1.Cells[i, 8].Tag.ToString() == this.neuSpread1_Sheet1.Cells[e.Row, 8].Tag.ToString()
                            && this.neuSpread1_Sheet1.Cells[i, 8].Tag.ToString() != null && this.neuSpread1_Sheet1.Cells[i, 8].Tag.ToString() != ""
                            && i != e.Row)
                        {

                            if (strTemp == "TRUE")
                            {
                                this.neuSpread1_Sheet1.SetValue(i, 0, true, false);
                                if (this.neuSpread1_Sheet1.Cells[i, n].Text == null
                                    || this.neuSpread1_Sheet1.Cells[i, n].Text == "")
                                {
                                    this.neuSpread1_Sheet1.SetValue(i, n, ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Name /*var.User.Name.ToString()*/);
                                    this.neuSpread1_Sheet1.Cells[i, n].Tag = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).ID; /*var.User.ID.ToString();*/
                                }

                            }
                            else
                            {
                                this.neuSpread1_Sheet1.SetValue(i, 0, false, false);
                                if (this.neuSpread1_Sheet1.GetValue(i, n).ToString() == ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Name /*var.User.Name.ToString()*/)
                                {
                                    this.neuSpread1_Sheet1.SetValue(i, n, "");
                                    this.neuSpread1_Sheet1.Cells[i, n].Tag = "";
                                }
                            }

                        }//end if
                    }//end for()
                }
                //绑定确认人
                this.neuSpread1.StopCellEditing();
                if (e.Column == 0)
                {
                    int n = 13;
                    if (this.formSet == "注射")
                    {
                        n++;
                    }
                    if (this.formSet == "拔针")
                    {
                        n = n + 4;
                    }
                    if (this.neuSpread1_Sheet1.GetValue(e.Row, 0).ToString().ToUpper() == "TRUE")
                    {
                        if (this.neuSpread1_Sheet1.Cells[e.Row, n].Text == null
                            || this.neuSpread1_Sheet1.Cells[e.Row, n].Text == "")
                        {
                            this.neuSpread1_Sheet1.SetValue(e.Row, n, ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Name /*var.User.Name.ToString()*/);
                            this.neuSpread1_Sheet1.Cells[e.Row, n].Tag = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).ID; /*var.User.ID.ToString();*/
                        }
                    }
                    else
                    {
                        if (this.neuSpread1_Sheet1.Cells[e.Row, n].Text == ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Name /*var.User.Name.ToString()*/)
                        {
                            this.neuSpread1_Sheet1.SetValue(e.Row, n, "");
                            this.neuSpread1_Sheet1.Cells[e.Row, n].Tag = "";
                        }

                    }
                    this.neuSpread1_Sheet1.SetActiveCell(e.Row, 1);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "1");
                return;
            }
        }

        private void neuSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.neuSpread1_Sheet1.ActiveColumnIndex == 19)
            {
                if (e.KeyData == Keys.Space)
                {
                    Neusoft.FrameWork.Models.NeuObject neuObj = new Neusoft.FrameWork.Models.NeuObject();
                    /* 这个有问题[2007/03/10]
                    if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(Constant.GetList("CLININCON"), ref neuObj) == 1)
                    {
                        this.neuSpread1_Sheet1.SetValue(this.neuSpread1_Sheet1.ActiveRowIndex,
                            this.neuSpread1_Sheet1.ActiveColumnIndex, neuObj.Name);
                    }
                    */

                }
            }
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Column == 20)
            {
                /* 这个地方有问题[2007/03/10]
                Neusoft.FrameWork.Models.NeuObject neuObj = new Neusoft.FrameWork.Models.NeuObject();
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(Constant.GetList("CLININCON"), ref neuObj) == 1)
                {
                    this.neuSpread1_Sheet1.SetValue(e.Row, e.Column, neuObj.Name);
                }
                 * 
                 */
            }
        }

        //private void neuSpread1_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        //{
        //    //this.SetPatient(e.NewRow);
        //}

        protected override bool ProcessDialogKey(Keys keyData)
        {
            int altKey = Keys.Alt.GetHashCode();

            if (keyData == Keys.F1)
            {
                this.SelectAll(true);
                return true;
            }
            if (keyData == Keys.F2)
            {
                this.SelectAll(false);
                return true;
            }
            if (keyData == Keys.F12)
            {
                this.SetQueryBar();
                return true;
            }
            if (keyData.GetHashCode() == altKey + Keys.S.GetHashCode())
            {
                if (this.Save() == 0)
                { }
                return true;
            }
            if (keyData.GetHashCode() == altKey + Keys.Q.GetHashCode())
            {
                this.Query();
                return true;
            }
            if (keyData.GetHashCode() == altKey + Keys.P.GetHashCode())
            {
                //
                return true;
            }
            if (keyData.GetHashCode() == altKey + Keys.X.GetHashCode())
            {
                this.FindForm().Close();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void ucConfirm_Load(object sender, EventArgs e)
        {
            if (this.funcation.ToString() != null)
                this.formSet = this.funcation.ToString();
            
            this.Text = this.formSet + "确认";
            this.Init();
            this.SetFP();
            this.QueryAll();
            //{03E7916F-5AA8-4e95-BBE2-61EB6FDEB96C} 输液申请
            this.SetAlterControl();
        }

        /// <summary>
        /// 配药提示
        /// {03E7916F-5AA8-4e95-BBE2-61EB6FDEB96C}
        /// </summary>
        private void SetAlterControl()
        {
            if (this.funcation != Funcations.配药)
            {
                return;
            }
            this.ucDosageAlter1.Visible = true;
            this.ucDosageAlter1.QueryDate = this.dtpExec.Value.Date;
            this.ucDosageAlter1.Init();
            
        }

        private Funcations funcation = Funcations.配药;

        public Funcations Funcation 
        {
            get 
            {
                return this.funcation;
            }
            set 
            {
                this.funcation = value;
            }
        }
         
        public enum Funcations 
        {
            配药 = 0,

            注射,

            拔针
        }

        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader) 
            {
                return;
            }
            
            this.SetPatient(e.Row);
        }
    }
}