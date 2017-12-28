using System.IO;
namespace Neusoft.FrameWork.Models
{  
    /// <summary>
    /// NeuLogo<br></br>
    /// [功能描述: NeuLogo]<br></br>
    /// [创 建 者: 李云凡]<br></br>
    /// [创建时间: 2006-08-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
	public class NeuLog
	{
		public NeuLog()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			newLog();
		}
		public NeuLog(string strFileName)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.strFileName=strFileName;
			newLog();
		}
		private void newLog()
		{
			if(!Neusoft.FrameWork.Management.Connection.IsWeb)
			{
				if(! File.Exists(this.strFileName))
				{
					System.IO.File.CreateText(this.strFileName);
				}
			}
        }

        #region 变量
        private string strFileName = ".\\log.txt";
        private System.IO.TextWriter output;
        #endregion

        #region 属性
        /// <summary>
		/// 设置/读取文件名
		/// </summary>
		public string FileName
		{
			get
			{
				return strFileName;
			}
			set
			{
				strFileName=value;
			}
        }
        #endregion

        #region 方法
        /// <summary>
		/// 写日志
		/// </summary>
		/// <param name="str"></param>
		public void WriteLog(string str)
		{
			if(!Neusoft.FrameWork.Management.Connection.IsWeb)
			{
				try
				{
					output=File.AppendText(strFileName);
					output.WriteLine(System.DateTime.Now+"\n"+str);
					output.Close();
				}
				catch {}
			}
        }
        #endregion
    }
}
