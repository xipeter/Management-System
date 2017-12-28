using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    internal delegate void InsertSuccessedHandler();
    /// <summary>
    /// 这个控件是给(科室常用项目维护时用的,在程序集外部没用,所以internal
    /// </summary>
    internal partial class ucDeptItem : UserControl
    {
        private Neusoft.HISFC.BizLogic.Manager.DeptItem diBusiness = new Neusoft.HISFC.BizLogic.Manager.DeptItem();
        public event InsertSuccessedHandler InsertSuccessed;

        /// <summary>
        /// 存放单位标识
        /// </summary>
        private string UnitFlag = "";

        public ucDeptItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 供外部调用,根据参数初始化窗体
        /// </summary>
        /// <param name="deptItem">科常用项目对象</param>
        public void ShowWindow(Neusoft.HISFC.Models.Base.DeptItem deptItem)
        {
            this.tbItemCode.Text = deptItem.ItemProperty.ID;
            this.tbItemName.Text = deptItem.ItemProperty.Name;

            this.UnitFlag = deptItem.UnitFlag;

            //this.ckbUnitFlag.Checked = deptItem.UnitFlag.Trim().Equals("明细") ? true : false;
            this.tbBookLocate.Text = deptItem.BookLocate;

            if (deptItem.BookTime == "" || deptItem.BookTime == null)
            {
                this.dtBookTime.Value = DateTime.Now;
            }
            else
            {
                this.dtBookTime.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime(deptItem.BookTime);
            }

            this.tbExecLocate.Text = deptItem.ExecuteLocate;

            if (deptItem.ReportDate == "" || deptItem.ReportDate == null)
            {
                this.dtReportTime.Value = DateTime.Now;
            }
            else
            {
                this.dtReportTime.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime(deptItem.ReportDate);
            }
            
            this.ckbHurtFlag.Checked = deptItem.HurtFlag.Trim().Equals("有") ? true : false;
            this.ckbSelfBookFlag.Checked = deptItem.SelfBookFlag.Trim().Equals("是") ? true : false;
            this.ckbReasonableFlag.Checked = deptItem.ReasonableFlag.Trim().Equals("需要") ? true : false;
            this.ckbStat.Checked = deptItem.IsStat.Trim().Equals("需要") ? true : false;
            this.ckbAutoBook.Checked = deptItem.IsAutoBook.Trim().Equals("需要") ? true : false;
            this.tbSpeciality.Text = deptItem.Speciality;
            this.tbMeaning.Text = deptItem.ClinicMeaning;
            this.tbSampleKind.Text = deptItem.SampleKind;
            this.tbSampleWay.Text = deptItem.SampleWay;
            this.tbSampleUnit.Text = deptItem.SampleUnit;
            this.ntSampleQty.Text = deptItem.SampleQty.ToString();
            this.tbContainer.Text = deptItem.SampleContainer;
            this.tbScope.Text = deptItem.Scope;
            this.tbItemTime.Text = deptItem.ItemTime;
            this.tbMemo.Text = deptItem.Memo;
            //
            this.tbCustomName.Text = deptItem.CustomName;
        }
        /// <summary>
        /// 校验 
        /// by niuxy
        /// </summary>
        /// <returns></returns>
        private int valid()
        {
            //采样方法
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbSampleWay.Text, 200) == false)
            {
                MessageBox.Show("采样方法过长，最长支持100个汉字");
                return -1;
            }
            //临床意义
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbMeaning.Text, 200) == false)
            {
                MessageBox.Show("临床意义过长，最长支持100个汉字");
                return -1;
            }

            //标本
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbSampleKind.Text,200) == false)
            {
                MessageBox.Show("标本过长，最长支持100个汉字");
                return -1;
            }
            //所属专业
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbSpeciality.Text, 20) == false)
            {
                MessageBox.Show("所属专业字段过长，最长支持10个汉字");
                return -1;
            }

            //标本单位
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbSampleUnit.Text, 20) == false)
            {
                MessageBox.Show("标本单位过长，最长支持10个汉字");
                return -1;
            }

            //标本容器
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbContainer.Text, 200) == false)
            {
                MessageBox.Show("标本容器过长，最长支持100个汉字");
                return -1;
            }
            //正常范围
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbScope.Text, 200) == false)
            {
                MessageBox.Show("正常范围过长，最长支持100个汉字");
                return -1;
            }
            //注意事项
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbMemo.Text, 4000) == false)
            {
                MessageBox.Show("注意事项过长，最长支持2000个汉字");
                return -1;
            }
            //正常范围
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbScope.Text, 200) == false)
            {
                MessageBox.Show("正常范围过长，最长支持100个汉字");
                return -1;
            }
            //科内名称
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbCustomName.Text, 100) == false)
            {
                MessageBox.Show("科内名称过长，最长支持50个汉字");
                return -1;
            }
            //预约地点
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbBookLocate.Text, 100) == false)
            {
                MessageBox.Show("预约地点过长，最长支持50个汉字");
                return -1;
            }
            
            //执行地点
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbBookLocate.Text, 100) == false)
            {
                MessageBox.Show("执行地点过长，最长支持50个汉字");
                return -1;
            }
            

            //执行地点
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbItemTime.Text, 100) == false)
            {
                MessageBox.Show("项目执行所需要时间，最长支持25位");
                return -1;
            }
            return 0;
        }
        private Neusoft.HISFC.Models.Base.DeptItem SaveButtonHandler()
        {
            if (this.valid() == -1)
            {
                return null;
            }
            Neusoft.HISFC.Models.Base.DeptItem deptItem = new Neusoft.HISFC.Models.Base.DeptItem();

            deptItem.Dept.ID = this.Tag.ToString();//根据这上决定是更新还是保存,科室编号

            deptItem.ItemProperty.ID = this.tbItemCode.Text;
            deptItem.ItemProperty.Name = this.tbItemName.Text;

            deptItem.UnitFlag = this.UnitFlag;

            //deptItem.UnitFlag = this.ckbUnitFlag.Checked ? "1" : "2";
            deptItem.BookLocate = this.tbBookLocate.Text;

            deptItem.BookTime = this.dtBookTime.Value.ToString();

            deptItem.ExecuteLocate = this.tbExecLocate.Text;

            deptItem.ReportDate = this.dtReportTime.Value.ToString();

            deptItem.HurtFlag = this.ckbHurtFlag.Checked ? "0" : "1";
            deptItem.SelfBookFlag = this.ckbSelfBookFlag.Checked ? "0" : "1";
            deptItem.ReasonableFlag = this.ckbReasonableFlag.Checked ? "0" : "1";
            deptItem.IsStat = this.ckbStat.Checked ? "0" : "1";
            deptItem.IsAutoBook = this.ckbAutoBook.Checked ? "0" : "1";
            //if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.tbSpeciality.Text, 20))
            //{
                deptItem.Speciality = this.tbSpeciality.Text;
            //}
            //else
            //{
            //    MessageBox.Show("所属专业字段过长", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.tbSpeciality.Focus();
            //    return null;
            //}
            
            deptItem.ClinicMeaning = this.tbMeaning.Text;
            deptItem.SampleKind = this.tbSampleKind.Text;
            deptItem.SampleWay = this.tbSampleWay.Text;
            deptItem.SampleUnit = this.tbSampleUnit.Text;

            deptItem.SampleQty = Convert.ToDecimal(this.ntSampleQty.NumericValue);

            deptItem.SampleContainer = this.tbContainer.Text;
            deptItem.Scope = this.tbScope.Text;
            deptItem.ItemTime = this.tbItemTime.Text;
            deptItem.Memo = this.tbMemo.Text;
            //
            deptItem.CustomName = this.tbCustomName.Text;

            return deptItem;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.Models.Base.DeptItem deptItem = this.SaveButtonHandler();

            if (deptItem == null)
            {
                return;
            }

            if (deptItem.Dept.ID == "" || deptItem.Dept.Name == null)
            {

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                //t.BeginTransaction();

                this.diBusiness.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.diBusiness.InsertItem(deptItem) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据失败"));
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();;
                if (this.InsertSuccessed != null)
                {
                    InsertSuccessed();
                }
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据成功"));
                this.FindForm().Close();
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                //t.BeginTransaction();

                this.diBusiness.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.diBusiness.UpdateItem(deptItem) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据失败"));
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();;
                if (this.InsertSuccessed != null)
                {
                    InsertSuccessed();
                }
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据成功"));
                this.FindForm().Close();
            }
            //更新操作
        }
    }
}
