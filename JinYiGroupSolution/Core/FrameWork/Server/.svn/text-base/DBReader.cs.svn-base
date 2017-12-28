using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.Server
{
    public class DBReader:System.Data.IDataReader
    {

        public DBReader(System.Data.DataTable dt)
        {
            this.dt = dt;
            isClosed = false;
            iCursor = -1;
        }
        private System.Data.DataTable dt = null;
        private bool isClosed = false;
        private int iCursor = -1;
        #region IDataReader 成员

        public void Close()
        {
            dt.Dispose();
            isClosed = true;
        }

        public int Depth
        {
            get { return dt.Rows.Count; }
        }

        public System.Data.DataTable GetSchemaTable()
        {
            return dt;
        }

        public bool IsClosed
        {
            get { return isClosed; }
        }

        public bool NextResult()
        {
            iCursor++;
            if (iCursor >= dt.Rows.Count)
                return false;
            return true;
        }

        public bool Read()
        {
            return NextResult();
        }

        public int RecordsAffected
        {
            get { return 0; }
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            this.Close();
            
        }

        #endregion

        #region IDataRecord 成员

        public int FieldCount
        {
            get { return dt.Columns.Count; }
        }

        public bool GetBoolean(int i)
        {
             return Boolean.Parse(dt.Rows[iCursor][i].ToString());
        }

        public byte GetByte(int i)
        {
            return byte.Parse(dt.Rows[iCursor][i].ToString());
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return 0;
        }

        public char GetChar(int i)
        {
            return char.Parse(dt.Rows[iCursor][i].ToString());
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return 0;
        }

        public System.Data.IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            return dt.Columns[i].DataType.FullName;
        }

        public DateTime GetDateTime(int i)
        {
            return DateTime.Parse(dt.Rows[iCursor][i].ToString());
        }

        public decimal GetDecimal(int i)
        {
            return decimal.Parse(dt.Rows[iCursor][i].ToString());
        }

        public double GetDouble(int i)
        {
            return double.Parse(dt.Rows[iCursor][i].ToString());
        }

        public Type GetFieldType(int i)
        {
            return dt.Columns[i].DataType;
        }

        public float GetFloat(int i)
        {
            return float.Parse(dt.Rows[iCursor][i].ToString());
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            return short.Parse(dt.Rows[iCursor][i].ToString());
        }

        public int GetInt32(int i)
        {
            return int.Parse(dt.Rows[iCursor][i].ToString());
        }

        public long GetInt64(int i)
        {
            return long.Parse(dt.Rows[iCursor][i].ToString());
        }

        public string GetName(int i)
        {
            return dt.Columns[i].Caption;
        }

        public int GetOrdinal(string name)
        {
            return 0;
        }

        public string GetString(int i)
        {
            return dt.Rows[iCursor][i].ToString();
        }

        public object GetValue(int i)
        {
            return dt.Rows[iCursor][i];
        }

        public int GetValues(object[] values)
        {
            return 0;
        }

        public bool IsDBNull(int i)
        {
            if (dt.Rows[iCursor][i] == null || dt.Rows[iCursor][i].GetType() == typeof(DBNull))
                return true;
            else
                return false;
        }

        public object this[string name]
        {
            get { return dt.Rows[iCursor][name]; }
        }

        public object this[int i]
        {
            get { return dt.Rows[iCursor][i]; }
        }

        #endregion
    }
}
