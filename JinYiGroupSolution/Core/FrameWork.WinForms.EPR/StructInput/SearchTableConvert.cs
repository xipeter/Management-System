using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace Neusoft.FrameWork.EPRControl.StructInput
{
    public class SearchTableConvert : TypeConverter
    {
        public SearchTableConvert()
        {
            this.Init();
        }

        private ArrayList alTables;

        private static System.Collections.Generic.Dictionary<string, string> searchTables;
        public static System.Collections.Generic.Dictionary<string, string> SearchTables
        {
            get
            {
                if (searchTables == null || searchTables.Count == 0)
                {
                    searchTables = new Dictionary<string, string>();
                    searchTables.Add("T", "局部解剖学");
                    searchTables.Add("M", "病理形态");
                    searchTables.Add("F", "功能");
                    searchTables.Add("D", "疾病/诊断");
                    searchTables.Add("P", "操作");
                    searchTables.Add("L", "活有机体");
                    searchTables.Add("C", "化学制品、药物和生物制品");
                    searchTables.Add("A", "物理因素");
                    searchTables.Add("J", "职业");
                    searchTables.Add("S", "社会");
                    searchTables.Add("G", "连接词/修饰词");
                    searchTables.Add("X", "制药厂");
                }
                return searchTables;
            }
        }

        private void Init()
        {
            this.alTables = new ArrayList();
            foreach (string key in SearchTables.Keys)
            {
                this.alTables.Add(SearchTables[key]);
            }
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            StandardValuesCollection stv = new StandardValuesCollection(this.alTables);
            return stv;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            else
            {
                return base.CanConvertFrom(context, sourceType);
            }
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                string table = (string)value;
                if (this.alTables.Contains(table))
                {
                    return table;
                }
                else
                {
                    return base.ConvertFrom(context, culture, value);
                }
            }
            else
            {
                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}
