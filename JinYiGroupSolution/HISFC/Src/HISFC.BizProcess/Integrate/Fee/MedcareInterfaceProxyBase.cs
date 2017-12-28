using System;
using System.Collections.Generic;
using System.Reflection;
using Neusoft.HISFC.BizProcess.Interface.FeeInterface;

namespace Neusoft.HISFC.BizProcess.Integrate.FeeInterface
{
    public abstract class MedcareInterfaceProxyBase
    {
        #region 变量

        /// <summary>
        /// 医保接口实例
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare medcaredInterface = null;

        /// <summary>
        /// 本地数据库事务
        /// </summary>
        protected Neusoft.FrameWork.Management.Transaction trans = null;
        
        /// <summary>
        /// 错误信息
        /// </summary>
        protected string errMsg = string.Empty;

        /// <summary>
        /// 调用的医保接口实例
        /// </summary>
        protected object objInterface = null;//调用接口实例

        /// <summary>
        /// 合同单位编码
        /// </summary>
        protected string pactCode = null;//合同单位编码

        #endregion

        #region 属性

        /// <summary>
        /// 合同单位编码
        /// </summary>
        public string PactCode
        {
            set
            {
                string tmpPactCode = value;
                //如果新赋值的合同单位编码不等于原来的合同单位编码
                //说明患者的医保接口可能发生编码,把接口实例清空,下面的业务会重新反射
                //对应的医保接口实例
                if (tmpPactCode != this.pactCode)
                {
                    this.objInterface = null;
                }

                pactCode = tmpPactCode;
            }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg
        {
            get
            {
                return errMsg;
            }
        }

        /// <summary>
        /// 本地数据库事务
        /// </summary>
        public Neusoft.FrameWork.Management.Transaction Trans
        {
            set
            {
                this.trans = value;
                try
                {
                    if (objInterface == null)
                    {
                        //如果当前的实例为null,重新获得医保对象实例
                        objInterface = this.GetInterfaceFromPact(pactCode);
                        if (objInterface == null)
                        {
                            return;
                        }
                    }
                    //((FeeInterface.IMedcare)objInterface).SetTrans(trans);
                }
                catch (Exception e)
                {
                    this.errMsg = e.Message;

                    return;
                }
            }
        }

        #endregion

        #region 方法


        /// <summary>
        /// 设置本地数据库连接
        /// </summary>
        /// <param name="t">当前数据库连接</param>
        public void SetTrans(Neusoft.FrameWork.Management.Transaction t)
        {
            this.trans = t;
            try
            {
                if (objInterface == null)
                {
                    //如果当前的实例为null,重新获得医保对象实例
                    objInterface = this.GetInterfaceFromPact(pactCode);
                    if (objInterface == null)
                    {
                        return;
                    }
                }
                //((FeeInterface.IMedcare)objInterface).SetTrans(t);
            }
            catch (Exception e)
            {
                this.errMsg = e.Message;

                return;
            }
        }

        /// <summary>
        /// 获得错误信息
        /// </summary>
        /// <returns>错误信息</returns>
        public string GetErrMsg()
        {
            return this.errMsg;
        }

        /// <summary>
        /// 设置合同单位编码
        /// </summary>
        /// <param name="pactCode">合同单位编码</param>
        public void SetPactCode(string pactCode)
        {
            if (pactCode != this.pactCode)
            {
                this.objInterface = null;
            }

            this.pactCode = pactCode;
        }

        /// <summary>
        /// 通过合同单位编码获得
        /// </summary>
        /// <param name="pactCode">合同单位编码</param>
        /// <returns>成功: 医保接口实例 失败: null</returns>
        public Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare GetInterfaceFromPact(string pactCode)
        {

            Neusoft.FrameWork.Management.ControlParam myCtrl = new Neusoft.FrameWork.Management.ControlParam();
            //Trans为全局量 不需要单独SetTrans
            //if (this.trans != null)
            //{
            //    myCtrl.SetTrans(trans.Trans);
            //}
            Neusoft.HISFC.Models.Base.ControlParam con = myCtrl.QueryControlInfoByName(pactCode);
            if (con == null)
            {
                this.errMsg = "获得调用接口处错!" + myCtrl.Err;

                return null;
            }

            try
            {
                Assembly a = Assembly.LoadFrom(con.ControlerValue);
                System.Type[] types = a.GetTypes();
                foreach (System.Type type in types)
                {
                    if (type.GetInterface("IMedcare") != null)
                    {
                        objInterface = System.Activator.CreateInstance(type);
                    }
                }
            }
            catch (Exception e)
            {
                this.errMsg = e.Message;

                return null;
            }

            return (Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare)objInterface;
        }

        #region 数据库事务

        /// <summary>
        /// 数据库提交
        /// </summary>
        /// <returns>false失败 ture成功</returns>
        public bool Commit()
        {
            if (this.pactCode == null)
            {
                this.errMsg = "合同单位没有付值";

                return false;
            }

            return this.Commit(this.pactCode);
        }

        /// <summary>
        /// 数据库回滚
        /// </summary>
        /// <returns>false失败 ture成功</returns>
        public bool Rollback()
        {
            if (this.pactCode == null)
            {
                this.errMsg = "合同单位没有付值";

                return false;
            }

            return this.Rollback(this.pactCode);
        }

        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <returns>false失败 ture成功</returns>
        public bool Connect()
        {
            if (this.pactCode == null)
            {
                this.errMsg = "合同单位没有付值";

                return false;
            }

            return this.Connect(this.pactCode);
        }

        /// <summary>
        /// 断开数据库连接
        /// </summary>
        /// <returns>false失败 ture成功</returns>
        public bool Disconnect()
        {
            if (this.pactCode == null)
            {
                this.errMsg = "合同单位没有付值";

                return false;
            }

            return this.Disconnect(this.pactCode);
        }

        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <param name="pactCode">合同单位</param>
        /// <returns>false失败 ture成功</returns>
        public bool Connect(string pactCode)
        {
            if (pactCode != this.pactCode)
            {
                objInterface = null;
            }
            try
            {
                if (objInterface == null)
                {
                    objInterface = this.GetInterfaceFromPact(pactCode);
                    if (objInterface == null)
                    {
                        return false;
                    }
                }
                
                long lReturn = ((Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare)objInterface).Connect();
                
                if (lReturn < 0)
                {
                    this.errMsg = ((Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare)objInterface).ErrMsg;

                    return false;
                }
            }
            catch (Exception e)
            {
                this.errMsg = e.Message;

                return false;
            }

            return true;
        }

        /// <summary>
        /// 数据库提交
        /// </summary>
        /// <param name="pactCode">合同单位</param>
        /// <returns>false失败 ture成功</returns>
        public bool Commit(string pactCode)
        {
            try
            {
                if (objInterface == null)
                {
                    objInterface = this.GetInterfaceFromPact(pactCode);
                    if (objInterface == null)
                    {
                        return false;
                    }
                }

                long lReturn = ((Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare)objInterface).Commit();
                
                if (lReturn < 0)
                {
                    this.errMsg = ((Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare)objInterface).ErrMsg;

                    return false;
                }
            }
            catch (Exception e)
            {
                this.errMsg = e.Message;

                return false;
            }

            return true;
        }

        /// <summary>
        /// 数据库回滚
        /// </summary>
        /// <param name="pactCode">合同单位</param>
        /// <returns>false失败 ture成功</returns>
        public bool Rollback(string pactCode)
        {
            try
            {
                if (objInterface == null)
                {
                    objInterface = this.GetInterfaceFromPact(pactCode);

                    if (objInterface == null)
                    {
                        return false;
                    }
                }
                long lReturn = ((Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare)objInterface).Rollback();

                if (lReturn < 0)
                {
                    this.errMsg = ((Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare)objInterface).ErrMsg;

                    return false;
                }
            }
            catch (Exception e)
            {
                this.errMsg = e.Message;

                return false;
            }

            return true;
        }

        /// <summary>
        /// 断开数据库连接
        /// </summary>
        /// <param name="pactCode">合同单位编码</param>
        /// <returns>false失败 ture成功</returns>
        public bool Disconnect(string pactCode)
        {
            try
            {
                if (objInterface == null)
                {
                    objInterface = this.GetInterfaceFromPact(pactCode);
                    if (objInterface == null)
                    {
                        return false;
                    }
                }

                long lReturn = ((Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare)objInterface).Disconnect();

                if (lReturn < 0)
                {
                    this.errMsg = ((Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMedcare)objInterface).ErrMsg;

                    return false;
                }
            }
            catch (Exception e)
            {
                this.errMsg = e.Message;

                return false;
            }
            return true;
        }

        /// <summary>
        /// 开始一个新事务
        /// </summary>
        /// <returns>成功 true 失败false</returns>
        public bool BeginTranscation()
        {
            if (this.pactCode == null)
            {
                this.errMsg = "合同单位没有付值";

                return false;
            }
            return this.BeginTranscation(this.pactCode);
        }

        /// <summary>
        /// 开始一个新事务
        /// </summary>
        /// <param name="pactCode">合同单位</param>
        /// <returns></returns>
        public bool BeginTranscation(string pactCode)
        {
            try
            {
                if (objInterface == null)
                {
                    objInterface = this.GetInterfaceFromPact(pactCode);
                    if (objInterface == null)
                    {
                        return false;
                    }
                }

                ((IMedcare)objInterface).BeginTranscation();
            }
            catch (Exception e)
            {
                this.errMsg = e.Message;

                return false;
            }

            return true;
        }

        #endregion

        #endregion
    }
}
