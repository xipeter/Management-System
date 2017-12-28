using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.WinForms.Classes;
using System.Collections;
using System.Xml;
using FarPoint.Win.Spread;
namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// [功能描述: 项目列表]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucItemList : UserControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
       
        public ucItemList()
        {
            InitializeComponent();
            InitDataSet();
        }

        public ucItemList(EnumShowItemType type)
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。
            InitializeComponent();

            // TODO: 在 InitializeComponent 调用后添加任何初始化


            InitDataSet();
            //加载项目
            _enuShowItemType = type;
            Init();
        }

        #region 变量
        //项目数组
        private ArrayList _alItems = new ArrayList();
        //项目dataset
        private DataSet _dsItems;
        private DataView _dvItems;
        //显示项目范围
        protected EnumShowItemType _enuShowItemType = EnumShowItemType.All;
        //查询方式0:拼音码 1:五笔码 2:自定义码 3:国标码 4:英文
        private int _InputType = 0;
        /// <summary>
        /// 患者所在科室
        /// </summary>
        private string patientDept = string.Empty;
        //dataview中的当前行
        private int _CurrentRow = -1;
        public delegate int MyDelegate(Keys key);
        /// <summary>
        /// 双击、回车项目列表时执行的事件
        /// </summary>
        public event MyDelegate SelectItem;

        //{4AAE2DA2-80C2-4297-A0F2-7E314F8BBF6D}
        /// <summary>
        /// 加载项目线程
        /// </summary>
        System.Threading.Thread threadItem;
        //设置fp状态
        delegate void InitFpStateHander();

        #region  {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}

        /// <summary>
        /// 详细信息文本
        /// </summary>
        public System.Windows.Forms.TextBox txt = new TextBox();

        /// <summary>
        /// 项目扩展信息接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Common.IItemExtendInfo iItemExtendInfo = null;

        /// <summary>
        /// 项目扩展信息接口
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Interface.Common.IItemExtendInfo IItemExtendInfo
        {
            get
            {
                if (this.iItemExtendInfo == null)
                {
                    this.iItemExtendInfo = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Common.IItemExtendInfo)) as Neusoft.HISFC.BizProcess.Interface.Common.IItemExtendInfo;
                }

                return this.iItemExtendInfo;
            }
        }

        /// <summary>
        /// 患者基本信息实体
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 患者基本信息实体
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            get { return patient; }
            set { patient = value;}
        }

        #endregion

        #endregion

        #region 属性
        /// <summary>
        /// 显示项目范围
        /// </summary>
        public EnumShowItemType enuShowItemType
        {
            get
            {
                return _enuShowItemType;
            }
            set
            {
                _enuShowItemType = value;
            }
        }
        /// <summary>
        /// 获取查询方式0:拼音码 1:五笔码 2:自定义码 3:国标码 4:英文
        /// </summary>
        public int InputType
        {
            get
            {
                return _InputType;
            }
        }
      
        /// <summary>
        /// 患者科室编码
        /// </summary>
        public string PatientDept
        {
            get { return patientDept; }
            set { patientDept = value;
            this.Init(value);
        }
        }

        /// <summary>
        /// {112B7DB5-0462-4432-AD9D-17A7912FFDBE}  获取项目医保标记接口 
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade iGetSiFlag = null;

        /// <summary>
        /// {112B7DB5-0462-4432-AD9D-17A7912FFDBE}  获取项目医保标记接口 
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade IGetSiFlag
        {
            get
            {
                if (this.iGetSiFlag == null)
                {
                    this.iGetSiFlag = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade;
                }

                return this.iGetSiFlag;
            }
        }

        #endregion

        #region 函数

        /// <summary>
        ///初始设置调用
        /// </summary>
        /// <returns></returns>
        protected virtual  int Init()
        {
            //{4AAE2DA2-80C2-4297-A0F2-7E314F8BBF6D}
            threadItem = new System.Threading.Thread(new System.Threading.ThreadStart(InitItem));
            threadItem.IsBackground = true;
            threadItem.Start();
            this.FindForm().FormClosing += new FormClosingEventHandler(ucItemList_FormClosing);
            this.AddBottomControl(this.txt);// {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
            return 1;
        }
        //{4AAE2DA2-80C2-4297-A0F2-7E314F8BBF6D}
        void ucItemList_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            this.threadItem.Abort();
           
        }

        //{4AAE2DA2-80C2-4297-A0F2-7E314F8BBF6D}
        /// <summary>
        /// 加载项目信息
        /// </summary>
        protected void InitItem()
        {
            int _intRtn;

            _intRtn = AddItemsToArrayList(patientDept);
            if (_intRtn == -1) return ;

            _intRtn = AddItemsToDataSet();
            if (_intRtn == -1) return ;
            AddGroup(patientDept);
            InitFpStateHander OnSetFpState = new InitFpStateHander(InitFpState);
            this.Invoke(OnSetFpState);
        }

        //{4AAE2DA2-80C2-4297-A0F2-7E314F8BBF6D}
        /// <summary>
        /// 初始化Fp状态
        /// </summary>
        private void InitFpState()
        {
            if (_dvItems.Count == 0)
                _CurrentRow = -1;
            else
                _CurrentRow = 0;
            AddItemsToSheet(_CurrentRow);
            fpSpread1_Sheet1.AddSelection(0, 0, 1, 1);
            fpSpread1_Sheet1.ActiveRowIndex = 0;
            DisplayCurrentRow(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientDept"></param>
        /// <returns></returns>
        public int Init(string patientDept)
        {
            //{190A587F-31D5-4253-9E73-61CC9055B081}
            this.patientDept = patientDept;
            if (Init() == -1) return -1;
            return 1;
        }

        /// <summary>
        /// 得到本科室的物资信息
        /// </summary>
        /// <param name="deptId">科室编码</param>
        /// <returns></returns>
        private List<Neusoft.HISFC.Models.FeeStuff.MaterialItem> GetMateList(string deptId)
        {
            //物资
            Neusoft.HISFC.BizProcess.Integrate.Material.Material _meItems = new Neusoft.HISFC.BizProcess.Integrate.Material.Material();
            List<Neusoft.HISFC.Models.FeeStuff.MaterialItem> list = _meItems.QueryStockHeadItemForFee(deptId);
            if (list == null)
            {
                MessageBox.Show("加载物资项目失败" + _meItems.Err);
                return null;
            }
            return list;
        }

        /// <summary>
        /// 刷新DataSet
        /// </summary>
        public int RefreshDataSet(string deptId)
        {
            //查找物资项目
            DataRow[] vdr = _dsItems.Tables["items"].Select("isdrug = '6'");
            foreach (DataRow dr in vdr)
            {
                _dsItems.Tables["items"].Rows.Remove(dr);
            }
            for (int i = 0; i < _alItems.Count; i++)
            {
                if (_alItems[i].GetType() == typeof(Neusoft.HISFC.Models.FeeStuff.MaterialItem))
                {
                    _alItems.RemoveAt(i);
                }
            }
            //查找物资项目
            List<Neusoft.HISFC.Models.FeeStuff.MaterialItem> list = GetMateList(deptId);
            _alItems.AddRange(list.ToArray());
            //刷新dataset
            foreach (Neusoft.HISFC.Models.FeeStuff.MaterialItem item in list)
            {
                _dsItems.Tables["items"].Rows.Add(new Object[]{item.UserCode, //输入码
                                                                       item.SpellCode,//拼音码
                                                                       item.WbCode,//五笔码
                                                                        item.ID,//项目代码
                                                                        item.Name,//项目名称
                                                                        item.Specs,//规格
                                                                        item.Price,//价格
                                                                        item.PriceUnit,//单位
                                                                        string.Empty,//生产厂家
                                                                        item.Memo,//备注
                                                                        string.Empty,//医保级别
                                                                        "6",//物资
                                                                        item.GbCode,//国标码
                                                                        string.Empty,//频次名称
                                                                        string.Empty,//用法名称
                                                                        item.SysClass.Name,//系统类别
                                                                        string.Empty,//英文
                                                                        string.Empty,//公费标志
                                                                        item.Price,//儿童价格
                                                                        item.Price//特诊价格
                                                                        
                        });
            }
            this.fpSelectionChanged();// {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
            return 1;
        }

        private void InitDataSet()
        {
            //初始化
            //SetStyle(Function.CurrentPath + Function.SettingPath+"feeSetting.xml", "//Column", fpSpread1_Sheet1);
            SetStyle("", "", fpSpread1_Sheet1);
            SetAutoSize();
            _dsItems = new DataSet();
            _dsItems.Tables.Add("items");
            _dsItems.Tables["items"].Columns.AddRange(new DataColumn[]
				{
					new DataColumn("input_code",Type.GetType("System.String")),//输入码
					new DataColumn("spell_code",Type.GetType("System.String")),//拼音码
					new DataColumn("wb_code",Type.GetType("System.String")),//五笔码
					new DataColumn("item_code",Type.GetType("System.String")),//项目代码
					new DataColumn("item_name",Type.GetType("System.String")),//项目名称
					new DataColumn("specs",Type.GetType("System.String")),//规格
					new DataColumn("price",Type.GetType("System.String")),//价格
					new DataColumn("unit",Type.GetType("System.String")),//单位
					new DataColumn("producer",Type.GetType("System.String")),//生产厂家
					new DataColumn("memo",Type.GetType("System.String")),//备注
					new DataColumn("grade",Type.GetType("System.String")),//医保级别
					new DataColumn("isdrug",Type.GetType("System.String")),//1药，2非药
					new DataColumn("gb_code",Type.GetType("System.String")),//国标码
					new DataColumn("freq_name",Type.GetType("System.String")),//频次名称
					new DataColumn("usage_name",Type.GetType("System.String")),//用法名称
					new DataColumn("class_code",Type.GetType("System.String")),//系统类别
					new DataColumn("english_code",Type.GetType("System.String")),//英文
					new DataColumn("pub_grade",Type.GetType("System.String")),//公费标志
					new DataColumn("child_price",Type.GetType("System.String")),//儿童价格
					new DataColumn("special_price",Type.GetType("System.String"))//特诊价格
				});
            _dsItems.CaseSensitive = false;
            _dvItems = new DataView(_dsItems.Tables["items"]);
            GetQueryType();
        }

        enum Cols
        {
            input_code ,//输入码0
			spell_code ,//拼音码1
			wb_code ,//五笔码2
			item_code ,//项目代码3
			item_name ,//项目名称4
			specs ,//规格5
			price ,//价格6
			unit ,//单位7
			producer ,//生产厂家8
			memo ,//备注9
			grade ,//医保级别10
			isdrug ,//1药，2非药11
			gb_code ,//国标码12
			freq_name ,//频次名称13
			usage_name ,//用法名称14
			class_code ,//系统类别15
			english_code ,//英文16
			pub_grade ,//公费标志17
			child_price ,//儿童价格18
			special_price ,//特诊价格19
        }

        //{4AAE2DA2-80C2-4297-A0F2-7E314F8BBF6D}
        /// <summary>
        /// 添加操作员所在科室的组套
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        protected int AddGroup(string deptID)
        {
            //添加组套
            Neusoft.HISFC.BizLogic.Manager.ComGroup group = new Neusoft.HISFC.BizLogic.Manager.ComGroup();
            ArrayList al = group.GetValidGroupList(deptID);
            if (al == null) return 0;

            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.ComGroup obj;
                obj = (Neusoft.HISFC.Models.Fee.ComGroup)al[i];
                _dsItems.Tables["items"].Rows.Add(new Object[] {obj.inputCode,obj.spellCode,string.Empty,
																   obj.ID,obj.Name,obj.reMark,string.Empty,
																   "[组套]",string.Empty,obj.reMark,
																   string.Empty,"3",string.Empty,
																   string.Empty,string.Empty,"组套",
																   string.Empty,string.Empty,string.Empty,string.Empty });
            }

            _alItems.AddRange(al);

            //AddCompound();//添加复合项

            //if (_dvItems.Count == 0)
            //    _CurrentRow = -1;
            //else
            //    _CurrentRow = 0;
            //AddItemsToSheet(_CurrentRow);
            //fpSpread1_Sheet1.AddSelection(0, 0, 1, 1);
            //fpSpread1_Sheet1.ActiveRowIndex = 0;
            //DisplayCurrentRow(0);

            return 0;
        }
        /// <summary>
        /// 添加体检组套
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public int AddExamGroup(string deptID)
        {
            ////添加组套
            Neusoft.HISFC.BizLogic.PhysicalExamination.Group group = new Neusoft.HISFC.BizLogic.PhysicalExamination.Group();
            ArrayList al = group.QueryValidGroupList(deptID);
            if (al == null) return 0;

            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.PhysicalExamination.Group obj;
                obj = (Neusoft.HISFC.Models.PhysicalExamination.Group)al[i];
                _dsItems.Tables["items"].Rows.Add(new Object[] {obj.inputCode,obj.spellCode,obj.WBCode,
																	   obj.ID,obj.Name,string.Empty,string.Empty,
																	   "[体检组套]",string.Empty,string.Empty,
																	   string.Empty,"5",string.Empty,
																	   string.Empty,string.Empty,"体检组套",
																	   string.Empty,string.Empty,string.Empty,string.Empty });
            }

            _alItems.AddRange(al);

            //AddCompound();//添加复合项

            //if (_dvItems.Count == 0)
            //    _CurrentRow = -1;
            //else
            //    _CurrentRow = 0;
            //AddItemsToSheet(_CurrentRow);
            //fpSpread1_Sheet1.AddSelection(0, 0, 1, 1);
            //fpSpread1_Sheet1.ActiveRowIndex = 0;
            //DisplayCurrentRow(0);

            return 0;
        }
        #endregion

        #region 私有函数
        /// <summary>
        /// 添加复合项目
        /// </summary>
        /// <returns></returns>
        [Obsolete("作废,已经合并到非药品中",true)]
        private void AddCompound()
        {
            //添加复合项目
            //Neusoft.HISFC.BizLogic.Fee.UndrugComb compound = new Neusoft.HISFC.BizLogic.Fee.UndrugComb();
            //ArrayList al = compound.QueryUndrugCombsValid();
            //if (al == null) return;
            //for (int i = 0; i < al.Count; i++)
            //{
            //    Neusoft.HISFC.Models.Fee.Undrugztinfo obj;
            //    obj = (Neusoft.HISFC.Models.Fee.Undrugztinfo)al[i];
            //    Neusoft.HISFC.Models.Fee.Item.UndrugComb obj;
            //    obj = (Neusoft.HISFC.Models.Fee.Item.UndrugComb)al[i];
            //    _dsItems.Tables["items"].Rows.Add(new Object[] {obj.UserCode, //0
            //                                                    obj.SpellCode,//1
            //                                                    obj.WBCode,//2
            //                                                    obj.Package.ID,//3
            //                                                    obj.Package.Name,//4
            //                                                    string.Empty,//5
            //                                                    string.Empty,//6
            //                                                   "[复合项]",//7
            //                                                    string.Empty,//8
            //                                                    string.Empty,//9
            //                                                    string.Empty,//10
            //                                                    "4",//11
            //                                                    string.Empty,//12
            //                                                    string.Empty,//13
            //                                                    string.Empty,//14
            //                                                    "复合项",//15
            //                                                    string.Empty,//16
            //                                                    string.Empty,//17
            //                                                    string.Empty,//18
            //                                                    string.Empty //19
            //    });
            //}
            //_alItems.AddRange(al);
        }
        /// <summary>
        /// 自动调整项目列表大小
        /// </summary>
        /// <returns></returns>
        private int SetAutoSize()
        {
            //设置宽度
            int _intWidth = SystemInformation.Border3DSize.Width * 2;
            int i;

            _intWidth += (int)fpSpread1_Sheet1.RowHeader.Columns[0].Width;

            for (i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
            {
                if (fpSpread1_Sheet1.Columns[i].Visible)
                    _intWidth += (int)fpSpread1_Sheet1.Columns[i].Width;
            }

            //			_intWidth+=SystemInformation.VerticalScrollBarWidth;
            this.Width = _intWidth + 14;

            //设置高度
            int _intHeight = SystemInformation.Border3DSize.Height * 2;
            _intHeight += (int)fpSpread1_Sheet1.ColumnHeader.Rows[0].Height;
            #region {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
            if (this.pnlBottom.Visible)
            {
                _intHeight += 25;
            }
            #endregion
            for (i = 0; i < fpSpread1_Sheet1.RowCount; i++)
                _intHeight += (int)fpSpread1_Sheet1.Rows[i].Height;

            this.Height = _intHeight + 23;// {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}

            return 1;
        }
        /// <summary>
        /// 添加项目列表到_alItems
        /// </summary>
        /// <returns></returns>
        private int AddItemsToArrayList(string patientDept)
        {
            try
            {
                //TODO: 加载药品和非药品列表
                if (_enuShowItemType == EnumShowItemType.Pharmacy)
                {
                    Neusoft.HISFC.BizLogic.Pharmacy.Item _items = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                    if (patientDept == string.Empty)
                        _alItems = new ArrayList(_items.QueryItemAvailableList().ToArray());
                    else
                        _alItems = _items.QueryItemAvailableList(patientDept);
                }
                else if (_enuShowItemType == EnumShowItemType.Undrug)
                {
                    Neusoft.HISFC.BizLogic.Fee.Item _items = new Neusoft.HISFC.BizLogic.Fee.Item();
                    _alItems = _items.QueryValidItems();
                    ////物资
                    List<Neusoft.HISFC.Models.FeeStuff.MaterialItem> list = this.GetMateList((_items.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID);
                    _alItems.AddRange(list.ToArray());
                }
                else if (_enuShowItemType == EnumShowItemType.DeptItem)
                {
                    Neusoft.HISFC.BizLogic.Pharmacy.Item _items1 = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                    ArrayList _al1 = new ArrayList();
                    _al1 = new ArrayList(_items1.QueryItemAvailableListDept(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID).ToArray());
                    Neusoft.HISFC.BizLogic.Fee.Item _items2 = new Neusoft.HISFC.BizLogic.Fee.Item();
                    _alItems = _al1;
                    ArrayList _al2 = new ArrayList(_items2.QueryValidItemsList(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID));
                    _alItems.AddRange(_al2);

                }

                else
                {
                    Neusoft.HISFC.BizLogic.Pharmacy.Item _items1 = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                    ArrayList _al1 = new ArrayList();
                    if (patientDept == string.Empty)
                        _al1 = new ArrayList(_items1.QueryItemAvailableList().ToArray());
                    else
                        _al1 = _items1.QueryItemAvailableList(patientDept);
                    Neusoft.HISFC.BizLogic.Fee.Item _items2 = new Neusoft.HISFC.BizLogic.Fee.Item();
                    ArrayList _al2 = new ArrayList(_items2.QueryValidItemsList().ToArray());
                    _alItems = _al1;
                    _alItems.AddRange(_al2);
                    //物资
                    List<Neusoft.HISFC.Models.FeeStuff.MaterialItem> mateList = this.GetMateList((_items1.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID);
                    _alItems.AddRange(mateList.ToArray());
                }
            }
            #region{1FA0BCB8-3325-4db1-A9E2-74CE8453810E}
            //catch (System.Threading.ThreadAbortException ex)
            //{
 
            //}
            catch (System.Threading.ThreadAbortException ex) { }
            catch (NullReferenceException ex1) { }
            #endregion
            catch (Exception error)
            {
                MessageBox.Show("加载收费项目列表时出错!" + error.Message);
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 将_alItems的项目添加到_dsItems
        /// </summary>
        /// <returns></returns>
        private int AddItemsToDataSet()
        {
            _dsItems.Tables["items"].Clear();
            string  siflag = string.Empty;

            //try
            //{
                for (int i = 0; i < _alItems.Count; i++)
                {
                    if (_alItems[i] is Neusoft.HISFC.Models.Pharmacy.Item)
                    {
                        Neusoft.HISFC.Models.Pharmacy.Item obj;
                        obj = (Neusoft.HISFC.Models.Pharmacy.Item)_alItems[i];


                        //siflag = this.getSIFlag(obj.ID, obj.Grade);

                        _dsItems.Tables["items"].Rows.Add(new Object[] {obj.UserCode,//0
                                                                        obj.SpellCode,//1
                                                                        obj.WBCode,//2
                                                                        obj.ID,//3
                                                                        obj.Name,//4
                                                                        obj.Specs,//5
                                                                        obj.Price,//6
                                                                        obj.PackUnit,//7
                                                                        obj.Product.Name,//8
                                                                        obj.Memo,//9
                                                                        siflag,//10
                                                                        "1",//11
                                                                        obj.GBCode,//12
                                                                        obj.Frequency.Name,//13
                                                                        obj.Usage.Name,//14
                                                                        obj.SysClass.Name,//15
                                                                        obj.NameCollection.EnglishRegularName,//16
                                                                        string.Empty,//17
                                                                        obj.Price,//18
                                                                        obj.Price //19
                        });
                    }
                    else if (_alItems[i] is Neusoft.HISFC.Models.Fee.Item.Undrug)
                    {
                        Neusoft.HISFC.Models.Fee.Item.Undrug obj;
                        obj = (Neusoft.HISFC.Models.Fee.Item.Undrug)_alItems[i];


                        //siflag = this.getSIFlag(obj.ID, obj.Grade);
                        string strSysClass = obj.SysClass.Name;
                        string strPriceUnit = obj.PriceUnit;
                        if (obj.UnitFlag == "1")
                        {
                            strPriceUnit = "[复合项]";
                            strSysClass = "[复合项]";
                        }

                        _dsItems.Tables["items"].Rows.Add(new Object[] {obj.UserCode,//0
                                                                        obj.SpellCode,//1
                                                                        obj.WBCode,//2
                                                                        obj.ID,//3
                                                                        obj.Name,//4
                                                                        obj.Specs,//5
                                                                        obj.Price,//6
                                                                        strPriceUnit,//7
                                                                        string.Empty,//8
                                                                        obj.Memo,//9
                                                                        siflag,//10
                                                                        "2",//11
                                                                        obj.GBCode,//12
                                                                        string.Empty,//13
                                                                        string.Empty,//14
                                                                        strSysClass,//15
                                                                        string.Empty,//16
                                                                        string.Empty,//17
                                                                        obj.ChildPrice,//18
                                                                        obj.SpecialPrice//19
                        });
                    }
                    else if (_alItems[i] is Neusoft.HISFC.Models.FeeStuff.MaterialItem)
                    {
                        Neusoft.HISFC.Models.FeeStuff.MaterialItem obj;
                        obj = _alItems[i] as Neusoft.HISFC.Models.FeeStuff.MaterialItem;
                        _dsItems.Tables["items"].Rows.Add(new Object[]{obj.UserCode, //输入码
                                                                       obj.SpellCode,//拼音码
                                                                       obj.WbCode,//五笔码
                                                                        obj.ID,//项目代码
                                                                        obj.Name,//项目名称
                                                                        obj.Specs,//规格
                                                                        obj.Price,//价格
                                                                        obj.PriceUnit,//单位
                                                                        string.Empty,//生产厂家
                                                                        obj.Memo,//备注
                                                                        string.Empty,//医保级别
                                                                        "6",//物资
                                                                        obj.GbCode,//国标码
                                                                        string.Empty,//频次名称
                                                                        string.Empty,//用法名称
                                                                        obj.SysClass.Name,//系统类别
                                                                        string.Empty,//英文
                                                                        string.Empty,//公费标志
                                                                        obj.Price,//儿童价格
                                                                        obj.Price//特诊价格
                                                                        
                        });
                    }

                }
            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show("加载项目列表时出错!" + error.Message);
            //    return -1;
            //}


            //			_dsItems.CaseSensitive=false;
            //			_dvItems=new DataView(_dsItems.Tables["items"]);
            if (_dvItems.Count == 0)
                _CurrentRow = -1;
            else
                _CurrentRow = 0;

            return 1;
        }
       
        /// <summary>
        /// 得到医保标志
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        protected virtual string getSIFlag(string itemCode, string grade)
        {
            //{112B7DB5-0462-4432-AD9D-17A7912FFDBE}   获取医保项目标记
            if (this.IGetSiFlag != null)
            {
                grade = "0";

                this.IGetSiFlag.GetSiItemGrade(itemCode, ref grade);
            }

            return Neusoft.HISFC.BizLogic.Fee.Interface.ShowItemGradeByCode(grade);

        }
        /// <summary>
        /// 将_dsItems的项目添加到Sheet中，每次添加10条记录
        /// </summary>
        /// <returns></returns>
        private int AddItemsToSheet(int BeginIndex)
        {
            for (int i = BeginIndex; i < BeginIndex + 10; i++)
            {
                if (i > _dvItems.Count - 1 || _dvItems.Count == 0)
                {
                    for (int j = 0; j < fpSpread1_Sheet1.Columns.Count; j++)
                    {
                        fpSpread1_Sheet1.RowHeader.Rows[i - BeginIndex].Tag = string.Empty;
                        fpSpread1_Sheet1.SetValue(i - BeginIndex, j, string.Empty, false);
                    }
                }
                else
                {
                    DataRowView _row = _dvItems[i];
                    for (int j = 0; j < fpSpread1_Sheet1.Columns.Count; j++)
                    {
                        fpSpread1_Sheet1.RowHeader.Rows[i - BeginIndex].Tag = _row["isdrug"].ToString() + _row["item_code"].ToString();
                        if (fpSpread1_Sheet1.Columns[j].Tag == null)
                            fpSpread1_Sheet1.Columns[j].Tag = string.Empty;
                        fpSpread1_Sheet1.SetValue(i - BeginIndex, j, _row[fpSpread1_Sheet1.Columns[j].Tag.ToString()].ToString(), false);
                    }
                }
            }
            this.fpSelectionChanged();// {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
            return 1;
        }
        string _Text = string.Empty;
        /// <summary>
        /// 过滤项目
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public int Filter(string strText)
        {
            if (threadItem.ThreadState != System.Threading.ThreadState.Stopped)
            {
                return 1;
            }
            string _filter = strText.Trim();
            this._Text = _filter;
            if (_filter.Length > 0)
            {
                //"/"表示按中文名称检索，不管当前是何输入法
                if (_filter.Substring(0, 1) == "/")
                {
                    if (_filter.Length == 1) return 1;

                    _filter = "item_name LIKE '%" + _filter.Substring(1, _filter.Length - 1) + "%'";
                    try
                    {
                        _dvItems.RowFilter = _filter;
                    }
                    catch { }

                    if (_dvItems.Count == 0)
                        _CurrentRow = -1;
                    else
                        _CurrentRow = 0;

                    AddItemsToSheet(_CurrentRow);
                    fpSpread1_Sheet1.ActiveRowIndex = 0;
                    fpSpread1_Sheet1.AddSelection(0, 0, 1, 1);
                    DisplayCurrentRow(0);
                    return 1;
                }
            }

            //			switch(this._InputType)
            //			{
            //				case 0://拼音吗
            //					_filter="spell_code LIKE '%"+_filter+"%'";
            //					break;
            //				case 1://五笔
            //					_filter="wb_code LIKE '%"+_filter+"%'";
            //					break;
            //				case 2://自定义
            //					_filter="input_code LIKE '%"+_filter+"%'";
            //					break;
            //				case 3://国标
            //					_filter="gb_code LIKE '%"+_filter+"%'";
            //					break;
            //				case 4://英文
            //					_filter="english_code LIKE '%"+_filter+"%'";
            //					break;	
            //				default:
            //					return 1;
            //			}
            string filter;
            if (this.checkBox1.Checked)
                filter = "(spell_code LIKE '%" + _filter + "%') OR" + "(input_code LIKE '%" + _filter + "%') OR" + "(english_code LIKE '%" + _filter + "%') OR" + "(wb_code LIKE '%" + _filter + "%') OR" + "(item_name LIKE '%" + _filter + "%')";
            else
                filter = "(spell_code LIKE '" + _filter + "%') OR" + "(input_code LIKE '" + _filter + "%') OR" + "(english_code LIKE '" + _filter + "%') OR" + "(wb_code LIKE '" + _filter + "%') OR" + "(item_name LIKE '" + _filter + "%')";
            //			filter = "spell_code LIKE '%"+_filter+"%'";
            try
            {
                _dvItems.RowFilter = filter;
            }
            catch { }
            if (_dvItems.Count == 0)
                _CurrentRow = -1;
            else
                _CurrentRow = 0;

            AddItemsToSheet(_CurrentRow);
            fpSpread1_Sheet1.ActiveRowIndex = 0;
            fpSpread1_Sheet1.AddSelection(0, 0, 1, 1);
            DisplayCurrentRow(0);

            return 1;
        }
        /// <summary>
        /// 过滤项目
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Filter(string strText, string type)
        {
            if (threadItem.ThreadState != System.Threading.ThreadState.Stopped)
            {
                return 1;
            }
            string _filter = strText.Trim();
            this._Text = _filter;
            if (_filter.Length >= 0)
            {
                //				//"/"表示按中文名称检索，不管当前是何输入法
                //				if(_filter.Substring(0,1)=="/")
                //				{
                //					if(_filter.Length==1) return 1;

                _filter = "(( item_name LIKE '%" + _filter + "%' )" + " or ( spell_code LIKE '%" + _filter + "%' )" + " or ( input_code LIKE '%" + _filter + "%' )" + " or ( wb_code LIKE '%" + _filter + "%' )" + ") and  " + "unit LIKE '%" + type + "%'";
                try
                {
                    _dvItems.RowFilter = _filter;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (_dvItems.Count == 0)
                    _CurrentRow = -1;
                else
                    _CurrentRow = 0;

                AddItemsToSheet(_CurrentRow);
                fpSpread1_Sheet1.ActiveRowIndex = 0;
                fpSpread1_Sheet1.AddSelection(0, 0, 1, 1);
                DisplayCurrentRow(0);
                return 1;
                //				}
            }
            string filter;
            if (this.checkBox1.Checked)
                filter = "(spell_code LIKE '%" + _filter + "%') OR" + "(input_code LIKE '%" + _filter + "%') OR" + "(english_code LIKE '%" + _filter + "%') OR" + "(wb_code LIKE '%" + _filter + "%') OR" + "(item_name LIKE '%" + _filter + "%')";
            else
                filter = "(spell_code LIKE '" + _filter + "%') OR" + "(input_code LIKE '" + _filter + "%') OR" + "(english_code LIKE '" + _filter + "%') OR" + "(wb_code LIKE '" + _filter + "%') OR" + "(item_name LIKE '" + _filter + "%')";
            //			filter = "spell_code LIKE '%"+_filter+"%'";
            try
            {
                _dvItems.RowFilter = filter;
            }
            catch { }
            if (_dvItems.Count == 0)
                _CurrentRow = -1;
            else
                _CurrentRow = 0;

            AddItemsToSheet(_CurrentRow);
            fpSpread1_Sheet1.ActiveRowIndex = 0;
            fpSpread1_Sheet1.AddSelection(0, 0, 1, 1);
            DisplayCurrentRow(0);

            return 1;
        }
        /// <summary>
        /// 跳到下一行
        /// </summary>
        /// <returns></returns>
        public int NextRow()
        {
            int _Row = fpSpread1_Sheet1.ActiveRowIndex;
            if (_Row < 9)
            {
                _Row = _Row + 1;
                fpSpread1_Sheet1.ActiveRowIndex = _Row;
                fpSpread1_Sheet1.AddSelection(_Row, 0, 1, 1);
            }
            else
            {
                if (_CurrentRow >= _dvItems.Count - 10 || _dvItems.Count < 10) return 1;

                _CurrentRow++;
                AddItemsToSheet(_CurrentRow);
                fpSpread1_Sheet1.AddSelection(9, 0, 1, 1);
            }
            DisplayCurrentRow(fpSpread1_Sheet1.ActiveRowIndex);
            this.fpSelectionChanged();// {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
            return 1;
        }
        /// <summary>
        /// 跳到上一行
        /// </summary>
        /// <returns></returns>
        public int PriorRow()
        {
            int _Row = fpSpread1_Sheet1.ActiveRowIndex;
            if (_Row > 0)
            {
                _Row = _Row - 1;
                fpSpread1_Sheet1.ActiveRowIndex = _Row;
                fpSpread1_Sheet1.AddSelection(_Row, 0, 1, 1);
            }
            else
            {
                if (_CurrentRow == 0) return 1;

                _CurrentRow--;
                AddItemsToSheet(_CurrentRow);
                fpSpread1_Sheet1.AddSelection(0, 0, 1, 1);
            }
            DisplayCurrentRow(fpSpread1_Sheet1.ActiveRowIndex);
            this.fpSelectionChanged();// {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
            return 1;
        }
        /// <summary>
        /// 跳到下一页
        /// </summary>
        /// <returns></returns>
        public int NextPage()
        {
            if (_CurrentRow < _dvItems.Count - 10)
            {
                _CurrentRow = _CurrentRow + 10;

                AddItemsToSheet(_CurrentRow);
            }
            else if (_CurrentRow == _dvItems.Count - 10)
            {
                fpSpread1_Sheet1.ActiveRowIndex = 9;
                fpSpread1_Sheet1.AddSelection(9, 0, 1, 1);
            }
            DisplayCurrentRow(fpSpread1_Sheet1.ActiveRowIndex);
            this.fpSelectionChanged();// {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
            return 1;
        }
        /// <summary>
        /// 跳到上一页
        /// </summary>
        /// <returns></returns>
        public int PriorPage()
        {
            if (_CurrentRow >= 10)
            {
                _CurrentRow = _CurrentRow - 10;
                AddItemsToSheet(_CurrentRow);
            }
            else if (_CurrentRow > 0)
            {
                _CurrentRow = 0;
                AddItemsToSheet(_CurrentRow);
                fpSpread1_Sheet1.ActiveRowIndex = 0;
                fpSpread1_Sheet1.AddSelection(0, 0, 1, 1);
            }
            else if (_CurrentRow == 0)
            {
                fpSpread1_Sheet1.ActiveRowIndex = 0;
                fpSpread1_Sheet1.AddSelection(0, 0, 1, 1);
            }
            DisplayCurrentRow(fpSpread1_Sheet1.ActiveRowIndex);
            this.fpSelectionChanged();// {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
            return 1;
        }
        /// <summary>
        /// 修改检索方式
        /// </summary>
        /// <returns></returns>
        public int ChangeQueryType()
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml"))
                {
                    Neusoft.HISFC.Components.Common.Classes.Function.CreateFeeSetting();
                }
                _doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
                XmlNode _node = _doc.SelectSingleNode("//输入法");

                _InputType = int.Parse(_node.Attributes["currentmodel"].Value);
                _InputType++;
                if (_InputType > 4 || _InputType < 0) _InputType = 0;

                switch (_InputType)
                {
                    case 0://拼音
                        _dvItems.Sort = "spell_code ASC";
                        //						lbInput.Text="当前输入法为拼音码,F11切换输入法";
                        break;
                    case 1://五笔
                        _dvItems.Sort = "wb_code ASC";
                        //						lbInput.Text="当前输入法为五笔码,F11切换输入法";
                        break;
                    case 2://自定义
                        _dvItems.Sort = "input_code ASC";
                        //						lbInput.Text="当前输入法为自定义码,F11切换输入法";
                        break;
                    case 3://国标
                        _dvItems.Sort = "gb_code ASC";
                        //						lbInput.Text="当前输入法为国标码,F11切换输入法";
                        break;
                    case 4://英文
                        _dvItems.Sort = "english_code ASC";
                        //						lbInput.Text="当前输入法为英文码,F11切换输入法";
                        break;
                }
                lbInput.Text = "自定义码、拼音码、五笔码、英文码、项目名称";

                _node.Attributes["currentmodel"].Value = _InputType.ToString();
                _doc.Save(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");

                if (_dvItems.Count == 0)
                    _CurrentRow = -1;
                else
                    _CurrentRow = 0;

                AddItemsToSheet(_CurrentRow);
                fpSpread1_Sheet1.ActiveRowIndex = 0;
                fpSpread1_Sheet1.AddSelection(0, 0, 1, 1);
                DisplayCurrentRow(0);
            }
            catch (Exception error)
            {
                MessageBox.Show("切换输入法时出错!" + error.Message);
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 获取检索方式
        /// </summary>
        /// <returns></returns>
        private int GetQueryType()
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml"))
                {
                    Neusoft.HISFC.Components.Common.Classes.Function.CreateFeeSetting();
                }
                _doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
                XmlNode _node = _doc.SelectSingleNode("//输入法"); 
                _InputType = int.Parse(_node.Attributes["currentmodel"].Value);
                if (_InputType > 4 || _InputType < 0) _InputType = 0;

                switch (_InputType)
                {
                    case 0://拼音
                        _dvItems.Sort = "spell_code ASC";
                        //						lbInput.Text="当前输入法为拼音码,F11切换输入法";
                        break;
                    case 1://五笔
                        _dvItems.Sort = "wb_code ASC";
                        //						lbInput.Text="当前输入法为五笔码,F11切换输入法";
                        break;
                    case 2://自定义
                        _dvItems.Sort = "input_code ASC";
                        //						lbInput.Text="当前输入法为自定义码,F11切换输入法";
                        break;
                    case 3://国标
                        _dvItems.Sort = "gb_code ASC";
                        //						lbInput.Text="当前输入法为国标码,F11切换输入法";
                        break;
                    case 4://英文
                        _dvItems.Sort = "english_code ASC";
                        //						lbInput.Text="当前输入法为英文码,F11切换输入法";
                        break;
                }
                lbInput.Text = "自定义码、拼音码、五笔码、英文码、项目名称";
            }
            catch (Exception error)
            {
                MessageBox.Show("获取输入法时出错!" + error.Message);
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 获得当前选中的item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>-1:失败 0:没有 1:成功</returns>
        public int GetSelectItem(out Neusoft.HISFC.Models.Base.Item item)
        {
            Neusoft.HISFC.Models.Base.Item _item = null;
            _item = new Neusoft.HISFC.Models.Base.Item();
            if (_CurrentRow == -1)
            {
                item = _item;
                return 0;
            }
            int _Index = fpSpread1_Sheet1.ActiveRowIndex;
            string _ItemCode = fpSpread1_Sheet1.RowHeader.Rows[_Index].Tag.ToString();
            if (_ItemCode == string.Empty || _ItemCode == null)
            {
                item = _item;
                return 0;
            }
            //Isdrug: 1药品、2非药品、3组套、4复合项目、6物资
            string Isdrug = _ItemCode.Substring(0, 1);
            _ItemCode = _ItemCode.Substring(1);

            return GetSelectItem(_ItemCode,Isdrug,out item);
        }

        //{1E64A9A8-F0CC-449d-B16C-1C8B6D226839}
        /// <summary>
        /// 获得当前选中的item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="_ItemCode">项目编号</param>
        /// <param name="Isdrug">项目类别</param>
        /// <returns>-1:失败 0:没有 1:成功</returns>
        public int GetSelectItem(string _ItemCode,string Isdrug, out Neusoft.HISFC.Models.Base.Item item)
        {
            Neusoft.HISFC.Models.Base.Item _item = null;
            try
            {
                _item = new Neusoft.HISFC.Models.Base.Item();
                //Isdrug: 1药品、2非药品、3组套、4复合项目、6物资

                for (int i = 0; i < _alItems.Count; i++)
                {
                    Neusoft.FrameWork.Models.NeuObject obj = _alItems[i] as Neusoft.FrameWork.Models.NeuObject;
                    if (Isdrug == "1")//药品
                    {
                        if (obj.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item) &&
                            obj.ID == _ItemCode)
                        {
                            _item = (_alItems[i] as Neusoft.HISFC.Models.Base.Item).Clone();
                            //_item.IsPharmacy = true;
                            _item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.Drug;
                            item = _item;
                            return 1;
                        }
                    }
                    else if (Isdrug == "2")//非药品
                    {
                        if (obj.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug) &&
                            obj.ID == _ItemCode)
                        {
                            Neusoft.HISFC.Models.Fee.Item.Undrug undrugObj = (Neusoft.HISFC.Models.Fee.Item.Undrug)_alItems[i];

                            _item = (_alItems[i] as Neusoft.HISFC.Models.Base.Item).Clone();
                            //_item.IsPharmacy = false;
                            _item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
                            item = _item;
                            if (undrugObj.UnitFlag == "1")
                            {
                                item.User01 = "[复合项]"; ;
                            }
                            return 1;
                        }
                    }
                    else if (Isdrug == "3")//收费组套项目
                    {
                        if (obj.GetType() == typeof(Neusoft.HISFC.Models.Fee.ComGroup) &&
                            obj.ID == _ItemCode)
                        {
                            _item.ID = obj.ID;
                            _item.Name = obj.Name;
                            _item.User01 = "[组套]";
                            item = _item;
                            return 1;
                        }
                    }
                    //复合项目已经归并到非药品中 所以此处去掉
                    //else if (Isdrug == "4")//复合项目
                    //{
                    //    if (obj.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.UndrugComb) &&
                    //        obj.ID == _ItemCode)
                    //    {
                    //        _item.ID = obj.ID;
                    //        _item.Name = obj.Name;
                    //        _item.User01 = "[复合项]";
                    //        //_item.User02 = (obj as Neusoft.HISFC.Models.Fee.Undrugztinfo).;
                    //        item = _item;
                    //        return 1;
                    //    }
                    //}
                    else if (Isdrug == "5")//体检组套
                    {
                        //???????
                        if (obj.GetType() == typeof(Neusoft.HISFC.Models.PhysicalExamination.Group) &&
                            obj.ID == _ItemCode)
                        {
                            _item.ID = obj.ID;
                            _item.Name = obj.Name;
                            _item.User01 = "[组套]";
                            // _item.User02 = (obj as Neusoft.HISFC.Models.Fee.Item.Undrug).deptCode;
                            item = _item;
                            return 1;
                        }
                    }
                    else if (Isdrug == "6") //物资
                    {
                        if (obj.GetType() == typeof(Neusoft.HISFC.Models.FeeStuff.MaterialItem))
                        {
                            if (obj.ID == _ItemCode)
                            {
                                _item = (_alItems[i] as Neusoft.HISFC.Models.Base.Item).Clone();
                                _item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.MatItem;
                                item = _item;
                                item.Price = (obj as Neusoft.HISFC.Models.FeeStuff.MaterialItem).Price;
                                return 1;
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("获取项目信息时出错!" + error.Message);
                item = new Neusoft.HISFC.Models.Base.Item();
                return -1;
            }

            item = new Neusoft.HISFC.Models.Base.Item();
            return -1;
        }


        /// <summary>
        /// 设置项目显示风格
        /// </summary>
        /// <returns></returns>
        private int SetStyle(string strFileName, string strElement, FarPoint.Win.Spread.SheetView svControl)
        {
            //XmlDocument _xmlDoc = new XmlDocument();
            //int _intCount = 0;
            //try
            //{
            //    _xmlDoc.Load(strFileName);

            //    XmlNodeList _xmlNodes = _xmlDoc.SelectNodes(strElement);
            //    foreach (XmlNode node in _xmlNodes)
            //    {
            //        svControl.AddColumns(_intCount, 1);
            //        FarPoint.Win.Spread.Column _column = svControl.Columns[_intCount];
            //        _column.Width = int.Parse(node.Attributes["width"].Value);
            //        _column.Visible = bool.Parse(node.Attributes["visible"].Value);
            //        _column.Locked = true;//bool.Parse(node.Attributes["locked"].Value);
            //        _column.Tag = node.Attributes["tag"].Value;
            //        string _displayName = node.Attributes["displayname"].Value;
            //        if (_displayName != string.Empty)
            //        {
            //            _column.Label = _displayName;
            //        }
            //        else { _column.Label = "未定义名称"; }
            //        _intCount++;
            //    }
            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show("加载项目列表的配置文件时出错!" + error.Message);
            //    return -1;
            //}
            //if (_intCount == 0)
            //{
            //    MessageBox.Show("加载项目列表的配置文件时出错,文件未定义列!");
            //    return -1;
            //}
            //svControl.ColumnCount = _intCount;

            svControl.ColumnCount = 20;
            svControl.Columns[(int)Cols.input_code].Visible = true; //输入码0
            svControl.Columns[(int)Cols.spell_code].Visible = false;//拼音码1
            svControl.Columns[(int)Cols.wb_code].Visible = false;//五笔码2
            svControl.Columns[(int)Cols.item_code].Visible = false;//项目代码3
            svControl.Columns[(int)Cols.item_name].Visible = true;//项目名称4
            svControl.Columns[(int)Cols.specs].Visible = true;//规格5
            svControl.Columns[(int)Cols.price].Visible = true;//价格6
            svControl.Columns[(int)Cols.unit].Visible = true;//单位7
            svControl.Columns[(int)Cols.producer].Visible = false;//生产厂家8
            svControl.Columns[(int)Cols.memo].Visible = false;//备注9
            svControl.Columns[(int)Cols.grade].Visible = true;//医保级别10
            svControl.Columns[(int)Cols.isdrug].Visible = false;//1药，2非药11
            svControl.Columns[(int)Cols.gb_code].Visible = false;//国标码12
            svControl.Columns[(int)Cols.freq_name].Visible = false;//频次名称13
            svControl.Columns[(int)Cols.usage_name].Visible = false;//用法名称14
            svControl.Columns[(int)Cols.class_code].Visible = false;//系统类别15
            svControl.Columns[(int)Cols.english_code].Visible = false;//英文16
            svControl.Columns[(int)Cols.pub_grade].Visible = true;//公费标志17
            svControl.Columns[(int)Cols.child_price].Visible = true;//儿童价格18
            svControl.Columns[(int)Cols.special_price].Visible = true;//特诊价格19

            svControl.Columns[(int)Cols.input_code].Label = "输入码";
            svControl.Columns[(int)Cols.spell_code].Label ="拼音码";
            svControl.Columns[(int)Cols.wb_code].Label ="五笔码";
            svControl.Columns[(int)Cols.item_code].Label ="项目代码";
            svControl.Columns[(int)Cols.item_name].Label ="项目名称";
            svControl.Columns[(int)Cols.specs].Label =" 规格";
            svControl.Columns[(int)Cols.price].Label ="价格";
            svControl.Columns[(int)Cols.unit].Label ="单位";
            svControl.Columns[(int)Cols.producer].Label ="厂家";
            svControl.Columns[(int)Cols.memo].Label ="备注";
            svControl.Columns[(int)Cols.grade].Label ="医保级别";
            svControl.Columns[(int)Cols.isdrug].Label ="项目";
            svControl.Columns[(int)Cols.gb_code].Label ="国标码";
            svControl.Columns[(int)Cols.freq_name].Label ="频次";
            svControl.Columns[(int)Cols.usage_name].Label ="用法";
            svControl.Columns[(int)Cols.class_code].Label ="系统类别";
            svControl.Columns[(int)Cols.english_code].Label ="英文";
            svControl.Columns[(int)Cols.pub_grade].Label ="公费标志";
            svControl.Columns[(int)Cols.child_price].Label ="儿童价";
            svControl.Columns[(int)Cols.special_price].Label ="特诊价";

            svControl.Columns[(int)Cols.input_code].Tag = "input_code";
            svControl.Columns[(int)Cols.spell_code].Tag = "spell_code";
            svControl.Columns[(int)Cols.wb_code].Tag = "wb_code";
            svControl.Columns[(int)Cols.item_code].Tag = "item_code";
            svControl.Columns[(int)Cols.item_name].Tag = "item_name";
            svControl.Columns[(int)Cols.specs].Tag = "specs";
            svControl.Columns[(int)Cols.price].Tag = "price";
            svControl.Columns[(int)Cols.unit].Tag = "unit";
            svControl.Columns[(int)Cols.producer].Tag = "producer";
            svControl.Columns[(int)Cols.memo].Tag = "memo";
            svControl.Columns[(int)Cols.grade].Tag = "grade";
            svControl.Columns[(int)Cols.isdrug].Tag = "isdrug";
            svControl.Columns[(int)Cols.gb_code].Tag = "gb_code";
            svControl.Columns[(int)Cols.freq_name].Tag = "freq_name";
            svControl.Columns[(int)Cols.usage_name].Tag = "usage_name";
            svControl.Columns[(int)Cols.class_code].Tag = "class_code";
            svControl.Columns[(int)Cols.english_code].Tag = "english_code";
            svControl.Columns[(int)Cols.pub_grade].Tag = "pub_grade";
            svControl.Columns[(int)Cols.child_price].Tag = "child_price";
            svControl.Columns[(int)Cols.special_price].Tag = "special_price";

            svControl.Columns[(int)Cols.input_code].Width = 60; 
            svControl.Columns[(int)Cols.item_name].Width = 200;
            svControl.Columns[(int)Cols.price].Width = 60;
            svControl.Columns[(int)Cols.unit].Width = 40;
            svControl.Columns[(int)Cols.grade].Width = 40;
            svControl.Columns[(int)Cols.pub_grade].Width = 30;
            svControl.Columns[(int)Cols.child_price].Width = 60;
            svControl.Columns[(int)Cols.special_price].Width = 60;
            svControl.Columns[(int)Cols.specs].Width = 100;
            InputMap im;

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.PageUp, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.PageDown, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            return 1;
        }

        /// <summary>
        /// 显示当前行和总行数
        /// </summary>
        /// <returns></returns>
        private int DisplayCurrentRow(int SheetRow)
        {
            int row = _CurrentRow + SheetRow + 1;
            if (_dvItems.Count < 10)
                lbCount.Text = "当前行:" + row.ToString() + "/共:" + fpSpread1_Sheet1.RowCount.ToString();
            else
                lbCount.Text = "当前行:" + row.ToString() + "/共:" + _dvItems.Count.ToString();
            return 1;
        }
        /// <summary>
        /// 设置Sheet当前行
        /// </summary>
        /// <param name="Row"></param>
        /// <returns></returns>
        public int SetCurrentRow(int Row)
        {
            if (Row < 0 || Row > 9) return -1;
            fpSpread1_Sheet1.ActiveRowIndex = Row;
            fpSpread1_Sheet1.AddSelection(Row, 0, 1, 1);
            return 1;
        }

        #endregion

        #region 事件
        //触发selectitem事件
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (SelectItem != null)
            {
                this.SelectItem(Keys.Enter);
            }
        }

        //当焦点在fpspread1_Sheet1上，处理enter事件
        private void fpSpread1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2
                || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5
                || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8
                || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10)
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        fpSpread1_Sheet1.ActiveRowIndex = 0;
                        break;
                    case Keys.F2:
                        fpSpread1_Sheet1.ActiveRowIndex = 1;
                        break;
                    case Keys.F3:
                        fpSpread1_Sheet1.ActiveRowIndex = 2;
                        break;
                    case Keys.F4:
                        fpSpread1_Sheet1.ActiveRowIndex = 3;
                        break;
                    case Keys.F5:
                        fpSpread1_Sheet1.ActiveRowIndex = 4;
                        break;
                    case Keys.F6:
                        fpSpread1_Sheet1.ActiveRowIndex = 5;
                        break;
                    case Keys.F7:
                        fpSpread1_Sheet1.ActiveRowIndex = 6;
                        break;
                    case Keys.F8:
                        fpSpread1_Sheet1.ActiveRowIndex = 7;
                        break;
                    case Keys.F9:
                        fpSpread1_Sheet1.ActiveRowIndex = 8;
                        break;
                    case Keys.F10:
                        fpSpread1_Sheet1.ActiveRowIndex = 9;
                        break;
                }

                fpSpread1_Sheet1.AddSelection(fpSpread1_Sheet1.ActiveRowIndex, 0, 1, 1);

                if (SelectItem != null)
                {
                    this.SelectItem(e.KeyCode);
                }
            }
        }
        //处理up,down,pageup,pagedown事件
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (fpSpread1.ContainsFocus)
            {
                switch (keyData)
                {
                    case Keys.Up:
                        this.PriorRow();
                        break;
                    case Keys.Down:
                        this.NextRow();
                        break;
                    case Keys.PageUp:
                        this.PriorPage();
                        break;
                    case Keys.PageDown:
                        this.NextPage();
                        break;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 单击行时，变化当前行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Row > 0)
            {
                DisplayCurrentRow(e.Row);
            }           
            if(e.Row == 0)
            {
                fpSpread1_Sheet1.ActiveRowIndex = 0;
                fpSpread1_Sheet1.AddSelection(0, 0, 1, 1);
                DisplayCurrentRow(0);
            }

            //{CC5C1FD9-DAC4-4459-AB71-CA9AE16A9B3C} 2010.11.29 hzl add:单击时显示扩展信息
            int CurrentRow = e.Row;
            if (CurrentRow >= 0)
            {
                fpSpread1_Sheet1.ActiveRowIndex = CurrentRow;
                fpSpread1_Sheet1.AddSelection(CurrentRow, 0, 1, 1);
                this.fpSelectionChanged();
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            this.Filter(this._Text);
        }
        #endregion

        #region IInterfaceContainer 成员
        //{112B7DB5-0462-4432-AD9D-17A7912FFDBE} 增加接口容器
        public Type[] InterfaceTypes
        {
            get
            {
                return new Type[] { typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade) };
            }
        }

        #endregion

        #region {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}

        /// <summary>
        /// 添加详细列表
        /// </summary>
        /// <param name="c"></param>
        public void AddBottomControl(Control c)
        {
            if (c.GetType().IsSubclassOf(typeof(FarPoint.Win.Spread.FpSpread)))
            {
                //sheeViewDetail = c as FarPoint.Win.Spread.FpSpread;
                //sheeViewDetail.Sheets[0].GrayAreaBackColor = pnlBottom.BackColor;
                //sheeViewDetail.Sheets[0].DefaultStyle.BackColor = pnlBottom.BackColor;
                //sheeViewDetail.Sheets[0].RowHeader.DefaultStyle.BackColor = pnlBottom.BackColor;
                //this.statusbarText.Text = "下面显示复合项目对应的收费项目供医生参考";
            }
            else
            {
                //this.statusbarText.Text = "下面显示的扩展信息供医生参考";
            }

            c.Visible = true;
            this.pnlBottom.Controls.Add(c);
            c.Dock = DockStyle.Fill;
            txt.Multiline = true;
            txt.ReadOnly = true;
            txt.Multiline = true;
            txt.Visible = true;
            txt.ScrollBars = ScrollBars.Both;
        }

        public bool IsTxtHorizone = false;

        private void fpSelectionChanged()
        {
            if (this.fpSpread1.Sheets[0].RowCount <= 0)
            {
                //this.fpItemDetal.Sheets[0].Rows.Count = 0;
                this.txt.Text = "";
                this.pnlBottom.Visible = false;
                this.SetAutoSize();
                return;
            }

            #region  注释
            Neusoft.HISFC.BizLogic.Pharmacy.Item phaManger = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            Neusoft.HISFC.Models.Pharmacy.Item itm;

            string itemid = fpSpread1.Sheets[0].Cells[fpSpread1.Sheets[0].ActiveRowIndex, 3].Text;

            itm = phaManger.GetItem(itemid);

            if (itm != null && itm.ID != "")
            {
                string itmExtendInfo = "";
                ArrayList alExtendInfo = new ArrayList();
                if (this.IItemExtendInfo != null)
                {
                    IItemExtendInfo.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.Drug;
                    if (patient != null)
                    {
                        IItemExtendInfo.PactInfo = patient.Pact;
                    }
                    int iRtn = IItemExtendInfo.GetItemExtendInfo(itemid, ref itmExtendInfo, ref alExtendInfo);
                    if (string.IsNullOrEmpty(itmExtendInfo))
                    {
                        this.txt.Text = "";
                        this.pnlBottom.Visible = false;
                    }
                    else
                    {
                        this.pnlBottom.Visible = true;

                        #region {7AF39AE0-1FD6-4e2d-B457-71D8C0EB5907}

                        if (IsTxtHorizone)
                        {
                            txt.Text = itmExtendInfo.Replace("\r\n","  ");
                        }
                        else 
                        {
                            txt.Text = itmExtendInfo;
                        }

                        #endregion
                    }
                }
                else
                {
                    this.txt.Text = "";
                    this.pnlBottom.Visible = false;
                }
            }
            else
            {
                Neusoft.HISFC.BizProcess.Integrate.Fee itemMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
                Neusoft.HISFC.Models.Fee.Item.Undrug itemtmp = itemMgr.GetItem(itemid);
                string itmExtendInfo = "";
                ArrayList al = new ArrayList();
                if (itemtmp != null )
                {
                    if (this.IItemExtendInfo != null)
                    {
                        IItemExtendInfo.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
                        if (patient != null)
                        {
                            IItemExtendInfo.PactInfo = patient.Pact;
                        }
                        int iRtn = IItemExtendInfo.GetItemExtendInfo(itemid, ref itmExtendInfo, ref al);
                        if (string.IsNullOrEmpty(itmExtendInfo))
                        {
                            this.txt.Text = "";
                            this.pnlBottom.Visible = false;
                        }
                        else
                        {
                            this.pnlBottom.Visible = true;
                            txt.Text = itmExtendInfo;
                        }
                    }
                    else
                    {
                        this.pnlBottom.Visible = false;
                        this.txt.Text = "";
                    }
                }
            }
            this.SetAutoSize();

            #endregion
        }

        #endregion
    }
}
