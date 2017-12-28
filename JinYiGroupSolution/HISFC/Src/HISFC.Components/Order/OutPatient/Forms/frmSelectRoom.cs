using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.OutPatient.Forms
{
    public partial class frmSelectRoom : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmSelectRoom(ArrayList aldepts)
        {
            InitializeComponent();

            if (aldepts == null)
            {
                aldepts = new ArrayList();
            }

            this.alDepts = aldepts;

            this.Closing += new CancelEventHandler(frmSelectRoom_Closing);
        }


        #region 变量

        
        private Neusoft.HISFC.BizProcess.Integrate.Manager seatMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        
        Neusoft.FrameWork.Public.ObjectHelper helper = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.HISFC.BizLogic.Order.OutPatient.Order orderManager = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();
        public event Neusoft.FrameWork.WinForms.Forms.OKHandler OKEvent;
        public ArrayList alFZDepts;
        private ArrayList alDepts = null;//科室数组
        public string pValue = "";

        #endregion

        private void frmSelectRoom_Load(object sender, System.EventArgs e)
		{
		     this.helper.ArrayObject = alFZDepts;
             this.SetList();
		}
		
		/// <summary>
		/// 显示列表
		/// </summary>
		private void SetList()
		{
			this.neuListBox1.Items.Clear();
			foreach(Neusoft.FrameWork.Models.NeuObject  obj in alDepts)
			{
				try
				{
					if(this.pValue == "1"&&this.helper.GetObjectFromID((this.orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID)!=null)
					{
						ArrayList al = new ArrayList();
                        al = this.seatMgr.QuerySeatByRoomNo(obj.ID);
						if(al.Count <=0)
						{
							continue;
						}
						for(int i=0;i<al.Count;i++)
						{
							Neusoft.FrameWork.Models.NeuObject rObj = al[i] as Neusoft.FrameWork.Models.NeuObject;
							rObj.Name = obj.Name+"--"+rObj.Name;
							this.neuListBox1.Items.Add(rObj);
						}
					}
					else
					{
						this.neuListBox1.Items.Add(obj);
					}
				}
				catch{}
			}
			
			if(this.neuListBox1.Items.Count>0) this.neuListBox1.SelectedIndex =0;
		}

		/// <summary>
		/// 双击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void neuListBox1_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				this.DialogResult = DialogResult.OK;
				OKEvent(sender,(Neusoft.FrameWork.Models.NeuObject)this.neuListBox1.SelectedItem);
			}
			catch{}
		}

		/// <summary>
		/// 确定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.DialogResult = DialogResult.OK;
				OKEvent(sender,(Neusoft.FrameWork.Models.NeuObject)this.neuListBox1.SelectedItem);
			}
			catch{}
		}
		
		/// <summary>
		/// 获得当前房间
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject SelectRoom
		{
			get
			{

				return (Neusoft.FrameWork.Models.NeuObject)this.neuListBox1.SelectedItem;
			}
		}

		/// <summary>
		/// 关闭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmSelectRoom_Closing(object sender, CancelEventArgs e)
		{
			//this.DialogResult = DialogResult.Cancel;
		}
	
    }
}

