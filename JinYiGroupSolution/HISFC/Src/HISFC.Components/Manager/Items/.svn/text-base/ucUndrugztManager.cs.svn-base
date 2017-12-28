//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;

//namespace Neusoft.HISFC.Components.Manager.Items
//{
//    public partial class ucUndrugztManager : UserControl
//    {
//        #region 全局变量

//        public delegate void SaveHandle(neusoft.HISFC.Object.Fee.Undrugzt obj);
//        public event SaveHandle SaveInfo;
//        //private neusoft.Common.Class.EditTypes editType; //标识

//        #endregion

//        public ucUndrugztManager()
//        {
//            InitializeComponent();
//        }

//        /// <summary>
//        /// 初始化下拉列表
//        /// </summary>
//        public void InitList()
//        {
//            Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
//            ArrayList al = dept.GetDeptmentAllOrderByDeptType();
//            //系统类别
//            this.cbSysClass.AddItems(Neusoft.HISFC.Models.Base.SysClassEnumService.List());
//            this.cbDept.AddItems(al);
//        }
//        //public neusoft.Common.Class.EditTypes EditType
//        //{
//        //    get
//        //    {
//        //        return editType;
//        //    }
//        //    set
//        //    {
//        //        editType = value;
//        //    }

//        //}

//        /// <summary>
//        /// 清除所有的信息
//        /// </summary>
//        private void ClearInfo()
//        {
//            this.tbZTName.Text = ""; //组套名称
//            this.tbSpell.Text = "";//拼音码
//            this.tbWB.Text = "";//五笔码
//            this.tbInput.Text = "";//输入码
//            this.cbSysClass.Tag = null;//系统类别
//            this.cbSysClass.Text = "";
//            this.cbDept.Tag = null;//执行科室
//            this.cbDept.Text = "";
//            this.Mark4.Text = "";//检查单名称
//            this.tbSortID.Text = ""; //序号
//            this.ckbConfirm.Checked = false;//确认标志
//            this.ckbValid.Checked = false;//有效标志
//            this.cbSpellItem.Checked = false;//特殊项目标志
//        }
//        /// <summary>
//        /// 加载数据
//        /// </summary>
//        public void SetValue(neusoft.HISFC.Object.Fee.Undrugzt info)
//        {
//            ztName.Tag = info.ID;//组套编码
//            ztName.Text = info.Name; //组套名称
//            txSpellCode.Text = info.spellCode;//拼音码
//            txtWB.Text = info.wbCode;//五笔码
//            txtInput.Text = info.inputCode;//输入码
//            comSys.Tag = info.sysClass;//系统类别
//            comDept.Tag = info.deptCode;//执行科室
//            Mark4.Text = info.Mark4;//检查单名称
//            textBox5.Text = info.sortId.ToString(); //序号
//            cbEnter.Checked = neusoft.neuFC.Function.NConvert.ToBoolean(info.confirmFlag);//确认标志
//            cbValid.Checked = !neusoft.neuFC.Function.NConvert.ToBoolean(info.validState);//有效标志
//            if (info.User01 == "1")
//            {
//                cbSpellItem.Checked = true;//特殊项目标志
//            }
//            else
//            {
//                cbSpellItem.Checked = false;
//            }
//            Mark1.Text = info.Mark1;
//            Mark2.Text = info.Mark2;
//            Mark3.Text = info.Mark3;
//        }
//        /// <summary>
//        /// 提取数据
//        /// </summary>
//        private Neusoft.HISFC.Models.Fee.Undrugztinfo GetValue()
//        {
//            neusoft.HISFC.Object.Fee.Undrugzt info = new neusoft.HISFC.Object.Fee.Undrugzt();
//            try
//            {
//                if (ztName.Tag != null)
//                {
//                    info.ID = ztName.Tag.ToString();
//                }
//                info.Name = ztName.Text; //组套名称
//                info.spellCode = txSpellCode.Text;//拼音码
//                info.wbCode = txtWB.Text;//五笔码
//                info.inputCode = txtInput.Text;//输入码
//                if (comSys.Tag != null)
//                {
//                    info.sysClass = comSys.Tag.ToString();//系统类别
//                }
//                if (comDept.Tag != null)
//                {
//                    info.deptCode = comDept.Tag.ToString();//执行科室
//                }
//                info.Mark4 = Mark4.Text;//检查单名称
//                info.sortId = neusoft.neuFC.Function.NConvert.ToInt32(textBox5.Text); //序号
//                if (cbEnter.Checked)
//                {
//                    info.confirmFlag = "1";//确认标志
//                }
//                else
//                {
//                    info.confirmFlag = "0";//确认标志
//                }
//                if (cbValid.Checked)
//                {
//                    info.validState = "0";//有效标志
//                }
//                else
//                {
//                    info.validState = "1";//有效标志
//                }
//                if (cbSpellItem.Checked)
//                {
//                    info.User01 = "1";//特殊项目标志
//                }
//                else
//                {
//                    info.User01 = "0";//特殊项目标志
//                }
//                info.Mark1 = Mark1.Text;
//                info.Mark2 = Mark2.Text;
//                info.Mark3 = Mark3.Text;
//                return info;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//                return null;
//            }
//        }
//    }
//}