using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Neusoft.HISFC.Components.Privilege
{
    internal class Function
    {
        public static void ShowForm(Neusoft.HISFC.Models.Admin.SysMenu obj)
        {
            if (obj == null) return;

            string dllName = obj.ModelFuntion.DllName + ".dll";
            string formName = obj.ModelFuntion.WinName.TrimStart().TrimEnd();
            string tag = obj.MenuParm;
            string param = "";
            string showType = obj.ModelFuntion.FormShowType;
            #region {CCC3E877-ADB8-43e5-80B5-53FDEE94C47E}
            switch (showType)
            {
                case "FormDialog":
                    // ((Form)form).ShowDialog();
                    break;
                case "Web":
                    try
                    {
                        //System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();

                        System.Diagnostics.Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", formName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    return;
                default:
                    //((Form)form).Show();
                    break;
            } 
            #endregion
            string tree = obj.ModelFuntion.TreeControl.WinName;
            string treeDll = obj.ModelFuntion.TreeControl.DllName + ".dll";
            string treeTag = obj.ModelFuntion.TreeControl.Param;


            if (formName == "") return;

            if (formName.IndexOf(" ") >= 0)
            {
                param = formName.Substring(formName.IndexOf(" ") + 1).TrimStart();
                formName = formName.Substring(0, formName.IndexOf(" "));
            }

            System.Windows.Forms.Control form = null;
            System.Reflection.Assembly assembly = null;

           
            Object[] objParam = null;
            if (param != "")
            {
                objParam = new object[0];
                objParam[0] = param;
            }
            try
            {
                assembly = System.Reflection.Assembly.LoadFrom(dllName);
                Type type = assembly.GetType(formName);
                if (type == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("创建窗体出错！\n") + formName);
                    return;
                }
                System.Object objHandle = System.Activator.CreateInstance(type, objParam);
                form = objHandle as Control;
                form.Tag = tag;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("创建窗体出错！\n") + ex.Message);
                return;
            }



            Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable iQueryControl = form as Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable;
            if (iQueryControl != null) //维护查询窗口
            {
                form = new Neusoft.FrameWork.WinForms.Forms.frmQuery(iQueryControl);
                //将菜单的名称付给窗口的名称
                form.Text = obj.MenuName;
            }

            Neusoft.FrameWork.WinForms.Forms.IControlable iControlable = form as Neusoft.FrameWork.WinForms.Forms.IControlable;
            if (iControlable != null) //功能窗口
            {
                //添加树
                System.Windows.Forms.TreeView tv = null;
                if (tree.Trim() != "")
                {
                    assembly = System.Reflection.Assembly.LoadFrom(treeDll);
                    tv = AddTree(tree, assembly, tv);
                }
                if (tv == null)
                    form = new Neusoft.FrameWork.WinForms.Forms.frmBaseForm(form);
                else
                {
                    tv.Tag = treeTag;
                    form = new Neusoft.FrameWork.WinForms.Forms.frmBaseForm(form, tv);
                }
                //将菜单的名称付给窗口的名称
                form.Text = obj.MenuName;
            }

            Type typeSender = form.GetType();
            if (typeSender.IsSubclassOf(typeof(Neusoft.FrameWork.WinForms.Forms.frmBaseForm)) || typeSender == typeof(Neusoft.FrameWork.WinForms.Forms.frmBaseForm))
            {
                ((Neusoft.FrameWork.WinForms.Forms.frmBaseForm)form).SetFormID(obj.MenuWin);
            }

            switch (showType)
            {
                case "FormDialog":
                    ((Form)form).ShowDialog();
                    break;
                case "Web":
                    try
                    {
                        //System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                        
                        System.Diagnostics.Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", formName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                default:
                    ((Form)form).Show();
                    break;
            }
        }

        private static System.Windows.Forms.TreeView AddTree(string tree, System.Reflection.Assembly assembly, System.Windows.Forms.TreeView tv)
        {
            Type type = assembly.GetType(tree);
            if (type != null)
            {
                try
                {

                    tv = System.Activator.CreateInstance(type) as System.Windows.Forms.TreeView;
                }
                catch { }

            }
            return tv;
        }
    }
}
