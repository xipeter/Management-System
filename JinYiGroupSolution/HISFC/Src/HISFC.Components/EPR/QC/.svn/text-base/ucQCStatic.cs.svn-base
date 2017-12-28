using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR.QC
{
	/// <summary>
	/// ucQCStatic 的摘要说明。
	/// </summary>
	public class ucQCStatic : UserControl
	{
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucQCStatic()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpSpread1
			// 
			this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fpSpread1.Location = new System.Drawing.Point(0, 0);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				   this.fpSpread1_Sheet1});
			this.fpSpread1.Size = new System.Drawing.Size(520, 392);
			this.fpSpread1.TabIndex = 0;
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			// 
			// ucQCStatic
			// 
			this.Controls.Add(this.fpSpread1);
			this.Name = "ucQCStatic";
			this.Size = new System.Drawing.Size(520, 392);
			this.Load += new System.EventHandler(this.ucQCStatic_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		#region 初始化

		private ArrayList alConditions = null;

		private void Init()
		{
			// Neusoft.HISFC.Management.Manager.Department managerDept = new Neusoft.HISFC.Management.Manager.Department();
			//alDepts = managerDept.GetDeptment(Neusoft.HISFC.Models.Base.DepartmentType.enuDepartmentType.I);	
            this.initFP(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetQCConditionList());
			
		}

		private void initFP(ArrayList al)
		{
			this.alConditions = al;
			this.fpSpread1_Sheet1.DataAutoCellTypes = false;
			this.fpSpread1_Sheet1.Columns[-1].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpSpread1_Sheet1.DataAutoHeadings = false;
			this.fpSpread1_Sheet1.DataAutoSizeColumns = false;
			this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
			this.fpSpread1_Sheet1.ColumnCount = al.Count+2;
			this.fpSpread1_Sheet1.Columns[0].Label  = "住院号";
			this.fpSpread1_Sheet1.Columns[1].Label  = "姓名";
			this.fpSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 59F;
			this.fpSpread1_Sheet1.Columns[-1].Width  = 100;
			for(int i=0;i<al.Count;i++)
			{
				this.fpSpread1_Sheet1.Columns[i+2].Label = al[i].ToString();
				
			}
			this.fpSpread1.CellDoubleClick+=new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellDoubleClick);
			
		}
		private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(this.fpSpread1_Sheet1.Rows[e.Row].Tag.GetType() == typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
			{
				Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.fpSpread1_Sheet1.Rows[e.Row].Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
				//双击显示病历
				Panel p =new Panel();
				p.Size = new Size(800,600);
				//--待完成
                Common.Classes.Function.EMRShow(p,patientInfo,"0",false);
				Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(p);
			}
		}
		
		#endregion

		private void ucQCStatic_Load(object sender, System.EventArgs e)
		{
			if(DesignMode == false)
				this.Init();
		}

		#region 函数

		/// <summary>
		/// 查询,刷新
		/// </summary>
		/// <param name="alPatients"></param>
		public void Query(ArrayList alPatients)
		{
			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询质控信息，请稍候.");
			Application.DoEvents();
			int iProgress = 0 ;
			this.fpSpread1_Sheet1.RowCount = 0;
			foreach(Neusoft.HISFC.Models.RADT.PatientInfo obj in alPatients)
			{
				Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(iProgress,alPatients.Count);
				iProgress++;
				Application.DoEvents();

				this.fpSpread1_Sheet1.Rows.Add(0,1);
				this.fpSpread1_Sheet1.Rows[0].Tag = obj;
				this.fpSpread1_Sheet1.Cells[0,0].Text = obj.PID.PatientNO;
				this.fpSpread1_Sheet1.Cells[0,1].Text = obj.Name;
				int iColumns = 1;
				//查询
				foreach(Neusoft.HISFC.Models.EPR.QCConditions condition  in alConditions)
				{
                    bool b = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.ExecQCInfo(obj.ID, Common.Classes.Function.ISql, condition);
					iColumns++;
					if(b)
					{
						this.fpSpread1_Sheet1.Cells [0,iColumns].ForeColor = Color.Red;
						try
						{
							this.fpSpread1_Sheet1.Cells[0,iColumns].Text = "Ｘ";//+((Neusoft.FrameWork.Models.NeuObject)condition.AlConditions[0]).Memo+((Neusoft.FrameWork.Models.NeuObject)condition.AlConditions[1]).Memo;
						}
						catch{}

					}
					else
					{
						this.fpSpread1_Sheet1.Cells[0,iColumns].Text = "√";
					}
					
				}

			}
			Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
		}
		#endregion
	}
}
