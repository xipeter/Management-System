using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Preparation
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 常用数据选择组件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-03]<br></br>
    /// <说明>
    /// </说明>
    /// </summary>
    public partial class ucChooseData : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucChooseData()
        {
            InitializeComponent();
        }

        #region 静态公开函数

        /// <summary>
        /// 目标科室集合
        /// </summary>
        private static System.Collections.ArrayList alTargetDeptList = null;

        /// <summary>
        /// 入库科室、设置信息选择
        /// </summary>
        /// <param name="stockDept">库存科室</param>
        /// <param name="inTargetDept">入库目标科室</param>
        /// <param name="isNeedApply">是否需要发送申请</param>
        /// <returns>成功返回1 失败返回-1</returns>
        internal static int ChooseInputTargetData(Neusoft.FrameWork.Models.NeuObject stockDept, ref Neusoft.FrameWork.Models.NeuObject inTargetDept, out bool isNeedApply)
        {
            isNeedApply = false;

            if (alTargetDeptList == null)
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager privInOutManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                alTargetDeptList = privInOutManager.GetPrivInOutDeptList(stockDept.ID, "0320");
                if (alTargetDeptList == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(privInOutManager.Err));
                    return -1;
                }
            }

            ArrayList alTarget = new ArrayList();
            foreach (Neusoft.HISFC.Models.Base.PrivInOutDept privInOutDept in alTargetDeptList)
            {
                Neusoft.FrameWork.Models.NeuObject offerInfo = new Neusoft.FrameWork.Models.NeuObject();
                offerInfo.ID = privInOutDept.Dept.ID;			    //供货单位编码
                offerInfo.Name = privInOutDept.Dept.Name;		    //供货单位名称
                offerInfo.Memo = privInOutDept.Memo;		    //备注

                alTarget.Add(offerInfo.Clone());
            }

            alTarget.Add(inTargetDept.Clone());

            using (ucChooseData uc = new ucChooseData())
            {
                uc.ComboxLabel = "入库目标科室";
                uc.ComboxData = alTarget;
                uc.ComboxSelectTag = inTargetDept.ID;

                uc.CheckLabel = "仅发送入库申请而不是直接入库";
                uc.CheckChooseChecked = isNeedApply;

                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "入库信息设置";
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                if (uc.Result == DialogResult.OK)
                {
                    inTargetDept.ID = uc.ComboxSelectTag.ToString();
                    inTargetDept.Name = uc.ComboxSelectText;

                    isNeedApply = uc.CheckChooseChecked;
                }
                else
                {
                    return -1;
                }
            }

            return 1;
        }

        #endregion

        /// <summary>
        /// 结果选择
        /// </summary>
        private DialogResult rs = DialogResult.Cancel;

        #region 属性

        /// <summary>
        /// Combox对应Label
        /// </summary>
        public string ComboxLabel
        {
            set
            {
                this.lbTarget.Text = value;
            }
        }

        /// <summary>
        /// CheckBox 的 Label
        /// </summary>
        public string CheckLabel
        {
            set
            {
                this.ckChoose.Text = value;
            }
        }

        /// <summary>
        /// Combox 数据源
        /// </summary>
        public System.Collections.ArrayList ComboxData
        {
            set
            {
                if (value != null)
                {
                    this.cmbData.AddItems(value);
                }
            }
        }

        /// <summary>
        /// Combox 当前选择项 Tag
        /// </summary>
        public object ComboxSelectTag
        {
            get
            {
                return this.cmbData.Tag;
            }
            set
            {
                this.cmbData.Tag = value;
            }
        }

        /// <summary>
        /// Combox 当前选择项 Text
        /// </summary>
        public string ComboxSelectText
        {
            get
            {
                return this.cmbData.Text;
            }
            set
            {
                this.cmbData.Text = value;
            }
        }

        /// <summary>
        /// CheckBox 当前是否选中
        /// </summary>
        public bool CheckChooseChecked
        {
            get
            {
                return this.ckChoose.Checked;
            }
            set
            {
                this.ckChoose.Checked = value;
            }
        }

        /// <summary>
        /// 结果值
        /// </summary>
        public DialogResult Result
        {
            get
            {
                return this.rs;
            }
        }

        #endregion

        /// <summary>
        /// 关闭
        /// </summary>
        protected void Close()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ComboxSelectTag == null || this.ComboxSelectTag.ToString() == "")
            {
                MessageBox.Show("请选择入库目标科室");
            }

            this.rs = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.rs = DialogResult.Cancel;

            this.Close();
        }
    }
}
