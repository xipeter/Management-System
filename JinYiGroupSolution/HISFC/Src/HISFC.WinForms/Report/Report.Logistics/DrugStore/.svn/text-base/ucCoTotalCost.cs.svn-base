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
    public partial class ucCoTotalCost : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucCoTotalCost()
        {
            InitializeComponent();
            this.myInit();
        }

        private void myInit()
        {
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            ArrayList alItemType = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);
            if (alItemType == null)
            {
                MessageBox.Show(Language.Msg("根据常数类别获取药品类型名称发生错误!") + consManager.Err);
                return;
            }
            this.cmbType.AddItems(alItemType);
            //Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
            //string sqlSentence = @"select t.code,t.name from com_dictionary t where t.type = 'ITEMTYPE' order by sort_id";
            //if (dataManager.ExecQuery(sqlSentence, ref ds) == -1)
            //{
            //   MessageBox.Show(Language.Msg("获取药品类型发生错误"));
            //    return;
            //}
            //else if (ds != null && ds.Tables.Count > 0)
            //{
            //    this.cmbStockDept.Items.Clear();

            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {
            //        this.cmbStockDept.Items.Add(dr[1]);
                    
            //    }
            //}
         }
        
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1 || this.cmbType.SelectedIndex == -1)
            {
                return -1;
            }
            return base.OnRetrieve(base.beginTime,base.endTime,cmbType.Tag);
        }
       
    }
}

