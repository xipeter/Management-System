using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述：化疗医嘱开立]
    /// [创 建 者：薛文进]
    /// [创建时间：2009-8-25]
    /// {1F2B9330-7A32-4da4-8D60-3A4568A2D1D8}
    /// </summary>
    public partial class ucAssayCure : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public ucAssayCure()
        {
            InitializeComponent();
        }

        #endregion

        #region 变量

        /// <summary>
        /// 化疗生成代理
        /// </summary>
        /// <param name="alOrders"></param>
        public delegate void MakeSuccessedHandler(System.Collections.ArrayList alOrders);

        /// <summary>
        /// 生成化疗医嘱
        /// </summary>
        public event MakeSuccessedHandler MakeSuccessed;

        /// <summary>
        /// 取医嘱流水号等等信息
        /// </summary>
        private Neusoft.HISFC.BizLogic.Order.Order OrderMgr = new Neusoft.HISFC.BizLogic.Order.Order();

        /// <summary>
        /// 设置一些医嘱信息
        /// </summary>
        private System.Collections.ArrayList orders = new System.Collections.ArrayList();

        #endregion

        #region 属性

        /// <summary>
        /// 设置一些医嘱信息
        /// </summary>
        public System.Collections.ArrayList Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 取化疗医嘱时间
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="injectDate"></param>
        /// <returns></returns>
        private List<Neusoft.HISFC.Models.Base.OperEnvironment> GetOrderDate(string strDate, DateTime injectDate)
        {
            //{7E8FD8F7-AB9D-47ce-A245-37F8BE2D023D} 异常处理 增加界面提示信息
            try
            {
                strDate = strDate.ToLower();//所有字母都转小写

                List<Neusoft.HISFC.Models.Base.OperEnvironment> listDate = new List<Neusoft.HISFC.Models.Base.OperEnvironment>();
                if (strDate.IndexOf('-') > 0)
                {
                    //例如: d1-d8,那么用-分隔后就是一个有两个元素的数组,0为开始日期,1为结束日期
                    //要求这个字符串必须连续,不能这样d1,d2,d3-d5,这种格式处理不了
                    string[] temp = strDate.Split(new char[] { '-' });
                    int begin = int.Parse(temp[0].Replace("d", "").Trim()) - 1; //从当前日期开始啊,所以减一
                    int end = int.Parse(temp[1].Replace("d", "").Trim()) - 1;   //既然开始日期减一了,那结束日期也必须啊

                    Neusoft.HISFC.Models.Base.OperEnvironment obj = null;
                    for (int i = begin; i <= end; i++)
                    {
                        obj = new Neusoft.HISFC.Models.Base.OperEnvironment();
                        obj.OperTime = injectDate.AddDays(i);
                        obj.ID = "d" + Convert.ToString(i + 1) + "(" + obj.OperTime.ToShortDateString() + ")";
                        listDate.Add(obj);
                    }
                }
                else if (strDate.IndexOf(',') > 0)
                {
                    //例如: d1,d2,d4,d8,那么用,分隔后就是一个数组
                    string[] temp = strDate.Split(new char[] { ',' });
                    int[] days = new int[temp.Length];

                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i] != "")
                        {
                            days[i] = int.Parse(temp[i].Replace("d", "").Trim()) - 1; //从当前日期开始啊,所以所有的值都需要减一
                        }
                    }

                    Neusoft.HISFC.Models.Base.OperEnvironment obj = null;
                    for (int i = 0; i < days.Length; i++)
                    {
                        obj = new Neusoft.HISFC.Models.Base.OperEnvironment();
                        obj.OperTime = injectDate.AddDays(days[i]);
                        obj.ID = "d" + Convert.ToString(days[i] + 1) + "(" + obj.OperTime.ToShortDateString() + ")";
                        listDate.Add(obj);
                    }
                }
                else
                {
                    MessageBox.Show("输入信息格式不正确，请参照蓝色提示信息输入正确信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return null;
                }

                return listDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入信息格式不正确，请参照蓝色提示信息输入正确信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return null;
            }
        }

        /// <summary>
        /// 有效性判断
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            if (this.dtpBeginDate.Value.Date < this.OrderMgr.GetDateTimeFromSysDateTime().Date)
            {
                MessageBox.Show("开始日期不能小于当前日期", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.txtDays.Text.Trim().Equals(""))
            {
                MessageBox.Show("请输入化疗天数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 生成化疗医嘱
        /// </summary>
        /// <returns></returns>
        private int SaveAssayCure()
        {
            DateTime currentTime = this.OrderMgr.GetDateTimeFromSysDateTime();//当前系统时间

            DateTime tempOrder = this.dtpBeginDate.Value;

            //取医嘱时间
            List<Neusoft.HISFC.Models.Base.OperEnvironment> listDays = this.GetOrderDate(this.txtDays.Text, tempOrder);
            if (listDays == null)
            {
                return -1;
            }

            System.Collections.ArrayList al = new System.Collections.ArrayList();
            Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
            string comboID = string.Empty;
            string preComboID = string.Empty;
            string preNewComboID = string.Empty;

            foreach (Neusoft.HISFC.Models.Base.OperEnvironment dt in listDays)
            {
                if (dt.OperTime.Date < currentTime.Date)
                {
                    MessageBox.Show("化疗时间不能小于当前时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }


                int rowIndex = 0;//肿瘤医院提的需求,在一组药里面只有第一条医嘱加上备注

                foreach (Neusoft.HISFC.Models.Order.Inpatient.Order obj in this.orders)
                {

                    order = obj.Clone();
                    order.SortID = 0;
                    if (obj.Combo.ID == preComboID)
                    {
                        order.Combo.ID = preNewComboID;
                    }
                    else
                    {
                        comboID = this.OrderMgr.GetNewOrderComboID();//嗯那
                        preComboID = obj.Combo.ID;
                        preNewComboID = comboID;
                        order.Combo.ID = comboID;
                    }
                    order.BeginTime = dt.OperTime;
                    order.Oper.OperTime = dt.OperTime;
                    order.ID = string.Empty;
                    if (rowIndex == 0)
                    {
                        order.Memo += dt.ID;
                        rowIndex++;
                    }
                    else
                    {
                        if (order.Memo == "")
                        {
                            order.Memo = string.Empty;
                        }
                    }

                    al.Add(order);//一条一条的搞啊,是不
                }
            }

            if (this.MakeSuccessed != null)
            {
                this.MakeSuccessed(al);
            }

            return 1;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!this.IsValid())
            {
                return;
            }

            if (this.orders == null)
            {
                MessageBox.Show("请在临时医嘱中选择项目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (SaveAssayCure() == -1)
            {
                return;
            }

            this.FindForm().DialogResult = DialogResult.OK;//外面要用的了

            this.FindForm().Close();
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        #endregion
    }
}
