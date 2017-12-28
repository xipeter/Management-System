using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    public partial class ucQuery : Common.Controls.ucQuery
    {
        public ucQuery()
        {
            InitializeComponent();
        }

        private void ucQuery_Load(object sender, System.EventArgs e)
        {
            //设定按钮不可见
            this.ButtonOK.Visible = false;
            this.ButtonReset.Visible = false;
            this.ButtonExit.Visible = false;

            //设置条件
            InitDragList();
        }
        /// <summary>
        /// 填充下拉菜单 
        /// </summary>
        private void InitDragList()
        {
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "PATIENT_NO";
            obj.Name = "住院号";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "CARD_NO";
            obj.Name = "就诊卡号";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "MCARD_NO";
            obj.Name = "医疗证号";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "NAME";
            obj.Name = "姓名";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "SEX_CODE";
            obj.Name = "性别";
            obj.Memo = "SEX";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "IDENNO";
            obj.Name = "身份证";
            obj.Memo = "";
            al.Add(obj);
            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "DEPT_NAME";
            obj.Name = "科室";
            obj.Memo = "DEPARTMENT";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "BIRTHDAY";
            obj.Name = "生日";
            obj.Memo = "DATETIME";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "WORK_NAME";
            obj.Name = "工作单位";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "WORK_TEL";
            obj.Name = "工作单位电话";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "WORK_ZIP";
            obj.Name = "单位邮编";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "HOME";
            obj.Name = "户口或家庭地址";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "HOME_TEL";
            obj.Name = "家庭电话";
            obj.Memo = "";

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "HOME_ZIP";
            obj.Name = "户口或家庭邮编";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "DIST";
            obj.Name = "籍贯";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "NATION_CODE";
            obj.Name = "民族";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "LINKMAN_NAME";
            obj.Name = "联系人姓名";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "LINKMAN_TEL";
            obj.Name = "联系人电话";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "LINKMAN_ADD";
            obj.Name = "联系人地址";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "MARI";
            obj.Name = "婚姻状况";
            obj.Memo = "MARI";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "BLOOD_CODE";
            obj.Name = "血型编码";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "PACT_NAME";
            obj.Name = "合同单位";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "IN_CIRCS";
            obj.Name = "入院情况";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "IN_AVENUE";
            obj.Name = "入院途径";
            obj.Memo = "";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "OUT_DATE";
            obj.Name = "出院日期";
            obj.Memo = "DATETIME";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "BED_NO";
            obj.Name = "床号";
            obj.Memo = "";
            al.Add(obj);

            al.Add(obj);
            //设置列
            this.InitCondition(al);
        }
    }
}
