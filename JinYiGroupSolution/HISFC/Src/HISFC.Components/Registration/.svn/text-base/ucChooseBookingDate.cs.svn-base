using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Registration
{
    /// <summary>
    /// 选择医生出诊信息列表
    /// </summary>
    public partial class ucChooseBookingDate : UserControl
    {
        public ucChooseBookingDate()
        {
            InitializeComponent();

            this.InitNoon();
            this.fpSpread1.KeyDown          += new KeyEventHandler(fpSpread1_KeyDown);
            this.fpSpread1.CellDoubleClick  += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellDoubleClick);

            Neusoft.HISFC.BizProcess.Integrate.Manager conMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            this.alSpecialDepts = conMgr.QueryConstantList("IsSpecialClinic");
            if (this.alSpecialDepts == null) this.alSpecialDepts = new ArrayList();
            SetFarpoint();
        }

        #region 变量
        /// <summary>
		/// 排班管理类
		/// </summary>
		private Neusoft.HISFC.BizLogic.Registration.Schema SchemaMgr = new Neusoft.HISFC.BizLogic.Registration.Schema();
		/// <summary>
		/// 午别
		/// </summary>
		private Hashtable htNoon = new Hashtable() ;
		/// <summary>
		/// Array Collections
		/// </summary>
		private ArrayList al = new ArrayList() ;
		private ArrayList alSpecialDepts = new ArrayList();
        #endregion

        #region 属性
        /// <summary>
		/// 预约排班信息集合
		/// </summary>
		public ArrayList Bookings
		{
			get{return al ;}
		}
		/// <summary>
		/// 有效预约数
		/// </summary>
		public int Count
		{
			get{return this.fpSpread1_Sheet1.RowCount ;}
		}		
		/// <summary>
		/// delegate
		/// </summary>
		public delegate void dSelectedItem(Neusoft.HISFC.Models.Registration.Schema sender) ;
		/// <summary>
		/// 选择排班事件
		/// </summary>
		public event dSelectedItem SelectedItem;
        #endregion

        #region 私有函数
        /// <summary>
		/// 初始化午别
		/// </summary>
		private void InitNoon()
		{
            Neusoft.HISFC.BizLogic.Registration.Noon NoonMgr = new Neusoft.HISFC.BizLogic.Registration.Noon();

			ArrayList al = NoonMgr.Query() ;
			if( al == null)
			{
				MessageBox.Show("获取午别信息时出错!" + NoonMgr.Err,"提示") ;
				return ;
			}

			foreach(Neusoft.HISFC.Models.Base.Noon obj in al)
			{
				this.htNoon.Add(obj.ID,obj.Name) ;
			}
		}
		
		/// <summary>
		/// 根据代码查午别名称
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		private string GetNoonNameByID(string ID)
		{
			System.Collections.IDictionaryEnumerator dict = this.htNoon.GetEnumerator() ;

			while(dict.MoveNext() )
			{
				if(dict.Key.ToString() == ID)
				{
					return dict.Value.ToString() ;
				}
			}
			return ID ;
		}

		
		/// <summary>
		/// 查询科室预约号安排
		/// </summary>
		/// <param name="bookingDate"></param>
		/// <param name="deptID"></param>	
		/// <param name="regType"></param>	
		public void QueryDeptBooking(DateTime bookingDate,string deptID,RegTypeNUM regType)
		{
			if(this.fpSpread1_Sheet1.RowCount > 0)
				this.fpSpread1_Sheet1.Rows.Remove(0,this.fpSpread1_Sheet1.RowCount) ;

			al = this.SchemaMgr.QueryByDept(bookingDate.Date,deptID) ;
			if( al == null)
			{
				MessageBox.Show("查询排班信息时出错!" +this.SchemaMgr.Err,"提示") ;
				return ;
			}

			DateTime current = this.SchemaMgr.GetDateTimeFromSysDateTime() ;

			foreach(Neusoft.HISFC.Models.Registration.Schema obj in al)
			{
				if( !IsMaybeValid(obj, current, regType)) continue ;

				this.AddRow(obj) ;
			}

			//this.Span() ;
		}

		/// <summary>
		/// 查询医生预约号安排
		/// </summary>
		/// <param name="bookingDate"></param>
		/// <param name="doctID"></param>
		/// <param name="regType"></param>	
		public void QueryDoctBooking(DateTime bookingDate,string doctID,RegTypeNUM regType)
		{
			if(this.fpSpread1_Sheet1.RowCount > 0)
				this.fpSpread1_Sheet1.Rows.Remove(0,this.fpSpread1_Sheet1.RowCount) ;

			al = this.SchemaMgr.QueryByDoct(bookingDate.Date,doctID) ;
			if( al == null)
			{
				MessageBox.Show("查询排班信息时出错!" +this.SchemaMgr.Err,"提示") ;
				return ;
			}
			
			DateTime current = this.SchemaMgr.GetDateTimeFromSysDateTime() ;

			foreach(Neusoft.HISFC.Models.Registration.Schema obj in al)
			{
				
				if( !IsMaybeValid(obj, current, regType)) continue ;

				this.AddRow(obj) ;
			}

			//this.Span() ;
        }
       
        
        /// <summary>
		/// 按科室、医生查询出诊医生
		/// </summary>
		/// <param name="bookingDate"></param>
		/// <param name="doctId"></param>
		/// <param name="deptID"></param>
		/// <param name="regType"></param>
		public void QueryDoctBooking(DateTime bookingDate,string doctId, string deptID,RegTypeNUM regType)
		{
			if(this.fpSpread1_Sheet1.RowCount > 0)
				this.fpSpread1_Sheet1.Rows.Remove(0,this.fpSpread1_Sheet1.RowCount) ;

			al = this.SchemaMgr.QueryByDoct(bookingDate.Date,deptID,doctId) ;
			if( al == null)
			{
				MessageBox.Show("查询排班信息时出错!" +this.SchemaMgr.Err,"提示") ;
				return ;
			}
			
			DateTime current = this.SchemaMgr.GetDateTimeFromSysDateTime() ;

			foreach(Neusoft.HISFC.Models.Registration.Schema obj in al)
			{
				
				if( !IsMaybeValid(obj, current, regType)) continue ;

				this.AddRow(obj) ;
			}

		}
         #region 暂时不用
        /*
        private void Span()
		{
			int rowLastDate = 0, rowLastNoon = 0 ;
			int rowCnt = this.fpSpread1_Sheet1.RowCount ;
			for( int i = 0 ;i < rowCnt ; i++)
			{
				if( i > 0 && this.fpSpread1_Sheet1.GetText(i,0) != this.fpSpread1_Sheet1.GetText(i-1,0))
				{
					if( i - rowLastDate > 1 )
					{						
						this.fpSpread1_Sheet1.Models.Span.Add(rowLastDate,0 , i - rowLastDate ,1) ;						
					}

					rowLastDate = i ;					
				}

				//最后一行处理
				if(i > 0&& i == rowCnt -1 && this.fpSpread1_Sheet1.GetText(i,0) == this.fpSpread1_Sheet1.GetText(i-1,0))
				{
					this.fpSpread1_Sheet1.Models.Span.Add(rowLastDate,0, i - rowLastDate + 1,1) ;
				}

				///午别
				///
				if( i > 0 &&
					(this.fpSpread1_Sheet1.GetText(i,0) != this.fpSpread1_Sheet1.GetText(i-1,0)||
					this.fpSpread1_Sheet1.GetText(i,1) != this.fpSpread1_Sheet1.GetText(i-1,1)))
					
				{
					if(i - rowLastNoon >1 )
					{						
						this.fpSpread1_Sheet1.Models.Span.Add(rowLastNoon,1, i - rowLastNoon,1) ;
					}
					rowLastNoon = i ;
				}
				//最后一行
				if( i > 0 && i == rowCnt - 1 &&
					(this.fpSpread1_Sheet1.GetText(i,1) == this.fpSpread1_Sheet1.GetText(i-1,1)||
					this.fpSpread1_Sheet1.GetText(i,0) == this.fpSpread1_Sheet1.GetText(i-1,0)))
				{
					this.fpSpread1_Sheet1.Models.Span.Add(rowLastNoon,1, i - rowLastNoon + 1,1) ;
				}
			}
		}
        */
        #endregion
        
        /// <summary>
		/// 判断一条出诊信息是否有效(超出限额的为判断,所以用了Maybe, HaHa ～～ :))
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="current"></param>
		/// <param name="regType"></param>
		/// <returns></returns>
		private bool IsMaybeValid(Neusoft.HISFC.Models.Registration.Schema obj, DateTime current, RegTypeNUM regType)
		{
			//无效

			if(obj.Templet.IsValid == false) return false ;
			
			//不是加号
//			if(!obj.Templet.IsAppend)
//			{
//				if(regType == RegTypeNUM.Booking)
//				{
//					if(obj.Templet.TelLmt == 0) return false ;//没有预约安排,不显示
//				}
//				else if(regType == RegTypeNUM.Expert)
//				{
//					if(obj.Templet.RegLmt ==0) return false ;
//				}
//				else if(regType == RegTypeNUM.Faculty)
//				{
//					if(obj.Templet.RegLmt ==0) return false ;
//				}
//				else if(regType == RegTypeNUM.Special)
//				{
//					if(obj.Templet.SpeLmt == 0) return false ;
//				}
//			}

			//
			//只有日期相同,才判断时间是否超时,否则就是预约到以后日期,时间不用判断,(出诊时间一定是>=当前时间)
			//
			if(current.Date == obj.SeeDate.Date)
			{
				if(obj.Templet.End.TimeOfDay <current.TimeOfDay) return false ;//时间小于当前时间,不显示
			}

			return true ;
		}

		/// <summary>
		/// 取得最有效的一条出诊记录
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="current"></param>
		/// <param name="regType"></param>
		/// <returns></returns>
		private bool IsValid(Neusoft.HISFC.Models.Registration.Schema obj,DateTime current, RegTypeNUM regType)
		{

			if(this.IsMaybeValid(obj,current,regType) == false)return false ;

			//判断是否超限额
			if(!obj.Templet.IsAppend)
			{
				if(regType == RegTypeNUM.Booking)
				{					
					//中山特诊不预约,但是排班时特诊和其他科作为两条排班记录,预约挂号时只选择教授,默认检索一条符合条件的排班记录
					//这时就会经常带出特诊科室,没法看到另外科室的排班信息,在这里限制一下
					bool found = false;

					foreach(Neusoft.HISFC.Models.Base.Const con in this.alSpecialDepts)
					{
						if(obj.Templet.Dept.ID == con.ID)
						{
							found = true ;
							break;
						}
					}

					if(found)return false ;

					if(obj.Templet.TelQuota <= obj.TelingQTY) return false;//超限额
				}
				else if(regType == RegTypeNUM.Expert)
				{				
					if(obj.Templet.RegQuota <= obj.RegedQTY) return false;
				}
				else if(regType == RegTypeNUM.Faculty)
				{					
					if(obj.Templet.RegQuota <= obj.RegedQTY) return false;
				}
				else if(regType == RegTypeNUM.Special)
				{					
					if(obj.Templet.SpeQuota <= obj.SpedQTY) return false;
				}				
			}

			return true ;
		}

        /// <summary>
        /// add object to farpoint
        /// </summary>
        /// <param name="schema"></param>
        private void AddRow(Neusoft.HISFC.Models.Registration.Schema schema)
        {
            this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);

            int Index = this.fpSpread1_Sheet1.RowCount - 1;

            this.fpSpread1_Sheet1.SetValue(Index, 0, schema.SeeDate.ToString("yyyy-MM-dd") + this.getWeek(schema.SeeDate), false);
            this.fpSpread1_Sheet1.SetValue(Index, 1, this.GetNoonNameByID(schema.Templet.Noon.ID), false);
            //开始时间、结束时间
            if (schema.Templet.IsAppend)
            {
                this.fpSpread1_Sheet1.SetValue(Index, 2, "加号", false);
                this.fpSpread1_Sheet1.SetValue(Index, 3, "加号", false);
            }
            else
            {
                this.fpSpread1_Sheet1.SetValue(Index, 2, schema.Templet.Begin.ToString("HH:mm"), false);
                this.fpSpread1_Sheet1.SetValue(Index, 3, schema.Templet.End.ToString("HH:mm"), false);
            }

            //来人设号
            this.fpSpread1_Sheet1.SetValue(Index, 4, schema.Templet.RegQuota, false);
            //来人取号
            this.fpSpread1_Sheet1.SetValue(Index, 5, schema.RegedQTY, false);
            //来电
            this.fpSpread1_Sheet1.SetValue(Index, 6, schema.Templet.TelQuota, false);
            this.fpSpread1_Sheet1.SetValue(Index, 7, schema.TelingQTY, false);
            this.fpSpread1_Sheet1.SetValue(Index, 8, schema.TeledQTY, false);
            //特诊
            this.fpSpread1_Sheet1.SetValue(Index, 9, schema.Templet.SpeQuota, false);
            this.fpSpread1_Sheet1.SetValue(Index, 10, schema.SpedQTY, false);

            this.fpSpread1_Sheet1.Rows[Index].Tag = schema;
        }

        /// <summary>
        /// 获得星期
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        private string getWeek(DateTime current)
        {
            string[] week = new string[] { "[日]", "[一]", "[二]", "[三]", "[四]", "[五]", "[六]" };

            return week[(int)current.DayOfWeek];
        }
        #endregion

        #region 公有函数
        /// <summary>
		/// 获得一条有效的、最早的、限额未满的排班信息
		/// </summary>
		/// <param name="regType"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Registration.Schema GetValidBooking(RegTypeNUM regType)
		{
			return this.GetValidBooking(al, regType) ;
		}		
		
		/// <summary>
		/// 从指定的排班信息中,获得一条有效的、最早的、限额未满的排班信息
		/// </summary>
		/// <param name="regType"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Registration.Schema GetValidBooking(ArrayList schemaCollection, RegTypeNUM regType)
		{
			if(schemaCollection == null)return null ;
			
			DateTime current = this.SchemaMgr.GetDateTimeFromSysDateTime() ;

			foreach(Neusoft.HISFC.Models.Registration.Schema obj in  schemaCollection)
			{
				if(!this.IsValid(obj,current,regType)) continue ;

				return obj ;
			}

			return null;
		}

		/// <summary>
		/// 清空排班信息
		/// </summary>
		public void Clear() 
		{
			this.al = new ArrayList() ;

			if(this.fpSpread1_Sheet1.RowCount> 0)
			{
				this.fpSpread1_Sheet1.Rows.Remove(0,this.fpSpread1_Sheet1.RowCount) ;
			}
        }
        #endregion

        #region 事件
        /// <summary>
		/// 回车选择排班信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fpSpread1_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				this.SelectItem() ;
			}
		}

		private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			this.SelectItem() ;
		}

		/// <summary>
		/// 选择排班信息
		/// </summary>
		/// <returns></returns>
		private int SelectItem()
		{
			int row = this.fpSpread1_Sheet1.ActiveRowIndex ;
			if(row == -1 || this.fpSpread1_Sheet1.RowCount == 0) return 0;

			Neusoft.HISFC.Models.Registration.Schema schema ;

			schema = (Neusoft.HISFC.Models.Registration.Schema)this.fpSpread1_Sheet1.Rows[row].Tag ;

			if(this.SelectedItem != null)
				this.SelectedItem(schema ) ;
			
			return 0;
        }

        private void SetFarpoint()
        {
            this.fpSpread1_Sheet1.Columns[9].Visible = false;
            this.fpSpread1_Sheet1.Columns[10].Visible = false;
        }
        #endregion
    }	
	/// <summary>
	/// 挂号类别
	/// </summary>
	public enum RegTypeNUM
	{
		/// <summary>
		/// 专家号
		/// </summary>
		Expert,
		/// <summary>
		/// 专科号
		/// </summary>
		Faculty,
		/// <summary>
		/// 特诊号
		/// </summary>
		Special,
		/// <summary>
		/// 预约号
		/// </summary>
		Booking
	}  
}
