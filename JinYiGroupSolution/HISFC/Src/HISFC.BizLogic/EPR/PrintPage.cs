using System;
using System.Xml;
using System.Collections;
using System.Text;

namespace Neusoft.HISFC.BizLogic.EPR
{
    public class PrintPage:Neusoft.FrameWork.Management.Database 
    {
        
		/// <summary>
		/// 保存打印页
		/// </summary>
		/// <param name="PrintPage">权限实体</param>
        /// <param name="img">修改痕迹</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int SetPrintPage(Neusoft.HISFC.Models.EPR.EPRPrintPage printPage, byte[] img) 
		{
			//选择
			Neusoft.HISFC.Models.EPR.EPRPrintPage obj = GetPrintPage(printPage);

			//如果没有找到可以更新的数据，则插入一条新记录
            if (obj == null)
            {
                return InsertPrintPage(printPage, img);
            }
            else
            {
                return UpdatePrintPage(printPage, img);
            }
		}
        /// <summary>
		/// 修改一条上级修改记录
		/// </summary>
		/// <returns></returns>
		public int UpdatePrintPage(Neusoft.HISFC.Models.EPR.EPRPrintPage printPage, byte[] img)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.EMR.UpdatePrintPage",ref strSql)==-1) return -1;
			strSql = string.Format(strSql, printPage.ID, printPage.Page, printPage.Name, printPage.Memo, printPage.SortedControlsXml.ToString(), printPage.BeginDate.ToString("yyyy-MM-dd HH:mm:ss"), printPage.EndDate.ToString("yyyy-MM-dd HH:mm:ss"), printPage.StartRow.ToString(),Neusoft.FrameWork.Management.Connection.Operator.ID);

			return this.InputBlob(strSql, img);
		}
        /// <summary>
        /// 删除一条上级修改记录
        /// </summary>
        /// <returns></returns>
        public int DeletePrintPage(Neusoft.HISFC.Models.EPR.EPRPrintPage printPage, byte[] img)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.EMR.DeletePrintPage", ref strSql) == -1) return -1;
            strSql = string.Format(strSql, printPage.ID, printPage.Page.ToString());

            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 插入一条上级修改记录
        /// </summary>
        /// <returns></returns>
        public int InsertPrintPage(Neusoft.HISFC.Models.EPR.EPRPrintPage printPage, byte[] img)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.EMR.InsertPrintPage", ref strSql) == -1) return -1;
            strSql = string.Format(strSql, printPage.ID, printPage.Page, printPage.Name, printPage.Memo, "<?xml version=\"1.0\" encoding=\"GB2312\"?><Controls Version=\"1.0\"></Controls>", //printPage.SortedControlsXml.ToString(), 
                printPage.BeginDate.ToString("yyyy-MM-dd HH:mm:ss"), printPage.EndDate.ToString("yyyy-MM-dd HH:mm:ss"), printPage.StartRow.ToString(), Neusoft.FrameWork.Management.Connection.Operator.ID);
            return this.InputBlob(strSql, img);
        }

        /// <summary>
		/// 获得打印页
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.EPR.EPRPrintPage GetPrintPage(Neusoft.HISFC.Models.EPR.EPRPrintPage obj)
		{
			string strSql = "";
            if (this.Sql.GetSql("EPR.EMR.GetPrintPage", ref strSql) == -1) return null;
			strSql = string.Format(strSql,obj.ID, obj.Page.ToString());
            
			ArrayList al =  this.myGetPrintPage(strSql);
			if(al ==null || al.Count == 0) return null;
			return al[0] as Neusoft.HISFC.Models.EPR.EPRPrintPage;
		}

        /// <summary>
		/// 获得打印页
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public ArrayList GetPrintPageList(Neusoft.HISFC.Models.EPR.EPRPrintPage obj)
		{
			string strSql = "";
            if (this.Sql.GetSql("EPR.EMR.GetPrintPageList", ref strSql) == -1) return null;
			strSql = string.Format(strSql,obj.ID);
            
			ArrayList al =  this.myGetPrintPage(strSql);
			if(al ==null || al.Count == 0) return null;
            return al;
		}

        /// <summary>
		/// 获得打印页
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
        public byte[] GetPrintPageImage(Neusoft.HISFC.Models.EPR.EPRPrintPage obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("EPR.EMR.GetPrintPageImage", ref strSql) == -1) return null;
            strSql = string.Format(strSql, obj.ID, obj.Page.ToString());
            return this.OutputBlob(strSql);
        } 

        #region "私有"
        private ArrayList myGetPrintPage(string sql)
        {
            if (this.ExecQuery(sql) == -1) return null;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.EPR.EPRPrintPage printPage = new Neusoft.HISFC.Models.EPR.EPRPrintPage();
                printPage.ID = this.Reader[0].ToString();
                printPage.Page = int.Parse(this.Reader[1].ToString());
                printPage.Name = this.Reader[2].ToString();
                printPage.Memo = this.Reader[3].ToString();
                Neusoft.FrameWork.Xml.XML xml = new Neusoft.FrameWork.Xml.XML();
                System.Xml.XmlDocument doc = new XmlDocument();
                printPage.SortedControlsXml = this.Reader[4].ToString();
                printPage.BeginDate = DateTime.Parse(this.Reader[5].ToString());
                printPage.EndDate = DateTime.Parse(this.Reader[6].ToString());
                printPage.StartRow = int.Parse(this.Reader[7].ToString());
                al.Add(printPage);
            }
            this.Reader.Close();
            return al;
        }

		#endregion

    }
}
