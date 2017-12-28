using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;


namespace Neusoft.HISFC.BizLogic.Privilege.Model
{
    /// <summary>
    /// 菜单项
    /// </summary>
    [Serializable]
    public class MenuItem : NeuObject
    {
        private string _id;
        private string _name;
        private string _parentId;
        private string _shortcut;
        private string _icon;
        private string _dllName;
        private string _winName;
        private string _controlType;
        private string _showType;
        private string _param;
        private string _layer;
        private string _tooltip;
        private bool _enabled;
        private string _userId;
        private DateTime _operDate;
        private string _type;
        private int _order;
        private string _desc;
        private string _treeDllName;

        /// <summary>
        /// 树型控件所在dll
        /// </summary>
        public string TreeDllName
        {
            get { return _treeDllName; }
            set { _treeDllName = value; }
        }

        private string _treeName;

        /// <summary>
        /// 树型控件名称
        /// </summary>
        public string TreeName
        {
            get { return _treeName; }
            set { _treeName = value; }
        }

        #region IResource 成员

        /// <summary>
        /// 菜单项Id
        /// </summary>
        
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// 菜单项名称
        /// </summary>
        
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// 菜单项父级Id
        /// </summary>
        
        public string ParentId
        {
            get
            {
                return _parentId;
            }
            set
            {
                _parentId = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }
        #endregion

        /// <summary>
        /// 菜单项快捷键
        /// </summary>
        
        public string Shortcut
        {
            get
            {
                return _shortcut;
            }
            set
            {
                _shortcut = value;
            }
        }

        /// <summary>
        /// 菜单项图标
        /// </summary>
        
        public string Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
            }
        }

        /// <summary>
        /// 调用控件所在Dll名称
        /// </summary>
        
        public string DllName
        {
            get
            {
                return _dllName;
            }
            set
            {
                _dllName = value;
            }
        }

        /// <summary>
        /// 调用控件名称
        /// </summary>
        
        public string WinName
        {
            get
            {
                return _winName;
            }
            set
            {
                _winName = value;
            }
        }

        /// <summary>
        /// 控件类型
        /// </summary>
        
        public string ControlType
        {
            get
            {
                return _controlType;
            }
            set
            {
                _controlType = value;
            }
        }

        /// <summary>
        /// 控件显示类型
        /// </summary>
        
        public string ShowType
        {
            get
            {
                return _showType;
            }
            set
            {
                _showType = value;
            }
        }

        /// <summary>
        /// 传入控件参数
        /// </summary>
        
        public string Param
        {
            get
            {
                return _param;
            }
            set
            {
                _param = value;
            }
        }

        /// <summary>
        /// 菜单项所在层数
        /// </summary>
        
        public string Layer
        {
            get
            {
                return _layer;
            }
            set
            {
                _layer = value;
            }
        }

        /// <summary>
        /// 工具提示
        /// </summary>
        
        public string Tooltip
        {
            get
            {
                return _tooltip;
            }
            set
            {
                _tooltip = value;
            }
        }

        /// <summary>
        /// 是否可用
        /// </summary>
        
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        /// <summary>
        /// 操作用户代码
        /// </summary>
        
        public string UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId= value;
            }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        
        public DateTime OperDate
        {
            get
            {
                return _operDate;
            }
            set
            {
                _operDate = value;
            }
        }

        /// <summary>
        /// 资源类型
        /// </summary>
        
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        /// <summary>
        /// 显示顺序
        /// </summary>
        
        public int Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
            }
        }

        /// <summary>
        /// 菜单克隆
        /// </summary>
        /// <returns></returns>
        public new MenuItem Clone()
        {
            MenuItem obj = base.MemberwiseClone() as MenuItem;
            return obj;
        }
    }
}
