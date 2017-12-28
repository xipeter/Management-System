using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Drawing;
namespace Neusoft.FrameWork.EPRControl
{  
    public class UIemrGridEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            return "…Ë÷√";
        }
        public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {

        }
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }

}
