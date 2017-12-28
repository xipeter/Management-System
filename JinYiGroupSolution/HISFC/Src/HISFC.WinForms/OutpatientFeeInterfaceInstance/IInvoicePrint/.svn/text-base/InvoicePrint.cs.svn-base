using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace OutpatientInvoicePrint
{
	/// <summary>
	/// ucInvoiceGY 的摘要说明。
    /// donggq--20101202--{47D224C1-D4ED-4eb6-B605-02669C3D1ED7}
	/// </summary>
    public class ucInvoiceGY : System.Windows.Forms.UserControl//, Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
	{
      //  #region windows代码

      //  protected System.Windows.Forms.Label lblPreSign;
      //  protected System.Windows.Forms.Label lblPriLower;
      //  protected System.Windows.Forms.Label lblPriPay;
      //  protected System.Windows.Forms.Label lblPreOwnPay;
      //  protected System.Windows.Forms.Label lblPriPub;
      //  protected System.Windows.Forms.Label lblPrePub;
      //  protected System.Windows.Forms.Label lblPreUpperCost;
      //  protected System.Windows.Forms.Label lblPriPayKind;
      //  protected System.Windows.Forms.Label lblPrePaykind;
      //  protected System.Windows.Forms.Label lblPreName;
      //  protected System.Windows.Forms.Label lblPriName;
      //  protected System.Windows.Forms.Label lblPriCost8;
      //  protected System.Windows.Forms.Label lblPriCost7;
      //  protected System.Windows.Forms.Label lblPriCost6;
      //  protected System.Windows.Forms.Label lblPriCost5;
      //  protected System.Windows.Forms.Label lblPriCost4;
      //  protected System.Windows.Forms.Label lblPriCost3;
      //  protected System.Windows.Forms.Label lblPriCost2;
      //  protected System.Windows.Forms.Label lblPriCost1;
      //  protected System.Windows.Forms.Label lblPreColumn2;
      //  protected System.Windows.Forms.Label lblPreFeeName8;
      //  protected System.Windows.Forms.Label lblPreFeeName7;
      //  protected System.Windows.Forms.Label lblPreFeeName6;
      //  protected System.Windows.Forms.Label lblPreFeeName5;
      //  protected System.Windows.Forms.Label lblPreFeeName4;
      //  protected System.Windows.Forms.Label lblPreFeeName3;
      //  protected System.Windows.Forms.Label lblPreFeeName2;
      //  protected System.Windows.Forms.Label lblPreFeeName1;
      //  protected System.Windows.Forms.Label lblPreColumn1;
      //  protected System.Windows.Forms.Label lblPriCost24;
      //  protected System.Windows.Forms.Label lblPriCost23;
      //  protected System.Windows.Forms.Label lblPriCost22;
      //  protected System.Windows.Forms.Label lblPriCost21;
      //  protected System.Windows.Forms.Label lblPriCost20;
      //  protected System.Windows.Forms.Label lblPriCost19;
      //  protected System.Windows.Forms.Label lblPriCost18;
      //  protected System.Windows.Forms.Label lblPriCost17;
      //  protected System.Windows.Forms.Label lblPreColumn7;
      //  protected System.Windows.Forms.Label lblPreFeeName24;
      //  protected System.Windows.Forms.Label lblPreFeeName23;
      //  protected System.Windows.Forms.Label lblPreFeeName22;
      //  protected System.Windows.Forms.Label lblPreFeeName21;
      //  protected System.Windows.Forms.Label lblPreFeeName20;
      //  protected System.Windows.Forms.Label lblPreFeeName19;
      //  protected System.Windows.Forms.Label lblPreFeeName18;
      //  protected System.Windows.Forms.Label lblPreFeeName17;
      //  protected System.Windows.Forms.Label lblPreColumn5;
      //  protected System.Windows.Forms.Label lblPriCost16;
      //  protected System.Windows.Forms.Label lblPriCost15;
      //  protected System.Windows.Forms.Label lblPriCost14;
      //  protected System.Windows.Forms.Label lblPriCost13;
      //  protected System.Windows.Forms.Label lblPriCost12;
      //  protected System.Windows.Forms.Label lblPriCost11;
      //  protected System.Windows.Forms.Label lblPriCost10;
      //  protected System.Windows.Forms.Label lblPriCost9;
      //  protected System.Windows.Forms.Label lblPreColumn4;
      //  protected System.Windows.Forms.Label lblPreFeeName16;
      //  protected System.Windows.Forms.Label lblPreFeeName15;
      //  protected System.Windows.Forms.Label lblPreFeeName14;
      //  protected System.Windows.Forms.Label lblPreFeeName13;
      //  protected System.Windows.Forms.Label lblPreFeeName12;
      //  protected System.Windows.Forms.Label lblPreFeeName11;
      //  protected System.Windows.Forms.Label lblPreFeeName10;
      //  protected System.Windows.Forms.Label lblPreFeeName9;
      //  protected System.Windows.Forms.Label lblPreColumn3;
      //  protected System.Windows.Forms.Label lblPreSwTitle;
      //  protected System.Windows.Forms.Label lblPreSwXL;
      //  protected System.Windows.Forms.Label lblPreSwYearDisPlay;
      //  protected System.Windows.Forms.Label lblPreSwMonthDisPlay;
      //  protected System.Windows.Forms.Label lblPreSwDayDisPlay;
      //  protected System.Windows.Forms.Label lblPreSwHosPital;
      //  protected System.Windows.Forms.Label lblPriSwBalanceType;
      //  protected System.Windows.Forms.Label lblPriSwDay;
      //  protected System.Windows.Forms.Label lblPriSwMonth;
      //  protected System.Windows.Forms.Label lblPriSwYear;
      //  protected System.Windows.Forms.Label lblPriSwCardNo;
      //  protected System.Windows.Forms.Label lblPreSwInclude4;
      //  protected System.Windows.Forms.Label lblPreSwInclude2;
      //  protected System.Windows.Forms.Label lblPriSwOper;
      //  protected System.Windows.Forms.Label lblPreSwOper;
      //  protected System.Windows.Forms.Label lblPreSwInclude6;
      //  protected System.Windows.Forms.Label lblPreSwInclude5;
      //  protected System.Windows.Forms.Label lblPriSwHosPital;
      //  protected System.Windows.Forms.Label lblPreSwCheck;
      //  protected System.Windows.Forms.Label lblPriSwCheck;
      //  protected System.Windows.Forms.Label lblPreFen;
      //  protected System.Windows.Forms.Label lblPreJiao;
      //  protected System.Windows.Forms.Label lblPreYuan;
      //  protected System.Windows.Forms.Label lblPreShi;
      //  protected System.Windows.Forms.Label lblPreBai;
      //  protected System.Windows.Forms.Label lblPreQiang;
      //  protected System.Windows.Forms.Label lblPreWWW;
      //  protected System.Windows.Forms.Label lblPreTenW;
      //  protected System.Windows.Forms.Label lblPriQian;
      //  protected System.Windows.Forms.Label lblPriTenW;
      //  protected System.Windows.Forms.Label lblPriWan;
      //  protected System.Windows.Forms.Label lblPriBai;
      //  protected System.Windows.Forms.Label lblPriShi;
      //  protected System.Windows.Forms.Label lblPriYing;
      //  protected System.Windows.Forms.Label lblPriJiao;
      //  protected System.Windows.Forms.Label lblPriFen;
      //  protected System.Windows.Forms.Label lblPriSwDrugWindow;
      //  private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblDrugWindow;
      //  private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblRecipeNo;
      //  protected Label lblReprint;
      //  private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel24;
      //  private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel22;
      //  protected Label label1;
      //  protected Label label2;
		
      //  /// <summary> 
      //  /// 必需的设计器变量。
      //  /// </summary>
      //  private System.ComponentModel.Container components = null;

      //  public ucInvoiceGY()
      //  {
      //      // 该调用是 Windows.Forms 窗体设计器所必需的。
      //      InitializeComponent();

      //      // TODO: 在 InitializeComponent 调用后添加任何初始化

      //  }

      //  /// <summary> 
      //  /// 清理所有正在使用的资源。
      //  /// </summary>
      //  protected override void Dispose( bool disposing )
      //  {
      //      if( disposing )
      //      {
      //          if(components != null)
      //          {
      //              components.Dispose();
      //          }
      //      }
      //      base.Dispose( disposing );
      //  }

      //  #region 组件设计器生成的代码
      //  /// <summary> 
      //  /// 设计器支持所需的方法 - 不要使用代码编辑器 
      //  /// 修改此方法的内容。
      //  /// </summary>
      //  private void InitializeComponent()
      //  {
      //      this.lblPreSwInclude4 = new System.Windows.Forms.Label();
      //      this.lblPriSwBalanceType = new System.Windows.Forms.Label();
      //      this.lblPriFen = new System.Windows.Forms.Label();
      //      this.lblPriJiao = new System.Windows.Forms.Label();
      //      this.lblPriYing = new System.Windows.Forms.Label();
      //      this.lblPriShi = new System.Windows.Forms.Label();
      //      this.lblPriBai = new System.Windows.Forms.Label();
      //      this.lblPriQian = new System.Windows.Forms.Label();
      //      this.lblPriWan = new System.Windows.Forms.Label();
      //      this.lblPriTenW = new System.Windows.Forms.Label();
      //      this.lblPreSign = new System.Windows.Forms.Label();
      //      this.lblPriLower = new System.Windows.Forms.Label();
      //      this.lblPreFen = new System.Windows.Forms.Label();
      //      this.lblPreJiao = new System.Windows.Forms.Label();
      //      this.lblPreYuan = new System.Windows.Forms.Label();
      //      this.lblPreShi = new System.Windows.Forms.Label();
      //      this.lblPreBai = new System.Windows.Forms.Label();
      //      this.lblPreQiang = new System.Windows.Forms.Label();
      //      this.lblPreWWW = new System.Windows.Forms.Label();
      //      this.lblPreSwInclude2 = new System.Windows.Forms.Label();
      //      this.lblPriSwDay = new System.Windows.Forms.Label();
      //      this.lblPriSwMonth = new System.Windows.Forms.Label();
      //      this.lblPriSwYear = new System.Windows.Forms.Label();
      //      this.lblPriSwCardNo = new System.Windows.Forms.Label();
      //      this.lblPriSwOper = new System.Windows.Forms.Label();
      //      this.lblPreSwOper = new System.Windows.Forms.Label();
      //      this.lblPriPay = new System.Windows.Forms.Label();
      //      this.lblPreOwnPay = new System.Windows.Forms.Label();
      //      this.lblPriPub = new System.Windows.Forms.Label();
      //      this.lblPrePub = new System.Windows.Forms.Label();
      //      this.lblPreTenW = new System.Windows.Forms.Label();
      //      this.lblPreUpperCost = new System.Windows.Forms.Label();
      //      this.lblPriPayKind = new System.Windows.Forms.Label();
      //      this.lblPrePaykind = new System.Windows.Forms.Label();
      //      this.lblPriCost24 = new System.Windows.Forms.Label();
      //      this.lblPriCost23 = new System.Windows.Forms.Label();
      //      this.lblPriCost22 = new System.Windows.Forms.Label();
      //      this.lblPriCost21 = new System.Windows.Forms.Label();
      //      this.lblPriCost20 = new System.Windows.Forms.Label();
      //      this.lblPriCost19 = new System.Windows.Forms.Label();
      //      this.lblPriCost18 = new System.Windows.Forms.Label();
      //      this.lblPriCost17 = new System.Windows.Forms.Label();
      //      this.lblPreColumn7 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName24 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName23 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName22 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName21 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName20 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName19 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName18 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName17 = new System.Windows.Forms.Label();
      //      this.lblPreColumn5 = new System.Windows.Forms.Label();
      //      this.lblPriCost16 = new System.Windows.Forms.Label();
      //      this.lblPriCost15 = new System.Windows.Forms.Label();
      //      this.lblPriCost14 = new System.Windows.Forms.Label();
      //      this.lblPriCost13 = new System.Windows.Forms.Label();
      //      this.lblPriCost12 = new System.Windows.Forms.Label();
      //      this.lblPriCost11 = new System.Windows.Forms.Label();
      //      this.lblPriCost10 = new System.Windows.Forms.Label();
      //      this.lblPriCost9 = new System.Windows.Forms.Label();
      //      this.lblPreColumn4 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName16 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName15 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName14 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName13 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName12 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName11 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName10 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName9 = new System.Windows.Forms.Label();
      //      this.lblPreColumn3 = new System.Windows.Forms.Label();
      //      this.lblPreName = new System.Windows.Forms.Label();
      //      this.lblPriName = new System.Windows.Forms.Label();
      //      this.lblPriCost8 = new System.Windows.Forms.Label();
      //      this.lblPriCost7 = new System.Windows.Forms.Label();
      //      this.lblPriCost6 = new System.Windows.Forms.Label();
      //      this.lblPriCost5 = new System.Windows.Forms.Label();
      //      this.lblPriCost4 = new System.Windows.Forms.Label();
      //      this.lblPriCost3 = new System.Windows.Forms.Label();
      //      this.lblPriCost2 = new System.Windows.Forms.Label();
      //      this.lblPriCost1 = new System.Windows.Forms.Label();
      //      this.lblPreColumn2 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName8 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName7 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName6 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName5 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName4 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName3 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName2 = new System.Windows.Forms.Label();
      //      this.lblPreFeeName1 = new System.Windows.Forms.Label();
      //      this.lblPreColumn1 = new System.Windows.Forms.Label();
      //      this.lblPreSwDayDisPlay = new System.Windows.Forms.Label();
      //      this.lblPreSwMonthDisPlay = new System.Windows.Forms.Label();
      //      this.lblPreSwYearDisPlay = new System.Windows.Forms.Label();
      //      this.lblPreSwXL = new System.Windows.Forms.Label();
      //      this.lblPreSwTitle = new System.Windows.Forms.Label();
      //      this.lblPreSwInclude6 = new System.Windows.Forms.Label();
      //      this.lblPreSwInclude5 = new System.Windows.Forms.Label();
      //      this.lblPreSwHosPital = new System.Windows.Forms.Label();
      //      this.lblPriSwHosPital = new System.Windows.Forms.Label();
      //      this.lblPreSwCheck = new System.Windows.Forms.Label();
      //      this.lblPriSwCheck = new System.Windows.Forms.Label();
      //      this.lblPriSwDrugWindow = new System.Windows.Forms.Label();
      //      this.lblDrugWindow = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
      //      this.lblRecipeNo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
      //      this.lblReprint = new System.Windows.Forms.Label();
      //      this.neuLabel24 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
      //      this.neuLabel22 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
      //      this.label1 = new System.Windows.Forms.Label();
      //      this.label2 = new System.Windows.Forms.Label();
      //      this.SuspendLayout();
      //      // 
      //      // lblPreSwInclude4
      //      // 
      //      this.lblPreSwInclude4.Location = new System.Drawing.Point(208, 228);
      //      this.lblPreSwInclude4.Name = "lblPreSwInclude4";
      //      this.lblPreSwInclude4.Size = new System.Drawing.Size(17, 21);
      //      this.lblPreSwInclude4.TabIndex = 365;
      //      this.lblPreSwInclude4.Text = "中";
      //      this.lblPreSwInclude4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriSwBalanceType
      //      // 
      //      this.lblPriSwBalanceType.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriSwBalanceType.Location = new System.Drawing.Point(516, 9);
      //      this.lblPriSwBalanceType.Name = "lblPriSwBalanceType";
      //      this.lblPriSwBalanceType.Size = new System.Drawing.Size(111, 19);
      //      this.lblPriSwBalanceType.TabIndex = 363;
      //      this.lblPriSwBalanceType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      //      // 
      //      // lblPriFen
      //      // 
      //      this.lblPriFen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriFen.Location = new System.Drawing.Point(396, 289);
      //      this.lblPriFen.Name = "lblPriFen";
      //      this.lblPriFen.Size = new System.Drawing.Size(33, 21);
      //      this.lblPriFen.TabIndex = 362;
      //      this.lblPriFen.Text = "lblPriF";
      //      this.lblPriFen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriJiao
      //      // 
      //      this.lblPriJiao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriJiao.Location = new System.Drawing.Point(349, 289);
      //      this.lblPriJiao.Name = "lblPriJiao";
      //      this.lblPriJiao.Size = new System.Drawing.Size(30, 21);
      //      this.lblPriJiao.TabIndex = 361;
      //      this.lblPriJiao.Text = "lblPriJ";
      //      this.lblPriJiao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriYing
      //      // 
      //      this.lblPriYing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriYing.Location = new System.Drawing.Point(310, 289);
      //      this.lblPriYing.Name = "lblPriYing";
      //      this.lblPriYing.Size = new System.Drawing.Size(22, 21);
      //      this.lblPriYing.TabIndex = 360;
      //      this.lblPriYing.Text = "lblPriY";
      //      this.lblPriYing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriShi
      //      // 
      //      this.lblPriShi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriShi.Location = new System.Drawing.Point(265, 289);
      //      this.lblPriShi.Name = "lblPriShi";
      //      this.lblPriShi.Size = new System.Drawing.Size(28, 21);
      //      this.lblPriShi.TabIndex = 359;
      //      this.lblPriShi.Text = "lblPriS";
      //      this.lblPriShi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriBai
      //      // 
      //      this.lblPriBai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriBai.Location = new System.Drawing.Point(229, 289);
      //      this.lblPriBai.Name = "lblPriBai";
      //      this.lblPriBai.Size = new System.Drawing.Size(19, 21);
      //      this.lblPriBai.TabIndex = 358;
      //      this.lblPriBai.Text = "lblPriB";
      //      this.lblPriBai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriQian
      //      // 
      //      this.lblPriQian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriQian.Location = new System.Drawing.Point(179, 289);
      //      this.lblPriQian.Name = "lblPriQian";
      //      this.lblPriQian.Size = new System.Drawing.Size(33, 21);
      //      this.lblPriQian.TabIndex = 357;
      //      this.lblPriQian.Text = "lblPriQ";
      //      this.lblPriQian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriWan
      //      // 
      //      this.lblPriWan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriWan.Location = new System.Drawing.Point(144, 289);
      //      this.lblPriWan.Name = "lblPriWan";
      //      this.lblPriWan.Size = new System.Drawing.Size(18, 21);
      //      this.lblPriWan.TabIndex = 356;
      //      this.lblPriWan.Text = "lblPriW";
      //      this.lblPriWan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriTenW
      //      // 
      //      this.lblPriTenW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriTenW.Location = new System.Drawing.Point(113, 289);
      //      this.lblPriTenW.Name = "lblPriTenW";
      //      this.lblPriTenW.Size = new System.Drawing.Size(16, 21);
      //      this.lblPriTenW.TabIndex = 355;
      //      this.lblPriTenW.Text = "lblPriSW";
      //      this.lblPriTenW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreSign
      //      // 
      //      this.lblPreSign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreSign.Location = new System.Drawing.Point(446, 289);
      //      this.lblPreSign.Name = "lblPreSign";
      //      this.lblPreSign.Size = new System.Drawing.Size(21, 21);
      //      this.lblPreSign.TabIndex = 354;
      //      this.lblPreSign.Text = "￥";
      //      this.lblPreSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriLower
      //      // 
      //      this.lblPriLower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriLower.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriLower.Location = new System.Drawing.Point(467, 289);
      //      this.lblPriLower.Name = "lblPriLower";
      //      this.lblPriLower.Size = new System.Drawing.Size(153, 21);
      //      this.lblPriLower.TabIndex = 353;
      //      this.lblPriLower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFen
      //      // 
      //      this.lblPreFen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFen.Location = new System.Drawing.Point(429, 289);
      //      this.lblPreFen.Name = "lblPreFen";
      //      this.lblPreFen.Size = new System.Drawing.Size(17, 21);
      //      this.lblPreFen.TabIndex = 352;
      //      this.lblPreFen.Text = "分";
      //      this.lblPreFen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreJiao
      //      // 
      //      this.lblPreJiao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreJiao.Location = new System.Drawing.Point(379, 289);
      //      this.lblPreJiao.Name = "lblPreJiao";
      //      this.lblPreJiao.Size = new System.Drawing.Size(17, 21);
      //      this.lblPreJiao.TabIndex = 351;
      //      this.lblPreJiao.Text = "角";
      //      this.lblPreJiao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreYuan
      //      // 
      //      this.lblPreYuan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreYuan.Location = new System.Drawing.Point(332, 289);
      //      this.lblPreYuan.Name = "lblPreYuan";
      //      this.lblPreYuan.Size = new System.Drawing.Size(17, 21);
      //      this.lblPreYuan.TabIndex = 350;
      //      this.lblPreYuan.Text = "元";
      //      this.lblPreYuan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreShi
      //      // 
      //      this.lblPreShi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreShi.Location = new System.Drawing.Point(293, 289);
      //      this.lblPreShi.Name = "lblPreShi";
      //      this.lblPreShi.Size = new System.Drawing.Size(17, 21);
      //      this.lblPreShi.TabIndex = 349;
      //      this.lblPreShi.Text = "拾";
      //      this.lblPreShi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreBai
      //      // 
      //      this.lblPreBai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreBai.Location = new System.Drawing.Point(248, 289);
      //      this.lblPreBai.Name = "lblPreBai";
      //      this.lblPreBai.Size = new System.Drawing.Size(17, 21);
      //      this.lblPreBai.TabIndex = 348;
      //      this.lblPreBai.Text = "佰";
      //      this.lblPreBai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreQiang
      //      // 
      //      this.lblPreQiang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreQiang.Location = new System.Drawing.Point(212, 289);
      //      this.lblPreQiang.Name = "lblPreQiang";
      //      this.lblPreQiang.Size = new System.Drawing.Size(17, 21);
      //      this.lblPreQiang.TabIndex = 347;
      //      this.lblPreQiang.Text = "仟";
      //      this.lblPreQiang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreWWW
      //      // 
      //      this.lblPreWWW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreWWW.Location = new System.Drawing.Point(162, 289);
      //      this.lblPreWWW.Name = "lblPreWWW";
      //      this.lblPreWWW.Size = new System.Drawing.Size(17, 21);
      //      this.lblPreWWW.TabIndex = 346;
      //      this.lblPreWWW.Text = "万";
      //      this.lblPreWWW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreSwInclude2
      //      // 
      //      this.lblPreSwInclude2.Location = new System.Drawing.Point(208, 203);
      //      this.lblPreSwInclude2.Name = "lblPreSwInclude2";
      //      this.lblPreSwInclude2.Size = new System.Drawing.Size(17, 21);
      //      this.lblPreSwInclude2.TabIndex = 345;
      //      this.lblPreSwInclude2.Text = "其";
      //      this.lblPreSwInclude2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriSwDay
      //      // 
      //      this.lblPriSwDay.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriSwDay.Location = new System.Drawing.Point(328, 56);
      //      this.lblPriSwDay.Name = "lblPriSwDay";
      //      this.lblPriSwDay.Size = new System.Drawing.Size(40, 19);
      //      this.lblPriSwDay.TabIndex = 343;
      //      this.lblPriSwDay.Text = "lblPriDay";
      //      this.lblPriSwDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriSwMonth
      //      // 
      //      this.lblPriSwMonth.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriSwMonth.Location = new System.Drawing.Point(259, 56);
      //      this.lblPriSwMonth.Name = "lblPriSwMonth";
      //      this.lblPriSwMonth.Size = new System.Drawing.Size(50, 19);
      //      this.lblPriSwMonth.TabIndex = 342;
      //      this.lblPriSwMonth.Text = "lblPriMonth";
      //      this.lblPriSwMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriSwYear
      //      // 
      //      this.lblPriSwYear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriSwYear.Location = new System.Drawing.Point(202, 56);
      //      this.lblPriSwYear.Name = "lblPriSwYear";
      //      this.lblPriSwYear.Size = new System.Drawing.Size(41, 19);
      //      this.lblPriSwYear.TabIndex = 341;
      //      this.lblPriSwYear.Text = "lblPriYear";
      //      this.lblPriSwYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriSwCardNo
      //      // 
      //      this.lblPriSwCardNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriSwCardNo.Location = new System.Drawing.Point(56, 53);
      //      this.lblPriSwCardNo.Name = "lblPriSwCardNo";
      //      this.lblPriSwCardNo.Size = new System.Drawing.Size(146, 19);
      //      this.lblPriSwCardNo.TabIndex = 339;
      //      this.lblPriSwCardNo.Text = "lblPriCardNo";
      //      this.lblPriSwCardNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      //      // 
      //      // lblPriSwOper
      //      // 
      //      this.lblPriSwOper.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriSwOper.Location = new System.Drawing.Point(393, 331);
      //      this.lblPriSwOper.Name = "lblPriSwOper";
      //      this.lblPriSwOper.Size = new System.Drawing.Size(205, 21);
      //      this.lblPriSwOper.TabIndex = 337;
      //      this.lblPriSwOper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreSwOper
      //      // 
      //      this.lblPreSwOper.Location = new System.Drawing.Point(338, 331);
      //      this.lblPreSwOper.Name = "lblPreSwOper";
      //      this.lblPreSwOper.Size = new System.Drawing.Size(59, 21);
      //      this.lblPreSwOper.TabIndex = 336;
      //      this.lblPreSwOper.Text = "收费员:";
      //      this.lblPreSwOper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriPay
      //      // 
      //      this.lblPriPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriPay.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriPay.Location = new System.Drawing.Point(416, 310);
      //      this.lblPriPay.Name = "lblPriPay";
      //      this.lblPriPay.Size = new System.Drawing.Size(204, 21);
      //      this.lblPriPay.TabIndex = 327;
      //      this.lblPriPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreOwnPay
      //      // 
      //      this.lblPreOwnPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreOwnPay.Location = new System.Drawing.Point(323, 310);
      //      this.lblPreOwnPay.Name = "lblPreOwnPay";
      //      this.lblPreOwnPay.Size = new System.Drawing.Size(93, 21);
      //      this.lblPreOwnPay.TabIndex = 326;
      //      this.lblPreOwnPay.Text = "个人缴费金额:";
      //      this.lblPreOwnPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriPub
      //      // 
      //      this.lblPriPub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriPub.Font = new System.Drawing.Font("宋体", 10.5F);
      //      this.lblPriPub.Location = new System.Drawing.Point(126, 310);
      //      this.lblPriPub.Name = "lblPriPub";
      //      this.lblPriPub.Size = new System.Drawing.Size(197, 21);
      //      this.lblPriPub.TabIndex = 325;
      //      this.lblPriPub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPrePub
      //      // 
      //      this.lblPrePub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPrePub.Location = new System.Drawing.Point(3, 310);
      //      this.lblPrePub.Name = "lblPrePub";
      //      this.lblPrePub.Size = new System.Drawing.Size(123, 21);
      //      this.lblPrePub.TabIndex = 324;
      //      this.lblPrePub.Text = "医保/公医记账金额:";
      //      this.lblPrePub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreTenW
      //      // 
      //      this.lblPreTenW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreTenW.Location = new System.Drawing.Point(129, 289);
      //      this.lblPreTenW.Name = "lblPreTenW";
      //      this.lblPreTenW.Size = new System.Drawing.Size(15, 21);
      //      this.lblPreTenW.TabIndex = 323;
      //      this.lblPreTenW.Text = "拾";
      //      this.lblPreTenW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreUpperCost
      //      // 
      //      this.lblPreUpperCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreUpperCost.Location = new System.Drawing.Point(3, 289);
      //      this.lblPreUpperCost.Name = "lblPreUpperCost";
      //      this.lblPreUpperCost.Size = new System.Drawing.Size(110, 21);
      //      this.lblPreUpperCost.TabIndex = 322;
      //      this.lblPreUpperCost.Text = "合计人民币(大写)";
      //      this.lblPreUpperCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriPayKind
      //      // 
      //      this.lblPriPayKind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriPayKind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriPayKind.Location = new System.Drawing.Point(275, 77);
      //      this.lblPriPayKind.Name = "lblPriPayKind";
      //      this.lblPriPayKind.Size = new System.Drawing.Size(345, 23);
      //      this.lblPriPayKind.TabIndex = 321;
      //      this.lblPriPayKind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      //      // 
      //      // lblPrePaykind
      //      // 
      //      this.lblPrePaykind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPrePaykind.Location = new System.Drawing.Point(202, 77);
      //      this.lblPrePaykind.Name = "lblPrePaykind";
      //      this.lblPrePaykind.Size = new System.Drawing.Size(74, 23);
      //      this.lblPrePaykind.TabIndex = 320;
      //      this.lblPrePaykind.Text = "结算方式:";
      //      this.lblPrePaykind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost24
      //      // 
      //      this.lblPriCost24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost24.Location = new System.Drawing.Point(89, 247);
      //      this.lblPriCost24.Name = "lblPriCost24";
      //      this.lblPriCost24.Size = new System.Drawing.Size(113, 21);
      //      this.lblPriCost24.TabIndex = 316;
      //      this.lblPriCost24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      this.lblPriCost24.Visible = false;
      //      // 
      //      // lblPriCost23
      //      // 
      //      this.lblPriCost23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost23.Location = new System.Drawing.Point(504, 247);
      //      this.lblPriCost23.Name = "lblPriCost23";
      //      this.lblPriCost23.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost23.TabIndex = 315;
      //      this.lblPriCost23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost22
      //      // 
      //      this.lblPriCost22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost22.Location = new System.Drawing.Point(504, 226);
      //      this.lblPriCost22.Name = "lblPriCost22";
      //      this.lblPriCost22.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost22.TabIndex = 314;
      //      this.lblPriCost22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost21
      //      // 
      //      this.lblPriCost21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost21.Location = new System.Drawing.Point(504, 205);
      //      this.lblPriCost21.Name = "lblPriCost21";
      //      this.lblPriCost21.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost21.TabIndex = 313;
      //      this.lblPriCost21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost20
      //      // 
      //      this.lblPriCost20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost20.Location = new System.Drawing.Point(504, 184);
      //      this.lblPriCost20.Name = "lblPriCost20";
      //      this.lblPriCost20.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost20.TabIndex = 312;
      //      this.lblPriCost20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost19
      //      // 
      //      this.lblPriCost19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost19.Location = new System.Drawing.Point(504, 163);
      //      this.lblPriCost19.Name = "lblPriCost19";
      //      this.lblPriCost19.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost19.TabIndex = 311;
      //      this.lblPriCost19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost18
      //      // 
      //      this.lblPriCost18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost18.Location = new System.Drawing.Point(504, 142);
      //      this.lblPriCost18.Name = "lblPriCost18";
      //      this.lblPriCost18.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost18.TabIndex = 310;
      //      this.lblPriCost18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost17
      //      // 
      //      this.lblPriCost17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost17.Location = new System.Drawing.Point(504, 121);
      //      this.lblPriCost17.Name = "lblPriCost17";
      //      this.lblPriCost17.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost17.TabIndex = 309;
      //      this.lblPriCost17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreColumn7
      //      // 
      //      this.lblPreColumn7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreColumn7.Location = new System.Drawing.Point(504, 100);
      //      this.lblPreColumn7.Name = "lblPreColumn7";
      //      this.lblPreColumn7.Size = new System.Drawing.Size(116, 21);
      //      this.lblPreColumn7.TabIndex = 308;
      //      this.lblPreColumn7.Text = "金     额";
      //      this.lblPreColumn7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName24
      //      // 
      //      this.lblPreFeeName24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName24.Location = new System.Drawing.Point(3, 247);
      //      this.lblPreFeeName24.Name = "lblPreFeeName24";
      //      this.lblPreFeeName24.Size = new System.Drawing.Size(86, 21);
      //      this.lblPreFeeName24.TabIndex = 306;
      //      this.lblPreFeeName24.Text = "自费项";
      //      this.lblPreFeeName24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName23
      //      // 
      //      this.lblPreFeeName23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName23.Location = new System.Drawing.Point(414, 247);
      //      this.lblPreFeeName23.Name = "lblPreFeeName23";
      //      this.lblPreFeeName23.Size = new System.Drawing.Size(90, 21);
      //      this.lblPreFeeName23.TabIndex = 305;
      //      this.lblPreFeeName23.Text = "特需服务费";
      //      this.lblPreFeeName23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName22
      //      // 
      //      this.lblPreFeeName22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName22.Location = new System.Drawing.Point(414, 226);
      //      this.lblPreFeeName22.Name = "lblPreFeeName22";
      //      this.lblPreFeeName22.Size = new System.Drawing.Size(90, 21);
      //      this.lblPreFeeName22.TabIndex = 304;
      //      this.lblPreFeeName22.Text = "其    他";
      //      this.lblPreFeeName22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName21
      //      // 
      //      this.lblPreFeeName21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName21.Location = new System.Drawing.Point(414, 205);
      //      this.lblPreFeeName21.Name = "lblPreFeeName21";
      //      this.lblPreFeeName21.Size = new System.Drawing.Size(90, 21);
      //      this.lblPreFeeName21.TabIndex = 303;
      //      this.lblPreFeeName21.Text = "手 术 费";
      //      this.lblPreFeeName21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName20
      //      // 
      //      this.lblPreFeeName20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName20.Location = new System.Drawing.Point(437, 184);
      //      this.lblPreFeeName20.Name = "lblPreFeeName20";
      //      this.lblPreFeeName20.Size = new System.Drawing.Size(67, 21);
      //      this.lblPreFeeName20.TabIndex = 302;
      //      this.lblPreFeeName20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName19
      //      // 
      //      this.lblPreFeeName19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName19.Location = new System.Drawing.Point(437, 163);
      //      this.lblPreFeeName19.Name = "lblPreFeeName19";
      //      this.lblPreFeeName19.Size = new System.Drawing.Size(67, 21);
      //      this.lblPreFeeName19.TabIndex = 301;
      //      this.lblPreFeeName19.Text = "输氧费";
      //      this.lblPreFeeName19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName18
      //      // 
      //      this.lblPreFeeName18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName18.Location = new System.Drawing.Point(437, 142);
      //      this.lblPreFeeName18.Name = "lblPreFeeName18";
      //      this.lblPreFeeName18.Size = new System.Drawing.Size(67, 21);
      //      this.lblPreFeeName18.TabIndex = 300;
      //      this.lblPreFeeName18.Text = "输血费";
      //      this.lblPreFeeName18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName17
      //      // 
      //      this.lblPreFeeName17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName17.Location = new System.Drawing.Point(414, 121);
      //      this.lblPreFeeName17.Name = "lblPreFeeName17";
      //      this.lblPreFeeName17.Size = new System.Drawing.Size(90, 21);
      //      this.lblPreFeeName17.TabIndex = 299;
      //      this.lblPreFeeName17.Text = "治 疗 费";
      //      this.lblPreFeeName17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreColumn5
      //      // 
      //      this.lblPreColumn5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreColumn5.Location = new System.Drawing.Point(414, 100);
      //      this.lblPreColumn5.Name = "lblPreColumn5";
      //      this.lblPreColumn5.Size = new System.Drawing.Size(90, 21);
      //      this.lblPreColumn5.TabIndex = 298;
      //      this.lblPreColumn5.Text = "医疗项目";
      //      this.lblPreColumn5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost16
      //      // 
      //      this.lblPriCost16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost16.Location = new System.Drawing.Point(298, 268);
      //      this.lblPriCost16.Name = "lblPriCost16";
      //      this.lblPriCost16.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost16.TabIndex = 296;
      //      this.lblPriCost16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost15
      //      // 
      //      this.lblPriCost15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost15.Location = new System.Drawing.Point(298, 247);
      //      this.lblPriCost15.Name = "lblPriCost15";
      //      this.lblPriCost15.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost15.TabIndex = 295;
      //      this.lblPriCost15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost14
      //      // 
      //      this.lblPriCost14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost14.Location = new System.Drawing.Point(298, 226);
      //      this.lblPriCost14.Name = "lblPriCost14";
      //      this.lblPriCost14.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost14.TabIndex = 294;
      //      this.lblPriCost14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost13
      //      // 
      //      this.lblPriCost13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost13.Location = new System.Drawing.Point(298, 205);
      //      this.lblPriCost13.Name = "lblPriCost13";
      //      this.lblPriCost13.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost13.TabIndex = 293;
      //      this.lblPriCost13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost12
      //      // 
      //      this.lblPriCost12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost12.Location = new System.Drawing.Point(298, 184);
      //      this.lblPriCost12.Name = "lblPriCost12";
      //      this.lblPriCost12.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost12.TabIndex = 292;
      //      this.lblPriCost12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost11
      //      // 
      //      this.lblPriCost11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost11.Location = new System.Drawing.Point(298, 163);
      //      this.lblPriCost11.Name = "lblPriCost11";
      //      this.lblPriCost11.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost11.TabIndex = 291;
      //      this.lblPriCost11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost10
      //      // 
      //      this.lblPriCost10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost10.Location = new System.Drawing.Point(298, 142);
      //      this.lblPriCost10.Name = "lblPriCost10";
      //      this.lblPriCost10.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost10.TabIndex = 290;
      //      this.lblPriCost10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost9
      //      // 
      //      this.lblPriCost9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost9.Location = new System.Drawing.Point(298, 121);
      //      this.lblPriCost9.Name = "lblPriCost9";
      //      this.lblPriCost9.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost9.TabIndex = 289;
      //      this.lblPriCost9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreColumn4
      //      // 
      //      this.lblPreColumn4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreColumn4.Location = new System.Drawing.Point(298, 100);
      //      this.lblPreColumn4.Name = "lblPreColumn4";
      //      this.lblPreColumn4.Size = new System.Drawing.Size(116, 21);
      //      this.lblPreColumn4.TabIndex = 288;
      //      this.lblPreColumn4.Text = "金     额";
      //      this.lblPreColumn4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName16
      //      // 
      //      this.lblPreFeeName16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName16.Location = new System.Drawing.Point(202, 268);
      //      this.lblPreFeeName16.Name = "lblPreFeeName16";
      //      this.lblPreFeeName16.Size = new System.Drawing.Size(96, 21);
      //      this.lblPreFeeName16.TabIndex = 286;
      //      this.lblPreFeeName16.Text = "检 验 费";
      //      this.lblPreFeeName16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName15
      //      // 
      //      this.lblPreFeeName15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName15.Location = new System.Drawing.Point(233, 247);
      //      this.lblPreFeeName15.Name = "lblPreFeeName15";
      //      this.lblPreFeeName15.Size = new System.Drawing.Size(65, 21);
      //      this.lblPreFeeName15.TabIndex = 285;
      //      this.lblPreFeeName15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName14
      //      // 
      //      this.lblPreFeeName14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName14.Location = new System.Drawing.Point(233, 226);
      //      this.lblPreFeeName14.Name = "lblPreFeeName14";
      //      this.lblPreFeeName14.Size = new System.Drawing.Size(65, 21);
      //      this.lblPreFeeName14.TabIndex = 284;
      //      this.lblPreFeeName14.Text = "PET";
      //      this.lblPreFeeName14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName13
      //      // 
      //      this.lblPreFeeName13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName13.Location = new System.Drawing.Point(233, 205);
      //      this.lblPreFeeName13.Name = "lblPreFeeName13";
      //      this.lblPreFeeName13.Size = new System.Drawing.Size(65, 21);
      //      this.lblPreFeeName13.TabIndex = 283;
      //      this.lblPreFeeName13.Text = "MRI";
      //      this.lblPreFeeName13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName12
      //      // 
      //      this.lblPreFeeName12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName12.Location = new System.Drawing.Point(233, 184);
      //      this.lblPreFeeName12.Name = "lblPreFeeName12";
      //      this.lblPreFeeName12.Size = new System.Drawing.Size(65, 21);
      //      this.lblPreFeeName12.TabIndex = 282;
      //      this.lblPreFeeName12.Text = "CT";
      //      this.lblPreFeeName12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName11
      //      // 
      //      this.lblPreFeeName11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName11.Location = new System.Drawing.Point(202, 163);
      //      this.lblPreFeeName11.Name = "lblPreFeeName11";
      //      this.lblPreFeeName11.Size = new System.Drawing.Size(96, 21);
      //      this.lblPreFeeName11.TabIndex = 281;
      //      this.lblPreFeeName11.Text = "检 查 费";
      //      this.lblPreFeeName11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName10
      //      // 
      //      this.lblPreFeeName10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName10.Font = new System.Drawing.Font("宋体", 9F);
      //      this.lblPreFeeName10.Location = new System.Drawing.Point(202, 142);
      //      this.lblPreFeeName10.Name = "lblPreFeeName10";
      //      this.lblPreFeeName10.Size = new System.Drawing.Size(96, 21);
      //      this.lblPreFeeName10.TabIndex = 280;
      //      this.lblPreFeeName10.Text = "急诊留观床位费";
      //      this.lblPreFeeName10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName9
      //      // 
      //      this.lblPreFeeName9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName9.Location = new System.Drawing.Point(202, 121);
      //      this.lblPreFeeName9.Name = "lblPreFeeName9";
      //      this.lblPreFeeName9.Size = new System.Drawing.Size(96, 21);
      //      this.lblPreFeeName9.TabIndex = 279;
      //      this.lblPreFeeName9.Text = "诊 察 费";
      //      this.lblPreFeeName9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreColumn3
      //      // 
      //      this.lblPreColumn3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreColumn3.Location = new System.Drawing.Point(202, 100);
      //      this.lblPreColumn3.Name = "lblPreColumn3";
      //      this.lblPreColumn3.Size = new System.Drawing.Size(96, 21);
      //      this.lblPreColumn3.TabIndex = 278;
      //      this.lblPreColumn3.Text = "医疗项目";
      //      this.lblPreColumn3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreName
      //      // 
      //      this.lblPreName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreName.Location = new System.Drawing.Point(3, 77);
      //      this.lblPreName.Name = "lblPreName";
      //      this.lblPreName.Size = new System.Drawing.Size(54, 23);
      //      this.lblPreName.TabIndex = 257;
      //      this.lblPreName.Text = "姓名:";
      //      this.lblPreName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriName
      //      // 
      //      this.lblPriName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriName.Location = new System.Drawing.Point(56, 77);
      //      this.lblPriName.Name = "lblPriName";
      //      this.lblPriName.Size = new System.Drawing.Size(146, 23);
      //      this.lblPriName.TabIndex = 256;
      //      this.lblPriName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      //      // 
      //      // lblPriCost8
      //      // 
      //      this.lblPriCost8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost8.Location = new System.Drawing.Point(89, 268);
      //      this.lblPriCost8.Name = "lblPriCost8";
      //      this.lblPriCost8.Size = new System.Drawing.Size(113, 21);
      //      this.lblPriCost8.TabIndex = 254;
      //      this.lblPriCost8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      this.lblPriCost8.Visible = false;
      //      // 
      //      // lblPriCost7
      //      // 
      //      this.lblPriCost7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost7.Location = new System.Drawing.Point(504, 268);
      //      this.lblPriCost7.Name = "lblPriCost7";
      //      this.lblPriCost7.Size = new System.Drawing.Size(116, 21);
      //      this.lblPriCost7.TabIndex = 253;
      //      this.lblPriCost7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost6
      //      // 
      //      this.lblPriCost6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost6.Location = new System.Drawing.Point(89, 226);
      //      this.lblPriCost6.Name = "lblPriCost6";
      //      this.lblPriCost6.Size = new System.Drawing.Size(113, 21);
      //      this.lblPriCost6.TabIndex = 252;
      //      this.lblPriCost6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost5
      //      // 
      //      this.lblPriCost5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost5.Location = new System.Drawing.Point(89, 205);
      //      this.lblPriCost5.Name = "lblPriCost5";
      //      this.lblPriCost5.Size = new System.Drawing.Size(113, 21);
      //      this.lblPriCost5.TabIndex = 251;
      //      this.lblPriCost5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost4
      //      // 
      //      this.lblPriCost4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost4.Location = new System.Drawing.Point(89, 184);
      //      this.lblPriCost4.Name = "lblPriCost4";
      //      this.lblPriCost4.Size = new System.Drawing.Size(113, 21);
      //      this.lblPriCost4.TabIndex = 250;
      //      this.lblPriCost4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost3
      //      // 
      //      this.lblPriCost3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost3.Location = new System.Drawing.Point(89, 163);
      //      this.lblPriCost3.Name = "lblPriCost3";
      //      this.lblPriCost3.Size = new System.Drawing.Size(113, 21);
      //      this.lblPriCost3.TabIndex = 249;
      //      this.lblPriCost3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost2
      //      // 
      //      this.lblPriCost2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost2.Location = new System.Drawing.Point(89, 142);
      //      this.lblPriCost2.Name = "lblPriCost2";
      //      this.lblPriCost2.Size = new System.Drawing.Size(113, 21);
      //      this.lblPriCost2.TabIndex = 248;
      //      this.lblPriCost2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriCost1
      //      // 
      //      this.lblPriCost1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPriCost1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriCost1.Location = new System.Drawing.Point(89, 121);
      //      this.lblPriCost1.Name = "lblPriCost1";
      //      this.lblPriCost1.Size = new System.Drawing.Size(113, 21);
      //      this.lblPriCost1.TabIndex = 247;
      //      this.lblPriCost1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreColumn2
      //      // 
      //      this.lblPreColumn2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreColumn2.Location = new System.Drawing.Point(89, 100);
      //      this.lblPreColumn2.Name = "lblPreColumn2";
      //      this.lblPreColumn2.Size = new System.Drawing.Size(113, 21);
      //      this.lblPreColumn2.TabIndex = 246;
      //      this.lblPreColumn2.Text = "金     额";
      //      this.lblPreColumn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName8
      //      // 
      //      this.lblPreFeeName8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName8.Location = new System.Drawing.Point(3, 268);
      //      this.lblPreFeeName8.Name = "lblPreFeeName8";
      //      this.lblPreFeeName8.Size = new System.Drawing.Size(86, 21);
      //      this.lblPreFeeName8.TabIndex = 244;
      //      this.lblPreFeeName8.Text = "诊金";
      //      this.lblPreFeeName8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName7
      //      // 
      //      this.lblPreFeeName7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName7.Location = new System.Drawing.Point(414, 268);
      //      this.lblPreFeeName7.Name = "lblPreFeeName7";
      //      this.lblPreFeeName7.Size = new System.Drawing.Size(90, 21);
      //      this.lblPreFeeName7.TabIndex = 243;
      //      this.lblPreFeeName7.Text = "四舍五入金额";
      //      this.lblPreFeeName7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName6
      //      // 
      //      this.lblPreFeeName6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName6.Location = new System.Drawing.Point(3, 226);
      //      this.lblPreFeeName6.Name = "lblPreFeeName6";
      //      this.lblPreFeeName6.Size = new System.Drawing.Size(86, 21);
      //      this.lblPreFeeName6.TabIndex = 242;
      //      this.lblPreFeeName6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName5
      //      // 
      //      this.lblPreFeeName5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName5.Location = new System.Drawing.Point(3, 205);
      //      this.lblPreFeeName5.Name = "lblPreFeeName5";
      //      this.lblPreFeeName5.Size = new System.Drawing.Size(86, 21);
      //      this.lblPreFeeName5.TabIndex = 241;
      //      this.lblPreFeeName5.Text = "超标药";
      //      this.lblPreFeeName5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      this.lblPreFeeName5.Visible = false;
      //      // 
      //      // lblPreFeeName4
      //      // 
      //      this.lblPreFeeName4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName4.Location = new System.Drawing.Point(3, 184);
      //      this.lblPreFeeName4.Name = "lblPreFeeName4";
      //      this.lblPreFeeName4.Size = new System.Drawing.Size(86, 21);
      //      this.lblPreFeeName4.TabIndex = 240;
      //      this.lblPreFeeName4.Text = "自费药";
      //      this.lblPreFeeName4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      this.lblPreFeeName4.Visible = false;
      //      // 
      //      // lblPreFeeName3
      //      // 
      //      this.lblPreFeeName3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName3.Location = new System.Drawing.Point(3, 163);
      //      this.lblPreFeeName3.Name = "lblPreFeeName3";
      //      this.lblPreFeeName3.Size = new System.Drawing.Size(86, 21);
      //      this.lblPreFeeName3.TabIndex = 239;
      //      this.lblPreFeeName3.Text = "中 草 药";
      //      this.lblPreFeeName3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName2
      //      // 
      //      this.lblPreFeeName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName2.Location = new System.Drawing.Point(3, 142);
      //      this.lblPreFeeName2.Name = "lblPreFeeName2";
      //      this.lblPreFeeName2.Size = new System.Drawing.Size(86, 21);
      //      this.lblPreFeeName2.TabIndex = 238;
      //      this.lblPreFeeName2.Text = "中 成 药";
      //      this.lblPreFeeName2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreFeeName1
      //      // 
      //      this.lblPreFeeName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreFeeName1.Location = new System.Drawing.Point(3, 121);
      //      this.lblPreFeeName1.Name = "lblPreFeeName1";
      //      this.lblPreFeeName1.Size = new System.Drawing.Size(86, 21);
      //      this.lblPreFeeName1.TabIndex = 237;
      //      this.lblPreFeeName1.Text = "西    药";
      //      this.lblPreFeeName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreColumn1
      //      // 
      //      this.lblPreColumn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //      this.lblPreColumn1.Location = new System.Drawing.Point(3, 100);
      //      this.lblPreColumn1.Name = "lblPreColumn1";
      //      this.lblPreColumn1.Size = new System.Drawing.Size(86, 21);
      //      this.lblPreColumn1.TabIndex = 236;
      //      this.lblPreColumn1.Text = "药品项目";
      //      this.lblPreColumn1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreSwDayDisPlay
      //      // 
      //      this.lblPreSwDayDisPlay.Location = new System.Drawing.Point(368, 58);
      //      this.lblPreSwDayDisPlay.Name = "lblPreSwDayDisPlay";
      //      this.lblPreSwDayDisPlay.Size = new System.Drawing.Size(21, 19);
      //      this.lblPreSwDayDisPlay.TabIndex = 235;
      //      this.lblPreSwDayDisPlay.Text = "日";
      //      this.lblPreSwDayDisPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreSwMonthDisPlay
      //      // 
      //      this.lblPreSwMonthDisPlay.Location = new System.Drawing.Point(309, 58);
      //      this.lblPreSwMonthDisPlay.Name = "lblPreSwMonthDisPlay";
      //      this.lblPreSwMonthDisPlay.Size = new System.Drawing.Size(19, 19);
      //      this.lblPreSwMonthDisPlay.TabIndex = 234;
      //      this.lblPreSwMonthDisPlay.Text = "月";
      //      this.lblPreSwMonthDisPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreSwYearDisPlay
      //      // 
      //      this.lblPreSwYearDisPlay.Location = new System.Drawing.Point(243, 58);
      //      this.lblPreSwYearDisPlay.Name = "lblPreSwYearDisPlay";
      //      this.lblPreSwYearDisPlay.Size = new System.Drawing.Size(16, 19);
      //      this.lblPreSwYearDisPlay.TabIndex = 233;
      //      this.lblPreSwYearDisPlay.Text = "年";
      //      this.lblPreSwYearDisPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreSwXL
      //      // 
      //      this.lblPreSwXL.Location = new System.Drawing.Point(3, 58);
      //      this.lblPreSwXL.Name = "lblPreSwXL";
      //      this.lblPreSwXL.Size = new System.Drawing.Size(54, 19);
      //      this.lblPreSwXL.TabIndex = 231;
      //      this.lblPreSwXL.Text = "系列号:";
      //      // 
      //      // lblPreSwTitle
      //      // 
      //      this.lblPreSwTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPreSwTitle.Location = new System.Drawing.Point(192, 4);
      //      this.lblPreSwTitle.Name = "lblPreSwTitle";
      //      this.lblPreSwTitle.Size = new System.Drawing.Size(343, 20);
      //      this.lblPreSwTitle.TabIndex = 230;
      //      this.lblPreSwTitle.Text = "广东省医疗机构门诊收费收据(票据预览)";
      //      this.lblPreSwTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      //      // 
      //      // lblPreSwInclude6
      //      // 
      //      this.lblPreSwInclude6.Location = new System.Drawing.Point(418, 182);
      //      this.lblPreSwInclude6.Name = "lblPreSwInclude6";
      //      this.lblPreSwInclude6.Size = new System.Drawing.Size(17, 21);
      //      this.lblPreSwInclude6.TabIndex = 368;
      //      this.lblPreSwInclude6.Text = "中";
      //      this.lblPreSwInclude6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreSwInclude5
      //      // 
      //      this.lblPreSwInclude5.Location = new System.Drawing.Point(418, 147);
      //      this.lblPreSwInclude5.Name = "lblPreSwInclude5";
      //      this.lblPreSwInclude5.Size = new System.Drawing.Size(17, 21);
      //      this.lblPreSwInclude5.TabIndex = 367;
      //      this.lblPreSwInclude5.Text = "其";
      //      this.lblPreSwInclude5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreSwHosPital
      //      // 
      //      this.lblPreSwHosPital.Location = new System.Drawing.Point(1, 331);
      //      this.lblPreSwHosPital.Name = "lblPreSwHosPital";
      //      this.lblPreSwHosPital.Size = new System.Drawing.Size(74, 21);
      //      this.lblPreSwHosPital.TabIndex = 369;
      //      this.lblPreSwHosPital.Text = "收费单位 (盖章) :";
      //      this.lblPreSwHosPital.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriSwHosPital
      //      // 
      //      this.lblPriSwHosPital.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriSwHosPital.Location = new System.Drawing.Point(76, 331);
      //      this.lblPriSwHosPital.Name = "lblPriSwHosPital";
      //      this.lblPriSwHosPital.Size = new System.Drawing.Size(121, 21);
      //      this.lblPriSwHosPital.TabIndex = 370;
      //      this.lblPriSwHosPital.Text = "北滘医院";
      //      this.lblPriSwHosPital.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPreSwCheck
      //      // 
      //      this.lblPreSwCheck.Location = new System.Drawing.Point(202, 331);
      //      this.lblPreSwCheck.Name = "lblPreSwCheck";
      //      this.lblPreSwCheck.Size = new System.Drawing.Size(50, 21);
      //      this.lblPreSwCheck.TabIndex = 371;
      //      this.lblPreSwCheck.Text = "审核员:";
      //      this.lblPreSwCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriSwCheck
      //      // 
      //      this.lblPriSwCheck.Location = new System.Drawing.Point(252, 331);
      //      this.lblPriSwCheck.Name = "lblPriSwCheck";
      //      this.lblPriSwCheck.Size = new System.Drawing.Size(86, 21);
      //      this.lblPriSwCheck.TabIndex = 372;
      //      this.lblPriSwCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //      // 
      //      // lblPriSwDrugWindow
      //      // 
      //      this.lblPriSwDrugWindow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblPriSwDrugWindow.Location = new System.Drawing.Point(4, 34);
      //      this.lblPriSwDrugWindow.Name = "lblPriSwDrugWindow";
      //      this.lblPriSwDrugWindow.Size = new System.Drawing.Size(607, 17);
      //      this.lblPriSwDrugWindow.TabIndex = 373;
      //      this.lblPriSwDrugWindow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      //      this.lblPriSwDrugWindow.Visible = false;
      //      // 
      //      // lblDrugWindow
      //      // 
      //      this.lblDrugWindow.AutoSize = true;
      //      this.lblDrugWindow.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblDrugWindow.Location = new System.Drawing.Point(5, 352);
      //      this.lblDrugWindow.Name = "lblDrugWindow";
      //      this.lblDrugWindow.Size = new System.Drawing.Size(70, 12);
      //      this.lblDrugWindow.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
      //      this.lblDrugWindow.TabIndex = 374;
      //      this.lblDrugWindow.Text = "领药窗口：";
      //      // 
      //      // lblRecipeNo
      //      // 
      //      this.lblRecipeNo.AutoSize = true;
      //      this.lblRecipeNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblRecipeNo.Location = new System.Drawing.Point(413, 55);
      //      this.lblRecipeNo.Name = "lblRecipeNo";
      //      this.lblRecipeNo.Size = new System.Drawing.Size(0, 14);
      //      this.lblRecipeNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
      //      this.lblRecipeNo.TabIndex = 375;
      //      this.lblRecipeNo.Visible = false;
      //      // 
      //      // lblReprint
      //      // 
      //      this.lblReprint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.lblReprint.Location = new System.Drawing.Point(271, 354);
      //      this.lblReprint.Name = "lblReprint";
      //      this.lblReprint.Size = new System.Drawing.Size(186, 16);
      //      this.lblReprint.TabIndex = 337;
      //      this.lblReprint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      //      // 
      //      // neuLabel24
      //      // 
      //      this.neuLabel24.AutoSize = true;
      //      this.neuLabel24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.neuLabel24.Location = new System.Drawing.Point(4, 34);
      //      this.neuLabel24.Name = "neuLabel24";
      //      this.neuLabel24.Size = new System.Drawing.Size(119, 14);
      //      this.neuLabel24.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
      //      this.neuLabel24.TabIndex = 377;
      //      this.neuLabel24.Tag = "Print";
      //      this.neuLabel24.Text = "医保结算后金额：";
      //      // 
      //      // neuLabel22
      //      // 
      //      this.neuLabel22.AutoSize = true;
      //      this.neuLabel22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.neuLabel22.Location = new System.Drawing.Point(4, 17);
      //      this.neuLabel22.Name = "neuLabel22";
      //      this.neuLabel22.Size = new System.Drawing.Size(119, 14);
      //      this.neuLabel22.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
      //      this.neuLabel22.TabIndex = 376;
      //      this.neuLabel22.Tag = "Print";
      //      this.neuLabel22.Text = "医保结算前金额：";
      //      // 
      //      // label1
      //      // 
      //      this.label1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.label1.Location = new System.Drawing.Point(120, 17);
      //      this.label1.Name = "label1";
      //      this.label1.Size = new System.Drawing.Size(119, 14);
      //      this.label1.TabIndex = 378;
      //      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      //      // 
      //      // label2
      //      // 
      //      this.label2.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      //      this.label2.Location = new System.Drawing.Point(120, 34);
      //      this.label2.Name = "label2";
      //      this.label2.Size = new System.Drawing.Size(119, 14);
      //      this.label2.TabIndex = 379;
      //      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      //      // 
      //      // ucInvoiceGY
      //      // 
      //      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      //      this.Controls.Add(this.label2);
      //      this.Controls.Add(this.label1);
      //      this.Controls.Add(this.neuLabel24);
      //      this.Controls.Add(this.neuLabel22);
      //      this.Controls.Add(this.lblRecipeNo);
      //      this.Controls.Add(this.lblDrugWindow);
      //      this.Controls.Add(this.lblPriSwDrugWindow);
      //      this.Controls.Add(this.lblPriSwCheck);
      //      this.Controls.Add(this.lblPreSwCheck);
      //      this.Controls.Add(this.lblPreSwHosPital);
      //      this.Controls.Add(this.lblPreSwInclude6);
      //      this.Controls.Add(this.lblPreSwInclude5);
      //      this.Controls.Add(this.lblPreSwInclude4);
      //      this.Controls.Add(this.lblPriSwBalanceType);
      //      this.Controls.Add(this.lblPriFen);
      //      this.Controls.Add(this.lblPriJiao);
      //      this.Controls.Add(this.lblPriYing);
      //      this.Controls.Add(this.lblPriShi);
      //      this.Controls.Add(this.lblPriBai);
      //      this.Controls.Add(this.lblPriQian);
      //      this.Controls.Add(this.lblPriWan);
      //      this.Controls.Add(this.lblPriTenW);
      //      this.Controls.Add(this.lblPreSign);
      //      this.Controls.Add(this.lblPriLower);
      //      this.Controls.Add(this.lblPreFen);
      //      this.Controls.Add(this.lblPreJiao);
      //      this.Controls.Add(this.lblPreYuan);
      //      this.Controls.Add(this.lblPreShi);
      //      this.Controls.Add(this.lblPreBai);
      //      this.Controls.Add(this.lblPreQiang);
      //      this.Controls.Add(this.lblPreWWW);
      //      this.Controls.Add(this.lblPreSwInclude2);
      //      this.Controls.Add(this.lblPriSwDay);
      //      this.Controls.Add(this.lblPriSwMonth);
      //      this.Controls.Add(this.lblPriSwYear);
      //      this.Controls.Add(this.lblPriSwCardNo);
      //      this.Controls.Add(this.lblReprint);
      //      this.Controls.Add(this.lblPriSwOper);
      //      this.Controls.Add(this.lblPreSwOper);
      //      this.Controls.Add(this.lblPriPay);
      //      this.Controls.Add(this.lblPreOwnPay);
      //      this.Controls.Add(this.lblPriPub);
      //      this.Controls.Add(this.lblPrePub);
      //      this.Controls.Add(this.lblPreTenW);
      //      this.Controls.Add(this.lblPreUpperCost);
      //      this.Controls.Add(this.lblPriPayKind);
      //      this.Controls.Add(this.lblPrePaykind);
      //      this.Controls.Add(this.lblPriCost24);
      //      this.Controls.Add(this.lblPriCost23);
      //      this.Controls.Add(this.lblPriCost22);
      //      this.Controls.Add(this.lblPriCost21);
      //      this.Controls.Add(this.lblPriCost20);
      //      this.Controls.Add(this.lblPriCost19);
      //      this.Controls.Add(this.lblPriCost18);
      //      this.Controls.Add(this.lblPriCost17);
      //      this.Controls.Add(this.lblPreColumn7);
      //      this.Controls.Add(this.lblPreFeeName24);
      //      this.Controls.Add(this.lblPreFeeName23);
      //      this.Controls.Add(this.lblPreFeeName22);
      //      this.Controls.Add(this.lblPreFeeName21);
      //      this.Controls.Add(this.lblPreFeeName20);
      //      this.Controls.Add(this.lblPreFeeName19);
      //      this.Controls.Add(this.lblPreFeeName18);
      //      this.Controls.Add(this.lblPreFeeName17);
      //      this.Controls.Add(this.lblPreColumn5);
      //      this.Controls.Add(this.lblPriCost16);
      //      this.Controls.Add(this.lblPriCost15);
      //      this.Controls.Add(this.lblPriCost14);
      //      this.Controls.Add(this.lblPriCost13);
      //      this.Controls.Add(this.lblPriCost12);
      //      this.Controls.Add(this.lblPriCost11);
      //      this.Controls.Add(this.lblPriCost10);
      //      this.Controls.Add(this.lblPriCost9);
      //      this.Controls.Add(this.lblPreColumn4);
      //      this.Controls.Add(this.lblPreFeeName16);
      //      this.Controls.Add(this.lblPreFeeName15);
      //      this.Controls.Add(this.lblPreFeeName14);
      //      this.Controls.Add(this.lblPreFeeName13);
      //      this.Controls.Add(this.lblPreFeeName12);
      //      this.Controls.Add(this.lblPreFeeName11);
      //      this.Controls.Add(this.lblPreFeeName10);
      //      this.Controls.Add(this.lblPreFeeName9);
      //      this.Controls.Add(this.lblPreColumn3);
      //      this.Controls.Add(this.lblPreName);
      //      this.Controls.Add(this.lblPriName);
      //      this.Controls.Add(this.lblPriCost8);
      //      this.Controls.Add(this.lblPriCost7);
      //      this.Controls.Add(this.lblPriCost6);
      //      this.Controls.Add(this.lblPriCost5);
      //      this.Controls.Add(this.lblPriCost4);
      //      this.Controls.Add(this.lblPriCost3);
      //      this.Controls.Add(this.lblPriCost2);
      //      this.Controls.Add(this.lblPriCost1);
      //      this.Controls.Add(this.lblPreColumn2);
      //      this.Controls.Add(this.lblPreFeeName8);
      //      this.Controls.Add(this.lblPreFeeName7);
      //      this.Controls.Add(this.lblPreFeeName6);
      //      this.Controls.Add(this.lblPreFeeName5);
      //      this.Controls.Add(this.lblPreFeeName4);
      //      this.Controls.Add(this.lblPreFeeName3);
      //      this.Controls.Add(this.lblPreFeeName2);
      //      this.Controls.Add(this.lblPreFeeName1);
      //      this.Controls.Add(this.lblPreColumn1);
      //      this.Controls.Add(this.lblPreSwDayDisPlay);
      //      this.Controls.Add(this.lblPreSwMonthDisPlay);
      //      this.Controls.Add(this.lblPreSwYearDisPlay);
      //      this.Controls.Add(this.lblPreSwXL);
      //      this.Controls.Add(this.lblPreSwTitle);
      //      this.Controls.Add(this.lblPriSwHosPital);
      //      this.Name = "ucInvoiceGY";
      //      this.Size = new System.Drawing.Size(729, 377);
      //      this.ResumeLayout(false);
      //      this.PerformLayout();

      //  }
      //  #endregion
      //  #endregion

      //  #region 变量

      //  private bool _isPreView;//是否预览
      //  private Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction();
     
      //  //ucFeeDetail otherPrint = new ucFeeDetail();
      //  //显示公医特殊
      //  string SpecialDisPlay = "";
      //  //公医特殊比例显示
      //  string TSNewRate = string.Empty;
      //  /// <summary>
      //  /// diffrent NewRate For GYTS
      //  /// </summary>
      //  ArrayList alTSNewRate = new ArrayList();
      //  /// <summary>
      //  /// has Find
      //  /// </summary>
      //  bool hsFind = false;
      //  #endregion

      //  #region 函数

      //  public int SetPrintValue(Neusoft.HISFC.Models.Registration.Register regInfo, Neusoft.HISFC.Models.Fee.Outpatient .Balance invoice, 
      //      ArrayList alInvoiceDetail, ArrayList alFeeItemList, bool isPreview)
      //  {
      //      //如果费用明细为空，则返回
      //      if(alFeeItemList.Count <= 0)
      //      {
      //          return -1;
      //      }
      //      //【方便药房取药】
      //      //中药处方号
      //      //string ZYRecipeNo = string.Empty;
      //      ////西药处方号
      //      //string XYRecipeNo = string.Empty;
      //      ////打印处方号
      //      //string printRecipeNo = string.Empty;

      //      //foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item in alFeeItemList)
      //      //{
      //      //    if (ZYRecipeNo != string.Empty && XYRecipeNo != string.Empty)
      //      //    {
      //      //        printRecipeNo = XYRecipeNo + "," + ZYRecipeNo;
      //      //        break;
      //      //    }
      //      //    //西药处方号选择
      //      //    if (item.Item.MinFee.ID == "001")
      //      //    {
      //      //        if (item.RecipeNO != string.Empty&&XYRecipeNo==string.Empty)
      //      //        {
      //      //            XYRecipeNo = item.RecipeNO;
      //      //            continue;
      //      //        }
      //      //    }
      //      //    else if (item.Item.MinFee.ID == "002" || item.Item.MinFee.ID == "003" )
      //      //    {
      //      //        if (item.RecipeNO != string.Empty && ZYRecipeNo == string.Empty)
      //      //        {
      //      //            ZYRecipeNo = item.RecipeNO;
      //      //            continue;
      //      //        }
      //      //    }
      //      //}

      //      //if (XYRecipeNo != string.Empty&&printRecipeNo==string.Empty)
      //      //{
      //      //    printRecipeNo = XYRecipeNo;
      //      //    if (ZYRecipeNo != string.Empty)
      //      //    {
      //      //        printRecipeNo += "," + ZYRecipeNo;
      //      //    }
      //      //}

      //      decimal ZFPha = 0m, CBPha = 0m, ZFItem = 0m;

      //      foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item in alFeeItemList)
      //      {
      //          if (item.Item.MinFee.ID == "001" || item.Item.MinFee.ID == "002" || item.Item.MinFee.ID == "003")
      //          {
      //              if (item.ItemRateFlag == "1")
      //              {
      //                  ZFPha += Neusoft.FrameWork.Function.NConvert.ToDecimal(item.FT.DrugOwnCost);
      //              }
      //              CBPha += Neusoft.FrameWork.Function.NConvert.ToDecimal(item.FT.ExcessCost);
      //          }
      //          else
      //          {
      //              ZFItem += item.FT.OwnCost;
      //          }
      //          //zhangq [add TS ItemNewRateList]
      //          if (alTSNewRate.Count == 0)
      //          {
      //              Neusoft.FrameWork.Models.NeuObject objN = new Neusoft.FrameWork.Models.NeuObject();
      //              if (item.NewItemRate < Neusoft.FrameWork.Function.NConvert.ToDecimal("0.1"))
      //              {
      //                  objN.ID = (item.NewItemRate * 100).ToString("0") + "%";
      //              }
      //              else
      //              {
      //                  objN.ID = (item.NewItemRate * 100).ToString("00") + "%";
      //              }
      //              TSNewRate += objN.ID + ",";
      //              alTSNewRate.Add(objN);
      //          }
      //          else
      //          {
      //              hsFind = false;
      //              foreach (Neusoft.FrameWork.Models.NeuObject obj in alTSNewRate)
      //              {
      //                  string tempTSRate = obj.ID.Trim('%');
      //                  decimal hsSameRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(tempTSRate) / 100;
      //                  if (hsSameRate == item.NewItemRate)
      //                  {
      //                      hsFind = true;
      //                      break;
      //                  }
      //              }

      //              if (!hsFind)
      //              {
      //                  Neusoft.FrameWork.Models.NeuObject objN = new Neusoft.FrameWork.Models.NeuObject();
      //                  if (item.NewItemRate < Neusoft.FrameWork.Function.NConvert.ToDecimal("0.1"))
      //                  {
      //                      objN.ID = (item.NewItemRate * 100).ToString("0") + "%";
      //                  }
      //                  else
      //                  {
      //                      objN.ID = (item.NewItemRate * 100).ToString("00") + "%";
      //                  }
      //                  TSNewRate += objN.ID + ",";
      //                  alTSNewRate.Add(objN);
      //              }
      //          }
      //      }

      //      this.lblPriCost4.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(ZFPha, 2);
      //      this.lblPriCost5.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(CBPha, 2);
      //      if (regInfo.Pact.PayKind.ID == "02")
      //      {
      //         // this.lblPriCost24.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(ZFItem, 2);
      //      }           
      //      //清空控件边框
      //      foreach(Control c in this.Controls)
      //      {
      //          if(c.Name.Substring(0, 3) == "lbl")
      //          {
      //              System.Windows.Forms.Label lblControl = null;
      //              lblControl = (System.Windows.Forms.Label)c;
      //              lblControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
      //              c.Visible = true;
      //          }
      //      }
      //      //控制根据打印和预览显示选项
      //      if(isPreview)
      //      {
      //          foreach(Control c in this.Controls)
      //          {
      //              if(c.Name.Substring(0, 3)=="lbl")
      //              {
      //                  c.Visible = isPreview;
      //                  if(c.Name.Substring(0, 8) == "lblPreSw" || c.Name.Substring(0, 8) == "lblPriSw")
      //                  {
							
      //                  }
      //                  else
      //                  {																				 
      //                      ((System.Windows.Forms.Label)c).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      //                  }
      //              }
      //          }
      //      }
      //      else
      //      {
      //          foreach(Control c in this.Controls)
      //          {
      //              if(c.Name == "lblPreSw")
      //              {
      //                  c.Visible=false;
      //              }
      //              if(c.Name.Substring(0, 6) == "lblPre")
      //              {
      //                  c.Visible = isPreview;
      //              }

      //          }
      //      }

      //      Neusoft.FrameWork.Management.DataBaseManger dbManager = new Neusoft.FrameWork.Management.DataBaseManger();
      //Neusoft.HISFC.BizLogic.Fee.Outpatient  myOutPatient = new Neusoft.HISFC.BizLogic.Fee.Outpatient ();
      //      Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
      //      if(this.trans != null)
      //      {
      //          dbManager.SetTrans(this.trans.Trans);
      //          myOutPatient.SetTrans(this.trans.Trans);
      //          managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
      //      }

      //      DateTime dtNow = dbManager.GetDateTimeFromSysDateTime();
      //      //2008-05-04
      //      //if(invoice.Invoice.User03 == "C")
      //      //{
      //      //    invoice.PrintTime = new DateTime(invoice.PrintTime.Year,invoice.PrintTime.Month,invoice.PrintTime.Day,dtNow.Hour,dtNow.Minute,dtNow.Second);
      //      //}
      //      //else
      //      //{
      //      //    invoice.PrintTime = dtNow;
      //      //}

      //      string minute = "";
      //      if(invoice.PrintTime.Minute > 9)
      //      {
      //          minute = invoice.PrintTime.Minute.ToString();
      //      }
      //      else
      //      {
      //          minute = "0" + invoice.PrintTime.Minute.ToString();
      //      }

      //      //基本信息
      //      if(isPreview)
      //      {
				
      //          this.lblPriSwYear.Text = invoice.PrintTime.Year.ToString();  //年
      //          this.lblPriSwMonth.Text = invoice.PrintTime.Month.ToString();//月
      //          this.lblPriSwDay.Text = invoice.PrintTime.Day.ToString();
      //          this.lblPriSwOper.Text = invoice.BalanceOper.ID + "    " + invoice.PrintTime.Hour.ToString()+":"+minute + "  "
      //              ;//结算操作员
      //      }
      //      else
      //      {
      //          this.lblPriSwYear.Text = invoice.PrintTime.Year.ToString();  //年
      //          this.lblPriSwMonth.Text = invoice.PrintTime.Month.ToString();//月
      //          this.lblPriSwDay.Text = invoice.PrintTime.Day.ToString();    //日
      //          string docName = regInfo.DoctorInfo.Templet.Doct.ID;
      //          if(docName == "")
      //          {
      //              Neusoft.HISFC.Models.Fee.Outpatient .FeeItemList f = alFeeItemList[0] as Neusoft.HISFC.Models.Fee.Outpatient .FeeItemList;

      //              if(f != null && f.RecipeOper != null)
      //              {
      //                  this.lblPriSwOper.Text = invoice.BalanceOper.ID + "    " + invoice.PrintTime.Hour.ToString()+":"+minute + "  "
      //                      ;//结算操作员
      //              }
      //          }
      //          else
      //          {
      //              this.lblPriSwOper.Text = invoice.BalanceOper.ID + "    " + invoice.PrintTime.Hour.ToString()+":"+minute + "  "
      //                  ;//结算操作员
      //          }
				
      //      }
      //      this.lblPriSwCardNo.Text = regInfo.PID.CardNO;//门诊卡号
      //      lblPriSwBalanceType.Text = invoice.Invoice.ID;//发票号
      //      //this.lblPriPayKind.Text = regInfo.Pact.Name;//合同单位
			
      //      if (regInfo.SSN != "")
      //      {
      //          this.lblPriName.Text = regInfo.Name + "(" + regInfo.SSN +")";
      //      }
      //      else
      //      {
      //          this.lblPriName.Text = regInfo.Name;//姓名
      //      }
      //      string tempRate = "";

      //      if (regInfo.Pact.ID == "2" || regInfo.Pact.ID == "YTS")
      //      {
      //          Neusoft.HISFC.BizLogic.Registration.Register regMgr = new Neusoft.HISFC.BizLogic.Registration.Register();
      //          if (this.trans != null)
      //          {
      //              regMgr.SetTrans(this.trans.Trans);
      //          }
      //          Neusoft.HISFC.Models.Registration.Register temp = regMgr.GetByClinic(regInfo.ID);
      //          if (temp != null)
      //          {
      //              if (temp.Pact.PayKind.ID == "02")
      //              {
      //                  if (regInfo.Pact.ID == "2")
      //                  {
      //                      tempRate = "【" + "普通医保" + "】";
      //                  }
      //                  else if (regInfo.SIMainInfo.PersonType.ToString() == "2")
      //                  {
      //                      tempRate = "【" + "生育医疗" + "】";
      //                  }
      //              }
      //              else
      //              {
      //                  if (regInfo.SIMainInfo.PersonType.ToString() == "3")
      //                  {
      //                      tempRate = "离休医疗";
      //                  }
      //                  else if (regInfo.SIMainInfo.PersonType.ToString() == "4")
      //                  {
      //                      tempRate = "家属统筹医疗";
      //                  }
      //              }
      //          }
      //          TSNewRate = TSNewRate.TrimEnd(',');
      //          SpecialDisPlay = "(" + TSNewRate + ")";
      //      }
      //      else
      //      {
      //          tempRate = regInfo.Pact.Name;
      //          SpecialDisPlay = string.Empty;
      //          this.neuLabel22.Visible = false;
      //          this.neuLabel24.Visible = false;
      //          this.label1.Visible = false;
      //          this.label2.Visible = false;
      //      }
      //      if (regInfo.Pact.PayKind.ID == "02")
      //      {
      //          if (invoice.Memo == "1")
      //          {
      //            //  tempRate += "100%";
      //          }
      //          if (invoice.Memo == "5")
      //          {
      //              tempRate += "";
      //          }
      //          if (invoice.Memo == "2")
      //          {
      //              foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in alFeeItemList)
      //              {
      //                  if (f.Item.SpecialFlag3 == "2")
      //                  {
      //                      tempRate += (f.NewItemRate * 100).ToString() + "%";
      //                      break;
      //                  }
      //              }
      //          }
      //          if (invoice.Memo == "3")
      //          {
      //              foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in alFeeItemList)
      //              {
      //                  if (f.Item.SpecialFlag3 == "3")
      //                  {
      //                      tempRate += (f.NewItemRate * 100).ToString() + "%";
      //                      break;
      //                  }
      //              }
      //          }
      //      }

      //      ArrayList al;
      //      try
      //      {	
      //          al = myOutPatient.QueryBalancePaysByInvoiceSequence(invoice.CombNO);
      //          if(al == null)
      //          {
      //              return -1;
      //          }
      //      }
      //      catch
      //      {
      //          return -1;
      //      }
      //      Neusoft.FrameWork.Public.ObjectHelper helper = new Neusoft.FrameWork.Public.ObjectHelper();
      //      helper.ArrayObject =  managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYMODES);
      //      if(helper.ArrayObject == null)
      //      {
      //          return -1;
      //      }

      //      string strPayMode = "";//支付方式

      //      for (int i = 0; i < al.Count; i++)
      //      {
      //          Neusoft.HISFC.Models.Fee.Outpatient.BalancePay payMode = al[i] as Neusoft.HISFC.Models.Fee.Outpatient.BalancePay;

      //          strPayMode += " " + helper.GetObjectFromID(payMode.PayType.ID.ToString()).Name;// +" ";//+Neusoft.FrameWork.Public.String.FormatNumber(payMode.Cost,2);//结算操作员
      //      }

      //      if (this.setPayModeType == "1")
      //      {
      //          lblPriPayKind.Text = this.splitInvoicePayMode;
      //      }
      //      else
      //      {
      //          lblPriPayKind.Text = /*"合同单位：" +*/  tempRate  /*+ "|支付方式：" + strPayMode + SpecialDisPlay*/ ;
      //      }
      //      //lblPriSwDrugWindow.Text = invoice.User01;//发药药房

      //      decimal CTFee = 0m, MRIFee = 0m, SXFee = 0m, SYFee = 0m; ;//, PETFee = 0m; ;
      //      //治疗总费用
      //      decimal ZLTotFee = 0m;
      //      //CT总费用 
      //      decimal JCTotFee = 0m;
      //      //票面信息
      //      for(int i=0; i < alInvoiceDetail.Count; i++)
      //      {
      //          Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detail = null;
      //          detail = (Neusoft.HISFC.Models.Fee.Outpatient.BalanceList)alInvoiceDetail[i];
      //          //显示费用名称
      //          if(isPreview)
      //          {
      //              System.Windows.Forms.Label lblFeeName;
      //              if (detail.InvoiceSquence < 1 || detail.InvoiceSquence > 24)
      //              {
      //                  continue;
      //              }
      //              lblFeeName = (System.Windows.Forms.Label)this.GetFeeNameLable(detail.FeeCodeStat.SortID);
      //              if(lblFeeName == null)
      //              {
      //                  MessageBox.Show("没有找到费用大类为" + detail.FeeCodeStat.StatCate.Name + "的打印序号!");
      //                  return -1;
      //              }
      //              try
      //              {
      //                  lblFeeName.Text = detail.FeeCodeStat.StatCate.Name;
      //                  lblFeeName.Visible = true;
      //              }
      //              catch(Exception ex)
      //              {
      //                  MessageBox.Show(ex.Message);
      //                  return -1;
      //              }
      //          }
      //          //费用金额赋值
      //          System.Windows.Forms.Label lblFeeCost ;//= null;
      //          lblFeeCost = (System.Windows.Forms.Label)this.GetFeeCostLable(detail.FeeCodeStat.SortID);
      //          if(lblFeeCost == null)
      //          {
      //              MessageBox.Show("没有找到费用大类为" + detail.FeeCodeStat.StatCate.Name + "的打印序号!");
      //              return -1;
      //          }

      //      //    if (regInfo.Pact.PayKind.ID == "01")
      //      //    {
      //           lblFeeCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(detail.BalanceBase.FT.TotCost, 2);

      //           if (detail.FeeCodeStat.SortID >= 11 && detail.FeeCodeStat.SortID <= 15)
      //          {
      //              JCTotFee = JCTotFee + detail.BalanceBase.FT.TotCost;
      //          }
      //          else if (detail.FeeCodeStat.SortID >= 17 && detail.FeeCodeStat.SortID <= 20)
      //          {
      //              ZLTotFee = ZLTotFee +　detail.BalanceBase.FT.TotCost;
      //          }
      //      //    }
      //      //    else
      //      //    {
      //      //        lblFeeCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(detail.BalanceBase.FT.PayCost + detail.BalanceBase.FT.PubCost, 2);
      //      //        detail.CTFee = 0;
      //      //        detail.MRIFee = 0;
      //      //        //detail.PETFee = 0;
      //      //        detail.SXFee = 0;
      //      //        detail.SYFee = 0;
      //      //    }

      //      //    CTFee += detail.CTFee;
      //      //    MRIFee += detail.MRIFee;
      //      //    //PETFee += detail.PETFee;
      //      //    SXFee += detail.SXFee;
      //      //    SYFee += detail.SYFee;
      //      //    JCTotFee += detail.CTFee + detail.MRIFee;// +detail.PETFee;
      //      //    ZLTotFee += detail.SXFee + detail.SYFee;
      //      }
      //      this.lblPriCost11.Text = JCTotFee.ToString();
      //      this.lblPriCost17.Text = ZLTotFee.ToString();

      //      this.neuLabel22.Text = "医保结算前金额：";//
      //      this.neuLabel24.Text = "医保结算后金额：";//
      //      string[] tempMZZF =  regInfo.SIMainInfo.User03.Split('|');
      //      for (int m= 0; m < tempMZZF.Length; m ++)
      //      {
      //          string[] tempstr = tempMZZF[m].Split(',');
      //          for(int count= 0 ;count < tempstr.Length; count++)
      //          {
      //              if (tempstr[0] == invoice.Invoice.ID)
      //              {
      //                  if (tempstr[1] == "0303" || tempstr[2] != "0")
      //                      this.label1.Text = tempstr[2] + "元";////医保结算前金额
      //                  else
      //                      neuLabel22.Visible = false;
      //                  if (tempstr[1] == "0306" || tempstr[2] != "0")
      //                      this.label2.Text = tempstr[2] + "元";//医保结算后金额
      //                  else 
      //                      neuLabel24.Visible = false;

      //              }
      //          }
               
      //      }
                
			
      //      //if(CTFee > 0)
      //      //{
      //      //    lblPriCost12.Text = CTFee.ToString();
      //      //}
      //      //else
      //      //{
      //      //    lblPriCost12.Text = "";
      //      //}
      //      //if(MRIFee > 0)
      //      //{
      //      //    lblPriCost13.Text = MRIFee.ToString();
      //      //}
      //      //else
      //      //{
      //      //    lblPriCost13.Text = "";
      //      //}
      //      //if (PETFee > 0)
      //      //{
      //      //    lblPriCost14.Text = PETFee.ToString();
      //      //    lblPreFeeName14.Visible = true;
      //      //}
      //      //else
      //      //{
      //      //    lblPriCost14.Text = "";
      //      //    lblPreFeeName14.Visible = false;
      //      //}
      //      //if(SXFee > 0)
      //      //{
      //      //    lblPriCost18.Text = SXFee.ToString();
      //      //}
      //      //else
      //      //{
      //      //    lblPriCost18.Text = "";
      //      //}
      //      //if(SYFee > 0)
      //      //{
      //      //    lblPriCost19.Text = SYFee.ToString();
      //      //}
      //      //else
      //      //{
      //      //    lblPriCost19.Text = "";
      //      //}

      //      //打印处方号
      //      //if (printRecipeNo != string.Empty)
      //      //{
      //      //    this.lblRecipeNo.Text = "处方号：" + printRecipeNo;
      //      //}
      //      //else
      //      //{
      //      //    this.lblRecipeNo.Text = "";
      //      //}

      //      //if (JCTotFee > 0)
      //      //{
      //      //    if (this.lblPriCost11.Text == string.Empty)
      //      //    {
      //      //        this.lblPriCost11.Text = "0";
      //      //    }
      //      //    lblPriCost11.Text = (JCTotFee +
      //      //        Neusoft.FrameWork.Function.NConvert.ToDecimal(this.lblPriCost11.Text.Trim())).ToString();
      //      //}
      //      //if (ZLTotFee > 0)
      //      //{
      //      //    if (this.lblPriCost17.Text == string.Empty)
      //      //    {
      //      //        this.lblPriCost17.Text = "0";
      //      //    }
      //      //    lblPriCost17.Text = (ZLTotFee +
      //      //        Neusoft.FrameWork.Function.NConvert.ToDecimal(this.lblPriCost17.Text.Trim())).ToString();
      //      //}
      //      if(Neusoft.FrameWork.Function.NConvert.ToDecimal(this.lblPriCost4.Text.Trim()) > 0)
      //      {
      //          this.lblPreFeeName4.Visible = true;
      //          this.lblPriCost4.Visible = true;
      //      }
      //      else
      //      {
      //          this.lblPreFeeName4.Visible = false;
      //          this.lblPriCost4.Visible = false;
      //      }
      //      if (regInfo.Pact.PayKind.ID == "02")
      //      {
      //          this.lblPriCost6.Text = invoice.FT.OwnCost.ToString();
      //          this.lblPriCost5.Text = invoice.FT.PayCost.ToString();
      //          this.lblPreFeeName5.Text = "医保个人自负";
      //          this.lblPreFeeName6.Text = "医保不记金额";
      //          this.lblPreFeeName5.Visible = false;
      //          this.lblPreFeeName6.Visible = false;
      //          this.lblPriCost6.Visible = false;
      //          this.lblPriCost5.Visible = false;

      //      }
      //      else
      //      {
      //          if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.lblPriCost5.Text.Trim()) > 0)
      //          {
      //              this.lblPreFeeName5.Visible = true;
      //              this.lblPriCost5.Visible = true;
      //          }
      //          else
      //          {
      //              this.lblPreFeeName5.Visible = false;
      //              this.lblPriCost5.Visible = false;
      //          }
      //          this.lblPreFeeName6.Visible = false;
      //      }
      //      if(Neusoft.FrameWork.Function.NConvert.ToDecimal(this.lblPriCost24.Text.Trim()) > 0)
      //      {
      //          this.lblPreFeeName24.Visible = false;
      //          this.lblPriCost24.Visible = false;
      //      }
      //      else
      //      {
      //          this.lblPreFeeName24.Visible = false;
      //          this.lblPriCost24.Visible = false;
      //      }
      //      if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.lblPriCost8.Text.Trim()) > 0)
      //      {
      //          this.lblPreFeeName8.Visible = false;
      //          this.lblPriCost8.Visible = false;
      //      }
      //      else
      //      {
      //          this.lblPreFeeName8.Visible = false;
      //          this.lblPriCost8.Visible = false;
      //      }
      //      //zhangq
      //      ///没有处理的发票应受金额
      //      decimal NoDealOwnPay = invoice.FT.OwnCost + invoice.FT.PayCost;
      //      ///处理后的发票应受金额
      //      decimal DealOwnPay = Neusoft.FrameWork.Public.String.FormatNumber( NoDealOwnPay, 1 );
      //      ///四舍五入金额
      //      decimal DealedCost = DealOwnPay - NoDealOwnPay;
      //      this.lblPriCost7.Text = DealedCost.ToString();//Neusoft.FrameWork.Public.String.FormatNumberReturnString(DealedCost,2);
      //      if (Neusoft.FrameWork.Function.NConvert.ToDecimal( this.lblPriCost7.Text.Trim() ) != 0)
      //      {
      //          this.lblPreFeeName7.Visible = true;
      //          this.lblPriCost7.Visible = true;
      //      }
      //      else
      //      {
      //          this.lblPreFeeName7.Visible = false;
      //          this.lblPriCost7.Visible = false;
      //      }

      //      if (regInfo.Pact.PayKind.ID == "03")//公费
      //      {
      //          this.lblPriPub.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(invoice.FT.PubCost, 2) + " 医保合计:" + Neusoft.FrameWork.Public.String.FormatNumberReturnString(invoice.FT.PubCost + invoice.FT.PayCost, 2);
      //          //根据合同单位获取自付比例
      //          Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactMgr = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();
      //          pactMgr.SetTrans(this.trans.Trans);
      //          Neusoft.HISFC.Models.Base.PactInfo pactObj = pactMgr.GetPactUnitInfoByPactCode(regInfo.Pact.ID);
      //          if (pactObj != null && pactObj.Rate.PayRate > 0)
      //          {
      //              this.lblPriPay.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString( DealOwnPay, 2 ) + " (" + Neusoft.FrameWork.Public.String.FormatNumberReturnString( pactObj.Rate.PayRate * 100, 0 ).Replace( ".", "" ) + "%:" + Neusoft.FrameWork.Public.String.FormatNumberReturnString( invoice.FT.PayCost, 2 ) + ")";
      //          }
      //          else
      //          {
      //              this.lblPriPay.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString( DealOwnPay, 2 );
      //          }
      //      }
      //      else if (regInfo.Pact.PayKind.ID == "02")
      //      {
      //          string[] tempzfstr = new string[5];//regInfo.SIPerson.User02.Split('|');
      //          for (int m = 0; m < tempzfstr.Length; m++)
      //          {
      //              string[] tempstr = tempzfstr[m].Split(',');
      //              for (int count = 0; count < tempstr.Length; count++)
      //              {
      //                  if (tempstr[0] == invoice.Invoice.ID)
      //                  {
      //                      this.lblPriPub.Text = tempstr[1];
      //                  }
      //              }

      //          }
               
                   
                
      //          //if (invoice.FT.PubCost > 0)
      //          //{
      //          //    this.lblPriPub.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(invoice.FT.PubCost, 2);
      //          //}
      //          //if (invoice.FT.OwnCost > 0)
      //          //{
      //          //    this.lblPriPay.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(DealOwnPay, 2)+"("+invoice.FT.PayCost.ToString()+
      //          //        "+" + "不属门特药品" + (DealOwnPay - invoice.FT.PayCost).ToString() + ")";
      //          //}
      //          //else
      //          //{
      //          //    this.lblPriPay.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(DealOwnPay, 2);
      //          //}
          
      //      }
      //      else
      //      {
              
      //          this.lblPriPay.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(DealOwnPay, 2);
      //      }
      //      //zhangq
      //      //显示药房领药窗口
      //      try
      //      {
      //          if (invoice.DrugWindowsNO != null && invoice.DrugWindowsNO != string.Empty)
      //          {
      //              string[] drugWindow = invoice.DrugWindowsNO.Split('|');
      //              Hashtable hsDrugWindow = new Hashtable();
      //              string disPlayWindow = string.Empty;
      //              for (int x = 0; x < drugWindow.Length; x++)
      //              {
      //                  if(!hsDrugWindow.Contains(drugWindow[x]))
      //                  {
      //                      disPlayWindow += "，" + drugWindow[x];
      //                      hsDrugWindow.Add(drugWindow[x],null);
      //                  }
                        
      //                  //if (hsDrugWindow.ContainsValue(drugWindow[x]))
      //                  //{
      //                  //    disPlayWindow = disPlayWindow + "，" + drugWindow[x].ToString();
      //                  //}
      //                  //else
      //                  //{
      //                  //    hsDrugWindow.Add(x, drugWindow[x].ToString());
      //                  //    disPlayWindow = disPlayWindow + "，" + drugWindow[x].ToString();
      //                  //}
      //              }

      //              if (disPlayWindow != string.Empty)
      //              {
      //                  this.lblDrugWindow.Visible = true;
      //                  this.lblDrugWindow.Text += disPlayWindow.TrimStart('，');
      //              }
      //              else
      //              {
      //                  this.lblDrugWindow.Visible = false;
      //              }
      //          }
      //          else
      //          {
      //              this.lblDrugWindow.Visible = false;
      //          }
      //      }
      //      catch
      //      { }
      //      this.lblPriLower.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(invoice.FT.TotCost, 2);

      //      string[] strMoney = new string[8];
			
      //      strMoney = this.GetUpperCashbyNumber(Neusoft.FrameWork.Public.String.FormatNumber(invoice.FT.TotCost, 2));
      //      this.lblPriFen.Text=strMoney[0];
      //      this.lblPriJiao.Text=strMoney[1];
      //      this.lblPriYing.Text=strMoney[3];
      //      this.lblPriShi.Text=strMoney[4];
      //      this.lblPriBai.Text=strMoney[5];
      //      this.lblPriQian.Text=strMoney[6];
      //      this.lblPriWan.Text=strMoney[7];
      //      this.lblPriTenW.Text="";
      //      if (!string.IsNullOrEmpty(invoice.CanceledInvoiceNO))
      //      {
      //          this.lblReprint.Text = "重打发票号:" + invoice.CanceledInvoiceNO;
      //          this.lblReprint.Visible = true;
      //      }
      //      else
      //      {
      //          lblReprint.Visible = false;
      //      }
      //      lblPriSwHosPital.Text = managerIntegrate.GetHospitalName();
      //      this.Print();
      //      return 0;
      //  }
      //  /// <summary>
      //  /// 获得费用名称输入框
      //  /// </summary>
      //  /// <param name="i">序号</param>
      //  /// <returns>费用名称输入框控件</returns>
      //  private Control GetFeeNameLable(int i)
      //  {
      //      foreach(Control c in this.Controls)
      //      {
      //          if(c.Name == "lblPreFeeName"+i.ToString()) 
      //          {
      //              c.Visible = true;
      //              return c;
      //          }
      //      }
      //      return null;
      //  }
      //  /// <summary>
      //  /// 获得费用金额输入框
      //  /// </summary>
      //  /// <param name="i">序号</param>
      //  /// <returns>费用金额输入框控件</returns>
      //  private Control GetFeeCostLable(int i)
      //  {
      //      foreach(Control c in this.Controls)
      //      {
      //          if(c.Name == "lblPriCost"+i.ToString()) 
      //          {
      //              c.Visible = true;
      //              return c;
      //          }
      //      }
      //      return null;
      //  }
		

      //  /// <summary>
      //  /// 发票只打印大写数字 打印到十万
      //  /// </summary>
      //  /// <param name="Cash"></param>
      //  /// <returns></returns>
      //  private string[] GetUpperCashbyNumber(decimal Cash)
      //  {
      //      string[] sNumber = {"零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖"};
      //      string[] sReturn = new string[9];
      //      string strCash = null;
      //      //填充位数
      //      int iLen = 0;
      //      strCash = Neusoft.FrameWork.Public.String.FormatNumber(Cash, 2).ToString("############.00");
      //      if(strCash.Length > 9)
      //      {
      //          strCash = strCash.Substring(strCash.Length - 9);
      //      }

      //      //填充位数
      //      iLen = 9 - strCash.Length;
      //      for(int j = 0; j < iLen; j++)
      //      {
      //          int k = 0;
      //          k = 8 - j;
      //          sReturn[k] = "零";
      //      }
      //      for(int i = 0; i < strCash.Length; i++)
      //      {
      //          string Temp = null;
				
      //          Temp = strCash.Substring(strCash.Length - 1 - i, 1);

      //          if(Temp == ".")
      //          {
      //              continue;
      //          }
      //          sReturn[i] = sNumber[int.Parse(Temp)];
      //      }
      //      return sReturn;
      //  }

      //  #endregion

      //  #region IInvoicePrint 成员

      //  public bool IsPreView
      //  {
      //      set
      //      {
      //          _isPreView = value;
      //      }
      //  }

      //  public string Description
      //  {
      //      get
      //      {
      //          // TODO:  添加 ucInvoiceGY.Description getter 实现
      //          return "门诊发票";
      //      }
      //  }

      //  public void SetPreView(bool isPreView)
      //  {
      //      _isPreView = isPreView;
      //  }

      //  public int Print()
      //  {
      //      try
      //      {
      //          Neusoft.FrameWork.WinForms.Classes.Print print = null;
      //          try
      //          {
      //              print = new Neusoft.FrameWork.WinForms.Classes.Print();
      //          }
      //          catch(Exception ex)
      //          {
      //              MessageBox.Show("初始化打印机失败!" + ex.Message);
      //              return -1;
      //          }
      //          if(this.trans == null)
      //          {
      //              MessageBox.Show("没有设置数据库连接!");
      //              return -1;
      //          }
      //          Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("MZINVOICE", ref print, ref this.trans);

      //          System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize("GYMZInvoice", 787 ,400);
      //          print.SetPageSize(size);
      //          print.IsCanCancel = false;
      //          print.PrintPage(0, 0, this);
      //      }
      //      catch(Exception e)
      //      {
      //          MessageBox.Show(e.Message);
      //          return -1;
      //      }
      //      return 0;
      //  }

      //  private string invoiceType;

      //  public string InvoiceType
      //  {
      //      get { return "MZ01"; }
      //  }

      //  private Neusoft.HISFC.Models.Registration.Register register;
      //  public Neusoft.HISFC.Models.Registration.Register Register
      //  {
      //      set
      //      {
      //          //register = value;
      //          //if (register.Pact.ID == "7")
      //          //{
      //          //    invoiceType = "MZ05";
      //          //}
      //          //else
      //          //{
      //          invoiceType = "MZ01";
      //          //}
      //      }
      //  }
      //  #endregion

      //  #region IInvoicePrint 成员

      //  public void SetTrans(Neusoft.FrameWork.Management.Transaction t)
      //  {
      //      this.trans = t;
      //  }

      //  public Neusoft.FrameWork.Management.Transaction Trans
      //  {
      //      set
      //      {
      //          this.trans = value;
      //      }
      //  }

      //  #endregion

      //  #region IInvoicePrint 成员

      //  //public int SetPrintOtherInfomation(Neusoft.HISFC.Models.Registration.Register regInfo, ArrayList Invoices, ArrayList invoiceDetails, ArrayList feeDetails)
      //  //{
      //  //    this.otherPrint.RInfo = regInfo;
      //  //    this.otherPrint.Trans = this.trans;
      //  //    this.otherPrint.Invoices = Invoices;
      //  //    this.otherPrint.FeeDetails = feeDetails;
      //  //    this.otherPrint.SetDisplay();
      //  //    return 0;
      //  //}

      //  public int PrintOtherInfomation()
      //  {
      //      Neusoft.FrameWork.WinForms.Classes.Print print = null;
      //      try
      //      {
      //          print = new Neusoft.FrameWork.WinForms.Classes.Print();
      //      }
      //      catch(Exception ex)
      //      {
      //          MessageBox.Show("初始化打印机失败!" + ex.Message);
      //          return -1;
      //      }
      //      if(this.trans == null)
      //      {
      //          MessageBox.Show("没有设置数据库连接!");
      //          return -1;
      //      }
      //      //Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("MZFEEDETAIL", ref print, ref this.trans);
      //      print.PrintDocument.PrinterSettings.PrinterName = "MZFEEDETAILPRINTER";
      //      System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize("MZFEEDETAIL", 669, 425);
      //      print.IsDataAutoExtend = true;
      //      print.SetPageSize(size);
      //      print.IsCanCancel = false;
      //      print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
      //      //print.IsDataAutoExtend = false;


      //      //注销小票打印功能，何荣 09-07-02
      //      //for (int m = 0; m < otherPrint.fpSpread1.Sheets.Count; m++)
      //      //{
      //      //    this.otherPrint.fpSpread1.ActiveSheet = otherPrint.fpSpread1.Sheets[m];
      //      //    print.PrintPage(0, 0, this.otherPrint.fpSpread1);
      //      //}
      //      return 0;
           
      //  }

      //  #endregion

      //  #region IInvoicePrint 成员

      //  private string setPayModeType = "";
      //   private string splitInvoicePayMode = "";
		
      //  #endregion

      //  #region IInvoicePrint 成员

      //  public string SetPayModeType
      //  {
      //      set
      //      {
      //          this.setPayModeType = value;
      //      }
      //  }

      //  public void SetTrans( IDbTransaction trans )
      //  {
      //      this.trans.Trans = trans;
      //  }

      //  public string SplitInvoicePayMode
      //  {
      //      set
      //      {
      //          this.splitInvoicePayMode = value;
      //      }
      //  }

      //  IDbTransaction Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.Trans
      //  {
      //      set
      //      {
      //          throw new Exception( "The method or operation is not implemented." );
      //      }
      //  }

      //  #endregion

      //  //#region IInvoicePrint 成员


      //  //public string InvoiceType
      //  //{
      //  //    get { throw new Exception("The method or operation is not implemented."); }
      //  //}

      //  //public Neusoft.HISFC.Models.Registration.Register Register
      //  //{
      //  //    set { throw new Exception("The method or operation is not implemented."); }
      //  //}

      //  //#endregion

      //  #region IInvoicePrint 成员

      //  string Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.Description
      //  {
      //      get { return null; }
      //  }

      //  //string Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.InvoiceType
      //  //{
      //  //    get { return null; }
      //  //}

      //  bool Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.IsPreView
      //  {
      //      set {  }
      //  }

      //  int Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.Print()
      //  {
      //      return 1;
      //  }

      //  int Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.PrintOtherInfomation()
      //  {
      //      return 1;
      //  }

      //  Neusoft.HISFC.Models.Registration.Register Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.Register
      //  {
      //      set {  }
      //  }

      //  string Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetPayModeType
      //  {
      //      set { }
      //  }

      //  void Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetPreView(bool isPreView)
      //  {
      //      ;
      //  }

      //  int Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetPrintOtherInfomation(Neusoft.HISFC.Models.Registration.Register regInfo, ArrayList Invoices, ArrayList invoiceDetails, ArrayList feeDetails)
      //  {
      //      return 1;
      //  }

      //  int Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetPrintValue(Neusoft.HISFC.Models.Registration.Register regInfo, Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice, ArrayList invoiceDetails, ArrayList feeDetails, bool isPreview)
      //  {
      //      this.SetPrintValue(regInfo, invoice, invoiceDetails, feeDetails, isPreview);
      //      return 1;
      //  }

      //  void Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetTrans(IDbTransaction trans)
      //  {
            
      //  }

      //  string Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SplitInvoicePayMode
      //  {
      //      set { }
      //  }

      //  #endregion


      //  #region IInterfaceContainer 成员

      //  public Type[] InterfaceTypes
      //  {
      //      get
      //      {
      //          Type[] type = new Type[1];
             
      //          type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint);
      //          return type;
      //      }
      //  }

      //  #endregion
    }
}