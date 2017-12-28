using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.Controls
{
    public partial class ucOrderPrint : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucOrderPrint()
        {
            InitializeComponent();
        }

        Neusoft.HISFC.Models.RADT.PatientInfo myPatientInfo = null;

        Neusoft.HISFC.BizProcess.Interface.IPrintOrder ip = null;//当前接口
        /// <summary>
        /// 患者基本信息
        /// </summary>
        protected Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                if (this.myPatientInfo == null)
                    this.myPatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                return this.myPatientInfo;
            }
            set
            {
                this.myPatientInfo = value;
               

                //this.QueryOrder();

            }
        }
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.tv.CheckBoxes = false;

            this.myPatientInfo = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;
            if (myPatientInfo != null)
            {
           
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询执行单信息...");

            if (this.Controls[0].Controls.Count == 0)
            {
                object o = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(HISFC.Components.Order.Controls.ucOrderPrint), typeof(Neusoft.HISFC.BizProcess.Interface.IPrintOrder));
                if (o == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("请维护HISFC.Components.Order.Controls.ucOrderPrint里面接口Neusoft.HISFC.BizProcess.Integrate.IPrintOrder的实例对照！");
                    return -1;
                }
                ip = o as Neusoft.HISFC.BizProcess.Interface.IPrintOrder;
                Control c = ip as Control;
                c.Dock = DockStyle.Fill;
                this.Controls[0].Controls.Add(c);
                
            }
            else
            {
                ip = this.Controls[0].Controls[0] as Neusoft.HISFC.BizProcess.Interface.IPrintOrder;
            }

            if (ip == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("维护的实例不具备Neusoft.HISFC.BizProcess.Integrate.IPrintOrder接口");
                return -1;
            }
            
            ip.SetPatient(this.myPatientInfo);

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            return base.OnSetValue(neuObject, e);
        }

        public override int Print(object sender, object neuObject)
        {
            ip.Print();
            return base.Print(sender, neuObject);
        }

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] type = new Type[1];
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.IPrintOrder);
                return type;
            }
        }

        #endregion
    }
}
