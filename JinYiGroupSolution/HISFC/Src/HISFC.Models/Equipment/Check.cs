using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// Check<br></br>
    /// [功能描述: 设备盘点实体类]<br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2007-12-4]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class Check : Neusoft.HISFC.Models.Base.Spell
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public Check()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion 构造函数

        #region 变量

        #region 私有变量

        /// <summary>
        /// 盘点单序号
        /// </summary>
        private int checkSerialCode;

        /// <summary>
        /// 盘点单据号
        /// </summary>
        private string checkListCode;

        /// <summary>
        /// 卡片实体
        /// </summary>
        private Main checkMain = new Main();

        /// <summary>
        /// 现状态
        /// </summary>
        private string currStateNew;

        /// <summary>
        /// 现状态涵义码
        /// </summary>
        private string class3MeaningCodeNew;

        /// <summary>
        /// 盈亏状态0正常1盘盈2盘亏
        /// </summary>
        private string checkState;

        /// <summary>
        /// 盈亏金额(原值)
        /// </summary>
        private decimal checkCost;

        /// <summary>
        /// 是否核准盘点0未核准1核准
        /// </summary>
        private bool isApprove;

        /// <summary>
        /// 盘点人
        /// </summary>
        private NeuObject checkOper = new NeuObject();

        /// <summary>
        /// 盘点科室
        /// </summary>
        private NeuObject checkDept = new NeuObject();

        /// <summary>
        /// 盘点时间
        /// </summary>
        private DateTime checkDate;

        /// <summary>
        /// 核准人
        /// </summary>
        private NeuObject approveOper = new NeuObject();

        /// <summary>
        /// 核准科室
        /// </summary>
        private NeuObject aproveDept = new NeuObject();

        /// <summary>
        /// 核准时间
        /// </summary>
        private DateTime approveDate;

        /// <summary>
        /// 报废表流水号
        /// </summary>
        private string rejectNo;

        /// <summary>
        /// 该盘点单的盘点列表
        /// </summary>
        private List<Check> checkList = new List<Check>();

        #endregion 私有变量

        #region 保护变量
        #endregion 保护变量

        #region 公开变量
        #endregion 公开变量

        #endregion 变量

        #region 属性

        /// <summary>
        /// 盘点单序号
        /// </summary>
        public int CheckSerialCode
        {
            get { return checkSerialCode; }
            set { checkSerialCode = value; }
        }

        /// <summary>
        /// 盘点单据号
        /// </summary>
        public string CheckListCode
        {
            get { return checkListCode; }
            set { checkListCode = value; }
        }

        /// <summary>
        /// 卡片实体
        /// </summary>
        public Main CheckMain
        {
            get { return checkMain; }
            set { checkMain = value; }
        }

        /// <summary>
        /// 现状态
        /// </summary>
        public string CurrStateNew
        {
            get { return currStateNew; }
            set { currStateNew = value; }
        }

        /// <summary>
        /// 现状态涵义码
        /// </summary>
        public string Class3MeaningCodeNew
        {
            get { return class3MeaningCodeNew; }
            set { class3MeaningCodeNew = value; }
        }

        /// <summary>
        /// 盈亏状态0正常1盘盈2盘亏
        /// </summary>
        public string CheckState
        {
            get { return checkState; }
            set { checkState = value; }
        }

        /// <summary>
        /// 盈亏金额(原值)
        /// </summary>
        public decimal CheckCost
        {
            get { return checkCost; }
            set { checkCost = value; }
        }

        /// <summary>
        /// 是否核准盘点0未核准1核准
        /// </summary>
        public bool IsApprove
        {
            get { return isApprove; }
            set { isApprove = value; }
        }

        /// <summary>
        /// 盘点人
        /// </summary>
        public NeuObject CheckOper
        {
            get { return checkOper; }
            set { checkOper = value; }
        }

        /// <summary>
        /// 盘点科室
        /// </summary>
        public NeuObject CheckDept
        {
            get { return checkDept; }
            set { checkDept = value; }
        }

        /// <summary>
        /// 盘点时间
        /// </summary>
        public DateTime CheckDate
        {
            get { return checkDate; }
            set { checkDate = value; }
        }

        /// <summary>
        /// 核准人
        /// </summary>
        public NeuObject ApproveOper
        {
            get { return approveOper; }
            set { approveOper = value; }
        }

        /// <summary>
        /// 核准科室
        /// </summary>
        public NeuObject AproveDept
        {
            get { return aproveDept; }
            set { aproveDept = value; }
        }

        /// <summary>
        /// 核准时间
        /// </summary>
        public DateTime ApproveDate
        {
            get { return approveDate; }
            set { approveDate = value; }
        }

        /// <summary>
        /// 报废表流水号
        /// </summary>
        public string RejectNo
        {
            get { return rejectNo; }
            set { rejectNo = value; }
        }

        /// <summary>
        /// 盘点单序号索引器
        /// </summary>
        /// <param name="serial">盘点单序号</param>
        /// <returns></returns>
        public Check this[int serial]
        {
            get
            {
                if (serial > this.checkList.Count)
                {
                    return null;
                }
                return this.checkList[serial];
            }
            set
            {
                if (this.checkList.Count > serial)
                {
                    this.checkList[serial] = value;
                }
            }
        }

        /// <summary>
        /// 盘点单个数
        /// </summary>
        public int Count
        {
            get
            {
                return this.checkList.Count;
            }
        }

        #endregion 属性

        #region 方法

        #region 资源释放
        #endregion 资源释放

        #region 添加
        /// <summary>
        /// 添加一条盘点信息
        /// </summary>
        /// <param name="newCheck"></param>
        public void Add(Neusoft.HISFC.Models.Equipment.Check newCheck)
        {
            for (int i = 0; i < this.checkList.Count; i++)
            {
                if (this.checkList[i].checkMain.ID == newCheck.checkMain.ID)
                {
                    return;
                }
            }
            this.checkList.Add(newCheck);
            this.setSerialCode();
        }
        #endregion

        #region 移除
        /// <summary>
        /// 移除一条盘点信息
        /// </summary>
        /// <param name="cardNo">卡片编号</param>
        public void Remove(string cardNo)
        {
            for (int i = 0; i < this.checkList.Count; i++)
            {
                if (this.checkList[i].checkMain.ID == cardNo)
                {
                    this.checkList.Remove(this.checkList[i]);
                    break;
                }
            }
            this.setSerialCode();
        }
        #endregion

        #region 设置盘点序号
        /// <summary>
        /// 设置盘点序号
        /// </summary>
        private void setSerialCode()
        {
            for (int i = 0; i < this.checkList.Count; i++)
            {
                this.checkList[i].checkSerialCode = i;
            }
        }
        #endregion

        #region 克隆

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new Check Clone()
        {
            Check check = base.Clone() as Check;

            check.CheckMain = this.checkMain.Clone();
            check.CheckOper = this.checkOper.Clone();
            check.CheckDept = this.checkDept.Clone();
            check.ApproveOper = this.approveOper.Clone();
            check.AproveDept = this.aproveDept.Clone();
            for (int i = 0; i < this.checkList.Count; i++)
            {
                check.checkList[i] = this.checkList[i].Clone();
            }

            return check;
        }

        #endregion 克隆

        #region 私有方法
        #endregion 私有方法

        #region 保护方法
        #endregion 保护方法

        #region 公开方法
        #endregion 公开方法

        #endregion 方法

        #region 接口实现
        #endregion 接口实现
    }
}
