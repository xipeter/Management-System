using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.Management
{
    /// <summary>
    /// wolf 重构 Reader 
    /// 为三层应用打基础
    /// </summary>
    public class DBReader:System.Data.IDataReader
    {
        private System.Data.IDataReader reader = null;
        public DBReader(System.Data.IDataReader reader)
        {
            this.reader = reader;
        }
        public void Close()
        {
            try
            {
                this.reader.Close();
            }
            catch { }
            CloseDB();

        }
        private void CloseDB()
        {
            //Server.Function manager = new Neusoft.NFC.Server.Function();
            //Server.Function.Manager.CloseDB();
        }
        public object this[int i]
        {
            get{
                
                return this.reader[i];
            }
        }
        public object this[string name]
        {
            get
            {

                return this.reader[name];
            }
        }
        public bool Read()
        {
            
            return this.reader.Read();
        }

        public int FieldCount
        {
            get
            {
                return this.reader.FieldCount;
            }
        }
        public object GetValue(int i)
        {

            return this.reader.GetValue(i);
            
        }

        public bool IsDBNull(int i)
        {
            return this.reader.IsDBNull(i);
        }
        public bool IsClosed
        {
            get
            {

                return this.reader.IsClosed;
            }
        }
        public void Dispose()
        {
            this.reader.Dispose();
            CloseDB();
        }
        public string GetName(int i)
        {
            return this.reader.GetName(i);
        }
        public decimal GetDecimal(int i)
        {
            return this.reader.GetDecimal(i);
        }
        public string GetString(int i)
        {
            return this.reader.GetString(i);
        }
        public DateTime  GetDateTime(int i)
        {
            return this.reader.GetDateTime(i);
        }

        #region IDataReader 成员


        public int Depth
        {
            get { return this.reader.Depth; }
        }

        public System.Data.DataTable GetSchemaTable()
        {
            return this.reader.GetSchemaTable();
        }

        public bool NextResult()
        {
            return this.reader.NextResult();
        }

        public int RecordsAffected
        {
            get { return this.reader.RecordsAffected; }
        }

        #endregion

        #region IDataRecord 成员


        public bool GetBoolean(int i)
        {
            return this.reader.GetBoolean(i);
        }

        public byte GetByte(int i)
        {
            return this.reader.GetByte(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return this.reader.GetBytes(i,fieldOffset,buffer,bufferoffset,length);
        }

        public char GetChar(int i)
        {
            return this.reader.GetChar(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return this.reader.GetChars(i,fieldoffset,buffer,bufferoffset,length);
        }

        public System.Data.IDataReader GetData(int i)
        {
            return this.reader.GetData(i);
        }

        public string GetDataTypeName(int i)
        {
            return this.reader.GetDataTypeName(i);
        }

        public double GetDouble(int i)
        {
            return this.reader.GetDouble(i);
        }

        public Type GetFieldType(int i)
        {
            return this.reader.GetFieldType(i);
        }

        public float GetFloat(int i)
        {
            return this.reader.GetFloat(i);
        }

        public Guid GetGuid(int i)
        {
            return this.reader.GetGuid(i);
        }

        public short GetInt16(int i)
        {
            return this.reader.GetInt16(i);
        }

        public int GetInt32(int i)
        {
            return this.reader.GetInt32(i);
        }

        public long GetInt64(int i)
        {
            return this.reader.GetInt64(i);
        }

        public int GetOrdinal(string name)
        {
            return this.reader.GetOrdinal(name);
        }

        public int GetValues(object[] values)
        {
            return this.reader.GetValues(values);
        }

        #endregion
    }

   
}
