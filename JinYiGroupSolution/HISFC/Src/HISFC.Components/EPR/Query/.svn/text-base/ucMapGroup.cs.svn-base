using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
    public partial class ucMapGroup : UserControl  
    {
        public ucMapGroup()
        {
            InitializeComponent();
            if(DesignMode)return;
            init();
        }
       
        ucPrintPreview printPreview;
        ucSuperMark superMark;
        ucEMRMap emrMap;
        private void ucMapGroup_Load(object sender, EventArgs e)
        {
           
        }
        private void init()
        {
            if (this.printPreview == null)
            {
                try
                {
                    printPreview = new ucPrintPreview();
                    superMark = new ucSuperMark();
                    emrMap = new ucEMRMap();
                    printPreview.Dock = DockStyle.Fill;
                    superMark.Dock = DockStyle.Fill;
                    emrMap.Dock = DockStyle.Fill;
                   
                    pagePrintPreview.Controls.Clear();
                    pageSuperMark.Controls.Clear();
                
                    pagePrintPreview.Controls.Add(printPreview);
                    pageSuperMark.Controls.Add(superMark);

                    printPreview.refresh_Click += new EventHandler(printPreview_refresh_Click);
                    superMark.refresh_Click += new EventHandler(printPreview_refresh_Click);
                    emrMap.refresh_Click += new EventHandler(printPreview_refresh_Click);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void SetLoader(TemplateDesignerApplication.ucDataFileLoader loader, Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            init();
            this.printPreview.SetLoader(loader, patient);
            this.emrMap.SetLoader(loader, patient);
            this.superMark.SetLoader(loader, patient);
            printPreview_refresh_Click(null, null);
        }

        void printPreview_refresh_Click(object sender, EventArgs e)
        {
            init();
            printPreview.Refresh();
            superMark.Refresh();
            emrMap.Refresh();
        }

    

    }
}
