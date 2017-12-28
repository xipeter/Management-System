using System;
using Neusoft.FrameWork.Models;
namespace Neusoft.HISFC.Models.HealthRecord
{
    /// <summary>
    /// Baby<br></br>
    /// [功能描述:婴儿基本信息登记]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-04-2]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
 
    [Serializable]
    public class Baby : NeuObject
    {
        public Baby()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 私有变量

        //住院流水号
        private string inpatientNo;
        //婴儿序号 
        private int happenNum;
        //性别  
        private string sexCode;
        //妊辰结果  
        private string birthEnd;
        //体重
        private float weight;
        //转归  
        private string babyState;
        //呼吸
        private string breath;
        //  感染  ID代码 name 名称 
        private NeuObject infect = new NeuObject();
        //感染次数   
        private int infectNum;
        //抢救次数  
        private int salvNum;
        //成功次数 
        private int succNum;
        //生产方式
        private string birthMod;
        //操作员 ID 编码 ，name 姓名
        private NeuObject oper = new NeuObject();

        #endregion

        #region 属性
        /// <summary>
        /// 操作员 ID 编码 ，name 姓名
        /// </summary>
        public NeuObject OperInfo
        {
            get
            {
                if (oper == null)
                {
                    oper = new NeuObject();
                }
                return oper;
            }
            set
            {
                oper = value;
            }
        }

        /// <summary>
        /// 生产方式
        /// </summary>
        public string BirthMod
        {
            get
            {
                if (birthMod == null)
                {
                    birthMod = "";
                }
                return birthMod;
            }
            set
            {
                birthMod = value;
            }
        }

        /// <summary>
        /// 成功次数
        /// </summary>
        public int SuccNum
        {
            get
            {
                return succNum;
            }
            set
            {
                succNum = value;
            }
        }

        /// <summary>
        /// 抢救次数
        /// </summary>
        public int SalvNum
        {
            get
            {
                return salvNum;
            }
            set
            {
                salvNum = value;
            }
        }

        /// <summary>
        /// 感染次数
        /// </summary>
        public int InfectNum
        {
            get
            {
                return infectNum;
            }
            set
            {
                infectNum = value;
            }
        }

        /// <summary>
        /// 感染
        /// </summary>
        public NeuObject Infect
        {
            get
            {
                if (infect == null)
                {
                    infect = new NeuObject();
                }
                return infect;
            }
            set
            {
                infect = value;
            }
        }

        /// <summary>
        /// 呼吸
        /// </summary>
        public string Breath
        {
            get
            {
                if (breath == null)
                {
                    breath = "";
                }
                return breath;
            }
            set
            {
                breath = value;
            }
        }

        /// <summary>
        /// 转归 
        /// </summary>
        public string BabyState
        {
            get
            {
                if (babyState == null)
                {
                    babyState = "";
                }
                return babyState;
            }
            set
            {
                babyState = value;
            }
        }

        /// <summary>
        /// 体重
        /// </summary>
        public float Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        /// <summary>
        /// 妊辰结果  
        /// </summary>
        public string BirthEnd
        {
            get
            {
                if (birthEnd == null)
                {
                    birthEnd = "";
                }
                return birthEnd;
            }
            set
            {
                birthEnd = value;
            }
        }

        /// <summary>
        /// 性别  
        /// </summary>
        public string SexCode
        {
            get
            {
                if (sexCode == null)
                {
                    sexCode = "";
                }
                return sexCode;
            }
            set
            {
                sexCode = value;
            }
        }

        /// <summary>
        /// 婴儿序号
        /// </summary>
        public int HappenNum
        {
            get
            {
                return happenNum;
            }
            set
            {
                happenNum = value;
            }
        }

        /// <summary>
        /// 住院流水号
        /// </summary>
        public string InpatientNo
        {
            get
            {
                if (inpatientNo == null)
                {
                    inpatientNo = "";
                }
                return inpatientNo;
            }
            set
            {
                inpatientNo = value;
            }
        }
        #endregion

        #region  克隆函数


        public new Baby Clone()
        {
            Baby bb = base.Clone() as Baby;
            bb.OperInfo = oper.Clone();
            bb.infect = infect.Clone();
            return bb;
        }
        #endregion

    }
}
