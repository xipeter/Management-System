using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Components.Common.Controls;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Runtime.InteropServices;
using System.IO;

namespace Neusoft.HISFC.Components.Common.Classes
{
    /// <summary>
    /// [��������: ���ú���]<br></br>
    /// [�� �� ��: wolf]<br></br>
    /// [����ʱ��: 2004-10-12]<br></br>
    /// <�޸ļ�¼
    ///		�޸���=''
    ///		�޸�ʱ��=''
    ///		�޸�Ŀ��=''
    ///		�޸�����=''
    ///  />
    /// </summary>
    public class Function
    {
        public Function( )
        {

        }

        private static Neusoft.HISFC.BizLogic.Fee.Interface managerInterface = null;
        /// <summary>
        /// �ж��Ƿ��ڱ���״̬
        /// </summary>
        public static bool DesignMode
        {
            get
            {
                return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");


            }
        }
        /// <summary>
        /// ��ʾ��־
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string ShowItemFlag(Neusoft.HISFC.Models.Base.Item item)
        {
            if (managerInterface == null)
                managerInterface = new Neusoft.HISFC.BizLogic.Fee.Interface();
            return managerInterface.ShowItemFlag(item);
        }
        /// <summary>
        /// �����ѡ��
        /// </summary>
        /// <returns>��ѡ�еĿ�������</returns>
        public  static List<Neusoft.HISFC.Models.Base.Department> ChooseMultiDept( )
        {
            ucChooseMultiDept uc = new ucChooseMultiDept( );
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "����ѡ��";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl( uc );
            return uc.SelectedDeptList;
        }

        #region Ȩ�޿���

        /// <summary>
        /// ȡ��ǰ����Ա�Ƿ���ĳһȨ�ޡ�
        /// </summary>
        /// <param name="class2Code">����Ȩ�ޱ���</param>
        /// <returns>True ��Ȩ��, False ��Ȩ��</returns>
        public static bool ChoosePiv(string class2Code)
        {
            List<Neusoft.FrameWork.Models.NeuObject> al = null;
            //Ȩ�޹�����
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager privManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
            //ȡ����Աӵ��Ȩ�޵Ŀ���
            al = privManager.QueryUserPriv(privManager.Operator.ID, class2Code);

            if (al == null || al.Count == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// ��ȡ��ǰ����Ȩ�޿��Ҽ���
        /// </summary>
        /// <param name="class2Code">����Ȩ�ޱ���</param>
        /// <param name="class3Code">����Ȩ�ޱ���</param>
        /// <param name="isShowErrMsg">�Ƿ񵯳�������Ϣ</param>
        /// <returns>�ɹ�����ӵ��Ȩ�޿����б� ʧ�ܷ���null</returns>
        public static List<Neusoft.FrameWork.Models.NeuObject> QueryPrivList(string class2Code,string class3Code, bool isShowErrMsg)
        {
            List<Neusoft.FrameWork.Models.NeuObject> al = null;
            //Ȩ�޹�����
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager privManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
            //ȡ����Աӵ��Ȩ�޵Ŀ���
            if (class3Code == null || class3Code == "")
                al = privManager.QueryUserPriv(privManager.Operator.ID, class2Code);
            else
                al = privManager.QueryUserPriv(privManager.Operator.ID, class2Code, class3Code);

            if (al == null)
            {
                if (isShowErrMsg)
                {
                    System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(privManager.Err));
                }
                return null;
            }
            if (al.Count == 0)
            {
                if (isShowErrMsg)
                {
                    System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("��û�д˴��ڵĲ���Ȩ��"));
                }
                return al;
            }

            //�ɹ���Ȩ�޿�������
            return al;
        }

         /// <summary>
        /// ��ȡ��ǰ����Ȩ�޿��Ҽ���
        /// </summary>
        /// <param name="class2Code">����Ȩ�ޱ���</param>
        /// <param name="isShowErrMsg">�Ƿ񵯳�������Ϣ</param>
        /// <returns>�ɹ�����ӵ��Ȩ�޿����б� ʧ�ܷ���null</returns>
        public static List<Neusoft.FrameWork.Models.NeuObject> QueryPrivList(string class2Code, bool isShowErrMsg)
        {
            return Function.QueryPrivList(class2Code, null, isShowErrMsg);
        }

        /// <summary>
        /// �������ڣ�ѡ��Ȩ�޿��ң�����û�ֻ��һ�����ҵ�Ȩ�ޣ������ֱ�ӵ�½
        /// </summary>
        /// <param name="class2Code">����Ȩ�ޱ���</param>
        /// <param name="privDept">Ȩ�޿���</param>
        /// <returns>1 ��������Ȩ�޿��� 0 �û�ѡ��ȡ�� ��1 �û���Ȩ��</returns>
        public static int ChoosePivDept(string class2Code, ref Neusoft.FrameWork.Models.NeuObject privDept)
        {
            return ChoosePrivDept(class2Code, null, ref privDept);
        }

        /// <summary>
        /// �������ڣ�ѡ��Ȩ�޿��ң�����û�ֻ��һ�����ҵ�Ȩ�ޣ������ֱ�ӵ�½
        /// </summary>
        /// <param name="class2Code">����Ȩ�ޱ���</param>
        /// <param name="class3Code">����Ȩ�ޱ���</param>
        /// <param name="privDept">Ȩ�޿���</param>
        /// <returns>1 ��������Ȩ�޿��� 0 �û�ѡ��ȡ�� ��1 �û���Ȩ��</returns>
        public static int ChoosePrivDept(string class2Code, string class3Code, ref Neusoft.FrameWork.Models.NeuObject privDept)
        {
            List<Neusoft.FrameWork.Models.NeuObject> al = new List<Neusoft.FrameWork.Models.NeuObject>();
            if (class3Code == null || class3Code == "")
                al = QueryPrivList(class2Code, true);
            else
                al = QueryPrivList(class2Code, class3Code, true);

            if (al == null || al.Count == 0)
            {
                return -1;
            }

            //����û�ֻ��һ�����ҵ�Ȩ�ޣ��򷵻ش˿���
            if (al.Count == 1)
            {
                privDept = al[0] as Neusoft.FrameWork.Models.NeuObject;
                return 1;
            }

            //�������ڣ�ȡȨ�޿���
            Neusoft.HISFC.Components.Common.Forms.frmChoosePrivDept formPrivDept = new Neusoft.HISFC.Components.Common.Forms.frmChoosePrivDept();
            formPrivDept.SetPriv(al, true);
            System.Windows.Forms.DialogResult Result = formPrivDept.ShowDialog();

            //ȡ���ڷ���Ȩ�޿���
            if (Result == System.Windows.Forms.DialogResult.OK)
            {
                privDept = formPrivDept.SelectData;
                return 1;
            }

            return 0;
        }

        #endregion

        #region ��ʾҽ��
        /// <summary>
        /// ��ʾҽ����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        public static void ShowOrder(object sender, ArrayList alOrder, Neusoft.HISFC.Models.Base.ServiceTypes serviceType)
        {
            ShowOrder(sender, alOrder, 0, serviceType);
        }
        /// <summary>
        /// ��ʾҽ����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="alOrder"></param>
        /// <param name="type"></param>
        public static void ShowOrder(object sender, ArrayList alOrder, int type ,Neusoft.HISFC.Models.Base.ServiceTypes serviceType)
        {
            try
            {
                #region ����dataSet

                #region ������������ʼ��
                //���崫��DataSet
                DataSet myDataSet = new DataSet();
                myDataSet.EnforceConstraints = false;//�Ƿ���ѭԼ������
                //��������
                System.Type dtStr = System.Type.GetType("System.String");
                System.Type dtBool = System.Type.GetType("System.Boolean");
                System.Type dtInt = System.Type.GetType("System.Int32");
                //�����********************************************************
                //Main Table
                DataTable dtMain = new DataTable();
                dtMain = myDataSet.Tables.Add("TableMain");

                dtMain.Columns.AddRange(new DataColumn[]{  new DataColumn("ID", dtStr),new DataColumn("��Ϻ�", dtStr), new DataColumn("ҽ������", dtStr),new DataColumn("���", dtStr),
															new DataColumn("���", dtStr),new DataColumn("���ʱ��", dtStr),new DataColumn("ÿ�μ���", dtStr),
															new DataColumn("Ƶ��", dtStr),new DataColumn("����", dtStr),new DataColumn("����", dtStr),
															new DataColumn("�÷�", dtStr),new DataColumn("ҽ������", dtStr),new DataColumn("�Ӽ�", dtBool),
															new DataColumn("��ʼʱ��", dtStr),new DataColumn("����ʱ��", dtStr),new DataColumn("����ҽ��", dtStr),
															new DataColumn("ִ�п���", dtStr),new DataColumn("ֹͣʱ��", dtStr),new DataColumn("ֹͣҽ��", dtStr),
															new DataColumn("��ע", dtStr),new DataColumn("˳���", dtStr)});


                Neusoft.HISFC.BizLogic.Pharmacy.Item pManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                Neusoft.HISFC.BizLogic.Fee.Item fManager = new Neusoft.HISFC.BizLogic.Fee.Item();
                Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();

                Neusoft.HISFC.BizLogic.Manager.OrderType orderType = new Neusoft.HISFC.BizLogic.Manager.OrderType();
                //Neusoft.HISFC.BizLogic.Fee.UndrugComb ztMgr = new Neusoft.HISFC.BizLogic.Fee.UndrugComb();

                Neusoft.FrameWork.Public.ObjectHelper helper = new Neusoft.FrameWork.Public.ObjectHelper(orderType.GetList());
                #endregion

                string beginDate = "", endDate = "", moDate = "";

                for (int i = 0; i < alOrder.Count; i++)
                {
                    if (serviceType == Neusoft.HISFC.Models.Base.ServiceTypes.I)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order o = alOrder[i] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        
                        #region ����ҽ������
                        o.OrderType = helper.GetObjectFromID(o.OrderType.ID) as Neusoft.HISFC.Models.Order.OrderType;
                        #endregion
                        Neusoft.HISFC.Models.Base.Item tempItem = null;
                        #region ������Ŀ��Ϣ
                        if (o.Item == null || o.Item.ID == "")
                        {
                            if (o.ID == "999")//�Ա���Ŀ
                            {
                                Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                                undrug.ID = o.ID;
                                undrug.Name = o.Name;
                                undrug.Qty = o.Item.Qty;
                                //undrug.IsPharmacy = false;
                                undrug.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
                                undrug.SysClass.ID = "M";
                                undrug.PriceUnit = o.Unit;
                                tempItem = undrug;
                                o.Item = tempItem;
                            }
                            else if (o.ID.Substring(0, 1) == "F")//��ҩƷ
                            {
                                #region ��ҩƷ
                                tempItem = fManager.GetValidItemByUndrugCode(o.ID);
                                if (tempItem == null || tempItem.ID == "")
                                {
                                    MessageBox.Show("��Ŀ" + o.Name + "�Ѿ�ͣ�ã�!", "��ʾ");
                                    o.Item.ID = o.ID;
                                    o.Item.Name = o.Name;
                                    o.ExtendFlag2 = "N";
                                }
                                else
                                {
                                    //zlw 10 01
                                //    if (((Neusoft.HISFC.Models.Fee.Item.Undrug)tempItem).ExecDepts.Count > 0)
                                //        o.ExeDept.ID = (((Neusoft.HISFC.Models.Fee.Item.Undrug)tempItem).ExecDepts[0]).ToString();
                                //    else
                                //        o.ExeDept = new Neusoft.FrameWork.Models.NeuObject();
                                    tempItem.Qty = o.Item.Qty;
                                    o.Item = tempItem;
                                }
                                #endregion
                            }
                            else if (o.ID.Substring(0, 1) == "Y")//ҩƷ
                            {
                                #region ҩƷ
                                Neusoft.HISFC.Models.Base.Employee p = pManager.Operator as Neusoft.HISFC.Models.Base.Employee;
                                if (p == null) return;
                                tempItem = pManager.GetItemForInpatient(p.Dept.ID, o.ID).Item;

                                if (tempItem == null || tempItem.ID == "")
                                {
                                    MessageBox.Show("��Ŀ" + o.Name + "�Ѿ�ͣ�ã�!", "��ʾ");
                                    //								alOrder.RemoveAt(i);//�Ƴ���ǰ��Ŀ	
                                    o.ExtendFlag2 = "N";
                                }
                                else
                                {
                                    //ҩƷִ�п���Ϊ��
                                    o.ExeDept = new Neusoft.FrameWork.Models.NeuObject();
                                    //{B9661764-2E06-462a-A9D9-05A3009D1F23}
                                    o.StockDept.ID = o.Item.User01;
                                    tempItem.Qty = o.Item.Qty;
                                    o.Item = tempItem;
                                    //o.StockDept.ID = tempItem.User02;

                                    Neusoft.HISFC.Models.Base.Department dept = null;
                                    if (o.StockDept != null && o.StockDept.ID != null && o.StockDept.ID != "")
                                        dept = deptMgr.GetDeptmentById(o.StockDept.ID);
                                    if (dept != null && dept.ID != "")
                                        o.StockDept.Name = dept.Name;
                                }
                                #endregion
                            }
                            else//������Ŀ
                            {
                                #region �����������Ŀ�Ѿ��鵽��ҩƷ��,��һ����ĸ��"F" ���Դ˴�����
                                Neusoft.HISFC.Models.Fee.Item.Undrug undrug = fManager.GetValidItemByUndrugCode(o.ID);
                                if (undrug == null)
                                {
                                    MessageBox.Show("������Ŀ:" + o.Name + "�Ѿ�ͣ�û���ɾ��,���ܵ���!", "��ʾ");

                                    o.ExtendFlag2 = "N";
                                }
                                else
                                {

                                    undrug.ID = o.ID;
                                    undrug.Name = o.Name;
                                    undrug.Qty = o.Item.Qty;
                                    undrug.PriceUnit = o.Unit;
                                    tempItem = undrug;
                                    o.Item = tempItem;

                                    //o.Item.IsPharmacy = false;
                                    o.Item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
                                    //if (((Neusoft.HISFC.Models.Fee.Item.Undrug)tempItem).ExecDepts.Count > 0)
                                    //    o.ExeDept.ID = (((Neusoft.HISFC.Models.Fee.Item.Undrug)tempItem).ExecDepts[0]).ToString();
                                    //else
                                    //    o.ExeDept = new Neusoft.FrameWork.Models.NeuObject();
                                    tempItem.Qty = o.Item.Qty;
                                    o.Item = tempItem;
                                }��
                                #endregion 
                            }
                        }

                        #endregion

                        #region ��ʾҽ��
                        if (o.Item != null)
                        {

                            if (o.BeginTime == DateTime.MinValue)
                                beginDate = "";
                            else
                                beginDate = o.BeginTime.ToString();

                            if (o.EndTime == DateTime.MinValue)
                                endDate = "";
                            else
                                endDate = o.EndTime.ToString();

                            if (o.MOTime == DateTime.MinValue)
                                moDate = "";
                            else
                                moDate = o.MOTime.ToString();

                            if (o.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
                            {
                                Neusoft.HISFC.Models.Pharmacy.Item item = o.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                                o.DoseUnit = item.DoseUnit;
                                dtMain.Rows.Add(new Object[] {  o.ID,o.Combo.ID,o.Item.Name,o.Item.Specs,
																 "",o.User03,o.DoseOnce.ToString()+item.DoseUnit ,
																 o.Frequency.ID,o.Qty.ToString()+o.Unit,o.HerbalQty,o.Usage.Name,
																 o.OrderType.Name,o.IsEmergency,beginDate,moDate,o.ReciptDoctor.Name,o.ExeDept.Name,endDate,
																 o.DCOper.Name,o.Memo,o.SortID});

                            }
                            else if (o.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))
                            {
                                dtMain.Rows.Add(new Object[] { o.ID,o.Combo.ID,o.Item.Name,o.Item.Specs,
																 "",o.User03,"" ,
																 o.Frequency.ID,o.Qty.ToString()+o.Unit,"","",
																 o.OrderType.Name,o.IsEmergency,beginDate,moDate,o.ReciptDoctor.Name,
																 o.ExeDept.Name,endDate,
																 o.DCOper.Name,o.Memo,o.SortID});
                            }
                            else
                            {
                                dtMain.Rows.Add(new Object[] { o.ID,o.Combo.ID, o.Item.Name,o.Item.Specs,
																 "",o.User03,o.DoseOnce.ToString()+o.DoseUnit,
																 o.Frequency.ID,o.Qty.ToString()+o.Unit,o.HerbalQty,o.Usage.Name,
																 o.OrderType.Name,o.IsEmergency,beginDate,moDate,o.ReciptDoctor.Name,
																 o.ExeDept.Name,endDate,
																 o.DCOper.Name,o.Memo,o.SortID});
                            }
                            //						}
                        #endregion
                        }
                    }
                    else
                    {
                        Neusoft.HISFC.Models.Order.OutPatient.Order o = alOrder[i] as Neusoft.HISFC.Models.Order.OutPatient.Order;
                        Neusoft.HISFC.Models.Base.Item tempItem = null;
                        #region ������Ŀ��Ϣ
                        if (o.Item == null || o.Item.ID == "")
                        {
                            if (o.ID == "999")//�Ա���Ŀ
                            {
                                Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                                undrug.ID = o.ID;
                                undrug.Name = o.Name;
                                undrug.Qty = o.Item.Qty;
                                //undrug.IsPharmacy = false;
                                undrug.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
                                undrug.SysClass.ID = "M";
                                undrug.PriceUnit = o.Unit;
                                tempItem = undrug;
                                o.Item = tempItem;
                            }
                            else if (o.ID.Substring(0, 1) == "F")//��ҩƷ
                            {
                                #region ��ҩƷ
                                tempItem = fManager.GetValidItemByUndrugCode(o.ID);
                                if (tempItem == null || tempItem.ID == "")
                                {
                                    MessageBox.Show("��Ŀ" + o.Name + "�Ѿ�ͣ�ã�!", "��ʾ");
                                    o.Item.ID = o.ID;
                                    o.Item.Name = o.Name;
                                    o.ExtendFlag2 = "N";
                                }
                                else
                                {
                                    //if (((Neusoft.HISFC.Models.Fee.Item.Undrug)tempItem).ExecDepts.Count > 0)
                                    //    o.ExeDept.ID = (((Neusoft.HISFC.Models.Fee.Item.Undrug)tempItem).ExecDepts[0]).ToString();
                                    //else
                                    //    o.ExeDept = new Neusoft.FrameWork.Models.NeuObject();
                                    tempItem.Qty = o.Item.Qty;
                                    o.Item = tempItem;
                                }
                                #endregion
                            }
                            else if (o.ID.Substring(0, 1) == "Y")//ҩƷ
                            {
                                #region ҩƷ
                                Neusoft.HISFC.Models.Base.Employee p = pManager.Operator as Neusoft.HISFC.Models.Base.Employee;
                                if (p == null) return;
                                //tempItem = pManager.GetItemForInpatient(p.Dept.ID, o.ID).Item;
                                Neusoft.HISFC.Models.Pharmacy.Storage tem = pManager.GetItemForInpatient(p.Dept.ID, o.ID);
                                tempItem = tem.Item;
                                if (tempItem == null || tempItem.ID == "")
                                {
                                    MessageBox.Show("��Ŀ" + o.Name + "�Ѿ�ͣ�ã�!", "��ʾ");
                                    //								alOrder.RemoveAt(i);//�Ƴ���ǰ��Ŀ	
                                    o.ExtendFlag2 = "N";
                                }
                                else
                                {
                                    //ҩƷִ�п���Ϊ��
                                    o.ExeDept = new Neusoft.FrameWork.Models.NeuObject();
                                    //{B9661764-2E06-462a-A9D9-05A3009D1F23}
                                    o.StockDept.ID = o.Item.User01;
                                    tempItem.Qty = o.Item.Qty;
                                    o.Item = tempItem;
                                    //o.StockDept.ID = tem.StockDept.ID;
                                    

                                    Neusoft.HISFC.Models.Base.Department dept = null;
                                    if (o.StockDept != null && o.StockDept.ID != null && o.StockDept.ID != "")
                                        dept = deptMgr.GetDeptmentById(o.StockDept.ID);
                                    if (dept != null && dept.ID != "")
                                        o.StockDept.Name = dept.Name;
                                }
                                #endregion
                            }
                            else//������Ŀ
                            {
                                #region ������ ������Ŀ�Ѿ��鲢����ҪƷ��,�˴�����
                                Neusoft.HISFC.Models.Fee.Item.Undrug undrug = fManager.GetValidItemByUndrugCode(o.ID);
                                if (undrug == null)
                                {
                                    MessageBox.Show("������Ŀ:" + o.Name + "�Ѿ�ͣ�û���ɾ��,���ܵ���!", "��ʾ");

                                    o.ExtendFlag2 = "N";
                                }
                                else
                                {

                                    undrug.ID = o.ID;
                                    undrug.Name = o.Name;
                                    undrug.Qty = o.Item.Qty;
                                    undrug.PriceUnit = o.Unit;
                                    tempItem = undrug;
                                    o.Item = tempItem;
                                    //o.Item.IsPharmacy = false;
                                    o.Item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
                                    //if (((Neusoft.HISFC.Models.Fee.Item.Undrug)tempItem).ExecDepts.Count > 0)
                                    //    o.ExeDept.ID = (((Neusoft.HISFC.Models.Fee.Item.Undrug)tempItem).ExecDepts[0]).ToString();
                                    //else
                                    //    o.ExeDept = new Neusoft.FrameWork.Models.NeuObject();
                                    tempItem.Qty = o.Item.Qty;
                                    o.Item = tempItem;
                                }��
                                #endregion
                            }
                        }

                        #endregion

                        #region ��ʾҽ��
                        if (o.Item != null)
                        {

                            if (o.BeginTime == DateTime.MinValue)
                                beginDate = "";
                            else
                                beginDate = o.BeginTime.ToString();

                            if (o.EndTime == DateTime.MinValue)
                                endDate = "";
                            else
                                endDate = o.EndTime.ToString();

                            if (o.MOTime == DateTime.MinValue)
                                moDate = "";
                            else
                                moDate = o.MOTime.ToString();

                            if (o.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
                            {
                                Neusoft.HISFC.Models.Pharmacy.Item item = o.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                                o.DoseUnit = item.DoseUnit;
                                dtMain.Rows.Add(new Object[] {  o.ID,o.Combo.ID,o.Item.Name,o.Item.Specs,
																 "",o.User03,o.DoseOnce.ToString()+item.DoseUnit ,
																 o.Frequency.ID,o.Qty.ToString()+o.Unit,o.HerbalQty,o.Usage.Name,
																 "",o.IsEmergency,beginDate,moDate,o.ReciptDoctor.Name,o.ExeDept.Name,endDate,
																 o.DCOper.Name,o.Memo,o.SortID});

                            }
                            else if (o.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))
                            {
                                dtMain.Rows.Add(new Object[] { o.ID,o.Combo.ID,o.Item.Name,o.Item.Specs,
																 "",o.User03,"" ,
																 o.Frequency.ID,o.Qty.ToString()+o.Unit,"","",
																 "",o.IsEmergency,beginDate,moDate,o.ReciptDoctor.Name,
																 o.ExeDept.Name,endDate,
																 o.DCOper.Name,o.Memo,o.SortID});
                            }
                            else
                            {
                                dtMain.Rows.Add(new Object[] { o.ID,o.Combo.ID, o.Item.Name,o.Item.Specs,
																 "",o.User03,o.DoseOnce.ToString()+o.DoseUnit,
																 o.Frequency.ID,o.Qty.ToString()+o.Unit,o.HerbalQty,o.Usage.Name,
																 "",o.IsEmergency,beginDate,moDate,o.ReciptDoctor.Name,
																 o.ExeDept.Name,endDate,
																 o.DCOper.Name,o.Memo,o.SortID});
                            }
                            //						}
                        #endregion
                        }
                    }
                    
                }
                #endregion

                switch (sender.GetType().ToString().Substring(sender.GetType().ToString().LastIndexOf(".") + 1))
                {
                    case "SheetView":
                        FarPoint.Win.Spread.SheetView o = sender as FarPoint.Win.Spread.SheetView;
                        o.RowCount = 0;
                        o.DataSource = myDataSet.Tables[0];
                        for (int i = 0; i < alOrder.Count; i++)
                        {
                            o.Rows[i].Tag = alOrder[i];

                            #region {6FD06A35-8BF7-4f16-8100-70D8EA28F122}
                            //����ҽ��״̬������ɫ
                            Neusoft.HISFC.Models.Order.Order tmpOrder = alOrder[i] as Neusoft.HISFC.Models.Order.Order;

                            switch (tmpOrder.Status)
                            {
                                case 0:
                                    o.RowHeader.Rows[i].BackColor = Color.FromArgb(128, 255, 128);
                                    break;
                                case 1:
                                    o.RowHeader.Rows[i].BackColor = Color.FromArgb(106, 174, 242);
                                    break;
                                case 2:
                                    o.RowHeader.Rows[i].BackColor = Color.FromArgb(243, 230, 105);
                                    break;
                                case 3:
                                    o.RowHeader.Rows[i].BackColor = Color.FromArgb(248, 120, 222);
                                    break;
                                default:
                                    o.RowHeader.Rows[i].BackColor = Color.Black;
                                    break;
                            }
                            #endregion

                        }
                        #region ������
                        o.Columns[0].Visible = false;
                        o.Columns[1].Visible = false;
                        //2 ("ҽ������", dtStr),3("���", dtStr),4 ���,5���ʱ��,6("ÿ�μ���", dtStr),
                        //7("Ƶ��", dtStr),8("����", dtStr),9("����", dtStr),
                        //10("�÷�", dtStr),11("ҽ������", dtStr),12("�Ӽ�", dtBool),
                        //13("��ʼʱ��", dtStr),14("����ʱ��", dtStr),15("����ҽ��", dtStr),
                        //16("ִ�п���", dtStr),17("ֹͣʱ��", dtStr),18("ֹͣҽ��", dtStr),
                        //19("��ע", dtStr),20("˳���", dtStr)});
                        o.Columns[2].Width = 150;
                        o.Columns[3].Width = 50;
                        o.Columns[4].Width = 40;
                        o.Columns[5].Width = 80;
                        o.Columns[5].CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                        o.Columns[6].Width = 100;
                        o.Columns[7].Width = 80;
                        o.Columns[8].Width = 80;
                        o.Columns[9].Width = 60;
                        o.Columns[10].Width = 80;
                        o.Columns[11].Width = 60;
                        o.Columns[12].Width = 40;
                        o.Columns[13].Width = 80;
                        o.Columns[14].Width = 80;
                        o.Columns[15].Width = 80;
                        o.Columns[16].Width = 80;
                        o.Columns[17].Width = 80;
                        o.Columns[18].Width = 80;
                        o.Columns[19].Width = 80;
                        o.Columns[20].Width = 30;
                        if (type == 1)//����
                        {
                            o.Columns[5].Visible = true;
                        }
                        else
                        {
                            o.Columns[5].Visible = false;
                        }
                        #endregion
                       
                        Function.DrawCombo(o, 1, 4);
                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public static void DrawCombo(object sender, int column, int DrawColumn, int ChildViewLevel)
        {
            switch (sender.GetType().ToString().Substring(sender.GetType().ToString().LastIndexOf(".") + 1))
            {
                case "SheetView":
                    FarPoint.Win.Spread.SheetView o = sender as FarPoint.Win.Spread.SheetView;
                    int i = 0;
                    string tmp = "", curComboNo = "";
                    if (ChildViewLevel == 0)
                    {
                        for (i = 0; i < o.RowCount; i++)
                        {
                            #region "��"
                            if (o.Cells[i, column].Text == "0") o.Cells[i, column].Text = "";
                            tmp = o.Cells[i, column].Text + "";
                            o.Cells[i, column].Tag = tmp;
                            if (curComboNo != tmp && tmp != "") //��ͷ
                            {
                                curComboNo = tmp;
                                o.Cells[i, DrawColumn].Text = "��";
                                try
                                {
                                    if (o.Cells[i - 1, DrawColumn].Text == "��")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "��";
                                    }
                                    else if (o.Cells[i - 1, DrawColumn].Text == "��")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "";
                                    }
                                }
                                catch { }
                            }
                            else if (curComboNo == tmp && tmp != "")
                            {
                                o.Cells[i, DrawColumn].Text = "��";
                            }
                            else if (curComboNo != tmp && tmp == "")
                            {
                                try
                                {
                                    if (o.Cells[i - 1, DrawColumn].Text == "��")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "��";
                                    }
                                    else if (o.Cells[i - 1, DrawColumn].Text == "��")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "";
                                    }
                                }
                                catch { }
                                o.Cells[i, DrawColumn].Text = "";
                                curComboNo = "";
                            }
                            if (i == o.RowCount - 1 && o.Cells[i, DrawColumn].Text == "��") o.Cells[i, DrawColumn].Text = "��";
                            if (i == o.RowCount - 1 && o.Cells[i, DrawColumn].Text == "��") o.Cells[i, DrawColumn].Text = "";
                            //o.Cells[i, DrawColumn].ForeColor = System.Drawing.Color.Red;
                            #endregion
                        }
                    }
                    else if (ChildViewLevel == 1)
                    {
                        for (int m = 0; m < o.RowCount; m++)
                        {
                            FarPoint.Win.Spread.SheetView c = o.GetChildView(m, 0);
                            for (int j = 0; j < c.RowCount; j++)
                            {
                                #region "��"
                                if (c.Cells[j, column].Text == "0") c.Cells[j, column].Text = "";
                                tmp = c.Cells[j, column].Text + "";

                                c.Cells[j, column].Tag = tmp;
                                if (curComboNo != tmp && tmp != "") //��ͷ
                                {
                                    curComboNo = tmp;
                                    c.Cells[j, DrawColumn].Text = "��";
                                    try
                                    {
                                        if (c.Cells[j - 1, DrawColumn].Text == "��")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "��";
                                        }
                                        else if (c.Cells[j - 1, DrawColumn].Text == "��")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "";
                                        }
                                    }
                                    catch { }
                                }
                                else if (curComboNo == tmp && tmp != "")
                                {
                                    c.Cells[j, DrawColumn].Text = "��";
                                }
                                else if (curComboNo != tmp && tmp == "")
                                {
                                    try
                                    {
                                        if (c.Cells[j - 1, DrawColumn].Text == "��")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "��";
                                        }
                                        else if (c.Cells[j - 1, DrawColumn].Text == "��")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "";
                                        }
                                    }
                                    catch { }
                                    c.Cells[j, DrawColumn].Text = "";
                                    curComboNo = "";
                                }
                                if (j == c.RowCount - 1 && c.Cells[j, DrawColumn].Text == "��") c.Cells[j, DrawColumn].Text = "��";
                                if (j == c.RowCount - 1 && c.Cells[j, DrawColumn].Text == "��") c.Cells[j, DrawColumn].Text = "";
                                //c.Cells[j, DrawColumn].ForeColor = System.Drawing.Color.Red;
                                #endregion

                            }
                        }
                    }
                    break;
            }

        }
        /// <summary>
        /// ����Ϻ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="column"></param>
        /// 		/// <param name="DrawColumn"></param>
        public static void DrawCombo(object sender, int column, int DrawColumn)
        {
            DrawCombo(sender, column, DrawColumn, 0);
        }
       
        #endregion

        #region ���ֽ�Ŵ�С
        protected static Neusoft.HISFC.BizLogic.Manager.PageSize manager = new Neusoft.HISFC.BizLogic.Manager.PageSize();

        /// <summary>
        /// ���ô�ӡֽ��
        /// ֻ�Է�Ĭ��ֽ��A4��Ҫ��������
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="print"></param>
        public static void GetPageSize(string ID, ref Neusoft.FrameWork.WinForms.Classes.Print print)
        {

            Neusoft.HISFC.Models.Base.PageSize p = manager.GetPageSize(ID);
            if (p == null || p.Name.Trim() == "") return;
            print.SetPageSize(p);
            //manager = null;
        }
        /// <summary>
        /// ���ô�ӡֽ��
        /// ��Ҫ��Transaction
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="print"></param>
        /// <param name="t"></param>
        public static void GetPageSize(string ID, ref Neusoft.FrameWork.WinForms.Classes.Print print, ref Neusoft.FrameWork.Management.Transaction t)
        {
            try
            {
                manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            }
            catch { }
            Neusoft.HISFC.Models.Base.PageSize p = manager.GetPageSize(ID);
            if (p == null || p.Name.Trim() == "") return;
            print.SetPageSize(p);
            //manager = null;
        }
        /// <summary>
        /// ��ô�ӡֽ��
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Neusoft.HISFC.Models.Base.PageSize GetPageSize(string ID)
        {
            return manager.GetPageSize(ID);
        }
        #endregion

        #region "ISql interface����"
        private static Neusoft.FrameWork.Management.Interface sql = null;
        /// <summary>
        /// sql סԺ������
        /// </summary>
        public static Neusoft.FrameWork.Management.Interface ISql
        {
            get
            {
                if (sql == null)
                {
                    sql = new Neusoft.FrameWork.Management.Interface();
                    string fileName = "";// TemplateDesignerHost.Function.SystemPath + "PATIENTINFO.xml";
                    sql.ReadXML(fileName);
                    try
                    {
                        sql.SetParam(Neusoft.FrameWork.Management.Connection.Operator.ID, "");
                        sql.RefreshVariant();
                    }
                    catch { }
                    return sql;
                }
                else
                {
                    return sql;
                }
            }
        }
        private static Neusoft.FrameWork.Management.Interface sqlOutPatient = null;
        /// <summary>
        /// sql ���������
        /// </summary>
        public static Neusoft.FrameWork.Management.Interface ISqlOutPatient
        {
            get
            {
                if (sqlOutPatient == null)
                {
                    sqlOutPatient = new Neusoft.FrameWork.Management.Interface();
                    string fileName = "";// TemplateDesignerHost.Function.SystemPath + "OUTPATIENTINFO.xml";
                    sqlOutPatient.ReadXML(fileName);
                    try
                    {
                        sqlOutPatient.SetParam(Neusoft.FrameWork.Management.Connection.Operator.ID, "");
                        sqlOutPatient.RefreshVariant();
                    }
                    catch { }
                    return sqlOutPatient;
                }
                else
                {
                    return sqlOutPatient;
                }
            }
        }
        private static Neusoft.FrameWork.Management.Interface sqlCheck = null;
        /// <summary>
        /// sql ��������
        /// </summary>
        public static Neusoft.FrameWork.Management.Interface ISqlCheck
        {
            get
            {
                if (sqlCheck == null)
                {
                    sqlCheck = new Neusoft.FrameWork.Management.Interface();
                    string fileName = "";// TemplateDesignerHost.Function.SystemPath + "CHECKPATIENTINFO.xml";
                    sqlCheck.ReadXML(fileName);
                    try
                    {
                        sqlCheck.SetParam(Neusoft.FrameWork.Management.Connection.Operator.ID, "");
                        sqlCheck.RefreshVariant();
                    }
                    catch { }
                    return sqlCheck;
                }
                else
                {
                    return sqlCheck;
                }
            }
        }

        private static Neusoft.FrameWork.Management.Interface sqlOther = null;
        /// <summary>
        /// sql ��������
        /// </summary>
        public static Neusoft.FrameWork.Management.Interface ISqlOther
        {
            get
            {
                if (sqlOther == null)
                {
                    sqlOther = new Neusoft.FrameWork.Management.Interface();
                    string fileName = Neusoft.FrameWork.Management.Connection.SystemPath + "\\OtherPATIENTINFO.xml";
                    sqlOther.ReadXML(fileName);
                    try
                    {
                        sqlOther.SetParam(Neusoft.FrameWork.Management.Connection.Operator.ID, "");
                        sqlOther.RefreshVariant();
                    }
                    catch { }
                    return sqlOther;
                }
                else
                {
                    return sqlOther;
                }
            }
        }

        #endregion


        #region ���Ӳ���ʹ�õĵ���
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="patientInfo"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int EMRPrint(Control parentControl, Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, string type)
        {
            //TemplateDesignerApplication.ucDataFileLoader ucDataFileLoader1 = new TemplateDesignerApplication.ucDataFileLoader();
            //string[] param ={ Neusoft.FrameWork.Management.Connection.Operator.ID, patientInfo.ID };
            //ucDataFileLoader1.Location = new Point(0, 2000);
            //ucDataFileLoader1.ISql = Neusoft.HISFC.Components.Common.Classes.Function.ISql;
            //ucDataFileLoader1.InitSql("", param);
            //ucDataFileLoader1.Init(type, patientInfo.ID);//3 ��Ժ֪ͨ��
            //ucDataFileLoader1.index1 = patientInfo.ID;
            //ucDataFileLoader1.index2 = patientInfo.Name;
            //ucDataFileLoader1.IsShowInterface = false;
            //ucDataFileLoader1.RefreshForm();
            //ucDataFileLoader1.Visible = true;
            //parentControl.Controls.Add(ucDataFileLoader1);

            //Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            //int i = p.PrintPage(0, 0, ucDataFileLoader1.CurrntPanel);
            //ucDataFileLoader1.Visible = false;
            return 0;// i;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="patientInfo"></param>
        /// <param name="type"></param>
        /// <param name="printer"></param>
        /// <returns></returns>
        public static int EMRPrint(Control parentControl, Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, string type, Neusoft.FrameWork.WinForms.Classes.Print printer)
        {
            //TemplateDesignerApplication.ucDataFileLoader ucDataFileLoader1 = new TemplateDesignerApplication.ucDataFileLoader();
            //string[] param ={ Neusoft.FrameWork.Management.Connection.Operator.ID, patientInfo.ID };
            //ucDataFileLoader1.Location = new Point(0, 2000);
            //ucDataFileLoader1.ISql = Neusoft.HISFC.Components.Common.Classes.Function.ISql;
            //ucDataFileLoader1.InitSql("", param);
            //ucDataFileLoader1.Init(type, patientInfo.ID);//3 ��Ժ֪ͨ��
            //ucDataFileLoader1.index1 = patientInfo.ID;
            //ucDataFileLoader1.index2 = patientInfo.Name;
            //ucDataFileLoader1.IsShowInterface = false;
            //ucDataFileLoader1.RefreshForm();
            //ucDataFileLoader1.Visible = true;
            //parentControl.Controls.Add(ucDataFileLoader1);
            //int i = printer.PrintPage(0, 0, ucDataFileLoader1.CurrntPanel);
            //ucDataFileLoader1.Visible = false;
            return 0;// i;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="patientInfo"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int EMRPrintPreview(Control parentControl, Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, string type)
        {
            //TemplateDesignerApplication.ucDataFileLoader ucDataFileLoader1 = new TemplateDesignerApplication.ucDataFileLoader();
            //string[] param ={ Neusoft.FrameWork.Management.Connection.Operator.ID, patientInfo.ID };
            //ucDataFileLoader1.Location = new Point(0, 2000);
            //ucDataFileLoader1.ISql = Neusoft.HISFC.Components.Common.Classes.Function.ISql;
            //ucDataFileLoader1.InitSql("", param);
            //ucDataFileLoader1.Init(type, patientInfo.ID);//3 ��Ժ֪ͨ��
            //ucDataFileLoader1.index1 = patientInfo.ID;
            //ucDataFileLoader1.index2 = patientInfo.Name;
            //ucDataFileLoader1.IsShowInterface = false;
            //ucDataFileLoader1.RefreshForm();
            //ucDataFileLoader1.Visible = true;
            //parentControl.Controls.Add(ucDataFileLoader1);
            //Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            //int i = p.PrintPreview(ucDataFileLoader1.CurrntPanel);
            //ucDataFileLoader1.Visible = false;
            return 0;//i;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="patientInfo"></param>
        /// <param name="type"></param>
        /// <param name="printer"></param>
        /// <returns></returns>
        public static int EMRPrintPreview(Control parentControl, Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, string type, Neusoft.FrameWork.WinForms.Classes.Print printer)
        {
            //TemplateDesignerApplication.ucDataFileLoader ucDataFileLoader1 = new TemplateDesignerApplication.ucDataFileLoader();
            //string[] param ={ Neusoft.FrameWork.Management.Connection.Operator.ID, patientInfo.ID };
            //ucDataFileLoader1.Location = new Point(0, 2000);
            //ucDataFileLoader1.ISql = Neusoft.HISFC.Components.Common.Classes.Function.ISql;
            //ucDataFileLoader1.InitSql("", param);
            //ucDataFileLoader1.Init(type, patientInfo.ID);//3 ��Ժ֪ͨ��
            //ucDataFileLoader1.index1 = patientInfo.ID;
            //ucDataFileLoader1.index2 = patientInfo.Name;
            //ucDataFileLoader1.IsShowInterface = false;
            //ucDataFileLoader1.RefreshForm();
            //ucDataFileLoader1.Visible = true;
            //parentControl.Controls.Add(ucDataFileLoader1);
            //int i = printer.PrintPreview(ucDataFileLoader1.CurrntPanel);
            //ucDataFileLoader1.Visible = false;
            return 0;// i;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="patientInfo"></param>
        /// <param name="type"></param>
        public static void EMRShow(Control parentControl, Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, string type)
        {
            //TemplateDesignerApplication.ucDataFileLoader ucDataFileLoader1 = new TemplateDesignerApplication.ucDataFileLoader();
            //string[] param ={ Neusoft.FrameWork.Management.Connection.Operator.ID, patientInfo.ID };
            //ucDataFileLoader1.Location = new Point(0, 0);
            //ucDataFileLoader1.Dock = DockStyle.Fill;
            //ucDataFileLoader1.ISql = Neusoft.HISFC.Components.Common.Classes.Function.ISql;
            //ucDataFileLoader1.InitSql("", param);
            //ucDataFileLoader1.Init(type, patientInfo.ID);
            //ucDataFileLoader1.index1 = patientInfo.ID;
            //ucDataFileLoader1.index2 = patientInfo.Name;
            //ucDataFileLoader1.IsShowInterface = false;
            //ucDataFileLoader1.RefreshForm();
            //ucDataFileLoader1.Visible = true;
            //parentControl.Controls.Add(ucDataFileLoader1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="patientInfo"></param>
        /// <param name="type"></param>
        /// <param name="bShowInterface"></param>
        public static void EMRShow(Control parentControl, Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, string type, bool bShowInterface)
        {
            //TemplateDesignerApplication.ucDataFileLoader ucDataFileLoader1 = new TemplateDesignerApplication.ucDataFileLoader();
            //string[] param ={ Neusoft.FrameWork.Management.Connection.Operator.ID, patientInfo.ID };
            //ucDataFileLoader1.Location = new Point(0, 0);
            //ucDataFileLoader1.Dock = DockStyle.Fill;
            //ucDataFileLoader1.ISql = Neusoft.HISFC.Components.Common.Classes.Function.ISql;
            //ucDataFileLoader1.InitSql("", param);
            //ucDataFileLoader1.Init(type, patientInfo.ID);
            //ucDataFileLoader1.index1 = patientInfo.ID;
            //ucDataFileLoader1.index2 = patientInfo.Name;
            //ucDataFileLoader1.IsShowInterface = bShowInterface;
            //ucDataFileLoader1.RefreshForm();
            //ucDataFileLoader1.Visible = true;
            //parentControl.Controls.Add(ucDataFileLoader1);
        }
        #endregion

        /// <summary>
        /// ���������ļ� feeSetting.xml �ṩ�������뷨
        /// </summary>
        /// <returns></returns>
        public static int CreateFeeSetting()
        {
            try
            {
                XmlDocument docXml = new XmlDocument();
                if (System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml"))
                {
                    System.IO.File.Delete(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath);
                }
                docXml.LoadXml("<setting>  </setting>");
                XmlNode root = docXml.DocumentElement;

                XmlElement elem1 = docXml.CreateElement("���뷨");
                System.Xml.XmlComment xmlcomment; 
                xmlcomment = docXml.CreateComment("��ѯ��ʽ0:ƴ���� 1:����� 2:�Զ����� 3:������ 4:Ӣ��");
                elem1.SetAttribute("currentmodel", "0");
                root.AppendChild(xmlcomment);
                root.AppendChild(elem1);

                XmlElement elem2 = docXml.CreateElement("IME");
                System.Xml.XmlComment xmlcomment2;
                xmlcomment2 = docXml.CreateComment("��ǰĬ�����뷨");
                elem2.SetAttribute("currentmodel", "�Ϲ�ƴ�����뷨");
                root.AppendChild(xmlcomment2);
                root.AppendChild(elem2);

                docXml.Save(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 1;
        }

        #region ���ݿ����

        /// <summary>
        /// ��ѯ�ۼ�����Sql
        /// </summary>
        private static string insertSql = @"INSERT INTO COM_QUERY_LOG (
	REPORT_ID ,                             --����ID
	REPORT_NAME ,                           --��������
	REPORT_CONDITION ,                      --��ѯ����
	QUERY_OPER ,                            --��ѯ��
	LOGIN_FUN ,                             --��½������
	LOGIN_DEPT ,                            --��½����
	MACHINE_NAME ,                          --��������
	MACHINE_IP ,                            --��½IP
	QUERY_DATE                              --��ѯʱ��
)  VALUES(
	'{0}' ,       --����ID
	'{1}' ,       --��������
	'{2}' ,       --��ѯ����
	'{3}' ,       --��ѯ��
	'{4}' ,       --��½������
	'{5}' ,       --��½����
	'{6}' ,       --��������
	'{7}' ,       --��½IP
	to_date('{8}','yyyy-mm-dd HH24:mi:ss')         --��ѯʱ��
) 
";

        #endregion

        /// <summary>
        /// ������Ϣ��ѯ�ۼ���������
        /// </summary>
        /// <param name="reportID">����ID</param>
        /// <param name="reportName">��������</param>
        /// <param name="reportCondition">��ѯ����</param>
        public static void SaveQueryLog(string reportID, string reportName, string reportCondition)
        {
            Neusoft.HISFC.Models.Base.Employee person = new Neusoft.HISFC.Models.Base.Employee();
            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

            string hosName = System.Net.Dns.GetHostName();
            string ip = System.Net.Dns.GetHostEntry(hosName).AddressList[0].ToString();

            person = dataManager.Operator as Neusoft.HISFC.Models.Base.Employee;
            if (person == null)
            {
                return;
            }

            //person.ID = person.ID;							//����ԱID
            //person.Name = person.Name;						//����Ա����
            //person.Memo = person.Dept.ID;					//��½������
            //person.User01 = person.Dept.Name;				//��½����ID
            //person.User02 = hosName;						//��������
            //person.User03 = ip;								//IP
            //person.CurrentGroup.Name = person.CurrentGroup.Name;	//��½����
            //person.CurrentGroup.ID = person.CurrentGroup.ID;		//�Ǽ���ID

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(dataManager.Connection);
            //t.BeginTransaction();
            dataManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            string sql = string.Format(Function.insertSql, 
                                        reportID, 
                                        reportName, 
                                        reportCondition, 
                                        person.ID, 
                                        person.CurrentGroup.Name, 
                                        person.Dept.ID, 
                                        hosName, 
                                        ip, 
                                        dataManager.GetDateTimeFromSysDateTime().ToString());
            int parm = dataManager.ExecNoQuery(sql);
            if (parm == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return;
            }
            if (parm > 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                return;
            }
        }

        #region ���뷨ȫ���л��ɰ��

        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hwnd);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetOpenStatus(IntPtr himc);
        [DllImport("imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr himc, bool b);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr himc, ref int lpdw, ref int lpdw2);
        [DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr hwnd, int lngHotkey);
        public const int IME_CMODE_FULLSHAPE = 0x8;
        public const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;

        /// <summary>
        /// ���ô���ؼ��е����뷨״̬Ϊ���
        /// </summary>
        /// <param name="frm">��ǰ����</param>
        public static void SetIme(Form frm)
        {
            frm.Paint += new PaintEventHandler(frm_Paint);
            ChangeAllControl(frm);
        }
        /// <summary>
        /// ���ÿؼ������뷨״̬Ϊ���
        /// </summary>
        /// <param name="ctl">�ؼ�</param>
        public static void SetIme(Control ctl)
        {
            ChangeAllControl(ctl);
        }
        /// <summary>
        /// ���ö�������뷨״̬Ϊ���
        /// </summary>
        /// <param name="Handel">������</param>
        public static void SetIme(IntPtr Handel)
        {
            ChangeControlIme(Handel);
        }
        private static void ChangeAllControl(Control ctl)
        {
            //�ڿؼ��ĵ�Enter�¼��д������������뷨״̬


            ctl.Enter += new EventHandler(ctl_Enter);
            //�����ӿؼ���ʹÿ���ؼ�������Enter��ί�д���


            foreach (Control ctlChild in ctl.Controls)
            {
                ChangeAllControl(ctlChild);
            }
        }

        static void frm_Paint(object sender, PaintEventArgs e)
        {
            ChangeControlIme(sender);
        }
        //�ؼ���Enter��������
        static void ctl_Enter(object sender, EventArgs e)
        {
            ChangeControlIme(sender);
        }
        private static void ChangeControlIme(object sender)
        {
            Control ctl = (Control)sender;
            ChangeControlIme(ctl.Handle);
        }
        /// <summary>
        /// �������������������������뷨��ȫ�ǰ��״̬


        /// </summary>
        /// <param name="h"></param>
        private static void ChangeControlIme(IntPtr h)
        {
            IntPtr HIme = ImmGetContext(h);
            if (ImmGetOpenStatus(HIme)) //������뷨���ڴ�״̬
            {
                int iMode = 0;
                int iSentence = 0;
                bool bSuccess = ImmGetConversionStatus(HIme, ref iMode, ref iSentence); //�������뷨��Ϣ
                if (bSuccess)
                {
                    if ((iMode & IME_CMODE_FULLSHAPE) > 0) //�����ȫ��
                    {
                        ImmSimulateHotKey(h, IME_CHOTKEY_SHAPE_TOGGLE); //ת���ɰ��


                    }
                }
            }
        }

        #endregion

        //{ED51E97B-B752-4c32-BD93-F80209A24879}���������������

        #region ������Ŀʹ��Ƶ������

        /// <summary>
        /// ����xml �ļ���ַ
        /// </summary>
        public static string SORT_FILE_PATH = Application.StartupPath + "\\Setting\\Profiles\\itemSort.xml";

        /// <summary>
        /// ����XML �ļ�λ��
        /// </summary>
        public static string FEE_SET_PATH = Application.StartupPath + "\\Setting\\Profiles\\feeSetting.xml";

        /// <summary>
        /// ��ǰxml��ʵ��
        /// </summary>
        public static XmlDocument xmlDoc = null;

        /// <summary>
        /// ��ǰ����xmlʵ��
        /// </summary>
        public static XmlDocument xmlSetDoc = null;

        /// <summary>
        /// �Ƿ���ڹ���xml
        /// </summary>
        /// <returns>�ɹ� true ʧ�� false</returns>
        private static bool IsExistSettingFeeXML()
        {
            try
            {
                return System.IO.File.Exists(FEE_SET_PATH);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// ��õ�ǰ��Ŀ���������,���û���ҵ�,��Ĭ��Ϊ0
        /// </summary>
        /// <param name="xDoc">��ǰxml</param>
        /// <param name="itemCode">��Ŀ����</param>
        /// <returns>�ɹ� ��ǰ��Ŀ��������� û���ҵ����� 0</returns>
        public static string GetDeptValue(XmlDocument xDoc)
        {
            XmlNode root = xDoc.SelectSingleNode("setting//defaultDept");

            if (root != null)
            {
                return root.InnerText;
            }

            return null;
        }

        /// <summary>
        /// ���õ�ǰĬ��ִ��ҩ��
        /// </summary>
        /// <param name="deptCode">���Ҵ���</param>
        public static void SetDefaultDeptXML(string deptCode)
        {
            if (xmlSetDoc == null)
            {
                xmlSetDoc = GetSetXML();
            }

            if (xmlDoc == null)
            {
                return;
            }

            XmlNode root = xmlSetDoc.SelectSingleNode("setting");

            XmlNode xFind = root.SelectSingleNode("defaultDept");
            if (xFind == null)//û���ҵ�,Ҫ����һ���ڵ�
            {
                InsertSettingNewItem(deptCode, xmlSetDoc);
            }
            else//���ĵ�ǰ��Ŀ��ʹ��Ƶ�� + 1 
            {
                ModifySettingItem(deptCode, xmlSetDoc, xFind);
            }
        }

        /// <summary>
        /// ����һ���µĽڵ�,���ĵ�һ��Ϊ����,��Ŀ����ǰ������һ����д��ĸ"A"
        /// </summary>
        /// <param name="deptCode">���ұ���</param>
        /// <param name="xDoc">��ǰxml</param>
        private static void InsertSettingNewItem(string deptCode, XmlDocument xDoc)
        {
            if (xDoc == null)
            {
                return;
            }
            
            XmlElement xe = xDoc.CreateElement("defaultDept");
            xe.InnerText = deptCode;

            XmlNode root = xDoc.SelectSingleNode("Setting");

            root.AppendChild(xe);

            xDoc.Save(FEE_SET_PATH);
        }

        /// <summary>
        /// �޸�һ���ڵ�
        /// </summary>
        /// <param name="deptCode">���ұ���</param>
        /// <param name="xDoc">��ǰxml</param>
        /// <param name="xe">��ǰ�ڵ�</param>
        private static void ModifySettingItem(string deptCode, XmlDocument xDoc, XmlNode xe)
        {
            if (xDoc == null)
            {
                return;
            }
            
            xe.InnerText = deptCode;

            xDoc.Save(FEE_SET_PATH);
        }

        /// <summary>
        /// �Ƿ���ڹ���xml
        /// </summary>
        /// <returns>�ɹ� true ʧ�� false</returns>
        private static bool IsExistSettingXML()
        {
            try
            {
                return System.IO.File.Exists(SORT_FILE_PATH);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// ��õ�ǰsortXML
        /// </summary>
        /// <returns>�ɹ� ����xml ʧ�� null</returns>
        public static XmlDocument GetSortXML()
        {
            if (!IsExistSettingXML())
            {
                return null;
            }

            XmlDocument xdoc = new XmlDocument();

            xdoc.Load(SORT_FILE_PATH);

            return xdoc;
        }

        /// <summary>
        /// ��õ�ǰsortXML
        /// </summary>
        /// <returns>�ɹ� ����xml ʧ�� null</returns>
        public static XmlDocument GetSetXML()
        {
            if (!IsExistSettingXML())
            {
                return null;
            }

            XmlDocument xdoc = new XmlDocument();

            xdoc.Load(FEE_SET_PATH);

            return xdoc;
        }

        /// <summary>
        /// ����һ���µĽڵ�,���ĵ�һ��Ϊ����,��Ŀ����ǰ������һ����д��ĸ"A"
        /// </summary>
        /// <param name="itemCode">��Ŀ����</param>
        /// <param name="xDoc">��ǰxml</param>
        private static void InsertNewItem(string itemCode, XmlDocument xDoc)
        {
            if (xDoc == null)
            {
                return;
            }
            
            XmlElement xe = xDoc.CreateElement("A" + itemCode);
            xe.InnerText = "1";

            XmlNode root = xDoc.SelectSingleNode("Column");

            root.AppendChild(xe);

            xDoc.Save(SORT_FILE_PATH);
        }

        /// <summary>
        /// �޸�һ���ڵ�
        /// </summary>
        /// <param name="itemCode">��Ŀ����</param>
        /// <param name="xDoc">��ǰxml</param>
        /// <param name="xe">��ǰ�ڵ�</param>
        private static void ModifyItem(string itemCode, XmlDocument xDoc, XmlNode xe)
        {
            if (xDoc == null)
            {
                return;
            }
            
            xe.InnerText = (Neusoft.FrameWork.Function.NConvert.ToInt32(xe.InnerText) + 1).ToString();

            xDoc.Save(SORT_FILE_PATH);
        }

        /// <summary>
        /// ���õ�ǰ�������Ŀ������Ŀ����һ������ڵ�,����Ѿ�����,�����������+1
        /// </summary>
        /// <param name="itemCode">��Ŀ����</param>
        public static void SetSortItemXML(string itemCode)
        {
            if (xmlDoc == null)
            {
                xmlDoc = GetSortXML();
            }

            if (xmlDoc == null)
            {
                return;
            }

            XmlNode root = xmlDoc.SelectSingleNode("Column");

            XmlNode xFind = root.SelectSingleNode("A" + itemCode);
            if (xFind == null)//û���ҵ�,Ҫ����һ���ڵ�
            {
                InsertNewItem(itemCode, xmlDoc);
            }
            else//���ĵ�ǰ��Ŀ��ʹ��Ƶ�� + 1 
            {
                ModifyItem(itemCode, xmlDoc, xFind);
            }
        }

        /// <summary>
        /// ��õ�ǰ��Ŀ���������,���û���ҵ�,��Ĭ��Ϊ0
        /// </summary>
        /// <param name="xDoc">��ǰxml</param>
        /// <param name="itemCode">��Ŀ����</param>
        /// <returns>�ɹ� ��ǰ��Ŀ��������� û���ҵ����� 0</returns>
        public static int GetSortValue(XmlDocument xDoc, string itemCode)
        {
            if (xDoc == null) 
            {
                return 0;
            }
            
            XmlNode root = xDoc.SelectSingleNode("Column");

            XmlNode xFind = root.SelectSingleNode("A" + itemCode);
            if (xFind != null)
            {
                return Neusoft.FrameWork.Function.NConvert.ToInt32(xFind.InnerText);
            }

            return 0;
        }

        #endregion

        //{ED51E97B-B752-4c32-BD93-F80209A24879}������������������

        #region {839D3A8A-49FA-4d47-A022-6196EB1A5715} ��MQǶ��ϵͳ��ҽ��վ����ʱ���Զ�֪ͨ��ʿվ����ʿվҽ���������Զ���Ӧ������QQ��ͷ��ζ��������Ը���������ʾ

        public static string currentPath = ".";
        public static string strLabel = "";

        /// <summary>
        /// ��¼ɾ�����MQ��Ϣ
        /// </summary>
        /// <param name="sRecord"></param>
        public static string Label(string sRecord)
        {
            FileStream fs;
            string path = currentPath + "\\Label.txt";
            if (!File.Exists(path))
            {
                fs = File.Create(path);
                fs.Close();
            }
            StreamReader sr = File.OpenText(path);
            strLabel = sr.ReadToEnd();
            strLabel = strLabel.Trim('\0') + '\0';
            sr.Close();

            if (!string.IsNullOrEmpty(sRecord))
            {
                strLabel += sRecord + "\0";

                fs = File.OpenWrite(path);
                Byte[] info = new UTF8Encoding(true).GetBytes(strLabel);
                fs.Write(info, 0, info.Length);
                fs.Close();
            }

            return strLabel;
        }

        /// <summary>
        /// ɾ����������ʾ
        /// </summary>
        /// <param name="inpatientNO"></param>
        public static void DelLabel(string inpatientNO)
        {
            Label("");

            string sRecord = "";
            string[] messageArr = strLabel.Split('\0');
            ArrayList alInpatienNO = new ArrayList();
            foreach (string messageInfo in messageArr)
            {
                if (messageInfo != "")
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    if (messageInfo.Substring(messageInfo.IndexOf("ZY"), 14) == inpatientNO)
                    {
                        sRecord += messageInfo + '\0';
                    }
                }
            }

            if (strLabel.IndexOf(sRecord) < 0)
            {
                return;
            }
            strLabel = strLabel.Remove(strLabel.LastIndexOf(sRecord), sRecord.Length);

            if (File.Exists(currentPath + "\\Label.txt"))
            {
                File.Delete(currentPath + "\\Label.txt");
            }
            Label(strLabel);
        }

        #endregion

        #region addby xuewj 2010-11-11 �������뵥��ȡ���������ļ� {457F6C34-7825-4ece-ACFB-B3A9CA923D6D}
        /// <summary>
        /// �½�XML
        /// </summary>
        /// <returns></returns>
        public static int CreateXML(string fileName, string isUsePacsApply)
        {
            string path;
            try
            {
                path = fileName.Substring(0, fileName.LastIndexOf(@"\"));
                if (System.IO.Directory.Exists(path) == false)
                {
                    System.IO.Directory.CreateDirectory(path);
                }
            }
            catch { }

            Neusoft.FrameWork.Xml.XML myXml = new Neusoft.FrameWork.Xml.XML();
            XmlDocument doc = new XmlDocument();
            XmlElement root;
            root = myXml.CreateRootElement(doc, "Setting", "1.0");

            XmlElement e = myXml.AddXmlNode(doc, root, "�Ƿ����õ������뵥", "");
            myXml.AddNodeAttibute(e, "IsUsePacsApply", isUsePacsApply);

            try
            {
                StreamWriter sr = new StreamWriter(fileName, false, System.Text.Encoding.Default);
                string cleandown = doc.OuterXml;
                sr.Write(cleandown);
                sr.Close();
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show("�޷����棡" + ex.Message); }

            return 1;
        }

        /// <summary>
        /// �˵�����
        /// <returns></returns>
        /// </summary>
        public static bool LoadMenuSet()
        {
            try
            {
                bool isUsePACSApplySheet = false;
                if (!System.IO.File.Exists(Application.StartupPath + "/Setting/PacsApplySetting.xml"))
                {
                    Neusoft.HISFC.Components.Common.Classes.Function.CreateXML(Application.StartupPath + "/Setting/PacsApplySetting.xml", "0");
                }
                //�Ƿ��ӳ�����ʱ�� �кŵı�������
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + "/Setting/PacsApplySetting.xml");
                XmlNode node = doc.SelectSingleNode("//�Ƿ����õ������뵥");

                if (node != null)
                {
                    isUsePACSApplySheet = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["IsUsePacsApply"].Value);
                }
                return isUsePACSApplySheet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ʾ");
                return false;
            }
        }
        #endregion

    }
}