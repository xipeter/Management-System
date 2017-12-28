using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Blood
{
    /// <summary>
    /// [功能描述: 血库申请单组件类]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-5-9]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  /> 
    /// </summary>
    public class BloodApplyMessage : Neusoft.NFC.Object.NeuObject
    {
        public BloodApplyMessage()
        {

        }

        #region 变量

        /// <summary>
        /// 申请科室
        /// </summary>
        private Neusoft.NFC.Object.NeuObject applyDept = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 库存科室(取血科室)
        /// </summary>
        private Neusoft.NFC.Object.NeuObject myBloodDept = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 申请单单分类
        /// </summary>
        private Neusoft.NFC.Object.NeuObject myBloodApplyClass = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 通知发送时间  
        /// </summary>
        private DateTime mySendDtime;

        /// <summary>
        /// 通知发送类型
        /// </summary>
        private int mySendType;

        /// <summary>
        /// 摆药通知标记 0 通知 1 已摆
        /// </summary>
        private int mySendFlag;

        #endregion

        #region

        /// <summary>
        /// 申请科室编码 0-全部部门
        /// </summary>
        public Neusoft.NFC.Object.NeuObject ApplyDept
        {
            get
            {
                return this.applyDept;
            }
            set
            {
                this.applyDept = value;
            }
        }


        /// <summary>
        /// 申请单分类
        /// </summary>
        public Neusoft.NFC.Object.NeuObject MyBloodApplyClass
        {
            get
            {
                return this.myBloodApplyClass;
            }
            set
            {
                this.myBloodApplyClass = value;
            }
        }


        /// <summary>
        /// 发送类型，1-集中发送，0-临时发送
        /// </summary>
        public int SendType
        {
            get
            {
                return this.mySendType;
            }
            set
            {
                this.mySendType = value;
            }
        }


        /// <summary>
        /// 发送通知时间
        /// </summary>
        public System.DateTime SendTime
        {
            get
            {
                return this.mySendDtime;
            }
            set
            {
                this.mySendDtime = value;
            }
        }


        /// <summary>
        /// 取血标记0-通知1-已取
        /// </summary>
        public int SendFlag
        {
            get
            {
                return this.mySendFlag;
            }
            set
            {
                this.mySendFlag = value;
            }
        }


        /// <summary>
        /// 取血科室(库存科室)
        /// </summary>
        public Neusoft.NFC.Object.NeuObject MyBloodDept
        {
            get
            {
                return this.myBloodDept;
            }
            set
            {
                this.myBloodDept = value;
            }
        }

        #endregion

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns>成功返回当前实例副本</returns>
        public new BloodApplyMessage Clone()
        {
            BloodApplyMessage bloodApplyMessage = base.Clone() as BloodApplyMessage;

            bloodApplyMessage.ApplyDept = this.ApplyDept.Clone();

            bloodApplyMessage.MyBloodApplyClass = this.MyBloodApplyClass.Clone();

            bloodApplyMessage.MyBloodDept = this.MyBloodDept.Clone();

            return bloodApplyMessage;
        }
    }
}
