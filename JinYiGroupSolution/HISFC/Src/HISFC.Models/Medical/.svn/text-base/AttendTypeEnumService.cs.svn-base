using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Models.Medical
{
    /// <summary>
    /// [功能描述: 医务排班大类枚举服务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class AttendTypeEnumService
    {
        static AttendTypeEnumService()
        {
            items[AttendType.FirstAttend] = "一值";
            items[AttendType.SecondAttend] = "二值";
            items[AttendType.ThirdAttend] = "三值";
            items[AttendType.GeneralShift] = "总班";
            items[AttendType.FestivalAttend] = "节假日";
            items[AttendType.DutyAttend] = "出勤";
        }

        static Hashtable items = new Hashtable();

        public static ArrayList List()
        {
            ArrayList list=new ArrayList();
            foreach (DictionaryEntry de in items)
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = de.Key.ToString();
                obj.Name = de.Value.ToString();
                list.Add(obj);
            }
            return list;
        }

        public static String[] StringItems()
        {
            string[] arrStr = new string[items.Count];
            Array arr = List().ToArray();
            for (int i = 0; i < items.Count; i++)
            {
                arrStr[i] = arr.GetValue(i).ToString();
            }

            return arrStr;
        }

        public static string GetName(AttendType attendType)
        {
            return items[attendType].ToString();
        }

        public static AttendType GetID(string Name)
        {
            foreach (DictionaryEntry de in items)
            {
                if (de.Value.ToString() == Name)
                {
                    return (AttendType)de.Key;
                }
            }
            return AttendType.FirstAttend;
        }

    }

    /// <summary>
    /// 排班大类
    /// </summary>
    public enum AttendType
    {
        /// <summary>
        /// 一值
        /// </summary>
        FirstAttend = 0,
        /// <summary>
        /// 二值
        /// </summary>
        SecondAttend = 1,
        /// <summary>
        /// 三值
        /// </summary>
        ThirdAttend = 2,
        /// <summary>
        /// 总班
        /// </summary>
        GeneralShift = 3,
        /// <summary>
        /// 节假日
        /// </summary>
        FestivalAttend = 4,
        /// <summary>
        /// 出勤
        /// </summary>
        DutyAttend = 5
    }

    /// <summary>
    /// 出勤大类
    /// </summary>
    public enum AttendanceType
    {
        /// <summary>
        /// 外派
        /// </summary>
        Assignment,
        /// <summary>
        /// 加班
        /// </summary>
        Overtime,
        /// <summary>
        /// 补休
        /// </summary>
        OffRest,
        /// <summary>
        /// 串休
        /// </summary>
        BreakRest,
        /// <summary>
        /// 夜班
        /// </summary>
        NightShift,
        /// <summary>
        /// 节假日
        /// </summary>
        Holidays,
        /// <summary>
        /// 缺勤
        /// </summary>
        Absence,

        /// <summary>
        /// 正常出勤{D06DDE4E-9595-4b52-A3DE-DA22B4E5A792}
        /// </summary>
        Normal

    }

    /// <summary>
    /// 出勤大类
    /// </summary>
    public class AttendanceTypeEnumService
    {
        static AttendanceTypeEnumService()
        {
            items[AttendanceType.Assignment] = "外派";
            items[AttendanceType.Overtime] = "加班";
            items[AttendanceType.OffRest] = "补休";
            items[AttendanceType.BreakRest] = "串休";
            items[AttendanceType.Holidays] = "节假日";
            items[AttendanceType.NightShift] = "夜班";
            items[AttendanceType.Absence] = "缺勤";
            /// 正常出勤{D06DDE4E-9595-4b52-A3DE-DA22B4E5A792}
            items[AttendanceType.Normal] = "正常出勤";
        }

        static Hashtable items = new Hashtable();

        public static ArrayList List()
        {
            ArrayList list=new ArrayList();
            foreach (DictionaryEntry de in items)
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = de.Key.ToString();
                obj.Name = de.Value.ToString();
                list.Add(obj);
            }
            return list;
        }

        public static String[] StringItems()
        {
            string[] arrStr = new string[items.Count];
            Array arr = List().ToArray();
            for (int i = 0; i < items.Count; i++)
            {
                arrStr[i] = arr.GetValue(i).ToString();
            }

            return arrStr;
        }

        public static string GetName(AttendanceType ID)
        {
            return items[ID].ToString();
        }

        public static AttendanceType GetID(string Name)
        {
            foreach (DictionaryEntry de in items)
            {
                if (de.Value.ToString() == Name)
                {
                    return (AttendanceType)de.Key;
                }
            }

            return AttendanceType.Assignment;
        }
    }
}
