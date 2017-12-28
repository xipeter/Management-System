using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse.Inject
{
    /// <summary>
    /// ucDosageAlter<br></br>
    /// <Font color='#FF1111'>[功能描述:门诊注射拔针提醒{03E7916F-5AA8-4e95-BBE2-61EB6FDEB96C}]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-7-21]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public partial class ucDosageAlter : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 构造函数
        public ucDosageAlter()
        {
            InitializeComponent();
        }
        #endregion

        #region 私有变量

        /// <summary>
        /// 查询日期
        /// </summary>
        private DateTime queryDate = DateTime.Now;

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt = null;

        /// <summary>
        /// 注射业务层
        /// </summary>
        private HISFC.BizLogic.Nurse.Inject injectManager = new Neusoft.HISFC.BizLogic.Nurse.Inject();

        #endregion

        #region 属性

        /// <summary>
        /// 查询日期
        /// </summary>
        public DateTime QueryDate
        {
            get
            {
                return queryDate;
            }
            set
            {
                queryDate = value;
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.InitDataTable();
            this.timer1.Tick += new EventHandler(timer1_Tick);
            this.timer1.Start();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void Refresh()
        {
            this.timer1.Stop();

            ArrayList al = this.injectManager.QueryNeedDosageInjectRecord(this.queryDate);
            if (al == null)
            {
                MessageBox.Show("刷新注射完毕患者数据出错：" + this.injectManager.Err);
                return;
            }
            this.AddDataToTable(al);

            this.timer1.Start();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化数据表
        /// </summary>
        private void InitDataTable()
        {
            this.dt = new DataTable();
            this.dt.Columns.AddRange(new DataColumn[] { 
                new DataColumn("患者姓名",typeof(string)),
                new DataColumn("开单医生",typeof(string)),
                new DataColumn("登记时间",typeof(string)),
                new DataColumn("注射完成时间",typeof(string))
            });
            this.neuSpread1_Sheet1.DataSource = this.dt;
        }

        /// <summary>
        /// 填入数据
        /// </summary>
        /// <param name="al"></param>
        private void AddDataToTable(ArrayList al)
        {
            this.dt.Rows.Clear();
            //每个患者只保留最后一次拔针的注射记录
            Hashtable ht = new Hashtable();
            foreach (Neusoft.HISFC.Models.Nurse.Inject info in al)
            {
                string key = info.Patient.PID.CardNO;
                if (!ht.ContainsKey(key))
                {
                    Neusoft.HISFC.Models.Nurse.Inject lastInject = this.injectManager.QueryLastByPatient(info.Patient.PID.CardNO);
                    if (lastInject == null)
                    {
                        MessageBox.Show("查找患者" + info.Patient.Name + "的最后一次注射记录失败：" + this.injectManager.Err);
                        return;
                    }
                    ht.Add(key, lastInject);
                }
            }
            foreach (string key in ht.Keys)
            {
                Neusoft.HISFC.Models.Nurse.Inject info = ht[key] as Neusoft.HISFC.Models.Nurse.Inject;
                //增加一行
                DataRow dr = this.dt.NewRow();
                this.dt.Rows.Add(dr);
                dr["患者姓名"] = info.Patient.Name;
                dr["开单医生"] = info.Item.Order.Doctor.Name;
                dr["登记时间"] = info.Booker.OperTime.ToString("yyyy-MM-dd HH:mm:ss");
                dr["注射完成时间"] = info.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        #endregion
    }
}
