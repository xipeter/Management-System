using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Pharmacy
{
	/// <summary>
	/// Dictionary 的摘要说明。
	/// 药品字典
	/// </summary>
    public class Dictionary : Neusoft.FrameWork.Management.Database
	{
		public Dictionary()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 获得一级分类
		/// </summary>
		/// <returns></returns>
        public ArrayList QueryGradeOne()
		{
			ArrayList al=new ArrayList();            //用于返回药品信息的数组
			string SQLString ="Pharmacy.Dictionary.GetClass1";
			if(this.Sql.GetSql(SQLString,ref SQLString)==-1) return null;
			if(this.ExecQuery(SQLString)==-1) return null;
			try 
			{
				while (this.Reader.Read()) 
				{
					Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
					obj.ID = this.Reader[0].ToString();
					obj.Name = this.Reader[1].ToString();
					obj.Memo = this.Reader[2].ToString();
					al.Add(obj);
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.WriteErr();
			}
			finally
			{
				this.Reader.Close();
			}
			return al;
		}
		/// <summary>
		/// 获得二级分类
		/// </summary>
		/// <returns></returns>
        public ArrayList QueryGradeTwo(string Class1Code)
		{
			ArrayList al=new ArrayList();            //用于返回药品信息的数组
			string SQLString ="Pharmacy.Dictionary.GetClass2";
			if(this.Sql.GetSql(SQLString,ref SQLString)==-1) return null;
			SQLString = string.Format(SQLString,Class1Code);
			if(this.ExecQuery(SQLString)==-1) return null;
			try 
			{
				while (this.Reader.Read()) 
				{
					Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
					obj.ID = this.Reader[0].ToString();
					obj.Name = this.Reader[1].ToString();
					obj.Memo = this.Reader[2].ToString();
					al.Add(obj);
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.WriteErr();
			}
			finally
			{
				this.Reader.Close();
			}
			return al;
		}
		/// <summary>
		/// 获得字典列表
		/// </summary>
		/// <param name="ds"></param>
		/// <returns></returns>
        public int QueryDictionaryList(ref System.Data.DataSet ds)
		{
			string SQLString ="Pharmacy.Dictionary.GetList";
			if(this.Sql.GetSql(SQLString,ref SQLString)==-1) return -1;
			return this.ExecQuery(SQLString,ref ds);
        }


        #region 作废
        /// <summary>
        /// 获得一级分类
        /// </summary>
        /// <returns></returns>
        [System.Obsolete("系统重构，用函数QueryGradeOne代替", true)]
        public ArrayList GetClass1()
        {
            ArrayList al = new ArrayList();            //用于返回药品信息的数组
            string SQLString = "Pharmacy.Dictionary.GetClass1";
            if (this.Sql.GetSql(SQLString, ref SQLString) == -1) return null;
            if (this.ExecQuery(SQLString) == -1) return null;
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();
                    obj.Name = this.Reader[1].ToString();
                    obj.Memo = this.Reader[2].ToString();
                    al.Add(obj);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 获得二级分类
        /// </summary>
        /// <returns></returns>
        [System.Obsolete("系统重构，用函数QueryGradeTwo代替",true)]
        public ArrayList GetClass2(string Class1Code)
        {
            ArrayList al = new ArrayList();            //用于返回药品信息的数组
            string SQLString = "Pharmacy.Dictionary.GetClass2";
            if (this.Sql.GetSql(SQLString, ref SQLString) == -1) return null;
            SQLString = string.Format(SQLString, Class1Code);
            if (this.ExecQuery(SQLString) == -1) return null;
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();
                    obj.Name = this.Reader[1].ToString();
                    obj.Memo = this.Reader[2].ToString();
                    al.Add(obj);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 获得字典列表
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        [System.Obsolete("系统重构，用函数QueryDictionaryList代替", true)]
        public int GetList(ref System.Data.DataSet ds)
        {
            string SQLString = "Pharmacy.Dictionary.GetList";
            if (this.Sql.GetSql(SQLString, ref SQLString) == -1) return -1;
            return this.ExecQuery(SQLString, ref ds);
        }

        #endregion 
    }
}
