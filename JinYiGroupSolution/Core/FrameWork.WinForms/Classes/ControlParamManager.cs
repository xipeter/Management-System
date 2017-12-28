using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.WinForms.Classes
{
    /// <summary>
    /// [功能描述: 参数控制业务层]<br></br>
    /// [创 建 者: 张凯钧]<br></br>
    /// [创建时间: 2009-5-5]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class ControlParamManager : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 插入控制参数信息
        /// </summary>
        /// <param name="controlParam"></param>
        /// <returns></returns>
        public int Insert(ControlParam controlParam)
        {
            string sql = "insert into com_controlargument(control_code,control_name,control_value,visible_flag,kind,controltype,controlvalue,oper_code,oper_date) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',TO_DATE('{8}','YYYY-MM-DD HH24:MI:SS'))";

            sql = string.Format(sql, controlParam.ID, controlParam.Name, controlParam.ParamValue, controlParam.ParamState, controlParam.ParamKind, controlParam.ParamControlKind, controlParam.ParamControlValue, controlParam.Oper, controlParam.OperDate);
            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 更新控制参数信息
        /// </summary>
        /// <param name="controlParam"></param>
        /// <returns></returns>
        public int update(ControlParam controlParam)
        {
            string sql = "update com_controlargument t set t.control_name='{1}',t.control_value='{2}',t.visible_flag='{3}',t.kind='{4}',t.controltype='{5}',t.controlvalue='{6}',t.oper_code='{7}',t.oper_date=TO_DATE('{8}','YYYY-MM-DD HH24:MI:SS') where t.control_code='{0}'  ";

            sql = string.Format(sql, controlParam.ID, controlParam.Name, controlParam.ParamValue, controlParam.ParamState, controlParam.ParamKind, controlParam.ParamControlKind, controlParam.ParamControlValue, controlParam.Oper, controlParam.OperDate);
            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 删除控制参数信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(string ID)
        {
            string sql = "delete from com_controlargument t where  t.control_code='{0}' ";
            sql = string.Format(sql, ID);
            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 判断主键是不是唯一；是0，否-1；
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int JudgeOnly(string ID)
        {
            string sql = "select t.* from com_controlargument t where t.control_code='{0}' ";
            sql = string.Format(sql, ID);
            int ret = this.ExecQuery(sql);
            return ret;
        }

        /// <summary>
        /// 查询所有的参数信息
        /// </summary>
        /// <returns></returns>
        public List<ControlParam> Query()
        {
            string sql = "select t.control_code,t.control_name,t.control_value,t.visible_flag,kind,t.controltype,t.controlvalue,t.oper_code,t.oper_date from com_controlargument t  ";
            int ret = this.ExecQuery(sql);
            if (ret == -1) return null;
            return GetEnity(this.Reader);
        }

        /// <summary>
        /// 查询指定参数模块的参数信息
        /// </summary>
        /// <param name="parmType">参数分类</param>
        /// <returns></returns>
        public List<ControlParam> QueryByType(string parmType)
        {
            string sql = "select t.control_code,t.control_name,t.control_value,t.visible_flag,kind,t.controltype,t.controlvalue,t.oper_code,t.oper_date from com_controlargument t where t.kind='{0}' ";
            int ret = this.ExecQuery(sql, parmType);
            if (ret == -1) return null;
            return GetEnity(this.Reader);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="ID">参数ID</param>
        /// <returns></returns>
        public List<ControlParam> QueryByID(string ID)
        {
            string sql = "select t.control_code,t.control_name,t.control_value,t.visible_flag,kind,t.controltype,t.controlvalue,t.oper_code,t.oper_date from com_controlargument t where t.control_code='{0}' ";
            
            int ret = this.ExecQuery(sql, ID);
            if (ret == -1) return null;
            return GetEnity(this.Reader);
        }

        /// <summary>
        /// 为参数列表赋值
        /// </summary>
        /// <param name="commonReader"></param>
        /// <returns></returns>
        private List<ControlParam> GetEnity(System.Data.IDataReader commonReader)
        {
            List<ControlParam> newList = new List<ControlParam>();
            while (commonReader.Read())
            {
                ControlParam controlParam = new ControlParam();
                controlParam.ID = commonReader[0].ToString();
                controlParam.Name = commonReader[1].ToString();
                controlParam.ParamValue = commonReader[2].ToString();
                controlParam.ParamState = commonReader[3].ToString();
                controlParam.ParamKind = commonReader[4].ToString();
                controlParam.ParamControlKind = commonReader[5].ToString();
                controlParam.ParamControlValue = commonReader[6].ToString();
                controlParam.Oper = commonReader[7].ToString();
                controlParam.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(commonReader[8].ToString());
                newList.Add(controlParam);
            }

            return newList;
        }
    }
}
