using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy.Out
{
    public partial class frmEveryStore : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmEveryStore()
        {
            InitializeComponent();
        }


        #region 变量
        /// <summary>
        /// 药品业务层

        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 药品编码
        /// </summary>
        private string drugCode = string.Empty;

        private ArrayList storeArrayList = new ArrayList();
        #endregion

        #region 属性

        /// <summary>
        /// 药品编码
        /// </summary>
        public string DrugCode
        {
            set
            {
                this.drugCode = value;
                this.SetValue(this.drugCode);
            }
            get
            {
                return this.drugCode;

            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 显示库存数量
        /// </summary>
        /// <param name="drugCode"></param>
        /// <returns></returns>
        public int SetValue(string drugCode)
        {
            this.storeArrayList = this.itemManager.QueryStoreDeptList(drugCode); 
            if (storeArrayList == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(this.itemManager.Err));
                return -1;
            }

            decimal littleTotStorage = 0;  //小计总数量
            decimal pactNum = 1;

            decimal totStorage = 0;
            string privDeptCode = string.Empty;
            
            string minUnit = "";
            string pactUnit = "";

            //就一条信息
            if (this.storeArrayList.Count == 1)
            {
                #region 添加一条信息进行处理

                Neusoft.HISFC.Models.Pharmacy.Storage info = this.storeArrayList[0] as Neusoft.HISFC.Models.Pharmacy.Storage;

                //添加明细
                this.AddDeptData(info, info.StoreQty, false);
                this.AddDeptData(info, info.StoreQty, true);

                //添加小计
                this.AddDeptTotData(info, info.StoreQty);

                #endregion
            }
            else
            {
                #region 存在多条信息

                Neusoft.HISFC.Models.Pharmacy.Storage privStorage = null;
                foreach (Neusoft.HISFC.Models.Pharmacy.Storage info in this.storeArrayList)
                {                    
                    this.Text = info.Item.Name + "[" + info.Item.Specs + "] － 各药房库存分布";
                    minUnit = info.Item.MinUnit;
                    pactUnit = info.Item.PackUnit;
                    pactNum = info.Item.PackQty;

                    #region 换科室了(第一条不处理) 添加小计数量

                    if (privDeptCode != info.StockDept.ID && privDeptCode != string.Empty)
                    {
                        //添加明细的小计
                        this.AddDeptTotData(info, littleTotStorage);
                        //添加汇总信息
                        this.AddDeptData(privStorage, littleTotStorage, false);

                        littleTotStorage = 0;
                    }

                    #endregion

                    littleTotStorage += info.StoreQty;
                    totStorage += info.StoreQty;
                    privDeptCode = info.StockDept.ID;

                    //添加明细信息
                    this.AddDeptData(info, info.StoreQty, true);

                    privStorage = info.Clone();
                }

                //添加明细的小计
                this.AddDeptTotData(privStorage, littleTotStorage);
                //添加汇总信息
                this.AddDeptData(privStorage, littleTotStorage, false);

                #endregion
            }

            if (this.neuSpread1_Sheet2.RowCount > 0)
            {
                this.neuSpread1_Sheet2.AddRows(this.neuSpread1_Sheet2.RowCount, 1);
                this.neuSpread1_Sheet2.Cells[this.neuSpread1_Sheet2.RowCount - 1, 3].Text = "合计数量";         //药品批号
                this.neuSpread1_Sheet2.Cells[this.neuSpread1_Sheet2.RowCount - 1, 4].Text = this.GetDivQty(totStorage, pactNum, pactUnit, minUnit);

                this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
                this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 2].Text = "合计数量";         //药品批号
                this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 3].Text = this.GetDivQty(totStorage, pactNum, pactUnit, minUnit);

            }
            return 1;
        }

        /// <summary>
        /// 根据库存添加科室数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int AddDeptData(Neusoft.HISFC.Models.Pharmacy.Storage info,decimal storeQty,bool isDetail)
        {
            if (isDetail)
            {
                int iDetailIndex = this.neuSpread1_Sheet2.Rows.Count;
                this.neuSpread1_Sheet2.AddRows(iDetailIndex, 1);
                this.neuSpread1_Sheet2.Cells[iDetailIndex, 0].Text = info.StockDept.Name;  //药房名称
                this.neuSpread1_Sheet2.Cells[iDetailIndex, 1].Text = info.Item.Name;       //药品名称
                this.neuSpread1_Sheet2.Cells[iDetailIndex, 2].Text = info.Item.Specs;      //药品规格
                this.neuSpread1_Sheet2.Cells[iDetailIndex, 3].Text = info.BatchNO;         //药品批号

                this.neuSpread1_Sheet2.Cells[iDetailIndex, 4].Text = this.GetDivQty(storeQty, info.Item.PackQty, info.Item.PackUnit, info.Item.MinUnit);
            }
            else
            {
                int iTotIndex = this.neuSpread1_Sheet1.Rows.Count;
                this.neuSpread1_Sheet1.AddRows(iTotIndex, 1);
                this.neuSpread1_Sheet1.Cells[iTotIndex, 0].Text = info.StockDept.Name;
                this.neuSpread1_Sheet1.Cells[iTotIndex, 1].Text = info.Item.Name;
                this.neuSpread1_Sheet1.Cells[iTotIndex, 2].Text = info.Item.Specs;
                this.neuSpread1_Sheet1.Cells[iTotIndex, 3].Text = this.GetDivQty(storeQty, info.Item.PackQty, info.Item.PackUnit, info.Item.MinUnit);
            }

            return 1;
        }

        /// <summary>
        /// 添加合计/小计信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="storeQty"></param>
        /// <param name="isDetail"></param>
        /// <returns></returns>
        private void AddDeptTotData(Neusoft.HISFC.Models.Pharmacy.Storage info, decimal storeQty)
        {
            int iDetailIndex = this.neuSpread1_Sheet2.Rows.Count;

            this.neuSpread1_Sheet2.AddRows(iDetailIndex, 1);
            this.neuSpread1_Sheet2.Cells[iDetailIndex, 3].Text = "小计数量";
            this.neuSpread1_Sheet2.Cells[iDetailIndex, 4].Text = this.GetDivQty(storeQty, info.Item.PackQty, info.Item.PackUnit, info.Item.MinUnit);
        }

        /// <summary>
        /// 根据当前库存数量、包装数量返回库存表示字符串
        /// </summary>
        /// <param name="storeQty">库存数量</param>
        /// <param name="packQty">包装数量</param>
        /// <param name="packUnit">包装单位</param>
        /// <param name="minUnit">最小单位</param>
        /// <returns>成功返回库存字符串</returns>
        private string GetDivQty(decimal storeQty, decimal packQty, string packUnit, string minUnit)
        {
            int minStoreQty;
            int packStoreQty = System.Math.DivRem((int)storeQty, (int)packQty, out minStoreQty);

            if (packStoreQty == 0)
            {
                return minStoreQty.ToString() + minUnit;
            }
            else if (minStoreQty == 0)
            {
                return packStoreQty.ToString() + packUnit;
            }
            else
            {
                return string.Format("{0}[{1}]{2}[{3}]", packStoreQty, packUnit, minStoreQty, minUnit);
            }
        }

        #endregion

    }
}