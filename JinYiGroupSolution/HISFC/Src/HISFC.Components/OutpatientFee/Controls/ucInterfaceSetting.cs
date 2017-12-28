using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    public partial class ucInterfaceSetting : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucInterfaceSetting()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 控制参数
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        #endregion

        #region 方法

        /// <summary>
        /// 初始化接口树
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int InitTreeView() 
        {
            TreeNode parentNode = new TreeNode();

            parentNode.Tag = new ArrayList();
            parentNode.Text = "门诊收费接口";

            this.tvInterface.Nodes.Add(parentNode);

            ArrayList interfaces = this.managerIntegrate.GetConstantList("MZINTF");
            if (interfaces == null) 
            {
                MessageBox.Show("获得门诊接口参数设置出错!" + this.managerIntegrate.Err);

                return -1;
            }
            if (interfaces.Count == 0) 
            {
                MessageBox.Show("没有维护任何门诊接口参数!");

                return -1;
            }

            foreach (Neusoft.HISFC.Models.Base.Const c in interfaces) 
            {
                TreeNode tnInterface = new TreeNode();

                tnInterface.Tag = c.Memo;
                tnInterface.Text = c.Name;

                parentNode.Nodes.Add(tnInterface);
            }

            this.tvInterface.ExpandAll();

            return 1;
        }

        /// <summary>
        /// 初始化方法
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public virtual int Init() 
        {
            if (this.InitTreeView() == -1) 
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 判断选择的文件是否包含实现接口UC
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="interfaceName">接口名</param>
        /// <returns>成功 true 失败 false</returns>
        protected virtual bool IsValidFileToInterface(string fileName, string interfaceName) 
        {
            bool isValid = false;

            try
            {
                Assembly a = Assembly.LoadFrom(fileName);
                System.Type[] types = a.GetTypes();

                foreach (System.Type type in types)
                {
                    if (type.GetInterface(interfaceName) != null)
                    {   
                        isValid = true;

                        break;
                    }
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show("反射插件错误!" + e.Message);

                return false;
            }

            if(!isValid)
            {
                MessageBox.Show("您选择的DLL不包含实现接口的UC,请重新选择!");

                return false;
            }

            return isValid;
        }

        /// <summary>
        /// 获得实际接口名
        /// </summary>
        /// <param name="interfaceFullName">接口全名,包括命名空间</param>
        /// <returns>成功 实际接口名 失败 null</returns>
        protected string GetInterfaceName(string interfaceFullName) 
        {
            string[] s = interfaceFullName.Split('.');

            int count = s.Length;

            return s[count - 1];
        }

        /// <summary>
        /// 获得实际文件名
        /// </summary>
        /// <param name="dllFullName">全名,带路径</param>
        /// <returns>成功 实际文件名 失败 null</returns>
        protected string GetDLLName(string dllFullName) 
        {
            string[] s = dllFullName.Split('\\');

            int count = s.Length;

            return s[count - 1];
        }

        /// <summary>
        /// 预览
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected int Preview() 
        {
            if (this.tvInterface.SelectedNode.Level == 0)
            {
                return -1;
            }
            string objNameSpace = this.txtNameSpace.Text;
            string assemblyName = this.txtDll.Text.Substring(0, this.txtDll.Text.Length - 4);

            if (objNameSpace == string.Empty) 
            {
                MessageBox.Show("请正确选择插件!");

                return -1;
            }

            System.Runtime.Remoting.ObjectHandle objPreview = null;

            try
            {

                objPreview = System.Activator.CreateInstance(assemblyName, objNameSpace);
            }
            catch (Exception e)
            {
                MessageBox.Show("预览失败!" + e.Message);

                return -1;
            }

            if (objPreview == null) 
            {
                MessageBox.Show("反射失败!请确认您选择的dll和uc的正确和完整!");

                return -1;
            }

            object obj = objPreview.Unwrap();

            if (obj is Form) 
            {
                ((Form)obj).ShowDialog();

                return 1;
            }

            if (obj is Control)
            {
                Control c = obj as Control;

                this.plPreview.Enabled = false;

                this.plPreview.Controls.Add(c);

                c.Location = new Point(0, 0);
            }
            else 
            {
                MessageBox.Show("该控件不支持预览!");
            }

            return 1;
        }

        /// <summary>
        /// 清空
        /// </summary>
        protected void Clear() 
        {
            this.txtDll.Text = string.Empty;
            this.txtDll.Tag = string.Empty;
            this.txtNameSpace.Text = string.Empty;
            this.txtNameSpace.Tag = string.Empty;
            this.cmbControl.Items.Clear();
            this.cmbControl.Text = string.Empty;
            this.plPreview.Controls.Clear();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int Save() 
        {
            Neusoft.HISFC.Models.Base.Controler tempControlObj = null;//临时控制类实体;

            string tempControlValue = null;// 从界面读取的控制参数值

            TreeNode selectedNode = this.tvInterface.SelectedNode;

            if (selectedNode == null || selectedNode.Level == 0) 
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);


            string consName = Neusoft.HISFC.BizProcess.Integrate.Const.GetOutpatientPlugInConstNameByInterfaceName(selectedNode.Tag.ToString());

            tempControlValue = this.txtDll.Tag.ToString().Replace(Application.StartupPath, string.Empty) + "|" + this.txtNameSpace.Text;
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = consName;
            tempControlObj.Name = selectedNode.Text;
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            int iReturn = this.managerIntegrate.InsertControlerInfo(tempControlObj);
            if (iReturn == -1)
            {
                //主键重复，说明已经存在参数值,那么直接更新
                if (managerIntegrate.DBErrCode == 1)
                {
                    iReturn = this.managerIntegrate.UpdateControlerInfo(tempControlObj);
                    if (iReturn <= 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新控制参数[" + tempControlObj.Name + "]失败! 控制参数值:" + tempControlObj.ID + "\n错误信息:" + this.managerIntegrate.Err);

                        return -1;
                    }
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("插入控制参数[" + tempControlObj.Name + "]失败! 控制参数值:" + tempControlObj.ID + "\n错误信息:" + this.managerIntegrate.Err);

                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("保存成功!");

            return 1;
        }

        #endregion

        private void ucInterfaceSetting_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode) 
            {
                if (this.Init() == -1) 
                {
                    return;
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();

            if (result == DialogResult.Cancel) 
            {
                return;
            }

            string fileName = this.openFileDialog1.FileName;

            if (fileName == string.Empty) 
            {
                MessageBox.Show("请选择dll");

                return;
            }

            TreeNode selectedNode = this.tvInterface.SelectedNode;

            if (selectedNode == null || selectedNode.Level == 0)
            {
                return;
            }

            if (selectedNode.Tag == null)
            {
                MessageBox.Show("接口命名控件赋值错误!");

                return;
            }

            string interfaceName = selectedNode.Tag.ToString();

            interfaceName = this.GetInterfaceName(interfaceName);

            bool isValid = this.IsValidFileToInterface(fileName, interfaceName);

            if (!isValid) 
            {
                return;
            }

            this.txtDll.Text = this.GetDLLName(fileName);
            this.txtDll.Tag = fileName;

            ArrayList ucList = new ArrayList();

            try
            {
                Assembly a = Assembly.LoadFrom(fileName);
                System.Type[] types = a.GetTypes();

                foreach (System.Type type in types)
                {
                    if (type.GetInterface(interfaceName) != null)
                    {
                        Neusoft.FrameWork.Models.NeuObject objFile = new Neusoft.FrameWork.Models.NeuObject();
                        objFile.ID = type.Namespace;
                        objFile.Name = type.Name;

                        ucList.Add(objFile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("反射插件错误!" + ex.Message);

                return;
            }

            this.cmbControl.AddItems(ucList);

            this.cmbControl.SelectedIndex = 0;
        }

        private void cmbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtNameSpace.Text = this.cmbControl.Tag.ToString();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Preview();
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();
            
            return base.OnSave(sender, neuObject);
        }

        private void tvInterface_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0) 
            {
                this.Clear();

                return;
            }

            string consName = Neusoft.HISFC.BizProcess.Integrate.Const.GetOutpatientPlugInConstNameByInterfaceName(e.Node.Tag.ToString());

            string controlValue = controlParamIntegrate.GetControlParam<string>(consName, true, string.Empty);

            if (controlValue == string.Empty) 
            {
                this.Clear();

                return;
            }

            string dllName = controlValue.Split('|')[0];
            string nameSpace = controlValue.Split('|')[1];
            string interfaceName = this.GetInterfaceName(e.Node.Tag.ToString());

            this.txtDll.Text = this.GetDLLName(dllName);
            this.txtDll.Tag = Application.StartupPath + dllName;
            this.txtNameSpace.Text = nameSpace;


            string fileName = this.txtDll.Tag.ToString();

            ArrayList ucList = new ArrayList();

            this.cmbControl.Items.Clear();

            try
            {
                Assembly a = Assembly.LoadFrom(fileName);
                System.Type[] types = a.GetTypes();

                foreach (System.Type type in types)
                {
                    if (type.GetInterface(interfaceName) != null)
                    {
                        Neusoft.FrameWork.Models.NeuObject objFile = new Neusoft.FrameWork.Models.NeuObject();
                        objFile.ID = type.Namespace + "." + type.Name;
                        objFile.Name = type.Name;

                        ucList.Add(objFile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("反射插件错误!" + ex.Message);

                return;
            }

            this.cmbControl.AddItems(ucList);

            this.cmbControl.Tag = nameSpace;
        }
    }
}
