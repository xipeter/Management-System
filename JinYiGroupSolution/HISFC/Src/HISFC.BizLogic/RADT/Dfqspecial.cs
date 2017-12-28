using System;

namespace RADT
{
	/// <summary>
	/// 医嘱特殊频次表
	/// </summary>
	public class Dfqspecial
	{
		public Dfqspecial()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public int InsertDfqspecial(neusoft.HISFC.Object.RADT.Cdfqspecial info)
		{
			string strSql = "";
			if (this.Sql.GetSql("RADT.Dfqspecial.InsertDfqspecial",ref strSql)==-1)return -1;
			try
			{
				//insert into fin_com_undrugzt(PACKAGE_CODE ,PACKAGE_NAME ,SYS_CLASS,,SPELL_CODE ,WB_CODE,INPUT_CODE,DEPT_CODE,SORT_ID  ,CONFIRM_FLAG ,VALID_STATE ,EXT_FLAG ,EXT1_FLAG ,OPER_CODE,OPER_DATE  ) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',sysdate)
				string OperId =this.Operator.ID;
				strSql = string.Format(strSql,info.ID,info.Name,info.sysClass,info.spellCode,info.wbCode ,info.inputCode,info.deptCode,info.sortId,info.confirmFlag,info.validState, OperId);
			}
			catch(Exception ee)
			{
				this.Err  = ee.Message;
			}
			return this.ExecNoQuery(strSql);
		}
	}
}
