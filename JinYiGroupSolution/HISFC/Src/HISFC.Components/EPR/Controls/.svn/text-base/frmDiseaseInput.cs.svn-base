using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
namespace Neusoft.HISFC.Components.EPR.Controls
{
    internal partial class frmDiseaseInput : Form
    {
        public frmDiseaseInput()
        {
            InitializeComponent();
        }
        public frmDiseaseInput(string str,Font ftemp)
        {           
            this.mainProperty = str;
            this.fontFromMain = ftemp;
            InitializeComponent();
        }

        private System.Collections.ArrayList ucList;
        /// <summary>
        /// 传出对象AL
        /// </summary>
        public System.Collections.ArrayList UcList
        {
            get {
                ucList = this.ucDiseaseInput1.getObjFromList();
                return ucList; }
            set { ucList = value; }
        }
        private Font fontFromMain;
        /// <summary>
        /// 主窗体字体
        /// </summary>
        public Font FontFromMain
        {
            get 
            {
                return fontFromMain;
            }
            set 
            {
                this.fontFromMain = value;
            }
        
        }

        private string ucXmlStr;
        /// <summary>
        /// 属性XML
        /// </summary>
        public string UcXmlStr
        {
            get {
                ucXmlStr = this.ucDiseaseInput1.GetXml();
                return ucXmlStr; }
            set { ucXmlStr = value; }
        }
        private string mainProperty;

        /// <summary>
        /// 主窗体属性
        /// </summary>
        public string MainProperty
        {
            get { return mainProperty; }
            set { mainProperty = value; }
        }
        private void ucDiseaseInput1_Load(object sender, EventArgs e)
        {

             
        }

        private void frmDiseaseInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}