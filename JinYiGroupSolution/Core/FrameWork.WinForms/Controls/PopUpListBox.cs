using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// ListBox 的摘要说明。
	/// </summary>
	public class PopUpListBox  : System.Windows.Forms.ListBox,IFpInputable
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components=null;

		public PopUpListBox()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			
			// TODO: 在 InitializeComponent 调用后添加任何初始化
			Init();
			base.KeyDown+=new KeyEventHandler(ListBox_KeyDown);
			base.Click+=new EventHandler(ListBox_Click);

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
			components = new System.ComponentModel.Container();
		}
		#endregion

		private ArrayList alItems=new ArrayList();
		private DataSet dsItems=new DataSet();
        private bool showID = true;
        private bool selectNone = false; 
		private int Spell=0;
		/// <summary>
		/// 设置输入法
		/// </summary>
		public int InputCode
		{
			get{return Spell;}
			set
			{
				Spell=value;
				if(Spell>3||Spell<0)Spell=0;
			}
		}
        private bool omitFilter = true;
        /// <summary>
        /// 是否模糊查询
        /// </summary>
        public bool OmitFilter
        {
            set
            {
                omitFilter = true;
            }
            get
            {
                return omitFilter;
            }
        }
		/// <summary>
		/// 所有的数据，原来的alItems
		/// </summary>
		public ArrayList Items
		{
			get
			{
				return this.alItems;
			}
			set
			{
				this.alItems = value;
			}
		}
        #region  设置当输入的文字为""时 ,默认不选中任何项
        public bool SelectNone
        {
            get
            {
                return selectNone;
            }
            set
            {
                selectNone = value;
            }
        }
        #endregion
        /// <summary>
        /// 是否显示代码
        /// </summary>
        public bool IsShowID
        {
            get { return showID; }
            set { showID = value; }
        }
		public delegate int MyDelegate(Keys key);
		public event MyDelegate SelectItem;
		public new event System.EventHandler SelectedItem;
		/// <summary>
		/// 初始化
		/// </summary>
		/// <returns></returns>
		private int Init()
		{
			dsItems.Tables.Add("items");
			dsItems.Tables["items"].Columns.AddRange(new DataColumn[]
				{
					new DataColumn("ID",Type.GetType("System.String")),//ID
					new DataColumn("Name",Type.GetType("System.String")),//名称
					new DataColumn("spell_code",Type.GetType("System.String")),//拼音码
					new DataColumn("input_code",Type.GetType("System.String")),//输入码
					new DataColumn("wb_code",Type.GetType("System.String"))//五笔码
				});
			dsItems.CaseSensitive=false;
			return 1;
		}
		/// <summary>
		/// 添加项目列表
		/// </summary>
		/// <param name="Items"></param>
		/// <returns></returns>
		public int AddItems(ArrayList Items)
		{
			base.Items.Clear();

			alItems=Items;
			dsItems.Tables["items"].Rows.Clear();
			Neusoft.FrameWork.Models.NeuObject objItem;
			Neusoft.HISFC.Models.Base.ISpell objspell;
			
			try
			{
				for(int i=0;i<alItems.Count;i++)
				{
					objItem=new Neusoft.FrameWork.Models.NeuObject();
					objItem=(Neusoft.FrameWork.Models.NeuObject)alItems[i];
                    if (objItem.GetType().GetInterface("ISpell", true) != null)
                    {
                        objspell = (Neusoft.HISFC.Models.Base.ISpell)objItem;
                        base.Items.Add(objItem.ID + ". " + objItem.Name);
                        dsItems.Tables["items"].Rows.Add(new object[]{
																	 objItem.ID,objItem.Name,objspell.SpellCode,
																	 objspell.UserCode,objspell.WBCode});
                    }
                    else 
                    {
                        base.Items.Add(objItem.ID + ". " + objItem.Name);
                        dsItems.Tables["items"].Rows.Add(new object[]{
																	 objItem.ID,objItem.Name,objItem.ID,
																	 objItem.Name,objItem.ID});	
                    }
									
				}
			}
			catch(Exception error)
			{
				MessageBox.Show("添加项目列表出错!"+error.Message,"ListBox");
				return -1;
			}
			return 1;
		}
		/// <summary>
		/// 过滤项目
		/// </summary>
		/// <param name="where"></param>
		/// <returns></returns>
		public int Filter(string where)
		{
			DataView _dv=new DataView(dsItems.Tables["items"]);
            if (Spell == 0)
            {
                if (omitFilter)
                {
                    _dv.RowFilter = "(ID like '%" + where + "%') or (Name like '%" + where + "%') or (spell_code like '%" + where + "%')";
                }
                else
                {
                    _dv.RowFilter = "(ID like '" + where + "%') or (Name like '" + where + "%') or (spell_code like '" + where + "%')";
                }
            }
            else if (Spell == 1)
            {
                if (omitFilter)
                {
                    _dv.RowFilter = "(ID like '%" + where + "%') or (Name like '%" + where + "%') or (input_code like '%" + where + "%')";
                }
                else
                {
                    _dv.RowFilter = "(ID like '" + where + "%') or (Name like '" + where + "%') or (input_code like '" + where + "%')";
                }
            }
            else if (Spell == 2)
            {
                if (omitFilter)
                {
                    _dv.RowFilter = "(ID like '%" + where + "%') or (Name like '%" + where + "%') or (wb_code like '%" + where + "%')";
                }
                else
                {
                    _dv.RowFilter = "(ID like '" + where + "%') or (Name like '" + where + "%') or (wb_code like '" + where + "%')";
                }
            }
            else
            {
                if (omitFilter)
                {
                    _dv.RowFilter = "(ID like '%" + where + "%') or (Name like '%" + where + "%') or (wb_code like '%" + where + "%') or (input_code like '%" + where + "%') or (spell_code like '%" + where + "%')";
                }
                else
                {
                    _dv.RowFilter = "(ID like '" + where + "%') or (Name like '" + where + "%') or (wb_code like '" + where + "%') or (input_code like '" + where + "%') or (spell_code like '" + where + "%')";
                }
            }
            			
			base.Items.Clear();
			for(int i=0;i<_dv.Count;i++)
			{
				DataRowView _row=_dv[i];
				base.Items.Add(_row["ID"].ToString()+". "+_row["Name"].ToString());
			}
			if(base.Items.Count>0)
				base.SelectedIndex=0;

			return 1;
		}
		/// <summary>
		/// 移动下一行
		/// </summary>
		/// <returns></returns>
		public int NextRow()
		{
			int index=base.SelectedIndex;
			if(index>=base.Items.Count-1)return 1;

			base.SelectedIndex=index+1;
			return 1;
		}
		/// <summary>
		/// 移动上一行
		/// </summary>
		/// <returns></returns>
		public int PriorRow()
		{
			int index=base.SelectedIndex;
			if(index<=0)return 1;

			base.SelectedIndex=index -1;
			return 1;
		}
		/// <summary>
		/// 切换输入法
		/// </summary>
		/// <returns></returns>
		public int SetInputMode()
		{
			Spell++;
			if(Spell>2)Spell=0;
			return 1;
		}
		/// <summary>
		/// 获得选中项
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int GetSelectedItem(out Neusoft.FrameWork.Models.NeuObject item)
		{
			int index=base.SelectedIndex;
			if(index<0||index>base.Items.Count-1)
			{
				item=new Neusoft.FrameWork.Models.NeuObject();
				return -1;
			}
			
			//获得ID
			string itemname=base.SelectedItem.ToString();
			string ID=itemname.Substring(0,itemname.IndexOf(". ",0));
			for(int i=0;i<alItems.Count;i++)
			{
				Neusoft.FrameWork.Models.NeuObject obj=(Neusoft.FrameWork.Models.NeuObject)alItems[i];
				if(obj.ID==ID)
				{
					item=obj.Clone();
					return 1;
				}
			}
			item=new Neusoft.FrameWork.Models.NeuObject();
			return -1;
		}

		private void ListBox_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(SelectItem!=null)
					SelectItem(Keys.Enter);
				if(SelectedItem!=null)
					SelectedItem(this.GetSelectedItem(),e);
			}
		}

		private void ListBox_Click(object sender, EventArgs e)
		{
			if(SelectItem!=null)
				SelectItem(Keys.Enter);
		}
		
		#region IFpInputable 成员
		/// <summary>
		/// 下移
		/// </summary>
		public void MoveNext()
		{
			// TODO:  添加 PopUpListBox.MoveNext 实现
			this.NextRow();
		}
		/// <summary>
		/// 上移
		/// </summary>
		public void MovePrevious()
		{
			// TODO:  添加 PopUpListBox.MovePrevious 实现
			this.PriorRow();
		}
		/// <summary>
		/// 下页
		/// </summary>
		public void NextPage()
		{
			// TODO:  添加 PopUpListBox.NextPage 实现
			
		}
		/// <summary>
		/// 上页
		/// </summary>
		public void PreviousPage()
		{
			// TODO:  添加 PopUpListBox.PreviousPage 实现
		}
		/// <summary>
		/// 获得当前行
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		public object GetRow(int row)
		{
			// TODO:  添加 PopUpListBox.GetRow 实现
			if(row >= this.alItems.Count) 
				return null;
			else
				return this.alItems[row];
		}
		/// <summary>
		/// 过滤
		/// </summary>
		/// <param name="filter"></param>
		void Neusoft.FrameWork.WinForms.Controls.IFpInputable.Filter(string filter)
		{
			// TODO:  添加 PopUpListBox.Neusoft.FrameWork.WinForms.Controls.IFpInputable.Filter 实现
			this.Filter(filter);
		}
		/// <summary>
		/// 变化输入法
		/// </summary>
		public void ChangeInput()
		{
			// TODO:  添加 PopUpListBox.ChangeInput 实现
			this.SetInputMode();
		}
		/// <summary>
		/// 获得项目
		/// </summary>
		public object GetSelectedItem()
		{
			// TODO:  添加 PopUpListBox.ChangeInput 实现
			Neusoft.FrameWork.Models.NeuObject obj = null;
			this.GetSelectedItem(out obj);
			return obj;
		}
		#endregion
	}
}
