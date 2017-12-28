using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InterfaceInstanceDefault.IInpatientProof
{
    /// <summary>
    /// ucZZFYPrepayPrint<br></br>
    /// [功能描述: 住院证打印<br></br>
    /// [创 建 者: 何志力]<br></br>
    /// [创建时间: 20120224]<br></br>
    /// <修改记录 
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucInpatientProofPrint : System.Windows.Forms.UserControl, Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInpatientProofPrint
    {
        public ucInpatientProofPrint()
        {
            InitializeComponent();
        }
        #region 变量
        //private Neusoft.HISFC.Models.RADT.InPatientProof inpatientproofinfo = null;
        #endregion

        #region IPrepayPrint 成员

        public int Clear()
        {
            return 0;
        }

        public int Print()
        {
            #region 
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

                //Neusoft.HISFC.Models.Base.PageSize ps = new Neusoft.HISFC.Models.Base.PageSize();
                //Neusoft.HISFC.BizLogic.Manager.PageSize pss = new Neusoft.HISFC.BizLogic.Manager.PageSize();
                //ps = pss.GetPageSize("MZZYZ");
                print.PrintDocument.DefaultPageSettings.Landscape = true;
                //print.PrintDocument.DefaultPageSettings.HardMarginX =100;
                //print.SetPageSize(ps);
                print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
                print.PrintPage(330, 200, this);
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
        /// 设置住院证中的数据
        /// </summary>
        /// <param name="inpatientproof">【实体】住院证信息</param>
        /// <returns></returns>
        public int SetValue(Neusoft.HISFC.Models.RADT.InPatientProof inpatientproofinfo)
        {
            if (!string.IsNullOrEmpty(inpatientproofinfo.Clinic_code))
            {
                try
                {
                    //Neusoft.HISFC.BizProcess.Integrate.Manager mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                    //this.neuLBTITLE.Text = mgr.GetHospitalName()+"住院证";
                    this.LBCLINC_CODE.Text = inpatientproofinfo.Clinic_code;   //门诊号
                    this.LBCARD_NO.Text = inpatientproofinfo.Card_no; //卡号
                    this.LBNAME.Text = inpatientproofinfo.Name; //姓名
                    this.LBSEX.Text = inpatientproofinfo.Sex_code.Name;            //性别
                    this.LBAGE.Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(inpatientproofinfo.Birthday);//年龄
                    this.LBDEPT.Text = inpatientproofinfo.Dept_code.Name;//住院科室名称
                    //this.cmbDept.Tag = inpatientproofinfo.Dept_code.ID; //住院科室代码
                    this.LBDIOAGE.Text = inpatientproofinfo.Diagnose; //诊断
                    this.LBADDRESS.Text = inpatientproofinfo.Address;  //家庭住址
                   // this.LBINTEXT.Text = inpatientproofinfo.Intext;//紧急
                    this.LB_KZRQ.Text = inpatientproofinfo.In_date.ToString(" yyyy 年 MM 月 dd 日");//开证日期
                    this.LBDOCT.Text = inpatientproofinfo.Doct_code.Name;//医生
                    //this.cmbDoctor.Tag = inpatientproofinfo.Doct_code.ID;
                    this.LBINPCOUNT.Text = inpatientproofinfo.Inpatient_count.ToString(); //约计天数
                    this.LBBLOOD.Text = inpatientproofinfo.Blood_qty.ToString();//输血数量
                    if (inpatientproofinfo.Wwfs == "半卧" )
                    {
                        this.CKB1.Checked = true;
                    }
                    if (inpatientproofinfo.Wwfs == "休克卧")
                    {
                        this.CKB2.Checked = true;
                    }
                    if (inpatientproofinfo.Is_ys == "禁食")
                    {
                        this.CKB3.Checked = true;
                    }
                    if (inpatientproofinfo.Is_ys == "食")
                    {
                        this.CKB4.Checked = true;
                    }
                    if (inpatientproofinfo.Is_tj == "抬架")
                    {
                        this.CKB5.Checked = true;
                    }
                    if (inpatientproofinfo.Is_zx == "自行")
                    {
                        this.CKB6.Checked = true;
                    }
                    if (inpatientproofinfo.Is_my == "沐浴")
                    {
                        this.CKB7.Checked = true;
                    }
                    if (inpatientproofinfo.Is_lf == "理发")
                    {
                        this.CKB7.Checked = true;
                    }
                    if (inpatientproofinfo.Is_drug == "用")
                    {
                        this.CB1.Checked = true;
                    }
                    if (inpatientproofinfo.Is_drug == "不用")
                    {
                        this.CB2.Checked = true;
                    }
                    if (inpatientproofinfo.Ops_type == "大")
                    {
                        this.CB3.Checked = true;
                    }
                    if (inpatientproofinfo.Ops_type == "中")
                    {
                        this.CB4.Checked = true;
                    }
                    if (inpatientproofinfo.Ops_type =="小")
                    {
                        this.CB5.Checked = true;
                    }
                    if (inpatientproofinfo.Xxfs == "一般")
                    {
                        this.CB6.Checked = true;
                    }
                    if (inpatientproofinfo.Xxfs == "特别")
                    {
                        this.CB7.Checked = true;
                    }
                    //zhangyt-2011-03-01
                    if (inpatientproofinfo.Memo == "危")
                    {
                        this.dangercheck.Checked = true;
                    }
                    if (inpatientproofinfo.Memo == "急")
                    {
                        this.urgentcheck.Checked = true;
                    }
                    if (inpatientproofinfo.Memo == "一般")
                    {
                        this.generalcheck.Checked = true;
                    }

                    this.lblPacName.Text = inpatientproofinfo.Memo1;     //合同单位
                }
                catch (Exception ex)
                {
                    return -1;
                }
                return 1;
            }
            else
            {
                return -1;
            }

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
