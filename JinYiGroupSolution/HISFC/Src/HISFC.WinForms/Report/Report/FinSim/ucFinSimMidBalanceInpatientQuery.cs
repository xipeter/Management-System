using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.FinSim
{
    /// <summary>
    /// 医保住院中途结算患者查询
    /// 07-12-28 xuc
    /// </summary>
    public partial class ucFinSimMidBalanceInpatientQuery : Common.ucQueryBaseForDataWindow
    {
        public ucFinSimMidBalanceInpatientQuery()
        {
            InitializeComponent();
        }

        #region 私有成员
        /// <summary>
        /// 综合业务管理
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 合同单位
        /// </summary>
        private string pactUnit;

        /// <summary>
        /// 过滤字符串
        /// </summary>
        private string filterStr = "(fin_ipr_siinmaininfo_姓名 like '{0}%') or (name_spell like '{0}%')";
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnLoad()
        {
            #region 加载合同单位列表
            //合同单位列表
            ArrayList list = new ArrayList();
            //全部
            Neusoft.HISFC.Models.Base.Const all = new Neusoft.HISFC.Models.Base.Const();
            all.ID = "ALL";
            all.Name = "全部";
            all.SpellCode = "QB";
            all.WBCode = "WU";
            //加入合同单位列表
            list.Add(all);
            //list.AddRange(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PACTUNIT));
            //{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
            list.AddRange(manager.QueryPactUnitAll());
            //加入下拉列表
            this.neuComboBox1.alItems.AddRange(list);
            this.neuComboBox1.Items.AddRange(list.ToArray());
            //默认合同单位
            if (this.neuComboBox1.Items.Count > 0)
            {
                this.neuComboBox1.SelectedIndex = 0;
                this.pactUnit = this.neuComboBox1.SelectedItem.ID;
            }
            #endregion
            base.OnLoad();
        }
        #endregion

        #region 事件
        /// <summary>
        /// 住院号查询控件事件
        /// </summary>
        private void ucQueryInpatientNo1_myEvent()
        {
            if (this.ucQueryInpatientNo1.InpatientNo.Equals(""))
            {
                MessageBox.Show("该患者不存在！");
            }
            else
            {
                if (this.GetQueryTime() == -1)
                {
                    return;
                }
                //住院号查询控件按回车后直接检索信息,忽略合同单位
                this.dwMain.Retrieve(this.beginTime, this.endTime, this.ucQueryInpatientNo1.InpatientNo, this.pactUnit);
            }

        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }
            //点击查询按钮时直接按合同单位检索信息
            return base.OnRetrieve(this.beginTime, this.endTime, "ALL", this.pactUnit);
        }

        /// <summary>
        /// 过滤框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            string str = this.neuTextBox1.Text.Trim().Replace(@"\", "").ToUpper();
            if (str.Equals(""))
            {
                this.dwMain.SetFilter("");
                this.dwMain.Filter();
            }
            else
            {
                str = string.Format(this.filterStr, str);
                this.dwMain.SetFilter(str);
                this.dwMain.Filter();
            }
        }

        /// <summary>
        /// 合同单位选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pactUnit = this.neuComboBox1.SelectedItem.ID;

        }

        #endregion
    }
}

