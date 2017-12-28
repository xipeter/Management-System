using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.ComponentModel;
using Neusoft.FrameWork.Models;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 科室人员列表]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-26]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class ListViewEmployee : Neusoft.FrameWork.WinForms.Controls.NeuListView
    {

        public ListViewEmployee()
        {
            this.imageList.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.R人员));
            this.LargeImageList = this.imageList;
            this.SmallImageList = this.imageList;
            this.StateImageList = this.imageList;
        }
#region 字段
        private string deptID;
        private ImageList imageList = new ImageList();
#endregion

#region 属性
        /// <summary>
        /// 科室编码
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DeptID
        {
            get
            {
                return this.deptID;
            }

            set
            {
                this.deptID = value;
                this.LoadData(value);
            }
        }
#endregion


#region 方法


        #region donggq--2010.10.05--{DFFAAA32-367B-496b-B08E-9BB19925E795}

        private void LoadData()
        {
            ArrayList al = Environment.IntegrateManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D, "2600");
            al.AddRange(Environment.IntegrateManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D, "2603"));

            foreach (NeuObject obj in al)
            {
                ListViewItem item = new ListViewItem();
                item.Text = obj.Name;
                item.ImageIndex = 0;
                item.Tag = obj;
                this.Items.Add(item);
            }
        } 

        #endregion

        private void LoadData(string deptID)
        {
            ArrayList al = Environment.IntegrateManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D, deptID);
            foreach(NeuObject obj in al)
            {
                ListViewItem item = new ListViewItem();
                item.Text = obj.Name;
                item.ImageIndex = 0;
                item.Tag = obj;
                this.Items.Add(item);
            }
        }

        public void Refresh()
        {
            this.Items.Clear();


            #region donggq--2010.10.05--{DFFAAA32-367B-496b-B08E-9BB19925E795}


            //this.LoadData(this.deptID);

            this.LoadData();

            #endregion
        }

        /// <summary>
        /// 移除人员
        /// </summary>
        /// <param name="id">人员ID</param>
        /// <returns></returns>
        public int RemoveEmployee(string id)
        {
            foreach(ListViewItem item in this.Items)
            {
                if((item.Tag as NeuObject).ID==id)
                {
                    this.Items.Remove(item);
                    return 0;
                }
            }

            return -1;
        }
#endregion
    }
}
