using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 附材维护管理]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucSubtblManagement : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private Neusoft.HISFC.BizLogic.Order.AdditionalItem manager = new Neusoft.HISFC.BizLogic.Order.AdditionalItem();
        private ArrayList alDels = new ArrayList();
       
    
        private Neusoft.HISFC.BizProcess.Integrate.Fee itemManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();
   
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("添加", "添加新数据", 5, true, false, null);
            this.toolBarService.AddToolButton("删除", "删除数据", 6, true, false, null);
            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "添加":
                    this.Add();
                    break;
                case "删除":
                    this.Del();
                    break;
                default:
                    break;
            }
            //base.ToolStrip_ItemClicked(sender, e);
        }
        #region toolbar按钮处理函数

        public int Del()
        {
            if (this.neuSpread1_Sheet1.ActiveRowIndex < 0 || this.neuSpread1_Sheet1.RowCount == 0) return 0;

            if (MessageBox.Show("确认删除" + this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text + "吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.alDels.Add(this.neuSpread1_Sheet1.ActiveRow.Tag);
                this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);
            }
            return 0;
        }

        public override int PrintPreview(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.PrintPreview(0, 0, this.neuPanel7);
            return 0;
        }

        public int Add()
        {
            this.ucItem1_SelectedItem(null);
            return 0;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.PrintPage(0, 0, this.neuPanel7);
            return 0;
        }

        public override int Exit(object sender, object neuObject)
        {
            return base.Exit(sender, neuObject);
        }

        public override int Save(object sender, object neuObject)
        {
            if (this.neuListView1.SelectedItems.Count <= 0 && this.neuRadioButton2.Checked)
            {
                return -1;
            }
            if (this.neuListView2.SelectedItems.Count <= 0 && this.neuRadioButton1.Checked)
            {
                return -1;
            }

            this.neuSpread1.StopCellEditing();
            Neusoft.FrameWork.Models.NeuObject o = null;
            bool bIsPharmacy = true;
            try
            {
                if (this.neuRadioButton1.Checked)
                {
                    o = this.neuListView2.SelectedItems[0].Tag as Neusoft.FrameWork.Models.NeuObject;
                    bIsPharmacy = true;
                }
                else
                {
                    o = this.neuListView1.SelectedItems[0].Tag as Neusoft.FrameWork.Models.NeuObject;
                    bIsPharmacy = false;
                }
            }
            catch { return 0; }

            Neusoft.FrameWork.Models.NeuObject dept = this.neuListBox1.SelectedItem as Neusoft.FrameWork.Models.NeuObject;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Base.Item obj = (Neusoft.HISFC.Models.Base.Item)this.neuSpread1_Sheet1.Rows[i].Tag;
                //{24F859D1-3399-4950-A79D-BCCFBEEAB939}
                obj.User03 = neuSpread1_Sheet1.Cells[i, 5].Text;
                if (string.IsNullOrEmpty(obj.User03.Trim()))
                {
                    obj.User03 = "0H";
                }

                if (obj.Qty <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();                    
                    MessageBox.Show("数量不允许为零！");
                    return -1;
                }
                //{24F859D1-3399-4950-A79D-BCCFBEEAB939}
                //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl 增加参数price
                if (this.manager.SetAdditionalItem(obj, dept.ID, bIsPharmacy, o.ID, obj.User03, obj.Price) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.manager.Err);
                    return -1;
                }
            }
            for (int i = 0; i < this.alDels.Count; i++)
            {
                if (this.manager.DeleteAdditionalItem((Neusoft.HISFC.Models.Base.Item)this.alDels[i], dept.ID, bIsPharmacy, o.ID) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.manager.Err);
                    return -1;
                }
            }
            //ADD BY NIUXY

            if (this.alDels.Count == 0 && this.neuSpread1_Sheet1.Rows.Count == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();                
                MessageBox.Show("没有项目无需保存");
                return -1;
            }
            else
            {
                //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl 清空一下删除列表
                this.alDels.Clear();
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("保存成功!");
                return 0;
            }
        }
        public override int Export(object sender, object neuObject)
        {
            SaveFileDialog op = new SaveFileDialog();

            op.Title = "请选择保存的路径和名称";
            op.CheckFileExists = false;
            op.CheckPathExists = true;
            op.DefaultExt = "*.xls";
            op.Filter = "(*.xls)|*.xls";

            DialogResult result = op.ShowDialog();

            if (result == DialogResult.Cancel || op.FileName == string.Empty)
            {
                return -1;
            }

            string filePath = op.FileName;

            this.neuSpread1.SaveExcel(filePath,FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
            return base.Export(sender, neuObject);

        }

        #endregion

        public ucSubtblManagement()
        {
            InitializeComponent();
        }

        private void ucSubtblManagement_Load(object sender, EventArgs e)
        {
            //{24F859D1-3399-4950-A79D-BCCFBEEAB939}
            this.neuSpread1_Sheet1.ColumnCount = 6;
            FarPoint.Win.Spread.CellType.ComboBoxCellType cbxItemType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            cbxItemType.Items = new string[] { " ","24H" };
            this.neuSpread1_Sheet1.Columns[5].CellType = cbxItemType;
            this.neuSpread1_Sheet1.RowCount = 0;
            
            this.neuSpread1_Sheet1.Columns[5].Label = "间隔";     
            
            this.neuSpread1_Sheet1.Columns[0].Label = "项目名称";
            this.neuSpread1_Sheet1.Columns[1].Label = "数量";

            this.neuSpread1_Sheet1.Columns[2].Label = "单位";
                

            try
            {
                this.neuRadioButton1.Checked = true;
                this.InitControl();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
            //Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
            Neusoft.HISFC.BizProcess.Integrate.Manager dept = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.Models.Base.Employee person = null;//.RADT.Person person = null;
            ArrayList al = null;
            if (Neusoft.FrameWork.Management.Connection.Operator != null)  //获得科室
            {
                person = /*dept.Operator*/Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;//.RADT.Person;
                ////F0BF027A-9C8A-4bb7-AA23-26A5F3539586
                ////al = dept.QueryDepartment(person.Nurse.ID);
                ////if (al != null)
                ////{
                ////    for (int i = 0; i < al.Count; i++)
                ////    {
                ////        try
                ////        {
                ////            Neusoft.FrameWork.Models.NeuObject o = al[i] as Neusoft.FrameWork.Models.NeuObject;
                ////            this.neuListBox1.Items.Add(o);
                ////        }
                ////        catch { }
                ////    }
                ////}
                ////this.neuListBox1.Items.Add(person.Dept);//{6442200A-66BF-41c3-9374-C8BBBBBD41C2}
                //this.neuListBox1.Items.Add(person.Nurse);//{6442200A-66BF-41c3-9374-C8BBBBBD41C2}
                //{A4ED7668-8B4C-441f-9A0D-7029EA040B14}
                al = dept.QueryDepartment(person.Nurse.ID);
                if (al == null || al.Count == 0)
                {

                    this.neuListBox1.Items.Add(person.Dept);
                }
                else
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        try
                        {
                            Neusoft.FrameWork.Models.NeuObject o = al[i] as Neusoft.FrameWork.Models.NeuObject;
                            this.neuListBox1.Items.Add(o);
                        }
                        catch { }
                    }
                }
            }

            Neusoft.HISFC.BizProcess.Integrate.Manager f = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            try
            {
                al = f.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE);
            }
            catch { return; }
            //this.neuListView1.Columns.Add("用法", 100, HorizontalAlignment.Center);
            this.neuListView2.Columns.Add("用法", 300, HorizontalAlignment.Center);
            if (al != null)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.FrameWork.Models.NeuObject o = al[i] as Neusoft.FrameWork.Models.NeuObject;
                    ListViewItem lt = new ListViewItem();
                    lt.Tag = o;
                    lt.Text = o.Name;
                    //lt.ImageIndex = 0;
                    //this.neuListView1.Items.Add(lt);
                    this.neuListView2.Items.Add(lt);
                }
            }

            if (this.neuListBox1.Items.Count > 0)
            {
                this.neuListBox1.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("没有维护相关科室或护理站，维护后才能使用该功能");
                return;
            }
            Neusoft.FrameWork.Models.NeuObject objdept = this.neuListBox1.SelectedItem as Neusoft.FrameWork.Models.NeuObject;
            this.InitUndrug(objdept.ID);

            this.neuListView2.View = View.Details;
            this.neuSpread1_Sheet1.Columns[0].Locked = true;
            this.neuSpread1_Sheet1.Columns[2].Locked = true;
            this.neuSpread1_Sheet1.Columns[3].Locked = true;
            this.neuSpread1_Sheet1.Columns[4].Locked = true;
            this.neuSpread1_Sheet1.Columns[0].CellType = new FarPoint.Win.Spread.CellType.TextCellType();

            FarPoint.Win.Spread.CellType.NumberCellType cell = new FarPoint.Win.Spread.CellType.NumberCellType();
            cell.DecimalPlaces = 2;
            cell.MaximumValue = 9999.99;
            cell.MinimumValue = 0.00;


            this.neuSpread1_Sheet1.Columns[1].CellType = cell;
            this.neuSpread1_Sheet1.Columns[3].Label = "单价";
            this.neuSpread1_Sheet1.Columns[4].Label = "总价格";
            this.neuSpread1_Sheet1.Columns[4].CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            this.neuSpread1_Sheet1.Columns[4].Formula = "B1*D1";

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载收费项目列表 请稍侯....");
            Application.DoEvents();

            try
            {
                //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl 取登陆科室的非药品及物资
                this.ucItem1.DeptCode = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
                this.ucItem1.IsIncludeMat = true;
                this.ucItem1.Init();
                this.ucItem2.Init();

                this.neuListView1.HideSelection = false;
                this.neuListView2.HideSelection = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            this.ucItem2.SelectedItem += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(ucItem2_SelectedItem);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deptCode"></param>
        private void InitUndrug(string deptCode)
        {
            #region 初始化非药品
            //this.neuListView2.Items.Clear();
            this.neuListView1.View = View.Details;
            this.neuListView1.Columns.Add("", 200, HorizontalAlignment.Center);
            this.neuListView1.Items.Clear();
            ArrayList al = manager.QueryAdditionalItem(false, deptCode);
            if (al != null)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.FrameWork.Models.NeuObject o = al[i] as Neusoft.FrameWork.Models.NeuObject;
                    ListViewItem lt = new ListViewItem();
                    lt.Tag = o;
                    lt.Text = o.Name;
                    //lt.ImageIndex = 0;
                    //this.neuListView2.Items.Add(lt);
                    this.neuListView1.Items.Add(lt);
                }
            }

            #endregion
        }

        private void ucItem2_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
        {
            foreach (ListViewItem item in this.neuListView1.Items)
            {
                if ((Neusoft.FrameWork.Models.NeuObject)item.Tag == this.ucItem2.FeeItem) return;
            }
            ListViewItem lt = new ListViewItem();
            lt.Tag = this.ucItem2.FeeItem;
            lt.Text = this.ucItem2.FeeItem.Name;
            //lt.ImageIndex = 0;
            this.neuListView1.Items.Insert(0, lt);
            this.neuListView1.Items[0].Selected = true;
        }

        private void ucItem1_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
        {
            if (this.ucItem1.FeeItem == null || string.IsNullOrEmpty(this.ucItem1.FeeItem.ID))
            {
                return;
            }
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)//检查是否重复
            {
                Neusoft.HISFC.Models.Base.Item obj = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Base.Item;
                if (obj != null)
                {
                    if (obj.ID == this.ucItem1.FeeItem.ID)
                    {
                        MessageBox.Show(this.ucItem1.FeeItem.Name + "已经存在，请选择其他项目");
                        return;//如果重复 返回
                    }
                }
            }
            this.AddItemToFarpoint(this.ucItem1.FeeItem, 0);
        }

        /// <summary>
        /// 选择项目
        /// </summary>
        //private void ucItem1_SelectedItem()
        //{
        //    if (this.ucItem1.FeeItem == null) return;
        //    for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)//检查是否重复
        //    {
        //        Neusoft.HISFC.Models.Base.Item obj = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Base.Item;
        //        if (obj.ID == this.ucItem1.FeeItem.ID) return;//如果重复 返回
        //    }
        //    this.AddItemToFarpoint(this.ucItem1.FeeItem, 0);
        //}

        /// <summary>
        /// 添加项目到farpoint
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="row"></param>
        private void AddItemToFarpoint(object Item, int row)
        {
            this.neuSpread1_Sheet1.Rows.Add(row, 1);
            if (Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug) || Item.GetType() == typeof(Neusoft.HISFC.Models.Base.Item)
                //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                || Item.GetType() == typeof(Neusoft.HISFC.Models.FeeStuff.MaterialItem))
            {
                Neusoft.HISFC.Models.Base.Item myItem = Item as Neusoft.HISFC.Models.Base.Item;
                //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                //this.neuSpread1_Sheet1.Cells[row, 0].Text = myItem.Name;
                this.neuSpread1_Sheet1.Cells[row, 0].Text = myItem.Name + (string.IsNullOrEmpty(myItem.Specs) ? "" : "[" + myItem.Specs + "]");
                if (myItem.Qty/*.Amount*/ == 0) myItem.Qty/*.Amount*/ = 1;
                this.neuSpread1_Sheet1.Cells[row, 1].Value = myItem.Qty;//.Amount;
                this.neuSpread1_Sheet1.Cells[row, 2].Text = myItem.PriceUnit;
                this.neuSpread1_Sheet1.Cells[row, 3].Value = myItem.Price;
                //{24F859D1-3399-4950-A79D-BCCFBEEAB939}
                this.neuSpread1_Sheet1.Cells[row, 5].Text = myItem.User03;
                this.neuSpread1_Sheet1.Rows[row].Tag = Item;
            }
        }

        /// <summary>
        /// 刷新显示信息
        /// </summary>
        private void RefreshInfo()
        {
            //查询项目信息
            try
            {
                if (this.neuListBox1.Items.Count == 0)
                {
                    return;
                }
                if (this.neuListView1.SelectedItems.Count <= 0 && this.neuRadioButton2.Checked) return;
                if (this.neuListView2.SelectedItems.Count <= 0 && this.neuRadioButton1.Checked) return;


                Neusoft.FrameWork.Models.NeuObject o = null;

                Neusoft.FrameWork.Models.NeuObject dept = this.neuListBox1.SelectedItem as Neusoft.FrameWork.Models.NeuObject;

                ArrayList al = null;

                if (this.neuRadioButton1.Checked)
                {
                    //o = this.neuListView1.SelectedItems[0].Tag as Neusoft.FrameWork.Models.NeuObject;
                    o = this.neuListView2.SelectedItems[0].Tag as Neusoft.FrameWork.Models.NeuObject;
                    al = manager.QueryAdditionalItem(true, o.ID, dept.ID);
                }
                else
                {
                    //o = this.neuListView2.SelectedItems[0].Tag as Neusoft.FrameWork.Models.NeuObject;
                    o = this.neuListView1.SelectedItems[0].Tag as Neusoft.FrameWork.Models.NeuObject;
                    al = manager.QueryAdditionalItem(false, o.ID, dept.ID);
                }

                this.neuSpread1_Sheet1.RowCount = 0;
                for (int i = 0; i < al.Count; i++)
                {
                    //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                    //Neusoft.HISFC.Models.Fee.Item.Undrug item = this.itemManager.GetItem(((Neusoft.FrameWork.Models.NeuObject)al[i]).ID);
                    Neusoft.HISFC.Models.Base.Item item = this.itemManager.GetUndrugAndMatItem(((Neusoft.FrameWork.Models.NeuObject)al[i]).ID, ((Neusoft.HISFC.Models.Base.Item)al[i]).Price);

                    if (item == null)
                    {
                        //MessageBox.Show("获得项目信息出错！" + this.itemManager.Err);
                        continue;
                    }
                    else
                    {
                        ((Neusoft.HISFC.Models.Base.Item)al[i]).Name = item.Name;
                        //((Neusoft.HISFC.Models.Base.Item)al[i]).Amount = item.Amount;
                        ((Neusoft.HISFC.Models.Base.Item)al[i]).Price = item.Price;
                        ((Neusoft.HISFC.Models.Base.Item)al[i]).PriceUnit = item.PriceUnit;
                        //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                        ((Neusoft.HISFC.Models.Base.Item)al[i]).Specs = item.Specs;

                        this.AddItemToFarpoint(al[i], 0);
                    }
                }

                this.alDels.Clear();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            }
        }

        private void neuRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.neuPanel4.Visible = false;
            this.neuListView2.Visible = true;
            this.RefreshInfo();
        }

        private void neuRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.neuPanel4.Visible = true;
            this.neuListView2.Visible = false;
            this.RefreshInfo();
        }

        private void neuListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.Rows.Count);
            }
            //this.neuListView1.SelectedItems[0].Checked = true;
            this.RefreshInfo();
        }

        private void neuListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.neuListView2.SelectedItems.Clear();
            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.Rows.Count);
            }
            //this.neuListView2.SelectedItems[0].Checked = true;
            this.RefreshInfo();

            
 
 
        }

        private void neuListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //查询项目信息
            this.RefreshInfo();
        }

        private void neuSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            if (e.Column == 1)//项目
            {
                if (this.neuSpread1_Sheet1.ActiveRowIndex < 0) return;
                try
                {
                    if (this.neuSpread1_Sheet1.ActiveRow.Tag == null) return;
                    Neusoft.HISFC.Models.Base.Item obj = (Neusoft.HISFC.Models.Base.Item)this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag;
                    obj.Qty/*.Amount*/ = decimal.Parse(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 1].Value.ToString());
                    this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag = obj;
                }
                catch { }
            }
        }
    }
}