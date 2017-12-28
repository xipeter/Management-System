using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Neusoft.HISFC.Components.InpatientFee.Register
{
    public partial class frmModifyUserKeys : Form
    {
        public frmModifyUserKeys()
        {
            InitializeComponent();
        }

        #region 变量
        
        /// <summary>
        /// 设置路径
        /// </summary>
        public string filePath = Application.StartupPath  + @".\" + Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\InpatientShotcut.xml";

        #endregion

        #region 方法

        /// <summary>
        /// 刷新哈希表信息
        /// </summary>
        public void RefreshHashCode()
        {
            int row = this.fpSpead1_Sheet1.ActiveRowIndex;
            int col = this.fpSpead1_Sheet1.ActiveColumnIndex;
            if (this.fpSpead1_Sheet1.RowCount <= 0)
            {
                return;
            }
            int finHashCode = 0; int groupHashCode = 0; int useHashCode = 0;
            if (this.fpSpead1_Sheet1.Cells[row, 2].Text != string.Empty)//组合键为空
            {
                groupHashCode = Convert.ToInt32(this.fpSpead1_Sheet1.Cells[row, 2].Tag.ToString());
            }
            if (this.fpSpead1_Sheet1.Cells[row, 3].Text == string.Empty)//功能键为空
            {
                this.fpSpead1_Sheet1.Cells[row, 4].Text = string.Empty;
                return;
            }
            else
            {
                useHashCode = Convert.ToInt32(this.fpSpead1_Sheet1.Cells[row, 3].Tag.ToString());
            }
            finHashCode = groupHashCode + useHashCode;

            this.fpSpead1_Sheet1.Cells[row, 4].Text = finHashCode.ToString();
        }
        /// <summary>
        /// 验证录入是否合法
        /// </summary>
        /// <param name="beginRow">开始验证的行数</param>
        /// <returns>false不合法 true合法</returns>
        public bool IsValid(int beginRow)
        {
            if (beginRow >= this.fpSpead1_Sheet1.RowCount)
            {
                return true;
            }
            string tmpHashCode = this.fpSpead1_Sheet1.Cells[beginRow, 4].Text;
            string tempFunName = this.fpSpead1_Sheet1.Cells[beginRow, 5].Text;
            for (int i = beginRow + 1; i < this.fpSpead1_Sheet1.RowCount; i++)
            {
                string currHashCode = this.fpSpead1_Sheet1.Cells[i, 4].Text;
                string currFunName = this.fpSpead1_Sheet1.Cells[i, 5].Text;
                if (currFunName != string.Empty && currHashCode != string.Empty )
                {
                    if (currHashCode == tmpHashCode && tempFunName == currFunName)
                    {
                        return false;
                    }
                }
            }
            if (this.IsValid(beginRow + 1) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 创建和更新配置文件
        /// </summary>
        /// <param name="filePath">配置文件路径</param>
        /// <returns>false创建失败 true创建成功</returns>
        public bool CreateXml(string filePath)
        {
            Neusoft.FrameWork.Xml.XML myXml = new Neusoft.FrameWork.Xml.XML();
            XmlDocument doc = new XmlDocument();
            XmlElement root;
            root = myXml.CreateRootElement(doc, "Setting", "1.0");
            string tempWindowName = this.fpSpead1_Sheet1.Cells[0, 5].Text;
            string currWindowName = string.Empty;
            XmlElement secondNode = null;
            for (int i = 0; i < this.fpSpead1_Sheet1.RowCount; i++)
            {
                currWindowName = this.fpSpead1_Sheet1.Cells[i, 5].Text;
                if (i == 0 ) 
                {
                    secondNode = myXml.AddXmlNode(doc, root, tempWindowName, string.Empty);
                }
                else if (tempWindowName != currWindowName)
                {
                    secondNode = myXml.AddXmlNode(doc, root, currWindowName, string.Empty);
                }

                XmlElement e = myXml.AddXmlNode(doc, secondNode, "Column", string.Empty);
                myXml.AddNodeAttibute(e, "opCode", this.fpSpead1_Sheet1.Cells[i, 0].Text);
                myXml.AddNodeAttibute(e, "opName", this.fpSpead1_Sheet1.Cells[i, 1].Text);
                myXml.AddNodeAttibute(e, "opKey", this.fpSpead1_Sheet1.Cells[i, 2].Text);
                string opKeyHash = string.Empty, cuKeyHash = string.Empty;
                if (this.fpSpead1_Sheet1.Cells[i, 2].Text != string.Empty)
                {
                    opKeyHash = this.fpSpead1_Sheet1.Cells[i, 2].Tag.ToString();
                }
                myXml.AddNodeAttibute(e, "opKeyHash", opKeyHash);
                myXml.AddNodeAttibute(e, "cuKey", this.fpSpead1_Sheet1.Cells[i, 3].Text);
                if (this.fpSpead1_Sheet1.Cells[i, 3].Text != string.Empty)
                {
                    cuKeyHash = this.fpSpead1_Sheet1.Cells[i, 3].Tag.ToString();
                }
                myXml.AddNodeAttibute(e, "cuKeyHash", cuKeyHash);
                myXml.AddNodeAttibute(e, "hash", this.fpSpead1_Sheet1.Cells[i, 4].Text);

                tempWindowName = currWindowName;
            }
            try
            {
                StreamWriter sr = new StreamWriter(filePath, false, System.Text.Encoding.Default);
                string cleandown = doc.OuterXml;
                sr.Write(cleandown);
                sr.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("无法保存！" + ex.Message); 
            }

            return true;
        }
        /// <summary>
        /// 根据功能代码查找行
        /// </summary>
        /// <param name="opCode">功能代码</param>
        /// <returns>-1没有找到 其他为找到的航数</returns>
        public int FindRow(string opCode)
        {
            for (int i = 0; i < this.fpSpead1_Sheet1.RowCount; i++)
            {
                string tmpCode = this.fpSpead1_Sheet1.Cells[i, 0].Text;
                if (tmpCode == opCode)
                {
                    return i;
                }
            }

            return -1;
        }
        /// <summary>
        /// 读取XML信息
        /// </summary>
        /// <param name="filePath"></param>
        public void ReadFromXml(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            if (filePath == string.Empty) return;
            try
            {
                StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default);
                string cleandown = sr.ReadToEnd();
                doc.LoadXml(cleandown);
                sr.Close();
            }
            catch 
            { 
                return; 
            }
            XmlNodeList nodes = doc.SelectNodes("//Column");
            foreach (XmlNode node in nodes)
            {

                string opCode = node.Attributes["opCode"].Value;
                int findRow = FindRow(opCode);
                if (findRow < 0)
                {
                    continue;
                }
                this.fpSpead1_Sheet1.Cells[findRow, 2].Text = node.Attributes["opKey"].Value;
                this.fpSpead1_Sheet1.Cells[findRow, 3].Text = node.Attributes["cuKey"].Value;
                this.fpSpead1_Sheet1.Cells[findRow, 2].Tag = node.Attributes["opKeyHash"].Value;
                this.fpSpead1_Sheet1.Cells[findRow, 3].Tag = node.Attributes["cuKeyHash"].Value;
                this.fpSpead1_Sheet1.Cells[findRow, 4].Text = node.Attributes["hash"].Value;

            }
        }

        /// <summary>
        /// 根据文件路径和按键HashCode查找当前值
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="hashCode">按键HashCode</param>
        /// <returns>成功 当前值 失败 string.Empty</returns>
        public string Operation(string filePath, string hashCode)
        {
            XmlDocument doc = new XmlDocument();
            if (filePath == string.Empty) return string.Empty;
            try
            {
                StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default);
                string cleandown = sr.ReadToEnd();
                doc.LoadXml(cleandown);
                sr.Close();
            }
            catch { return string.Empty; }
            XmlNodeList nodes = doc.SelectNodes("//Column");
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["hash"].Value == hashCode)
                {
                    return node.Attributes["opCode"].Value;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 保存值
        /// </summary>
        /// <param name="code">当前值</param>
        /// <returns>成功1 失败 -1</returns>
        public int OperationExe(string code)
        {
            switch (code)
            {
                case "1":
                    MessageBox.Show("Save");
                    break;
                case "2":
                    MessageBox.Show("划价保存!");
                    break;
                case "3":
                    MessageBox.Show("增加");
                    break;
            }

            return 1;
        }

        #endregion

        #region 事件

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bReturn = IsValid(0);
            if (!bReturn)
            {
                MessageBox.Show("快捷键设置不能重复!");
                return;
            }
            bReturn = CreateXml(filePath);
            if (!bReturn)
            {
                MessageBox.Show("保存失败!");
                return;
            }
            else
            {
                MessageBox.Show("保存成功!");
            }
        }

        private void fpSpead1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int row = this.fpSpead1_Sheet1.ActiveRowIndex;
            int col = this.fpSpead1_Sheet1.ActiveColumnIndex;
            if (this.fpSpead1_Sheet1.RowCount <= 0)
            {
                return;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (col <= 1)
                {
                    return;
                }
                this.fpSpead1_Sheet1.SetValue(row, col, string.Empty);
                this.fpSpead1_Sheet1.Cells[row, col].Tag = null;

                RefreshHashCode();

                return;

            }
            if (e.KeyCode != Keys.LButton)
            {
                if (col <= 1 || col == 4)
                {
                    return;
                }
                if (col == 2)
                {
                    if (e.KeyCode == Keys.ControlKey)
                    {
                        this.fpSpead1_Sheet1.SetValue(row, col, Keys.Control.ToString());
                        this.fpSpead1_Sheet1.Cells[row, col].Tag = Keys.Control.GetHashCode();
                    }
                }
                else
                {
                    this.fpSpead1_Sheet1.SetValue(row, col, e.KeyCode.ToString());
                    this.fpSpead1_Sheet1.Cells[row, col].Tag = e.KeyCode.GetHashCode();
                }

                RefreshHashCode();
            }
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmModifyUserKeys_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.ReadFromXml(this.filePath);
            }
            catch { }
        }

        #endregion
    }
}