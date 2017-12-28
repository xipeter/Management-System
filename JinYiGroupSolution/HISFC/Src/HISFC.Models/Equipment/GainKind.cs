using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Equipment
{
    [System.Serializable]
    public class GainKind:Spell,IValid
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public GainKind() 
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 上级编码(根的上级为0)
        /// </summary>
        private string preCode;

        /// <summary>
        /// 是否末级1是0否
        /// </summary>
        private string leafFlag;

        /// <summary>
        /// 设备科室信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject deptInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 收支标记0支出1收入
        /// </summary>
        private string inoutFlag;

        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        private string validFlag;

        /// <summary>
        /// 操作员信息
        /// </summary>
        private OperEnvironment operInfo = new OperEnvironment();

        /// <summary>
        /// 备注信息
        /// </summary>
        private string remark;

        /// <summary>
        /// 国标码
        /// </summary>
        private string nationCode;

        /// <summary>
        /// 树的层次
        /// </summary>
        private int treeLevel;

        #endregion

        #region 属性
        
        /// <summary>
        /// 上级编码(根的上级为0)
        /// </summary>
        public string PreCode
        {
            get { return preCode; }
            set { preCode = value; }
        }

        /// <summary>
        /// 是否末级1是0否
        /// </summary>
        public string LeafFlag
        {
            get { return leafFlag; }
            set { leafFlag = value; }
        }

        /// <summary>
        /// 设备科室信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject DeptInfo
        {
            get { return deptInfo; }
            set { deptInfo = value; }
        }

        /// <summary>
        /// 收支标记0支出1收入
        /// </summary>
        public string InoutFlag
        {
            get { return inoutFlag; }
            set { inoutFlag = value; }
        }

        /// <summary>
        /// 操作员信息
        /// </summary>
        public OperEnvironment OperInfo
        {
            get { return operInfo; }
            set { operInfo = value; }
        }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        /// <summary>
        /// 国标码
        /// </summary>
        public string NationCode
        {
            get { return nationCode; }
            set { nationCode = value; }
        }

        /// <summary>
        /// 树的层次
        /// </summary>
        public int TreeLevel
        {
            get { return treeLevel; }
            set { treeLevel = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new GainKind Clone() 
        {
            GainKind gainKind = base.Clone() as GainKind;

            gainKind.deptInfo = this.deptInfo.Clone();
            gainKind.operInfo = this.operInfo.Clone();

            return gainKind;
        }

        #endregion
    
        #region IValid 成员

        public bool  IsValid
        {
	          get 
	        {
                if (this.validFlag == "1")
                    return true;
                else
                    return false;
	        }
	          set 
	        {
                if (value == true)
                    this.validFlag = "1";
                else
                    this.validFlag = "0";
	        }
        }

        #endregion
}
}
