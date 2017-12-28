using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Manager.Forms
{
    public partial class frmEditParam : Form
    {
        private List<Neusoft.FrameWork.Models.NeuObject> resoucesTypeList = null;
        private Neusoft.FrameWork.WinForms.Classes.ControlParam currentControlParam = null;
        private Dictionary<string, string> resourceTypesMapping = null;
        /// <summary>
        /// 判断当前操作：添加，0|修改，1
        /// </summary>
        private int judgeOperation;

        public frmEditParam(List<Neusoft.FrameWork.Models.NeuObject> resoucesTypes)
        {

            InitializeComponent();
            this.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Blue);
            this.toolStrip1.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Blue);
            judgeOperation = 0;
            resoucesTypeList = resoucesTypes;
            initCmbInfo();
            initCmbControlType();

        }


        public frmEditParam(List<Neusoft.FrameWork.Models.NeuObject> resoucesTypes, Neusoft.FrameWork.WinForms.Classes.ControlParam controlParam, Dictionary<string, string> resourceTypesMapping1)
        {

            InitializeComponent();
            this.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Blue);
            this.toolStrip1.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Blue);
            judgeOperation = 1;
            resoucesTypeList = resoucesTypes;
            currentControlParam = controlParam;
            resourceTypesMapping = resourceTypesMapping1;
            initCmbInfo();
            initCmbControlType();
            InitUpdateInfo();
            txtParamID.Enabled = false;

        }

        #region 私有方法


        private void Add()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            int ret = new Neusoft.FrameWork.WinForms.Classes.ControlParamManager().Insert(GetInfo());
            if (ret == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存失败！");
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateParam()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            int ret = new Neusoft.FrameWork.WinForms.Classes.ControlParamManager().update(GetInfo());
            if (ret == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存失败！");
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 为实体类赋值
        /// </summary>
        /// <returns></returns>
        private Neusoft.FrameWork.WinForms.Classes.ControlParam GetInfo()
        {

            Neusoft.FrameWork.WinForms.Classes.ControlParam newParam = new Neusoft.FrameWork.WinForms.Classes.ControlParam();
            newParam.ID = txtParamID.Text.Trim();
            newParam.Name = txtParamName.Text.Trim();
            newParam.ParamKind = (cmbParamType.SelectedValue as Neusoft.FrameWork.Models.NeuObject).ID;
            newParam.ParamState = Neusoft.FrameWork.Function.NConvert.ToInt32(chbState.Checked).ToString();
            newParam.ParamControlKind = cmbControlType.Text.Trim();
            newParam.Oper = Neusoft.FrameWork.Management.Connection.Operator.Name;
            newParam.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(new Neusoft.FrameWork.Management.DataBaseManger().GetSysDateTime());

            if (newParam.ParamControlKind == ControlTypeValue.整数.ToString())
            {
                newParam.ParamValue = txtNumberValue.Value.ToString();
            }
            if (newParam.ParamControlKind == ControlTypeValue.文本框.ToString())
            {
                newParam.ParamValue = txtStringValue.Text.Trim();
            }
            if (newParam.ParamControlKind == ControlTypeValue.颜色.ToString())
            {
                newParam.ParamValue = colorResult.BackColor.ToArgb().ToString();
            }
            if (newParam.ParamControlKind == ControlTypeValue.选择框.ToString())
            {
                newParam.ParamValue = Neusoft.FrameWork.Function.NConvert.ToInt32(ckbvalue.Checked).ToString();
            }
            if (newParam.ParamControlKind == ControlTypeValue.下拉框_固定数组.ToString())
            {
                newParam.ParamValue = cmbDropDownValue.Text.ToString();
                newParam.ParamControlValue = rtxtString.Text.Replace('\n', '|');
            }
            if (newParam.ParamControlKind == ControlTypeValue.下拉框_动态反射.ToString())
            {
                newParam.ParamValue = cmbDropDownValue.SelectedValue.ToString();
                string newString = txtParamDll.Text.Trim() + "|" + txtParamClass.Text.Trim() + "|" + txtParamM.Text.Trim() + "|" + txtcontrolParmType.Text.Trim() + "|" + txtcontrolParmValue.Text.Trim();
                newParam.ParamControlValue = newString;
            }
            return newParam;

        }

        private void InitUpdateInfo()
        {
            cmbParamType.Text = resourceTypesMapping[currentControlParam.ParamKind];
            txtParamID.Text = currentControlParam.ID;
            txtParamName.Text = currentControlParam.Name;
            cmbControlType.Text = currentControlParam.ParamControlKind;
            ckbvalue.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean(currentControlParam.ParamState);

            if (currentControlParam.ParamControlKind == ControlTypeValue.文本框.ToString())
            {
                txtStringValue.Text = currentControlParam.ParamValue;
            }
            else if (currentControlParam.ParamControlKind == ControlTypeValue.选择框.ToString())
            {
                ckbvalue.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean(currentControlParam.ParamValue);
            }
            else if (currentControlParam.ParamControlKind == ControlTypeValue.颜色.ToString())
            {
                colorResult.BackColor = Color.FromArgb(Neusoft.FrameWork.Function.NConvert.ToInt32(currentControlParam.ParamValue));
            }
            else if (currentControlParam.ParamControlKind == ControlTypeValue.整数.ToString())
            {
                txtNumberValue.Text = currentControlParam.ParamValue;
            }
            else if (currentControlParam.ParamControlKind == ControlTypeValue.下拉框_固定数组.ToString())
            {
                string[] arr = currentControlParam.ParamControlValue.Split('|');
                string a = currentControlParam.ParamControlValue.Replace('|', '\n');
                if (arr == null) return;

                cmbDropDownValue.Items.AddRange(arr);
                cmbDropDownValue.Text = currentControlParam.ParamValue;
                rtxtString.Text = a;

            }
            else if (currentControlParam.ParamControlKind == ControlTypeValue.下拉框_动态反射.ToString())
            {
                string[] arr = currentControlParam.ParamControlValue.Split('|');

                if (arr == null) return;

                txtParamDll.Text = arr[0].ToString();
                txtParamClass.Text = arr[1].ToString();
                txtParamM.Text = arr[2].ToString();
                txtcontrolParmType.Text = arr[3].ToString();
                txtcontrolParmValue.Text = arr[4].ToString();
                cmbDropDownValue.DataSource=  GetReflectInfo();
            }

        }

        private void initCmbInfo()
        {
            cmbParamType.DataSource = resoucesTypeList;

            cmbControlType.Items.Add(ControlTypeValue.整数.ToString());
            cmbControlType.Items.Add(ControlTypeValue.选择框.ToString());
            cmbControlType.Items.Add(ControlTypeValue.文本框.ToString());
            cmbControlType.Items.Add(ControlTypeValue.颜色.ToString());
            cmbControlType.Items.Add(ControlTypeValue.下拉框_固定数组.ToString());
            cmbControlType.Items.Add(ControlTypeValue.下拉框_动态反射.ToString());
        }

        private void initCmbControlType()
        {
            gpString.Visible = false;
            gpNumber.Visible = false;
            gpDown.Visible = false;
            gpColor.Visible = false;
            gpChecked.Visible = false;
            plNoneString.Visible = false;
            plString.Visible = false;
        }

        private ArrayList GetReflectInfo()
        {
            ArrayList retrunList = null;
            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(txtParamDll.Text.Trim() + ".dll");

            if (!System.IO.File.Exists(assembly.Location))
            {
                MessageBox.Show(FrameWork.Management.Language.Msg("程序运行目录中未能找到" + txtParamDll.Text.Trim() + ".dll !"));
                return null;
            }

            Type type = assembly.GetType(txtParamClass.Text.Trim());

            if (type == null)
            {
                MessageBox.Show(FrameWork.Management.Language.Msg(txtParamDll.Text.Trim() + ".dll中不存在" + txtParamDll.Text.Trim() + "类!"));
                return null;
            }

            System.Reflection.MethodInfo[] members = type.GetMethods();

            ArrayList MemberList = new ArrayList();
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].Name == txtParamM.Text.Trim())
                {
                    MemberList.Add(members[i]);
                }
            }

            if (MemberList.Count == 0)
            {
                MessageBox.Show(FrameWork.Management.Language.Msg("没有找到该对应参数的方法！"));
                return null;
            }


            bool judge = true;
            for (int i = 0; i < MemberList.Count; i++)
            {
                System.Reflection.ParameterInfo[] paramInfo = (MemberList[i] as System.Reflection.MethodInfo).GetParameters();
                string[] paramTypes = txtcontrolParmType.Text.Trim().Split(',');

                if (txtcontrolParmType.Text.Trim().Length == 0 || txtcontrolParmType.Text.Trim() == string.Empty)
                {
                    System.Reflection.MethodInfo method = MemberList[i] as System.Reflection.MethodInfo;
                    retrunList = (ArrayList)method.Invoke(this, null);
                    break;
                }
                else
                {
                    //先判断参数个数是否相等
                    if (paramInfo.Length != paramTypes.Length)
                    {
                        continue;
                    }

                    for (int j = 0; j < paramTypes.Length; j++)
                    {
                        if (paramTypes[j].ToString().ToLower() != paramInfo[j].ParameterType.Name.ToString().ToLower())
                        {
                            judge = false;
                            break;
                        }
                    }

                    if (judge)
                    {
                        System.Reflection.MethodInfo method = MemberList[i] as System.Reflection.MethodInfo;
                        retrunList = (ArrayList)method.Invoke(this, txtcontrolParmValue.Text.Split(','));
                    }
                }
            }

            return retrunList;

        }


        /// <summary>
        /// 判断当前的控件值类型
        /// </summary>
        public enum ControlTypeValue
        {
            整数,
            选择框,
            文本框,
            颜色,
            下拉框_固定数组,
            下拉框_动态反射

        }

        private int Checked()
        {
            if (txtParamName.Text == string.Empty)
            {
                MessageBox.Show("参数名称不能为空！");
                return -1;
            }
            if (txtParamID.Text == string.Empty)
            {
                MessageBox.Show("参数ID不能为空！");
                return -1;
            }
            if (cmbControlType.Text == string.Empty)
            {
                MessageBox.Show("控件类型不能为空！");
                return -1;
            }

            return 0;
        }
        #endregion

        #region 事件

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            DialogResult result = this.colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.colorResult.BackColor = colorDialog1.Color;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Checked() == -1) return;
            if (judgeOperation == 0)
            {
                if (new Neusoft.FrameWork.WinForms.Classes.ControlParamManager().JudgeOnly(txtParamID.Text.Trim()) != 0)
                {

                    MessageBox.Show("参数ID已经存在！");
                    return;
                }
                this.Add();
            }
            else
            {
                this.UpdateParam();
            }
        }

        private void cmbControlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbControlType.Text == ControlTypeValue.文本框.ToString())
            {
                initCmbControlType();
                gpString.Visible = true;

            }
            else if (cmbControlType.Text == ControlTypeValue.下拉框_固定数组.ToString())
            {
                initCmbControlType();
                gpDown.Visible = true;
                plString.Visible = true;
            }
            else if (cmbControlType.Text == ControlTypeValue.下拉框_动态反射.ToString())
            {
                initCmbControlType();
                gpDown.Visible = true;
                plNoneString.Visible = true;
            }
            else if (cmbControlType.Text == ControlTypeValue.选择框.ToString())
            {
                initCmbControlType();
                gpChecked.Visible = true;
            }
            else if (cmbControlType.Text == ControlTypeValue.颜色.ToString())
            {
                initCmbControlType();
                gpColor.Visible = true;

            }
            else if (cmbControlType.Text == ControlTypeValue.整数.ToString())
            {
                initCmbControlType();
                gpNumber.Visible = true;
            }
            else
            {
                initCmbControlType();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {

            if (cmbControlType.Text == ControlTypeValue.下拉框_固定数组.ToString())
            {
                string[] arr = rtxtString.Text.Split('\n');
                cmbDropDownValue.Items.Clear();
                cmbDropDownValue.Items.AddRange(arr);
            }
            if (cmbControlType.Text == ControlTypeValue.下拉框_动态反射.ToString())
            {
                ArrayList a = GetReflectInfo();
                if (a != null)
                {
                    cmbDropDownValue.DataSource = a;
                }

            }

        }

        private void btnChanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        public ArrayList Get()
        {
            ArrayList a = new ArrayList();

            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "333";
            obj.Name = "dddd";
            a.Add(obj);

            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "22";
            obj1.Name = "cc";
            a.Add(obj1);

            Neusoft.FrameWork.Models.NeuObject obj2 = new Neusoft.FrameWork.Models.NeuObject();
            obj2.ID = "22111";
            obj2.Name = "cc22";
            a.Add(obj2);

            return a;
        }

        public ArrayList Get(string name)
        {
            ArrayList a = new ArrayList();

            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "333";
            obj.Name = name + "dddd";
            a.Add(obj);

            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "22";
            obj1.Name = name + "cc";
            a.Add(obj1);

            return a;
        }
        public ArrayList Get(string name,string id)
        {
            ArrayList a = new ArrayList();

            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "333";
            obj.Name = name + "dddd" + id;
            a.Add(obj);

            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "22";
            obj1.Name = name + "cc" + id;
            a.Add(obj1);

            return a;
        }

    }
}
