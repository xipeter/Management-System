using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    public partial class ucPactUnitMaintenance : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPactUnitMaintenance()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 合同单位基本信息
        /// </summary>
        DataTable dtMain = new DataTable();

        /// <summary>
        /// 合同单位基本信息视图
        /// </summary>
        DataView dvMain = new DataView();

        /// <summary>
        /// 合同单位基本信息设置
        /// </summary>
        private string mainSettingFilePath = Application.StartupPath + @".\Setting\profiles\mainSettingFilePath.xml";

        #endregion

        #region 私有方法

        public int Init() 
        {
            //初始化合同单位主要信息
            if (InitDataTableMain() == -1) 
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 初始化合同单位主要信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InitDataTableMain()
        {
            if (File.Exists(this.mainSettingFilePath))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(this.mainSettingFilePath, this.dtMain, ref this.dvMain, this.fpMain_Sheet1);

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpMain_Sheet1, this.mainSettingFilePath);
            }
            else
            {
                this.dtMain.Columns.AddRange(new DataColumn[] 
                {
                    new DataColumn("单位代码", typeof(string)),
                    new DataColumn("单位名称", typeof(string)),
                    new DataColumn("结算类别", typeof(string)),
                    new DataColumn("价格形式", typeof(string)),
                    new DataColumn("公费比例", typeof(decimal)),
                    new DataColumn("自付比例", typeof(decimal)),
                    new DataColumn("自费比例", typeof(decimal)),
                    new DataColumn("优惠比例", typeof(decimal)),
                    new DataColumn("欠费比例", typeof(decimal)),
                    new DataColumn("婴儿标志", typeof(bool)),
                    new DataColumn("是否监控", typeof(bool)),
                    new DataColumn("标志", typeof(bool)),
                    new DataColumn("需医疗证", typeof(bool)),
                    new DataColumn("需医疗证", typeof(bool)),
                    new DataColumn("日限额", typeof(decimal)),
                    new DataColumn("月限额", typeof(decimal)),
                    new DataColumn("年限额", typeof(decimal)),
                    new DataColumn("一次限额", typeof(decimal)),
                    new DataColumn("床位上限", typeof(decimal)),
                    new DataColumn("空调上限", typeof(decimal)),
                    new DataColumn("简称", typeof(string)),
                    new DataColumn("序号", typeof(int))
                });

                this.dvMain = new DataView(this.dtMain);

                this.fpMain_Sheet1.DataSource = this.dvMain;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpMain_Sheet1, this.mainSettingFilePath);
            }

            return 1;
        }

        #endregion

        #region 公有方法

        #endregion
    }
}
