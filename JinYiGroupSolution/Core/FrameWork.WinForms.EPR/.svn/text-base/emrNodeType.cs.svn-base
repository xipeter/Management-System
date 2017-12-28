using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.EPRControl
{
    public class emrNodeType : System.ComponentModel.StringConverter
    {
        public static string[] Groups = new string[] { "CheckBox", "ComboBox" };

        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(Groups);
        }

        public override bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }
        public static void SetGroups(string[] strGroups)
        {
            Groups = strGroups;
        }
        public static string[] GetGroups()
        {
            return Groups;
        }
    }
}
