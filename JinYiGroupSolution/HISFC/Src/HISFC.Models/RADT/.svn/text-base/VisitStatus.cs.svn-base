
using System;
 

namespace Neusoft.HISFC.Object.RADT
{
    /// <summary>
    /// 患者在院状态 written by wolf 
    /// 2004-6-9
    /// <br>Value	Description</br>
    ///	<br>R	Registration 住院登记完成 等待接诊</br>
    ///	<br>I	after Receiption,in 病房接诊完成 在院状态</br>
    ///	<br>B	Balance  出院登记完成 结算状态</br>
    ///	<br>O	out Balance出院结算完成</br>				
    ///	<br>P	PreOut预约出院</br>
    ///	<br>N	NoFee无费退院</br>
    /// <br>C cancel 取消状态</br> 
    /// </summary>
    [Obsolete("已经过期，更改为EnumInState")]
    public class VisitStatus:Neusoft.NFC.Object.NeuObject
    {
        /// <summary>
        /// 患者在院状态类
        /// </summary>
        public VisitStatus()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 在院状态
        /// </summary>
        public enum enuVisitStatus
        {
            /// <summary>
            /// Registration 住院登记完成 等待接诊
            /// </summary>
            R =0,
            /// <summary>
            /// after Receiption,in 病房接诊完成 在院状态
            /// </summary>
            I =1,
            /// <summary>
            /// Balance  出院登记完成 结算状态
            /// </summary>
            B =2,
            /// <summary>
            /// out Balance出院结算完成
            /// </summary>
            O =3,
            /// <summary>
            ///PreOut预约出院
            /// </summary>
            P =4,
            /// <summary>
            /// NoFee无费退院
            /// </summary>
            N =5,
            /// <summary>
            /// Close 封账状态
            /// </summary>
            C =6
        };
		
        /// <summary>
        /// 重载ID
        /// </summary>
        private enuVisitStatus myID;
        public new System.Object ID
        {
            get
            {
                return this.myID;
            }
            set
            {
                try
                {
                    this.myID=(this.GetIDFromName (value.ToString())); 
                }
                catch
                {}
                base.ID=this.myID.ToString();
                string s=this.Name;
            }
        }
        public enuVisitStatus GetIDFromName(string Name)
        {
            enuVisitStatus c=new enuVisitStatus();
            for(int i=0;i<100;i++)
            {
                c=(enuVisitStatus)i;
                if(c.ToString()==Name) return c;
            }
            return (enuVisitStatus)int.Parse(Name);
        }
        public new string Name
        {
            get
            {
                string strVisitStatus;
                switch ((int)this.ID)
                {
                    case 0:
                        strVisitStatus= "住院登记";
                        break;
                    case 1:
                        strVisitStatus="在院状态";
                        break;
                    case 2:
                        strVisitStatus="出院登记";
                        break;
                    case 3:
                        strVisitStatus="出院清账";
                        break;
                    case 4:
                        strVisitStatus="预约出院";
                        break;
                    case 5:
                        strVisitStatus="无费退院";
                        break;
                    case 6:
                        strVisitStatus="结帐";
                        break;
                    default:
                        strVisitStatus="未知";
                        break;
                }
                base.Name=strVisitStatus;
                return	strVisitStatus;
            }
        }
        /// <summary>
        /// 获得全部列表
        /// </summary>
        /// <returns>ArrayList(VisitStatus)</returns>
        public System.Collections.ArrayList List()
        {
            VisitStatus aVisitStatus;
            System.Collections.ArrayList alReturn=new System.Collections.ArrayList();
            int i;
            for(i=0;i<=6;i++)
            {
                aVisitStatus=new VisitStatus();
                aVisitStatus.ID=(enuVisitStatus)i;
                aVisitStatus.Memo=i.ToString();
                alReturn.Add(aVisitStatus);
            }
            return alReturn;
        }
        public new VisitStatus Clone()
        {
            return this.MemberwiseClone() as VisitStatus;
        }
    }
}
