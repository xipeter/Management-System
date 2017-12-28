using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using FarPoint.Win.Spread;
using FarPoint.Win;
namespace Neusoft.NFC.Interface.Controls
{
	/// <summary>
	/// FpTreeView 的摘要说明。
 	/// </summary>
	/// <example>
	/// <code language="C#">
///		private DataSet CreateDataSet()
///		{
///			//定义传出DataSet
///			DataSet myDataSet=new DataSet();
///			myDataSet.EnforceConstraints=false;//是否遵循约束规则
///			
///			//定义类型
///			System.Type dtStr=System.Type.GetType("System.String");
///			System.Type dtInt=System.Type.GetType("System.Int32");
///
///			//定义表********************************************************
///			//Main Table
///			DataTable dtMain;
///			dtMain=myDataSet.Tables.Add("TableMain");
///			dtMain.Columns.AddRange(new DataColumn[]{new DataColumn("TabMainColumn1",dtStr),new DataColumn("TabMainColumn2", dtStr), new DataColumn("id", dtInt)});
///			dtMain.Rows.Add(new Object[] {"Aerosmith", "http://www.aerosmith.com/detect.html", 0});
///			dtMain.Rows.Add(new Object[] {"Foreigner", "http://www.foreigneronline.com/", 1});
///			//ChildTable1
///			DataTable dtChild1;
///			dtChild1=myDataSet.Tables.Add("TableChild1");
///			dtChild1.Columns.AddRange(new DataColumn[]{new DataColumn("TabChildColumn1",dtStr),new DataColumn("childID", dtStr), new DataColumn("id", dtInt)});
///			dtChild1.Rows.Add(new Object[] {"ChildCol1Row1", "a", 0});
///			dtChild1.Rows.Add(new Object[] {"ChildCol1Row2", "a", 1});
///			dtChild1.Rows.Add(new Object[] {"ChildCol1Row3", "b", 0});
///			dtChild1.Rows.Add(new Object[] {"ChildCol1Row4", "c", 1});
///			//ChildTable2
///			/*			DataTable dtChild2;
///						dtChild2=myDataSet.Tables.Add("TableChild2");
///						dtChild2.Columns.AddRange(new DataColumn[]{new DataColumn("TabChildColumn2",dtStr),new DataColumn("TabChildColumn3", dtStr), new DataColumn("childID", dtStr)});
///						dtChild2.Rows.Add(new Object[] {"ChildCol2Row1","Kasd", "a"});
///						dtChild2.Rows.Add(new Object[] {"ChildCol2Row2","Kasdf", "c"});
///						dtChild2.Rows.Add(new Object[] {"ChildCol2Row3","Kdd", "b"});
///						dtChild2.Rows.Add(new Object[] {"ChildCol2Row4","o", "c"});
///			*/	
///			//********************************************************
///			//Add the relations
///			myDataSet.Relations.Add("TableChild1", dtMain.Columns["id"], dtChild1.Columns["id"]);
///			//myDataSet.Relations.Add("TableChild2", dtChild1.Columns["childID"], dtChild2.Columns["childID"]);
///
///			return myDataSet;	
///		}
	///	</code>
	/// <code language="VB">
	///	Private Sub CreateDataSet()
	///        Dim artists As DataTable
	///        Dim cds As DataTable
	///        Dim songs As DataTable
	///        Dim dtStr As System.Type
	///       Dim dtInt As System.Type
	///        dtStr = System.Type.GetType("System.String")
	///        dtInt = System.Type.GetType("System.Int32")
	///
	///        myDataSet = New DataSet()
	///        myDataSet.EnforceConstraints = False
	///
	///        artists = myDataSet.Tables.Add("artists")
	///        artists.Columns.AddRange(New DataColumn() {New DataColumn("Artist", dtStr), New DataColumn("Website", dtStr), New DataColumn("id", dtInt)})
	///        artists.Rows.Add(New Object() {"Aerosmith", "http://www.aerosmith.com/detect.html", 0})
	///        artists.Rows.Add(New Object() {"Foreigner", "http://www.foreigneronline.com/", 1})
	///        artists.Rows.Add(New Object() {"Jimi Hendrix", "http://www.jimi-hendrix.com/", 2})
	///        artists.Rows.Add(New Object() {"Pink Floyd", "http://www.pinkfloyd.com", 3})
	///        artists.Rows.Add(New Object() {"The Who", "http://www.thewho.net/", 4})
	///
	///        cds = myDataSet.Tables.Add("cds")
	///        cds.Columns.AddRange(New DataColumn() {New DataColumn("CD Title", dtStr), New DataColumn("Label", dtStr), New DataColumn("Year", dtStr), New DataColumn("ArtistID", dtInt)})
	///        cds.Rows.Add(New Object() {"Aerosmith", "Columbia", "1973", 0})
	///        cds.Rows.Add(New Object() {"Get Your Wings", "Columbia", "1974", 0})
	///        cds.Rows.Add(New Object() {"Toys In The Attic", "Columbia", "1975", 0})
	///        cds.Rows.Add(New Object() {"Foreigner", "Atlantic", "1977", 1})
	///        cds.Rows.Add(New Object() {"Double Vision", "Atlantic", "1978", 1})
	///        cds.Rows.Add(New Object() {"Head Games", "Atlantic", "1979", 1})
	///        cds.Rows.Add(New Object() {"Are You Experienced", "MCA", "1967", 2})
	///        cds.Rows.Add(New Object() {"Axis: Bold As Love", "MCA", "1968", 2})
	///        cds.Rows.Add(New Object() {"Electic Ladyland", "MCA", "1968", 2})
	///        cds.Rows.Add(New Object() {"Piper At The Gates Of Dawn", "EMI", "1967", 3})
	///        cds.Rows.Add(New Object() {"A Saucerful Of Secrets", "EMI", "1968", 3})
	///        cds.Rows.Add(New Object() {"Ummagumma", "EMI", "1969", 3})
	///        cds.Rows.Add(New Object() {"The Who Sings My Generation", "Decca", "1966", 4})
	///        cds.Rows.Add(New Object() {"Happy Jack", "Decca", "1967", 4})
	///        cds.Rows.Add(New Object() {"The Who Sell Out", "Decca", "1967", 4})
	///
	///        songs = myDataSet.Tables.Add("Songs")
	///        songs.Columns.AddRange(New DataColumn() {New DataColumn("Track", dtStr), New DataColumn("CD Title", dtStr), New DataColumn("ArtistID", dtInt)})
	///        songs.Rows.Add(New Object() {"Make It", "Aerosmith", 0})
	///        songs.Rows.Add(New Object() {"Somebody", "Aerosmith", 0})
	///        songs.Rows.Add(New Object() {"Dream On", "Aerosmith", 0})
	///        songs.Rows.Add(New Object() {"One Way Street", "Aerosmith", 0})
	///        songs.Rows.Add(New Object() {"Mama Kin", "Aerosmith", 0})
	///        songs.Rows.Add(New Object() {"Write Me", "Aerosmith", 0})
	///        songs.Rows.Add(New Object() {"Movin' Out", "Aerosmith", 0})
	///        songs.Rows.Add(New Object() {"Walkin' The Dog", "Aerosmith", 0})
	///        songs.Rows.Add(New Object() {"Same Old Song And Dance", "Get Your Wings", 0})
	///        songs.Rows.Add(New Object() {"Lord Of The Thighs", "Get Your Wings", 0})
	///        songs.Rows.Add(New Object() {"Spaced", "Get Your Wings", 0})
	///        songs.Rows.Add(New Object() {"Woman Of The World", "Get Your Wings", 0})
	///        songs.Rows.Add(New Object() {"S.O.S. (Too Bad)", "Get Your Wings", 0})
	///        songs.Rows.Add(New Object() {"Train Kept A Rollin'", "Get Your Wings", 0})
	///        songs.Rows.Add(New Object() {"Seasons Of Wither", "Get Your Wings", 0})
	///        songs.Rows.Add(New Object() {"Pandora's Box", "Get Your Wings", 0})
	///        songs.Rows.Add(New Object() {"Toys In The Attic ", "Toys In The Attic", 0})
	///        songs.Rows.Add(New Object() {"Uncle Salty", "Toys In The Attic", 0})
	///        songs.Rows.Add(New Object() {"Adam's Apple", "Toys In The Attic", 0})
	///        songs.Rows.Add(New Object() {"Walk This Way", "Toys In The Attic", 0})
	///        songs.Rows.Add(New Object() {"Big Ten Inch Record", "Toys In The Attic", 0})
	///        songs.Rows.Add(New Object() {"Sweet Emotion", "Toys In The Attic", 0})
	///        songs.Rows.Add(New Object() {"No More No More", "Toys In The Attic", 0})
	///        songs.Rows.Add(New Object() {"Round And Round", "Toys In The Attic", 0})
	///        songs.Rows.Add(New Object() {"You See Me Crying", "Toys In The Attic", 0})
	///        songs.Rows.Add(New Object() {"Feels Like The First Time", "Foreigner", 1})
	///        songs.Rows.Add(New Object() {"Cold As Ice", "Foreigner", 1})
	///        songs.Rows.Add(New Object() {"Starrider", "Foreigner", 1})
	///        songs.Rows.Add(New Object() {"Headknocker", "Foreigner", 1})
	/// /       songs.Rows.Add(New Object() {"The Damage Is Done", "Foreigner", 1})
	///        songs.Rows.Add(New Object() {"Long, Long Way From Home", "Foreigner", 1})
	///        songs.Rows.Add(New Object() {"Woman Oh Woman", "Foreigner", 1})
	///        songs.Rows.Add(New Object() {"At War With The World", "Foreigner", 1})
	///        songs.Rows.Add(New Object() {"Fool For You Anyway", "Foreigner", 1})
	///        songs.Rows.Add(New Object() {"I Need You", "Foreigner", 1})
	///        songs.Rows.Add(New Object() {"Hot Blooded", "Double Vision", 1})
	///        songs.Rows.Add(New Object() {"Blue Morning, Blue Day", "Double Vision", 1})
	///        songs.Rows.Add(New Object() {"You're All I Am", "Double Vision", 1})
	///        songs.Rows.Add(New Object() {"Back Where You Belong", "Double Vision", 1})
	///        songs.Rows.Add(New Object() {"Love Has Taken Its Toll", "Double Vision", 1})
	///        songs.Rows.Add(New Object() {"Double Vision", "Double Vision", 1})
	///        songs.Rows.Add(New Object() {"Tramontane", "Double Vision", 1})
	///        songs.Rows.Add(New Object() {"I Have Waited So Long", "Double Vision", 1})
	///        songs.Rows.Add(New Object() {"Lonely Children", "Double Vision", 1})
	///        songs.Rows.Add(New Object() {"Spellbinder", "Double Vision", 1})
	///        songs.Rows.Add(New Object() {"Dirty White Boy", "Head Games", 1})
	///        songs.Rows.Add(New Object() {"Love On The Telephone", "Head Games", 1})
	///        songs.Rows.Add(New Object() {"Woman", "Head Games", 1})
	///        songs.Rows.Add(New Object() {"I'll Get Even With You", "Head Games", 1})
	///        songs.Rows.Add(New Object() {"Seventeen", "Head Games", 1})
	///        songs.Rows.Add(New Object() {"Head Games", "Head Games", 1})
	///        songs.Rows.Add(New Object() {"The Modern Day", "Head Games", 1})
	///        songs.Rows.Add(New Object() {"Blinded By Science", "Head Games", 1})
	///       songs.Rows.Add(New Object() {"Do What You Like", "Head Games", 1})
	///       songs.Rows.Add(New Object() {"Rev On The Red Line", "Head Games", 1})
	///        songs.Rows.Add(New Object() {"Purple Haze", "Are You Experienced", 2})
	///        songs.Rows.Add(New Object() {"Manic Depression", "Are You Experienced", 2})
	///        songs.Rows.Add(New Object() {"Hey Joe", "Are You Experienced", 2})
	///        songs.Rows.Add(New Object() {"Love Or Confusion", "Are You Experienced", 2})
	///        songs.Rows.Add(New Object() {"May This Be Love", "Are You Experienced", 2})
	///        songs.Rows.Add(New Object() {"I Don't Live Today", "Are You Experienced", 2})
	///        songs.Rows.Add(New Object() {"The Wind Cries Mary", "Are You Experienced", 2})
	///        songs.Rows.Add(New Object() {"Third Stone From The Sun", "Are You Experienced", 2})
	///        songs.Rows.Add(New Object() {"Foxey Lady", "Are You Experienced", 2})
	///        songs.Rows.Add(New Object() {"Are You Experienced?", "Are You Experienced", 2})
	///        songs.Rows.Add(New Object() {"EXP", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"Up From The Skies", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"Spanish Castle Magic", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"Wait Until Tomorrow", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"Ain't No Telling", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"Little Wing", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"If 6 Was Nine", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"You Got Me Floatin'", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"Castles Made Of Sand", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"She's So Fine", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"One Rainy Wish", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"Little Miss Lover", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"Bold As Love", "Axis: Bold As Love", 2})
	///        songs.Rows.Add(New Object() {"...And The Gods Made Love", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"Have You Ever Been (To Electric Ladyland)", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"Crosstown Traffic", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"Voodoo Chile", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"Long Hot Summer Night", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"Come On", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"Gypsy Eyes", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"Burning Of The Midnight Lamp", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"Rainy Day, Dream Away", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"1983...(A Merman I Should Turn To Be)", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"Moon Turn The Tides... Gently, Gently Away", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"Still Raining, Still Dreaming", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"House Burning Down", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"All Along The Watchtower", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"Voodoo Child (Slight Return}", "Electic Ladyland", 2})
	///        songs.Rows.Add(New Object() {"Astronomy Domine", "Piper At The Gates Of Dawn", 3})
	///        songs.Rows.Add(New Object() {"Lucifer Sam", "Piper At The Gates Of Dawn", 3})
	///        songs.Rows.Add(New Object() {"Matilda Mother", "Piper At The Gates Of Dawn", 3})
	///        songs.Rows.Add(New Object() {"Flaming", "Piper At The Gates Of Dawn", 3})
	///        songs.Rows.Add(New Object() {"Pow R. Toc H.", "Piper At The Gates Of Dawn", 3})
	///        songs.Rows.Add(New Object() {"Take Up Thy Stethoscope And Walk", "Piper At The Gates Of Dawn", 3})
	///        songs.Rows.Add(New Object() {"Interstellar Overdrive", "Piper At The Gates Of Dawn", 3})
	///        songs.Rows.Add(New Object() {"The Gnome", "Piper At The Gates Of Dawn", 3})
	///        songs.Rows.Add(New Object() {"Chapter 24", "Piper At The Gates Of Dawn", 3})
	///        songs.Rows.Add(New Object() {"Scarecrow", "Piper At The Gates Of Dawn", 3})
	///        songs.Rows.Add(New Object() {"Bike", "Piper At The Gates Of Dawn", 3})
	///        songs.Rows.Add(New Object() {"Let There Be More Light", "A Saucerful Of Secrets", 3})
	///        songs.Rows.Add(New Object() {"Remember A Day", "A Saucerful Of Secrets", 3})
	///        songs.Rows.Add(New Object() {"Set The Controls For The Heart Of The Sun", "A Saucerful Of Secrets", 3})
	///        songs.Rows.Add(New Object() {"Corporal Clegg", "A Saucerful Of Secrets", 3})
	///        songs.Rows.Add(New Object() {"A Saucerful Of Secrets", "A Saucerful Of Secrets", 3})
	///        songs.Rows.Add(New Object() {"See-Saw", "A Saucerful Of Secrets", 3})
	///        songs.Rows.Add(New Object() {"Jugband Blues", "A Saucerful Of Secrets", 3})
	///        songs.Rows.Add(New Object() {"Astronomy Domine", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"Careful With That Axe, Eugene", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"Set The Controls For The Heart Of The Sun", "Ummagumma", 3})
	///       songs.Rows.Add(New Object() {"A Saucerful Of Secrets", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"Sysyphus: Part One", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"Sysyphus: Part Two", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"Sysyphus: Part Three", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"Sysyphus: Part Four", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"Grantchester Meadows", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"Several Species Of Small Furry Animals Gathered Together In A Cave And Grooving With A Pict", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"The Narrow Way: Part One", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"The Narrow Way: Part Two", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"The Narrow Way: Part Three", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"The Grand Vizier's Garden Party: Part One (Entrance)", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"The Grand Vizier's Garden Party: Part Two (Entertainment)", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"The Grand Vizier's Garden Party: Part Three (Exit)", "Ummagumma", 3})
	///        songs.Rows.Add(New Object() {"Out in the Street", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"I Don't Mind", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"The Goods Gone", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"La La La Lies", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"Much Too Much", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"My Generation", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"The Kids are Alright", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"Please, Please, Please", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"It's Not True", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"The Ox", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"A Legal Matter", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"I'm a Man", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"Instant Party (Circles)", "The Who Sings My Generation", 4})
	///        songs.Rows.Add(New Object() {"Run Run Run", "Happy Jack", 4})
	///        songs.Rows.Add(New Object() {"Boris The Spider", "Happy Jack", 4})
	///        songs.Rows.Add(New Object() {"I Need You", "Happy Jack", 4})
	///        songs.Rows.Add(New Object() {"Whiskey Man", "Happy Jack", 4})
	///        songs.Rows.Add(New Object() {"Heat Wave/Happy Jack", "Happy Jack", 4})
	///        songs.Rows.Add(New Object() {"Cobwebs And Strange", "Happy Jack", 4})
	///        songs.Rows.Add(New Object() {"Don't Look Away", "Happy Jack", 4})
	///        songs.Rows.Add(New Object() {"See My Way", "Happy Jack", 4})
	///        songs.Rows.Add(New Object() {"So Sad About Us", "Happy Jack", 4})
	///        songs.Rows.Add(New Object() {"A Quick One While He's Away", "Happy Jack", 4})
	///        songs.Rows.Add(New Object() {"Armenia City In The Sky", "The Who Sell Out", 4})
	///        songs.Rows.Add(New Object() {"Heinz Baked Beans", "The Who Sell Out", 4})
	///        songs.Rows.Add(New Object() {"Mary Anne With The Shaky Hand", "The Who Sell Out", 4})
	///        songs.Rows.Add(New Object() {"Odorono", "The Who Sell Out", 4})
	///        songs.Rows.Add(New Object() {"Tattoo", "The Who Sell Out", 4})
	///        songs.Rows.Add(New Object() {"Our Love Was", "The Who Sell Out", 4})
	///        songs.Rows.Add(New Object() {"I Can See For Miles", "The Who Sell Out", 4})
	///        songs.Rows.Add(New Object() {"I Can't Reach You", "The Who Sell Out", 4})
	///        songs.Rows.Add(New Object() {"Medac (Spotted Henry)", "The Who Sell Out", 4})
	///        songs.Rows.Add(New Object() {"Relax", "The Who Sell Out", 4})
	///        songs.Rows.Add(New Object() {"Silas Stingy", "The Who Sell Out", 4})
	///        songs.Rows.Add(New Object() {"Sunrise", "The Who Sell Out", 4})
	///        songs.Rows.Add(New Object() {"Rael 12", "The Who Sell Out", 4})
	///
	///        'Add the relations
	///        myDataSet.Relations.Add("cds", artists.Columns("id"), cds.Columns("ArtistID"))
	///        myDataSet.Relations.Add("songs", cds.Columns("CD Title"), songs.Columns("CD Title"))
	///
	///    End Sub
	///</code>
	/// </example>
	public class FpTreeView : BaseFp
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FpTreeView()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

		}

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region 组件设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			
		}
		#endregion
		public event SheetViewEventHandler sv_CellChanged;
		#region 方法
		/// <summary>
		/// 初始化
		/// </summary>
		public virtual void  init(int i)
		{
			this.fpSpread1.Sheets[i].DataSource=this.fpDateSet;
			this.fpSpread1.Sheets[i].DataMember="Table";
			this.fpSpread1.Sheets[i].DefaultStyle.Font=this.fpSpread1.Font;
			//Set width on row header to display to nav buttons
			this.fpSpread1.Sheets[i].Models.RowHeaderColumnAxis.SetSize(0,40);
			
			this.fpSpread1.BorderStyle=System.Windows.Forms.BorderStyle.None;
			this.fpSpread1.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
			this.fpSpread1.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
			
			this.fpSpread1.ChildViewCreated+=new ChildViewCreatedEventHandler(fpSpread1_ChildViewCreated);
			#region
			//this.fpSpread1.Expand+=new ExpandEventHandler(fpSpread1_Expand);
			//this.fpSpread1_Sheet1.AlternatingRows[0].BackColor=this.fpColumnBackColor;
			//this.fpSpread1_Sheet1.AlternatingRows[0].ForeColor=this.fpColumnForeColor;

//			FarPoint.Win.Spread.Model.DefaultSheetDataModel model=this.fpSpread1_Sheet1.Models.Data;
//			model.DataMember="Table";
//			model.DataSource=this.fpDateSet;
//			
//			this.fpSpread1_Sheet1.GetDataView(false).AddNew=false;
			#endregion
		}
		public new void  init()
		{
			this.init(0);
		}
		/// <summary>
		/// 刷新
		/// </summary>
		public new void Refresh()
		{
		}
		#endregion
		#region 属性
		bool bIsChildRowHeaderShowAutoText = false;
		/// <summary>
		/// 
		/// </summary>
		public bool IsChildRowHeaderShowAutoText
		{
			set
			{
				this.bIsChildRowHeaderShowAutoText = value;
			}
		}
		#endregion
		#region 事件
		private void fpSpread1_ChildViewCreated(object sender, FarPoint.Win.Spread.ChildViewCreatedEventArgs e)
		{
			try
			{
				SetChildViewStyle(e.SheetView);
			}
			catch(Exception ex)
			{
				string err=ex.Message;
			}
		}
		#endregion
		#region 函数
		public void SetChildViewStyle(FarPoint.Win.Spread.SheetView sv)
		{
			this.SetChildViewStyle(sv,this.fpChildColumnVisible);
		}
		public void SetChildViewStyle(FarPoint.Win.Spread.SheetView sv,bool SetChildViewStyle)
		{
			try
			{
				//Make the header font italic
				sv.ColumnHeader.DefaultStyle.Font=this.fpSpread1.Font;
				sv.ColumnHeader.DefaultStyle.Border=new EmptyBorder();
				sv.ColumnHeader.DefaultStyle.BackColor =this.fpChildColumn1BackColor;
				sv.ColumnHeader.DefaultStyle.ForeColor =this.fpChildColumn1ForeColor;
				//Change the sheet corner color
				sv.SheetCornerStyle.BackColor = this.fpHeaderBackColor;
				sv.SheetCornerStyle.Border = new EmptyBorder();

				//Clear the autotext
				if(bIsChildRowHeaderShowAutoText==false)
					sv.RowHeader.AutoText = HeaderAutoText.Blank;

				sv.RowHeader.DefaultStyle.BackColor = this.fpChildHeader1BackColor;
				sv.RowHeader.DefaultStyle.ForeColor = this.fpChildHeader1ForeColor;

				sv.ColumnHeaderVisible = this.fpChildColumnVisible;
				sv.RowHeaderVisible = SetChildViewStyle;
				for(int i = 0 ; i<sv.RowCount;i++)	sv.Rows[i].Height = this.DefaultRowHeight;
				sv.CellChanged+=new SheetViewEventHandler(sv_CellChanged);
			}
			catch{}

			//sv.DataAutoCellTypes=false;
			sv.DataAutoSizeColumns=this.DataAutoSizeColumns;
			sv.OperationMode = this.fpSpread1.Sheets[0].OperationMode ;
			
			ArrayList al = new ArrayList();
			switch(sv.GetDataView(true).Table.TableName)
			{
				case "TableMain":
					al = this.ColumnsProperty;
					break;
				case "TableChild1":
					al = this.alChild1ColumnsProperty ;
					break;
				case "TableChild2":
					al = this.alChild2ColumnsProperty ;
					break;
				default:
					al = this.ColumnsProperty;
					break;
			}
			//hide or show the ID column
			try
			{
				for(int i=0;i<sv.ColumnCount;i++)
				{

					ColumnProperty cp = (ColumnProperty)al[i];
					//chage the column widths
					if(this.DataAutoSizeColumns==false)
					{
						if(cp.Width==-1){cp.Width=this.DefaultColumnWidth;}
						sv.Columns[i].Width=cp.Width;
					}
					if(cp.Height==-1){cp.Height=this.DefaultRowHeight;}
					sv.Columns[i].BackColor=cp.BackColor;
					sv.Columns[i].ForeColor=cp.ForeColor;
					sv.Columns[i].Locked =true;//cp.Locked;
					sv.Columns[i].Visible=cp.Visible;
					sv.Columns[i].Font=cp.Font;
					if(this.fpIDColumnVisible==false && i==0)sv.Columns[i].Visible=false;
				}
			}
			catch(Exception ex){System.Windows.Forms.MessageBox.Show(ex.Message);}
		}
		#endregion

		
	}
}
