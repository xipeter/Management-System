using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Medical
{
    /// <summary>
    /// 医务排班权限类
    /// </summary>
    [Serializable]
    public class AttendPermission:Neusoft.FrameWork.Models.NeuObject
    {
        #region 变量

        /// <summary>
        /// 排班人员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject permissionOper = null;

        /// <summary>
        /// 排班大类
        /// </summary>
        private string attendType="";

        /// <summary>
        /// 权限排班科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject attendDept = null;

        /// <summary>
        /// 权限排班人员职务
        /// </summary>
        private Base.EmployeeTypeEnumService attendPersonType = null;

        /// <summary>
        /// 操作环境
        /// </summary>
        private Base.OperEnvironment oper = null;

        #endregion

        #region 属性

        /// <summary>
        /// 排班人员
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject PermissionOper
        {
            get
            {
                if(this.permissionOper==null)
                {
                    this.permissionOper = new Neusoft.FrameWork.Models.NeuObject();
                }
                return this.permissionOper;
            }
            set
            {
                this.permissionOper = value;
            }
        }

        /// <summary>
        /// 排班大类
        /// </summary>
        public string AttendType
        {
            get
            {
                return this.attendType;
            }
            set
            {
                this.attendType = value;
            }
        }

        /// <summary>
        /// 权限排班科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject AttendDept
        {
            get
            {
                if (this.attendDept == null)
                {
                    this.attendDept = new Neusoft.FrameWork.Models.NeuObject();
                }
                return this.attendDept;
            }
            set
            {
                this.attendDept = value;
            }
        }

        /// <summary>
        /// 权限排班人员职务
        /// </summary>
        public Base.EmployeeTypeEnumService AttendPersonType
        {
            get
            {
                if (this.attendPersonType == null)
                {
                    this.attendPersonType = new Neusoft.HISFC.Models.Base.EmployeeTypeEnumService();
                }
                return this.attendPersonType;
            }
            set
            {
                this.attendPersonType = value;
            }
        }

        /// <summary>
        /// 操作环境
        /// </summary>
        public Base.OperEnvironment Oper
        {
            get
            {
                if (this.oper == null)
                {
                    this.oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
                }
                return this.oper;
            }
            set
            {
                this.oper = value;
            }
        }


        #endregion

        #region 方法

        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public new AttendPermission Clone()
        {
            AttendPermission attend = base.Clone() as AttendPermission;

            this.oper = this.Oper.Clone();
            //this.attendPersonType = this.AttendPersonType.Clone();
            this.attendDept = this.attendDept.Clone();
            this.permissionOper = this.PermissionOper.Clone();

            return attend;
        }

        #endregion
    }
}
