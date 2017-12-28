using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace InterfaceInstanceDefault.IPrepayPrint
{
    /// <summary>
    /// ucZZFYPrepayPrint<br></br>
    /// [功能描述: 郑州预约金发票<br></br>//{F7351081-C195-4c54-8A35-A1066CF35A10}
    /// [创 建 者: 董国强]<br></br>
    /// [创建时间: 2010-08-05]<br></br>
    /// <修改记录 
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucZZFYPrepayPrint : System.Windows.Forms.UserControl, Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint
    {
        /// <summary>
        /// 字段：是否作废发票，控制显示"作废字样";
        /// </summary>
        private bool isReturn = false;

        

        /// <summary>
        ///  属性：是否作废发票，控制显示"作废字样";
        /// </summary>
        public bool IsRetrun
        {
            set
            {
                isReturn = value;
            }
        }


        public ucZZFYPrepayPrint()
        {
            InitializeComponent();
        }


        #region IPrepayPrint 成员

        public int Clear()
        {
            return 0;
        }

        public int Print()
        {
            #region {3D7893EA-5DE3-4799-8C8F-B5FF40591C15}
            

            try
            {
                Neusoft.FrameWork.WinForms.Classes.Print print = null;
                try
                {
                    print = new Neusoft.FrameWork.WinForms.Classes.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化打印机失败!" + ex.Message);

                    return -1;
                }

                Neusoft.HISFC.Models.Base.PageSize ps = new Neusoft.HISFC.Models.Base.PageSize();
                Neusoft.HISFC.BizLogic.Manager.PageSize pss = new Neusoft.HISFC.BizLogic.Manager.PageSize();
                ps = pss.GetPageSize("YJJFP");
                
                print.SetPageSize(ps);
                print.PrintPage(0, 0, this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }

            return 1; 
            
            #endregion
        }

        public void SetTrans(System.Data.IDbTransaction trans)
        {
            return;
        }

        /// <summary>
        /// 设置预交金发票中的数据
        /// </summary>
        /// <param name="patient">【实体】病人</param>
        /// <param name="prepay">【实体】预交金</param>
        /// <returns></returns>
        public int SetValue(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay)
        {
            System.Windows.Forms.MessageBox.Show("预交金收取成功：" + prepay.FT.PrepayCost + "元！");
            try
            {
                #region 收据打印
                //
                Neusoft.HISFC.BizProcess.Integrate.Manager mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                this.lblHospitalName.Text =  mgr.GetHospitalName();

                //票据号
                //this.lblPrePayNo.Text = prepay.RecipeNO;
                //票据批次
                
                //支付方式
                this.lblPrePayTypeName.Text = mgr.GetConstansObj("PAYMODES",  prepay.PayType.ID).Name+"   "+patient.Pact.Name;
                //操作日期
                this.lblPrePayDate.Text = prepay.PrepayOper.OperTime.ToString();
                //流水号
                this.lblPrePaySerialNo.Text = prepay.RecipeNO;
                //患者姓名
                this.lblPatientName.Text = patient.Name;
                //住院科室
                this.lblDept.Text = patient.PVisit.PatientLocation.Dept.Name;
                //住院号码
                this.lblInNo.Text = patient.PID.PatientNO;
                //预交金大写
                this.lblCnCost.Text =  Neusoft.FrameWork.Public.String.LowerMoneyToUpper(prepay.FT.PrepayCost);
                //预交金额
                this.lblCost.Text = Neusoft.FrameWork.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();
                //收款员
                this.lblPayeer.Text = prepay.PrepayOper.ID;
                #endregion


            }
            catch (Exception ex)
            {
                return -1;
            }
            return 1;
        }

        public System.Data.IDbTransaction Trans
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion



    }
}
