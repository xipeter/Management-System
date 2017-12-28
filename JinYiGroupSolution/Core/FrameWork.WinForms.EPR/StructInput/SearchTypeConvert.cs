using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.FrameWork.EPRControl.StructInput
{
    public class SearchTypeConvert : System.ComponentModel.TypeConverter
    {
        private ArrayList alValues;
        public SearchTypeConvert()
        {
            this.alValues = new ArrayList();
            this.alValues.Add(enumSearchType.CNOMEN);
            this.alValues.Add(enumSearchType.TERMCODE);
            this.alValues.Add(enumSearchType.ENOMEN);
            this.alValues.Add(enumSearchType.PY_CODE);
            this.alValues.Add(enumSearchType.WB_CODE);
        }

        public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }

        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            StandardValuesCollection sdv = new StandardValuesCollection(this.alValues);
            return sdv;
        }

        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, Type sourceType)
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

        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                enumSearchType searchType = (enumSearchType)Enum.Parse(typeof(enumSearchType), (string)value);
                return searchType;
            }
            else
            {
                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}
