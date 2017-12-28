using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Operation
{
    public partial class frmChooseGroupDetails : Form
    {
        public frmChooseGroupDetails()
        {
            InitializeComponent();
        }

        private Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        private string groupID = string.Empty;

        public string GroupID
        {
            get { return groupID; }
            set
            {
                groupID = value;
                this.ShowDetail(groupID);
            }
        }

        private ArrayList alReturnDetails = null;

        public ArrayList AlReturnDetails
        {
            get { return alReturnDetails; }
            set { alReturnDetails = value; }
        }

        /// <summary>
        /// 显示组套明细
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        private int ShowDetail(string groupID)
        {
            Neusoft.HISFC.BizLogic.Manager.ComGroupTail detailManager = new Neusoft.HISFC.BizLogic.Manager.ComGroupTail();
            //组套明细
            ArrayList details = this.managerIntegrate.QueryGroupDetailByGroupCode(groupID);
            if (details == null)
            {
                MessageBox.Show("提取组套明细失败 " + detailManager.Err);
                return -1;
            }

            if (neuSpread1_Sheet1.Rows.Count > 0)
                neuSpread1_Sheet1.Rows.Remove(0, neuSpread1_Sheet1.Rows.Count);
            foreach (Neusoft.HISFC.Models.Fee.ComGroupTail detail in details)
            {
                AddDetailToFP(detail);
            }
            return 0;
        }

        #region 显示组套
        /// <summary>
        /// 添加明细到farpoint
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        private int AddDetailToFP(Neusoft.HISFC.Models.Fee.ComGroupTail detail)
        {
            neuSpread1_Sheet1.Rows.Add(neuSpread1_Sheet1.Rows.Count, 1);
            int row = neuSpread1_Sheet1.Rows.Count - 1;

            if (detail.drugFlag == "1")
            {
                //药品进销存管理类
                //Neusoft.HISFC.BizLogic.Pharmacy.Item drugManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                //根据药品编码获得某一药品信息
                Neusoft.HISFC.Models.Pharmacy.Item drug = this.pharmacyIntegrate.GetItem(detail.itemCode);
                if (drug == null)//没找到
                {
                    drug = new Neusoft.HISFC.Models.Pharmacy.Item();
                    drug.Name = "帐目表中无该项目";
                }
                //如果规格不为空
                if (drug.Specs != null && drug.Specs != "")
                    drug.Name = drug.Name + "{" + drug.Specs + "}";

                neuSpread1_Sheet1.SetValue(row, (int)Cols.ItemName, drug.Name, false);//项目名称
                neuSpread1_Sheet1.SetValue(row, (int)Cols.Price, drug.Price, false);//价格
                neuSpread1_Sheet1.SetValue(row, (int)Cols.Unit, drug.PriceUnit, false);//单位
            }
            else
            {
                //Neusoft.HISFC.BizLogic.Fee.Item undrugManager = new Neusoft.HISFC.BizLogic.Fee.Item();
               

                Neusoft.HISFC.Models.Fee.Item.Undrug undrug = this.feeIntegrate.GetUndrugByCode(detail.itemCode);
                if (undrug == null)
                {//没找到
                    undrug = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                    undrug.Name = "帐目表中无该项目";
                }
                neuSpread1_Sheet1.SetValue(row, (int)Cols.ItemName, undrug.Name, false);//项目名称
                neuSpread1_Sheet1.SetValue(row, (int)Cols.Price, undrug.Price, false);//价格
                neuSpread1_Sheet1.SetValue(row, (int)Cols.Unit, undrug.PriceUnit, false);//单位
            }

            //项目代码
            neuSpread1_Sheet1.SetTag(row, (int)Cols.ItemName, detail.itemCode);

            neuSpread1_Sheet1.SetValue(row, (int)Cols.Qty, detail.qty, false);//数量
            neuSpread1_Sheet1.SetValue(row, (int)Cols.Dept, detail.deptName, false);//执行科室
            neuSpread1_Sheet1.SetTag(row, (int)Cols.Dept, detail.deptCode);//执行科室代码

            neuSpread1_Sheet1.SetValue(row, (int)Cols.Combo, detail.combNo, false);//组合号
            neuSpread1_Sheet1.SetValue(row, (int)Cols.Memo, detail.reMark, false);//备注
            neuSpread1_Sheet1.SetValue(row, (int)Cols.OperCode, detail.operCode, false);//操作员
            neuSpread1_Sheet1.SetValue(row, (int)Cols.OperDate, detail.OperDate.ToString(), false);//操作时间
            neuSpread1_Sheet1.SetValue(row, (int)Cols.SortId, (decimal)detail.SortNum, false); //序号 
            neuSpread1_Sheet1.Rows[row].Tag = detail;
            return 0;
        }

        private ArrayList GetSelectedDetail()
        {
            ArrayList alReturnDetailsTemp = new ArrayList();
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                bool isSelected = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value);

                if (!isSelected)
                {
                    Neusoft.HISFC.Models.Fee.ComGroupTail comGroupTail = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Fee.ComGroupTail;

                    alReturnDetailsTemp.Add(comGroupTail);
                }
            }
            return alReturnDetailsTemp;
        }

        private void SelectAll(bool isSelect)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Value = isSelect;
            }
        }

        #endregion

        #region cols
        /// <summary>
        /// 列枚举
        /// </summary>
        private enum Cols
        {
            ChooseFlag, 
            ItemName ,//项目名称
            Price,//价格
            Qty,//数量
            Unit,//单位
            Dept,//执行科室
            Combo,//组合号
            Memo,//备注
            OperCode,//操作员
            OperDate,//操作日期
            SortId//排序号
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.AlReturnDetails = this.GetSelectedDetail();
            if (AlReturnDetails.Count == this.neuSpread1_Sheet1.Rows.Count)
            {
                MessageBox.Show("请选择明细");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.SelectAll(true);
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            this.SelectAll(false);
        }


    }
}
