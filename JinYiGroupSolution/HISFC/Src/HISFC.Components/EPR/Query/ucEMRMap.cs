using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.EPR;

namespace Neusoft.HISFC.Components.EPR
{
    public partial class ucEMRMap : ucPrintPicture
    {
        public ucEMRMap()
        {
            InitializeComponent();
        }
        public ucEMRMap(TemplateDesignerApplication.ucDataFileLoader loader, Neusoft.HISFC.Models.RADT.PatientInfo patient)
            : base(loader, patient)
        {
            InitializeComponent();
        }

        #region "事件与事件处理函数"

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintPreview printPreview = new frmPrintPreview(this.arrPicture, patient);
            printPreview.ShowDialog();
            //this.arrControls = this.SortControls(loader.CurrntPanel);
            //this.cboPage.Items.Clear();
            //TotalPage = 0;
            //this.Print();
        }

        protected override void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
            {
                PictureBox pic = (PictureBox)sender;
                pic.Controls.Clear();
                foreach (SortedControl ctr in this.arrSortedControls)
                {
                    if (ctr.Page == this.cboPage.SelectedIndex + 1 &&
                        e.Location.X >= ctr.Rect.Left && e.Location.Y >= ctr.Rect.Top &&
                        e.Location.X < ctr.Rect.Right && e.Location.Y <= ctr.Rect.Bottom)
                    {
                        PictureBox picPanel = new PictureBox();
                        picPanel.Location = ctr.Rect.Location;
                        picPanel.Width = ctr.Rect.Width;
                        picPanel.Height = ctr.Rect.Height;
                        picPanel.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        picPanel.MouseDown += new MouseEventHandler(picPanel_MouseDown);
                        picPanel.MouseDoubleClick += new MouseEventHandler(picPanel_MouseDoubleClick);
                        pic.Controls.Clear();
                        pic.Controls.Add(picPanel);
                        pic.Update();
                        break;
                    }
                }
            }
        }

        void picPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox picPanel = (PictureBox)sender;
                foreach (SortedControl ctr in this.arrSortedControls)
                {
                    if (ctr.Page == this.cboPage.SelectedIndex + 1 &&
                        picPanel.Location == ctr.Rect.Location &&
                        picPanel.Width == ctr.Rect.Width && picPanel.Height == ctr.Rect.Height)
                    {
                        Control ctrControl = this.currentPanel.Controls[ctr.Name];
                        Panel pnl = (Panel)ctrControl.Parent;
                        //pnl.Select();
                        //ctr.Control.Select();
                        pnl.ScrollControlIntoView(ctrControl);

                        this.SetFocus(ctrControl);
                        ctrControl.FindForm().Update();
                        ctrControl.FindForm().Refresh();
                        ctrControl.Parent.Update();
                        ctrControl.Parent.Refresh();
                        //this.Close();
                        //PictureBox pic = (PictureBox)picPanel;
                        //pic.Controls.Clear();
                        //pic.Update();
                        break;
                    }
                }
            }

        }

        private void SetFocus(Control ctr)
        {
            if (ctr.Parent.GetType() != typeof(Form) && !ctr.Parent.GetType().IsSubclassOf(typeof(Form)))
            {
                SetFocus(ctr.Parent);
            }
            ctr.Focus();
        }

        void picPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox picPanel = (PictureBox)sender;
                foreach (SortedControl ctr in this.arrSortedControls)
                {
                    if (ctr.Page == this.cboPage.SelectedIndex + 1 &&
                        picPanel.Location == ctr.Rect.Location &&
                        picPanel.Width == ctr.Rect.Width && picPanel.Height == ctr.Rect.Height)
                    {
                        this.Parent.Parent.Parent.Size = this.Parent.Parent.Parent.MinimumSize;
                        Control ctrControl = this.currentPanel.Controls[ctr.Name];
                        Panel pnl = (Panel)ctrControl.Parent;
                        pnl.Select();
                        ctrControl.Select();
                        pnl.ScrollControlIntoView(ctrControl);

                        ctrControl.FindForm().ActiveControl = ctrControl;
                        ctrControl.FindForm().Update();
                        ctrControl.FindForm().Refresh();
                        ctrControl.Parent.Update();
                        ctrControl.Parent.Refresh();
                        PictureBox pic = (PictureBox)picPanel;
                        pic.Controls.Clear();
                        pic.Update();
                        break;
                    }
                }
            }
        }

        #endregion "事件与事件处理函数"
    }
}
