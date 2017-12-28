using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse.Print
{
    /// <summary>
    /// ucPrintCureNewControl<br></br>
    /// <Font color='#FF1111'>[功能描述:门诊注射瓶签打印{EB016FFE-0980-479c-879E-225462ECA6D0}]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-7-29]<br></br>
    /// <修改记录 
    ///		修改人='管玉兴' 
    ///		修改时间='2011-02-19' 
    ///		修改目的='满足郑州大学第一附属医院需求'
    ///		修改描述='{2DC86A33-872A-4b9a-9C4D-D6CBBF584020}'
    ///		/>
    /// </summary>
    public partial class ucPrintCureNewControl : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 构造函数
        public ucPrintCureNewControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 私有变量

        /// <summary>
        /// 整合的管理业务层
        /// </summary>
        private HISFC.BizProcess.Integrate.Manager interManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #endregion

        #region 公开方法
        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="alData"></param>
        /// <param name="totPage"></param>
        /// <param name="currPage"></param>
        public void SetData(List<Neusoft.HISFC.Models.Nurse.Inject> alData, int totPage, int currPage)
        {
            this.SetLable(alData, totPage, currPage);
            this.SetFpData(alData);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 设置标签
        /// </summary>
        /// <param name="alData"></param>
        /// <param name="totPage"></param>
        /// <param name="currPage"></param>
        private void SetLable(List<Neusoft.HISFC.Models.Nurse.Inject> alData, int totPage, int currPage)
        {
            //标题
            this.lblTitle.Text = this.interManager.GetHospitalName() + "输液单";
            //位置
            int localX = 0;
            if (this.lblTitle.Width < this.Width)
            {
                localX = (this.Width - this.lblTitle.Width) / 2;
            }
            this.lblTitle.Location = new Point(localX, this.lblTitle.Location.Y);
            //页码
            this.lblPage.Text = currPage.ToString() + "/共" + totPage.ToString() + "贴";
            //取出第一个注射记录
            Neusoft.HISFC.Models.Nurse.Inject inject = alData[0];
            //科室
            this.lblDept.Text = inject.Item.Order.DoctorDept.Name;
            //姓名
            this.lblName.Text = inject.Patient.Name;
            //性别
            this.lblSex.Text = (inject.Patient.Sex.ID.ToString() == "M") ? "男" : "女";
            //年龄

            this.lblAge.Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(inject.Patient.Birthday);
            //病历号
            this.lblPrintNo.Text = inject.Patient.PID.CardNO;
            //序号
            List<string> orderList = new List<string>();
            string strOrderNo = "";
            foreach (Neusoft.HISFC.Models.Nurse.Inject tmpInject in alData)
            {
                if (!orderList.Contains(tmpInject.OrderNO))
                {
                    orderList.Add(tmpInject.OrderNO);
                    strOrderNo += tmpInject.OrderNO + ".";
                }
            }
            this.lblOrderNo.Text = strOrderNo;
            //开方医生
            this.lblDoctor.Text = inject.Item.Order.Doctor.Name;
            //配液人
            this.lblOper.Text = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Name;
            //配液时间
            this.lblOperDate.Text = System.DateTime.Now.ToString();
        }

        /// <summary>
        /// 将数据填入farpoint中
        /// </summary>
        /// <param name="alData"></param>
        private void SetFpData(List<Neusoft.HISFC.Models.Nurse.Inject> alData)
        {
            for (int i = 0; i < alData.Count; i++)
            {
                Neusoft.HISFC.Models.Nurse.Inject inject = alData[i];
                this.neuSpread1_Sheet1.Cells[i, 0].Text = inject.Item.Name;
                this.neuSpread1_Sheet1.Cells[i, 1].Text = inject.Item.Item.Specs;
                this.neuSpread1_Sheet1.Cells[i, 2].Text = inject.Item.Order.DoseOnce + inject.Item.Order.DoseUnit;
            }
        }

        #endregion

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
