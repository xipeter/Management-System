using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.WinForms.Classes
{
    /// <summary>
    /// [功能描述: 控制参数实体类]<br></br>
    /// [创 建 者: 张凯钧]<br></br>
    /// [创建时间: 2009-5-5]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class ControlParam : Neusoft.FrameWork.Models.NeuObject
    {
        private string paramValue;
        /// <summary>
        /// 参数值
        /// </summary>
        public String ParamValue
        {
            get
            {
                return paramValue;
            }
            set
            {
                this.paramValue = value;
            }

        }

        private string paramState;
        /// <summary>
        /// 启用标识1启用0不启用
        /// </summary>
        public String ParamState
        {
            get
            {
                return paramState;
            }
            set
            {
                this.paramState = value;
            }

        }


        private string paramKind;
        /// <summary>
        /// 参数所属模块类别
        /// </summary>
        public String ParamKind
        {
            get
            {
                return paramKind;
            }
            set
            {
                this.paramKind = value;
            }

        }


        private string paramControlKind;
        /// <summary>
        /// 使用控件的类型
        /// </summary>
        public String ParamControlKind
        {
            get
            {
                return paramControlKind;
            }
            set
            {
                this.paramControlKind = value;
            }

        }

        private string paramControlValue;
        /// <summary>
        /// 使用控件中的值
        /// </summary>
        public String ParamControlValue
        {
            get
            {
                return paramControlValue;
            }
            set
            {
                this.paramControlValue = value;
            }
        }

        private string oper;
        /// <summary>
        /// 使用控件中的值
        /// </summary>
        public String Oper
        {
            get
            {
                return oper;
            }
            set
            {
                this.oper = value;
            }
        }

        private DateTime operDate;
        /// <summary>
        /// 使用控件中的值
        /// </summary>
        public DateTime OperDate
        {
            get
            {
                return operDate;
            }
            set
            {
                this.operDate = value;
            }
        }
    }
}
