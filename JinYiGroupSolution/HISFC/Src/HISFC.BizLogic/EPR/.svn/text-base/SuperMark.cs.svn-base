using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Neusoft.HISFC.BizLogic.EPR
{
    public class SuperMark:Neusoft.FrameWork.Management.Database 
    {
        
		/// <summary>
		/// 保存上级修改痕迹
		/// </summary>
		/// <param name="supermark">权限实体</param>
        /// <param name="img">修改痕迹</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int SetSuperMark(Neusoft.FrameWork.Models.NeuObject supermark, byte[] img) 
		{
			//选择
			Neusoft.FrameWork.Models.NeuObject obj = GetSuperMark(supermark);

			//如果没有找到可以更新的数据，则插入一条新记录
            if (obj == null)
            {
                return InsertSuperMark(supermark, img);
            }
            else
            {
                return UpdateSuperMark(supermark, img);
            }
		}
        /// <summary>
		/// 修改一条上级修改记录
		/// </summary>
		/// <returns></returns>
		public int UpdateSuperMark(Neusoft.FrameWork.Models.NeuObject supermark, byte[] img)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.EMR.UpdateSuperMark",ref strSql)==-1) return -1;
			strSql = string.Format(strSql, supermark.ID,supermark.Name,Neusoft.FrameWork.Management.Connection.Operator.ID);

			return this.InputBlob(strSql, img);
		}
        /// <summary>
        /// 删除一条上级修改记录
        /// </summary>
        /// <returns></returns>
        public int DeleteSuperMark(Neusoft.FrameWork.Models.NeuObject supermark, byte[] img)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.EMR.DeleteSuperMark", ref strSql) == -1) return -1;
            strSql = string.Format(strSql, supermark.ID, supermark.Name);

            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 插入一条上级修改记录
        /// </summary>
        /// <returns></returns>
        public int InsertSuperMark(Neusoft.FrameWork.Models.NeuObject supermark, byte[] img)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.EMR.InsertSuperMark", ref strSql) == -1) return -1;
            strSql = string.Format(strSql, supermark.ID, supermark.Name, supermark.Memo, supermark.User01,supermark.User02, supermark.User03);

            return this.InputBlob(strSql, img);
        }

        /// <summary>
		/// 获得上级修改痕迹
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public Neusoft.FrameWork.Models.NeuObject GetSuperMark(Neusoft.FrameWork.Models.NeuObject obj)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.EMR.GetSuperMark",ref strSql)==-1) return null;
			strSql = string.Format(strSql,obj.ID, obj.Name);
            
			ArrayList al =  this.myGetSuperMark(strSql);
			if(al ==null || al.Count == 0) return null;
			return al[0] as Neusoft.FrameWork.Models.NeuObject;
		}

        /// <summary>
		/// 获得上级修改痕迹
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
        public byte[] GetSuperMarkImage(Neusoft.FrameWork.Models.NeuObject obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("EPR.EMR.GetSuperMarkImage", ref strSql) == -1) return null;
            strSql = string.Format(strSql, obj.ID, obj.Name);
            return this.OutputBlob(strSql);
        } 

        #region "私有"
        private ArrayList myGetSuperMark(string sql)
        {
            if (this.ExecQuery(sql) == -1) return null;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject supermark = new Neusoft.FrameWork.Models.NeuObject();
                supermark.ID = this.Reader[0].ToString();
                supermark.Name = this.Reader[1].ToString();
                supermark.Memo = this.Reader[2].ToString();
                supermark.User01 = this.Reader[3].ToString();
                supermark.User02 = this.Reader[4].ToString();
                supermark.User03 = this.Reader[5].ToString();
                al.Add(supermark);
            }
            this.Reader.Close();
            return al;
        }

		#endregion

    }
}
