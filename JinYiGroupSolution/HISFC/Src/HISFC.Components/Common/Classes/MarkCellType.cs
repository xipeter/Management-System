using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Common.Classes
{
    /// <summary>
    /// 屏蔽CellType弹出控件
    /// 
    /// Add By liangjz
    /// </summary>
    [System.Obsolete("请使用Neusoft.FrameWork.WinForms.Classes.MarkCellType类",false)]
    public class MarkCellType 
    {
        public MarkCellType()
        { 

        }

        public class NumCellType : FarPoint.Win.Spread.CellType.NumberCellType
        {
            public NumCellType()
            {
                this.SubEditor = new MarkSubEditor();
            }

            public override FarPoint.Win.Spread.CellType.ISubEditor SubEditor
            {
                get
                {
                    return null;
                }
                set
                {
                    base.SubEditor = value;
                }
            }
        }

        public class DateTimeCellType : FarPoint.Win.Spread.CellType.DateTimeCellType
        {
            public DateTimeCellType()
            {
 
            }

            public override FarPoint.Win.Spread.CellType.ISubEditor SubEditor
            {
                get
                {
                    return null;
                }
                set
                {
                    base.SubEditor = value;
                }
            }
        }

        private class MarkSubEditor : FarPoint.Win.Spread.CellType.ISubEditor
        {
            public MarkSubEditor()
            {

            }

            #region ISubEditor 成员

            public event EventHandler CloseUp;

            public System.Drawing.Point GetLocation(System.Drawing.Rectangle rect)
            {
                return new System.Drawing.Point();
            }

            public System.Drawing.Size GetPreferredSize()
            {
                return new System.Drawing.Size();
            }

            public System.Windows.Forms.Control GetSubEditorControl()
            {
                return null;
            }

            public object GetValue()
            {
                return null;
            }

            public void SetValue(object value)
            {

            }

            public event EventHandler ValueChanged;

            #endregion
        }
    }
}
