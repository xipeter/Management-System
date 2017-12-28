using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace AutoUpdate
{
	/// <summary>
	/// SystemUpdate ��ժҪ˵����
	/// </summary>
	public class SystemUpdate
	{
		public Waiting wait = new Waiting(); 
		public SystemUpdate()
		{
			//
			// TODO: �ڴ˴����ӹ��캯���߼�
			//
			
		}

		OracleCommand command = new OracleCommand();
		public string Err = "";
		/// <summary>
		/// �ж������Ƿ����
		/// </summary>
		/// <param name="con"></param>
		/// <returns>1 ���� ��0 ������ ����1 ���� </returns>
		public int IsExistPrimaryKey(OracleConnection con,string ID)
		{
			string strSql = "SELECT primary_id, file_name,local_directory,file_content, file_version, oper_code,  oper_date  FROM com_downloadfile t WHERE t.primary_id = '{0}'";
			strSql = string.Format(strSql,ID);
			System.Data.DataSet ds = SelectData(con,strSql);
			if(ds == null )
			{
				Err = "��������ѯʧ��";
				return -1;
			}
			if(ds.Tables.Count ==0)
			{
				return 0;
			}
			if(ds.Tables[0].Rows.Count == 0)
			{
				return 0;
			}
			return 1;
		}
		/// <summary>
		/// ��ȡ�ļ�
		/// </summary>
		/// <param name="con"></param>
		/// <param name="FileID">����</param>
		/// <param name="FileName">�ļ���</param>
		/// <returns></returns>
		public  int DownLoadFile(OracleConnection con,string FileID,string FileName)
		{
			FtpFile ftpObj = new FtpFile();
			string strSql = "SELECT primary_id, file_name,local_directory,file_content, file_version, oper_code,  oper_date  FROM com_downloadfile t WHERE t.primary_id = '{0}'";
			strSql = string.Format(strSql,FileID);
			System.Data.DataSet ds = SelectData(con,strSql);
			if(ds == null )
			{
				Err = "��ѯ��Ҫ���µ��ļ�ʧ��";
				return -1;
			}
			if(ds.Tables.Count ==0)
			{
				return 1;
			}
			if(ds.Tables[0].Rows.Count == 0)
			{
				return 1;
			}
			#region �����ļ� 
			wait.lblTip.Text = "��ʼ���س���.....";
			foreach(DataRow row in ds.Tables[0].Rows)
			{
				ftpObj.PrimaryID  = row[0].ToString();
				ftpObj.FileName = row[1].ToString();
				ftpObj.LocalDirectory = row[2].ToString();
				ftpObj.LocalDirectory = ConvertPath(ftpObj.LocalDirectory); //ת��·��
				ftpObj.FileVersion = row[4].ToString();
				ftpObj.OperCode =row[5].ToString();
				try
				{
					//��ȡ�ļ�
					byte []data=(byte [])row["file_content"];
					DirectoryCheckAndCreate(FileName);
					//���ص����ص�����
					string LocalFileName  = FileName;
					if(File.Exists(LocalFileName))
					{
						System.IO.File.SetAttributes(LocalFileName,System.IO.FileAttributes.Normal);
					}
					FileStream fs = new FileStream(LocalFileName,System.IO.FileMode.Create);
					int arraysize=new int();//ע����仰
					arraysize=data.Length;
					fs.Write(data,0,arraysize);
					fs.Close();
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					return -1;
				}
			}
			//�ر�����
			con.Close();
			#endregion  

			return 1;
		}
		/// <summary>
		/// ��ȡ�ļ�
		/// </summary>
		/// <param name="con"></param>
		/// <returns></returns>
		public  int DownLoadFile(OracleConnection con)
		{
			Process[] proc = Process.GetProcessesByName("His");
			if(proc.Length>=1)
			{
				if(MessageBox.Show("��ǰϵͳ����JinYiGroupStation�����У�\n����ص����ܸ���ϵͳ���Ƿ�رս��и��£�","��ʾ",MessageBoxButtons.OKCancel)==DialogResult.OK)
				{
					for(int i=0;i<proc.Length;i++)
					{
						proc[i].Kill();
					}
				}
				else
				{
					Application.Exit();
				}
			}

			string filePath = Application.StartupPath;
			FtpFile ftpObj = new FtpFile();
			string strSql = "SELECT primary_id, file_name,local_directory,file_content, file_version, oper_code,  oper_date  FROM com_downloadfile t WHERE t.oper_date > to_date('{0}','yyyy-mm-dd hh24:mi:ss')";
			string tempLastTime =  ReadConfig("UpdateTime"); //�ϴθ���ʱ��
			strSql = string.Format(strSql,tempLastTime);

			wait.lblTip.Text = "���ڲ�ѯ����.....";
			System.Windows.Forms.Application.DoEvents();
			wait.Refresh();  

			System.Data.DataSet ds = SelectData(con,strSql);
			if(ds == null )
			{
				Err = "��ѯ��Ҫ���µ��ļ�ʧ��";
				return -1;
			}
			if(ds.Tables.Count ==0)
			{
				return 1;
			}
			if(ds.Tables[0].Rows.Count == 0)
			{
				return 1;
			}
			wait.lblTip.Text = "�������أ���ȴ���������";
			System.Windows.Forms.Application.DoEvents();
			wait.Refresh();
			wait.progressBar1.Maximum = ds.Tables[0].Rows.Count;
			wait.progressBar1.Minimum = 0;
			#region �����ļ� 
			foreach(DataRow row in ds.Tables[0].Rows)
			{
				ftpObj.PrimaryID  = row[0].ToString();
				ftpObj.FileName = row[1].ToString();
				ftpObj.LocalDirectory = row[2].ToString();
				ftpObj.LocalDirectory = ConvertPath(ftpObj.LocalDirectory); //ת��·��
				ftpObj.FileVersion = row[4].ToString();
				ftpObj.OperCode =row[5].ToString();

				wait.lblTip.Text = "��������" + ftpObj.FileName;
				wait.lblTip.Refresh();
				wait.progressBar1.Value ++;
				wait.progressBar1.Refresh();
				System.Windows.Forms.Application.DoEvents();

				try
				{
					//��ȡ�ļ�
					byte []data=(byte [])row["file_content"];
					DirectoryCheckAndCreate(filePath + ftpObj.LocalDirectory);
					//���ص����ص�����
					string LocalFileName  = filePath + ftpObj.LocalDirectory + ftpObj.FileName;
					if(File.Exists(LocalFileName))
					{
						System.IO.File.SetAttributes(LocalFileName,System.IO.FileAttributes.Normal);
					}
					FileStream fs = new FileStream(LocalFileName,System.IO.FileMode.Create);
					int arraysize=new int();//ע����仰
					arraysize=data.Length;
					fs.Write(data,0,arraysize);
					fs.Close();
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					return -1;
				}
			}
			//�ر�����
			con.Close();
			#endregion  

			return 1;
		}
		/// <summary>
		/// �ж�·���Ƿ���ڣ���������ڣ��򴴽�
		/// </summary>
		/// <param name="szLocalFileName"></param>
		/// <returns></returns>
		public bool DirectoryCheckAndCreate(string szLocalFileName)
		{
			string szPath;
			int iPos;

			//·������һ��Ϊ: d:\temp\test\filename.ext ���� .\test\filename.ext ,�������ﲻ������..\test\filename.ext            

			//������û����Ӧ��·��
			if(szLocalFileName == "" || szLocalFileName == null)
				return true;

			iPos = szLocalFileName.LastIndexOf("\\");
			if( iPos < 1) // �������ļ�����ڸ�����ô�����������ַ���Ҫ��Ȼû��·��,��0��ʼ��ֵ
			{
				//��ʾ���������һ���ļ������ƣ�û��·�� ,�����\filename.ext ��ôҲ��Ϊû��·����
				return true;
			}

			szPath = szLocalFileName.Substring(0,iPos); //iPos ��һ�������� ��\�����ַ���

			if(szPath == "" || szPath == null)
				return true; //û��·��

			if(Directory.Exists(szPath))
				return true; //Ŀ¼�Ѿ�����

			//Ŀ¼�����ڣ���ôҪ����һ��Ŀ¼
			Directory.CreateDirectory(szPath);                
			return true;

		}
		/// <summary>
		/// ת��·��
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		private string ConvertPath(string filePath)
		{
			filePath = filePath.Replace("/",@"\");
			if(filePath.Length ==0)
			{
				return @"\";
			}
			if(filePath.Substring(filePath.Length -1 ,1)  != @"\")
			{ 
				//�ж����һ���Ƿ��� ��\��
				filePath += @"\";
			}
			if(filePath.Substring(0,1) != @"\")
			{
				//�жϵ�һ���Ƿ��� ��\��
				filePath = @"\" +filePath;
			}
			return filePath;
		}
		/// <summary>
		/// �ж�ͬһĿ¼���Ƿ����ͬ���ļ�
		/// </summary>
		/// <param name="con"></param>
		/// <returns>1 ���� ��0 ������ ����1 ���� </returns>
		public int IsExistPrimaryKey(OracleConnection con,FtpFile obj )
		{
			string strSql = "SELECT primary_id, file_name,local_directory,file_content, file_version, oper_code,  oper_date  FROM com_downloadfile t WHERE t.file_name = '{0}' and local_directory = '{1}' ";
			strSql = string.Format(strSql,obj.FileName,obj.LocalDirectory);
			System.Data.DataSet ds = SelectData(con,strSql);
			if(ds == null )
			{
				this.Err = "�ж�ͬһĿ¼���Ƿ����ͬ���ļ�ʧ��";
				return -1;
			}
			if(ds.Tables.Count ==0)
			{
				return 0;
			}
			if(ds.Tables[0].Rows.Count == 0)
			{
				return 0;
			}
			bool Result = false;
			foreach(DataRow row in ds.Tables[0].Rows)
			{
				try
				{
					if(row[0].ToString() != obj.PrimaryID) //�ļ��� ·����ͬ id��ͬ
					{
						Result = true;
					}
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					return -1;
				}
			}

			if(Result) 
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="Trans">����command����</param>
		public void SetTrans(OracleTransaction Trans) 
		{
			try 
			{
				command.Transaction=Trans;
			}
			catch(Exception ex) 
			{
				this.Err="�������������" +ex.Message;
			}
		}
		/// <summary>
		/// ����SQL��ѯ���ݿ⣬���ҷ������ݼ�
		/// </summary>
		/// <param name="con"></param>
		/// <param name="Sql"></param>
		/// <returns></returns>
		public DataSet SelectData(OracleConnection con ,string Sql)
		{
			System.Data.DataSet dataSet = new DataSet("Data");
			try
			{
				command.Connection= con;
				command.CommandType= System.Data.CommandType.Text;
				command.Parameters.Clear();
				command.CommandText =Sql + "";
				OracleDataAdapter adapter = new OracleDataAdapter(this.command);
				adapter.Fill(dataSet);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				dataSet = null;
			}
			return dataSet;
		}
		/// <summary>
		/// ��ȡ
		/// </summary>
		/// <param name="con"></param>
		/// <param name="Sql"></param>
		/// <returns></returns>
		public string ReturnOne(OracleConnection con ,string Sql)
		{
			string str = "";
			System.Data.DataSet dataSet = new DataSet("Data");
			try
			{
				command.Connection= con;
				command.CommandType= System.Data.CommandType.Text;
				command.Parameters.Clear();
				command.CommandText =Sql + "";
				OracleDataAdapter adapter = new OracleDataAdapter(this.command);
				adapter.Fill(dataSet); 
				if(dataSet == null || dataSet.Tables.Count == 0)
				{
					this.Err = "��ѯʧ��" ;
					return null;
				}
				foreach(DataRow row in dataSet.Tables[0].Rows)
				{
					try
					{
						str = row[0].ToString();
					}
					catch(Exception ex)
					{
						this.Err = ex.Message;
						str = null;
					}
				}
				
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				str = null;
			}
			return str;

		}

		/// <summary>
		/// ִ�зǲ�ѯ���
		/// </summary>
		/// <param name="con"></param>
		/// <param name="Sql"></param>
		/// <returns></returns>
		public int  ExeNoQuery(OracleConnection con ,string Sql)
		{
			int i=0;
			try
			{
				command.Connection=con;
				command.CommandType=System.Data.CommandType.Text;
				command.Parameters.Clear();
				command.CommandText =Sql;
				
				try
				{
					i=command.ExecuteNonQuery();
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					return -1;
				}
				return i;
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// д������־
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		private  bool MessageEventLog(string message)
		{			
			try
			{
				//����¼�Դ�Ƿ���ڣ����������,����Application�����¼���־����һ���¼�Դ
				if(!System.Diagnostics.EventLog.SourceExists("AutoUpdate"))
					System.Diagnostics.EventLog.CreateEventSource("AutoUpdate","Application");;

				System.Diagnostics.EventLog eg= new System.Diagnostics.EventLog(); //�����¼�����
				eg.Source = "AutoUpdate"; //�����¼�Դ
				eg.WriteEntry(message); //д�¼���־��Ϣ
			}
			catch(Exception)
			{
				return false;  //û��Ȩ�޵������д��־����ʧ��
			}

			return true;       //д��־�ɹ�
		}
		
		/// <summary>
		///  �������ļ�
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string ReadConfig(string key)
		{
			string configStr ="";
			string XPath="/configuration/add[@key='?']";
			XmlDocument domWebConfig=new XmlDocument();
			domWebConfig.Load(Application.StartupPath+"\\AutoApp.config");
			XmlNode addKey=domWebConfig.SelectSingleNode( (XPath.Replace("?",key)) );
			if(addKey == null)
			{
				throw new ArgumentException("û���ҵ�<add key='"+key+"' value=.../>�����ý�");
			}
			else
			{
				try
				{
					configStr=addKey.Attributes["value"].InnerText;
				}
				catch(Exception ee)
				{
					string Error = ee.Message;
				}
			}
			return configStr;
		}
		/// <summary>
		/// д�����ļ�
		/// </summary>
		/// <param name="key"></param>
		/// <param name="keyvalues"></param>
		public  void  WriteConfig(string key ,string keyvalues)
		{
			string XPath="/configuration/add[@key='?']";
			XmlDocument domWebConfig=new XmlDocument();
			domWebConfig.Load(Application.StartupPath +"\\AutoApp.config");
			XmlNode addKey=domWebConfig.SelectSingleNode( (XPath.Replace("?",key)) );
			if(addKey == null)
			{
				throw new ArgumentException("û���ҵ�<add key='"+key+"' value=.../>�����ý�");
			}
			else
			{
				try
				{
					addKey.Attributes["value"].InnerText =keyvalues ;
				}
				catch(Exception ee)
				{
					string Error = ee.Message;
				}
			}
			domWebConfig.Save(Application.StartupPath+"\\AutoApp.config");
		}

		/// <summary>
		/// �õ������ݿ������
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public OracleConnection  ConnectOracle(string str)
		{
            //{D515E09B-E299-47e0-BF19-EDFDB6E4C775}
			//str = Neusoft.HisDecrypt.Decrypt(str);
            //str = Neusoft.HisCrypto.DESCryptoService.DESDecrypt(str, Neusoft.FrameWork.Management.Connection.DESKey);
			wait.lblTip.Text = "�����������ݿ�.....";
			System.Windows.Forms.Application.DoEvents();
			wait.Refresh();
			//			str = Neusoft.HisDecrypt.Decrypt(str);
			OracleConnection con=null ;
			if(str!="")
			{
				try
				{
					con = new OracleConnection(str);
					con.Open();
				}
				catch(Exception ee)
				{
                    try
                    {
                        wait.lblTip.Text = "���ڽ��еڶ����������ݿ�.....";
                        System.Windows.Forms.Application.DoEvents();
                        wait.Refresh();
                        con = new OracleConnection(str);
                        con.Open();
                    }
                    catch (Exception f)
                    {
                        this.Err = "�������ݿ�ʧ�� " + f.Message;
                        con = null;
                    }
                   
					
				}
			}
			return con; 
		}
		/// <summary>
		/// �õ������ݿ������
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public OracleConnection ConnectOracle()
		{
			string str = GetSetting();
			wait.lblTip.Text = "�����������ݿ�.....";
			System.Windows.Forms.Application.DoEvents();
			wait.Refresh();
			//			str = Neusoft.HisDecrypt.Decrypt(str);
			OracleConnection con = null;
			if (str != "")
			{
				try
				{                    
					con = new System.Data.OracleClient.OracleConnection(str);
					con.Open();
				}
				catch (Exception ee)
				{
                    try
                    {
                        wait.lblTip.Text = "���ڽ��еڶ����������ݿ�.....";
                        System.Windows.Forms.Application.DoEvents();
                        wait.Refresh();
                        con = new OracleConnection(str);
                        con.Open();
                    }
                    catch (Exception f)
                    {
                        this.Err = "�������ݿ�ʧ�� " + f.Message;
                        con = null;
                    }
				}
			} 
			return con;
		}
		/// <summary>
		/// ��������ļ�
		/// </summary>
		/// <returns></returns>
		private string GetSetting()
		{
			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
			try
			{
				doc.Load(Application.StartupPath + "\\url.xml");
			}
			catch (Exception ex)
			{
				MessageBox.Show("װ��urlʧ�ܣ�\n" + ex.Message);
				return null;
			}
			System.Xml.XmlNode node = doc.SelectSingleNode("//dir");
			if (node == null)
			{
				MessageBox.Show("url����dir��������");
				return null;
			}

			string ServerPath = node.InnerText;
            string serverSettingFileName = "profile.xml"; //�������ļ���

			try
			{
				doc.Load(ServerPath + serverSettingFileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show("װ��Profile.xmlʧ�ܣ�\n" + ex.Message);
				return null;
			}

			node = doc.SelectSingleNode("/����/�Զ��������ݿ�����");

			if (node == null)
			{
				MessageBox.Show("û���ҵ����ݿ�����!");
				return null;
			}

			string strDataSource = node.Attributes[0].Value;

			if (strDataSource.ToUpper().IndexOf("PASSWORD") > 0)
			{

			}
			else //��Ҫ����
			{
                //strDataSource = Neusoft.HisDecrypt.Decrypt(strDataSource);
                //strDataSource = Neusoft.HisCrypto.DESCryptoService.DESDecrypt(strDataSource,Neusoft.FrameWork.Management.Connection.DESKey);
			}

			node = doc.SelectSingleNode("/����/����");

			return strDataSource;


		}
      /// <summary>
      /// �Ǽǻ����ĵ�¼ʱ��
      /// </summary>
      /// <param name="con">���ݿ�����</param>
      /// <param name="machineName">��������</param>
      /// <returns></returns>
        public int Login( OracleConnection con,string machineName) {
            string strSQL = string.Empty;
            strSQL = "insert into  login_machine values(loginid.nextval,'{0}',sysdate)";
            int val = 0;
            try 
	        {	        
                 strSQL = string.Format(strSQL,machineName);
                 val = this.ExeNoQuery(con, strSQL);
	        }
	        catch (Exception)
	        {

                val = -1;
	        }
            return val;
           
        }
		[DllImport("kernel32.dll", SetLastError=true)]  
		public static extern int SetLocalTime (ref SystemTime lpSystemTime); 
		/// <summary>
		/// �ж��ַ���byte�Ƿ񳬳�����--���ַ���ת��Ϊbyte�����Ƚ�
		/// </summary>
		/// <param name="Str">������ַ���</param>
		/// <param name="MaxLengh">Ҫ�жϵ���󳤶�</param>
		/// <returns>true ��Χ֮�� false ������Χ</returns>
		public int ValidMaxLengh(string Str)
		{
			if(Str==null) Str  = "";
			byte [] Byte =System.Text.Encoding.Default.GetBytes(Str);
			int Len = 0;
			Len = Byte.Length;
			return Len;
		}
		public struct SystemTime 
		{ 
			public short wYear; 
			public short wMonth; 
			public short wDayOfWeek; 
			public short wDay; 
			public short wHour; 
			public short wMinute; 
			public short wSecond; 
			public short wMilliseconds; 
		} 
	}
}