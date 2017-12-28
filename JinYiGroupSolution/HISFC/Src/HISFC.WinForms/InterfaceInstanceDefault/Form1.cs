using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace InterfaceInstanceDefault
{

    public partial class Form1 : Form
    {
        public static void Main()
        {
            Application.Run(new Form1());
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InterfaceInstanceDefault.ISplitRecipe.ISplitRecipeDefault ispd =
                new InterfaceInstanceDefault.ISplitRecipe.ISplitRecipeDefault();
            string err=string.Empty ;
            ispd.SetDrugRecipeNO(new Neusoft.HISFC.Models.Registration.Register(),new ArrayList(),ref err);
        }
    }
}