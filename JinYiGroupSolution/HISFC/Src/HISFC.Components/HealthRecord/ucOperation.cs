using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FarPoint.Win.Spread;
using Neusoft.HISFC.Object.HealthRecord.EnumServer;
namespace UFC.HealthRecord
{
    public partial class ucOperation : UserControl
    {
        public ucOperation()
        {
            InitializeComponent();
        }

        #region   全局变量
        //配置文件路径 
        //private string filePath = Application.StartupPath + "\\profile\\OperationCard.xml";
        //如果是 "DOC" 查询的是医生站录入的手术信息 如果输入的是“CAS”，则查询病案师录入的手术信息
        private Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes operType;
        //产科分娩婴儿记录表 
        private DataTable dtOperation;
        private DataView dvOperation;
        /// <summary>
        ///ICD 诊断信息 列表
        /// </summary>
        private Neusoft.NFC.Interface.Controls.PopUpListBox ICDType = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        //切口类型
        private Neusoft.NFC.Interface.Controls.PopUpListBox NickType = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper NickTypeHelper = new Neusoft.NFC.Public.ObjectHelper();

        //愈合类型
        private Neusoft.NFC.Interface.Controls.PopUpListBox CicaType = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper CicaTypeHelper = new Neusoft.NFC.Public.ObjectHelper();
        //麻醉方式列表
        private Neusoft.NFC.Interface.Controls.PopUpListBox NarcType = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper NarcTypeHelper = new Neusoft.NFC.Public.ObjectHelper();
        //手术/麻醉医生列表
        private Neusoft.NFC.Interface.Controls.PopUpListBox DoctorType = new Neusoft.NFC.Interface.Controls.PopUpListBox();

        private Neusoft.HISFC.Object.RADT.PatientInfo patient = new Neusoft.HISFC.Object.RADT.PatientInfo();
        #endregion

        #region 属性
        //		/// <summary>
        //		///如果是 "DOC" 查询的是医生站录入的手术信息 如果输入的是“CAS”，则查询病案师录入的手术信息
        //		/// </summary>
        //		public string OperType
        //		{
        //			set
        //			{
        //				operType =value;
        //			}
        //		}
        //		/// <summary>
        //		/// 住院流水号
        //		/// </summary>
        //		public string InpatientNo
        //		{
        //			set
        //			{
        //				if(value != null)
        //				{
        //					inpatientNo = value;
        //					try
        //					{
        //						LoadInfo();
        //					}
        //					catch
        //					{
        //					}
        //				}
        //			}
        //		}
        ////		/// <summary>
        ////		/// 新增加的数据
        ////		/// </summary>
        ////		public ArrayList AddList
        ////		{
        ////			get
        ////			{
        ////				try
        ////				{
        ////					GetList("A");
        ////				}
        ////				catch{}
        ////				return addList;
        ////			}
        ////		}
        ////		/// <summary>
        ////		/// 修改过的数据
        ////		/// </summary>
        ////		public ArrayList ModList
        ////		{
        ////			get
        ////			{
        ////				try
        ////				{
        ////					GetList("M");
        ////				}
        ////				catch{}
        ////				return modList;
        ////			}
        ////		}
        ////		/// <summary>
        ////		/// 删除的数据
        ////		/// </summary>
        ////		public ArrayList DelList
        ////		{
        ////			get
        ////			{
        ////				try
        ////				{
        ////					GetList("D");
        ////				}
        ////				catch{}
        ////				return delList;
        ////			}
        ////		}
        #endregion

        #region 函数
       
        /// <summary>
        /// 限定格的宽度很可见性 
        /// </summary>
        private void LockFpEnter()
        {
            this.fpSpread1_Sheet1.Columns[0].Width = 76; //手术日期
            this.fpSpread1_Sheet1.Columns[1].Width = 93;//手术名称
            this.fpSpread1_Sheet1.Columns[2].Width = 40;//术者 A
            this.fpSpread1_Sheet1.Columns[3].Width = 40; //术者 B
            this.fpSpread1_Sheet1.Columns[4].Width = 40; //I 助
            this.fpSpread1_Sheet1.Columns[5].Width = 40; //II 助
            this.fpSpread1_Sheet1.Columns[6].Width = 40; //麻醉方式
            this.fpSpread1_Sheet1.Columns[7].Width = 80; //切口愈合等级
            this.fpSpread1_Sheet1.Columns[7].Locked = true;//切口愈合等级
            this.fpSpread1_Sheet1.Columns[8].Width = 50; //麻醉医师
            this.fpSpread1_Sheet1.Columns[9].Width = 100; //ICD-9-CM-3编号
            this.fpSpread1_Sheet1.Columns[9].Locked = true; //ICD-9-CM-3编号
            this.fpSpread1_Sheet1.Columns[10].Width = 50; //切口
            this.fpSpread1_Sheet1.Columns[11].Width = 50; //愈合
            this.fpSpread1_Sheet1.Columns[12].Width = 40; //统计
            this.fpSpread1_Sheet1.Columns[13].Visible = false; //医师代码1
            this.fpSpread1_Sheet1.Columns[14].Visible = false; //医师代码2
            this.fpSpread1_Sheet1.Columns[15].Visible = false; //助手编码1
            this.fpSpread1_Sheet1.Columns[16].Visible = false; //助手编码2
            this.fpSpread1_Sheet1.Columns[17].Visible = false; //麻醉医师编码
            this.fpSpread1_Sheet1.Columns[18].Visible = false; //发生序号
        }
        /// <summary>
        /// 清空原有的数据
        /// </summary>
        /// <returns></returns>
        public int ClearInfo()
        {
            if (this.dtOperation != null)
            {
                this.dtOperation.Clear();
                LockFpEnter();
            }
            else
            {
                MessageBox.Show("手术表为null");
            }
            return 1;
        }
        public int SetReadOnly(bool type)
        {
            if (type)
            {
                this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            }
            else
            {
                this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
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
            foreach (Neusoft.HISFC.Object.HealthRecord.OperationDetail obj in list)
            {
                if (obj.InpatientNO == "" || obj.InpatientNO == null)
                {
                    MessageBox.Show("住院流水号不能为空");
                    return -1;
                }
                if (obj.OperationInfo.ID == "" || obj.OperationInfo.Name == "")
                {
                    MessageBox.Show("手术信息不能为空");
                    return -1;
                }
                if (obj.InpatientNO.Length > 14)
                {
                    MessageBox.Show("住院流水号过长");
                    return -1;
                }
                if (obj.HappenNO.Length > 2)
                {
                    MessageBox.Show("发生序号过长");
                    return -1;
                }
                if (obj.OperType == "" || obj.OperType == null)
                {
                    MessageBox.Show("类别不能为空");
                    return -1;
                }
                if (obj.OperType.Length > 1)
                {
                    MessageBox.Show("类别编码过长");
                    return -1;
                }
            }
            return 0;
        }
        /// <summary>
        /// 删除当前行 
        /// </summary>
        /// <returns></returns>
        public int DeleteActiveRow()
        {
            if (fpSpread1_Sheet1.Rows.Count > 0)
            {
                this.fpSpread1_Sheet1.Rows.Remove(fpSpread1_Sheet1.ActiveRowIndex, 1);
            }
            if (fpSpread1_Sheet1.Rows.Count == 0)
            {
                ICDType.Visible = false;
                NickType.Visible = false;
                CicaType.Visible = false;
                NarcType.Visible = false;
                DoctorType.Visible = false;
            }
            return 1;
        }
        /// <summary>
        /// 删除空白的行
        /// </summary>
        /// <returns></returns>
        public int deleteRow()
        {
            if (fpSpread1_Sheet1.Rows.Count == 1)
            {
                //第一行编码为空 
                if (fpSpread1_Sheet1.Cells[0, 1].Text == "" && fpSpread1_Sheet1.Cells[0, 2].Text == "")
                {
                    fpSpread1_Sheet1.Rows.Remove(0, 1);
                }
            }
            return 1;
        }
        /// <summary>
        /// 保存对表做的所有修改
        /// </summary>
        /// <returns></returns>
        public int fpEnterSaveChanges()
        {
            try
            {
                this.dtOperation.AcceptChanges();
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
            dtOperation.AcceptChanges();
            LockFpEnter();
            return 0;
        }
        public int AddInfoToTable(ArrayList list)
        {
            if (this.dtOperation != null)
            {
                this.dtOperation.Clear();
                this.dtOperation.AcceptChanges();
            }
            if (list != null)
            {
                //循环插入数据
                foreach (Neusoft.HISFC.Object.HealthRecord.OperationDetail info in list)
                {
                    DataRow row = dtOperation.NewRow();
                    SetRow(row, info);
                    dtOperation.Rows.Add(row);
                }
            }
            else
            {
                return -1;
            }
            //更改标志
            if ((this.operType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC && this.patient.CaseState == "2") || (this.operType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.CAS && this.patient.CaseState == "3"))
            {
                //清空表的标志位
                dtOperation.AcceptChanges();
            }

            //			if(System.IO.File.Exists(filePath))
            //			{
            //				Neusoft.NFC.Interface.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1_Sheet1,filePath);
            //			}
            LockFpEnter();
            return 0;
        }
    
        //添加一行项目
        public int AddRow()
        {
            //			DialogResult result = MessageBox.Show("是否要增加一行","提示",MessageBoxButtons.YesNo);
            //			if(result == DialogResult.No)
            //			{
            //				return 0 ;
            //			}
            if (fpSpread1_Sheet1.Rows.Count < 1)
            {
                //增加一行空值
                DataRow row = dtOperation.NewRow();
                dtOperation.Rows.Add(row);
                //切口愈合登记
                fpSpread1_Sheet1.Cells[0, 7].Text = "/";
                fpSpread1_Sheet1.Cells[0, 0].Value = System.DateTime.Now;
            }
            else if (fpSpread1_Sheet1.ActiveRowIndex == fpSpread1_Sheet1.Rows.Count - 1)
            {
                //增加一行
                int row = fpSpread1_Sheet1.ActiveRowIndex;
                int col = fpSpread1_Sheet1.Columns.Count;
                fpSpread1_Sheet1.Rows.Add(fpSpread1_Sheet1.Rows.Count, 1);
                for (int i = 0; i < col; i++)
                {
                    fpSpread1_Sheet1.Cells[row + 1, i].Value = fpSpread1_Sheet1.Cells[row, i].Value;
                }
            }
            fpSpread1.Focus();
            fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.Rows.Count, 0);
            return 0;
        }
        /// <summary>
        /// 初始化 变量
        /// </summary>
        public void InitInfo()
        {
            try
            {
                InputMap im;
                im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
                im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

                im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
                im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

                im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
                im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

                fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;



                InitDataTable();
                //切口类型
                IniNickType();
                //愈合类型
                IniCicaType();
                //麻醉方式
                InitNarcList();
                //医生列表
                InitDoctorList();

                fpSpread1.EditModePermanent = true;
                fpSpread1.EditModeReplace = true;
                fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
                LockFpEnter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadInfo(Neusoft.HISFC.Object.RADT.PatientInfo patientInfo, Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes Type)
        {
            if (dtOperation == null)
            {
                return;
            }
            if (patientInfo == null)
            {
                return;
            }
            //保存病人信息
            patient = patientInfo;
            //赋值操作类型
            operType = Type;
            Neusoft.HISFC.Management.HealthRecord.Operation op = new Neusoft.HISFC.Management.HealthRecord.Operation();
            if (patient.ID == "")
            {
                return;
            }
            //查询符合条件的数据
            ArrayList list = op.QueryOperation(operType, patient.ID);
            if (list == null)
            {
                MessageBox.Show("查询手术信息出错!");
                return;
            }
            if (list.Count == 0)
            {
                if (operType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.CAS)
                {
                    list = op.QueryOperation(Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC, patient.ID);
                }
            }
            this.AddInfoToTable(list);
        }

        /// <summary>
        /// 获取相关的数据
        /// creator:zhangjunyi@Neusoft.com
        /// </summary>
        /// <param name="str"> “A”增加 “M” 修改 “D”删除</param>
        /// <returns>失败返回 false </returns>
        public bool GetList(string str, ArrayList list)
        {
            try
            {
                if (dtOperation == null)
                {
                    list = null;
                    return false;
                }
                this.fpSpread1.StopCellEditing();
                switch (str)
                {
                    case "A":
                        //获取新增加的数据
                        DataTable AddTable = dtOperation.GetChanges(DataRowState.Added);
                        //提取数据
                        GetChange(AddTable, list);
                        break;
                    case "M":
                        //获取修改过的数据
                        DataTable ModTable = dtOperation.GetChanges(DataRowState.Modified);
                        //提取数据
                        GetChange(ModTable, list);
                        break;
                    case "D":
                        //获取修改过的数据
                        DataTable DelTable = dtOperation.GetChanges(DataRowState.Deleted);
                        if (DelTable != null)
                        {
                            DelTable.RejectChanges();
                        }
                        //提取数据
                        GetChange(DelTable, list);
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                list = null;
                return false;
            }
        }

        /// <summary>
        /// 获取修改过的数据 
        /// </summary>
        /// <param name="table">要提取数据的Table</param>
        /// <param name="list"> 输出的数组</param>
        /// <returns>失败返回false ,且数组返回null 成功返回 null</returns>
        private bool GetChange(DataTable table, ArrayList list)
        {
            try
            {
                if (table == null)
                {
                    return false;
                }
                Neusoft.HISFC.Object.HealthRecord.OperationDetail bb;
                foreach (DataRow row in table.Rows)
                {
                    bb = new Neusoft.HISFC.Object.HealthRecord.OperationDetail();
                    //操作类型 医生站录入的或病案室录入的
                    if (operType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC)
                    {
                        bb.OperType = "1";
                    }
                    else if (operType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.CAS)
                    {
                        bb.OperType = "2";
                    }
                    bb.InpatientNO = patient.ID;
                    bb.OperationDate = Neusoft.NFC.Function.NConvert.ToDateTime(row["手术日期"]);
                    bb.OperationInfo.Name = row["手术名称"].ToString();
                    bb.FirDoctInfo.Name = row["术者 A"].ToString();
                    bb.FourDoctInfo.Name = row["术者 B"].ToString();
                    bb.SecDoctInfo.Name = row["I 助"].ToString();
                    bb.ThrDoctInfo.Name = row["II 助"].ToString();
                    if (row["麻醉方式"].ToString() != "")
                    {
                        bb.MarcKind = NarcTypeHelper.GetID(row["麻醉方式"].ToString());
                    }
                    bb.NarcDoctInfo.Name = row["麻醉医师"].ToString();
                    bb.OperationInfo.ID = row["ICD-9-CM-3编号"].ToString();
                    if (row["切口"].ToString() != "")
                    {
                        bb.NickKind = NickTypeHelper.GetID(row["切口"].ToString());
                    }
                    if (row["愈合"].ToString() != "")
                    {
                        bb.CicaKind = CicaTypeHelper.GetID(row["愈合"].ToString());
                    }
                    if (row["统计"] != DBNull.Value)
                    {
                        if (Convert.ToBoolean(row["统计"]))
                        {
                            bb.StatFlag = "0";
                        }
                        else
                        {
                            bb.StatFlag = "1";
                        }
                    }
                    else
                    {
                        bb.StatFlag = "1";
                    }
                    bb.FirDoctInfo.ID = row["医师代码1"].ToString();
                    bb.FourDoctInfo.ID = row["医师代码2"].ToString();
                    bb.SecDoctInfo.ID = row["助手编码1"].ToString();
                    bb.ThrDoctInfo.ID = row["助手编码2"].ToString();
                    bb.NarcDoctInfo.ID = row["麻醉医师编码"].ToString();
                    bb.HappenNO = row["发生序号"].ToString();
                    bb.OutDate = this.patient.PVisit.OutTime;//出院日期
                    bb.InDate = patient.PVisit.InTime; //入院日期 
                    bb.DeatDate = patient.DeathTime; //死亡时间 
                    bb.OperationDeptInfo.ID = ""; //手术科室
                    bb.OutDeptInfo.ID = patient.PVisit.PatientLocation.ID; //出院科室
                    //					bb.OperDate = dateTime;
                    list.Add(bb);
                }
                return true;
            }
            catch (Exception ex)
            {
                list = null;
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 初始化table 
        /// </summary>
        /// <returns></returns>
        private bool InitDataTable()
        {
            try
            {
                dtOperation = new DataTable("手术信息记录表");
                dvOperation = new DataView(dtOperation);
                Type strType = typeof(System.String);
                Type intType = typeof(System.Int32);
                Type dtType = typeof(System.DateTime);
                Type boolType = typeof(System.Boolean);
                Type floatType = typeof(System.Single);

                dtOperation.Columns.AddRange(new DataColumn[]{
																 new DataColumn("手术日期", dtType),  //0
																 new DataColumn("手术名称", strType), //1
																 new DataColumn("术者 A", strType),//2
																 new DataColumn("术者 B", strType),//3
																 new DataColumn("I 助", strType),//4
																 new DataColumn("II 助", strType),//5
																 new DataColumn("麻醉方式", strType), //6
																 new DataColumn("切口愈合等级", strType),//7
																 new DataColumn("麻醉医师", strType),//8
																 new DataColumn("ICD-9-CM-3编号", strType),//9
																 new DataColumn("切口", strType),//10
																 new DataColumn("愈合", strType),//11
																 new DataColumn("统计", boolType),//12
																 new DataColumn("医师代码1", strType),//13
																 new DataColumn("医师代码2", strType),//14
																 new DataColumn("助手编码1", strType),//15
																 new DataColumn("助手编码2", strType),//16
																 new DataColumn("麻醉医师编码", strType),//17
																 new DataColumn("发生序号", strType)});//18

                //				//设置主键为序号列
                //				CreateKeys(dtOperation);

                this.fpSpread1.DataSource = dvOperation;
                fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
                //设置fpSpread1 的属性
                //				if(System.IO.File.Exists(filePath))
                //				{
                //					Neusoft.NFC.Interface.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1_Sheet1,filePath);
                //				}
                //				else
                //				{
                //					Neusoft.NFC.Interface.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1_Sheet1,filePath);
                //				}
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// 将实体中的值赋值到row中
        /// </summary>
        /// <param name="row">传入的row</param>
        /// <param name="info">传入的实体</param>
        private void SetRow(DataRow row, Neusoft.HISFC.Object.HealthRecord.OperationDetail info)
        {
            row["手术日期"] = info.OperationDate;
            row["手术名称"] = info.OperationInfo.Name;
            row["术者 A"] = info.FirDoctInfo.Name;
            row["术者 B"] = info.FourDoctInfo.Name;
            row["I 助"] = info.SecDoctInfo.Name;
            row["II 助"] = info.ThrDoctInfo.Name;
            if (info.MarcKind != "")
            {
                row["麻醉方式"] = NarcTypeHelper.GetName(info.MarcKind);
            }
            row["切口愈合等级"] = NickTypeHelper.GetName(info.NickKind) + "/" + CicaTypeHelper.GetName(info.CicaKind);
            row["麻醉医师"] = info.NarcDoctInfo.Name;
            row["ICD-9-CM-3编号"] = info.OperationInfo.ID;
            if (info.NickKind != "")
            {
                row["切口"] = NickTypeHelper.GetName(info.NickKind);
            }
            if (info.CicaKind != "")
            {
                row["愈合"] = CicaTypeHelper.GetName(info.CicaKind);
            }
            if (info.StatFlag == "0")
            {
                row["统计"] = true;
            }
            else
            {
                row["统计"] = false;
            }
            row["医师代码1"] = info.FirDoctInfo.ID;
            row["医师代码2"] = info.FourDoctInfo.ID;
            row["助手编码1"] = info.SecDoctInfo.ID;
            row["助手编码2"] = info.ThrDoctInfo.ID;
            row["发生序号"] = info.HappenNO;
        }

        /// <summary>
        /// 初始化 医生列表和麻醉医师列表
        /// </summary>
        private void InitDoctorList()
        {
            Neusoft.HISFC.Management.Manager.Person per = new Neusoft.HISFC.Management.Manager.Person();
            //获取手术/麻醉医生列表
            ArrayList list = per.GetEmployee(Neusoft.HISFC.Object.Base.EnumEmployeeType.D);
            if (list != null)
            {
                DoctorType.AddItems(list);
            }
            //加载 listBox
            Controls.Add(DoctorType);
            //隐藏
            DoctorType.Hide();
            //设置边框
            DoctorType.BorderStyle = BorderStyle.Fixed3D;
            DoctorType.BringToFront();
            DoctorType.SelectNone = true;
            //				lbDept.Font=new System.Drawing.Font("宋体", 12F);
            //定义listBox的单击事件
            DoctorType.SelectItem += new Neusoft.NFC.Interface.Controls.PopUpListBox.MyDelegate(diagType_SelectItem);
        }

        /// <summary>
        /// 初始化ICD手术列表
        /// </summary>
        public void InitICDList()
        {
            //ICD手术诊断
            Neusoft.HISFC.Management.HealthRecord.ICD icd = new Neusoft.HISFC.Management.HealthRecord.ICD();
            ArrayList icdList = icd.Query(ICDTypes.ICDOperation, QueryTypes.Valid);
            //			Neusoft.HISFC.Management.Fee.Item item = new Neusoft.HISFC.Management.Fee.Item();
            //			ArrayList  icdList = item.GetOperationItemList();
            //加载列表
            if (icdList != null)
            {

                ICDType.AddItems(icdList);
            }
            //加载 listBox
            Controls.Add(ICDType);
            //隐藏
            ICDType.Hide();
            //设置边框
            ICDType.BorderStyle = BorderStyle.Fixed3D;
            ICDType.BringToFront();
            ICDType.SelectNone = true;
            //定义listBox的单击事件
            ICDType.SelectItem += new Neusoft.NFC.Interface.Controls.PopUpListBox.MyDelegate(diagType_SelectItem);
        }
        /// <summary>
        /// 单击选择事件 
        /// </summary>
        /// <param name="key"></param>
        /// <returns> 成功返回 0</returns>
        private int diagType_SelectItem(Keys key)
        {
            ProcessDept();
            return 0;
        }
        /// <summary>
        /// 麻醉方式列表
        /// </summary>
        private void InitNarcList()
        {
            Neusoft.HISFC.Management.Manager.Constant con = new Neusoft.HISFC.Management.Manager.Constant();
            //从常数表中获取麻醉类型
            ArrayList list = con.GetList("ANESTYPE");
            if (list != null)
            {
                //填充下拉框
                NarcType.AddItems(list);
                NarcTypeHelper.ArrayObject = list;
            }
            //加载 listBox
            Controls.Add(NarcType);
            //隐藏
            NarcType.Hide();
            //设置边框
            NarcType.BorderStyle = BorderStyle.Fixed3D;
            NarcType.BringToFront();
            NarcType.SelectNone = true;
            //				lbDept.Font=new System.Drawing.Font("宋体", 12F);
            //定义listBox的单击事件
            NarcType.SelectItem += new Neusoft.NFC.Interface.Controls.PopUpListBox.MyDelegate(diagType_SelectItem);
        }
        /// <summary>
        /// 初始化切口列表
        /// </summary>
        private void IniNickType()
        {
            Neusoft.HISFC.Management.Manager.Constant con = new Neusoft.HISFC.Management.Manager.Constant();
            //从常数表中获取切口类型
            ArrayList list = con.GetList("INCITYPE");
            if (list != null)
            {
                NickType.AddItems(list);
                NickTypeHelper.ArrayObject = list;
            }
            //加载 listBox
            Controls.Add(NickType);
            //隐藏
            NickType.Hide();
            //设置边框
            NickType.BorderStyle = BorderStyle.Fixed3D;
            NickType.BringToFront();
            NickType.SelectNone = true;
            //				lbDept.Font=new System.Drawing.Font("宋体", 12F);
            //定义listBox的单击事件
            NickType.SelectItem += new Neusoft.NFC.Interface.Controls.PopUpListBox.MyDelegate(diagType_SelectItem);
        }
        /// <summary>
        /// 初始化愈合列表
        /// </summary>
        private void IniCicaType()
        {
            Neusoft.HISFC.Management.Manager.Constant con = new Neusoft.HISFC.Management.Manager.Constant();
            //从常数表中获取切口类型
            ArrayList list = con.GetList("CICATYPE");
            if (list != null)
            {
                CicaType.AddItems(list);
                CicaTypeHelper.ArrayObject = list;
            }
            //加载 listBox
            Controls.Add(CicaType);
            //隐藏
            CicaType.Hide();
            //设置边框
            CicaType.BorderStyle = BorderStyle.Fixed3D;
            CicaType.BringToFront();
            CicaType.SelectNone = true;
            //				lbDept.Font=new System.Drawing.Font("宋体", 12F);
            //定义listBox的单击事件
            CicaType.SelectItem += new Neusoft.NFC.Interface.Controls.PopUpListBox.MyDelegate(diagType_SelectItem);
        }
        /// <summary>
        /// 处理fpSpread1,执行科室的回车
        /// </summary>
        /// <returns></returns>
        private int ProcessDept()
        {
            try
            {
                int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                if (CurrentRow < 0) return 0;

                if (fpSpread1_Sheet1.ActiveColumnIndex == 1)
                {
                    //获取选中的信息
                    Neusoft.NFC.Object.NeuObject item = null;
                    int rtn = ICDType.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //ICD诊断名称
                    fpSpread1_Sheet1.ActiveCell.Text = item.Name;
                    //ICD诊断编码
                    fpSpread1_Sheet1.Cells[CurrentRow, 9].Text = item.ID;
                    ICDType.Visible = false;
                    fpSpread1.Focus();
                    fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 2);
                    return 0;
                }
                else if (fpSpread1_Sheet1.ActiveColumnIndex == 2)
                {
                    //获取选中的信息
                    Neusoft.NFC.Object.NeuObject item = null;
                    int rtn = DoctorType.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //术者A
                    fpSpread1_Sheet1.ActiveCell.Text = item.Name;
                    //术者A编码
                    fpSpread1_Sheet1.Cells[CurrentRow, 13].Text = item.ID;
                    DoctorType.Visible = false;
                    fpSpread1.Focus();
                    fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 3, true);
                    return 0;
                }
                else if (fpSpread1_Sheet1.ActiveColumnIndex == 3)
                {
                    //获取选中的信息
                    Neusoft.NFC.Object.NeuObject item = null;
                    int rtn = DoctorType.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //术者B
                    fpSpread1_Sheet1.ActiveCell.Text = item.Name;
                    //术者B编码
                    fpSpread1_Sheet1.Cells[CurrentRow, 14].Text = item.ID;
                    DoctorType.Visible = false;
                    fpSpread1.Focus();
                    fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 4, true);
                    return 0;
                }
                else if (fpSpread1_Sheet1.ActiveColumnIndex == 4)
                {
                    //获取选中的信息
                    Neusoft.NFC.Object.NeuObject item = null;
                    int rtn = DoctorType.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //一助A
                    fpSpread1_Sheet1.ActiveCell.Text = item.Name;
                    //一助A编码
                    fpSpread1_Sheet1.Cells[CurrentRow, 15].Text = item.ID;
                    DoctorType.Visible = false;
                    fpSpread1.Focus();
                    fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 5, true);
                    return 0;
                }
                else if (fpSpread1_Sheet1.ActiveColumnIndex == 5)
                {
                    //获取选中的信息
                    Neusoft.NFC.Object.NeuObject item = null;
                    int rtn = DoctorType.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //二助
                    fpSpread1_Sheet1.ActiveCell.Text = item.Name;
                    //二助编码
                    fpSpread1_Sheet1.Cells[CurrentRow, 16].Text = item.ID;
                    DoctorType.Visible = false;
                    fpSpread1.Focus();
                    fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 6, true);
                    return 0;
                }
                else if (fpSpread1_Sheet1.ActiveColumnIndex == 6)
                {
                    //获取选中的信息
                    Neusoft.NFC.Object.NeuObject item = null;
                    int rtn = NarcType.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //麻醉方式
                    fpSpread1_Sheet1.ActiveCell.Text = item.Name;
                    NarcType.Visible = false;
                    fpSpread1.Focus();
                    fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 8, true);
                    return 0;
                }
                else if (fpSpread1_Sheet1.ActiveColumnIndex == 8)
                {
                    //获取选中的信息
                    Neusoft.NFC.Object.NeuObject item = null;
                    int rtn = DoctorType.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //麻醉医师
                    fpSpread1_Sheet1.ActiveCell.Text = item.Name;
                    //麻醉医师编码
                    fpSpread1_Sheet1.Cells[CurrentRow, 17].Text = item.ID;
                    DoctorType.Visible = false;
                    fpSpread1.Focus();
                    fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 10, true);
                    return 0;
                }

                else if (fpSpread1_Sheet1.ActiveColumnIndex == 9)
                {
                    //获取选中的信息
                    Neusoft.NFC.Object.NeuObject item = null;
                    int rtn = ICDType.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //ICD诊断编码
                    fpSpread1_Sheet1.ActiveCell.Text = item.ID;
                    //ICD诊断名称 
                    fpSpread1_Sheet1.Cells[CurrentRow, 1].Text = item.Name;
                    ICDType.Visible = false;
                    fpSpread1.Focus();
                    fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 10, true);
                    return 0;
                }
                else if (fpSpread1_Sheet1.ActiveColumnIndex == 10)
                {
                    //获取选中的信息
                    Neusoft.NFC.Object.NeuObject item = null;
                    int rtn = NickType.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //切口类型
                    fpSpread1_Sheet1.ActiveCell.Text = item.Name;
                    NickType.Visible = false;

                    //切口愈合等级
                    string strText = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 7].Text;
                    //获取/之后的字符串 替换/之前的字符串
                    strText = item.Name + strText.Substring(GetStrPosition(strText, "/"));
                    fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 7].Text = strText;

                    fpSpread1.Focus();
                    fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 11, true);
                    return 0;
                }
                else if (fpSpread1_Sheet1.ActiveColumnIndex == 11)
                {
                    //获取选中的信息
                    Neusoft.NFC.Object.NeuObject item = null;
                    int rtn = CicaType.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //愈合类型
                    fpSpread1_Sheet1.ActiveCell.Text = item.Name;
                    CicaType.Visible = false;

                    //切口愈合等级
                    string strText = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 7].Text;
                    //获取 /之前的字符串  替换 /之后的字符串
                    strText = strText.Substring(0, GetStrPosition(strText, "/") + 1) + item.Name;
                    fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 7].Text = strText;

                    fpSpread1.Focus();
                    fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 12);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        private int GetStrPosition(string strStr, string subStr)
        {
            return strStr.LastIndexOf(subStr);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            try
            {
                switch (keyData)
                {
                    case Keys.Enter:
                        #region 回车事件
                        if (fpSpread1.ContainsFocus)
                        {
                            int i = fpSpread1_Sheet1.ActiveColumnIndex;
                            if (i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 8 || i == 9 || i == 10 || i == 11)
                            {
                                ProcessDept();
                            }
                            if (i == 0)
                            {
                                //手术日期
                                fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 1);
                            }
                            if (i == 7)
                            {
                                //切口愈合类型
                                fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 8);
                            }
                            if (i == 12)
                            {
                                if (fpSpread1_Sheet1.ActiveRowIndex < fpSpread1_Sheet1.Rows.Count - 1)
                                {
                                    //如果不是最后一行 ，跳到最后一行第一格
                                    fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex + 1, 0);
                                }
                                else
                                {
                                    //									//如果是最后一行 跳到本行第一格
                                    //									fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex,0);
                                    //增加一行
                                    this.AddRow();
                                }
                            }
                        }
                        break;
                        #endregion
                    case Keys.Up:
                        #region 上键
                        if (fpSpread1.ContainsFocus)
                        {
                            //手术诊断
                            if (ICDType.Visible)
                            {
                                ICDType.PriorRow();
                            }
                            //切口类型
                            else if (NickType.Visible)
                            {
                                NickType.PriorRow();
                            }
                            //愈合类型
                            else if (CicaType.Visible)
                            {
                                CicaType.PriorRow();
                            }
                            //麻醉类型
                            else if (NarcType.Visible)
                            {
                                NarcType.PriorRow();
                            }
                            //医生列表
                            else if (DoctorType.Visible)
                            {
                                DoctorType.PriorRow();
                            }
                            else
                            {
                                int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                                if (CurrentRow > 0)
                                {
                                    fpSpread1_Sheet1.ActiveRowIndex = CurrentRow - 1;
                                    fpSpread1_Sheet1.AddSelection(CurrentRow - 1, 0, 1, 0);
                                }
                            }
                        }
                        break;
                        #endregion
                    case Keys.Down:
                        #region  下键

                        if (fpSpread1.ContainsFocus)
                        {
                            //手术诊断
                            if (ICDType.Visible)
                            {
                                ICDType.NextRow();
                            }
                            //切口类型
                            else if (NickType.Visible)
                            {
                                NickType.NextRow();
                            }
                            //愈合类型
                            else if (CicaType.Visible)
                            {
                                CicaType.NextRow();
                            }
                            //麻醉类型
                            else if (NarcType.Visible)
                            {
                                NarcType.NextRow();
                            }
                            //医生列表
                            else if (DoctorType.Visible)
                            {
                                DoctorType.NextRow();
                            }
                            else
                            {
                                int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;

                                if (CurrentRow < fpSpread1_Sheet1.RowCount - 1)
                                {
                                    fpSpread1_Sheet1.ActiveRowIndex = CurrentRow + 1;
                                    fpSpread1_Sheet1.AddSelection(CurrentRow + 1, 0, 1, 0);
                                }
                                else
                                {
                                    //									AddRow();							
                                }
                            }
                        }
                        break;

                        #endregion
                    case Keys.NumPad1:
                        #region 数字键 1
                        //统计标志
                        if (fpSpread1_Sheet1.ActiveColumnIndex == 12)
                        {
                            //统计标志取反
                            if (fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 12].Value == null)
                            {
                                fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 12].Value = true;
                            }
                            else if (fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 12].Value.ToString() == "False")
                            {
                                fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 12].Value = true;
                            }
                            else
                            {
                                fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 12].Value = false;
                            }
                            //							//跳转
                            //							if(fpSpread1_Sheet1.ActiveRowIndex < fpSpread1_Sheet1.Rows.Count -1)
                            //							{
                            //								//如果不是最后一行 ，跳到下一行第一格
                            //								fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex+1,0);
                            //							}
                            //							else
                            //							{
                            //								//如果是最后一行 跳到本行第一格
                            //								fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex,0);
                            //							}
                        }
                        #endregion
                        break;
                    case Keys.Escape:
                        ICDType.Visible = false;
                        NickType.Visible = false;
                        CicaType.Visible = false;
                        NarcType.Visible = false;
                        DoctorType.Visible = false;
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return base.ProcessDialogKey(keyData);
        }
        /// <summary>
        /// 单元格处于编辑状态时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                switch (e.Column)
                {

                    case 1:
                        //过滤诊断类别
                        //获取当前格的值
                        ICDType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                        //筛选数据
                        break;
                    case 9:
                        //过滤ICD诊断名称
                        //获取当前格的值
                        ICDType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                        //筛选数据
                        break;

                    #region  医生

                    case 2:
                        //过滤术者A
                        //获取当前格的值
                        DoctorType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                        //筛选数据
                        break;
                    case 3:
                        //过滤术者B
                        //获取当前格的值
                        DoctorType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                        //筛选数据
                        break;
                    case 4:
                        //过滤一助
                        //获取当前格的值
                        DoctorType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                        //筛选数据
                        break;
                    case 5:
                        //过滤二助
                        //获取当前格的值
                        DoctorType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                        //筛选数据
                        break;
                    case 8:
                        //过滤麻醉医师名称
                        //获取当前格的值
                        DoctorType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                        //筛选数据
                        break;

                    #endregion

                    case 6:
                        //过滤麻醉方式名称
                        //获取当前格的值
                        NarcType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                        //筛选数据
                        break;
                    case 10:
                        //过滤切口名称
                        //获取当前格的值
                        NickType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                        //筛选数据
                        break;
                    case 11:
                        //过滤愈合名称
                        //获取当前格的值
                        CicaType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                        //筛选数据
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 设置下来菜单的显示位置
        /// </summary>
        /// <returns></returns>

        private int SetLocation()
        {
            Control _cell = fpSpread1.EditingControl;
            //当前活动列
            int intCol = fpSpread1_Sheet1.ActiveColumnIndex;
            //设置 ICD诊断 下拉框的位置 
            if (intCol == 1 || intCol == 9)
            {
                ICDType.Location = new Point(panel1.Location.X + _cell.Location.X,
                    panel1.Location.Y + panel1.Location.Y + _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
                //				ICDType.Size=new Size(_cell.Width+SystemInformation.Border3DSize.Width*2,150);
                ICDType.Size = new Size(200, 200);
            }
            //设置 医生下拉框的位置 
            else if (intCol == 2 || intCol == 3 || intCol == 4 || intCol == 5 || intCol == 8)
            {
                DoctorType.Location = new Point(panel1.Location.X + _cell.Location.X,
                    panel1.Location.Y + panel1.Location.Y + _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
                //				DoctorType.Size=new Size(_cell.Width+SystemInformation.Border3DSize.Width*2,150);
                DoctorType.Size = new Size(200, 150);
            }
            //设置 麻醉方式 下拉框的位置 
            else if (intCol == 6)
            {
                NarcType.Location = new Point(panel1.Location.X + _cell.Location.X,
                    panel1.Location.Y + panel1.Location.Y + _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
                //				NarcType.Size=new Size(_cell.Width+SystemInformation.Border3DSize.Width*2,150);
                NarcType.Size = new Size(150, 100);
            }
            //设置 切口 下拉框的位置 
            else if (intCol == 10)
            {
                NickType.Location = new Point(panel1.Location.X + _cell.Location.X,
                    panel1.Location.Y + panel1.Location.Y + _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
                //				NickType.Size=new Size(_cell.Width+SystemInformation.Border3DSize.Width*2,150);
                NickType.Size = new Size(150, 100);
            }
            //设置 愈合 下拉框的位置 
            else if (intCol == 11)
            {
                CicaType.Location = new Point(panel1.Location.X + _cell.Location.X,
                    panel1.Location.Y + panel1.Location.Y + _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
                //				CicaType.Size=new Size(_cell.Width+SystemInformation.Border3DSize.Width*2,150);
                CicaType.Size = new Size(150, 100);
            }

            return 0;
        }

        private void fpSpread1_EditModeOn(object sender, System.EventArgs e)
        {
            try
            {
                //			fpSpread1.EditingControl.KeyDown+=new KeyEventHandler(EditingControl_KeyDown);
                SetLocation();
                int intCol = fpSpread1_Sheet1.ActiveColumnIndex;
                //设置 ICD诊断 下拉框的可见性
                if (intCol != 1 && intCol != 9)
                {
                    ICDType.Visible = false;
                }
                //设置 医生下拉框的可见性
                if (intCol != 2 || intCol != 3 || intCol != 4 || intCol != 5 || intCol != 8)
                {
                    DoctorType.Visible = false;
                }
                //设置 麻醉类型下拉框的可见性
                if (intCol != 6)
                {
                    NarcType.Visible = false;
                }
                //设置 切口下拉框的可见性
                if (intCol != 10)
                {
                    NickType.Visible = false;
                }
                //设置 愈合下拉框的可见性
                if (intCol != 11)
                {
                    CicaType.Visible = false;
                }

                //手术诊断
                if (intCol == 1 || intCol == 9)
                {
                    ICDType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                    ICDType.Visible = true;
                }
                //医生
                else if (intCol == 2 || intCol == 3 || intCol == 4 || intCol == 5 || intCol == 8)
                {
                    DoctorType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                    DoctorType.Visible = true;
                }
                //麻醉方式
                else if (intCol == 6)
                {
                    NarcType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                    NarcType.Visible = true;
                }
                //切口
                else if (intCol == 10)
                {
                    NickType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                    NickType.Visible = true;
                }
                //愈合
                else if (intCol == 11)
                {
                    CicaType.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                    CicaType.Visible = true;
                }
            }
            catch { }
        }
        /// <summary>
        /// 获取列号
        /// </summary>
        /// <param name="view"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public int ColumnIndex(FarPoint.Win.Spread.SheetView view, string str)
        {
            try
            {
                foreach (FarPoint.Win.Spread.Column col in view.Columns)
                {
                    if (col.Label == str)
                    {
                        return col.Index;
                    }
                }
                MessageBox.Show("没有找到" + str + "列");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            //			//设置fpSpread1 的属性
            //			if(System.IO.File.Exists(filePath))
            //			{
            //				Neusoft.NFC.Interface.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1_Sheet1,filePath);
            //			}
        }
        //设置
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            SetUp();
        }
        /// <summary>
        ///设置fpSpread1_Sheet1 的属性
        /// </summary>
        public void SetUp()
        {
            //Neusoft.UFC.Common.Controls.ucSetColumn uc = new Neusoft.UFC.Common.Controls.ucSetColumn();
            //uc.FilePath = this.filePath;
            //uc.GoDisplay += new Neusoft.UFC.Common.Controls.ucSetColumn.DisplayNow(uc_GoDisplay);
            //Neusoft.NFC.Interface.Classes.Function.PopShowControl(uc);
        }
        /// <summary>
        /// 调整fpSpread1_Sheet1的宽度等 保存后触发的事件
        /// </summary>
        private void uc_GoDisplay()
        {
            LoadInfo(patient, operType); //重新加载数据

        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            DeleteRow();
        }
        /// <summary>
        /// 删除 
        /// </summary>
        /// <returns></returns>
        public int DeleteRow()
        {
            this.fpSpread1_Sheet1.Rows.Remove(fpSpread1_Sheet1.ActiveRowIndex, 1);
            return 1;
        }
        #endregion

        #region 废弃
        /// <summary>
        /// 返回当前得行数
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃", true)]
        public int GetfpSpread1RowCount()
        {
            return this.fpSpread1_Sheet1.Rows.Count;
        }
        /// <summary>
        /// 设置活动单元格
        /// </summary>
        [Obsolete("废弃", true)]
        public void SetActiveCells()
        {
            try
            {
                this.fpSpread1_Sheet1.SetActiveCell(0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion 
    }
}
