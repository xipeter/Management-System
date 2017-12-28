using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Integrate.HealthRecord.Case
{
    /// <summary>
    /// CaseBill <br></br>
    /// [功能描述: 病历出库单]<br></br>
    /// [创 建 者: 赫一阳]<br></br>
    /// [创建时间: 2007-09-14]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class CaseBill : IntegrateBase
    {
        #region 变量

        /// <summary>
        /// 返回值

        /// </summary>
        private int callReturn = -1;

        /// <summary>
        /// 病历出库单业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseBill caseBillFunction = new Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseBill();

        /// <summary>
        /// 病历基本信息业务层

        /// </summary>
        protected Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseInfo caseInfoFunction = new Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseInfo();

        /// <summary>
        /// 病历跟踪
        /// </summary>
        protected Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseTrackManager caseTrackFunction = new Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseTrackManager();

        #endregion

        #region 方法

        /// <summary>
        /// 设置数据库事务

        /// </summary>
        /// <param name="trans">数据库事务</param>
        public override void SetTrans( System.Data.IDbTransaction trans )
        {
            this.trans = trans;

            caseBillFunction.SetTrans( trans);
            caseInfoFunction.SetTrans( trans);
            caseTrackFunction.SetTrans( trans );
        }

        /// <summary>
        /// 获取当前科室
        /// </summary>
        /// <returns></returns>
        public string GetDept()
        {
            return ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
        }

        /// <summary>
        /// 取系统当前时间

        /// </summary>
        /// <returns>当前时间</returns>
        public DateTime GetDateTime()
        {
            return caseBillFunction.GetDateTimeFromSysDateTime();
        }

        /// <summary>
        /// 获取病历出库单管理树
        /// </summary>
        /// <param name="caseBillTree">树节点</param>
        /// <param name="fromDate">起始时间</param>
        /// <returns>－1－失败，1－成功</returns>
        public int GetTreeNode( ref TreeNode caseBillTree, DateTime fromDate )
        {
            TreeNode alreadyRequestTreeNode = new TreeNode("已经申请入库");
            TreeNode waitAuditingTreeNode = new TreeNode("等待出库审核");
            TreeNode waitConfirmTreeNode = new TreeNode("等待入库确认");

            this.callReturn = this.GetAlreadyRequestTreeNode( ref alreadyRequestTreeNode, fromDate );
            if ( this.callReturn == -1 )
            {
                return -1;
            }

            this.callReturn = this.GetWaitAuditingTreeNode( ref waitAuditingTreeNode, fromDate );
            if ( this.callReturn == -1 )
            {
                return -1;
            }

            this.callReturn = this.GetWaitConfirmTreeNode( ref waitConfirmTreeNode, fromDate );
            if ( this.callReturn == -1 )
            {
                return -1;
            }

            caseBillTree.Nodes.Add( alreadyRequestTreeNode );
            caseBillTree.Nodes.Add( waitAuditingTreeNode );
            caseBillTree.Nodes.Add( waitConfirmTreeNode );

            return 1;
        }

        /// <summary>
        /// 获取已经申请入库的病历出入库单树结点
        /// </summary>
        /// <param name="alreadyRequestTreeNode">树结点</param>
        /// <param name="fromDate">起始日期</param>
        /// <returns>－1－失败，1－成功</returns>
        public int GetAlreadyRequestTreeNode( ref TreeNode alreadyRequestTreeNode, DateTime fromDate )
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( "正在加载已经申请入库树结点..." );

            Application.DoEvents();

            List<Neusoft.FrameWork.Models.NeuObject> alreadyRequestList = new List<Neusoft.FrameWork.Models.NeuObject>();

            this.SetDB( caseBillFunction );
            this.callReturn = caseBillFunction.QueryAlreadyRequestTreeNode( ref alreadyRequestList, this.GetDept(), fromDate, Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InRequest );
            if ( this.callReturn == -1 )
            {
                this.Err = caseBillFunction.Err;
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                return -1;
            }

            foreach ( Neusoft.FrameWork.Models.NeuObject alreadyRequestBill in alreadyRequestList )
            {
                TreeNode node = new TreeNode();

                node.Tag = alreadyRequestBill;
                node.Text = alreadyRequestBill.ID + "(" + alreadyRequestBill.Name + ")";

                alreadyRequestTreeNode.Nodes.Add( node );
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;
        }

        /// <summary>
        /// 获取等待出库审核的病历出入库单树结点
        /// </summary>
        /// <param name="waitAuditingTreeNode">树结点</param>
        /// <param name="fromDate">起始日期</param>
        /// <returns>－1－失败，1－成功</returns>
        public int GetWaitAuditingTreeNode( ref TreeNode waitAuditingTreeNode, DateTime fromDate )
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( "正在加载等待出库审核树结点..." );

            Application.DoEvents();

            List<Neusoft.FrameWork.Models.NeuObject> waitAuditingList = new List<Neusoft.FrameWork.Models.NeuObject>();

            this.SetDB( caseBillFunction );
            this.callReturn = caseBillFunction.QueryWaitAuditingTreeNode( ref waitAuditingList, this.GetDept(), fromDate, Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InRequest );
            if ( this.callReturn == -1 )
            {
                this.Err = caseBillFunction.Err;
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                return -1;
            }

            foreach ( Neusoft.FrameWork.Models.NeuObject waitAuditingBill in waitAuditingList )
            {
                TreeNode node = new TreeNode();

                node.Tag = waitAuditingBill;
                node.Text = waitAuditingBill.ID + "(" + waitAuditingBill.Name + ")";

                waitAuditingTreeNode.Nodes.Add( node );
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;
        }

        /// <summary>
        /// 获取等待入库确认的病历出入库单树结点
        /// </summary>
        /// <param name="waitConfirmTreeNode">树结点</param>
        /// <param name="fromDate">起始日期</param>
        /// <returns>－1－失败，1－成功</returns>
        public int GetWaitConfirmTreeNode( ref TreeNode waitConfirmTreeNode, DateTime fromDate )
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( "正在加载等待入库确认树结点..." );

            Application.DoEvents();

            List<Neusoft.FrameWork.Models.NeuObject> waitConfirmList = new List<Neusoft.FrameWork.Models.NeuObject>();

            this.SetDB( caseBillFunction );
            this.callReturn = caseBillFunction.QueryWaitConfirmTreeNode( ref waitConfirmList, this.GetDept(), fromDate, Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.OutAuditing );
            if ( this.callReturn == -1 )
            {
                this.Err = caseBillFunction.Err;
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                return -1;
            }

            foreach ( Neusoft.FrameWork.Models.NeuObject waitConfirmBill in waitConfirmList )
            {
                TreeNode node = new TreeNode();

                node.Tag = waitConfirmBill;
                node.Text = waitConfirmBill.ID + "(" + waitConfirmBill.Name + ")";

                waitConfirmTreeNode.Nodes.Add( node );
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;
        }

        /// <summary>
        /// 根据单据号码获取病历出库单

        /// </summary>
        /// <param name="caseBillList">出库单</param>
        /// <param name="billCode">单据号码</param>
        /// <returns>－1－失败，1－成功</returns>
        public int QueryCaseBillByBillCode( ref List<Neusoft.HISFC.Models.HealthRecord.Case.CaseBill> caseBillList, string billCode )
        {
            this.SetDB( caseBillFunction );

            return caseBillFunction.QueryByBillCode( ref caseBillList, billCode );
        }

        /// <summary>
        /// 根据病历号获取病历基本信息

        /// </summary>
        /// <param name="caseInfo">病历基本信息</param>
        /// <param name="cardNo">病历号</param>
        /// <returns>－1－失败，0－不存在，1－成功</returns>
        public int GetCaseInfoByCardNo( ref Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInfo, string cardNo )
        {
            this.SetDB( caseInfoFunction );
            return caseInfoFunction.GetCaseInfoByCardNo( ref caseInfo, cardNo );
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="caseBill">单据</param>
        /// <returns>－1－失败，影响的行数</returns>
        public int Update( Neusoft.HISFC.Models.HealthRecord.Case.CaseBill caseBill )
        {
            this.SetDB( caseBillFunction );
            return caseBillFunction.UpdateByID( caseBill );
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="caseBill">单据</param>
        /// <returns>－1－失败，影响的行数</returns>
        public int Delete( Neusoft.HISFC.Models.HealthRecord.Case.CaseBill caseBill )
        {
            this.SetDB( caseBillFunction );
            return caseBillFunction.DeleteByID( caseBill.ID );
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="caseBill">单据</param>
        /// <returns>－1－失败，1－成功</returns>
        public int Insert( Neusoft.HISFC.Models.HealthRecord.Case.CaseBill caseBill )
        {
            this.SetDB( caseBillFunction );
            return caseBillFunction.Insert( caseBill );
        }

        /// <summary>
        /// 获取病历单据号

        /// </summary>
        /// <returns>病历单据号</returns>
        public string GetBillCode()
        {
            this.SetDB( caseBillFunction );
            return caseBillFunction.GetBillCode();
        }

        /// <summary>
        /// 入库确认创建病历跟踪
        /// </summary>
        /// <param name="caseBill">病历单据</param>
        /// <param name="useType">使用类型</param>
        /// <returns>－1－失败，1－成功</returns>
        public int InsertCaseTrackAfterInConfirm( Neusoft.HISFC.Models.HealthRecord.Case.CaseBill caseBill, string useType )
        {
            if ( caseBill.CaseBillState != Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InConfirm )
            {
                this.Err = "病历状态不正确，必须是入库确认状态";

                return -1;
            }

            Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack caseTrack = new Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack();

            caseTrack.PatientCase = caseBill.CaseInfo;
            caseTrack.UseCaseEnv.ID = caseBill.InConfirmOper.ID;
            caseTrack.UseCaseEnv.OperTime = caseBill.InConfirmOper.OperTime;
            caseTrack.UseCaseEnv.Dept.ID = this.GetDept();
            caseTrack.User01 = useType;

            return 1;
        }

        #endregion
    }
}
