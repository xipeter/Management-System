using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    public partial class ucDrugList : Neusoft.HISFC.Components.Common.Controls.ucDrugList
    {
        //库存科室，默认是西药库
        public ucDrugList()
        {
            InitializeComponent();
        }

        private string deptCode = "0003";

        /// <summary>
        /// 库存科室编码属性
        /// </summary>
        public string DeptCode
        {
            set
            {
                deptCode = value;
            }
            get
            {
                return deptCode;
            }
        }

        public  new  void ShowPharmacyList()
        {
            //base.ShowPharmacyList();
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索药品信息...");
            Application.DoEvents();
            try
            {
                Neusoft.FrameWork.Management.DataBaseManger databaseManager = new Neusoft.FrameWork.Management.DataBaseManger();
                DataSet dataSet = new DataSet();

                base.ShowAdvanceFilter = true;

                //string[] sqlIndex = new string[2] { "Pharmacy.Item.ValibInfo", "Pharmacy.Item.GetAvailableList.Where" };
                string[] sqlIndex = new string[1] { "Pharmacy.Item.ValibInfo.InPlan" };

                string itemType = "A";
                if (base.cmbItemType.Tag != null && base.cmbItemType.Text != "")
                {
                    itemType = base.cmbItemType.Tag.ToString();
                }

                //{E215BCFB-9D4B-418c-9C12-AC6E0242FB7F}修改传入SQL语句的参数，增加权限科室ID

                databaseManager.ExecQuery(sqlIndex, ref dataSet, itemType, deptCode);

                if (dataSet == null)
                {
                    MessageBox.Show("检索列表数据发生错误\n" + databaseManager.Err);
                    return;
                }
                base.filterField = new string[]{"药品名称","通用名","拼音","五笔","自定义码","通用名拼音","别名","别名拼音",
														"通用名五笔","学名","学名拼音","学名五笔","别名五笔"};
                base.DataAutoHeading = true;
                base.DataAutoWidth = false;
                int[] widthCollect = new int[] { 10, 120, 100, 60, 40, 40,40,40,120};
                bool[] visibleCollect = new bool[] { false, true, true, true, true, false, false, false, false, true, false, false, true, false, false, true, false, false, false };
                if (dataSet.Tables.Count > 0)
                {
                    base.DataTable = dataSet.Tables[0];
                }

                base.SetFormat(null, widthCollect, visibleCollect);
                //{3FF156FD-6AB7-4468-9BA6-69F2E143AF3C}
                for (int i = 0; i < base.neuSpread1_Sheet1.Columns.Count; i++)
                {
                    if (base.neuSpread1_Sheet1.Columns[i].CellType.GetType() == typeof(FarPoint.Win.Spread.CellType.NumberCellType))
                    {
                        FarPoint.Win.Spread.CellType.NumberCellType numCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                        numCellType.DecimalPlaces = 4;
                        base.neuSpread1_Sheet1.Columns[i].CellType = numCellType;

                        //{D0F050D1-5743-4c4a-B7A6-103F1AA0AD7D}库存量宽度显示不足
                        base.neuSpread1_Sheet1.Columns[i].Width = 100;
                    }
                }

                //this.SetpharmacyFormat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }
    }
}
