using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
//using Neusoft.Framework.Configuration;
//using Neusoft.Framework;
//using Neusoft.Framework.Interface;


namespace Neusoft.UFC.Privilege.Forms
{
    internal class Util
    {
        //private static Neusoft.Framework.Unity.FrameworkFactory factory;
        static Util()
        {
            //factory = Neusoft.Framework.Unity.FrameworkFactory.Current;
        }

        public static NFC.Management.ConfigurationManager CreateProxy()
        {
            return new Neusoft.NFC.Management.ConfigurationManager();
        }

        /// <summary>
        /// 设置属性给控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="propertys"></param>
        public static void SetPropertyToControl(Control control, Dictionary<string, string> propertys)
        {
            if (propertys == null) return;

            foreach (KeyValuePair<string, string> _pair in propertys)
            {
                string _value = "";
                object _propValue = null ;

                PropertyDescriptor _prop = TypeDescriptor.GetProperties(control)[_pair.Key];

                //设置属性
                if (_prop != null)
                {
                    bool isContent = _prop.Attributes.Contains(DesignerSerializationVisibilityAttribute.Content);
                    if (!isContent)
                    {
                        try
                        {
                            if (_prop.PropertyType.ToString() == "System.Drawing.Color")
                            {
                                _value = _pair.Value.Replace("Color [", "");
                                _value = _value.Substring(0, _value.Length - 1);
                                //不是RGB格式,按名称解析
                                if (!(_value.IndexOf("R") >= 0 && _value.IndexOf("G") >= 0 && _value.IndexOf("B") >= 0))
                                {
                                    _propValue = Color.FromName(_value);
                                }
                                else
                                {
                                    //_propValue = Color.FromArgb(
                                }
                            }
                            else
                            {
                                _propValue = _prop.Converter.ConvertFromInvariantString(_pair.Value);
                            }

                            _prop.SetValue(control, _propValue);
                        }
                        catch (Exception e) { throw e; }
                    }
                }
            }
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static Control CreateControl(string dllName, string Name)
        {
            if (dllName.Trim() == "") return null;

            System.Runtime.Remoting.ObjectHandle s;
            string objectNameSpace = dllName;
            string objectName = Name;
            string name = objectName.Substring(objectName.LastIndexOf(".") + 1);

            Control control = null;
            try
            {
                s = System.Activator.CreateInstance(objectNameSpace, objectName, true, System.Reflection.BindingFlags.CreateInstance, null, null, null, null, null);
                control = (Control)s.Unwrap();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }

            return control;
        }

        /// <summary>
        /// 用PopForm窗口显示弹出控件
        /// </summary>
        /// <param name="c">待显示的控件</param>
        /// <returns>System.Windows.Forms.DialogResult</returns>
        public static System.Windows.Forms.DialogResult PopShowControl(Control c )
        {
            BaseForm _form = new BaseForm();
            _form.SetOperAndDateInvisible();
                        
            _form.StartPosition = FormStartPosition.CenterScreen;
            _form.FormBorderStyle = FormBorderStyle.FixedToolWindow;//窗口边框类型
            _form.WindowState = FormWindowState.Normal;//窗口状态
            _form.AutoScaleMode = AutoScaleMode.None;

            //创建控件并添加到临时窗口中
            if (c == null) c = new Control();
            _form.Width = c.Width + 8;
            _form.Height = c.Height + 34;
            c.Dock = DockStyle.Fill;
            _form.Controls.Clear();
            _form.Visible = false;
            _form.Controls.Add(c);
            //显示临时窗口
            _form.ShowDialog();
            try
            {
                c.Dock = DockStyle.None;
            }
            catch { }
            _form.Text = c.Text;

            return _form.DialogResult;
        }

        //internal static PrivilegeService CreateProxy()
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}
    }
}
