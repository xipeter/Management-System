using System;
using System.Collections.Generic;
using System.Text;
 

namespace Neusoft.WinForms.Report.InpatientFee
{
    /// <summary>
    /// ucPrepayPrint<br></br>
    /// [功能描述: 预交金打印控件]<br></br>
    /// [创 建 者: 王儒超]<br></br>
    /// [创建时间: 2006-11-29]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPrepayPrint : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint
    {
        public ucPrepayPrint() 
        {
            this.InitializeComponent();
        }
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblPriCheckNo;
        private System.Windows.Forms.Label lblPriOperNo;
        private System.Windows.Forms.Label lblPriDaXie;
        private System.Windows.Forms.Label lblPriReceiptNo;
        private System.Windows.Forms.Label lblPriOperDate;
        private System.Windows.Forms.Label lblPriInpatientNo;
        private System.Windows.Forms.Label lblPriName;
        private System.Windows.Forms.Label lblPriSex;
        private System.Windows.Forms.Label lblPriDept;
        private System.Windows.Forms.Label lblPriJinE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPriCheckNo1;
        private System.Windows.Forms.Label lblPriOperNo1;
        private System.Windows.Forms.Label lblPriDaXie1;
        private System.Windows.Forms.Label lblPriReceiptNo1;
        private System.Windows.Forms.Label lblPriOperDate1;
        private System.Windows.Forms.Label lblPriInpatientNo1;
        private System.Windows.Forms.Label lblPriName1;
        private System.Windows.Forms.Label lblPriSex1;
        private System.Windows.Forms.Label lblPriDept1;
        private System.Windows.Forms.Label lblPriJinE1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblPriCheckNo2;
        private System.Windows.Forms.Label lblPriOperNo2;
        private System.Windows.Forms.Label lblPriDaXie2;
        private System.Windows.Forms.Label lblPriReceiptNo2;
        private System.Windows.Forms.Label lblPriOperDate2;
        private System.Windows.Forms.Label lblPriInpatientNo2;
        private System.Windows.Forms.Label lblPriName2;
        private System.Windows.Forms.Label lblPriSex2;
        private System.Windows.Forms.Label lblPriDept2;
        private System.Windows.Forms.Label lblPriJinE2;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label lblPriCheckNo3;
        private System.Windows.Forms.Label lblPriOperNo3;
        private System.Windows.Forms.Label lblPriDaXie3;
        private System.Windows.Forms.Label lblPriReceiptNo3;
        private System.Windows.Forms.Label lblPriOperDate3;
        private System.Windows.Forms.Label lblPriInpatientNo3;
        private System.Windows.Forms.Label lblPriName3;
        private System.Windows.Forms.Label lblPriSex3;
        private System.Windows.Forms.Label lblPriDept3;
        private System.Windows.Forms.Label lblPriJinE3;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
    
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblPriCheckNo = new System.Windows.Forms.Label();
            this.lblPriOperNo = new System.Windows.Forms.Label();
            this.lblPriDaXie = new System.Windows.Forms.Label();
            this.lblPriReceiptNo = new System.Windows.Forms.Label();
            this.lblPriOperDate = new System.Windows.Forms.Label();
            this.lblPriInpatientNo = new System.Windows.Forms.Label();
            this.lblPriName = new System.Windows.Forms.Label();
            this.lblPriSex = new System.Windows.Forms.Label();
            this.lblPriDept = new System.Windows.Forms.Label();
            this.lblPriJinE = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPriCheckNo1 = new System.Windows.Forms.Label();
            this.lblPriOperNo1 = new System.Windows.Forms.Label();
            this.lblPriDaXie1 = new System.Windows.Forms.Label();
            this.lblPriReceiptNo1 = new System.Windows.Forms.Label();
            this.lblPriOperDate1 = new System.Windows.Forms.Label();
            this.lblPriInpatientNo1 = new System.Windows.Forms.Label();
            this.lblPriName1 = new System.Windows.Forms.Label();
            this.lblPriSex1 = new System.Windows.Forms.Label();
            this.lblPriDept1 = new System.Windows.Forms.Label();
            this.lblPriJinE1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblPriCheckNo2 = new System.Windows.Forms.Label();
            this.lblPriOperNo2 = new System.Windows.Forms.Label();
            this.lblPriDaXie2 = new System.Windows.Forms.Label();
            this.lblPriReceiptNo2 = new System.Windows.Forms.Label();
            this.lblPriOperDate2 = new System.Windows.Forms.Label();
            this.lblPriInpatientNo2 = new System.Windows.Forms.Label();
            this.lblPriName2 = new System.Windows.Forms.Label();
            this.lblPriSex2 = new System.Windows.Forms.Label();
            this.lblPriDept2 = new System.Windows.Forms.Label();
            this.lblPriJinE2 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.lblPriCheckNo3 = new System.Windows.Forms.Label();
            this.lblPriOperNo3 = new System.Windows.Forms.Label();
            this.lblPriDaXie3 = new System.Windows.Forms.Label();
            this.lblPriReceiptNo3 = new System.Windows.Forms.Label();
            this.lblPriOperDate3 = new System.Windows.Forms.Label();
            this.lblPriInpatientNo3 = new System.Windows.Forms.Label();
            this.lblPriName3 = new System.Windows.Forms.Label();
            this.lblPriSex3 = new System.Windows.Forms.Label();
            this.lblPriDept3 = new System.Windows.Forms.Label();
            this.lblPriJinE3 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "预交金额";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "住院科室";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "性    别";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "姓    名";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 32;
            this.label12.Text = "住院号码";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 33;
            this.label13.Text = "交费日期";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 34;
            this.label14.Text = "票 据 号";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 306);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 40;
            this.label19.Text = "支 票 号";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(14, 333);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 39;
            this.label20.Text = "收 款 员";
            // 
            // lblPriCheckNo
            // 
            this.lblPriCheckNo.AutoSize = true;
            this.lblPriCheckNo.BackColor = System.Drawing.Color.Red;
            this.lblPriCheckNo.Location = new System.Drawing.Point(80, 306);
            this.lblPriCheckNo.Name = "lblPriCheckNo";
            this.lblPriCheckNo.Size = new System.Drawing.Size(17, 12);
            this.lblPriCheckNo.TabIndex = 50;
            this.lblPriCheckNo.Text = "印";
            // 
            // lblPriOperNo
            // 
            this.lblPriOperNo.AutoSize = true;
            this.lblPriOperNo.BackColor = System.Drawing.Color.Red;
            this.lblPriOperNo.Location = new System.Drawing.Point(80, 333);
            this.lblPriOperNo.Name = "lblPriOperNo";
            this.lblPriOperNo.Size = new System.Drawing.Size(17, 12);
            this.lblPriOperNo.TabIndex = 49;
            this.lblPriOperNo.Text = "印";
            // 
            // lblPriDaXie
            // 
            this.lblPriDaXie.AutoSize = true;
            this.lblPriDaXie.BackColor = System.Drawing.Color.Red;
            this.lblPriDaXie.Location = new System.Drawing.Point(14, 279);
            this.lblPriDaXie.Name = "lblPriDaXie";
            this.lblPriDaXie.Size = new System.Drawing.Size(17, 12);
            this.lblPriDaXie.TabIndex = 48;
            this.lblPriDaXie.Text = "印";
            // 
            // lblPriReceiptNo
            // 
            this.lblPriReceiptNo.AutoSize = true;
            this.lblPriReceiptNo.BackColor = System.Drawing.Color.Red;
            this.lblPriReceiptNo.Location = new System.Drawing.Point(80, 90);
            this.lblPriReceiptNo.Name = "lblPriReceiptNo";
            this.lblPriReceiptNo.Size = new System.Drawing.Size(17, 12);
            this.lblPriReceiptNo.TabIndex = 47;
            this.lblPriReceiptNo.Text = "印";
            // 
            // lblPriOperDate
            // 
            this.lblPriOperDate.AutoSize = true;
            this.lblPriOperDate.BackColor = System.Drawing.Color.Red;
            this.lblPriOperDate.Location = new System.Drawing.Point(80, 117);
            this.lblPriOperDate.Name = "lblPriOperDate";
            this.lblPriOperDate.Size = new System.Drawing.Size(17, 12);
            this.lblPriOperDate.TabIndex = 46;
            this.lblPriOperDate.Text = "印";
            // 
            // lblPriInpatientNo
            // 
            this.lblPriInpatientNo.AutoSize = true;
            this.lblPriInpatientNo.BackColor = System.Drawing.Color.Red;
            this.lblPriInpatientNo.Location = new System.Drawing.Point(80, 144);
            this.lblPriInpatientNo.Name = "lblPriInpatientNo";
            this.lblPriInpatientNo.Size = new System.Drawing.Size(17, 12);
            this.lblPriInpatientNo.TabIndex = 45;
            this.lblPriInpatientNo.Text = "印";
            // 
            // lblPriName
            // 
            this.lblPriName.AutoSize = true;
            this.lblPriName.BackColor = System.Drawing.Color.Red;
            this.lblPriName.Location = new System.Drawing.Point(80, 171);
            this.lblPriName.Name = "lblPriName";
            this.lblPriName.Size = new System.Drawing.Size(17, 12);
            this.lblPriName.TabIndex = 44;
            this.lblPriName.Text = "印";
            // 
            // lblPriSex
            // 
            this.lblPriSex.AutoSize = true;
            this.lblPriSex.BackColor = System.Drawing.Color.Red;
            this.lblPriSex.Location = new System.Drawing.Point(80, 198);
            this.lblPriSex.Name = "lblPriSex";
            this.lblPriSex.Size = new System.Drawing.Size(17, 12);
            this.lblPriSex.TabIndex = 43;
            this.lblPriSex.Text = "印";
            // 
            // lblPriDept
            // 
            this.lblPriDept.AutoSize = true;
            this.lblPriDept.BackColor = System.Drawing.Color.Red;
            this.lblPriDept.Location = new System.Drawing.Point(80, 225);
            this.lblPriDept.Name = "lblPriDept";
            this.lblPriDept.Size = new System.Drawing.Size(17, 12);
            this.lblPriDept.TabIndex = 42;
            this.lblPriDept.Text = "印";
            // 
            // lblPriJinE
            // 
            this.lblPriJinE.AutoSize = true;
            this.lblPriJinE.BackColor = System.Drawing.Color.Red;
            this.lblPriJinE.Location = new System.Drawing.Point(80, 252);
            this.lblPriJinE.Name = "lblPriJinE";
            this.lblPriJinE.Size = new System.Drawing.Size(17, 12);
            this.lblPriJinE.TabIndex = 41;
            this.lblPriJinE.Text = "印";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "预收住院医疗费退费凭证";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "(报销无效)";
            // 
            // lblPriCheckNo1
            // 
            this.lblPriCheckNo1.AutoSize = true;
            this.lblPriCheckNo1.BackColor = System.Drawing.Color.Red;
            this.lblPriCheckNo1.Location = new System.Drawing.Point(290, 306);
            this.lblPriCheckNo1.Name = "lblPriCheckNo1";
            this.lblPriCheckNo1.Size = new System.Drawing.Size(17, 12);
            this.lblPriCheckNo1.TabIndex = 71;
            this.lblPriCheckNo1.Text = "印";
            // 
            // lblPriOperNo1
            // 
            this.lblPriOperNo1.AutoSize = true;
            this.lblPriOperNo1.BackColor = System.Drawing.Color.Red;
            this.lblPriOperNo1.Location = new System.Drawing.Point(290, 333);
            this.lblPriOperNo1.Name = "lblPriOperNo1";
            this.lblPriOperNo1.Size = new System.Drawing.Size(17, 12);
            this.lblPriOperNo1.TabIndex = 70;
            this.lblPriOperNo1.Text = "印";
            // 
            // lblPriDaXie1
            // 
            this.lblPriDaXie1.AutoSize = true;
            this.lblPriDaXie1.BackColor = System.Drawing.Color.Red;
            this.lblPriDaXie1.Location = new System.Drawing.Point(224, 279);
            this.lblPriDaXie1.Name = "lblPriDaXie1";
            this.lblPriDaXie1.Size = new System.Drawing.Size(17, 12);
            this.lblPriDaXie1.TabIndex = 69;
            this.lblPriDaXie1.Text = "印";
            // 
            // lblPriReceiptNo1
            // 
            this.lblPriReceiptNo1.AutoSize = true;
            this.lblPriReceiptNo1.BackColor = System.Drawing.Color.Red;
            this.lblPriReceiptNo1.Location = new System.Drawing.Point(290, 90);
            this.lblPriReceiptNo1.Name = "lblPriReceiptNo1";
            this.lblPriReceiptNo1.Size = new System.Drawing.Size(17, 12);
            this.lblPriReceiptNo1.TabIndex = 68;
            this.lblPriReceiptNo1.Text = "印";
            // 
            // lblPriOperDate1
            // 
            this.lblPriOperDate1.AutoSize = true;
            this.lblPriOperDate1.BackColor = System.Drawing.Color.Red;
            this.lblPriOperDate1.Location = new System.Drawing.Point(290, 117);
            this.lblPriOperDate1.Name = "lblPriOperDate1";
            this.lblPriOperDate1.Size = new System.Drawing.Size(17, 12);
            this.lblPriOperDate1.TabIndex = 67;
            this.lblPriOperDate1.Text = "印";
            // 
            // lblPriInpatientNo1
            // 
            this.lblPriInpatientNo1.AutoSize = true;
            this.lblPriInpatientNo1.BackColor = System.Drawing.Color.Red;
            this.lblPriInpatientNo1.Location = new System.Drawing.Point(290, 144);
            this.lblPriInpatientNo1.Name = "lblPriInpatientNo1";
            this.lblPriInpatientNo1.Size = new System.Drawing.Size(17, 12);
            this.lblPriInpatientNo1.TabIndex = 66;
            this.lblPriInpatientNo1.Text = "印";
            // 
            // lblPriName1
            // 
            this.lblPriName1.AutoSize = true;
            this.lblPriName1.BackColor = System.Drawing.Color.Red;
            this.lblPriName1.Location = new System.Drawing.Point(290, 171);
            this.lblPriName1.Name = "lblPriName1";
            this.lblPriName1.Size = new System.Drawing.Size(17, 12);
            this.lblPriName1.TabIndex = 65;
            this.lblPriName1.Text = "印";
            // 
            // lblPriSex1
            // 
            this.lblPriSex1.AutoSize = true;
            this.lblPriSex1.BackColor = System.Drawing.Color.Red;
            this.lblPriSex1.Location = new System.Drawing.Point(290, 198);
            this.lblPriSex1.Name = "lblPriSex1";
            this.lblPriSex1.Size = new System.Drawing.Size(17, 12);
            this.lblPriSex1.TabIndex = 64;
            this.lblPriSex1.Text = "印";
            // 
            // lblPriDept1
            // 
            this.lblPriDept1.AutoSize = true;
            this.lblPriDept1.BackColor = System.Drawing.Color.Red;
            this.lblPriDept1.Location = new System.Drawing.Point(290, 225);
            this.lblPriDept1.Name = "lblPriDept1";
            this.lblPriDept1.Size = new System.Drawing.Size(17, 12);
            this.lblPriDept1.TabIndex = 63;
            this.lblPriDept1.Text = "印";
            // 
            // lblPriJinE1
            // 
            this.lblPriJinE1.AutoSize = true;
            this.lblPriJinE1.BackColor = System.Drawing.Color.Red;
            this.lblPriJinE1.Location = new System.Drawing.Point(290, 252);
            this.lblPriJinE1.Name = "lblPriJinE1";
            this.lblPriJinE1.Size = new System.Drawing.Size(17, 12);
            this.lblPriJinE1.TabIndex = 62;
            this.lblPriJinE1.Text = "印";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(224, 306);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 61;
            this.label22.Text = "支 票 号";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(224, 333);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 12);
            this.label23.TabIndex = 60;
            this.label23.Text = "收 款 员";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(224, 90);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 12);
            this.label24.TabIndex = 59;
            this.label24.Text = "票 据 号";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(224, 117);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 58;
            this.label25.Text = "交费日期";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(224, 144);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 57;
            this.label26.Text = "住院号码";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(224, 171);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 12);
            this.label27.TabIndex = 56;
            this.label27.Text = "姓    名";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(224, 198);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 12);
            this.label28.TabIndex = 55;
            this.label28.Text = "性    别";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(224, 225);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 12);
            this.label29.TabIndex = 54;
            this.label29.Text = "住院科室";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(224, 252);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 53;
            this.label30.Text = "预交金额";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(248, 60);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 12);
            this.label31.TabIndex = 52;
            this.label31.Text = "(报销无效)";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(224, 37);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(113, 12);
            this.label32.TabIndex = 51;
            this.label32.Text = "预收住院医疗费存根";
            // 
            // lblPriCheckNo2
            // 
            this.lblPriCheckNo2.AutoSize = true;
            this.lblPriCheckNo2.BackColor = System.Drawing.Color.Red;
            this.lblPriCheckNo2.Location = new System.Drawing.Point(543, 306);
            this.lblPriCheckNo2.Name = "lblPriCheckNo2";
            this.lblPriCheckNo2.Size = new System.Drawing.Size(17, 12);
            this.lblPriCheckNo2.TabIndex = 92;
            this.lblPriCheckNo2.Text = "印";
            // 
            // lblPriOperNo2
            // 
            this.lblPriOperNo2.AutoSize = true;
            this.lblPriOperNo2.BackColor = System.Drawing.Color.Red;
            this.lblPriOperNo2.Location = new System.Drawing.Point(543, 333);
            this.lblPriOperNo2.Name = "lblPriOperNo2";
            this.lblPriOperNo2.Size = new System.Drawing.Size(17, 12);
            this.lblPriOperNo2.TabIndex = 91;
            this.lblPriOperNo2.Text = "印";
            // 
            // lblPriDaXie2
            // 
            this.lblPriDaXie2.AutoSize = true;
            this.lblPriDaXie2.BackColor = System.Drawing.Color.Red;
            this.lblPriDaXie2.Location = new System.Drawing.Point(477, 279);
            this.lblPriDaXie2.Name = "lblPriDaXie2";
            this.lblPriDaXie2.Size = new System.Drawing.Size(17, 12);
            this.lblPriDaXie2.TabIndex = 90;
            this.lblPriDaXie2.Text = "印";
            // 
            // lblPriReceiptNo2
            // 
            this.lblPriReceiptNo2.AutoSize = true;
            this.lblPriReceiptNo2.BackColor = System.Drawing.Color.Red;
            this.lblPriReceiptNo2.Location = new System.Drawing.Point(543, 90);
            this.lblPriReceiptNo2.Name = "lblPriReceiptNo2";
            this.lblPriReceiptNo2.Size = new System.Drawing.Size(17, 12);
            this.lblPriReceiptNo2.TabIndex = 89;
            this.lblPriReceiptNo2.Text = "印";
            // 
            // lblPriOperDate2
            // 
            this.lblPriOperDate2.AutoSize = true;
            this.lblPriOperDate2.BackColor = System.Drawing.Color.Red;
            this.lblPriOperDate2.Location = new System.Drawing.Point(543, 117);
            this.lblPriOperDate2.Name = "lblPriOperDate2";
            this.lblPriOperDate2.Size = new System.Drawing.Size(17, 12);
            this.lblPriOperDate2.TabIndex = 88;
            this.lblPriOperDate2.Text = "印";
            // 
            // lblPriInpatientNo2
            // 
            this.lblPriInpatientNo2.AutoSize = true;
            this.lblPriInpatientNo2.BackColor = System.Drawing.Color.Red;
            this.lblPriInpatientNo2.Location = new System.Drawing.Point(543, 144);
            this.lblPriInpatientNo2.Name = "lblPriInpatientNo2";
            this.lblPriInpatientNo2.Size = new System.Drawing.Size(17, 12);
            this.lblPriInpatientNo2.TabIndex = 87;
            this.lblPriInpatientNo2.Text = "印";
            // 
            // lblPriName2
            // 
            this.lblPriName2.AutoSize = true;
            this.lblPriName2.BackColor = System.Drawing.Color.Red;
            this.lblPriName2.Location = new System.Drawing.Point(543, 171);
            this.lblPriName2.Name = "lblPriName2";
            this.lblPriName2.Size = new System.Drawing.Size(17, 12);
            this.lblPriName2.TabIndex = 86;
            this.lblPriName2.Text = "印";
            // 
            // lblPriSex2
            // 
            this.lblPriSex2.AutoSize = true;
            this.lblPriSex2.BackColor = System.Drawing.Color.Red;
            this.lblPriSex2.Location = new System.Drawing.Point(543, 198);
            this.lblPriSex2.Name = "lblPriSex2";
            this.lblPriSex2.Size = new System.Drawing.Size(17, 12);
            this.lblPriSex2.TabIndex = 85;
            this.lblPriSex2.Text = "印";
            // 
            // lblPriDept2
            // 
            this.lblPriDept2.AutoSize = true;
            this.lblPriDept2.BackColor = System.Drawing.Color.Red;
            this.lblPriDept2.Location = new System.Drawing.Point(543, 225);
            this.lblPriDept2.Name = "lblPriDept2";
            this.lblPriDept2.Size = new System.Drawing.Size(17, 12);
            this.lblPriDept2.TabIndex = 84;
            this.lblPriDept2.Text = "印";
            // 
            // lblPriJinE2
            // 
            this.lblPriJinE2.AutoSize = true;
            this.lblPriJinE2.BackColor = System.Drawing.Color.Red;
            this.lblPriJinE2.Location = new System.Drawing.Point(543, 252);
            this.lblPriJinE2.Name = "lblPriJinE2";
            this.lblPriJinE2.Size = new System.Drawing.Size(17, 12);
            this.lblPriJinE2.TabIndex = 83;
            this.lblPriJinE2.Text = "印";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(477, 306);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(53, 12);
            this.label43.TabIndex = 82;
            this.label43.Text = "支 票 号";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(477, 333);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(53, 12);
            this.label44.TabIndex = 81;
            this.label44.Text = "收 款 员";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(477, 90);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(53, 12);
            this.label45.TabIndex = 80;
            this.label45.Text = "票 据 号";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(477, 117);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(53, 12);
            this.label46.TabIndex = 79;
            this.label46.Text = "交费日期";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(477, 144);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(53, 12);
            this.label47.TabIndex = 78;
            this.label47.Text = "住院号码";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(477, 171);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(53, 12);
            this.label48.TabIndex = 77;
            this.label48.Text = "姓    名";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(477, 198);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(53, 12);
            this.label49.TabIndex = 76;
            this.label49.Text = "性    别";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(477, 225);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(53, 12);
            this.label50.TabIndex = 75;
            this.label50.Text = "住院科室";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(477, 252);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(53, 12);
            this.label51.TabIndex = 74;
            this.label51.Text = "预交金额";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(507, 60);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(65, 12);
            this.label52.TabIndex = 73;
            this.label52.Text = "(报销无效)";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(477, 37);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(125, 12);
            this.label53.TabIndex = 72;
            this.label53.Text = "预收住院医疗交款凭证";
            // 
            // lblPriCheckNo3
            // 
            this.lblPriCheckNo3.AutoSize = true;
            this.lblPriCheckNo3.BackColor = System.Drawing.Color.Red;
            this.lblPriCheckNo3.Location = new System.Drawing.Point(796, 306);
            this.lblPriCheckNo3.Name = "lblPriCheckNo3";
            this.lblPriCheckNo3.Size = new System.Drawing.Size(17, 12);
            this.lblPriCheckNo3.TabIndex = 113;
            this.lblPriCheckNo3.Text = "印";
            // 
            // lblPriOperNo3
            // 
            this.lblPriOperNo3.AutoSize = true;
            this.lblPriOperNo3.BackColor = System.Drawing.Color.Red;
            this.lblPriOperNo3.Location = new System.Drawing.Point(796, 333);
            this.lblPriOperNo3.Name = "lblPriOperNo3";
            this.lblPriOperNo3.Size = new System.Drawing.Size(17, 12);
            this.lblPriOperNo3.TabIndex = 112;
            this.lblPriOperNo3.Text = "印";
            // 
            // lblPriDaXie3
            // 
            this.lblPriDaXie3.AutoSize = true;
            this.lblPriDaXie3.BackColor = System.Drawing.Color.Red;
            this.lblPriDaXie3.Location = new System.Drawing.Point(730, 279);
            this.lblPriDaXie3.Name = "lblPriDaXie3";
            this.lblPriDaXie3.Size = new System.Drawing.Size(17, 12);
            this.lblPriDaXie3.TabIndex = 111;
            this.lblPriDaXie3.Text = "印";
            // 
            // lblPriReceiptNo3
            // 
            this.lblPriReceiptNo3.AutoSize = true;
            this.lblPriReceiptNo3.BackColor = System.Drawing.Color.Red;
            this.lblPriReceiptNo3.Location = new System.Drawing.Point(796, 90);
            this.lblPriReceiptNo3.Name = "lblPriReceiptNo3";
            this.lblPriReceiptNo3.Size = new System.Drawing.Size(17, 12);
            this.lblPriReceiptNo3.TabIndex = 110;
            this.lblPriReceiptNo3.Text = "印";
            // 
            // lblPriOperDate3
            // 
            this.lblPriOperDate3.AutoSize = true;
            this.lblPriOperDate3.BackColor = System.Drawing.Color.Red;
            this.lblPriOperDate3.Location = new System.Drawing.Point(796, 117);
            this.lblPriOperDate3.Name = "lblPriOperDate3";
            this.lblPriOperDate3.Size = new System.Drawing.Size(17, 12);
            this.lblPriOperDate3.TabIndex = 109;
            this.lblPriOperDate3.Text = "印";
            // 
            // lblPriInpatientNo3
            // 
            this.lblPriInpatientNo3.AutoSize = true;
            this.lblPriInpatientNo3.BackColor = System.Drawing.Color.Red;
            this.lblPriInpatientNo3.Location = new System.Drawing.Point(796, 144);
            this.lblPriInpatientNo3.Name = "lblPriInpatientNo3";
            this.lblPriInpatientNo3.Size = new System.Drawing.Size(17, 12);
            this.lblPriInpatientNo3.TabIndex = 108;
            this.lblPriInpatientNo3.Text = "印";
            // 
            // lblPriName3
            // 
            this.lblPriName3.AutoSize = true;
            this.lblPriName3.BackColor = System.Drawing.Color.Red;
            this.lblPriName3.Location = new System.Drawing.Point(796, 171);
            this.lblPriName3.Name = "lblPriName3";
            this.lblPriName3.Size = new System.Drawing.Size(17, 12);
            this.lblPriName3.TabIndex = 107;
            this.lblPriName3.Text = "印";
            // 
            // lblPriSex3
            // 
            this.lblPriSex3.AutoSize = true;
            this.lblPriSex3.BackColor = System.Drawing.Color.Red;
            this.lblPriSex3.Location = new System.Drawing.Point(796, 198);
            this.lblPriSex3.Name = "lblPriSex3";
            this.lblPriSex3.Size = new System.Drawing.Size(17, 12);
            this.lblPriSex3.TabIndex = 106;
            this.lblPriSex3.Text = "印";
            // 
            // lblPriDept3
            // 
            this.lblPriDept3.AutoSize = true;
            this.lblPriDept3.BackColor = System.Drawing.Color.Red;
            this.lblPriDept3.Location = new System.Drawing.Point(796, 225);
            this.lblPriDept3.Name = "lblPriDept3";
            this.lblPriDept3.Size = new System.Drawing.Size(17, 12);
            this.lblPriDept3.TabIndex = 105;
            this.lblPriDept3.Text = "印";
            // 
            // lblPriJinE3
            // 
            this.lblPriJinE3.AutoSize = true;
            this.lblPriJinE3.BackColor = System.Drawing.Color.Red;
            this.lblPriJinE3.Location = new System.Drawing.Point(796, 252);
            this.lblPriJinE3.Name = "lblPriJinE3";
            this.lblPriJinE3.Size = new System.Drawing.Size(17, 12);
            this.lblPriJinE3.TabIndex = 104;
            this.lblPriJinE3.Text = "印";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(730, 306);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(53, 12);
            this.label64.TabIndex = 103;
            this.label64.Text = "支 票 号";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(730, 333);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(53, 12);
            this.label65.TabIndex = 102;
            this.label65.Text = "收 款 员";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(730, 90);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(53, 12);
            this.label66.TabIndex = 101;
            this.label66.Text = "票 据 号";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(730, 117);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(53, 12);
            this.label67.TabIndex = 100;
            this.label67.Text = "交费日期";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(730, 144);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(53, 12);
            this.label68.TabIndex = 99;
            this.label68.Text = "住院号码";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(730, 171);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(53, 12);
            this.label69.TabIndex = 98;
            this.label69.Text = "姓    名";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(730, 198);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(53, 12);
            this.label70.TabIndex = 97;
            this.label70.Text = "性    别";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(730, 225);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(53, 12);
            this.label71.TabIndex = 96;
            this.label71.Text = "住院科室";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(730, 252);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(53, 12);
            this.label72.TabIndex = 95;
            this.label72.Text = "预交金额";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(754, 60);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(65, 12);
            this.label73.TabIndex = 94;
            this.label73.Text = "(报销无效)";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(730, 37);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(113, 12);
            this.label74.TabIndex = 93;
            this.label74.Text = "预收住院医疗费收据";
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label75.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label75.Location = new System.Drawing.Point(199, 86);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(2, 263);
            this.label75.TabIndex = 114;
            this.label75.Text = "|||||||||||||||||||||||||||||||||||||||";
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label76.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label76.Location = new System.Drawing.Point(705, 86);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(2, 263);
            this.label76.TabIndex = 115;
            this.label76.Text = "|||||||||||||||||||||||||||||||||||||||";
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label77.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label77.Location = new System.Drawing.Point(452, 86);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(2, 263);
            this.label77.TabIndex = 116;
            this.label77.Text = "|||||||||||||||||||||||||||||||||||||||";
            // 
            // ucPrepayPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.lblPriCheckNo3);
            this.Controls.Add(this.lblPriOperNo3);
            this.Controls.Add(this.lblPriDaXie3);
            this.Controls.Add(this.lblPriReceiptNo3);
            this.Controls.Add(this.lblPriOperDate3);
            this.Controls.Add(this.lblPriInpatientNo3);
            this.Controls.Add(this.lblPriName3);
            this.Controls.Add(this.lblPriSex3);
            this.Controls.Add(this.lblPriDept3);
            this.Controls.Add(this.lblPriJinE3);
            this.Controls.Add(this.lblPriCheckNo2);
            this.Controls.Add(this.lblPriOperNo2);
            this.Controls.Add(this.lblPriDaXie2);
            this.Controls.Add(this.lblPriReceiptNo2);
            this.Controls.Add(this.lblPriOperDate2);
            this.Controls.Add(this.lblPriInpatientNo2);
            this.Controls.Add(this.lblPriName2);
            this.Controls.Add(this.lblPriSex2);
            this.Controls.Add(this.lblPriDept2);
            this.Controls.Add(this.lblPriJinE2);
            this.Controls.Add(this.lblPriCheckNo1);
            this.Controls.Add(this.lblPriOperNo1);
            this.Controls.Add(this.lblPriDaXie1);
            this.Controls.Add(this.lblPriReceiptNo1);
            this.Controls.Add(this.lblPriOperDate1);
            this.Controls.Add(this.lblPriInpatientNo1);
            this.Controls.Add(this.lblPriName1);
            this.Controls.Add(this.lblPriSex1);
            this.Controls.Add(this.lblPriDept1);
            this.Controls.Add(this.lblPriJinE1);
            this.Controls.Add(this.lblPriCheckNo);
            this.Controls.Add(this.lblPriOperNo);
            this.Controls.Add(this.lblPriDaXie);
            this.Controls.Add(this.lblPriReceiptNo);
            this.Controls.Add(this.lblPriOperDate);
            this.Controls.Add(this.lblPriInpatientNo);
            this.Controls.Add(this.lblPriName);
            this.Controls.Add(this.lblPriSex);
            this.Controls.Add(this.lblPriDept);
            this.Controls.Add(this.lblPriJinE);
            this.Controls.Add(this.label77);
            this.Controls.Add(this.label76);
            this.Controls.Add(this.label75);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.label74);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucPrepayPrint";
            this.Size = new System.Drawing.Size(933, 370);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool isReturn = false; //是否作废发票，控制显示"作废字样";
        public bool IsRetrun
        {
            set
            {
                isReturn = value;
                //if (isReturn)
                //{
                //    this.lbRetrun.Visible = true;
                //}
                //else
                //{
                //    this.lbRetrun.Visible = false;
                //}
            }
        }



        /// <summary>
        /// 打印界面赋值
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="Prepay"></param>
        public void SetPrintValue(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay)
        {
            #region 收据打印
            //票据号
            this.lblPriReceiptNo.Text = prepay.RecipeNO;
            //交费日期
            this.lblPriOperDate.Text = prepay.PrepayOper.OperTime.ToShortDateString();
            //住院号码
            this.lblPriInpatientNo.Text = patient.PID.PatientNO;
            //姓名
            this.lblPriName.Text = patient.Name;
            //性别
            this.lblPriSex.Text = patient.Sex.Name;
            //住院科室
            this.lblPriDept.Text = patient.PVisit.PatientLocation.Dept.Name;
            //预交金额
            this.lblPriJinE.Text = Neusoft.FrameWork.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();
            //预交金大写
            this.lblPriDaXie.Text = Function.ConvertNumberToChineseMoneyString(prepay.FT.PrepayCost.ToString());
            //支票号
            this.lblPriCheckNo.Text = prepay.Bank.InvoiceNO;
            //收款员
            this.lblPriOperNo.Text = prepay.PrepayOper.ID;
            #endregion

            #region 收据打印
            //票据号
            this.lblPriReceiptNo1.Text = prepay.RecipeNO;
            //交费日期
            this.lblPriOperDate1.Text = prepay.PrepayOper.OperTime.ToShortDateString();
            //住院号码
            this.lblPriInpatientNo1.Text = patient.PID.PatientNO;
            //姓名
            this.lblPriName1.Text = patient.Name;
            //性别
            this.lblPriSex1.Text = patient.Sex.Name;
            //住院科室
            this.lblPriDept1.Text = patient.PVisit.PatientLocation.Dept.Name;
            //预交金额
            this.lblPriJinE1.Text = Neusoft.FrameWork.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();
            //预交金大写
            this.lblPriDaXie1.Text = Function.ConvertNumberToChineseMoneyString(prepay.FT.PrepayCost.ToString());
            //支票号
            this.lblPriCheckNo1.Text = prepay.Bank.InvoiceNO;
            //收款员
            this.lblPriOperNo1.Text = prepay.PrepayOper.ID;
            #endregion

            #region 收据打印
            //票据号
            this.lblPriReceiptNo2.Text = prepay.RecipeNO;
            //交费日期
            this.lblPriOperDate2.Text = prepay.PrepayOper.OperTime.ToShortDateString();
            //住院号码
            this.lblPriInpatientNo2.Text = patient.PID.PatientNO;
            //姓名
            this.lblPriName2.Text = patient.Name;
            //性别
            this.lblPriSex2.Text = patient.Sex.Name;
            //住院科室
            this.lblPriDept2.Text = patient.PVisit.PatientLocation.Dept.Name;
            //预交金额
            this.lblPriJinE2.Text = Neusoft.FrameWork.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();
            //预交金大写
            this.lblPriDaXie2.Text = Function.ConvertNumberToChineseMoneyString(prepay.FT.PrepayCost.ToString());
            //支票号
            this.lblPriCheckNo2.Text = prepay.Bank.InvoiceNO;
            //收款员
            this.lblPriOperNo2.Text = prepay.PrepayOper.ID;
            #endregion

            #region 收据打印
            //票据号
            this.lblPriReceiptNo3.Text = prepay.RecipeNO;
            //交费日期
            this.lblPriOperDate3.Text = prepay.PrepayOper.OperTime.ToShortDateString();
            //住院号码
            this.lblPriInpatientNo3.Text = patient.PID.PatientNO;
            //姓名
            this.lblPriName3.Text = patient.Name;
            //性别
            this.lblPriSex3.Text = patient.Sex.Name;
            //住院科室
            this.lblPriDept3.Text = patient.PVisit.PatientLocation.Dept.Name;
            //预交金额
            this.lblPriJinE3.Text = Neusoft.FrameWork.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();
            //预交金大写
            this.lblPriDaXie3.Text = Function.ConvertNumberToChineseMoneyString(prepay.FT.PrepayCost.ToString());
            //支票号
            this.lblPriCheckNo3.Text = prepay.Bank.InvoiceNO;
            //收款员
            this.lblPriOperNo3.Text = prepay.PrepayOper.ID;
            #endregion
      
            // this.lblDeptName.Text = patientInfo.PVisit.PatientLocation.Dept.Name;//患者所在科室
           
            
            //this.lblName.Text = patientInfo.Name;//患者姓名
            //this.lblOper.Text = prepay.PrepayOper.ID;//经办
            //this.lblPatientNo.Text = patientInfo.PID.PatientNO;


            //this.lblPrepayCost.Text = Neusoft.FrameWork.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();//金额合计

            //this.lblRecipe.Text = prepay.RecipeNO;//预交金发票号
            //this.lblTime.Text = prepay.PrepayOper.OperTime.ToShortDateString();//交款时间
            //if (prepay.PayType.Name == "")
            //{
            //    switch (prepay.PayType.ID.ToString())
            //    {
            //        case "CA":
            //            prepay.PayType.Name = "现金";
            //            break;
            //        case "CH":
            //            prepay.PayType.Name = "支票";
            //            break;
            //        case "PO":
            //            prepay.PayType.Name = "汇票";
            //            break;
            //        case "CD":
            //            prepay.PayType.Name = "信用卡";
            //            break;
            //        case "DB":
            //            prepay.PayType.Name = "借记卡";
            //            break;
            //        default:
            //            prepay.PayType.Name = "其他";
            //            break;
            //    }
            //}
            //this.lblType.Text = "(" + prepay.PayType.Name + ")";//付款方式
            ////			this.lblUpPreCost.Text = Function.ChangeCash(Prepay.Pre_Cost);//-------------- 人民币合计
            //this.lblUpPreCost.Text =  Function.ConvertNumberToChineseMoneyString(prepay.FT.PrepayCost.ToString());

            //switch (prepay.PayType.ID.ToString())
            //{
            //    case "CA":   //现金

            //        break;
            //    case "CH":   //支票  
            //        this.lblBank.Text = prepay.Bank.Name;//开户银行
            //        this.lblBankAcount.Text = prepay.Bank.Account;//账号
            //        //					this.labCardNo.Text = Prepay.AccountBank.ID;//卡号
            //        this.labWorkName.Text = prepay.Bank.WorkName;//交款单位				
            //        break;
            //    case "PO"://汇票
            //        this.lblBank.Text = prepay.Bank.Name;//开户银行
            //        this.lblBankAcount.Text = prepay.Bank.Account;//账号
            //        this.labWorkName.Text = prepay.Bank.WorkName;//交款单位
            //        break;
            //    default: //delete by maokb           
            //        //					this.lblBank.Text=Prepay.AccountBank.Name;//开户银行
            //        ////					this.lblBankAcount.Text=Prepay.AccountBank.Account;//账号
            //        //					this.labCardNo.Text = Prepay.AccountBank.ID;//卡号
            //        //					this.labWorkName.Text = Prepay.AccountBank.WorkName.ToString();//交款单位
            //        break;
            //}




        }

        #region IPrepayPrint 成员

        public int Clear()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 0;
        }

        public int Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
           

            this.Size = new System.Drawing.Size(500, 364);

            print.PrintPage(0, 0, this);

            return 1;
        }

        public void SetTrans(System.Data.IDbTransaction trans)
        {
            //throw new Exception("The method or operation is not implemented.");
            return;
        }

        /// <summary>
        /// 打印界面赋值
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="Prepay"></param>
        public int SetValue(
            Neusoft.HISFC.Models.RADT.PatientInfo patient,
            Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay)
        {
            try
            {
                #region 收据打印
                //票据号
                this.lblPriReceiptNo.Text = prepay.RecipeNO;
                //交费日期
                this.lblPriOperDate.Text = prepay.PrepayOper.OperTime.ToShortDateString();
                //住院号码
                this.lblPriInpatientNo.Text = patient.PID.PatientNO;
                //姓名
                this.lblPriName.Text = patient.Name;
                //性别
                this.lblPriSex.Text = patient.Sex.Name;
                //住院科室
                this.lblPriDept.Text = patient.PVisit.PatientLocation.Dept.Name;
                //预交金额
                this.lblPriJinE.Text = Neusoft.FrameWork.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();
                //预交金大写
                this.lblPriDaXie.Text = Function.ConvertNumberToChineseMoneyString(prepay.FT.PrepayCost.ToString());
                //支票号
                this.lblPriCheckNo.Text = prepay.Bank.InvoiceNO;
                //收款员
                this.lblPriOperNo.Text = prepay.PrepayOper.ID;  
                #endregion

                #region 收据打印
                //票据号
                this.lblPriReceiptNo1.Text = prepay.RecipeNO;
                //交费日期
                this.lblPriOperDate1.Text = prepay.PrepayOper.OperTime.ToShortDateString();
                //住院号码
                this.lblPriInpatientNo1.Text = patient.PID.PatientNO;
                //姓名
                this.lblPriName1.Text = patient.Name;
                //性别
                this.lblPriSex1.Text = patient.Sex.Name;
                //住院科室
                this.lblPriDept1.Text = patient.PVisit.PatientLocation.Dept.Name;
                //预交金额
                this.lblPriJinE1.Text = Neusoft.FrameWork.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();
                //预交金大写
                this.lblPriDaXie1.Text = Function.ConvertNumberToChineseMoneyString(prepay.FT.PrepayCost.ToString());
                //支票号
                this.lblPriCheckNo1.Text = prepay.Bank.InvoiceNO;
                //收款员
                this.lblPriOperNo1.Text = prepay.PrepayOper.ID;
                #endregion

                #region 收据打印
                //票据号
                this.lblPriReceiptNo2.Text = prepay.RecipeNO;
                //交费日期
                this.lblPriOperDate2.Text = prepay.PrepayOper.OperTime.ToShortDateString();
                //住院号码
                this.lblPriInpatientNo2.Text = patient.PID.PatientNO;
                //姓名
                this.lblPriName2.Text = patient.Name;
                //性别
                this.lblPriSex2.Text = patient.Sex.Name;
                //住院科室
                this.lblPriDept2.Text = patient.PVisit.PatientLocation.Dept.Name;
                //预交金额
                this.lblPriJinE2.Text = Neusoft.FrameWork.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();
                //预交金大写
                this.lblPriDaXie2.Text = Function.ConvertNumberToChineseMoneyString(prepay.FT.PrepayCost.ToString());
                //支票号
                this.lblPriCheckNo2.Text = prepay.Bank.InvoiceNO;
                //收款员
                this.lblPriOperNo2.Text = prepay.PrepayOper.ID;
                #endregion

                #region 收据打印
                //票据号
                this.lblPriReceiptNo3.Text = prepay.RecipeNO;
                //交费日期
                this.lblPriOperDate3.Text = prepay.PrepayOper.OperTime.ToShortDateString();
                //住院号码
                this.lblPriInpatientNo3.Text = patient.PID.PatientNO;
                //姓名
                this.lblPriName3.Text = patient.Name;
                //性别
                this.lblPriSex3.Text = patient.Sex.Name;
                //住院科室
                this.lblPriDept3.Text = patient.PVisit.PatientLocation.Dept.Name;
                //预交金额
                this.lblPriJinE3.Text = Neusoft.FrameWork.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();
                //预交金大写
                this.lblPriDaXie3.Text = Function.ConvertNumberToChineseMoneyString(prepay.FT.PrepayCost.ToString());
                //支票号
                this.lblPriCheckNo3.Text = prepay.Bank.InvoiceNO;
                //收款员
                this.lblPriOperNo3.Text = prepay.PrepayOper.ID;
                #endregion
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 1;          
        }

        public System.Data.IDbTransaction Trans
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

       
    }
}
