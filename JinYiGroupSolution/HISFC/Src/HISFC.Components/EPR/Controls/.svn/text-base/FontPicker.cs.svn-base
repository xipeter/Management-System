using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Toolkit.Controls
{
    public partial class NeuFontPicker : UserControl
    {
        public NeuFontPicker()
        {
            InitializeComponent();
            this.SetFontItem();
            this.cboFamily.Text = "ËÎÌו";
           
        }
        public Font SelectedFont
        {
            get
            {
                FontStyle fs = FontStyle.Regular;
                if(this.chkB.Checked)
                {
                    fs = fs | FontStyle.Bold;
                }
                if(this.chkI.Checked)
                {
                    fs = fs | FontStyle.Italic;
                }
                if(this.chkU.Checked)
                {
                    fs = fs | FontStyle.Underline;
                }
                return new Font(cboFamily.Text, float.Parse(cboSize.Text), fs);
            }
            set
            {
                this.cboFamily.SelectedValue = value.FontFamily;
                this.cboSize.Text = value.Size.ToString();
                this.chkB.Checked = value.Bold;
                this.chkI.Checked = value.Italic;
                this.chkU.Checked = value.Underline;
            }
        }
        public void SetFontItem()
        {
            this.cboFamily.Items.Clear();
            FontFamily[] families = FontFamily.Families;
            foreach (FontFamily family in families)
            {
                this.cboFamily.Items.Add(family.Name);
            }
        }
    }
}
