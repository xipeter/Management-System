using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Report.Order
{
    /// <summary>
    /// 医嘱单打印包含续打
    /// </summary>
    public partial class ucOrderPrintNew : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.HISFC.BizProcess.Interface.IPrintOrder
    {
        /// <summary>
        /// 
        /// </summary>
        public ucOrderPrintNew()
        {
            InitializeComponent();
        }

        //初始化长期医嘱和临时医嘱 列表
        ArrayList alLong = new ArrayList();
        ArrayList alShort = new ArrayList();
        //存储没有打印的医嘱列表
        ArrayList alLong1 = new ArrayList();
        ArrayList alShort1 = new ArrayList();
        //存储长期医嘱和临时医嘱目前打印到的页数，用于提示用户
        int longordercurrentpage = 1;
        int shortordercurrentpage = 1;

        #region 变量

        ////医嘱业务
        //private Neusoft.HISFC.BizLogic.Order.Order ordManager = new Neusoft.HISFC.BizLogic.Order.Order();

        //患者信息
        private Neusoft.HISFC.Models.RADT.PatientInfo pInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        //人员信息
        private Neusoft.HISFC.BizLogic.Manager.Person person = new Neusoft.HISFC.BizLogic.Manager.Person();

        /// 科室帮助类
        private Neusoft.FrameWork.Public.ObjectHelper objHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        //报表医嘱打印业务类
        private Neusoft.WinForms.Report.Order.Function myfun = new Neusoft.WinForms.Report.Order.Function();

        //医嘱单打印
        private Neusoft.HISFC.BizLogic.Order.OrderBill orderBillMgr = new Neusoft.HISFC.BizLogic.Order.OrderBill();

        //每页最多条数
        private const int orderline = 27;

        #endregion

        #region IPrintOrder 成员
        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            //MessageBox.Show("长期医嘱请插入第" + this.longordercurrentpage.ToString() + "页\n\t" + "临时医嘱请插入第"+this.shortordercurrentpage.ToString() + "页");
            #region 续打更新打印标记 
            if (this.checkBox1.Checked)
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                if (this.tabControl1.SelectedIndex == 0)//长期医嘱
                {
                    foreach (object obj in alLong1)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order order = obj as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        //User03 是否打印过 
                        if (order.User03 != "1")
                        {
                            if (this.myfun.UpdateOrderStatus(order.ID, "1") == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(myfun.Err);
                                return;
                            }
                        }
                        if (order.Status == 3 && order.EndTime.ToString() != System.DateTime.MinValue.ToString())
                        {
                            if (this.orderBillMgr.UpdatePrinStopFlag(order.ID) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(orderBillMgr.Err);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    foreach (object obj in alShort1)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order order = obj as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        if (order.User03 != "1")
                        {
                            if (this.myfun.UpdateOrderStatus(order.ID, "1") == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(myfun.Err);
                                return;
                            }
                        }
                        if (order.Status == 3 && order.EndTime.ToString() != System.DateTime.MinValue.ToString())
                        {
                            if (this.orderBillMgr.UpdatePrinStopFlag(order.ID) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(orderBillMgr.Err);
                                return;
                            }
                        }
                    }
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            else //不是续打
            {
                if (this.tabControl1.SelectedIndex == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    foreach (object obj in alLong)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order order = obj as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        if (order.User03 != "1")
                        {
                            if (this.myfun.UpdateOrderStatus(order.ID, "1") == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(myfun.Err);
                                return;
                            }
                        }
                        if (order.Status == 3 && order.EndTime.ToString() != System.DateTime.MinValue.ToString())
                        {
                            if (this.orderBillMgr.UpdatePrinStopFlag(order.ID) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(orderBillMgr.Err);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    foreach (object obj in alShort)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order order = obj as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        if (order.User03 != "1")
                        {
                            if (this.myfun.UpdateOrderStatus(order.ID, "1") == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(myfun.Err);
                                return;
                            }
                        }
                        if (order.Status == 3 && order.EndTime.ToString() != System.DateTime.MinValue.ToString())
                        {
                            if (this.orderBillMgr.UpdatePrinStopFlag(order.ID) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(orderBillMgr.Err);
                                return;
                            }
                        }
                    }
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            #endregion
            #region 长期医嘱
            if (tabControl1.SelectedIndex == 0)
            {
                if (this.checkBox1.Checked)
                {
                    if (this.alLong1.Count > 0)
                    {
                        MessageBox.Show("长期医嘱插入" + this.longordercurrentpage.ToString() + "页");
                    }
                    else
                    {
                        MessageBox.Show("没有要打印的续打医嘱");
                        return;
                    }
                }
                Neusoft.WinForms.Report.Common.frmPreviewDataWindow frm = new Neusoft.WinForms.Report.Common.frmPreviewDataWindow();
                frm.PreviewDataWindow = this.dwLongOrder;
                frm.Show();
            }
            #endregion
            #region 临时医嘱
            else
            {
                if (this.checkBox1.Checked)
                {
                    if (this.alShort1.Count > 0)
                    {
                        MessageBox.Show("临时医嘱插入" + this.shortordercurrentpage.ToString() + "页");
                    }
                    else
                    {
                        MessageBox.Show("没有要打印的续打医嘱");
                        return;
                    }
                }
                Neusoft.WinForms.Report.Common.frmPreviewDataWindow frm = new Neusoft.WinForms.Report.Common.frmPreviewDataWindow();
                frm.PreviewDataWindow = this.dwShortOrder;
                frm.Show();
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientInfo"></param>
        public void SetPatient(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            #region 初始化 数据窗口
            this.dwLongOrder.LibraryList =@"Report\met_ord.pbl;Report\met_ord.pbd";
            this.dwShortOrder.LibraryList = @"Report\met_ord.pbl;Report\met_ord.pbd";
            this.dwLongOrder.DataWindowObject = "d_longorder_print";
            this.dwShortOrder.DataWindowObject = "d_shortorder_print";
            #endregion
            #region 初始化全部医嘱
            pInfo = patientInfo;
            
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询显示医嘱信息,请稍候......");
            Application.DoEvents();
            ArrayList alAll = new ArrayList();
            try
            {
                alAll = this.myfun.QueryDcOrder(patientInfo.ID);
            }
            catch
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }

            alLong.Clear();
            alShort.Clear();
            
            if (alAll != null)
            {
                foreach (object obj in alAll)
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = obj as Neusoft.HISFC.Models.Order.Inpatient.Order;
                    if (order.Status == 0) continue;
                    //停止标志是否打印过
                    Neusoft.HISFC.Models.Order.OrderBill orderBill = null;
                    orderBill = this.orderBillMgr.GetOrderBillByOrderID(order.ID);
                    if (orderBill != null)
                    {
                        order.User01 = orderBill.PrintDCFlag;
                        //order.User03 = orderBill.PrintFlag;
                    }
                    else
                    {
                        order.User01 = "0";
                        //order.User03 = "0";
                    }
                    if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG)
                    {
                        //长期医嘱
                        alLong.Add(obj);
                    }
                    else
                    {
                        //临时医嘱
                        alShort.Add(obj);
                    }
                }
            }
            #endregion
            #region 分长期和临时写入数据窗口
            if (this.tabControl1.SelectedIndex == 0)
                AddDataToLongOrder(alLong,"0");
            else
                AddDataToShortOrder(alShort,"0");
           
           
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            #endregion
        }

        /// <summary>
        /// 续打
        /// </summary>
        /// <param name="patientInfo"></param>
        public void SetPatientOn(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            #region 初始化数据窗口
            //this.dwLongOrder.LibraryList = @"Report\met_ord.pbl;Report\met_ord.pbd";
            //this.dwShortOrder.LibraryList = @"Report\met_ord.pbl;Report\met_ord.pbd";
            //this.dwLongOrder.DataWindowObject = "d_longorderon_print";
            //this.dwShortOrder.DataWindowObject = "d_shortorderon_print";
            pInfo = patientInfo;
            #endregion

            //Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询显示续打医嘱信息,请稍候......");
            #region 查询打印和没有打印的医嘱
            Application.DoEvents();
            //存储打印过的医嘱
            ArrayList alPrinted = new ArrayList();
            //存储没有打印的医嘱
            ArrayList alNoPrint = new ArrayList();
            ArrayList alAll = new ArrayList();

            try
            {
                //已经打印的医嘱
                alPrinted = this.myfun.QueryDcOrder(patientInfo.ID,"1");
                //没有打印的医嘱
                alNoPrint = this.myfun.QueryDcOrder(patientInfo.ID,"0");
            }
            catch
            {
                //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            //存储没有打印过的长期和临时医嘱
            alLong1.Clear();
            alShort1.Clear();
            alLong.Clear();
            alShort.Clear();

            #endregion

            #region 打印过的医嘱区分长期医嘱和临时医嘱
            if (alPrinted != null)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
                Neusoft.HISFC.Models.Order.OrderBill orderbill = null;
                foreach (object obj in alPrinted)
                {
                    
                    order = obj as Neusoft.HISFC.Models.Order.Inpatient.Order;
                    if (order.Status == 0) continue;
                    orderbill = this.orderBillMgr.GetOrderBillByOrderID(order.ID);
                    if (orderbill != null)
                    {
                        order.User01 = orderbill.PrintDCFlag;
                        order.User03 = orderbill.PrintFlag;
                    }
                    else
                    {
                        order.User01 = "0";
                        order.User03 = "0";
                    }
                    if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG)
                    {
                        //长期医嘱
                        alLong.Add(order);
                    }
                    else
                    {
                        //临时医嘱
                        alShort.Add(order);
                    }
                }
            }
            #endregion

            #region 没有打印过的医嘱区分长期医嘱和临时医嘱
            if (alNoPrint != null)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
                Neusoft.HISFC.Models.Order.OrderBill orderbill = null;
                foreach (object obj in alNoPrint)
                {
                    order = obj as Neusoft.HISFC.Models.Order.Inpatient.Order;
                    orderbill = this.orderBillMgr.GetOrderBillByOrderID(order.ID);
                    if (orderbill != null)
                    {
                        order.User01 = orderbill.PrintDCFlag;
                    }
                    else
                    {
                        order.User01 = "0";
                    }
                    //order.User03 = orderbill.PrintFlag;
                    if (order.Status == 0) continue;
                    if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG)
                    {
                        //长期医嘱
                        alLong1.Add(order);
                    }
                    else
                    {
                        //临时医嘱
                        alShort1.Add(order);
                    }
                }
            }
            #endregion

            #region 续打开始
            //上次打印到的行数 25倍的 整数倍取余数
            int longleave = 0;
            int shortleave = 0;

            //取余
            longleave = alLong.Count % orderline;
            shortleave = alShort.Count % orderline;

            //本次应该打印到的页数
            this.longordercurrentpage = alLong.Count / orderline + 1;
            this.shortordercurrentpage = alShort.Count / orderline + 1;

            ArrayList alLongTemp = new ArrayList();
            ArrayList alShortTemp = new ArrayList();
            if(longleave >= 0)
            {
                alLongTemp = alLong.GetRange( alLong.Count - longleave, longleave);
            }
            if(shortleave >= 0)
            {
                alShortTemp = alShort.GetRange(alShort.Count - shortleave, shortleave);
            }
            alLongTemp.AddRange(alLong1);
            alShortTemp.AddRange(alShort1);
            #endregion

            #region 显示打印
            if (this.tabControl1.SelectedIndex == 0)
                AddDataToLongOrder(alLongTemp,"1");
            else
                AddDataToShortOrder(alShortTemp,"1");
            #endregion

            //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }
        /// <summary>
        /// 
        /// </summary>
        public void ShowPrintSet()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        #region 方法

        /// <summary>
        /// 长期 续打
        /// </summary>
        /// <param name="al"></param>
        /// <param name="sgoon"></param>
        private void AddDataToLongOrder(ArrayList al,string sgoon)
        {
            this.dwLongOrder.Reset();
          
            #region 写报表标题
            this.dwLongOrder.Modify("t_3.text ='" + Neusoft.HISFC.BizProcess.Integrate.Function.GetHosName() + "'");
            this.dwLongOrder.Modify("t_name.text ='" + pInfo.Name + "'");
            this.dwLongOrder.Modify("t_sex.text ='" + pInfo.Sex.Name + "'");
            this.dwLongOrder.Modify("t_age.text ='" + pInfo.Age + "'");
            this.dwLongOrder.Modify("t_inpatientno.text ='" + pInfo.ID + "'");
            this.dwLongOrder.Modify("t_bed.text ='" + pInfo.PVisit.PatientLocation.Bed.ToString() + "'");
            this.dwLongOrder.Modify("t_dept.text ='" + pInfo.PVisit.PatientLocation.Dept.Name + "'");
            #endregion

            #region 变量定义
            Neusoft.HISFC.Models.Order.Inpatient.Order order = new Neusoft.HISFC.Models.Order.Inpatient.Order();
            Neusoft.HISFC.Models.Pharmacy.Item item = null;
            ArrayList all = new ArrayList();//存储所有需要修改的组
            ArrayList combLocation = new ArrayList();//需要存储的数据
            ArrayList tempComb = new ArrayList();//需要存储的数据
            string tempID = (al.Count > 0) ? ((Neusoft.HISFC.Models.Order.Inpatient.Order)al[0]).Combo.ID : "";
            string combID = "";
            int count = 1;//判断是否是组，是否需要存储
            int alcount = 0;//一共有多少条医嘱
            int times = al.Count;//总共要循环次数（初始和医嘱条数一样，随着增加组的频次后增加）
            string frequency = "";//临时存储组的频次
            string name = "";//存储组里药的名词
            Neusoft.HISFC.Models.Order.Inpatient.Order tempobj = new Neusoft.HISFC.Models.Order.Inpatient.Order();//保存组里的第一条药品
            #endregion

            #region 循环写医嘱
            for (int i = 0; i < times; i++)
            {
                order = al[alcount] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                this.dwLongOrder.InsertRow();
                int rows = this.dwLongOrder.RowCount;

                combID = order.Combo.ID;
                if (i > 0)
                {
                #region 当组合不同而且count大于1时说明是下一条要显示组的频次
                    if (tempID != combID && count > 1)
                    {
                        //取上一条医嘱
                        Neusoft.HISFC.Models.Order.Inpatient.Order tempOrder = al[alcount - 1] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        //起始日期
                        this.dwLongOrder.SetItemDateTime(rows, 1, tempOrder.MOTime);
                        //起始时间
                        this.dwLongOrder.SetItemDateTime(rows, 2, tempOrder.MOTime);
                        this.dwLongOrder.SetItemString(rows, 14, tempOrder.User03);
                        this.dwLongOrder.SetItemDecimal(rows, 15, longordercurrentpage);
                        this.dwLongOrder.SetItemString(rows, 16, sgoon);
                        this.dwLongOrder.SetItemString(rows, 17, tempOrder.User01);
                        this.dwLongOrder.SetItemString(rows, 3, frequency);
                        this.dwLongOrder.SetItemString(rows, 13, "dfdf");//防止组合号相同
                        
                        //医嘱者
                        this.dwLongOrder.SetItemString(rows, 5, tempOrder.ReciptDoctor.Name);
                        //处理者
                        this.dwLongOrder.SetItemString(rows, 6, objHelper.GetName(tempOrder.Nurse.ID));
                        //处理时间
                        if (tempOrder.ConfirmTime != DateTime.MinValue)
                        {
                            this.dwLongOrder.SetItemDateTime(rows, 7, tempOrder.ConfirmTime);
                        }
                        //如果医嘱已经停止
                        if (tempOrder.EndTime != DateTime.MinValue)
                        {
                            //停止日期
                            this.dwLongOrder.SetItemDateTime(rows, 8, tempOrder.EndTime);
                            //停止时间
                            this.dwLongOrder.SetItemDateTime(rows, 9, tempOrder.EndTime);
                            //停止医生
                            this.dwLongOrder.SetItemString(rows, 10, tempOrder.DCOper.Name);
                            //停止护士（处理者）
                            this.dwLongOrder.SetItemString(rows, 11, objHelper.GetName(tempOrder.ExecOper.ID));
                            //处理者处理时间
                            if (order.ExecOper.OperTime != DateTime.MinValue)
                            {
                                this.dwLongOrder.SetItemDateTime(rows, 12, tempOrder.ExecOper.OperTime);
                            }
                        }

                        times++;//增加了一行，需要增加一次循环次数
                        count = 1;//
                        tempID = "fuck";//防止组合号相同
                        tempComb = combLocation.Clone() as ArrayList;
                        all.Add(tempComb);//保持最后需要改的药品信息
                        combLocation.Clear();//清空数据供下一次使用
                        continue;
                    }
                    //if (tempID == combID)
                    //{
                    //    Neusoft.HISFC.Models.Order.Inpatient.Order obj = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                    //    obj.ID = rows.ToString();
                    //    if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                    //    {
                    //        item = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                    //        obj.Name = order.Item.Name + "  " + order.DoseOnce + item.DoseUnit;
                    //    }
                    //    if (combLocation.Count == 0)
                    //    {
                    //        combLocation.Add(obj);
                    //        Neusoft.HISFC.Models.Order.Inpatient.Order o = tempobj.Clone();
                    //        combLocation.Add(o);
                    //    }
                    //    else
                    //    {
                    //        combLocation.Add(obj);
                    //    }
                    //    count++;
                    //}
                }
                #endregion

                //起始日期
                this.dwLongOrder.SetItemDateTime(rows, 1, order.MOTime);
                //起始时间
                this.dwLongOrder.SetItemDateTime(rows, 2, order.MOTime);
                #region 药品频次
                if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    item = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                    //药品医嘱
                    this.dwLongOrder.SetItemString(rows, 3, order.Item.Name + "  " + order.DoseOnce + item.DoseUnit + " " + order.Usage.Name.ToLower() + " " + order.Frequency.ID.ToLower() + " " + order.Memo);
                    frequency = "                      " + order.Usage.Name.ToLower() + " " + ((order.Frequency.ID.ToUpper() == "WPC") ? null : order.Frequency.ID.ToLower());
                    name = order.Item.Name + "  " + order.DoseOnce + item.DoseUnit ;
                }
                #endregion

                #region 非药品频次
                else
                {
                    //非药品医嘱
                    if (order.Frequency.ID == "WPC")
                    {
                        this.dwLongOrder.SetItemString(rows, 3, order.Item.Name + "  " + order.Usage.Name.ToLower() + order.Memo);
                    }
                    else
                    {
                        this.dwLongOrder.SetItemString(rows, 3, order.Item.Name + "  " + order.Usage.Name.ToLower() + "  " + order.Frequency.ID.ToLower() + " " + order.Memo);
                    }
                }
                #endregion
                //组合
                this.dwLongOrder.SetItemString(rows, 13, order.Combo.ID);
                //医嘱者
                this.dwLongOrder.SetItemString(rows, 5, order.ReciptDoctor.Name);
                //处理者
                this.dwLongOrder.SetItemString(rows, 6, objHelper.GetName(order.Nurse.ID));
                //处理时间
                if (order.ConfirmTime != DateTime.MinValue)
                {
                    this.dwLongOrder.SetItemDateTime(rows, 7, order.ConfirmTime);
                }
                #region 停止医嘱
                //如果医嘱已经停止
                if (order.EndTime != DateTime.MinValue)
                {
                    //停止日期
                    this.dwLongOrder.SetItemDateTime(rows, 8, order.EndTime);
                    //停止时间
                    this.dwLongOrder.SetItemDateTime(rows, 9, order.EndTime);
                    //停止医生
                    this.dwLongOrder.SetItemString(rows, 10, order.DCOper.Name);
                    //停止护士（处理者）
                    this.dwLongOrder.SetItemString(rows, 11, objHelper.GetName(order.ExecOper.ID));
                    //处理者处理时间
                    if (order.ExecOper.OperTime != DateTime.MinValue)
                    {
                        this.dwLongOrder.SetItemDateTime(rows, 12, order.ExecOper.OperTime);
                    }
                }
                #endregion
                this.dwLongOrder.SetItemString(rows, 14, order.User03);//是否打印过
                this.dwLongOrder.SetItemDecimal(rows, 15, longordercurrentpage);
                this.dwLongOrder.SetItemString(rows, 16, sgoon);
                this.dwLongOrder.SetItemString(rows, 17, order.User01);//是否打印过停止
                tempobj.ID = rows.ToString();
                tempobj.Name = name;
                tempID = combID;
                alcount++;
            }
            #endregion
            
            /*

            #region  如果最后一行是组需要再单独增加频次行
            //如果最后一行是组需要再单独增加频次行
            if (tempID == combID && count > 1)
            {
                this.dwLongOrder.InsertRow();
                //起始日期
                this.dwLongOrder.SetItemDateTime(this.dwLongOrder.RowCount, 1, order.MOTime);
                //起始时间
                this.dwLongOrder.SetItemDateTime(this.dwLongOrder.RowCount, 2, order.MOTime);
                this.dwLongOrder.SetItemString(this.dwLongOrder.RowCount, 14, order.User03);
                this.dwLongOrder.SetItemString(this.dwLongOrder.RowCount, 3, frequency);
                this.dwLongOrder.SetItemString(this.dwLongOrder.RowCount, 13, "dfd");
                this.dwLongOrder.SetItemString(this.dwLongOrder.RowCount, 14, order.User03);
                this.dwLongOrder.SetItemDecimal(this.dwLongOrder.RowCount, 15, longordercurrentpage);
                //是否是续打
                this.dwLongOrder.SetItemString(this.dwLongOrder.RowCount, 16, sgoon);
                //是否打印了停止时间
                this.dwLongOrder.SetItemString(this.dwLongOrder.RowCount,17, order.User01);

                //医嘱者
                this.dwLongOrder.SetItemString(this.dwLongOrder.RowCount, 5, order.ReciptDoctor.Name);
                //处理者
                this.dwLongOrder.SetItemString(this.dwLongOrder.RowCount, 6, objHelper.GetName(order.Nurse.ID));
                //处理时间
                if (order.ConfirmTime != DateTime.MinValue)
                {
                    this.dwLongOrder.SetItemDateTime(this.dwLongOrder.RowCount, 7, order.ConfirmTime);
                }
                //如果医嘱已经停止
                if (order.EndTime != DateTime.MinValue)
                {
                    //停止日期
                    this.dwLongOrder.SetItemDateTime(this.dwLongOrder.RowCount, 8, order.EndTime);
                    //停止时间
                    this.dwLongOrder.SetItemDateTime(this.dwLongOrder.RowCount, 9, order.EndTime);
                    //停止医生
                    this.dwLongOrder.SetItemString(this.dwLongOrder.RowCount, 10, order.DCOper.Name);
                    //停止护士（处理者）
                    this.dwLongOrder.SetItemString(this.dwLongOrder.RowCount, 11, objHelper.GetName(order.ExecOper.ID));
                    //处理者处理时间
                    if (order.ExecOper.OperTime != DateTime.MinValue)
                    {
                        this.dwLongOrder.SetItemDateTime(this.dwLongOrder.RowCount, 12, order.ExecOper.OperTime);
                    }
                }
            }
            for (int i = this.dwLongOrder.RowCount; i >= 2; i--)
            {
                if (!dwLongOrder.IsItemNull(i, 13) && !dwLongOrder.IsItemNull(i - 1, 13) && !dwLongOrder.IsItemNull(i - 1, 10))
                    if (this.dwLongOrder.GetItemString(i, 13) == this.dwLongOrder.GetItemString(i - 1, 13))
                    {
                        this.dwLongOrder.SetItemString(i - 1, 10, dwLongOrder.GetItemString(i, 10));
                    }
            }
            #endregion

            #region 循环完后添加最后需要修改的组
            if (combLocation.Count != 0)
                        {
                            tempComb = combLocation.Clone() as ArrayList;
                            all.Add(tempComb);
                            combLocation.Clear();
                        }
                        //修改所有需要修改的组
                        for (int j = 0; j < all.Count; j++)
                        {
                            ArrayList yunal = all[j] as ArrayList;
                            for (int k = 0; k < yunal.Count; k++)
                            {
                                Neusoft.HISFC.Models.Order.Inpatient.Order changeobj = yunal[k] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                                this.dwLongOrder.SetItemString(Convert.ToInt16(changeobj.ID), 3, changeobj.Name);
                                //this.dwLongOrder.SetItemString(Convert.ToInt16(changeobj.ID), 17, changeobj.User01);
                            }
                        }

            Neusoft.WinForms.Report.Order.Function.DrawCombo(dwLongOrder, 13, 4);
            //Neusoft.HISFC.Components.Common.Classes.Function.DrawCombo(dwLongOrder, 13, 4);
            #endregion

            */
            Neusoft.WinForms.Report.Order.Function.DrawCombo(dwLongOrder, 13, 4);
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="al"></param>
        /// <param name="sgoon"></param>
        private void AddDataToShortOrder(ArrayList al,string sgoon)
        {
            this.dwShortOrder.Reset();
            #region 写报表标题
            this.dwShortOrder.Modify("t_3.text ='" + Neusoft.HISFC.BizProcess.Integrate.Function.GetHosName() + "'");
            this.dwShortOrder.Modify("t_name.text ='" + pInfo.Name + "'");
            this.dwShortOrder.Modify("t_sex.text ='" + pInfo.Sex.Name + "'");
            this.dwShortOrder.Modify("t_age.text ='" + pInfo.Age + "'");
            this.dwShortOrder.Modify("t_inpatientno.text ='" + pInfo.ID + "'");
            this.dwShortOrder.Modify("t_bed.text ='" + pInfo.PVisit.PatientLocation.Bed.ToString() + "'");
            this.dwShortOrder.Modify("t_dept.text ='" + pInfo.PVisit.PatientLocation.Dept.Name + "'");
            #endregion

            #region  变量定义
            Neusoft.HISFC.Models.Order.Inpatient.Order order = new Neusoft.HISFC.Models.Order.Inpatient.Order();
            Neusoft.HISFC.Models.Pharmacy.Item item = null;
            ArrayList all = new ArrayList();//存储所有需要修改的组
            ArrayList combLocation = new ArrayList();//需要存储的数据
            ArrayList tempComb = new ArrayList();//需要存储的数据
            string tempID = (al.Count > 0) ? ((Neusoft.HISFC.Models.Order.Inpatient.Order)al[0]).Combo.ID : "";
            string combID = "";
            int count = 1;//判断是否是组，是否需要存储
            int alcount = 0;//一共有多少条医嘱
            int times = al.Count;//总共要循环次数（初始和医嘱条数一样，随着增加组的频次后增加）
            string frequency = "";//临时存储组的频次
            string name = "";//存储组里药的名词
            Neusoft.HISFC.Models.Order.Inpatient.Order tempobj = new Neusoft.HISFC.Models.Order.Inpatient.Order();//保存组里的第一条药品
            #endregion

            #region 循环医嘱
            for (int i = 0; i < times; i++)
            {
                this.dwShortOrder.InsertRow();
                int rows = this.dwShortOrder.RowCount;
                order = al[alcount] as Neusoft.HISFC.Models.Order.Inpatient.Order;

                combID = order.Combo.ID;
                if (i > 0)
                {
                    //当组合不同而且count大于1时说明是下一条要显示组的频次
                    if (tempID != combID && count > 1)
                    {
                        //取上一条医嘱，就是组合里的那条
                        Neusoft.HISFC.Models.Order.Inpatient.Order tempOrder = al[alcount - 1] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        //起始日期
                        this.dwShortOrder.SetItemDateTime(rows, 1, tempOrder.BeginTime);
                        //起始时间
                        this.dwShortOrder.SetItemDateTime(rows, 2, tempOrder.BeginTime);

                        this.dwShortOrder.SetItemString(rows, 3, frequency);
                        this.dwShortOrder.SetItemString(rows, 10, tempOrder.User03);
                        this.dwShortOrder.SetItemDecimal(rows, 11, this.shortordercurrentpage);
                        this.dwShortOrder.SetItemString(rows, 12, sgoon);
                        this.dwShortOrder.SetItemString(rows, 13, tempOrder.User01);
                        //医嘱者
                        this.dwShortOrder.SetItemString(rows, 5, tempOrder.ReciptDoctor.Name);
                        //处理者
                        this.dwShortOrder.SetItemString(rows, 6, objHelper.GetName(tempOrder.Nurse.ID));
                        //处理日期
                        if (order.ConfirmTime != DateTime.MinValue)
                        {
                            this.dwShortOrder.SetItemDateTime(rows, 7, tempOrder.ConfirmTime);
                        }
                        //处理时间
                        if (order.ConfirmTime != DateTime.MinValue)
                        {
                            this.dwShortOrder.SetItemDateTime(rows, 8, tempOrder.ConfirmTime);
                        }

                        this.dwShortOrder.SetItemString(rows, 9, "dfdf");//防止组合号相同

                        times++;//增加了一行，需要增加一次循环次数
                        count = 1;//
                        tempID = "fuck";//防止组合号相同
                        tempComb = combLocation.Clone() as ArrayList;
                        all.Add(tempComb);//保持最后需要改的药品信息
                        combLocation.Clear();//清空数据供下一次使用
                        continue;
                    }
                    //if (tempID == combID)
                    //{
                    //    Neusoft.HISFC.Models.Order.Inpatient.Order obj = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                    //    obj.ID = rows.ToString();
                    //    if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                    //    {
                    //        item = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                    //        obj.Name = order.Item.Name + "  " + order.DoseOnce + item.DoseUnit;
                    //    }
                    //    if (combLocation.Count == 0)
                    //    {
                    //        combLocation.Add(obj);
                    //        Neusoft.HISFC.Models.Order.Inpatient.Order o = tempobj.Clone();
                    //        combLocation.Add(o);
                    //    }
                    //    else
                    //    {
                    //        combLocation.Add(obj);
                    //    }
                    //    count++;
                    //}
                }

                //起始日期
                this.dwShortOrder.SetItemDateTime(rows, 1, order.BeginTime);
                //起始时间
                this.dwShortOrder.SetItemDateTime(rows, 2, order.BeginTime);

                #region 药品频次处理
                if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    item = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                    //药品医嘱
                    if (order.Memo == "备用" || order.Memo == "术中用" || order.Memo == "检查中用")
                    {//医嘱备注如果是“备用”等三者之一，就只显示规格*数量
                        this.dwShortOrder.SetItemString(rows, 3, order.Item.Name + "  " + order.Item.Specs + "*" + order.Qty + order.Unit + " " + order.Memo);
                    }
                    else if (order.Frequency.ID.ToUpper() != "ST" && order.Frequency.ID.ToUpper() != "SOS")
                    {//临时药嘱除了ST和SOS频次，其他频次都不打印
                        this.dwShortOrder.SetItemString(rows, 3, order.Item.Name + "  " + order.DoseOnce + item.DoseUnit + " " + order.Usage.Name.ToLower());
                        frequency = "                                         " + order.Usage.Name.ToLower() + " " + order.Memo;
                    }
                    else
                    {
                        this.dwShortOrder.SetItemString(rows, 3, order.Item.Name + "  " + order.DoseOnce + item.DoseUnit + " " + order.Usage.Name.ToLower() + " " + order.Frequency.ID.ToLower());
                        frequency = "                                         " + order.Usage.Name.ToLower() + " " + ((order.Frequency.ID.ToUpper() == "WPC") ? null : order.Frequency.ID.ToLower()) + " " + order.Memo;
                    }
                    name = order.Item.Name + "  " + order.DoseOnce + item.DoseUnit;
                }
                #endregion

                #region 非药品频次处理
                else
                {//非药品医嘱
                    if (order.Memo == "备用" || order.Memo == "术中用" || order.Memo == "检查中用")
                    {//医嘱备注如果是“备用”等三者之一，就只显示规格*数量
                        this.dwShortOrder.SetItemString(rows, 3, order.Item.Name + "  " + order.Item.Specs + "*" + order.Qty + " " + order.Memo);
                    }
                    else if(order.Frequency.ID != "ST" && order.Frequency.ID != "SOS")
                    {//非药品不管是无频次还是什么，只要不是ST或者SOS就不显示频次
                        this.dwShortOrder.SetItemString(rows, 3, order.Item.Name + "  " + order.Usage.Name.ToLower() + " " + order.Memo);
                    }
                    else
                    {
                        this.dwShortOrder.SetItemString(rows, 3, order.Item.Name + "  " + order.Usage.Name.ToLower() + "  " + order.Frequency.ID.ToLower() + " "  +order.Memo);
                    }
                }
                #endregion

                this.dwShortOrder.SetItemString(rows, 10, order.User03);
                this.dwShortOrder.SetItemDecimal(rows, 11, this.shortordercurrentpage);
                this.dwShortOrder.SetItemString(rows, 12, sgoon);
                this.dwShortOrder.SetItemString(rows, 13, order.User01);
                //组合
                this.dwShortOrder.SetItemString(rows, 9, order.Combo.ID);
                //医嘱者
                this.dwShortOrder.SetItemString(rows, 5, order.ReciptDoctor.Name);
                //处理者
                this.dwShortOrder.SetItemString(rows, 6, objHelper.GetName(order.Nurse.ID));

                //处理日期
                if (order.ConfirmTime != DateTime.MinValue)
                {
                    this.dwShortOrder.SetItemDateTime(rows, 7, order.ConfirmTime);
                }
                //处理时间
                if (order.ConfirmTime != DateTime.MinValue)
                {
                    this.dwShortOrder.SetItemDateTime(rows, 8, order.ConfirmTime);
                }
                tempobj.ID = rows.ToString();
                tempobj.Name = name;
                tempID = combID;
                alcount++;
            }
            #endregion
            /*
            #region  如果最后一行是组需要再单独增加频次行
            //如果最后一行是组需要再单独增加频次行
            if (tempID == combID && count > 1)
            {
                this.dwShortOrder.InsertRow();
                //起始日期
                this.dwShortOrder.SetItemDateTime(this.dwShortOrder.RowCount, 1, order.BeginTime);
                //起始时间
                this.dwShortOrder.SetItemDateTime(this.dwShortOrder.RowCount, 2, order.BeginTime);

                this.dwShortOrder.SetItemString(this.dwShortOrder.RowCount, 3, frequency);
                this.dwShortOrder.SetItemString(this.dwShortOrder.RowCount, 10, order.User03);
                this.dwShortOrder.SetItemDecimal(this.dwShortOrder.RowCount, 11, this.shortordercurrentpage);
                this.dwShortOrder.SetItemString(this.dwShortOrder.RowCount, 12, sgoon);

                //医嘱者
                this.dwShortOrder.SetItemString(this.dwShortOrder.RowCount, 5, order.ReciptDoctor.Name);
                //处理者
                this.dwShortOrder.SetItemString(this.dwShortOrder.RowCount, 6, objHelper.GetName(order.Nurse.ID));
                //处理日期
                if (order.ConfirmTime != DateTime.MinValue)
                {
                    this.dwShortOrder.SetItemDateTime(this.dwShortOrder.RowCount, 7, order.ConfirmTime);
                }
                //处理时间
                if (order.ConfirmTime != DateTime.MinValue)
                {
                    this.dwShortOrder.SetItemDateTime(this.dwShortOrder.RowCount, 8, order.ConfirmTime);
                }
                this.dwShortOrder.SetItemString(this.dwShortOrder.RowCount, 9, "dfd");
                this.dwShortOrder.SetItemString(this.dwShortOrder.RowCount, 13, order.User01);
            }
            #endregion

            #region 组合号
            //循环完后添加最后需要修改的组
            if (combLocation.Count != 0)
            {
                tempComb = combLocation.Clone() as ArrayList;
                all.Add(tempComb);
                combLocation.Clear();
            }
            //修改所有需要修改的组
            for (int j = 0; j < all.Count; j++)
            {
                ArrayList yunal = all[j] as ArrayList;
                for (int k = 0; k < yunal.Count; k++)
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order changeobj = yunal[k] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                    this.dwShortOrder.SetItemString(Convert.ToInt16(changeobj.ID), 3, changeobj.Name);
                    //this.dwShortOrder.SetItemString(Convert.ToInt16(changeobj.ID), 13, changeobj.User01);
                }
            }
             *  #endregion
             * */

            //Neusoft.WinForms.Report.Order.Function.DrawCombo(dwLongOrder, 9, 4);
            Neusoft.WinForms.Report.Order.Function.DrawCombo(dwShortOrder, 9, 4);
           
           
        }
        /// <summary>
        /// 画组合号方法
        /// </summary>
        /// <param name="o"></param>
        /// <param name="column"></param>
        /// <param name="DrawColumn"></param>
        private void DrawCombo(NeuDataWindow.Controls.NeuDataWindow o, int column, int DrawColumn)
        {
            if (o.RowCount < 1)//如果没有医嘱返回
                return;
            int i = 0;
            string tmp = "", curComboNo = "";
            tmp = o.GetItemString(1, (short)column);
            for (i = 2; i <= o.RowCount; i++)
            {
                curComboNo = o.GetItemString(i, (short)column);
                if (tmp == curComboNo)
                {
                    //组合号相等，如果上一个没有标志说明是组合的第一个
                    if (o.IsItemNull(i - 1, (short)DrawColumn))
                    {
                        //组合第一个赋值
                        o.SetItemSqlString(i - 1, (short)DrawColumn, "┓");
                        //如果是最后一行
                        if (i == o.RowCount)
                            o.SetItemString(i, (short)DrawColumn, "┛");
                        else
                            o.SetItemString(i, (short)DrawColumn, "┃");//这里不管是否是一组最后一个，最后一个在组合号不等时才设置
                    }
                    else
                    {
                        //如果是最后一行
                        if (i == o.RowCount)
                            o.SetItemString(i, (short)DrawColumn, "┛");
                        else
                            o.SetItemString(i, (short)DrawColumn, "┃");                        
                    }
                }
                else
                {
                    //组合号不等，这时会改变在组合号相等时设置的"┃"或者"┓"，为"┛"
                    if (!o.IsItemNull(i - 1, (short)DrawColumn))
                    {
                        //设置一组的最后一个符合
                        if (o.GetItemString(i - 1, (short)DrawColumn) == "┃" || o.GetItemString(i - 1, (short)DrawColumn) == "┓")
                            o.SetItemString(i - 1, (short)DrawColumn, "┛");
                    }
                }
                tmp = curComboNo;
            }
        }

        #endregion

        #region 事件
        private void ucOrderPrintXajd_Load(object sender, EventArgs e)
        {
            this.objHelper.ArrayObject = person.GetEmployeeAll();
        }

        

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dwLongOrder.SetRedrawOff();
            this.dwShortOrder.SetRedrawOff();
            if (this.checkBox1.Checked)
            { this.SetPatientOn(pInfo); }
            else
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    AddDataToLongOrder(alLong,"0");
                }
                else
                {
                    AddDataToShortOrder(alShort,"0");
                }
            }
            this.dwLongOrder.SetRedrawOn();
            this.dwShortOrder.SetRedrawOn();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.dwLongOrder.SetRedrawOff();
            this.dwShortOrder.SetRedrawOff();
            if (checkBox1.Checked)
            {
                this.SetPatientOn(pInfo);
            }
            else
            {
                this.SetPatient(pInfo);
            }
            this.dwLongOrder.SetRedrawOn();
            this.dwShortOrder.SetRedrawOn();
        }
        #endregion
    }
}
