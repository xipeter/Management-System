using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// 
    [System.Serializable]
    public class GainReg : Spell, IValid
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public GainReg() 
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 效益登记流水号
        /// </summary>
        private string gainRegNO;

        /// <summary>
        /// 效益分类流水号
        /// </summary>
        private string gainKindNO;
     
        /// <summary>
        /// 效益登记单据号
        /// </summary>
        private string gainRegListCode;
         
        /// <summary>
        /// 设备科室信息
        /// id=设备科室编码
        /// name=设备科室名称
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject deptInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 卡片流水号
        /// </summary>
        private string seqNO;

        /// <summary>
        /// 保管科室
        /// 编码
        /// </summary>
        private string storDept;

        /// <summary>
        /// 保管人
        /// 编码
        /// </summary>
        private string storOper;

        /// <summary>
        /// 设备信息
        /// id=设备编码
        /// name=设备名称
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject equInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 规格
        /// </summary>
        private string specs;

        /// <summary>
        /// 型号
        /// </summary>
        private string model;
    
        /// <summary>
        /// 单位
        /// </summary>
        private string unit;

        /// <summary>
        /// 保管等级
        /// </summary>
        private string storClass;

        /// <summary>
        /// 操作员信息
        /// 操作员
        /// 操作时间
        /// </summary>
        private OperEnvironment operInfo = new OperEnvironment();

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;

        /// <summary>
        /// 效益金额
        /// </summary>
        private int gainCost;

        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        private string validFlag = "1";
        #endregion

        #region 属性
        /// <summary>
        /// 效益登记流水号
        /// </summary>       
        public string GainRegNO
        {
            get { return gainRegNO; }
            set { gainRegNO = value; }
        }

        /// <summary>
        /// 效益分类流水号
        /// </summary>
        public string GainKindNO
        {
            get { return gainKindNO; }
            set { gainKindNO = value; }
        }

        /// <summary>
        /// 效益登记单据号
        /// </summary>
        public string GainRegListCode
        {
            get { return gainRegListCode; }
            set { gainRegListCode = value; }
        }
       
        /// <summary>
        /// 设备科室信息
        /// id=设备科室编码
        /// name=设备科室名称
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject DeptInfo
        {
            get { return deptInfo; }
            set { deptInfo = value; }
        }

        /// <summary>
        /// 卡片流水号
        /// </summary>
        public string SeqNO
        {
            get { return seqNO; }
            set { seqNO = value; }
        }
        /// <summary>
        /// 保管科室
        /// 编码
        /// </summary>
        public string StorDept
        {
            get { return storDept; }
            set { storDept = value; }
        }
        /// <summary>
        /// 保管人
        /// 编码
        /// </summary>
        public string StorOper
        {
            get { return storOper; }
            set { storOper = value; }
        }
        /// <summary>
        /// 设备信息
        /// id=设备编码
        /// name=设备名称
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject EquInfo
        {
            get { return equInfo; }
            set { equInfo = value; }
        }

        /// <summary>
        /// 规格
        /// </summary>
        public string Specs
        {
            get { return specs; }
            set { specs = value; }
        }

        /// <summary>
        /// 型号
        /// </summary>
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        /// <summary>
        /// 保管等级
        /// </summary>
        public string StorClass
        {
            get { return storClass; }
            set { storClass = value; }
        }

        /// <summary>
        /// 操作员信息
        /// 操作员
        /// 操作时间
        /// </summary>
        public OperEnvironment OperInfo
        {
            get { return operInfo; }
            set { operInfo = value; }
        }

        /// <summary>
        /// 效益金额
        /// </summary>
        public int GainCost
        {
            get { return gainCost; }
            set { gainCost = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new GainReg Clone()
        {
            GainReg gainReg = base.Clone() as GainReg;

            gainReg.deptInfo = this.deptInfo.Clone();
            gainReg.operInfo = this.operInfo.Clone();
            gainReg.equInfo = this.equInfo.Clone();
            return gainReg;
        }

        #endregion

        #region IValid 成员

        public bool IsValid
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
