using System;

namespace Neusoft.FrameWork.Models
{
    /// <summary>
    /// NeuManageObject<br></br>
    /// [功能描述: NeuManageObject抽象类，只能用于继承，不能直接实例化]<br></br>
    /// [创 建 者: 李云凡]<br></br>
    /// [创建时间: 2006-08-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
	public abstract class NeuManageObject:NeuObject
	{
		public NeuManageObject()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
        }

        #region 变量
        private string strErr;
		private string strErrCode;
		private int iDBErrCode;
		private int intProgressBarValue=-1;
		private string strProgressBarText;
		private NeuObject myOperator= new NeuObject();

        private NeuObject myHospital = new NeuObject();
        #endregion

        #region 属性

        /// <summary>
        /// 医院信息
        /// </summary>
        public NeuObject Hospital
        {
            get
            {
                return myHospital;
            }
            set
            {
                myHospital = value;
            }
        }

        /// <summary>
		/// 操作员
		/// </summary>
		public NeuObject Operator
		{
			get
			{
				return myOperator;
			}
			set
			{
				myOperator = value;
			}
		}

        /// <summary>
		/// 数据库错误
		/// －1 主键重复
		/// </summary>
		public int DBErrCode
		{
			get
			{
				return this.iDBErrCode;
			}
			set
			{
				this.iDBErrCode=value;
			}
		}

		/// <summary>
		/// 错误信息
		/// </summary>
		public string Err
		{
			get
			{
				return strErr;
			}
			set
			{
				strErr=value;
			}
		}

		/// <summary>
		/// 错误代码
		/// </summary>
		public string ErrCode
		{
			get
			{
				return strErrCode;
			}
			set
			{
				strErrCode=value;
			}
		}

		/// <summary>
		/// 滚动当前值
		/// </summary>
		public int ProgressBarValue
		{
			get
			{
				return intProgressBarValue;
			}
			set
			{
				intProgressBarValue=value;
			}
		}

		/// <summary>
		/// 滚动当前显示
		/// </summary>
		public string ProgressBarText
		{
			get
			{
				return strProgressBarText;
			}
			set
			{
				strProgressBarText=value;
			}
        }
        #endregion

    }
}
