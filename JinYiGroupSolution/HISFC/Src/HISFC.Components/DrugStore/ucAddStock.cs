using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore
{
    /// <summary>
    /// [�ؼ�����: ucAddStock]<br></br>
    /// [��������: ����ʼ��<br></br>
    /// [�� �� ��: ������]<br></br>
    /// [����ʱ��: 2006-11-1]<br></br>
    /// <�޸ļ�¼ 
    ///		�޸���='' 
    ///		�޸�ʱ��='yyyy-mm-dd' 
    ///		�޸�Ŀ��=''
    ///		�޸�����=''
    ///  />
    /// </summary>
    public partial class ucAddStock : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucAddStock( )
        {
            InitializeComponent( );
        }

        #region ����

        //���ݴ洢
        private DataView dvDrugList;
        private DataSet dsDrug = new DataSet( );
        //������
        private Neusoft.FrameWork.Public.ObjectHelper drugTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper( );
        private Neusoft.FrameWork.Public.ObjectHelper qualityHelper = new Neusoft.FrameWork.Public.ObjectHelper( );
        //ҩƷ������
        private Neusoft.HISFC.BizLogic.Pharmacy.Item item = new Neusoft.HISFC.BizLogic.Pharmacy.Item( );
        //���Ǵ�
        private string filter = "1=1";

        /// <summary>
        /// �Ƿ�ӵ������Ȩ��
        /// </summary>
        private bool isHavePriv = false;

        /// <summary>
        /// Ȩ�޿���
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();
        #endregion

        #region ����

        /// <summary>
        /// ����ҩƷ��Ϣ
        /// </summary>
        private void RetrieveData( )
        {
            //��ʾ�ȴ���Ϣ
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( Language.Msg( "���ڼ���ҩƷ��Ϣ..." ) );
            Application.DoEvents( );

            //ȡҩƷ����
            List<Neusoft.HISFC.Models.Pharmacy.Item> al = item.QueryItemList( true );
 
            //��ҩƷ��������
            CompareApplyOut compare = new CompareApplyOut();
            al.Sort(compare);

            if( al == null )
            {
                MessageBox.Show( item.Err );
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm( );
                return;
            }

            //ȡҩƷ��������
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager( );
            this.drugTypeHelper.ArrayObject = manager.GetConstantList( Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE );
            this.qualityHelper.ArrayObject = manager.GetConstantList( Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY );

            //��ʾҩƷ����
            Neusoft.HISFC.Models.Pharmacy.Item info;
            for( int i = 0 ; i < al.Count ; i++ )
            {
                info = al[ i ] as Neusoft.HISFC.Models.Pharmacy.Item;

                //{D3E6C674-8623-42bf-8F60-C92A303E4073}
                if (info.ValidState!= Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                {
                    continue;
                }
                this.dsDrug.Tables[ 0 ].Rows.Add( new object[ ] {
																	false,             //�Ƿ�����
																	info.Name,        //ҩƷ����
																	info.Specs,       //ҩƷ���
																	info.PriceCollection.RetailPrice, //���ۼ�
																	qualityHelper.GetName(info.Quality.ID),//ҩƷ����
																	info.PackUnit,    //��װ��λ
																	info.PackQty,     //��װ����
																	info.MinUnit,     //��С��λ
																	info.ID,          //ҩƷ����
																	drugTypeHelper.GetName(info.Type.ID), //ҩƷ����
																	info.NameCollection.SpellCode,  //ƴ����		
																	info.NameCollection.WBCode,     //�����		
																	info.NameCollection.UserCode,   //�Զ�����		
																	info.NameCollection.RegularName, //ͨ����		
																	info.NameCollection.SpellCode,//ͨ����ƴ����		
																	info.NameCollection.WBCode,   //ͨ���������	
				} );
                //���ø�ʽ
                this.SetFormat( );
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( i , al.Count );
                Application.DoEvents( );
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm( );

        }

        /// <summary>
        /// ��ʼ����ͼ
        /// </summary>
        private void InitDataView( )
        {
            //������Դ
            this.dsDrug.Tables.Clear( );
            this.dsDrug.Tables.Add( );
            this.dvDrugList = new DataView( this.dsDrug.Tables[ 0 ] );
            this.neuSpread1_Sheet1.DataSource = this.dvDrugList;
            this.dvDrugList.AllowEdit = true;

            //��������
            System.Type dtStr = System.Type.GetType( "System.String" );
            System.Type dtDec = System.Type.GetType( "System.Decimal" );
            System.Type dtDTime = System.Type.GetType( "System.DateTime" );
            System.Type dtBool = System.Type.GetType( "System.Boolean" );

            //��myDataTable��������
            this.dsDrug.Tables[ 0 ].Columns.AddRange( new DataColumn[ ] {
																			new DataColumn("����",        dtBool),
																			new DataColumn("��Ʒ����",    dtStr),
																			new DataColumn("���",        dtStr),
																			new DataColumn("���ۼ�",      dtDec),
																			new DataColumn("ҩƷ����",    dtStr),
																			new DataColumn("��װ��λ",    dtStr),
																			new DataColumn("��װ����",    dtDec),
																			new DataColumn("��С��λ",    dtStr),
																			new DataColumn("ҩƷ����",    dtStr),
																			new DataColumn("ҩƷ���",    dtStr),
																			new DataColumn("ƴ����",      dtStr),
																			new DataColumn("�����",      dtStr),
																			new DataColumn("�Զ�����",    dtStr),
																			new DataColumn("ͨ����",      dtStr),
																			new DataColumn("ͨ����ƴ����",dtStr),
																			new DataColumn("ͨ���������",dtStr)
																		} );
        }

        /// <summary>
        /// ����farpoint��ʽ
        /// </summary>
        private void SetFormat( )
        {
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType( );
            this.neuSpread1_Sheet1.Columns.Get( 0 ).CellType = checkBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get( 0 ).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get( 0 ).Label = "����";
            this.neuSpread1_Sheet1.Columns.Get( 0 ).Locked = false;
            this.neuSpread1_Sheet1.Columns.Get( 0 ).Width = 38F;
            this.neuSpread1_Sheet1.Columns.Get( 1 ).Label = "��Ʒ����";
            this.neuSpread1_Sheet1.Columns.Get( 1 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 1 ).Width = 129F;
            this.neuSpread1_Sheet1.Columns.Get( 2 ).Label = "���";
            this.neuSpread1_Sheet1.Columns.Get( 2 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 3 ).Label = "���ۼ�";
            this.neuSpread1_Sheet1.Columns.Get( 3 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 4 ).Label = "ҩƷ����";
            this.neuSpread1_Sheet1.Columns.Get( 4 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 4 ).Width = 72F;
            this.neuSpread1_Sheet1.Columns.Get( 5 ).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get( 5 ).Label = "��װ��λ";
            this.neuSpread1_Sheet1.Columns.Get( 5 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 5 ).Width = 39F;
            this.neuSpread1_Sheet1.Columns.Get( 6 ).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.neuSpread1_Sheet1.Columns.Get( 6 ).Label = "��װ����";
            this.neuSpread1_Sheet1.Columns.Get( 6 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 6 ).Width = 42F;
            this.neuSpread1_Sheet1.Columns.Get( 7 ).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get( 7 ).Label = "��С��λ";
            this.neuSpread1_Sheet1.Columns.Get( 7 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 7 ).Width = 41F;
            this.neuSpread1_Sheet1.Columns.Get( 8 ).Label = "ҩƷ����";
            this.neuSpread1_Sheet1.Columns.Get( 8 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 9 ).Label = "ҩƷ���";
            this.neuSpread1_Sheet1.Columns.Get( 9 ).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get( 10 ).Label = "ƴ����";
            this.neuSpread1_Sheet1.Columns.Get( 10 ).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get( 11 ).Label = "�����";
            this.neuSpread1_Sheet1.Columns.Get( 11 ).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get( 12 ).Label = "�Զ�����";
            this.neuSpread1_Sheet1.Columns.Get( 12 ).Visible = true;
            this.neuSpread1_Sheet1.Columns.Get( 13 ).Label = "ͨ����";
            this.neuSpread1_Sheet1.Columns.Get( 13 ).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get( 14 ).Label = "ͨ����ƴ����";
            this.neuSpread1_Sheet1.Columns.Get( 14 ).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get( 15 ).Label = "ͨ���������";
            this.neuSpread1_Sheet1.Columns.Get( 15 ).Visible = false;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

        }

        /// <summary>
        /// ѡ���¼�
        /// </summary>
        /// <param name="isSelectAll"></param>
        private void SelectDrug( bool isSelectAll )
        {
            for( int i = 0 ; i < this.neuSpread1_Sheet1.Rows.Count ; i++ )
            {
                this.neuSpread1_Sheet1.Cells[ i , 0 ].Value = isSelectAll;
            }
        }

        /// <summary>
        /// �Ϸ��Լ��
        /// </summary>
        private int ValidCheck( )
        {
            //�ж�����¼���Ƿ���ȷ
            if( this.txtSum.Text == string.Empty || this.txtSum.Text.Trim( ) == "" )
            {
                MessageBox.Show( Language.Msg( "��¼��Ҫ���ӵĿ����������С��λ��" ) , Language.Msg( "��ʾ" ) );
                return -1;
            }

            //�ж�¼�������Ƿ������
      
            if( Neusoft.FrameWork.Function.NConvert.ToDecimal( this.txtSum.Text ) <= 0 )
            {
                MessageBox.Show( Language.Msg("�������������"), Language.Msg( "����¼�����" ));
                this.txtSum.Focus( );
                return -1;
            }

            //ֹͣ���ݱ༭״̬
            for( int i = 0 ; i < this.dvDrugList.Count ; i++ )
            {
                this.dvDrugList[ i ].EndEdit( );
            }
            //���ù�������
            this.dvDrugList.RowFilter = this.filter + " and ���� = true";
            //���ø�ʽ
            this.SetFormat( );

            //�ж��Ƿ����ҩƷ����
            if( this.neuSpread1_Sheet1.Rows.Count == 0 )
            {
                MessageBox.Show( Language.Msg("��ѡ��Ҫ���ӵ�ҩƷ" ),Language.Msg( "��ʾ" ));
                return -1;
            }

            if( MessageBox.Show(Language.Msg( "ȷ��Ҫ������ѡ�еġ�") + this.neuSpread1_Sheet1.Rows.Count.ToString( ) + Language.Msg("����ҩƷ�����") ,Language.Msg( "ȷ�����ӿ��") , MessageBoxButtons.YesNo ) == DialogResult.No ) return -1;

            return 0;
        }

        /// <summary>
        /// ��ʼ�����
        /// </summary>
        private void AddStock( )
        {
            if( this.ValidCheck( ) < 0 )
            {
                return;
            }
            List<Neusoft.HISFC.Models.Base.Department> aldept = this.tvDeptTree1.SelectNodes;

            if( aldept.Count == 0 )
            {
                MessageBox.Show( Language.Msg( "��ѡ��Ҫ���ӵĿⷿ" ) , Language.Msg( "��ʾ" ) );
                return;
            }
            if (!this.isHavePriv)
            {
                bool isAllowEdit = false;
                foreach (Neusoft.HISFC.Models.Base.Department dept in aldept)
                {
                    if (dept.ID == this.privDept.ID)
                    {
                        isAllowEdit = true;
                    }
                }
                if (!isAllowEdit)
                {
                    MessageBox.Show(Language.Msg("����Ȩ�޲��ܶ����������ҽ��п���ʼ��! ������ҩƷ������Ϣά��Ȩ��"), Language.Msg("��ʾ"));
                    return;
                }
            }

            //�������ݿ⴦������
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction( Neusoft.FrameWork.Management.Connection.Instance );
            //t.BeginTransaction( );

            this.item.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            try
            {
                string drugCode = "";
                decimal quantity = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.txtSum.Text );
                bool IsUpdate = false;
                bool check = false;
                Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase = new Neusoft.HISFC.Models.Pharmacy.StorageBase( );
                storageBase.GroupNO = 1;                   //���κ�  
                storageBase.BatchNO = "1";                 //����
                storageBase.ShowState = "0";               //��ʾ�ĵ�λ���
                storageBase.ValidTime = this.item.GetDateTimeFromSysDateTime( ).AddYears( 5 );          //��Ч��
                storageBase.Quantity = quantity;          //����������
                storageBase.PlaceNO = "0";               //��λ��
                storageBase.ID = "0";                      //���ݺ�
                storageBase.SerialNO = 0;                 //�������
                storageBase.SystemType = "01";            //����������M1���﷢ҩ,M2������ҩ,Z1סԺ��ҩ,Z2סԺ��ҩ����
                storageBase.PrivType = "00";			   //class2_code
                storageBase.Class2Type = "0310";
                storageBase.Memo = "����ʼ��";           //��ע
                storageBase.Operation.Oper.OperTime = this.item.GetDateTimeFromSysDateTime( );

                foreach( Neusoft.HISFC.Models.Base.Department dept in aldept )
                {
                    for( int i = 0 ; i < this.neuSpread1_Sheet1.RowCount ; i++ )
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( i ,this.neuSpread1_Sheet1.RowCount );
                        Application.DoEvents( );

                        //���û��ѡ�У��򲻴�����������
                        check = Neusoft.FrameWork.Function.NConvert.ToBoolean( this.neuSpread1_Sheet1.Cells[ i , 0 ].Value );
                        if( !check ) continue;

                        //ȡҩƷ����
                        drugCode = this.neuSpread1_Sheet1.Cells[ i , 8 ].Text;
                        //�ⷿ����
                        storageBase.StockDept.ID = dept.ID;   
                        //Ŀ�����
                        storageBase.TargetDept.ID = dept.ID;  
                        //���ҩƷ��Ϣ
                        storageBase.Item = this.item.GetItem( drugCode );

                        if( storageBase.Item == null )
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show( Language.Msg("�޷�ת����storageBase.Item����") , Language.Msg("��ʾ" ));
                            return;
                        }

                        //��װ����Ϊ0ʱ�����������ӿ��
                        if( storageBase.Item.PackQty == 0 ) continue;

                        storageBase.StoreCost = quantity * storageBase.Item.PriceCollection.RetailPrice / storageBase.Item.PackQty;      //�����

                        //�������
                        if( this.item.SetStorage( storageBase ) != 1 )
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show( this.item.Err , Language.Msg( "���������ʾ" ) );
                            return;
                        }

                        IsUpdate = true;
                    }
                }
                if( IsUpdate )
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    MessageBox.Show( Language.Msg("����ɹ���" ));
                }
                else
                {
                    //���û�и��µ�����,��ع�����.
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                }
            }
            catch( Exception ex )
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show( ex.Message );
                return;
            }

            //��ʾȫ��ҩƷ
            this.dvDrugList.RowFilter = "1=1";
            this.SetFormat( );
            //ȡ��ѡ��
            this.SelectDrug( false );

        }

        #endregion

        #region �¼�

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            //��ʼ��dataview
            this.InitDataView( );
            //��ʼ��ҩƷ������Ϣ
            this.RetrieveData( );
            //ҩƷ�б�չ����һ��
            this.tvDrugType1.Nodes[ 0 ].Expand( );

            this.isHavePriv = Neusoft.HISFC.BizProcess.Integrate.Pharmacy.ChoosePiv("0301");
            this.privDept = ((Neusoft.HISFC.Models.Base.Employee)(item.Operator)).Dept;

            base.OnLoad( e );
        }

        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQueryCode_TextChanged( object sender , EventArgs e )
        {
            if( this.dsDrug.Tables[ 0 ].Rows.Count == 0 ) return;

            try
            {
                string queryCode = "";
                queryCode = "%" + this.txtQueryCode.Text.Trim( ) + "%";

                string str = "((ƴ���� LIKE '" + queryCode + "') OR " +
                    "(����� LIKE '" + queryCode + "') OR " +
                    "(�Զ����� LIKE '" + queryCode + "') OR " +
                    "(��Ʒ���� LIKE '" + queryCode + "') OR" +
                    "(ͨ����ƴ���� LIKE '" + queryCode + "') OR " +
                    "(ͨ��������� LIKE '" + queryCode + "') OR " +
                    "(ͨ���� LIKE '" + queryCode + "') )";

                //���ù�������
                this.dvDrugList.RowFilter = this.filter + " AND " + str;
                //���ø�ʽ
                this.SetFormat( );
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex.Message );
            }

        }

        /// <summary>
        /// ҩƷ����ѡ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDrugType1_AfterSelect( object sender , TreeViewEventArgs e )
        {
            //��ʼ��
            this.filter = "1=1";
            this.txtQueryCode.Text = "";
            if( e.Node.Parent != null )
            {
                if( e.Node.Level == 1 )
                {
                    this.filter = "( ҩƷ��� = '" + e.Node.Text + "') ";
                }
                else if( e.Node.Level == 2 )
                {
                    this.filter = "( ҩƷ��� = '" + e.Node.Parent.Text + "')" + " and ( ҩƷ���� = '" + e.Node.Text + "')";
                }
            }
            else
            {
                this.filter = "1=1";
            }

            this.dvDrugList.RowFilter = this.filter;
            //���ø�ʽ
            this.SetFormat( );
        }

        #endregion

        #region ��������Ϣ

        /// <summary>
        /// ���幤��������
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService( );

        /// <summary>
        /// ��ʼ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit( object sender , object NeuObject , object param )
        {
            //���ӹ�����
            this.toolBarService.AddToolButton( "ȫѡ" , "ѡ��ȫ��ҩƷ" , 0 , true , false , null );
            this.toolBarService.AddToolButton( "ȫ��ѡ" , "ȡ��ѡ��ȫ��ҩƷ" , 1 , true , false , null );
            return this.toolBarService;
        }

        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave( object sender , object neuObject )
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( Language.Msg( "�������ӿ������..." ) );
            Application.DoEvents( );
            this.AddStock( );
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm( );
            return base.OnSave( sender , neuObject );
        }

        /// <summary>
        /// ��������ť�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked( object sender , ToolStripItemClickedEventArgs e )
        {
            switch( e.ClickedItem.Text )
            {
                case "ȫѡ":
                    this.SelectDrug( true );
                    break;
                case "ȫ��ѡ":
                    this.SelectDrug( false );
                    break;

            }

        }

        #endregion

      
        public class CompareApplyOut : IComparer<Neusoft.HISFC.Models.Pharmacy.Item>
        {
            public int Compare(Neusoft.HISFC.Models.Pharmacy.Item x, Neusoft.HISFC.Models.Pharmacy.Item y)
            {
                Neusoft.HISFC.Models.Pharmacy.Item o1 = (x as Neusoft.HISFC.Models.Pharmacy.Item).Clone();
                Neusoft.HISFC.Models.Pharmacy.Item o2 = (y as Neusoft.HISFC.Models.Pharmacy.Item).Clone();


                string oX = o1.UserCode;
                string oY = o2.UserCode;

                int nComp;

                if (oX == null)
                {
                    nComp = (oY != null) ? -1 : 0;   //oxΪnull��oy��Ϊnull������-1�����򷵻�0��
                }
                else if (oY == null)
                {
                    nComp = 1;
                }
                else
                {
                    nComp = string.Compare(oX.ToString(), oY.ToString());
                }

                return nComp;
            }
        }

    }
}