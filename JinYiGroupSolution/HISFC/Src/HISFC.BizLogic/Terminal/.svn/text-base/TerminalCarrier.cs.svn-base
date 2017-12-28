using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Terminal
{

    /// <summary>
    /// [功能描述: 医技设备维护]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-8-20]<br></br> 
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class TerminalCarrier : Neusoft.FrameWork.Management.Database
    {
  
        /// <summary>
        /// 插入医技设备信息
        /// </summary>
        /// <param name="terminalCarrier"></param>
        /// <returns></returns>         
        public int InsertTerminalCarrier(Neusoft.HISFC.Models.Terminal.TerminalCarrier terminalCarrier)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Met.InsertMedTerminalCarrier", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.GetTerminalCarrierParam(terminalCarrier);   //取参数列表

                strSQL = string.Format(strSQL, strParm);                //替换SQL语句中的参数。

            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        
        /// <summary>
        /// 根据实体信息获取Insert或Update语句参数数组
        /// </summary>
        /// <param name="terminalCarrier"></param>
        /// <returns></returns>
        private string[] GetTerminalCarrierParam(Neusoft.HISFC.Models.Terminal.TerminalCarrier terminalCarrier)
        {
            string[] strParam = new string[] { 
                terminalCarrier.Dept.ID,
                terminalCarrier.CarrierCode,
                terminalCarrier.CarrierName,
                terminalCarrier.CarrierType,
                terminalCarrier.CarrierMemo,
                terminalCarrier.SpellCode,
                terminalCarrier.WBCode,
                terminalCarrier.UserCode,
                terminalCarrier.Model,
                terminalCarrier.IsDisengaged,
                terminalCarrier.DisengagedTime.ToString(),
                terminalCarrier.DayQuota.ToString(),
                terminalCarrier.DoctorQuota.ToString(),
                terminalCarrier.SelfQuota.ToString(),
                terminalCarrier.WebQuota.ToString(),
                terminalCarrier.Building,
                terminalCarrier.Floor,
                terminalCarrier.Room,
                terminalCarrier.SortId.ToString(),
                terminalCarrier.IsPrestopTime.ToString(),
                terminalCarrier.PreStopTime.ToString(),
                terminalCarrier.PreStartTime.ToString(),
                terminalCarrier.AvgTurnoverTime.ToString(),
                terminalCarrier.CreateOper.ToString(),
                terminalCarrier.CreateTime.ToString(),
                terminalCarrier.IsValid,
                terminalCarrier.InvalidOper.ID,
                terminalCarrier.InvalidOper.OperTime.ToString(),
                terminalCarrier.ValidOper.ID,
                terminalCarrier.ValidOper.OperTime.ToString(),
                terminalCarrier.DeviceType                                     
                                             };

            return strParam;
        }


        /// <summary>
        /// 根据实体信息获取Insert或Update语句参数数组
        /// </summary>
        /// <param name="terminalCarrier"></param>
        /// <returns></returns>
        private string[] GetTerminalCarrierParam2(Neusoft.HISFC.Models.Terminal.TerminalCarrier terminalCarrier)
        {
            string[] strParam = new string[] { 
 
                terminalCarrier.ValidOper.OperTime.ToString(), 
                terminalCarrier.CarrierCode,
                terminalCarrier.CarrierName,
                terminalCarrier.CarrierType,
                terminalCarrier.CarrierMemo,
                terminalCarrier.SpellCode,
                terminalCarrier.WBCode,
                terminalCarrier.UserCode,
                terminalCarrier.Model,
                terminalCarrier.IsDisengaged,
                terminalCarrier.DisengagedTime.ToString(),
                terminalCarrier.DayQuota.ToString(),
                terminalCarrier.DoctorQuota.ToString(),
                terminalCarrier.SelfQuota.ToString(),
                terminalCarrier.WebQuota.ToString(),
                terminalCarrier.Building,
                terminalCarrier.Floor,
                terminalCarrier.Room,
                terminalCarrier.SortId.ToString(),
                terminalCarrier.IsPrestopTime.ToString(),
                terminalCarrier.PreStopTime.ToString(),
                terminalCarrier.PreStartTime.ToString(),
                terminalCarrier.AvgTurnoverTime.ToString(),
                terminalCarrier.CreateOper.ToString(),
                terminalCarrier.CreateTime.ToString(),
                terminalCarrier.IsValid,
                terminalCarrier.InvalidOper.ID,
                terminalCarrier.InvalidOper.OperTime.ToString(),
                terminalCarrier.ValidOper.ID,
                terminalCarrier.DeviceType                     //{FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD}                        
                                             };

            return strParam;
        }

        /// <summary>
        /// 更新医技设备信息
        /// </summary>
        /// <param name="terminalCarrier"></param>
        /// <returns></returns>
        public int UpdateTerminalCarrier(Neusoft.HISFC.Models.Terminal.TerminalCarrier terminalCarrier)
        {
            string strSQL = "";
            //更新取药科室信息
            if (this.Sql.GetSql("Met.UpdateMedTerminalCarrier", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Met.UpdateMedTerminalCarrier";
                return -1;
            }
            try
            {
                string[] strParm = this.GetTerminalCarrierParam2(terminalCarrier);   //取参数列表 
                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。

            }
            catch (Exception ex)
            {
                this.Err = "更新出库记录的SQl参数赋值时出错！Met.UpdateMedTerminalCarrier" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除医技设备信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DelTerminalCarrier(string ID)
        {
            string strSQL = "";
            //根据药房/药库编号删除取药科室的DELETE语句
            if (this.Sql.GetSql("Met.DeleteMedTerminalCarrier", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Met.DeleteMedTerminalCarrier";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, ID);
            }
            catch
            {
                this.Err = "数据删除出错！Met.DeleteMedTerminalCarrier";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }      

        /// <summary>
        /// 根据所选科室查医技设备信息
        /// </summary>
        /// <param name="terminal"></param>
        /// <returns>医技设备信息集合</returns>
        public ArrayList GetDesigns(string terminal)
        {
            string strSQL = null;
            string strWhere = null;

            if (this.Sql.GetSql("Met.QueryMedTerminalCarrier", ref strSQL) == -1)
            {
                this.Err = "SQL语句出错!";

                return null;
            }

            if (this.Sql.GetSql("Met.QueryMedTerminalCarrier.Where1", ref strWhere) == -1)
            {
                this.Err = "SQL语句出错!";

                return null;
            }

            try
            {
                strSQL = string.Format(strSQL + strWhere, terminal);
            }
            catch { }

            return GetComponentDetail(strSQL);
        }

        /// <summary>
        /// 根据所选科室查医技设备信息
        /// </summary>
        /// <param name="terminal"></param>
        /// <returns>医技设备信息集合</returns>
        public Neusoft.HISFC.Models.Terminal.TerminalCarrier GetItem(string terminal, string deptCode)
        {
            string strSQL = null;
            string strWhere = null;

            if (this.Sql.GetSql("Met.QueryMedTerminalCarrier", ref strSQL) == -1)
            {
                this.Err = "SQL语句出错!";

                return null;
            }

            if (this.Sql.GetSql("Met.QueryMedTerminalCarrier.Where2", ref strWhere) == -1)
            {
                this.Err = "SQL语句出错!";

                return null;
            }

            try
            {
                strSQL = string.Format(strSQL + strWhere, terminal, deptCode);
            }
            catch { }

            return GetComponentDetail2(strSQL);
        }

        /// <summary>
        /// 读取医技设备基本信息 
        /// </summary>
        /// <param name="strSQL">查询SQL语句</param>
        /// <returns>符合条件的数据集</returns>
        private Neusoft.HISFC.Models.Terminal.TerminalCarrier GetComponentDetail2(string strSQL)
        {

            Neusoft.HISFC.Models.Terminal.TerminalCarrier terminal = null;
            try
            {
                if (this.ExecQuery(strSQL) == -1)
                {
                    return null;
                }

                while (this.Reader.Read())
                {
                    terminal = new Neusoft.HISFC.Models.Terminal.TerminalCarrier();

                    terminal.Dept.ID = this.Reader[0].ToString();
                    terminal.CarrierCode = this.Reader[1].ToString();
                    terminal.CarrierName = this.Reader[2].ToString();
                    terminal.CarrierType = this.Reader[3].ToString();
                    terminal.CarrierMemo = this.Reader[4].ToString();
                    terminal.SpellCode = this.Reader[5].ToString();
                    terminal.WBCode = this.Reader[6].ToString();
                    terminal.UserCode = this.Reader[7].ToString();
                    terminal.Model = this.Reader[8].ToString();
                    terminal.IsDisengaged = this.Reader[9].ToString();
                    terminal.DisengagedTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());
                    terminal.DayQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[11].ToString());
                    terminal.DoctorQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12].ToString());
                    terminal.SelfQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[13].ToString());
                    terminal.WebQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[14].ToString());
                    terminal.Building = this.Reader[15].ToString();
                    terminal.Floor = this.Reader[16].ToString();
                    terminal.Room = this.Reader[17].ToString();
                    terminal.SortId = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[18].ToString());
                    terminal.IsPrestopTime = this.Reader[19].ToString();
                    terminal.PreStopTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[20].ToString());
                    terminal.PreStartTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[21].ToString());
                    terminal.AvgTurnoverTime = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[22].ToString());
                    terminal.CreateOper = this.Reader[23].ToString();
                    terminal.CreateTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[24].ToString());
                    terminal.IsValid = this.Reader[25].ToString();
                    terminal.DeviceType = this.Reader[26].ToString();
                }

                return terminal;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                terminal = null;
                return null;
            }
            finally
            {
                this.Reader.Close();
                terminal = null;
            }
        }

        /// <summary>
        /// 读取医技设备基本信息 
        /// </summary>
        /// <param name="strSQL">查询SQL语句</param>
        /// <returns>符合条件的数据集</returns>
        private ArrayList GetComponentDetail(string strSQL)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Terminal.TerminalCarrier terminal = null;
            try
            {
                if (this.ExecQuery(strSQL) == -1)
                {
                    return null;
                }

                while (this.Reader.Read())
                {
                    terminal = new Neusoft.HISFC.Models.Terminal.TerminalCarrier();

                    terminal.Dept.ID = this.Reader[0].ToString();
                    terminal.CarrierCode = this.Reader[1].ToString();
                    terminal.CarrierName = this.Reader[2].ToString();
                    terminal.CarrierType = this.Reader[3].ToString();
                    terminal.CarrierMemo = this.Reader[4].ToString();
                    terminal.SpellCode = this.Reader[5].ToString();
                    terminal.WBCode = this.Reader[6].ToString();
                    terminal.UserCode = this.Reader[7].ToString();
                    terminal.Model = this.Reader[8].ToString();
                    terminal.IsDisengaged = this.Reader[9].ToString();
                    terminal.DisengagedTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());
                    terminal.DayQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[11].ToString());
                    terminal.DoctorQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12].ToString());
                    terminal.SelfQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[13].ToString());
                    terminal.WebQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[14].ToString());
                    terminal.Building = this.Reader[15].ToString();
                    terminal.Floor = this.Reader[16].ToString();
                    terminal.Room = this.Reader[17].ToString();
                    terminal.SortId = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[18].ToString());
                    terminal.IsPrestopTime = this.Reader[19].ToString();
                    terminal.PreStopTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[20].ToString());
                    terminal.PreStartTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[21].ToString());
                    terminal.AvgTurnoverTime = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[22].ToString());
                    terminal.CreateOper = this.Reader[23].ToString();
                    terminal.CreateTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[24].ToString());
                    terminal.IsValid = this.Reader[25].ToString();
                    terminal.DeviceType = this.Reader[26].ToString();
                    al.Add(terminal);
                }

                return al;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                al = null;
                terminal = null;
                return null;
            }
            finally
            {
                this.Reader.Close();
                al = null;
                terminal = null;
            }
        }
    }
}
