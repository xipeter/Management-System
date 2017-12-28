using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
namespace Neusoft.UFC.Privilege.Common
{
    /// <summary>
    /// [功能描述: 基类窗口用的ToolBar管理类]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class PrivilegelBar
    {
        public PrivilegelBar()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        protected List<ToolStripItem> toolButtons = new List<ToolStripItem>();

        /// <summary>
        /// 添加ToolButton
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tooltip"></param>
        /// <param name="imageIndex"></param>
        /// <param name="e"></param>
        public void AddToolButton(string text, string tooltip, Image image, bool enabled, bool isChecked, System.EventHandler e)
        {

            ToolStripButton tb = new ToolStripButton(text);
            tb.Tag = e;
            tb.Enabled = enabled;
            tb.Checked = isChecked;         //Robin Add
            tb.ToolTipText = tooltip;
            tb.Image = image;
            tb.ImageScaling = ToolStripItemImageScaling.SizeToFit;   //Robin Add
            this.toolButtons.Add(tb);

        }

        /// <summary>
        /// 增加分隔符
        /// </summary>
        public void AddToolSeparator()
        {
            ToolStripSeparator _sp = new ToolStripSeparator();
            this.toolButtons.Add(_sp);
        }

        /// <summary>
        /// 清空ToolButton
        /// </summary>
        public void Clear()
        {
            this.toolButtons.Clear();
        }

        /// <summary>
        /// 设置toolButton按钮可不可用
        /// </summary>
        /// <param name="text"></param>
        /// <param name="enabled"></param>
        public void SetToolButtonEnabled(string text, bool enabled)
        {
            foreach (ToolStripItem _item in this.toolButtons)
            {
                if (_item.GetType() == typeof(ToolStripButton) && _item.Text == text)
                {
                    _item.Enabled = enabled;
                    break;
                }
            }
        }

        /// <summary>
        /// 获得所有ToolButton
        /// </summary>
        /// <returns></returns>
        public IList<ToolStripItem> GetToolButtons()
        {
            return this.toolButtons;
        }

        /// <summary>
        /// 获得所有ToolButton
        /// </summary>
        /// <returns></returns>
        public ToolStripItem[] GetToolStripButtons()
        {
            ToolStripItem[] _collect = new ToolStripItem[toolButtons.Count];

            for (int i = 0; i < toolButtons.Count; i++)
            {
                _collect[i] = toolButtons[i];
            }

            return _collect;
        }
        /// <summary>
        /// 根据名称获取Botton
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public System.Windows.Forms.ToolStripButton GetToolButton(string text)
        {
            foreach (ToolStripItem _item in this.toolButtons)
            {
                if (_item.GetType() == typeof(ToolStripButton) && _item.Text == text)
                    return _item as ToolStripButton;
            }

            return null;
        }
    }
}
