using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.Report.Finance.FinIpb
{
    /// <summary>
    /// ucFinIpbPatientDetail<br></br>
    /// [功能描述: 出院病人报表UC]<br></br>
    /// [创 建 者: 孙刚]<br></br>
    /// [创建时间: 2007-10-22]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucFinIpbOutPatientReport : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbOutPatientReport()
        {
            InitializeComponent();
        }

        private string personCode = "ALL";
        private string personName = "全部";
        private string pactCode = "ALL";
        private string balType = "ALL";
        ArrayList alPersonconstantList = new ArrayList();
        ArrayList alBalanceList = new ArrayList();
        ArrayList alPactList = new ArrayList();


        /// <summary>
        /// 住院收费业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        /// <summary>
        /// 常数业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

        //{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
        /// <summary>
        /// 合同单位
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();


        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value,this.personCode,this.pactCode,this.balType);
        }

        /// <summary>
        /// 初始化合同单位
        /// </summary>
        /// <returns>成功1 失败 -1</returns>
        private int InitPact()
        {
            int findAll = 0;
            Neusoft.FrameWork.Models.NeuObject objAll = new Neusoft.FrameWork.Models.NeuObject();

            objAll.ID = "ALL";
            objAll.Name = "全部";
            //{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
            //this.alPactList = this.consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.PACTUNIT);
            this.alPactList = this.pactManager.QueryPactUnitAll();
            if (alPactList == null)
            {
                MessageBox.Show(Language.Msg("加载合同单位列表出错!") + this.consManager.Err);

                return -1;
            }

            alPactList.Insert(0,objAll);

            findAll = alPactList.IndexOf(objAll);

            this.cboPactCode.AddItems(alPactList);

            if (findAll >= 0)
            {
                this.cboPactCode.SelectedIndex = findAll;
            }

            return 1;
        }


        private int InitBalanceType()
        {
            int findAll = 0;
            Neusoft.FrameWork.Models.NeuObject objAll = new Neusoft.FrameWork.Models.NeuObject();

            objAll.ID = "ALL";
            objAll.Name = "全部";

            Neusoft.FrameWork.Models.NeuObject objI = new Neusoft.FrameWork.Models.NeuObject();

            objI.ID = "I";
            objI.Name = "中途结算";

            Neusoft.FrameWork.Models.NeuObject objO = new Neusoft.FrameWork.Models.NeuObject();

            objO.ID = "O";
            objO.Name = "出院结算";

            Neusoft.FrameWork.Models.NeuObject objQ = new Neusoft.FrameWork.Models.NeuObject();

            objQ.ID = "Q";
            objQ.Name = "欠费结算";

            alBalanceList.Insert(0,objAll);
            alBalanceList.Insert(1, objI);
            alBalanceList.Insert(2, objO);
            alBalanceList.Insert(3, objQ);

            this.cboBalanceType.AddItems(alBalanceList);

            findAll = alBalanceList.IndexOf(objAll);

            if (findAll >= 0)
            {
                this.cboBalanceType.SelectedIndex = findAll;
            }

            return 1;
        }

        #region 事件

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucFinIpbOutPatientReport_Load(object sender, EventArgs e)
        {
            DateTime nowTime = this.inpatientManager.GetDateTimeFromSysDateTime();

             

            this.dtpEndTime.Value = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 23, 59, 59);
            this.dtpBeginTime.Value = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 00, 00, 00);


            //填充数据
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            alPersonconstantList = manager.QueryEmployeeAll();
            Neusoft.HISFC.Models.Base.Employee allPerson = new Neusoft.HISFC.Models.Base.Employee();
            allPerson.ID = "ALL";
            allPerson.Name = "全部";
            allPerson.SpellCode = "QB";

            alPersonconstantList.Insert(0, allPerson);
            this.cboPersonCode.AddItems(alPersonconstantList);
            cboPersonCode.SelectedIndex = 0;

            this.InitPact();

            this.InitBalanceType();

        }



        private void cboPersonCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPersonCode.SelectedIndex >= 0)
            {
                personCode = ((Neusoft.HISFC.Models.Base.Employee)alPersonconstantList[this.cboPersonCode.SelectedIndex]).ID.ToString();
                personName = ((Neusoft.HISFC.Models.Base.Employee)alPersonconstantList[this.cboPersonCode.SelectedIndex]).Name.ToString();
            }
        }

        #endregion

        private void cboPactCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPactCode.SelectedIndex >= 0)
            {
                pactCode = ((Neusoft.FrameWork.Models.NeuObject)this.alPactList[this.cboPactCode.SelectedIndex]).ID.ToString();
            }

        }

        private void cboBalanceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBalanceType.SelectedIndex >= 0)
            {
                balType =((Neusoft.FrameWork.Models.NeuObject)this.alBalanceList[this.cboBalanceType.SelectedIndex]).ID.ToString();
            }
        }
    }
}