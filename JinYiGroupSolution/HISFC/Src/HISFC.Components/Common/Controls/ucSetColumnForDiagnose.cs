using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.IO;

namespace Neusoft.UFC.Common.Controls
{
    /*----------------------------------------------------------------
    // Copyright (C) 2004 东软集团有限公司
    // 版权所有。 
    //
    // 文件名：ucSetColumnForDiagnose
    // 文件功能描述：用来设置输入诊断控件的列信息，并将其保存到本地配置文件中。
    //
    // 
    // 创建标识：leiyj 2007-07-18
    //
    // 修改标识：
    // 修改描述：
    //
    // 修改标识：
    // 修改描述：
    ----------------------------------------------------------------*/

    public partial class ucSetColumnForDiagnose : UserControl
    {
        public ucSetColumnForDiagnose()
        {
            InitializeComponent();
            this.allColumns = new ArrayList();
            this.showColumns = new ArrayList();
            this.ConfigDoc = new XmlDocument();
        }

        public ucSetColumnForDiagnose(ArrayList allCols,ArrayList showCols)
        {
            InitializeComponent();
            this.allColumns = allCols;
            this.showColumns = showCols;
            this.ConfigDoc = new XmlDocument();
        }

        #region 变量
        //所有的列
        public ArrayList allColumns;

        //显示的列
        public ArrayList showColumns ;

        //配置文件名
        public string configFileName = Application.StartupPath + @"\profile\DiagnoseInputSetting.xml";

        //配置文件
        private XmlDocument ConfigDoc ;
        #endregion

        #region 方法

        /// <summary>
        /// 保存修改到配置文件和数组列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //判断选择项是否为空
            if (this.chklsSetColumn.CheckedItems.Count != 0)
            {
                this.showColumns.Clear();
                //根节点
                XmlNode setNode = this.ConfigDoc.SelectSingleNode("//Setting");

                //判断有无该控件节点
                if (this.ConfigDoc.SelectNodes("//Setting//" + this.Name).Count != 0)
                {
                    setNode.RemoveChild(this.ConfigDoc.SelectSingleNode("//Setting//"+this.Name));
                }

                //新建控件节点
                XmlNode controlNode = this.ConfigDoc.CreateNode(XmlNodeType.Element, this.Name, this.ConfigDoc.NamespaceURI);

                //填写控件节点
                for (int i = 0; i < this.chklsSetColumn.Items.Count; i++)
                {
                    XmlNode columnNode = this.ConfigDoc.CreateNode(XmlNodeType.Element, "Column", this.ConfigDoc.NamespaceURI);

                    XmlAttribute name = this.ConfigDoc.CreateAttribute("name");
                    name.Value = this.chklsSetColumn.Items[i].ToString();

                    XmlAttribute index = this.ConfigDoc.CreateAttribute("index");
                    index.Value = i.ToString();

                    XmlAttribute show = this.ConfigDoc.CreateAttribute("show");
                    if (this.chklsSetColumn.GetItemChecked(i))
                    {
                        show.Value = "true";

                        //添加显示列
                        this.showColumns.Add(i);
                    }
                    else
                    {
                        show.Value = "false";
                    }

                    columnNode.Attributes.Append(name);
                    columnNode.Attributes.Append(index);
                    columnNode.Attributes.Append(show);

                    controlNode.AppendChild(columnNode);
                }

                //将控件节点添加到根节点
                setNode.AppendChild(controlNode);

                try
                {
                    this.ConfigDoc.Save(this.configFileName);
                    this.FindForm().DialogResult = DialogResult.OK;
                    this.FindForm().Close();
                }
                catch
                {
                    MessageBox.Show("保存配置文件出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("诊断录入项不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 取消修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        /// <summary>
        /// 选项上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.chklsSetColumn.SelectedItem != null)
            {
                if (this.chklsSetColumn.SelectedIndex != 0)
                {
                    System.Object selObj = this.chklsSetColumn.SelectedItem;
                    int selIndex=this.chklsSetColumn.SelectedIndex;
                    this.chklsSetColumn.Items.Remove(selObj);
                    this.chklsSetColumn.Items.Insert(selIndex - 1, selObj);
                    this.chklsSetColumn.SetSelected(selIndex - 1, true);
                    this.chklsSetColumn.SetItemChecked(selIndex - 1, true);
                }
            }
            else
            {
                MessageBox.Show("您还没有选择项目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 选项下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.chklsSetColumn.SelectedItem != null)
            {
                if (this.chklsSetColumn.SelectedIndex != this.chklsSetColumn.Items.Count - 1)
                {
                    System.Object selObj = this.chklsSetColumn.SelectedItem;
                    int selIndex=this.chklsSetColumn.SelectedIndex;
                    this.chklsSetColumn.Items.Remove(selObj);
                    this.chklsSetColumn.Items.Insert(selIndex + 1, selObj);
                    this.chklsSetColumn.SetSelected(selIndex + 1, true);
                    this.chklsSetColumn.SetItemChecked(selIndex + 1, true);
                }
            }
            else
            {
                MessageBox.Show("您还没有选择项目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        /// <summary>
        /// 读取配置文件，设置选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSetColumnForDiagnose_Load(object sender, EventArgs e)
        {
            //获取配置文件
            if(System.IO.File.Exists(this.configFileName))
            {
                try
                {
                    this.ConfigDoc.Load(this.configFileName);
                }
                catch(Exception err)
                {
                    MessageBox.Show("输入诊断配置文件有错误","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("输入诊断配置文件不存在","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return ;
            }

            //获取全部列
            for (int i = 0; i < this.allColumns.Count; i++)
            {
                this.chklsSetColumn.Items.Add(this.allColumns[i]);
            }

            //获取显示列
            for(int i=0;i<this.showColumns.Count;i++)
            {
                int selIndex=(int)this.showColumns[i];
                this.chklsSetColumn.SetItemChecked(selIndex,true);
            }
        }
    }
}
