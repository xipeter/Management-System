using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.Common 
{
    /// <summary>
    /// [功能描述: 整合控制参数管理类]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2007-4-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class ControlParam : Integrate.IntegrateBase
    {

        #region 变量

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        protected Neusoft.FrameWork.Management.ControlParam controlParam = new Neusoft.FrameWork.Management.ControlParam();

        #endregion

        /// <summary>
        /// 设置数据库事务
        /// </summary>
        /// <param name="trans"></param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;

            controlParam.SetTrans(this.trans);
            
            base.SetTrans(trans);
        }

        #region 方法

        /// <summary>
        /// 获得控制参数值,如果数据库出错等原因返回输入的T类型 defaultValue
        /// </summary>
        /// <typeparam name="T">获得的参数类型 例如Int</typeparam>
        /// <param name="controlCode">参数编码</param>
        /// <param name="isRefresh">是否重新刷新数据库</param>
        /// <param name="defaultValue">T类型的默认值</param>
        /// <returns>成功 当前T类型参数值 失败 T 类型的传入默认值</returns>
        public T GetControlParam<T>(string controlCode, bool isRefresh, T defaultValue) 
        {
            this.SetDB(controlParam);

            string tempReturnValue = controlParam.QueryControlerInfo(controlCode, isRefresh);

            //如果参数获得错误,默认返回false
            if (tempReturnValue == null || tempReturnValue == "-1")
            {
                return defaultValue;
            }

            T tempValue = default(T);

            switch (Type.GetTypeCode(typeof(T))) 
            {
                case TypeCode.String:
                    tempValue = (T)(object)tempReturnValue;

                    break;
                case TypeCode.Int32:
                    tempValue = (T)(object)Neusoft.FrameWork.Function.NConvert.ToInt32(tempReturnValue);

                    break;
                case TypeCode.Boolean:
                    tempValue = (T)(object)Neusoft.FrameWork.Function.NConvert.ToBoolean(tempReturnValue);

                    break;
                case TypeCode.Decimal:
                    tempValue = (T)(object)Neusoft.FrameWork.Function.NConvert.ToDecimal(tempReturnValue);

                    break;
                case TypeCode.DateTime:
                    tempValue = (T)(object)Neusoft.FrameWork.Function.NConvert.ToDateTime(tempReturnValue);

                    break;
            }

            return tempValue;
        }

        /// <summary>
        /// 获得控制参数值,如果数据库出错等原因返回T类型default(T)
        /// </summary>
        /// <typeparam name="T">获得的参数类型 例如Int</typeparam>
        /// <param name="controlCode">参数编码</param>
        /// <param name="isRefresh">是否重新刷新数据库</param>
        /// <returns>成功 当前T类型参数值 失败 T类型default(T)</returns>
        public T GetControlParam<T>(string controlCode, bool isRefresh)
        {
            return this.GetControlParam<T>(controlCode, isRefresh, default(T));
        }

        /// <summary>
        /// 获得控制参数值(每次都重新刷新数据库),如果数据库出错等原因返回T类型default(T)
        /// </summary>
        /// <typeparam name="T">获得的参数类型 例如Int</typeparam>
        /// <param name="controlCode">参数编码</param>
        /// <returns>成功 当前T类型参数值 失败 T类型default(T)</returns>
        public T GetControlParam<T>(string controlCode)
        {
            return this.GetControlParam<T>(controlCode, true, default(T));
        }

        #endregion
    }
}
