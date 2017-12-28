using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.FinIpr
{
	/// <summary>
	/// 患者查询，实现患者按姓名，按住院科室查询
	/// </summary>
    public partial class ucFinIprInpatientQuery : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
	{
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private IContainer components;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cbstate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox neuComboBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
    
		public ucFinIprInpatientQuery()
		{
			InitializeComponent();
		}

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTextBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cbstate = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuComboBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.plLeft.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plQueryCondition.SuspendLayout();
            this.plMain.SuspendLayout();
            this.plTop.SuspendLayout();
            this.plBottom.SuspendLayout();
            this.plRightTop.SuspendLayout();
            this.plRightBottom.SuspendLayout();
            this.gbMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // plLeft
            // 
            this.plLeft.Size = new System.Drawing.Size(0, 394);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Size = new System.Drawing.Size(800, 394);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(800, 464);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.neuLabel6);
            this.plTop.Controls.Add(this.neuComboBox1);
            this.plTop.Controls.Add(this.cbstate);
            this.plTop.Controls.Add(this.neuLabel5);
            this.plTop.Controls.Add(this.neuTextBox2);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.neuTextBox1);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Size = new System.Drawing.Size(800, 65);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.neuTextBox1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.neuTextBox2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel5, 0);
            this.plTop.Controls.SetChildIndex(this.cbstate, 0);
            this.plTop.Controls.SetChildIndex(this.neuComboBox1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel6, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 65);
            this.plBottom.Size = new System.Drawing.Size(800, 399);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Size = new System.Drawing.Size(3, 394);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 361);
            // 
            // plRightTop
            // 
            this.plRightTop.Controls.Add(this.neuSplitter1);
            this.plRightTop.Size = new System.Drawing.Size(800, 391);
            this.plRightTop.Controls.SetChildIndex(this.neuSplitter1, 0);
            this.plRightTop.Controls.SetChildIndex(this.dwMain, 0);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 391);
            this.slTop.Size = new System.Drawing.Size(800, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 394);
            this.plRightBottom.Size = new System.Drawing.Size(800, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(792, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1509, 9);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipr_inpatient_query";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.LibraryList = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.dwMain.Location = new System.Drawing.Point(3, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(797, 391);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(0, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 391);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.OliveDrab;
            this.neuLabel3.Location = new System.Drawing.Point(383, 41);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(29, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "姓名";
            // 
            // neuTextBox1
            // 
            this.neuTextBox1.Location = new System.Drawing.Point(418, 38);
            this.neuTextBox1.Name = "neuTextBox1";
            this.neuTextBox1.Size = new System.Drawing.Size(100, 21);
            this.neuTextBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox1.TabIndex = 5;
            this.neuTextBox1.TextChanged += new System.EventHandler(this.neuTextBox1_TextChanged);
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.ForeColor = System.Drawing.Color.OliveDrab;
            this.neuLabel4.Location = new System.Drawing.Point(524, 41);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 6;
            this.neuLabel4.Text = "住院科室";
            // 
            // neuTextBox2
            // 
            this.neuTextBox2.Location = new System.Drawing.Point(584, 36);
            this.neuTextBox2.Name = "neuTextBox2";
            this.neuTextBox2.Size = new System.Drawing.Size(100, 21);
            this.neuTextBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox2.TabIndex = 7;
            this.neuTextBox2.TextChanged += new System.EventHandler(this.neuTextBox1_TextChanged);
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.ForeColor = System.Drawing.Color.OliveDrab;
            this.neuLabel5.Location = new System.Drawing.Point(9, 45);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(29, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 8;
            this.neuLabel5.Text = "状态";
            // 
            // cbstate
            // 
            this.cbstate.ArrowBackColor = System.Drawing.Color.Silver;
            this.cbstate.IsFlat = true;
            this.cbstate.IsLike = true;
            this.cbstate.Location = new System.Drawing.Point(44, 39);
            this.cbstate.Name = "cbstate";
            this.cbstate.PopForm = null;
            this.cbstate.ShowCustomerList = false;
            this.cbstate.ShowID = false;
            this.cbstate.Size = new System.Drawing.Size(121, 20);
            this.cbstate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbstate.TabIndex = 9;
            this.cbstate.Tag = "";
            this.cbstate.ToolBarUse = false;
            // 
            // neuComboBox1
            // 
            this.neuComboBox1.ArrowBackColor = System.Drawing.Color.Silver;
            this.neuComboBox1.IsFlat = true;
            this.neuComboBox1.IsLike = true;
            this.neuComboBox1.Location = new System.Drawing.Point(246, 40);
            this.neuComboBox1.Name = "neuComboBox1";
            this.neuComboBox1.PopForm = null;
            this.neuComboBox1.ShowCustomerList = false;
            this.neuComboBox1.ShowID = false;
            this.neuComboBox1.Size = new System.Drawing.Size(121, 20);
            this.neuComboBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuComboBox1.TabIndex = 9;
            this.neuComboBox1.Tag = "";
            this.neuComboBox1.ToolBarUse = false;
            this.neuComboBox1.SelectedIndexChanged += new System.EventHandler(this.neuComboBox1_SelectedIndexChanged);
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.ForeColor = System.Drawing.Color.OliveDrab;
            this.neuLabel6.Location = new System.Drawing.Point(187, 45);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(53, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 10;
            this.neuLabel6.Text = "合同单位";
            // 
            // ucFinIprInpatientQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_fin_ipr_inpatient_query";
            this.MainDWLabrary = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.Name = "ucFinIprInpatientQuery";
            this.Size = new System.Drawing.Size(800, 464);
            this.plLeft.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plQueryCondition.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.plBottom.ResumeLayout(false);
            this.plRightTop.ResumeLayout(false);
            this.plRightBottom.ResumeLayout(false);
            this.gbMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        private string pactCode = string.Empty;
        private string pactName = string.Empty;
        private string instateCode = string.Empty;
        private string instateName = string.Empty;
        System.Collections.ArrayList alpaykindConstantList = null;
        System.Collections.ArrayList alinstateConstantList = null;
        private string instate0 = string.Empty;
        private string instate1 = string.Empty;
        private string instate2 = string.Empty;
        private string instate3 = string.Empty;
        private string instate4 = string.Empty;
        private string instate5 = string.Empty;

        protected override void OnLoad()
        {
            this.Init();

            base.OnLoad();
            //设置时间范围
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(DateTime.Now.Year, 1, 1);
            this.dtpBeginTime.Value = dt;

            //填充数据
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            alpaykindConstantList = manager.QueryPactUnitAll();
            Neusoft.HISFC.Models.Base.Pact alpact = new Neusoft.HISFC.Models.Base.Pact();
            alpact.ID = "ALL";
            alpact.Name = "全部";
            alpact.SpellCode = "QB";
            alpaykindConstantList.Insert(0, alpact);
            this.neuComboBox1.AddItems(alpaykindConstantList);
            neuComboBox1.SelectedIndex = 0;


            alinstateConstantList = new ArrayList();
            #region 全部患者状态

            //全部
            Neusoft.HISFC.Models.Base.Const allinstate0 = new Neusoft.HISFC.Models.Base.Const();
            allinstate0.ID = "QB";
            allinstate0.Name = "全部";
            allinstate0.SpellCode = "QB";
            alinstateConstantList.Add(allinstate0);
            //住院登记
            Neusoft.HISFC.Models.Base.Const allinstate1 = new Neusoft.HISFC.Models.Base.Const();
            allinstate1.ID = "ZYDJ";
            allinstate1.Name = "住院登记";
            allinstate1.SpellCode = "ZYDJ";
            alinstateConstantList.Add(allinstate1);
            //病房接诊
            Neusoft.HISFC.Models.Base.Const allinstate2 = new Neusoft.HISFC.Models.Base.Const();
            allinstate2.ID = "BFJZ";
            allinstate2.Name = "病房接诊";
            allinstate2.SpellCode = "BFJZ";
            alinstateConstantList.Add(allinstate2);
            //出院登记
            Neusoft.HISFC.Models.Base.Const allinstate3 = new Neusoft.HISFC.Models.Base.Const();
            allinstate3.ID = "CYDJ";
            allinstate3.Name = "出院登记";
            allinstate3.SpellCode = "CYDJ";
            alinstateConstantList.Add(allinstate3);
            //出院结算
            Neusoft.HISFC.Models.Base.Const allinstate4 = new Neusoft.HISFC.Models.Base.Const();
            allinstate4.ID = "CYJS";
            allinstate4.Name = "出院结算";
            allinstate4.SpellCode = "CYJS";
            alinstateConstantList.Add(allinstate4);
            //预约出院
            Neusoft.HISFC.Models.Base.Const allinstate5 = new Neusoft.HISFC.Models.Base.Const();
            allinstate5.ID = "YYCY";
            allinstate5.Name = "预约出院";
            allinstate5.SpellCode = "YYCY";
            alinstateConstantList.Add(allinstate5);
            //无费退院
            Neusoft.HISFC.Models.Base.Const allinstate6 = new Neusoft.HISFC.Models.Base.Const();
            allinstate6.ID = "WFTY";
            allinstate6.Name = "无费退院";
            allinstate6.SpellCode = "WFTY";
            alinstateConstantList.Add(allinstate6);
            #endregion

            this.cbstate.AddItems(alinstateConstantList);
            cbstate.SelectedIndex = 0;

        }

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (neuComboBox1.SelectedIndex >= 0)
            {
                pactCode = ((Neusoft.HISFC.Models.Base.Pact)alpaykindConstantList[this.neuComboBox1.SelectedIndex]).ID.ToString();
                pactName = ((Neusoft.HISFC.Models.Base.Pact)alpaykindConstantList[this.neuComboBox1.SelectedIndex]).Name.ToString();
            }
        }
       // protected override int OnQuery(object sender, object neuObject)
        protected override int  OnRetrieve(params object[] objects)

        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }
            //全部
            //住院登记 "R"
            //病房接诊 "I"
            //出院登记 "B"
            //出院结算 "O"
            //预约出院 "P"
            //无费退院 "N"

            switch (this.cbstate.SelectedItem.ID)
            {
                case "QB":
                    {
                        instate0 = "R";
                        instate1 = "I";
                        instate2 = "B";
                        instate3 = "O";
                        instate4 = "P";
                        instate5 = "N";
                        break;
                    }
                case "ZYDJ":
                    {
                        instate0 = "R";
                        instate1 = "R";
                        instate2 = "R";
                        instate3 = "R";
                        instate4 = "R";
                        instate5 = "R";
                        break;
                    }
                case "BFJZ":
                    {
                        instate0 = "I";
                        instate1 = "I";
                        instate2 = "I";
                        instate3 = "I";
                        instate4 = "I";
                        instate5 = "I";
                        break;
                    }
                case "CYDJ":
                    {
                        instate0 = "B";
                        instate1 = "B";
                        instate2 = "B";
                        instate3 = "B";
                        instate4 = "B";
                        instate5 = "B";
                        break;
                    }
                case "CYJS":
                    {
                        instate0 = "O";
                        instate1 = "O";
                        instate2 = "O";
                        instate3 = "O";
                        instate4 = "O";
                        instate5 = "O";
                        break;
                    }
                case "YYCY":
                    {
                        instate0 = "P";
                        instate1 = "P";
                        instate2 = "P";
                        instate3 = "P";
                        instate4 = "P";
                        instate5 = "P";
                        break;
                    }
                case "WFTY":
                    {
                        instate0 = "N";
                        instate1 = "N";
                        instate2 = "N";
                        instate3 = "N";
                        instate4 = "N";
                        instate5 = "N";
                        break;
                    }
                default:
                    {
                        instate0 = "R";
                        instate1 = "I";
                        instate2 = "B";
                        instate3 = "O";
                        instate4 = "P";
                        instate5 = "N";
                        break;
                    }
            }
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索数据请稍候....");



                this.dwMain.Modify("time.text='入院时间：" + this.beginTime.ToString("yyyy-MM-dd HH:mm:ss") + "至" + this.endTime.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                //return this.dwMain.Retrieve(this.beginTime, this.endTime, instate0, instate1, instate2, instate3, instate4, instate5, pactCode);
                return base.OnRetrieve(this.beginTime, this.endTime, instate0, instate1, instate2, instate3, instate4, instate5, pactCode);

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }


        }

        /// <summary>
        /// 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            string dept = this.neuTextBox2.Text.Trim().ToUpper().Replace(@"\", "");
            string name = this.neuTextBox1.Text.Trim().ToUpper().Replace(@"\","");
            DataView dv = this.dwMain.Dv;
            if (dv == null)
            {
                return;
            }

            if (dept.Equals("") && name.Equals(""))
            {
                //this.dwMain.SetFilter("");
                //this.dwMain.Filter();
                dv.RowFilter = "";
                return;
            }

            string query = string.Format(this.queryStr, name, dept);
            //this.dwMain.SetFilter(query);
            //this.dwMain.Filter();
            try
            {
                dv.RowFilter = query;
            }
            catch
            {
                MessageBox.Show("请输入正确信息，不许输入特殊字符");
                return;
            }
        }

        //过滤字符串
        private string queryStr = "((dept_name like '{1}%') or (dept_spell_code like '{1}%') or (dept_wb_code like '{1}%')) and ((name like '{0}%') or (name_spell_code like '{0}%') or (name_wb_code like '{0}%'))";


	}
}

