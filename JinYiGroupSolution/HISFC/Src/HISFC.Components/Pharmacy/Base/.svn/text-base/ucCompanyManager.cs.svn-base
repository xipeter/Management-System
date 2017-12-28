using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using System.Collections;
using FarPoint.Win.Spread;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述: 药品供货公司、生产厂家维护]<br></br>
    /// [创 建 者: Liangjz]<br></br>
    /// [创建时间: 2007-07]<br></br>
    /// <修改记录>
    ///    1.生产厂家供货公司维护增加特殊字符校验 by Sunjh 2010-8-25 {90875342-BE12-41fb-8F26-4EFF1889E7B2}
    /// </修改记录>
    /// </summary>
    public partial class ucCompanyManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCompanyManager()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt = new DataTable();

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

        /// <summary>
        /// 维护的公司类型 
        /// </summary>
        private CompanyType type = CompanyType.生产厂家;

        /// <summary>
        /// 可存储的公司名称最长长度
        /// </summary>
        private int nameMaxLength = 100;

        /// <summary>
        /// 可维护的公司地址最长长度
        /// </summary>
        private int addressMaxLength = 200;

        /// <summary>
        /// 可维护的公司联系方式最长长度
        /// </summary>
        private int relativeMaxLength = 100;

        /// <summary>
        /// 可维护的公司GSP信息最长长度
        /// </summary>
        private int gspMaxLength = 100;

        /// <summary>
        /// 可维护的公司GMP信息最长长度
        /// </summary>
        private int gmpMaxLength = 200;

        /// <summary>
        /// 可维护的公司开户银行最长长度
        /// </summary>
        private int bankMaxLength = 200;

        /// <summary>
        /// 可维护的公司开户帐号最长长度
        /// </summary>
        private int accountMaxLength = 100;

        /// <summary>
        /// 开户银行是否必须输入项目
        /// </summary>
        private bool isBankNeed = false;

        /// <summary>
        /// 联系方式是否必须输入项目
        /// </summary>
        private bool isRelativeNeed = false;

        #endregion

        #region 属性

        /// <summary>
        /// 维护的公司类型
        /// </summary>
        [Description("本窗口维护的公司类型"),Category("设置")]
        public CompanyType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;

                this.SetCellType();
            }
        }

        /// <summary>
        /// 可存储的公司最长字符长度(汉字两字符)
        /// </summary>
        [Description("可存储的公司最长字符长度(汉字两字符)"), Category("有效性校验"), DefaultValue(100)]
        public int NameMaxLength
        {
            get
            {
                return this.nameMaxLength;
            }
            set
            {
                this.nameMaxLength = value;
            }
        }

        /// <summary>
        /// 可维护的公司地址最长长度(汉字两字符)
        /// </summary>
        [Description("可维护的公司地址最长长度(汉字两字符)"), Category("有效性校验"), DefaultValue(200)]
        public int AddressMaxLength
        {
            get
            {
                return this.addressMaxLength;
            }
            set
            {
                this.addressMaxLength = value;
            }
        }

        /// <summary>
        /// 可维护的公司联系方式最长长度(汉字两字符)
        /// </summary>
        [Description("可维护的公司联系方式最长长度(汉字两字符)"), Category("有效性校验"), DefaultValue(100)]
        public int RelativeMaxLength
        {
            get
            {
                return this.relativeMaxLength;
            }
            set
            {
                this.relativeMaxLength = value;
            }
        }

        /// <summary>
        /// 可维护的公司GSP信息最长长度(汉字两字符)
        /// </summary>
        [Description("可维护的公司GSP信息最长长度(汉字两字符)"), Category("有效性校验"), DefaultValue(100)]
        public int GSPMaxLength
        {
            get
            {
                return this.gspMaxLength;
            }
            set
            {
                this.gspMaxLength = value;
            }
        }

        /// <summary>
        /// 可维护的公司GMP信息最长长度(汉字两字符)
        /// </summary>
        [Description("可维护的公司GMP信息最长长度(汉字两字符)"), Category("有效性校验"), DefaultValue(200)]
        public int GMPMaxLength
        {
            get
            {
                return this.gmpMaxLength;
            }
            set
            {
                this.gmpMaxLength = value;
            }
        }

        /// <summary>
        /// 可维护的公司开户银行最长长度(汉字两字符)
        /// </summary>
        [Description("可维护的公司开户银行最长长度(汉字两字符)"), Category("有效性校验"), DefaultValue(200)]
        public int BankMaxLength
        {
            get
            {
                return this.bankMaxLength;
            }
            set
            {
                this.bankMaxLength = value;
            }
        }

        /// <summary>
        /// 可维护的公司开户帐号最长长度(汉字两字符)
        /// </summary>
        [Description("可维护的公司开户帐号最长长度(汉字两字符)"), Category("有效性校验"), DefaultValue(100)]
        public int AccountMaxLength
        {
            get
            {
                return this.accountMaxLength;
            }
            set
            {
                this.accountMaxLength = value;
            }
        }

        /// <summary>
        /// 开户银行是否必须输入项目
        /// </summary>
        [Description("开户银行是否必须输入项目"), Category("有效性校验"), DefaultValue(false)]
        public bool IsBankNeed
        {
            get
            {
                return this.isBankNeed;
            }
            set
            {
                this.isBankNeed = value;
            }
        }

        /// <summary>
        /// 联系方式是否必须输入项目
        /// </summary>
        [Description("联系方式是否必须输入项目"), Category("有效性校验"), DefaultValue(false)]
        public bool IsRelativeNeed
        {
            get
            {
                return this.isRelativeNeed;
            }
            set
            {
                this.isRelativeNeed = value;
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            #region {9768C6B1-5F8C-484c-AFBC-0B2D8CC55400}
            toolBarService.AddToolButton("增加", "增加", Neusoft.FrameWork.WinForms.Classes.EnumImageList.A安排, true, false, null); 
            #endregion
           
            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "增加")
            {
                this.AddData();
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();

            return 1;
        }

        public override int Export(object sender, object neuObject)
        {
            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                if (this.neuSpread1.Export() == 1)
                {
                    MessageBox.Show(Language.Msg("导出成功"));
                }
            }

            return 1;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.ShowData(this.type);

            return base.OnQuery(sender, neuObject);
        }

        #endregion

        #region 初始化及数据表操作

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            InputMap im;

            im = this.neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            this.InitDataSet();

            return 1;
        }

        /// <summary>
        ///  初始化DataSet
        /// </summary>
        private void InitDataSet()
        {
            this.neuSpread1_Sheet1.DataAutoSizeColumns = false;           

            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBol = System.Type.GetType("System.Boolean");

            //在myDataTable中添加列
            this.dt.Columns.AddRange(new DataColumn[] {														
														new DataColumn("单位名称",   dtStr),														
													    new DataColumn("联系方式",   dtStr),
                                                        new DataColumn("开户银行",   dtStr),
														new DataColumn("开户帐号",   dtStr),
                                                        new DataColumn("加价率",     dtDec),														                                                        
														new DataColumn("拼音码",     dtStr),
														new DataColumn("五笔码",     dtStr),
														new DataColumn("自定义码",   dtStr),
                                                        new DataColumn("有效",       dtBol),
                                                        new DataColumn("GSP",        dtStr),
                                                        new DataColumn("GMP",        dtStr),
                                                        new DataColumn("地址",       dtStr),
                										new DataColumn("备注",       dtStr),
                                                        new DataColumn("公司编码",   dtStr),
														new DataColumn("公司类型",   dtStr)
											        });

            this.neuSpread1_Sheet1.DataSource = this.dt.DefaultView;
        }

        /// <summary>
        /// 向数据表内加入数据
        /// </summary>
        /// <param name="company"></param>
        private void AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Company company)
        {
            this.dt.Rows.Add(new object[] {
					                                company.Name,					                                
				                                    company.RelationCollection.Relative,
                                                    company.OpenBank,
                                                    company.OpenAccounts,
                                                    company.ActualRate,
                                                    company.SpellCode,
                                                    company.WBCode,
                                                    company.UserCode,
                                                    company.IsValid,
                                                    company.GSPInfo,
                                                    company.GMPInfo,
                                                    company.RelationCollection.Address,
                                                    company.Memo,
                                                    company.ID,
                                                    company.Type
											        });
        }

        /// <summary>
        /// 从数据表内获取数据
        /// </summary>
        /// <param name="row">需获取数据的数据表行</param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Pharmacy.Company GetDataFromTable(DataRow row)
        {
            Neusoft.HISFC.Models.Pharmacy.Company company = new Neusoft.HISFC.Models.Pharmacy.Company();

            company.ID = row["公司编码"].ToString();                            //公司编码
            company.Name = row["单位名称"].ToString();                          //公司名称
            company.RelationCollection.Address = row["地址"].ToString();        //公司地址
            company.RelationCollection.Relative = row["联系方式"].ToString();   //联系方式
            company.GMPInfo = row["GMP"].ToString();                            //GMP信息
            company.GSPInfo = row["GSP"].ToString();                            //GSP信息
            company.SpellCode = row["拼音码"].ToString();                       //拼音码
            company.WBCode = row["五笔码"].ToString();                          //五笔码
            company.UserCode = row["自定义码"].ToString();                      //自定义码
            company.Type = ((int)this.type).ToString();                         //公司类型
            company.OpenBank = row["开户银行"].ToString();                      //开户银行
            company.OpenAccounts = row["开户帐号"].ToString();                  //开户帐号
            company.ActualRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["加价率"]);    //加价率
            company.Memo = row["备注"].ToString();                              //备注	
            company.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["有效"]);         //有效性

            return company;
        }

        #endregion

        #region Fp的CellType格式化

        /// <summary>
        /// 设置显示格式
        /// </summary>
        private void SetCellType()
        {
            if (this.type == CompanyType.供货公司)
            {
                this.SetCompany();
            }
            else if (this.type == CompanyType.生产厂家)
            {
                {
                    this.SetProducer();
                }
            }
            else
            {
                MessageBox.Show(Language.Msg("传入公司类型错误"));
            }
        }

        /// <summary>
        /// 设置生产厂家的显示格式
        /// </summary>
        private void SetProducer()
        {
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColGMP].Visible = true;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColGSP].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColGrade].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColID].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColType].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColGMP].Width = 60;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColGSP].Width = 60;
        }

        /// <summary>
        /// 设置供货公司的显示格式
        /// </summary>
        private void SetCompany()
        {
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColGSP].Visible = true;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColGMP].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColGrade].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColID].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColType].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColGMP].Width = 60;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColGSP].Width = 60;
        }

        #endregion

        /// <summary>
        /// 将传入数组中的数据显示Fp中
        /// </summary>
        public void ShowData(CompanyType type)
        {
            //清空数据
            this.dt.Rows.Clear();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在加载数据,请稍候..."));
            Application.DoEvents();

            //取公司记录
            ArrayList alCompany = this.phaConsManager.QueryCompany(((int)type).ToString(),false);
            if (alCompany == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("加载公司数据发生错误" + this.phaConsManager.Err));
                return;
            }

            Neusoft.HISFC.Models.Pharmacy.Company company;

            for (int i = 0; i < alCompany.Count; i++)
            {
                company = alCompany[i] as Neusoft.HISFC.Models.Pharmacy.Company;

                this.AddDataToTable(company);  
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            //提交DataTable中的变化。
            this.dt.AcceptChanges();

            this.SetCellType();
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        public void ClearData()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 增加新行
        /// </summary>
        public void AddData()
        {
            this.dt.DefaultView.RowFilter = "";

            this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.RowCount - 1;
            this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColName;          

            this.dt.Rows.Add(this.dt.NewRow());
        }

        /// <summary>
        /// 删除一条公司记录
        /// </summary>
        public void DeleteData()
        {
            this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);
        }

        /// <summary>
        /// 通过输入的查询码，过滤数据列表
        /// </summary>
        private void ChangeItem()
        {
            if (this.dt.Rows.Count == 0) return;

            try
            {
                string queryCode = "";

                queryCode = "%" + this.txtFilter.Text.Trim() + "%";

                string filter = "(拼音码 LIKE '" + queryCode + "') OR " +
                    "(五笔码 LIKE '" + queryCode + "') OR " +
                    "(自定义码 LIKE '" + queryCode + "') OR " +
                    "(单位名称 LIKE '" + queryCode + "') ";

                //设置过滤条件
                this.dt.DefaultView.RowFilter = filter;

                this.SetCellType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public int Save()
        {
            this.neuSpread1.StopCellEditing();

            foreach (DataRow dr in this.dt.Rows)
            {
                dr.EndEdit();
            }

            //有效性判断
            if (!Valid())
            {
                return -1;
            };

            //定义数据库处理事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.phaConsManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            bool isUpdate = false; //判断是否更新或者删除过数据

            //取修改和增加的数据
            DataTable dataChanges = this.dt.GetChanges(DataRowState.Modified | DataRowState.Added);
            if (dataChanges != null)
            {
                foreach (DataRow row in dataChanges.Rows)
                {
                    Neusoft.HISFC.Models.Pharmacy.Company company = this.GetDataFromTable(row);                    

                    //执行更新操作，先更新，如果没有成功则插入新数据
                    if (this.phaConsManager.SetCompany(company) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("保存公司信息发生错误!" + this.phaConsManager.Err));
                        return -1;
                    }
                }
                dataChanges.AcceptChanges();

                isUpdate = true;
            }

            //取删除的数据
            dataChanges = this.dt.GetChanges(DataRowState.Deleted);
            if (dataChanges != null)
            {
                dataChanges.RejectChanges();
                foreach (DataRow row in dataChanges.Rows)
                {
                    string companyID = row["公司编码"].ToString();        //公司编码		
                    //执行删除操作
                    if (this.phaConsManager.DeleteCompany(companyID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("删除供货公司" + row["单位名称"].ToString() + "发生错误" + this.phaConsManager.Err));
                        return -1;
                    }
                }
                dataChanges.AcceptChanges();

                isUpdate = true;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            if (isUpdate)
            {
                MessageBox.Show(Language.Msg("保存成功！"));
            }
            else
            {
                return 1;
            }

            //刷新数据
            this.ShowData(this.type);

            return 1;
        }

        /// <summary>
        ///  有效性判断
        /// </summary>
        private bool Valid()
        {
            int i = 1;

            //{2876B618-36A2-4faf-8DF1-7728D400ACA9} 重复公司名称判断
            System.Collections.Generic.Dictionary<string,int> companyNameIndexDictionary = new Dictionary<string,int>();

            foreach (DataRow dr in this.dt.Rows)
            {
                if (dr["单位名称"].ToString() == "")
                {
                    MessageBox.Show(Language.Msg("第" + i.ToString() + "行单位名称不能为空"));//{52A48F33-7979-447d-9925-1B1B3389929A}
                    return false;
                }
                //{2876B618-36A2-4faf-8DF1-7728D400ACA9} 重复公司名称判断
                if (companyNameIndexDictionary.ContainsKey(dr["单位名称"].ToString()) == true)
                {
                    companyNameIndexDictionary[dr["单位名称"].ToString()] = companyNameIndexDictionary[dr["单位名称"].ToString()] + 1;
                }
                else
                {
                    companyNameIndexDictionary.Add(dr["单位名称"].ToString(), 1);
                }

                #region 有效性校验

                //生产厂家供货公司维护增加特殊字符校验 by Sunjh 2010-8-25 {90875342-BE12-41fb-8F26-4EFF1889E7B2}
                string mStr = dr["单位名称"].ToString() + dr["联系方式"].ToString();

                if (this.isBankNeed)
                {
                    if (dr["开户银行"].ToString() == "")
                    {
                        MessageBox.Show(Language.Msg(dr["单位名称"].ToString() +" 开户银行不能为空"));
                        return false;
                    }

                    if (dr["开户帐号"].ToString() == "")
                    {
                        MessageBox.Show(Language.Msg(dr["单位名称"].ToString() + " 开户帐号不能为空"));
                        return false;
                    }
                    //生产厂家供货公司维护增加特殊字符校验 by Sunjh 2010-8-25 {90875342-BE12-41fb-8F26-4EFF1889E7B2}
                    mStr = mStr + dr["开户银行"].ToString() + dr["开户账号"].ToString();
                }

                if (this.isRelativeNeed)
                {
                    if (dr["联系方式"].ToString() == "")
                    {
                        MessageBox.Show(Language.Msg(dr["单位名称"].ToString() + " 联系方式不能为空"));
                        return false;
                    }                    
                }

                //生产厂家供货公司维护增加特殊字符校验 by Sunjh 2010-8-25 {90875342-BE12-41fb-8F26-4EFF1889E7B2}
                mStr = mStr + dr["地址"].ToString() + dr["备注"].ToString() + dr["自定义码"].ToString() + dr["GSP"].ToString();

                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(dr["单位名称"].ToString(), this.nameMaxLength))
                {
                    MessageBox.Show(Language.Msg(dr["单位名称"].ToString() + " 单位名称超长"));
                    return false;
                }

                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(dr["地址"].ToString(), this.addressMaxLength))
                {
                    MessageBox.Show(Language.Msg(dr["单位名称"].ToString() + " 单位地址超长"));
                    return false;
                }

                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(dr["联系方式"].ToString(), this.relativeMaxLength))
                {
                    MessageBox.Show(Language.Msg(dr["单位名称"].ToString() + " 单位联系方式超长"));
                    return false;
                }

                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(dr["GMP"].ToString(), this.gmpMaxLength))
                {
                    MessageBox.Show(Language.Msg(dr["单位名称"].ToString() + " 单位GMP超长"));
                    return false;
                }

                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(dr["GSP"].ToString(), this.gspMaxLength))
                {
                    MessageBox.Show(Language.Msg(dr["单位名称"].ToString() + " 单位GSP超长"));
                    return false;
                }

                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(dr["开户银行"].ToString(), this.bankMaxLength))
                {
                    MessageBox.Show(Language.Msg(dr["单位名称"].ToString() + " 单位开户银行超长"));
                    return false;
                }

                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(dr["开户帐号"].ToString(), this.accountMaxLength))
                {
                    MessageBox.Show(Language.Msg(dr["单位名称"].ToString() + " 单位开户帐号超长"));
                    return false;
                }

                //生产厂家供货公司维护增加特殊字符校验 by Sunjh 2010-8-25 {90875342-BE12-41fb-8F26-4EFF1889E7B2}
                string QueueName = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(mStr);
                if (QueueName != mStr)
                {
                    MessageBox.Show("不能输入特殊字符!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                #endregion

                i++;
            }
            //{2876B618-36A2-4faf-8DF1-7728D400ACA9} 重复公司名称判断
            foreach (string key in companyNameIndexDictionary.Keys)
            {
                if (companyNameIndexDictionary[key] > 1)
                {
                    MessageBox.Show(key + " 单位名称存在重复 请核对输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);//{52A48F33-7979-447d-9925-1B1B3389929A}
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 获取指定行的公司名称拼音码/五笔码信息
        /// </summary>
        /// <param name="iRow">指定行名称</param>
        /// <returns></returns>
        private int GetSpell(int iRow)
        {
            if (this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnSet.ColName].Text.ToString() == "")
            {
                return 1;
            }

            Neusoft.HISFC.Models.Base.Spell spCode = new Neusoft.HISFC.Models.Base.Spell();
            Neusoft.HISFC.BizLogic.Manager.Spell spellManager = new Neusoft.HISFC.BizLogic.Manager.Spell();

            spCode = (Neusoft.HISFC.Models.Base.Spell)spellManager.Get(this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnSet.ColName].Text.ToString());

            if (spCode != null && spCode.SpellCode != null)
            {
                if (spCode.SpellCode.Length > 10)
                    spCode.SpellCode = spCode.SpellCode.Substring(0, 10);
                if (spCode.WBCode.Length > 10)
                    spCode.WBCode = spCode.WBCode.Substring(0, 10);

                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnSet.ColSpell].Value = spCode.SpellCode;
                this.neuSpread1_Sheet1.Cells[iRow, (int)ColumnSet.ColWB].Value = spCode.WBCode;
            }

            return 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.Init();

                this.ShowData(this.type);
            }
            catch { }

            base.OnLoad(e);
        }
        
        private void txtQueryCode_TextChanged(object sender, EventArgs e)
        {
            this.ChangeItem();
        }

        private void fpCompany_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            if (e.Column == 1)
            {
                this.GetSpell(e.Row);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.neuSpread1.ContainsFocus)
            {
                if (keyData == Keys.Enter)
                {
                    if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColName)
                    {
                        this.GetSpell(this.neuSpread1_Sheet1.ActiveRowIndex);
                    }

                    this.neuSpread1_Sheet1.ActiveColumnIndex++;
                }

            }
            return base.ProcessDialogKey(keyData);
        }                     

        #region 枚举类

        /// <summary>
        /// 维护公司类型
        /// </summary>
        public enum CompanyType
        {
            生产厂家,
            供货公司
        }

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            /// <summary>
            /// 单位名称
            /// </summary>
            ColName,           
            /// <summary>
            /// 联系方式
            /// </summary>
            ColPhone,
            /// <summary>
            /// 开户银行
            /// </summary>
            ColBank,
            /// <summary>
            /// 帐号
            /// </summary>
            ColAccount,
            /// <summary>
            /// 加价率
            /// </summary>
            ColGrade,           
            /// <summary>
            /// 拼音码
            /// </summary>
            ColSpell,
            /// <summary>
            /// 五笔码
            /// </summary>
            ColWB,
            /// <summary>
            /// 自定义码
            /// </summary>
            ColUserCode,
            /// <summary>
            /// 有效
            /// </summary>
            ColValid,
            /// <summary>
            /// GSP
            /// </summary>
            ColGSP,
            /// <summary>
            /// GMP
            /// </summary>
            ColGMP,
            /// <summary>
            /// 地址
            /// </summary>
            ColAddress,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo,
            /// <summary>
            /// 编码
            /// </summary>
            ColID,
            /// <summary>
            /// 类型
            /// </summary>
            ColType

        }

        #endregion

    }
}
