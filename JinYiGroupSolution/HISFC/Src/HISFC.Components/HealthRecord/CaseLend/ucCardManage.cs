using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.HealthRecord.CaseLend
{
    /// <summary>
    /// ucCardManage<br></br>
    /// [功能描述: 病案借阅卡信息录入]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-04-20]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucCardManage : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCardManage()
        {
            InitializeComponent();
        }

        #region 全局变量
        private Neusoft.HISFC.BizLogic.HealthRecord.CaseCard card = new Neusoft.HISFC.BizLogic.HealthRecord.CaseCard();
        private System.Data.DataSet ds = new System.Data.DataSet();
        private frmCaseCard frm = new frmCaseCard(); //借阅卡维护界面
        #endregion

        #region 工具栏增加按钮单击事件

        /// <summary>
        /// 工具栏增加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加":
                    this.AddInfo();
                    break;
                case "修改":
                    this.ModifyInfo();
                    break;　
                default:
                    break;
            }
        }
        #endregion

        #region 初始化工具栏
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加", "增加", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("修改", "修改", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新, true, false, null);
            //toolBarService.AddToolButton("删除", "删除", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            //toolBarService.AddToolButton("打印", "打印", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, true, false, null);
            return toolBarService;
        }
        #endregion

        private void frmCardManage_Load(object sender, System.EventArgs e)
        {
            if (card.GetCardInfo(ref ds) != -1)
            {
                this.fpSpread1_Sheet1.DataSource = ds;
            }
            LockFp();
            Neusoft.HISFC.BizLogic.Manager.Person person = new Neusoft.HISFC.BizLogic.Manager.Person();
            //获取人员列表
            ArrayList DoctorList = person.GetEmployeeAll();
            frm.SetPersonList(DoctorList);

            Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
            //获取部门列表
            ArrayList deptList = dept.GetInHosDepartment();
            frm.SetDeptList(deptList);
            frm.SaveHandle +=new frmCaseCard.SaveInfo(frm_SaveHandle);
        }
        /// <summary>
        /// 锁定 单元格的宽度 
        /// </summary>
        private void LockFp()
        {
            this.fpSpread1_Sheet1.Columns[0].Width = 80;
            //{19AB39F1-B0A0-4d74-A4BF-DB026DE9E832} 病案借阅修改
            this.fpSpread1_Sheet1.Columns[0].Visible = false;
            this.fpSpread1_Sheet1.Columns[1].Width = 80;
            this.fpSpread1_Sheet1.Columns[2].Width = 80;
            this.fpSpread1_Sheet1.Columns[3].Width = 80;
            this.fpSpread1_Sheet1.Columns[4].Width = 80;
            this.fpSpread1_Sheet1.Columns[5].Width = 80;
            this.fpSpread1_Sheet1.Columns[6].Width = 80;
            this.fpSpread1_Sheet1.Columns[7].Width = 80;
            this.fpSpread1_Sheet1.Columns[8].Width = 50;
            this.fpSpread1_Sheet1.Columns[9].Width = 80;
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
        }

        /// <summary>
        /// 增加 
        /// </summary>
        private void AddInfo()
        {
            frm.ClearInfo();
            frm.EditType = Neusoft.HISFC.Models.HealthRecord.EnumServer.EditTypes.Add;
            frm.Text = "增加";
            frm.Visible = true;
        }
        /// <summary>
        /// 修改 
        /// </summary>
        private void ModifyInfo()
        {
            if (this.fpSpread1_Sheet1.Rows.Count == 0)
            {
                return;
            }
            string str = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 0].Text;
            Neusoft.HISFC.Models.HealthRecord.ReadCard info = card.GetCardInfo(str);
            if (info.CardID == null || info.CardID == "")
            {
                MessageBox.Show("查询数据库失败");
                return;
            }
            frm.EditType = Neusoft.HISFC.Models.HealthRecord.EnumServer.EditTypes.Modify;
            frm.SetInfo(info);
            frm.Text = "修改";
            frm.Visible = true;
        }
        /// <summary>
        /// 删除 
        /// </summary>
        private void delete()
        {
            if (this.fpSpread1_Sheet1.Rows.Count == 0)
            {
                MessageBox.Show("没有可删除的数据");
                return;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void frm_SaveHandle(Neusoft.HISFC.Models.HealthRecord.ReadCard obj)
        {
            if (frm.EditType == Neusoft.HISFC.Models.HealthRecord.EnumServer.EditTypes.Add)
            {

                int i = this.fpSpread1_Sheet1.Rows.Count;
                this.fpSpread1_Sheet1.Rows.Add(i, 1);
                this.fpSpread1_Sheet1.Cells[i, 0].Text = obj.CardID; //卡号
                this.fpSpread1_Sheet1.Cells[i, 1].Text = obj.EmployeeInfo.ID; //员工号
                this.fpSpread1_Sheet1.Cells[i, 2].Text = obj.EmployeeInfo.Name;//员工姓名
                this.fpSpread1_Sheet1.Cells[i, 3].Text = obj.DeptInfo.ID;//科室代码
                this.fpSpread1_Sheet1.Cells[i, 4].Text = obj.DeptInfo.Name;//科室名称
                this.fpSpread1_Sheet1.Cells[i, 5].Text = obj.User01;//操作员
                this.fpSpread1_Sheet1.Cells[i, 6].Text = obj.EmployeeInfo.OperTime.ToString();//操作时间
                if (obj.ValidFlag == "1")
                {
                    this.fpSpread1_Sheet1.Cells[i, 7].Text = "有效";//有效
                }
                else
                {
                    this.fpSpread1_Sheet1.Cells[i, 7].Text = "无效";//有效
                }
                this.fpSpread1_Sheet1.Cells[i, 8].Text = obj.CancelOperInfo.Name;//作废人
                this.fpSpread1_Sheet1.Cells[i, 9].Text = obj.CancelDate.ToString();//作废时间
            }
            else
            {
                int i = fpSpread1_Sheet1.ActiveRowIndex;
                this.fpSpread1_Sheet1.Cells[i, 0].Text = obj.CardID; //卡号
                this.fpSpread1_Sheet1.Cells[i, 1].Text = obj.EmployeeInfo.ID; //员工号
                this.fpSpread1_Sheet1.Cells[i, 2].Text = obj.EmployeeInfo.Name;//员工姓名
                this.fpSpread1_Sheet1.Cells[i, 3].Text = obj.DeptInfo.ID;//科室代码
                this.fpSpread1_Sheet1.Cells[i, 4].Text = obj.DeptInfo.Name;//科室名称
                this.fpSpread1_Sheet1.Cells[i, 5].Text = obj.User01;//操作员
                this.fpSpread1_Sheet1.Cells[i, 6].Text = obj.EmployeeInfo.OperTime.ToString();//操作时间
                if (obj.ValidFlag == "1")
                {
                    this.fpSpread1_Sheet1.Cells[i, 7].Text = "有效";//有效
                }
                else
                {
                    this.fpSpread1_Sheet1.Cells[i, 7].Text = "无效";//有效
                }
                this.fpSpread1_Sheet1.Cells[i, 8].Text = obj.CancelOperInfo.Name;//作废人
                this.fpSpread1_Sheet1.Cells[i, 9].Text = obj.CancelDate.ToString();//作废时间
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        private void PrintInfo()
        {
            try
            {

                Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
                p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
                p.PrintPreview(panel2);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (keyData.GetHashCode() == Keys.F1.GetHashCode())
            //{
            //    this.AddInfo();
            //}
            //else if (keyData.GetHashCode() == Keys.F2.GetHashCode())
            //{
            //    this.ModifyInfo();
            //}
            //else if (keyData.GetHashCode() == Keys.F9.GetHashCode())
            //{
            //    this.PrintInfo();
            //}
            return base.ProcessDialogKey(keyData);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            this.PrintInfo();
            return base.OnPrint(sender, neuObject);
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //			this.ModifyInfo();
        }

    }
}