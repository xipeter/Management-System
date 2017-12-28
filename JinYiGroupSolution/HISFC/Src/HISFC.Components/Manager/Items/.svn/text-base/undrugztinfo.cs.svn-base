//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;

//namespace Neusoft.HISFC.Components.Manager.Items
//{
//    public partial class undrugztinfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
//    {
//        public delegate void myEventDelegate();
//        public DataView dataView = null;

//        private DataSet UndrugztinfoDataSet = null;
//        private DataView Undrugztinfodv = null;
//        private DataSet UndrugDataSet = null;
//        private ArrayList DepartMentList = null;
//        private ArrayList SystClassArrayList = null;
//        private DataSet UndrugztDataSet = null;
//        private DataView Undrugztdv = null;


//        public undrugztinfo()
//        {
//            InitializeComponent();
//        }

//        /// <summary>
//        /// 实例化非药品组套
//        /// </summary>
//        /// <returns></returns>
//        private DataSet InitUndrugzt()
//        {
//            //非药品组套表
//            DataSet ds = null;
//            DataTable Table = null;
//            this.neuSpread1_Sheet1.Columns[0].Width = 60;
//            this.neuSpread1_Sheet1.Columns[1].Width = 180;
//            this.neuSpread1_Sheet1.Columns[2].Width = 60;
//            this.neuSpread1_Sheet1.Columns[3].Width = 50;
//            this.neuSpread1_Sheet1.Columns[4].Width = 50;
//            this.neuSpread1_Sheet1.Columns[5].Width = 50;
//            try
//            {
//                ds = new DataSet();
//                Table = new DataTable("非药品组套表");

//                DataColumn dataColumn1 = new DataColumn("组套编码");
//                dataColumn1.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn1);

//                DataColumn dataColumn2 = new DataColumn("组套名称");
//                dataColumn2.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn2);

//                DataColumn dataColumn3 = new DataColumn("系统类别");
//                dataColumn3.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn3);

//                DataColumn dataColumn4 = new DataColumn("拼音码");
//                dataColumn4.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn4);

//                DataColumn dataColumn5 = new DataColumn("五笔");
//                dataColumn5.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn5);

//                DataColumn dataColumn6 = new DataColumn("输入码");
//                dataColumn6.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn6);

//                DataColumn dataColumn7 = new DataColumn("执行科室编码");
//                dataColumn7.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn7);

//                DataColumn dataColumn8 = new DataColumn("顺序号");
//                dataColumn8.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn8);

//                DataColumn dataColumn9 = new DataColumn("确认标志");
//                dataColumn9.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn9);

//                DataColumn dataColumn10 = new DataColumn("有效性标志");
//                dataColumn10.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn10);

//                DataColumn dataColumn11 = new DataColumn("特殊治疗项目");
//                dataColumn11.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn11);

//                ds.Tables.Add(Table);
//            }
//            catch (Exception ee)
//            {
//                string Error = ee.Message;
//                ds = null;
//            }
//            return ds;
//        }

//        /// <summary>
//        /// 初始化非药品列表
//        /// </summary>
//        /// <returns></returns>
//        private DataSet InitUndrugDataSet()
//        {
//            DataSet ds = null;
//            try
//            {
//                ds = new DataSet();

//                DataTable Table = new DataTable("非药品列表");

//                DataColumn dataColumn1 = new DataColumn("名称"); //0
//                dataColumn1.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn1);


//                DataColumn dataColumn2 = new DataColumn("编码"); //1
//                dataColumn2.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn2);

//                DataColumn dataColumn7 = new DataColumn("默认价");//2
//                dataColumn7.DataType = typeof(System.Decimal);
//                Table.Columns.Add(dataColumn7);

//                DataColumn dataColumn8 = new DataColumn("儿童价");//3
//                dataColumn8.DataType = typeof(System.Decimal);
//                Table.Columns.Add(dataColumn8);

//                DataColumn dataColumn9 = new DataColumn("特诊价");//4
//                dataColumn9.DataType = typeof(System.Decimal);
//                Table.Columns.Add(dataColumn9);


//                DataColumn dataColumn3 = new DataColumn("自定义码");//5
//                dataColumn3.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn3);

//                DataColumn dataColumn4 = new DataColumn("拼音码");//6
//                dataColumn4.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn4);

//                DataColumn dataColumn5 = new DataColumn("五笔码");//7
//                dataColumn5.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn5);

//                DataColumn dataColumn6 = new DataColumn("国际编码");
//                dataColumn6.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn6);

//                ds.Tables.Add(Table);
//            }
//            catch (Exception ee)
//            {
//                string Error = ee.Message;
//                ds = null;
//            }
//            return ds;
//        }

//        /// <summary>
//        /// 非药品列表
//        /// </summary>
//        /// <param name="List"></param>
//        /// <param name="Table"></param>
//        /// <param name="view"></param>
//        private void AddDataToUndrug(ArrayList List, DataTable Table, FarPoint.Win.Spread.SheetView view)
//        {
//            try
//            {
//                if (Table != null)
//                {
//                    Table.Clear();
//                }
//                if (List != null)
//                {
//                    foreach (Neusoft.HISFC.Models.Fee.Item.Undrug info in List)
//                    {
//                        Table.Rows.Add(new object[] { info.Name, info.ID, info.Price, info.ChildPrice, info.SpecialPrice, info.UserCode, info.SpellCode, info.WBCode, info.GBCode });
//                    }
//                }
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show(ee.Message); //
//            }
//        }

//        /// <summary>
//        /// 填充非药品组套
//        /// </summary>
//        /// <param name="List"></param>
//        /// <param name="Table"></param>
//        /// <param name="view"></param>
//        /// <returns></returns>
//        private bool AddDataToUndrugzt(ArrayList List, DataTable Table, FarPoint.Win.Spread.SheetView view)
//        {
//            bool Result = true;
//            try
//            {
//                if (Table != null)
//                {
//                    Table.Clear();
//                }
//                if (List != null)
//                {
//                    foreach (Neusoft.HISFC.Models.Fee.Item.UndrugComb info in List)
//                    {
//                        //插入一行
//                        string valid = "";
//                        if (info.IsValid)
//                        {
//                            valid = "有效";
//                        }
//                        else if (info.IsValid)
//                        {
//                            valid = "无效";
//                        }
//                        else
//                        {
//                            valid = "作废";
//                        }
//                        string confirmFlag = "";

//                        if (info.IsNeedConfirm)
//                        {
//                            confirmFlag = "需要确认";
//                        }
//                        else
//                        {
//                            confirmFlag = "不需要确认";
//                        }
//                        string SpellFlag = "";
//                        if (info.User01 == "1")
//                        {
//                            SpellFlag = "是";
//                        }
//                        else if (info.User01 == "0")
//                        {
//                            SpellFlag = "否";
//                        }
//                        Table.Rows.Add(new object[] { info.ID, info.Name, GetSysClassName(info.SysClass.Name, SystClassArrayList), info.SpellCode, info.WBCode, info.UserCode, GetDepartMentName(info.ExecDept, DepartMentList), info.SortID, confirmFlag, valid, SpellFlag });
//                    }
//                    Table.AcceptChanges();
//                    //
//                    //锁定
//                    LockfpSpread1();
//                }

//            }
//            catch (Exception ee)
//            {
//                string Error = ee.Message;
//            }

//            return Result;
//        }

//        /// <summary>
//        /// 非药品组套明细表
//        /// </summary>
//        /// <returns></returns>
//        private DataSet InitUndrugztinfo()
//        {
//            DataSet ds = null;
//            try
//            {
//                ds = new DataSet();
//                DataTable Table = new DataTable("非药品组套明细表");

//                DataColumn dataColumn1 = new DataColumn("组套编码");
//                dataColumn1.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn1);

//                DataColumn dataColumn2 = new DataColumn("非药品名称");
//                dataColumn2.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn2);

//                DataColumn dataColumn3 = new DataColumn("非药品编码");
//                dataColumn3.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn3);

//                DataColumn dataColumn8 = new DataColumn("有效");
//                dataColumn8.DataType = typeof(System.Boolean);
//                Table.Columns.Add(dataColumn8);

//                DataColumn dataColumn4 = new DataColumn("顺序号");
//                dataColumn4.DataType = typeof(System.Int32);
//                Table.Columns.Add(dataColumn4);

//                DataColumn dataColumn5 = new DataColumn("拼音码");
//                dataColumn5.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn5);

//                DataColumn dataColumn6 = new DataColumn("五笔码");
//                dataColumn6.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn6);

//                DataColumn dataColumn7 = new DataColumn("输入码");
//                dataColumn7.DataType = typeof(System.String);
//                Table.Columns.Add(dataColumn7);

//                DataColumn dataColumn9 = new DataColumn("数量");
//                dataColumn9.DataType = typeof(System.Decimal);
//                Table.Columns.Add(dataColumn9);


//                ds.Tables.Add(Table);
//            }
//            catch (Exception ee)
//            {
//                string Error = ee.Message;
//                ds = null;
//            }
//            return ds;
//        }

//        /// <summary>
//        /// 填充非药品组套明细表
//        /// </summary>
//        /// <param name="List"></param>
//        /// <param name="Table"></param>
//        /// <param name="view"></param>
//        /// <returns></returns>
//        private bool AddDataToUndrugztinfo(ArrayList List, DataTable Table, FarPoint.Win.Spread.SheetView view)
//        {
//            bool Result = false;
//            if (Table != null)
//            {
//                Table.Clear();
//            }

//            if (List != null)
//            {

//                foreach (Neusoft.HISFC.Models.Fee.Item.UndrugComb info in List)
//                {
//                    bool Value = true;
//                    if (info.User01 == "1") //无效
//                    {
//                        Value = false;
//                    }
//                    Table.Rows.Add(new object[] { info.ID, info.itemName, info.itemCode, Value, info.SortID, info.SpellCode, info.WbCode, info.InputCode, info.Qty });
//                }
//                LockfpSpread2();
//                Result = true;
//                Table.AcceptChanges();
//            }
//            return Result;
//        }

//        /// <summary>
//        /// 返回系统类别数组
//        /// </summary>
//        /// <returns></returns>
//        private string[] GetSysClass(ArrayList List)
//        {
//            //返回系统类别数组
//            string[] Str = null;
//            try
//            {
//                if (List != null)
//                {
//                    int j = 0;
//                    for (int i = 0; i < List.Count; i++)
//                    {
//                        string StrTemp = ((Neusoft.HISFC.Models.Base.EnumSysClass)List[i]).ID.ToString();
//                        if (StrTemp != "P" && StrTemp != "PCC" && StrTemp != "PCZ")
//                        {
//                            j++;
//                        }
//                    }
//                    if (j > 0)
//                    {
//                        Str = new string[j];
//                        int n = 0;
//                        for (int i = 0; i < List.Count; i++)
//                        {
//                            string StrTemp = ((Neusoft.HISFC.Models.Base.EnumSysClass)List[i]).ID.ToString();
//                            if (StrTemp != "P" && StrTemp != "PCC" && StrTemp != "PCZ")
//                            {
//                                Str[n] = ((Neusoft.HISFC.Models.Base.EnumSysClass)List[i]).Name;
//                                n++;
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ee)
//            {
//                string Error = ee.Message;
//            }
//            return Str;

//        }

//        /// <summary>
//        /// 根据ＩＤ得到系统类别的名称
//        /// </summary>
//        /// <param name="SysClassId"></param>
//        /// <param name="List"></param>
//        /// <returns></returns>
//        private string GetSysClassName(string SysClassId, ArrayList List)
//        {
//            if (List != null && SysClassId != "")
//            {
//                try
//                {
//                    foreach (Neusoft.HISFC.Models.Base.EnumSysClass info in List)
//                    {
//                        if (SysClassId == Convert.ToString(((Neusoft.HISFC.Models.Base.EnumSysClass)info).ID))
//                        {
//                            return ((Neusoft.HISFC.Models.Base.EnumSysClass)info).Name;
//                        }
//                    }
//                }
//                catch (Exception ee)
//                {
//                    string Error = ee.Message;
//                }
//            }
//            return "";
//        }

//        /// <summary>
//        /// 根据系统类别名称得到系统类别的ＩＤ
//        /// </summary>
//        /// <param name="SysClassName"></param>
//        /// <param name="List"></param>
//        /// <returns></returns>
//        private string GetSysClassId(string SysClassName, ArrayList List)
//        {
//            if (List != null && SysClassName != "")
//            {
//                try
//                {
//                    foreach (Neusoft.HISFC.Models.Base.EnumSysClass info in List)
//                    {
//                        if (SysClassName == ((Neusoft.HISFC.Models.Base.EnumSysClass)info).Name)
//                        {
//                            return Convert.ToString(((Neusoft.HISFC.Models.Base.EnumSysClass)info).ID);
//                        }
//                    }
//                }
//                catch (Exception ee)
//                {
//                    string Error = ee.Message;
//                }
//            }

//            return "";
//        }
//        private string[] GetDepartMentStr(ArrayList List)
//        {
//            //返回科室列表
//            string[] Str = null;
//            try
//            {
//                if (List != null)
//                {
//                    Str = new string[List.Count];
//                    for (int i = 0; i < List.Count; i++)
//                    {
//                        Str[i] = ((Neusoft.HISFC.Models.Base.Department)List[i]).DeptName;
//                    }

//                }
//            }
//            catch (Exception ee)
//            {
//                string Error = ee.Message;
//            }
//            return Str;
//        }
//        private string GetDepartMentName(string DepartmentCode, ArrayList List)
//        {
//            if (List != null && DepartmentCode != "")
//            {
//                try
//                {
//                    foreach (Neusoft.HISFC.Models.Base.Department info in List)
//                    {
//                        if (DepartmentCode == info.DeptID)
//                        {
//                            //返回科室名称 对应的编码
//                            return info.DeptName;
//                        }
//                    }
//                }
//                catch (Exception ee)
//                {
//                    MessageBox.Show(ee.Message);
//                }
//            }
//            return "";
//        }
//        private string GetDepartMentId(string DepartmentName, ArrayList List)
//        {
//            if (List != null && DepartmentName != "")
//            {
//                try
//                {
//                    foreach (Neusoft.HISFC.Models.Base.Department info in List)
//                    {
//                        if (DepartmentName == info.DeptName)
//                        {
//                            //返回编码 对应的科室名称
//                            return info.DeptID;
//                        }
//                    }
//                }
//                catch (Exception ee)
//                {
//                    string Error = ee.Message;
//                }
//            }
//            return "";
//        }

//        /// <summary>
//        /// 保存组套明细表
//        /// </summary>
//        /// <returns></returns>
//        private bool SaveUndrugztinfo()
//        {
//            //保存组套明细表
//            bool SaveSuccess = true;
//            try
//            {
//                //新增加的
//                DataTable AddTable = UndrugztinfoDataSet.Tables[0].GetChanges(System.Data.DataRowState.Added);
//                //修改的
//                DataTable ModTable = UndrugztinfoDataSet.Tables[0].GetChanges(System.Data.DataRowState.Modified);
//                //删除的
//                DataTable DelTable = UndrugztinfoDataSet.Tables[0].GetChanges(System.Data.DataRowState.Deleted);

//                Neusoft.HISFC.BizProcess.Integrate.Fee undrugztinfo = new Neusoft.HISFC.BizProcess.Integrate.Fee();

//                //Neusoft.HISFC.BizLogic.Fee.undrugztinfo undrugztinfo = new neusoft.HISFC.Management.Fee.undrugztinfo();
//                Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(undrugztinfo.Connection);
//                trans.BeginTransaction();
//                undrugztinfo.SetTrans(trans.Trans);
//                if (AddTable != null)
//                {
//                    ArrayList List = GetUndruginfoChangeList(AddTable);
//                    foreach (Neusoft.HISFC.Models.Fee.Item.UndrugComb info in List)
//                    {
//                        if (undrugztinfo.InsertUndrugComb(info) > 0)
//                        {
//                        }
//                        else
//                        {
//                            SaveSuccess = false;
//                            break;
//                        }
//                    }
//                }
//                if (ModTable != null && SaveSuccess)
//                {
//                    ArrayList List = GetUndruginfoChangeList(ModTable);
//                    foreach (Neusoft.HISFC.Models.Fee.Item.UndrugComb info in List)
//                    {
//                        if (undrugztinfo.UpdateUndrugComb(info) > 0)
//                        {
//                        }
//                        else
//                        {
//                            SaveSuccess = false;
//                            break;
//                        }
//                    }
//                }
//                if (DelTable != null && SaveSuccess)
//                {
//                    DelTable.RejectChanges();
//                    ArrayList List = GetUndruginfoChangeList(DelTable);
//                    foreach (neusoft.HISFC.Object.Fee.Undrugztinfo info in List)
//                    {
//                        if (undrugztinfo.DeleteUndrugComb(info) > 0)
//                        {
//                        }
//                        else
//                        {
//                            SaveSuccess = false;
//                            break;
//                        }
//                    }
//                }
//                if (SaveSuccess)
//                {
//                    trans.Commit();
//                    UndrugztinfoDataSet.Tables[0].AcceptChanges();
//                }
//                else
//                {
//                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
//                    MessageBox.Show(undrugztinfo.Err);
//                }
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show(ee.Message);
//                SaveSuccess = false;
//            }
//            return SaveSuccess;
//        }

//        private bool UndrugztChanged()
//        {
//            bool IsChange = false;
//            neuSpread1.StopCellEditing();
//            try
//            {
//                DataTable AddTable = UndrugztDataSet.Tables[0].GetChanges(System.Data.DataRowState.Added);
//                DataTable ModTable = UndrugztDataSet.Tables[0].GetChanges(System.Data.DataRowState.Modified);
//                DataTable DelTable = UndrugztDataSet.Tables[0].GetChanges(System.Data.DataRowState.Deleted);
//                if (AddTable != null || ModTable != null || DelTable != null)
//                {
//                    IsChange = true;
//                }
//            }
//            catch (Exception ee)
//            {
//                string Error = ee.Message;
//            }
//            return IsChange;
//        }

//        private bool UndrugztinfoChanged()
//        {
//            bool IsChange = false;
//            neuSpread2.StopCellEditing();
//            try
//            {
//                DataTable AddTable = UndrugztinfoDataSet.Tables[0].GetChanges(System.Data.DataRowState.Added);
//                DataTable ModTable = UndrugztinfoDataSet.Tables[0].GetChanges(System.Data.DataRowState.Modified);
//                DataTable DelTable = UndrugztinfoDataSet.Tables[0].GetChanges(System.Data.DataRowState.Deleted);
//                if (AddTable != null || ModTable != null || DelTable != null)
//                {
//                    IsChange = true;
//                }
//            }
//            catch (Exception ee)
//            {
//                string Error = ee.Message;
//            }
//            return IsChange;
//        }

//        private ArrayList GetUndrugChangeList(DataTable Table, ref bool Result)
//        {
//            ArrayList List = null;
//            try
//            {
//                if (Table != null)
//                {
//                    List = new ArrayList();
//                    Neusoft.HISFC.Models.Fee.Item.UndrugComb info = null;
//                    foreach (DataRow row in Table.Rows)
//                    {
//                        info = new Neusoft.HISFC.Models.Fee.Item.UndrugComb();
//                        info.ID = row["组套编码"].ToString();

//                        info.Name = row["组套名称"].ToString();

//                        info.SysClass = GetSysClassId(row["系统类别"].ToString(), SystClassArrayList);

//                        info.SpellCode = row["拼音码"].ToString();

//                        info.WBCode = row["五笔"].ToString();

//                        info.UserCode = row["输入码"].ToString();

//                        info.ExecDept = GetDepartMentId(row["执行科室编码"].ToString(), DepartMentList);
//                        if (row["顺序号"] != DBNull.Value)
//                        {
//                            info.SortID = Convert.ToInt32(row["顺序号"]);
//                        }
//                        else
//                        {
//                            MessageBox.Show("请输入顺序号");
//                            Result = false;
//                        }
//                        if (row["确认标志"].ToString() == "需要确认")
//                        {
//                            info.IsNeedConfirm = true;
//                        }
//                        else
//                        {
//                            info.IsNeedConfirm = false;
//                        }
//                        if (row["有效性标志"] != DBNull.Value)
//                        {
//                            if (row["有效性标志"].ToString() == "有效")
//                            {
//                                info.ValidState = "0";
//                            }
//                            else if (row["有效性标志"].ToString() == "无效")
//                            {
//                                info.ValidState = "1";
//                            }
//                            else if (row["有效性标志"].ToString() == "作废")
//                            {
//                                info.ValidState = "2";
//                            }
//                            else
//                            {
//                                info.ValidState = "";
//                            }
//                        }
//                        else
//                        {
//                            MessageBox.Show("请选择有效性标识");
//                            Result = false;
//                            return null;
//                        }
//                        if (row["特殊治疗项目"] != DBNull.Value)
//                        {
//                            if (row["特殊治疗项目"].ToString() == "是")
//                            {
//                                info.User02 = "1";
//                            }
//                            else if (row["特殊治疗项目"].ToString() == "否")
//                            {
//                                info.User02 = "0";
//                            }
//                        }
//                        List.Add(info);
//                        info = null;
//                    }
//                }
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show(ee.Message);
//                Result = false;
//                return null;
//            }
//            return List;
//        }

//        /// <summary>
//        /// 获取组套明细信息
//        /// </summary>
//        /// <param name="Table"></param>
//        /// <returns></returns>
//        private ArrayList GetUndruginfoChangeList(DataTable Table)
//        {
//            ArrayList List = null;
//            try
//            {
//                List = new ArrayList();
//                if (Table != null)
//                {
//                    Neusoft.HISFC.Models.Fee.Item.UndrugComb info = null;
//                    foreach (DataRow row in Table.Rows)
//                    {
//                        info = new Neusoft.HISFC.Models.Fee.Item.UndrugComb();
//                        info.ID = row["组套编码"].ToString();
//                        info.itemName = row["非药品名称"].ToString();
//                        info.itemCode = row["非药品编码"].ToString();
//                        info.SortID = Convert.ToInt32(row["顺序号"]);
//                        info.SpellCode = row["拼音码"].ToString();
//                        info.WBCode = row["五笔码"].ToString();
//                        info.UserCode = row["输入码"].ToString();
//                        string str = row["有效"].ToString();
//                        if (row["有效"].ToString() == "False")
//                        {
//                            info.User01 = "1";
//                        }
//                        else
//                        {
//                            info.User01 = "0";
//                        }
//                        //数量
//                        info.Qty = neusoft.neuFC.Function.NConvert.ToDecimal(row["数量"].ToString());
//                        List.Add(info);
//                        info = null;
//                    }
//                }
//            }
//            catch (Exception ee)
//            {
//                string Error = ee.Message;
//            }
//            return List;
//        }


//        public void ShowNewData()
//        {
//            try
//            {
//                int temp = neuSpread1_Sheet1.ActiveRowIndex;
//                string packageCode = "";
//                try
//                {
//                    Neusoft.HISFC.BizProcess.Integrate.Fee undrugzt = new Neusoft.HISFC.BizProcess.Integrate.Fee();
//                    packageCode = neuSpread1.Cells[temp, 0].Text;
//                    Neusoft.HISFC.Models.Fee.Item.UndrugComb itemzt = Undrugszinfo.GetUndrugztinfo(packageCode);
//                    ArrayList UndrugztinfoList = new ArrayList();
//                    UndrugztinfoList.Add(itemzt);
//                    AddDataToUndrugztinfo(UndrugztinfoList, UndrugztinfoDataSet.Tables[0], fpSpread2_Sheet1);
//                }
//                catch (Exception ee)
//                {
//                    string Error = ee.Message;
//                }
//            }
//            catch (Exception ee)
//            {
//                string Error = ee.Message;
//            }
//        }

//        private void InsertInfo()
//        {
//            if (MessageBox.Show("真的要添加组套吗", "添加组套", System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.Yes)
//            {
//                AddUndrugzt();
//            }
//        }
//        private void DeleteInfo()
//        {
//            //停用非药品组套明细
//            try
//            {
//                if (neuSpread2_Sheet1.Rows.Count > 0)
//                {
//                    string Name = neuSpread2_Sheet1.Cells[neuSpread2_Sheet1.ActiveRowIndex, 1].Text;
//                    DialogResult result;
//                    result = MessageBox.Show("是否要停用" + Name, "停用", MessageBoxButtons.YesNo);
//                    if (result == DialogResult.Yes)
//                    {
//                        neuSpread2_Sheet1.Cells[neuSpread2_Sheet1.ActiveRowIndex, 3].Value = false;
//                    }
//                }
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show(ee.Message);
//            }
//        }
//        private void RecoverInfo()
//        {
//            //停用非药品组套明细
//            try
//            {
//                if (neuSpread2_Sheet1.Rows.Count > 0)
//                {
//                    string Name = neuSpread2_Sheet1.Cells[neuSpread2_Sheet1.ActiveRowIndex, 1].Text;
//                    DialogResult result;
//                    result = MessageBox.Show("是否要恢复" + Name, "恢复", MessageBoxButtons.YesNo);
//                    if (result == DialogResult.Yes)
//                    {
//                        neuSpread2_Sheet1.Cells[neuSpread2_Sheet1.ActiveRowIndex, 3].Value = true;
//                    }
//                }
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show(ee.Message);
//            }
//        }
//        private void PrintInfo()
//        {
//            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
//            p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
//            p.PrintPreview(panel7);
//        }
//        private void ExportData()
//        {
//            string Result = "";
//            try
//            {
//                bool ret = false;
//                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
//                saveFileDialog1.Filter = "Excel |.xls";
//                saveFileDialog1.Title = "导出数据";
//                try
//                {
//                    saveFileDialog1.FileName = neuSpread1_Sheet1.Cells[neuSpread1_Sheet1.ActiveRowIndex, 1].Text;
//                }
//                catch (Exception)
//                {
//                    saveFileDialog1.FileName = "";
//                }
//                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
//                {
//                    if (saveFileDialog1.FileName != "")
//                    {
//                        //以Excel 的形式导出数据
//                        UndrugztDataSet.Tables[0].AcceptChanges();
//                        fpSpread1.StopCellEditing();
//                        ret = fpSpread2.SaveExcel(saveFileDialog1.FileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
//                    }
//                    if (ret)
//                    {
//                        MessageBox.Show("成功导出数据");
//                    }
//                }
//                else
//                {
//                    MessageBox.Show("操作被取消");
//                }
//            }
//            catch (Exception ee)
//            {
//                Result = ee.Message;
//                MessageBox.Show(Result);
//            }

//        }
//        private void ExistForm()
//        {
//            // 如果有新的数据，提示保存然后 退出
//            if (UndrugztChanged() || UndrugztinfoChanged())
//            {
//                DialogResult result;
//                result = MessageBox.Show("是否保存刚才改动过的数据", "保存", MessageBoxButtons.YesNo);
//                if (result == DialogResult.Yes)
//                {
//                    if (SaveUndrugztinfo())
//                    {
//                        MessageBox.Show("保存成功！");
//                        this.FindForm().Close();
//                    }
//                    else
//                    {
//                        //保存不成功
//                        MessageBox.Show("保存失败");
//                    }
//                }
//                else
//                {
//                    Form form = this.FindForm();
//                    form.Close();
//                }
//            }
//            else
//            {
//                Form form = this.FindForm();
//                form.Close();
//            }
//        }

//        /// <summary>
//        /// 增加组套
//        /// </summary>
//        /// <returns></returns>
//        public int AddUndrugzt()
//        {
//            frmUndrugztManager frm = new frmUndrugztManager();
//            frm.SaveInfo += new Fee.frmUndrugztManager.SaveHandle(frm_SaveInfo);
//            frm.EditType = neusoft.Common.Class.EditTypes.Add;
//            this.editType = neusoft.Common.Class.EditTypes.Add;
//            frm.ShowDialog();
//            return 0;
//        }
//        /// <summary>
//        /// 修改当前行
//        /// </summary>
//        /// <returns></returns>
//        public int ModifyUndrugzt()
//        {
//            if (this.neuSpread1_Sheet1.RowCount == 0)
//            {
//                return -1;
//            }
//            frmUndrugztManager frm = new frmUndrugztManager();
//            frm.SaveInfo += new Fee.frmUndrugztManager.SaveHandle(frm_SaveInfo);
//            frm.EditType = neusoft.Common.Class.EditTypes.Modify;
//            this.editType = neusoft.Common.Class.EditTypes.Modify;
//            frm.InitList();
//            neusoft.HISFC.Management.Fee.undrugzt neuUndrugsz = new neusoft.HISFC.Management.Fee.undrugzt();
//            neusoft.HISFC.Object.Fee.Undrugzt obj = neuUndrugsz.GetSingleUndrugzt(this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 0].Text);
//            if (obj == null)
//            {
//                MessageBox.Show("获取组套信息失败");
//                return -1;
//            }
//            frm.SetValue(obj);
//            frm.ShowDialog();
//            return 0;
//        }


//    }
//}