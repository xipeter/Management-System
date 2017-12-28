using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace Neusoft.HISFC.BizProcess.Integrate
{
    /// <summary>
    /// [功能描述: 静态函数集合类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// </summary>
    public class Function : IntegrateBase
    {
        public Function()
        {

        }

        #region 领药单打印

        /// <summary>
        /// 领药单打印接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.IPrintExecDrug IPrintConsume = null;

        /// <summary>
        /// 领药单接口打印
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        private int InitConsumePrintInterface()
        {
            try
            {
                object[] o = new object[] { };
                //以后由维护界面获取类名称
                System.Runtime.Remoting.ObjectHandle objHandel = System.Activator.CreateInstance("Report", "Report.Order.ucDrugConsuming", false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);
                if (objHandel != null)
                {
                    object oLabel = objHandel.Unwrap();

                    IPrintConsume = oLabel as Neusoft.HISFC.BizProcess.Interface.IPrintExecDrug;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(ex.Message));
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="alList">需打印函数</param>
        public void PrintDrugConsume(List<Neusoft.HISFC.Models.Order.ExecOrder> alList)
        {
            PrintDrugConsume(new System.Collections.ArrayList(alList.ToArray()));
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="alList">需打印函数</param>
        public void PrintDrugConsume(System.Collections.ArrayList alData)
        {
            if (IPrintConsume == null)
            {
                if (InitConsumePrintInterface() == -1)
                {
                    return;
                }
            }

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

            Neusoft.FrameWork.Models.NeuObject dept = ((Neusoft.HISFC.Models.Base.Employee)dataManager.Operator).Dept;
            Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
            oper.ID = dataManager.Operator.ID;
            oper.Name = dataManager.Operator.Name;

            SortStockDept sort = new SortStockDept();

            alData.Sort(sort);

            IPrintConsume.SetTitle(oper, dept);

            IPrintConsume.SetExecOrder(alData);

            IPrintConsume.Print();
        }

        private class SortStockDept : System.Collections.IComparer
        {
            public SortStockDept()
            {
 
            }

            #region IComparer 成员

            public int Compare(object x, object y)
            {
                string xSort = (x as Neusoft.HISFC.Models.Order.ExecOrder).Order.StockDept.ID;
                string ySort = (y as Neusoft.HISFC.Models.Order.ExecOrder).Order.StockDept.ID;

                return xSort.CompareTo(ySort);
            }

            #endregion
        }

        #endregion

        #region  项目变更记录    
   
         /// <summary>
        /// 变更信息保存
        /// </summary>
        /// <param name="isInsert">是否插入</param>
        /// <param name="isDel">是否删除</param>
        /// <param name="itemCode">项目编码 用于标志变更信息</param>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="originalObject">原数据</param>
        /// <param name="newObject">新数据</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SaveChange<T>(bool isInsert, bool isDel, string itemCode, T originalObject, T newObject)
        {
            return SaveChange<T>(null,isInsert, isDel, itemCode, originalObject, newObject);
        }

        /// <summary>
        /// 变更信息保存
        /// </summary>
        /// <param name="shiftType"></param>
        /// <param name="isInsert">是否插入</param>
        /// <param name="isDel">是否删除</param>
        /// <param name="itemCode">项目编码 用于标志变更信息</param>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="originalObject">原数据</param>
        /// <param name="newObject">新数据</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SaveChange<T>(string shiftType,bool isInsert,bool isDel,string itemCode,T originalObject, T newObject)
        {         
            Neusoft.HISFC.BizLogic.Manager.ShiftData shiftManager = new Neusoft.HISFC.BizLogic.Manager.ShiftData();

            #region 获取类型信息
            
            Type t = typeof(T);

            string itemType = "0";
            if (shiftType == null)
            {
                switch (t.ToString())
                {
                    case "Neusoft.HISFC.Models.Pharmacy.Item":
                        itemType = "0";
                        break;
                    case "Neusoft.HISFC.Models.Fee.Item":
                        itemType = "1";
                        break;
                    case "Neusoft.HISFC.Models.RADT.Patient":
                        itemType = "2";
                        break;
                    case "Neusoft.HISFC.Models.RADT.PVisit":   /*{DB3B44F0-B049-4644-B599-82456C9CFC31}*/
                        itemType = "A";
                        break;
                }
            }
            else
            {
                itemType = shiftType;
            }

            #endregion

            #region 插入/删除保存变更

            if (isInsert)           //新插入数据
            {
                if (shiftManager.SetShiftData(itemCode, itemType, new Neusoft.FrameWork.Models.NeuObject(), new Neusoft.FrameWork.Models.NeuObject(), "新建") == -1)
                {
                    System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存项目新建变更记录失败") + shiftManager.Err);
                    return -1;
                }
                return 1;
            }

            if (isDel)           //删除数据
            {
                if (shiftManager.SetShiftData(itemCode, itemType, new Neusoft.FrameWork.Models.NeuObject(), new Neusoft.FrameWork.Models.NeuObject(), "删除") == -1)
                {
                    System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存项目删除变更记录失败") + shiftManager.Err);
                    return -1;
                }
                return 1;
            }

            #endregion

            if (originalObject == null || newObject == null)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存变更记录 传入参数错误 修改时原始值与新值不能为null"));
                return -1;
            }
                     
            //获取维护的需记录变更属性
            List<Neusoft.HISFC.Models.Base.ShiftProperty> sihftList = shiftManager.QueryShiftProperty(t.ToString());
            if (sihftList == null)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取需记录变更属性列表失败") + shiftManager.Err);
                return -1;
            }
         
            foreach (Neusoft.HISFC.Models.Base.ShiftProperty sf in sihftList)
            {
                if (!sf.IsRecord)           //不对该属性变更进行记录
                {
                    continue;
                }
                //根据字段名称获取Propertyinfo
                System.Reflection.PropertyInfo rP = t.GetProperty(sf.Property.ID);
                //由实体内取出相应属性值
                object rO = rP.GetValue(originalObject, null);
                //由实体内取出相应属性值
                object rN = rP.GetValue(newObject, null);
                //是否发生变化判断
                if (rO is Neusoft.FrameWork.Models.NeuObject)
                {
                    Neusoft.FrameWork.Models.NeuObject origNeu = rO as Neusoft.FrameWork.Models.NeuObject;
                    Neusoft.FrameWork.Models.NeuObject newNeu = rN as Neusoft.FrameWork.Models.NeuObject;

                    if (origNeu == null)
                    {
                        origNeu = new Neusoft.FrameWork.Models.NeuObject();
                    }
                    if (newNeu == null)
                    {
                        newNeu = new Neusoft.FrameWork.Models.NeuObject();
                    }

                    if (origNeu.ID != newNeu.ID)
                    {
                        if (shiftManager.SetShiftData(itemCode, itemType,origNeu, newNeu,sf.ShiftCause) == -1)
                        {
                            System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存变更记录失败 属性:") + sf.Property.ID + shiftManager.Err);
                            return -1;
                        }
                    }
                }
                else
                {
                    Neusoft.FrameWork.Models.NeuObject origNeu = new Neusoft.FrameWork.Models.NeuObject();
                    Neusoft.FrameWork.Models.NeuObject newNeu = new Neusoft.FrameWork.Models.NeuObject();
                    if (rO == null)
                    {
                        rO = string.Empty;
                    }
                    origNeu.ID = rO.ToString();
                    origNeu.Name = sf.Property.Name;

                    newNeu.ID = rN.ToString();
                    newNeu.Name = sf.Property.Name;

                    if (origNeu.ID != newNeu.ID)
                    {
                        if (shiftManager.SetShiftData(itemCode, itemType, origNeu, newNeu, sf.ShiftCause) == -1)
                        {
                            System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存变更记录失败 属性:") + sf.Property.ID + shiftManager.Err);
                            return -1;
                        }
                    }
                }
            }

            return 1;
        }

        #endregion

        #region 医院名称

        //        static string hosNameSelect = @"SELECT T.HOS_NAME,T.HOS_CODE,T.Mark 
        //										FROM  COM_HOSPITALINFO T
        //										WHERE  ROWNUM = 1";
        static string hosNameSelect = @"SELECT T.HOS_NAME,T.HOS_CODE,T.Mark 
										FROM  COM_HOSPITALINFO T";

        /// <summary>
        /// 医院名称
        /// </summary>
        protected static string HosName = "-1";
        protected static string HosCode = "-1";
        protected static string HosMemo = "-1";

        public static string GetHosCode()
        {
            GetHosName();
            return HosCode;
        }
        /// <summary>
        /// 医院名称获取
        /// </summary>
        /// <returns>成功返回医院名称 失败返回空字符串</returns>
        public static string GetHosName()
        {
            if (HosName == "-1")
            {
                Neusoft.FrameWork.Management.DataBaseManger dataBase = new Neusoft.FrameWork.Management.DataBaseManger();
                if (dataBase.ExecQuery(Function.hosNameSelect) == -1)
                {
                    return HosCode;
                }

                try
                {
                    if (dataBase.Reader.Read())
                    {
                        HosName = dataBase.Reader[0].ToString();
                        HosCode = dataBase.Reader[1].ToString();
                        HosMemo = dataBase.Reader[2].ToString();
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
                finally
                {
                    if (!dataBase.Reader.IsClosed)
                    {
                        dataBase.Reader.Close();
                    }
                }
            }

            return HosName;
        }

        /// <summary>
        /// 获取医院信息
        /// </summary>
        /// <returns></returns>
        public static Neusoft.FrameWork.Models.NeuObject GetHosInfo()
        {
            GetHosName();
            return new Neusoft.FrameWork.Models.NeuObject(HosCode, HosName, HosMemo);
        }

        //{F8B5A5CE-4BDF-4bcb-A57B-AD635CA0B5AE}
        public static System.Drawing.Color GetPactColor(string pactCode)
        {

            Neusoft.FrameWork.Management.ControlParam ctlMgr = new Neusoft.FrameWork.Management.ControlParam();
            
            string returnValue = ctlMgr.QueryControlerInfo("Pact" + pactCode);

            return System.Drawing.Color.FromArgb(Neusoft.FrameWork.Function.NConvert.ToInt32(returnValue));
            
        }

        /// <summary>
        /// {01938238-FE86-4e62-A1CC-037D0DAB8587}
        /// 获取年龄函数
        /// </summary>
        /// <param name="birthday"></param>
        public static string GetAge(DateTime birthday)
        {
            string ageStr = "";

            if (birthday == DateTime.MinValue)
            {
                return "";
            }

            Neusoft.FrameWork.Management.DataBaseManger dataBase = new Neusoft.FrameWork.Management.DataBaseManger();
            DateTime current = dataBase.GetDateTimeFromSysDateTime();
            TimeSpan age = current - birthday;
            if (age.Ticks < 0)
            {
                return "";
            }
            int totMonth = (current.Year - birthday.Year) * 12 + (current.Month - birthday.Month);
            if (age.Days <= 90)
            {
                ageStr = age.Days.ToString() + "天";
            }
            else if (totMonth > 0 && totMonth < 24)
            {
                ageStr = totMonth.ToString() + "月";
            }
            else
            {
                ageStr = (current.Year - birthday.Year).ToString() + "岁";
            }
            
            return ageStr;
        }

        #endregion

        /// <summary>
        /// 进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
        /// </summary>
        private static Neusoft.FrameWork.Models.NeuObject drugDept = null;

        /// <summary>
        /// 医生站当前操作药房 进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
        /// </summary>
        public static Neusoft.FrameWork.Models.NeuObject DrugDept
        {
            get
            {
                #region 默认上次选择药房为默认药房
                string path = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath;
                string fileName = "OrderDrugDept.ini";
                Neusoft.FrameWork.Models.NeuObject obj = null;

                if (File.Exists(path + fileName))
                {
                    try
                    {
                        FileStream fs = new FileStream(path + fileName, FileMode.Open, FileAccess.Read);
                        byte[] arrByte = new byte[(int)fs.Length];
                        int result = fs.Read(arrByte, 0, (int)fs.Length);
                        fs.Close();
                        obj = Neusoft.FrameWork.Function.Serialize.DeSerialization(arrByte) as Neusoft.FrameWork.Models.NeuObject;
                    }
                    catch (Exception e)
                    {
                        obj = null;
                    }
                }
                if (obj != null)
                {
                    drugDept = obj.Clone();
                }
                #endregion

                return drugDept;
            }
            set
            {
                drugDept = value;

                #region 默认上次选择药房为默认药房

                string path = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath;
                string fileName = "OrderDrugDept.ini";
                try
                {
                    FileStream fs = new FileStream(path + fileName, FileMode.Create, FileAccess.ReadWrite);
                    byte[] arrByte = Neusoft.FrameWork.Function.Serialize.Serialization(value);
                    fs.Write(arrByte, 0, arrByte.Length);
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                }
                catch (Exception e)
                { }

                #endregion
            }
        }
    }
}
