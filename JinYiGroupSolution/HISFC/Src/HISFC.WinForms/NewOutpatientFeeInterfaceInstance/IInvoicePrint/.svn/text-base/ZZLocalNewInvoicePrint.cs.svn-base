using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace OutpatientInvoicePrint
{
	/// <summary>
	/// 医生站上之后的新门诊发票，显示八条明细，小联作废。
	/// </summary>
    public class ZZLocalNewInvoicePrint : System.Windows.Forms.UserControl, Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
	{
		#region windows代码


        /// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        public ZZLocalNewInvoicePrint()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化

		}

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPrint = new System.Windows.Forms.Label();
            this.lblRePrint2 = new System.Windows.Forms.Label();
            this.lblRePrint1 = new System.Windows.Forms.Label();
            this.lblRePrint3 = new System.Windows.Forms.Label();
            this.lblCardNo5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblCardNo4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblCardNo3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblCardNo2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblCardNo1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblCardNo0 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblPayKind1 = new System.Windows.Forms.Label();
            this.lblPayKind3 = new System.Windows.Forms.Label();
            this.lbltotcost5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTotCost4 = new System.Windows.Forms.Label();
            this.invoiceno2 = new System.Windows.Forms.Label();
            this.invoiceno6 = new System.Windows.Forms.Label();
            this.invoiceno5 = new System.Windows.Forms.Label();
            this.invoiceno4 = new System.Windows.Forms.Label();
            this.invoiceno3 = new System.Windows.Forms.Label();
            this.invoiceno1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDistroy5 = new System.Windows.Forms.Label();
            this.lblDistroy4 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.lblDistroy6 = new System.Windows.Forms.Label();
            this.lblItemFee6 = new System.Windows.Forms.Label();
            this.lblItemFee5 = new System.Windows.Forms.Label();
            this.lblItemFee4 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lbl3XianJinZhiFu = new System.Windows.Forms.Label();
            this.lbl3GeRenZhangHu = new System.Windows.Forms.Label();
            this.lbl2XianJinZhiFu = new System.Windows.Forms.Label();
            this.lbl3GongWuYuan = new System.Windows.Forms.Label();
            this.lbl2GeRenZhangHu = new System.Windows.Forms.Label();
            this.lbl3DaEJiZhang = new System.Windows.Forms.Label();
            this.lbl2GongWuYuan = new System.Windows.Forms.Label();
            this.lbl3TongChouJiZhang = new System.Windows.Forms.Label();
            this.lbl2DaEJiZhang = new System.Windows.Forms.Label();
            this.lbl3QiFuBiaoZhun = new System.Windows.Forms.Label();
            this.lbl2TongChouJiZhang = new System.Windows.Forms.Label();
            this.lbl3AnBiLiZhiFu = new System.Windows.Forms.Label();
            this.lbl2QiFuBiaoZhun = new System.Windows.Forms.Label();
            this.lbl3GeRenZhiFu = new System.Windows.Forms.Label();
            this.lbl2AnBiLiZhiFu = new System.Windows.Forms.Label();
            this.lblItem6 = new System.Windows.Forms.Label();
            this.lbl2GeRenZhiFu = new System.Windows.Forms.Label();
            this.lblItem5 = new System.Windows.Forms.Label();
            this.lbl3ZhiFeiFeiYong = new System.Windows.Forms.Label();
            this.lblItem4 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.lbl2ZhiFeiFeiYong = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lblOp6 = new System.Windows.Forms.Label();
            this.lbl3ItemFee7 = new System.Windows.Forms.Label();
            this.lbl1ItemFee7 = new System.Windows.Forms.Label();
            this.lbl3ItemFee6 = new System.Windows.Forms.Label();
            this.lbl1ItemFee6 = new System.Windows.Forms.Label();
            this.lbl3ItemFee5 = new System.Windows.Forms.Label();
            this.lbl1ItemFee5 = new System.Windows.Forms.Label();
            this.lbl3ItemFee4 = new System.Windows.Forms.Label();
            this.lbl1ItemFee4 = new System.Windows.Forms.Label();
            this.lbl3ItemFee3 = new System.Windows.Forms.Label();
            this.lbl3ItemFee2 = new System.Windows.Forms.Label();
            this.lbl1ItemFee3 = new System.Windows.Forms.Label();
            this.lbl3Item7 = new System.Windows.Forms.Label();
            this.lbl1ItemFee2 = new System.Windows.Forms.Label();
            this.lbl3ItemFee1 = new System.Windows.Forms.Label();
            this.lbl1Item7 = new System.Windows.Forms.Label();
            this.lbl3Item6 = new System.Windows.Forms.Label();
            this.lbl1ItemFee1 = new System.Windows.Forms.Label();
            this.lbl3ItemFee0 = new System.Windows.Forms.Label();
            this.lbl1Item6 = new System.Windows.Forms.Label();
            this.lbl3Item5 = new System.Windows.Forms.Label();
            this.lbl1ItemFee0 = new System.Windows.Forms.Label();
            this.lbl1Item5 = new System.Windows.Forms.Label();
            this.lbl3Item4 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl1Item4 = new System.Windows.Forms.Label();
            this.lbl3Item3 = new System.Windows.Forms.Label();
            this.lblOp5 = new System.Windows.Forms.Label();
            this.lbl1Item3 = new System.Windows.Forms.Label();
            this.lbl3Item2 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.lbl1Item2 = new System.Windows.Forms.Label();
            this.lbl3Item1 = new System.Windows.Forms.Label();
            this.lblOp4 = new System.Windows.Forms.Label();
            this.lbl1Item1 = new System.Windows.Forms.Label();
            this.lbl3Item0 = new System.Windows.Forms.Label();
            this.lblOp3 = new System.Windows.Forms.Label();
            this.lbl1Item0 = new System.Windows.Forms.Label();
            this.lblOp2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblOp1 = new System.Windows.Forms.Label();
            this.lblTotCost3 = new System.Windows.Forms.Label();
            this.lblTotCost1 = new System.Windows.Forms.Label();
            this.lblHosName6 = new System.Windows.Forms.Label();
            this.lblHosName5 = new System.Windows.Forms.Label();
            this.lblDeptE6 = new System.Windows.Forms.Label();
            this.lblDeptE5 = new System.Windows.Forms.Label();
            this.lblDeptR6 = new System.Windows.Forms.Label();
            this.lblDeptE4 = new System.Windows.Forms.Label();
            this.lblDeptR5 = new System.Windows.Forms.Label();
            this.lblDeptR4 = new System.Windows.Forms.Label();
            this.lblHosName4 = new System.Windows.Forms.Label();
            this.lblHosName3 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.lblPactName3 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblPactName2 = new System.Windows.Forms.Label();
            this.lblPactName1 = new System.Windows.Forms.Label();
            this.lblDate6 = new System.Windows.Forms.Label();
            this.lblDate5 = new System.Windows.Forms.Label();
            this.lblDate4 = new System.Windows.Forms.Label();
            this.lblName6 = new System.Windows.Forms.Label();
            this.lblDate3 = new System.Windows.Forms.Label();
            this.lblName5 = new System.Windows.Forms.Label();
            this.lblDate2 = new System.Windows.Forms.Label();
            this.lblName4 = new System.Windows.Forms.Label();
            this.lblName3 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblDate1 = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblReprint = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPrint);
            this.panel1.Controls.Add(this.lblRePrint2);
            this.panel1.Controls.Add(this.lblRePrint1);
            this.panel1.Controls.Add(this.lblRePrint3);
            this.panel1.Controls.Add(this.lblCardNo5);
            this.panel1.Controls.Add(this.lblCardNo4);
            this.panel1.Controls.Add(this.lblCardNo3);
            this.panel1.Controls.Add(this.lblCardNo2);
            this.panel1.Controls.Add(this.lblCardNo1);
            this.panel1.Controls.Add(this.lblCardNo0);
            this.panel1.Controls.Add(this.lblPayKind1);
            this.panel1.Controls.Add(this.lblPayKind3);
            this.panel1.Controls.Add(this.lbltotcost5);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lblTotCost4);
            this.panel1.Controls.Add(this.invoiceno2);
            this.panel1.Controls.Add(this.invoiceno6);
            this.panel1.Controls.Add(this.invoiceno5);
            this.panel1.Controls.Add(this.invoiceno4);
            this.panel1.Controls.Add(this.invoiceno3);
            this.panel1.Controls.Add(this.invoiceno1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDistroy5);
            this.panel1.Controls.Add(this.lblDistroy4);
            this.panel1.Controls.Add(this.label54);
            this.panel1.Controls.Add(this.lblDistroy6);
            this.panel1.Controls.Add(this.lblItemFee6);
            this.panel1.Controls.Add(this.lblItemFee5);
            this.panel1.Controls.Add(this.lblItemFee4);
            this.panel1.Controls.Add(this.label52);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.lbl3XianJinZhiFu);
            this.panel1.Controls.Add(this.lbl3GeRenZhangHu);
            this.panel1.Controls.Add(this.lbl2XianJinZhiFu);
            this.panel1.Controls.Add(this.lbl3GongWuYuan);
            this.panel1.Controls.Add(this.lbl2GeRenZhangHu);
            this.panel1.Controls.Add(this.lbl3DaEJiZhang);
            this.panel1.Controls.Add(this.lbl2GongWuYuan);
            this.panel1.Controls.Add(this.lbl3TongChouJiZhang);
            this.panel1.Controls.Add(this.lbl2DaEJiZhang);
            this.panel1.Controls.Add(this.lbl3QiFuBiaoZhun);
            this.panel1.Controls.Add(this.lbl2TongChouJiZhang);
            this.panel1.Controls.Add(this.lbl3AnBiLiZhiFu);
            this.panel1.Controls.Add(this.lbl2QiFuBiaoZhun);
            this.panel1.Controls.Add(this.lbl3GeRenZhiFu);
            this.panel1.Controls.Add(this.lbl2AnBiLiZhiFu);
            this.panel1.Controls.Add(this.lblItem6);
            this.panel1.Controls.Add(this.lbl2GeRenZhiFu);
            this.panel1.Controls.Add(this.lblItem5);
            this.panel1.Controls.Add(this.lbl3ZhiFeiFeiYong);
            this.panel1.Controls.Add(this.lblItem4);
            this.panel1.Controls.Add(this.label51);
            this.panel1.Controls.Add(this.lbl2ZhiFeiFeiYong);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.lblOp6);
            this.panel1.Controls.Add(this.lbl3ItemFee7);
            this.panel1.Controls.Add(this.lbl1ItemFee7);
            this.panel1.Controls.Add(this.lbl3ItemFee6);
            this.panel1.Controls.Add(this.lbl1ItemFee6);
            this.panel1.Controls.Add(this.lbl3ItemFee5);
            this.panel1.Controls.Add(this.lbl1ItemFee5);
            this.panel1.Controls.Add(this.lbl3ItemFee4);
            this.panel1.Controls.Add(this.lbl1ItemFee4);
            this.panel1.Controls.Add(this.lbl3ItemFee3);
            this.panel1.Controls.Add(this.lbl3ItemFee2);
            this.panel1.Controls.Add(this.lbl1ItemFee3);
            this.panel1.Controls.Add(this.lbl3Item7);
            this.panel1.Controls.Add(this.lbl1ItemFee2);
            this.panel1.Controls.Add(this.lbl3ItemFee1);
            this.panel1.Controls.Add(this.lbl1Item7);
            this.panel1.Controls.Add(this.lbl3Item6);
            this.panel1.Controls.Add(this.lbl1ItemFee1);
            this.panel1.Controls.Add(this.lbl3ItemFee0);
            this.panel1.Controls.Add(this.lbl1Item6);
            this.panel1.Controls.Add(this.lbl3Item5);
            this.panel1.Controls.Add(this.lbl1ItemFee0);
            this.panel1.Controls.Add(this.lbl1Item5);
            this.panel1.Controls.Add(this.lbl3Item4);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.lbl1Item4);
            this.panel1.Controls.Add(this.lbl3Item3);
            this.panel1.Controls.Add(this.lblOp5);
            this.panel1.Controls.Add(this.lbl1Item3);
            this.panel1.Controls.Add(this.lbl3Item2);
            this.panel1.Controls.Add(this.label66);
            this.panel1.Controls.Add(this.lbl1Item2);
            this.panel1.Controls.Add(this.lbl3Item1);
            this.panel1.Controls.Add(this.lblOp4);
            this.panel1.Controls.Add(this.lbl1Item1);
            this.panel1.Controls.Add(this.lbl3Item0);
            this.panel1.Controls.Add(this.lblOp3);
            this.panel1.Controls.Add(this.lbl1Item0);
            this.panel1.Controls.Add(this.lblOp2);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.lblOp1);
            this.panel1.Controls.Add(this.lblTotCost3);
            this.panel1.Controls.Add(this.lblTotCost1);
            this.panel1.Controls.Add(this.lblHosName6);
            this.panel1.Controls.Add(this.lblHosName5);
            this.panel1.Controls.Add(this.lblDeptE6);
            this.panel1.Controls.Add(this.lblDeptE5);
            this.panel1.Controls.Add(this.lblDeptR6);
            this.panel1.Controls.Add(this.lblDeptE4);
            this.panel1.Controls.Add(this.lblDeptR5);
            this.panel1.Controls.Add(this.lblDeptR4);
            this.panel1.Controls.Add(this.lblHosName4);
            this.panel1.Controls.Add(this.lblHosName3);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.label53);
            this.panel1.Controls.Add(this.lblPactName3);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.lblPactName2);
            this.panel1.Controls.Add(this.lblPactName1);
            this.panel1.Controls.Add(this.lblDate6);
            this.panel1.Controls.Add(this.lblDate5);
            this.panel1.Controls.Add(this.lblDate4);
            this.panel1.Controls.Add(this.lblName6);
            this.panel1.Controls.Add(this.lblDate3);
            this.panel1.Controls.Add(this.lblName5);
            this.panel1.Controls.Add(this.lblDate2);
            this.panel1.Controls.Add(this.lblName4);
            this.panel1.Controls.Add(this.lblName3);
            this.panel1.Controls.Add(this.lblName2);
            this.panel1.Controls.Add(this.lblDate1);
            this.panel1.Controls.Add(this.lblName1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblReprint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 470);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblPrint
            // 
            this.lblPrint.AutoSize = true;
            this.lblPrint.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrint.Location = new System.Drawing.Point(174, 372);
            this.lblPrint.Name = "lblPrint";
            this.lblPrint.Size = new System.Drawing.Size(52, 21);
            this.lblPrint.TabIndex = 522;
            this.lblPrint.Text = "补打";
            this.lblPrint.Visible = false;
            // 
            // lblRePrint2
            // 
            this.lblRePrint2.AutoSize = true;
            this.lblRePrint2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRePrint2.Location = new System.Drawing.Point(884, 219);
            this.lblRePrint2.Name = "lblRePrint2";
            this.lblRePrint2.Size = new System.Drawing.Size(52, 21);
            this.lblRePrint2.TabIndex = 519;
            this.lblRePrint2.Text = "补打";
            this.lblRePrint2.Visible = false;
            // 
            // lblRePrint1
            // 
            this.lblRePrint1.AutoSize = true;
            this.lblRePrint1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRePrint1.Location = new System.Drawing.Point(783, 219);
            this.lblRePrint1.Name = "lblRePrint1";
            this.lblRePrint1.Size = new System.Drawing.Size(52, 21);
            this.lblRePrint1.TabIndex = 520;
            this.lblRePrint1.Text = "补打";
            this.lblRePrint1.Visible = false;
            // 
            // lblRePrint3
            // 
            this.lblRePrint3.AutoSize = true;
            this.lblRePrint3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRePrint3.Location = new System.Drawing.Point(984, 219);
            this.lblRePrint3.Name = "lblRePrint3";
            this.lblRePrint3.Size = new System.Drawing.Size(52, 21);
            this.lblRePrint3.TabIndex = 521;
            this.lblRePrint3.Text = "补打";
            this.lblRePrint3.Visible = false;
            // 
            // lblCardNo5
            // 
            this.lblCardNo5.AutoSize = true;
            this.lblCardNo5.Font = new System.Drawing.Font("宋体", 10F);
            this.lblCardNo5.Location = new System.Drawing.Point(975, 32);
            this.lblCardNo5.Name = "lblCardNo5";
            this.lblCardNo5.Size = new System.Drawing.Size(56, 14);
            this.lblCardNo5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblCardNo5.TabIndex = 518;
            this.lblCardNo5.Text = "病历号:";
            this.lblCardNo5.Visible = false;
            // 
            // lblCardNo4
            // 
            this.lblCardNo4.AutoSize = true;
            this.lblCardNo4.Font = new System.Drawing.Font("宋体", 10F);
            this.lblCardNo4.Location = new System.Drawing.Point(881, 32);
            this.lblCardNo4.Name = "lblCardNo4";
            this.lblCardNo4.Size = new System.Drawing.Size(56, 14);
            this.lblCardNo4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblCardNo4.TabIndex = 517;
            this.lblCardNo4.Text = "病历号:";
            this.lblCardNo4.Visible = false;
            // 
            // lblCardNo3
            // 
            this.lblCardNo3.AutoSize = true;
            this.lblCardNo3.Font = new System.Drawing.Font("宋体", 10F);
            this.lblCardNo3.Location = new System.Drawing.Point(775, 32);
            this.lblCardNo3.Name = "lblCardNo3";
            this.lblCardNo3.Size = new System.Drawing.Size(56, 14);
            this.lblCardNo3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblCardNo3.TabIndex = 516;
            this.lblCardNo3.Text = "病历号:";
            this.lblCardNo3.Visible = false;
            // 
            // lblCardNo2
            // 
            this.lblCardNo2.AutoSize = true;
            this.lblCardNo2.Font = new System.Drawing.Font("宋体", 11F);
            this.lblCardNo2.Location = new System.Drawing.Point(430, 42);
            this.lblCardNo2.Name = "lblCardNo2";
            this.lblCardNo2.Size = new System.Drawing.Size(60, 15);
            this.lblCardNo2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblCardNo2.TabIndex = 515;
            this.lblCardNo2.Text = "病历号:";
            // 
            // lblCardNo1
            // 
            this.lblCardNo1.AutoSize = true;
            this.lblCardNo1.Font = new System.Drawing.Font("宋体", 11F);
            this.lblCardNo1.Location = new System.Drawing.Point(313, 42);
            this.lblCardNo1.Name = "lblCardNo1";
            this.lblCardNo1.Size = new System.Drawing.Size(60, 15);
            this.lblCardNo1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblCardNo1.TabIndex = 514;
            this.lblCardNo1.Text = "病历号:";
            // 
            // lblCardNo0
            // 
            this.lblCardNo0.AutoSize = true;
            this.lblCardNo0.Font = new System.Drawing.Font("宋体", 11F);
            this.lblCardNo0.Location = new System.Drawing.Point(124, 42);
            this.lblCardNo0.Name = "lblCardNo0";
            this.lblCardNo0.Size = new System.Drawing.Size(60, 15);
            this.lblCardNo0.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblCardNo0.TabIndex = 513;
            this.lblCardNo0.Text = "病历号:";
            // 
            // lblPayKind1
            // 
            this.lblPayKind1.AutoSize = true;
            this.lblPayKind1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPayKind1.Location = new System.Drawing.Point(55, 101);
            this.lblPayKind1.Name = "lblPayKind1";
            this.lblPayKind1.Size = new System.Drawing.Size(143, 15);
            this.lblPayKind1.TabIndex = 420;
            this.lblPayKind1.Text = "支付方式1+花费金额";
            // 
            // lblPayKind3
            // 
            this.lblPayKind3.AutoSize = true;
            this.lblPayKind3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPayKind3.Location = new System.Drawing.Point(418, 79);
            this.lblPayKind3.Name = "lblPayKind3";
            this.lblPayKind3.Size = new System.Drawing.Size(67, 15);
            this.lblPayKind3.TabIndex = 435;
            this.lblPayKind3.Text = "支付方式";
            // 
            // lbltotcost5
            // 
            this.lbltotcost5.AutoSize = true;
            this.lbltotcost5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltotcost5.Location = new System.Drawing.Point(305, 423);
            this.lbltotcost5.Name = "lbltotcost5";
            this.lbltotcost5.Size = new System.Drawing.Size(37, 15);
            this.lbltotcost5.TabIndex = 512;
            this.lbltotcost5.Text = "合计";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(64, 384);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 511;
            this.label15.Text = "账户余额";
            // 
            // lblTotCost4
            // 
            this.lblTotCost4.AutoSize = true;
            this.lblTotCost4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotCost4.Location = new System.Drawing.Point(671, 423);
            this.lblTotCost4.Name = "lblTotCost4";
            this.lblTotCost4.Size = new System.Drawing.Size(37, 15);
            this.lblTotCost4.TabIndex = 510;
            this.lblTotCost4.Text = "合计";
            // 
            // invoiceno2
            // 
            this.invoiceno2.AutoSize = true;
            this.invoiceno2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.invoiceno2.Location = new System.Drawing.Point(124, 60);
            this.invoiceno2.Name = "invoiceno2";
            this.invoiceno2.Size = new System.Drawing.Size(52, 15);
            this.invoiceno2.TabIndex = 509;
            this.invoiceno2.Text = "发票号";
            // 
            // invoiceno6
            // 
            this.invoiceno6.AutoSize = true;
            this.invoiceno6.Font = new System.Drawing.Font("宋体", 10F);
            this.invoiceno6.Location = new System.Drawing.Point(975, 48);
            this.invoiceno6.Name = "invoiceno6";
            this.invoiceno6.Size = new System.Drawing.Size(49, 14);
            this.invoiceno6.TabIndex = 508;
            this.invoiceno6.Text = "发票号";
            this.invoiceno6.Click += new System.EventHandler(this.label18_Click);
            // 
            // invoiceno5
            // 
            this.invoiceno5.AutoSize = true;
            this.invoiceno5.Font = new System.Drawing.Font("宋体", 10F);
            this.invoiceno5.Location = new System.Drawing.Point(881, 49);
            this.invoiceno5.Name = "invoiceno5";
            this.invoiceno5.Size = new System.Drawing.Size(49, 14);
            this.invoiceno5.TabIndex = 507;
            this.invoiceno5.Text = "发票号";
            // 
            // invoiceno4
            // 
            this.invoiceno4.AutoSize = true;
            this.invoiceno4.Font = new System.Drawing.Font("宋体", 10F);
            this.invoiceno4.Location = new System.Drawing.Point(775, 49);
            this.invoiceno4.Name = "invoiceno4";
            this.invoiceno4.Size = new System.Drawing.Size(49, 14);
            this.invoiceno4.TabIndex = 506;
            this.invoiceno4.Text = "发票号";
            // 
            // invoiceno3
            // 
            this.invoiceno3.AutoSize = true;
            this.invoiceno3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.invoiceno3.Location = new System.Drawing.Point(473, 442);
            this.invoiceno3.Name = "invoiceno3";
            this.invoiceno3.Size = new System.Drawing.Size(52, 15);
            this.invoiceno3.TabIndex = 505;
            this.invoiceno3.Text = "发票号";
            // 
            // invoiceno1
            // 
            this.invoiceno1.AutoSize = true;
            this.invoiceno1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.invoiceno1.Location = new System.Drawing.Point(313, 60);
            this.invoiceno1.Name = "invoiceno1";
            this.invoiceno1.Size = new System.Drawing.Size(52, 15);
            this.invoiceno1.TabIndex = 504;
            this.invoiceno1.Text = "发票号";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10F);
            this.label14.Location = new System.Drawing.Point(871, 169);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 14);
            this.label14.TabIndex = 503;
            this.label14.Text = "执行科室：";
            this.label14.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.Location = new System.Drawing.Point(975, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 502;
            this.label5.Text = "执行科室：";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(874, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 501;
            this.label4.Text = "开立科室：";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(970, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 500;
            this.label3.Text = "开立科室：";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(768, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 499;
            this.label2.Text = "执行科室：";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(765, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 498;
            this.label1.Text = "开立科室：";
            this.label1.Visible = false;
            // 
            // lblDistroy5
            // 
            this.lblDistroy5.AutoSize = true;
            this.lblDistroy5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDistroy5.Location = new System.Drawing.Point(882, 350);
            this.lblDistroy5.Name = "lblDistroy5";
            this.lblDistroy5.Size = new System.Drawing.Size(52, 21);
            this.lblDistroy5.TabIndex = 425;
            this.lblDistroy5.Text = "作废";
            // 
            // lblDistroy4
            // 
            this.lblDistroy4.AutoSize = true;
            this.lblDistroy4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDistroy4.Location = new System.Drawing.Point(781, 350);
            this.lblDistroy4.Name = "lblDistroy4";
            this.lblDistroy4.Size = new System.Drawing.Size(52, 21);
            this.lblDistroy4.TabIndex = 459;
            this.lblDistroy4.Text = "作废";
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(428, 324);
            this.label54.Margin = new System.Windows.Forms.Padding(0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(326, 12);
            this.label54.TabIndex = 497;
            this.label54.Text = "................................................";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label54.Visible = false;
            // 
            // lblDistroy6
            // 
            this.lblDistroy6.AutoSize = true;
            this.lblDistroy6.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDistroy6.Location = new System.Drawing.Point(982, 350);
            this.lblDistroy6.Name = "lblDistroy6";
            this.lblDistroy6.Size = new System.Drawing.Size(52, 21);
            this.lblDistroy6.TabIndex = 460;
            this.lblDistroy6.Text = "作废";
            // 
            // lblItemFee6
            // 
            this.lblItemFee6.AutoSize = true;
            this.lblItemFee6.Font = new System.Drawing.Font("宋体", 11F);
            this.lblItemFee6.Location = new System.Drawing.Point(1003, 336);
            this.lblItemFee6.Name = "lblItemFee6";
            this.lblItemFee6.Size = new System.Drawing.Size(37, 15);
            this.lblItemFee6.TabIndex = 461;
            this.lblItemFee6.Text = "金额";
            // 
            // lblItemFee5
            // 
            this.lblItemFee5.AutoSize = true;
            this.lblItemFee5.Font = new System.Drawing.Font("宋体", 11F);
            this.lblItemFee5.Location = new System.Drawing.Point(900, 336);
            this.lblItemFee5.Name = "lblItemFee5";
            this.lblItemFee5.Size = new System.Drawing.Size(37, 15);
            this.lblItemFee5.TabIndex = 456;
            this.lblItemFee5.Text = "金额";
            // 
            // lblItemFee4
            // 
            this.lblItemFee4.AutoSize = true;
            this.lblItemFee4.Font = new System.Drawing.Font("宋体", 11F);
            this.lblItemFee4.Location = new System.Drawing.Point(801, 336);
            this.lblItemFee4.Name = "lblItemFee4";
            this.lblItemFee4.Size = new System.Drawing.Size(37, 15);
            this.lblItemFee4.TabIndex = 457;
            this.lblItemFee4.Text = "金额";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(723, 60);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(29, 12);
            this.label52.TabIndex = 458;
            this.label52.Text = "金额";
            this.label52.UseWaitCursor = true;
            this.label52.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(334, 139);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(29, 12);
            this.label36.TabIndex = 462;
            this.label36.Text = "金额";
            this.label36.Visible = false;
            // 
            // lbl3XianJinZhiFu
            // 
            this.lbl3XianJinZhiFu.AutoSize = true;
            this.lbl3XianJinZhiFu.Location = new System.Drawing.Point(635, 401);
            this.lbl3XianJinZhiFu.Name = "lbl3XianJinZhiFu";
            this.lbl3XianJinZhiFu.Size = new System.Drawing.Size(11, 12);
            this.lbl3XianJinZhiFu.TabIndex = 466;
            this.lbl3XianJinZhiFu.Text = "0";
            // 
            // lbl3GeRenZhangHu
            // 
            this.lbl3GeRenZhangHu.AutoSize = true;
            this.lbl3GeRenZhangHu.Location = new System.Drawing.Point(539, 402);
            this.lbl3GeRenZhangHu.Name = "lbl3GeRenZhangHu";
            this.lbl3GeRenZhangHu.Size = new System.Drawing.Size(11, 12);
            this.lbl3GeRenZhangHu.TabIndex = 467;
            this.lbl3GeRenZhangHu.Text = "0";
            // 
            // lbl2XianJinZhiFu
            // 
            this.lbl2XianJinZhiFu.AutoSize = true;
            this.lbl2XianJinZhiFu.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2XianJinZhiFu.Location = new System.Drawing.Point(322, 385);
            this.lbl2XianJinZhiFu.Name = "lbl2XianJinZhiFu";
            this.lbl2XianJinZhiFu.Size = new System.Drawing.Size(15, 15);
            this.lbl2XianJinZhiFu.TabIndex = 468;
            this.lbl2XianJinZhiFu.Text = "0";
            // 
            // lbl3GongWuYuan
            // 
            this.lbl3GongWuYuan.AutoSize = true;
            this.lbl3GongWuYuan.Location = new System.Drawing.Point(443, 402);
            this.lbl3GongWuYuan.Name = "lbl3GongWuYuan";
            this.lbl3GongWuYuan.Size = new System.Drawing.Size(11, 12);
            this.lbl3GongWuYuan.TabIndex = 463;
            this.lbl3GongWuYuan.Text = "0";
            // 
            // lbl2GeRenZhangHu
            // 
            this.lbl2GeRenZhangHu.AutoSize = true;
            this.lbl2GeRenZhangHu.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2GeRenZhangHu.Location = new System.Drawing.Point(322, 358);
            this.lbl2GeRenZhangHu.Name = "lbl2GeRenZhangHu";
            this.lbl2GeRenZhangHu.Size = new System.Drawing.Size(15, 15);
            this.lbl2GeRenZhangHu.TabIndex = 464;
            this.lbl2GeRenZhangHu.Text = "0";
            // 
            // lbl3DaEJiZhang
            // 
            this.lbl3DaEJiZhang.AutoSize = true;
            this.lbl3DaEJiZhang.Location = new System.Drawing.Point(635, 372);
            this.lbl3DaEJiZhang.Name = "lbl3DaEJiZhang";
            this.lbl3DaEJiZhang.Size = new System.Drawing.Size(11, 12);
            this.lbl3DaEJiZhang.TabIndex = 465;
            this.lbl3DaEJiZhang.Text = "0";
            // 
            // lbl2GongWuYuan
            // 
            this.lbl2GongWuYuan.AutoSize = true;
            this.lbl2GongWuYuan.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2GongWuYuan.Location = new System.Drawing.Point(322, 331);
            this.lbl2GongWuYuan.Name = "lbl2GongWuYuan";
            this.lbl2GongWuYuan.Size = new System.Drawing.Size(15, 15);
            this.lbl2GongWuYuan.TabIndex = 455;
            this.lbl2GongWuYuan.Text = "0";
            // 
            // lbl3TongChouJiZhang
            // 
            this.lbl3TongChouJiZhang.AutoSize = true;
            this.lbl3TongChouJiZhang.Location = new System.Drawing.Point(539, 375);
            this.lbl3TongChouJiZhang.Name = "lbl3TongChouJiZhang";
            this.lbl3TongChouJiZhang.Size = new System.Drawing.Size(11, 12);
            this.lbl3TongChouJiZhang.TabIndex = 445;
            this.lbl3TongChouJiZhang.Text = "0";
            // 
            // lbl2DaEJiZhang
            // 
            this.lbl2DaEJiZhang.AutoSize = true;
            this.lbl2DaEJiZhang.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2DaEJiZhang.Location = new System.Drawing.Point(322, 303);
            this.lbl2DaEJiZhang.Name = "lbl2DaEJiZhang";
            this.lbl2DaEJiZhang.Size = new System.Drawing.Size(15, 15);
            this.lbl2DaEJiZhang.TabIndex = 446;
            this.lbl2DaEJiZhang.Text = "0";
            // 
            // lbl3QiFuBiaoZhun
            // 
            this.lbl3QiFuBiaoZhun.AutoSize = true;
            this.lbl3QiFuBiaoZhun.Location = new System.Drawing.Point(636, 347);
            this.lbl3QiFuBiaoZhun.Name = "lbl3QiFuBiaoZhun";
            this.lbl3QiFuBiaoZhun.Size = new System.Drawing.Size(11, 12);
            this.lbl3QiFuBiaoZhun.TabIndex = 447;
            this.lbl3QiFuBiaoZhun.Text = "0";
            // 
            // lbl2TongChouJiZhang
            // 
            this.lbl2TongChouJiZhang.AutoSize = true;
            this.lbl2TongChouJiZhang.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2TongChouJiZhang.Location = new System.Drawing.Point(322, 275);
            this.lbl2TongChouJiZhang.Name = "lbl2TongChouJiZhang";
            this.lbl2TongChouJiZhang.Size = new System.Drawing.Size(15, 15);
            this.lbl2TongChouJiZhang.TabIndex = 442;
            this.lbl2TongChouJiZhang.Text = "0";
            // 
            // lbl3AnBiLiZhiFu
            // 
            this.lbl3AnBiLiZhiFu.AutoSize = true;
            this.lbl3AnBiLiZhiFu.Location = new System.Drawing.Point(446, 374);
            this.lbl3AnBiLiZhiFu.Name = "lbl3AnBiLiZhiFu";
            this.lbl3AnBiLiZhiFu.Size = new System.Drawing.Size(11, 12);
            this.lbl3AnBiLiZhiFu.TabIndex = 443;
            this.lbl3AnBiLiZhiFu.Text = "0";
            // 
            // lbl2QiFuBiaoZhun
            // 
            this.lbl2QiFuBiaoZhun.AutoSize = true;
            this.lbl2QiFuBiaoZhun.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2QiFuBiaoZhun.Location = new System.Drawing.Point(322, 219);
            this.lbl2QiFuBiaoZhun.Name = "lbl2QiFuBiaoZhun";
            this.lbl2QiFuBiaoZhun.Size = new System.Drawing.Size(15, 15);
            this.lbl2QiFuBiaoZhun.TabIndex = 444;
            this.lbl2QiFuBiaoZhun.Text = "0";
            // 
            // lbl3GeRenZhiFu
            // 
            this.lbl3GeRenZhiFu.AutoSize = true;
            this.lbl3GeRenZhiFu.Location = new System.Drawing.Point(539, 347);
            this.lbl3GeRenZhiFu.Name = "lbl3GeRenZhiFu";
            this.lbl3GeRenZhiFu.Size = new System.Drawing.Size(11, 12);
            this.lbl3GeRenZhiFu.TabIndex = 448;
            this.lbl3GeRenZhiFu.Text = "0";
            // 
            // lbl2AnBiLiZhiFu
            // 
            this.lbl2AnBiLiZhiFu.AutoSize = true;
            this.lbl2AnBiLiZhiFu.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2AnBiLiZhiFu.Location = new System.Drawing.Point(322, 246);
            this.lbl2AnBiLiZhiFu.Name = "lbl2AnBiLiZhiFu";
            this.lbl2AnBiLiZhiFu.Size = new System.Drawing.Size(15, 15);
            this.lbl2AnBiLiZhiFu.TabIndex = 452;
            this.lbl2AnBiLiZhiFu.Text = "0";
            // 
            // lblItem6
            // 
            this.lblItem6.AutoSize = true;
            this.lblItem6.Font = new System.Drawing.Font("宋体", 11F);
            this.lblItem6.Location = new System.Drawing.Point(973, 276);
            this.lblItem6.Name = "lblItem6";
            this.lblItem6.Size = new System.Drawing.Size(37, 15);
            this.lblItem6.TabIndex = 453;
            this.lblItem6.Text = "项目";
            // 
            // lbl2GeRenZhiFu
            // 
            this.lbl2GeRenZhiFu.AutoSize = true;
            this.lbl2GeRenZhiFu.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2GeRenZhiFu.Location = new System.Drawing.Point(322, 194);
            this.lbl2GeRenZhiFu.Name = "lbl2GeRenZhiFu";
            this.lbl2GeRenZhiFu.Size = new System.Drawing.Size(15, 15);
            this.lbl2GeRenZhiFu.TabIndex = 454;
            this.lbl2GeRenZhiFu.Text = "0";
            // 
            // lblItem5
            // 
            this.lblItem5.AutoSize = true;
            this.lblItem5.Font = new System.Drawing.Font("宋体", 11F);
            this.lblItem5.Location = new System.Drawing.Point(870, 276);
            this.lblItem5.Name = "lblItem5";
            this.lblItem5.Size = new System.Drawing.Size(37, 15);
            this.lblItem5.TabIndex = 449;
            this.lblItem5.Text = "项目";
            // 
            // lbl3ZhiFeiFeiYong
            // 
            this.lbl3ZhiFeiFeiYong.AutoSize = true;
            this.lbl3ZhiFeiFeiYong.Location = new System.Drawing.Point(449, 347);
            this.lbl3ZhiFeiFeiYong.Name = "lbl3ZhiFeiFeiYong";
            this.lbl3ZhiFeiFeiYong.Size = new System.Drawing.Size(11, 12);
            this.lbl3ZhiFeiFeiYong.TabIndex = 450;
            this.lbl3ZhiFeiFeiYong.Text = "0";
            // 
            // lblItem4
            // 
            this.lblItem4.AutoSize = true;
            this.lblItem4.Font = new System.Drawing.Font("宋体", 11F);
            this.lblItem4.Location = new System.Drawing.Point(768, 276);
            this.lblItem4.Name = "lblItem4";
            this.lblItem4.Size = new System.Drawing.Size(37, 15);
            this.lblItem4.TabIndex = 451;
            this.lblItem4.Text = "项目";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(474, 126);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(29, 12);
            this.label51.TabIndex = 469;
            this.label51.Text = "项目";
            this.label51.Visible = false;
            // 
            // lbl2ZhiFeiFeiYong
            // 
            this.lbl2ZhiFeiFeiYong.AutoSize = true;
            this.lbl2ZhiFeiFeiYong.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2ZhiFeiFeiYong.Location = new System.Drawing.Point(322, 167);
            this.lbl2ZhiFeiFeiYong.Name = "lbl2ZhiFeiFeiYong";
            this.lbl2ZhiFeiFeiYong.Size = new System.Drawing.Size(15, 15);
            this.lbl2ZhiFeiFeiYong.TabIndex = 487;
            this.lbl2ZhiFeiFeiYong.Text = "0";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(273, 141);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(29, 12);
            this.label35.TabIndex = 488;
            this.label35.Text = "项目";
            this.label35.Visible = false;
            // 
            // lblOp6
            // 
            this.lblOp6.AutoSize = true;
            this.lblOp6.Font = new System.Drawing.Font("宋体", 10F);
            this.lblOp6.Location = new System.Drawing.Point(973, 439);
            this.lblOp6.Name = "lblOp6";
            this.lblOp6.Size = new System.Drawing.Size(35, 14);
            this.lblOp6.TabIndex = 489;
            this.lblOp6.Text = "制单";
            this.lblOp6.Visible = false;
            // 
            // lbl3ItemFee7
            // 
            this.lbl3ItemFee7.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3ItemFee7.Location = new System.Drawing.Point(672, 286);
            this.lbl3ItemFee7.Name = "lbl3ItemFee7";
            this.lbl3ItemFee7.Size = new System.Drawing.Size(80, 14);
            this.lbl3ItemFee7.TabIndex = 484;
            this.lbl3ItemFee7.Text = "金额";
            this.lbl3ItemFee7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl3ItemFee7.Visible = false;
            // 
            // lbl1ItemFee7
            // 
            this.lbl1ItemFee7.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1ItemFee7.Location = new System.Drawing.Point(151, 341);
            this.lbl1ItemFee7.Name = "lbl1ItemFee7";
            this.lbl1ItemFee7.Size = new System.Drawing.Size(70, 14);
            this.lbl1ItemFee7.TabIndex = 485;
            this.lbl1ItemFee7.Text = "金额";
            this.lbl1ItemFee7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1ItemFee7.Visible = false;
            // 
            // lbl3ItemFee6
            // 
            this.lbl3ItemFee6.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3ItemFee6.Location = new System.Drawing.Point(672, 264);
            this.lbl3ItemFee6.Name = "lbl3ItemFee6";
            this.lbl3ItemFee6.Size = new System.Drawing.Size(80, 14);
            this.lbl3ItemFee6.TabIndex = 486;
            this.lbl3ItemFee6.Text = "金额";
            this.lbl3ItemFee6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl3ItemFee6.Visible = false;
            // 
            // lbl1ItemFee6
            // 
            this.lbl1ItemFee6.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1ItemFee6.Location = new System.Drawing.Point(151, 311);
            this.lbl1ItemFee6.Name = "lbl1ItemFee6";
            this.lbl1ItemFee6.Size = new System.Drawing.Size(70, 14);
            this.lbl1ItemFee6.TabIndex = 490;
            this.lbl1ItemFee6.Text = "金额";
            this.lbl1ItemFee6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1ItemFee6.Visible = false;
            // 
            // lbl3ItemFee5
            // 
            this.lbl3ItemFee5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3ItemFee5.Location = new System.Drawing.Point(672, 244);
            this.lbl3ItemFee5.Name = "lbl3ItemFee5";
            this.lbl3ItemFee5.Size = new System.Drawing.Size(80, 14);
            this.lbl3ItemFee5.TabIndex = 494;
            this.lbl3ItemFee5.Text = "金额";
            this.lbl3ItemFee5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl3ItemFee5.Visible = false;
            // 
            // lbl1ItemFee5
            // 
            this.lbl1ItemFee5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1ItemFee5.Location = new System.Drawing.Point(151, 286);
            this.lbl1ItemFee5.Name = "lbl1ItemFee5";
            this.lbl1ItemFee5.Size = new System.Drawing.Size(70, 14);
            this.lbl1ItemFee5.TabIndex = 495;
            this.lbl1ItemFee5.Text = "金额";
            this.lbl1ItemFee5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1ItemFee5.Visible = false;
            // 
            // lbl3ItemFee4
            // 
            this.lbl3ItemFee4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3ItemFee4.Location = new System.Drawing.Point(672, 223);
            this.lbl3ItemFee4.Name = "lbl3ItemFee4";
            this.lbl3ItemFee4.Size = new System.Drawing.Size(80, 14);
            this.lbl3ItemFee4.TabIndex = 496;
            this.lbl3ItemFee4.Text = "金额";
            this.lbl3ItemFee4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl3ItemFee4.Visible = false;
            // 
            // lbl1ItemFee4
            // 
            this.lbl1ItemFee4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1ItemFee4.Location = new System.Drawing.Point(151, 258);
            this.lbl1ItemFee4.Name = "lbl1ItemFee4";
            this.lbl1ItemFee4.Size = new System.Drawing.Size(70, 14);
            this.lbl1ItemFee4.TabIndex = 491;
            this.lbl1ItemFee4.Text = "金额";
            this.lbl1ItemFee4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1ItemFee4.Visible = false;
            // 
            // lbl3ItemFee3
            // 
            this.lbl3ItemFee3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3ItemFee3.Location = new System.Drawing.Point(672, 204);
            this.lbl3ItemFee3.Name = "lbl3ItemFee3";
            this.lbl3ItemFee3.Size = new System.Drawing.Size(80, 14);
            this.lbl3ItemFee3.TabIndex = 492;
            this.lbl3ItemFee3.Text = "金额";
            this.lbl3ItemFee3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl3ItemFee3.Visible = false;
            // 
            // lbl3ItemFee2
            // 
            this.lbl3ItemFee2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3ItemFee2.Location = new System.Drawing.Point(672, 184);
            this.lbl3ItemFee2.Name = "lbl3ItemFee2";
            this.lbl3ItemFee2.Size = new System.Drawing.Size(80, 14);
            this.lbl3ItemFee2.TabIndex = 493;
            this.lbl3ItemFee2.Text = "金额";
            this.lbl3ItemFee2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl3ItemFee2.Visible = false;
            // 
            // lbl1ItemFee3
            // 
            this.lbl1ItemFee3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1ItemFee3.Location = new System.Drawing.Point(151, 233);
            this.lbl1ItemFee3.Name = "lbl1ItemFee3";
            this.lbl1ItemFee3.Size = new System.Drawing.Size(70, 14);
            this.lbl1ItemFee3.TabIndex = 483;
            this.lbl1ItemFee3.Text = "金额";
            this.lbl1ItemFee3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1ItemFee3.Visible = false;
            // 
            // lbl3Item7
            // 
            this.lbl3Item7.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3Item7.Location = new System.Drawing.Point(452, 286);
            this.lbl3Item7.Name = "lbl3Item7";
            this.lbl3Item7.Size = new System.Drawing.Size(80, 14);
            this.lbl3Item7.TabIndex = 473;
            this.lbl3Item7.Text = "项目";
            this.lbl3Item7.Visible = false;
            // 
            // lbl1ItemFee2
            // 
            this.lbl1ItemFee2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1ItemFee2.Location = new System.Drawing.Point(151, 209);
            this.lbl1ItemFee2.Name = "lbl1ItemFee2";
            this.lbl1ItemFee2.Size = new System.Drawing.Size(70, 14);
            this.lbl1ItemFee2.TabIndex = 474;
            this.lbl1ItemFee2.Text = "金额";
            this.lbl1ItemFee2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1ItemFee2.Visible = false;
            // 
            // lbl3ItemFee1
            // 
            this.lbl3ItemFee1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3ItemFee1.Location = new System.Drawing.Point(672, 165);
            this.lbl3ItemFee1.Name = "lbl3ItemFee1";
            this.lbl3ItemFee1.Size = new System.Drawing.Size(80, 14);
            this.lbl3ItemFee1.TabIndex = 475;
            this.lbl3ItemFee1.Text = "金额";
            this.lbl3ItemFee1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl3ItemFee1.Visible = false;
            // 
            // lbl1Item7
            // 
            this.lbl1Item7.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1Item7.Location = new System.Drawing.Point(66, 341);
            this.lbl1Item7.Name = "lbl1Item7";
            this.lbl1Item7.Size = new System.Drawing.Size(70, 14);
            this.lbl1Item7.TabIndex = 470;
            this.lbl1Item7.Text = "项目";
            this.lbl1Item7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1Item7.Visible = false;
            // 
            // lbl3Item6
            // 
            this.lbl3Item6.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3Item6.Location = new System.Drawing.Point(452, 264);
            this.lbl3Item6.Name = "lbl3Item6";
            this.lbl3Item6.Size = new System.Drawing.Size(80, 14);
            this.lbl3Item6.TabIndex = 471;
            this.lbl3Item6.Text = "项目";
            this.lbl3Item6.Visible = false;
            // 
            // lbl1ItemFee1
            // 
            this.lbl1ItemFee1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1ItemFee1.Location = new System.Drawing.Point(151, 186);
            this.lbl1ItemFee1.Name = "lbl1ItemFee1";
            this.lbl1ItemFee1.Size = new System.Drawing.Size(70, 14);
            this.lbl1ItemFee1.TabIndex = 472;
            this.lbl1ItemFee1.Text = "金额";
            this.lbl1ItemFee1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1ItemFee1.Visible = false;
            // 
            // lbl3ItemFee0
            // 
            this.lbl3ItemFee0.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3ItemFee0.Location = new System.Drawing.Point(672, 146);
            this.lbl3ItemFee0.Name = "lbl3ItemFee0";
            this.lbl3ItemFee0.Size = new System.Drawing.Size(80, 14);
            this.lbl3ItemFee0.TabIndex = 476;
            this.lbl3ItemFee0.Text = "金额";
            this.lbl3ItemFee0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl3ItemFee0.Visible = false;
            // 
            // lbl1Item6
            // 
            this.lbl1Item6.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1Item6.Location = new System.Drawing.Point(66, 311);
            this.lbl1Item6.Name = "lbl1Item6";
            this.lbl1Item6.Size = new System.Drawing.Size(70, 14);
            this.lbl1Item6.TabIndex = 480;
            this.lbl1Item6.Text = "项目";
            this.lbl1Item6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1Item6.Visible = false;
            // 
            // lbl3Item5
            // 
            this.lbl3Item5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3Item5.Location = new System.Drawing.Point(452, 244);
            this.lbl3Item5.Name = "lbl3Item5";
            this.lbl3Item5.Size = new System.Drawing.Size(80, 14);
            this.lbl3Item5.TabIndex = 481;
            this.lbl3Item5.Text = "项目";
            this.lbl3Item5.Visible = false;
            // 
            // lbl1ItemFee0
            // 
            this.lbl1ItemFee0.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1ItemFee0.Location = new System.Drawing.Point(151, 161);
            this.lbl1ItemFee0.Name = "lbl1ItemFee0";
            this.lbl1ItemFee0.Size = new System.Drawing.Size(70, 14);
            this.lbl1ItemFee0.TabIndex = 482;
            this.lbl1ItemFee0.Text = "金额";
            this.lbl1ItemFee0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1ItemFee0.Visible = false;
            // 
            // lbl1Item5
            // 
            this.lbl1Item5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1Item5.Location = new System.Drawing.Point(66, 286);
            this.lbl1Item5.Name = "lbl1Item5";
            this.lbl1Item5.Size = new System.Drawing.Size(70, 14);
            this.lbl1Item5.TabIndex = 477;
            this.lbl1Item5.Text = "项目";
            this.lbl1Item5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1Item5.Visible = false;
            // 
            // lbl3Item4
            // 
            this.lbl3Item4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3Item4.Location = new System.Drawing.Point(452, 223);
            this.lbl3Item4.Name = "lbl3Item4";
            this.lbl3Item4.Size = new System.Drawing.Size(80, 14);
            this.lbl3Item4.TabIndex = 478;
            this.lbl3Item4.Text = "项目";
            this.lbl3Item4.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(145, 132);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 479;
            this.label20.Text = "金额";
            this.label20.Visible = false;
            // 
            // lbl1Item4
            // 
            this.lbl1Item4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1Item4.Location = new System.Drawing.Point(66, 258);
            this.lbl1Item4.Name = "lbl1Item4";
            this.lbl1Item4.Size = new System.Drawing.Size(70, 14);
            this.lbl1Item4.TabIndex = 441;
            this.lbl1Item4.Text = "项目";
            this.lbl1Item4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1Item4.Visible = false;
            // 
            // lbl3Item3
            // 
            this.lbl3Item3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3Item3.Location = new System.Drawing.Point(452, 204);
            this.lbl3Item3.Name = "lbl3Item3";
            this.lbl3Item3.Size = new System.Drawing.Size(80, 14);
            this.lbl3Item3.TabIndex = 408;
            this.lbl3Item3.Text = "项目";
            this.lbl3Item3.Visible = false;
            // 
            // lblOp5
            // 
            this.lblOp5.AutoSize = true;
            this.lblOp5.Font = new System.Drawing.Font("宋体", 10F);
            this.lblOp5.Location = new System.Drawing.Point(881, 442);
            this.lblOp5.Name = "lblOp5";
            this.lblOp5.Size = new System.Drawing.Size(35, 14);
            this.lblOp5.TabIndex = 409;
            this.lblOp5.Text = "制单";
            this.lblOp5.Visible = false;
            // 
            // lbl1Item3
            // 
            this.lbl1Item3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1Item3.Location = new System.Drawing.Point(66, 233);
            this.lbl1Item3.Name = "lbl1Item3";
            this.lbl1Item3.Size = new System.Drawing.Size(70, 14);
            this.lbl1Item3.TabIndex = 410;
            this.lbl1Item3.Text = "项目";
            this.lbl1Item3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1Item3.Visible = false;
            // 
            // lbl3Item2
            // 
            this.lbl3Item2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3Item2.Location = new System.Drawing.Point(452, 184);
            this.lbl3Item2.Name = "lbl3Item2";
            this.lbl3Item2.Size = new System.Drawing.Size(80, 14);
            this.lbl3Item2.TabIndex = 405;
            this.lbl3Item2.Text = "项目";
            this.lbl3Item2.Visible = false;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(675, 444);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(29, 12);
            this.label66.TabIndex = 406;
            this.label66.Text = "收款";
            this.label66.Visible = false;
            // 
            // lbl1Item2
            // 
            this.lbl1Item2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1Item2.Location = new System.Drawing.Point(66, 209);
            this.lbl1Item2.Name = "lbl1Item2";
            this.lbl1Item2.Size = new System.Drawing.Size(70, 14);
            this.lbl1Item2.TabIndex = 407;
            this.lbl1Item2.Text = "项目";
            this.lbl1Item2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1Item2.Visible = false;
            // 
            // lbl3Item1
            // 
            this.lbl3Item1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3Item1.Location = new System.Drawing.Point(452, 165);
            this.lbl3Item1.Name = "lbl3Item1";
            this.lbl3Item1.Size = new System.Drawing.Size(80, 14);
            this.lbl3Item1.TabIndex = 414;
            this.lbl3Item1.Text = "项目";
            this.lbl3Item1.Visible = false;
            // 
            // lblOp4
            // 
            this.lblOp4.AutoSize = true;
            this.lblOp4.Font = new System.Drawing.Font("宋体", 10F);
            this.lblOp4.Location = new System.Drawing.Point(777, 442);
            this.lblOp4.Name = "lblOp4";
            this.lblOp4.Size = new System.Drawing.Size(35, 14);
            this.lblOp4.TabIndex = 415;
            this.lblOp4.Text = "制单";
            this.lblOp4.Visible = false;
            // 
            // lbl1Item1
            // 
            this.lbl1Item1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1Item1.Location = new System.Drawing.Point(66, 186);
            this.lbl1Item1.Name = "lbl1Item1";
            this.lbl1Item1.Size = new System.Drawing.Size(70, 14);
            this.lbl1Item1.TabIndex = 416;
            this.lbl1Item1.Text = "项目";
            this.lbl1Item1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1Item1.Visible = false;
            // 
            // lbl3Item0
            // 
            this.lbl3Item0.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl3Item0.Location = new System.Drawing.Point(452, 146);
            this.lbl3Item0.Name = "lbl3Item0";
            this.lbl3Item0.Size = new System.Drawing.Size(80, 14);
            this.lbl3Item0.TabIndex = 411;
            this.lbl3Item0.Text = "项目";
            this.lbl3Item0.Visible = false;
            // 
            // lblOp3
            // 
            this.lblOp3.AutoSize = true;
            this.lblOp3.Location = new System.Drawing.Point(581, 445);
            this.lblOp3.Name = "lblOp3";
            this.lblOp3.Size = new System.Drawing.Size(29, 12);
            this.lblOp3.TabIndex = 412;
            this.lblOp3.Text = "制单";
            // 
            // lbl1Item0
            // 
            this.lbl1Item0.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1Item0.Location = new System.Drawing.Point(66, 161);
            this.lbl1Item0.Name = "lbl1Item0";
            this.lbl1Item0.Size = new System.Drawing.Size(70, 14);
            this.lbl1Item0.TabIndex = 413;
            this.lbl1Item0.Text = "项目";
            this.lbl1Item0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1Item0.Visible = false;
            // 
            // lblOp2
            // 
            this.lblOp2.AutoSize = true;
            this.lblOp2.Location = new System.Drawing.Point(361, 445);
            this.lblOp2.Name = "lblOp2";
            this.lblOp2.Size = new System.Drawing.Size(29, 12);
            this.lblOp2.TabIndex = 396;
            this.lblOp2.Text = "制单";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(81, 132);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 397;
            this.label19.Text = "项目";
            this.label19.Visible = false;
            // 
            // lblOp1
            // 
            this.lblOp1.AutoSize = true;
            this.lblOp1.Location = new System.Drawing.Point(188, 445);
            this.lblOp1.Name = "lblOp1";
            this.lblOp1.Size = new System.Drawing.Size(29, 12);
            this.lblOp1.TabIndex = 398;
            this.lblOp1.Text = "制单";
            // 
            // lblTotCost3
            // 
            this.lblTotCost3.AutoSize = true;
            this.lblTotCost3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotCost3.Location = new System.Drawing.Point(471, 423);
            this.lblTotCost3.Name = "lblTotCost3";
            this.lblTotCost3.Size = new System.Drawing.Size(37, 15);
            this.lblTotCost3.TabIndex = 393;
            this.lblTotCost3.Text = "合计";
            // 
            // lblTotCost1
            // 
            this.lblTotCost1.AutoSize = true;
            this.lblTotCost1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotCost1.Location = new System.Drawing.Point(116, 423);
            this.lblTotCost1.Name = "lblTotCost1";
            this.lblTotCost1.Size = new System.Drawing.Size(37, 15);
            this.lblTotCost1.TabIndex = 394;
            this.lblTotCost1.Text = "合计";
            // 
            // lblHosName6
            // 
            this.lblHosName6.AutoSize = true;
            this.lblHosName6.Font = new System.Drawing.Font("宋体", 10F);
            this.lblHosName6.Location = new System.Drawing.Point(973, 90);
            this.lblHosName6.Name = "lblHosName6";
            this.lblHosName6.Size = new System.Drawing.Size(63, 14);
            this.lblHosName6.TabIndex = 395;
            this.lblHosName6.Text = "医院名称";
            // 
            // lblHosName5
            // 
            this.lblHosName5.AutoSize = true;
            this.lblHosName5.Font = new System.Drawing.Font("宋体", 10F);
            this.lblHosName5.Location = new System.Drawing.Point(870, 92);
            this.lblHosName5.Name = "lblHosName5";
            this.lblHosName5.Size = new System.Drawing.Size(63, 14);
            this.lblHosName5.TabIndex = 402;
            this.lblHosName5.Text = "医院名称";
            // 
            // lblDeptE6
            // 
            this.lblDeptE6.AutoSize = true;
            this.lblDeptE6.Font = new System.Drawing.Font("宋体", 10F);
            this.lblDeptE6.Location = new System.Drawing.Point(975, 146);
            this.lblDeptE6.Name = "lblDeptE6";
            this.lblDeptE6.Size = new System.Drawing.Size(0, 14);
            this.lblDeptE6.TabIndex = 403;
            // 
            // lblDeptE5
            // 
            this.lblDeptE5.AutoSize = true;
            this.lblDeptE5.Font = new System.Drawing.Font("宋体", 10F);
            this.lblDeptE5.Location = new System.Drawing.Point(873, 146);
            this.lblDeptE5.Name = "lblDeptE5";
            this.lblDeptE5.Size = new System.Drawing.Size(0, 14);
            this.lblDeptE5.TabIndex = 404;
            // 
            // lblDeptR6
            // 
            this.lblDeptR6.AutoSize = true;
            this.lblDeptR6.Font = new System.Drawing.Font("宋体", 10F);
            this.lblDeptR6.Location = new System.Drawing.Point(975, 139);
            this.lblDeptR6.Name = "lblDeptR6";
            this.lblDeptR6.Size = new System.Drawing.Size(63, 14);
            this.lblDeptR6.TabIndex = 399;
            this.lblDeptR6.Text = "开立科室";
            this.lblDeptR6.Visible = false;
            // 
            // lblDeptE4
            // 
            this.lblDeptE4.AutoSize = true;
            this.lblDeptE4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeptE4.Location = new System.Drawing.Point(768, 146);
            this.lblDeptE4.Name = "lblDeptE4";
            this.lblDeptE4.Size = new System.Drawing.Size(63, 14);
            this.lblDeptE4.TabIndex = 400;
            this.lblDeptE4.Text = "执行科室";
            // 
            // lblDeptR5
            // 
            this.lblDeptR5.AutoSize = true;
            this.lblDeptR5.Font = new System.Drawing.Font("宋体", 10F);
            this.lblDeptR5.Location = new System.Drawing.Point(873, 137);
            this.lblDeptR5.Name = "lblDeptR5";
            this.lblDeptR5.Size = new System.Drawing.Size(63, 14);
            this.lblDeptR5.TabIndex = 401;
            this.lblDeptR5.Text = "开立科室";
            this.lblDeptR5.Visible = false;
            // 
            // lblDeptR4
            // 
            this.lblDeptR4.AutoSize = true;
            this.lblDeptR4.Font = new System.Drawing.Font("宋体", 10F);
            this.lblDeptR4.Location = new System.Drawing.Point(768, 137);
            this.lblDeptR4.Name = "lblDeptR4";
            this.lblDeptR4.Size = new System.Drawing.Size(63, 14);
            this.lblDeptR4.TabIndex = 432;
            this.lblDeptR4.Text = "开立科室";
            this.lblDeptR4.Visible = false;
            // 
            // lblHosName4
            // 
            this.lblHosName4.AutoSize = true;
            this.lblHosName4.Font = new System.Drawing.Font("宋体", 10F);
            this.lblHosName4.Location = new System.Drawing.Point(763, 91);
            this.lblHosName4.Name = "lblHosName4";
            this.lblHosName4.Size = new System.Drawing.Size(63, 14);
            this.lblHosName4.TabIndex = 433;
            this.lblHosName4.Text = "医院名称";
            // 
            // lblHosName3
            // 
            this.lblHosName3.AutoSize = true;
            this.lblHosName3.Location = new System.Drawing.Point(557, 45);
            this.lblHosName3.Name = "lblHosName3";
            this.lblHosName3.Size = new System.Drawing.Size(53, 12);
            this.lblHosName3.TabIndex = 434;
            this.lblHosName3.Text = "医院名称";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(303, 124);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 429;
            this.label30.Text = "医保编号";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(431, 313);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(53, 12);
            this.label53.TabIndex = 430;
            this.label53.Text = "账户余额";
            this.label53.UseWaitCursor = true;
            // 
            // lblPactName3
            // 
            this.lblPactName3.AutoSize = true;
            this.lblPactName3.Location = new System.Drawing.Point(522, 82);
            this.lblPactName3.Name = "lblPactName3";
            this.lblPactName3.Size = new System.Drawing.Size(53, 12);
            this.lblPactName3.TabIndex = 431;
            this.lblPactName3.Text = "合同单位";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(240, 87);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 12);
            this.label31.TabIndex = 438;
            this.label31.Text = "账户余额";
            this.label31.UseWaitCursor = true;
            // 
            // lblPactName2
            // 
            this.lblPactName2.AutoSize = true;
            this.lblPactName2.Location = new System.Drawing.Point(239, 47);
            this.lblPactName2.Name = "lblPactName2";
            this.lblPactName2.Size = new System.Drawing.Size(53, 12);
            this.lblPactName2.TabIndex = 439;
            this.lblPactName2.Text = "合同单位";
            // 
            // lblPactName1
            // 
            this.lblPactName1.AutoSize = true;
            this.lblPactName1.Location = new System.Drawing.Point(63, 365);
            this.lblPactName1.Name = "lblPactName1";
            this.lblPactName1.Size = new System.Drawing.Size(53, 12);
            this.lblPactName1.TabIndex = 440;
            this.lblPactName1.Text = "合同单位";
            // 
            // lblDate6
            // 
            this.lblDate6.AutoSize = true;
            this.lblDate6.Font = new System.Drawing.Font("宋体", 10F);
            this.lblDate6.Location = new System.Drawing.Point(979, 423);
            this.lblDate6.Name = "lblDate6";
            this.lblDate6.Size = new System.Drawing.Size(35, 14);
            this.lblDate6.TabIndex = 436;
            this.lblDate6.Text = "日期";
            // 
            // lblDate5
            // 
            this.lblDate5.AutoSize = true;
            this.lblDate5.Font = new System.Drawing.Font("宋体", 10F);
            this.lblDate5.Location = new System.Drawing.Point(896, 423);
            this.lblDate5.Name = "lblDate5";
            this.lblDate5.Size = new System.Drawing.Size(35, 14);
            this.lblDate5.TabIndex = 437;
            this.lblDate5.Text = "日期";
            // 
            // lblDate4
            // 
            this.lblDate4.AutoSize = true;
            this.lblDate4.Font = new System.Drawing.Font("宋体", 10F);
            this.lblDate4.Location = new System.Drawing.Point(792, 423);
            this.lblDate4.Name = "lblDate4";
            this.lblDate4.Size = new System.Drawing.Size(35, 14);
            this.lblDate4.TabIndex = 421;
            this.lblDate4.Text = "日期";
            // 
            // lblName6
            // 
            this.lblName6.AutoSize = true;
            this.lblName6.Font = new System.Drawing.Font("宋体", 10F);
            this.lblName6.Location = new System.Drawing.Point(1005, 186);
            this.lblName6.Name = "lblName6";
            this.lblName6.Size = new System.Drawing.Size(35, 14);
            this.lblName6.TabIndex = 422;
            this.lblName6.Text = "姓名";
            // 
            // lblDate3
            // 
            this.lblDate3.AutoSize = true;
            this.lblDate3.Location = new System.Drawing.Point(559, 99);
            this.lblDate3.Name = "lblDate3";
            this.lblDate3.Size = new System.Drawing.Size(29, 12);
            this.lblDate3.TabIndex = 417;
            this.lblDate3.Text = "日期";
            // 
            // lblName5
            // 
            this.lblName5.AutoSize = true;
            this.lblName5.Font = new System.Drawing.Font("宋体", 10F);
            this.lblName5.Location = new System.Drawing.Point(906, 187);
            this.lblName5.Name = "lblName5";
            this.lblName5.Size = new System.Drawing.Size(35, 14);
            this.lblName5.TabIndex = 418;
            this.lblName5.Text = "姓名";
            // 
            // lblDate2
            // 
            this.lblDate2.AutoSize = true;
            this.lblDate2.Location = new System.Drawing.Point(247, 50);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Size = new System.Drawing.Size(29, 12);
            this.lblDate2.TabIndex = 419;
            this.lblDate2.Text = "日期";
            this.lblDate2.Visible = false;
            // 
            // lblName4
            // 
            this.lblName4.AutoSize = true;
            this.lblName4.Font = new System.Drawing.Font("宋体", 10F);
            this.lblName4.Location = new System.Drawing.Point(801, 186);
            this.lblName4.Name = "lblName4";
            this.lblName4.Size = new System.Drawing.Size(35, 14);
            this.lblName4.TabIndex = 426;
            this.lblName4.Text = "姓名";
            // 
            // lblName3
            // 
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName3.Location = new System.Drawing.Point(466, 100);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(37, 15);
            this.lblName3.TabIndex = 427;
            this.lblName3.Text = "姓名";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName2.Location = new System.Drawing.Point(304, 101);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(37, 15);
            this.lblName2.TabIndex = 428;
            this.lblName2.Text = "姓名";
            // 
            // lblDate1
            // 
            this.lblDate1.AutoSize = true;
            this.lblDate1.Location = new System.Drawing.Point(118, 119);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Size = new System.Drawing.Size(29, 12);
            this.lblDate1.TabIndex = 423;
            this.lblDate1.Text = "日期";
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Location = new System.Drawing.Point(57, 50);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(29, 12);
            this.lblName1.TabIndex = 424;
            this.lblName1.Text = "姓名";
            this.lblName1.Visible = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(971, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 387;
            this.label8.Text = "核算联(3)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(875, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 388;
            this.label7.Text = "核算联(2)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(771, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 385;
            this.label6.Text = "核算联(1)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Visible = false;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(965, 9);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(7, 439);
            this.label13.TabIndex = 386;
            this.label13.Text = "..................................";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Visible = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(861, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(7, 439);
            this.label12.TabIndex = 389;
            this.label12.Text = "..................................";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Visible = false;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(755, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(7, 439);
            this.label11.TabIndex = 392;
            this.label11.Text = "..................................";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(409, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(7, 439);
            this.label10.TabIndex = 391;
            this.label10.Text = "..................................";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(229, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(7, 439);
            this.label9.TabIndex = 390;
            this.label9.Text = "..................................";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Visible = false;
            // 
            // lblReprint
            // 
            this.lblReprint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReprint.Location = new System.Drawing.Point(295, 884);
            this.lblReprint.Name = "lblReprint";
            this.lblReprint.Size = new System.Drawing.Size(186, 16);
            this.lblReprint.TabIndex = 384;
            this.lblReprint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ZZLocalInvoicePrint
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel1);
            this.Name = "ZZLocalInvoicePrint";
            this.Size = new System.Drawing.Size(1048, 470);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		#endregion

		#region 变量

        private bool _isPreView;
        private Panel panel1;
        private Label lblDistroy5;
        private Label lblDistroy4;
        private Label label54;
        private Label lblDistroy6;
        private Label lblItemFee6;
        private Label lblItemFee5;
        private Label lblItemFee4;
        private Label label52;
        private Label label36;
        private Label lbl3XianJinZhiFu;
        private Label lbl3GeRenZhangHu;
        private Label lbl2XianJinZhiFu;
        private Label lbl3GongWuYuan;
        private Label lbl2GeRenZhangHu;
        private Label lbl3DaEJiZhang;
        private Label lbl2GongWuYuan;
        private Label lbl3TongChouJiZhang;
        private Label lbl2DaEJiZhang;
        private Label lbl3QiFuBiaoZhun;
        private Label lbl2TongChouJiZhang;
        private Label lbl3AnBiLiZhiFu;
        private Label lbl2QiFuBiaoZhun;
        private Label lbl3GeRenZhiFu;
        private Label lbl2AnBiLiZhiFu;
        private Label lblItem6;
        private Label lbl2GeRenZhiFu;
        private Label lblItem5;
        private Label lbl3ZhiFeiFeiYong;
        private Label lblItem4;
        private Label label51;
        private Label lbl2ZhiFeiFeiYong;
        private Label label35;
        private Label lblOp6;
        private Label lbl3ItemFee7;
        private Label lbl1ItemFee7;
        private Label lbl3ItemFee6;
        private Label lbl1ItemFee6;
        private Label lbl3ItemFee5;
        private Label lbl1ItemFee5;
        private Label lbl3ItemFee4;
        private Label lbl1ItemFee4;
        private Label lbl3ItemFee3;
        private Label lbl3ItemFee2;
        private Label lbl1ItemFee3;
        private Label lbl3Item7;
        private Label lbl1ItemFee2;
        private Label lbl3ItemFee1;
        private Label lbl1Item7;
        private Label lbl3Item6;
        private Label lbl1ItemFee1;
        private Label lbl3ItemFee0;
        private Label lbl1Item6;
        private Label lbl3Item5;
        private Label lbl1ItemFee0;
        private Label lbl1Item5;
        private Label lbl3Item4;
        private Label label20;
        private Label lbl1Item4;
        private Label lbl3Item3;
        private Label lblOp5;
        private Label lbl1Item3;
        private Label lbl3Item2;
        private Label label66;
        private Label lbl1Item2;
        private Label lbl3Item1;
        private Label lblOp4;
        private Label lbl1Item1;
        private Label lbl3Item0;
        private Label lblOp3;
        private Label lbl1Item0;
        private Label lblOp2;
        private Label label19;
        private Label lblOp1;
        private Label lblTotCost3;
        private Label lblTotCost1;
        private Label lblHosName6;
        private Label lblHosName5;
        private Label lblDeptE6;
        private Label lblDeptE5;
        private Label lblDeptR6;
        private Label lblDeptE4;
        private Label lblDeptR5;
        private Label lblDeptR4;
        private Label lblHosName4;
        private Label lblHosName3;
        private Label label30;
        private Label label53;
        private Label lblPactName3;
        private Label label31;
        private Label lblPactName2;
        private Label lblPactName1;
        private Label lblPayKind3;
        private Label lblDate6;
        private Label lblDate5;
        private Label lblPayKind1;
        private Label lblDate4;
        private Label lblName6;
        private Label lblDate3;
        private Label lblName5;
        private Label lblDate2;
        private Label lblName4;
        private Label lblName3;
        private Label lblName2;
        private Label lblDate1;
        private Label lblName1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label13;
        private Label label12;
        protected Label lblReprint;
        private Label label14;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label invoiceno1;
        private Label invoiceno6;
        private Label invoiceno5;
        private Label invoiceno4;
        private Label invoiceno3;
        private Label invoiceno2;
        private Label lblTotCost4;
        private Label label15;
        private Label lbltotcost5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblCardNo0;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblCardNo5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblCardNo4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblCardNo3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblCardNo2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblCardNo1;
        private Label lblRePrint2;
        private Label lblRePrint1;
        private Label lblRePrint3;
        private Label lblPrint;
        private Label label11;
        private Label label10;
        private Label label9;//是否预览
		private Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction();
             
		#endregion

		#region 函数

		public int SetPrintValue(Neusoft.HISFC.Models.Registration.Register regInfo, Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice, ArrayList alInvoiceDetail, ArrayList alFeeItemList, bool isPreview)
		{
			//如果费用明细为空，则返回
            if (alFeeItemList.Count <= 0)
            {
                return -1;
            }

            #region 基本信息

            this.invoiceno1.Text = long.Parse(invoice.Invoice.ID).ToString();
            this.invoiceno3.Text = long.Parse(invoice.Invoice.ID).ToString();
            this.invoiceno4.Text = long.Parse(invoice.Invoice.ID).ToString();
            this.invoiceno5.Text = long.Parse(invoice.Invoice.ID).ToString();
            this.invoiceno6.Text = long.Parse(invoice.Invoice.ID).ToString();
            this.invoiceno2.Text = long.Parse(invoice.Invoice.ID).ToString();

            this.lblCardNo0.Text = long.Parse(regInfo.PID.CardNO).ToString();
            this.lblCardNo1.Text = long.Parse(regInfo.PID.CardNO).ToString();
            this.lblCardNo2.Text = long.Parse(regInfo.PID.CardNO).ToString();
            this.lblCardNo3.Text = long.Parse(regInfo.PID.CardNO).ToString();
            this.lblCardNo4.Text = long.Parse(regInfo.PID.CardNO).ToString();
            this.lblCardNo5.Text = long.Parse(regInfo.PID.CardNO).ToString();
            //姓名
            //regInfo.Name;
            this.lblName1.Text = string.Format("姓名：{0}", regInfo.Name);
            this.lblName2.Text = string.Format("{0}", regInfo.Name);
            this.lblName3.Text = string.Format("{0}", regInfo.Name);
            this.lblName4.Text = string.Format("{0}", regInfo.Name);
            this.lblName5.Text = string.Format("{0}", regInfo.Name);
            this.lblName6.Text = string.Format("{0}", regInfo.Name);

            //日期
            //invoice.PrintTime;  
            this.lblDate1.Text = string.Format("{0}", invoice.PrintTime.ToString("yyyy.MM.dd"));
            this.lblDate2.Text = string.Format("日期：{0}", invoice.PrintTime.ToString("yyyy.MM.dd"));
            this.lblDate3.Text = string.Format("{0}", invoice.PrintTime.ToString("yyyy.MM.dd"));
            this.lblDate4.Text = string.Format("{0}", invoice.PrintTime.ToString("yyyy.MM.dd"));
            this.lblDate5.Text = string.Format("{0}", invoice.PrintTime.ToString("yyyy.MM.dd"));
            this.lblDate6.Text = string.Format("{0}", invoice.PrintTime.ToString("yyyy.MM.dd"));

            //制单
            //invoice.BalanceOper.ID;
           // this.lblOp1.Text = string.Format("制单：{0}", invoice.BalanceOper.ID);
            this.lblOp1.Text = string.Format("{0}", invoice.BalanceOper.ID.Substring(4,2));
            this.lblOp2.Text = string.Format("{0}", invoice.BalanceOper.ID.Substring(4,2));
            this.lblOp3.Text = string.Format("{0}", invoice.BalanceOper.ID.Substring(4,2));
            this.lblOp4.Text = string.Format("制单：{0}", invoice.BalanceOper.ID);
            this.lblOp5.Text = string.Format("制单：{0}", invoice.BalanceOper.ID);
            this.lblOp6.Text = string.Format("制单：{0}", invoice.BalanceOper.ID);

            //医院名称
            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            string hosName= managerIntegrate.GetHospitalName();
            this.lblHosName3.Text = hosName;
            //this.lblHosName4.Text = hosName;
            //this.lblHosName5.Text = hosName;
            //this.lblHosName6.Text = hosName;

            this.lblHosName4.Text = string.Format("{0}", "郑大一附院");
            this.lblHosName5.Text = string.Format("{0}", "郑大一附院");
            this.lblHosName6.Text = string.Format("{0}", "郑大一附院");

            //支付方式
            this.lblPayKind1.Visible = true;
            this.lblPayKind3.Visible = true;
            this.lblPayKind1.Text = this.splitInvoicePayMode;
            if (!string.IsNullOrEmpty(this.lblPayKind1.Text))
            {
                if (this.lblPayKind1.Text.Substring(0, 2) == "现金")
                {
                    this.lblPayKind1.Text = "现金";
                }
                else if (this.lblPayKind1.Text.Substring(0, 3) == "银行卡")
                {
                    this.lblPayKind1.Text = "银行卡";
                }
                else
                {
                    this.lblPayKind1.Text = this.splitInvoicePayMode;
                }
            }

                this.lblPayKind3.Text = this.splitInvoicePayMode;

                if (!string.IsNullOrEmpty(this.lblPayKind3.Text))
                {
                    if (this.lblPayKind3.Text.Substring(0, 2) == "现金")
                    {
                        this.lblPayKind3.Text = "现金";
                    }
                    else if (this.lblPayKind3.Text.Substring(0, 3) == "银行卡")
                    {
                        this.lblPayKind3.Text = "银行卡";
                    }
                    else
                    {
                        this.lblPayKind3.Text = this.splitInvoicePayMode;
                    }

                }
            //if (this.setPayModeType == "1")
            //{
               
            //}
            //else
            //{
            //    this.lblPayKind1.Text = this.SplitInvoicePayMode;
            //    this.lblPayKind3.Text = this.SplitInvoicePayMode;
            //}

            //合同单位
            Hashtable ZZCityKind = new Hashtable();
            ZZCityKind["302"] = "郑州市医疗保险(中原区)";
            ZZCityKind["303"] = "郑州市医疗保险(二七区)";
            ZZCityKind["304"] = "郑州市医疗保险(管城区)";
            ZZCityKind["305"] = "郑州市医疗保险(金水区)";
            ZZCityKind["306"] = "郑州市医疗保险(上街区)";
            ZZCityKind["308"] = "郑州市医疗保险(惠济区)";
            ZZCityKind["000"] = "郑州市医疗保险";
            if (string.IsNullOrEmpty(regInfo.SIMainInfo.Fund.Name)) {
                regInfo.SIMainInfo.Fund.Name = "000";
            }
            if (regInfo.Pact.ID == "05")
            {
                if (regInfo.SIMainInfo.PersonType.ID == "41")
                {
                    this.lblPactName1.Text = "郑州市医疗保险(居民)";
                    this.lblPactName2.Text = "郑州市医疗保险(居民)";
                    this.lblPactName3.Text = "郑州市医疗保险(居民)";
                }
                else if ((regInfo.SIMainInfo.PersonType.ID == "21" || regInfo.SIMainInfo.PersonType.ID == "11") && !ZZCityKind.ContainsKey(regInfo.SIMainInfo.Fund.Name))
                {
                    this.lblPactName1.Text = "郑州市医疗保险(职工)";
                    this.lblPactName2.Text = "郑州市医疗保险(职工)";
                    this.lblPactName3.Text = "郑州市医疗保险(职工)";
                }
                else
                {
                    this.lblPactName1.Text = ZZCityKind[regInfo.SIMainInfo.Fund.Name].ToString();
                    this.lblPactName2.Text = ZZCityKind[regInfo.SIMainInfo.Fund.Name].ToString();
                    this.lblPactName3.Text = ZZCityKind[regInfo.SIMainInfo.Fund.Name].ToString();
                }
            }
            else if (regInfo.Pact.ID == "08")
            {
                if (regInfo.SIMainInfo.PersonType.ID == "11" || regInfo.SIMainInfo.PersonType.ID == "21")
                {
                    this.lblPactName1.Text = "郑州市铁路医疗保险(职工)";
                    this.lblPactName2.Text = "郑州市铁路医疗保险(职工)";
                    this.lblPactName3.Text = "郑州市铁路医疗保险(职工)";
                }
                else if (regInfo.SIMainInfo.PersonType.ID == "31")
                {
                    this.lblPactName1.Text = "郑州市铁路医疗保险(家庭)";
                    this.lblPactName2.Text = "郑州市铁路医疗保险(家庭)";
                    this.lblPactName3.Text = "郑州市铁路医疗保险(家庭)";
                }
                else
                {
                    this.lblPactName1.Text = "郑州市铁路医疗保险(离休)";
                    this.lblPactName2.Text = "郑州市铁路医疗保险(离休)";
                    this.lblPactName3.Text = "郑州市铁路医疗保险(离休)";
                }
            }
            else
            {
               
                this.lblPactName1.Text = regInfo.Pact.Name;
                this.lblPactName2.Text = regInfo.Pact.Name;
                this.lblPactName3.Text = regInfo.Pact.Name;
                if (this.lblPactName1.Text == "自费")
                {
                    this.lblPactName1.Visible = false;
                    this.lblPactName2.Visible = false;
                    this.lblPactName3.Visible = false;
                }
                //席宗飞 省保慢性病打印{A697AC2B-7F8C-4312-A6BF-0F80257A2CAD}
                if (!string.IsNullOrEmpty(regInfo.SIMainInfo.MedicalType.ID)) {
                    if (regInfo.SIMainInfo.MedicalType.ID == "2") {
                        this.lblPactName1.Text += " 慢性病";
                        this.lblPactName2.Text += " 慢性病";
                        this.lblPactName3.Text += " 慢性病";
                    }
                }
            }

            //合计
            //this.lblTotCost1.Text =string.Format("合计：{0}", Neusoft.FrameWork.Public.String.FormatNumberReturnString(invoice.FT.TotCost, 2));
            this.lblTotCost1.Text = string.Format("{0}", Neusoft.FrameWork.Public.String.FormatNumberReturnString(invoice.FT.TotCost, 2));
            this.lblTotCost3.Text = string.Format("{0}", Neusoft.FrameWork.Public.String.LowerMoneyToUpper(Neusoft.FrameWork.Public.String.FormatNumber(invoice.FT.TotCost, 2)));
            this.lblTotCost4.Text = string.Format("{0}", Neusoft.FrameWork.Public.String.FormatNumberReturnString(invoice.FT.TotCost, 2));

          
            #endregion

            //#region 具体的项目

            //for (int i = 0; i < alInvoiceDetail.Count; i++)
            //{
            //    Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detail = null;
            //    detail = (Neusoft.HISFC.Models.Fee.Outpatient.BalanceList)alInvoiceDetail[i];

            //    foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lbl1Item" + i.ToString(), true))
            //    {
            //        ctrl.Visible = true;
            //        ctrl.Text = detail.FeeCodeStat.Name;
            //    }

            //    foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lbl1ItemFee" + i.ToString(), true))
            //    {
            //        ctrl.Visible = true;
            //        ctrl.Text = detail.BalanceBase.FT.TotCost.ToString();
                    
            //    }

            //    foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lbl3Item" + i.ToString(), true))
            //    {
            //        ctrl.Visible = true;
            //        ctrl.Text = detail.FeeCodeStat.Name;
            //    }

            //    foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lbl3ItemFee" + i.ToString(), true))
            //    {
            //        ctrl.Visible = true;
            //        ctrl.Text = detail.BalanceBase.FT.TotCost.ToString();
            //    }

            //}

            //#endregion


            #region 医保相关信息

            this.lbl2ZhiFeiFeiYong.Visible = false;
            this.lbl3ZhiFeiFeiYong.Visible = false;

            this.lbl2GeRenZhiFu.Visible = false;
            this.lbl3GeRenZhiFu.Visible = false;

            this.lbl2QiFuBiaoZhun.Visible = false;
            this.lbl3QiFuBiaoZhun.Visible = false;

            this.lbl2AnBiLiZhiFu.Visible = false;
            this.lbl3AnBiLiZhiFu.Visible = false;

            this.lbl2TongChouJiZhang.Visible = false;
            this.lbl3TongChouJiZhang.Visible = false;

            this.lbl2DaEJiZhang.Visible = false;
            this.lbl3DaEJiZhang.Visible = false;

            this.lbl2GongWuYuan.Visible = false;
            this.lbl3GongWuYuan.Visible = false;

            this.lbl2GeRenZhangHu.Visible = false;
            this.lbl3GeRenZhangHu.Visible = false;

            this.lbl2XianJinZhiFu.Visible = false;
            this.lbl3XianJinZhiFu.Visible = false;

            this.label53.Visible = false;
            this.label31.Visible = false;
            this.label15.Visible = false;
            this.label30.Visible = false;

            this.lbltotcost5.Visible = false;

            if (regInfo.Pact.PayKind.ID != "01")
            {

                this.label53.Visible = true;
                this.label31.Visible = true;
                this.label15.Visible = true;

                this.lbltotcost5.Visible = true;
                
                this.label30.Visible = true;
                
                this.lbl2ZhiFeiFeiYong.Visible = true;
                this.lbl3ZhiFeiFeiYong.Visible = true;

                this.lbl2GeRenZhiFu.Visible = true;
                this.lbl3GeRenZhiFu.Visible = true;

                this.lbl2QiFuBiaoZhun.Visible = true;
                this.lbl3QiFuBiaoZhun.Visible = true;

                this.lbl2AnBiLiZhiFu.Visible = true;
                this.lbl3AnBiLiZhiFu.Visible = true;

                this.lbl2TongChouJiZhang.Visible = true;
                this.lbl3TongChouJiZhang.Visible = true;

                this.lbl2DaEJiZhang.Visible = true;
                this.lbl3DaEJiZhang.Visible = true;

                this.lbl2GongWuYuan.Visible = true;
                this.lbl3GongWuYuan.Visible = true;

                this.lbl2GeRenZhangHu.Visible = true;
                this.lbl3GeRenZhangHu.Visible = true;

                this.lbl2XianJinZhiFu.Visible = true;
                this.lbl3XianJinZhiFu.Visible = true;

                //
                decimal ziFeiFeiYong = decimal.Zero;
                decimal geRenZiFu = decimal.Zero;
                decimal qiFuBiaoZhun = decimal.Zero;
                decimal anBiLiZiFu = decimal.Zero;
                decimal tongChouJiZhang = decimal.Zero;
                decimal daEJiZhang = decimal.Zero;
                decimal gongWuYuanJiZhang = decimal.Zero;
                decimal geRenZhangHu = decimal.Zero;
                decimal xianJinZhiFu = decimal.Zero;

                //自费费用
                ziFeiFeiYong = regInfo.SIMainInfo.ItemYLCost;
                //医保编号
                this.label30.Text = string.Format("{0}", regInfo.SIMainInfo.RegNo);
                //账户余额
                this.label53.Text = string.Format("账户余额:{0}", regInfo.SIMainInfo.IndividualBalance.ToString("0.00"));
                this.label31.Text = string.Format("账户余额:{0}", regInfo.SIMainInfo.IndividualBalance.ToString("0.00"));
                this.label15.Text = string.Format("账户余额:{0}", regInfo.SIMainInfo.IndividualBalance.ToString("0.00"));

                if (ziFeiFeiYong != 0)
                {
                    this.lbl2ZhiFeiFeiYong.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(ziFeiFeiYong, 2);
                    this.lbl3ZhiFeiFeiYong.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(ziFeiFeiYong, 2);
                }

                //个人自付
                geRenZiFu = regInfo.SIMainInfo.PubOwnCost;
                if (geRenZiFu != 0)
                {
                    this.lbl2GeRenZhiFu.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(geRenZiFu, 2);
                    this.lbl3GeRenZhiFu.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(geRenZiFu, 2);
                }

                //起付标准
                qiFuBiaoZhun = regInfo.SIMainInfo.BaseCost;
                if (qiFuBiaoZhun != 0)
                {
                    this.lbl2QiFuBiaoZhun.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(qiFuBiaoZhun, 2);
                    this.lbl3QiFuBiaoZhun.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(qiFuBiaoZhun, 2);
                }

                //按比例自付
                anBiLiZiFu = regInfo.SIMainInfo.ItemPayCost;
                if (anBiLiZiFu != 0)
                {
                    this.lbl2AnBiLiZhiFu.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(anBiLiZiFu, 2);
                    this.lbl3AnBiLiZhiFu.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(anBiLiZiFu, 2);
                }

                //统筹记账
                tongChouJiZhang = regInfo.SIMainInfo.SiPubCost;
                if (tongChouJiZhang != 0)
                {
                    this.lbl2TongChouJiZhang.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(tongChouJiZhang, 2);
                    this.lbl3TongChouJiZhang.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(tongChouJiZhang, 2);
                }

                //大额记账
                daEJiZhang = regInfo.SIMainInfo.OverCost;
                if (daEJiZhang != 0)
                {
                    this.lbl2DaEJiZhang.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(daEJiZhang, 2);
                    this.lbl3DaEJiZhang.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(daEJiZhang, 2);
                }

                //公务员记账
                gongWuYuanJiZhang = regInfo.SIMainInfo.OfficalCost;
                if (gongWuYuanJiZhang > 0)
                {
                    //{8DA5C28A-11C3-4891-A727-E72A19C36AE2} 席宗飞2010118 对于省农合公务员记帐不显示
                    if (regInfo.Pact.ID == "13")
                    {
                        this.lbl2GongWuYuan.Text = "";
                        this.lbl3GongWuYuan.Text = "";
                    }
                    else
                    {
                        this.lbl2GongWuYuan.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(gongWuYuanJiZhang, 2);
                        this.lbl3GongWuYuan.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(gongWuYuanJiZhang, 2);
                    }

                }

                //个人账户
                geRenZhangHu = regInfo.SIMainInfo.PayCost;
                if (geRenZhangHu != 0)
                {
                    //20101108 席宗飞 省农合的个人账户存储超限额费用{B8DCCA59-92A9-483d-8531-D1177F0D79E3}
                    if (regInfo.Pact.ID == "13")
                    {
                        this.lbl2GeRenZhangHu.Text = "超限额:" + Neusoft.FrameWork.Public.String.FormatNumberReturnString(geRenZhangHu, 2);
                        this.lbl3GeRenZhangHu.Text = "超限额:" + Neusoft.FrameWork.Public.String.FormatNumberReturnString(geRenZhangHu, 2);
                    }
                    else
                    {
                        this.lbl2GeRenZhangHu.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(geRenZhangHu, 2);
                        this.lbl3GeRenZhangHu.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(geRenZhangHu, 2);
                    }

                }

                //现金支付
                xianJinZhiFu = regInfo.SIMainInfo.OwnCost;
                if (xianJinZhiFu != 0)
                {
                    this.lbl2XianJinZhiFu.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(xianJinZhiFu, 2);
                    this.lbl3XianJinZhiFu.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(xianJinZhiFu, 2);
                }
               //合计
                this.lbltotcost5.Text = string.Format("{0}", Neusoft.FrameWork.Public.String.FormatNumberReturnString(invoice.FT.TotCost, 2));


            }

            #endregion           


            #region 小联相关

            ArrayList tmp = new ArrayList();

            //foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item in alFeeItemList)
            //{
            //    if (item.Invoice.ID == invoice.Invoice.ID)
            //    {
            //        tmp.Add(item);
            //    }
            //}
            //zhangyt 2011-03-02
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.BalanceList item in alInvoiceDetail)
            {

                if (item.BalanceBase.Invoice.ID == invoice.Invoice.ID)
                {
                    tmp.Add(item);
                }
            }

            //Hashtable tab = new Hashtable();
            //string key = string.Empty;
            //Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList itemNew = null;
            //foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item in tmp)
            //{
            //    key = GetFeeStatNameByFeeCode(item.Item.MinFee.ID) + "|" + item.ExecOper.Dept.ID;
            //    if (!tab.ContainsKey(key))
            //    {
            //        tab.Add(key, item);
            //    }
            //    else
            //    {
            //        itemNew = item.Clone();
            //        itemNew.FT.TotCost=((Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList)tab[key]).FT.TotCost + item.FT.TotCost;
            //        tab[key] = itemNew;
            //    }
            //}

            //ArrayList mylist = new ArrayList();
            //foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item in tab.Values)
            //{
            //    mylist.Add(item);
            //}

            for (int i = 0; i < tmp.Count; i++) 
            {
              //  Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItem = tmp[i] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
                //zhangyt  2011-03-02
                Neusoft.HISFC.Models.Fee.Outpatient.BalanceList feeItem = tmp[i] as Neusoft.HISFC.Models.Fee.Outpatient.BalanceList;
               // string feeStatName = GetFeeStatNameByFeeCode(feeItem.Item.MinFee.ID);
                string feeStatName = feeItem.FeeCodeStat.Name;

                
                //第一票
                foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lbl1Item" + i.ToString(), true))
                {
                    ctrl.Visible = true;
                    ctrl.Text = feeStatName;
                }

                foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lbl1ItemFee" + i.ToString(), true))
                {
                    ctrl.Visible = true;
                   // ctrl.Text = feeItem.FT.TotCost.ToString();
                    ctrl.Text = feeItem.BalanceBase.FT.TotCost.ToString();

                }
                //第三票
                foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lbl3Item" + i.ToString(), true))
                {
                    ctrl.Visible = true;
                    ctrl.Text = feeStatName;
                }

                foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lbl3ItemFee" + i.ToString(), true))
                {
                    ctrl.Visible = true;
                    //ctrl.Text = feeItem.FT.TotCost.ToString();
                    //zhangyt
                    ctrl.Text = feeItem.BalanceBase.FT.TotCost.ToString();
                }

                if (regInfo.Memo != "门诊退费标记")
                {
                    //执行科室
                    foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lblDeptE" + (4 + i).ToString(), true))
                    {
                        ctrl.Visible = true;
                        //ctrl.Text = feeItem.ExecOper.Dept.Name;
                        //zhangyt
                       // ctrl.Text = feeItem.ExecDept.Name;
                    }
                    //开立科室
                    //foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lblDeptR" + (4 + i).ToString(), true))
                    //{
                    //    ctrl.Visible = true;
                    //    ctrl.Text = regInfo.DoctorInfo.Templet.Dept.Name;
                    //}
                    //姓名
                    foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lblName" + (4 + i).ToString(), true))
                    {
                        ctrl.Visible = true;
                    }

                    if (regInfo.Memo.Trim() == "补打")
                    {
                        this.lblPrint.Visible = true;
                        foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lblRePrint" + (1 + i).ToString(), true))
                        {
                            ctrl.Visible = true;
                        }
                    }
                    //else
                    //{
                    //    foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lblRePrint" + (1 + i).ToString(), true))
                    //    {
                    //        ctrl.Visible = false;
                    //    }

                    //}

                    //项目名称
                    foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lblItem" + (4 + i).ToString(), true))
                    {
                        ctrl.Visible = true;
                        ctrl.Text = feeStatName;
                    }

                    //项目金额
                    foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lblItemFee" + (4 + i).ToString(), true))
                    {
                        ctrl.Visible = true;
                        //ctrl.Text = feeItem.FT.TotCost.ToString();
                        //zhangyt 2011-03-02
                        ctrl.Text = feeItem.BalanceBase.FT.TotCost.ToString();
                    }

                    ////作废
                    ////项目金额
                    //foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lblDistroy" + (4 + i).ToString(), true))
                    //{
                    //    ctrl.Visible = false;
                    //}
                }
                //else 
                //{
                //    //作废
                //    //项目金额
                //    foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lblDistroy" + (4 + i).ToString(), true))
                //    {
                //        ctrl.Visible = true;
                //    }

                //}

            }
         
            #endregion
            this.lblDistroy4.Visible = true;
            this.lblDistroy5.Visible = true;
            this.lblDistroy6.Visible = true;
           
            this.lblDeptE4.Visible = false;
            this.lblDeptE5.Visible = false;
            this.lblDeptE6.Visible = false;

            #region   小联是作废 不显示信息
            for(int i=0;i<3;i++)
            {
                foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lblDistroy" + (4 + i).ToString(), true))
                {
                    if (ctrl.Text == "作废"&&ctrl.Visible==true)
                    {
                        foreach (System.Windows.Forms.Control ctrl1 in this.Controls.Find("lblItem" + (4 + i).ToString(), true))
                        {
                            ctrl1.Visible = false;
                        }

                        foreach (System.Windows.Forms.Control ctrl1 in this.Controls.Find("lblItemFee" + (4 + i).ToString(), true))
                        {
                            ctrl1.Visible = false;
                        }

                        foreach (System.Windows.Forms.Control ctrl1 in this.Controls.Find("lblName" + (4 + i).ToString(), true))
                        {
                            ctrl1.Visible = false;
                        }

                        foreach (System.Windows.Forms.Control ctrl1 in this.Controls.Find("lblDate" + (4 + i).ToString(), true))
                        {
                            ctrl1.Visible = false;
                        }
                        foreach (System.Windows.Forms.Control ctrl1 in this.Controls.Find("lblHosName" + (4 + i).ToString(), true))
                        {
                            ctrl1.Visible = false;
                        }
                        foreach (System.Windows.Forms.Control ctrl1 in this.Controls.Find("invoiceno" + (4 + i).ToString(), true))
                        {
                            ctrl1.Visible = false;
                        }  
                    }
                }
            }
            #endregion

            //this.Print();
			return 0;
		}


        private string GetFeeStatNameByFeeCode(string feeCode) 
        {
            Neusoft.HISFC.BizLogic.Fee.FeeCodeStat feeMgr = new Neusoft.HISFC.BizLogic.Fee.FeeCodeStat();
            DataSet ds = new DataSet();

            string sql = @"
SELECT feestat.FEE_STAT_NAME 
FROM FIN_COM_FEECODESTAT feestat
WHERE  feestat.FEE_CODE='{0}'
     AND feestat.REPORT_CODE='MZ01'
";

            sql = string.Format(sql, feeCode);

            string val = string.Empty;
            try
            {
                //val = feeMgr.ExecQuery(sql,ref ds);
                feeMgr.ExecQuery(sql, ref ds);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    return " ";
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    val = dr.ItemArray.GetValue(0).ToString();
                }
               
            }
            catch (Exception ex)
            {
                feeMgr.Err = ex.Message;
            }

            return val;
        }
		


		#endregion

		#region IInvoicePrint 成员

		public bool IsPreView
		{
			set
			{
				_isPreView = value;
			}
		}

		public string Description
		{
			get
			{
				return "门诊发票";
			}
		}

		public void SetPreView(bool isPreView)
		{
			_isPreView = isPreView;
		}

		public int Print()
		{
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Print print = null;
                Neusoft.HISFC.Models.Base.PageSize ps = null;
                try
                {
                    print = new Neusoft.FrameWork.WinForms.Classes.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化打印机失败!" + ex.Message);

                    return -1;
                }

                ps = new Neusoft.HISFC.Models.Base.PageSize();
                Neusoft.HISFC.BizLogic.Manager.PageSize pss = new Neusoft.HISFC.BizLogic.Manager.PageSize();
                ps = pss.GetPageSize("MZJSFP");

                print.SetPageSize(ps);

                print.PrintPage(0, 0, this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }

            return 1;
		}

        private string setPayModeType = "";
        
        private string splitInvoicePayMode = "";
        
        private string invoiceType;

        public string InvoiceType
        {
            get { return "MZ01"; }
        }

        private Neusoft.HISFC.Models.Registration.Register register;
        public Neusoft.HISFC.Models.Registration.Register Register
        {
            set
            {
                invoiceType = "MZ01";
            }
        }

		public void SetTrans(Neusoft.FrameWork.Management.Transaction t)
		{
			this.trans = t;
		}

		public Neusoft.FrameWork.Management.Transaction Trans
		{
			set
			{
				this.trans = value;
			}
		}


		public int PrintOtherInfomation()
		{
            //Neusoft.FrameWork.WinForms.Classes.Print print = null;
            //try
            //{
            //    print = new Neusoft.FrameWork.WinForms.Classes.Print();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("初始化打印机失败!" + ex.Message);
            //    return -1;
            //}
            //if(this.trans == null)
            //{
            //    MessageBox.Show("没有设置数据库连接!");
            //    return -1;
            //}
            ////Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("MZFEEDETAIL", ref print, ref this.trans);
            //print.PrintDocument.PrinterSettings.PrinterName = "MZFEEDETAILPRINTER";
            //System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize("MZFEEDETAIL", 669, 425);
            //print.IsDataAutoExtend = true;
            //print.SetPageSize(size);
            //print.IsCanCancel = false;
            //print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;

            return 0;
           
		}

        public string SetPayModeType
        {
            set
            {
                this.setPayModeType = value;
            }
            get
            {
                return this.setPayModeType;
            }
        }

        public void SetTrans( IDbTransaction trans )
        {
            this.trans.Trans = trans;
        }

        public string SplitInvoicePayMode
        {
            set
            {
                this.splitInvoicePayMode = value;
            }
            get 
            {
                return this.splitInvoicePayMode;
            }
        }

        IDbTransaction Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.Trans
        {
            set
            {
                throw new Exception( "The method or operation is not implemented." );
            }
        }

        string Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.Description
        {
            get { return null; }
        }

        bool Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.IsPreView
        {
            set {  }
        }

        int Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.Print()
        {
            //try
            //{
            //    Neusoft.FrameWork.WinForms.Classes.Print print = null;
            //    try
            //    {
            //        print = new Neusoft.FrameWork.WinForms.Classes.Print();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("初始化打印机失败!" + ex.Message);
            //        return -1;
            //    }
            //    if (this.trans == null)
            //    {
            //        MessageBox.Show("没有设置数据库连接!");
            //        return -1;
            //    }
            //    Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("MZINVOICE", ref print, ref this.trans);

            //    System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize("GYMZInvoice", 787, 400);
            //    print.SetPageSize(size);
            //    print.IsCanCancel = false;
            //    print.PrintPage(0, 0, this);
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //    return -1;
            //}
            //return 0;
           return this.Print();
           
        }

        int Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.PrintOtherInfomation()
        {
            return 1;
        }

        Neusoft.HISFC.Models.Registration.Register Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.Register
        {
            set {  }
        }

        string Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetPayModeType
        {
            set { }
        }

        void Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetPreView(bool isPreView)
        {
            ;
        }

        int Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetPrintOtherInfomation(Neusoft.HISFC.Models.Registration.Register regInfo, ArrayList Invoices, ArrayList invoiceDetails, ArrayList feeDetails)
        {
            return 1;
        }

        int Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetPrintValue(Neusoft.HISFC.Models.Registration.Register regInfo, Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice, ArrayList invoiceDetails, ArrayList feeDetails, bool isPreview)
        {
            this.SetPrintValue(regInfo, invoice, invoiceDetails, feeDetails, isPreview);
            return 1;
        }

        void Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetTrans(IDbTransaction trans)
        {
            
        }

        string Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SplitInvoicePayMode
        {

            set
            {
                SplitInvoicePayMode = value;
            }

            
         
        }

        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] type = new Type[1];
             
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint);
                return type;
            }
        }

        #endregion

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}