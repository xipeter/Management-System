using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR.Interface
{
    public partial class ucSearchPatient : UserControl,ISearchPatient
    {
        public ucSearchPatient()
        {
            InitializeComponent();
        }

        #region ISearchPatient ≥…‘±

        public event ObjectHandle OnSelectedPatient;

        public Control SearchControl
        {
            get { return this; }
        }

        #endregion
    }
}
