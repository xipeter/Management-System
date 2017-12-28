using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Nurse.Controls
{
    public partial class ucPatientCardList : UserControl
    {
        /// <summary>
        /// [功能描述: 床位卡片]<br></br>
        /// [创 建 者: wolf]<br></br>
        /// [创建时间: 2006-11-30]<br></br>
        /// <修改记录
        ///		修改人=''
        ///		修改时间='yyyy-mm-dd'
        ///		修改目的=''
        ///		修改描述=''
        ///  />
        /// </summary>
        public ucPatientCardList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置患者
        /// </summary>
        /// <param name="al"></param>
        public virtual void SetPatients(ArrayList al)
        {
            this.Controls.Clear();
            Neusoft.FrameWork.WinForms.Classes.Function.AddControlToPanel(al, typeof(ucPatientCard), this, new System.Drawing.Size(1000, 2000));   
            
        }
    }
}
