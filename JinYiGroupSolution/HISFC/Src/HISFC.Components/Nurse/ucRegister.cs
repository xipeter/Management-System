using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace Neusoft.HISFC.Components.Nurse
{
    public partial class ucRegister : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 定义域
        /// <summary>
        /// 门诊费用管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee patientMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        /// <summary>
        /// 院注管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Nurse.Inject InjMgr = new Neusoft.HISFC.BizLogic.Nurse.Inject();
        /// <summary>
        /// 
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Pharmacy drugMgr = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
        /// <summary>
        /// 
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        /// <summary>
        /// 科室函数
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager DeptMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 人员函数
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager PsMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 挂号实体
        /// </summary>
        private Neusoft.HISFC.Models.Registration.Register reg = null;
        /// <summary>
        /// 常数业务层函数
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager conMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 药房函数
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Pharmacy storeMgr = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
        private ArrayList al = new ArrayList();
        /// <summary>
        /// 治疗单的数据
        /// </summary>
        private ArrayList alPrint = null;
        /// <summary>
        /// 注射单的数据
        /// </summary>
        private ArrayList alInject = null;
        /// <summary>
        /// 样本集合
        /// </summary>
        private Hashtable htSamples = new Hashtable();
        /// <summary>
        /// 医生集合
        /// </summary>
        private Hashtable htDoctors = new Hashtable();
        /// <summary>
        /// 是否第一次登记
        /// </summary>
        private bool IsFirstTime = false;
        /// <summary>
        /// 院注次数
        /// </summary>
        private int countInject = 0;
        /// <summary>
        /// 最大注射顺序号
        /// </summary>
        private int maxInjectOrder = 0;
        #region 注射顺序号
        /// <summary>
        /// 是否自动生成注射顺序号
        /// </summary>
        private bool IsAutoOrder = true;
        /// <summary>
        /// 当前注射顺序号
        /// </summary>
        private int currentOrder = 0;
        #endregion

        /// <summary>
        /// 是否显示患者当天可登记的全部处方
        /// {24A47206-F111-4817-A7B4-353C21FC7724}
        /// </summary>
        private bool isShowAllInject = false;

        /// <summary>
        /// 用来存储频次实体的字典
        /// {24A47206-F111-4817-A7B4-353C21FC7724}
        /// </summary>
        private Dictionary<string, Neusoft.HISFC.Models.Order.Frequency> dicFrequency = new Dictionary<string, Neusoft.HISFC.Models.Order.Frequency>();

        /// <summary>
        /// 
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Nurse.IGetInjectOrderNo IGetOrderNo = null;

        #region {EDC3F829-A686-409e-A4F4-4D5B8C2F3799} 门诊注射管理读卡操作 by guanyx
        private event System.EventHandler ReadCardEvent;
        #endregion

        #endregion

        #region 属性

        /// <summary>
        /// 是否显示患者当天可登记的全部处方
        /// {24A47206-F111-4817-A7B4-353C21FC7724}
        /// </summary>
        [Description("是否显示患者当天可登记的全部处方"), Category("设置"), DefaultValue("false")]
        public bool IsShowAllInject
        {
            get
            {
                return isShowAllInject;
            }
            set
            {
                isShowAllInject = value;
            }
        }

        #endregion

        #region 初始化
        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            this.dtpStart.Value = this.InjMgr.GetDateTimeFromSysDateTime().AddDays(-7);
            this.dtpEnd.Value = this.InjMgr.GetDateTimeFromSysDateTime();
            this.lbCue.Text = "";
            this.initDoctor();
            this.txtCardNo.Focus();
            this.InitOrder();
        }
        /// <summary>
        /// 初始化医生
        /// </summary>
        private void initDoctor()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager doctMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            al = doctMgr.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (al != null)
            {
                foreach (Neusoft.HISFC.Models.Base.Employee p in al)
                {
                    this.htDoctors.Add(p.ID, p.Name);
                }
            }
        }
        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("全选", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全选, true, false, null);
            this.toolBarService.AddToolButton("取消", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);
            this.toolBarService.AddToolButton("打印瓶签", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, true, false, null);
            this.toolBarService.AddToolButton( "打印签名卡", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, true, false, null );
            this.toolBarService.AddToolButton( "打印注射单", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, true, false, null );
            this.toolBarService.AddToolButton( "打印患者卡", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, true, false, null );
            //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B} 增加打印号码条
            this.toolBarService.AddToolButton("打印号码条", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, true, false, null);
            //{26E88889-B2CF-4965-AFD8-6D9BE4519EBF}
            this.toolBarService.AddToolButton("修改皮试", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            #region {EDC3F829-A686-409e-A4F4-4D5B8C2F3799} 门诊注射管理读卡操作 by guanyx
            this.ReadCardEvent += new EventHandler(ucRegister_ReadCardEvent);
            this.toolBarService.AddToolButton("读卡", "读院内卡", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z召回, true, false, this.ReadCardEvent);
            #endregion
            return this.toolBarService;
        }

        #region {EDC3F829-A686-409e-A4F4-4D5B8C2F3799} 门诊注射管理读卡操作 by guanyx
        private string cardno = "";
        private bool isNewCard = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();
        /// <summary>
        /// 读卡操作
        /// {EDC3F829-A686-409e-A4F4-4D5B8C2F3799} 门诊注射管理读卡操作 by guanyx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucRegister_ReadCardEvent(object sender, EventArgs e)
        {
            if (icreader.GetConnect())
            {
                cardno = icreader.ReaderICCard();
                if (cardno == "0000000000")
                {
                    isNewCard = true;
                    MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                }
                else
                {
                    this.txtCardNo.Text = cardno;
                    this.txtCardNo_KeyDown(this.txtCardNo, new KeyEventArgs(Keys.Enter));
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();
            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            this.Query();
            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "全选":
                    this.SelectedAll(true);
                    break;
                case "取消":
                    this.SelectedAll(false);
                    break;
                case "打印瓶签":
                    this.PrintCure();
                    break;
                case "打印签名卡":
                    this.PrintItinerate();
                    break;
                case "打印注射单":
                    this.PrintInject();
                    break;
                case "打印患者卡":
                    this.PrintPatient();
                    break;
                //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B} 增加打印号码条
                case "打印号码条":
                    this.PrintNumber();
                    break;
                //{26E88889-B2CF-4965-AFD8-6D9BE4519EBF}
                case "修改皮试":
                    this.ModifyHytest();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 公共
        /// <summary>
        /// 获取医生名称根据代码
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string GetDoctByID(string ID)
        {
            IDictionaryEnumerator dict = htDoctors.GetEnumerator();
            while (dict.MoveNext())
            {
                if (dict.Key.ToString() == ID)
                    return dict.Value.ToString();
            }

            return "";
        }
        /// <summary>
        /// 设置格式
        /// </summary>
        private void SetFP()
        {
            FarPoint.Win.Spread.CellType.TextCellType txtOnly = new FarPoint.Win.Spread.CellType.TextCellType();
            txtOnly.ReadOnly = true;
            this.neuSpread1_Sheet1.Columns[2].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[3].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[3].Visible = false;
            this.neuSpread1_Sheet1.Columns[4].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[5].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[6].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[7].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[8].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[9].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[10].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[11].CellType = txtOnly;
            //{24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
            this.neuSpread1_Sheet1.Columns[13].CellType = txtOnly;
        }
        /// <summary>
        /// 获取午别
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetNoon(DateTime dt)
        {
            string strNoon = "上午";
            if (Neusoft.FrameWork.Function.NConvert.ToInt32(dt.ToString("HH")) >= 12)
            {
                strNoon = "下午";
            }
            return strNoon;
        }
        /// <summary>
        /// 压缩显示
        /// </summary>
        private void LessShow()
        {

        }
        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsNum(String str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsNumber(str, i))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 设置颜色(高亮度显示最后一条clinic医嘱)
        /// </summary>
        /// <returns></returns>
        private int ShowColor()
        {
            //取得最大clinic_code
            int maxClinic = 0;
            if (this.neuSpread1_Sheet1.RowCount <= 0) return -1;
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item =
                    (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList)this.neuSpread1_Sheet1.Rows[i].Tag;
                if (Neusoft.FrameWork.Function.NConvert.ToInt32(item.ID) > maxClinic)
                {
                    maxClinic = Neusoft.FrameWork.Function.NConvert.ToInt32(item.ID);
                }
            }
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item =
                    (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList)this.neuSpread1_Sheet1.Rows[i].Tag;
                if (item.ID == maxClinic.ToString())
                {
                    //					this.fpSpread1_Sheet1.Rows[i].BackColor = System.Drawing.Color.LightYellow;
                    this.neuSpread1_Sheet1.Rows[i].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    this.neuSpread1_Sheet1.SetValue(i, 0, false);
                }
            }
            return 0;
        }
        /// <summary>
        /// 只显示最后一次的
        /// </summary>
        /// <returns></returns>
        private int ShowLastOnly()
        {
            //取得最大clinic_code
            int maxClinic = 0;
            if (this.neuSpread1_Sheet1.RowCount <= 0) return -1;
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item =
                    (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList)this.neuSpread1_Sheet1.Rows[i].Tag;
                if (Neusoft.FrameWork.Function.NConvert.ToInt32(item.ID) > maxClinic)
                {
                    maxClinic = Neusoft.FrameWork.Function.NConvert.ToInt32(item.ID);
                }
            }
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item =
                    (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList)this.neuSpread1_Sheet1.Rows[i].Tag;
                if (item.ID != maxClinic.ToString())
                {
                    //this.fpSpread1_Sheet1.Rows[i].BackColor = System.Drawing.Color.LightYellow;
                    this.neuSpread1_Sheet1.SetValue(i, 0, false);
                    this.neuSpread1_Sheet1.Rows[i].Remove();
                }
            }
            return 0;
        }
        /// <summary>
        /// 获得最大注射顺序
        /// </summary>
        /// <returns></returns>
        private int GetMaxInjectOrder()
        {
            if (this.neuSpread1_Sheet1.RowCount <= 0) return 0;
            this.neuSpread1.StopCellEditing();
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                if (this.neuSpread1_Sheet1.GetText(i, 0).ToUpper() == "FALSE" ||
                    this.neuSpread1_Sheet1.GetText(i, 0) == "") continue;
                if (Neusoft.FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[i, 1].Text) > maxInjectOrder)
                {
                    maxInjectOrder = Neusoft.FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[i, 1].Text);
                }
            }
            return maxInjectOrder;
        }

        /// <summary>
        /// 设置病人信息
        /// </summary>
        /// <param name="reg"></param>
        private void SetPatient(Neusoft.HISFC.Models.Registration.Register reg)
        {

            if (reg == null || reg.ID == "")
            {
                return;
            }
            else
            {
                int iAge = Neusoft.FrameWork.Function.NConvert.ToInt32(System.DateTime.Now.ToString("yyyy"))
                    - Neusoft.FrameWork.Function.NConvert.ToInt32(reg.Birthday.ToString("yyyy"));
                this.txtName.Text = reg.Name;
                this.txtSex.Text = reg.Sex.Name;
                this.txtBirthday.Text = reg.Birthday.ToString("yyyy-MM-dd");
                this.txtAge.Text = this.InjMgr.GetAge(reg.Birthday);//iAge.ToString();
                this.txtCardNo.Text = reg.PID.CardNO;
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        private void SelectAll(bool isSelected)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                //{FAC1693A-3EBA-44b3-A1E3-6D6750A98D80}
                //this.neuSpread1_Sheet1.SetValue(i, 0, isSelected, false);
                this.neuSpread1_Sheet1.Cells[i, 0].Value = isSelected;
            }
        }
		

        #endregion

        #region  打印
        /// <summary>
        /// 打印患者卡
        /// </summary>
        private void PrintPatient()
        {
            //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}
            ArrayList al = this.GetPrintInjectList();
            if (al == null || al.Count <= 0)
            {
                MessageBox.Show("没有选择数据!");
                return;
            }
            //{637EDB0D-3F39-4fde-8686-F3CD87B64581} 打印改为接口方式
            Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectPatientPrint patientPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectPatientPrint)) as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectPatientPrint;
            if (patientPrint == null)
            {
                patientPrint = new Nurse.Print.ucPrintPatient() as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectPatientPrint;
                //Nurse.Print.ucPrintPatient uc = new Nurse.Print.ucPrintPatient();
            }
            patientPrint.Init(al);
        }
        /// <summary>
        /// 打印瓶签
        /// </summary>
        private void PrintCure()
        {
            //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}
            ArrayList al = this.GetPrintInjectList();
            //			this.maxInjectOrder = 0;
            if (al == null || al.Count <= 0)
            {
                MessageBox.Show("没有选择数据!");
                return;
            }
            //{637EDB0D-3F39-4fde-8686-F3CD87B64581} 打印改为接口方式
            Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectCurePrint curePrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectCurePrint)) as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectCurePrint;
            if (curePrint == null)
            {
                curePrint = new Nurse.Print.ucPrintCure() as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectCurePrint;
                //Nurse.Print.ucPrintCure uc = new Nurse.Print.ucPrintCure();
            }
            curePrint.Init(al);
            //			uc.Init(alJiePing);
        }
        /// <summary>
        /// 打印注射单.
        /// </summary>
        private void PrintInject()
        {
            //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}
            ArrayList al = this.GetPrintInjectList();
            //			this.maxInjectOrder = 0;
            if (al == null || al.Count <= 0)
            {
                MessageBox.Show("没有选择数据!");
                return;
            }
            //{637EDB0D-3F39-4fde-8686-F3CD87B64581} 打印改为接口方式
            Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectPrint injectPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectPrint)) as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectPrint;
            if (injectPrint == null)
            {
                injectPrint = new Nurse.Print.ucPrintInject() as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectPrint;
                //Nurse.Print.ucPrintCure uc = new Nurse.Print.ucPrintCure();
            }
            //			if(alJiePing.Count > 0 )
            //			{
            //				al.AddRange(alJiePing);
            //			}
            injectPrint.Init(al);
        }
        /// <summary>
        /// 打印签名卡
        /// </summary>
        private void PrintItinerate()
        {
            //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}
            ArrayList al = this.GetPrintInjectList();
            //			this.maxInjectOrder = 0;
            if (al == null || al.Count <= 0)
            {
                MessageBox.Show("没有选择数据!");
                return;
            }
            //{637EDB0D-3F39-4fde-8686-F3CD87B64581} 打印改为接口方式
            Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectItineratePrint itineratePrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectItineratePrint)) as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectItineratePrint;
            if (itineratePrint == null)
            {
                itineratePrint = new Nurse.Print.ucPrintItinerate() as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectItineratePrint;
                //Nurse.Print.ucPrintItinerate uc = new Nurse.Print.ucPrintItinerate();
            }
            itineratePrint.Init(al);
        }
        /// <summary>
        /// 连续纸张的签名卡
        /// </summary>
        private void PrintItinerateLarge()
        {
            //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}
            ArrayList al = this.GetPrintInjectList();
            //			this.maxInjectOrder = 0;
            if (al == null || al.Count <= 0)
            {
                MessageBox.Show("没有选择数据!");
                return;
            }
            //{637EDB0D-3F39-4fde-8686-F3CD87B64581} 打印改为接口方式
            Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectItineratePrint itineratePrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectItineratePrint)) as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectItineratePrint;
            if (itineratePrint == null)
            {
                itineratePrint = new Nurse.Print.ucPrintItinerateLarge() as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectItineratePrint;
                //Nurse.Print.ucPrintItinerate uc = new Nurse.Print.ucPrintItinerate();
            }
            //			if(alJiePing.Count > 0 )
            //			{
            //				al.AddRange(alJiePing);
            //			}
            itineratePrint.Init(al);
        }

        /// <summary>
        /// {30E1EF7D-1236-4e38-A8E3-7567C9E33B0B} 增加号码条
        /// </summary>
        private void PrintNumber()
        {
            //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}
            ArrayList al = this.GetPrintInjectList();
            //			this.maxInjectOrder = 0;
            if (al == null || al.Count <= 0)
            {
                MessageBox.Show("没有选择数据!");
                return;
            }
            //{637EDB0D-3F39-4fde-8686-F3CD87B64581} 打印改为接口方式
            Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectNumberPrint numberPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectNumberPrint)) as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectNumberPrint;
            if (numberPrint == null)
            {
                numberPrint = new Nurse.Print.ucPrintNumber() as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectNumberPrint;
                //Nurse.Print.ucPrintNumber uc = new Nurse.Print.ucPrintNumber();
            }
            numberPrint.Init(al);
        }

        /// <summary>
        /// 获取要打印的数据
        /// {30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}
        /// </summary>
        /// <returns></returns>
        private ArrayList GetPrintInjectList()
        {
            ArrayList al = new ArrayList();
            ArrayList alJiePing = new ArrayList();
            this.neuSpread1.StopCellEditing();
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                if (this.neuSpread1_Sheet1.GetValue(i, 0).ToString().ToUpper() == "FALSE")
                    continue;
                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList detail =
                    (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList)this.neuSpread1_Sheet1.Rows[i].Tag;
                Neusoft.HISFC.Models.Order.OutPatient.Order orderinfo =
                    (Neusoft.HISFC.Models.Order.OutPatient.Order)this.neuSpread1_Sheet1.Cells[i, 11].Tag;
                Neusoft.HISFC.Models.Nurse.Inject info = new Neusoft.HISFC.Models.Nurse.Inject();

                info.Patient.Name = reg.Name;
                info.Patient.Sex.ID = reg.Sex.ID;
                info.Patient.Birthday = reg.Birthday;
              
                //zhangyt 2011-02-27  病历号
                info.Patient.PID.CardNO = reg.PID.CardNO;

                info.Patient.Name = reg.Name;
                info.Item = detail;
                info.Item.InjectCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[i, 2].Text);
                info.OrderNO = this.txtOrder.Text.ToString();
                info.Item.Order.Combo.ID = this.neuSpread1_Sheet1.Cells[i, 7].Tag.ToString();
                //医生名称
                Neusoft.HISFC.Models.Base.Employee ps = this.PsMgr.GetEmployeeInfo(detail.RecipeOper.ID);
                info.Item.Order.Doctor.Name = ps.Name;
                info.Item.Order.Doctor.ID = ps.ID;
                info.Item.Name = detail.Item.Name;
                string strOrder = "";
                if (this.neuSpread1_Sheet1.GetValue(i, 1) == null || this.neuSpread1_Sheet1.GetValue(i, 1).ToString() == "")
                {
                    strOrder = "";
                }
                else
                {
                    strOrder = this.neuSpread1_Sheet1.GetValue(i, 1).ToString();
                }
                info.InjectOrder = strOrder;
                al.Add(info);
                //判断接瓶,如果是则添加到alJiePing中
                if (orderinfo.ExtendFlag1 == null || orderinfo.ExtendFlag1.Length < 1)
                    orderinfo.ExtendFlag1 = "1|";
                //				string[] str = orderinfo.Mark1.Split('|');
                int inum = Neusoft.FrameWork.Function.NConvert.ToInt32(orderinfo.ExtendFlag1.Substring(0, 1));
                info.Memo = inum.ToString();
                //neusoft.neNeusoft.HISFC.Components.Function.NConvert.ToInt32(str[0]);
                //				if(inum > 1)
                //				{
                //					for(int m = 1 ; m < inum ; m++ )
                //					{
                //						Neusoft.HISFC.Models.Nurse.Inject inj = new Neusoft.HISFC.Models.Nurse.Inject();
                //						inj = info.Clone();
                //						inj.InjectOrder = (this.GetMaxInjectOrder() + 1).ToString();
                //						maxInjectOrder++;
                //						alJiePing.Add(inj);
                //					}
                //				}

                //{EB016FFE-0980-479c-879E-225462ECA6D0}
                info.PrintNo = detail.User02;
            }
            return al;
        }

        /// <summary>
        /// 获取最优先的使用方法
        /// </summary>
        /// <param name="IsInit">是否初始化</param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Base.Const GetFirstUsage()
        {
            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList info = new Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList();
            if (this.neuSpread1_Sheet1.RowCount <= 0) return new Neusoft.HISFC.Models.Base.Const();

            int FirstCodeNum = 10000;
            Neusoft.HISFC.Models.Base.Const retobj = new Neusoft.HISFC.Models.Base.Const();
            try
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    info = (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList)this.neuSpread1_Sheet1.Rows[i].Tag;
                    Neusoft.FrameWork.Models.NeuObject obj = this.conMgr.GetConstant("SPECIAL", info.Order.Usage.ID);
                    Neusoft.HISFC.Models.Base.Const conobj = (Neusoft.HISFC.Models.Base.Const)obj;

                    if (conobj.SortID < FirstCodeNum)
                    {
                        FirstCodeNum = conobj.SortID;
                        retobj = conobj;
                    }
                }
            }
            catch
            {
                return retobj;
            }

            return retobj;
        }
        #endregion	

        #region 注射顺序号的处理
        /// <summary>
        /// 设置默认注射顺序
        /// </summary>
        private void SetInject()
        {

            #region  没有数据就不管了,直接返回
            if (this.neuSpread1_Sheet1.RowCount <= 0) return;
            #endregion

            #region 设置患者今天的注射顺序号
            if (this.chkIsOrder.Checked)
            {
                this.SetOrder();
            }
            else
            {
                this.txtOrder.Text = "0";
                //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    this.neuSpread1_Sheet1.Cells[i, 14].Text = this.txtOrder.Text;
                }
            }
            #endregion

            #region 设置每组项目的注射顺序
            int InjectOrder = 1;
            this.neuSpread1_Sheet1.SetValue(0, 1, 1, false);
            for (int i = 1; i < this.neuSpread1_Sheet1.RowCount; i++)
            {

                if (this.neuSpread1_Sheet1.Cells[i, 7].Text == null || this.neuSpread1_Sheet1.Cells[i, 7].Text.Trim() == "")
                {
                    InjectOrder++;
                    this.neuSpread1_Sheet1.SetValue(i, 1, InjectOrder, false);
                }
                else if (this.neuSpread1_Sheet1.Cells[i, 7].Text != null && this.neuSpread1_Sheet1.Cells[i, 7].Text.Trim() != ""
                    //{24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
                    && this.neuSpread1_Sheet1.Cells[i, 7].Tag.ToString() + this.neuSpread1_Sheet1.Cells[i, 13].Text == this.neuSpread1_Sheet1.Cells[i - 1, 7].Tag.ToString() + this.neuSpread1_Sheet1.Cells[i - 1, 13].Text)
                {
                    this.neuSpread1_Sheet1.SetValue(i, 1, InjectOrder, false);
                }
                else
                {
                    InjectOrder++;
                    this.neuSpread1_Sheet1.SetValue(i, 1, InjectOrder, false);
                }
            }
            #endregion

        }

        /// <summary>
        /// 初始化注射顺序号
        /// </summary>
        private void InitOrder()
        {
            //读取是否自动生成注射顺序
            try
            {
                bool isAutoInjectOrder = false;
                isAutoInjectOrder = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.conMgr.QueryControlerInfo("900005"));
                if (isAutoInjectOrder)
                {
                    this.chkIsOrder.Checked = true;
                    this.SetOrder();
                    this.lbLastOrder.Text = "今天最后一次注射号:" +
                        (Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtOrder.Text.Trim()) - 1).ToString();
                }
                else
                {
                    this.chkIsOrder.Checked = false;
                    this.lbLastOrder.Text = "本机不自动生成注射顺序号!";
                    this.txtOrder.Text = "0";
                }
                //XmlDocument doc = new XmlDocument();
                //doc.Load(Application.StartupPath + "/Setting/NurseSetting.xml");
                //XmlNode node = doc.SelectSingleNode("//是否生成注射顺序");

                //if (node != null && node.Attributes["isAutoInjectOrder"].Value.ToString() == "false")
                //{
                //    this.chkIsOrder.Checked = false;
                //    this.lbLastOrder.Text = "本机不自动生成注射顺序号!";
                //    this.txtOrder.Text = "0";
                //}
                //else
                //{
                //    this.chkIsOrder.Checked = true;
                //    this.SetOrder();
                //    this.lbLastOrder.Text = "今天最后一次注射号:" +
                //        (Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtOrder.Text.Trim()) - 1).ToString();
                //}
            }
            catch //无配置文件
            {
                this.chkIsOrder.Checked = false;
                this.lbLastOrder.Text = "本机不自动生成注射顺序号!";
                this.txtOrder.Text = "0";
            }


        }
        /// <summary>
        /// 设置注射号
        /// </summary>
        private void SetOrder()
        {
            if (!this.chkIsOrder.Checked)
            {
                this.txtOrder.Text = "0";
                this.lbLastOrder.Text = "现在本机没有设置自动生成序号!";
                return;
            }
            //如果自动生成,设置第一个序号,并赋值this.currentOrder
            //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B} 改为通过接口实现，如果没有配置则按原代码生程序号
            this.CreateInterface();
            if (IGetOrderNo != null)
            {
                string orderNo = IGetOrderNo.GetOrderNo(this.reg);
                this.txtOrder.Text = orderNo;
                if (this.neuSpread1_Sheet1.Rows.Count == 0)
                {
                    return;
                }
                string comboAndInjectTime = this.neuSpread1_Sheet1.Cells[0, 7].Tag.ToString() + this.neuSpread1_Sheet1.Cells[0, 13].Text;
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    string rowComboAndInjectTime = this.neuSpread1_Sheet1.Cells[i, 7].Tag.ToString() + this.neuSpread1_Sheet1.Cells[i, 13].Text;
                    if (comboAndInjectTime != rowComboAndInjectTime)
                    {
                        comboAndInjectTime = rowComboAndInjectTime;
                        orderNo = IGetOrderNo.GetSamePatientNextOrderNo(orderNo);
                    }
                    this.neuSpread1_Sheet1.Cells[i, 14].Text = orderNo;
                }
                return;
            }
            else
            {
                Neusoft.HISFC.Models.Nurse.Inject info = this.InjMgr.QueryLast();
                if (info != null && info.Booker.OperTime != System.DateTime.MinValue)
                {
                    if (info.Booker.OperTime.ToString("yyyy-MM-dd")
                        == this.InjMgr.GetDateTimeFromSysDateTime().ToString("yyyy-MM-dd"))
                    {
                        this.txtOrder.Text = (Neusoft.FrameWork.Function.NConvert.ToInt32(info.OrderNO) + 1).ToString();
                    }
                    else
                    {
                        this.txtOrder.Text = "1";
                    }
                }
                else
                {
                    this.txtOrder.Text = "1";
                }
                //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    this.neuSpread1_Sheet1.Cells[i, 14].Text = this.txtOrder.Text;
                }
            }
        }

        /// <summary>
        /// 创建接口
        /// {30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}
        /// </summary>
        private void CreateInterface()
        {
            if (this.IGetOrderNo == null)
            {
                this.IGetOrderNo = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Nurse.IGetInjectOrderNo)) as Neusoft.HISFC.BizProcess.Interface.Nurse.IGetInjectOrderNo;
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 确认保存( 1.met_nuo_inject插入记录  2.fin_ipb_feeitemlist更新已确认院注数量，确认标志)
        /// </summary>
        private int Save()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
            {
                MessageBox.Show("没有要保存的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            
            this.neuSpread1.StopCellEditing();
            int selectNum = 0;
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                if (this.neuSpread1_Sheet1.GetValue(i, 0).ToString().ToUpper() == "FALSE" || this.neuSpread1_Sheet1.GetValue(i, 0).ToString() == "")
                {
                    selectNum++;
                }
            }
            if (selectNum >= this.neuSpread1_Sheet1.RowCount)
            {
                MessageBox.Show("请选择要保存的数据", "提示");
                return -1;
            }
            alInject = new ArrayList();
            alPrint = new ArrayList();
            #region 判断输入队列号的有效性
            if (this.txtOrder.Text == null || this.txtOrder.Text.Trim().ToString() == "")
            {
                MessageBox.Show("没有输入队列顺序号!");
                this.txtOrder.Focus();
                return -1;
            }
            //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}通过接口打印顺序号，该校验屏蔽
            //else if (this.IsNum(this.txtOrder.Text.Trim().ToString()) == false)
            //{
            //    MessageBox.Show("队列顺序号必须为数字!");
            //    this.txtOrder.Focus();
            //    return -1;
            //}
            else if (this.InjMgr.QueryInjectOrder(this.txtOrder.Text.Trim().ToString()).Count > 0)
            {
                if (MessageBox.Show("该队列号已经使用,是否继续!", "提示", System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    this.txtOrder.Focus();
                    return -1;
                }
            }
            //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}通过接口打印顺序号，该校验屏蔽
            //if (Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtOrder.Text) <= 0)
            //{
            //    MessageBox.Show("队列顺序号必须大于０!");
            //    this.txtOrder.Focus();
            //    return -1;
            //}
            #endregion

            #region 检查注射顺序号的有效性（组号相同的，注射顺序号也必须相同）
            for (int i = 1; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, 7].Tag != null && this.neuSpread1_Sheet1.Cells[i, 7].Tag.ToString() != "" &&
                    //{24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
                    this.neuSpread1_Sheet1.Cells[i, 7].Tag.ToString() + this.neuSpread1_Sheet1.Cells[i, 13].Text == this.neuSpread1_Sheet1.Cells[i - 1, 7].Tag.ToString() + this.neuSpread1_Sheet1.Cells[i - 1, 13].Text
                    && this.neuSpread1_Sheet1.GetValue(i, 1).ToString() != this.neuSpread1_Sheet1.GetValue(i - 1, 1).ToString()
                    )
                {
                    MessageBox.Show("相同组号的注射顺序号必须相同!", "第" + (i + 1).ToString() + "行");
                    return -1;
                }
            }
            #endregion

            #region 检查院注次数的有效性（组号相同的，注射顺序号也必须相同）
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                string strnum = this.neuSpread1_Sheet1.Cells[i, 2].Text;
                if (strnum == null || strnum == "")
                {
                    MessageBox.Show("院注次数不能为空!", "第" + (i + 1).ToString() + "行");
                    return -1;
                }
                if (!this.IsNum(strnum))
                {
                    MessageBox.Show("院注次数必须为数字!", "第" + (i + 1).ToString() + "行");
                    return -1;
                }
                string completenum = this.neuSpread1_Sheet1.Cells[i, 3].Text;
                if (this.neuSpread1_Sheet1.GetValue(i, 0).ToString().ToUpper() == "TRUE")
                {
                    if (Neusoft.FrameWork.Function.NConvert.ToInt32(strnum) <= Neusoft.FrameWork.Function.NConvert.ToInt32(completenum))
                    {
                        MessageBox.Show("院注次数已满!", "第" + (i + 1).ToString() + "行");
                        return -1;
                    }
                }
                //				if(this.fpSpread1_Sheet1.Cells[i,7].Tag != null && this.fpSpread1_Sheet1.Cells[i,7].Tag.ToString() != "" &&
                //					this.fpSpread1_Sheet1.Cells[i,7].Tag.ToString() == this.fpSpread1_Sheet1.Cells[i-1,7].Tag.ToString()
                //					&& this.fpSpread1_Sheet1.GetValue(i,2).ToString() != this.fpSpread1_Sheet1.GetValue(i-1,2).ToString()
                //					)
                //				{
                //					MessageBox.Show("相同组号的院注次数必须相同!","第"+ (i+1).ToString() +"行");
                //					return -1;
                //				}
            }
            #endregion

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //SQLCA.BeginTransaction();

            try
            {
                this.InjMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.patientMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.drugMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.DeptMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.PsMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                DateTime confirmDate = this.InjMgr.GetDateTimeFromSysDateTime();

                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    if (this.neuSpread1_Sheet1.GetText(i, 0).ToUpper() == "FALSE" ||
                        this.neuSpread1_Sheet1.GetText(i, 0) == "") continue;

                    Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList detail =
                        (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList)this.neuSpread1_Sheet1.Rows[i].Tag;

                    //					#region 判断是否需要打印注射单
                    //					if(detail.ConfirmedInject == 0)
                    //					{
                    //						IsFirstTime = true;
                    //						countInject = detail.InjectCount;
                    //					}
                    //					#endregion

                    Neusoft.HISFC.Models.Nurse.Inject info = new Neusoft.HISFC.Models.Nurse.Inject();
                    #region 实体转化（门诊项目收费明细实体FeeItemList－->注射实体Inject）
                    info.Patient.Name = reg.Name;
                    info.Patient.Sex.ID = reg.Sex.ID;
                    info.Patient.Birthday = reg.Birthday;
                    info.Patient.PID.CardNO= reg.PID.CardNO;

                    //info.Item = (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList)detail.Item;
                    info.Item = detail;
                    info.Item.ID = detail.Item.ID;
                    info.Item.Name = detail.Item.Name;

                    //info.Item.Item.MinFee.ID = detail.Item.MinFee.ID;
                    //info.Item.Item.Price = detail.Item.Price;
                    
               

                    

                    info.Item.InjectCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[i, 2].Text);
                    //开单科室名称
                    //Neusoft.HISFC.Models.Base.Department dept = this.DeptMgr.GetDepartment(detail.Order.DoctorDept.ID);
                    Neusoft.HISFC.Models.Base.Department dept = this.DeptMgr.GetDepartment(detail.RecipeOper.Dept.ID);
                    info.Item.Order.DoctorDept.Name = dept.Name;
                    info.Item.Order.DoctorDept.ID = dept.ID;
                    //医生名称
                    Neusoft.HISFC.Models.Base.Employee ps = this.PsMgr.GetEmployeeInfo(detail.RecipeOper.ID);
                    info.Item.Order.Doctor.Name = ps.Name;
                    info.Item.Order.Doctor.ID = ps.ID;
                    //是否皮试
                    if (this.neuSpread1_Sheet1.Cells[i, 11].Tag.ToString().ToUpper() == "TRUE")
                    {
                        info.Hypotest = "1";
                    }
                    else
                    {
                        info.Hypotest = "0";
                    }
                    #endregion

                    info.ID = this.InjMgr.GetSequence("Nurse.Inject.GetSeq");
                    //{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}
                    //info.OrderNO = this.txtOrder.Text.ToString();
                    info.OrderNO = this.neuSpread1_Sheet1.Cells[i, 14].Text;
                    //{24A47206-F111-4817-A7B4-353C21FC7724}
                    info.PrintNo = detail.User02;
                    info.Item.Order.Combo.ID = this.neuSpread1_Sheet1.Cells[i, 7].Tag.ToString();
                    info.Booker.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
                    info.Booker.OperTime = confirmDate;
                    info.Item.ExecOper.ID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
                    string strOrder = "";
                    if (this.neuSpread1_Sheet1.GetValue(i, 1) == null || this.neuSpread1_Sheet1.GetValue(i, 1).ToString() == "")
                    {
                        strOrder = "";
                    }
                    else
                    {
                        strOrder = this.neuSpread1_Sheet1.GetValue(i, 1).ToString();
                    }
                    info.InjectOrder = strOrder;

                    //备注--(取医嘱备注)
                    Neusoft.HISFC.Models.Order.OutPatient.Order orderinfo =
                        (Neusoft.HISFC.Models.Order.OutPatient.Order)this.neuSpread1_Sheet1.Cells[i, 11].Tag;
                    if (orderinfo != null)
                    {
                        info.Memo = orderinfo.ExtendFlag1;
                    }

                    #region 向met_nuo_inject中，插入记录
                    if (this.InjMgr.Insert(info) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.InjMgr.Err, "提示");
                        return -1;
                    }
                    #endregion

                    #region 向fin_ipb_feeitemlist中，插入数量

                    if (this.patientMgr.UpdateConfirmInject(detail.Order.ID, detail.RecipeNO, detail.SequenceNO.ToString(), 1) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.patientMgr.Err, "提示");
                        return -1;
                    }
                    #endregion
                    info.Item.InjectCount = info.Item.InjectCount;
                    //打吊瓶的才打印治疗单---先写死-------------此段程序不用,改为由操作员选择是否打印
                    if (info.Item.Order.Usage.ID == "03" || info.Item.Order.Usage.ID == "04")
                    {
                        alPrint.Add(info);
                    }
                    alInject.Add(info);
                    this.lbLastOrder.Text = "今天最后一次注射号:" + info.OrderNO;

                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();

            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return -1;
            }

            MessageBox.Show("保存成功!", "提示");
            this.Clear();
            this.lbCue.Text = "";

            this.txtCardNo.SelectAll();
            this.txtRecipe.Text = "";
            this.txtCardNo.Text = "";
            this.txtCardNo.Focus();
            return 0;
        }
        /// <summary>
        /// 清空
        /// </summary>
        private void Clear()
        {
            if (this.neuSpread1_Sheet1.RowCount > 0)
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.RowCount);
            this.txtOrder.Text = "";
            this.txtRecipe.Text = "";
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void Query()
        {
            //this.Clear();
            if (this.neuSpread1_Sheet1.RowCount > 0)
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.RowCount);
            string cardNo;
            cardNo = this.txtCardNo.Text.Trim().PadLeft(10, '0');
            //获取医生开立的处方信息（没有全部执行完的）
            DateTime dtFrom = this.dtpStart.Value.Date;
            DateTime dtTo = this.dtpEnd.Value.Date.AddDays(1);

            if (/*this.txtRecipe.Text == null ||*/ this.txtRecipe.Text.Trim() == "")
            {
                al = this.patientMgr.QueryOutpatientFeeItemListsZs(cardNo, dtFrom, dtTo);

                //al = this.patientMgr.QueryOutpatientFeeItemLists(cardNo, dtFrom, dtTo);
            }
            else
            {
                al = this.patientMgr.QueryFeeDetailFromRecipeNO(this.txtRecipe.Text.Trim());

                if (al == null)
                {
                    return;
                }

                if (al.Count > 0)
                {
                    Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item = (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList)al[0];
                    reg = this.regMgr.GetByClinic(item.Patient.ID);
                    if (reg == null || reg.ID == "")
                    {
                        MessageBox.Show("没有病历号为:" + item.Patient.ID + "的患者!", "提示");

                        this.txtCardNo.Focus();
                        return;
                    }

                    this.txtCardNo.Text = item.Patient.PID.CardNO;
                    this.SetPatient(reg);
                    this.txtRecipe.Text = "";
                    this.Query();
                    return;
                }

            }

            this.Query(al);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        private void Query(ArrayList al)
        {
            if (al == null || al.Count == 0)
            {
                MessageBox.Show("该患者没有需要确认的医嘱信息!", "提示");
                this.txtCardNo.Focus();
                return;
            }
            this.AddDetail(al);
            if (this.neuSpread1_Sheet1.RowCount <= 0)
            {
                MessageBox.Show("该时间段内没有该患者信息!", "提示");
                this.txtCardNo.Focus();
                return;
            }
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                int confirmNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[i, 3].Text);
                if (confirmNum == 0)
                {
                    this.lbCue.Text = "首次院注,请核对院注次数!";
                    this.lbCue.ForeColor = System.Drawing.Color.Magenta;
                }
            }
            this.SelectAll(true);
            this.SetComb();

            #region 此处添加一个医嘱备注
            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList info
                        = (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList)this.neuSpread1_Sheet1.Rows[i].Tag;
                    //
                    Neusoft.HISFC.BizProcess.Integrate.Order orderMgr = new Neusoft.HISFC.BizProcess.Integrate.Order();
                    Neusoft.HISFC.Models.Order.OutPatient.Order orderinfo = new Neusoft.HISFC.Models.Order.OutPatient.Order();

                    orderinfo = orderMgr.GetOneOrder(info.Order.ID);
                    if (orderinfo != null && orderinfo.Memo != null)
                    {
                        this.neuSpread1_Sheet1.SetText(i, 12, orderinfo.Memo);
                        string strHypoTest = "";
                        if (orderinfo.HypoTest == 1)
                        {
                            strHypoTest = "否";
                        }
                        else if (orderinfo.HypoTest == 2)
                        {
                            strHypoTest = "是";
                        }
                        else if (orderinfo.HypoTest == 3)
                        {
                            strHypoTest = "阳性";
                        }
                        else if (orderinfo.HypoTest == 4)
                        {
                            strHypoTest = "阴性";
                        }
                        this.neuSpread1_Sheet1.Cells[i, 11].Text = strHypoTest;
                        this.neuSpread1_Sheet1.Cells[i, 11].Tag = orderinfo;
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.Cells[i, 11].Tag = new Neusoft.HISFC.Models.Order.OutPatient.Order();
                    }
                }
            #endregion

            }

            this.SetFP();
            this.ShowColor();
            this.txtOrder.Focus();
        }
        /// <summary>
        /// 添加项目明细
        /// </summary>
        /// <param name="detail"></param>
        private void AddDetail(ArrayList details)
        {
            if (this.neuSpread1_Sheet1.RowCount > 0) this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.RowCount);
            //{24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
            List<Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList> tmpFeeList = new List<Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList>();
            if (details != null)
            {
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList detail in al)
                {
                    #region  非药品不显示
                    //非药品不显示
                    //if (detail.Item.IsPharmacy == false) continue;
                    if (detail.Item.ItemType != HISFC.Models.Base.EnumItemType.Drug) continue;
                    #endregion

                    #region 不是院注的不显示
                    //不是院注的不显示-------权益之计
                    Neusoft.HISFC.BizProcess.Integrate.Manager con = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                    Neusoft.FrameWork.Models.NeuObject obj = con.GetConstant("SPECIAL", detail.Order.Usage.ID);
                    if (obj == null || obj.ID == null || obj.ID == "")
                    {
                        continue;
                    }
                    //					neusoft.neNeusoft.HISFC.Components.Object.neuObject obj = con.Get(Neusoft.HISFC.Models.Base.enuConstant.USAGE,detail.UsageInfo.ID);
                    //					if(obj.Memo == null ||obj.Memo == "" || obj.Memo != this.Tag.ToString().Trim()) continue;
                    #endregion

                    #region  院注次数 <= 已确认院注次数 的不显示

                    //院注次数 <= 已确认院注次数 的不显示
                    if (detail.InjectCount != 0 && detail.InjectCount <= detail.ConfirmedInjectCount && !this.cbFinish.Checked)
                    {
                        continue;
                    }
                    #endregion

                    #region 是否显示0次数的
                    if (!chkNullNum.Checked && detail.InjectCount == 0)
                    {
                        continue;
                    }
                    #endregion

                    #region 只显示最后一次遗嘱
                    //					if(this.chkLast.Checked )
                    //					{
                    //						this.ShowLastOnly();
                    //					}
                    #endregion

                    #region 今天已经登记的QD不显示，注射两次的BID不显示，当前午别注射一次的BID不再显示。(根据今天的登记时间)
                    DateTime dt = Neusoft.FrameWork.Function.NConvert.ToDateTime(
                        this.InjMgr.GetDateTimeFromSysDateTime().ToString("yyyy-MM-dd 00:00:00"));
                    //{24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
                    ArrayList alTodayInject = this.InjMgr.Query(detail.Patient.PID.CardNO, detail.RecipeNO, detail.SequenceNO.ToString(), dt);
                    Neusoft.HISFC.Models.Order.Frequency frequence = this.dicFrequency[detail.Order.Frequency.ID];
                    string[] injectTime = frequence.Time.Split('-');
                    //当天的已经全部注射完毕后跳过
                    if (alTodayInject.Count >= injectTime.Length)
                    {
                        continue;
                    }
                    if (this.isShowAllInject)
                    {
                        for (int i = alTodayInject.Count; i < injectTime.Length; i++)
                        {
                            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList newDetail = detail.Clone();
                            newDetail.User03 = injectTime[i];
                            tmpFeeList.Add(newDetail);
                        }
                    }
                    else
                    {
                        //未过上次注射时间的话不允许再次登记
                        if (alTodayInject.Count > 0)
                        {
                            DateTime lastInjectTime = FrameWork.Function.NConvert.ToDateTime(dt.ToString("yyyy-MM-dd ") + injectTime[alTodayInject.Count - 1] + ":00");
                            if (this.InjMgr.GetDateTimeFromSysDateTime() < lastInjectTime)
                            {
                                continue;
                            }
                        }
                        detail.User03 = injectTime[alTodayInject.Count];
                        tmpFeeList.Add(detail);
                    }
                    //if (detail.Order.Frequency.ID == "QD")
                    //{
                    //    ArrayList alTemp = this.InjMgr.Query(detail.Patient.PID.CardNO, detail.RecipeNO,
                    //        detail.SequenceNO.ToString(), dt);
                    //    if (alTemp != null)
                    //    {
                    //        if (alTemp.Count > 0) continue;
                    //    }
                    //}
                    //if (detail.Order.Frequency.ID == "BID")
                    //{
                    //    ArrayList alTemp = this.InjMgr.Query(detail.Patient.PID.CardNO, detail.RecipeNO,
                    //        detail.SequenceNO.ToString(), dt);
                    //    if (alTemp != null && alTemp.Count > 0)
                    //    {
                    //        if (alTemp.Count >= 2) continue;
                    //        //当前午别注射一次的BID不再显示
                    //        Neusoft.HISFC.Models.Nurse.Inject item = (Neusoft.HISFC.Models.Nurse.Inject)alTemp[0];
                    //        bool bl1 = true;
                    //        bool bl2 = true;
                    //        if (Neusoft.FrameWork.Function.NConvert.ToInt32(item.Booker.OperTime.ToString("HH")) > 12) bl1 = false;
                    //        if (Neusoft.FrameWork.Function.NConvert.ToInt32(this.InjMgr.GetDateTimeFromSysDateTime().ToString("HH")) > 12) bl2 = false;
                    //        if (bl1 == bl2) continue;
                    //    }
                    //}
                    #endregion
                    //{24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
                    //this.AddDetail(detail);
                }
                //{24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
                //排序
                tmpFeeList.Sort(new FeeItemListSort());
                //获取打印序号
                this.CreateInterface();
                if (this.IGetOrderNo != null)
                {
                    this.IGetOrderNo.SetPrintNo(new ArrayList(tmpFeeList.ToArray()));
                }
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItem in tmpFeeList)
                {
                    this.AddDetail(feeItem);
                }

                if (this.neuSpread1_Sheet1.RowCount > 0)
                {
                    this.LessShow();
                }
            }
            #region {A9925B9E-1918-461e-BEFE-3104E86E0B4F} 未收治疗费的医嘱显示另类颜色
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, 2].Text == "0")
                {
                    this.neuSpread1_Sheet1.Rows[i].ForeColor = Color.Blue;
                }
            }
            #endregion
        }
        /// <summary>
        /// 添加明细
        /// </summary>
        /// <param name="detail"></param>
        private void AddDetail(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList info)
        {
            this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.RowCount, 1);
            int row = this.neuSpread1_Sheet1.RowCount - 1;
            this.neuSpread1_Sheet1.Rows[row].Tag = info;

            #region "窗口赋值"
            #region 获取皮试信息
            //获取皮试信息
           // Neusoft.HISFC.Models.Pharmacy.Item drug = this.drugMgr.GetItem(info.ID);
            Neusoft.HISFC.Models.Pharmacy.Item drug = this.drugMgr.GetItem(info.Item.ID);
            if (drug == null)
            {
                MessageBox.Show("获取药品皮试信息失败!");
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.RowCount);
                return;
            }
            string strTest = "否";
            if (drug.IsAllergy)
            {
                strTest = "是";
            }
            //
            #endregion
            Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department(); 
               dept = this.DeptMgr.GetDepartment(info.RecipeOper.Dept.ID);
            info.Order.DoctorDept.Name = dept.Name;

            this.neuSpread1_Sheet1.SetValue(row, 1, "", false);//注射顺序号
            this.neuSpread1_Sheet1.SetValue(row, 2, info.InjectCount.ToString(), false);//院注次数
            this.neuSpread1_Sheet1.SetValue(row, 3, info.ConfirmedInjectCount.ToString(), false);//已经确认的院注次数
            this.neuSpread1_Sheet1.SetValue(row, 4, this.GetDoctByID(info.RecipeOper.ID), false);//开单医生
            this.neuSpread1_Sheet1.Cells[row, 4].Tag = info.Order.Doctor.ID;
            this.neuSpread1_Sheet1.SetValue(row, 5, dept.Name, false);//科别
            this.neuSpread1_Sheet1.Cells[row, 5].Tag = info.Order.DoctorDept.ID;
            this.neuSpread1_Sheet1.SetValue(row, 6, info.Item.Name, false);//药品名称
            this.neuSpread1_Sheet1.Cells[row, 7].Tag = info.Order.Combo.ID;//组合号
            this.neuSpread1_Sheet1.SetValue(row, 8, info.Order.DoseOnce.ToString() + info.Order.DoseUnit, false);//每次量
            this.neuSpread1_Sheet1.SetValue(row, 9, info.Order.Frequency.ID, false);//频次
            this.neuSpread1_Sheet1.Cells[row, 9].Tag = info.Order.Frequency.ID.ToString();
            this.neuSpread1_Sheet1.SetValue(row, 10, info.Order.Usage.Name, false);//用法
            this.neuSpread1_Sheet1.SetValue(row, 11, strTest, false);//皮试？
            this.neuSpread1_Sheet1.Cells[row, 11].Tag = drug.IsAllergy.ToString().ToUpper();
            //{24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
            this.neuSpread1_Sheet1.Cells[row, 13].Text = info.User03;
            #endregion
        }
        /// <summary>
        /// 设置组合号
        /// </summary>
        private void SetComb()
        {
            int myCount = this.neuSpread1_Sheet1.RowCount;
            int i;
            //第一行
            this.neuSpread1_Sheet1.SetValue(0, 7, "┓");
            //最后行
            this.neuSpread1_Sheet1.SetValue(myCount - 1, 7, "┛");
            //中间行
            for (i = 1; i < myCount - 1; i++)
            {
                int prior = i - 1;
                int next = i + 1;
                string currentRowCombNo = this.neuSpread1_Sheet1.Cells[i, 7].Tag.ToString();
                string priorRowCombNo = this.neuSpread1_Sheet1.Cells[prior, 7].Tag.ToString();
                string nextRowCombNo = this.neuSpread1_Sheet1.Cells[next, 7].Tag.ToString();

                //{24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
                string currentRowInjectTime = this.neuSpread1_Sheet1.Cells[i, 13].Text.ToString();
                string priorRowInjectTime = this.neuSpread1_Sheet1.Cells[prior, 13].Text.ToString();
                string nextRowInjectTime = this.neuSpread1_Sheet1.Cells[next, 13].Text.ToString();

                #region """""
                bool bl1 = true;
                bool bl2 = true;
                //{24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
                if (currentRowCombNo + currentRowInjectTime != priorRowCombNo + priorRowInjectTime)
                    bl1 = false;
                if (currentRowCombNo + currentRowInjectTime != nextRowCombNo + nextRowInjectTime)
                    bl2 = false;
                //  ┃
                if (bl1 && bl2)
                {
                    this.neuSpread1_Sheet1.SetValue(i, 7, "┃");
                }
                //  ┛
                if (bl1 && !bl2)
                {
                    this.neuSpread1_Sheet1.SetValue(i, 7, "┛");
                }
                //  ┓
                if (!bl1 && bl2)
                {
                    this.neuSpread1_Sheet1.SetValue(i, 7, "┓");
                }
                //  ""
                if (!bl1 && !bl2)
                {
                    this.neuSpread1_Sheet1.SetValue(i, 7, "");
                }
                #endregion
            }
            //把没有组号的去掉
            for (i = 0; i < myCount; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, 7].Tag.ToString() == "")
                {
                    this.neuSpread1_Sheet1.SetValue(i, 7, "");
                }
            }
            //判断首末行 有组号，且只有自己一组数据的情况
            if (myCount == 1)
            {
                this.neuSpread1_Sheet1.SetValue(0, 7, "");
            }
            //只有首末两行，那么还要判断组号啊
            if (myCount == 2)
            {
                if (this.neuSpread1_Sheet1.Cells[0, 7].Tag.ToString().Trim() != this.neuSpread1_Sheet1.Cells[1, 7].Tag.ToString().Trim())
                {
                    this.neuSpread1_Sheet1.SetValue(0, 7, "");
                    this.neuSpread1_Sheet1.SetValue(1, 7, "");
                }
            }
            if (myCount > 2)
            {
                if (this.neuSpread1_Sheet1.GetValue(1, 7).ToString() != "┃"
                    && this.neuSpread1_Sheet1.GetValue(1, 7).ToString() != "┛")
                {
                    this.neuSpread1_Sheet1.SetValue(0, 7, "");
                }
                if (this.neuSpread1_Sheet1.GetValue(myCount - 2, 7).ToString() != "┃"
                    && this.neuSpread1_Sheet1.GetValue(myCount - 2, 7).ToString() != "┓")
                {
                    this.neuSpread1_Sheet1.SetValue(myCount - 1, 7, "");
                }
            }

        }

        /// <summary>
        /// 打印
        /// </summary>
        private void Print()
        {
            if (this.alPrint == null || this.alPrint.Count <= 0)
            {
                MessageBox.Show("没有需要打印的数据!");
                return;
            }
            Nurse.Print.ucPrintCure uc = new Nurse.Print.ucPrintCure();
            uc.Init(alPrint);

            if (this.IsFirstTime)
            {
                Nurse.Print.ucPrintInject uc2 = new Nurse.Print.ucPrintInject();
                uc2.Init(alInject);
            }
            alPrint.Clear();
            alInject.Clear();
        }

        /// <summary>
        /// 全选
        /// </summary>
        private void SelectedAll(bool isSelected)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                //{FAC1693A-3EBA-44b3-A1E3-6D6750A98D80}
                //this.neuSpread1_Sheet1.SetValue(i, 0, isSelected, false);
                this.neuSpread1_Sheet1.Cells[i, 0].Value = isSelected;
            }
        }

        private void SelectedComb(bool isSelect)
        {
            
            int row = this.neuSpread1_Sheet1.ActiveRowIndex;
            string combID = this.neuSpread1_Sheet1.Cells[row, 7].Tag.ToString();
            //{24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
            string injectTime = this.neuSpread1_Sheet1.Cells[row, 13].Text;
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                //{24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
                if (this.neuSpread1_Sheet1.Cells[i, 7].Tag.ToString() == combID && this.neuSpread1_Sheet1.Cells[i, 13].Text == injectTime) 
                {
                    this.neuSpread1_Sheet1.Cells[i, 0].Value = isSelect;
                }
            }

        }

        /// <summary>
        /// 修改皮试信息//{26E88889-B2CF-4965-AFD8-6D9BE4519EBF}
        /// </summary>
        private void ModifyHytest()
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                bool isSelected = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value);
                if (isSelected)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order orderinfo = this.neuSpread1_Sheet1.Cells[i, 11].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                    if (orderinfo.HypoTest == 1) continue;
                    al.Add(orderinfo);
                }

            }

            if (al.Count == 0)
            {
                return;
            }
            Forms.frmHypoTest frmHypoTest = new Neusoft.HISFC.Components.Nurse.Forms.frmHypoTest();
            frmHypoTest.AlOrderList = al;
            DialogResult d = frmHypoTest.ShowDialog();
            if (d == DialogResult.OK)
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    bool isSelected = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value);
                    if (!isSelected)
                    {
                        continue;
                    }
                    Neusoft.HISFC.Models.Order.OutPatient.Order orderinfo = this.neuSpread1_Sheet1.Cells[i, 11].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                    string strHypoTest = "";
                    if (orderinfo.HypoTest == 1)
                    {
                        strHypoTest = "否";
                    }
                    else if (orderinfo.HypoTest == 2)
                    {
                        strHypoTest = "是";
                    }
                    else if (orderinfo.HypoTest == 3)
                    {
                        strHypoTest = "阳性";
                    }
                    else if (orderinfo.HypoTest == 4)
                    {
                        strHypoTest = "阴性";
                    }
                    this.neuSpread1_Sheet1.Cells[i, 11].Text = strHypoTest;

                }
            }


        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public ucRegister()
        {
            InitializeComponent();
        }

        private void ucDept_Load(object sender, EventArgs e)
        {
            this.Init();
            this.SetFP();
            //{24A47206-F111-4817-A7B4-353C21FC7724} 初始化帮助类
            this.InitHelper();
            //{EB016FFE-0980-479c-879E-225462ECA6D0} 瓶签补打
            this.ucCureReprint1.Init();
        }

        /// <summary>
        /// 初始化帮助类
        /// {24A47206-F111-4817-A7B4-353C21FC7724}
        /// </summary>
        private void InitHelper()
        {
            //频次
            ArrayList alFrequency = this.conMgr.QuereyFrequencyList();
            foreach (Neusoft.HISFC.Models.Order.Frequency frequency in alFrequency)
            {
                this.dicFrequency.Add(frequency.ID, frequency);
            }
        }

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtRecipe.Text = string.Empty;
                if (this.txtCardNo.Text.Trim() == "")
                {
                    MessageBox.Show("请输入病历号!", "提示");
                    this.txtCardNo.Focus();
                    return;
                }
                string cardNo = this.txtCardNo.Text.Trim().PadLeft(10, '0');
                ArrayList alRegs = this.regMgr.Query(cardNo, this.dtpStart.Value);
                if (alRegs == null || alRegs.Count == 0)
                {
                    MessageBox.Show("没有病历号为:" + cardNo + "的患者!", "提示");
                    this.txtCardNo.Focus();
                    return;
                }
                reg = alRegs[0] as Neusoft.HISFC.Models.Registration.Register;
                if (reg == null || reg.ID == "")
                {
                    MessageBox.Show("没有病历号为:" + cardNo + "的患者!", "提示");

                    this.txtCardNo.Focus();
                    return;
                }

                this.txtCardNo.Text = cardNo;
                this.SetPatient(reg);

                //分解注射项目
                if (al != null)
                {
                    this.Query();
                    this.SetInject();
                }
                this.txtCardNo.Focus();
                this.txtRecipe.SelectAll();
            }
        }

        private void txtRecipe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtCardNo.Text = string.Empty;
                if (this.txtRecipe.Text.Trim() == "")
                {
                    this.txtRecipe.Focus();
                    return;
                }
                this.Query();
                this.SetInject();
                this.txtRecipe.Focus();
                this.txtRecipe.SelectAll();
            }
        }

        private void txtOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtCardNo.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            int altKey = Keys.Alt.GetHashCode();

            if (keyData == Keys.F1)
            {
                this.SelectAll(true);
                return true;
            }
            if (keyData == Keys.F2)
            {
                this.SelectAll(false);
                return true;
            }
            if (keyData.GetHashCode() == altKey + Keys.S.GetHashCode())
            {
                if (this.Save() == 0)
                {
                    this.Print();
                }
                return true;
            }
            if (keyData.GetHashCode() == altKey + Keys.Q.GetHashCode())
            {
                this.Query();
                return true;
            }
            if (keyData.GetHashCode() == altKey + Keys.P.GetHashCode())
            {
                //
                return true;
            }
            if (keyData.GetHashCode() == altKey + Keys.X.GetHashCode())
            {
                this.FindForm().Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void neuSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            int row = this.neuSpread1_Sheet1.ActiveRowIndex;
            bool isSelect = Convert.ToBoolean(this.neuSpread1_Sheet1.Cells[row, 0].Value);
            this.SelectedComb(isSelect);
        }

        /// <summary>
        /// 排序
        /// {24A47206-F111-4817-A7B4-353C21FC7724} 患者可以登记全天所有注射处方
        /// </summary>
        public class FeeItemListSort : IComparer<Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList>
        {
            public int Compare(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList x, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList y)
            {
                //先按照处方排序
                if (x.Order.ReciptNO != y.Order.ReciptNO)
                {
                    return y.Order.ReciptNO.CompareTo(x.Order.ReciptNO);
                }
                //按注射时间排序
                if (x.User03 != y.User03)
                {
                    return y.User03.CompareTo(x.User03);
                }
                //按组合号排序
                if (x.Order.Combo.ID != y.Order.Combo.ID)
                {
                    return y.Order.Combo.ID.CompareTo(x.Order.Combo.ID);
                }
                //处方内序号
                if (x.Order.SequenceNO != y.Order.SequenceNO)
                {
                    return y.Order.SequenceNO.CompareTo(x.Order.SequenceNO);
                }
                //药品编码
                if (x.Item.ID != y.Item.ID)
                {
                    return y.Item.ID.CompareTo(x.Item.ID);
                }
                return 0;
            }
        }
    }
}
