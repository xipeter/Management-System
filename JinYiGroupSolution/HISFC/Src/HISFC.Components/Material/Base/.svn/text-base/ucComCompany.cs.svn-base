using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using FarPoint.Win.Spread;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Models.Material;

namespace Neusoft.HISFC.Components.Material.Base
{
    /// <summary>		
    /// ucComCompany的摘要说明。<br></br>
    /// [功能描述: 供货公司维护]<br></br>
    /// [创 建 者: 李志涛]<br></br>
    /// [创建时间: 2007-11-26<br></br>
    /// 
    /// </summary>
    public partial class ucComCompany : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucComCompany()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 供应商信息类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.ComCompany comCompany = new Neusoft.HISFC.BizLogic.Material.ComCompany();
       
        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt = new DataTable();

        /// <summary>
        /// 维护的公司类别 
        /// </summary>
        private CompanyKind kind = CompanyKind.物资程序使用;

        /// <summary>
        /// 维护的公司类型 
        /// </summary>
        private CompanyType type = CompanyType.供货公司;

        /// <summary>
        /// 维护的公司编号 
        /// </summary>
        public string companyID;

        /// <summary>
        /// 供货商维护控件
        /// </summary>
        private ucComCompanyEdit ComEdit = null;
        private System.Windows.Forms.Form EditForm = null;

        /// <summary>
        /// 只读属性
        /// </summary>
        private bool isEditExpediency = true;
        #endregion

        #region 属性

        /// <summary>
        /// 维护的公司类型
        /// </summary>
        [Description("本窗口维护的公司类型"), Category("设置")]
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

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加", "新增供货商", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("删除", "删除供货商，保存后生效!", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);            
            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "增加")
            {
                this.Add();
            }
            else if (e.ClickedItem.Text == "删除")
            {
                this.DeleteData();
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
            if (this.fpCompany_Sheet1.Rows.Count > 0)
            {
                if (this.fpCompany.Export() == 1)
                {
                    MessageBox.Show("导出成功");
                }
            }

            return 1;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.ShowData(this.type,this.kind);

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

            im = this.fpCompany.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            //this.cmbLeach.AddItems(this.comCompany.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM));
            this.InitDataSet();

            return 1;
        }

        /// <summary>
        ///  初始化DataSet
        /// </summary>
        private void InitDataSet()
        {
            this.fpCompany_Sheet1.DataAutoSizeColumns = false;

            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBol = System.Type.GetType("System.Boolean");

            //在myDataTable中添加列
            this.dt.Columns.AddRange(new DataColumn[] {	    
                                                            new DataColumn( "公司编码",     dtStr),
                                                            new DataColumn( "公司名称",     dtStr),
                                                            new DataColumn( "公司地址",     dtStr),
                                                            new DataColumn( "公司电话",     dtStr),
                                                            new DataColumn( "GMP信息",      dtStr),
                                                            new DataColumn( "GSP信息",      dtStr),
                                                            new DataColumn( "拼音码",       dtStr),
                                                            new DataColumn( "五笔码",       dtStr),
                                                            new DataColumn( "自定义码",     dtStr),
                                                            new DataColumn( "类型",         dtStr),
                                                            new DataColumn( "开户银行",     dtStr),
                                                            new DataColumn( "开户帐号",     dtStr),
                                                            new DataColumn( "加价率",       dtStr),
                                                            new DataColumn( "备注",         dtStr),
                                                            new DataColumn( "是否有效",     dtStr),
                                                            new DataColumn( "执照有效期",   dtStr),
                                                            new DataColumn( "经营许可证有效期",dtStr),
                                                            new DataColumn( "税务登记证有效期",dtStr),
                                                            new DataColumn( "组织机构代码证有效期",dtStr)
											        });

            this.fpCompany_Sheet1.DataSource = this.dt.DefaultView;

            DataColumn[] keys = new DataColumn[1];
            keys[0] = dt.Columns["公司编码"];
            dt.PrimaryKey = keys;

        }

        /// <summary>
        /// 向数据表内加入数据
        /// </summary>
        /// <param name="company"></param>
        private void AddDataToTable(Neusoft.HISFC.Models.Material.MaterialCompany  company)
        {
            this.dt.Rows.Add(new object[] {           
                                              company.ID,           //公司编码
						                      company.Name ,        //公司名称
						                      company.Address ,     //公司地址
						                      company.TelCode,      //公司电话
						                      company.GMPInfo,      //GMP信息
						                      company.GSPInfo ,     //GSP信息
						                      company.SpellCode ,   //拼音码
						                      company.WBCode ,      //五笔码
						                      company.UserCode ,    //自定义码
						                      company.Type ,        //类型
						                      company.OpenBank ,    //开户银行
						                      company.OpenAccounts ,//开户帐号
                                              company.ActualRate.ToString() ,//加价率
						                      company.Memo,         //备注
                                              company.IsValid==true?"1":"0",//有效  
                                              company.BusinessDate.ToString(),
                                              company.ManageDate.ToString(),
                                              company.DutyDate.ToString(),
                                              company.OrgDate.ToString()
  
                                #region   备用
                                              //company.Oper.ID.ToString(),
                                              //company.OperTime.ToString(),
                                              //company.Extend1.ToString(),
                                              //company.Extend2.ToString(),
                                              //company.BusinessDate.ToString(),
                                              //company.ManageDate.ToString(),
                                              //company.DutyDate.ToString(),
                                              //company.OrgDate.ToString()
						                      //company.Kind ,        //公司类型
						                      //company.Coporation,  //公司法人
						                      //company.FaxCode,     //公司传真
						                      //company.NetAddress , //公司网址
						                      //company.EMail ,      //公司邮箱
						                      //company.LinkMan,    //联系人
						                      //company.LinkMail ,  //联系人邮箱
						                      //company.LinkTel,    //联系人电话
						                      //company.ISOInfo,    //ISO信息
                                #endregion             					                  
											 });

        }

        /// <summary>
        /// 从数据表内获取数据
        /// </summary>
        /// <param name="row">需获取数据的数据表行</param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Material.MaterialCompany GetDataFromTable(DataRow row)
        {
            Neusoft.HISFC.Models.Material.MaterialCompany company = new Neusoft.HISFC.Models.Material.MaterialCompany();
            company.ID = row["公司编码"].ToString();                            //公司编码
            company.Name = row["公司名称"].ToString();                          //公司名称
            company.Address = row["公司地址"].ToString();                           //公司地址
            company.TelCode = row["公司电话"].ToString();                       //联系方式
            company.GMPInfo = row["GMP信息"].ToString();                            //GMP信息
            company.GSPInfo = row["GSP信息"].ToString();                            //GSP信息
            company.SpellCode = row["拼音码"].ToString();                       //拼音码
            company.WBCode = row["五笔码"].ToString();                          //五笔码
            company.UserCode = row["自定义码"].ToString();                      //自定义码
            company.Type = ((int)this.type).ToString();                         //公司类型
            company.OpenBank = row["开户银行"].ToString();                      //开户银行
            company.OpenAccounts = row["开户帐号"].ToString();                  //开户帐号
            company.ActualRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["加价率"]);    //加价率
            company.Memo = row["备注"].ToString();                              //备注	
            company.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["是否有效"]);         //有效性
            company.BusinessDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(row["执照有效期"]);
            company.ManageDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(row["经营许可证有效期"]);
            company.DutyDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(row["税务登记证有效期"]);
            company.OrgDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(row["组织机构代码证有效期"]);
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
            this.fpCompany_Sheet1.Columns[(int)ColumnSet.ColGMP].Visible = true;

            this.fpCompany_Sheet1.Columns[(int)ColumnSet.ColGMP].Width = 120; 
        }

        /// <summary>
        /// 设置供货公司的显示格式
        /// </summary>
        private void SetCompany()
        {
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.fpCompany_Sheet1.Columns.Get(14).CellType = checkBoxCellType1;
            this.fpCompany_Sheet1.Columns.Get(0).Visible = false;
            this.fpCompany_Sheet1.Columns.Get(15).Visible = false;
            this.fpCompany_Sheet1.Columns.Get(16).Visible = false;
            this.fpCompany_Sheet1.Columns.Get(17).Visible = false;
            this.fpCompany_Sheet1.Columns.Get(18).Visible = false;
            this.fpCompany_Sheet1.Columns.Get(14).Visible = false;
            this.fpCompany_Sheet1.Columns.Get(9).Visible = false;

        }

        #endregion

        #region 方法
        
        /// <summary>
        /// 将传入数组中的数据显示Fp中
        /// </summary>
        public void ShowData(CompanyType type,CompanyKind kind)
        {
            //清空数据
            this.dt.Rows.Clear();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在加载数据,请稍候..."));
            Application.DoEvents();

            //取公司记录
            ArrayList alCompany = this.comCompany.QueryCompanyAppr(((int)type).ToString(), ((int)kind).ToString());
            if (alCompany == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("加载公司数据发生错误" + this.comCompany.Err));
                return;
            }

            Neusoft.HISFC.Models.Material.MaterialCompany company;

            for (int i = 0; i < alCompany.Count; i++)
            {
                company = alCompany[i] as Neusoft.HISFC.Models.Material.MaterialCompany;

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
            this.fpCompany_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        public void Add()
        {
            MaterialCompany company = null;
            company = new MaterialCompany();
            company.ID = companyID;

            this.ShowMaintenanceForm("I", company, true);
        }

        /// <summary>
        /// 删除一条公司记录
        /// </summary>
        public void DeleteData()
        {
            this.fpCompany_Sheet1.Rows.Remove(this.fpCompany_Sheet1.ActiveRowIndex, 1);
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
                queryCode = "%" + this.txtQueryCode.Text.Trim() + "%";

                string filter = "(拼音码 LIKE '" + queryCode + "') OR " +
                    "(五笔码 LIKE '" + queryCode + "') OR " +
                    "(自定义码 LIKE '" + queryCode + "') OR " +
                    "(公司名称 LIKE '" + queryCode + "') ";

                //设置过滤条件
                this.dt.DefaultView.RowFilter = filter;
                //this.SetCellType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public int Save()
        {
            this.fpCompany.StopCellEditing();

            foreach (DataRow dr in this.dt.Rows)
            {
                dr.EndEdit();
            }

            //定义数据库处理事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.comCompany.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            bool isUpdate = false; //判断是否更新或者删除过数据

            //取修改和增加的数据
            DataTable dataChanges = this.dt.GetChanges(DataRowState.Deleted);
            if (dataChanges != null)
            {
                dataChanges.RejectChanges();
                foreach (DataRow row in dataChanges.Rows)
                {
                    string companyID = row["公司编码"].ToString();        //公司编码		
                    //执行删除操作
                    if (this.comCompany.DeleteCompany(companyID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("删除供货公司" + row["公司名称"].ToString() + "发生错误" + this.comCompany.Err));
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

            //刷新数据
            this.ShowData(this.type,this.kind);

            return 1;

        }

        /// <summary>
        /// 获取指定行的公司名称拼音码/五笔码信息
        /// </summary>
        /// <param name="iRow">指定行名称</param>
        /// <returns></returns>
        private int GetSpell(int iRow)
        {
            if (this.fpCompany_Sheet1.Cells[iRow, (int)ColumnSet.ColName].Text.ToString() == "")
            {
                return 1;
            }

            Neusoft.HISFC.Models.Base.Spell spCode = new Neusoft.HISFC.Models.Base.Spell();
            Neusoft.HISFC.BizLogic.Manager.Spell spellManager = new Neusoft.HISFC.BizLogic.Manager.Spell();

            spCode = (Neusoft.HISFC.Models.Base.Spell)spellManager.Get(this.fpCompany_Sheet1.Cells[iRow, (int)ColumnSet.ColName].Text.ToString());

            if (spCode != null && spCode.SpellCode != null)
            {
                if (spCode.SpellCode.Length > 10)
                    spCode.SpellCode = spCode.SpellCode.Substring(0, 10);
                if (spCode.WBCode.Length > 10)
                    spCode.WBCode = spCode.WBCode.Substring(0, 10);

                this.fpCompany_Sheet1.Cells[iRow, (int)ColumnSet.ColSpell].Value = spCode.SpellCode;
                this.fpCompany_Sheet1.Cells[iRow, (int)ColumnSet.ColWB].Value = spCode.WBCode;
            }

            return 1;
        }

        /// <summary>
        /// 控件中增加显示一条数据
        /// </summary>
        /// <param name="obj"></param>
        public void AddNewRow(Neusoft.HISFC.Models.Material.MaterialCompany obj)
        {
            DataRow newRow = dt.NewRow();

            this.SetRow(newRow, obj);

            dt.Rows.Add(newRow);
        }

        /// <summary>
        /// 向DataSet中插入数据
        /// </summary>
        /// <param name="row"></param>
        /// <param name="myItem"></param>
        /// <returns></returns>
        private DataRow SetRow(DataRow row, Neusoft.HISFC.Models.Material.MaterialCompany company)
        {
            row["公司编码"] = company.ID ;                              //公司编码
            row["公司名称"] = company.Name;                             //公司名称
            row["公司地址"] = company.Address;                          //公司地址
            row["公司电话"] = company.TelCode;                          //联系方式
            row["GMP信息"] = company.GMPInfo;                           //GMP信息
            row["GSP信息"] = company.GSPInfo;                           //GSP信息
            row["拼音码"] = company.SpellCode;                          //拼音码
            row["五笔码"] = company.WBCode;                             //五笔码
            row["自定义码"] = company.UserCode;                         //自定义码
            row["开户银行"] = company.OpenBank;                         //开户银行
            row["开户帐号"] = company.OpenAccounts;                     //开户帐号
            row["加价率"] = company.ActualRate;                         //加价率
            row["备注"] = company.Memo;                                 //备注	
            row["是否有效"] = company.IsValid;                          //有效性
            row["执照有效期"]= company.BusinessDate;
            row["经营许可证有效期"] = company.ManageDate;
            row["税务登记证有效期"] = company.DutyDate;
            row["组织机构代码证有效期"] = company.OrgDate ;
            return row;

        }

        /// <summary>
        /// 修改数据
        /// </summary>
        public void Modify()
        {
            if (this.fpCompany_Sheet1.Rows.Count == 0)
                return;

            DataRow findRow;

            MaterialCompany myCompany = null;
            myCompany = this.comCompany.QueryCompanyByCompanyID(this.fpCompany_Sheet1.Cells[this.fpCompany_Sheet1.ActiveRowIndex, this.dt.Columns.IndexOf("公司编码")].Value.ToString(),"A","A");
  
            this.ShowMaintenanceForm("U", myCompany, true);
            findRow = dt.Rows.Find(myCompany.ID.ToString());
            if (myCompany.ID.ToString() != null)
            {
                //根据编码取全部信息并显示在列表中
                myCompany = comCompany.QueryCompanyByCompanyID(myCompany.ID.ToString(),"A","A");
                this.SetRow(findRow, myCompany);
            }
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        public void Copy()
        {
            if (this.fpCompany_Sheet1.Rows.Count == 0)
                return;

            MaterialCompany company = null;
            company = this.comCompany.QueryCompanyByCompanyID(this.fpCompany_Sheet1.Cells[this.fpCompany_Sheet1.ActiveRowIndex, this.dt.Columns.IndexOf("公司编码")].Value.ToString(),"A","A");

            company.ID = "";

            this.ShowMaintenanceForm("I", company, true);
        }


        #endregion

        #region 事件
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.Init();

                this.ShowData(this.type,this.kind);
            }
            catch { }

            base.OnLoad(e);
        }

        private void txtQueryCode_TextChanged(object sender, EventArgs e)
        {
            this.ChangeItem();
            this.SetCellType();

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
            if (this.fpCompany.ContainsFocus)
            {
                if (keyData == Keys.Enter)
                {
                    if (this.fpCompany_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColName)
                    {
                        this.GetSpell(this.fpCompany_Sheet1.ActiveRowIndex);
                    }

                    this.fpCompany_Sheet1.ActiveColumnIndex++;
                }

            }
            return base.ProcessDialogKey(keyData);
        }

        private void cmbLeach_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //DateTime dtSys = this.comCompany.GetDateTimeFromSysDateTime();

            DateTime dtSys = DateTime.Now.Date; //临时代替
            if (this.cmbLeach.SelectedIndex == 0)
            {
                if (this.dt.Rows.Count == 0) return;

                try
                {
                    string queryCode = "";
                    queryCode = "执照有效期 <" + "#" + dtSys + "#";

                    //设置过滤条件
                    this.dt.DefaultView.RowFilter = queryCode;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.cmbLeach.SelectedIndex == 1)
            {
                if (this.dt.Rows.Count == 0) return;

                try
                {
                    string queryCode = "";
                    queryCode = "经营许可证有效期 <" + "#" + dtSys + "#";

                    //设置过滤条件
                    this.dt.DefaultView.RowFilter = queryCode;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.cmbLeach.SelectedIndex == 2)
            {
                if (this.dt.Rows.Count == 0) return;

                try
                {
                    string queryCode = "";
                    queryCode = "税务登记证有效期 <" + "#" + dtSys + "#";

                    //设置过滤条件
                    this.dt.DefaultView.RowFilter = queryCode;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.cmbLeach.SelectedIndex == 3)
            {
                if (this.dt.Rows.Count == 0) return;

                try
                {
                    string queryCode = "";
                    queryCode = "组织机构代码证有效期 <" + "#" + dtSys + "#";

                    //设置过滤条件
                    this.dt.DefaultView.RowFilter = queryCode;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.SetCellType();

        }

        private void ucComCompanyEdit_MyInput(Neusoft.HISFC.Models.Material.MaterialCompany company)
        {
            this.AddNewRow(company);

        }

        private void fpMaterialQuery_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.isEditExpediency)	//拥有修改权限
            {
                this.Modify();
            }
        }

        //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
        private void cmbLeach_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbLeach.Text == "")
            {
                this.dt.DefaultView.RowFilter = "1=1";
            }
        }

        #endregion

        #region 枚举类
        /// <summary>
        /// 维护公司类别
        /// </summary>
        public enum CompanyKind
        {
            药库使用,
            物资程序使用
        }

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
            /// 单位编码
            /// </summary>
            ColID, 
            /// <summary>
            /// 单位名称
            /// </summary>
            ColName,
            /// <summary>
            /// 法人
            /// </summary>
            ColCoporation,
            /// <summary>
            /// 地址
            /// </summary>
            ColAddress,
            /// <summary>
            /// 联系方式
            /// </summary>
            ColPhone,
            /// <summary>
            /// 传真
            /// </summary>
            ColFaxCode,
            /// <summary>
            /// 网址
            /// </summary>
            ColNetAddress,
            /// <summary>
            /// 公司邮箱
            /// </summary>
            ColEMail,
            /// <summary>
            /// 联系人
            /// </summary>
            ColLinkMan,
            /// <summary>
            /// 联系人电话
            /// </summary>
            ColLinkTel,
            /// <summary>
            /// 联系人邮箱
            /// </summary>
            CollinkMail,
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
            /// 备注
            /// </summary>
            ColMemo,
            /// <summary>
            /// 类型
            /// </summary>
            ColType

        }

        #endregion

        #region 维护弹出窗口

        /// <summary>
        /// 维护弹出窗口 需继承自Material.Base.ucComCompanyEdit
        /// </summary>
        public Material.Base.ucComCompanyEdit ComCompanyEditPop
        {
            set
            {
                if (value != null && value as Material.Base.ucComCompanyEdit == null)
                {
                    System.Windows.Forms.MessageBox.Show("该维护控件需继承自Material.Base.ucComCompanyEdit");
                }
                else
                {
                    this.ComEdit = value as Material.Base.ucComCompanyEdit;

                    this.ComEdit.MyInput -= new ucComCompanyEdit.SaveInput(ucComCompanyEdit_MyInput);
                    this.ComEdit.MyInput += new ucComCompanyEdit.SaveInput(ucComCompanyEdit_MyInput);
                }
            }
        }
        /// <summary>
        /// 设置维护窗口
        /// </summary>
        private void InitMaintenanceForm()
        {
            if (this.ComEdit == null)
            {
                this.ComEdit = new Material.Base.ucComCompanyEdit();
                this.ComEdit.MyInput -= new Material.Base.ucComCompanyEdit.SaveInput(ucComCompanyEdit_MyInput);
                this.ComEdit.MyInput += new Material.Base.ucComCompanyEdit.SaveInput(ucComCompanyEdit_MyInput);
            }
            if (this.EditForm == null)
            {
                this.EditForm = new Form();
                this.EditForm.Width = this.ComEdit.Width + 10;
                this.EditForm.Height = this.ComEdit.Height + 25;
                this.EditForm.Text = "物品详细信息维护";
                this.EditForm.StartPosition = FormStartPosition.CenterScreen;
                this.EditForm.ShowInTaskbar = false;
                this.EditForm.HelpButton = false;
                this.EditForm.MaximizeBox = false;
                this.EditForm.MinimizeBox = false;
                this.EditForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            }


            this.ComEdit.Dock = DockStyle.Fill;
            this.EditForm.Controls.Add(this.ComEdit);
        }
        /// <summary>
        /// 维护窗口显示
        /// </summary>
        private void ShowMaintenanceForm(string inputType, Neusoft.HISFC.Models.Material.MaterialCompany company, bool isShow)
        {
            if (this.EditForm == null || this.ComEdit == null)
                this.InitMaintenanceForm();

            this.ComEdit.InputType = inputType;
            this.ComEdit.Company = company;
            this.ComEdit.ReadOnly = !this.isEditExpediency;
            this.ComEdit.Type = this.type;

            if (isShow)
            {
                this.EditForm.ShowDialog();
            }
        }

        #endregion

        

    }
}



