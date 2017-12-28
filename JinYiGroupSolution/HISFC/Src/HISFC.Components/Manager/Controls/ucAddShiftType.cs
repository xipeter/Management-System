using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Neusoft.HISFC.Components.Manager
{
    /// <summary>
    /// [功能描述: 增加属性变更实体类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007－04]<br></br>
    /// 
    /// <说明>
    ///     1 增加属性变更实体类
    /// </说明>
    /// </summary>
    public partial class ucAddShiftType : UserControl
    {
        public ucAddShiftType()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 结果
        /// </summary>
        private DialogResult result = DialogResult.Cancel;

        private System.Collections.Hashtable hsExtisClass = new System.Collections.Hashtable();

        #endregion

        #region 属性

        /// <summary>
        /// 类型描述
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ReflectedClass
        {
            get
            {
                Neusoft.FrameWork.Models.NeuObject refClass = new Neusoft.FrameWork.Models.NeuObject();

                refClass.ID = this.txtTypeStr.Text;
                refClass.Name = this.lbDescrip.Text;

                return refClass;
            }
        }

        /// <summary>
        /// 需变更的属性值
        /// </summary>
        public List<Neusoft.FrameWork.Models.NeuObject> Properties
        {
            get
            {
                List<Neusoft.FrameWork.Models.NeuObject> alPropertyList = new List<Neusoft.FrameWork.Models.NeuObject>();
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    alPropertyList.Add(this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.FrameWork.Models.NeuObject);
                }

                return alPropertyList;
            }
        }

        /// <summary>
        /// 结果
        /// </summary>
        public DialogResult Result
        {
            get
            {
                return this.result;
            }
            set
            {
                this.result = value;
            }
        }

        /// <summary>
        /// 已存在的类信息
        /// </summary>
        public System.Collections.Hashtable HsExitsClass
        {
            set
            {
                this.hsExtisClass = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 清空
        /// </summary>
        private void Clear()
        {
            this.lbDescrip.Text = "";
            this.neuSpread1_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 由类型内获取需变更属性
        /// </summary>
        /// <param name="t">传入类型</param>
        /// <returns>成功返回需设置变更的信息</returns>
        private List<Neusoft.FrameWork.Models.NeuObject> GetProperty(Type t)
        {
            //获取类的DisplayName属性 用于类中文名称
            object[] display = t.GetCustomAttributes(false);
            if (display != null)
            {
                foreach (object oDisplay in display)
                {
                    if (oDisplay is System.ComponentModel.DisplayNameAttribute)
                    {
                        System.ComponentModel.DisplayNameAttribute displayAttribute = oDisplay as System.ComponentModel.DisplayNameAttribute;

                        this.lbDescrip.Text = displayAttribute.DisplayName;

                        break;
                    }
                }
            }
            //获取类型内所有的属性Property
            PropertyInfo[] propertyCollection = t.GetProperties();

            List<Neusoft.FrameWork.Models.NeuObject> recordList = new List<Neusoft.FrameWork.Models.NeuObject>();
            //对类型内属性进行循环判断
            foreach (PropertyInfo p in propertyCollection)
            {  
                //对只读或只写属性不进行处理
                if (p.CanRead && p.CanWrite)
                {
                    string propertyID = "";
                    string propertyName = "";
                    string propertyDescrip = "";
                    //获取对每个属性设置的属性 (Property的Attribute)
                    foreach (Attribute a in p.GetCustomAttributes(true))
                    {
                        //属性中文名称显示
                        if (a is System.ComponentModel.DisplayNameAttribute)
                        {
                            System.ComponentModel.DisplayNameAttribute displayName = a as System.ComponentModel.DisplayNameAttribute;

                            propertyName = displayName.DisplayName;
                        }
                        //属性描述
                        if (a is System.ComponentModel.DescriptionAttribute)
                        {
                            System.ComponentModel.DescriptionAttribute descrip = a as System.ComponentModel.DescriptionAttribute;

                            propertyDescrip = descrip.Description;
                        }                        
                    }                   
                    //如 存在有效数据 进行保存 ID Name不能为空
                    if (propertyName != "")
                    {
                        Neusoft.FrameWork.Models.NeuObject shiftProperty = new Neusoft.FrameWork.Models.NeuObject();
                        shiftProperty.ID = p.Name;
                        shiftProperty.Name = propertyName;
                        shiftProperty.Memo = propertyDescrip;

                        recordList.Add(shiftProperty);
                    }
                }
            }

            return recordList;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        protected void Close()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        /// <summary>
        /// 获取需设置的类变更属性
        /// </summary>
        protected void GetShiftProperty()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Neusoft.FrameWork.Management.Language.Msg("正在载入信息 请稍候..."));
            Application.DoEvents();

            try
            {
                System.Runtime.Remoting.ObjectHandle oHandle = System.Activator.CreateInstance("HISFC.Object", this.txtTypeStr.Text);
                if (oHandle == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("未能由输入信息获取类型 请检查是否输入正确"));
                    return;
                }
                Type t = oHandle.Unwrap().GetType();
                if (t == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("未能由输入信息获取类型 请检查是否输入正确"));
                    return;
                }

                if (this.hsExtisClass.ContainsKey(t.ToString()))
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("该实体信息已存在 请删除原信息后重新添加"));
                    this.txtTypeStr.SelectAll();
                    return;
                }

                List<Neusoft.FrameWork.Models.NeuObject> alProperty = this.GetProperty(t);
                if (alProperty != null)
                {
                    if (alProperty.Count == 0)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("该实体类无满足条件的属性信息"));
                        return;
                    }

                    this.neuSpread1_Sheet1.Rows.Count = 0;
                    foreach (Neusoft.FrameWork.Models.NeuObject info in alProperty)
                    {
                        this.neuSpread1_Sheet1.Rows.Add(0, 1);
                        this.neuSpread1_Sheet1.Cells[0, 0].Text = info.Name;        //属性名称中文描述
                        this.neuSpread1_Sheet1.Cells[0, 1].Text = info.Memo;        //属性描述

                        this.neuSpread1_Sheet1.Rows[0].Tag = info;
                    }
                }
            }
            catch
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("未能由输入信息获取类型 请检查是否输入正确"));
                return;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        #endregion

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.Clear();

            this.GetShiftProperty();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtTypeStr.Text != "")
            {
                this.result = DialogResult.OK;
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.result = DialogResult.Cancel;

            this.Close();
        }
    }
}
