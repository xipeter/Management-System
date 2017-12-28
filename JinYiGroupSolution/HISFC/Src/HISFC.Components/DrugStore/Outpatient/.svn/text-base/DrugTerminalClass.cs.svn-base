using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;
using Neusoft.HISFC.Object.Pharmacy;

namespace Neusoft.UFC.DrugStore.Outpatient
{
    [DefaultPropertyAttribute( "名称" )]
    public class DrugTerminalClass
    {

        #region 构造函数

        /// <summary>
        /// 不带参数的构造函数
        /// </summary>
        public DrugTerminalClass( )
        {
        }
        /// <summary>
        /// 带参数的构造函数
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="terminalType">终端类型</param>
        public DrugTerminalClass( string deptCode , string terminalType )
        {
            //获取终端列表
            Neusoft.HISFC.Management.Pharmacy.DrugStore drugStore = new Neusoft.HISFC.Management.Pharmacy.DrugStore( );
            ArrayList al = drugStore.QueryDrugTerminalByDeptCode( deptCode , terminalType );
            string[ ] temp = new string[ al.Count + 1 ];

            temp[ 0 ] = "无替代";

            for( int i = 1 ; i < al.Count ; i++ )
            {
                Neusoft.HISFC.Object.Pharmacy.DrugTerminal info = al[ i ] as Neusoft.HISFC.Object.Pharmacy.DrugTerminal;
                temp[ i ] = "<" + info.ID + ">" + info.Name;
            }

            ReplaceConverter.EnumString = temp;

            //获取发药窗口列表
            ArrayList tempAl = drugStore.QueryDrugTerminalByDeptCode( deptCode , "0" );
            string[ ] tempStr = new string[ tempAl.Count ];

            for( int i = 0 ; i < tempAl.Count ; i++ )
            {
                Neusoft.HISFC.Object.Pharmacy.DrugTerminal info = tempAl[ i ] as Neusoft.HISFC.Object.Pharmacy.DrugTerminal;
                tempStr[ i ] = "<" + info.ID + ">" + info.Name;
            }

            SendWindowConverter.EnumString = tempStr;

        }

        #endregion

        #region 变量

        private string name = ""; //终端名称
        private EnumTerminalType enumType = EnumTerminalType.发药窗口; //终端类型
        private EnumTerminalProperty enumProperty = EnumTerminalProperty.普通; //终端性质
        private string replaceName = "";					//替代终端
        private string isClose = "否";						//是否关闭
        private string isAutoPrint = "是";					//是否自动打印
        private decimal refreshInterval1 = 10;				//程序刷新间隔
        private decimal refreshInterval2 = 10;				//打印/显示 刷新间隔
        private int alertNum = 25;						    //警戒线
        private int showNum = 5;						    //显示人数
        private string sendWindow = "";					    //发药窗口(只用于配药台)
        private string mark = "";						    //备注

        #endregion

        #region 属性

        [CategoryAttribute( "基本信息" ) , DescriptionAttribute( "配药台/发药窗口名称" )]
        public string 名称
        {
            get { return name; }
            set { name = value; }
        }

        [CategoryAttribute( "基本信息" ) ,
        DescriptionAttribute( "终端类别 发药窗口/配药台" ) ,
        ReadOnlyAttribute( true )]
        public EnumTerminalType 类别
        {
            get { return enumType; }
            set { enumType = value; }
        }


        [CategoryAttribute( "基本信息" ) ,
        DescriptionAttribute( "终端性质 普通、特殊、专科" ) ,
        DefaultValueAttribute( EnumTerminalProperty.普通 )]
        public EnumTerminalProperty 性质
        {
            get { return enumProperty; }
            set { enumProperty = value; }
        }


        [CategoryAttribute( "使用信息" ) ,
        DescriptionAttribute( "该终端关闭时的替代终端" ) ,
        TypeConverter( typeof( ReplaceConverter ) )
        ]
        public string 替代终端
        {
            get { return replaceName; }
            set { replaceName = value; }
        }


        [CategoryAttribute( "使用信息" ) ,
        DescriptionAttribute( "是否启用该终端" ) ,
        DefaultValueAttribute( "否" ) ,
        TypeConverter( typeof( IsTure ) )
        ]
        public string 是否关闭
        {
            get { return isClose; }
            set { isClose = value; }
        }


        [CategoryAttribute( "使用信息" ) ,
        DescriptionAttribute( "在配药台配药时是否自动打印配药标签,对发药窗口该参数无意义" ) ,
        DefaultValueAttribute( "是" ) ,
        TypeConverter( typeof( IsTure ) )
        ]
        public string 是否自动打印
        {
            get { return isAutoPrint; }
            set { isAutoPrint = value; }
        }


        [CategoryAttribute( "使用信息" ) ,
        DescriptionAttribute( "在电脑界面刷新患者列表的时间间隔 对配药台为标签打印间隔 " ) ,
        DefaultValueAttribute( 10.0 )]
        public decimal 程序刷新间隔
        {
            get { return refreshInterval1; }
            set { refreshInterval1 = value; }
        }


        [CategoryAttribute( "使用信息" ) ,
        DescriptionAttribute( "对发药窗口为大屏幕刷新患者列表时间间隔" ) ,
        DefaultValueAttribute( 10.0 )]
        public decimal 显示刷新间隔
        {
            get { return refreshInterval2; }
            set { refreshInterval2 = value; }
        }


        [CategoryAttribute( "使用信息" ) ,
        DescriptionAttribute( "对配药台为发送至该配药台的待配药处方数警戒值 对发药窗口为待取药患者的警戒值" ) ,
        DefaultValueAttribute( 25 )]
        public int 警戒线
        {
            get { return alertNum; }
            set { alertNum = value; }
        }


        [CategoryAttribute( "使用信息" ) ,
        DescriptionAttribute( "每次大屏幕刷新显示的患者人数" ) ,
        DefaultValueAttribute( 5 )]
        public int 显示人数
        {
            get { return showNum; }
            set { showNum = value; }
        }


        [CategoryAttribute( "杂项" ) ,
        DescriptionAttribute( "配药台对应的发药窗口、对发药窗口该参数无意义" ) ,
        TypeConverter( typeof( SendWindowConverter ) )
        ]
        public string 发药窗口
        {
            get { return sendWindow; }
            set { sendWindow = value; }
        }


        [CategoryAttribute( "杂项" ) ,
        DescriptionAttribute( "补充说明" )]
        public string 备注
        {
            get { return mark; }
            set { mark = value; }
        }


        #endregion


    }

    /// <summary>
    /// 重写基类、实现对是否列表选择
    /// </summary>
    public class IsTure : StringConverter
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public IsTure( )
        {
        }

        private static string[ ] str = { "是" , "否" };
        public static string[ ] EnumString
        {
            get { return str; }
            set { str = value; }
        }

        /// <summary>
        /// 设定该对象支持从列表中选择一组标准值
        /// </summary>
        /// <param name="context">要获取值的组件</param>
        /// <returns>返回True</returns>
        public override bool GetStandardValuesSupported( ITypeDescriptorContext context )
        {
            return true;
        }


        /// <summary>
        /// 填充下拉列表的数据
        /// </summary>
        /// <param name="context">要获取值的组件</param>
        /// <returns></returns>
        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues( ITypeDescriptorContext context )
        {
            return new StandardValuesCollection( EnumString );
        }


        /// <summary>
        /// 操作员是否不允许键入下拉表内不存在的值
        /// </summary>
        /// <param name="context">要获取值的组件</param>
        /// <returns></returns>
        public override bool GetStandardValuesExclusive(  ITypeDescriptorContext context )
        {
            return true;
        }

    }


    /// <summary>
    /// 重写基类、实现对替代终端显示列表选择
    /// </summary>
    public class ReplaceConverter : StringConverter
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ReplaceConverter( )
        {
        }

        private static string[ ] str = { };
        public static string[ ] EnumString
        {
            get { return str; }
            set { str = value; }
        }


        /// <summary>
        /// 设定该对象支持从列表中选择一组标准值
        /// </summary>
        /// <param name="context">要获取值的组件</param>
        /// <returns>返回True</returns>
        public override bool GetStandardValuesSupported( ITypeDescriptorContext context )
        {
            return true;
        }


        /// <summary>
        /// 填充下拉列表的数据
        /// </summary>
        /// <param name="context">要获取值的组件</param>
        /// <returns></returns>
        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues( ITypeDescriptorContext context )
        {

            return new StandardValuesCollection( EnumString );
        }


        /// <summary>
        /// 操作员是否不允许键入下拉表内不存在的值
        /// </summary>
        /// <param name="context">要获取值的组件</param>
        /// <returns></returns>
        public override bool GetStandardValuesExclusive( ITypeDescriptorContext context )
        {
            return true;
        }

    }


    /// <summary>
    /// 重写基类、实现对发药窗口显示列表选择
    /// </summary>
    public class SendWindowConverter : StringConverter
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SendWindowConverter( )
        {
        }

        private static string[ ] str = { };
        public static string[ ] EnumString
        {
            get { return str; }
            set { str = value; }
        }


        /// <summary>
        /// 设定该对象支持从列表中选择一组标准值
        /// </summary>
        /// <param name="context">要获取值的组件</param>
        /// <returns>返回True</returns>
        public override bool GetStandardValuesSupported( ITypeDescriptorContext context )
        {
            return true;
        }


        /// <summary>
        /// 填充下拉列表的数据
        /// </summary>
        /// <param name="context">要获取值的组件</param>
        /// <returns></returns>
        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues( ITypeDescriptorContext context )
        {
            return new StandardValuesCollection( EnumString );
        }


        /// <summary>
        /// 操作员是否不允许键入下拉表内不存在的值
        /// </summary>
        /// <param name="context">要获取值的组件</param>
        /// <returns></returns>
        public override bool GetStandardValuesExclusive( ITypeDescriptorContext context )
        {
            return true;
        }

    }

}
