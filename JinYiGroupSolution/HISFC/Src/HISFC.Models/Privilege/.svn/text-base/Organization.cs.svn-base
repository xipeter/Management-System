using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;


namespace Neusoft.HISFC.Models.Privilege
{

    public class Organization :Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
        /// 基类中的name表示科室名称
        /// </summary>
        public new String Name
        {
            get { return this.department.Name; }
            set { this.department.Name = value; }
        }

        private NeuObject department = new NeuObject();
        /// <summary>
        /// 科室
        /// </summary>
        public NeuObject Department
        {
            get { return department; }
            set { department = value; }
        }

        private String type;
        /// <summary>
        /// 组织结构分类
        /// </summary>
        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        private Organization parent;
        /// <summary>
        /// 父级节点
        /// </summary>
        public Organization Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        private int level;
        /// <summary>
        /// 节点的深度（从零开始）
        /// </summary>
        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        private bool hasChildren;
        /// <summary>
        /// 是否有子节点
        /// </summary>
        public bool HasChildren
        {
            get
            {
                return hasChildren;
            }
            set
            {
                hasChildren = value;
            }
        }

        private int orderNumber;
        /// <summary>
        /// 在同一父级节点下的排列顺序
        /// </summary>
        public int OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        List<Organization> organizations;
        /// <summary>
        /// 子节点集合
        /// </summary>
        public List<Organization> Organizations
        {
            get { return organizations; }
            set { organizations = value; }
        }

        public string AppId
        {
            get { return "HIS"; }
            set { }
        }

        public string ParentId
        {
            get
            {
                if (parent == null)
                {
                    return null;
                }
                else
                {
                    return this.parent.ID;

                }

            }
        }
    }
}

