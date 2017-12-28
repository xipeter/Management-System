using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Management.Terminal;
using Neusoft.HISFC.Object.Base;
using Neusoft.HISFC.Object.Terminal;
using Controler = Neusoft.HISFC.Management.Manager.Controler;
using Department = Neusoft.HISFC.Management.Manager.Department;
using DeptItem = Neusoft.HISFC.Management.Manager.DeptItem;
using InPatient = Neusoft.HISFC.Management.RADT.InPatient;
using Register = Neusoft.HISFC.Management.Registration.Register;

namespace Neusoft.HISFC.Integrate.Terminal
{
    /// <summary>
    /// Common <br></br>
    /// [功能描述: 医技设备维护]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-08-22]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    
    public class Common : IntegrateBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Common()
        {
        }

        #region 静态变量

        /// <summary>
        /// 医技设备维护业务层
        /// </summary>
        protected static Neusoft.HISFC.Management.Terminal.TerminalCarrier terminalManager = new Neusoft.HISFC.Management.Terminal.TerminalCarrier();

        #endregion

        /// <summary>
        /// 设置事务对象
        /// </summary>
        /// <param name="trans">数据库事务</param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;

            terminalManager.SetTrans(trans);
 
        }

        #region 提供的外部服务

        /// <summary>
        /// 插入医技设备信息
        /// </summary> 
        public int InsertToTerminalCarrier(Neusoft.HISFC.Object.Terminal.TerminalCarrier terminalCarrier)
        {
            this.SetDB(terminalManager);

            return terminalManager.InsertTerminalCarrier(terminalCarrier);
        }

        /// <summary>
        /// 更新医技设备信息
        /// </summary> 
        public int UpdateTerminalCarrier(Neusoft.HISFC.Object.Terminal.TerminalCarrier terminalCarrier)
        {
            this.SetDB(terminalManager);

            return terminalManager.UpdateTerminalCarrier(terminalCarrier);
        }

        /// <summary>
        /// 查询一个医技设备信息
        /// </summary>
        /// <param name="terminal"></param>
        public void GetAllTerminalCarriers(string terminal)
        {
            this.SetDB(terminalManager);

            terminalManager.GetDesigns(terminal);
        }

        /// <summary>
        /// 查询某个科室的医技设备信息
        /// </summary>
        /// <param name="terminal"></param>
        public void GetTerminalCarrier(string terminal)
        {
            this.SetDB(terminalManager);

            terminalManager.GetItem(terminal);
        }

        /// <summary>
        /// 删除医技设备信息
        /// </summary> 
        public int DeleteTerminalCarrier(string ID)
        {
            this.SetDB(terminalManager);

            return terminalManager.DelTerminalCarrier(ID);
        }
  
        #endregion
    }
}
