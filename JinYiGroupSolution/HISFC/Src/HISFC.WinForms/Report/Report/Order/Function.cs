using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.WinForms.Report.Order
{
    class Function:Neusoft.FrameWork.Management.Database 
    {
        #region 组合医嘱 传入的对象，column 组合项目列
        public static void DrawCombo(object sender, int column, int DrawColumn, int ChildViewLevel)
        {
            switch (sender.GetType().ToString().Substring(sender.GetType().ToString().LastIndexOf(".") + 1))
            {
                case "SheetView":
                    FarPoint.Win.Spread.SheetView o = sender as FarPoint.Win.Spread.SheetView;
                    int i = 0;
                    string tmp = "", curComboNo = "";
                    if (ChildViewLevel == 0)
                    {
                        for (i = 0; i < o.RowCount; i++)
                        {
                            #region "画"
                            if (o.Cells[i, column].Text == "0") o.Cells[i, column].Text = "";
                            tmp = o.Cells[i, column].Text + "";
                            o.Cells[i, column].Tag = tmp;
                            if (curComboNo != tmp && tmp != "") //是头
                            {
                                curComboNo = tmp;
                                o.Cells[i, DrawColumn].Text = "┓";
                                try
                                {
                                    if (o.Cells[i - 1, DrawColumn].Text == "┃")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "┛";
                                    }
                                    else if (o.Cells[i - 1, DrawColumn].Text == "┓")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "";
                                    }
                                }
                                catch { }
                            }
                            else if (curComboNo == tmp && tmp != "")
                            {
                                o.Cells[i, DrawColumn].Text = "┃";
                            }
                            else if (curComboNo != tmp && tmp == "")
                            {
                                try
                                {
                                    if (o.Cells[i - 1, DrawColumn].Text == "┃")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "┛";
                                    }
                                    else if (o.Cells[i - 1, DrawColumn].Text == "┓")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "";
                                    }
                                }
                                catch { }
                                o.Cells[i, DrawColumn].Text = "";
                                curComboNo = "";
                            }
                            if (i == o.RowCount - 1 && o.Cells[i, DrawColumn].Text == "┃") o.Cells[i, DrawColumn].Text = "┛";
                            if (i == o.RowCount - 1 && o.Cells[i, DrawColumn].Text == "┓") o.Cells[i, DrawColumn].Text = "";
                            //o.Cells[i, DrawColumn].ForeColor = System.Drawing.Color.Red;
                            #endregion
                        }
                    }
                    else if (ChildViewLevel == 1)
                    {
                        for (int m = 0; m < o.RowCount; m++)
                        {
                            FarPoint.Win.Spread.SheetView c = o.GetChildView(m, 0);
                            for (int j = 0; j < c.RowCount; j++)
                            {
                                #region "画"
                                if (c.Cells[j, column].Text == "0") c.Cells[j, column].Text = "";
                                tmp = c.Cells[j, column].Text + "";

                                c.Cells[j, column].Tag = tmp;
                                if (curComboNo != tmp && tmp != "") //是头
                                {
                                    curComboNo = tmp;
                                    c.Cells[j, DrawColumn].Text = "┓";
                                    try
                                    {
                                        if (c.Cells[j - 1, DrawColumn].Text == "┃")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "┛";
                                        }
                                        else if (c.Cells[j - 1, DrawColumn].Text == "┓")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "";
                                        }
                                    }
                                    catch { }
                                }
                                else if (curComboNo == tmp && tmp != "")
                                {
                                    c.Cells[j, DrawColumn].Text = "┃";
                                }
                                else if (curComboNo != tmp && tmp == "")
                                {
                                    try
                                    {
                                        if (c.Cells[j - 1, DrawColumn].Text == "┃")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "┛";
                                        }
                                        else if (c.Cells[j - 1, DrawColumn].Text == "┓")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "";
                                        }
                                    }
                                    catch { }
                                    c.Cells[j, DrawColumn].Text = "";
                                    curComboNo = "";
                                }
                                if (j == c.RowCount - 1 && c.Cells[j, DrawColumn].Text == "┃") c.Cells[j, DrawColumn].Text = "┛";
                                if (j == c.RowCount - 1 && c.Cells[j, DrawColumn].Text == "┓") c.Cells[j, DrawColumn].Text = "";
                                //c.Cells[j, DrawColumn].ForeColor = System.Drawing.Color.Red;
                                #endregion

                            }
                        }
                    }
                    break;
                case "NeuDataWindow":
                    NeuDataWindow.Controls.NeuDataWindow obj = sender as NeuDataWindow.Controls.NeuDataWindow;
                    if (obj.RowCount < 1)//如果没有医嘱返回
                        return;
                    string curComboID = "";
                    string tmpComboID = obj.GetItemString(1, (short)column);
                    for (i = 2; i <= obj.RowCount; i++)
                    {
                        curComboID = obj.GetItemString(i, (short)column);
                        if (tmpComboID == curComboID)
                        {
                            //组合号相等，如果上一个没有标志说明是组合的第一个
                            if (obj.IsItemNull(i - 1, (short)DrawColumn))
                            {
                                //组合第一个赋值
                                obj.SetItemSqlString(i - 1, (short)DrawColumn, "┓");
                                //如果是最后一行
                                if (i == obj.RowCount)
                                    obj.SetItemString(i, (short)DrawColumn, "┛");
                                else
                                    obj.SetItemString(i, (short)DrawColumn, "┃");//这里不管是否是一组最后一个，最后一个在组合号不等时才设置
                            }
                            else
                            {
                                //如果是最后一行
                                if (i == obj.RowCount)
                                    obj.SetItemString(i, (short)DrawColumn, "┛");
                                else
                                    obj.SetItemString(i, (short)DrawColumn, "┃");
                            }
                        }
                        else
                        {
                            //组合号不等，这时会改变在组合号相等时设置的"┃"或者"┓"，为"┛"
                            if (!obj.IsItemNull(i - 1, (short)DrawColumn))
                            {
                                //设置一组的最后一个符合
                                if (obj.GetItemString(i - 1, (short)DrawColumn) == "┃" || obj.GetItemString(i - 1, (short)DrawColumn) == "┓")
                                    obj.SetItemString(i - 1, (short)DrawColumn, "┛");
                            }
                        }
                        tmpComboID = curComboID;
                    }
                    break;
            }

        }
        /// <summary>
        /// 画组合号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="column"></param>
        /// 		/// <param name="DrawColumn"></param>
        public static void DrawCombo(object sender, int column, int DrawColumn)
        {
            DrawCombo(sender, column, DrawColumn, 0);
        }
       
        #endregion
        #region 医嘱单打印
        #region 医嘱单打印查询

        /// <summary>
        /// 查询医嘱单打印的医嘱
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns></returns>
        public ArrayList QueryPrnOrder(string inpatientNO)
        {

            string sql = "";
            ArrayList al = new ArrayList();
            //sql = OrderQuerySelect();
            //if (sql == null) return null;
            if (this.Sql.GetSql("Order.OrderPrn.QueryOrderByPatient", ref sql) == -1)
            {
                this.Err = "没有找到Order.OrderPrn.QueryOrderByPatient字段!";
                return null;
            }
            sql = string.Format(sql, inpatientNO);
            return this.myOrderQuery(sql);
        }
        #endregion
        /// <summary>
        /// 查询所有医嘱
        /// </summary>
        /// <param name="InPatientNO"></param>
        /// <returns></returns>
        public ArrayList QueryDcOrder(string InPatientNO)
        {
            #region 查询所有医嘱
            //查询所有医嘱
            //Order.Order.QueryOrder.1
            //传入：0 inpatientno
            //传出：ArrayList
            #endregion
            string sql = "", sql1 = "";
            ArrayList al = new ArrayList();
            sql = OrderQuerySelect();
            if (sql == null) return null;
            if (this.Sql.GetSql("Order.Order.QueryOrder.OrderPrint", ref sql1) == -1)
            {
                this.Err = "没有找到Order.Order.QueryOrder.1字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            sql = sql + " " + string.Format(sql1, InPatientNO);
            return this.myOrderQuery(sql);
        }

        /// <summary>
        /// 按照状态查询
        /// </summary>
        /// <param name="InPatientNO"></param>
        /// <returns></returns>
        public ArrayList QueryDcOrder(string InPatientNO, string Status)
        {
            #region 查询所有医嘱
            //查询所有医嘱
            //Order.Order.QueryOrder.1
            //传入：0 inpatientno
            //传出：ArrayList
            #endregion
            string sql = "", sql1 = "";
            ArrayList al = new ArrayList();
            sql = OrderQuerySelect();
            if (sql == null) return null;
            if (this.Sql.GetSql("Order.Order.QueryOrder.OrderPrintGoOn", ref sql1) == -1)
            {
                this.Err = "没有找到Order.Order.QueryOrder.OrderPrintGoOn字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            sql = sql + " " + string.Format(sql1, InPatientNO, Status);
            return this.myOrderQuery(sql);
        }
        /// 查询患者信息的select语句（无where条件）
        private string OrderQuerySelect()
        {
            #region 接口说明
            //Order.Order.QueryOrder.Select.1
            //传入：0
            //传出：sql.select
            #endregion
            string sql = "";
            if (this.Sql.GetSql("Order.Order.QueryOrder.Select.New", ref sql) == -1)
            {
                this.Err = "没有找到Order.Order.QueryOrder.Select.New字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            return sql;
        }

        /// <summary>
        /// 更新医嘱状态
        /// 为已经执行
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdateOrderStatus(string orderNo, string status)
        {
            string strSql = "";

            if (this.Sql.GetSql("Order.Update.OrderTerm.OrderPrintStatus", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, orderNo, status.ToString());
            }
            catch (Exception ex)
            {
                this.Err = "传入参数不对！Order.Update.OrderTerm.OrderPrintStatus" + ex.Message;
                this.WriteErr();
                return -1;
            }
            if (this.ExecNoQuery(strSql) <= 0) return -1;
            return 0;
        }
        //私有函数，查询医嘱信息
        private ArrayList myOrderQuery(string SQLPatient)
        {

            ArrayList al = new ArrayList();

            if (this.ExecQuery(SQLPatient) == -1) return null;
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order objOrder = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                    #region "患者信息"
                    //患者信息——  
                    //			1 住院流水号   2住院病历号     3患者科室id      4患者护理id
                    try
                    {
                        objOrder.Patient.ID = this.Reader[1].ToString();
                        objOrder.Patient.PID.PatientNO = this.Reader[2].ToString();
                        objOrder.Patient.PVisit.PatientLocation.Dept.ID = this.Reader[3].ToString();
                        objOrder.InDept.ID = this.Reader[3].ToString();
                        objOrder.Patient.PVisit.PatientLocation.NurseCell.ID = this.Reader[4].ToString();

                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得患者基本信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }
                    #endregion
                    #region "项目信息"
                    //医嘱辅助信息
                    // ——项目信息
                    //	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
                    //	       10项目类别代码 11项目类别名称  12药品规格     13药品基本剂量  14剂量单位       
                    //         15最小单位     16包装数量,     17剂型代码     18药品类别  ,   19药品性质
                    //         20零售价       21用法代码      22用法名称     23用法英文缩写  24频次代码  
                    //         25频次名称     26每次剂量      27项目总量     28计价单位      29使用天数			  
                    // 判断药品/非药品
                    //         25频次名称     26每次剂量      27项目总量     28计价单位      29使用天数			  
                    // 73 样本类型 名称
                    if (this.Reader[5].ToString() == "1")//药品
                    {
                        Neusoft.HISFC.Models.Pharmacy.Item objPharmacy = new Neusoft.HISFC.Models.Pharmacy.Item();
                        try
                        {
                            objPharmacy.ID = this.Reader[6].ToString();
                            objPharmacy.Name = this.Reader[7].ToString();
                            objPharmacy.UserCode = this.Reader[8].ToString();
                            objPharmacy.SpellCode = this.Reader[9].ToString();
                            objPharmacy.SysClass.ID = this.Reader[10].ToString();
                            //objPharmacy.SysClass.Name = this.Reader[11].ToString();
                            objPharmacy.Specs = this.Reader[12].ToString();
                            //							try
                            //							{
                            if (!this.Reader.IsDBNull(13)) objPharmacy.BaseDose = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[13].ToString());
                            //}
                            //							catch{}
                            objPharmacy.DoseUnit = this.Reader[14].ToString();
                            objPharmacy.MinUnit = this.Reader[15].ToString();
                            //try
                            //{
                            if (!this.Reader.IsDBNull(16)) objPharmacy.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[16].ToString());
                            //}
                            //catch{}
                            objPharmacy.DosageForm.ID = this.Reader[17].ToString();
                            objPharmacy.Type.ID = this.Reader[18].ToString();
                            objPharmacy.Quality.ID = this.Reader[19].ToString();
                            //try
                            //{
                            if (!this.Reader.IsDBNull(20)) objPharmacy.PriceCollection.RetailPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20].ToString());
                            //}
                            //catch{}					
                            objOrder.Usage.ID = this.Reader[21].ToString();
                            objOrder.Usage.Name = this.Reader[22].ToString();
                            objOrder.Usage.Memo = this.Reader[23].ToString();
                        }
                        catch (Exception ex)
                        {
                            this.Err = "获得医嘱项目信息出错！" + ex.Message;
                            this.WriteErr();
                            return null;
                        }
                        objOrder.Item = objPharmacy;
                    }
                    else if (this.Reader[5].ToString() == "2")//非药品
                    {
                        Neusoft.HISFC.Models.Fee.Item.Undrug objAssets = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                        try
                        {
                            objAssets.ID = this.Reader[6].ToString();
                            objAssets.Name = this.Reader[7].ToString();
                            objAssets.UserCode = this.Reader[8].ToString();
                            objAssets.SpellCode = this.Reader[9].ToString();
                            objAssets.SysClass.ID = this.Reader[10].ToString();
                            //objAssets.SysClass.Name = this.Reader[11].ToString();
                            objAssets.Specs = this.Reader[12].ToString();
                            //							try
                            //							{
                            if (!this.Reader.IsDBNull(20)) objAssets.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20].ToString());
                            //}
                            //							catch{}	
                            objAssets.PriceUnit = this.Reader[28].ToString();
                            //样本类型名称
                            objOrder.Sample.Name = this.Reader[73].ToString();
                        }
                        catch (Exception ex)
                        {
                            this.Err = "获得医嘱项目信息出错！" + ex.Message;
                            this.WriteErr();
                            return null;
                        }
                        objOrder.Item = objAssets;
                    }


                    objOrder.Frequency.ID = this.Reader[24].ToString();
                    objOrder.Frequency.Name = this.Reader[25].ToString();
                    //try
                    //{
                    if (!this.Reader.IsDBNull(26)) objOrder.DoseOnce = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[26].ToString());//}
                    //catch{}
                    //try
                    //{
                    if (!this.Reader.IsDBNull(27)) objOrder.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[27].ToString());//}
                    //catch{}
                    objOrder.Unit = this.Reader[28].ToString();
                    //try
                    //{
                    if (!this.Reader.IsDBNull(29)) objOrder.HerbalQty = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[29].ToString());//}
                    //catch{}

                    #endregion
                    #region "医嘱属性"
                    // ——医嘱属性
                    //		   30医嘱类别代码 31医嘱类别名称  32医嘱是否分解:1长期/2临时     33是否计费 
                    //		   34药房是否配药 35打印执行单    36是否需要确认   
                    try
                    {
                        objOrder.ID = this.Reader[0].ToString();
                        objOrder.ExtendFlag1 = this.Reader[78].ToString();//临时医嘱执行时间－－自定义
                        objOrder.OrderType.ID = this.Reader[30].ToString();
                        objOrder.OrderType.Name = this.Reader[31].ToString();
                        //try
                        //{
                        if (!this.Reader.IsDBNull(32)) objOrder.OrderType.IsDecompose = System.Convert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[32].ToString()));//}
                        //catch{}
                        //try
                        //{
                        if (!this.Reader.IsDBNull(33)) objOrder.OrderType.IsCharge = System.Convert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[33].ToString()));//}
                        //catch{}
                        //try
                        //{
                        if (!this.Reader.IsDBNull(34)) objOrder.OrderType.IsNeedPharmacy = System.Convert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[34].ToString()));//}
                        //catch{}
                        //try
                        //{
                        if (!this.Reader.IsDBNull(35)) objOrder.OrderType.IsPrint = System.Convert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[35].ToString()));//}

                        //是否打印过医嘱单
                        if (!this.Reader.IsDBNull(84)) objOrder.User03 = this.Reader[84].ToString();//}
                        //catch{}
                        //try
                        //{
                        if (!this.Reader.IsDBNull(36)) objOrder.OrderType.IsConfirm = System.Convert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[36].ToString()));//}


                        //catch{}
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得医嘱属性信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }
                    #endregion
                    #region "执行情况"
                    // ——执行情况
                    //		   37开立医师Id   38开立医师name  39开始时间      40结束时间     41开立科室
                    //		   42开立时间     43录入人员代码  44录入人员姓名  45审核人ID     46审核时间       
                    //		   47DC原因代码   48DC原因名称    49DC医师代码    50DC医师姓名   51Dc时间
                    //         52执行人员代码 53执行时间      54执行科室代码  55执行科室名称 
                    //		   56本次分解时间 57下次分解时间
                    try
                    {
                        objOrder.ReciptDoctor.ID = this.Reader[37].ToString();
                        objOrder.ReciptDoctor.Name = this.Reader[38].ToString();
                        //try{
                        if (!this.Reader.IsDBNull(39)) objOrder.BeginTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[39].ToString());
                        //}
                        //catch{}
                        //try{
                        if (!this.Reader.IsDBNull(40)) objOrder.EndTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[40].ToString());
                        //}
                        //catch{}
                        objOrder.ReciptDept.ID = this.Reader[41].ToString();//InDept.ID
                        //try{
                        if (!this.Reader.IsDBNull(42)) objOrder.MOTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[42].ToString());
                        //}
                        //catch{}
                        objOrder.Oper.ID = this.Reader[43].ToString();
                        objOrder.Oper.Name = this.Reader[44].ToString();
                        objOrder.Nurse.ID = this.Reader[45].ToString();
                        //try{
                        if (!this.Reader.IsDBNull(46)) objOrder.ConfirmTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[46].ToString());
                        //}
                        //catch{}
                        objOrder.DcReason.ID = this.Reader[47].ToString();
                        objOrder.DcReason.Name = this.Reader[48].ToString();
                        objOrder.DCOper.ID = this.Reader[49].ToString();
                        objOrder.DCOper.Name = this.Reader[50].ToString();
                        //try{
                        if (!this.Reader.IsDBNull(51)) objOrder.DCOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[51].ToString());
                        //}
                        //catch{}
                        objOrder.ExecOper.ID = this.Reader[52].ToString();
                        //try{
                        if (!this.Reader.IsDBNull(53)) objOrder.ExecOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[53].ToString());

                        objOrder.ExeDept.ID = this.Reader[54].ToString();
                        objOrder.ExeDept.Name = this.Reader[55].ToString();

                        objOrder.ExecOper.Dept.ID = this.Reader[54].ToString();
                        objOrder.ExecOper.Dept.Name = this.Reader[55].ToString();

                        if (!this.Reader.IsDBNull(56)) objOrder.CurMOTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[56].ToString());

                        if (!this.Reader.IsDBNull(57)) objOrder.NextMOTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[57].ToString());

                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得医嘱执行情况信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }
                    #endregion
                    #region "医嘱类型"
                    // ——医嘱类型
                    //		   58是否婴儿（1是/2否）          59发生序号  	  60组合序号     61主药标记 
                    //		   62是否附材'1'  63是否包含附材  64医嘱状态      65扣库标记     66执行标记1未执行/2已执行/3DC执行 
                    //		   67医嘱说明                     68加急标记:1普通/2加急         69排列序号
                    //         70 批注       ,       71检查部位备注    ,72 整档标记,74 取药药房编码 81 是否皮试
                    try
                    {

                        if (!this.Reader.IsDBNull(58)) objOrder.IsBaby = Neusoft.FrameWork.Function.NConvert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[58].ToString()));

                        if (!this.Reader.IsDBNull(59)) objOrder.BabyNO = this.Reader[59].ToString();

                        objOrder.Combo.ID = this.Reader[60].ToString();

                        if (!this.Reader.IsDBNull(61)) objOrder.Combo.IsMainDrug = Neusoft.FrameWork.Function.NConvert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[61].ToString()));

                        if (!this.Reader.IsDBNull(62)) objOrder.IsSubtbl = Neusoft.FrameWork.Function.NConvert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[62].ToString()));

                        if (!this.Reader.IsDBNull(63)) objOrder.IsHaveSubtbl = Neusoft.FrameWork.Function.NConvert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[63].ToString()));

                        if (!this.Reader.IsDBNull(64)) objOrder.Status = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[64].ToString());

                        if (!this.Reader.IsDBNull(65)) objOrder.IsStock = Neusoft.FrameWork.Function.NConvert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[65].ToString()));


                        if (!this.Reader.IsDBNull(66)) objOrder.ExecStatus = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[66].ToString());

                        objOrder.Note = this.Reader[67].ToString();

                        if (!this.Reader.IsDBNull(68)) objOrder.IsEmergency = Neusoft.FrameWork.Function.NConvert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[68].ToString()));

                        if (!this.Reader.IsDBNull(69)) objOrder.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[69]);

                        objOrder.Memo = this.Reader[70].ToString();
                        objOrder.CheckPartRecord = this.Reader[71].ToString();
                        objOrder.Reorder = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[72].ToString());
                        objOrder.StockDept.ID = this.Reader[74].ToString();//取药药房编码
                        try
                        {
                            if (!this.Reader.IsDBNull(75)) objOrder.IsPermission = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[75]);//患者用药知情
                        }
                        catch { }
                        objOrder.Package.ID = this.Reader[76].ToString();
                        objOrder.Package.Name = this.Reader[77].ToString();
                        objOrder.ExtendFlag2 = this.Reader[79].ToString();
                        objOrder.ExtendFlag3 = this.Reader[80].ToString();
                        try
                        {
                            if (!this.Reader.IsDBNull(81))
                                objOrder.HypoTest = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[81].ToString());//1 不需皮试 2 需皮试 3 阳 4 阴
                        }
                        catch
                        {
                            objOrder.HypoTest = 1;
                        }

                        objOrder.Frequency.Time = this.Reader[82].ToString(); //执行时间
                        objOrder.ExecDose = this.Reader[83].ToString();//特殊频次剂量
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得医嘱类型信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }
                    #endregion
                    al.Add(objOrder);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得医嘱信息出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            this.Reader.Close();
            return al;
        }
          #endregion
    }
}
