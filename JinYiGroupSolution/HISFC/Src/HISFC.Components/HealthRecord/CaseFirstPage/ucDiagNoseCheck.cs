using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.HealthRecord.CaseFirstPage
{
    /// <summary>
    /// ucDiagNoseCheck<br></br>
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
    public partial class ucDiagNoseCheck : Form
    {
        public ucDiagNoseCheck()
        {
            InitializeComponent();
        }
        #region  全局变量
        #endregion
        #region 属性
        #endregion
        /// <summary>
        /// 初始化窗口
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int initDiangNoseCheck(ArrayList list)
        {
            try
            {
                ucDiagCheck.InitInfo();
                ucDiagCheck.LoadInfo(list);
                if (this.ucDiagCheck.RedAlarm)
                {
                    this.label1.Text = "保存失败 : 诊断缺少必填项（红色），请补充";
                }
                else
                {
                    this.label1.Text = "保存成功 : 诊断可能还有疏漏,请核查";
                }
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
        /// <summary>
        /// 如果有必须填写的项目 返回 true; 否则返回 false; 
        /// </summary>
        /// <returns></returns>
        public bool GetRedALarm()
        {
            return ucDiagCheck.RedAlarm;
        }

        private void FrmDiagNoseCheck_Activated(object sender, System.EventArgs e)
        {

        }

        private void tbReturn_Click(object sender, System.EventArgs e)
        {
            //关闭
            this.Close();
        }
    }
}