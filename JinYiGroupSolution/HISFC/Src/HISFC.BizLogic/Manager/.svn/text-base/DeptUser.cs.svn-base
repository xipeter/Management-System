using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// DeptUser 的摘要说明。
	/// </summary>
    //public class DeptUser:Neusoft.FrameWork.Management.Database
    //{
    //    public DeptUser()
    //    {
    //        //
    //        // TODO: 在此处添加构造函数逻辑
    //        //
    //    }
    //    /// <summary>
    //    /// 获取所有科常用 
    //    /// </summary>
    //    /// <returns></returns>
    //    public ArrayList GetDeptUserAll()
    //    {
    //        string strSql = "";
    //        ArrayList al = new ArrayList();
    //        if (this.Sql.GetSql("Manager.DeptUser.GetDeptUserAll",ref strSql)==-1)return null;
    //        this.ExecQuery(strSql);
    //        //0控制参数代码1控制参数名称2控制参数值3显示标记
    //        while (this.Reader.Read())
    //        {
    //            Neusoft.HISFC.Models.PhysicalExam.DeptUse Control = new Neusoft.HISFC.Models.PhysicalExam.DeptUse();
    //            try
    //            {
    //                //					Control.ID = this.Reader[0].ToString();
    //                //					Control.Name= this.Reader[1].ToString();
    //                //					Control.ControlValue=this.Reader[3].ToString();
    //                //					Control.VisibleFlag=this.Reader[4].ToString();
    //            }
    //            catch(Exception ex)
    //            {
    //                this.Err="查询控制信息赋值错误!"+ex.Message;
    //                this.ErrCode=ex.Message;
    //                return null;
    //            }
				
    //            al.Add(Control);

    //        }
    //        this.Reader.Close();

    //        return al;
    //    }
    //    /// <summary>
    //    /// 获取所有的科常用 
    //    /// </summary>
    //    /// <param name="deptCode"></param>
    //    /// <returns></returns>
    //    public ArrayList  GetDeptUse(string deptCode)
    //    {
    //        string strSql = "";
    //        if (this.Sql.GetSql("Manager.DeptUser.GetDeptUse",ref strSql)==-1) return null;
    //        strSql = string.Format(strSql,deptCode);
    //        try
    //        {				
    //            return myGetDeptUse(strSql);
    //        }
    //        catch(Exception ee)
    //        {
    //            this.Err = "Manager.DeptUser.GetDeptUse"+ee.Message;
    //            this.ErrCode=ee.Message;
    //            WriteErr();
    //            return null;
    //        }
    //    }
    //    /// <summary>
    //    /// 私有成员 获取科常用
    //    /// </summary>
    //    /// <param name="strSql"></param>
    //    /// <returns></returns>
    //    private ArrayList myGetDeptUse(string strSql)
    //    {
    //        try
    //        {
    //            ArrayList list = new  ArrayList();
    //            Neusoft.HISFC.Models.PhysicalExam.DeptUse info = null;
    //            this.ExecQuery(strSql);
    //            while(this.Reader.Read())
    //            {
    //                info = new Neusoft.HISFC.Models.PhysicalExam.DeptUse();
    //                info.item.Name = this.Reader[0].ToString(); //项目名称
    //                info.ExecDeptInfo.Name = this.Reader[1].ToString(); //执行科室
    //                info.Memo = this.Reader[2].ToString(); //注意事项
    //                info.item.ID = this.Reader[3].ToString();//项目代码
    //                info.ExecDeptInfo.ID = this.Reader[4].ToString(); //执行科室
    //                info.DeptInfo.ID = this.Reader[5].ToString(); //科室 
    //                info.UnitFlag = this.Reader[6].ToString(); //单位标识
    //                info.item.SysClass.ID = this.Reader[7].ToString();//系统类别
    //                list.Add(info);
    //            }
    //            return list;
    //        }
    //        catch(Exception ex)
    //        {
    //            this.Err  = ex.Message;
    //            return null;
    //        }
    //    }
    //    /// <summary>
    //    /// 获取某条科常用
    //    /// </summary>
    //    /// <param name="ItemCode"></param>
    //    /// <returns></returns>
    //    public ArrayList GetDeptUser(string ItemCode)
    //    {
    //        ArrayList list = new  ArrayList();
    //        return list;
    //    }
    //    /// <summary>
    //    /// 获取所有的科常用 
    //    /// </summary>
    //    /// <param name="ds"></param>
    //    /// <param name="deptCode"></param>
    //    /// <returns></returns>
    //    public int GetDeptUse(ref System.Data.DataSet ds ,string deptCode)
    //    {
    //        string strSql = "";
    //        if (this.Sql.GetSql("Manager.DeptUser.GetDeptUse",ref strSql)==-1) return -1;
    //        strSql = string.Format(strSql,deptCode);
    //        try
    //        {				
    //            if(this.ExecQuery(strSql)==-1)return -1;
    //            this.ExecQuery(strSql,ref ds);
    //            return 1;
    //        }
    //        catch(Exception ee)
    //        {
    //            this.Err = "Manager.DeptUser.GetDeptUse"+ee.Message;
    //            this.ErrCode=ee.Message;
    //            WriteErr();
    //            return -1;
    //        }
    //    }
    //    public int AddOrUpdateDeptUse(Neusoft.HISFC.Models.PhysicalExamination.DeptUse item)
    //    {
    //        return 1;
    //    }
    //    /// <summary>
    //    /// 增加科常用
    //    /// </summary>
    //    /// <param name="item"></param>
    //    /// <returns></returns>
    //    public int AddDeptUse(Neusoft.HISFC.Models.PhysicalExamination.DeptUse item)
    //    {
    //        string sql = "";
    //        if(this.Sql.GetSql("Manager.DeptUser.AddDeptUse",ref sql)== -1)
    //            return -1;
    //        try 
    //        {
    //            sql=string.Format(sql,ItemParam(item));
    //        }
    //        catch(Exception ex) 
    //        {
    //            this.ErrCode=ex.Message;
    //            this.Err="接口错误！"+ex.Message;
    //            this.WriteErr();
    //            return -1;
    //        }

    //        if(this.ExecNoQuery(sql) == -1) return -1;


    //        return 1;
    //    }

    //    /// <summary>
    //    /// 获取参数
    //    /// </summary>
    //    /// <param name="item"></param>
    //    /// <returns></returns>
    //    private string[] ItemParam(Neusoft.HISFC.Models.PhysicalExamination.DeptUse item)
    //    {
    //        string []str = new string[]{
    //                                       item.DeptInfo.ID,
    //                                       item.item.ID,
    //                                       item.item.SysClass.ID.ToString(),
    //                                       item.item.Name,
    //                                       item.ExecDeptInfo.ID,
    //                                       item.UnitFlag,
    //                                       item.Memo,
    //                                       this.Operator.ID
    //                                   };
    //        return str;
    //    }
    //    /// <summary>
    //    /// 更新科常用
    //    /// </summary>
    //    /// <param name="item"></param>
    //    /// <returns></returns>
    //    public int UpdateDeptUse(Neusoft.HISFC.Models.PhysicalExamination.DeptUse item)
    //    {
    //        string sql = "";
    //        if(this.Sql.GetSql("Manager.DeptUser.UpdateDeptUse",ref sql)== -1)
    //            return -1;
    //        try 
    //        {
    //            sql=string.Format(sql,ItemParam(item));
    //        }
    //        catch(Exception ex) 
    //        {
    //            this.ErrCode=ex.Message;
    //            this.Err="接口错误！"+ex.Message;
    //            this.WriteErr();
    //            return -1;
    //        }

    //        if(this.ExecNoQuery(sql) == -1) return -1;


    //        return 1;
    //    }
    //    /// <summary>
    //    /// 删除一条科常用
    //    /// </summary>
    //    /// <param name="item"></param>
    //    ///  
    //    /// <returns></returns>
    //    public int DeleteDeptUse(Neusoft.HISFC.Models.PhysicalExamination.DeptUse item)
    //    {
    //        string sql = "";
    //        if(this.Sql.GetSql("Manager.DeptUser.DeleteDeptUse",ref sql)== -1)
    //            return -1;
    //        try 
    //        {
    //            sql=string.Format(sql,ItemParam(item));
    //        }
    //        catch(Exception ex) 
    //        {
    //            this.ErrCode=ex.Message;
    //            this.Err="接口错误！"+ex.Message;
    //            this.WriteErr();
    //            return -1;
    //        }

    //        return this.ExecNoQuery(sql);
    //    }
    //}
}
