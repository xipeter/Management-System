namespace Neusoft.HISFC.WinForms.DrugStore
{
    partial class ucOutpatientDrug
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Neusoft.FrameWork.Models.NeuObject neuObject1 = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject neuObject2 = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject neuObject3 = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject neuObject4 = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject neuObject5 = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject neuObject6 = new Neusoft.FrameWork.Models.NeuObject();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucClinicTree1 = new Neusoft.HISFC.Components.DrugStore.Outpatient.ucClinicTree();
            this.ucClinicDrug1 = new Neusoft.HISFC.Components.DrugStore.Outpatient.ucClinicDrug();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucClinicTree1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucClinicDrug1);
            this.splitContainer1.Size = new System.Drawing.Size(749, 449);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // ucClinicTree1
            // 
            neuObject1.ID = "";
            neuObject1.Memo = "";
            neuObject1.Name = "";
            this.ucClinicTree1.ApproveDept = neuObject1;
            this.ucClinicTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucClinicTree1.IsShowFeeData = true;
            this.ucClinicTree1.Location = new System.Drawing.Point(0, 0);
            this.ucClinicTree1.Name = "ucClinicTree1";
            neuObject2.ID = "";
            neuObject2.Memo = "";
            neuObject2.Name = "";
            this.ucClinicTree1.OperDept = neuObject2;
            neuObject3.ID = "";
            neuObject3.Memo = "";
            neuObject3.Name = "";
            this.ucClinicTree1.OperInfo = neuObject3;
            this.ucClinicTree1.Size = new System.Drawing.Size(170, 449);
            this.ucClinicTree1.TabIndex = 0;
            // 
            // ucClinicDrug1
            // 
            neuObject4.ID = "";
            neuObject4.Memo = "";
            neuObject4.Name = "";
            this.ucClinicDrug1.ApproveDept = neuObject4;
            this.ucClinicDrug1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucClinicDrug1.Location = new System.Drawing.Point(0, 0);
            this.ucClinicDrug1.Name = "ucClinicDrug1";
            neuObject5.ID = "";
            neuObject5.Memo = "";
            neuObject5.Name = "";
            this.ucClinicDrug1.OperDept = neuObject5;
            neuObject6.ID = "";
            neuObject6.Memo = "";
            neuObject6.Name = "";
            this.ucClinicDrug1.OperInfo = neuObject6;
            this.ucClinicDrug1.Size = new System.Drawing.Size(577, 449);
            this.ucClinicDrug1.TabIndex = 0;
            // 
            // ucOutpatientDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucOutpatientDrug";
            this.Size = new System.Drawing.Size(749, 449);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.HISFC.Components.DrugStore.Outpatient.ucClinicTree ucClinicTree1;
        private Neusoft.HISFC.Components.DrugStore.Outpatient.ucClinicDrug ucClinicDrug1;

    }
}
