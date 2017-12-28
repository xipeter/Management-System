using System;
using System.Windows.Forms;
namespace Neusoft.FrameWork.WinForms.Forms
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
    public class ToolBarService
    {
        public ToolBarService()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        protected System.Collections.ArrayList toolButtons = new System.Collections.ArrayList();
        
        /// <summary>
        /// 添加ToolButton
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tooltip"></param>
        /// <param name="imageIndex"></param>
        /// <param name="e"></param>
        public void AddToolButton(string text, string tooltip, int imageIndex, bool enabled, bool isChecked, System.EventHandler e)
        {
            ToolStripButton tb = new ToolStripButton(text);
            tb.Tag = e;
            tb.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage((Neusoft.FrameWork.WinForms.Classes.EnumImageList)imageIndex);
            tb.Enabled = enabled;
            tb.Checked = isChecked;         //Robin Add
            //{1B10BCB7-8133-4282-8479-9C41FE5A23FD}  区域语言转换
            tb.ToolTipText = Neusoft.FrameWork.Management.Language.Msg( tooltip );

            tb.ImageScaling = ToolStripItemImageScaling.SizeToFit;   //Robin AddSizeToFit
            this.toolButtons.Add(tb);

        }

        /// <summary>
        /// 添加ToolButton
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tooltip"></param>
        /// <param name="imageIndex"></param>
        /// <param name="enabled"></param>
        /// <param name="isChecked"></param>
        /// <param name="e"></param>
        /// Robin   2007-01-05 
        public void AddToolButton(string text, string tooltip, Neusoft.FrameWork.WinForms.Classes.EnumImageList imageIndex, bool enabled, bool isChecked, System.EventHandler e)
        {
            ToolStripButton tb = new ToolStripButton(text);
            tb.Tag = e;
            tb.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(imageIndex);
            tb.Enabled = enabled;
            tb.Checked = isChecked;         //Robin Add
            //{1B10BCB7-8133-4282-8479-9C41FE5A23FD}  区域语言转换
            tb.ToolTipText = Neusoft.FrameWork.Management.Language.Msg( tooltip );
            tb.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            this.toolButtons.Add(tb);

        }

        /// <summary>
        /// 添加默认ToolButton
        /// 
        /// {BA871A23-D5AB-42c8-9C8A-B19339B991FC}
        /// </summary>
        /// <param name="defaultButton">默认Button</param>
        public void AddToolButton(ToolStripButton defaultButton)
        {
            this.toolButtons.Add( defaultButton );
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
            foreach (ToolStripButton tb in this.toolButtons)
            {
                //去掉ToolButton中的快捷键
                if (GetToolButtonText(tb.Text) == text)
                    tb.Enabled = enabled;

            }
        }
        /// <summary>
        /// 去掉ToolButton中的快捷键以及多语言转换
        /// </summary>
        /// <param name="text">当前button的菜单名称</param>
        /// <returns>去掉快捷键后的名称</returns>
        private string GetToolButtonText(string text)
        {
            //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 转换多语言
            string originalStr = text;

            int index = text.IndexOf('(');
            if (index < 0)
            {
                originalStr = text;
            }
            else
            {
                originalStr = text.Substring( 0, index );
            }

            //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 转换多语言
            if (ToolBarButtonService.TranslateTextDictionary.ContainsKey( originalStr ) == true)
            {
                originalStr = ToolBarButtonService.TranslateTextDictionary[originalStr];
            }

            return originalStr;
        }

        /// <summary>
        /// 获得所有ToolButton
        /// </summary>
        /// <returns></returns>
        public System.Collections.ArrayList GetToolButtons()
        {
            
            return this.toolButtons;
        }

        public System.Windows.Forms.ToolStripButton GetToolButton(string text)
        {
            foreach (ToolStripButton tb in this.toolButtons)
            {
                //去掉快捷键
                if (GetToolButtonText(tb.Text) == text)
                    return tb;

            }
            return null;
        }

        protected bool IsHaveButton(string text)
        {
            return false;
        }

        /// <summary>
        /// 增加分隔符
        /// </summary>
        public void AddToolSeparator()
        {
            ToolStripSeparator _sp = new ToolStripSeparator();
            this.toolButtons.Add(_sp);
        }
    }
}
