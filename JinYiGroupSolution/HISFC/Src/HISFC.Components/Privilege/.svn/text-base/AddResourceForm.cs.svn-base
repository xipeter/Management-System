using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


//using Neusoft.Framework;
//using Neusoft.WinForms.Forms;
using System.IO;
using System.Collections;
using System.Reflection;
using Neusoft.HISFC.Components.Privilege;
using Neusoft.HISFC.BizLogic.Privilege;
using Neusoft.HISFC.BizLogic.Privilege.Model;
using Neusoft.HISFC.BizLogic.Privilege.Service;

namespace Neusoft.HISFC.Components.Privilege
{
    /// <summary>
    /// [功能描述: 资源管理]<br></br>
    /// [创建者:   张凯钧]<br></br>
    /// [创建时间: 2008.6.23]<br></br>
    /// <说明>
    ///     增加修改资源信息
    /// </说明>
    /// </summary>
    public partial class AddResourceForm : InputBaseForm
    {
        #region 变量
        private Neusoft.HISFC.BizLogic.Privilege.Model.Resource currentParentRes;
        public Neusoft.HISFC.BizLogic.Privilege.Model.Resource currentRes;
        private string JudgePageType = null;
        private string JudgeType = null;
        #endregion

        #region 共有方法
        /// <summary>
        /// 添加操作构造函数
        /// </summary>
        /// <param name="current"></param>
        public AddResourceForm(Neusoft.HISFC.BizLogic.Privilege.Model.Resource current, String pageType)
        {
            InitializeComponent();

            currentParentRes = current;
            JudgePageType = pageType;
            ResInitNew();
        }

        /// <summary>
        /// 更新操作构造函数
        /// </summary>
        /// <param name="current"></param>
        /// <param name="updataRes"></param>
        public AddResourceForm(Neusoft.HISFC.BizLogic.Privilege.Model.Resource current, String pageType, String updataRes)
        {
            InitializeComponent();

            currentRes = current;
            JudgePageType = pageType;
            JudgeType = updataRes;
            ResInit();
        }
        #endregion

        #region 私有方法
        private void ResInit()
        {
            WebViewInit();
            this.ResInitShortCutList();

            this.txtResName.Text = currentRes.Name;
            this.txtResParentName.Text = currentRes.Name;
            this.cmbResShortcut.Text = currentRes.Shortcut;
            this.txtResTooltips.Text = currentRes.Tooltip;
            this.txtResDllName.Text = currentRes.DllName;
            this.txtResWinName.Text = currentRes.WinName;
            this.txtResTreeDllName.Text = currentRes.TreeDllName;
            this.txtResTreeName.Text = currentRes.TreeName;
            this.txtResParam.Text = currentRes.Param;
            this.cmbResShowType.SelectedIndex = (currentRes.ShowType == "Show" ? 1 : (currentRes.ShowType == "ShowDialog" ? 0 : (currentRes.ShowType == "Web" ? 2 : 0)));
            this.chbResEnabled.Checked = currentRes.Enabled;

        }

        private void ResInitNew()
        {
            this.ResInitShortCutList();
            WebViewInit();
        }

        /// <summary>
        /// 初始化web资源的控件
        /// </summary>
        private void WebViewInit()
        {
            if (JudgePageType == "WebRes")
            {
                nButton1.Visible = false;
                txtResDllName.Visible = false;
                txtResTooltips.Visible = false;
                txtResTreeDllName.Visible = false;
                txtResTreeName.Visible = false;
                txtResParam.Visible = false;
                cmbResShortcut.Visible = false;
                cmbResShowType.Visible = false;
                nResLabel6.Visible = false;
                nResLabel5.Visible = false;
                nResLabel3.Visible = false;
                nResLabel9.Visible = false;
                nResLabel8.Visible = false;
                nResLabel4.Visible = false;
                nResLabel11.Visible = false;
                cmbResShowType.SelectedIndex = 2;
                nResLabel7.Text = "    URL地址：";
                nResLabel7.TextAlign = ContentAlignment.MiddleLeft;
            }
        }

        private int ResCheck()
        {

            if (string.IsNullOrEmpty(this.cmbResShowType.Text.Trim()))
            {
                MessageBox.Show("请选择显示类型!", "提示");
                this.cmbResShowType.Focus();
                return -1;
            }

            if (string.IsNullOrEmpty(this.txtResName.Text.Trim()))
            {
                MessageBox.Show("菜单名称不能为空!", "提示");
                this.txtResName.Focus();
                return -1;
            }

            if (string.IsNullOrEmpty(this.txtResName.Text.Trim()))
            {
                MessageBox.Show("菜单名称不能为空!", "提示");
                this.txtResName.Focus();
                return -1;
            }

            if (!FrameWork.Public.String.ValidMaxLengh(this.txtResName.Text.Trim(), 60))
            {
                MessageBox.Show("菜单名称长度不能超过30个汉字!", "提示");
                this.txtResName.Focus();
                return -1;
            }

            if (this.cmbResShortcut.Text.Trim() != "" && cmbResShortcut.SelectedIndex == -1)
            {
                MessageBox.Show("无此快捷键!", "提示");
                this.cmbResShortcut.Focus();
                return -1;
            }

            if (!FrameWork.Public.String.ValidMaxLengh(this.txtResTooltips.Text.Trim(), 50))
            {
                MessageBox.Show("工具提示长度不能超过25个汉字!", "提示");
                this.txtResTooltips.Focus();
                return -1;
            }

            if (!FrameWork.Public.String.ValidMaxLengh(this.txtResDllName.Text.Trim(), 50))
            {
                MessageBox.Show("调用程序集名称长度不能超过50个字母!", "提示");
                this.txtResDllName.Focus();
                return -1;
            }
            #region {E07BBA02-0CC9-4015-A9F8-EBB88AEB535F}

            if (!FrameWork.Public.String.ValidMaxLengh(this.txtResWinName.Text.Trim(), 1000))
            {
                MessageBox.Show("调用控件名称长度不能超过1000个字母!", "提示");
                this.txtResWinName.Focus();
                return -1;
            } 
            #endregion

            if (!FrameWork.Public.String.ValidMaxLengh(this.txtResTreeDllName.Text.Trim(), 50))
            {
                MessageBox.Show("树控件程序集名称长度不能超过50个字母!", "提示");
                this.txtResTreeDllName.Focus();
                return -1;
            }

            if (!FrameWork.Public.String.ValidMaxLengh(this.txtResTreeName.Text.Trim(), 100))
            {
                MessageBox.Show("树控件名称长度不能超过100个字母!", "提示");
                this.txtResTreeName.Focus();
                return -1;
            }

            if (!FrameWork.Public.String.ValidMaxLengh(this.txtResParam.Text.Trim(), 100))
            {
                MessageBox.Show("传入参数长度不能超过100个字母!", "提示");
                this.txtResParam.Focus();
                return -1;
            }

            return 0;
        }

        private Neusoft.HISFC.BizLogic.Privilege.Model.Resource ResGetValue()
        {
            if (JudgeType == null)
            {
                currentRes = new Neusoft.HISFC.BizLogic.Privilege.Model.Resource();
                currentRes.ParentId = currentParentRes.Id;
                currentRes.Layer = Convert.ToString(long.Parse(currentParentRes.Layer) + 1);

            }
            currentRes.Name = txtResName.Text.Trim();
            currentRes.Shortcut = cmbResShortcut.Text.Trim();
            currentRes.Tooltip = txtResTooltips.Text.Trim();
            currentRes.DllName = txtResDllName.Text.Trim();
            currentRes.WinName = txtResWinName.Text.Trim();
            currentRes.TreeDllName = txtResTreeDllName.Text.Trim();
            currentRes.TreeName = txtResTreeName.Text.Trim();
            currentRes.Param = txtResParam.Text.Trim();
            currentRes.ShowType = cmbResShowType.Text == "" ? "" : (cmbResShowType.Text == "模式窗体" ? "ShowDialog" : (cmbResShowType.Text == "无模式窗体" ? "Show" : "Web"));
            currentRes.Enabled = chbResEnabled.Checked;
            currentRes.UserId = Neusoft.FrameWork.Management.Connection.Operator.ID;
            currentRes.OperDate = FrameWork.Function.NConvert.ToDateTime(new FrameWork.Management.DataBaseManger().GetSysDateTime());
            currentRes.ControlType = JudgePageType;
            return currentRes;
        }

        private void ResInitShortCutList()
        {
            string[] _names = Enum.GetNames(typeof(Shortcut));
            AutoCompleteStringCollection _autoCollection = new AutoCompleteStringCollection();

            foreach (string _name in _names)
            {
                this.cmbResShortcut.Items.Add(_name);
                _autoCollection.Add(_name);
            }

            this.cmbResShortcut.AutoCompleteCustomSource = _autoCollection;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                Control _control = this.ActiveControl;
                if (_control != null && _control.Name == "cmbShortcut")
                {
                    this.txtResTooltips.Focus();
                }
                else if (_control != null && _control.Name == "cmbShowType")
                {
                    this.chbResEnabled.Focus();
                }
                else if (_control != null && _control.Name == "chbEnabled")
                {
                    this.btnResOK.Focus();
                }
            }

            return base.ProcessDialogKey(keyData);
        }
        #endregion

        #region 事件
        private void btnResOK_Click(object sender, EventArgs e)
        {

            //保存菜单
            if (ResCheck() == -1) return;

            try
            {
                FrameWork.Management.PublicTrans.BeginTransaction();

                PrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    currentRes = _proxy.SaveResourcesItem(ResGetValue());
                }
                this.DialogResult = DialogResult.OK;
                FrameWork.Management.PublicTrans.Commit();

            }
            catch (Exception ex)
            {
                currentRes = null;
                FrameWork.Management.PublicTrans.RollBack();

                MessageBox.Show(ex.Message, "提示");
                return;
            }
            this.Close();
        }
        #endregion

        private void nButton1_Click(object sender, EventArgs e)
        {
            Dictionary<int, String> dictionary = SelectDll.SelectFile(Application.StartupPath);

            if (dictionary == null)
            {
                return;
            }
            txtResDllName.Text = dictionary[1];

            SelectClassForm selectForm = new SelectClassForm(SelectDll.SelectClassDll(dictionary[0]));
            selectForm.GetName += new SelectClassForm.GetClassName(selectForm_GetName);
            selectForm.ShowDialog();


        }

        void selectForm_GetName(string Name)
        {
            txtResWinName.Text = Name;
        }

        private void btnResCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }

    public class SelectDll
    {
        public static Dictionary<int, string> SelectFile(string path)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = path;
            openFileDialog.Filter = "Assemblies (*.dll)|*.dll|Executables (*.exe)|*.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!openFileDialog.FileName.Equals(string.Empty))
                {
                    string fileName = openFileDialog.FileName;
                    openFileDialog.Dispose();
                    result.Add(0, fileName);
                    result.Add(1, DelExetendName(fileName));
                    return result;

                }
                return null;
            }
            return null;
        }

        private static string DelExetendName(string fileName)
        {
            string str = fileName.Substring(fileName.LastIndexOf("\\") + 1, fileName.Length - fileName.LastIndexOf("\\") - 1);
            return str.Substring(0, str.LastIndexOf("."));
        }

        public static ArrayList SelectClassDll(string fileName)
        {
            FileInfo _currFile = new FileInfo(fileName);
            if (_currFile != null)
            {
                if (IsDotNetAssembly(_currFile.FullName))
                {
                    GC.Collect();
                    Application.DoEvents();
                    Assembly ass = Assembly.LoadFrom(_currFile.FullName);
                    if (ass.FullName.StartsWith("System"))
                    {
                        ErrorBox("System namespace assemblies not allowed");
                        return null;
                    }
                    else
                    {
                        Application.DoEvents();
                        return StartAnylsisProcess(ass);
                    }
                }
                else
                {
                    ErrorBox("The file [" + _currFile.Name +
                                     "], 不是 CLR 类型.\r\n\r\n" +
                                     "请选择其他文件！！");
                    return null;
                }
            }
            else
            {
                ErrorBox("选择的文件不存在！");
                return null;
            }
            return null;
        }

        private static void ErrorBox(string err)
        {
            MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static bool IsDotNetAssembly(String file)
        {

            uint peHeader;
            uint peHeaderSignature;
            ushort machine;
            ushort sections;
            uint timestamp;
            uint pSymbolTable;
            uint noOfSymbol;
            ushort optionalHeaderSize;
            ushort characteristics;
            ushort dataDictionaryStart;
            uint[] dataDictionaryRVA = new uint[16];
            uint[] dataDictionarySize = new uint[16];

            Stream fs = new FileStream(@file, FileMode.Open, FileAccess.Read);

            try
            {
                BinaryReader reader = new BinaryReader(fs);
                fs.Position = 0x3C;
                peHeader = reader.ReadUInt32();
                fs.Position = peHeader;
                peHeaderSignature = reader.ReadUInt32();
                machine = reader.ReadUInt16();
                sections = reader.ReadUInt16();
                timestamp = reader.ReadUInt32();
                pSymbolTable = reader.ReadUInt32();
                noOfSymbol = reader.ReadUInt32();
                optionalHeaderSize = reader.ReadUInt16();
                characteristics = reader.ReadUInt16();

                dataDictionaryStart = Convert.ToUInt16(Convert.ToUInt16(fs.Position) + 0x60);
                fs.Position = dataDictionaryStart;
                for (int i = 0; i < 15; i++)
                {
                    dataDictionaryRVA[i] = reader.ReadUInt32();
                    dataDictionarySize[i] = reader.ReadUInt32();
                }
                if (dataDictionaryRVA[14] == 0)
                {
                    fs.Close();
                    return false;
                }
                else
                {
                    fs.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                fs.Close();
            }

        }

        private static ArrayList StartAnylsisProcess(Assembly a)
        {
            ArrayList alist = new ArrayList();
            foreach (Type t in a.GetTypes())
            {
                if (!string.IsNullOrEmpty(t.Namespace))
                {
                    alist.Add(t.FullName);
                }
            }
            return alist;
        }
    }

}

