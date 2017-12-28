using System;

namespace Neusoft.HISFC.Models.Pharmacy 
{
	/// <summary>
	/// Copyright (C) 2004 东软股份有限公司
	/// 版权所有
	/// 
	/// 文件名：DrugRecipe.cs
	/// 文件功能描述：门诊终端实体
	/// 
	/// 
	/// 创建标识：梁俊泽 2005-11
	/// 创建描述：ID 终端编码 Name 终端名称
	/// 
	/// 
	/// 修改标识：梁俊泽 2006-09
	/// 修改描述：程序整合
	/// </summary>
    [Serializable]
    public class DrugTerminal : Neusoft.FrameWork.Models.NeuObject
    {

        public DrugTerminal()
        {

        }


        #region 变量

        /// <summary>
        /// 所属库房
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        ///	终端类型 0 发药窗口 1 配药台
        /// </summary>
        private EnumTerminalType terminalType = EnumTerminalType.配药台;

        /// <summary>
        /// 终端性质 0 普通 1 专科 2 特殊
        /// </summary>
        private EnumTerminalProperty terminalProperty = EnumTerminalProperty.普通;

        /// <summary>
        /// 替代终端
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject replaceTerminal = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 是否关闭
        /// </summary>
        private bool isClose = false;

        /// <summary>
        /// 是否自动打印
        /// </summary>
        private bool isAutoPrint = true;

        /// <summary>
        /// 程序刷新间隔 (打印标签间隔)
        /// </summary>
        private decimal refreshInterval1 = 10;

        /// <summary>
        /// 大屏幕显示 刷新间隔
        /// </summary>
        private decimal refreshInterval2 = 10;

        /// <summary>
        /// 警戒线
        /// </summary>
        private int alertNum = 15;

        /// <summary>
        /// 显示人数
        /// </summary>
        private int showNum = 5;

        /// <summary>
        /// 发药窗口编码(只用于配药台)
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject sendWindow = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作环境信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 已发送处方品种数
        /// </summary>
        private decimal sendQty = 0;

        /// <summary>
        /// 待配药处方品种数
        /// </summary>
        private decimal drugQty = 0;

        /// <summary>
        /// 处方调剂中竞争调剂的均分次数参数
        /// </summary>
        private decimal averageNum = 0;

        /// <summary>
        /// 打印类型
        /// </summary>
        private EnumClinicPrintType terimalPrintType = EnumClinicPrintType.清单;

        #endregion

        /// <summary>
        /// 所属库房
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get
            {
                return this.dept;
            }
            set
            {
                this.dept = value;
            }
        }


        /// <summary>
        /// 终端类型
        /// </summary>
        public EnumTerminalType TerminalType
        {
            get { return terminalType; }
            set { terminalType = value; }
        }


        /// <summary>
        /// 终端性质
        /// </summary>
        public EnumTerminalProperty TerminalProperty
        {
            get { return terminalProperty; }
            set { terminalProperty = value; }
        }


        /// <summary>
        /// 替代终端
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ReplaceTerminal
        {
            get
            {
                return this.replaceTerminal;
            }
            set
            {
                this.replaceTerminal = value;
            }
        }


        /// <summary>
        /// 是否关闭
        /// </summary>
        public bool IsClose
        {
            get { return isClose; }
            set { isClose = value; }
        }


        /// <summary>
        /// 是否自动打印
        /// </summary>
        public bool IsAutoPrint
        {
            get { return isAutoPrint; }
            set { isAutoPrint = value; }
        }


        /// <summary>
        /// 程序刷新间隔
        /// </summary>
        public decimal RefreshInterval1
        {
            get { return refreshInterval1; }
            set { refreshInterval1 = value; }
        }


        /// <summary>
        /// 打印/显示 刷新间隔
        /// </summary>
        public decimal RefreshInterval2
        {
            get { return refreshInterval2; }
            set { refreshInterval2 = value; }
        }


        /// <summary>
        /// 警戒线
        /// </summary>
        public int AlertQty
        {
            get { return alertNum; }
            set { alertNum = value; }
        }


        /// <summary>
        /// 大屏幕显示人数
        /// </summary>
        public int ShowQty
        {
            get { return showNum; }
            set { showNum = value; }
        }


        /// <summary>
        /// 发药窗口编码(只用于配药台)
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject SendWindow
        {
            get { return sendWindow; }
            set { sendWindow = value; }
        }


        /// <summary>
        /// 操作环境信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return this.oper;
            }
            set
            {
                this.oper = value;
            }
        }


        /// <summary>
        /// 已发送配药处方品种数
        /// </summary>
        public decimal SendQty
        {
            get
            {
                return this.sendQty;
            }
            set
            {
                this.sendQty = value;
            }
        }


        /// <summary>
        /// 待配药处方品种数
        /// </summary>
        public decimal DrugQty
        {
            get
            {
                return this.drugQty;
            }
            set
            {
                this.drugQty = value;
            }
        }


        /// <summary>
        /// 处方调剂中竞争调剂的均分次数参数
        /// </summary>
        public decimal Average
        {
            get
            {
                return this.averageNum;
            }
            set
            {
                this.averageNum = value;
            }
        }

        /// <summary>
        /// 打印类型
        /// </summary>
        public EnumClinicPrintType TerimalPrintType
        {
            get
            {
                return terimalPrintType;
            }
            set
            {
                this.terimalPrintType = value;
            }
        }

        #region 方法

        /// <summary>
        /// 克隆函数 
        /// </summary>
        /// <returns>成功返回当前实例的副本</returns>
        public new DrugTerminal Clone()
        {
            DrugTerminal drugTerminal = base.Clone() as DrugTerminal;

            drugTerminal.Dept = this.Dept.Clone();
            drugTerminal.ReplaceTerminal = this.ReplaceTerminal.Clone();
            drugTerminal.Oper = this.Oper.Clone();
            drugTerminal.SendWindow = this.sendWindow.Clone();

            return drugTerminal;
        }


        #endregion

        #region 无效属性

        private string terminalCode;		//终端编号

        private string terminalName;		//终端名称

        private string deptCode;			//所属库房编码

        private string replaceCode;			//替代终端编号

        private string operCode;			//操作员

        private DateTime operDate;			//操作时间

        private string mark;				//备注

        /// <summary>
        /// 所属库房编码
        /// </summary>
        [System.Obsolete("程序整合 更改为Neuobject类型的Dept属性", true)]
        public string DeptCode
        {
            get { return deptCode; }
            set { deptCode = value; }
        }


        /// <summary>
        /// 替代终端编号
        /// </summary>
        [System.Obsolete("程序整合 更改为Neuobject类型的ReplactTerminal属性")]
        public string ReplaceCode
        {
            get { return replaceCode; }
            set { replaceCode = value; }
        }



        /// <summary>
        /// 操作员
        /// </summary>
        [System.Obsolete("程序整合 更改为Oper属性", true)]
        public string OperCode
        {
            get { return operCode; }
            set { operCode = value; }
        }


        /// <summary>
        /// 操作时间
        /// </summary>
        [System.Obsolete("程序整合 更改为Oper属性", true)]
        public DateTime OperDate
        {
            get { return operDate; }
            set { operDate = value; }
        }


        /// <summary>
        /// 备注
        /// </summary>
        [System.Obsolete("程序整合 更改为基类的Memo属性")]
        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }


        /// <summary>
        /// 处方调剂中竞争调剂的均分次数参数
        /// </summary>
        [System.Obsolete("程序整合 更改为Average属性")]
        public decimal AverageNum
        {
            get
            {
                return this.averageNum;
            }
            set
            {
                this.averageNum = value;
            }
        }


        /// <summary>
        /// 终端编号
        /// </summary>
        [System.Obsolete("程序整合 更改为基类的ID属性", true)]
        public string TerminalCode
        {
            get { return terminalCode; }
            set
            {
                terminalCode = value;
                this.ID = value;
            }
        }


        /// <summary>
        /// 终端名称
        /// </summary>
        [System.Obsolete("程序整合 更改为基类的Name属性", true)]
        public string TerminalName
        {
            get { return terminalName; }
            set
            {
                terminalName = value;
                this.Name = value;
            }
        }


        /// <summary>
        /// 警戒线
        /// </summary>
        [System.Obsolete("程序整合 更改为AlterQty属性", true)]
        public int AlertNum
        {
            get { return alertNum; }
            set { alertNum = value; }
        }


        /// <summary>
        /// 大屏幕显示人数
        /// </summary>
        [System.Obsolete("程序整合 更改为ShowQty属性", true)]
        public int ShowNum
        {
            get { return showNum; }
            set { showNum = value; }
        }


        #endregion

    }
}
