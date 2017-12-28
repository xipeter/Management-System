using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.HealthRecord
{
    public partial class ucDiagnoseCheck : UserControl
    {
        /// <summary>
        /// ucDiagnoseCheck<br></br>
        /// [功能描述: 病案诊断冲突结果提示]<br></br>
        /// [创 建 者: 张俊义]<br></br>
        /// [创建时间: 2007-04-20]<br></br>
        /// <修改记录 
        ///		修改人='' 
        ///		修改时间='yyyy-mm-dd' 
        ///		修改目的=''
        ///		修改描述=''
        ///  />
        /// </summary>
        public ucDiagnoseCheck()
        {
            InitializeComponent();
        }

        #region  全局变量
        private System.Drawing.Color alarmColr = System.Drawing.Color.Red;
        private bool redAlarm = false;
        #endregion

        #region  属性
        /// <summary>
        /// 如果有必须输入的项目, redAlarm 为 true;
        /// </summary>
        public bool RedAlarm
        {
            get
            {
                return redAlarm;
            }
        }
        /// <summary>
        /// 设置必须输入的项的背景色
        /// </summary>
        private System.Drawing.Color AlarmColr
        {
            get
            {
                return alarmColr;
            }
            set
            {
                alarmColr = value;
            }
        }
        #endregion
        /// <summary>
        /// 加载信息列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns>出错返回 -1 </returns>
        public int LoadInfo(ArrayList list)
        {
            if (list == null)
            {
                return -1;
            }
            foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in list)
            {
                ListViewItem item = new ListViewItem(obj.DiagInfo.ICD10.Name);
                item.SubItems.Add(obj.User02);
                if (obj.User01 == "2") //必须输入的 
                {
                    //设置背景为红色
                    item.BackColor = System.Drawing.Color.Red;
                    redAlarm = true;
                }
                listView1.Items.Add(item);
            }
            return 1;
        }
        /// <summary>
        /// 初始化控件 加载列头 
        /// </summary>
        /// <returns></returns>
        public int InitInfo()
        {
            //Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;
            // Create columns for the items and subitems.
            listView1.Columns.Add("诊断名称", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("提示信息", -2, HorizontalAlignment.Left);
            return 1;
        }
    }
}
