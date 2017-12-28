using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Operation;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 手术间维护]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-18]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class frmOperationRoom : Form
    {
        public frmOperationRoom()
        {
            InitializeComponent();
            this.cmbValid.SelectedIndex = 0;
            this.txtDept.Text = Environment.OperatorDept.Name;
        }

#region 字段
        private bool isNew;
        private OpsRoom room = new OpsRoom();
#endregion

        #region 属性


        public OpsRoom Room
        {
            get
            {
                return this.room;
            }
            set
            {
                this.room = value;
                this.txtID.Text = room.ID;
                this.txtName.Text = room.Name;
                this.txtInputCode.Text = room.InputCode;
                if (room.IsValid)
                    this.cmbValid.SelectedIndex = 0;
                else
                    this.cmbValid.SelectedIndex = 1;
            }
        }

        public bool IsNew
        {
            get
            {
                return this.isNew;
            }
            set
            {
                this.isNew = value;
                if(this.isNew)
                {
                    this.Reset();
                }
                this.room.ID = Environment.TableManager.GetNewRoomID();
                this.txtID.Text = this.room.ID;
            }
        }


       #endregion

#region 方法
        private bool IsValid()
        {
            string text = this.txtName.Text.Trim();
            if (text == "")
            {
                MessageBox.Show("房间名称不能为空!", "提示");
                return false;
            }

            return true;
        }

        private new void Update()
        {
            this.room.ID = this.txtID.Text;
            this.room.Name = this.txtName.Text;
            this.room.InputCode = this.txtInputCode.Text;
            this.room.IsValid = this.cmbValid.SelectedIndex == 0 ? true : false;
            this.room.DeptID = Environment.OperatorDeptID;
            
        }

        private void Reset()
        {
            this.txtID.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtInputCode.Text = string.Empty;
            this.cmbValid.SelectedIndex = 0;

            this.room.ID = string.Empty;
            this.room.Name = string.Empty;
            this.room.InputCode = string.Empty;
            this.room.IsValid = true;
        }
#endregion
        private void neuLabelTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.IsValid())
            {
                this.Update();

                int ret;

                if(this.isNew)
                {
                    ret=Environment.TableManager.AddOpsRoom(this.room);
                    if (ret == -1)
                    {
                        MessageBox.Show("插入手术间信息表出差!" + Environment.TableManager.Err, "提示");
                    }
                }else
                {
                    ret = Environment.TableManager.UpdateOpsRoom(this.room);
                    if (ret == -1)
                    {
                        MessageBox.Show("更新手术间信息表出差!" + Environment.TableManager.Err, "提示");
                    }
                }

                
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}