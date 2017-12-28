using System;

namespace Neusoft.FrameWork.Management
{
	/// <summary>
	/// File 文件管理
	/// 本地dll
	/// </summary>
	public class File
	{
		/// <summary>
		/// ftp 设置 
		/// </summary>
		private FrameWork.Models.NeuObject Ftp=new FrameWork.Models.NeuObject();
		/// <summary>
		/// 构造函数
		/// </summary>
		public File()
		{
		}
		/// <summary>
		/// 构造函数，传入ftp
		/// </summary>
		/// <param name="Ftp"></param>
		public File(FrameWork.Models.NeuObject Ftp)
		{
			this.Ftp=Ftp;
		}
		/// <summary>
		/// 当前ftp设置
		/// </summary>
		public FrameWork.Models.NeuObject objFtp
		{
			get
			{
				return this.Ftp;
			}
			set
			{
				this.Ftp=value;
			}
		}
		/// <summary>
		/// 保存文件到服务器
		/// </summary>
		/// <param name="sourceFileName">本地文件</param>
		/// <param name="targetFile">目标文件</param>
		/// <returns></returns>
		public int SaveFile(string sourceFileName,FrameWork.Models.NeuFileInfo targetFile)
		{
			return 0;
		}
		/// <summary>
		/// 获得服务器文件
		/// </summary>
		/// <param name="sourceFile">服务器文件</param>
		/// <param name="targetFileName">本地文件</param>
		/// <returns></returns>
		public int GetFile(FrameWork.Models.NeuFileInfo sourceFile,string targetFileName)
		{
			return 0;
		}
	}
}
