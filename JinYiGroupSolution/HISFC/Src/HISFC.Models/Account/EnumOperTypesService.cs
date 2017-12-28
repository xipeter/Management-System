using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.Models.Account
{
    
    [Serializable]
    public class EnumOperTypesService : Neusoft.HISFC.Models.Base.EnumServiceBase
    {
        public EnumOperTypesService() 
        {
            this.Items[OperTypes.PrePay] = "预交金";
            this.Items[OperTypes.NewAccount] = "新建帐户";
            this.Items[OperTypes.StopAccount] = "停帐户";
            this.Items[OperTypes.AginAccount] = "重启帐户";
            this.Items[OperTypes.Pay] = "帐户支付";
            this.Items[OperTypes.CancelPay] = "退费入户";
            this.Items[OperTypes.CancelAccount] = "注销帐户";
            this.Items[OperTypes.EmpowerPay] = "授权支付";
            this.Items[OperTypes.CancelPrePay] = "退预交金";
            this.Items[OperTypes.EditPassWord] = "修改密码";
            this.Items[OperTypes.BalanceVacancy] = "结清余额";
            this.Items[OperTypes.Empower] = "授权";
            this.Items[OperTypes.CancelEmpower] = "取消授权";
            this.Items[OperTypes.EmpowerCancelPay] = "授权退费入户";
            this.Items[OperTypes.EditEmpowerInfo] = "修改授权信息";
            this.Items[OperTypes.RevertEmpower] = "恢复授权";
        }

        #region 变量
        /// <summary>
        /// 操作类别
        /// </summary>
        OperTypes operTypes;
        /// <summary>
        /// 存储枚举
        /// </summary>
        protected static Hashtable items = new Hashtable();
        #endregion

        #region 属性
        /// <summary>
        /// 存贮枚举
        /// </summary>
        protected override Hashtable Items
        {
            get 
            { 
                return items; 
            }
        }
        /// <summary>
        /// 枚举项目
        /// </summary>
        protected override System.Enum EnumItem
        {
            get 
            {
                return operTypes; 
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 得到枚举的NeuObject数组
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
        #endregion  

      
    }
    #region 操作类型枚举
    /// <summary>
    /// 操作类型0预交金1建帐户2停帐户3重启帐户4支付5退费入户
    /// </summary>
    public enum OperTypes
    {
        /// <summary>
        /// 预交金
        /// </summary>
        PrePay = 0,
        /// <summary>
        /// 新建帐户
        /// </summary>
        NewAccount=1,
        /// <summary>
        /// 停帐户
        /// </summary>
        StopAccount=2,
        /// <summary>
        /// 重启帐户
        /// </summary>
        AginAccount=3,
        /// <summary>
        /// 支付
        /// </summary>
        Pay=4,
        /// <summary>
        /// 退费入户
        /// </summary>
        CancelPay=5,
        /// <summary>
        /// 注销帐户
        /// </summary>
        CancelAccount=6,
        /// <summary>
        /// 授权支付
        /// </summary>
        EmpowerPay=7,
        /// <summary>
        /// 退预交金
        /// </summary>
        CancelPrePay=8,
        /// <summary>
        /// 修改密码
        /// </summary>
        EditPassWord=9,
        /// <summary>
        /// 结清余额
        /// </summary>
        BalanceVacancy=10,
        /// <summary>
        /// 授权
        /// </summary>
        Empower=11,
        /// <summary>
        /// 取消授权
        /// </summary>
        CancelEmpower=12,
        /// <summary>
        /// 授权退费入户
        /// </summary>
        EmpowerCancelPay = 13,
        /// <summary>
        /// 修改授权信息
        /// </summary>
        EditEmpowerInfo=14,
        /// <summary>
        /// 恢复授权
        /// </summary>
        RevertEmpower = 15
    };
    #endregion
}
