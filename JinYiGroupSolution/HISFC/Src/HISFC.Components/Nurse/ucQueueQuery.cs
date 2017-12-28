using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Nurse
{
    /// <summary>
    /// 分诊队列查询
    /// </summary>
    internal partial class ucQueueQuery : UserControl
    {
        public ucQueueQuery()
        {
            InitializeComponent();
        }

        public ucQueueQuery(Neusoft.FrameWork.Models.NeuObject obj)
            : this()
        {
            if (obj == null) return;
            this.btnRefresh.Tag = obj;
        }

        #region 属性

        private Neusoft.FrameWork.Models.NeuObject objNurse = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ObjNurse
        {
            get
            {
                return this.objNurse;
            }
            set
            {
                this.objNurse = value;
            }
        }

        private ArrayList queueInfo = new ArrayList();

        /// <summary>
        /// 
        /// </summary>
        public ArrayList QueueInfo
        {
            get
            {
                return this.queueInfo;
            }
            set
            {
                this.queueInfo = value;
            }
        }

        #endregion

        #region  定义域

        private Neusoft.HISFC.BizLogic.Nurse.Queue myQueue = new Neusoft.HISFC.BizLogic.Nurse.Queue();

        private Hashtable htNoon = new Hashtable();
        private Hashtable htDoct = new Hashtable();

        public delegate void RefQueue(ArrayList alQueue);
        public event RefQueue RefList;

        private Neusoft.HISFC.BizProcess.Integrate.Registration.Registration  myMgr = null;
        private Neusoft.HISFC.BizProcess.Integrate.Manager personMgr = null;

        #endregion


        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="person"></param>
        private void RefreshList(Neusoft.FrameWork.Models.NeuObject nurse)
        {
            try
            {
                if (this.neuSpread1_Sheet1.RowCount > 0)
                    this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.RowCount);

                //检索病区的维护信息
                this.QueueInfo = this.myQueue.Query(nurse.ID, this.dtDate.Value.ToShortDateString());

                this.neuSpread1_Sheet1.Tag = nurse;

                if (QueueInfo != null)
                {
                    foreach (Neusoft.HISFC.Models.Nurse.Queue obj in QueueInfo)
                    {
                        this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.RowCount, 1);
                        int row = this.neuSpread1_Sheet1.RowCount - 1;
                        this.neuSpread1_Sheet1.Rows[row].Tag = obj;

                        //队列名称
                        this.neuSpread1_Sheet1.SetValue(row, 0, obj.Name, false);
                        //午别
                        obj.Noon.Name = this.GetNoonNameByID(obj.Noon.ID);
                        this.neuSpread1_Sheet1.SetValue(row, 1, obj.Noon.Name, false);
                        //显示顺序
                        this.neuSpread1_Sheet1.SetValue(row, 2, obj.Order, false);
                        //是否有效
                        this.neuSpread1_Sheet1.SetValue(row, 3, obj.IsValid ? "有效" : "无效", false);
                        //队列日期
                        this.neuSpread1_Sheet1.SetValue(row, 4, obj.QueueDate, false);
                        //看诊医生
                        obj.Doctor.Name = this.GetDoctNameByID(obj.Doctor.ID);
                        this.neuSpread1_Sheet1.SetValue(row, 5, obj.Doctor.Name, false);
                        //诊室
                        this.neuSpread1_Sheet1.SetValue(row, 6, obj.SRoom.Name, false);
                        //备注
                        this.neuSpread1_Sheet1.SetValue(row, 7, obj.Memo, false);
                        //操作员
                        this.neuSpread1_Sheet1.SetValue(row, 8, obj.Oper.ID, false);
                        //操作时间
                        this.neuSpread1_Sheet1.SetValue(row, 9, this.myQueue.GetDateTimeFromSysDateTime(), false);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + this.myQueue.Err);
            }
        }
        private void GetQueue()
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                if (this.neuSpread1_Sheet1.Rows[i].Tag == null)
                    return;
                Neusoft.HISFC.Models.Nurse.Queue obj = new Neusoft.HISFC.Models.Nurse.Queue();
                obj = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Nurse.Queue;
                this.QueueInfo.Add(obj);
            }
        }

        private void Init()
        {
            ArrayList al = new ArrayList();
            if (this.myMgr == null) this.myMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
            al = this.myMgr.Query();
            foreach (Neusoft.HISFC.Models.Registration.Noon noon in al)
            {
                this.htNoon.Add(noon.ID, noon.Name);
            }

            if (this.personMgr == null) this.personMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            //得到医生列表
            al = new ArrayList();
            al = this.personMgr.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            foreach (Neusoft.HISFC.Models.Base.Employee person in al)
            {
                this.htDoct.Add(person.ID, person.Name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string GetNoonNameByID(string ID)
        {
            IDictionaryEnumerator dict = this.htNoon.GetEnumerator();
            while (dict.MoveNext())
            {
                if (dict.Key.ToString() == ID)
                    return dict.Value.ToString();
            }
            return ID;
        }

        private string GetDoctNameByID(string ID)
        {
            IDictionaryEnumerator dict = this.htDoct.GetEnumerator();
            while (dict.MoveNext())
            {
                if (dict.Key.ToString() == ID)
                    return dict.Value.ToString();
            }
            return ID;
        }

        private void ucQueueQuery_Load(object sender, EventArgs e)
        {
            this.Init();
            this.FindForm().Text = "模板";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.btnRefresh.Tag == null)
                return;
            this.ObjNurse = this.btnRefresh.Tag as Neusoft.FrameWork.Models.NeuObject;
            this.RefreshList(ObjNurse);
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.RefList(this.QueueInfo);
            this.FindForm().Close();
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

    }
}
