using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    public partial class ucPrivManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPrivManager()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 系统权限列表
        /// </summary>
        private ArrayList alClass3Meaning = new ArrayList();

        /// <summary>
        /// 三级权限管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.PowerLevelManager class3Manager = new Neusoft.HISFC.BizLogic.Manager.PowerLevelManager();
      
        /// <summary>
        /// 二级权限实体类
        /// </summary>
        private Neusoft.HISFC.Models.Admin.PowerLevelClass2 operClass2Priv = new Neusoft.HISFC.Models.Admin.PowerLevelClass2();
        
        /// <summary>
        /// 二级权限管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.PowerLevel2Manager class2Manager = new Neusoft.HISFC.BizLogic.Manager.PowerLevel2Manager();

        /// <summary>
        /// 三级权限关联
        /// </summary>
        private System.Collections.Hashtable hsClass3JoinCode = new Hashtable();

        /// <summary>
        /// 是否可以修改系统权限与二级权限
        /// </summary>
        private bool isEditSysData = false;

        #endregion

        #region 属性

        /// <summary>
        /// 是否可以维护系统权限类型
        /// </summary>
        public bool IsManagerEdit
        {
            get
            {
                return this.isEditSysData;
            }
            set
            {
                this.isEditSysData = value;
                this.gbClass2.Enabled = value;
                this.gbClass3Meaning.Enabled = value;
            }
        }

        #endregion

        /// <summary>
        /// 根据传入的参数，显示可维护的一级权限
        /// </summary>
        /// <param name="parm"></param>
        public void ShowClass1(string parm)
        {
            //清空节点
            this.tvClass1.Nodes.Clear();

            //取可维护的一级权限，显示在树型控件的根节点。
            Neusoft.HISFC.BizLogic.Manager.PowerLevel1Manager class1Manager = new Neusoft.HISFC.BizLogic.Manager.PowerLevel1Manager();
            ArrayList al = class1Manager.LoadLevel1Available(parm);
            if (al == null)
            {
                MessageBox.Show(Language.Msg(class1Manager.Err));
                return;
            }

            this.tvClass1.ImageList = this.tvClass1.groupImageList;

            //添加一级权限节点
            Neusoft.HISFC.Models.Admin.PowerLevelClass2 class2 = null;

            foreach (Neusoft.HISFC.Models.Admin.PowerLevelClass1 info in al)
            {
                TreeNode node = this.tvClass1.Nodes.Add(info.Name);

                node.Text = info.Class1Name;
                node.ImageIndex = 2;
                node.SelectedImageIndex = 4;
                //将一级权限的信息转换为二级权限实体,并保存在节点的Tag中
                class2 = new Neusoft.HISFC.Models.Admin.PowerLevelClass2();
                class2.Class1Code = info.Class1Code;

                node.Tag = class2;
            }
        }

        /// <summary>
        /// 显示二级权限
        /// </summary>
        public void ShowClass2()
        {
            //清屏
            this.Clear();

            //取二级权限
            ArrayList al = this.class2Manager.LoadLevel2All(this.operClass2Priv.Class1Code);
            if (al == null)
            {
                MessageBox.Show(Language.Msg(class2Manager.Err));
                return;
            }
            //将二级权限显示在列表中
            this.fpClass2_Sheet1.RowCount = al.Count;
            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Admin.PowerLevelClass2 info = al[i] as Neusoft.HISFC.Models.Admin.PowerLevelClass2;

                this.fpClass2_Sheet1.Cells[i, 0].Text = info.Class2Code;		    //二级权限编码	
                this.fpClass2_Sheet1.Cells[i, 1].Text = info.Class2Name;		    //二级权限名称 
                this.fpClass2_Sheet1.Cells[i, 2].Text = info.Flag;			        //特殊标记 
                this.fpClass2_Sheet1.Cells[i, 3].Text = info.Memo;			        //备注 
                this.fpClass2_Sheet1.Cells[i, 4].Text = info.Class1Code;		    //一级权限编码 
                this.fpClass2_Sheet1.Rows[i].Tag = info;
            }

            if (al.Count > 0)
            {
                this.fpClass2_Sheet1.ActiveColumnIndex = 0;

                //取当前二级权限
                this.GetClass2();
            }
        }

        /// <summary>
        /// 显示三级权限
        /// </summary>
        public void ShowClass3()
        {
            //{42AB2AC3-EAC6-4b7d-9102-4997B2E9AAAA} 增加二级权限报错
            if (this.operClass2Priv == null || string.IsNullOrEmpty( this.operClass2Priv.Class2Code))
            {
                this.fpClass3_Sheet1.RowCount = 0;

                return;
            }

            //取三级权限
            ArrayList al = class3Manager.LoadLevel3ByLevel2(this.operClass2Priv.Class2Code);
            if (al == null)
            {
                MessageBox.Show(Language.Msg(class2Manager.Err));
                return;
            }

            string[] class3JoinCollection = this.ShowClass3JoinPriv();

            if (class3JoinCollection != null)
            {
                //创建ComboBoxCellType，填充系统类型列
                FarPoint.Win.Spread.CellType.ComboBoxCellType combo = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                //将ComboBoxCellType付给三级权限的对应列
                combo.Items = class3JoinCollection;
                this.fpClass3_Sheet1.Columns[5].CellType = combo;
            }
            else
            {
                //创建ComboBoxCellType，填充系统类型列
                FarPoint.Win.Spread.CellType.ComboBoxCellType combo = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                //将ComboBoxCellType付给三级权限的对应列
                combo.Items = new string[1];
                this.fpClass3_Sheet1.Columns[5].CellType = combo;
            }

            //显示三级权限
            this.fpClass3_Sheet1.RowCount = al.Count;

            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Admin.PowerLevelClass3 info = al[i] as Neusoft.HISFC.Models.Admin.PowerLevelClass3;
                this.fpClass3_Sheet1.Cells[i, 0].Text = info.ID;
                this.fpClass3_Sheet1.Cells[i, 1].Text = info.Name;
                this.fpClass3_Sheet1.Cells[i, 2].Text = info.Class3MeaningCode;
                this.fpClass3_Sheet1.Cells[i, 3].Text = info.Class3MeaningName;

                this.fpClass3_Sheet1.Cells[i, 4].Text = info.Class3JoinCode;
                if (this.hsClass3JoinCode.ContainsKey(info.Class3JoinCode))
                {
                    this.fpClass3_Sheet1.Cells[i, 5].Text = this.hsClass3JoinCode[info.Class3JoinCode] as string;
                }

                this.fpClass3_Sheet1.Cells[i, 6].Text = info.Memo;
                this.fpClass3_Sheet1.Rows[i].Tag = info;
            }
        }

        /// <summary>
        /// 获取允许的三级分类权限集合
        /// </summary>
        protected string[] ShowClass3JoinPriv()
        {
            string class2JoinPrivCode = null;
            if (this.operClass2Priv.Class2Code.Substring(2) == "10" )
            {
                class2JoinPrivCode = "20";
            }
            else if (this.operClass2Priv.Class2Code.Substring(2) == "20")
            {
                class2JoinPrivCode = "10";
            }
            else
            {
                return null;
            }

            ArrayList alClass3Join = class3Manager.LoadLevel3ByLevel2(this.operClass2Priv.Class1Code + class2JoinPrivCode);
            if (alClass3Join == null)
            {
                return null;
            }

            string[] class3JoinName = new string[alClass3Join.Count];
            int i = 0;
            this.hsClass3JoinCode = new Hashtable();

            foreach (Neusoft.HISFC.Models.Admin.PowerLevelClass3 class3Join in alClass3Join)
            {
                class3JoinName[i] = class3Join.Class3Name;

                this.hsClass3JoinCode.Add(class3Join.Class3Code, class3Join.Class3Name);

                i++;
            }

            return class3JoinName;
        }

        /// <summary>
        /// 显示系统权限
        /// </summary>
        public void ShowClass3Meaning()
        {
            //{42AB2AC3-EAC6-4b7d-9102-4997B2E9AAAA} 增加二级权限报错
            //if (this.operClass2Priv == null)
            if (this.operClass2Priv == null || string.IsNullOrEmpty(this.operClass2Priv.Class2Code))
            {
                this.fpClass3Meaning_Sheet1.RowCount = 0;

                return;
            }

            //取系统权限
            alClass3Meaning = class3Manager.LoadLevel3Meaning(this.operClass2Priv.Class2Code);
            if (alClass3Meaning == null)
            {
                MessageBox.Show(Language.Msg(class3Manager.Err));
                return;
            }

            //取系统权限数组
            string[] items = new string[this.alClass3Meaning.Count];
            int index = 0;

            //显示系统权限
            this.fpClass3Meaning_Sheet1.RowCount = alClass3Meaning.Count;
            Neusoft.FrameWork.Models.NeuObject info;
            for (int i = 0; i < alClass3Meaning.Count; i++)
            {
                info = alClass3Meaning[i] as Neusoft.FrameWork.Models.NeuObject;
                this.fpClass3Meaning_Sheet1.Cells[i, 0].Text = info.ID;
                this.fpClass3Meaning_Sheet1.Cells[i, 1].Text = info.Name;
                this.fpClass3Meaning_Sheet1.Cells[i, 2].Text = info.Memo;
                this.fpClass3Meaning_Sheet1.Rows[i].Tag = info;

                items[index] = info.Name;
                index++;
            }

            //如果此二级权限下没有系统权限，则默认二级权限名称，编码为01
            if (alClass3Meaning.Count == 0)
            {
                items = new string[1];
                items[0] = this.operClass2Priv.Class2Name;
            }

            //创建ComboBoxCellType，填充系统类型列
            FarPoint.Win.Spread.CellType.ComboBoxCellType combo = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            //将ComboBoxCellType付给三级权限的对应列
            combo.Items = items;
            this.fpClass3_Sheet1.Columns[3].CellType = combo;
        }

        /// <summary>
        /// 保存二级权限
        /// </summary>
        public void SaveClass2()
        {
            int parm;
            bool isUpdate = false;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            try
            {
                //二级
                this.class2Manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //先删除数据
                parm = this.class2Manager.DeleteLevel2(this.operClass2Priv.Class1Code);
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Language.Msg("保存二级权限时删除操作发生错误 " + class2Manager.Err), "错误提示");
                    return;
                }

                //如果处理到有效的数据则更新标志
                if (parm > 0)
                {
                    isUpdate = true;
                }

                Neusoft.HISFC.Models.Admin.PowerLevelClass2 info;
                //插入数据
                for (int i = 0; i < this.fpClass2_Sheet1.Rows.Count; i++)
                {
                    info = new Neusoft.HISFC.Models.Admin.PowerLevelClass2();

                    info.Class2Code = this.fpClass2_Sheet1.Cells[i, 0].Text; //二级权限编码
                    info.Class2Name = this.fpClass2_Sheet1.Cells[i, 1].Text; //二级权限名称
                    if (info.Class2Code == "" || info.Class2Name == "")
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        MessageBox.Show(Language.Msg("二级权限编码和名称不能为空"), "提示");
                        return;
                    }
                    
                    info.Class1Code = this.operClass2Priv.Class1Code;		    //一级权限编码
                    info.Flag = this.fpClass2_Sheet1.Cells[i, 2].Text;	    //特殊标记
                    info.Memo = this.fpClass2_Sheet1.Cells[i, 3].Text;        //备注
                    this.fpClass2_Sheet1.Rows[i].Tag = info;	                //在当前行中保存二级权限信息
                    parm = class2Manager.InsertLevel2(info);
                    if (parm != 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        if (this.class2Manager.DBErrCode == 1)
                            MessageBox.Show(Language.Msg("编码为【" + info.Class2Code + "】的二级权限已经存在,不能重复添加."));
                        else
                            MessageBox.Show(Language.Msg(this.class3Manager.Err), "错误提示");

                        return;
                    }
                }

                //如果处理到有效的数据则更新标志
                if (this.fpClass2_Sheet1.Rows.Count > 0)
                {
                    isUpdate = true;
                }

                if (isUpdate)
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();;
                    MessageBox.Show(Language.Msg("保存成功"), "提示");
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                MessageBox.Show(ex.Message, "错误提示");
            }
        }

        /// <summary>
        /// 保存三级权限
        /// </summary>
        public void SaveClass3()
        {
            int parm;
            bool isUpdate = false;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            class3Manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //先删除数据
            parm = class3Manager.Delete(this.operClass2Priv.Class2Code);
            if (parm == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                MessageBox.Show(Language.Msg(class3Manager.Err), "错误提示");
                return;
            }

            //如果处理到有效的数据则更新标志
            if (parm > 0)
            {
                isUpdate = true;
            }

            Neusoft.HISFC.Models.Admin.PowerLevelClass3 info;
            //插入数据
            for (int i = 0; i < this.fpClass3_Sheet1.Rows.Count; i++)
            {
                info = new Neusoft.HISFC.Models.Admin.PowerLevelClass3();

                info.Class3Code = this.fpClass3_Sheet1.Cells[i, 0].Text;          //三级权限编码
                info.Class3Name = this.fpClass3_Sheet1.Cells[i, 1].Text;          //三级权限名称
                info.Class3MeaningCode = this.fpClass3_Sheet1.Cells[i, 2].Text;   //系统权限编码
                info.Class3MeaningName = this.fpClass3_Sheet1.Cells[i, 3].Text;   //系统权限名称

                if (info.Class3Code == "" || info.Class3Name == "")
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Language.Msg("三级权限编码和名称不能为空"), "提示");
                    return;
                }

                if (info.Class3MeaningCode == "" || info.Class3MeaningName == "")
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Language.Msg("请选择系统权限"), "提示");
                    return;
                }

                info.Class3JoinCode = this.fpClass3_Sheet1.Cells[i, 4].Text;           //关联权限名称               

                info.Memo = this.fpClass3_Sheet1.Cells[i, 6].Text; //备注
                info.Class2Code = this.operClass2Priv.Class2Code;					   //二级权限编码
                parm = class3Manager.InsertPowerLevelClass3(info);
                if (parm != 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    if (this.class3Manager.DBErrCode == 1)
                        MessageBox.Show(Language.Msg("编码为【" + info.Class3Code + "】的三级权限已经存在,不能重复添加."));
                    else
                        MessageBox.Show(Language.Msg(this.class3Manager.Err), "错误提示");

                    return;
                }
            }

            //如果处理到有效的数据则更新标志
            if (this.fpClass3_Sheet1.Rows.Count > 0)
            {
                isUpdate = true;
            }

            if (isUpdate)
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();;
                MessageBox.Show(Language.Msg("保存成功"), "提示");
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
            }
        }

        /// <summary>
        /// 保存系统权限
        /// </summary>
        public void SaveClass3Meaning()
        {
            int parm;
            bool isUpdate = false;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            class3Manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //先删除数据
            parm = this.class3Manager.DeleteLevel3Meaning(this.operClass2Priv.Class2Code);
            if (parm == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                MessageBox.Show(Language.Msg(class3Manager.Err), "错误提示");
                return;
            }

            //如果处理到有效的数据则更新标志
            if (parm > 0) isUpdate = true;

            Neusoft.FrameWork.Models.NeuObject info;
            //插入数据
            for (int i = 0; i < this.fpClass3Meaning_Sheet1.Rows.Count; i++)
            {
                info = new Neusoft.FrameWork.Models.NeuObject();
                info.ID = this.fpClass3Meaning_Sheet1.Cells[i, 0].Text; //系统权限编码
                info.Name = this.fpClass3Meaning_Sheet1.Cells[i, 1].Text; //系统权限名称
                if (info.ID == "" || info.Name == "")
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Language.Msg("系统权限编码和名称不能为空"), "提示");
                    return;
                }
                info.Memo = this.fpClass3Meaning_Sheet1.Cells[i, 2].Text; //备注
                info.User01 = this.operClass2Priv.Class2Code;					 //二级权限编码
                info.User02 = this.operClass2Priv.Class2Name;					 //二级权限名称
                parm = class3Manager.InsertLevel3Meaning(info);
                if (parm != 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    if (this.class3Manager.DBErrCode == 1)
                        MessageBox.Show(Language.Msg("编码为【" + info.ID + "】的系统权限已经存在,不能重复添加."));
                    else
                        MessageBox.Show(Language.Msg(this.class3Manager.Err), "错误提示");

                    return;
                }
            }

            //如果处理到有效的数据则更新标志
            if (this.fpClass3Meaning_Sheet1.Rows.Count > 0) isUpdate = true;

            if (isUpdate)
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();;
                MessageBox.Show(Language.Msg("保存成功"), "提示");
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
            }
        }

        /// <summary>
        /// 取当前的二级权限
        /// </summary>
        public void GetClass2()
        {
            //取当前操作的行中的数据
            Neusoft.HISFC.Models.Admin.PowerLevelClass2 temp = this.fpClass2_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.Admin.PowerLevelClass2;
            if (temp == null)
            {
                this.operClass2Priv.Class2Code = "";
            }
            else
            {
                this.operClass2Priv = temp;
            }

            //显示系统权限
            this.ShowClass3Meaning();

            //显示三级权限
            this.ShowClass3();
        }

        /// <summary>
        /// 清屏
        /// </summary>
        private void Clear()
        {
            //清空二级权限记录
            this.fpClass2_Sheet1.RowCount = 0;
            //清空三级权限记录
            this.fpClass3_Sheet1.RowCount = 0;
            //清空系统权限记录
            this.fpClass3Meaning_Sheet1.RowCount = 0;
        }


        private void ucPrivManager_Load(object sender, System.EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.ShowClass1("@@");

               // this.IsManagerEdit = false;
                this.gbClass2.Enabled = this.isEditSysData;
                this.gbClass3Meaning.Enabled = this.isEditSysData;
                //不允许删除
                this.btSysDel.Enabled = false;
                this.btnDeleteClass2.Enabled = false;
            }
        }

        private void tvClass1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.operClass2Priv = e.Node.Tag as Neusoft.HISFC.Models.Admin.PowerLevelClass2;

            this.ShowClass2();
        }

        private void fpClass2_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            if (this.fpClass2_Sheet1.RowCount == 0) return;

            //取当前操作的行中的数据
            this.GetClass2();
        }

        private void fpClass3_ComboSelChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 3)
            {
                try
                {
                    //取当前选中的系统权限名称
                    string text = ((FarPoint.Win.FpCombo)e.EditingControl).SelectedItem.ToString();
                    //找到文本所对应的系统权限编码，付给对应的列
                    foreach (Neusoft.FrameWork.Models.NeuObject info in this.alClass3Meaning)
                    {
                        if (text == info.Name)
                        {
                            this.fpClass3_Sheet1.Cells[e.Row, 2].Value = info.ID;
                            break;
                        }
                    }

                    //如果此二级权限下没有系统权限，则默认二级权限名称，编码为01
                    if (this.alClass3Meaning.Count == 0)
                    {
                        this.fpClass3_Sheet1.Cells[e.Row, 0].Text = "01"; //三级权限编码
                        this.fpClass3_Sheet1.Cells[e.Row, 2].Text = "01"; //系统权限编码
                    }

                    //三级权限默认名称为系统权限名称
                    if (this.fpClass3_Sheet1.Cells[e.Row, 1].Text == "") this.fpClass3_Sheet1.Cells[e.Row, 1].Text = text;

                }
                catch { }
            }
            if (e.Column == 5)
            {
                try
                {
                    if (e.EditingControl == null)
                    {
                        return;
                    }

                    //取当前选中的系统权限名称
                    string text = ((FarPoint.Win.FpCombo)e.EditingControl).SelectedItem.ToString();
                    //找到文本所对应的系统权限编码，付给对应的列
                    foreach (string strKey in this.hsClass3JoinCode.Keys)
                    {
                        if (this.hsClass3JoinCode[strKey] as string == text)
                        {
                            this.fpClass3_Sheet1.Cells[e.Row, 4].Value = strKey;
                            break;
                        }
                    }
                }
                catch { }
            }

        }


        private void btnAddClass2_Click(object sender, System.EventArgs e)
        {
            if (this.operClass2Priv.Class1Code == "") return;

            this.fpClass2_Sheet1.Rows.Add(this.fpClass2_Sheet1.RowCount, 1);
            //显示第一条数据
            this.fpClass2_Sheet1.ActiveRowIndex = this.fpClass2_Sheet1.RowCount - 1;
            this.fpClass2_Sheet1.Cells[this.fpClass2_Sheet1.ActiveRowIndex, 2].Value = 0;	//默认的特殊标记为0,特殊标记的含义是:在判断权限时,不考虑科室信息
            //取当前二级权限信息
            this.GetClass2();
            this.fpClass2.Focus();
        }

        private void btnDeleteClass2_Click(object sender, System.EventArgs e)
        {
            if (this.fpClass2_Sheet1.RowCount == 0)
            {
                MessageBox.Show(Language.Msg("请选择要删除的系统权限"), "提示");
                return;
            }
            if (MessageBox.Show(Language.Msg("确定要删除此条二级权限吗？"), "二级权限删除", MessageBoxButtons.YesNo) == DialogResult.No) return;
            //删除一条二级权限
            this.fpClass2_Sheet1.ActiveRow.Remove();
        }

        private void btnSaveClass2_Click(object sender, System.EventArgs e)
        {
            //保存二级权限
            this.SaveClass2();
        }


        private void btnAddClass3_Click(object sender, System.EventArgs e)
        {
            if (this.operClass2Priv.Class2Code == "")
            {
                MessageBox.Show(Language.Msg("请选择一项二级权限"), "提示");
                return;
            }

            if (this.neuTabControl1.SelectedIndex == 0)
            {
                //如果此二级权限下没有系统权限，则只能增加一条三级权限
                if (this.alClass3Meaning.Count == 0 && this.fpClass3_Sheet1.RowCount == 1)
                {
                    MessageBox.Show(Language.Msg("此二级权限下只能存在一条三级权限！"), "提示");
                    return;
                }
                //增加一条三级权限
                this.fpClass3_Sheet1.Rows.Add(this.fpClass3_Sheet1.RowCount, 1);
                //显示第一条数据
                this.fpClass3_Sheet1.ActiveRowIndex = this.fpClass3_Sheet1.RowCount - 1;
                this.fpClass3.Focus();
            }
            else
            {
                //增加一条系统权限
                this.fpClass3Meaning_Sheet1.Rows.Add(this.fpClass3Meaning_Sheet1.RowCount, 1);
                //显示第一条数据
                this.fpClass3Meaning_Sheet1.ActiveRowIndex = this.fpClass3Meaning_Sheet1.RowCount - 1;
                this.fpClass3Meaning.Focus();
            }
        }

        private void btnDeleteClass3_Click(object sender, System.EventArgs e)
        {
            if (this.neuTabControl1.SelectedIndex == 0)
            {
                if (this.fpClass3_Sheet1.RowCount == 0)
                {
                    MessageBox.Show(Language.Msg("没有可以删除的三级权限"), "提示");
                    return;
                }
                if (MessageBox.Show(Language.Msg("确定要删除此条三级权限吗？"), "三级权限删除", MessageBoxButtons.YesNo) == DialogResult.No) return;
                //删除一条三级权限
                this.fpClass3_Sheet1.ActiveRow.Remove();
                //保存三级权限
                this.SaveClass3();
            }
            else
            {
                if (this.fpClass3Meaning_Sheet1.RowCount == 0)
                {
                    MessageBox.Show(Language.Msg("没有可以删除的系统权限"), "提示");
                    return;
                }
                if (MessageBox.Show(Language.Msg("确定要删除此条系统权限吗？"), "系统权限删除", MessageBoxButtons.YesNo) == DialogResult.No) return;
                //删除一条系统权限
                this.fpClass3Meaning_Sheet1.ActiveRow.Remove();
                //保存系统权限
                this.SaveClass3Meaning();
            }
        }

        private void btnSaveClass3_Click(object sender, System.EventArgs e)
        {
            if (this.operClass2Priv.Class2Code == "") return;
            if (this.neuTabControl1.SelectedIndex == 0)
            {
                //保存三级权限
                this.SaveClass3();
            }
            else
            {
                //保存系统权限
                this.SaveClass3Meaning();
            }
        }

        private void tabControl1_SelectionChanged(object sender, EventArgs e)
        {
           
        }
    }
}
