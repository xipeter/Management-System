using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 设置医嘱分解时间]<br></br>
    /// [创 建 者: guanyx]<br></br>
    /// [创建时间: 2010-11-17]<br></br>
    /// <修改记录
    ///	修改人=''
    ///	修改时间='yyyy-mm-dd'
    ///	修改目的=''
    ///	修改描述=''
    /// />
    /// </summary>
    public partial class ucSetExecTime : Neusoft .FrameWork .WinForms.Controls .ucBaseControl 
    {
        public ucSetExecTime()
        {
            InitializeComponent();
        }
        #region 变量
        //参数控制是护士站维护还是信息科
        private bool isNurseStation = true;

        [Category("控件设置"), Description("是否是护士站，True:是 False:否")]
        public bool IsNurseStation
        {
            get
            {
                return isNurseStation;
            }
            set
            {
                isNurseStation = value;
            }
        }

        Neusoft.HISFC.BizLogic.Manager.Department dp = new Neusoft.HISFC.BizLogic.Manager.Department();
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
        string deptCode = "";
        string deptName = "";
        #endregion

        /// <summary>
        /// 加载界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSetExecTime_Load(object sender, EventArgs e)
        {
            //如果是护士站
            if (this.isNurseStation == true)
            {
                //获取登陆科室信息
                deptCode = ((HISFC.Models.Base.Employee)dp.Operator).Dept.ID;
                deptName = ((HISFC.Models.Base.Employee)dp.Operator).Dept.Name;
            }
            //获取参数信息
            obj = manager.GetConstant("SETEXECTIME", deptCode);
            this.lblTitle.Text = deptName + "医嘱分解时间";
            if (deptCode == "")
            {
            }
            else
            {
                if (obj.ID == "")
                {
                    MessageBox.Show("本科室尚未设置医嘱分解时间，请进入界面后点【初始化】按钮！");
                }
                if (obj.Memo == "12")
                {
                    this.lblShowTime.Text = deptName + "的分解时间：当日 12:00 到次日 12:00 ";
                }
                else if (obj.Memo == "0")
                {
                    this.lblShowTime.Text = deptName + "的分解时间：当日 00:00 到次日 00:00 ";
                }
                else
                {
                    this.lblShowTime.Text = deptName + "的分解时间：当日______到次日______";
                }
            }
        }

        /// <summary>
        /// 科室更新分解时间常数
        /// </summary>
        /// <returns></returns>
        private int Save()
        {
            Neusoft.HISFC.Models.Base.Const cons = new Neusoft.HISFC.Models.Base.Const();
            string type = "SETEXECTIME";
            string code = "";
            string name = "";
            string mark = "";

            if (deptCode != "")
            {
                code = deptCode;
                name = deptName;
                if (this.cmbTime.SelectedIndex == 0)
                {
                    mark = "12";
                }
                else if (this.cmbTime.SelectedIndex == 1)
                {
                    mark = "0";
                }
                else
                {
                    MessageBox.Show("请选择一个分解时间！");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("请选择一个科室！");
                return -1;
            }
            cons.ID = code;
            cons.Name = name;
            cons.Memo = mark;
            try
            {
                return manager.UpdateConstant(type, cons);
            }
            catch (Exception e)
            {
                MessageBox.Show("更新常数失败！" + e.Message.ToString());
                return -1;
            }
        }

        /// <summary>
        /// 科室初始化分解时间常数
        /// </summary>
        /// <returns></returns>
        private int InitDic()
        {
            if ((manager.GetConstant("SETEXECTIME", deptCode)).ID == "")
            {
                Neusoft.HISFC.Models.Base.Const cons = new Neusoft.HISFC.Models.Base.Const();
                if (deptCode != "")
                {
                    cons.ID = deptCode;
                    cons.Name = deptName;
                    cons.Memo = "12";
                    try
                    {
                        return manager.InsertConstant("SETEXECTIME", cons);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("插入新常数失败！" + e.Message.ToString());
                        return -1;
                    }
                }
                else
                {
                    MessageBox.Show("请选择一个科室！");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("本科室的分解时间已经完成了初始化！无需再次初始化！");
                return -1;
            }
          
               
          
            
        }

        /// <summary>
        /// 点击初始化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            int i = this.InitDic();
            if (i != -1)
            {
                this.ucSetExecTime_Load(null, null);
                MessageBox.Show("初始化成功，初始值为：12:00");
            }
        }

        /// <summary>
        /// 点击保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("此次修改影响到医嘱的分解，操作请慎重，不要频繁修改！\n\r                  是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                int i = this.Save();
                if (i != -1)
                {
                    this.ucSetExecTime_Load(null, null);
                    MessageBox.Show("更新成功！请注意上面显示的分解时间！");
                }
            }
        }

        /// <summary>
        /// 选择左侧树事件
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            if (e != null&&e.Tag!=null)
            {
                deptCode = e.Tag.ToString();
                deptName = e.Text;
                this.ucSetExecTime_Load(null, null);
            }
            return base.OnSetValue(neuObject, e);
        }

    }
}
