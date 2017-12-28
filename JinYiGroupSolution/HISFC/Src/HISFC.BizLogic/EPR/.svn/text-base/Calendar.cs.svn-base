using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
/// <summary>
/// Bank<br></br>
/// [功能描述: 日程管理类]<br></br>
/// [创 建 者: 秦婧]<br></br>
/// [创建时间: 2007-10]<br></br>
/// <修改记录
///		修改人=''
///		修改时间='yyyy-mm-dd'
///		修改目的=''
///		修改描述=''
///  />
/// </summary>
namespace Neusoft.HISFC.BizLogic.EPR
{
    public class Calendar : Neusoft.FrameWork.Management.Database
    {

        public Calendar()
        {

        }
        public int InsertCalendar(Neusoft.HISFC.Models.Base.Calendar calendar)
        {

            string strSql = "";

            if (this.Sql.GetSql("EPR.CALENDAR.INSERT", ref strSql) == -1) return -1;

            try
            {
                strSql = string.Format(strSql, calendar.Name, calendar.CalendarDate, calendar.ParamXML, calendar.Oper.ID, calendar.Oper.OperTime, calendar.Type);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = "接口错误！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.ExecNoQuery(strSql);
        }
        public ArrayList QueryCalendar()
        {
            string strSql = "";

            Neusoft.HISFC.Models.Base.Calendar calendar = null;

            ArrayList lis = new ArrayList();

            if (this.Sql.GetSql("EPR.CALENDAR.QUERY", ref strSql) == -1) return null;

            try
            {


                this.ExecQuery(strSql);

                while (this.Reader.Read())
                {
                    calendar = new Neusoft.HISFC.Models.Base.Calendar();
                    calendar.ID = this.Reader[0].ToString();
                    calendar.Name = this.Reader[1].ToString();
                    calendar.CalendarDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[2].ToString());
                    calendar.ParamXML = this.Reader[3].ToString();
                    calendar.Oper.ID = this.Reader[4].ToString();
                    calendar.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[5].ToString());
                    calendar.Type = this.Reader[6].ToString();
                    lis.Add(calendar);
                }

                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;

                this.WriteErr();

                return null;
            }

            return lis;

        }
        public ArrayList QueryCalendar(DateTime dtBegin, DateTime dtEnd)
        {
            string strSql = "";

            Neusoft.HISFC.Models.Base.Calendar calendar = null;

            ArrayList lis = new ArrayList();

            if (this.Sql.GetSql("EPR.CALENDAR.QUERY1", ref strSql) == -1) return null;

            try
            {
                strSql = string.Format(strSql, dtBegin, dtEnd);

                this.ExecQuery(strSql);

                while (this.Reader.Read())
                {
                    calendar = new Neusoft.HISFC.Models.Base.Calendar();
                    calendar.ID = this.Reader[0].ToString();
                    calendar.Name = this.Reader[1].ToString();
                    calendar.CalendarDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[2].ToString());
                    calendar.ParamXML = this.Reader[3].ToString();
                    calendar.Oper.ID = this.Reader[4].ToString();
                    calendar.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[5].ToString());
                    calendar.Type = this.Reader[6].ToString();
                    lis.Add(calendar);
                }

                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;

                this.WriteErr();

                return null;
            }

            return lis;

        }
        public int DeleteCalendar(string id)
        {
            string strSql = "";

            if (this.Sql.GetSql("EPR.CALENDAR.DELETE", ref strSql) == -1) return -1;

            try
            {
                strSql = string.Format(strSql, id);

                if (this.ExecNoQuery(strSql) == -1)
                {
                    return -1;
                }


            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;

                this.WriteErr();

                return -1;
            }
            return 1;

        }

    }
}
