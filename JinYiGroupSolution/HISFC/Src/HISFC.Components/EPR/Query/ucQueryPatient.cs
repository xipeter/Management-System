using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
namespace Neusoft.HISFC.Components.EPR.Query
{
    public partial class ucQueryPatient : UserControl,Interface.ISearchPatient
    {
        public ucQueryPatient()
        {
            InitializeComponent();
        }

        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

        private void ucQueryPatient_Load(object sender, EventArgs e)
        {
            alControls.Add(this.lblRefer1);
            alControls.Add(this.lblRefer2);
            alControls.Add(this.lblRefer3);
            alControls.Add(this.lblRefer4);
            alControls.Add(this.txtRefer1);
            alControls.Add(this.txtRefer2);
            alControls.Add(this.txtRefer3);
            alControls.Add(this.txtRefer4);
            this.load_QuerySetting();
            this.cmbCondition.SelectedIndex = 0;
            this.fpSpread1_Sheet1.Columns[-1].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.DataAutoCellTypes = false;
            this.fpSpread1.Sheets[0].Columns[-1].ShowSortIndicator = true;

            this.txtRefer1.Focus();
        }

        string strFileName;
		XmlDataDocument doc = new XmlDataDocument();
		XmlNodeList nodes;
		XmlNode node;
		string type  = "";
		public short param  = 0;
		ArrayList alControls = new ArrayList();

		bool first=true;
					  
		//装载查询条件
		//
		private void load_QuerySetting()
		{
			try
			{
				strFileName =  TemplateDesignerHost.Function.SystemPath  + "HIS_QUERY_SETTING.xml";
				doc.Load(strFileName);
				nodes = doc.SelectNodes("设置/系统设置");

				foreach(XmlNode node in nodes)
					this.cmbCondition.Items.Add(node.Attributes["名称"].Value);
													   
			}
			catch 
			{}
							

			first = false;
			this.cmbCondition.SelectedIndex = 0;

		}
		//变换条件
		private void cmbCondition_SelectedIndexChanged(System.Object sender, System.EventArgs e) //Handles cmbCondition.SelectedIndexChanged
		{
			if (first == true)
				return;
			try
			{
				string s  = "设置/系统设置[@名称=\"" + this.cmbCondition.Text + "\"]";
				node = doc.SelectSingleNode(s);
			}
			catch (Exception ex)
			{
																																									
				MessageBox.Show(ex.Message);
			}

			short i, j;
			
			try
			{
														  
				type = node.Attributes[1].Value;
			}
			catch
			{
				type = "";
			}
			short k  = 0;
			for (j = 0 ;j< alControls.Count;++j)
			{
					  
				Control control= alControls[j] as Control;
				control.Visible = false;
			}
			for (i = 0 ;i< node.ChildNodes[0].Attributes.Count;++i)
			{
											  
				if (node.ChildNodes[0].Attributes[i].Name.Substring(node.ChildNodes[0].Attributes[i].Name.Length- 2) != "数值")
				{
					for (j = 0 ;j<alControls.Count;++j)
					{
																							 
						Control control= alControls[j] as Control;

						if (control.Name == "lblRefer" + (k + 1).ToString())
						{
							control.Text = node.ChildNodes[0].Attributes[i].Name;
							control.Visible = true;
						}
						if (control.Name == "txtRefer" + (k + 1).ToString())
						{
							control.Tag = node.ChildNodes[0].Attributes[i].Value;
							control.Visible = true;
							((ComboBox)control).Items.Clear();
							//找到 value
							try
							{
								if (node.ChildNodes[0].Attributes[i + 1].Name.Substring(node.ChildNodes[0].Attributes[i + 1].Name.Length- 2) == "数值")
									f_fillCombo(control, node.ChildNodes[0].Attributes[i + 1].Value);
							}
							catch{}
				
						}
					}
					k += 1;
				}
			}

			this.cmbCondition.Tag = node.InnerText;
			//*****显示必须控件*******************************
			this.cmbCondition.Visible = true;
//			
																																																																																	
		}
		//fill combo 
		Neusoft.FrameWork.Management.DataBaseManger manager = new Neusoft.FrameWork.Management.DataBaseManger();
		private void f_fillCombo(Object sender, string s)
		{
			string[] ss;
			bool b  = false;
			if (s.Length > 5)
				if ((s.Trim().Substring(0, 6)).ToUpper() == "SELECT")
					b = true;
																												  
			((ComboBox)sender).Text="";
			short i;
			try
			{			
				if (b) //select
				{
					System.Data.DataSet ds = new System.Data.DataSet();
					if(manager.ExecQuery(s,ref ds)==-1)
					{
						//
						MessageBox.Show(manager.Err);
						return;
					}
					
					foreach (System.Data.DataRow r in ds.Tables[0].Rows) 
					{
						((ComboBox)sender).Items.Add(r[0].ToString());
					}
				}
				else 
				{
					ss = s.Split(',');
					for (i = 0 ;i< ss.Length;i++)
						((ComboBox)sender).Items.Add(ss[i]);
																  
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

  
		private void btnQuery_Click(System.Object sender, System.EventArgs e) //Handles btnQuery.Click
		{
			//Me.chkSealed.Checked = False
			short i;
			string strSql;

			strSql = this.cmbCondition.Tag.ToString();

			for (i = 0;i<this.alControls.Count;++i)
			{
											  
				string s= ((Control)this.alControls[i]).Name;
				if (((Control)this.alControls[i]).Visible && s.Substring(0, 8) == "txtRefer" && ((Control)this.alControls[i]).Tag.ToString() != "")
				  
					strSql = strSql.Replace(((Control)this.alControls[i]).Tag.ToString(), ((Control)this.alControls[i]).Text);
																																   
			}
			System.Data.DataSet ds = new System.Data.DataSet();
			if(manager.ExecQuery(strSql,ref ds)==-1)
			{
				//
				MessageBox.Show(manager.Err);
				return;
			}
			this.fpSpread1_Sheet1.DataSource=ds;
       
		}




        #region ISearchPatient 成员

        public event Neusoft.HISFC.Components.EPR.Interface.ObjectHandle OnSelectedPatient;

        public Control SearchControl
        {
            get { return this; }
        }

        #endregion

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string s = "";
            try
            {
                s = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 0].Text;
            }
            catch { return; }

            Neusoft.HISFC.Models.RADT.PatientInfo p = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateRADT.QueryPatientInfoByInpatientNO(s);
            if (p == null)
            {
                MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateRADT.Err);
                return;
            }
            if (this.OnSelectedPatient != null)
                this.OnSelectedPatient(p);
        }
    }
}
