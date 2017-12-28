using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using System.Collections;

namespace Neusoft.Report.Logistics.DrugStore
{
    public partial class ucPhaDrugDateValidList : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucPhaDrugDateValidList()
        {
            InitializeComponent();

        }

        private Neusoft.FrameWork.Public.ObjectHelper drugTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        private Neusoft.FrameWork.Public.ObjectHelper qualityHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        private string companyName;
        private string companyValue;
        private string drugQualityName;
        private string drugQualityValue;
        private string drugTypeName;
        private string drugTypeValue;

        protected override void OnLoad()
        {
            base.OnLoad();

            // 药品类别下拉列表
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            ArrayList allDrugType = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);
            if (allDrugType == null)
            {
                MessageBox.Show(Language.Msg("根据常数类别获取药品类型名称发生错误!") + consManager.Err);
                drugTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();
                return;
            }

            Neusoft.FrameWork.Models.NeuObject drugTypeObj = new Neusoft.FrameWork.Models.NeuObject();
            drugTypeObj.ID = "ALL";
            drugTypeObj.Name = "全部";

            allDrugType.Insert(0, drugTypeObj);

            drugTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper(allDrugType);

            for (int i = 0; i < allDrugType.Count; i++)
            {
                ncboDrugType.Items.Add(allDrugType[i]);
            }
            ncboDrugType.alItems.AddRange(allDrugType);

            if (ncboDrugType.Items.Count > 0)
            {
                ncboDrugType.SelectedIndex = 0;
                drugTypeName = ((Neusoft.FrameWork.Models.NeuObject)ncboDrugType.Items[0]).Name;
                drugTypeValue = ((Neusoft.FrameWork.Models.NeuObject)ncboDrugType.Items[0]).ID;
            }

            // 药品性质下拉列表
            ArrayList allQuality = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY);
            if (allQuality == null)
            {
                MessageBox.Show(Language.Msg("根据常数类别获取药品性质发生错误!") + consManager.Err);
                this.qualityHelper = new Neusoft.FrameWork.Public.ObjectHelper();
                return;
            }

            Neusoft.FrameWork.Models.NeuObject qualityObj = new Neusoft.FrameWork.Models.NeuObject();
            qualityObj.ID = "ALL";
            qualityObj.Name = "全部";

            allQuality.Insert(0, qualityObj);

            this.qualityHelper = new Neusoft.FrameWork.Public.ObjectHelper(allQuality);

            for (int i = 0; i < allQuality.Count; i++)
            {
                ncboDrugQuality.Items.Add(allQuality[i]);
            }
            ncboDrugQuality.alItems.AddRange(allQuality);

            if (ncboDrugQuality.Items.Count > 0)
            {
                ncboDrugQuality.SelectedIndex = 0;
                drugQualityName = ((Neusoft.FrameWork.Models.NeuObject)ncboDrugQuality.Items[0]).Name;
                drugQualityValue = ((Neusoft.FrameWork.Models.NeuObject)ncboDrugQuality.Items[0]).ID;
            }

            // 供货公司下拉列表
            Neusoft.HISFC.BizLogic.RADT.InPatient Manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            System.Collections.ArrayList alUsecodeList = new ArrayList();
            this.ncboCompany.alItems.Clear();
            this.ncboCompany.Items.Clear();
            string strSql = @"select fac_code,fac_name,spell_code,wb_code from pha_com_company";

            strSql = string.Format(strSql);
            DataSet ds = new DataSet();
            if (Manager.ExecQuery(strSql, ref ds) == -1)
            {
                //return;
            }
            if (ds == null || ds.Tables[0] == null)
            {
                MessageBox.Show("查询错误", "警告,用法加载错误！");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Neusoft.HISFC.Models.Base.Spell obj = new Neusoft.HISFC.Models.Base.Spell();
                    obj.ID = ds.Tables[0].Rows[i][0].ToString();
                    obj.Name = ds.Tables[0].Rows[i][1].ToString();
                    obj.SpellCode = ds.Tables[0].Rows[i][2].ToString();
                    obj.WBCode = ds.Tables[0].Rows[i][3].ToString();
                    alUsecodeList.Add(obj);
                }
            }

            Neusoft.HISFC.Models.Base.Spell obj2 = new Neusoft.HISFC.Models.Base.Spell();
            obj2.ID = "ALL";
            obj2.Name = "全部";
            obj2.SpellCode = "QB";
            alUsecodeList.Insert(0, obj2);

            for (int i = 0; i < alUsecodeList.Count; i++)
            {
                ncboCompany.Items.Add(alUsecodeList[i]);
            }

            ncboCompany.alItems.AddRange(alUsecodeList);

            if (ncboCompany.Items.Count > 0)
            {
                ncboCompany.SelectedIndex = 0;
                companyName = ((Neusoft.HISFC.Models.Base.Spell)ncboCompany.Items[0]).Name;
                companyValue = ((Neusoft.HISFC.Models.Base.Spell)ncboCompany.Items[0]).ID;
            }
        }

        protected override int OnRetrieve(params object[] objects)
        {
            

            return base.OnRetrieve(dtpBeginTime.Value, companyValue, drugQualityValue, drugTypeValue);
        }

        /// <summary>
        /// 药品类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ncboDrugType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ncboDrugType.SelectedIndex >= 0)
            {
                drugTypeName = ((Neusoft.FrameWork.Models.NeuObject)ncboDrugType.Items[ncboDrugType.SelectedIndex]).Name;
                drugTypeValue = ((Neusoft.FrameWork.Models.NeuObject)ncboDrugType.Items[ncboDrugType.SelectedIndex]).ID;
            }
        }

        /// <summary>
        /// 药品性质
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ncboDrugQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ncboDrugQuality.SelectedIndex >= 0)
            {
                drugQualityName = ((Neusoft.FrameWork.Models.NeuObject)ncboDrugQuality.Items[ncboDrugQuality.SelectedIndex]).Name;
                drugQualityValue = ((Neusoft.FrameWork.Models.NeuObject)ncboDrugQuality.Items[ncboDrugQuality.SelectedIndex]).ID;
            }
        }

        /// <summary>
        /// 供货单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ncboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ncboCompany.SelectedIndex >= 0)
            {
                companyName = ((Neusoft.HISFC.Models.Base.Spell)ncboCompany.Items[ncboCompany.SelectedIndex]).Name;
                companyValue = ((Neusoft.HISFC.Models.Base.Spell)ncboCompany.Items[ncboCompany.SelectedIndex]).ID;
            }
        }
       
    }
}

