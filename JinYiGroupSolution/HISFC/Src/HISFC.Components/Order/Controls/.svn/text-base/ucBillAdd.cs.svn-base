using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.Controls
{
    public partial class ucBillAdd : UserControl
    {
        private ArrayList arr = new ArrayList();
        private Neusoft.FrameWork.Public.ObjectHelper helper;
        private cResult r = new cResult();
        public ArrayList alExecBill = new ArrayList();
        public Neusoft.FrameWork.Models.NeuObject objExecBill = new Neusoft.FrameWork.Models.NeuObject();
        #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
        private Neusoft.FrameWork.Models.NeuObject aExecBill = new Neusoft.FrameWork.Models.NeuObject();
        private ArrayList alExecBillNames = new ArrayList();
        public ArrayList AlExecBillNames
        {
            get
            {
                return this.alExecBillNames;
            }
            set
            {
                alExecBillNames = value;
            }
        }
        #endregion
        public ucBillAdd()
        {
            InitializeComponent();
        }

        public ucBillAdd(cResult r)
            : this()
        {
            this.r = r;
        }

        public ucBillAdd(Neusoft.FrameWork.Models.NeuObject aExecBill, ArrayList alExecBillNames)
            : this()
        {
            this.aExecBill = aExecBill;
            this.alExecBillNames = alExecBillNames;
        }

        /// <summary>
        /// 判断输入的数据是否null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsNull(Neusoft.FrameWork.WinForms.Controls.NeuTextBox obj)
        {
            if (obj.Text.Trim() != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("文本框不能为空！"));
                return false;
            }
        }

        private void ucBillAdd_Load(object sender, EventArgs e)
        {
            helper = new Neusoft.FrameWork.Public.ObjectHelper(this.alExecBill);
            arr = r.al;
            txtExecBillName.Text = r.Result1;
            string ID = r.Result2;
            if (ID.Trim() != "")
            {
                Neusoft.FrameWork.Models.NeuObject obj = helper.GetObjectFromID(ID);
                txtExecBillName.Tag = r.Result2;
                this.txtMemo.Text = obj.User01;//执行单备注
                if (obj.User02 != "")
                    this.cmbStyle.SelectedIndex = System.Convert.ToInt16(obj.User02);//执行单分类
            }
            else
            {
                txtExecBillName.Tag = null;
                this.cmbStyle.SelectedIndex = 1;
                this.txtMemo.Text = "";
            }
        }

        private void EventResultChanged(ArrayList al)
        {

        }

        private bool IsRepeat()
        {
            bool bRet = true;
            for (int i = 0; i < arr.Count; i++)
            {
                if (txtExecBillName.Text.Trim() == arr[i].ToString().Trim())
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("名字重复！"));
                    bRet = false;
                }
            }
            return bRet;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtExecBillName.Text.Trim() == "" || this.txtExecBillName.Text.Length == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("执行单名称不能为空"));
                return;
            }
            if (this.cmbStyle.Text.Length == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("执行单类别不能为空"));
                return;
            }
            Neusoft.HISFC.BizLogic.Order.ExecBill oExecBill = new Neusoft.HISFC.BizLogic.Order.ExecBill();
            if (txtExecBillName.Tag == null)
            {
                if (IsNull(txtExecBillName) && IsRepeat())
                {
                    this.objExecBill.Name = this.txtExecBillName.Text.Trim();
                    #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护

                    if (this.chkItemBill.Checked)
                    {
                        this.objExecBill.Memo = "1";//项目执行单
                    }
                    else
                    {
                        this.objExecBill.Memo = "0";//非项目执行单
                    }

                    #endregion
                    this.objExecBill.User01 = this.txtMemo.Text;//备注
                    this.objExecBill.User02 = this.cmbStyle.SelectedIndex.ToString();//类型
                    r.Result1 = txtExecBillName.Text;
                    #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护

                    Neusoft.HISFC.Models.Base.Employee empl = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
                    if (oExecBill.SetExecBill(this.objExecBill, empl.Nurse.ID) < 0)
                    {
                        MessageBox.Show("添加新执行单错误！:" + oExecBill.Err);
                        this.objExecBill = null;
                    }

                    #endregion
                    this.FindForm().Close();
                }
            }
            else
            {
                string strId = txtExecBillName.Tag.ToString();
                if (txtMemo.Text != "")
                    txtMemo.Text = txtMemo.Text.Trim();
                if (oExecBill.UpdateExecBillName(strId, txtExecBillName.Text.Trim(), txtMemo.Text, this.cmbStyle.SelectedIndex.ToString()) != -1)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新成功！"));
                    r.Result1 = txtExecBillName.Text;
                    this.FindForm().Close();
                }
                else
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新失败"));
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}