using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using Neusoft.FrameWork.WinForms.Forms;

namespace Neusoft.FrameWork.WinForms.Controls
{
    /// <summary>
    /// NeuSpread<br></br>
    /// [功能描述: 简单查询表格控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-01]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [ToolboxBitmap(typeof(FarPoint.Win.Spread.FpSpread))]
    public partial class SimpleQuerySpread : Controls.NeuSpread, IMaintenanceControlable
    {
        private SimpleQuerySpread()
        {
            InitializeComponent();
        }

        private SimpleQuerySpread(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public SimpleQuerySpread(string sql)
            :this()
        {
            this.sql = sql;
        }


        #region Field

        private string sql;
        private IMaintenanceForm queryForm;
        
        #endregion
        

        #region IMaintenanceControlable 成员

        public IMaintenanceForm QueryForm
        {
            get
            {
                if (this.queryForm == null)
                {
                    throw new ApplicationException("未设置QueryForm!");
                }
                return this.queryForm;
            }
            set
            {
                this.queryForm = value;

                this.QueryForm.ShowAddButton = false;
                this.QueryForm.ShowSaveButton = false;
            }
        }

        public int Query()
        {
            return 0;
        }

        public int Add()
        {
            return 0;
        }

        public int Delete()
        {
            return 0;
        }

        public int Save()
        {
            return 0;
        }

        //public int Export()
        //{
        //    return 0;
        //}

        public int Print()
        {
            return 0;
        }

        public bool IsDirty
        {
            get
            {
                return false;
            }
            set
            {
                
            }
        }

        public int Init()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Modify()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Import()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PrintPreview()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PrintConfig()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Cut()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Copy()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Paste()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int NextRow()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PreRow()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
