using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [��������: ҩƷ�ȼ���ҽ��ְ������ά��]<br></br>
    /// [�� �� ��: ������]<br></br>
    /// [����ʱ��: 2007-07]<br></br>
    /// </summary>
    public partial class ucDrugDocGradeCompare : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable
    {
        public ucDrugDocGradeCompare()
        {
            InitializeComponent();
        }


        #region �����

        /// <summary>
        /// ְ��������
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper employeeLevelHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// ҩƷ�ȼ�������
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper drugGradeHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        private ArrayList alEmployeeLevel = null;

        private ArrayList alDrugGrade = null;

        #endregion

        /// <summary>
        /// ҩƷ�ȼ���ҽ��ְ��������ʾ
        /// </summary>
        /// <returns></returns>
        internal int ShowDrugDocCompare()
        {
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

            ArrayList al = consManager.GetList("SpeDrugGrade");

            return this.ShowDrugDocCompare(al);
        }

        /// <summary>
        /// ҩƷ�ȼ���ҽ��ְ��������ʾ
        /// </summary>
        /// <returns></returns>
        internal int ShowDrugDocCompare(ArrayList alCompare)
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;

            if (alCompare == null)
            {
                return 1;
            }

            foreach (Neusoft.FrameWork.Models.NeuObject info in alCompare)
            {
                this.neuSpread1_Sheet1.Rows.Add(0, 1);
                //{3972BA6D-5CE4-4995-90AA-30DD281D1660}
                if (info.ID.IndexOf("|") != -1)
                {
                    info.ID = info.ID.Substring(0, info.ID.IndexOf("|"));       //����ַ� ��ȡҽ��ְ��
                }

                this.neuSpread1_Sheet1.Cells[0, 0].Text = info.ID;
                this.neuSpread1_Sheet1.Cells[0, 1].Text = this.employeeLevelHelper.GetName(info.ID);

                this.neuSpread1_Sheet1.Cells[0, 2].Text = info.Name;
                this.neuSpread1_Sheet1.Cells[0, 3].Text = this.drugGradeHelper.GetName(info.Name);                
            }

            return 1;
        }

        #region IMaintenanceControlable ��Ա
       
        private bool isDirty = false;

        private Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm queryForm = null;

        public int Add()
        {
            this.neuSpread1_Sheet1.Rows.Add(0, 1);

            return 1;
        }

        public int Copy()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Cut()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Delete()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
            {
                return -1;
            }

            DialogResult rs = MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("ȷ��ɾ����ǰѡ����Ϣ��"),"",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
            {
                return -1;
            }

            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            string id = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text;
            //{B7BFFC6E-D820-44ca-B74C-2B211EA9FA1F}
            string name = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 2].Text;

            if (consManager.DelConstant("SpeDrugGrade", id + "|" + name) == -1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("ɾ��ҩƷ�ȼ�ְ�������б���������"));
                return -1;
            }

            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("ɾ��ҩƷ�ȼ�ְ�������б��ɹ�"));

            //{B7BFFC6E-D820-44ca-B74C-2B211EA9FA1F}ˢ����ʾ
            ShowDrugDocCompare();

            return 1;
        }

        public int Export()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Import()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            this.alEmployeeLevel = consManager.GetList("LEVEL");
            if (alEmployeeLevel == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("������Աְ���б���������"));
                return -1;
            }
            this.employeeLevelHelper = new Neusoft.FrameWork.Public.ObjectHelper(this.alEmployeeLevel);

            this.alDrugGrade = consManager.GetList("DRUGGRADE");
            if (alDrugGrade == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("����ҩƷ�ȼ�ְ�������б���������"));
                return -1;
            }
            this.drugGradeHelper = new Neusoft.FrameWork.Public.ObjectHelper(this.alDrugGrade);

            this.ShowDrugDocCompare();

            return 1;
        }

        public bool IsDirty
        {
            get
            {
                return false;
            }
            set
            {
                this.isDirty = value;
            }
        }

        public int Modify()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int NextRow()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Paste()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PreRow()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Print()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PrintConfig()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PrintPreview()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Query()
        {
            return this.ShowDrugDocCompare();
        }

        public Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm QueryForm
        {
            get
            {
                return this.queryForm;
            }
            set
            {
                this.queryForm = value;
            }
        }

        public int Save()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction(); 
            //consManager.SetTrans(t.Trans);            
            //{3F1D29EA-0A9D-4703-938E-AB3E51257672}
            int returnValue =  consManager.DelConstant("SpeDrugGrade");
            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("ɾ��������Ϣ����.\n ������Ϣ :" + consManager.Err  );
                return -1;
            }

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(this.neuSpread1_Sheet1.Cells[i, 0].Text) || string.IsNullOrEmpty(this.neuSpread1_Sheet1.Cells[i, 2].Text))
                {
                    continue;
                }

                Neusoft.HISFC.Models.Base.Const cons = new Neusoft.HISFC.Models.Base.Const();

                cons.ID = this.neuSpread1_Sheet1.Cells[i, 0].Text;
                cons.Name = this.neuSpread1_Sheet1.Cells[i, 2].Text;
                cons.IsValid = true;
                //{3972BA6D-5CE4-4995-90AA-30DD281D1660}
                //Ϊ�˱��������ظ� ����ҽ��ְ����ҩƷ�ȼ��ֿ�
                cons.ID = cons.ID + "|" + cons.Name;

                if (consManager.SetConstant("SpeDrugGrade", cons) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("ҩƷ�ȼ���ҽ��ְ�����ո���ʧ��"));
                    return 1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("����ɹ�"));

            this.Query();

            return 1;
        }

        #endregion

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Column == 0)
            {
                //����Ա�Դ���ѡ�񷵻ص���Ϣ
                Neusoft.FrameWork.Models.NeuObject docLevel = new Neusoft.FrameWork.Models.NeuObject();
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alEmployeeLevel, ref docLevel) == 0)
                {
                    return;
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[e.Row, 0].Text = docLevel.ID;
                    this.neuSpread1_Sheet1.Cells[e.Row, 1].Text = docLevel.Name;
                }
            }

            if (e.Column == 2)
            {
                //����Ա�Դ���ѡ�񷵻ص���Ϣ
                Neusoft.FrameWork.Models.NeuObject drugGrade = new Neusoft.FrameWork.Models.NeuObject();
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alDrugGrade, ref drugGrade) == 0)
                {
                    return;
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[e.Row, 2].Text = drugGrade.ID;
                    this.neuSpread1_Sheet1.Cells[e.Row, 3].Text = drugGrade.Name;
                }
            }
        }
    }
}