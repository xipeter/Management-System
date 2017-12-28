using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Terminal
{
    /// <summary>
    /// Terminal<br></br>
    /// [功能描述: 医技设备维护]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-8-20]<br></br>
    /// <说明>
    ///     1、  {F8383442-78B0-40c2-B906-50BA52ADB139}  增加实体属性 设备类型
    /// </说明>
    /// </summary>
    [Serializable]
    public class TerminalCarrier : Base.Spell
    {
        public TerminalCarrier()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //

        }

        #region 变量

        /// <summary>
        /// 科室编码
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        ///  预约载体编码
        /// </summary>
        private string carrierCode;

        /// <summary>
        ///  预约载体名称
        /// </summary>
        private string carrierName;

        /// <summary>
        ///  预约载体类别
        /// </summary>
        private string carrierType;

        /// <summary>
        ///  备注信息
        /// </summary>
        private string carrierMemo;

        /// <summary>
        ///  型号
        /// </summary>
        private string model;

        /// <summary>
        ///  是否空闲
        /// </summary>
        private string isDisengaged;

        /// <summary>
        ///  预计空闲日期
        /// </summary>
        private DateTime disengagedTime = new DateTime(1900, 1, 1, 1, 1, 1);

        /// <summary>
        ///  日限额

        /// </summary>
        private decimal dayQuota;

        /// <summary>
        ///  医生直接预约限额
        /// </summary>
        private decimal doctorQuota;

        /// <summary>
        ///  患者自助预约限额（在医院、触摸屏）

        /// </summary>
        private decimal selfQuota;

        /// <summary>
        ///  患者自助预约限额（Web）


        /// </summary>
        private decimal webQuota;

        /// <summary>
        /// 所处建筑物
        /// </summary>
        private string building;

        /// <summary>
        /// 所处楼层


        /// </summary>
        private string floor;

        /// <summary>
        /// 所处房间


        /// </summary>
        private string room;

        /// <summary>
        /// 排列序号
        /// </summary>
        private decimal sortId;

        /// <summary>
        /// 是否有预停用时间
        /// </summary>
        private string isPrestopTime;

        /// <summary>
        /// 预停用时间


        /// </summary>
        private DateTime preStopTime = new DateTime(1900, 1, 1, 1, 1, 1);
        /// <summary>
        /// 与启动时间


        /// </summary>
        private DateTime preStartTime = new DateTime(1900, 1, 1, 1, 1, 1);

        /// <summary>
        /// 平均周转时间
        /// </summary>
        private decimal avgTurnoverTime;

        /// <summary>
        /// 创建人工号


        /// </summary>
        private string createOper;

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime createTime = new DateTime(1900, 1, 1, 1, 1, 1); //DateTime.MaxValue;//

        /// <summary>
        /// 是否有效
        /// </summary>
        private string isValid = "1";

        /// <summary>
        /// 操作员(包括使有效)
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment validOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 操作员(包括使无效)
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment invalidOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 设备类型
        /// </summary>
        private string deviceType = string.Empty;

        #endregion

        #region 属性

        /// <summary>
        /// 操作员(包括使无效)
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment InvalidOper
        {
            get
            {
                return invalidOper;
            }
            set
            {
                invalidOper = value;
            }
        }

        /// <summary>
        /// 操作员(包括使有效)
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment ValidOper
        {
            get
            {
                return validOper;
            }
            set
            {
                validOper = value;
            }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public string IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get
            {
                return createTime;
            }
            set
            {
                createTime = value;
            }
        }

        /// <summary>
        /// 创建人工号

        /// </summary>
        public string CreateOper
        {
            get
            {
                return createOper;
            }
            set
            {
                createOper = value;
            }
        }

        /// <summary>
        /// 平均周转时间
        /// </summary>
        public decimal AvgTurnoverTime
        {
            get
            {
                return avgTurnoverTime;
            }
            set
            {
                avgTurnoverTime = value;
            }
        }

        /// <summary>
        /// 与启动时间


        /// </summary>
        public DateTime PreStartTime
        {
            get
            {
                return preStartTime;
            }
            set
            {
                preStartTime = value;
            }
        }

        /// <summary>
        /// 预停用时间

        /// </summary>
        public DateTime PreStopTime
        {
            get
            {
                return preStopTime;
            }
            set
            {
                preStopTime = value;
            }
        }

        /// <summary>
        /// 是否有预停用时间
        /// </summary>
        public string IsPrestopTime
        {
            get
            {
                return isPrestopTime;
            }
            set
            {
                isPrestopTime = value;
            }
        }

        /// <summary>
        /// 排列序号
        /// </summary>
        public decimal SortId
        {
            get
            {
                return sortId;
            }
            set
            {
                sortId = value;
            }
        }

        /// <summary>
        /// 所处房间

        /// </summary>
        public string Room
        {
            get
            {
                return room;
            }
            set
            {
                room = value;
            }
        }

        /// <summary>
        /// 所处楼层

        /// </summary>
        public string Floor
        {
            get
            {
                return floor;
            }
            set
            {
                floor = value;
            }
        }

        /// <summary>
        /// 所处建筑物
        /// </summary>
        public string Building
        {
            get
            {
                return building;
            }
            set
            {
                building = value;
            }
        }

        /// <summary>
        ///  患者自助预约限额（Web）

        /// </summary>
        public decimal WebQuota
        {
            get
            {
                return webQuota;
            }
            set
            {
                webQuota = value;
            }
        }

        /// <summary>
        ///  患者自助预约限额（在医院、触摸屏）

        /// </summary>
        public decimal SelfQuota
        {
            get
            {
                return selfQuota;
            }
            set
            {
                selfQuota = value;
            }
        }

        /// <summary>
        ///  医生直接预约限额
        /// </summary>
        public decimal DoctorQuota
        {
            get
            {
                return doctorQuota;
            }
            set
            {
                doctorQuota = value;
            }
        }

        /// <summary>
        ///  日限额


        /// </summary>
        public decimal DayQuota
        {
            get
            {
                return dayQuota;
            }
            set
            {
                dayQuota = value;
            }
        }

        /// <summary>
        ///  预计空闲日期
        /// </summary>
        public DateTime DisengagedTime
        {
            get
            {
                return disengagedTime;
            }
            set
            {
                disengagedTime = value;
            }
        }

        /// <summary>
        ///  是否空闲
        /// </summary>
        public string IsDisengaged
        {
            get
            {
                return isDisengaged;
            }
            set
            {
                isDisengaged = value;
            }
        }



        /// <summary>
        ///  型号
        /// </summary>
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        /// <summary>
        ///  备注信息
        /// </summary>
        public string CarrierMemo
        {
            get
            {
                return carrierMemo;
            }
            set
            {
                carrierMemo = value;
            }
        }

        /// <summary>
        ///  预约载体类别
        /// </summary>
        public string CarrierType
        {
            get
            {
                return carrierType;
            }
            set
            {
                carrierType = value;
            }
        }

        /// <summary>
        ///  预约载体名称
        /// </summary>
        public string CarrierName
        {
            get
            {
                return carrierName;
            }
            set
            {
                carrierName = value;
            }
        }


        /// <summary>
        ///  预约载体编码
        /// </summary>
        public string CarrierCode
        {
            get
            {
                return carrierCode;
            }
            set
            {
                carrierCode = value;
            }
        }

        /// <summary>
        /// 科室编码
        /// </summary> 
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get
            {
                return dept;
            }
            set
            {
                dept = value;
            }
        }

        /// <summary>
        /// 设备类型
        /// </summary>
        public string DeviceType
        {
            get
            {
                return deviceType;
            }
            set
            {
                deviceType = value;
            }
        }
        #endregion

        #region 克隆

        public new TerminalCarrier Clone()
        {
            TerminalCarrier terminalCarrier = base.Clone() as TerminalCarrier;

            terminalCarrier.dept = this.dept.Clone();
            terminalCarrier.validOper = this.validOper.Clone();
            terminalCarrier.invalidOper = this.invalidOper.Clone();

            return terminalCarrier;
        }

        #endregion
    }
}
