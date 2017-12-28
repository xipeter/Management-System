using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Manager
{
    public partial class ucExceBill : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucExceBill()
        {
            InitializeComponent();
        } 
		  
		#region 全局变量 
		//业务层函数 
		Neusoft.HISFC.BizLogic.Order.ExecBill execBill = new Neusoft.HISFC.BizLogic.Order.ExecBill();
		ArrayList ExecBillList = null; //主挡列表 
		#endregion 
		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.ExecBillList = null;
			//删除原有的数据

			if(this.fpSpread1_Sheet1.RowCount >0)
			{
				this.fpSpread1_Sheet1.Rows.Remove(0,this.fpSpread1_Sheet1.Rows.Count);
			}
			if(comboBox1.Tag == null)
			{

				MessageBox.Show("请选择病区");
				return ;
			}
			ExecBillList= execBill.QueryExecBill(this.comboBox1.Tag.ToString());
			if(ExecBillList == null )
			{
				MessageBox.Show("查询执行单出错" + execBill.Err);
				return ;
			}

			foreach(Neusoft.FrameWork.Models.NeuObject obj in ExecBillList)
			{
				this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.Rows.Count,1);
				int i = this.fpSpread1_Sheet1.Rows.Count -1;
				this.fpSpread1_Sheet1.Cells[i,0].Text = obj.Name;
				this.fpSpread1_Sheet1.Cells[i,1].Text = obj.ID;
				this.fpSpread1_Sheet1.Cells[i,0].Tag = obj;
			}
		}

        //private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        //{
        //    if(e.Button == this.toolBarButton1)
        //    {
        //        //保存
        //        SaveInfo();
        //    }
        //    if(e.Button == this.toolBarButton2)
        //    {
        //        //关闭窗口
        //        this.Close();
        //    }
        //}

        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveInfo();

            return base.OnSave(sender, neuObject);
        }

		/// <summary>
		/// 保存数据
		/// </summary>
		private void SaveInfo()
		{
			if(this.comboBox1.Tag == null)
			{
				MessageBox.Show("请选择目标护理站");
				this.comboBox1.Focus();
				return ;
			}
			//科室编码
			string OldDeptCode = this.comboBox1.Tag.ToString(); 
			//执行
			string ExecNo = "";
			ArrayList deptlist = GetDept();
			if(deptlist.Count == 0) 
			{
				//没有需要转化的
				return ;
			}
			if(this.ExecBillList == null)
			{
				MessageBox.Show("请选择原科室");
				this.comboBox1.Focus();
				return ;
			}
			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在转换数据，请稍候...");
			Application.DoEvents();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(execBill.Connection);
            //t.BeginTransaction();
            execBill.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
			try
			{
				foreach(Neusoft.FrameWork.Models.NeuObject obj  in deptlist) //循环科室 
				{
					if(obj.ID == OldDeptCode) //如果目标科室等于原科室 跳过
					{
						continue;
					}
					#region 删除执行单 
					if(execBill.DeleteAllExecBill(obj.ID) == -1) //删除护理站的所有原来的数据
					{
						Neusoft.FrameWork.Management.PublicTrans.RollBack();;
						Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
						MessageBox.Show("删除原有数据失败 : "+ execBill.Err );
						return ;
					}
					#endregion 
				}
				foreach(Neusoft.FrameWork.Models.NeuObject info in ExecBillList) //循环执行档 
				{
                    ////addby xuewj 2009-8-26 执行单管理 单项目维护 {0BB98097-E0BE-4e8c-A619-8B4BCA715001}
                    //ArrayList DetailList = execBill.QueryExecBillDetailByBillNo(info.ID);
                    ArrayList DetailList = execBill.QueryExecBillDetail(info.ID);
					foreach(Neusoft.FrameWork.Models.NeuObject obj  in deptlist) //循环科室 
					{						
						#region 插入主档 
						//Neusoft.FrameWork.Models.neuObject MainObj = (Neusoft.FrameWork.Models.neuObject ) fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex,0].Tag ;
						//ArrayList DetailList = GetDetail();
						if(obj.ID == OldDeptCode) //如果目标科室等于原科室 跳过
						{
							continue;
						}

						if(DetailList.Count == 0)
						{
							continue;
						}
                        //addby xuewj 2009-8-26 执行单管理 单项目维护 {0BB98097-E0BE-4e8c-A619-8B4BCA715001}
						if(execBill.SetExecBillNew(DetailList,info,obj.ID,ref ExecNo) == -1)
						{
							Neusoft.FrameWork.Management.PublicTrans.RollBack();;
							Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
							MessageBox.Show("保存失败" + execBill.Err);
							return ;
						}
						#endregion 
					}
				}
				Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
				Neusoft.FrameWork.Management.PublicTrans.Commit();;
				MessageBox.Show("保存成功");

			}
			catch(Exception ex)
			{
				Neusoft.FrameWork.Management.PublicTrans.RollBack();;
				Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
				MessageBox.Show(ex.Message);
			}
		}
		/// <summary>
		/// 获取需要转化的目标护理站 
		/// </summary>
		/// <returns></returns>
		private ArrayList GetDept()
		{
			ArrayList list = new ArrayList();
			for(int i =0;i < fpDept.RowCount;i++)
			{
				if(this.fpDept.Cells[i,0].Value.ToString().ToUpper() =="TRUE")
				{
					Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
					obj.Name = this.fpDept.Cells[i,1].Text;
					obj.ID = this.fpDept.Cells[i,2].Text;
					list.Add(obj);
				}
			}
			return list;
		}
		private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
//			try
//			{
//				//删除原有的数据

//				if(this.fpSpread2_Sheet1.RowCount >0)
//				{
//					this.fpSpread2_Sheet1.Rows.Remove(0,this.fpSpread2_Sheet1.Rows.Count);
//				}
//				if(this.fpSpread1_Sheet1.RowCount ==0)
//				{
//					return;
//				}
//				ArrayList list = execBill.GetExecBillDetail(this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex,1].Text);
//				if(list == null)
//				{
//					MessageBox.Show("查询执行单明细出错" + execBill.Err);
//					return ;
//				}
//
//				foreach(Neusoft.HISFC.Models.Order.Order  obj in list)
//				{
//					this.fpSpread2_Sheet1.Rows.Add(this.fpSpread2_Sheet1.Rows.Count,1);
//					int i = this.fpSpread2_Sheet1.Rows.Count -1;
//					this.fpSpread2_Sheet1.Cells[i,0].Text = obj.OrderType.Name; //医嘱类型 
//					if(obj.Memo == "1")
//					{
//						this.fpSpread2_Sheet1.Cells[i,1].Text = "药品";
//					}
//					else if(obj.Memo == "2")
//					{
//						this.fpSpread2_Sheet1.Cells[i,1].Text = "非药品"; //药品非药品

//					}
//					this.fpSpread2_Sheet1.Cells[i,2].Text = obj.Item.SysClass.ID.ToString(); //系统类别 
//					this.fpSpread2_Sheet1.Cells[i,3].Text = obj.Usage.Name; //用法
//					this.fpSpread2_Sheet1.Cells[i,0].Tag  = obj;
//				}
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show(ex.Message);
//			}
		}

		private void frmExecBill_Load(object sender, System.EventArgs e)
		{
			Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
			ArrayList deptList = dept.GetNurseAll();
			if(deptList == null)
			{
				MessageBox.Show("获取护理站出错" + dept.Err);
				return ;
			}
			FarPoint.Win.Spread.CellType.CheckBoxCellType cb = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			fpDept.Columns[0].CellType = cb;
			this.comboBox1.AddItems(deptList);
			int i =0;
			foreach(Neusoft.HISFC.Models.Base.Department obj in deptList)
			{
				this.fpDept.Rows.Add(this.fpDept.RowCount,1);
				this.fpDept.Cells[i,0].Value = false;
				this.fpDept.Cells[i,1].Text  = obj.Name;
				this.fpDept.Cells[i,2].Text = obj.ID ;
				i++;
			}
		}
	/// <summary>
	/// 全选 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
		private void checkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.checkAll.Checked)
			{
				for(int i= 0; i<this.fpDept.RowCount;i++)
				{
					this.fpDept.Cells[i,0].Value =true;
				}
			}
			else
			{
				for(int i= 0; i<this.fpDept.RowCount;i++)
				{
					this.fpDept.Cells[i,0].Value =false;
				}
				this.checkAll.Checked = false;
			}
		}
	}
}
