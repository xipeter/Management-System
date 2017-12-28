using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse
{
    public partial class ucPopPatient : UserControl
    {
        public ArrayList alAll = new ArrayList();
        public Neusoft.HISFC.Models.Registration.Register retInfo = new Neusoft.HISFC.Models.Registration.Register();

        public ucPopPatient()
        {
            InitializeComponent();
        }

        public delegate void SelectHander(Neusoft.HISFC.Models.Registration.Register res);
        public event SelectHander OnSelect;

        protected virtual void OnSelected(Neusoft.HISFC.Models.Registration.Register res)
        {
            if (OnSelect != null)
                this.OnSelect(res);
        }


        /// <summary>
        /// ≥ı ºªØ∏≥÷µ
        /// </summary>
        public void Init()
        {
            foreach (Neusoft.HISFC.Models.Registration.Register reg in alAll)
            {
                ListViewItem item = new ListViewItem();
                item.Text = reg.ID;
                item.Tag = reg;
                item.SubItems.Add(reg.Name);
                item.SubItems.Add(reg.DoctorInfo.SeeDate.ToString());
                item.SubItems.Add(reg.DoctorInfo.Templet.Dept.Name);

                this.lvPatient.Items.Add(item);
            }
        }

        private void GetValue()
        {
            Neusoft.HISFC.Models.Registration.Register reginfo
                = (Neusoft.HISFC.Models.Registration.Register)this.lvPatient.SelectedItems[0].Tag;
            this.retInfo = reginfo;
            OnSelected(reginfo);
            this.ParentForm.Close();
        }

        private void lvPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.GetValue();
            }
        }

        private void lvPatient_DoubleClick(object sender, EventArgs e)
        {
            this.GetValue();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.Escape.GetHashCode())
            {
                this.ParentForm.Close();
                return true;
            }

            if (keyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                this.GetValue();
                return true;
            }
            return true;
        }
    }
}
