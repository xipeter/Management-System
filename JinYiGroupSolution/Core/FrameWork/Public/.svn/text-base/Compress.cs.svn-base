using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;

using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;

namespace Neusoft.FrameWork.Public
{
	/// <summary>
    /// Compress<br></br>
    /// [功能描述: Compress类]<br></br>
    /// [创 建 者: 李云凡从网上下载的]<br></br>
    /// [创建时间: 2006-08-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
	public sealed class CompressionHelper
    {
        public  CompressionHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量
        #endregion

        #region 属性
        #endregion

        #region 方法

       	/// <summary>
		/// 压缩多文件和子文件夹
		/// </summary>
		/// <param name="folderPath">带目录属性的文件夹</param>
		/// <returns>返回压缩性字节</returns>
		public static byte[] CompressFolder( string folderPath )
		{
            //如果文件夹或目录为空返回
			if ( folderPath==null || folderPath.Length<=0 )
			{

				return null;
			}
			else
			{
				using ( MemoryStream buf = new MemoryStream() )
				using ( ZipOutputStream zip = new ZipOutputStream( buf ) )
				{
					Crc32 crc = new Crc32();
					zip.SetLevel( 9 );	// 0..9.

					DoCompressFolder(
						buf,
						zip,
						crc,
						folderPath,
						folderPath );

					zip.Finish();

					// --

					byte[] c = new byte[buf.Length];
					buf.Seek( 0, SeekOrigin.Begin );
					buf.Read( c, 0, c.Length );

					// --

					zip.Close();

					return c;
				}	 
			}		
		}

        /// <summary>
        /// 压缩多文件夹
        /// </summary>
        /// <param name="filePaths">文件夹数组</param>
        /// <returns>返回压缩后字节</returns>
		public static byte[] CompressFiles( string[] filePaths )
		{
			if ( filePaths==null || filePaths.Length<=0 )
			{
				return null;
			}
			else
			{
				using ( MemoryStream buf = new MemoryStream() )
				using ( ZipOutputStream zip = new ZipOutputStream( buf ) )
				{
					Crc32 crc = new Crc32();
					zip.SetLevel( 9 );	// 0..9.

					foreach ( string filePath in filePaths )
					{
						using ( FileStream fs = new FileStream( 
									filePath, 
									FileMode.Open, 
									FileAccess.Read ) )
						using ( BinaryReader r = new BinaryReader( fs ) )
						{
							byte[] buffer = new byte[fs.Length];
							fs.Read( buffer, 0, buffer.Length );
        			
							ZipEntry entry = new ZipEntry( Path.GetFileName( filePath ) );
							entry.DateTime = DateTime.Now;
							entry.Size = buffer.Length;

							crc.Reset();
							crc.Update( buffer );

							entry.Crc = crc.Value;

							zip.PutNextEntry( entry );
							zip.Write( buffer, 0, buffer.Length );
						}
					}

					zip.Finish();

					// --

					byte[] c = new byte[buf.Length];
					buf.Seek( 0, SeekOrigin.Begin );
					buf.Read( c, 0, c.Length );

					// --

					zip.Close();

					return c;
				}	 
			}
		}

		/// <summary>
		/// 用压缩算法压缩一个文件
		/// </summary>
		/// <param name="filePath">需要压缩的文件目录</param>
		/// <returns>返回压缩文件的字节</returns>
		public static byte[] CompressFile( string filePath )
		{
			using ( FileStream fs = new FileStream( 
						filePath, 
						FileMode.Open, 
						FileAccess.Read ) )
			using ( BinaryReader r = new BinaryReader( fs ) )
			{
				byte[] buf = new byte[fs.Length];
				r.Read( buf, 0, (int)fs.Length );

				return CompressBytes( buf );
			}
		}

		/// <summary>
		/// 用压缩算法压缩一下XML文档
		/// </summary>
		/// <param name="input">需要压缩的XML文档.</param>
		/// <returns>返回压缩的字节</returns>
		public static byte[] CompressXmlDocument( XmlDocument input )
		{

			return CompressString( input.InnerXml );
		}		
	
		/// <summary>
		/// 用压缩算法压缩一个字符串
		/// </summary>
		/// <param name="input">输入的字符串.</param>
		/// <returns>返回字节</returns>
		public static byte[] CompressString( string input )
		{
			return CompressBytes(Encoding.UTF8.GetBytes( input ) );
		}		
		
		/// <summary>
		/// 用压缩算法压缩一个DataSet
		/// </summary>
		/// <param name="input">输入的DataSet</param>
		/// <returns>返回字节</returns>
		public static byte[] CompressDataSet( DataSet input )
		{
			BinaryFormatter bf = new BinaryFormatter();

			using ( MemoryStream ms = new MemoryStream() )
			{
				bf.Serialize( ms, input );
				return CompressBytes( ms.GetBuffer() );
			}
		}		
		
		/// <summary>
		/// 用压缩算法压缩字节
		/// </summary>
		/// <param name="input">需要压缩的字节</param>
		/// <returns>返回压缩的字节</returns>
		public static byte[] CompressBytes( byte[] input )
		{
			using ( MemoryStream buf = new MemoryStream() )
			using ( ZipOutputStream zip = new ZipOutputStream( buf ) )
			{
				Crc32 crc = new Crc32();
				zip.SetLevel( 9 );	// 0..9.

				ZipEntry entry = new ZipEntry( string.Empty );
				entry.DateTime = DateTime.Now;
				entry.Size = input.Length;

				crc.Reset();
				crc.Update( input );

				entry.Crc = crc.Value;

				zip.PutNextEntry( entry );

				zip.Write( input, 0, input.Length );
				zip.Finish();

				// --

				byte[] c = new byte[buf.Length];
				buf.Seek( 0, SeekOrigin.Begin );
				buf.Read( c, 0, c.Length );

				// --

				zip.Close();

				return c;
			}	 
		}

		/// <summary>
		/// 把一个压缩的字节流解压到指定的文件夹
		/// <param name="input">压缩的字节流,包括文件的和子目录</param>
		/// <param name="folderPath">指定的解压缩目录</param>
        /// </summary>
		public static void DecompressFolder( byte[] input, string folderPath )
		{
			if ( !Directory.Exists( folderPath ) )
			{
				Directory.CreateDirectory( folderPath );
			}
            using ( MemoryStream mem = new MemoryStream( input ) )
			using (	ZipInputStream stm = new ZipInputStream( mem ) )
			{
				ZipEntry entry;
				while ( (entry = stm.GetNextEntry())!=null )
				{
					// Create this stream new for each zip entry.
					using ( MemoryStream mem2 = new MemoryStream() )
					{
						byte[] data = new byte[4096];

						while ( true ) 
						{
							int size = stm.Read( data, 0, data.Length );
							if ( size>0 ) 
							{
								mem2.Write( data, 0, size );
							} 
							else 
							{
								break;
							}
						}

						// --
						// Finished reading, now write to file.

						string filePath = Path.Combine( folderPath, entry.Name );

						if ( !Directory.Exists( Path.GetDirectoryName( filePath ) ) )
						{
							Directory.CreateDirectory( Path.GetDirectoryName( filePath ) );
						}

						if ( File.Exists( filePath ) )
						{
							File.Delete( filePath );
						}

						using ( BinaryReader r = new BinaryReader( mem2 ) )
						using ( FileStream fs = new FileStream( 
									filePath, 
									FileMode.CreateNew, 
									FileAccess.Write ) )
						using ( BinaryWriter w = new BinaryWriter( fs ) )
						{
							byte[] buf = new byte[mem2.Length];
							mem2.Seek( 0, SeekOrigin.Begin );
							r.Read( buf, 0, (int)mem2.Length );

							w.Write( buf );
						}
					}	 
				}
			}
		}

		/// <summary>
		/// 解压一个压缩指定到固定的文件夹
		/// </summary>
		/// <param name="input">传入的字节流</param>
		/// <param name="folderPath">指定的文件夹</param>
		public static void DecompressFiles( byte[] input, string folderPath )
		{
			if ( !Directory.Exists( folderPath ) )
			{
				Directory.CreateDirectory( folderPath );
			}

			using ( MemoryStream mem = new MemoryStream( input ) )
			using (	ZipInputStream stm = new ZipInputStream( mem ) )
			{
				ZipEntry entry;
				while ( (entry = stm.GetNextEntry())!=null )
				{
					// Make this stream new for each zip entry.
					using ( MemoryStream mem2 = new MemoryStream() )
					{
						byte[] data = new byte[4096];

						while ( true ) 
						{
							int size = stm.Read( data, 0, data.Length );
							if ( size>0 ) 
							{
								mem2.Write( data, 0, size );
							} 
							else 
							{
								break;
							}
						}

						// --
						// Finished reading, now write to file.

						string filePath = Path.Combine( folderPath, entry.Name );

						if ( !Directory.Exists( Path.GetDirectoryName( filePath ) ) )
						{
							Directory.CreateDirectory( Path.GetDirectoryName( filePath ) );
						}

						if ( File.Exists( filePath ) )
						{
							File.Delete( filePath );
						}

						using ( BinaryReader r = new BinaryReader( mem2 ) )
						using ( FileStream fs = new FileStream( 
									filePath, 
									FileMode.CreateNew, 
									FileAccess.Write ) )
						using ( BinaryWriter w = new BinaryWriter( fs ) )
						{
							byte[] buf = new byte[mem2.Length];
							mem2.Seek( 0, SeekOrigin.Begin );
							r.Read( buf, 0, (int)mem2.Length );

							w.Write( buf );
						}
					}	 
				}
			}
		}

		/// <summary>
		/// Decompress a byte stream that was formerly compressed
		/// with the CompressFile() routine with the ZIP algorithm and 
		/// store it to a file.
		/// </summary>
		/// <param name="input">The buffer that contains the compressed
		/// stream with the file.</param>
		/// <param name="filePath">The file path where the file will be 
		/// stored.</param>
		public static void DecompressFile( byte[] input, string filePath )
		{
			if ( File.Exists( filePath ) )
			{
				File.Delete( filePath );
			}

			using ( FileStream fs = new FileStream( 
						filePath, 
						FileMode.CreateNew, 
						FileAccess.Write ) )
			using ( BinaryWriter w = new BinaryWriter( fs ) )
			{
				byte[] buf = DecompressBytes( input );
				w.Write( buf );
			}
		}

		/// <summary>
		/// Decompress a byte stream of an XML document that was formerly
		/// compressed with the CompressXmlDocument() routine with 
		/// the ZIP algorithm.
		/// </summary>
		/// <param name="input">The buffer that contains the compressed
		/// stream with the XML document.</param>
		/// <returns>Returns the decompressed XML document.</returns>
		public static XmlDocument DecompressXmlDocument( 
			byte[] input )
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml( DecompressString( input ) );

			return doc;
		}

		/// <summary>
		/// Decompress a byte stream of a string that was formerly 
		/// compressed with the CompressString() routine with the ZIP algorithm.
		/// </summary>
		/// <param name="input">The buffer that contains the compressed
		/// stream with the string.</param>
		/// <returns>Returns the decompressed string.</returns>
		public static string DecompressString( 
			byte[] input )
		{
			return Encoding.UTF8.GetString( DecompressBytes( input ) );
		}

		/// <summary>
		/// Decompress a byte stream of a DataSet that was formerly 
		/// compressed with the CompressDataSet() routine with the ZIP algorithm.
		/// </summary>
		/// <param name="input">The buffer that contains the compressed
		/// stream with the DataSet.</param>
		/// <returns>Returns the decompressed DataSet.</returns>
		public static DataSet DecompressDataSet( 
			byte[] input )
		{
			BinaryFormatter bf = new BinaryFormatter();

			byte[] buffer = DecompressBytes( input );
			using ( MemoryStream ms = new MemoryStream( buffer ) )
			{
				return (DataSet)bf.Deserialize( ms );
			}
		}

		/// <summary>
		/// Decompress a byte stream that was formerly compressed
		/// with the CompressBytes() routine with the ZIP algorithm.
		/// </summary>
		/// <param name="input">The buffer that contains the compressed
		/// stream with the bytes.</param>
		/// <returns>Returns the decompressed bytes.</returns>
		public static byte[] DecompressBytes( 
			byte[] input )
		{
			using ( MemoryStream mem = new MemoryStream( input ) )
			using (	ZipInputStream stm = new ZipInputStream( mem ) )
			using ( MemoryStream mem2 = new MemoryStream() )
			{
				ZipEntry entry = stm.GetNextEntry();
				if ( entry!=null )
				{
					byte[] data = new byte[4096];

					while ( true ) 
					{
						int size = stm.Read( data, 0, data.Length );
						if ( size>0 ) 
						{
							mem2.Write( data, 0, size );
						} 
						else 
						{
							break;
						}
					}
				}

				using ( BinaryReader r = new BinaryReader( mem2 ) )
				{
					byte[] c = new byte[mem2.Length];
					mem2.Seek( 0, SeekOrigin.Begin );
					r.Read( c, 0, (int)mem2.Length );

					return c;
				}
			}	 
		}

        /// <summary>
        /// 压缩文件夹
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="zip"></param>
        /// <param name="crc"></param>
        /// <param name="baseFolderPath"></param>
        /// <param name="currentFolderPath"></param>
        private static void DoCompressFolder(
            MemoryStream buf,
            ZipOutputStream zip,
            Crc32 crc,
            string baseFolderPath,
            string currentFolderPath)
        {
            // Add all files of the current folder.
            foreach (string filePath in
                Directory.GetFiles(currentFolderPath))
            {
                // Make relative path for storing the information
                // inside the ZIP file.
                string relativeFilePath = filePath.Substring(
                    baseFolderPath.Length).Trim('\\');

                using (FileStream fs = new FileStream(
                            filePath,
                            FileMode.Open,
                            FileAccess.Read))
                using (BinaryReader r = new BinaryReader(fs))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);

                    ZipEntry entry = new ZipEntry(relativeFilePath);
                    entry.DateTime = DateTime.Now;
                    entry.Size = buffer.Length;

                    crc.Reset();
                    crc.Update(buffer);

                    entry.Crc = crc.Value;

                    zip.PutNextEntry(entry);
                    zip.Write(buffer, 0, buffer.Length);
                }
            }

            // Recurse all subfolders.
            foreach (string folderPath in
                Directory.GetDirectories(currentFolderPath))
            {
                DoCompressFolder(
                    buf,
                    zip,
                    crc,
                    baseFolderPath,
                    folderPath);
            }
        }

			#endregion

	 
    }

	
}
