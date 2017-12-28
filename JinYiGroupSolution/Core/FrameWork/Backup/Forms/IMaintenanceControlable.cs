using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Neusoft.FrameWork.WinForms.Forms
{
    /// <summary>
    /// [功能描述: 基本查询控件接口]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-10-31]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public interface IMaintenanceControlable
    {
        /// <summary>
        /// 查询窗体按口
        /// </summary>
        IMaintenanceForm QueryForm
        {
            get;
            set;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        int Init();
        /// <summary>
        /// 查询记录
        /// </summary>
        /// <returns></returns>
        int Query();
        /// <summary>
        /// 增加记录
        /// </summary>
        /// <returns></returns>
        int Add();
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        int Delete();
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <returns></returns>
        int Modify();
        /// <summary>
        /// 保存记录
        /// </summary>
        /// <returns>0 成功，-1 失败</returns>
        int Save();
        /// <summary>
        /// 导入
        /// </summary>
        /// <returns></returns>
        int Import();
        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        int Export();
        /// <summary>
        /// 打印
        /// </summary>
        /// <returns></returns>
        int Print();
        /// <summary>
        /// 打印预览
        /// </summary>
        /// <returns></returns>
        int PrintPreview();
        /// <summary>
        /// 打印设置
        /// </summary>
        /// <returns></returns>
        int PrintConfig();
        /// <summary>
        /// 剪切
        /// </summary>
        /// <returns></returns>
        int Cut();
        /// <summary>
        /// 拷贝
        /// </summary>
        /// <returns></returns>
        int Copy();
        /// <summary>
        /// 粘贴
        /// </summary>
        /// <returns></returns>
        int Paste();
        /// <summary>
        /// 下一条
        /// </summary>
        /// <returns></returns>
        int NextRow();
        /// <summary>
        /// 上一条
        /// </summary>
        /// <returns></returns>
        int PreRow();
        /// <summary>
        /// 是否修改过，但未保存
        /// </summary>        
        bool IsDirty
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 维护控件经常使用的一个类
    /// </summary>
    public class XmlUtil
    {
        public static XmlAttribute GetXmlAttribute(XmlNode node, string name)
        {
            foreach (XmlAttribute attribute in node.Attributes)
            {
                if (attribute.Name == name)
                {
                    return attribute;
                }
            }

            return null;
        }
    };
}
