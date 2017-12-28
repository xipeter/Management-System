using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Components.Order.Classes
{
    /// <summary>
    /// [功能描述: 医嘱公用函数]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class Function
    {
        #region 医嘱管理
        /// <summary>
        /// 设置医嘱首次频次信息
        /// </summary>
        /// <param name="order"></param>
        public static void SetDefaultOrderFrequency(Neusoft.HISFC.Models.Order.Inpatient.Order order)
        {
            if (order.OrderType.IsDecompose || order.OrderType.ID == "CD" || 
                order.OrderType.ID == "QL")//默认为项目的频次
            {
                if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
                {
                    order.Frequency = (order.Item as Neusoft.HISFC.Models.Pharmacy.Item).Frequency.Clone();
                    order.Frequency.Time = "25:00";//默认为２５点，需要更新
                }
            }
            //else if (order.Item.IsPharmacy && order.OrderType.IsDecompose == false)//药品 临时医嘱，频次为空，默认为需要时候服用prn
            else if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug && order.OrderType.IsDecompose == false)//药品 临时医嘱，频次为空，默认为需要时候服用prn
            {
                order.Frequency.ID = "PRN";//药品临时医嘱默认为需要时执行
            }
            //else if (order.Item.IsPharmacy == false && order.OrderType.IsDecompose == false)
            else if (order.Item.ItemType != EnumItemType.Drug && order.OrderType.IsDecompose == false)
            {
                //{7ED952A2-0516-40c5-A548-719DB81D9633} 非药品临嘱的默认频次 按系统类别，检查、检验默认ST，转科转床出院手术会诊默认为ST(以后可能会改), 剩下默认QD 20100909
                //order.Frequency.ID = "QD";//非药品临时医嘱默认为每天一次
                if (order.Item.SysClass.ID.ToString() == Neusoft.HISFC.Models.Base.EnumSysClass.UC.ToString()
                || order.Item.SysClass.ID.ToString() == Neusoft.HISFC.Models.Base.EnumSysClass.UL.ToString())
                {
                    order.Frequency.ID = "ST";
                }
                else if (order.Item.SysClass.ID.ToString() == Neusoft.HISFC.Models.Base.EnumSysClass.MRB.ToString()
                || order.Item.SysClass.ID.ToString() == Neusoft.HISFC.Models.Base.EnumSysClass.MRD.ToString()
                || order.Item.SysClass.ID.ToString() == Neusoft.HISFC.Models.Base.EnumSysClass.MRH.ToString()
                || order.Item.SysClass.ID.ToString() == Neusoft.HISFC.Models.Base.EnumSysClass.UO.ToString()
                || order.Item.SysClass.ID.ToString() == Neusoft.HISFC.Models.Base.EnumSysClass.MC.ToString())
                {
                    order.Frequency.ID = "PRN";
                }
                else
                {
                    order.Frequency.ID = "QD";//临时医嘱默认QD
                }
            }
        }

        /// <summary>
        /// 是否允许开立
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static bool IsPermission(Neusoft.HISFC.Models.RADT.PatientInfo patient
            ,Neusoft.HISFC.Models.Order.OrderType orderType
            ,Neusoft.HISFC.Models.Base.Item item)
        {
            return false;
        }

        /// <summary>
        /// 根据医嘱类别判断,是否自动计算总量
        /// </summary>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public static bool IsAutoCalTotal(Neusoft.HISFC.Models.Order.OrderType orderType)
        {
            return false;
        }

        /// <summary>
        /// 计算总量
        /// </summary>
        /// <param name="order"></param>
        /// <returns>0 成功 -1失败</returns>
        public static int CalTotal(Neusoft.HISFC.Models.Order.Inpatient.Order order,int days)
        {
            Neusoft.HISFC.Models.Pharmacy.Item item = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
            #region 获得时间点
            if (order.Frequency.Usage.ID == "") order.Frequency.Usage = order.Usage.Clone();
            //***************获得频次时间点(每天多少次)******************
            if (days == 0) days = 1;
            #endregion
            if (item.OnceDose == 0M)//一次剂量为零，默认显示基本剂量
                order.Qty = order.Frequency.Times.Length * days;
            else
                order.Qty = item.OnceDose / item.BaseDose * order.Frequency.Times.Length * days;

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isShort"></param>
        public static System.Collections.ArrayList OrderCatatagory(bool isShort)
        {
            System.Collections.ArrayList al = Neusoft.HISFC.Models.Base.SysClassEnumService.List();
            Neusoft.FrameWork.Models.NeuObject objAll = new Neusoft.FrameWork.Models.NeuObject();
            objAll.ID = "ALL";
            objAll.Name = "全部";
            al.Add(objAll);
            //if (isShort) return al;//临时医嘱显示全部
            if (isShort)
            {
                ArrayList alShort = new ArrayList();
                foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
                {
                    if (obj.ID.Length > 2 && obj.ID.Substring(0, 3) == "PCC")//PCZ 中成药，PCC 中草药
                    {
                    }
                    else
                    {
                        alShort.Add(obj);
                    }
                }
                return alShort;
            }

            //长期医嘱屏蔽些东西

            System.Collections.ArrayList rAl = new ArrayList();
            foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            {
                if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "MR")//非药品，转科，转床
                {

                }
                else if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "UO")//手术
                {
                }
                else if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "UC")//检查
                {
                }
                else if (obj.ID.Length > 1 &&  obj.ID.Substring(0, 2) == "UL")	//检验
                {
                }
                else  if (obj.ID.Length > 2 && obj.ID.Substring(0, 3) == "PCC")//PCZ 中成药，PCC 中草药
                {
                 }
                else if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "MC")//会诊
                {
                }
                else
                {
                    rAl.Add(obj);
                }
            }
            return rAl;
        }

        

        /// <summary>
        /// 皮试字样
        /// </summary>
        public const string TipHypotest = "(需皮试)";

      
        #endregion

        #region 常用常数
        
        private static Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private static Neusoft.FrameWork.Public.ObjectHelper helpUsage = null;
        /// <summary>
        /// 用法
        /// </summary>
        public static Neusoft.FrameWork.Public.ObjectHelper HelperUsage
        {
            get
            {
                if(helpUsage == null)
                    helpUsage = new Neusoft.FrameWork.Public.ObjectHelper(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE));
                return helpUsage;
            }
            set
            {
                helpUsage = value;
            }
        }

        private static Neusoft.FrameWork.Public.ObjectHelper helpFrequency = null;
        /// <summary>
        /// 频次
        /// </summary>
        public static Neusoft.FrameWork.Public.ObjectHelper HelperFrequency
        {
            get
            {
                if (helpFrequency == null)
                    helpFrequency = new Neusoft.FrameWork.Public.ObjectHelper(manager.QuereyFrequencyList());
                return helpFrequency;
            }
            set
            {
                helpFrequency = value;
            }
        }

        #region 新增样本和检查部位{0A4BC81A-2F2B-4dae-A8E6-C8DC1F87AA32}

        private static Neusoft.FrameWork.Public.ObjectHelper helpSample = null;
        /// <summary>
        /// 样本
        /// </summary>
        public static Neusoft.FrameWork.Public.ObjectHelper HelperSample
        {
            get
            {
                if (helpSample == null)
                    helpSample = new Neusoft.FrameWork.Public.ObjectHelper(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.LABSAMPLE));
                return helpSample;
            }
            set
            {
                helpSample = value;
            }
        }

        private static Neusoft.FrameWork.Public.ObjectHelper helpCheckPart = null;
        /// <summary>
        /// 检查部位
        /// </summary>
        public static Neusoft.FrameWork.Public.ObjectHelper HelperCheckPart
        {
            get
            {
                if (helpCheckPart == null)
                    helpCheckPart = new Neusoft.FrameWork.Public.ObjectHelper(manager.GetConstantList("CHECKPART"));
                return helpCheckPart;
            }
            set
            {
                helpCheckPart = value;
            }
        }

        #endregion

        #endregion

        #region "是否默认开立医嘱时间"
        protected static bool bIsDefaultMoDate = false;
        protected static bool bFirst = true;//计数器
        /// <summary>
        /// 是否默认开立医嘱时间
        /// </summary>
        public static bool IsDefaultMoDate
        {
            get
            {
                if (bFirst)
                {
                    try//获得是否修改 开立时间添加首日量200012
                    {
                        Neusoft.FrameWork.Management.ControlParam mControl = new Neusoft.FrameWork.Management.ControlParam();
                        bIsDefaultMoDate = Neusoft.FrameWork.Function.NConvert.ToBoolean(mControl.QueryControlerInfo("200012"));
                    }
                    catch { }
                    bFirst = false;
                }
                else
                {
                }
                return bIsDefaultMoDate;
            }
        }
        #endregion

        #region 新开医嘱默认生效间隔天数

        protected static int moDateDays = 0;
        protected static bool isInitMoDateDays = true;

        public static int MoDateDays
        {
            get
            {
                if (isInitMoDateDays)
                {
                    Neusoft.FrameWork.Management.ControlParam mControl = new Neusoft.FrameWork.Management.ControlParam();
                    moDateDays = Neusoft.FrameWork.Function.NConvert.ToInt32(mControl.QueryControlerInfo("200040"));

                    isInitMoDateDays = false;
                }

                return moDateDays;
            }
        }

        #endregion

        #region 组合医嘱 传入的对象，column 组合项目列
        /// <summary>
        /// 括号在右边
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="column"></param>
        /// <param name="DrawColumn"></param>
        /// <param name="ChildViewLevel"></param>
        public static void DrawCombo(object sender, int column, int DrawColumn, int ChildViewLevel)
        {
            switch (sender.GetType().ToString().Substring(sender.GetType().ToString().LastIndexOf(".") + 1))
            {
                case "SheetView":
                    FarPoint.Win.Spread.SheetView o = sender as FarPoint.Win.Spread.SheetView;
                    int i = 0;
                    string tmp = "", curComboNo = "";
                    if (ChildViewLevel == 0)
                    {
                        for (i = 0; i < o.RowCount; i++)
                        {
                            #region "画"
                            if (o.Cells[i, column].Text == "0") o.Cells[i, column].Text = "";
                            tmp = o.Cells[i, column].Text + "";
                            o.Cells[i, column].Tag = tmp;
                            if (curComboNo != tmp && tmp != "") //是头
                            {
                                curComboNo = tmp;
                                o.Cells[i, DrawColumn].Text = "┓";
                                try
                                {
                                    if (o.Cells[i - 1, DrawColumn].Text == "┃")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "┛";
                                    }
                                    else if (o.Cells[i - 1, DrawColumn].Text == "┓")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "";
                                    }
                                }
                                catch { }
                            }
                            else if (curComboNo == tmp && tmp != "")
                            {
                                o.Cells[i, DrawColumn].Text = "┃";
                            }
                            else if (curComboNo != tmp && tmp == "")
                            {
                                try
                                {
                                    if (o.Cells[i - 1, DrawColumn].Text == "┃")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "┛";
                                    }
                                    else if (o.Cells[i - 1, DrawColumn].Text == "┓")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "";
                                    }
                                }
                                catch { }
                                o.Cells[i, DrawColumn].Text = "";
                                curComboNo = "";
                            }
                            if (i == o.RowCount - 1 && o.Cells[i, DrawColumn].Text == "┃") o.Cells[i, DrawColumn].Text = "┛";
                            if (i == o.RowCount - 1 && o.Cells[i, DrawColumn].Text == "┓") o.Cells[i, DrawColumn].Text = "";
                            //o.Cells[i, DrawColumn].ForeColor = System.Drawing.Color.Red;
                            #endregion
                        }
                    }
                    else if (ChildViewLevel == 1)
                    {
                        for (int m = 0; m < o.RowCount; m++)
                        {
                            FarPoint.Win.Spread.SheetView c = o.GetChildView(m, 0);
                            for (int j = 0; j < c.RowCount; j++)
                            {
                                #region "画"
                                if (c.Cells[j, column].Text == "0") c.Cells[j, column].Text = "";
                                tmp = c.Cells[j, column].Text + "";

                                c.Cells[j, column].Tag = tmp;
                                if (curComboNo != tmp && tmp != "") //是头
                                {
                                    curComboNo = tmp;
                                    c.Cells[j, DrawColumn].Text = "┓";
                                    try
                                    {
                                        if (c.Cells[j - 1, DrawColumn].Text == "┃")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "┛";
                                        }
                                        else if (c.Cells[j - 1, DrawColumn].Text == "┓")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "";
                                        }
                                    }
                                    catch { }
                                }
                                else if (curComboNo == tmp && tmp != "")
                                {
                                    c.Cells[j, DrawColumn].Text = "┃";
                                }
                                else if (curComboNo != tmp && tmp == "")
                                {
                                    try
                                    {
                                        if (c.Cells[j - 1, DrawColumn].Text == "┃")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "┛";
                                        }
                                        else if (c.Cells[j - 1, DrawColumn].Text == "┓")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "";
                                        }
                                    }
                                    catch { }
                                    c.Cells[j, DrawColumn].Text = "";
                                    curComboNo = "";
                                }
                                if (j == c.RowCount - 1 && c.Cells[j, DrawColumn].Text == "┃") c.Cells[j, DrawColumn].Text = "┛";
                                if (j == c.RowCount - 1 && c.Cells[j, DrawColumn].Text == "┓") c.Cells[j, DrawColumn].Text = "";
                                //c.Cells[j, DrawColumn].ForeColor = System.Drawing.Color.Red;
                                #endregion

                            }
                        }
                    }
                    break;
            }

        }
        /// <summary>
        /// 括号在左边
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="column"></param>
        /// <param name="DrawColumn"></param>
        /// <param name="ChildViewLevel"></param>
        public static void DrawComboLeft(object sender, int column, int DrawColumn, int ChildViewLevel)
        {
            switch (sender.GetType().ToString().Substring(sender.GetType().ToString().LastIndexOf(".") + 1))
            {
                case "SheetView":
                    FarPoint.Win.Spread.SheetView o = sender as FarPoint.Win.Spread.SheetView;
                    int i = 0;
                    string tmp = "", curComboNo = "";
                    if (ChildViewLevel == 0)
                    {
                        for (i = 0; i < o.RowCount; i++)
                        {
                            #region "画"
                            if (o.Cells[i, column].Text == "0") o.Cells[i, column].Text = "";
                            tmp = o.Cells[i, column].Text + "";
                            o.Cells[i, column].Tag = tmp;
                            if (curComboNo != tmp && tmp != "") //是头
                            {
                                curComboNo = tmp;
                                o.Cells[i, DrawColumn].Text = "┏";
                                try
                                {
                                    if (o.Cells[i - 1, DrawColumn].Text == "┃")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "┗";
                                    }
                                    else if (o.Cells[i - 1, DrawColumn].Text == "┏")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "";
                                    }
                                }
                                catch { }
                            }
                            else if (curComboNo == tmp && tmp != "")
                            {
                                o.Cells[i, DrawColumn].Text = "┃";
                            }
                            else if (curComboNo != tmp && tmp == "")
                            {
                                try
                                {
                                    if (o.Cells[i - 1, DrawColumn].Text == "┃")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "┗";
                                    }
                                    else if (o.Cells[i - 1, DrawColumn].Text == "┏")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "";
                                    }
                                }
                                catch { }
                                o.Cells[i, DrawColumn].Text = "";
                                curComboNo = "";
                            }
                            if (i == o.RowCount - 1 && o.Cells[i, DrawColumn].Text == "┃") o.Cells[i, DrawColumn].Text = "┗";
                            if (i == o.RowCount - 1 && o.Cells[i, DrawColumn].Text == "┏") o.Cells[i, DrawColumn].Text = "";
                            o.Cells[i, DrawColumn].ForeColor = System.Drawing.Color.Red;
                            #endregion
                        }
                    }
                    else if (ChildViewLevel == 1)
                    {
                        for (int m = 0; m < o.RowCount; m++)
                        {
                            FarPoint.Win.Spread.SheetView c = o.GetChildView(m, 0);
                            for (int j = 0; j < c.RowCount; j++)
                            {
                                #region "画"
                                if (c.Cells[j, column].Text == "0") c.Cells[j, column].Text = "";
                                tmp = c.Cells[j, column].Text + "";

                                c.Cells[j, column].Tag = tmp;
                                if (curComboNo != tmp && tmp != "") //是头
                                {
                                    curComboNo = tmp;
                                    c.Cells[j, DrawColumn].Text = "┏";
                                    try
                                    {
                                        if (c.Cells[j - 1, DrawColumn].Text == "┃")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "┗";
                                        }
                                        else if (c.Cells[j - 1, DrawColumn].Text == "┏")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "";
                                        }
                                    }
                                    catch { }
                                }
                                else if (curComboNo == tmp && tmp != "")
                                {
                                    c.Cells[j, DrawColumn].Text = "┃";
                                }
                                else if (curComboNo != tmp && tmp == "")
                                {
                                    try
                                    {
                                        if (c.Cells[j - 1, DrawColumn].Text == "┃")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "┗";
                                        }
                                        else if (c.Cells[j - 1, DrawColumn].Text == "┏")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "";
                                        }
                                    }
                                    catch { }
                                    c.Cells[j, DrawColumn].Text = "";
                                    curComboNo = "";
                                }
                                if (j == c.RowCount - 1 && c.Cells[j, DrawColumn].Text == "┃") c.Cells[j, DrawColumn].Text = "┗";
                                if (j == c.RowCount - 1 && c.Cells[j, DrawColumn].Text == "┏") c.Cells[j, DrawColumn].Text = "";
                                c.Cells[j, DrawColumn].ForeColor = System.Drawing.Color.Red;
                                #endregion

                            }
                        }
                    }
                    break;
            }

        }
        /// <summary>
        /// 画组合号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="column"></param>
        /// 		/// <param name="DrawColumn"></param>
        public static void DrawCombo(object sender, int column, int DrawColumn)
        {
            DrawCombo(sender, column, DrawColumn, 0);
        }
        /// <summary>
        /// 画组合号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="column"></param>
        /// 		/// <param name="DrawColumn"></param>
        public static void DrawComboLeft(object sender, int column, int DrawColumn)
        {
            DrawComboLeft(sender, column, DrawColumn, 0);
        }

        #endregion

        #region 获得是否可以开库存为零的药品
        /// <summary>
        /// 获得是否可以开库存为零的药品
        /// </summary>
        /// <returns></returns>
        public static int GetIsOrderCanNoStock()
        {
            Neusoft.FrameWork.Management.ControlParam controler = new Neusoft.FrameWork.Management.ControlParam();
            return Neusoft.FrameWork.Function.NConvert.ToInt32(controler.QueryControlerInfo("200001"));
            
        }
        #endregion

        #region 检查库存
        /// <summary>
        /// 检查库存
        /// </summary>
        /// <param name="iCheck"></param>
        /// <param name="itemID"></param>
        /// <param name="itemName"></param>
        /// <param name="deptCode"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        public static bool CheckPharmercyItemStock(int iCheck, string itemID, string itemName, string deptCode, decimal qty)
        {
            //Neusoft.HISFC.Manager.Item manager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            //Neusoft.HISFC.Models.Pharmacy.item item = null;
            //.
            Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaManager = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
          
            Neusoft.HISFC.Models.Pharmacy.Storage phaItem = null;
          
            
            switch (iCheck)
            {
                case 0:
                    phaItem = phaManager.GetItemForInpatient(deptCode, itemID);
                    if (phaItem == null) return true;
                    if (qty > Neusoft.FrameWork.Function.NConvert.ToDecimal(phaItem.StoreQty))
                    {
                        return false;
                    }
                    break;
                case 1:
                    phaItem = phaManager.GetItemForInpatient(deptCode, itemID);


                    if (phaItem == null) return true;
                    if (qty > Neusoft.FrameWork.Function.NConvert.ToDecimal(phaItem.StoreQty))
                    {
                        if (MessageBox.Show("药品【" + itemName + "】的库存不够！是否继续执行！", "提示库存不足", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            return true;
                        else
                            return false;
                    }
                    break;
                case 2:
                    break;
                default:
                    return true;
            }
            return true;
        }
        #endregion

        #region 集中发送
        /// <summary>
        /// 是否集中发送过
        /// </summary>
        /// <param name="DeptCode">科室编码</param>
        /// <returns>返回科室扩展实体</returns>
        public static Neusoft.HISFC.Models.Base.ExtendInfo IsDeptHaveDruged(string DeptCode)
        {
            Neusoft.FrameWork.Management.ExtendParam m = new Neusoft.FrameWork.Management.ExtendParam();
            Neusoft.HISFC.Models.Base.ExtendInfo obj = m.GetComExtInfo(Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT,"ORDER_ISDRUGED", DeptCode);
            if (obj == null) return null;
            return obj;
        }
        /// <summary>
        /// 已经集中发送
        /// </summary>
        /// <param name="DeptCode"></param>
        /// <returns></returns>
        public static int HaveDruged(string DeptCode)
        {
            return Function.HaveDruged(DeptCode, 1M);
        }
        /// <summary>
        /// 更新没集中发送
        /// </summary>
        /// <param name="DeptCode"></param>
        /// <returns></returns>
        public static int NotHaveDruged(string DeptCode)
        {
            return Function.HaveDruged(DeptCode, 0M);
        }
        /// <summary>
        /// 更新扩展信息表
        /// </summary>
        /// <param name="DeptCode"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int HaveDruged(string DeptCode, decimal i)
        {
            Neusoft.FrameWork.Management.ExtendParam m = new Neusoft.FrameWork.Management.ExtendParam();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(m.Connection);
            //t.BeginTransaction();
            m.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            Neusoft.HISFC.Models.Base.ExtendInfo obj = new Neusoft.HISFC.Models.Base.ExtendInfo();
            obj.ID = "ORDER_ISDRUGED";
            obj.Name = "住院科室集中摆药";
            obj.PropertyCode = "ORDER_ISDRUGED";
            obj.PropertyName = "住院科室集中摆药";
            obj.NumberProperty = i;
            obj.ExtendClass = Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT;
            obj.Item.ID = DeptCode;
            obj.StringProperty = "";
            obj.DateProperty = DateTime.Now;
            obj.Memo = "";
            if (m.SetComExtInfo(obj) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                MessageBox.Show(m.Err);
                return -1;
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            return 0;
        }
        #endregion

        #region "医嘱默认频次"
        /// <summary>
        /// 设置医嘱默认频次
        /// </summary>
        /// <param name="o"></param>
        public static void SetDefaultFrequency(Neusoft.HISFC.Models.Order.Inpatient.Order o)
        {
            //药品 临时医嘱，频次为空，默认为需要时候服用prn
            //if (o.Item.IsPharmacy && o.OrderType.IsDecompose == false)
            if (o.Item.ItemType == EnumItemType.Drug && o.OrderType.IsDecompose == false)
            {
                o.Frequency.ID = "PRN";//药品临时医嘱默认为需要时执行
            }
            //else if (o.Item.IsPharmacy == false && o.OrderType.IsDecompose == false)
            else if (o.Item.ItemType != EnumItemType.Drug && o.OrderType.IsDecompose == false)
            {
                o.Frequency.ID = "QD";//非药品临时医嘱默认为每天一次
            }
        }
        #endregion


        #region 床位处理
        /// <summary>
        /// 显示床位号
        /// </summary>
        /// <param name="orgBedNo"></param>
        /// <returns></returns>
        public static string BedDisplay(string orgBedNo)
        {
            if (orgBedNo == "")
            {
                return orgBedNo;
            }

            string tempBedNo = "";

            if (orgBedNo.Length > 4)
            {
                tempBedNo = orgBedNo.Substring(4);
            }
            else
            {
                return orgBedNo;
            }
            return tempBedNo;
         
        }
        #endregion

        #region 皮试字符串

        /// <summary>
        /// 翻译皮试
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string TransHypotest(int i)
        {
            switch (i)
            {
                case 2:
                    return "需皮试";
                case 3:
                    return "阳性";
                case 4:
                    return "阴性";
                default:
                    return  "不需皮试";
            }
        }

        /// <summary>
        /// 转医嘱状态
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string OrderStatus(int i)
        {
            switch (i)
            {
                case 0:
                    return "新开立";
                case 1:
                    return "已审核";
                case 2:
                    return "执行";
                case 3:
                    return "停止/取消";
                case 4:
                    return "作废";
                default:
                    return "未知";
            }
        }
        #endregion
    }

    /// <summary>
    /// 医嘱查询后，打印领药单接口liu.xq20071025
    /// </summary>
    public interface IOrderExeQuery
    {
        /// <summary>
        /// 住院患者实体
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfoObj
        {
            set;
            get;
        }
        /// <summary>
        /// 赋值函数
        /// </summary>
        /// <returns></returns>
        int SetValue(ArrayList alExeOrder);

        /// <summary>
        /// 打印
        /// </summary>
        void Print();
    }
}
