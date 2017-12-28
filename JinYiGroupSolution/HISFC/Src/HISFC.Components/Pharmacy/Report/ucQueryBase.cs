using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy.Report
{
    /// <summary>
    /// [功能描述: 药品基础查询控件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-10]<br></br>
    /// </summary>
    public partial class ucQueryBase : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucQueryBase()
        {
            InitializeComponent();
        }

        #region 参数属性

        /// <summary>
        /// 统计起始时间
        /// </summary>
        public DateTime BeginDate
        {
            get
            {
                return Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtpBegin.Text);
            }
            set
            {
                this.dtpBegin.Value = value;
            }
        }

        /// <summary>
        /// 统计截至时间
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtpEnd.Text);
            }
            set
            {
                this.dtpEnd.Value = value;
            }
        }

        /// <summary>
        /// 参数项目1
        /// </summary>
        public string FirstItemData
        {
            get
            {
                if (this.cmbItem1.Tag != null)
                {
                    return this.cmbItem1.Tag.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.cmbItem1.Tag = value;
            }
        }

        /// <summary>
        /// 参数项目2
        /// </summary>
        public string SecondItemData
        {
            get
            {
                if (this.cmbItem2.Tag != null)
                {
                    return this.cmbItem2.Tag.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.cmbItem2.Tag = value;
            }
        }

        /// <summary>
        /// 参数项目3
        /// </summary>
        public string ThirdItemData
        {
            get
            {
                if (this.cmbItem3.Tag != null)
                {
                    return this.cmbItem3.Tag.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.cmbItem3.Tag = value;
            }
        }


        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {           
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.Query();

            return base.OnQuery(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            return 1;
        }

        #endregion

        /// <summary>
        /// DataManager业务处理
        /// </summary>
        protected Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

        /// <summary>
        /// 设置数据初始化
        /// </summary>
        /// <param name="itemIndex">需设置Item索引 取值范围 0 1 2</param>
        /// <param name="customItemType">数据类型</param>
        /// <param name="customTitle">Item标题</param>
        /// <param name="alCustomData">Item数据</param>
        /// <returns>成功返回1 失败返回－1</returns>
        protected virtual int InitItemData(int itemIndex,CustomItemTypeEnum customItemType,string customTitle,ArrayList alCustomData)
        {
            ArrayList alData = new ArrayList();
            string itemTitle = customTitle;

            #region 加载基础数据

            if (customItemType == CustomItemTypeEnum.Drug)
            {
                Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                List<Neusoft.HISFC.Models.Pharmacy.Item> drugList = itemManager.QueryItemList(false);
                if (drugList == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载药品信息发生错误" + itemManager.Err));
                    return -1;
                }
                alData = new ArrayList(drugList.ToArray());
                itemTitle = "查询药品";
            }
            else if (customItemType == CustomItemTypeEnum.Dept)
            {
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                alData = deptManager.GetDeptmentAll();
                if (alData == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载科室信息发生错误" + deptManager.Err));
                    return -1;
                }
                itemTitle = "查询科室";
            }
            else if (customItemType == CustomItemTypeEnum.Employee)
            {
                Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
                alData = personManager.GetEmployeeAll();
                if (alData == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载人员信息发生错误" + personManager.Err));
                    return -1;
                }
                itemTitle = "查询人员";
            }
            else
            {
                alData = alCustomData;
            }

            #endregion

            switch (itemIndex)
            {
                case 0:
                    this.lbItem1.Text = itemTitle;
                    this.cmbItem1.AddItems(alData);

                    this.lbItem1.Visible = true;
                    this.cmbItem1.Visible = true;
                    break;
                case 1:
                    this.lbItem2.Text = itemTitle;
                    this.cmbItem2.AddItems(alData);

                    this.lbItem2.Visible = true;
                    this.cmbItem2.Visible = true;
                    break;
                case 2:
                    this.lbItem3.Text = itemTitle;
                    this.cmbItem3.AddItems(alData);

                    this.lbItem3.Visible = true;
                    this.cmbItem3.Visible = true;
                    break;
            }

            return 1;
        }

        /// <summary>
        /// 获取Sql索引
        /// </summary>
        /// <returns></returns>
        protected virtual string GetSqlIndex()
        {
            return null;
        }

        /// <summary>
        /// 获取需执行的Sql语句索引
        /// </summary>
        /// <param name="sqlIndex"></param>
        /// <returns></returns>
        protected virtual string GetExecSql(string sqlIndex)
        {
            string strSQL = "";
            if (this.dataManager.Sql.GetSql(sqlIndex, ref strSQL) == -1)
            {
                return null;
            }

            return strSQL;
        }

        /// <summary>
        /// sql语句格式化
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected virtual string FormatExecSql(string sql)
        {
            return sql; 
        }

        /// <summary>
        /// 执行Sql语句 获取DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected virtual DataSet QueryDataSet(string sql)
        {
            DataSet ds = new DataSet();

            if (this.dataManager.ExecQuery(sql, ref ds) == -1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("执行Sql获取查询数据发生错误"));
                return null;
            }
            
            return ds;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public virtual int Query()
        {
            string sqlIndex = this.GetSqlIndex();

            string sql = this.GetExecSql(sqlIndex);
            if (sql == null)
            {
                MessageBox.Show("根据Sql索引：" + sqlIndex + " 获取Sql语句失败");
                return -1;
            }

            sql = this.FormatExecSql(sql);
            if (sql == null)
            {
                return -1;
            }

            DataSet ds = this.QueryDataSet(sql);
            if (ds == null)
            {
                return -1;
            }

            this.neuSpread1_Sheet1.DataSource = ds;

            return 1;
        }

        /// <summary>
        /// 导出
        /// </summary>
        public virtual void Export()
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("导出成功"));
                return;
            }
        }
    }

    /// <summary>
    /// 项目类型
    /// </summary>
    public enum CustomItemTypeEnum
    {
        /// <summary>
        /// 药品
        /// </summary>
        Drug,
        /// <summary>
        /// 科室
        /// </summary>
        Dept,
        /// <summary>
        /// 人员
        /// </summary>
        Employee,
        /// <summary>
        /// 自定义
        /// </summary>
        Custom
    }
}
