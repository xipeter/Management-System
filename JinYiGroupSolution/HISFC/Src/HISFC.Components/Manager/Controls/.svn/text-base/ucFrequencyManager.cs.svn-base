using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Manager.Controls
{
    /// <summary>
    /// [功能描述: 频次维护]<br></br>
    /// [创 建 者: 薛占广]<br></br>
    /// [创建时间: 2006－12－18]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucFrequencyManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {   
        public ucFrequencyManager()
        {
            InitializeComponent();
        }
        #region 变量

        //验证错误选择行数
        int RowIndex;
        
        //科室编码
        private string deptCode = "ROOT";
        //定义频次管理类
        private Neusoft.HISFC.BizLogic.Manager.Frequency manager = new Neusoft.HISFC.BizLogic.Manager.Frequency();
        FarPoint.Win.Spread.CellType.ComboBoxCellType comboBox;
        ArrayList alUsage;
        //删除列表
        ArrayList delAl = new ArrayList();
        //定义数据集
        DataSet constantData = new DataSet();
        #endregion

        #region 属性
        /// <summary>
        /// 科室编码
        /// </summary>
        public string DeptCode
        {
            get 
            {
                return this.deptCode;
            }
            set
            {
                this.deptCode = value;
            }
        }
        #endregion

        #region 工具栏

        #region 定义工具栏

        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        
        #endregion

        #region 初始化工具栏
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("添加", "添加", 0, true, false, null);
            toolBarService.AddToolButton("删除", "删除", 1, true, false, null);
            
            return toolBarService;
        }
        #endregion

        #region 工具栏按钮对应调用方法
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            { 
                case "添加":
                    Add();
                    break;
                case "删除":
                    Del();
                    break;
                default:
                    break;
             
            }
            base.ToolStrip_ItemClicked(sender, e);
        }
        #endregion

        #region 重写工具栏按钮功能
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Save(object sender, object neuObject)
        {
            Save();
            return base.Save(sender, neuObject);
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Export(object sender, object neuObject)
        {
            ExportInfo();
            return base.Export(sender, neuObject);
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Print(object sender, object neuObject)
        {
            PrintInfo();
            return base.Print(sender, neuObject);
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Exit(object sender, object neuObject)
        {
            return base.Exit(sender, neuObject);
        }

        #endregion

        #endregion
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucFrequencyManager_Load(object sender, EventArgs e)
        {
            try
            {   
                //初始化
                Initialize();   
                //设置FarPoint样式
                SetFarPointStyle();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }

        }

        #region 方法
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
           //初始化comboxCellType
            //参数管理类
            Neusoft.HISFC.BizLogic.Manager.Constant constant = new Neusoft.HISFC.BizLogic.Manager.Constant();
            alUsage = constant.GetList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE);
            string [] s=new string[alUsage.Count+1];
            s[0] = "全部";            
            for (int i = 0; i < alUsage.Count; i++)
            {
                s[i + 1] = ((Neusoft.FrameWork.Models.NeuObject)alUsage[i]).Name;
            }
            try
            {
                comboBox = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                comboBox.Items = s;

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
            ;
            constantData = InitialDataSet();//初始化数据集
            //根据科室编码填充数据到数据集
            LoadData(this.DeptCode); 
            this.neuSpread1_Sheet1.DataSource = constantData;
            this.neuSpread1_Sheet1.SelectionBackColor = Color.YellowGreen;
            this.neuSpread1_Sheet1.Columns[-1].AllowAutoSort = true;//是否自动排序
            this.neuSpread1_Sheet1.Columns[2].Visible = false;//用法编码隐藏
            this.neuSpread1_Sheet1.Columns[3].CellType = comboBox;//用法名称       
                
            FarPoint.Win.Spread.CellType.TextCellType t = new FarPoint.Win.Spread.CellType.TextCellType();
            t.SubEditor = new ucFrequencyTimeEdit();
            this.neuSpread1_Sheet1.Columns[4].CellType = t;
           
        }
        /// <summary>
        /// 设置FarPoint样式
        /// </summary>
        private void SetFarPointStyle()
        {
            FarPoint.Win.Spread.CellType.TextCellType t = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuSpread1_Sheet1.Columns[0].CellType = t;
            t.MaxLength = 6;
            this.neuSpread1_Sheet1.Columns[0].Width = 50;

            FarPoint.Win.Spread.CellType.TextCellType t1 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuSpread1_Sheet1.Columns[1].CellType = t1;
            t1.MaxLength = 20;
            this.neuSpread1_Sheet1.Columns[1].Width = 80;

            this.neuSpread1_Sheet1.Columns[3].CellType = comboBox;
            this.neuSpread1_Sheet1.Columns[3].Width = 80;
            
            FarPoint.Win.Spread.CellType.TextCellType t2 = new FarPoint.Win.Spread.CellType.TextCellType();
            t2.SubEditor = new ucFrequencyTimeEdit();
            this.neuSpread1_Sheet1.Columns[4].CellType = t2;
            this.neuSpread1_Sheet1.Columns[4].Width = 800;

            FarPoint.Win.Spread.CellType.NumberCellType t3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.neuSpread1_Sheet1.Columns[5].CellType = t3;
            this.neuSpread1_Sheet1.Columns[5].Width = 80;         
        }

        /// <summary>
        /// 初始化数据集
        /// </summary>
        /// <returns></returns>
        private DataSet InitialDataSet()
        {
            try
            {   
                //声明数据集
                DataSet ds = new DataSet();
                //定义DataTable
                DataTable dataTable = new DataTable("constant");
                //定义DataTable列
                //编码
                DataColumn dataColumn1 = new DataColumn("Code");
                dataColumn1.DataType = typeof(System.String);
                dataTable.Columns.Add(dataColumn1);
                //名称
                DataColumn dataColumn2 = new DataColumn("Name");
                dataColumn2.DataType = typeof(System.String); ;
                dataTable.Columns.Add(dataColumn2);
                //使用编码
                DataColumn dataColumn3 = new DataColumn("Usage");
                dataColumn3.DataType = typeof(System.String);
                dataTable.Columns.Add(dataColumn3);
                //使用名称
                DataColumn dataColumn4 = new DataColumn("Usname");
                dataColumn4.DataType = typeof(System.String);
                dataTable.Columns.Add(dataColumn4);
                //时间点
                DataColumn dataColumn5 = new DataColumn("FrequencyTime");
                dataColumn5.DataType = typeof(System.String);
                dataTable.Columns.Add(dataColumn5);

                DataColumn dataColumn6 = new DataColumn("SortId");
                dataColumn6.DataType = typeof(System.Int32);
                dataTable.Columns.Add(dataColumn6);

                if (this.DeptCode != "ROOT")
                {
                    dataTable.Constraints.Add("PK_A", new DataColumn[] { dataColumn1, dataColumn3 }, true);
                }
                ds.Tables.Add(dataTable);
                return ds;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="DeptCode"></param>
        private void LoadData(string DeptCode)
        {   
            //如果数据集为空则加载
            if (constantData == null)
                constantData = InitialDataSet();
            DataTable table = constantData.Tables[0];
            //如果Datatalbe为空
            if (table != null)
            {
                if (table.Rows.Count > 0)
                    table.Rows.Clear();
                ArrayList list = null;
                try
                {
                    list = manager.GetList(DeptCode);
                    if (list == null) return;
                    //获得科室的频次
                    if (list.Count > 0)
                    {
                        AddConstsToTable(list, table);
                        constantData.AcceptChanges();                        
                    }                    
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            FarPoint.Win.Spread.CellType.TextCellType t = new FarPoint.Win.Spread.CellType.TextCellType();
            t.SubEditor = new ucFrequencyTimeEdit();
            this.neuSpread1_Sheet1.Columns[4].CellType = t;

            this.neuSpread1_Sheet1.Columns[3].CellType = comboBox;//用法Name
            this.neuSpread1_Sheet1.Columns[-1].AllowAutoSort = true;
            
        }

        /// <summary>
        /// 将传入的ArrayList中的医嘱频次信息添加到到DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <param name="table"></param>
        private void AddConstsToTable(ArrayList list, DataTable table)
        {
            table.Clear();

            foreach (Neusoft.HISFC.Models.Order.Frequency cons in list)
            {
                table.Rows.Add(new Object[] { cons.ID, cons.Name, cons.Usage.ID, cons.Usage.Name, cons.Time, cons.SortID });//,cons.OperatorCode ;
            }
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <returns></returns>
        private int Add()
        {
            try
            {
                int RowCount = this.neuSpread1_Sheet1.Rows.Count;
                this.neuSpread1_Sheet1.Rows.Add(RowCount, 1);
                this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.Rows.Count;
                neuSpread1.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center);
                this.neuSpread1_Sheet1.Cells[RowCount, 0].Locked = false;
                this.neuSpread1_Sheet1.Cells[RowCount, 3].Locked = false;
                this.neuSpread1_Sheet1.SetActiveCell(RowCount, 0);

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
            return 0;
        }
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <returns></returns>
        private int Del()
        {
            if (this.constantData.Tables[0].Rows.Count <= 0)
                return 0;
            int index = this.neuSpread1_Sheet1.ActiveRowIndex;
            if (index < 0) return 0;

            //将当前删除行转换成对象实体
            Neusoft.HISFC.Models.Order.Frequency frequency = GetObjFromRow(index);
            int returnvalue = manager.ExistFrequencyCounts(frequency);

            if (returnvalue >= 1)
            {
                MessageBox.Show("该频次已经使用,不能删除");
                return -1;
            }


            if (MessageBox.Show("确认删除" + this.neuSpread1_Sheet1.Cells[index, 0].Text + "?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ////将当前删除行转换成对象实体
                //Neusoft.HISFC.Models.Order.Frequency frequency = GetObjFromRow(index);
                //if (frequency.ID.Trim() != "" && frequency.ID != string.Empty)
                //{
                //    int returnvalue = manager.ExistFrequencyCounts(frequency);
                    //if (returnvalue == 0)
                    //{
                delAl.Add(frequency);
                this.neuSpread1_Sheet1.Rows[index].Remove();
                    //}

                    //if (returnvalue >= 1)
                    //{
                    //    MessageBox.Show("该频次已经使用,不能删除");
                    //    return -1;
                    //}


                //}
            }
            return 0;
        }
        /// <summary>
        /// 根据传入行数返回对应实体
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Order.Frequency GetObjFromRow(int i)
        {
            Neusoft.HISFC.Models.Order.Frequency f = new Neusoft.HISFC.Models.Order.Frequency();
            f.ID = this.neuSpread1_Sheet1.Cells[i, 0].Text;//频次编码
            f.Name = this.neuSpread1_Sheet1.Cells[i, 1].Text;//频次名称
            f.Usage.ID = this.neuSpread1_Sheet1.Cells[i, 2].Text;//使用编码
            f.Usage.Name = this.neuSpread1_Sheet1.Cells[i, 3].Text;//使用名称
            f.Time = this.neuSpread1_Sheet1.Cells[i, 4].Text;//使用时间
            f.Dept.ID = this.DeptCode;

            /*
             * [2007/01/31] 原来没有检察.
             * 
             * decimal a = Convert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 5].Text);
             * f.SortID = (int)a;
             * 
             */
            //类型为文本型,所以如果输入的是非数字,那么按0处理
            try
            {
                decimal a = Convert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 5].Text);
                f.SortID = (int)a;
            }
            catch
            {
                f.SortID = 0;
            }

            return f;
        }      
        /// <summary>
        /// 导出
        /// </summary>
        private void ExportInfo()
        {
            bool tr = false;
            string fileName = "";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "excel|*.xls";
            saveFile.Title = "导出到Excel";

            saveFile.FileName = "频次维护 " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Replace(':', '-');

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (saveFile.FileName.Trim() != "")
                {
                    fileName = saveFile.FileName;
                    tr = this.neuSpread1.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                }
                else
                {
                    MessageBox.Show("文件名不能为空!");
                    return;
                }

                if (tr)
                {
                    MessageBox.Show("导出成功!");
                }
                else
                {
                    MessageBox.Show("导出失败!");
                }
            }
        }
        
        /// <summary>
        /// 打印
        /// </summary>
        private void PrintInfo()
        {
            Neusoft.FrameWork.WinForms.Classes.Print pr = new Neusoft.FrameWork.WinForms.Classes.Print();
            pr.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
            //pr.ShowPrintPageDialog();
            pr.PrintPreview(this.neuPanel1);

          
    
        }

        /// <summary>
        /// 获得当前所有行中对应的对象
        /// </summary>
        /// <returns></returns>
        private ArrayList AddRowDataToObj()
        {
            ArrayList al = new ArrayList();
            try
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    Neusoft.HISFC.Models.Order.Frequency frequency = new Neusoft.HISFC.Models.Order.Frequency();
                    frequency.ID = this.neuSpread1_Sheet1.Cells[i, 0].Text;
                    frequency.Name = this.neuSpread1_Sheet1.Cells[i, 1].Text;
                    frequency.Usage.ID = this.neuSpread1_Sheet1.Cells[i, 2].Text;
                    frequency.Usage.Name = this.neuSpread1_Sheet1.Cells[i, 3].Text;
                    frequency.Time = this.neuSpread1_Sheet1.Cells[i, 4].Text;
                    frequency.Dept.ID = this.DeptCode;

                    /* [2007/01/31] 没有类型检查
                     * 
                     * decimal temp= Convert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 5].Text);
                     * 
                     */
                    try
                    {
                        decimal temp = Convert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 5].Text);
                        frequency.SortID = (int)temp;
                    }
                    catch
                    {
                        frequency.SortID = 0;
                    }
                   
                    al.Add(frequency);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
            return al;
        
        }        

        /// <summary>
        /// 保存方法
        /// </summary>
        private int Save()
        {
            string msgErr = string.Empty;
            this.neuSpread1.StopCellEditing();
            if (ValidData() == -1)
            {
                this.neuSpread1_Sheet1.SetActiveCell(RowIndex, 0);
                return -1;
            }
             ArrayList al = AddRowDataToObj();
             if (al == null) return -1;
             //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(manager.Connection);
             try
              { //事务开始

                  Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                 //trans.BeginTransaction();
                  manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                 //删除
                 foreach (Neusoft.HISFC.Models.Order.Frequency f in delAl)
                 {
                     if (manager.Del(f) == -1)
                     {
                         msgErr = Neusoft.FrameWork.Management.PublicTrans.Err;
                         Neusoft.FrameWork.Management.PublicTrans.RollBack();
                         MessageBox.Show("删除失败！" + msgErr);
                         return -1;
                     }
                 }
                 //添加修改
                 foreach (Neusoft.HISFC.Models.Order.Frequency fre in al)
                 {
                     if (manager.Set(fre) == -1)
                     {
                         msgErr = Neusoft.FrameWork.Management.PublicTrans.Err;
                         Neusoft.FrameWork.Management.PublicTrans.RollBack();
                         MessageBox.Show("保存失败！" + msgErr);
                         return -1;
                     }
                 }
                 Neusoft.FrameWork.Management.PublicTrans.Commit();
                 for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                 {
                     if (!this.neuSpread1_Sheet1.Cells[i, 0].Locked)
                         this.neuSpread1_Sheet1.Cells[i, 0].Locked = true;
                     if (!this.neuSpread1_Sheet1.Cells[i, 3].Locked)
                         this.neuSpread1_Sheet1.Cells[i, 3].Locked = true;
                 }
		      }
		     catch(Exception a)
		     {
                 Neusoft.FrameWork.Management.PublicTrans.RollBack();
			    MessageBox.Show("数据保存失败！"+a.Message,"失败",MessageBoxButtons.OK,MessageBoxIcon.Error);
			    return -1;
    			
		     }
           
             //Initialize();
             //SetFarPointStyle();
            MessageBox.Show("保存成功!");
            delAl.Clear();
            return 0;

         }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        private int ValidData()
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                string temp = this.neuSpread1_Sheet1.GetText(i, 0).ToString();
                if (temp.Trim() == "")
                {
                    MessageBox.Show("第" + (i + 1).ToString() + "频次编码不能为空！");
                    RowIndex = i;
                    return -1;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(temp,6))
                {
                    MessageBox.Show("第" + (i + 1).ToString() + "频次编码过长！");
                    RowIndex = i;
                    return -1;
                }

                /*
                 * [2007/01/31] 这个地方可能要加入对频次名称的检察
                 *              但是测试人员并没有说
                 * 
                 */

                string temp2=this.neuSpread1_Sheet1.GetText(i,3).ToString();
                if (temp2.Trim() == "")
                {
                    MessageBox.Show("第" + (i + 1).ToString() + "用法名称不能为空！");
                    RowIndex = i;
                    return -1;
                }
                string temp3 = this.neuSpread1_Sheet1.GetText(i, 4).ToString();
                if (temp3.Trim() == "")
                {
                    MessageBox.Show("第" + (i + 1).ToString() + "时间点不能为空！");
                    RowIndex = i;
                    return -1;
                }

                if (!this.IsTime(temp3))
                {
                    MessageBox.Show("第" + (i + 1).ToString() + "时间点不是有效的时间格式！");
                    RowIndex = i;
                    return -1;
                }

                string temp4 = this.neuSpread1_Sheet1.GetText(i, 1).ToString();
                if (temp4.Trim() == "")
                {
                    MessageBox.Show("第"+(i + 1).ToString()+"行名称不能为空");
                    RowIndex = i;
                    return -1;
                }
            }

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count - 1; i++)
                {
                    for (int k = i + 1; k < this.neuSpread1_Sheet1.Rows.Count; k++)
                    { 
                        if(this.neuSpread1_Sheet1.Cells[i,0].Text==this.neuSpread1_Sheet1.Cells[k,0].Text && 
                            this.neuSpread1_Sheet1.Cells[i,2].Text==this.neuSpread1_Sheet1.Cells[k,2].Text)
                        {
                            MessageBox.Show("第"+(i+1).ToString()+"与"+"第"+(k+1).ToString()+"数据重复！");
                            return -1;
                        }
                    }
                }

            return 0;
        }
        /// <summary>
        /// 根据传入名称获得用法编码
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private string GetUsageCode(string Name)
        {
            if (Name == "全部") return "All";
            for (int i = 0; i < alUsage.Count; i++)
            {
                if (((Neusoft.FrameWork.Models.NeuObject)alUsage[i]).Name == Name)
                    return ((Neusoft.FrameWork.Models.NeuObject)alUsage[i]).ID;
            }
            return "";
        }
        #endregion  
           
        #region 事件
        private void neuSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            
            try
            {
                if (e.Column == 0)
                {
                    Neusoft.HISFC.Models.Order.Frequency f = new Neusoft.HISFC.Models.Order.Frequency();
                    try
                    {
                        f.ID = this.neuSpread1_Sheet1.Cells[e.Row, e.Column].Text;
                        if (f.Name != "") this.neuSpread1_Sheet1.Cells[e.Row, 1].Text = f.Name;
                    }
                    catch { }
                }
                else if (e.Column == 3)
                {
                    //更新用法ID
                    this.neuSpread1_Sheet1.Cells[e.Row, e.Column - 1].Text = GetUsageCode(this.neuSpread1_Sheet1.Cells[e.Row, e.Column].Text);

                }
            }
            catch { }

        }
        #endregion

        //================================================================
        //修改人：路志鹏
        //时间：2007-4-10
        //目的：判断时间点是否是有效的时间格式

        #region 检验时间
        /// <summary>
        /// 检验时间
        /// </summary>
        /// <param name="timeStr">时间字符串</param>
        /// <returns></returns>
        private bool IsTime(string timeStr)
        {
            bool bl = true;
            if (timeStr.IndexOf("-") < 0)
            {
                try
                {
                    Convert.ToDateTime(timeStr);
                    bl= true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                string tempStr;
                int index;
                while ((index = timeStr.IndexOf("-")) > 0)
                {
                    try
                    {
                        tempStr = timeStr.Substring(0, index);
                        Convert.ToDateTime(tempStr);
                        timeStr = timeStr.Remove(0, index + 1);
                        bl = true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                try
                {
                    Convert.ToDateTime(timeStr);
                    bl=true;
                }
                catch
                {

                    return false;
                }
            }
            return bl;
        }
        #endregion
    }
       
}
