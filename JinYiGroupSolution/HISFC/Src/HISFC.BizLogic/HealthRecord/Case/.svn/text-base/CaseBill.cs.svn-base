using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.HealthRecord.Case
{
    /// <summary>
    /// CaseBill<br></br>
    /// [功能描述: 病历出库单]<br></br>
    /// [创 建 者: 赫一阳]<br></br>
    /// [创建时间: 2007-09-14]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class CaseBill : Neusoft.FrameWork.Management.Database
    {
        #region 变量

        /// <summary>
        /// 返回值
        /// </summary>
        int intReturn = -1;

        /// <summary>
        /// 字段数组
        /// </summary>
        string [] field = new string [26];

        #endregion

        #region 私有方法

        /// <summary>
        /// 转换实体为字段数组
        /// </summary>
        /// <param name="caseBill">病历出库单实体</param>
        /// <returns>－1－失败，1－成功</returns>
        private int ConvertEntityToArray( HISFC.Models.HealthRecord.Case.CaseBill caseBill )
        {
            try
            {
                #region 赋值

                // 唯一主键
                if ( caseBill.ID == null || caseBill.ID == "" )
                {
                    caseBill.ID = this.GetSequence( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.GetSequence" );
                }
                field [0] = caseBill.ID;
                // 出库单号码，一个单据可以包括多个病历
                field [1] = caseBill.BillCode;
                // 入库申请人工号
                field [2] = caseBill.InRequestOper.ID;
                // 入库申请科室编码
                field [3] = caseBill.InRequestOper.Dept.ID;
                // 入库申请病区编码
                field [4] = caseBill.InRequestNurse.ID;
                // 入库申请时间
                field [5] = caseBill.InRequestOper.OperTime.ToString();
                // 入库申请分区编码
                field [6] = caseBill.InRequestPartition.ID;
                // 出库审核人工号
                field [7] = caseBill.OutAuditingOper.ID;
                // 出库审核科室编码
                field [8] = caseBill.OutAuditingOper.Dept.ID;
                // 出库审核病区编码
                field [9] = caseBill.OutAuditingNurse.ID;
                // 出库审核时间
                field [10] = caseBill.OutAuditingOper.OperTime.ToString();
                // 入库确认人工号
                field [11] = caseBill.InConfirmOper.ID;
                // 入库确认时间
                field [12] = caseBill.InConfirmOper.OperTime.ToString();
                // 单据类型、出库类型，对应常数表的CASE01
                field [13] = caseBill.BillType.ID;
                // 发送人工号
                field [14] = caseBill.SendOper.ID;
                // 发送时间
                field [15] = caseBill.SendOper.OperTime.ToString();
                // 接收人工号
                field [16] = caseBill.ReceiveOper.ID;
                // 接收时间
                field [17] = caseBill.ReceiveOper.OperTime.ToString();
                // 是否已经接收：1－是、0－否
                if ( caseBill.IsReceive )
                {
                    field [18] = "1";
                }
                else
                {
                    field [18] = "0";
                }
                // 病历唯一ID
                field [19] = caseBill.CaseInfo.ID.ToString();
                // 单据状态：0－入库申请、1－出库审核、2、入库确认
                field [20] = ( (int)caseBill.CaseBillState ).ToString();
                // 该申请的病历是否被发送：1－是、0－否
                if ( caseBill.IsSend )
                {
                    field [21] = "1";
                }
                else
                {
                    field [21] = "0";
                }
                // 申请的目标科室：可以是病区、科室——病历所在科室
                field [22] = caseBill.FromDept.ID;
                // 扩展
                field [23] = caseBill.User01;
                field [24] = caseBill.User02;
                field [25] = caseBill.User03;

                #endregion
            }
            catch ( Exception exception )
            {
                this.Err = "插入数据库转换字段数组失败" + exception.Message;

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 转换Reader为实体
        /// </summary>
        /// <param name="caseBill">病历出库单实体</param>
        /// <returns>－1－失败，1－成功</returns>
        private int ConvertReaderToObject( ref HISFC.Models.HealthRecord.Case.CaseBill caseBill )
        {
            try
            {
                #region 赋值

                // 唯一主键
                caseBill.ID = this.Reader[0].ToString();
                // 出库单号码，一个单据可以包括多个病历
                caseBill.BillCode = this.Reader [1].ToString();
                // 入库申请人工号
                caseBill.InRequestOper.ID = this.Reader [2].ToString();
                caseBill.InRequestOper.Name = this.Reader [3].ToString();
                // 入库申请科室编码
                caseBill.InRequestOper.Dept.ID = this.Reader[4].ToString();
                caseBill.InRequestOper.Dept.Name = this.Reader [5].ToString();
                // 入库申请病区编码
                caseBill.InRequestNurse.ID = this.Reader[6].ToString();
                caseBill.InRequestNurse.Name = this.Reader [7].ToString();
                // 入库申请时间
                caseBill.InRequestOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader [8].ToString());
                // 入库申请分区编码
                caseBill.InRequestPartition.ID = this.Reader[9].ToString();
                caseBill.InRequestPartition.Name = this.Reader [10].ToString();
                // 出库审核人工号
                caseBill.OutAuditingOper.ID = this.Reader[11].ToString();
                caseBill.OutAuditingOper.Name = this.Reader [12].ToString();
                // 出库审核科室编码
                caseBill.OutAuditingOper.Dept.ID = this.Reader[13].ToString();
                caseBill.OutAuditingOper.Dept.Name = this.Reader [14].ToString();
                // 出库审核病区编码
                caseBill.OutAuditingNurse.ID = this.Reader[15].ToString();
                caseBill.OutAuditingNurse.Name = this.Reader [16].ToString();
                // 出库审核时间
                caseBill.OutAuditingOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[17].ToString());
                // 入库确认人工号
                caseBill.InConfirmOper.ID = this.Reader[18].ToString();
                caseBill.InConfirmOper.Name = this.Reader [19].ToString();
                // 入库确认时间
                caseBill.InConfirmOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[20].ToString());
                // 单据类型、出库类型，对应常数表的CASE01
                caseBill.BillType.ID = this.Reader[21].ToString();
                caseBill.BillType.Name = this.Reader [22].ToString();
                // 发送人工号
                caseBill.SendOper.ID = this.Reader[23].ToString();
                caseBill.SendOper.Name = this.Reader [24].ToString();
                // 发送时间
                caseBill.SendOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[25].ToString());
                // 接收人工号
                caseBill.ReceiveOper.ID = this.Reader[26].ToString();
                caseBill.ReceiveOper.Name = this.Reader [27].ToString();
                // 接收时间
                caseBill.ReceiveOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[28].ToString());
                // 是否已经接收：1－是、0－否
                if ( this.Reader [29].ToString() == "1" )
                {
                    caseBill.IsReceive = true;
                }
                else
                {
                    caseBill.IsReceive = false;
                }
                // 病历唯一ID
                caseBill.CaseInfo.ID = this.Reader[30].ToString();
                caseBill.CaseInfo.Patient.PID.CardNO = this.Reader [31].ToString();
                caseBill.CaseInfo.Patient.Name = this.Reader [32].ToString();
                caseBill.CaseInfo.Patient.Sex.ID = this.Reader [33].ToString();
                caseBill.CaseInfo.Patient.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader [34].ToString());
                // 单据状态：0－入库申请、1－出库审核、2、入库确认
                switch ( this.Reader [35].ToString() )
                {
                    case "0":
                        caseBill.CaseBillState = Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InRequest;
                        break;
                    case "1":
                        caseBill.CaseBillState = Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.OutAuditing;
                        break;
                    case "2":
                        caseBill.CaseBillState = Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InConfirm;
                        break;
                }
                // 该申请的病历是否被发送：1－是、0－否
                if ( this.Reader [36].ToString() == "1" )
                {
                    caseBill.IsSend = true;
                }
                else
                {
                    caseBill.IsSend = false;
                }
                // 申请的病历所在科室或病区
                caseBill.FromDept.ID = this.Reader [37].ToString();
                caseBill.FromDept.Name = this.Reader [38].ToString();
                // 扩展
                caseBill.User01 = this.Reader [39].ToString();
                caseBill.User02 = this.Reader [40].ToString();
                caseBill.User03 = this.Reader [41].ToString();
                // 病历状态
                caseBill.CaseInfo.CaseState.Name = this.Reader [42].ToString();
                // 所在类型
                caseBill.CaseInfo.InType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[43].ToString());
                caseBill.CaseInfo.InDept.ID = this.Reader [44].ToString();
                caseBill.CaseInfo.InDept.Name = this.Reader [45].ToString();
                caseBill.CaseInfo.InEmployee.ID = this.Reader [46].ToString();
                caseBill.CaseInfo.InEmployee.Name = this.Reader [47].ToString();

                #endregion
            }
            catch ( Exception exception )
            {
                this.Err = "转换Reader为出库单实体出错" + exception.Message;

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 转换Reader为病历出库单实体数组
        /// </summary>
        /// <param name="caseBillList">病历出库单实体数组</param>
        /// <returns>－1－失败，1－成功</returns>
        private int ConvertReaderToArrayList( ref List<HISFC.Models.HealthRecord.Case.CaseBill> caseBillList )
        {
            try
            {
                while ( this.Reader.Read() )
                {
                    HISFC.Models.HealthRecord.Case.CaseBill caseBill = new Neusoft.HISFC.Models.HealthRecord.Case.CaseBill();

                    this.intReturn = this.ConvertReaderToObject( ref caseBill );
                    if ( this.intReturn == -1 )
                    {
                        return -1;
                    }

                    caseBillList.Add( caseBill );
                }
            }
            catch ( Exception exception )
            {
                this.Err = "转换Reader为病历出库单实体数组失败" + exception.Message;

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="caseBill">病历出库单</param>
        /// <returns>－1－失败，影响的行数</returns>
        private int Delete( string deleteCondition )
        {
            string deleteSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.Delete", ref deleteSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "删除病历出库单失败" + this.Err;
                return -1;
            }

            deleteSql = deleteSql + " " + deleteCondition;

            this.intReturn = this.ExecNoQuery( deleteSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "删除病历出库单失败" + this.Err;
                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 更新出库单记录
        /// </summary>
        /// <param name="caseBill">病历出库单</param>
        /// <param name="updateCondition">更新条件</param>
        /// <returns>－1－失败，影响的行数</returns>
        private int Update( HISFC.Models.HealthRecord.Case.CaseBill caseBill, string updateCondition )
        {
            string updateSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.Update", ref updateSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "更新病历出库单失败" + this.Err;
                return -1;
            }

            this.intReturn = this.ConvertEntityToArray( caseBill );
            if ( this.intReturn == -1 )
            {
                return -1;
            }

            try
            {
                updateSql = string.Format( updateSql, field );
            }
            catch ( Exception exception )
            {
                this.Err = "更新病历出库单失败" + exception.Message;

                return -1;
            }

            updateSql = updateSql + " " + updateCondition;

            this.intReturn = this.ExecNoQuery( updateSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "更新病历出库单失败" + this.Err;
                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="caseBillList">病历出库单数组</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>－1－失败，1－成功</returns>
        private int Select( List<HISFC.Models.HealthRecord.Case.CaseBill> caseBillList, string selectCondition )
        {
            string selectSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.Select", ref selectSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "查询病历出库单失败" + this.Err;
                return -1;
            }

            selectSql = selectSql + " " + selectCondition;

            this.intReturn = this.ExecQuery( selectSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "查询病历出库单失败" + this.Err;
                return -1;
            }

            return this.ConvertReaderToArrayList( ref caseBillList );
        }

        #endregion

        #region 数据库操作

        /// <summary>
        /// 插入数据库
        /// </summary>
        /// <param name="caseBill">病历出库单</param>
        /// <returns>－1－失败，1－成功</returns>
        public int Insert( HISFC.Models.HealthRecord.Case.CaseBill caseBill )
        {
            string insertSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.Insert", ref insertSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "插入病历出库单失败" + this.Err;
                return -1;
            }

            this.intReturn = this.ConvertEntityToArray( caseBill );
            if ( this.intReturn == -1 )
            {
                return -1;
            }

            try
            {
                insertSql = string.Format( insertSql, this.field);
            }
            catch ( Exception exception)
            {
                this.Err = "插入病历出库单失败（匹配SQL参数失败）" + exception.Message;
                return -1;
            }

            this.intReturn = this.ExecNoQuery( insertSql );
            if ( this.intReturn <= 0 )
            {
                this.Err = "插入病历出库单失败" + this.Err;
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 根据出库单流水主键删除
        /// </summary>
        /// <param name="id">出库单流水主键</param>
        /// <returns>－1－失败，影响的行数</returns>
        public int DeleteByID( string id )
        {
            string deleteSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.ID", ref deleteSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "删除病历出库单失败" + this.Err;
                return -1;
            }

            try
            {
                deleteSql = string.Format( deleteSql, id );
            }
            catch( Exception exception)
            {
                this.Err = "删除病历出库单失败" + exception;

                return -1;
            }

            return this.Delete( deleteSql );
        }

        /// <summary>
        /// 根据流水主键更新出库单记录
        /// </summary>
        /// <param name="caseBill">流水主键</param>
        /// <returns>－1－失败，影响的行数</returns>
        public int UpdateByID( HISFC.Models.HealthRecord.Case.CaseBill caseBill)
        {
            string updateSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.ID", ref updateSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "更新病历出库单失败" + this.Err;
                return -1;
            }

            try
            {
                updateSql = string.Format( updateSql, caseBill.ID );
            }
            catch ( Exception exception )
            {
                this.Err = "更新病历出库单失败" + exception.Message;

                return -1;
            }

            return this.Update( caseBill, updateSql );
        }

        #endregion

        #region 查询

        /// <summary>
        /// 根据出库单号查询病历出库单
        /// </summary>
        /// <param name="caseBillList">病历出库单</param>
        /// <param name="billCode">出库单号</param>
        /// <returns>－1－失败，1－成功</returns>
        public int QueryByBillCode( ref List<HISFC.Models.HealthRecord.Case.CaseBill> caseBillList, string billCode )
        {
            string whereSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.SelectByBillCode", ref whereSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "根据出库单号查询病历出库单失败" + this.Err;
                return -1;
            }

            try
            {
                whereSql = string.Format( whereSql, billCode );
            }
            catch ( Exception exception )
            {
                this.Err = "根据出库单号查询病历出库单失败" + exception.Message;

                return -1;
            }

            return this.Select( caseBillList, whereSql );
        }

        /// <summary>
        /// 根据当前科室编码、申请日期获取已经申请入库的单据
        /// </summary>
        /// <param name="caseBillList">病历出库单数组</param>
        /// <param name="deptCode">科室编码</param>
        /// <param name="fromDate">起始时间</param>
        /// <param name="caseBillState">病历出库单状态</param>
        /// <returns>－1－失败，1－成功</returns>
        public int QueryAlreadyRequest( ref List<HISFC.Models.HealthRecord.Case.CaseBill> caseBillList, string deptCode, DateTime fromDate,
            HISFC.Models.HealthRecord.Case.EnumCaseBillState caseBillState )
        {
            string whereSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.QueryAlreadyRequest", ref whereSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "查询已经申请入库的病历出库单失败" + this.Err;
                return -1;
            }

            try
            {
                whereSql = string.Format( whereSql, deptCode, fromDate.ToString(), ((int)caseBillState).ToString() );
            }
            catch ( Exception exception )
            {
                this.Err = "查询已经申请入库的病历出库单失败" + exception.Message;

                return -1;
            }

            return this.Select( caseBillList, whereSql );
        }

        /// <summary>
        /// 根据当前科室编码、申请日期获取等待出库确认的单据
        /// </summary>
        /// <param name="caseBillList">病历出库单数组</param>
        /// <param name="deptCode">科室编码</param>
        /// <param name="fromDate">起始时间</param>
        /// <param name="caseBillState">病历出库单状态</param>
        /// <returns>－1－失败，1－成功</returns>
        public int QueryWaitAuditing( ref List<HISFC.Models.HealthRecord.Case.CaseBill> caseBillList, string deptCode, DateTime fromDate,
            HISFC.Models.HealthRecord.Case.EnumCaseBillState caseBillState )
        {
            string whereSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.QueryWaitAuditing", ref whereSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "查询等待出库确认的病历出库单失败" + this.Err;
                return -1;
            }

            try
            {
                whereSql = string.Format( whereSql, deptCode, fromDate.ToString(), ( (int)caseBillState ).ToString() );
            }
            catch ( Exception exception )
            {
                this.Err = "查询等待出库确认的病历出库单失败" + exception.Message;

                return -1;
            }

            return this.Select( caseBillList, whereSql );
        }

        /// <summary>
        /// 根据当前科室编码、申请日期获取等待入库确认的单据
        /// </summary>
        /// <param name="caseBillList">病历出库单数组</param>
        /// <param name="deptCode">科室编码</param>
        /// <param name="fromDate">起始时间</param>
        /// <param name="caseBillState">病历出库单状态</param>
        /// <returns>－1－失败，1－成功</returns>
        public int QueryWaitConfirm( ref List<HISFC.Models.HealthRecord.Case.CaseBill> caseBillList, string deptCode, DateTime fromDate,
            HISFC.Models.HealthRecord.Case.EnumCaseBillState caseBillState )
        {
            string whereSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.QueryWaitConfirm", ref whereSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "查询等待入库确认的病历出库单失败" + this.Err;
                return -1;
            }

            try
            {
                whereSql = string.Format( whereSql, deptCode, fromDate.ToString(), ( (int)caseBillState ).ToString() );
            }
            catch ( Exception exception )
            {
                this.Err = "查询等待入库确认的病历出库单失败" + exception.Message;

                return -1;
            }

            return this.Select( caseBillList, whereSql );
        }

        /// <summary>
        /// 根据当前科室编码、申请日期获取已经申请入库的单据树结点
        /// </summary>
        /// <param name="caseBillList">单据树结点</param>
        /// <param name="deptCode">科室编码</param>
        /// <param name="fromDate">起始时间</param>
        /// <param name="caseBillState">病历出库单状态</param>
        /// <returns>－1－失败，1－成功</returns>
        public int QueryAlreadyRequestTreeNode( ref List<Neusoft.FrameWork.Models.NeuObject> caseBillList, string deptCode, DateTime fromDate,
            HISFC.Models.HealthRecord.Case.EnumCaseBillState caseBillState )
        {
            string whereSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.QueryAlreadyRequestTreeNode", ref whereSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "查询已经申请入库的病历出库单失败" + this.Err;
                return -1;
            }

            try
            {
                whereSql = string.Format( whereSql, ( (int)caseBillState ).ToString(), deptCode, fromDate.ToString() );

                this.intReturn = this.ExecQuery( whereSql );
                if ( this.intReturn == -1 )
                {
                    this.Err = "查询已经申请入库的病历出库单失败" + this.Err;

                    return -1;
                }

                while ( this.Reader.Read() )
                {
                    Neusoft.FrameWork.Models.NeuObject node = new Neusoft.FrameWork.Models.NeuObject();

                    // 出库单号码
                    node.ID = this.Reader [0].ToString();
                    // 包含病历个数
                    node.Name = this.Reader [1].ToString();

                    caseBillList.Add( node );
                }
            }
            catch ( Exception exception )
            {
                this.Err = "查询已经申请入库的病历出库单失败" + exception.Message;

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 根据当前科室编码、申请日期获取等待出库审核的单据树结点
        /// </summary>
        /// <param name="caseBillList">单据树结点</param>
        /// <param name="deptCode">科室编码</param>
        /// <param name="fromDate">起始时间</param>
        /// <param name="caseBillState">病历出库单状态</param>
        /// <returns>－1－失败，1－成功</returns>
        public int QueryWaitAuditingTreeNode( ref List<Neusoft.FrameWork.Models.NeuObject> caseBillList, string deptCode, DateTime fromDate,
            HISFC.Models.HealthRecord.Case.EnumCaseBillState caseBillState )
        {
            string whereSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.QueryWaitAuditingTreeNode", ref whereSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "查询等待出库审核的病历出库单失败" + this.Err;
                return -1;
            }

            try
            {
                whereSql = string.Format( whereSql, ( (int)caseBillState ).ToString(), deptCode, fromDate.ToString() );

                this.intReturn = this.ExecQuery( whereSql );
                if ( this.intReturn == -1 )
                {
                    this.Err = "查询等待出库审核的病历出库单失败" + this.Err;

                    return -1;
                }

                while ( this.Reader.Read() )
                {
                    Neusoft.FrameWork.Models.NeuObject node = new Neusoft.FrameWork.Models.NeuObject();

                    // 出库单号码
                    node.ID = this.Reader [0].ToString();
                    // 包含病历个数
                    node.Name = this.Reader [1].ToString();

                    caseBillList.Add( node );
                }
            }
            catch ( Exception exception )
            {
                this.Err = "查询已经申请入库的病历出库单失败" + exception.Message;

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 根据当前科室编码、申请日期获取等待入库确认的单据树结点
        /// </summary>
        /// <param name="caseBillList">单据树结点</param>
        /// <param name="deptCode">科室编码</param>
        /// <param name="fromDate">起始时间</param>
        /// <param name="caseBillState">病历出库单状态</param>
        /// <returns>－1－失败，1－成功</returns>
        public int QueryWaitConfirmTreeNode( ref List<Neusoft.FrameWork.Models.NeuObject> caseBillList, string deptCode, DateTime fromDate,
            HISFC.Models.HealthRecord.Case.EnumCaseBillState caseBillState )
        {
            string whereSql = string.Empty;

            intReturn = this.Sql.GetSql( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.QueryWaitConfirmTreeNode", ref whereSql );
            if ( this.intReturn < 0 )
            {
                this.Err = "查询等待入库确认的病历出库单失败" + this.Err;
                return -1;
            }

            try
            {
                whereSql = string.Format( whereSql, ( (int)caseBillState ).ToString(), deptCode, fromDate.ToString() );

                this.intReturn = this.ExecQuery( whereSql );
                if ( this.intReturn == -1 )
                {
                    this.Err = "查询等待入库确认的病历出库单失败" + this.Err;

                    return -1;
                }

                while ( this.Reader.Read() )
                {
                    Neusoft.FrameWork.Models.NeuObject node = new Neusoft.FrameWork.Models.NeuObject();

                    // 出库单号码
                    node.ID = this.Reader [0].ToString();
                    // 包含病历个数
                    node.Name = this.Reader [1].ToString();

                    caseBillList.Add( node );
                }
            }
            catch ( Exception exception )
            {
                this.Err = "查询已经申请入库的病历出库单失败" + exception.Message;

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 获取单据号
        /// </summary>
        /// <returns>单据号</returns>
        public string GetBillCode()
        {
            return this.GetSequence( "Neusoft.HISFC.Management.HealthRecord.Case.CaseBill.GetBillCode" );
        }

        #endregion
    }
}
