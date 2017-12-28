using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Material
{
    public class MarkCellType
    {
        private MarkCellType()
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

        public class DateCellType : FarPoint.Win.Spread.CellType.DateTimeCellType
        {
            public DateCellType()
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

        private class MarkSubEditor : FarPoint.Win.Spread.CellType.ISubEditor
        {
            #region ISubEditor ≥…‘±

            public object GetValue()
            {
                return null;
            }


            public event System.EventHandler CloseUp;

            public void SetValue(object value)
            {

            }


            public System.Drawing.Point GetLocation(System.Drawing.Rectangle rect)
            {
                return new System.Drawing.Point();
            }


            public System.Windows.Forms.Control GetSubEditorControl()
            {
                return null;
            }


            public event System.EventHandler ValueChanged;

            public System.Drawing.Size GetPreferredSize()
            {
                return new System.Drawing.Size();
            }

            #endregion
        }
    }
}
