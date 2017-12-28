using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Neusoft.FrameWork.Models;
namespace Neusoft.FrameWork.WinForms.Forms {
	/// <summary>
	/// frmEasyChoose 的摘要说明。
	/// 快速查询窗口
	/// writed by cuipeng
	/// 2005-3
	/// </summary>
	public class frmEasyChoose :BaseForm{
		private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtQueryCode;
		private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
		private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
		private System.ComponentModel.IContainer components;
		private DataSet myDataSet = new DataSet();

		protected FarPoint.Win.Spread.FpSpread fpData;
		protected FarPoint.Win.Spread.SheetView fpData_Sheet1;
		private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chbMisty;
		private DataView myDataView;
		private Neusoft.FrameWork.Models.NeuObject myObject = new Neusoft.FrameWork.Models.NeuObject();
		private Neusoft.FrameWork.Public.ObjectHelper objHelper = new Neusoft.FrameWork.Public.ObjectHelper();
		public event SelectedItemHandler SelectedItem;
		/// <summary>
		/// 窗口返回的实体属性
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Object {
			get{ return myObject;}
			set{ 
				if(value == null) return;
				myObject = value;
			}
		}


		public frmEasyChoose(ArrayList arrayList) {
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            this.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Blue);
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle(fpData);
            this.fpData_Sheet1.RowCount = 0;
			this.components = new System.ComponentModel.Container();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//

			//this.myObject = NeuObject;
			this.InitData(arrayList);
		}


		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		
		/// <summary>
		/// 通过输入的查询码，过滤数据列表
		/// </summary>
		private void ChangeItem() {
			if (this.myDataSet.Tables[0].Rows.Count == 0) return;

			try {
				//取查询码
				string queryCode = "";
				if (this.chbMisty.Checked) {
					queryCode = "%" + Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtQueryCode.Text.Trim()) + "%";
				}
				else {
                    //
                    //[2007/02/05] 取消模糊
                    //queryCode = this.txtQueryCode.Text.Trim() + "%";
                    //
                    queryCode = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtQueryCode.Text.Trim());
				}
                //设置过滤条件
                string filter = string.Empty;
                if (queryCode.Trim() == "" || queryCode.Trim() == null)
                {
                    filter = "拼音码 LIKE '%'";//显示全部数据
                }
                else
                {

                    filter = "(拼音码 LIKE '" + queryCode + "') OR " +
                        "(五笔码 LIKE '" + queryCode + "') OR " +
                        "(自定义码 LIKE '" + queryCode + "') OR " +
                        "(编码 LIKE '" + queryCode + "') OR " +
                        "(名称 LIKE '" + queryCode + "')";
                }

				this.myDataView.RowFilter = filter;

				//显示第一条数据
				this.fpData_Sheet1.ActiveRowIndex= 0;

				//设置farpoint的显示格式
                //this.SetFormat();
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message );
				return;
			}
		}


		/// <summary>
		/// 取当前被选中的数据
		/// </summary>
		private void GetItem() {
			//没有数据则返回
			if(this.fpData_Sheet1.RowCount == 0) return;
			
			//取当前行的数据。
			string ID = this.fpData_Sheet1.Cells[this.fpData_Sheet1.ActiveRowIndex,0].Text;

			//根据编码取对应的对象
			this.myObject = objHelper.GetObjectFromID(ID);
			if (this.myObject == null) {
				MessageBox.Show("没有找到有效的数据","无法找到数据");
				return;
			}
			
			try {
				//抛出事件，传出用户选中的对象。用户需要通过定义此事件来接收数据
				SelectedItem(this.myObject);
			}
			catch{}
			this.DialogResult = DialogResult.OK;
			//this.Close();
		}


		/// <summary>
		/// 设置数据控件格式
		/// </summary>
		private void SetFormat() {
			//显示数据格式
			this.fpData_Sheet1.ColumnCount = 6;
            this.fpData_Sheet1.ColumnHeader.Cells.Get( 0, 0 ).Text = Neusoft.FrameWork.Management.Language.Msg( "编码" );
            this.fpData_Sheet1.ColumnHeader.Cells.Get( 0, 1 ).Text = Neusoft.FrameWork.Management.Language.Msg( "名称" );
            this.fpData_Sheet1.ColumnHeader.Cells.Get( 0, 2 ).Text = Neusoft.FrameWork.Management.Language.Msg( "其他" );
            this.fpData_Sheet1.ColumnHeader.Cells.Get( 0, 3 ).Text = Neusoft.FrameWork.Management.Language.Msg( "拼音码" );
            this.fpData_Sheet1.ColumnHeader.Cells.Get( 0, 4 ).Text = Neusoft.FrameWork.Management.Language.Msg( "五笔码" );
            this.fpData_Sheet1.ColumnHeader.Cells.Get( 0, 5 ).Text = Neusoft.FrameWork.Management.Language.Msg( "自定义码" );
			this.fpData_Sheet1.ColumnHeader.Rows.Get(0).Height = 24F;
            this.fpData_Sheet1.Columns.Get( 0 ).Label = Neusoft.FrameWork.Management.Language.Msg( "编码" );
			this.fpData_Sheet1.Columns.Get(0).Locked = true;
			this.fpData_Sheet1.Columns.Get(0).Width = 54F;
            this.fpData_Sheet1.Columns.Get( 1 ).Label = Neusoft.FrameWork.Management.Language.Msg( "名称" );
			this.fpData_Sheet1.Columns.Get(1).Locked = true;
			this.fpData_Sheet1.Columns.Get(1).Width = 139F;
            this.fpData_Sheet1.Columns.Get( 2 ).Label = Neusoft.FrameWork.Management.Language.Msg( "其他" );
			this.fpData_Sheet1.Columns.Get(2).Locked = true;
			this.fpData_Sheet1.Columns.Get(2).Width = 112F;
            this.fpData_Sheet1.Columns.Get( 3 ).Label = Neusoft.FrameWork.Management.Language.Msg( "拼音码" );
			this.fpData_Sheet1.Columns.Get(3).Locked = true;
			this.fpData_Sheet1.Columns.Get(3).Width = 81F;
            this.fpData_Sheet1.Columns.Get( 4 ).Label = Neusoft.FrameWork.Management.Language.Msg( "五笔码" );
			this.fpData_Sheet1.Columns.Get(4).Locked = true;
			this.fpData_Sheet1.Columns.Get(4).Width = 72F;
            this.fpData_Sheet1.Columns.Get( 5 ).Label = Neusoft.FrameWork.Management.Language.Msg( "自定义码" );
			this.fpData_Sheet1.Columns.Get(5).Locked = true;
			this.fpData_Sheet1.Columns.Get(5).Width = 67F;
			this.fpData_Sheet1.GrayAreaBackColor = System.Drawing.Color.Honeydew;
			this.fpData_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
			this.fpData_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpData_Sheet1.RowHeader.Columns.Get(0).Width = 30F;
			this.fpData_Sheet1.SelectionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(225)), ((System.Byte)(243)));
		}

        /// <summary>
        /// Fp格式化显示
        /// </summary>
        /// <param name="label"></param>
        /// <param name="visible"></param>
        /// <param name="width"></param>
        public virtual void SetFormat(string[] label, bool[] visible, int[] width)
        {
            for (int i = 0; i < this.fpData_Sheet1.Columns.Count; i++)
            {
                if (label != null && label.Length > i)
                {
                    this.fpData_Sheet1.Columns[i].Label = label[i];
                }

                if (visible != null && visible.Length > i)
                {
                    this.fpData_Sheet1.Columns[i].Visible = visible[i];
                }

                if (width != null && width.Length > i)
                {
                    this.fpData_Sheet1.Columns[i].Width = width[i];
                }
            }            
        }


        /// <summary>
        /// 初始化窗口
        /// </summary>
        /// <param name="al"></param>
        private void InitData(ArrayList al)
        {
			if(al == null) return;
			objHelper.ArrayObject = al;
			this.myDataSet.Tables.Clear();
			this.myDataSet.Tables.Add();
			
			//定义类型
			System.Type dtStr   = System.Type.GetType("System.String");

			//在myDataTable中添加列
			this.myDataSet.Tables[0].Columns.AddRange( new DataColumn[] {
																			new DataColumn("编码",     dtStr),
																			new DataColumn("名称",     dtStr),
																			new DataColumn("其他",     dtStr),
																			new DataColumn("拼音码",   dtStr),
																			new DataColumn("五笔码",   dtStr),
																			new DataColumn("自定义码", dtStr)
																		});

			//将数组中的数据插入到DataSet中
			Neusoft.HISFC.Models.Base.ISpell spell;
			Neusoft.FrameWork.Models.NeuObject obj;
			string spellCode = "";
			string wbCode = "";
			string userCode = "";
			this.fpData_Sheet1.Rows.Count = al.Count;
			for(int i=0; i<al.Count; i++) {
				//转成NeuObject类型
				obj = al[i] as Neusoft.FrameWork.Models.NeuObject;
				//如果传入的类型不能转换成NeuObject则返回
				if (obj == null) return;
				try {
					//实现接口
					spell = obj as Neusoft.HISFC.Models.Base.ISpell;
					if (spell != null) {
						spellCode = spell.SpellCode;  //拼音码
						wbCode    = spell.WBCode;     //五笔码	
						userCode  = spell.UserCode;   //自定义码
					}

					//向myDataSet中添加数据
					this.myDataSet.Tables[0].Rows.Add( new object[] {
																		obj.ID,    //编码
																		obj.Name,  //名称
																		obj.Memo,  //其他
																		spellCode, //拼音码		
																		wbCode,    //五笔码		
																		userCode   //自定义码	
																	});
					//this.fpData_Sheet1.Rows[i].Tag = obj;
				}
				catch(Exception ex) {
					MessageBox.Show(ex.Message);
					return;
				}
			}

			//指定farpoint的数据源，用myDataView来过滤数据
			this.myDataView = new DataView(this.myDataSet.Tables[0]);
			this.fpData.DataSource = this.myDataView;

			//设置数据控件格式
            this.SetFormat();
		}
		

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmEasyChoose ) );
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.txtQueryCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.fpData = new FarPoint.Win.Spread.FpSpread();
            this.fpData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.chbMisty = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fpData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.AccessibleDescription = null;
            this.txtQueryCode.AccessibleName = null;
            resources.ApplyResources( this.txtQueryCode, "txtQueryCode" );
            this.txtQueryCode.BackgroundImage = null;
            this.txtQueryCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueryCode.Font = null;
            this.txtQueryCode.IsEnter2Tab = false;
            this.txtQueryCode.Name = "txtQueryCode";
            this.txtQueryCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.txtQueryCode.TextChanged += new System.EventHandler( this.txtQueryCode_TextChanged );
            this.txtQueryCode.KeyDown += new System.Windows.Forms.KeyEventHandler( this.txtQueryCode_KeyDown );
            this.txtQueryCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtQueryCode_KeyPress );
            // 
            // fpData
            // 
            this.fpData.About = "3.0.2004.2005";
            resources.ApplyResources( this.fpData, "fpData" );
            this.fpData.AccessibleName = null;
            this.fpData.BackColor = System.Drawing.SystemColors.Control;
            this.fpData.BackgroundImage = null;
            this.fpData.Font = null;
            this.fpData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpData.Name = "fpData";
            this.fpData.Sheets.AddRange( new FarPoint.Win.Spread.SheetView[] {
            this.fpData_Sheet1} );
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)) );
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpData.TextTipAppearance = tipAppearance1;
            this.fpData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpData.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler( this.fpData_CellDoubleClick );
            this.fpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.fpData_KeyPress );
            // 
            // fpData_Sheet1
            // 
            this.fpData_Sheet1.Reset();
            this.fpData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpData_Sheet1.ColumnCount = 6;
            this.fpData_Sheet1.ColumnHeader.Cells.Get( 0, 0 ).Value = "编码";
            this.fpData_Sheet1.ColumnHeader.Cells.Get( 0, 1 ).Value = "名称";
            this.fpData_Sheet1.ColumnHeader.Cells.Get( 0, 2 ).Value = "其他";
            this.fpData_Sheet1.ColumnHeader.Cells.Get( 0, 3 ).Value = "拼音码";
            this.fpData_Sheet1.ColumnHeader.Cells.Get( 0, 4 ).Value = "五笔码";
            this.fpData_Sheet1.ColumnHeader.Cells.Get( 0, 5 ).Value = "自定义码";
            this.fpData_Sheet1.ColumnHeader.Rows.Get( 0 ).Height = 24F;
            this.fpData_Sheet1.Columns.Get( 0 ).AllowAutoSort = true;
            this.fpData_Sheet1.Columns.Get( 0 ).Label = "编码";
            this.fpData_Sheet1.Columns.Get( 0 ).Locked = true;
            this.fpData_Sheet1.Columns.Get( 0 ).Width = 79F;
            this.fpData_Sheet1.Columns.Get( 1 ).Label = "名称";
            this.fpData_Sheet1.Columns.Get( 1 ).Locked = true;
            this.fpData_Sheet1.Columns.Get( 1 ).Width = 148F;
            this.fpData_Sheet1.Columns.Get( 2 ).Label = "其他";
            this.fpData_Sheet1.Columns.Get( 2 ).Locked = true;
            this.fpData_Sheet1.Columns.Get( 2 ).Width = 64F;
            this.fpData_Sheet1.Columns.Get( 3 ).Label = "拼音码";
            this.fpData_Sheet1.Columns.Get( 3 ).Locked = true;
            this.fpData_Sheet1.Columns.Get( 3 ).Width = 84F;
            this.fpData_Sheet1.Columns.Get( 4 ).Label = "五笔码";
            this.fpData_Sheet1.Columns.Get( 4 ).Locked = true;
            this.fpData_Sheet1.Columns.Get( 4 ).Width = 76F;
            this.fpData_Sheet1.Columns.Get( 5 ).Label = "自定义码";
            this.fpData_Sheet1.Columns.Get( 5 ).Locked = true;
            this.fpData_Sheet1.Columns.Get( 5 ).Width = 92F;
            this.fpData_Sheet1.DataAutoHeadings = false;
            this.fpData_Sheet1.DataAutoSizeColumns = false;
            this.fpData_Sheet1.GrayAreaBackColor = System.Drawing.Color.Honeydew;
            this.fpData_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpData_Sheet1.RowHeader.Columns.Get( 0 ).AllowAutoSort = true;
            this.fpData_Sheet1.RowHeader.Columns.Get( 0 ).Width = 21F;
            this.fpData_Sheet1.SelectionForeColor = System.Drawing.Color.White;
            this.fpData_Sheet1.SheetCornerStyle.Locked = false;
            this.fpData_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpData_Sheet1.SheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.fpData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleDescription = null;
            this.btnOK.AccessibleName = null;
            resources.ApplyResources( this.btnOK, "btnOK" );
            this.btnOK.BackgroundImage = null;
            this.btnOK.Font = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = null;
            this.btnCancel.AccessibleName = null;
            resources.ApplyResources( this.btnCancel, "btnCancel" );
            this.btnCancel.BackgroundImage = null;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // chbMisty
            // 
            this.chbMisty.AccessibleDescription = null;
            this.chbMisty.AccessibleName = null;
            resources.ApplyResources( this.chbMisty, "chbMisty" );
            this.chbMisty.BackgroundImage = null;
            this.chbMisty.Checked = true;
            this.chbMisty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbMisty.Font = null;
            this.chbMisty.Name = "chbMisty";
            this.chbMisty.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.chbMisty.CheckedChanged += new System.EventHandler( this.chbMisty_CheckedChanged_2 );
            // 
            // frmEasyChoose
            // 
            this.AcceptButton = this.btnOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources( this, "$this" );
            this.BackgroundImage = null;
            this.CancelButton = this.btnCancel;
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnOK );
            this.Controls.Add( this.fpData );
            this.Controls.Add( this.txtQueryCode );
            this.Controls.Add( this.chbMisty );
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.KeyPreview = true;
            this.Name = "frmEasyChoose";
            this.Activated += new System.EventHandler( this.frmEasyChoose_Activated );
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.frmEasyChoose_FormClosed );
            ((System.ComponentModel.ISupportInitialize)(this.fpData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpData_Sheet1)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e) {
			this.GetItem();
		}


		private void btnCancel_Click(object sender, System.EventArgs e) {
            //liuke 20091026 del start
            //if (this.SelectedItem != null)
            //{
            //    SelectedItem(this.myObject);
            //}
            //liuke 20091026 del end

			this.Close();
		}


		private void txtQueryCode_TextChanged(object sender, System.EventArgs e) {
			this.ChangeItem();
		}


		private void txtQueryCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
			//回车选择项目
			if(e.KeyChar == (char)13) {
				this.GetItem();
				return;
			}
			else if(e.KeyChar == (char)27) {
				this.Close();
				return;
			}
		}


		private void txtQueryCode_KeyDown(object sender,System.Windows.Forms.KeyEventArgs e) {
			//上箭头选择上一条记录
			if(e.KeyCode == Keys.Up) {
				if (this.fpData_Sheet1.ActiveRowIndex > 0) {
					this.fpData_Sheet1.ActiveRowIndex--;
                    this.fpData.ShowRow(0, this.fpData_Sheet1.ActiveRowIndex, FarPoint.Win.Spread.VerticalPosition.Nearest);
					return;
				}
			}

			//下箭头选择下一条记录
			if(e.KeyCode == Keys.Down) {
				if (this.fpData_Sheet1.ActiveRowIndex < this.fpData_Sheet1.RowCount) {
					this.fpData_Sheet1.ActiveRowIndex++;
                    this.fpData.ShowRow(this.fpData.ActiveSheetIndex, this.fpData_Sheet1.ActiveRowIndex, FarPoint.Win.Spread.VerticalPosition.Nearest);
					return;
				}
			}
		}


		private void chbMisty_CheckedChanged(object sender, System.EventArgs e) {
			this.txtQueryCode.Focus();
		}


		private void fpData_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e) {
			this.GetItem();
		}


		private void fpData_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
			//回车选择项目
			if(e.KeyChar == (char)13) {
				this.GetItem();
				return;
			}
		}

		private void frmEasyChoose_Activated(object sender, System.EventArgs e)
		{
			this.txtQueryCode.Focus();
			this.txtQueryCode.SelectAll();
		}

        private void chbMisty_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void chbMisty_CheckedChanged_2(object sender, EventArgs e)
        {
            this.ChangeItem();
        }

        private void frmEasyChoose_FormClosed(object sender, FormClosedEventArgs e)
        {
            //liuke 20091026 del start
            //if (SelectedItem != null)
            //{
            //    SelectedItem(this.myObject);
            //}
            //liuke 20091026 del end
        }

        protected override void OnLoad(EventArgs e)
        {
            this.btnOK.Text = Neusoft.FrameWork.Management.Language.Msg( "确定" ) + "(&O)";
            this.btnCancel.Text = Neusoft.FrameWork.Management.Language.Msg( "取消" ) + "(&C)";
            this.Text = Neusoft.FrameWork.Management.Language.Msg( "检索数据" );

            base.OnLoad( e );
        }

	}
}
