using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.HealthRecord.Visit
{
    /// <summary>
    /// LinkWay <br></br>
    /// [功能描述: 联系方式记录]<br></br>
    /// [创 建 者: 赫一阳]<br></br>
    /// [创建时间: 2007-08-16]<br></br>
    /// <修改记录
    ///		修改人='金鹤'
    ///		修改时间='20090819'
    ///		修改目的='增加==运算符重载'
    ///		修改描述='
    /// {E9F858A6-BDBC-4052-BA57-68755055FB80}
    /// 更新数据前先判断对象是否被修改，只更新数据库中修改的记录，避免多次Update未修改的数据
    /// '
    ///  />
    /// </summary>
    [Serializable]
    public class LinkWay : Case.CaseInfo
    {
        #region 变量

        /// <summary>
        /// 联系方式类别
        /// </summary>
        private HISFC.Models.Base.Const linkWayType = new Neusoft.HISFC.Models.Base.Const();
        
        /// <summary>
        /// 联系方式内容
        /// </summary>
        [Obsolete ("废弃  选择对应的联系方式字段存")]
        private string linkWay = "";

        /// <summary>
        /// 邮政编码
        /// </summary>
        private string zip = "";
        
        /// <summary>
        /// 是否是联系人的联系方式
        /// </summary>
        private bool isLinkMan;
        
        /// <summary>
        /// 联系人
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject linkMan = new Neusoft.FrameWork.Models.NeuObject();
        
        /// <summary>
        /// 联系人与患者的关系
        /// </summary>
        private HISFC.Models.Base.Const relation = new Neusoft.HISFC.Models.Base.Const();

        #region 2007-10-25 ADD BY WANGLI

        /// <summary>
        /// 地址
        /// </summary>
        private string address = "";

        /// <summary>
        /// 电话
        /// </summary>
        private string phone = "";

        /// <summary>
        /// 邮件
        /// </summary>
        private string mail = "";

        /// <summary>
        /// 其它
        /// </summary>
        private string otherLinkway = "";

        #endregion

        /// <summary>
        /// 创建或修改的环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operEnvi = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性
        /// <summary>
        /// 联系方式类别
        /// </summary>
        public HISFC.Models.Base.Const LinkWayType
        {
            get
            {
                return this.linkWayType;
            }
            set
            {
                this.linkWayType = value;
            }
        }

        /// <summary>
        /// 联系方式内容
        /// </summary>
        [Obsolete("废弃  选择对应的联系方式字段存",true)]
        public string LinkWayContent
        {
            get
            {
                return this.linkWay;
            }
            set
            {
                this.linkWay = value;
            }
        }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZIP
        {
            get
            {
                return this.zip;
            }
            set
            {
                this.zip = value;
            }
        }

        /// <summary>
        /// 是否是联系人的联系方式
        /// </summary>
        public bool IsLinkMan
        {
            get
            {
                return this.isLinkMan;
            }
            set
            {
                this.isLinkMan = value;
            }
        }

        /// <summary>
        /// 联系人
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject LinkMan
        {
            get
            {
                return this.linkMan;
            }
            set
            {
                this.linkMan = value;
            }
        }

        /// <summary>
        /// 联系人与患者的关系
        /// </summary>
        public HISFC.Models.Base.Const Relation
        {
            get
            {
                return this.relation;
            }
            set
            {
                this.relation = value;
            }
        }

        /// <summary>
        /// 创建或修改的环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperEnvi
        {
            get
            {
                return this.operEnvi;
            }
            set
            {
                this.operEnvi = value;
            }
        }

        #region 2007-10-25 ADD BY WANGLI

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        /// <summary>
        /// 邮件
        /// </summary>
        public string Mail
        {
            get
            {
                return this.mail;
            }
            set
            {
                this.mail = value;
            }
        }

        /// <summary>
        /// 其它
        /// </summary>
        public string OtherLinkway
        {
            get
            {
                return this.otherLinkway;
            }
            set
            {
                this.otherLinkway = value;
            }
        }

        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>联系方式</returns>
        public new LinkWay Clone()
        {
            LinkWay linkWay = base.Clone() as LinkWay;

            linkWay.LinkWayType = this.LinkWayType.Clone();
            linkWay.LinkMan = this.LinkMan.Clone();
            linkWay.Relation = this.Relation.Clone();
            linkWay.OperEnvi = this.OperEnvi.Clone();
            //linkWay.ZIP = this.ZIP.Clone();

            return linkWay;
        }

        #region {E9F858A6-BDBC-4052-BA57-68755055FB80}
        
        

        /// <summary>
        /// ==运算符重载
        /// </summary>
        /// <param name="linkWay1"></param>
        /// <param name="linkWay2"></param>
        /// <returns></returns>
        public static bool operator ==(LinkWay linkWay1, LinkWay linkWay2)
        {

            if((object)linkWay1!=null&&(object)linkWay2!=null)
            {
                return linkWay1.Equals(linkWay2);
            }

            return object.Equals(linkWay1, linkWay2); 
                
        }
        /// <summary>
        /// !=运算符重载
        /// </summary>
        /// <param name="linkWay1"></param>
        /// <param name="linkWay2"></param>
        /// <returns></returns>
        public static bool operator !=(LinkWay linkWay1, LinkWay linkWay2)
        {
            return !(linkWay1 == linkWay2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return (
                this.Name == ((LinkWay)obj).Name
                && this.Memo == ((LinkWay)obj).Memo
                && this.Phone == ((LinkWay)obj).Phone
                && this.User01 == ((LinkWay)obj).User01
                && this.Address == ((LinkWay)obj).Address
                && this.Mail == ((LinkWay)obj).Mail
                );
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        } 

        #endregion

        #endregion
    }
}
