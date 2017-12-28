using System;
using System.Collections.Generic;
using System.Text;

namespace HeNanProvinceSI.Object
{
    /// <summary>
    /// [功能描述: 医保接口扩展用的实体类]<br></br>
    /// [创建者:   刘强]<br></br>
    /// [创建时间: 20090212]<br></br>
    /// <说明>
    ///    承载医保的本地化特性
    /// </说明>
    /// <修改记录>
    ///     <修改时间>20090212</修改时间>
    ///     <修改内容>
    ///            完善
    ///     </修改内容>
    /// </修改记录>
    /// </summary>
    public class ExtendProperty : Neusoft.FrameWork.Models.NeuObject
    {
        public ExtendProperty()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 手术一编码
        /// </summary>
        private string operatorCode1 = string.Empty;

        /// <summary>
        /// 手术二编码
        /// </summary>
        private string operatorCode2 = string.Empty;

        /// <summary>
        /// 手术三编码
        /// </summary>
        private string operatorCode3 = string.Empty;

        /// <summary>
        /// 诊断识别码
        /// </summary>
        private string primaryDiagnoseCode = string.Empty;

        /// <summary>
        /// 诊断识别码名称
        /// </summary>
        private string primaryDiagnoseName = string.Empty;

        /// <summary>
        /// 诊断主码
        /// </summary>
        private string mainDiagnoseCode = string.Empty;

        /// <summary>
        /// 诊断主码名称
        /// </summary>
        private string mainDiagnoseName = string.Empty;


        /// <summary>
        /// 诊断主码名称
        /// </summary>
        public string MainDiagnoseName
        {
            get
            {
                return mainDiagnoseName;
            }
            set
            {
                mainDiagnoseName = value;
            }
        }

        /// <summary>
        /// 诊断主码
        /// </summary>
        public string MainDiagnoseCode
        {
            get
            {
                return mainDiagnoseCode;
            }
            set
            {
                mainDiagnoseCode = value;
            }
        }

        /// <summary>
        /// 诊断主码名称
        /// </summary>
        public string PrimaryDiagnoseName
        {
            get
            {
                return primaryDiagnoseName;
            }
            set
            {
                primaryDiagnoseName = value;
            }
        }

        /// <summary>
        ///  手术一编码
        /// </summary>
        public string OperatorCode1
        {
            get
            {
                return operatorCode1;
            }
            set
            {
                operatorCode1 = value;
            }
        }

        /// <summary>
        /// 手术二编码
        /// </summary>
        public string OperatorCode2
        {
            get
            {
                return operatorCode2;
            }
            set
            {
                operatorCode2 = value;
            }
        }

        /// <summary>
        /// 手术三编码
        /// </summary>
        public string OperatorCode3
        {
            get
            {
                return operatorCode3;
            }
            set
            {
                operatorCode3 = value;
            }
        }

        /// <summary>
        /// 诊断主码
        /// </summary>
        public string PrimaryDiagnoseCode
        {
            get
            {
                return primaryDiagnoseCode;
            }
            set
            {
                primaryDiagnoseCode = value;
            }
        }

    }
}
