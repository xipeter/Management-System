using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.EPR
{
	/// <summary>
	/// NodePath 的摘要说明。
	/// </summary>
	public class NodePath:Neusoft.FrameWork.Management.Database
	{
		public NodePath()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 插入一条新节点
		/// </summary>
		/// <returns></returns>
		public int InsertNodePath(Neusoft.FrameWork.Models.NeuObject obj)
		{
			string strSql = "";
			if(this.Sql.GetSql("Manager.NodePath.Insert",ref strSql)==-1) return -1;
			
			return this.ExecNoQuery(strSql,obj.ID,obj.Name,obj.Memo,obj.User01,obj.User02,obj.User03,"0");
		}
		
		/// <summary>
		///  删除节点
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public int DeleteNodePath(string id)
		{
			string strSql = "";
			if(this.Sql.GetSql("Manager.NodePath.Delete",ref strSql)==-1) return -1;
			return this.ExecNoQuery(strSql,id);
		}
		
	
		/// <summary>
		/// 查询所有节点
		/// </summary>
		/// <returns></returns>
		public System.Data.DataSet GetNodePath()
		{
			string strSql="";
	
			if(this.Sql.GetSql("Manager.NodePath.Select",ref strSql)==-1) return null;
			System.Data.DataSet ds = new System.Data.DataSet();
			if(this.ExecQuery(strSql,ref ds) == -1) return null;
			return ds;
		}

		/// <summary>
		/// 获得所有
		/// </summary>
		/// <returns></returns>
		public ArrayList GetNodePathList()
		{
			string strSql="";
	
			if(this.Sql.GetSql("Manager.NodePath.Select",ref strSql)==-1) return null;
			
			ArrayList al = new ArrayList();
			Neusoft.FrameWork.Models.NeuObject obj = null;
			if(this.ExecQuery(strSql) == -1) return null;

			while(this.Reader.Read())
			{
				obj = new Neusoft.FrameWork.Models.NeuObject();

				try
				{
					obj.ID =this.Reader[0].ToString();//fullpath
				}
				catch
				{}
				try
				{
					obj.Name =this.Reader[1].ToString();//node name
				}
				catch
				{}
				try
				{
					obj.Memo  =this.Reader[2].ToString();//memo
				}
				catch
				{}
				try
				{
					obj.User01  =this.Reader[3].ToString();
				}
				catch
				{}
				try
				{
					obj.User02  =this.Reader[4].ToString();
				}
				catch
				{}
				try
				{
					obj.User03  =this.Reader[5].ToString();
				}
				catch
				{}
				al.Add(obj);
			}
			this.Reader.Close();
			return al;
		}
	}
}
