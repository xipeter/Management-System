using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.WinForms.Forms;
using Neusoft.FrameWork.WinForms.Classes;
using System.Collections;

namespace Neusoft.HISFC.Components.Manager.Forms
{
    public partial class frmMaintenacePop : Form
    {

        private List<Neusoft.FrameWork.Models.NeuObject> resoucesTypeList = null;
        private List<Neusoft.HISFC.BizLogic.Privilege.Model.Resource> resoucesList = null;
        private Dictionary<string, ReportPrintControl> dicReportPrintControl = null;
        private ReportPrint currentReportPrint = null;
        private Dictionary<string, string> resourceTypesMapping = null;
        /// <summary>
        /// 判断当前操作：添加，0|修改，1
        /// </summary>
        private int judgeOperation;

        /// <summary>
        /// 添加的构造函数
        /// </summary>
        /// <param name="resoucesTypes"></param>
        public frmMaintenacePop(List<Neusoft.FrameWork.Models.NeuObject> resoucesTypes)
        {
            judgeOperation = 0;
            resoucesTypeList = resoucesTypes;
            InitializeComponent();
            this.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(EnumSysColor.Blue);
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle(fpSpread_Info);
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle(fpSpread1);
            InitInfo();
            InitCmb();
        }

        /// <summary>
        /// 更新时的构造函数
        /// </summary>
        /// <param name="resoucesTypes"></param>
        public frmMaintenacePop(ReportPrint reportPrint, List<Neusoft.FrameWork.Models.NeuObject> resoucesTypes, Dictionary<string, string> resourceTypesMapping1)
        {
            judgeOperation = 1;
            currentReportPrint = reportPrint;
            resoucesTypeList = resoucesTypes;
            resourceTypesMapping = resourceTypesMapping1;
            dicReportPrintControl = new Dictionary<string, ReportPrintControl>();
            foreach (ReportPrintControl r in reportPrint.ReportPrintControls)
            {
                dicReportPrintControl.Add(r.InterfaceName, r);
            }
            InitializeComponent();
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle(fpSpread_Info);
            this.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(EnumSysColor.Blue);
            InitUpateInfo();
        }

        public int Add()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            ReportPrintManager DB = new ReportPrintManager();

            int ret = DB.InsertData(GetParamInfo());
            if (ret == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                MessageBox.Show("Save failed," + DB.Err);
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            return 0;
        }

        public int Updata()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            ReportPrintManager DBManager = new ReportPrintManager();
            ReportPrint reportPrint = GetParamInfo();

            //首先删除原数据
            int ret = DBManager.DeleteData(reportPrint);
            if (ret == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                return -1;
            }
            //对维护数据进行重新插入
            ret = DBManager.InsertData(reportPrint);
            if (ret == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 0;
        }

        #region 私有变量

        private void InitInfo()
        {
            resoucesList = new Neusoft.HISFC.BizLogic.Privilege.ResourceProcess().QueryNoneRoot();
        }

        private void InitCmb()
        {
            cmbType.DataSource = resoucesTypeList;
            string[] arr = System.IO.Directory.GetFiles(Application.StartupPath + "/");
            for(int i=0;i<arr.Length;i++)
            {
                if (arr[i].EndsWith(".dll"))
                {
                    try
                    {
                        System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(arr[i]);
                        Type[] type = assembly.GetTypes();
                        foreach (Type t in type)
                        {
                            if (t.GetInterface("IInterfaceContainer") != null)
                            {
                                cmbDLL.Items.Add(arr[i].Split('/')[1].ToString());
                                break;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
                      
        }

        /// <summary>
        /// 获得控件名称从DLL
        /// </summary>
        /// <param name="dllFileName">DLL文件名称</param>
        /// <param name="interfaceType">所实现的接口类型</param>
        /// <returns>名称数组</returns>
        private string[] GetControlNames(string dllName, Type type)
        {
            if (dllName.Length == 0)
                return null;

            try
            {
                List<string> ret = new List<string>();
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(dllName);

                if (!System.IO.File.Exists(assembly.Location))
                {
                    MessageBox.Show(FrameWork.Management.Language.Msg("程序运行目录中未能找到" + dllName));
                    return null;
                }

                Type[] types = assembly.GetTypes();


                foreach (Type mytype in types)
                {
                    //遍历所实现的接口
                    Type[] interfaces = mytype.GetInterfaces();
                    foreach (Type interfaceType in interfaces)
                    {
                        if (interfaceType.Equals(type))
                        {
                            ret.Add(mytype.ToString());
                        }
                    }

                }

                return ret.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void InitUpateInfo()
        {
            InitInfo();
            InitCmb();
            cmbDLL.Enabled = false;
            cmbWinName.Enabled = false;
            cmbType.Text = resourceTypesMapping[currentReportPrint.ContainerType]; ;
            txtName.Text = currentReportPrint.Name;
            cmbDLL.Text = currentReportPrint.ContainerDllName;
            cmbWinName.Text = currentReportPrint.ContainerContorl;

            IInterfaceContainer interfaceContainer = System.Reflection.Assembly.LoadFrom(currentReportPrint.ContainerDllName).CreateInstance(currentReportPrint.ContainerContorl) as IInterfaceContainer;
            if (interfaceContainer == null)
            {
                MessageBox.Show(FrameWork.Management.Language.Msg("您选择的接口容器" + cmbWinName.SelectedItem + "中不存在接口，请删除此条数据！"));
                return;
            }

            this.fpSpread_Info_Sheet1.RowCount = interfaceContainer.InterfaceTypes.Length;

            for (int i = 0; i < interfaceContainer.InterfaceTypes.Length; i++)
            {
                this.fpSpread_Info_Sheet1.Cells[i, 0].Text = interfaceContainer.InterfaceTypes[i].FullName;
                if (dicReportPrintControl.Count != 0 && dicReportPrintControl.Keys.Contains(interfaceContainer.InterfaceTypes[i].FullName))
                {
                    this.fpSpread_Info_Sheet1.Rows[i].Tag = dicReportPrintControl[interfaceContainer.InterfaceTypes[i].FullName];
                    this.fpSpread_Info_Sheet1.Cells[i, 1].Text = dicReportPrintControl[interfaceContainer.InterfaceTypes[i].FullName].DllName;
                    this.fpSpread_Info_Sheet1.Cells[i, 2].Text = dicReportPrintControl[interfaceContainer.InterfaceTypes[i].FullName].ControlName;
                    this.fpSpread_Info_Sheet1.Cells[i, 3].Text =Neusoft.FrameWork.Function.NConvert.ToBoolean( dicReportPrintControl[interfaceContainer.InterfaceTypes[i].FullName].State).ToString();
                    this.fpSpread_Info_Sheet1.Cells[i, 4].Text = dicReportPrintControl[interfaceContainer.InterfaceTypes[i].FullName].Memo;
                }

            }

        }

        private ReportPrint GetParamInfo()
        {

            string dllName = string.Empty;
            string winName = string.Empty;
            string interfaceName = string.Empty;
            string state = string.Empty;
            string meno = string.Empty;
            ReportPrint reportInfo = new ReportPrint();
            reportInfo.ContainerContorl = cmbWinName.SelectedItem.ToString();
            reportInfo.ContainerDllName = cmbDLL.SelectedItem.ToString();
            if (cmbType.Text != string.Empty && cmbType.SelectedValue != null)
            {
                reportInfo.ContainerType = (cmbType.SelectedValue as Neusoft.FrameWork.Models.NeuObject).ID;
            }
            reportInfo.Name = txtName.Text.Trim();

            for (int i = 0; i < fpSpread_Info_Sheet1.Rows.Count; i++)
            {
                interfaceName = fpSpread_Info_Sheet1.Cells[i, 0].Text.Trim();
                dllName = fpSpread_Info_Sheet1.Cells[i, 1].Text.Trim();
                winName = fpSpread_Info_Sheet1.Cells[i, 2].Text.Trim();
                state = Neusoft.FrameWork.Function.NConvert.ToInt32(fpSpread_Info_Sheet1.Cells[i, 3].Text.ToString()).ToString(); ;
                meno = fpSpread_Info_Sheet1.Cells[i, 4].Text.ToString();
                reportInfo.Add(dllName, winName, 0, meno, interfaceName, state);
            }

            return reportInfo;
        }

        #endregion


        #region 事件

        private void cmbDLL_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbWinName.Text = string.Empty;
            cmbWinName.Items.Clear();
            if (cmbDLL.SelectedItem != null)
            {
                string[] r = this.GetControlNames(cmbDLL.SelectedItem.ToString(), typeof(IInterfaceContainer));
                if (r == null)
                    return;
                foreach (string winName in r)
                {
                    cmbWinName.Items.Add(winName);
                }
            }
        }

        private void cmbWinName_SelectedValueChanged(object sender, EventArgs e)
        {
            IInterfaceContainer interfaceContainer = System.Reflection.Assembly.LoadFrom(cmbDLL.SelectedItem.ToString()).CreateInstance(cmbWinName.SelectedItem.ToString()) as IInterfaceContainer;
            if (interfaceContainer == null)
            {
                MessageBox.Show(FrameWork.Management.Language.Msg("您选择的接口容器" + cmbWinName.SelectedItem + "中不存在接口，请删除此条数据！"));
                return;
            }

            this.fpSpread_Info_Sheet1.RowCount = interfaceContainer.InterfaceTypes.Length;
            for (int i = 0; i < interfaceContainer.InterfaceTypes.Length; i++)
            {
                this.fpSpread_Info_Sheet1.Cells[i, 0].Tag = interfaceContainer.InterfaceTypes[i];
                this.fpSpread_Info_Sheet1.Cells[i, 0].Text = interfaceContainer.InterfaceTypes[i].FullName;

            }
        }

        private void fpSpread_Info_EditModeOff(object sender, EventArgs e)
        {
            int activeRowIndex = this.fpSpread_Info_Sheet1.ActiveRowIndex;
            int activeColumnIndex = this.fpSpread_Info_Sheet1.ActiveColumnIndex;

            if (activeColumnIndex == 1)
            {
                Type t = this.fpSpread_Info_Sheet1.Cells[activeRowIndex, 0].Tag as Type;
                string[] r = this.GetControlNames(this.fpSpread_Info_Sheet1.Cells[activeRowIndex, activeColumnIndex].Text, t);
                if (r == null)
                {
                    return;
                }

                FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                comboBoxCellType.Items = r;

                this.fpSpread_Info_Sheet1.Cells[activeRowIndex, 2].CellType = comboBoxCellType;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (judgeOperation == 0)
            {
                if (this.Add() == 0)
                {
                    MessageBox.Show("保存成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                if (this.Updata() == 0)
                {
                    MessageBox.Show("保存成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnChanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion




    }
}
