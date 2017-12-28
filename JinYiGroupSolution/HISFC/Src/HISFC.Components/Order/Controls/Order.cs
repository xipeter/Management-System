using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 医嘱控件]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    internal class Order
    {

        public string LONGSETTINGFILENAME = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "longordersetting.xml";
        public string SHORTSETTINGFILENAME = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "shortordersetting.xml";

        public DataSet dsAllLong = null;

        #region {1AF0EB93-27A8-462f-9A1E-E1A3ECA54ADE} 存储医嘱的哈希表、提高医嘱查询速度
        private System.Collections.Hashtable htOrder = new System.Collections.Hashtable();

        public System.Collections.Hashtable HtOrder
        {
            get
            {
                return htOrder;
            }
            set
            {
                htOrder = value;
            }
        }

        #endregion

        #region 初始化
        /// <summary>
        /// 设置DataSet
        /// </summary>
        /// <param name="dataSet"></param>
        public void  SetDataSet(ref System.Data.DataSet dataSet)
        {
            try
            {
                
                Type dtStr = System.Type.GetType("System.String");
                Type dtDbl = typeof(System.Double);
                Type dtInt = typeof(System.Int32);
                Type dtDecimal = typeof(System.Decimal);
                Type dtBoolean = typeof(System.Boolean);
                Type dtDate = typeof(System.DateTime);

                DataTable table = new DataTable("Table");
                table.Columns.AddRange(new DataColumn[] {
															new DataColumn("!",dtStr),     //0
															new DataColumn("期效",dtStr),     //0
															new DataColumn("医嘱类型",dtStr),//1
															new DataColumn("医嘱流水号",dtStr),//2
															new DataColumn("医嘱状态",dtStr),//新开立，审核，执行
															new DataColumn("组合号",dtStr),//4
															new DataColumn("主药",dtStr),//5
															new DataColumn("医嘱名称",dtStr),//6
															new DataColumn("组合",dtStr),     //0
															//new DataColumn("总量",dtInt),//7
                                                            new DataColumn("总量",dtDecimal),//7
															new DataColumn("总量单位",dtStr),//8
															new DataColumn("每次用量",dtDbl),//9
															new DataColumn("单位",dtStr),//10
															new DataColumn("付数",dtStr),//11
															new DataColumn("频次编码",dtStr),
															new DataColumn("频次名称",dtStr),
															new DataColumn("用法编码",dtStr),
															new DataColumn("用法名称",dtStr),//15
															new DataColumn("开始时间",dtStr),
															new DataColumn("停止时间",dtStr),//25
                                                            #region {62770BA9-AA59-4550-9020-9ABB323544AA}
                                                            new DataColumn("开立时间",dtStr),
                                                            #endregion
															new DataColumn("开立医生",dtStr),
															new DataColumn("执行科室编码",dtStr),
															new DataColumn("执行科室",dtStr),
															new DataColumn("加急",dtBoolean),
															new DataColumn("检查部位",dtStr),//31
															new DataColumn("样本类型/检查部位",dtStr),//32
															new DataColumn("扣库科室编码",dtStr),//33
															new DataColumn("扣库科室",dtStr),//34
															new DataColumn("备注",dtStr),//20
															new DataColumn("录入人编码",dtStr),
															new DataColumn("录入人",dtStr),
															new DataColumn("开立科室",dtStr),
															#region {62770BA9-AA59-4550-9020-9ABB323544AA}
                                                            //new DataColumn("开立时间",dtStr),
                                                            #endregion
															new DataColumn("停止人编码",dtStr),
															new DataColumn("停止人",dtStr),
															new DataColumn("顺序号",dtInt)//28
														});


                dataSet.Tables.Add(table);

                return ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ;
            }
        }

        /// <summary>
        /// 判断组合医嘱
        /// </summary>
        /// <param name="fpSpread1"></param>
        /// <returns></returns>
        public int ValidComboOrder(Neusoft.HISFC.BizLogic.Order.Order orderManagement)
        {
            Neusoft.HISFC.Models.Order.Frequency frequency = null;
            Neusoft.FrameWork.Models.NeuObject usage = null;
            Neusoft.FrameWork.Models.NeuObject exeDept = null;
            string sample = "";
            decimal amount = 0;
            int sysclass = -1;
            string sysClassID=string.Empty;
            DateTime dtBegin = new DateTime();
            for (int i = 0; i < fpSpread1.ActiveSheet.Rows.Count; i++)
            {
                if (fpSpread1.ActiveSheet.IsSelected(i, 0))
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order o = this.GetObjectFromFarPoint(i, fpSpread1.ActiveSheetIndex, orderManagement);

                    if (o.Status != 0)
                    {
                       
                        MessageBox.Show(string .Format("不符合组合条件，项目{0}状态不允许修改，请重新选择！",o.Item.Name));                       
                        return -1;
                    }
                    if (frequency == null)
                    {
                        frequency = o.Frequency.Clone();
                        usage = o.Usage.Clone();
                        sysclass = o.Item.SysClass.ID.GetHashCode();
                        sysClassID=o.Item.SysClass.ID.ToString();
                        exeDept = o.ExeDept.Clone();
                        sample = o.Sample.Name;
                        amount = o.Qty;
                        dtBegin = o.BeginTime;
                    }
                    else
                    {
                        o.BeginTime = dtBegin;
                        if (o.Frequency.ID != frequency.ID)
                        {
                            MessageBox.Show("频次不同，不可以组合用！");
                            return -1;
                        }
                        //if (o.Item.IsPharmacy)		//只对药品判断用法是否相同
                        if (o.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)		//只对药品判断用法是否相同
                        {
                            if (o.Item.SysClass.ID.ToString() != "PCC" && o.Usage.ID != usage.ID)
                            {
                                MessageBox.Show("用法不同，不可以组合用！");
                                return -1;
                            }
                            #region {B423CB4A-8E22-4aad-B847-76AAC7F9AD74}
                            if (sysClassID == "PCC")
                            {
                                if (o.Item.SysClass.ID.ToString() != sysClassID)
                                {
                                    MessageBox.Show("草药不可以和其他药品组合用！");
                                    return -1;
                                }
                            }
                            else
                            {
                                if (o.Item.SysClass.ID.ToString() == "PCC")
                                {
                                    MessageBox.Show("草药不可以和其他药品组合用！");
                                    return -1;
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            if (o.Item.SysClass.ID.ToString() == "UL")//检验
                            {
                                if (o.Qty != amount)
                                {
                                    MessageBox.Show("检验数量不同，不可以组合用！");
                                    return -1;
                                }
                                if (o.Sample.Name != sample)
                                {
                                    MessageBox.Show("检验样本不同，不可以组合用！");
                                    return -1;
                                }
                            }
                        }


                        if (o.ExeDept.ID != exeDept.ID)
                        {
                            MessageBox.Show("执行科室不同，不能组合使用!", "提示");
                            return -1;
                        }
                    }
                }
               
            }
            return 0;

        }
        public FarPoint.Win.Spread.FpSpread fpSpread1 = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="SheetIndex"></param>
        /// <param name="OrderManagement"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Order.Inpatient.Order GetObjectFromFarPoint(int i, int SheetIndex,Neusoft.HISFC.BizLogic.Order.Order OrderManagement)
        {
            Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
            if (this.fpSpread1.Sheets[SheetIndex].Rows[i].Tag != null)
            {
                order = this.fpSpread1.Sheets[SheetIndex].Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
            }
            #region {1AF0EB93-27A8-462f-9A1E-E1A3ECA54ADE} 再从哈希表中取值
            else if (this.htOrder != null && this.htOrder.ContainsKey(this.fpSpread1.Sheets[SheetIndex].Cells[i, iColumns[2]].Text))
            {
                order = this.htOrder[this.fpSpread1.Sheets[SheetIndex].Cells[i, iColumns[2]].Text] as Neusoft.HISFC.Models.Order.Inpatient.Order;
            }
            #endregion
            else
            {
                #region 付值
                order = OrderManagement.QueryOneOrder(this.fpSpread1.Sheets[SheetIndex].Cells[i, iColumns[2]].Text);
                #endregion
            }
            return order;
        }

        #endregion

        #region "对应"
        public int[] iColumns;
        public int[] iColumnWidth;
        /// <summary>
        /// 设置列属性
        /// </summary>
        public  void SetColumnProperty()
        {
            if (System.IO.File.Exists(LONGSETTINGFILENAME))
            {
                if (iColumnWidth == null || iColumnWidth.Length <= 0)
                {
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1.Sheets[0], LONGSETTINGFILENAME);
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1.Sheets[1], SHORTSETTINGFILENAME);

                    iColumnWidth = new int[40];
                    for (int i = 0; i < this.fpSpread1.Sheets[0].Columns.Count; i++)
                    {
                        iColumnWidth[i] = (int)this.fpSpread1.Sheets[0].Columns[i].Width;
                    }
                }
                else
                {
                    for (int i = 0; i < this.fpSpread1.Sheets[0].Columns.Count; i++)
                    {
                        this.fpSpread1.Sheets[0].Columns[i].Width = iColumnWidth[i];
                        this.fpSpread1.Sheets[1].Columns[i].Width = iColumnWidth[i];
                    }
                }
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1.Sheets[0], LONGSETTINGFILENAME);
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1.Sheets[0], SHORTSETTINGFILENAME);
            }
        }
        public  void SetColumnWidth()
        {
            this.iColumnWidth = new int[40];
            this.iColumnWidth[0] = 56;
            this.iColumnWidth[1] = 10;
            this.iColumnWidth[2] = 56;
            this.iColumnWidth[3] = 10;
            this.iColumnWidth[4] = 10;
            this.iColumnWidth[5] = 10;
            this.iColumnWidth[6] = 10;
            this.iColumnWidth[7] = 185;
            this.iColumnWidth[8] = 15;
            this.iColumnWidth[9] = 31;
            this.iColumnWidth[10] = 31;
            this.iColumnWidth[11] = 46;
            this.iColumnWidth[12] = 31;
            this.iColumnWidth[13] = 33;
            this.iColumnWidth[14] = 33;
            this.iColumnWidth[15] = 10;
            this.iColumnWidth[16] = 10;
            this.iColumnWidth[17] = 31;
            this.iColumnWidth[18] = 76;//开始时间
            this.iColumnWidth[19] = 76;//停止时间
            this.iColumnWidth[20] = 56;//开立医生
            this.iColumnWidth[21] = 10;//执行科室编码
            this.iColumnWidth[22] = 56;//执行科室
            this.iColumnWidth[23] = 19;//加急
            this.iColumnWidth[24] = 56;//检查部位
            this.iColumnWidth[26] = 56;//样本类型
            this.iColumnWidth[27] = 10;//扣库科室编码
            this.iColumnWidth[28] = 56;//扣库科室
            this.iColumnWidth[29] = 56;
            this.iColumnWidth[30] = 56;
            this.iColumnWidth[31] = 56;
            this.iColumnWidth[32] = 56;
            this.iColumnWidth[33] = 56;
            this.iColumnWidth[34] = 56;
            this.iColumnWidth[35] = 56;
            this.iColumnWidth[36] = 56;
            this.iColumnWidth[37] = 10;
            this.iColumnWidth[38] = 10;
            this.iColumnWidth[39] = 10;
        }
        /// <summary>
        /// 通过列名获得列索引
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int GetColumnIndexFromName(string Name)
        {
            for (int i = 0; i < dsAllLong.Tables[0].Columns.Count; i++)
            {
                if (dsAllLong.Tables[0].Columns[i].ColumnName == Name) return i;
            }
            MessageBox.Show("缺少列" + Name);
            return -1;
        }
        public void ColumnSet()
        {
            iColumns = new int[40];
            iColumns[0] = this.GetColumnIndexFromName("期效");     //Type
            iColumns[1] = this.GetColumnIndexFromName("医嘱类型");//OrderType
            iColumns[2] = this.GetColumnIndexFromName("医嘱流水号");//ID
            iColumns[3] = this.GetColumnIndexFromName("医嘱状态");//新开立，审核，执行State
            iColumns[4] = this.GetColumnIndexFromName("组合号");//4 ComboNo
            iColumns[5] = this.GetColumnIndexFromName("主药");//5 MainDrug
            iColumns[6] = this.GetColumnIndexFromName("医嘱名称");//6 Nameer	
            iColumns[7] = this.GetColumnIndexFromName("总量");//7	Qty
            iColumns[8] = this.GetColumnIndexFromName("总量单位");//8 PackUnit
            iColumns[9] = this.GetColumnIndexFromName("每次用量");//9 DoseOnce
            iColumns[10] = this.GetColumnIndexFromName("单位");//10 doseUnit
            iColumns[11] = this.GetColumnIndexFromName("付数");//11 Fu
            iColumns[12] = this.GetColumnIndexFromName("频次编码"); //FrequencyCode
            iColumns[13] = this.GetColumnIndexFromName("频次名称"); //FrequecyName
            iColumns[14] = this.GetColumnIndexFromName("用法编码"); //UsageCode
            iColumns[15] = this.GetColumnIndexFromName("用法名称");//15
            iColumns[16] = this.GetColumnIndexFromName("开始时间");
            iColumns[17] = this.GetColumnIndexFromName("执行科室编码");
            iColumns[18] = this.GetColumnIndexFromName("执行科室");
            iColumns[19] = this.GetColumnIndexFromName("加急");
            iColumns[20] = this.GetColumnIndexFromName("备注");//20
            iColumns[21] = this.GetColumnIndexFromName("录入人编码");
            iColumns[22] = this.GetColumnIndexFromName("录入人");
            iColumns[23] = this.GetColumnIndexFromName("开立科室");
            iColumns[24] = this.GetColumnIndexFromName("开立时间");
            iColumns[25] = this.GetColumnIndexFromName("停止时间");//25
            iColumns[26] = this.GetColumnIndexFromName("停止人编码");
            iColumns[27] = this.GetColumnIndexFromName("停止人");
            iColumns[28] = this.GetColumnIndexFromName("顺序号");//28
            iColumns[29] = this.GetColumnIndexFromName("开立医生");
            iColumns[30] = this.GetColumnIndexFromName("组合");
            iColumns[31] = this.GetColumnIndexFromName("检查部位");
            iColumns[32] = this.GetColumnIndexFromName("样本类型/检查部位");
            iColumns[33] = this.GetColumnIndexFromName("扣库科室编码");
            iColumns[34] = this.GetColumnIndexFromName("扣库科室");
            iColumns[35] = this.GetColumnIndexFromName("!");


        }

        public void SetColumnName(int k)
        {
            this.fpSpread1.Sheets[k].Columns.Count = 100;
            int i = 0;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("!");    //0
            this.fpSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("期效");     //0
            this.fpSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("医嘱类型");//1
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("医嘱流水号");//2
            this.fpSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("医嘱状态");//新开立，审核，执行
            this.fpSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("组合号");//4
            this.fpSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("主药");//5
            this.fpSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("医嘱名称");//6
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("组");    //0
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("总量");//7
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("单位");//8
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("每次量");//9
            this.fpSpread1.Sheets[k].Columns[i].CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            ((FarPoint.Win.Spread.CellType.NumberCellType)this.fpSpread1.Sheets[k].Columns[i].CellType).DecimalPlaces = 3;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("单位");//10
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("付数");//11
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("频次");
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("频次名称");
            this.fpSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("用法编码");
            this.fpSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("用法");//15
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("开始时间");
            this.fpSpread1.Sheets[k].Columns[i].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("停止时间");//25
            this.fpSpread1.Sheets[k].Columns[i].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            i++;
            #region {62770BA9-AA59-4550-9020-9ABB323544AA}
            this.fpSpread1.Sheets[k].Columns[i].Label = ("开立时间");
            this.fpSpread1.Sheets[k].Columns[i].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            i++;
            #endregion
            this.fpSpread1.Sheets[k].Columns[i].Label = ("开立医生");
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("执行科室编码");
            this.fpSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("执行科室");
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("急");
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("检查部位");
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("样本类型/检查部位");
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("扣库科室编码");
            this.fpSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("扣库科室");
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("备注");//20
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("录入人编码");
            this.fpSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("录入人");
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("开立科室");
            i++;
            #region {62770BA9-AA59-4550-9020-9ABB323544AA}
            //this.fpSpread1.Sheets[k].Columns[i].Label = ("开立时间");
            //this.fpSpread1.Sheets[k].Columns[i].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            //i++;
            #endregion
            this.fpSpread1.Sheets[k].Columns[i].Label = ("停止人编码");
            this.fpSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("停止人");
            i++;
            this.fpSpread1.Sheets[k].Columns[i].Label = ("顺序号");//28
            i++;
            this.fpSpread1.Sheets[k].Columns.Count = i;
        }

        #endregion

        #region 函数
        /// <summary>
        /// 保存格式
        /// </summary>
        public void SaveGrid()
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1.Sheets[0], this.LONGSETTINGFILENAME);
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1.Sheets[1], this.SHORTSETTINGFILENAME);
                MessageBox.Show("显示格式保存成功！请重新登录后生效。");
            }
            catch { }
        }

        #endregion

        #region 暂时
        //#region 全部删除、停止医嘱 Add By liangjz 2005-08
        ///// <summary>
        ///// 删除当前活动医嘱类别所有已审核、执行医嘱
        ///// </summary>
        ///// <param name="delSheet">待删除医嘱类别0 长嘱 1 临嘱</param>
        //public void DelAllApprove(int delSheet)
        //{
        //    if (this.ValidDel(delSheet, "1", false) == -1) return;
        //    DialogResult r;
        //    r = MessageBox.Show("是否停止所有长期医嘱?  \n *此操作不能撤消！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        //    if (r == DialogResult.OK)
        //        this.DelAll(delSheet, "1", false);
        //}
        ///// <summary>
        ///// 删除当前活动医嘱类别内所有选择的新开未审核医嘱
        ///// </summary>
        //public void DelAllSelect()
        //{
        //    if (this.ValidDel(this.fpSpread1.ActiveSheetIndex, "0", true) == -1) return;
        //    DialogResult r;
        //    r = MessageBox.Show("是否删除当前选择医嘱?  \n *此操作不能撤消！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        //    if (r == DialogResult.OK)
        //        this.DelAll(this.fpSpread1.ActiveSheetIndex, "0", true);
        //}
        ///// <summary>
        ///// 全部删除、停止医嘱
        ///// </summary>
        ///// <param name="orderType">长、临嘱标志 0 长嘱 1 临嘱 2 全部医嘱</param>
        ///// <param name="delFlag">是否删除标志 0 删除所有未审核 1 停止、作废所有审核医嘱、保留新开医嘱 2 删除、停止所有新开，已审核医嘱</param>
        ///// <param name="isNeedSelection">是否需要选择的行才可以操作</param>
        //public void DelAll(int orderType, string delFlag, bool isNeedSelection)
        //{
        //    DateTime dtEnd = new DateTime();
        //    Neusoft.FrameWork.Models.NeuObject dcReason = new Neusoft.FrameWork.Models.NeuObject();
        //    if (delFlag == "1" || delFlag == "2")
        //    {		//需要选择停止时间
        //        Forms.frmDCOrder fTest = new Forms.frmDCOrder();
        //        fTest.ShowDialog();
        //        if (fTest.DialogResult != DialogResult.OK)
        //        {
        //            return;
        //        }
        //        dtEnd = fTest.DCDateTime;
        //        dcReason = fTest.DCReason.Clone();
        //    }
        //    switch (orderType)
        //    {
        //        case 0:
        //        case 1:
        //            {
        //                switch (delFlag)
        //                {
        //                    case "0":
        //                    case "1":
        //                        if (this.DelSheet(orderType, delFlag, isNeedSelection, dtEnd, dcReason) == -1) return;
        //                        break;
        //                    case "2":
        //                        if (this.DelSheet(orderType, "0", isNeedSelection, dtEnd, dcReason) == -1) return;
        //                        if (this.DelSheet(orderType, "1", isNeedSelection, dtEnd, dcReason) == -1) return;
        //                        break;
        //                }
        //            }
        //            break;
        //        case 2:
        //            switch (delFlag)
        //            {
        //                case "0":
        //                case "1":
        //                    if (this.DelSheet(0, delFlag, isNeedSelection, dtEnd, dcReason) == -1) return;
        //                    if (this.DelSheet(1, delFlag, isNeedSelection, dtEnd, dcReason) == -1) return;
        //                    break;
        //                case "2":
        //                    if (this.DelSheet(0, "0", isNeedSelection, dtEnd, dcReason) == -1) return;
        //                    if (this.DelSheet(1, "0", isNeedSelection, dtEnd, dcReason) == -1) return;
        //                    if (this.DelSheet(1, "1", isNeedSelection, dtEnd, dcReason) == -1) return;
        //                    if (this.DelSheet(0, "1", isNeedSelection, dtEnd, dcReason) == -1) return;
        //                    break;
        //            }
        //            break;
        //    }

        //}
        ///// <summary>
        ///// 是否允许停止、删除
        ///// </summary>
        ///// <param name="delSheet">0 长嘱  1 临嘱</param>
        ///// <param name="delFlag">0 新开未审核 1 已审核或执行</param>
        ///// <param name="isNeedSelection">是否需要选择才有效</param>
        ///// <returns>成功返回1 失败返回－1</returns>
        //public int ValidDel(int delSheet, string delFlag, bool isNeedSelection)
        //{
        //    Neusoft.HISFC.Models.Order.Inpatient.Order info = new Neusoft.HISFC.Models.Order.Inpatient.Order();
        //    bool isApprove = false;		//存在已审核或执行数据
        //    bool isSelect = false;		//存在选择行

        //    for (int i = 0; i < this.fpSpread1.Sheets[delSheet].Rows.Count; i++)
        //    {
        //        info = this.fpSpread1.Sheets[delSheet].Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
        //        if (info.Status == 1 || info.Status == 2)			//存在已审核或执行
        //            isApprove = true;
        //        if (this.fpSpread1.Sheets[delSheet].IsSelected(i, 0) && info.Status == 0)	//存在选择行
        //            isSelect = true;
        //        //全存在的时候不需要在判断
        //        if (isApprove && isSelect)
        //            break;
        //    }

        //    if (delFlag == "0" && isNeedSelection && !isSelect)
        //    {
        //        MessageBox.Show("请选择待删除的新开医嘱");
        //        return -1;
        //    }
        //    if (delFlag == "1" && !isApprove)
        //    {
        //        MessageBox.Show("不存在已审核或执行的有效医嘱");
        //        return -1;
        //    }
        //    return 1;
        //}
        ///// <summary>
        ///// 对制定长、临嘱删除、停止医嘱
        ///// </summary>
        ///// <param name="delSheet">待删除、停止医嘱类别SheetIndex</param>
        ///// <param name="delFlag">是否删除标志 0 删除所有未审核 1 停止、作废所有审核医嘱</param>
        /////<param name="isNeedSelection">是否需要选择的行才有效</param>
        /////<param name="dtEnd">医嘱停止时间</param>
        /////<param name="dcReason">医嘱停止原因</param>
        ///// <returns>成功1 失败－1</returns>
        //private int DelSheet(int delSheet, string delFlag, bool isNeedSelection, DateTime dtEnd, Neusoft.FrameWork.Models.NeuObject dcReason)
        //{
        //    if (this.fpSpread1.Sheets[delSheet].Rows.Count <= 0) return -1;
        //    Neusoft.HISFC.Models.Order.Inpatient.Order info;
        //    bool isDo = false;
        //    if (isNeedSelection && delFlag == "0")
        //    {
        //        for (int i = 0; i < this.fpSpread1.Sheets[delSheet].Rows.Count; i++)
        //        {
        //            //标志所有选择行
        //            if (this.fpSpread1.Sheets[delSheet].IsSelected(i, 0))
        //            {

        //                this.fpSpread1.Sheets[delSheet].Cells[i, this.myOrderClass.iColumns[0]].Tag = "1";
        //            }
        //        }
        //    }

        //    //事务声明
        //    Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.OrderManagement.Connection);
        //    //Neusoft.HISFC.BizLogic.RADT.InPatient inPatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        //    t.BeginTransaction();
        //    this.OrderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

        //    string nurseStation = "";
        //    int rowCount = this.fpSpread1.Sheets[delSheet].Rows.Count;
        //    for (int i = rowCount - 1; i >= 0; i--)
        //    {
        //        info = this.fpSpread1.Sheets[delSheet].Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
        //        if (info == null)
        //        {
        //            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
        //            MessageBox.Show("处理第" + (i + 1).ToString() + "行出错\n类型转换错误");
        //            return -1;
        //        }
        //        nurseStation = info.NurseStation.ID;

        //        if (delFlag == "0")
        //        {				//删除所有未审核医嘱
        //            #region 删除所有未审核
        //            if ((string)this.fpSpread1.Sheets[delSheet].Cells[i, this.myOrderClass.iColumns[0]].Tag == "1" && info.Status == 0)
        //            {    //已选择且未审核
        //                if (info.ID == "")
        //                {		//新开、尚未保存
        //                    //自然删除
        //                    isDo = true;
        //                    this.fpSpread1.Sheets[delSheet].Rows.Remove(i, 1);
        //                }
        //                else
        //                {					//已保存未审核医嘱 
        //                    isDo = true;
        //                    int iParm = this.OrderManagement.DeleteOrder(info);
        //                    if (iParm == -1)
        //                    {
        //                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
        //                        MessageBox.Show(this.OrderManagement.Err);
        //                        return -1;
        //                    }
        //                    else
        //                    {
        //                        if (iParm == 0)
        //                        {
        //                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
        //                            MessageBox.Show("医嘱状态已发生变化 请刷新屏幕");
        //                            return -1;
        //                        }
        //                    }
        //                    //删除附材
        //                    if (OrderManagement.DeleteOrderSubtbl(info.Combo.ID) == -1)
        //                    {
        //                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
        //                        MessageBox.Show(this.OrderManagement.Err);
        //                        return -1;
        //                    }

        //                    this.fpSpread1.Sheets[delSheet].Rows.Remove(i, 1);
        //                }
        //            }

        //            #endregion
        //        }
        //        else if (delFlag == "1")
        //        {
        //            if (info.Status == 1 || info.Status == 2)
        //            {
        //                info.DCOper.OperTime = dtEnd;
        //                info.DcReason = dcReason.Clone();
        //                info.DCOper.ID = this.OrderManagement.Operator.ID;
        //                info.DCOper.Name = this.OrderManagement.Operator.Name;
        //                info.EndTime = info.DCOper.OperTime;

        //                isDo = true;
        //                #region 停止医嘱
        //                //预停止时间设定
        //                if (dtEnd.Date > this.OrderManagement.GetDateTimeFromSysDateTime().Date)
        //                {
        //                    if (this.OrderManagement.UpdateOrder(info) == -1)
        //                    {
        //                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
        //                        MessageBox.Show(this.OrderManagement.Err);
        //                        return -1;
        //                    }
        //                }
        //                else
        //                {			//直接停止
        //                    string strReturn = "";
        //                    info.Status = 3;
        //                    if (this.OrderManagement.DcOrder(info, true, out strReturn) == -1)
        //                    {
        //                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
        //                        MessageBox.Show(this.OrderManagement.Err);
        //                        return -1;
        //                    }

        //                    if (strReturn != "")
        //                    {
        //                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
        //                        MessageBox.Show(strReturn);
        //                        return -1;
        //                    }

        //                    this.fpSpread1.Sheets[delSheet].Rows[i].Tag = info;
        //                    this.fpSpread1.Sheets[delSheet].Cells[i, this.myOrderClass.iColumns[3]].Value = info.Status;
        //                }
        //            }
        //                #endregion
        //        }
        //    }

        //    Neusoft.FrameWork.Management.PublicTrans.Commit();


        //    //对停止医嘱设置状态
        //    if (delFlag != "0")
        //    {
        //        for (int i = 0; i < this.fpSpread1.Sheets[delSheet].Rows.Count; i++)
        //        {
        //            this.AddObjectToFarpoint(this.fpSpread1.Sheets[delSheet].Rows[i].Tag, i, delSheet);
        //        }
        //    }
        //    //删除一行后选择下一行 
        //    if (this.fpSpread1.Sheets[delSheet].Rows.Count > 0)
        //    {
        //        this.SelectionChanged();
        //    }
        //    else
        //        this.ucItemSelect1.Clear();

        //    //停止或作废医嘱时发送消息到护理站
        //    //if (delFlag != "0" && nurseStation != "")
        //    //    Neusoft.Common.Class.Message.SendMessage(this.PatientInfo.Patient.Name + "的医嘱已经全部停止", nurseStation);

        //    //更新状态			
        //    if (isDo)
        //    {


        //        this.RefreshCombo();
        //        this.RefreshOrderState();
        //    }
        //    return 1;
        //}
         //#endregion
        #endregion

    }
}
