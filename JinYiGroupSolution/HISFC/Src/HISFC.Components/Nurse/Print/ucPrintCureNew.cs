using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse.Print
{
    /// <summary>
    /// ucPrintCureNew<br></br>
    /// <Font color='#FF1111'>[功能描述:门诊注射瓶签打印{EB016FFE-0980-479c-879E-225462ECA6D0}]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-7-29]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public partial class ucPrintCureNew : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectCurePrint
    {
        #region 构造函数
        public ucPrintCureNew()
        {
            InitializeComponent();
        }
        #endregion

        #region IInjectCurePrint 成员

        public void Init(System.Collections.ArrayList alPrintData)
        {
            //用来将要分开打的数据分开
            Hashtable htInject = new Hashtable();
            foreach (Neusoft.HISFC.Models.Nurse.Inject inject in alPrintData)
            {
                string key = inject.PrintNo;
                if (htInject.ContainsKey(key))
                {
                    List<Neusoft.HISFC.Models.Nurse.Inject> injectList = htInject[key] as List<Neusoft.HISFC.Models.Nurse.Inject>;
                    injectList.Add(inject);
                }
                else
                {
                    List<Neusoft.HISFC.Models.Nurse.Inject> injectList = new List<Neusoft.HISFC.Models.Nurse.Inject>();
                    htInject.Add(key, injectList);
                    injectList.Add(inject);
                }
            }
            //分别打印
            int controlsHeight = 0;
            int pageCount = 1;
            int totPageCount = htInject.Count;
            foreach (string key in htInject.Keys)
            {
                ucPrintCureNewControl ucPrint = new ucPrintCureNewControl();
                ucPrint.SetData(htInject[key] as List<Neusoft.HISFC.Models.Nurse.Inject>, totPageCount, pageCount);
                pageCount++;
                ucPrint.Dock = DockStyle.Top;
                this.Controls.Add(ucPrint);
                controlsHeight += ucPrint.Height;
               
                //控件高度
                this.Height = controlsHeight;
                //打印
                Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
                p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
                p.PrintPage(180, 5, this);
            }

        }

        #endregion
    }
}
