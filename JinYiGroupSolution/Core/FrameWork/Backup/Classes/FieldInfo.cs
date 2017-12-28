using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.WinForms.Classes
{
    /// <summary>
    /// [功能描述: 字段信息]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-24]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class FieldInfo
    {
        public string ID;
        public string Name;
        public bool IsPrimaryKey;
        public FieldType DataType;
        public bool Nullable;
        public short Length;
        public string Default;
    }

    /// <summary>
    /// 字段类型
    /// </summary>
    public enum FieldType
    {
        Varchar2,
        Number,
        Date,
    }

    /// <summary>
    /// DB2字段类型
    /// </summary>
    public enum DB2FieldType
    {
        SMALLINT,
        INTEGER,
        BIGINT,
        REAL,
        DOUBLE,
        NUMERIC,
        Varchar,
        TimeStamp
    }
}
