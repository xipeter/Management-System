using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.InBase
{
    /// <summary>
    /// [控件名称:ucDrugSplitProperty]<br></br>
    /// [功能描述: 住院药品拆分属性维护]<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-15]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDrugSplitProperty : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDrugSplitProperty()
        {
            InitializeComponent();
            //绑定列表数据选择事
            this.ucDrugList1.ChooseDataEvent += new Common.Controls.ucDrugList.ChooseDataHandler(ucDrugList1_ChooseDataEvent);
        }

        #region 变量

        /// <summary>
        /// 科室列表
        /// </summary>
        private ArrayList alDept = null;

        /// <summary>
        /// 剂型列表
        /// </summary>
        private ArrayList alDosageMode = null;

        /// <summary>
        /// 拆分属性
        /// </summary>
        private ArrayList drugSplitPropertyList = new ArrayList();// { "0不可拆分" , "1可拆分不取整" , "2可拆分上取整" , "3不可拆分当日取整","4可拆分按科室取整","5可拆分按病区取整" };

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item drugManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 帮助
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper objHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 当前视图
        /// </summary>
        private FarPoint.Win.Spread.SheetView currentView = null;

        /// <summary>
        /// 当前行
        /// </summary>
        private int currentRow = 0;

        #endregion

        #region 属性

        private bool noSplitAtAll = true;
        /// <summary>
        /// 0不可拆分
        /// </summary>
        [Description("住院药品不可拆分"), Category("设置"), DefaultValue(true),Browsable(false)]
        public bool NoSplitAtAll
        {
            get
            {
                return noSplitAtAll;
            }
            set
            {
                noSplitAtAll = value;
            }
        }

        private bool splitAndNoInteger = true;
        /// <summary>
        /// 1可拆分不取整
        /// </summary>
        [Description("住院药品可拆分不取整"), Category("设置"), DefaultValue(true), Browsable(false)]
        public bool SplitAndNoInteger
        {
            get
            {
                return splitAndNoInteger;
            }
            set
            {
                splitAndNoInteger = value;
            }
        }

        private bool splitAndUpperToInteger = true;
        /// <summary>
        /// 2可拆分上取整
        /// </summary>
        [Description("住院药品可拆分上取整"), Category("设置"), DefaultValue(true), Browsable(false)]
        public bool SplitAndUpperToInteger
        {
            get
            {
                return splitAndUpperToInteger;
            }
            set
            {
                splitAndUpperToInteger = value;
            }
        }

        private bool nosplitAndDayToInteger = true;
        /// <summary>
        /// 3不可拆分当日取整
        /// </summary>
        [Description("住院药品不可拆分当日取整"), Category("设置"), DefaultValue(true), Browsable(false)]
        public bool NosplitAndDayToInteger
        {
            get
            {
                return nosplitAndDayToInteger;
            }
            set
            {
                nosplitAndDayToInteger = value;
            }
        }

        private bool splitAndDeptToInteger = true;
        /// <summary>
        /// 4可拆分按科室取整
        /// </summary>
        [Description("住院药品可拆分按科室取整"), Category("设置"), DefaultValue(true), Browsable(false)]
        public bool SplitAndDeptToInteger
        {
            get
            {
                return splitAndDeptToInteger;
            }
            set
            {
                splitAndDeptToInteger = value;
            }
        }

        private bool splitAndNurceCellToInteger = true;
        /// <summary>
        /// 5可拆分按病区取整
        /// </summary>
        [Description("住院药品可拆分按病区取整"), Category("设置"), DefaultValue(true), Browsable(false)]
        public bool SplitAndNurceCellToInteger
        {
            get
            {
                return splitAndNurceCellToInteger;
            }
            set
            {
                splitAndNurceCellToInteger = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            // 加载科室
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.Models.Base.Department temp = new Neusoft.HISFC.Models.Base.Department();

            temp.ID = "AAAA";
            temp.Name = "全院";
            alDept = manager.GetDepartment();
            if (alDept == null)
            {
                MessageBox.Show(Language.Msg("获得全院科室列表出错！") + manager.Err);
                return;
            }
            alDept.Insert(0, temp);

            objHelper.ArrayObject = alDept;
            // 加载药品剂型
            alDosageMode = manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM);
            if (alDosageMode == null)
            {
                MessageBox.Show(Language.Msg("获取药品剂型出错!") + manager.Err);
                return;
            }

            this.InitControlParam();
        }

        /// <summary>
        /// 初始化常数信息
        /// </summary>
        private void InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            //是否可设置不可拆分属性
            this.NoSplitAtAll = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Can_Set_NoSplitAtAll, true, true);
            //是否可设置可拆分不取整属性
            this.SplitAndNoInteger = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Can_Set_SplitAndNoInteger, true, false);
            //是否可设置可拆分上取整属性
            this.SplitAndUpperToInteger = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Can_Set_SplitAndUpperToInteger, true, true);
            //是否可设置不可拆分当日取整属性
            this.NosplitAndDayToInteger = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Can_Set_NosplitAndDayToInteger, true, true);
            //是否可设置住院药品可拆分按科室取整
            this.SplitAndDeptToInteger = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Can_Set_SplitAndDeptToInteger, true, false);
            //是否可设置住院药房可拆分按病区取整
            this.SplitAndNurceCellToInteger = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Can_Set_SplitAndNurceCellToInteger, true, false);
        }

        /// <summary>
        /// 设置Fp显示格式
        /// </summary>
        private void SetFpValueType()
        {
            if (this.noSplitAtAll)
            {
                this.drugSplitPropertyList.Add("0不可拆分");
            }
            if (this.splitAndNoInteger)
            {
                this.drugSplitPropertyList.Add("1可拆分不取整");
            }
            if (this.splitAndUpperToInteger)
            {
                this.drugSplitPropertyList.Add("2可拆分上取整");
            }
            if (this.nosplitAndDayToInteger)
            {
                this.drugSplitPropertyList.Add("3不可拆分当日取整");
            }
            if (this.splitAndDeptToInteger)
            {
                this.drugSplitPropertyList.Add("4可拆分按科室取整");
            }
            if (this.splitAndNurceCellToInteger)
            {
                this.drugSplitPropertyList.Add("5可拆分按病区取整");
            }
            //生成下拉列表
            string[] str = new string[this.drugSplitPropertyList.Count];
            for (int i = 0; i < this.drugSplitPropertyList.Count; i++)
            {
                str[i] = this.drugSplitPropertyList[i].ToString();
            }

            FarPoint.Win.Spread.CellType.ComboBoxCellType cel = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            cel.Items = str;
            this.neuSpread1_Sheet1.Columns[5].CellType = cel;
            this.neuSpread1_Sheet2.Columns[1].CellType = cel;
        }

        /// <summary>
        /// 初始化原始数据
        /// </summary>
        private void LoadDrugSplitProperty()
        {
            //药品信息实体
            Neusoft.HISFC.Models.Pharmacy.Item drugInfo;
            //临时变量，合成拆分属性
            string tempProperty = "";
            //获取全部配药属性
            ArrayList alProperty = drugManager.QueryDrugProperty();
            if (alProperty == null)
            {
                MessageBox.Show(Language.Msg("获取配药属性出错!") + drugManager.Err);
                return;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在加载药品配药属性信息..."));
            Application.DoEvents();
            foreach (Neusoft.FrameWork.Models.NeuObject info in alProperty)
            {
                switch (info.User01)
                {
                    case "0":
                        tempProperty = "0不可拆分";
                        break;
                    case "1":
                        tempProperty = "1可拆分不取整";
                        break;
                    case "2":
                        tempProperty = "2可拆分上取整";
                        break;
                    case "3":
                        tempProperty = "3不可拆分当日取整";
                        break;
                    case "4":
                        tempProperty = "4可拆分按科室取整";
                        break;
                    case "5":
                        tempProperty = "5可拆分按病区取整";
                        break;

                }
                //药品
                if (info.Memo == "0")
                {
                    //取药品字典信息
                    drugInfo = this.drugManager.GetItem(info.ID);
                    if (drugInfo == null) continue;
                    //拆分属性
                    drugInfo.User01 = tempProperty;
                    //部门编码
                    drugInfo.Product.Company.ID = info.User02;

                    //drugInfo.Product.Company.Name = this.objHelper.GetObjectFromID(info.User02).Name;
                    drugInfo.Product.Company.Name = this.objHelper.GetName(info.User02);

                    //部门名称
                    this.AddRow(drugInfo, 0);
                }
                else//剂型
                {
                    drugInfo = new Neusoft.HISFC.Models.Pharmacy.Item();
                    //剂型编码
                    drugInfo.ID = info.ID;
                    //剂型名称
                    drugInfo.Name = info.Name;
                    //拆分属性
                    drugInfo.User01 = tempProperty;
                    //部门编码
                    drugInfo.Product.Company.ID = info.User02;
                    //部门名称
                    drugInfo.Product.Company.Name = this.objHelper.GetObjectFromID(info.User02).Name;
                    this.AddRow(drugInfo, 1);
                }
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        /// <summary>
        /// 重复判断
        /// </summary>
        /// <param name="index"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        private int RepeatCheck(int index, string ID)
        {
            //药品信息
            if (index == 0)
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    string id = this.neuSpread1_Sheet1.Cells[i, 0].Tag.ToString();
                    if (id == ID)
                    {
                        MessageBox.Show(Language.Msg("当前选择药品已经存在，请重新选择!"));
                        return -1;
                    }
                }
            }
            else
            {
            }
            return 0;
        }

        /// <summary>
        /// 添加一行
        /// </summary>
        /// <param name="item">药品信息实体</param>
        /// <param name="index">0药品1剂型</param>
        private void AddRow(Neusoft.HISFC.Models.Pharmacy.Item item, int index)
        {
            //药品明细
            if (index == 0)
            {
                //if( this.RepeatCheck( index , item.ID ) < 0 )
                //{
                //    return;
                //}

                int rowCount = this.neuSpread1_Sheet1.Rows.Count;
                this.neuSpread1_Sheet1.Rows.Add(rowCount, 1);
                //药品编码
                this.neuSpread1_Sheet1.Cells.Get(rowCount, 0).Tag = item.ID;
                //药品名称
                this.neuSpread1_Sheet1.Cells.Get(rowCount, 0).Value = item.Name;
                //规格
                this.neuSpread1_Sheet1.Cells.Get(rowCount, 1).Value = item.Specs;
                //包装数量
                this.neuSpread1_Sheet1.Cells.Get(rowCount, 2).Value = item.PackQty;
                //包装单位
                this.neuSpread1_Sheet1.Cells.Get(rowCount, 3).Value = item.PackUnit;
                //最小单位
                this.neuSpread1_Sheet1.Cells.Get(rowCount, 4).Value = item.MinUnit;
                //拆分属性
                this.neuSpread1_Sheet1.Cells.Get(rowCount, 5).Value = item.User01;
                //部门名称
                this.neuSpread1_Sheet1.Cells.Get(rowCount, 6).Value = item.Product.Company.Name;
                //部门编码
                this.neuSpread1_Sheet1.Cells.Get(rowCount, 6).Tag = item.Product.Company.ID;
            }
            else //剂型信息
            {
                int rowCount = this.neuSpread1_Sheet2.Rows.Count;
                this.neuSpread1_Sheet2.Rows.Add(rowCount, 1);
                //剂型编码
                this.neuSpread1_Sheet2.Cells.Get(rowCount, 0).Tag = item.ID;
                //剂型名称
                this.neuSpread1_Sheet2.Cells.Get(rowCount, 0).Value = item.Name;
                //拆分属性
                this.neuSpread1_Sheet2.Cells.Get(rowCount, 1).Value = item.User01;
                //部门编码
                this.neuSpread1_Sheet2.Cells.Get(rowCount, 2).Tag = item.Product.Company.ID;
                //部门名称
                this.neuSpread1_Sheet2.Cells.Get(rowCount, 2).Value = item.Product.Company.Name;
            }
        }

        /// <summary>
        /// 增加一空行
        /// </summary>
        private void AddRow()
        {
            if (this.neuSpread1.ActiveSheetIndex == 0)
            {
                if (currentRow >= 0 && currentView != null)
                {
                    this.ucDrugList1_ChooseDataEvent(currentView, currentRow);
                }
                else
                {
                    MessageBox.Show(Language.Msg("请选择药品"));
                }

            }
            else
            {
                //插入空行
                Neusoft.HISFC.Models.Pharmacy.Item item = new Neusoft.HISFC.Models.Pharmacy.Item();
                //添加数据
                this.AddRow(item, 1);
            }
        }

        /// <summary>
        /// 删除一行
        /// </summary>
        private void DeleteRow()
        {
            if (this.neuSpread1.ActiveSheet.Rows.Count <= 0)
            {
                return;
            }
            DialogResult result = MessageBox.Show(Language.Msg("确认删除该条配药属性设置吗？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.No)
            {
                return;
            }
            //定义数据库处理事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            this.drugManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            string itemCode = "";
            string deptCode = "";
            //药品明细
            if (this.neuSpread1.ActiveSheetIndex == 0)
            {
                itemCode = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Tag.ToString();
                deptCode = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 6].Tag.ToString();
            }
            else //剂型信息
            {
                itemCode = this.neuSpread1_Sheet2.Cells[this.neuSpread1_Sheet2.ActiveRowIndex, 0].Tag.ToString();
                deptCode = this.neuSpread1_Sheet2.Cells[this.neuSpread1_Sheet2.ActiveRowIndex, 2].Tag.ToString();
            }

            if (this.drugManager.DeleteDrugProperty(this.neuSpread1.ActiveSheet.ActiveRowIndex.ToString(), itemCode, deptCode) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("删除配药属性数据失败！") + this.drugManager.Err);
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.neuSpread1.ActiveSheet.Rows.Remove(this.neuSpread1.ActiveSheet.ActiveRowIndex, 1);
        }

        /// <summary>
        /// 有效性判断
        /// </summary>
        /// <returns>填写正确返回1 否则返回－1</returns>
        private int isValid()
        {
            if (this.neuSpread1.ActiveSheetIndex == 0)
            {
                #region 药品明细
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    if (this.neuSpread1_Sheet1.Cells[i, 0].Text == "")
                    {
                        MessageBox.Show(Language.Msg("请选择第  ") + (i + 1).ToString() + Language.Msg("  行对应的药品"));
                        return -1;
                    }
                    if (this.neuSpread1_Sheet1.Cells[i, 5].Text == "")
                    {
                        MessageBox.Show(Language.Msg("请选择第  ") + (i + 1).ToString() + Language.Msg("  行对应的配药属性"));
                        return -1;
                    }
                    if (this.neuSpread1_Sheet1.Cells[i, 6].Text == "")
                    {
                        MessageBox.Show(Language.Msg("请选择第") + (i + 1).ToString() + Language.Msg("行科室"));
                        return -1;
                    }
                }
                #endregion
            }
            else
            {
                #region 药品剂型
                for (int i = 0; i < this.neuSpread1_Sheet2.RowCount; i++)
                {
                    if (this.neuSpread1_Sheet2.Cells[i, 0].Text == "")
                    {
                        MessageBox.Show(Language.Msg("请选择第  ") + (i + 1).ToString() + Language.Msg("  行对应的药品剂型"));
                        return -1;
                    }
                    if (this.neuSpread1_Sheet1.Cells[i, 1].Text == "")
                    {
                        MessageBox.Show(Language.Msg("请选择第  ") + (i + 1).ToString() + Language.Msg("  行对应的配药属性"));
                        return -1;
                    }
                    if (this.neuSpread1_Sheet2.Cells[i, 2].Text == "")
                    {
                        MessageBox.Show(Language.Msg("请选择第  ") + (i + 1).ToString() + Language.Msg("  行对应的科室"));
                        return -1;
                    }
                }
                #endregion
            }
            return 1;
        }

        /// <summary>
        /// 保存
        /// </summary>
        private int SaveData()
        {
            if (this.isValid() == -1)
            {
                return -1;
            }

            //定义数据库处理事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            this.drugManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //全部删除
            if (this.drugManager.DeleteDrugProperty(this.neuSpread1.ActiveSheetIndex.ToString(), "A", "A") == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("删除原有配药属性数据失败！") + this.drugManager.Err);
                return -1;
            }
            Neusoft.FrameWork.Models.NeuObject info;
            if (this.neuSpread1.ActiveSheetIndex == 0)
            {
                #region 药品
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();
                    //药品编码
                    info.ID = this.neuSpread1_Sheet1.Cells[i, 0].Tag.ToString();
                    //药品名称
                    info.Name = this.neuSpread1_Sheet1.Cells[i, 0].Value.ToString();
                    //类型
                    info.Memo = "0";
                    //拆分属性								
                    info.User01 = this.neuSpread1_Sheet1.Cells[i, 5].Value.ToString().Substring(0, 1);
                    //部门编码 "AAAA" 全院
                    info.User02 = this.neuSpread1_Sheet1.Cells[i, 6].Tag.ToString();
                    //插入表
                    if (this.drugManager.InsertDrugProperty(info) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        if (this.drugManager.DBErrCode == 1)
                        {
                            MessageBox.Show(Language.Msg("数据已存在，不能重复维护！\n" + "药品名称：") + info.Name + Language.Msg("\n 部门名称：") + this.neuSpread1_Sheet1.Cells[i, 6].Text);
                        }
                        else
                        {
                            MessageBox.Show(this.drugManager.Err);
                        }
                        return -1;
                    }
                }
                #endregion
            }
            else
            {
                #region 剂型
                for (int i = 0; i < this.neuSpread1_Sheet2.Rows.Count; i++)
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();
                    //剂型编码
                    info.ID = this.neuSpread1_Sheet2.Cells[i, 0].Tag.ToString();
                    //剂型名称
                    info.Name = this.neuSpread1_Sheet2.Cells[i, 0].Value.ToString();
                    //类型 0 药品 1 剂型
                    info.Memo = "1";
                    //拆分属性						
                    info.User01 = this.neuSpread1_Sheet2.Cells[i, 1].Value.ToString().Substring(0, 1);
                    //部门编码 "AAAA" 全院
                    info.User02 = this.neuSpread1_Sheet2.Cells[i, 2].Tag.ToString();

                    if (this.drugManager.InsertDrugProperty(info) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        if (this.drugManager.DBErrCode == 1)
                        {
                            MessageBox.Show(Language.Msg("数据已存在，不能重复维护！\n" + "药品名称：") + info.Name + Language.Msg("\n 部门名称：") + this.neuSpread1_Sheet2.Cells[i, 2].Text);
                        }
                        else
                        {
                            MessageBox.Show(this.drugManager.Err);
                        }
                        return -1;
                    }
                }
                #endregion
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Language.Msg("保存成功！"));
            return 1;
        }

        /// <summary>
        /// 弹出选择窗口
        /// </summary>
        private void PopSelectWindow()
        {
            if (this.neuSpread1.ActiveSheet.Rows.Count <= 0)
            {
                return;
            }
            //当前记录的行、列
            int iRow = this.neuSpread1.ActiveSheet.ActiveRowIndex;
            int iColumn = this.neuSpread1.ActiveSheet.ActiveColumnIndex;
            if (iRow < 0) return;

            #region 科室
            if ((this.neuSpread1.ActiveSheetIndex == 0 && iColumn == 6) || (this.neuSpread1.ActiveSheetIndex == 1 && iColumn == 2))
            {

                Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alDept, ref info) == 0)
                {
                    return;
                }
                else
                {
                    //药品明细
                    if (this.neuSpread1.ActiveSheetIndex == 0)
                    {
                        //部门编码
                        this.neuSpread1_Sheet1.Cells[iRow, 6].Tag = info.ID;
                        //部门名称
                        this.neuSpread1_Sheet1.Cells[iRow, 6].Value = info.Name;
                    }
                    else//药品剂型							
                    {
                        //部门编码
                        this.neuSpread1_Sheet2.Cells[iRow, 2].Value = info.Name;
                        //部门名称
                        this.neuSpread1_Sheet2.Cells[iRow, 2].Tag = info.ID;
                    }
                }
            }
            #endregion

            #region 剂型
            if (this.neuSpread1.ActiveSheetIndex == 1 && iColumn == 0)
            {
                Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alDosageMode, ref info) == 0)
                {
                    return;
                }
                else
                {
                    //剂型编码
                    this.neuSpread1_Sheet2.Cells[iRow, 0].Value = info.Name;
                    //剂型名称
                    this.neuSpread1_Sheet2.Cells[iRow, 0].Tag = info.ID;
                }
            }
            #endregion 剂型
        }

        #endregion

        #region 事件
        //初始化
        protected override void OnLoad(EventArgs e)
        {
            //显示药品信息
            this.ucDrugList1.ShowPharmacyList();
            //初始化科室、剂型列表
            this.InitData();
            //设置Fp显示格式
            this.SetFpValueType();
            //初始化已维护数据
            this.LoadDrugSplitProperty();

            this.ucDrugList1.ShowAdvanceFilter = false;
            base.OnLoad(e);
        }

        /// <summary>
        /// 列表选择触发的事件
        /// </summary>
        /// <param name="sv">视图</param>
        /// <param name="activeRow">选择的行</param>
        private void ucDrugList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            if (this.neuSpread1.ActiveSheetIndex != 0)
            {
                this.neuSpread1.ActiveSheetIndex = 0;
            }
            if (sv != null && activeRow >= 0)
            {
                this.currentView = sv;
                this.currentRow = activeRow;
                string drugID;
                drugID = sv.Cells[activeRow, 0].Value.ToString();
                //取药品字典信息
                Neusoft.HISFC.Models.Pharmacy.Item drugItem = this.drugManager.GetItem(drugID);
                if (drugItem != null)
                {
                    //添加数据
                    this.AddRow(drugItem, 0);
                }
                else
                {
                    MessageBox.Show(Language.Msg("检索药品基本信息失败"));
                }
            }
        }

        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.PopSelectWindow();
        }
        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object NeuObject, object param)
        {
            //增加工具栏
            this.toolBarService.AddToolButton("增加", "增加", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            this.toolBarService.AddToolButton("删除", "删除", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            return this.toolBarService;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveData();
            return base.OnSave(sender, neuObject);
        }

        /// <summary>
        /// 工具栏按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加":
                    this.AddRow();
                    break;
                case "删除":
                    this.DeleteRow();
                    break;
            }

        }

        #endregion


    }
}
