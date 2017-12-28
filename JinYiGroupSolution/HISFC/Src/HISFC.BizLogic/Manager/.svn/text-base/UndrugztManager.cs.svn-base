using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.Manager
{
    public class UndrugztManager : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UndrugztManager()
        {
        }

        /// <summary>
        /// 所有有效的组套信息
        /// </summary>
        /// <param name="lstUndrugzt">返回的数据集</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryAllValidItemzt(ref List<Neusoft.HISFC.Models.Fee.Item.Undrug> lstUndrugzt)
        {
            string strsql = "";
            if( this.Sql.GetSql("Fee.Itemzt.Info", ref strsql) ==-1)
            {
                return -1;
            }
			
			//执行当前Sql语句
			if (this.ExecQuery(strsql) == -1)
			{
				this.Err = this.Sql.Err;

				return -1;
			}

            try
            {
                //循环读取数据
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();

                    item.ID = this.Reader[0].ToString();//非药品编码 
                    item.Name = this.Reader[1].ToString(); //非药品名称 
                    item.SysClass.ID = this.Reader[2].ToString(); //系统类别
                    item.MinFee.ID = this.Reader[3].ToString();  //最小费用代码 
                    item.UserCode = this.Reader[4].ToString(); //输入码
                    item.SpellCode = this.Reader[5].ToString(); //拼音码
                    item.WBCode = this.Reader[6].ToString();    //五笔码
                    item.GBCode = this.Reader[7].ToString();    //国家编码
                    item.NationCode = this.Reader[8].ToString();//国际编码
                    item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString()); //三甲价
                    item.PriceUnit = this.Reader[10].ToString();  //计价单位
                    item.FTRate.EMCRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[11].ToString()); // 急诊加成比例
                    item.IsFamilyPlanning = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[12].ToString()); // 计划生育标记 
                    item.User01 = this.Reader[13].ToString(); //特定诊疗项目
                    item.Grade = this.Reader[14].ToString();//甲乙类标志
                    item.IsNeedConfirm = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[15].ToString());//确认标志 1 需要确认 0 不需要确认
                    item.ValidState = this.Reader[16].ToString(); //有效性标识 在用 1 停用 0 废弃 2   
                    item.Specs = this.Reader[17].ToString(); //规格
                    item.ExecDept = this.Reader[18].ToString();//执行科室
                    item.MachineNO = this.Reader[19].ToString(); //设备编号 用 | 区分 
                    item.CheckBody = this.Reader[20].ToString(); //默认检查部位或标本
                    item.OperationInfo.ID = this.Reader[21].ToString(); // 手术编码 
                    item.OperationType.ID = this.Reader[22].ToString(); // 手术分类
                    item.OperationScale.ID = this.Reader[23].ToString(); //手术规模 
                    item.IsCompareToMaterial = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[24].ToString());//是否有物资项目与之对照(1有，0没有) 
                    item.Memo = this.Reader[25].ToString(); //备注  
                    item.ChildPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[26].ToString()); //儿童价
                    item.SpecialPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[27].ToString()); //特诊价
                    item.SpecialFlag = this.Reader[28].ToString(); //省限制
                    item.SpecialFlag1 = this.Reader[29].ToString(); //市限制
                    item.SpecialFlag2 = this.Reader[30].ToString(); //自费项目
                    item.SpecialFlag3 = this.Reader[31].ToString();// 特殊检查
                    item.SpecialFlag4 = this.Reader[32].ToString();// 备用		
                    item.DiseaseType.ID = this.Reader[35].ToString(); //疾病分类
                    item.SpecialDept.ID = this.Reader[36].ToString();  //专科名称
                    item.MedicalRecord = this.Reader[37].ToString(); //  --病史及检查
                    item.CheckRequest = this.Reader[38].ToString();//--检查要求
                    item.Notice = this.Reader[39].ToString();//--  注意事项  
                    item.IsConsent = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[40].ToString());
                    item.CheckApplyDept = this.Reader[41].ToString();//检查申请单名称
                    item.IsNeedBespeak = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[42].ToString());//是否需要预约
                    item.ItemArea = this.Reader[43].ToString();//项目范围
                    item.ItemException = this.Reader[44].ToString();//项目约束

                    //单位标识(0,明细; 1,组套)[2007/01/01  xuweizhe]
                    item.UnitFlag = this.Reader.IsDBNull(45) ? "" : this.Reader.GetString(45);

                    lstUndrugzt.Add(item);
                }//循环结束

                //关闭Reader
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.Reader.Close();
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 所有有效的非药品项目
        /// </summary>
        /// <param name="dvAllItems">返回的数据集</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryAllValidItems(ref System.Data.DataView dvAllItems)
        {
            string strsql = "";
            if (this.Sql.GetSql("Fee.Itemzt.Info.AllItem", ref strsql) == -1)
            {
                return -1;
            }

            System.Data.DataSet ds = new System.Data.DataSet();
            if (this.ExecQuery(strsql, ref ds) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            dvAllItems.Table = ds.Tables[0];
            return 1;
        }

        /// <summary>
        /// 组套明细
        /// </summary>
        /// <param name="lstzt">返回的数据集</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryUnDrugztDetail(ref List<Neusoft.HISFC.Models.Fee.Item.UndrugComb> lstzt)
        {
            string strsql = "";
            if (this.Sql.GetSql("Fee.Itemzt.Info.QueryZTDetails", ref strsql) == -1)
            {
                return -1;
            }
            if (this.ExecQuery(strsql) == -1)
            {
                return -1;
            }
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Fee.Item.UndrugComb zt = new Neusoft.HISFC.Models.Fee.Item.UndrugComb();
                zt.Package.ID = this.Reader.IsDBNull(0) ? "" : this.Reader.GetString(0);
                zt.Package.Name = this.Reader.IsDBNull(1) ? "" : this.Reader.GetString(1);
                zt.ID = this.Reader.IsDBNull(2) ? "" : this.Reader.GetString(2);
                zt.Name = this.Reader.IsDBNull(3) ? "" : this.Reader.GetString(3);
                zt.SortID = this.Reader.IsDBNull(4) ? 0 : Convert.ToInt32(this.Reader.GetDecimal(4));
                zt.Qty = this.Reader.IsDBNull(5) ? 0 : this.Reader.GetDecimal(5);
                zt.ValidState = this.Reader.IsDBNull(6) ? "" : this.Reader.GetString(6);
                zt.SpellCode = this.Reader.IsDBNull(7) ? "" : this.Reader.GetString(7);
                zt.WBCode = this.Reader.IsDBNull(8) ? "" : this.Reader.GetString(8);
                zt.UserCode = this.Reader.IsDBNull(9) ? "" : this.Reader.GetString(9);

                zt.Memo = "11";//这是一个标志位,如果为11则,再操作时用update,否则用insert;

                lstzt.Add(zt);
            }
            this.Reader.Close();
            return 1;
        }

        /// <summary>
        /// 获取非药品组套明细
        /// </summary>
        /// <param name="pcode">组套编码</param>
        /// <param name="pname">组套名称</param>
        /// <param name="listzt">结果集</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryUnDrugztDetail(string pcode,ref List<Neusoft.HISFC.Models.Fee.Item.UndrugComb> listzt)
        {
            string strsql = "";
            if (this.Sql.GetSql("Fee.Itemzt.Info.QueryZTDetailsByCodeName1", ref strsql) == -1)
            {
                return -1;
            }
            try
            {
                strsql = String.Format(strsql, pcode);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

            if (this.ExecQuery(strsql) == -1)
            {
                return -1;
            }
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Fee.Item.UndrugComb zt = new Neusoft.HISFC.Models.Fee.Item.UndrugComb();
                zt.Package.ID = this.Reader.IsDBNull(0) ? "" : this.Reader.GetString(0);
                zt.Package.Name = this.Reader.IsDBNull(1) ? "" : this.Reader.GetString(1);
                zt.ID = this.Reader.IsDBNull(2) ? "" : this.Reader.GetString(2);
                zt.Name = this.Reader.IsDBNull(3) ? "" : this.Reader.GetString(3);
                zt.SortID = this.Reader.IsDBNull(4) ? 0 : Convert.ToInt32(this.Reader.GetDecimal(4));
                zt.Qty = this.Reader.IsDBNull(5) ? 0 : this.Reader.GetDecimal(5);
                zt.ValidState = this.Reader.IsDBNull(6) ? "" : this.Reader.GetString(6);
                zt.SpellCode = this.Reader.IsDBNull(7) ? "" : this.Reader.GetString(7);
                zt.WBCode = this.Reader.IsDBNull(8) ? "" : this.Reader.GetString(8);
                zt.UserCode = this.Reader.IsDBNull(9) ? "" : this.Reader.GetString(9);
                zt.Memo = "11";//这是一个标志位,如果为11则,再操作时用update,否则用insert;
                zt.Price = this.Reader.IsDBNull(10) ? 0 : Convert.ToDecimal(this.Reader.GetDecimal(10));
                zt.ChildPrice = this.Reader.IsDBNull(11) ? 0 : Convert.ToDecimal(this.Reader.GetDecimal(11));
                zt.SpecialPrice = this.Reader.IsDBNull(12) ? 0 : Convert.ToDecimal(this.Reader.GetDecimal(12));
                listzt.Add(zt);
            }
            this.Reader.Close();
            return 1;
        }

        /// <summary>
        /// 获取非药品组套明细
        /// </summary>
        /// <param name="pcode">组套编码</param>
        /// <param name="pname">组套名称</param>
        /// <param name="listzt">结果集</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryUnDrugztDetail(string pcode, string pname, ref List<Neusoft.HISFC.Models.Fee.Item.UndrugComb> listzt)
        {            
            string strsql = "";
            if (this.Sql.GetSql("Fee.Itemzt.Info.QueryZTDetailsByCodeName", ref strsql) == -1)
            {
                return -1;
            }
            try
            {
                strsql = String.Format(strsql, pcode, pname);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

            if (this.ExecQuery(strsql) == -1)
            {
                return -1;
            }
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Fee.Item.UndrugComb zt = new Neusoft.HISFC.Models.Fee.Item.UndrugComb();
                zt.Package.ID = this.Reader.IsDBNull(0) ? "" : this.Reader.GetString(0);
                zt.Package.Name = this.Reader.IsDBNull(1) ? "" : this.Reader.GetString(1);
                zt.ID = this.Reader.IsDBNull(2) ? "" : this.Reader.GetString(2);
                zt.Name = this.Reader.IsDBNull(3) ? "" : this.Reader.GetString(3);
                zt.SortID = this.Reader.IsDBNull(4) ? 0 : Convert.ToInt32(this.Reader.GetDecimal(4));
                zt.Qty = this.Reader.IsDBNull(5) ? 0 : this.Reader.GetDecimal(5);
                zt.ValidState = this.Reader.IsDBNull(6) ? "" : this.Reader.GetString(6);
                zt.SpellCode = this.Reader.IsDBNull(7) ? "" : this.Reader.GetString(7);
                zt.WBCode = this.Reader.IsDBNull(8) ? "" : this.Reader.GetString(8);
                zt.UserCode = this.Reader.IsDBNull(9) ? "" : this.Reader.GetString(9);

                zt.Memo = "11";//这是一个标志位,如果为11则,再操作时用update,否则用insert;

                listzt.Add(zt);
            }
            this.Reader.Close();
            return 1;
        }

        /// <summary>
        /// 判断项目在组套中是否存在
        /// </summary>
        /// <param name="package">组套编号</param>
        /// <param name="item">项目编号</param>
        /// <returns>true,已经使用; false,没有使用</returns>
        public bool IsUsed(string package, string item)
        {
            string strsql = "";
            if (this.Sql.GetSql("Fee.Itemzt.Info.IsUsed", ref strsql) == -1)
            {
                return true;
            }
            try
            {
                strsql = String.Format(strsql, package, item);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return true;
            }
            try
            {
                int itmp = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(strsql));
                //if (this.ExecSqlReturnOne(strsql).Trim().Equals("0"))
                if( itmp <= 0)
                {
                    return false;//没有使用,不存在
                }
            }
            catch
            {
                return true;
            }
            return true;
        }

        /// <summary>
        /// 保存组套明细
        /// </summary>
        /// <param name="lstUndrugzt">组套明细集合</param>
        /// <returns>1,成功; -1,失败</returns>
        public int SaveUndrugzt(List<Neusoft.HISFC.Models.Fee.Item.UndrugComb> lstUndrugzt)
        {
            if( lstUndrugzt.Count == 0)
            {
                return -1;
            }
            for (int i = 0, j = lstUndrugzt.Count; i < j; i++)
            {
                #region
                //insert
                //if (lstUndrugzt[i].Memo.Trim() == "")
                //{
                //    string strInsert = "";
                //    if (this.Sql.GetSql("Fee.Itemzt.Info.Insert", ref strInsert) == -1)
                //    {
                //        return -1;
                //    }
                //    try
                //    {
                //        strInsert = String.Format(strInsert,
                //                                  lstUndrugzt[i].Package.ID,
                //                                  lstUndrugzt[i].Package.Name,
                //                                  lstUndrugzt[i].ID,
                //                                  lstUndrugzt[i].Name,
                //                                  lstUndrugzt[i].SortID,
                //                                  this.Operator.ID,
                //                                  lstUndrugzt[i].SpellCode,
                //                                  lstUndrugzt[i].WBCode,
                //                                  lstUndrugzt[i].UserCode,
                //                                  lstUndrugzt[i].ValidState,
                //                                  lstUndrugzt[i].Qty);
                //    }
                //    catch (Exception ex)
                //    {
                //        this.Err = ex.Message;
                //        return -1;
                //    }
                //    if (this.ExecNoQuery(strInsert) <= 0)
                //    {
                //        return -1;
                //    }

                //}
                //else//update
                //{
                //    string strUpdate = "";
                //    if (this.Sql.GetSql("Fee.Itemzt.Info.Update", ref strUpdate) == -1)
                //    {
                //        return -1;
                //    }
                //    try
                //    {
                //        strUpdate = String.Format(strUpdate,
                //                                  lstUndrugzt[i].SortID,
                //                                  this.Operator.ID,
                //                                  lstUndrugzt[i].ValidState,
                //                                  lstUndrugzt[i].Qty,
                //                                  lstUndrugzt[i].Package.ID,
                //                                  lstUndrugzt[i].ID);
                //    }
                //    catch (Exception ex)
                //    {
                //        this.Err = ex.Message;
                //        return -1;
                //    }
                //    if (this.ExecNoQuery(strUpdate) <= 0)
                //    {
                //        return -1;
                //    }
                //}
                #endregion

                string strInsert = "";
                if (this.Sql.GetSql("Fee.Itemzt.Info.Insert", ref strInsert) == -1)
                {
                    return -1;
                }
                try
                {
                    strInsert = String.Format(strInsert,
                                              lstUndrugzt[i].Package.ID,
                                              lstUndrugzt[i].Package.Name,
                                              lstUndrugzt[i].ID,
                                              lstUndrugzt[i].Name,
                                              lstUndrugzt[i].SortID,
                                              this.Operator.ID,
                                              lstUndrugzt[i].SpellCode,
                                              lstUndrugzt[i].WBCode,
                                              lstUndrugzt[i].UserCode,
                                              lstUndrugzt[i].ValidState,
                                              lstUndrugzt[i].Qty);
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    return -1;
                }
                if (this.ExecNoQuery(strInsert) <= 0)
                {
                    string strUpdate = "";
                    if (this.Sql.GetSql("Fee.Itemzt.Info.Update", ref strUpdate) == -1)
                    {
                        return -1;
                    }
                    try
                    {
                        strUpdate = String.Format(strUpdate,
                                                  lstUndrugzt[i].SortID,
                                                  this.Operator.ID,
                                                  lstUndrugzt[i].ValidState,
                                                  lstUndrugzt[i].Qty,
                                                  lstUndrugzt[i].Package.ID,
                                                  lstUndrugzt[i].ID);
                    }
                    catch (Exception ex)
                    {
                        this.Err = ex.Message;
                        return -1;
                    }
                    if (this.ExecNoQuery(strUpdate) <= 0)
                    {
                        return -1;
                    }
                }

            }
            return 1;
        }
        /// <summary>
        /// 更新嘱套价格
        /// </summary>
        /// <param name="itemCode">编码</param>
        /// <param name="price">三甲价</param>
        /// <param name="childPrice">儿童价</param>
        /// <param name="specialPrice">特诊价</param>
        /// <returns></returns>
        public int UpdateUndrugztPrice(string itemCode, decimal price, decimal childPrice, decimal specialPrice)
        {
            string Sql = string.Empty;
            if (this.Sql.GetSql("Fee.Itemzt.UpdatePrice", ref Sql) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return -1;
            }
            try
            {
                Sql = string.Format(Sql, price, childPrice, specialPrice, itemCode);
            }
            catch
            {
                Err = "格式化SQL语句失败！";
                return -1;
            }
            return this.ExecNoQuery(Sql);
        }
    }
}
