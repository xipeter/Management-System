using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// Company<br></br>
    /// [功能描述: 文件信息基类]<br></br>
    /// [创 建 者: 朱庆元]<br></br>
    /// [创建时间: 2007-10-22]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class MainFile : Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
        /// 构造函数

        /// </summary>
        public MainFile()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 卡片流水号

        /// </summary>
        private string seqNo;

        /// <summary>
        /// 序号
        /// </summary>
        private int fileSerialCode;
        
        /// <summary>
        /// 设备信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject equInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 设备科室信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject deptInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 文件类型1电子文档2图片3无文件

        /// </summary>
        private string fileType;
        
        /// <summary>
        /// 文件附件
        /// </summary>
        private byte[] fileAnnex;

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;

        /// <summary>
        /// 操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 文件路径
        /// </summary>
        private string imageFilePath;

        #endregion

        #region 属性


        /// <summary>
        /// 卡片流水号

        /// </summary>
        public string SeqNo
        {
            get { return seqNo; }
            set { seqNo = value; }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public int FileSerialCode
        {
            get { return fileSerialCode; }
            set { fileSerialCode = value; }
        }

        /// <summary>
        /// 设备信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject EquInfo
        {
            get { return equInfo; }
            set { equInfo = value; }
        }

        /// <summary>
        /// 设备科室信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject DeptInfo
        {
            get { return deptInfo; }
            set { deptInfo = value; }
        }

        /// <summary>
        /// 文件类型1电子文档2图片3无文件

        /// </summary>
        public string FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }
    
        /// <summary>
        /// 文件附件
        /// </summary>
        public byte[] FileAnnex
        {
            get { return fileAnnex; }
            set { fileAnnex = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperInfo
        {
            get { return operInfo; }
            set { operInfo = value; }
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string ImageFilePath
        {
            get { return imageFilePath; }
            set { imageFilePath = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new MainFile Clone()
        {
            MainFile mainFileInfo = base.Clone() as MainFile;

            mainFileInfo.equInfo = this.equInfo.Clone();
            mainFileInfo.deptInfo = this.deptInfo.Clone();
            mainFileInfo.operInfo = this.operInfo.Clone();

            return mainFileInfo;
        }

        #endregion
    }
}

