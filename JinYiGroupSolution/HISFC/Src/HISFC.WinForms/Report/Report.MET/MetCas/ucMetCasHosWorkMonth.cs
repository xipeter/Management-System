using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.MET.MetCas
{
    public partial class ucMetCasHosWorkMonth : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        //private Neusoft.HISFC.Object.Base.Employee oper = Neusoft.NFC.Management.Connection.Operator as Neusoft.HISFC.Object.Base.Employee;
        private Neusoft.HISFC.Models.Base.Employee oper = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;



        public ucMetCasHosWorkMonth()
        {
            InitializeComponent();
    
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            
            int RetrieveRow = base.OnRetrieve(this.dtpBeginTime.Value.Date, this.dtpEndTime.Value.Date);
            return RetrieveRow;
        }
      
        //private void ucMetCasHos2_Load(object sender, EventArgs e)
        //{
        //    //Neusoft.HISFC.Management.RADT.InPatient inpatientManager = new Neusoft.HISFC.Management.RADT.InPatient();
        //    Neusoft.HISFC.BizLogic.RADT.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();

        //    DateTime nowTime = inpatientManager.GetDateTimeFromSysDateTime();
        //    DateTime lastTime = new DateTime(nowTime.Year, nowTime.Month, 26, 00, 00, 00);
        //    this.dtpBeginTime.Value = lastTime.AddMonths(-1);
        //    this.dtpEndTime.Value = new DateTime(nowTime.Year, nowTime.Month, 25, 00, 00, 00);
            
        //}

       
    }

    }

