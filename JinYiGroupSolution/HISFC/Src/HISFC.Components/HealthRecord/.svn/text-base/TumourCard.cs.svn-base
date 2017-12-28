using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace UFC.HealthRecord
{
    public partial class TumourCard : UserControl
    {
        public TumourCard()
        {
            InitializeComponent();
        }

        #region  全局变量
        //当前活动下拉列表
        private Neusoft.NFC.Interface.Controls.PopUpListBox listBoxActive = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        //但前活动控件
        private System.Windows.Forms.Control contralActive = new Control();
        private DataTable dtTumour = new DataTable("肿瘤");
        private Neusoft.NFC.Public.ObjectHelper diagnoseTypeHelper = new Neusoft.NFC.Public.ObjectHelper();
        //配置文件的路径 
        private string filePath = Application.StartupPath + "\\profile\\ucTumourCard1.xml";
        //病人基本信息表
        private Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
        //单位列表
        Neusoft.NFC.Public.ObjectHelper UnitListHelper = new Neusoft.NFC.Public.ObjectHelper();
        //疗程列表
        Neusoft.NFC.Public.ObjectHelper PeriodListHelper = new Neusoft.NFC.Public.ObjectHelper();
        //结果列表
        Neusoft.NFC.Public.ObjectHelper ResultListHelper = new Neusoft.NFC.Public.ObjectHelper();
        //放疗方式 
        private Neusoft.NFC.Interface.Controls.PopUpListBox RmodeidListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper RmodeidTypeHelper = new Neusoft.NFC.Public.ObjectHelper();

        //放疗程式 
        private Neusoft.NFC.Interface.Controls.PopUpListBox RprocessidListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper RprocessidTypeHelper = new Neusoft.NFC.Public.ObjectHelper();

        //放疗装置
        private Neusoft.NFC.Interface.Controls.PopUpListBox RdeviceidListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper RdeviceidTypeHelper = new Neusoft.NFC.Public.ObjectHelper();

        //化疗方式
        private Neusoft.NFC.Interface.Controls.PopUpListBox CmodeidListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper CmodeidTypeHelper = new Neusoft.NFC.Public.ObjectHelper();

        //化疗方法
        private Neusoft.NFC.Interface.Controls.PopUpListBox CmethodListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper CmethodTypeHelper = new Neusoft.NFC.Public.ObjectHelper();
        //但前选中的信息
        private Neusoft.NFC.Object.NeuObject selectObj;
        #endregion

        #region 肿瘤主表操作函数
        #region  下拉框的事件
        #region 放疗方式
        private void Rmodeid_Enter(object sender, System.EventArgs e)
        {
            if (Rmodeid.ReadOnly)
            {
                return;
            }
            contralActive = this.Rmodeid;
            listBoxActive = RmodeidListBox;
            ListBoxActiveVisible(true);
        }

        private void Rmodeid_TextChanged(object sender, System.EventArgs e)
        {
            ListFilter();
        }

        private void Rmodeid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Rprocessid.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                listBoxActive.PriorRow();
            }
            else if (e.KeyData == Keys.Down)
            {
                listBoxActive.NextRow();
            }
        }
        #endregion

        #region  放疗程式
        private void Rprocessid_TextChanged(object sender, System.EventArgs e)
        {
            ListFilter();
        }

        private void Rprocessid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Rdeviceid.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                listBoxActive.PriorRow();
            }
            else if (e.KeyData == Keys.Down)
            {
                listBoxActive.NextRow();
            }
        }

        private void Rprocessid_Enter(object sender, System.EventArgs e)
        {
            if (Rprocessid.ReadOnly)
            {
                return;
            }
            contralActive = this.Rprocessid;
            listBoxActive = RprocessidListBox;
            ListBoxActiveVisible(true);
        }
        #endregion

        #region  放疗装置
        private void Rdeviceid_TextChanged(object sender, System.EventArgs e)
        {
            ListFilter();
        }

        private void Rdeviceid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                gy1.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                listBoxActive.PriorRow();
            }
            else if (e.KeyData == Keys.Down)
            {
                listBoxActive.NextRow();
            }
        }

        private void Rdeviceid_Enter(object sender, System.EventArgs e)
        {
            if (Rdeviceid.ReadOnly)
            {
                return;
            }
            contralActive = this.Rdeviceid;
            listBoxActive = RdeviceidListBox;
            ListBoxActiveVisible(true);
        }
        #endregion

        #region  化疗方式
        private void Cmodeid_TextChanged(object sender, System.EventArgs e)
        {
            ListFilter();
        }

        private void Cmodeid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Cmethod.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                listBoxActive.PriorRow();
            }
            else if (e.KeyData == Keys.Down)
            {
                listBoxActive.NextRow();
            }
        }

        private void Cmodeid_Enter(object sender, System.EventArgs e)
        {
            if (Cmodeid.ReadOnly)
            {
                return;
            }
            contralActive = this.Cmodeid;
            listBoxActive = CmodeidListBox;
            ListBoxActiveVisible(true);
        }
        #endregion

        #region 化疗方法
        private void Cmethod_Enter(object sender, System.EventArgs e)
        {
            if (Cmethod.ReadOnly)
            {
                return;
            }
            contralActive = this.Cmethod;
            listBoxActive = CmethodListBox;
            ListBoxActiveVisible(true);
        }

        private void Cmethod_TextChanged(object sender, System.EventArgs e)
        {
            ListFilter();
        }

        private void Cmethod_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (fpEnter1_Sheet1.Rows.Count > 0)
                {
                    this.fpEnter1_Sheet1.SetActiveCell(0, 0);
                }
            }
            else if (e.KeyData == Keys.Up)
            {
                listBoxActive.PriorRow();
            }
            else if (e.KeyData == Keys.Down)
            {
                listBoxActive.NextRow();
            }
        }
        #endregion
        #endregion
        #region keypress事件
        private void gy1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 58)
            {
                e.Handled = true;
            }
        }
        #endregion
        #region 回车事件
        private void gy1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.time1.Focus();
            }
        }

        private void time1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.day1.Focus();
            }
        }

        private void day1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.begin_date1.Focus();
            }
        }

        private void begin_date1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.end_date1.Focus();
            }
        }

        private void end_date1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.gy2.Focus();
            }
        }

        private void gy2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.time2.Focus();
            }
        }

        private void time2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.day2.Focus();
            }
        }

        private void day2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.begin_date2.Focus();
            }
        }

        private void begin_date2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.end_date2.Focus();
            }
        }

        private void end_date2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.gy3.Focus();
            }
        }

        private void gy3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.time3.Focus();
            }
        }

        private void time3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.day3.Focus();
            }
        }

        private void day3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.begin_date3.Focus();
            }
        }

        private void begin_date3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.end_date3.Focus();
            }
        }

        private void end_date3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Cmodeid.Focus();
            }
        }
        #endregion
        /// <summary>
        /// 设置列下拉列表
        /// </summary>
        private void initList2()
        {
            try
            {
                Neusoft.HISFC.Management.HealthRecord.Tumour da = new Neusoft.HISFC.Management.HealthRecord.Tumour();
                //放疗方式 
                //ArrayList RmodeidList = da.GetRmodeidList();
                //InitList(RmodeidListBox, RmodeidList);
                //RmodeidTypeHelper.ArrayObject = RmodeidList;

                //放疗程式 
                //ArrayList RprocessidList = da.GetRprocessidList();
                //InitList(RprocessidListBox, RprocessidList);
                //RprocessidTypeHelper.ArrayObject = RprocessidList;

                //放疗装置
                //ArrayList RdeviceidList = da.GetRdeviceidList();
                //InitList(RdeviceidListBox, RdeviceidList);
                //RdeviceidTypeHelper.ArrayObject = RdeviceidList;

                //化疗方式
                //ArrayList CmodeidList = da.GetCmodeidList();
                //InitList(CmodeidListBox, CmodeidList);
                //CmodeidTypeHelper.ArrayObject = CmodeidList;

                //化疗方法
                //ArrayList CmethodList = da.GetCmethodList();
                //InitList(CmethodListBox, CmethodList);
                //CmethodTypeHelper.ArrayObject = CmethodList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 设置下拉列表的格式
        /// </summary>
        /// <param name="listBox"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private int InitList(Neusoft.NFC.Interface.Controls.PopUpListBox listBox, ArrayList list)
        {
            if (list == null)
            {
                return -1;
            }
            try
            {
                //加载列表
                listBox.AddItems(list);
                listBox.Visible = false;
                Controls.Add(listBox);
                //隐藏
                listBox.Hide();
                //设置边框
                listBox.BorderStyle = BorderStyle.FixedSingle;
                listBox.BringToFront();
                //单击事件
                listBox.SelectItem += new Neusoft.NFC.Interface.Controls.PopUpListBox.MyDelegate(ListBox_SelectItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 选择项目列表 按键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int ListBox_SelectItem(Keys key)
        {
            GetSelectItem();
            return 0;
        }
        /// <summary>
        /// 获取选中得项
        /// </summary>
        /// <returns></returns>
        private int GetSelectItem()
        {
            int rtn = listBoxActive.GetSelectedItem(out selectObj);
            if (selectObj == null)
            {
                return -1;
            }
            if (selectObj.ID != "")
            {
                this.contralActive.Tag = selectObj.ID;
                this.contralActive.Text = selectObj.Name;
            }
            else
            {
                this.contralActive.Tag = null;
            }
            this.listBoxActive.Visible = false;
            return rtn;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (listBoxActive != null) //有下拉列表的 
                {
                    if (listBoxActive.Visible == true)
                    {
                        GetSelectItem();
                    }
                }
                else if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.Qty) //没有下拉列表的  注意要用else 否则会发生一次走两格的事情
                {
                    if (fpEnter1_Sheet1.ActiveRowIndex < fpEnter1_Sheet1.Rows.Count - 1)
                    {
                        this.fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex + 1, 0);
                    }
                    else
                    {
                        this.AddRow();
                    }
                }
            }
            if (keyData == Keys.Escape)
            {
                listBoxActive.Visible = false;
            }
            return base.ProcessDialogKey(keyData);
        }
        /// <summary>
        /// 设置ICDList的可见性
        /// </summary>
        /// <param name="result"></param>
        private void ListBoxActiveVisible(bool result)
        {
            #region 将所有的下拉列表变成 不可见
            RmodeidListBox.Visible = false;
            RprocessidListBox.Visible = false;
            RdeviceidListBox.Visible = false;
            CmodeidListBox.Visible = false;
            CmethodListBox.Visible = false;
            #endregion
            if (result)
            {
                //				int i = contral.Top +contral.Height + ICDListBox.Height;
                //				if(i <= this.Height)
                //					ICDListBox.Location=new System.Drawing.Point(contral.Left, i - ICDListBox.Height);				
                //				else
                //					ICDListBox.Location=new System.Drawing.Point(contral.Left, contral.Top - ICDListBox.Height);
                listBoxActive.Location = new System.Drawing.Point(contralActive.Location.X, contralActive.Location.Y + contralActive.Height + 2);
                listBoxActive.SelectNone = true;
                listBoxActive.Width = 100;
            }
            else
            {

            }
            listBoxActive.BringToFront();
            try
            {
                if (contralActive.Text != "")
                {
                    listBoxActive.Filter(contralActive.Text);
                }
                else
                {
                    listBoxActive.Filter(contralActive.Text);
                    listBoxActive.SelectedIndex = -1;
                }
            }
            catch { }
            listBoxActive.Visible = result;
        }
        /// <summary>
        /// 有下拉列表的textBox 在改动时筛选数据
        /// </summary>
        private void ListFilter()
        {
            try
            {
                listBoxActive.Filter(contralActive.Text);
            }
            catch { }
        }
        /// <summary>
        /// 将实体中的数据显示到界面上 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int ConvertInfoToPanel(Neusoft.HISFC.Object.HealthRecord.Tumour info)
        {
            try
            {
                Rmodeid.Tag = info.Rmodeid;//放疗方式
                Rmodeid.Text = RmodeidTypeHelper.GetName(info.Rmodeid);//放疗方式

                Rprocessid.Tag = info.Rprocessid;//放疗程式
                Rprocessid.Text = RprocessidTypeHelper.GetName(info.Rprocessid);//放疗程式

                Rdeviceid.Tag = info.Rdeviceid;//放疗装置
                Rdeviceid.Text = RdeviceidTypeHelper.GetName(info.Rdeviceid);//放疗装置
                gy1.Text = info.Gy1.ToString();//原发灶计量
                time1.Text = info.Time1.ToString();//原发次数
                day1.Text = info.Day1.ToString();
                if (info.BeginDate1 != System.DateTime.MinValue)
                {
                    begin_date1.Value = info.BeginDate1;
                }
                else
                {
                    begin_date1.Value = System.DateTime.Now;
                }
                if (info.EndDate1 != System.DateTime.MinValue)
                {
                    end_date1.Value = info.EndDate1;
                }
                else
                {
                    end_date1.Value = System.DateTime.Now;
                }
                gy2.Text = info.Gy2.ToString(); //区域淋巴结
                time2.Text = info.Time2.ToString();
                day2.Text = info.Day2.ToString();
                if (info.BeginDate2 != System.DateTime.MinValue)
                {
                    begin_date2.Value = info.BeginDate2;
                }
                else
                {
                    begin_date2.Value = System.DateTime.Now;
                }
                if (info.EndDate2 != System.DateTime.MinValue)
                {
                    end_date2.Value = info.EndDate2;
                }
                else
                {
                    end_date2.Value = System.DateTime.Now;
                }
                gy3.Text = info.Gy3.ToString();//转移灶计量
                time3.Text = info.Time3.ToString();
                day3.Text = info.Day3.ToString();
                if (info.BeginDate3 != System.DateTime.MinValue)
                {
                    begin_date3.Value = info.BeginDate3;
                }
                else
                {
                    begin_date3.Value = System.DateTime.Now;
                }
                if (info.EndDate3 != System.DateTime.MinValue)
                {
                    end_date3.Value = info.EndDate3;
                }
                else
                {
                    end_date3.Value = System.DateTime.Now;
                }
                Cmodeid.Tag = info.Cmodeid;//化疗方式
                Cmodeid.Text = CmodeidTypeHelper.GetName(info.Cmodeid);//化疗方式
                Cmethod.Tag = info.Cmethod;//化疗方法
                Cmethod.Text = CmethodTypeHelper.GetName(info.Cmethod);//化疗方法
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 数据校验  校验失败返回 -1 成功返回 1 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int ValueTumourSate(Neusoft.HISFC.Object.HealthRecord.Tumour info)
        {
            if (info == null)
            {
                MessageBox.Show("肿瘤信息为空");
                return -1;
            }
            if (info.Rmodeid.Length > 2)
            {
                MessageBox.Show("放疗方式 编码过长");
                return -1;
            }
            if (info.Rprocessid.Length > 2)
            {
                MessageBox.Show("放疗程式 编码过长");
                return -1;
            }
            if (info.Rdeviceid.Length > 2)
            {
                MessageBox.Show("放疗装置 编码过长");
                return -1;
            }
            //化疗方式    
            if (info.Cmodeid.Length > 2)
            {
                MessageBox.Show("放疗装置 编码过长");
                return -1;
            }
            //化疗方法 
            if (info.Cmethod.Length > 2)
            {
                MessageBox.Show("放疗装置 编码过长");
                return -1;
            }
            if (info.Gy1 > (decimal)9999.99)
            {
                MessageBox.Show("原发灶计量 过大");
                return -1;
            }
            if (info.Gy1 < 0)
            {
                MessageBox.Show("原发灶计量 不能小于零");
                return -1;
            }
            if (info.Time1 < 0)
            {
                MessageBox.Show("原发灶次数 不能小于零");
                return -1;
            }
            if (info.Time1 > (decimal)9999.99)
            {
                MessageBox.Show("原发灶次数 过大");
                return -1;
            }
            if (info.Day1 < 0)
            {
                MessageBox.Show("原发灶天数 不能小于零");
                return -1;
            }
            if (info.Day1 > (decimal)9999.99)
            {
                MessageBox.Show("原发灶天数 过大");
                return -1;
            }
            if (info.Gy2 < 0)
            {
                MessageBox.Show("区域淋巴结计量 不能小于零");
                return -1;
            }
            if (info.Gy2 > (decimal)9999.99)
            {
                MessageBox.Show("区域淋巴结计量 过大");
                return -1;
            }
            if (info.Time2 < 0)
            {
                MessageBox.Show("区域淋巴结次数 不能小于零");
                return -1;
            }
            if (info.Time2 > (decimal)9999.99)
            {
                MessageBox.Show("区域淋巴结次数 过大");
                return -1;
            }
            if (info.Day2 < 0)
            {
                MessageBox.Show("区域淋巴结天数 不能小于零");
                return -1;
            }

            if (info.Day2 > (decimal)9999.99)
            {
                MessageBox.Show("区域淋巴结天数 过大");
                return -1;
            }

            if (info.Gy3 < 0)
            {
                MessageBox.Show("转移灶计量计量 不能小于零");
                return -1;
            }

            if (info.Gy3 > (decimal)9999.99)
            {
                MessageBox.Show("转移灶计量计量 过大");
                return -1;
            }

            if (info.Time3 < 0)
            {
                MessageBox.Show("转移灶计量次数 不能小于零");
                return -1;
            }
            if (info.Time3 > (decimal)9999.99)
            {
                MessageBox.Show("转移灶计量次数 过大");
                return -1;
            }

            if (info.Day3 < 0)
            {
                MessageBox.Show("转移灶计量天数 不能小于零");
                return -1;
            }

            if (info.Day3 > (decimal)9999.99)
            {
                MessageBox.Show("转移灶计量天数 过大");
                return -1;
            }
            if (info.Rmodeid != "" || info.Rmodeid != null || info.Rprocessid != "" || info.Rprocessid != null || info.Rdeviceid != "" || info.Rdeviceid != null || info.Cmodeid != "" || info.Cmodeid != null || info.Cmethod != "" || info.Cmethod != null)
            {
                return 2;
            }
            return 1;
        }
        /// <summary>
        /// 将界面上的数据 收集到实体上 
        /// </summary>
        /// <returns></returns>
        public Neusoft.HISFC.Object.HealthRecord.Tumour GetTumourInfo()
        {
            Neusoft.HISFC.Object.HealthRecord.Tumour info = new Neusoft.HISFC.Object.HealthRecord.Tumour();

            try
            {
                info.InpatientNo = this.patientInfo.ID; //住院流水号
                if (Rmodeid.Tag != null)
                {
                    info.Rmodeid = Rmodeid.Tag.ToString();//放疗方式
                }
                if (Rprocessid.Tag != null)
                {
                    info.Rprocessid = Rprocessid.Tag.ToString();//放疗程式
                }
                if (Rdeviceid.Tag != null)
                {
                    info.Rdeviceid = Rdeviceid.Tag.ToString();//放疗装置
                }
                info.Gy1 = Neusoft.NFC.Function.NConvert.ToDecimal(gy1.Text);//原发灶计量
                info.Time1 = Neusoft.NFC.Function.NConvert.ToDecimal(time1.Text);//原发次数
                info.Day1 = Neusoft.NFC.Function.NConvert.ToDecimal(day1.Text);
                info.BeginDate1 = begin_date1.Value;
                info.EndDate1 = end_date1.Value;
                info.Gy2 = Neusoft.NFC.Function.NConvert.ToDecimal(gy2.Text); //区域淋巴结
                info.Time2 = Neusoft.NFC.Function.NConvert.ToDecimal(time2.Text);
                info.Day2 = Neusoft.NFC.Function.NConvert.ToDecimal(day2.Text);
                info.BeginDate2 = begin_date2.Value;
                info.EndDate2 = end_date2.Value;
                info.Gy3 = Neusoft.NFC.Function.NConvert.ToDecimal(gy3.Text);//转移灶计量
                info.Time3 = Neusoft.NFC.Function.NConvert.ToDecimal(time3.Text);
                info.Day3 = Neusoft.NFC.Function.NConvert.ToDecimal(day3.Text);
                info.BeginDate3 = begin_date3.Value;
                info.EndDate3 = end_date3.Value;
                if (Cmodeid.Tag != null)
                {
                    info.Cmodeid = Cmodeid.Tag.ToString();//化疗方式
                }
                if (Cmethod.Tag != null)
                {
                    info.Cmethod = Cmethod.Tag.ToString();//化疗方法
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return info;
        }
        /// <summary>
        /// 设置 只读性 
        /// </summary>
        /// <param name="type"></param>
        private void SetTumourReadOnly(bool type)
        {
            Rmodeid.ReadOnly = type;//放疗方式
            Rprocessid.ReadOnly = type;//放疗程式
            Rdeviceid.ReadOnly = type;//放疗装置
            gy1.ReadOnly = type;//原发灶计量
            time1.ReadOnly = type;//原发次数
            day1.ReadOnly = type;
            begin_date1.Enabled = !type;
            end_date1.Enabled = !type;
            gy2.ReadOnly = type; //区域淋巴结
            time2.ReadOnly = type;
            day2.ReadOnly = type;
            begin_date2.Enabled = !type;
            end_date2.Enabled = !type;
            gy3.ReadOnly = type;//转移灶计量
            time3.ReadOnly = type;
            day3.ReadOnly = type;
            begin_date3.Enabled = !type;
            end_date3.Enabled = !type;
            Cmodeid.ReadOnly = type;//化疗方式
            Cmethod.ReadOnly = type;//化疗方法
        }
        private void ClearTumourInfo()
        {
            Rmodeid.Text = "";//放疗方式
            Rmodeid.Tag = null;
            Rprocessid.Text = "";//放疗程式
            Rprocessid.Tag = null;
            Rdeviceid.Text = "";//放疗装置
            Rdeviceid.Tag = null;
            gy1.Text = "";//原发灶计量
            time1.Text = "";//原发次数
            day1.Text = "";
            begin_date1.Value = System.DateTime.Now;
            end_date1.Value = System.DateTime.Now;
            gy2.Text = ""; //区域淋巴结
            time2.Text = "";
            day2.Text = "";
            begin_date2.Value = System.DateTime.Now;
            end_date2.Value = System.DateTime.Now;
            gy3.Text = "";//转移灶计量
            time3.Text = "";
            day3.Text = "";
            begin_date3.Value = System.DateTime.Now;
            end_date3.Value = System.DateTime.Now;
            Cmodeid.Tag = null;//化疗方式
            Cmodeid.Text = "";//化疗方式
            Cmethod.Tag = null;//化疗方法
            Cmethod.Text = "";//化疗方法
        }
        #endregion

        #region  肿瘤明细操作函数
        /// <summary>
        /// 设置活动单元格
        /// </summary>
        public void SetActiveCells()
        {
            try
            {
                this.fpEnter1_Sheet1.SetActiveCell(0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 限定格的宽度很可见性 
        /// </summary>
        private void LockFpEnter()
        {
            this.fpEnter1_Sheet1.Columns[0].Width = 63; //时间
            this.fpEnter1_Sheet1.Columns[1].Width = 129;//药物名称
            this.fpEnter1_Sheet1.Columns[5].Width = 60;//用量
            this.fpEnter1_Sheet1.Columns[2].Width = 40; //单位
            this.fpEnter1_Sheet1.Columns[3].Width = 40; //疗程
            this.fpEnter1_Sheet1.Columns[4].Width = 80; //结果
            this.fpEnter1_Sheet1.Columns[6].Width = 100; //药品编码
            this.fpEnter1_Sheet1.Columns[6].Locked = true;//药品编码
            this.fpEnter1_Sheet1.Columns[7].Visible = false; //序号
        }
        /// <summary>
        /// 清空原有的数据
        /// </summary>
        /// <returns></returns>
        public int ClearInfo()
        {
            if (this.dtTumour != null)
            {
                this.dtTumour.Clear();
                ClearTumourInfo();
                LockFpEnter();
            }
            else
            {
                MessageBox.Show("肿瘤表为null");
            }
            return 1;
        }
        public int SetReadOnly(bool type)
        {
            if (type)
            {
                this.fpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
                SetTumourReadOnly(type);
            }
            else
            {
                this.fpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
                SetTumourReadOnly(type);
            }
            return 0;
        }
        /// <summary>
        /// 校验数据的合法性。
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int ValueState(ArrayList list)
        {
            if (list == null)
            {
                return -2;
            }
            foreach (Neusoft.HISFC.Object.HealthRecord.TumourDetail obj in list)
            {
                if (obj.InpatientNO == "" || obj.InpatientNO == null)
                {
                    MessageBox.Show("肿瘤信息 住院流水号不能为空");
                    return -1;
                }

                if (obj.InpatientNO.Length > 14)
                {
                    MessageBox.Show("肿瘤信息 住院流水号过长");
                    return -1;
                }
                if (obj.DrugInfo.Name == null || obj.DrugInfo.Name == "")
                {
                    MessageBox.Show("肿瘤信息 药物名称不能为空");
                    return -1;
                }
                else if (obj.DrugInfo.Name.Length > 50)
                {
                    MessageBox.Show("肿瘤信息 药物名称过长");
                    return -1;
                }
                if (obj.Qty == 0)
                {
                    MessageBox.Show("肿瘤信息" + obj.DrugInfo.Name + " 计量不能为零");
                    return -1;
                }
                else if (obj.Qty > 10000)
                {
                    MessageBox.Show("肿瘤信息" + obj.DrugInfo.Name + " 计量过大");
                    return -1;
                }
                else if (obj.Qty < 0)
                {
                    MessageBox.Show("肿瘤信息" + obj.DrugInfo.Name + " 计量不能小于零");
                    return -1;
                }

                if (obj.Unit == null || obj.Unit == "")
                {
                    MessageBox.Show("请填写 肿瘤信息" + obj.DrugInfo.Name + " 的单位");
                    return -1;
                }
                else if (obj.Unit.Length > 8)
                {
                    MessageBox.Show("肿瘤信息" + obj.DrugInfo.Name + " 单位长度过大");
                    return -1;
                }
            }
            return 0;
        }
        /// <summary>
        /// 保存对表做的所有修改
        /// </summary>
        /// <returns></returns>
        public int fpEnterSaveChanges()
        {
            try
            {
                this.dtTumour.AcceptChanges();
                LockFpEnter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 将保存完的数据回写到表中
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int fpEnterSaveChanges(ArrayList list)
        {
            AddInfoToTable(list);
            dtTumour.AcceptChanges();
            LockFpEnter();
            return 0;
        }
        public int AddInfoToTable(ArrayList list)
        {
            if (this.dtTumour != null)
            {
                this.dtTumour.Clear();
                this.dtTumour.AcceptChanges();
            }
            if (list == null)
            {
                return -1;
            }

            //循环插入数据
            foreach (Neusoft.HISFC.Object.HealthRecord.TumourDetail info in list)
            {
                DataRow row = dtTumour.NewRow();
                SetRow(info, row);
                dtTumour.Rows.Add(row);
            }
            //更改标志
            dtTumour.AcceptChanges();
            LockFpEnter();
            return 0;
        }
        /// <summary>
        /// 返回当前数据行数
        /// </summary>
        /// <returns></returns>
        public int GetfpSpreadRowCount()
        {
            return fpEnter1_Sheet1.Rows.Count;
        }
        /// <summary>
        /// 如果reset 为真 则清空现有数据 并保存更改  为假 只是保存当前更改
        /// creator:zhangjunyi@Neusoft.com
        /// </summary>
        /// <param name="reset"></param>
        /// <returns></returns>
        public bool Reset(bool reset)
        {
            if (reset)
            {
                //清空数据 保存更改 
                if (dtTumour != null)
                {
                    dtTumour.Clear();
                    dtTumour.AcceptChanges();
                }
            }
            else
            {
                //保存更改
                dtTumour.AcceptChanges();
            }
            return true;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void InitInfo()
        {
            try
            {
                //初始化表
                InitDateTable();
                //设置下拉列表
                this.initList();
                //设置下拉列表
                initList2();
                fpEnter1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
                LockFpEnter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitDateTable()
        {
            try
            {
                Type strType = typeof(System.String);
                Type intType = typeof(System.Int32);
                Type dtType = typeof(System.DateTime);
                Type boolType = typeof(System.Boolean);
                Type floatType = typeof(System.Single);

                dtTumour.Columns.AddRange(new DataColumn[]{
														   new DataColumn("时间", dtType),	//0
														   new DataColumn("药物名称", strType),	 //1
														   new DataColumn("单位", strType),//2
														   new DataColumn("疗程", strType),//3
														   new DataColumn("结果", strType),//4
														   new DataColumn("用量", strType),//5
														   new DataColumn("药品编码", strType),//6
														   new DataColumn("序号", intType)});//7
                //绑定数据源
                this.fpEnter1_Sheet1.DataSource = dtTumour;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool GetList(string strType, ArrayList list)
        {
            try
            {
                this.fpEnter1.StopCellEditing();
                switch (strType)
                {
                    case "A":
                        //增加的数据
                        DataTable AddTable = this.dtTumour.GetChanges(DataRowState.Added);
                        GetChangeInfo(AddTable, list);
                        break;
                    case "M":
                        DataTable ModTable = this.dtTumour.GetChanges(DataRowState.Modified);
                        GetChangeInfo(ModTable, list);
                        break;
                    case "D":
                        DataTable DelTable = this.dtTumour.GetChanges(DataRowState.Deleted);
                        if (DelTable != null)
                        {
                            DelTable.RejectChanges();
                        }
                        GetChangeInfo(DelTable, list);
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 获取修改过的信息
        /// </summary>
        /// <returns></returns>
        private bool GetChangeInfo(DataTable tempTable, ArrayList list)
        {
            if (tempTable == null)
            {
                return true;
            }
            try
            {
                Neusoft.HISFC.Object.HealthRecord.TumourDetail info = null;
                foreach (DataRow row in tempTable.Rows)
                {
                    info = new Neusoft.HISFC.Object.HealthRecord.TumourDetail();
                    info.InpatientNO = this.patientInfo.ID;
                    if (row["时间"] != DBNull.Value)
                    {
                        info.CureDate = Neusoft.NFC.Function.NConvert.ToDateTime(row["时间"].ToString());
                    }
                    if (row["药物名称"] != DBNull.Value)
                    {
                        info.DrugInfo.Name = row["药物名称"].ToString();//1
                    }
                    if (row["用量"] != DBNull.Value)
                    {
                        info.Qty = Neusoft.NFC.Function.NConvert.ToDecimal(row["用量"]);//1
                    }
                    if (row["单位"] != DBNull.Value)
                    {
                        info.Unit = this.UnitListHelper.GetID(row["单位"].ToString());//2
                    }
                    if (row["疗程"] != DBNull.Value)
                    {
                        info.Period = this.PeriodListHelper.GetID(row["疗程"].ToString());//2
                    }
                    if (row["结果"] != DBNull.Value)
                    {
                        info.Result = this.ResultListHelper.GetID(row["结果"].ToString());//2
                    }
                    if (row["药品编码"] != DBNull.Value)
                    {
                        info.DrugInfo.ID = row["药品编码"].ToString();//2
                    }
                    if (row["序号"] != DBNull.Value)
                    {
                        info.HappenNO = Neusoft.NFC.Function.NConvert.ToInt32(row["序号"]);//1
                    }
                    list.Add(info);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除当前行 
        /// </summary>
        /// <returns></returns>
        public int DeleteActiveRow()
        {
            if (fpEnter1_Sheet1.Rows.Count > 0)
            {
                this.fpEnter1_Sheet1.Rows.Remove(fpEnter1_Sheet1.ActiveRowIndex, 1);
            }
            if (fpEnter1_Sheet1.Rows.Count == 0)
            {
                this.fpEnter1.SetAllListBoxUnvisible();
            }
            return 1;
        }
        /// <summary>
        /// 删除空白的行
        /// </summary>
        /// <returns></returns>
        public int deleteRow()
        {
            if (fpEnter1_Sheet1.Rows.Count == 1)
            {
                //第一行编码为空 
                if (fpEnter1_Sheet1.Cells[0, 1].Text == "")
                {
                    fpEnter1_Sheet1.Rows.Remove(0, 1);
                }
            }
            return 1;
        }
        /// <summary>
        /// 查询并显示数据
        /// </summary>
        /// <returns>出错返回 －1 正常 0 不允许有病案1  </returns>
        public int LoadInfo(Neusoft.HISFC.Object.RADT.PatientInfo patient, Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes Type)
        {
            if (patient == null)
            {
                return -1;
            }
            patientInfo = patient;
            if (patientInfo.CaseState == "0")
            {
                //不允许有病案
                return 1;
            }
            Neusoft.HISFC.Management.HealthRecord.Tumour tumour = new Neusoft.HISFC.Management.HealthRecord.Tumour();
            //查询符合条件的数据
            ArrayList list = tumour.QueryTumourDetail(patient.ID);
            AddInfoToTable(list);
            Neusoft.HISFC.Object.HealthRecord.Tumour obj = tumour.GetTumour(patient.ID);
            if (obj == null)
            {
                MessageBox.Show("获取肿瘤信息出错");
                return -1;
            }
            this.ConvertInfoToPanel(obj);
            return 0;

        }
        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="info"></param>
        private void SetRow(Neusoft.HISFC.Object.HealthRecord.TumourDetail info, DataRow row)
        {
            row["时间"] = info.CureDate;//0
            row["药物名称"] = info.DrugInfo.Name;//1
            row["用量"] = info.Qty;//2
            row["单位"] = UnitListHelper.GetName(info.Unit);            //3
            row["疗程"] = PeriodListHelper.GetName(info.Period);//4
            row["结果"] = ResultListHelper.GetName(info.Result);//5
            row["药品编码"] = info.DrugInfo.ID;//6
            row["序号"] = info.HappenNO;//7
        }
        private enum Col
        {
            colTime = 0,//时间
            DrugName = 1,//药品名称
            Unit = 2,//单位
            Preiod = 3,//疗程
            Result = 4,//结果
            Qty = 5,//剂量
            DrugCode = 6 //药品编码

        }
        /// <summary>
        /// 设置列下拉列表
        /// </summary>
        private void initList()
        {
            try
            {
                Neusoft.HISFC.Management.HealthRecord.Tumour da = new Neusoft.HISFC.Management.HealthRecord.Tumour();
                Neusoft.HISFC.Management.Manager.Constant con = new Neusoft.HISFC.Management.Manager.Constant();
                Neusoft.HISFC.Integrate.Pharmacy item = new Neusoft.HISFC.Integrate.Pharmacy();
                fpEnter1.SetWidthAndHeight(200, 200);
                fpEnter1.SelectNone = true;
                //药品信息
                ArrayList druglist = new ArrayList();
                //List<Neusoft.HISFC.Object.Pharmacy.Item> druglist = item.QueryItemAvailableList(true);
                //this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, (int)Col.DrugName, druglist);
                //this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, (int)Col.DrugCode, druglist);
                //药品信息不显示ID号
                this.fpEnter1.SetIDVisiable(this.fpEnter1_Sheet1, (int)Col.DrugName, false);
                this.fpEnter1.SetIDVisiable(this.fpEnter1_Sheet1, (int)Col.DrugCode, false);
                //单位列表
                ArrayList UnitList = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.DOSEUNIT);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, (int)Col.Unit, UnitList);
                UnitListHelper.ArrayObject = UnitList;

                //疗程列表 
                //ArrayList PeriodList = da.GetPeriodList(); ;
                //this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, (int)Col.Preiod, PeriodList);
                //PeriodListHelper.ArrayObject = PeriodList;

                //j结果列表
                //ArrayList ResultList = da.GetResultList();
                //this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, (int)Col.Result, ResultList);
                //ResultListHelper.ArrayObject = ResultList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ucTumourCard_Load(object sender, System.EventArgs e)
        {
            //定义响应按键事件
            fpEnter1.KeyEnter += new Neusoft.NFC.Interface.Controls.NeuFpEnter.keyDown(fpEnter1_KeyEnter);
            fpEnter1.SetItem += new Neusoft.NFC.Interface.Controls.NeuFpEnter.setItem(fpEnter1_SetItem);
            fpEnter1.ShowListWhenOfFocus = true;
            fpEnter1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
        }
        /// <summary>
        /// 按键响应处理
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int fpEnter1_KeyEnter(Keys key)
        {
            if (key == Keys.Enter)
            {
                //				MessageBox.Show("Enter,可以自己添加处理事件，比如跳到下一cell");
                //回车
                if (this.fpEnter1.ContainsFocus)
                {
                    int i = this.fpEnter1_Sheet1.ActiveColumnIndex;
                    if (i == (int)Col.DrugName || i == (int)Col.Unit || i == (int)Col.Preiod || i == (int)Col.Result || i == (int)Col.DrugCode)
                    {
                        ProcessDept();
                    }
                    else if (i == (int)Col.colTime)
                    {
                        this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.ActiveRowIndex, 1);
                    }
                    else if (i == (int)Col.Qty)
                    {
                        if (fpEnter1_Sheet1.ActiveRowIndex < fpEnter1_Sheet1.Rows.Count - 1)
                        {
                            this.fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex + 1, 0);
                        }
                        else
                        {
                            this.AddRow();
                        }
                    }
                }
            }
            else if (key == Keys.Up)
            {
                //				MessageBox.Show("Up,可以自己添加处理事件，比如无下拉列表时，跳到下列，显示下拉控件时，在下拉控件上下移动");
            }
            else if (key == Keys.Down)
            {
                //				MessageBox.Show("Down，可以自己添加处理事件，比如无下拉列表时，跳到上列，显示下拉控件时，在下拉控件上下移动");
            }
            else if (key == Keys.Escape)
            {
                //				MessageBox.Show("Escape,取消列表可见");
            }
            return 0;
        }
        /// <summary>
        /// 添加一行项目
        /// </summary>
        /// <returns></returns>
        public int AddRow()
        {
            try
            {
                if (fpEnter1_Sheet1.Rows.Count < 1)
                {
                    //增加一行空值
                    DataRow row = dtTumour.NewRow();
                    row["序号"] = 1;
                    row["时间"] = System.DateTime.Now;
                    row["用量"] = 0;//2
                    dtTumour.Rows.Add(row);
                }
                else
                {
                    //增加一行
                    int j = fpEnter1_Sheet1.Rows.Count;
                    this.fpEnter1_Sheet1.Rows.Add(j, 1);
                    for (int i = 0; i < fpEnter1_Sheet1.Columns.Count; i++)
                    {
                        fpEnter1_Sheet1.Cells[j, i].Value = fpEnter1_Sheet1.Cells[j - 1, i].Value;
                    }
                }
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.Rows.Count, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        /// <summary>
        /// 选则选中的项
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int fpEnter1_SetItem(Neusoft.NFC.Object.NeuObject obj)
        {
            this.ProcessDept();
            return 0;
        }
        /// <summary>
        /// 处理回车操作 ，并且取出数据
        /// </summary>
        /// <returns></returns>
        private int ProcessDept()
        {
            int CurrentRow = fpEnter1_Sheet1.ActiveRowIndex;
            if (CurrentRow < 0) return 0;

            if (fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.DrugName)
            {
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)Col.DrugName);
                //获取选中的信息
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                //药品名称
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                //药品编码
                fpEnter1_Sheet1.Cells[CurrentRow, (int)Col.DrugCode].Text = item.ID;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.Unit);
                return 0;
            }
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.DrugName)
            {
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)Col.DrugName);
                //获取选中的信息
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                //药品名称
                fpEnter1_Sheet1.ActiveCell.Text = item.ID;
                //药品编码
                fpEnter1_Sheet1.Cells[CurrentRow, (int)Col.DrugName].Text = item.Name;
                fpEnter1.Focus();
                //
                if (fpEnter1_Sheet1.ActiveRowIndex < fpEnter1_Sheet1.Rows.Count - 1)
                {
                    this.fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex + 1, 0);
                }
                //				else
                //				{
                //					this.AddRow();
                //				}
                return 0;
            }
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.Unit)
            {
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)Col.Unit);
                //获取选中的信息
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                //药品计量单位
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.Preiod);
                return 0;
            }
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.Preiod)
            {
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)Col.Preiod);
                //获取选中的信息
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                // 疗程
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.Result);
                return 0;
            }
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.Result)
            {
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)Col.Result);
                //获取选中的信息
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                if (item == null) return -1;
                //j结果
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.Qty);
                //
                //				if(fpEnter1_Sheet1.ActiveRowIndex < fpEnter1_Sheet1.Rows.Count -1)
                //				{
                //					this.fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex +1 ,0);
                //				}
                return 0;
            }

            return 0;
        }
        /// <summary>
        /// 设置网格得宽度 和是否打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            //			Neusoft.UFC.Common.Controls.ucSetColumn uc = new Neusoft.UFC.Common.Controls.ucSetColumn();
            //			uc.FilePath = this.filePath;
            //			uc.GoDisplay += new Neusoft.UFC.Common.Controls.ucSetColumn.DisplayNow(uc_GoDisplay);
            //			Neusoft.NFC.Interface.Classes.Function.PopShowControl(uc);
        }
        /// <summary>
        /// 调整fpSpread1_Sheet1的宽度等 保存后触发的事件
        /// </summary>
        private void uc_GoDisplay()
        {
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            if (this.fpEnter1_Sheet1.Rows.Count > 0)
            {
                //删除当前行
                this.fpEnter1_Sheet1.Rows.Remove(fpEnter1_Sheet1.ActiveRowIndex, 1);
            }

        }
        #endregion 
    }
}
