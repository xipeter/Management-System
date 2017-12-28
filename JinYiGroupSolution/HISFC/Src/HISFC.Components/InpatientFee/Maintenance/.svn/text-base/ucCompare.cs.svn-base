using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Models;
using System.Collections;

using Neusoft.HISFC.Models.SIInterface;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    public partial class ucCompare : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCompare()
        {
            InitializeComponent();
        }

        #region 枚举
        public enum CompareTypes
        {
            /// <summary>
            /// 西药
            /// </summary>
            P = 0,
            /// <summary>
            /// 中草药
            /// </summary>
            C = 1,
            /// <summary>
            /// 中成药
            /// </summary>
            Z = 2,
            //{B36F2A99-872C-4659-9035-6D80B5489F50} 同sql语句对应 wbo 2010-08-28
            ///// <summary>
            ///// 全部药品
            ///// </summary>
            //All = 3,
            /// <summary>
            /// 全部药品
            /// </summary>
            ALL = 3,
            /// <summary>
            /// 非药品
            /// </summary>
            Undrug = 4,
        };
        #endregion

        #region 变量
        ArrayList alDrug = new ArrayList();//药品列表
        private NeuObject pactCode = new NeuObject();//合同单位
        private bool isDrug = false;
        private string code = "PY"; //查询码
        private int circle = 0;
        DataTable dtHisItem = new DataTable();
        DataTable dtCenterItem = new DataTable();
        DataTable dtCompareItem = new DataTable();
        DataView dvHisItem = new DataView();
        DataView dvCenterItem = new DataView();
        DataView dvCompareItem = new DataView();
        private CompareTypes compareType;
        protected Neusoft.HISFC.BizLogic.Fee.ConnectSI myConnectSI = null;
        /// <summary>
        /// Tab
        /// </summary>
        protected Hashtable hashTableFp = new Hashtable();
        protected Neusoft.HISFC.BizLogic.Fee.Interface myInterface = new Neusoft.HISFC.BizLogic.Fee.Interface();
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion

        #region 属性
        [Category("设置"), Description("设置项目类型 P:西药；C:中草药；Z:中成药；ALL:全部药品；Undrug:非药品")]
        public CompareTypes CompareType
        {
            get
            {
                return compareType;
            }
            set
            {
                compareType = value;
            }
        }

        /// <summary>
        /// 合同单位信息
        /// </summary>
        public NeuObject PactCode
        {
            set
            {
                pactCode = value;
            }
            get
            {
                return pactCode;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 初始化显示数据
        /// </summary>
        public void Init()
        {
            if (CompareType.ToString() != CompareTypes.Undrug.ToString())
            {
                isDrug = true;
            }
            else
            {
                isDrug = false;
            }

            InitColumn();

            InitData();

            InitColumnProHis();

            InitColumnProCenter();

            InitColumnProCompare();

            InitHashTable();
        }
        /// <summary>
        /// 连接医保服务器
        /// </summary>
        /// <returns></returns>
        public int ConnectSIServer()
        {
            try
            {
                myConnectSI = new Neusoft.HISFC.BizLogic.Fee.ConnectSI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接医保服务器失败!,请重新配置连接" + ex.Message);
                return -1;
            }
            return 0;
        }

        private void InitHashTable()
        {
            foreach (TabPage t in this.tabCompare.TabPages)
            {
                foreach (Control c in t.Controls)
                {
                    if (c is FarPoint.Win.Spread.FpSpread)
                    {
                        this.hashTableFp.Add(t, c);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("对照", "对照", Neusoft.FrameWork.WinForms.Classes.EnumImageList.H合并, true, false, null);
            this.toolBarService.AddToolButton("取消", "取消", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);
            this.toolBarService.AddToolButton("清空", "清空", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 获得药品基本信息
        /// </summary>
        public void GetHisDrugItem()
        {
            alDrug = myInterface.GetNoCompareDrugItem(pactCode.ID, compareType.ToString());
        }
        /// <summary>
        /// 设置显示列信息;
        /// </summary>
        private void InitColumn()
        {

            Type str = typeof(System.String);
            Type dec = typeof(System.Decimal);
            Type date = typeof(System.DateTime);



            if (compareType.ToString() !=CompareTypes.Undrug.ToString())
            {
                //初始化本地项目:
                DataColumn[] colHisItem = new DataColumn[]{new DataColumn("药品编码", str),
                                                              new DataColumn("药品名称", str),
                                                              new DataColumn("拼音码", str),
                                                              new DataColumn("五笔码", str),
                                                              new DataColumn("自定义码", str),
                                                              new DataColumn("规格", str),
                                                              new DataColumn("通用名", str),
                                                              new DataColumn("通用名拼音", str),
                                                              new DataColumn("通用名五笔", str),
                                                              new DataColumn("国际编码", str),
                                                              new DataColumn("国家编码", str),
                                                              new DataColumn("价格", str),
                                                              new DataColumn("剂型编码", str),
                                                              //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
                                                              new DataColumn("药品类别", str)};

                dtHisItem.Columns.AddRange(colHisItem);

                DataColumn[] keyHis = new DataColumn[1];
                keyHis[0] = dtHisItem.Columns[0];
                dtHisItem.CaseSensitive = true;
                dtHisItem.PrimaryKey = keyHis;
                dvHisItem = new DataView(dtHisItem);
                dvHisItem.Sort = "药品编码 ASC";
                fpHisItem_Sheet1.DataSource = dvHisItem;

                DataColumn[] colCenterItem = new DataColumn[]{new DataColumn("中心编码", str),
                                                                 new DataColumn("中心项目名称", str),
                                                                 new DataColumn("中心项目英文名", str),
                                                                 new DataColumn("规格", str),
                                                                 new DataColumn("剂型", str),
                                                                 new DataColumn("中心拼音码", str),
                                                                 new DataColumn("费用分类", str),
                                                                 new DataColumn("目录级别", str),
                                                                 new DataColumn("目录等级", str),
                                                                 new DataColumn("自负比例", dec),
                                                                 new DataColumn("基准价格", dec),
                                                                 new DataColumn("限制使用说明", str),
                                                                 new DataColumn("项目类别", str)};
                dtCenterItem.Columns.AddRange(colCenterItem);
                DataColumn[] keyCenter = new DataColumn[1];
                keyCenter[0] = dtCenterItem.Columns[0];
                dtCenterItem.CaseSensitive = true;
                dtCenterItem.PrimaryKey = keyCenter;
                dvCenterItem = new DataView(dtCenterItem);
                dvCenterItem.Sort = "中心编码 ASC";
                fpCenterItem_Sheet1.DataSource = dvCenterItem;
            }
            else 
            {
                //初始化本地项目:
                DataColumn[] colHisItem = new DataColumn[]{new DataColumn("非药品编码", str),
                                                              new DataColumn("非药品名称", str),
                                                              new DataColumn("拼音码", str),
                                                              new DataColumn("五笔码", str),
                                                              new DataColumn("自定义码", str),
                                                              new DataColumn("规格", str),
                                                              new DataColumn("国际编码", str),
                                                              new DataColumn("国家编码", str),
                                                              new DataColumn("价格", str),
                                                              new DataColumn("单位", str)};

                dtHisItem.Columns.AddRange(colHisItem);

                DataColumn[] keyHis = new DataColumn[1];
                keyHis[0] = dtHisItem.Columns[0];
                dtHisItem.PrimaryKey = keyHis;
                dvHisItem = new DataView(dtHisItem);
                dvHisItem.Sort = "非药品编码 ASC";
                fpHisItem_Sheet1.DataSource = dvHisItem;

                DataColumn[] colCenterItem = new DataColumn[]{new DataColumn("中心编码", str),
                                                                 new DataColumn("中心项目名称", str),
                                                                 new DataColumn("中心项目英文名", str),
                                                                 new DataColumn("规格", str),
                                                                 new DataColumn("剂型", str),
                                                                 new DataColumn("中心拼音码", str),
                                                                 new DataColumn("费用分类", str),
                                                                 new DataColumn("目录级别", str),
                                                                 new DataColumn("目录等级", str),
                                                                 new DataColumn("自负比例", dec),
                                                                 new DataColumn("基准价格", dec),
                                                                 new DataColumn("限制使用说明", str),
                                                                 new DataColumn("项目类别", str)};
                dtCenterItem.Columns.AddRange(colCenterItem);
                DataColumn[] keyCenter = new DataColumn[1];
                keyCenter[0] = dtCenterItem.Columns[0];
                dtCenterItem.CaseSensitive=true;
                dtCenterItem.PrimaryKey = keyCenter;
                dvCenterItem = new DataView(dtCenterItem);
                dvCenterItem.Sort = "中心编码 ASC";
                fpCenterItem_Sheet1.DataSource = dvCenterItem;
            }

            DataColumn[] colCompareItem = new DataColumn[]{ 
                                                            new DataColumn("医院自定义码", str),
                                                            new DataColumn("本地项目编码", str),
                                                            new DataColumn("中心编码", str),
                                                            new DataColumn("项目类别", str),
                                                            new DataColumn("医保收费项目中文名称", str),
                                                            new DataColumn("本地项目名称", str),
                                                            new DataColumn("本地项目别名", str),
                                                            new DataColumn("医保收费项目英文名称", str),
                                                            new DataColumn("医保剂型", str),
                                                            new DataColumn("医保规格",str),
                                                            new DataColumn("医保拼音代码", str),
                                                            new DataColumn("医保费用分类代码", str),
                                                            new DataColumn("医保目录级别", str),
                                                            new DataColumn("医保目录等级", str),
                                                            new DataColumn("自负比例", dec),
                                                            new DataColumn("基准价格", dec),
                                                            new DataColumn("限制使用说明", str),
                                                            new DataColumn("医院拼音", str),
                                                            new DataColumn("医院五笔码", str),
                                                            new DataColumn("医院规格", str),
                                                            new DataColumn("医院基本价格", dec),
                                                            new DataColumn("医院剂型", str),
                                                            new DataColumn("操作员", str),
                                                            new DataColumn("操作时间", date),
                                                            //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
                                                            new DataColumn("医院项目类别", str)};
            dtCompareItem.Columns.AddRange(colCompareItem);
            DataColumn[] keyCompare = new DataColumn[1];
            keyCompare[0] = dtCompareItem.Columns[1];
            dtCompareItem.CaseSensitive=true;
            dtCompareItem.PrimaryKey = keyCompare;
            dvCompareItem = new DataView(dtCompareItem);
            dvCompareItem.Sort = "医院自定义码 ASC";
            fpCompareItem_Sheet1.DataSource = dvCompareItem;
            
        }
        /// <summary>
        /// HIS本地项目列属性
        /// </summary>
        private void InitColumnProHis()
        {
            int width = 20;

            if (compareType.ToString()!=CompareTypes.Undrug.ToString())
            {
                //this.fpHisItem_Sheet1.Columns[0].Visible = false;
                this.fpHisItem_Sheet1.Columns[0].Visible = true;
                this.fpHisItem_Sheet1.Columns[1].Width = width * 8;
                this.fpHisItem_Sheet1.Columns[2].Visible = false;
                this.fpHisItem_Sheet1.Columns[3].Visible = false;
                this.fpHisItem_Sheet1.Columns[4].Visible = true;
                this.fpHisItem_Sheet1.Columns[5].Width = width * 8;
                this.fpHisItem_Sheet1.Columns[6].Width = width * 8;
                this.fpHisItem_Sheet1.Columns[7].Visible = false;
                this.fpHisItem_Sheet1.Columns[8].Visible = false;
                this.fpHisItem_Sheet1.Columns[9].Visible = false;
                this.fpHisItem_Sheet1.Columns[10].Visible = false;
                this.fpHisItem_Sheet1.Columns[11].Width = width * 3;
                this.fpHisItem_Sheet1.Columns[12].Width = width * 4;
            }
            else
            {
                //this.fpHisItem_Sheet1.Columns[0].Visible = false;
                this.fpHisItem_Sheet1.Columns[0].Visible = true;
                this.fpHisItem_Sheet1.Columns[1].Width = width * 8;
                this.fpHisItem_Sheet1.Columns[2].Visible = false;
                this.fpHisItem_Sheet1.Columns[3].Visible = false;
                this.fpHisItem_Sheet1.Columns[4].Visible = true;
                this.fpHisItem_Sheet1.Columns[5].Width = width * 8;
                this.fpHisItem_Sheet1.Columns[6].Visible = false;
                this.fpHisItem_Sheet1.Columns[7].Visible = false;
                this.fpHisItem_Sheet1.Columns[8].Width = width * 3;
                this.fpHisItem_Sheet1.Columns[9].Width = width * 4;
            }
        }
        /// <summary>
        /// 初始化中心列属性信息
        /// </summary>
        private void InitColumnProCenter()
        {
            int width = 20;
            this.fpCenterItem_Sheet1.Columns[0].Visible = true;
            this.fpCenterItem_Sheet1.Columns[1].Width = width * 8;
            this.fpCenterItem_Sheet1.Columns[2].Width = width * 8;
            this.fpCenterItem_Sheet1.Columns[3].Width = width * 8;
            this.fpCenterItem_Sheet1.Columns[4].Width = width * 3;
            this.fpCenterItem_Sheet1.Columns[5].Visible = false;
            this.fpCenterItem_Sheet1.Columns[6].Visible = false;
            this.fpCenterItem_Sheet1.Columns[7].Visible = false;
            this.fpCenterItem_Sheet1.Columns[8].Width = width * 3;
            this.fpCenterItem_Sheet1.Columns[9].Width = width * 4;
            this.fpCenterItem_Sheet1.Columns[10].Width = width * 3;
            this.fpCenterItem_Sheet1.Columns[11].Width = width * 8;
        }
        private void InitColumnProCompare()
        {
            int width = 20;

            FarPoint.Win.Spread.CellType.DateTimeCellType dtType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            dtType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;

            fpCompareItem_Sheet1.Columns[0].Visible = true;
            fpCompareItem_Sheet1.Columns[1].Visible = true;
            fpCompareItem_Sheet1.Columns[2].Visible = true;
            fpCompareItem_Sheet1.Columns[3].Width = width * 8;
            fpCompareItem_Sheet1.Columns[4].Width = width * 8;
            fpCompareItem_Sheet1.Columns[5].Width = width * 8;
            fpCompareItem_Sheet1.Columns[6].Visible = true;
            fpCompareItem_Sheet1.Columns[7].Visible = false;
            fpCompareItem_Sheet1.Columns[8].Visible = false;
            fpCompareItem_Sheet1.Columns[9].Visible = false;
            fpCompareItem_Sheet1.Columns[10].Width = width * 4;
            fpCompareItem_Sheet1.Columns[11].Visible = true;
            fpCompareItem_Sheet1.Columns[12].Width = width * 4;
            fpCompareItem_Sheet1.Columns[13].Width = width * 4;
            fpCompareItem_Sheet1.Columns[14].Width = width * 4;
            fpCompareItem_Sheet1.Columns[15].Width = width * 6;
            fpCompareItem_Sheet1.Columns[16].Visible = false;
            fpCompareItem_Sheet1.Columns[17].Visible = false;
            fpCompareItem_Sheet1.Columns[18].Visible = false;
            fpCompareItem_Sheet1.Columns[19].Width = width * 8;
            fpCompareItem_Sheet1.Columns[20].Width = width * 4;
            fpCompareItem_Sheet1.Columns[21].Width = width * 4;
            fpCompareItem_Sheet1.Columns[22].Width = width * 4;
            fpCompareItem_Sheet1.Columns[23].Width = width * 6;
            fpCompareItem_Sheet1.Columns[23].CellType = dtType;


        }
        /// <summary>
        /// 初始化显示数据
        /// </summary>
        public void InitData()
        {
            ArrayList alHisItem = new ArrayList();
            ArrayList alCenterItem = new ArrayList();
            ArrayList alCompareItem = new ArrayList();

            if (isDrug)
            {
                #region 加载药品
                alHisItem = this.myInterface.GetNoCompareDrugItem(pactCode.ID, compareType.ToString());
                if (alHisItem != null)
                {
                    foreach (Neusoft.HISFC.Models.Pharmacy.Item obj in alHisItem)
                    {
                        DataRow row = dtHisItem.NewRow();
                        row["药品编码"] = obj.ID;
                        row["药品名称"] = obj.Name;
                        row["拼音码"] = obj.SpellCode;
                        row["五笔码"] = obj.WBCode;
                        row["自定义码"] = obj.UserCode;
                        row["规格"] = obj.Specs;
                        row["国际编码"] = obj.NationCode;
                        row["国家编码"] = obj.GBCode;
                        row["价格"] = obj.PriceCollection.RetailPrice;// .RetailPrice;
                        row["剂型编码"] = obj.DosageForm.ID;
                        //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
                        row["药品类别"] = (obj.Type.ID == "P") ? "X" : "Z";

                        dtHisItem.Rows.Add(row);
                    }
                }
                //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
                //if (compareType.ToString() == "ALL")
                //    alCenterItem = this.myInterface.GetCenterItem(pactCode.ID);
                //else
                alCenterItem = this.myInterface.GetCenterItem(pactCode.ID, compareType.ToString());

                if (alCenterItem != null)
                {
                    foreach (Neusoft.HISFC.Models.SIInterface.Item obj in alCenterItem)
                    {
                        DataRow row = dtCenterItem.NewRow();
                        row["中心编码"] = obj.ID;
                        row["中心项目名称"] = obj.Name;
                        row["中心项目英文名"] = obj.EnglishName;
                        row["规格"] = obj.Specs;
                        row["剂型"] = obj.DoseCode;
                        row["中心拼音码"] = obj.SpellCode;
                        row["费用分类"] = obj.FeeCode;
                        row["目录级别"] = obj.ItemType;
                        row["目录等级"] = obj.ItemGrade;
                        row["自负比例"] = obj.Rate;
                        row["基准价格"] = obj.Price;
                        row["限制使用说明"] = obj.Memo;
                        row["项目类别"] = obj.SysClass;
                        dtCenterItem.Rows.Add(row);
                    }
                }

                alCompareItem = this.myInterface.GetCompareItem(pactCode.ID, compareType.ToString());

                if (alCompareItem != null)
                {
                    foreach (Neusoft.HISFC.Models.SIInterface.Compare obj in alCompareItem)
                    {
                        DataRow row = dtCompareItem.NewRow();

                        row["本地项目编码"] = obj.HisCode;
                        row["中心编码"] = obj.CenterItem.ID;
                        row["项目类别"] = obj.CenterItem.SysClass;
                        row["医保收费项目中文名称"] = obj.CenterItem.Name;
                        row["医保收费项目英文名称"] = obj.CenterItem.EnglishName;
                        row["本地项目名称"] = obj.Name;
                        row["本地项目别名"] = obj.RegularName;
                        row["医保剂型"] = obj.CenterItem.DoseCode;
                        row["医保拼音代码"] = obj.CenterItem.SpellCode;
                        row["医保费用分类代码"] = obj.CenterItem.FeeCode;
                        row["医保目录级别"] = obj.CenterItem.ItemType;
                        row["医保目录等级"] = obj.CenterItem.ItemGrade;
                        row["自负比例"] = obj.CenterItem.Rate;
                        row["基准价格"] = obj.CenterItem.Price;
                        row["限制使用说明"] = obj.CenterItem.Memo;
                        row["医院拼音"] = obj.SpellCode.SpellCode;
                        row["医院五笔码"] = obj.SpellCode.WBCode;
                        row["医院自定义码"] = obj.SpellCode.UserCode;
                        row["医院规格"] = obj.Specs;
                        row["医院基本价格"] = obj.Price;
                        row["医院剂型"] = obj.DoseCode;
                        row["操作员"] = obj.CenterItem.OperCode;
                        row["操作时间"] = obj.CenterItem.OperDate;

                        dtCompareItem.Rows.Add(row);
                    }
                }
                #endregion
            }
            else
            {
                #region 加载非药品
                alHisItem = myInterface.GetNoCompareUndrugItem(pactCode.ID);
                if (alHisItem != null)
                {
                    foreach (Neusoft.HISFC.Models.Fee.Item.Undrug obj in alHisItem)
                    {
                        DataRow row = dtHisItem.NewRow();
                        row["非药品编码"] = obj.ID;
                        row["非药品名称"] = obj.Name;
                        row["拼音码"] = obj.SpellCode;
                        row["五笔码"] = obj.WBCode;
                        row["自定义码"] = obj.UserCode;
                        row["规格"] = obj.Specs;
                        row["国际编码"] = obj.NationCode;
                        row["国家编码"] = obj.GBCode;
                        row["价格"] = obj.Price;
                        row["单位"] = obj.PriceUnit;
                        dtHisItem.Rows.Add(row);
                    }
                }

                alCenterItem = this.myInterface.GetCenterItem(pactCode.ID, compareType.ToString());
                if (alCenterItem != null)
                {
                    foreach (Neusoft.HISFC.Models.SIInterface.Item obj in alCenterItem)
                    {
                        DataRow row = dtCenterItem.NewRow();
                        row["中心编码"] = obj.ID;
                        row["中心项目名称"] = obj.Name;
                        row["中心项目英文名"] = obj.EnglishName;
                        row["规格"] = obj.Specs;
                        row["剂型"] = obj.DoseCode;
                        row["中心拼音码"] = obj.SpellCode;
                        row["费用分类"] = obj.FeeCode;
                        row["目录级别"] = obj.ItemType;
                        row["目录等级"] = obj.ItemGrade;
                        row["自负比例"] = obj.Rate;
                        row["基准价格"] = obj.Price;
                        row["限制使用说明"] = obj.Memo;
                        row["项目类别"] = obj.SysClass;
                        dtCenterItem.Rows.Add(row);
                    }
                }

                alCompareItem = this.myInterface.GetCompareItem(pactCode.ID, compareType.ToString());
                if (alCompareItem != null)
                {
                    foreach (Neusoft.HISFC.Models.SIInterface.Compare obj in alCompareItem)
                    {
                        DataRow row = dtCompareItem.NewRow();

                        row["本地项目编码"] = obj.HisCode;//0
                        row["中心编码"] = obj.CenterItem.ID;
                        row["项目类别"] = obj.CenterItem.SysClass;
                        row["医保收费项目中文名称"] = obj.CenterItem.Name;
                        row["医保收费项目英文名称"] = obj.CenterItem.EnglishName;//4
                        row["本地项目名称"] = obj.Name;
                        row["本地项目别名"] = obj.RegularName;
                        row["医保剂型"] = obj.CenterItem.DoseCode;
                        row["医保拼音代码"] = obj.CenterItem.SpellCode;//8
                        row["医保费用分类代码"] = obj.CenterItem.FeeCode;
                        row["医保目录级别"] = obj.CenterItem.ItemType;
                        row["医保目录等级"] = obj.CenterItem.ItemGrade;
                        row["自负比例"] = obj.CenterItem.Rate;//12
                        row["基准价格"] = obj.CenterItem.Price;
                        row["限制使用说明"] = obj.CenterItem.Memo;
                        row["医院拼音"] = obj.SpellCode.SpellCode;
                        row["医院五笔码"] = obj.SpellCode.WBCode;//16
                        row["医院自定义码"] = obj.SpellCode.UserCode;
                        row["医院规格"] = obj.Specs;
                        row["医院基本价格"] = obj.Price;
                        row["医院剂型"] = obj.DoseCode;//20
                        row["操作员"] = obj.CenterItem.OperCode;
                        row["操作时间"] = obj.CenterItem.OperDate;

                        dtCompareItem.Rows.Add(row);
                    }
                    this.fpCompareItem_Sheet1.Columns[0].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[1].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[2].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[3].Width = 30;
                    this.fpCompareItem_Sheet1.Columns[4].Width = 120;
                    this.fpCompareItem_Sheet1.Columns[5].Width = 120;
                    this.fpCompareItem_Sheet1.Columns[6].Width = 60;
                    this.fpCompareItem_Sheet1.Columns[7].Width = 60;
                    this.fpCompareItem_Sheet1.Columns[8].Width = 60;
                    this.fpCompareItem_Sheet1.Columns[9].Width = 30;
                    this.fpCompareItem_Sheet1.Columns[10].Width = 30;
                    this.fpCompareItem_Sheet1.Columns[11].Width = 30;
                    this.fpCompareItem_Sheet1.Columns[12].Width = 30;
                    this.fpCompareItem_Sheet1.Columns[13].Width = 30;
                    this.fpCompareItem_Sheet1.Columns[14].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[15].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[16].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[17].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[18].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[19].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[20].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[21].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[22].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[23].Width = 80;
                    this.fpCompareItem_Sheet1.Columns[24].Width = 80;
                    /*
                                                            new DataColumn("医院自定义码", str),//0
                                                            new DataColumn("本地项目编码", str),
                                                            new DataColumn("中心编码", str),
                                                            new DataColumn("项目类别", str),
                                                            new DataColumn("医保收费项目中文名称", str),//4
                                                            new DataColumn("本地项目名称", str),
                                                            new DataColumn("本地项目别名", str),
                                                            new DataColumn("医保收费项目英文名称", str),
                                                            new DataColumn("医保剂型", str),//8
                                                            new DataColumn("医保规格",str),
                                                            new DataColumn("医保拼音代码", str),
                                                            new DataColumn("医保费用分类代码", str),
                                                            new DataColumn("医保目录级别", str),//12
                                                            new DataColumn("医保目录等级", str),
                                                            new DataColumn("自负比例", dec),
                                                            new DataColumn("基准价格", dec),
                                                            new DataColumn("限制使用说明", str),//16
                                                            new DataColumn("医院拼音", str),
                                                            new DataColumn("医院五笔码", str),
                                                            new DataColumn("医院规格", str),
                                                            new DataColumn("医院基本价格", dec),//20
                                                            new DataColumn("医院剂型", str),
                                                            new DataColumn("操作员", str),
                                                            new DataColumn("操作时间", date),
                                                            //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
                                                            new DataColumn("医院项目类别", str)};//24
                     */
                    if (pactCode.ID == "06")
                    {
                        this.fpCompareItem_Sheet1.Columns[7].Visible = false;//医保英文名
                        this.fpCompareItem_Sheet1.Columns[6].Visible = false;//本地别名
                        this.fpCompareItem_Sheet1.Columns[10].Visible = false;//拼音码
                        this.fpCompareItem_Sheet1.Columns[17].Visible = false;//拼音码
                        this.fpCompareItem_Sheet1.Columns[18].Visible = false;//五笔码
                    }
                }
                #endregion
            }

            this.dtCenterItem.AcceptChanges();
            this.dtCompareItem.AcceptChanges();
            this.dtHisItem.AcceptChanges();
        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="input"></param>
        private void FilterItem(string flag, string input)
        {
            string filterString = "";
            input = input.ToUpper();
            switch (flag)
            {
                case "HIS":
                    switch (code)
                    {
                        case "PY":
                            if (!this.checkBox1.Checked)
                            {
                                filterString = "拼音码" + " like '" + input + "%'";
                            }
                            else
                            {
                                filterString = "拼音码" + " like '%" + input + "%'";
                            }
                            break;
                        case "WB":
                            if (!this.checkBox1.Checked)
                            {
                                filterString = "五笔码" + " like '" + input + "%'";
                            }
                            else
                            {
                                filterString = "五笔码" + " like '%" + input + "%'";
                            }

                            break;
                        case "US":
                            if (!this.checkBox1.Checked)
                            {
                                filterString = "自定义码" + " like '" + input + "%'";
                            }
                            else
                            {
                                filterString = "自定义码" + " like '%" + input + "%'";
                            }

                            break;
                        case "ZW":
                            if (!this.checkBox1.Checked)
                            {
                                filterString = "药品名称" + " like '" + input + "%'";
                            }
                            else
                            {
                                filterString = "药品名称" + " like '%" + input + "%'";
                            }

                            break;
                        case "TYPY":
                            if (!this.checkBox1.Checked)
                            {
                                filterString = "通用名拼音" + " like '" + input + "%'";
                            }
                            else
                            {
                                filterString = "通用名拼音" + " like '%" + input + "%'";
                            }

                            break;
                        case "TYWB":
                            if (!this.checkBox1.Checked)
                            {
                                filterString = "通用名五笔" + " like '" + input + "%'";
                            }
                            else
                            {
                                filterString = "通用名五笔" + " like '%" + input + "%'";
                            }

                            break;
                    }
                    this.dvHisItem.RowFilter = filterString;
                    InitColumnProHis();
                    break;
                case "CENTER":
                    if (!this.checkBox1.Checked)
                    {
                        filterString = "中心拼音码" + " like '" + input + "%'" + " or " + "中心编码" + " like '" + input + "%'" + " or " + "中心编码" + " like '" + input + "%'";
                    }
                    else
                    {
                        filterString = "中心拼音码" + " like '%" + input + "%'" + " or " + "中心编码" + " like '%" + input + "%'" + " or " + "中心编码" + " like '%" + input + "%'";
                    }
                    this.dvCenterItem.RowFilter = filterString;
                    InitColumnProCenter();
                    break;
                case "COMPARE":
                    if (!this.checkBox1.Checked)
                    {
                        filterString = "医院拼音" + " like '" + input + "%'" + " or " + "医院自定义码" + " like '" + input + "%'";
                    }
                    else
                    {
                        filterString = "医院拼音" + " like '%" + input + "%'" + " or " + "医院自定义码" + " like '%" + input + "%'";
                    }
                    this.dvCompareItem.RowFilter = filterString;
                    break;
            }
        }
        /// <summary>
        /// 显示选择的本地信息
        /// </summary>
        /// <param name="row"></param>
        private void SetHisItemInfo(int row)
        {
            string hisCode = "";
            if (isDrug)
            {
                hisCode = this.fpHisItem_Sheet1.Cells[row, 0].Text.Trim();
                this.tbHisName.Text = this.fpHisItem_Sheet1.Cells[row, 1].Text;
                this.tbHisPrice.Text = this.fpHisItem_Sheet1.Cells[row, 11].Text;

                Neusoft.HISFC.Models.Pharmacy.Item obj = this.GetSelectHisItem(hisCode);

                if (obj == null)
                {
                    MessageBox.Show("未找到选定本地药品!");
                }
                else
                {
                    this.tbHisSpell.Tag = obj;
                }

            }
            else
            {
                hisCode = this.fpHisItem_Sheet1.Cells[row, 0].Text.Trim();
                this.tbHisName.Text = this.fpHisItem_Sheet1.Cells[row, 1].Text;
                this.tbHisPrice.Text = this.fpHisItem_Sheet1.Cells[row, 8].Text;

                Neusoft.HISFC.Models.Fee.Item.Undrug obj = this.GetSelectHisUndrugItem(hisCode);

                if (obj == null)
                {
                    MessageBox.Show("未找到选定本地非药品!");
                }
                else
                {
                    this.tbHisSpell.Tag = obj;
                }

            }

            tabCompare.SelectedTab = this.tbCenterItem;
            this.tbCenterSpell.Focus();
        }
        /// <summary>
        /// 显示选择的中心信息
        /// </summary>
        /// <param name="row"></param>
        private void SetCenterItemInfo(int row)
        {
            string centerCode = "";

            centerCode = this.fpCenterItem_Sheet1.Cells[row, 0].Text.Trim();

            Item obj = this.GetSelectCenterItem(centerCode);

            if (obj == null)
            {
                MessageBox.Show("未找到中心药品");
            }
            else
            {
                tbCenterSpell.Tag = obj;
            }

            this.tbCenterName.Text = this.fpCenterItem_Sheet1.Cells[row, 1].Text;
            this.tbCenterPrice.Text = this.fpCenterItem_Sheet1.Cells[row, 10].Text;
            this.tabCompare.SelectedTab = this.tbCompare;
        }
        /// <summary>
        /// 获得已选择HIS药品信息
        /// </summary>
        /// <param name="hisCode">医院药品代码</param>
        /// <returns>药品信息实体</returns>
        private Neusoft.HISFC.Models.Pharmacy.Item GetSelectHisItem(string hisCode)
        {
            Neusoft.HISFC.Models.Pharmacy.Item obj = new Neusoft.HISFC.Models.Pharmacy.Item();

            DataRow row = this.dtHisItem.Rows.Find(hisCode);

            obj.ID = row["药品编码"].ToString();
            obj.Name = row["药品名称"].ToString();
            obj.SpellCode = row["拼音码"].ToString();
            obj.WBCode = row["五笔码"].ToString();
            obj.UserCode = row["自定义码"].ToString();
            obj.Specs = row["规格"].ToString();
            obj.NameCollection.RegularName = row["通用名"].ToString();
            //obj.RegularSpellCode.Spell_Code = row["通用名拼音"].ToString();
            obj.NameCollection.SpellCode = row["通用名拼音"].ToString();
            obj.NameCollection.WBCode = row["通用名五笔"].ToString();
            obj.NameCollection.InternationalCode = row["国际编码"].ToString();
            obj.GBCode = row["国家编码"].ToString();
            obj.PriceCollection.RetailPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["价格"].ToString());
            obj.DosageForm.ID = row["剂型编码"].ToString();
            //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
            obj.Type.ID = row["药品类别"].ToString();

            return obj;
        }
        /// <summary>
        /// 获得本地His非药品信息
        /// </summary>
        /// <param name="hisCode"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Fee.Item.Undrug GetSelectHisUndrugItem(string hisCode)
        {
            Neusoft.HISFC.Models.Fee.Item.Undrug obj = new Neusoft.HISFC.Models.Fee.Item.Undrug();

            DataRow row = this.dtHisItem.Rows.Find(hisCode);

            obj.ID = row["非药品编码"].ToString();
            obj.Name = row["非药品名称"].ToString();
            obj.SpellCode = row["拼音码"].ToString();
            obj.WBCode = row["五笔码"].ToString();
            obj.UserCode = row["自定义码"].ToString();
            obj.Specs = row["规格"].ToString();
            obj.NationCode = row["国际编码"].ToString();
            obj.GBCode = row["国家编码"].ToString();
            obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["价格"].ToString());
            obj.PriceUnit = row["单位"].ToString();

            return obj;
        }

        /// <summary>
        /// 获得已选中心项目信息
        /// </summary>
        /// <param name="centerCode"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.SIInterface.Item GetSelectCenterItem(string centerCode)
        {
            Item obj = new Item();

            DataRow row = this.dtCenterItem.Rows.Find(centerCode);
            if (isDrug)
            {
                obj.ID = row["中心编码"].ToString();
                obj.Name = row["中心项目名称"].ToString();
                obj.EnglishName = row["中心项目英文名"].ToString();
            }
            else
            {
                obj.ID = row["中心编码"].ToString();
                obj.Name = row["中心项目名称"].ToString();
                obj.EnglishName = row["中心项目英文名"].ToString();
            }

            obj.Specs = row["规格"].ToString();
            obj.DoseCode = row["剂型"].ToString();
            obj.SpellCode = row["中心拼音码"].ToString();
            obj.FeeCode = row["费用分类"].ToString();
            obj.ItemType = row["目录级别"].ToString();
            obj.ItemGrade = row["目录等级"].ToString();
            obj.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["自负比例"].ToString());
            obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["基准价格"].ToString());
            obj.Memo = row["限制使用说明"].ToString();
            obj.SysClass = row["项目类别"].ToString();


            return obj;
        }
        /// <summary>
        /// 对照操作
        /// </summary>
        public void Compare()
        {
            Compare objCom = new Compare();

            if (isDrug)
            {
                Neusoft.HISFC.Models.Pharmacy.Item objHis = new Neusoft.HISFC.Models.Pharmacy.Item();
                Item objCenter = new Item();

                if (this.tbHisSpell.Tag == null || this.tbHisSpell.Tag.ToString() == "")
                {
                    MessageBox.Show("没有选择本地项目!");
                    return;
                }

                objHis = (Neusoft.HISFC.Models.Pharmacy.Item)this.tbHisSpell.Tag;

                if (tbCenterSpell.Tag == null || tbCenterSpell.Tag.ToString() == "")
                {
                    MessageBox.Show("没有选择中心项目");
                    return;
                }

                objCenter = (Item)this.tbCenterSpell.Tag;

                DataRow row = this.dtCompareItem.NewRow();

                row["本地项目编码"] = objHis.ID;
                row["中心编码"] = objCenter.ID;
                row["项目类别"] = objCenter.SysClass;
                row["医保收费项目中文名称"] = objCenter.Name;
                row["医保收费项目英文名称"] = objCenter.EnglishName;
                row["本地项目名称"] = objHis.Name;
                row["本地项目别名"] = objHis.NameCollection.RegularName;//.RegularName;
                row["医保剂型"] = objCenter.DoseCode;
                row["医保规格"] = objCenter.Specs;
                row["医保拼音代码"] = objCenter.SpellCode;
                row["医保费用分类代码"] = objCenter.FeeCode;
                row["医保目录级别"] = objCenter.ItemType;
                row["医保目录等级"] = objCenter.ItemGrade;
                row["自负比例"] = objCenter.Rate;
                row["基准价格"] = objCenter.Price;
                row["限制使用说明"] = objCenter.Memo;
                row["医院拼音"] = objHis.SpellCode;
                row["医院五笔码"] = objHis.WBCode;// .SpellCode.WB_Code;
                row["医院自定义码"] = objHis.UserCode;//SpellCode.User_Code;
                row["医院规格"] = objHis.Specs;
                row["医院基本价格"] = objHis.PriceCollection.RetailPrice; //.RetailPrice;
                row["医院剂型"] = objHis.DosageForm.ID;
                row["操作员"] = myInterface.Operator.ID;
                row["操作时间"] = System.DateTime.Now;
                //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
                row["医院项目类别"] = objHis.Type.ID;

                dtCompareItem.Rows.Add(row);


                objCom.CenterItem.PactCode = pactCode.ID;
                objCom.HisCode = objHis.ID;
                objCom.CenterItem.ID = objCenter.ID;
                objCom.CenterItem.SysClass = objCenter.SysClass;
                objCom.CenterItem.Name = objCenter.Name;
                objCom.CenterItem.EnglishName = objCenter.EnglishName;
                objCom.Name = objHis.Name;
                objCom.RegularName = objHis.NameCollection.RegularName; //.RegularName;
                objCom.CenterItem.DoseCode = objCenter.DoseCode;
                objCom.CenterItem.Specs = objCenter.Specs;
                objCom.CenterItem.FeeCode = objCenter.FeeCode;
                objCom.CenterItem.ItemType = objCenter.ItemType;
                objCom.CenterItem.ItemGrade = objCenter.ItemGrade;
                objCom.CenterItem.Rate = objCenter.Rate;
                objCom.CenterItem.Price = objCenter.Price;
                objCom.CenterItem.Memo = objCenter.Memo;
                objCom.SpellCode.SpellCode = objHis.SpellCode;
                objCom.SpellCode.WBCode = objHis.WBCode;//SpellCode.WB_Code;
                objCom.SpellCode.UserCode = objHis.UserCode;//SpellCode.User_Code;
                objCom.Specs = objHis.Specs;
                objCom.Price = objHis.PriceCollection.RetailPrice;//.RetailPrice;
                objCom.DoseCode = objHis.DosageForm.ID;
                objCom.CenterItem.OperCode = myInterface.Operator.ID;
                //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
                objCom.HisSysClass = objHis.Type.ID;

                DataRow rowFind = dtHisItem.Rows.Find(objHis.ID);
                dtHisItem.Rows.Remove(rowFind);
            }
            else
            {
                //neusoft.HISFC.Models.Fee.Item objHis = new neusoft.HISFC.Models.Fee.Item();
                Neusoft.HISFC.Models.Fee.Item.Undrug objHis = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                Item objCenter = new Item();

                if (this.tbHisSpell.Tag == null || this.tbHisSpell.Tag.ToString() == "")
                {
                    MessageBox.Show("没有选择本地项目!");
                    return;
                }

                objHis = (Neusoft.HISFC.Models.Fee.Item.Undrug)this.tbHisSpell.Tag;

                if (tbCenterSpell.Tag == null || tbCenterSpell.Tag.ToString() == "")
                {
                    MessageBox.Show("没有选择中心项目");
                    return;
                }

                objCenter = (Item)this.tbCenterSpell.Tag;

                DataRow row = this.dtCompareItem.NewRow();

                row["本地项目编码"] = objHis.ID;
                row["中心编码"] = objCenter.ID;
                row["项目类别"] = objCenter.SysClass;
                row["医保收费项目中文名称"] = objCenter.Name;
                row["医保收费项目英文名称"] = objCenter.EnglishName;
                row["本地项目名称"] = objHis.Name;
                row["本地项目别名"] = "";
                row["医保剂型"] = objCenter.DoseCode;
                row["医保规格"] = objCenter.Specs;
                row["医保拼音代码"] = objCenter.SpellCode;//SpellCode.Spell_Code;
                row["医保费用分类代码"] = objCenter.FeeCode;
                row["医保目录级别"] = objCenter.ItemType;
                row["医保目录等级"] = objCenter.ItemGrade;
                row["自负比例"] = objCenter.Rate;
                row["基准价格"] = objCenter.Price;
                row["限制使用说明"] = objCenter.Memo;
                row["医院拼音"] = objHis.SpellCode;
                row["医院五笔码"] = objHis.WBCode;
                row["医院自定义码"] = objHis.UserCode;
                row["医院规格"] = objHis.Specs;
                row["医院基本价格"] = objHis.Price;
                row["医院剂型"] = "";
                row["操作员"] = myInterface.Operator.ID;
                row["操作时间"] = System.DateTime.Now;
                //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
                row["医院项目类别"] = "L";

                dtCompareItem.Rows.Add(row);

                objCom.CenterItem.PactCode = pactCode.ID;
                objCom.HisCode = objHis.ID;
                objCom.CenterItem.ID = objCenter.ID;
                objCom.CenterItem.SysClass = objCenter.SysClass;
                objCom.CenterItem.Name = objCenter.Name;
                objCom.CenterItem.EnglishName = objCenter.EnglishName;
                objCom.Name = objHis.Name;
                objCom.RegularName = "";
                objCom.CenterItem.DoseCode = objCenter.DoseCode;
                objCom.CenterItem.Specs = objCenter.Specs;
                objCom.CenterItem.FeeCode = objCenter.FeeCode;
                objCom.CenterItem.ItemType = objCenter.ItemType;
                objCom.CenterItem.ItemGrade = objCenter.ItemGrade;
                objCom.CenterItem.Rate = objCenter.Rate;
                objCom.CenterItem.Price = objCenter.Price;
                objCom.CenterItem.Memo = objCenter.Memo;
                objCom.SpellCode.SpellCode = objHis.SpellCode;
                objCom.SpellCode.WBCode = objHis.WBCode;
                objCom.SpellCode.UserCode = objHis.UserCode;
                objCom.Specs = objHis.Specs;
                objCom.Price = objHis.Price;
                objCom.DoseCode = "";
                objCom.CenterItem.OperCode = myInterface.Operator.ID;
                //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
                objCom.HisSysClass = "L";

                DataRow rowFind = dtHisItem.Rows.Find(objHis.ID);
                dtHisItem.Rows.Remove(rowFind);
            }



            //neusoft.neuFC.Management.Transaction t = new neusoft.neuFC.Management.Transaction(neusoft.neuFC.Management.Connection.Instance);
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            myInterface.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            int returnValue = 0;

            returnValue = myInterface.InsertCompareItem(objCom);

            if (returnValue == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("对照失败!" + myInterface.Err);
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Clear();
            this.tbHisSpell.Focus();
        }
        /// <summary>
        /// 删除已对照信息
        /// </summary>
        public void Delete()
        {
            int rowAct = this.fpCompareItem_Sheet1.ActiveRowIndex;
            if (this.fpCompareItem_Sheet1.RowCount <= 0)
                return;

            string hisCode = "";
            hisCode = this.fpCompareItem_Sheet1.Cells[rowAct, 1].Text;

            if (hisCode == "" || hisCode == null)
                return;

            //neusoft.neuFC.Management.Transaction t = new neusoft.neuFC.Management.Transaction(neusoft.neuFC.Management.Connection.Instance);
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            myInterface.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            int returnValue = 0;

            returnValue = myInterface.DeleteCompareItem(pactCode.ID, hisCode);

            if (returnValue == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("删除对照失败!" + myInterface.Err);
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            DataRow row = this.dtCompareItem.Rows.Find(hisCode);

            DataRow rowHis = dtHisItem.NewRow();
            if (isDrug)
            {
                rowHis["药品编码"] = row["本地项目编码"].ToString();
                rowHis["药品名称"] = row["本地项目名称"].ToString();
                rowHis["通用名"] = row["本地项目别名"].ToString();
                rowHis["剂型编码"] = row["医院剂型"].ToString();
            }
            else
            {
                rowHis["非药品编码"] = row["本地项目编码"].ToString();
                rowHis["非药品名称"] = row["本地项目名称"].ToString();
                //				rowHis["国际编码"] = row["国际编码"].ToString();
                //				rowHis["国家编码"] = row["国家编码"].ToString();
                //				rowHis["单位"] = row["单位"].ToString();
            }
            rowHis["拼音码"] = row["医院拼音"].ToString();
            rowHis["五笔码"] = row["医院五笔码"].ToString();
            rowHis["自定义码"] = row["医院自定义码"].ToString();
            rowHis["规格"] = row["医院规格"].ToString();
            rowHis["价格"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["医院基本价格"].ToString());


            dtCompareItem.Rows.Remove(row);
            dtHisItem.Rows.Add(rowHis);


        }
        /// <summary>
        /// 清空信息
        /// </summary>
        public void Clear()
        {
            //this.tbCenterSpell.Text = "";
            this.tbCenterSpell.Tag = "";
            this.tbCenterName.Text = "";
            this.tbCenterPrice.Text = "";
            this.tbGrade.Text = "";


            this.tbHisSpell.Tag = "";
            this.tbHisName.Text = "";
            this.tbHisPrice.Text = "";
        }

        /// <summary>
        /// 保存函数
        /// </summary>
        public void Save()
        {
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            myInterface.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            int returnValue = 0;

            ArrayList alAdd = GetAddCompareItem();

            if (alAdd != null)
            {
                foreach (Compare obj in alAdd)
                {
                    returnValue = myInterface.InsertCompareItem(obj);
                    if (returnValue == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("插入对照信息出错!" + myInterface.Err);
                        return;
                    }
                }
            }

            ArrayList alDelete = GetDeleteCompareItem();

            if (alDelete != null)
            {
                foreach (Compare obj in alDelete)
                {
                    returnValue = myInterface.DeleteCompareItem(this.pactCode.ID, obj.HisCode);
                    if (returnValue == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("删除对照信息出错!" + myInterface.Err);
                        return;
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("保存成功!");
        }

        public void Close()
        {

        }

        /// <summary>
        /// 导出当前项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Export(object sender, object neuObject)
        {
            object obj = this.hashTableFp[this.tabCompare.SelectedTab];

            FarPoint.Win.Spread.FpSpread fp = obj as FarPoint.Win.Spread.FpSpread;

            SaveFileDialog op = new SaveFileDialog();

            op.Title = "请选择保存的路径和名称";
            op.CheckFileExists = false;
            op.CheckPathExists = true;
            op.DefaultExt = "*.xls";
            op.Filter = "(*.xls)|*.xls";

            DialogResult result = op.ShowDialog();

            if (result == DialogResult.Cancel || op.FileName == string.Empty)
            {
                return -1;
            }

            string filePath = op.FileName;

            bool returnValue = fp.SaveExcel(filePath, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                                


            return base.Export(sender, neuObject);
        }
        /// <summary>
        /// 获得新增项目
        /// </summary>
        /// <returns></returns>
        private ArrayList GetAddCompareItem()
        {
            DataTable dt = this.dtCompareItem.GetChanges(DataRowState.Added);
            ArrayList al = new ArrayList();
            if (dt == null)
            {
                return null;
            }
            foreach (DataRow row in dt.Rows)
            {
                Compare obj = new Compare();

                obj.CenterItem.PactCode = pactCode.ID;
                obj.HisCode = row["本地项目编码"].ToString();
                obj.CenterItem.ID = row["中心编码"].ToString();
                obj.CenterItem.SysClass = row["项目类别"].ToString();
                obj.CenterItem.Name = row["医保收费项目中文名称"].ToString();
                obj.CenterItem.EnglishName = row["医保收费项目英文名称"].ToString();
                obj.Name = row["本地项目名称"].ToString();
                obj.RegularName = row["本地项目别名"].ToString();
                obj.CenterItem.DoseCode = row["医保剂型"].ToString();
                obj.CenterItem.Specs = row["医保规格"].ToString();
                obj.CenterItem.SpellCode = row["医保拼音代码"].ToString();
                obj.CenterItem.FeeCode = row["医保费用分类代码"].ToString();
                obj.CenterItem.ItemType = row["医保目录级别"].ToString();
                obj.CenterItem.ItemGrade = row["医保目录等级"].ToString();
                obj.CenterItem.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["自负比例"].ToString());
                obj.CenterItem.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["基准价格"].ToString());
                obj.CenterItem.Memo = row["限制使用说明"].ToString();
                obj.SpellCode.SpellCode = row["医院拼音"].ToString();
                obj.SpellCode.WBCode = row["医院五笔码"].ToString();
                obj.SpellCode.UserCode = row["医院自定义码"].ToString();
                obj.Specs = row["医院规格"].ToString();
                obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["医院基本价格"].ToString());
                obj.DoseCode = row["医院剂型"].ToString();
                obj.CenterItem.OperCode = row["操作员"].ToString();
                obj.CenterItem.OperDate = Convert.ToDateTime(row["操作时间"].ToString());

                al.Add(obj);
            }

            return al;
        }

        private ArrayList GetDeleteCompareItem()
        {
            //dtCompareItem.RejectChanges();

            DataTable dt = this.dtCompareItem.GetChanges(DataRowState.Deleted);

            ArrayList al = new ArrayList();
            if (dt == null)
            {
                return null;
            }
            foreach (DataRow row in dt.Rows)
            {
                Compare obj = new Compare();

                obj.CenterItem.PactCode = pactCode.ID;
                obj.HisCode = row["本地项目编码"].ToString();
                obj.CenterItem.ID = row["中心编码"].ToString();
                obj.CenterItem.SysClass = row["项目类别"].ToString();
                obj.CenterItem.Name = row["医保收费项目中文名称"].ToString();
                obj.CenterItem.EnglishName = row["医保收费项目英文名称"].ToString();
                obj.Name = row["本地项目名称"].ToString();
                obj.RegularName = row["本地项目别名"].ToString();
                obj.CenterItem.DoseCode = row["医保剂型"].ToString();
                obj.CenterItem.Specs = row["医保规格"].ToString();
                obj.CenterItem.SpellCode = row["医保拼音代码"].ToString();
                obj.CenterItem.FeeCode = row["医保费用分类代码"].ToString();
                obj.CenterItem.ItemType = row["医保目录级别"].ToString();
                obj.CenterItem.ItemGrade = row["医保目录等级"].ToString();
                obj.CenterItem.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["自负比例"].ToString());
                obj.CenterItem.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["基准价格"].ToString());
                obj.CenterItem.Memo = row["限制使用说明"].ToString();
                obj.SpellCode.SpellCode = row["医院拼音"].ToString();
                obj.SpellCode.WBCode = row["医院五笔码"].ToString();
                obj.SpellCode.UserCode = row["医院自定义码"].ToString();
                obj.Specs = row["医院规格"].ToString();
                obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["医院基本价格"].ToString());
                obj.DoseCode = row["医院剂型"].ToString();
                obj.CenterItem.OperCode = row["操作员"].ToString();
                obj.CenterItem.OperDate = Convert.ToDateTime(row["操作时间"].ToString());

                al.Add(obj);
            }

            this.dtCompareItem.AcceptChanges();

            return al;
        }

        #endregion

        #region 事件
        private void tbHisSpell_TextChanged(object sender, EventArgs e)
        {
            this.FilterItem("HIS", this.tbHisSpell.Text);
        }

        private void tbCenterSpell_TextChanged(object sender, EventArgs e)
        {
            this.FilterItem("CENTER", this.tbCenterSpell.Text);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                circle++;

                switch (circle)
                {
                    case 0:
                        code = "PY";
                        tbSpell.Text = "拼音码";
                        break;
                    case 1:
                        code = "WB";
                        tbSpell.Text = "五笔码";
                        break;
                    case 2:
                        code = "US";
                        tbSpell.Text = "自定义码";
                        break;
                    case 3:
                        code = "ZW";
                        tbSpell.Text = "中文";
                        break;
                    case 4:
                        code = "TYPY";
                        tbSpell.Text = "通用拼音";
                        break;
                    case 5:
                        code = "TYWB";
                        tbSpell.Text = "通用五笔";
                        break;
                }

                if (circle == 5)
                {
                    circle = -1;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void tbHisSpell_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.fpHisItem_Sheet1.RowCount <= 0)
            {
                return;
            }

            if (e.KeyCode == Keys.Up)
            {
                this.fpHisItem.SetViewportTopRow(0, this.fpHisItem_Sheet1.ActiveRowIndex - 5);
                this.fpHisItem_Sheet1.ActiveRowIndex--;
                this.fpHisItem_Sheet1.AddSelection(this.fpHisItem_Sheet1.ActiveRowIndex, 0, 1, 0);
            }
            if (e.KeyCode == Keys.Down)
            {
                this.fpHisItem.SetViewportTopRow(0, this.fpHisItem_Sheet1.ActiveRowIndex - 4);
                this.fpHisItem_Sheet1.ActiveRowIndex++;
                this.fpHisItem_Sheet1.AddSelection(this.fpHisItem_Sheet1.ActiveRowIndex, 0, 1, 0);
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (this.fpHisItem_Sheet1.RowCount >= 0)
                {
                    SetHisItemInfo(this.fpHisItem_Sheet1.ActiveRowIndex);
                }
            }
        }

        private void fpHisItem_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.fpHisItem_Sheet1.RowCount >= 0)
                SetHisItemInfo(this.fpHisItem_Sheet1.ActiveRowIndex);
        }

        private void fpCenterItem_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.fpHisItem_Sheet1.RowCount >= 0)
            {
                SetCenterItemInfo(this.fpCenterItem_Sheet1.ActiveRowIndex);
            }
        }

        private void tbCenterSpell_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.fpCenterItem_Sheet1.RowCount <= 0)
            {
                return;
            }

            if (e.KeyCode == Keys.Up)
            {
                this.fpCenterItem.SetViewportTopRow(0, this.fpCenterItem_Sheet1.ActiveRowIndex - 5);
                this.fpCenterItem_Sheet1.ActiveRowIndex--;
                this.fpCenterItem_Sheet1.AddSelection(this.fpCenterItem_Sheet1.ActiveRowIndex, 0, 1, 0);
            }
            if (e.KeyCode == Keys.Down)
            {
                this.fpCenterItem.SetViewportTopRow(0, this.fpCenterItem_Sheet1.ActiveRowIndex - 4);
                this.fpCenterItem_Sheet1.ActiveRowIndex++;
                this.fpCenterItem_Sheet1.AddSelection(this.fpCenterItem_Sheet1.ActiveRowIndex, 0, 1, 0);
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (this.fpHisItem_Sheet1.RowCount >= 0)
                {
                    SetCenterItemInfo(this.fpCenterItem_Sheet1.ActiveRowIndex);
                }
            }
        }

        private void tbHisSpell_Enter(object sender, EventArgs e)
        {
            this.tabCompare.SelectedIndex = 0;
        }

        private void tbCenterSpell_Enter(object sender, EventArgs e)
        {
            this.tabCompare.SelectedIndex = 1;
        }

        private void tbCompareQuery_TextChanged(object sender, EventArgs e)
        {
            FilterItem("COMPARE", this.tbCompareQuery.Text);
        }

        private void ucCompare_Load(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据，请稍后^^");
            Application.DoEvents();
            ////compareType = base.Tag.ToString();// this.FindForm().Tag.ToString();
            //if (this.Tag.ToString() == "DALL")
            //{
            //    drugType.ID = "ALL";
            //    drugType.Name = "全部";
            //}
            //else
            //{
            //    drugType.ID = compareType.Substring(3, 1);
            //    switch (drugType.ID)
            //    {
            //        case "P":
            //            drugType.Name = "西药";
            //            break;
            //        case "Z":
            //            drugType.Name = "中成药";
            //            break;
            //        case "C":
            //            drugType.Name = "草药";
            //            break;
            //        case "U":
            //            drugType.Name = "非药品";
            //            break;
            //    }
            //}
            this.CompareType = this.compareType;
            this.GetPactinfo();
            //this.pactCode.ID = "2";
            this.Init();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        private int GetPactinfo()
        {
            Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();
            ArrayList pactList = pactManager.QueryPactUnitAll();
            if (pactList == null) 
            {
                MessageBox.Show("初始化合同单位出错!" + pactManager.Err);
                return -1;
            }
            this.cmbPact.AddItems(pactList);
            return 1;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "对照":
                    {
                        this.Compare();
                        break;
                    }
                case "取消":
                    {
                        this.Delete();
                        break;
                    }
                case "清空":
                    {
                        this.Clear();
                        break;
                    }
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion 

        private void cmbPact_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pactCode.ID = this.cmbPact.Tag.ToString();
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据，请稍后^^");
            Application.DoEvents();
            this.dtHisItem.Clear();
            this.dtCenterItem.Clear();
            this.dtCompareItem.Clear();
            InitData();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        private void tabCompare_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fpHisItem.Visible = true;
            this.fpCenterItem.Visible = true;
            this.fpCompareItem.Visible = true;
        }

        private void fpCompareItem_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if(pactCode.ID != "06" || this.isDrug == true)
            {
                return;
            }
            string hisCode = this.fpCompareItem_Sheet1.Cells[e.Row, 1].Text;
            string centerCode = this.fpCompareItem_Sheet1.Cells[e.Row, 2].Text;
            string centerName = this.fpCompareItem_Sheet1.Cells[e.Row, 4].Text;
            decimal hisPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpCompareItem_Sheet1.Cells[e.Row, 20].Text);
            decimal centerPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpCompareItem_Sheet1.Cells[e.Row, 15].Text);
            decimal centerRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpCompareItem_Sheet1.Cells[e.Row, 14].Text);
            string centerMemo = "";
            Neusoft.HISFC.Models.SIInterface.Compare com = new Compare();
            com.HisCode = hisCode;
            com.CenterItem.ID = centerCode;
            com.CenterItem.Name = centerName;
            com.Price = hisPrice;
            com.CenterItem.Price = centerPrice;
            com.CenterItem.Rate = centerRate;
            com.CenterItem.Memo = centerMemo;
            this.ShowForm(com);
            this.fpCompareItem_Sheet1.Cells[e.Row, 15].Text = com.CenterItem.Price.ToString("0.00");
            this.fpCompareItem_Sheet1.Cells[e.Row, 14].Text = com.CenterItem.Rate.ToString("0.00");
        }

        private void ShowForm(Neusoft.HISFC.Models.SIInterface.Compare com)
        {
            ucItem item = new ucItem();
            item.IsModify = true;
            item.PactCode = "06";          
            item.CompareItem = com;

            DialogResult dr = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(item);
            if (dr == DialogResult.Yes)
            {
                //界面显示
                DataRow dataRow = this.dtCompareItem.Rows.Find(com.HisCode);
                dataRow[15] = com.CenterItem.Price;
                dataRow[14] = com.CenterItem.Rate;
            }
        }
    }
}
