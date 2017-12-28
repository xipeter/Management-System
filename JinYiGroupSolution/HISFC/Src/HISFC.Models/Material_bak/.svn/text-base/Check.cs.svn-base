using System;

namespace Neusoft.HISFC.Object.Material
{
    /// <summary>
    /// Check 的摘要说明。
    /// 盘点实体继承库存实体
    /// ID			盘点流水号(CheckNo)
    /// GroupNo		批次
    /// Dept.Id		科室编码
    /// Item实体	盘点药品信息
    /// OperCode	操作员
    /// OperDate	操作时间
    /// </summary>
    public class Check : Neusoft.NFC.Object.NeuObject
    {
        //private string myCheckCode;		//盘点单号
        //private decimal myFStoreNum;	//封帐数量
        //private decimal myAdjustNum;	//盘点数量
        //private decimal myCStoreNum;	//结存数量
        //private decimal myMinNum;		//最小数量
        //private decimal myPackNum;		//包装数量
        //private decimal myProfitLossNum;//盈亏数量
        //private string myProfitStatic;	//盈亏标记 0 盘亏  1 盘盈 2 无盈亏
        //private string myQualityFlag;	//质量标记 0 好	   1 不好
        ////private string isAdd;			//附加药品标记  0 不附加  1 附加
        //private string myDisposeWay;	//处理方式
        //private string myFOperCode;		//封帐人
        //private DateTime myFOperDate;	//封帐时间
        //private string myCOperCode;		//结存人
        //private DateTime myCOperDate;	//结存时间
        //private string myCheckState;	//盘点状态:0封帐,1结存,2取消
        //private decimal myLastNum;//上月结存
        //private decimal myInNum;//本月入库数
        //private decimal myOutNum;//本月出库数
        //private decimal myInMoney;//本月入库金额
        //private decimal myOutMoney;//本月出库金额
        //private decimal myFstoreMoney;//账面金额（对应于封帐数量）
        //private DateTime myFromDate;
        //private DateTime myToDate;

        public Check()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            //this.PrivType = "0506";	//盘点结存权限编码
        }

        #region 变量

        private string myCheckCode;		//盘点单号

        private string myCheckName;     //盘点单名称

        private decimal myFStoreNum;	//封帐数量

        private decimal myAdjustNum;	//盘点数量

        private decimal myCStoreNum;	//结存数量

        private decimal myProfitLossNum;//盈亏数量

        private string myProfitFlag;	//盈亏标记 0 盘亏  1 盘盈 2 无盈亏

        private string myCheckState;	//盘点状态:0封帐,1结存,2取消

        private decimal myCheckLossCost; //盘亏金额(零售价)

        private decimal myCheckProfitCost; //盘盈金额(零售价)

        private StoreHead myStoreHead = new StoreHead();  //库存汇总信息

        /// <summary>
        /// 封帐操作信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment fOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 结存操作信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment cOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 操作信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        #endregion 变量

        #region 属性

        /// <summary>
        /// 盘点单号
        /// </summary>
        public string CheckCode
        {
            get { return myCheckCode; }
            set { myCheckCode = value; }
        }

        /// <summary>
        /// 盘点单名称
        /// </summary>
        public string CheckName
        {
            get { return myCheckName; }
            set { myCheckName = value; }
        }

        /// <summary>
        /// 封帐数量
        /// </summary>
        public decimal FStoreNum
        {
            get { return myFStoreNum; }
            set { myFStoreNum = value; }
        }

        /// <summary>
        /// 盘点数量
        /// </summary>
        public decimal AdjustNum
        {
            get { return myAdjustNum; }
            set { myAdjustNum = value; }
        }

        /// <summary>
        /// 结存数量
        /// </summary>
        public decimal CStoreNum
        {
            get { return myCStoreNum; }
            set { myCStoreNum = value; }
        }

        /// <summary>
        /// 盈亏数量
        /// </summary>
        public decimal ProfitLossNum
        {
            get { return myProfitLossNum; }
            set { myProfitLossNum = value; }
        }

        /// <summary>
        /// 盈亏标记 0 盘亏  1 盘盈 2 无盈亏
        /// </summary>
        public string ProfitFlag
        {
            get { return myProfitFlag; }
            set { myProfitFlag = value; }
        }

        /// <summary>
        /// 盘点状态:0封帐,1结存,2取消
        /// </summary>
        public string CheckState
        {
            get { return myCheckState; }
            set { myCheckState = value; }
        }

        /// <summary>
        /// 盘亏金额(零售价)
        /// </summary>
        public decimal CheckLossCost
        {
            get { return myCheckLossCost; }
            set { myCheckLossCost = value; }
        }

        /// <summary>
        /// 盘盈金额(零售价)
        /// </summary>
        public decimal CheckProfitCost
        {
            get { return myCheckProfitCost; }
            set { myCheckProfitCost = value; }
        }

        /// <summary>
        /// 封帐操作信息
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment FOper
        {
            get { return fOper; }
            set { fOper = value; }
        }

        /// <summary>
        /// 结存操作信息
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment COper
        {
            get { return cOper; }
            set { cOper = value; }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment Oper
        {
            get { return oper; }
            set { oper = value; }
        }

        /// <summary>
        /// 库存汇总信息
        /// </summary>
        public StoreHead StoreHead
        {
            get { return myStoreHead; }
            set { myStoreHead = value; }
        }

        #endregion 属性
    }
}
