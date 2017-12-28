using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.Manager
{
    /// <summary>
    /// 科室常用项目维护
    /// </summary>
    public class DeptItem : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 获取科室常用项目信息
        /// </summary>
        /// <param name="lstItems">项目信息</param>
        /// <returns>1,成功;  -1,失败</returns>
        public int SelectItem(ref List<Neusoft.HISFC.Models.Base.DeptItem> lstItems)
        {
            string strsql = "";

            //
            // 如果是取得当前科室
            //
            if (this.Sql.GetSql("Manager.DeptItem.SelectItem.2", ref strsql) == -1)
            {
                return -1;
            }

            try
            {
                //这个地方用当前科室编号来代替
                strsql = String.Format(strsql, ((Neusoft.HISFC.Models.Base.Employee)this.Operator).Dept.ID);
            }
            catch
            {
                return -1;
            }

            if (this.ExecQuery(strsql) == -1)
            {
                return -1;
            }

            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Base.DeptItem di = new Neusoft.HISFC.Models.Base.DeptItem();
                //di.DeptCode.Name = this.Reader.IsDBNull(1) ? "" : this.Reader.GetString(1);

                //di.Dept.ID = this.Reader.IsDBNull(0) ? "" : this.Reader.GetString(0);
                //di.ItemProperty.ID = this.Reader.IsDBNull(1) ? "" : this.Reader.GetString(1);
                //di.ItemProperty.Name = this.Reader.IsDBNull(2) ? "" : this.Reader.GetString(2);
                //di.UnitFlag = this.Reader.IsDBNull(3) ? "" : this.Reader.GetString(3);
                //di.BookLocate = this.Reader.IsDBNull(4) ? "" : this.Reader.GetString(4);
                //di.BookTime = this.Reader.IsDBNull(5) ? "" : this.Reader.GetString(5);
                //di.ExecuteLocate = this.Reader.IsDBNull(6) ? "" : this.Reader.GetString(6);
                //di.ReportDate = this.Reader.IsDBNull(7) ? "" : this.Reader.GetString(7);
                //di.HurtFlag = this.Reader.IsDBNull(8) ? "" : this.Reader.GetString(8);
                //di.SelfBookFlag = this.Reader.IsDBNull(9) ? "" : this.Reader.GetString(9);
                //di.ReasonableFlag = this.Reader.IsDBNull(10) ? "" : this.Reader.GetString(10);
                //di.Speciality = this.Reader.IsDBNull(11) ? "" : this.Reader.GetString(11);
                //di.ClinicMeaning = this.Reader.IsDBNull(12) ? "" : this.Reader.GetString(12);
                //di.SampleKind = this.Reader.IsDBNull(13) ? "" : this.Reader.GetString(13);
                //di.SampleWay = this.Reader.IsDBNull(14) ? "" : this.Reader.GetString(14);
                //di.SampleUnit = this.Reader.IsDBNull(15) ? "" : this.Reader.GetString(15);
                //di.SampleQty = this.Reader.IsDBNull(16) ? 0 : this.Reader.GetDecimal(16);//decimal类型
                //di.SampleContainer = this.Reader.IsDBNull(17) ? "" : this.Reader.GetString(17);
                //di.Scope = this.Reader.IsDBNull(18) ? "" : this.Reader.GetString(18);
                //di.IsStat = this.Reader.IsDBNull(19) ? "" : this.Reader.GetString(19);
                //di.IsAutoBook = this.Reader.IsDBNull(20) ? "" : this.Reader.GetString(20);
                //di.ItemTime = this.Reader.IsDBNull(21) ? "" : this.Reader.GetString(21);
                //di.Memo = this.Reader.IsDBNull(22) ? "" : this.Reader.GetString(22);

                di.Dept.ID = (this.Reader[0] == null ? "" : this.Reader[0].ToString());
                di.ItemProperty.ID = (this.Reader[1] == null ? "" : this.Reader[1].ToString());
                di.ItemProperty.Name = (this.Reader[2] == null ? "" : this.Reader[2].ToString());
                di.UnitFlag = (this.Reader[3] == null ? "" : this.Reader[3].ToString());
                di.BookLocate = (this.Reader[4] == null ? "" : this.Reader[4].ToString());
                di.BookTime = (this.Reader[5] == null ? "" : this.Reader[5].ToString());
                di.ExecuteLocate = (this.Reader[6] == null ? "" : this.Reader[6].ToString());
                di.ReportDate = (this.Reader[7] == null ? "" : this.Reader[7].ToString());
                di.HurtFlag = (this.Reader[8] == null ? "" : this.Reader[8].ToString());
                di.SelfBookFlag = (this.Reader[9] == null ? "" : this.Reader[9].ToString());
                di.ReasonableFlag = (this.Reader[10] == null ? "" : this.Reader[10].ToString());
                di.Speciality = (this.Reader[11] == null ? "" : this.Reader[11].ToString());
                di.ClinicMeaning = (this.Reader[12] == null ? "" : this.Reader[12].ToString());
                di.SampleKind = (this.Reader[13] == null ? "" : this.Reader[13].ToString());
                di.SampleWay = (this.Reader[14] == null ? "" : this.Reader[14].ToString());
                di.SampleUnit = (this.Reader[15] == null ? "" : this.Reader[15].ToString());
                di.SampleQty = (this.Reader[16] == null ? 0 : Convert.ToDecimal(this.Reader[16]));//decimal类型
                di.SampleContainer = (this.Reader[17] == null ? "" : this.Reader[17].ToString());
                di.Scope = (this.Reader[18] == null ? "" : this.Reader[18].ToString());
                di.IsStat = (this.Reader[19] == null ? "" : this.Reader[19].ToString());
                di.IsAutoBook = (this.Reader[20] == null ? "" : this.Reader[20].ToString());
                di.ItemTime = (this.Reader[21] == null ? "" : this.Reader[21].ToString());
                di.Memo = (this.Reader[22] == null ? "" : this.Reader[22].ToString());
                di.CustomName = (this.Reader[23] == null ? "" : this.Reader[23].ToString());

                lstItems.Add(di);
            }
            this.Reader.Close();

            return 1;
        }

        /// <summary>
        /// 保存项目信息
        /// </summary>
        /// <param name="DeptItem">项目信息</param>
        /// <returns>1,成功;  -1,失败</returns>
        public int InsertItem(Neusoft.HISFC.Models.Base.DeptItem deptitem)
        {
            string dcode = ((Neusoft.HISFC.Models.Base.Employee)this.Operator).Dept.ID;
            /* insert into fin_com_deptitem (parent_code,current_code,dept_code, item_code, item_name) values (fun_get_parentcode(),fun_get_currentcode(),'{0}','{1}','{2}');
             */
            string strsql = "";
            if (this.Sql.GetSql("Manager.DeptItem.InsertItem", ref strsql) == -1)
            {
                return -1;
            }
            try
            {
                strsql = String.Format(strsql,
                                       dcode/*dcode 实际上应该用这个,现在测试3001*/,
                                       deptitem.ItemProperty.ID,
                                       deptitem.ItemProperty.Name,
                                       deptitem.UnitFlag/*.Trim().Equals("明细") ? "1" : "2"*/,
                                       deptitem.BookLocate,
                                       deptitem.BookTime,
                                       deptitem.ExecuteLocate,
                                       deptitem.ReportDate,
                                       deptitem.HurtFlag/*.Trim().Equals("有") ? "0" : "1"*/,
                                       deptitem.SelfBookFlag/*.Trim().Equals("是") ? "0" : "1"*/,
                                       deptitem.ReasonableFlag/*.Trim().Equals("需要") ? "0" : "1"*/,
                                       deptitem.Speciality,
                                       deptitem.ClinicMeaning,
                                       deptitem.SampleKind,
                                       deptitem.SampleWay,
                                       deptitem.SampleUnit,
                                       deptitem.SampleQty,/*decimal类型*/
                                       deptitem.SampleContainer,
                                       deptitem.Scope,
                                       deptitem.IsStat/*.Trim().Equals("需要") ? "0" : "1"*/,
                                       deptitem.IsAutoBook/*.Trim().Equals("需要") ? "0" : "1"*/,
                                       deptitem.ItemTime,
                                       deptitem.Memo,
                                       this.Operator.ID,
                                       deptitem.CustomName
                                       );
            }
            catch
            {
                return -1;
            }
            if (this.ExecNoQuery(strsql) <= 0)
            {
                return -1;
            }
            return 1;
        }

        public int UpdateItem(Neusoft.HISFC.Models.Base.DeptItem deptItem)
        {
            string dcode = ((Neusoft.HISFC.Models.Base.Employee)this.Operator).Dept.ID;
            string strsql = "";
            if (this.Sql.GetSql("Manager.DeptItem.UpdateItem.1", ref strsql) == -1)
            {
                return -1;
            }

            try
            {
                strsql = String.Format(strsql,
                                       deptItem.UnitFlag/*.Trim().Equals("明细") ? "1" : "2"*/,
                                       deptItem.BookLocate,
                                       deptItem.BookTime,
                                       deptItem.ExecuteLocate,
                                       deptItem.ReportDate,
                                       deptItem.HurtFlag/*.Trim().Equals("有") ? "0" : "1"*/,
                                       deptItem.SelfBookFlag/*.Trim().Equals("是") ? "0" : "1"*/,
                                       deptItem.ReasonableFlag/*.Trim().Equals("需要") ? "0" : "1"*/,
                                       deptItem.Speciality,
                                       deptItem.ClinicMeaning,
                                       deptItem.SampleKind,
                                       deptItem.SampleWay,
                                       deptItem.SampleUnit,
                                       deptItem.SampleQty,/*decimal类型*/
                                       deptItem.SampleContainer,
                                       deptItem.Scope,
                                       deptItem.IsStat/*.Trim().Equals("需要") ? "0" : "1"*/,
                                       deptItem.IsAutoBook/*.Trim().Equals("需要") ? "0" : "1"*/,
                                       deptItem.ItemTime,
                                       deptItem.Memo,
                                       this.Operator.ID,
                                       dcode/*dcode 实际上应该用这个,现在测试3001*/,
                                       deptItem.ItemProperty.ID,
                                       deptItem.ItemProperty.Name,
                                       deptItem.CustomName
                                       );
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Source;
                return -1;
            }

            if (this.ExecNoQuery(strsql) <= 0)
            {
                return -1;
            }

            return 1;
        }
        /// <summary>
        /// 获取科室常用项目信息(按类别)
        /// </summary>
        /// <param name="lstItems">项目信息</param>
        /// <returns>1,成功;  -1,失败</returns>
        public int SelectItemByUint(ref List<Neusoft.HISFC.Models.Base.DeptItem> lstItems, string UnitFlag)
        {
            string strsql = "";

            //
            // 如果是取得当前科室
            //
            if (this.Sql.GetSql("Manager.DeptItem.SelectItem.4", ref strsql) == -1)
            {
                return -1;
            }

            try
            {
                //这个地方用当前科室编号来代替
                strsql = String.Format(strsql, ((Neusoft.HISFC.Models.Base.Employee)this.Operator).Dept.ID, UnitFlag);
            }
            catch
            {
                return -1;
            }

            if (this.ExecQuery(strsql) == -1)
            {
                return -1;
            }

            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Base.DeptItem di = new Neusoft.HISFC.Models.Base.DeptItem();
                //di.DeptCode.Name = this.Reader.IsDBNull(1) ? "" : this.Reader.GetString(1);

                //di.Dept.ID = this.Reader.IsDBNull(0) ? "" : this.Reader.GetString(0);
                //di.ItemProperty.ID = this.Reader.IsDBNull(1) ? "" : this.Reader.GetString(1);
                //di.ItemProperty.Name = this.Reader.IsDBNull(2) ? "" : this.Reader.GetString(2);
                //di.UnitFlag = this.Reader.IsDBNull(3) ? "" : this.Reader.GetString(3);
                //di.BookLocate = this.Reader.IsDBNull(4) ? "" : this.Reader.GetString(4);
                //di.BookTime = this.Reader.IsDBNull(5) ? "" : this.Reader.GetString(5);
                //di.ExecuteLocate = this.Reader.IsDBNull(6) ? "" : this.Reader.GetString(6);
                //di.ReportDate = this.Reader.IsDBNull(7) ? "" : this.Reader.GetString(7);
                //di.HurtFlag = this.Reader.IsDBNull(8) ? "" : this.Reader.GetString(8);
                //di.SelfBookFlag = this.Reader.IsDBNull(9) ? "" : this.Reader.GetString(9);
                //di.ReasonableFlag = this.Reader.IsDBNull(10) ? "" : this.Reader.GetString(10);
                //di.Speciality = this.Reader.IsDBNull(11) ? "" : this.Reader.GetString(11);
                //di.ClinicMeaning = this.Reader.IsDBNull(12) ? "" : this.Reader.GetString(12);
                //di.SampleKind = this.Reader.IsDBNull(13) ? "" : this.Reader.GetString(13);
                //di.SampleWay = this.Reader.IsDBNull(14) ? "" : this.Reader.GetString(14);
                //di.SampleUnit = this.Reader.IsDBNull(15) ? "" : this.Reader.GetString(15);
                //di.SampleQty = this.Reader.IsDBNull(16) ? 0 : this.Reader.GetDecimal(16);//decimal类型
                //di.SampleContainer = this.Reader.IsDBNull(17) ? "" : this.Reader.GetString(17);
                //di.Scope = this.Reader.IsDBNull(18) ? "" : this.Reader.GetString(18);
                //di.IsStat = this.Reader.IsDBNull(19) ? "" : this.Reader.GetString(19);
                //di.IsAutoBook = this.Reader.IsDBNull(20) ? "" : this.Reader.GetString(20);
                //di.ItemTime = this.Reader.IsDBNull(21) ? "" : this.Reader.GetString(21);
                //di.Memo = this.Reader.IsDBNull(22) ? "" : this.Reader.GetString(22);

                di.Dept.ID = (this.Reader[0] == null ? "" : this.Reader[0].ToString());
                di.ItemProperty.ID = (this.Reader[1] == null ? "" : this.Reader[1].ToString());
                di.ItemProperty.Name = (this.Reader[2] == null ? "" : this.Reader[2].ToString());
                di.UnitFlag = (this.Reader[3] == null ? "" : this.Reader[3].ToString());
                di.BookLocate = (this.Reader[4] == null ? "" : this.Reader[4].ToString());
                di.BookTime = (this.Reader[5] == null ? "" : this.Reader[5].ToString());
                di.ExecuteLocate = (this.Reader[6] == null ? "" : this.Reader[6].ToString());
                di.ReportDate = (this.Reader[7] == null ? "" : this.Reader[7].ToString());
                di.HurtFlag = (this.Reader[8] == null ? "" : this.Reader[8].ToString());
                di.SelfBookFlag = (this.Reader[9] == null ? "" : this.Reader[9].ToString());
                di.ReasonableFlag = (this.Reader[10] == null ? "" : this.Reader[10].ToString());
                di.Speciality = (this.Reader[11] == null ? "" : this.Reader[11].ToString());
                di.ClinicMeaning = (this.Reader[12] == null ? "" : this.Reader[12].ToString());
                di.SampleKind = (this.Reader[13] == null ? "" : this.Reader[13].ToString());
                di.SampleWay = (this.Reader[14] == null ? "" : this.Reader[14].ToString());
                di.SampleUnit = (this.Reader[15] == null ? "" : this.Reader[15].ToString());
                di.SampleQty = (this.Reader[16] == null ? 0 : Convert.ToDecimal(this.Reader[16]));//decimal类型
                di.SampleContainer = (this.Reader[17] == null ? "" : this.Reader[17].ToString());
                di.Scope = (this.Reader[18] == null ? "" : this.Reader[18].ToString());
                di.IsStat = (this.Reader[19] == null ? "" : this.Reader[19].ToString());
                di.IsAutoBook = (this.Reader[20] == null ? "" : this.Reader[20].ToString());
                di.ItemTime = (this.Reader[21] == null ? "" : this.Reader[21].ToString());
                di.Memo = (this.Reader[22] == null ? "" : this.Reader[22].ToString());
                di.CustomName = (this.Reader[23] == null ? "" : this.Reader[23].ToString());

                lstItems.Add(di);
            }
            this.Reader.Close();

            return 1;
        }

        /// <summary>
        /// 删除一个项目
        /// </summary>
        /// <param name="deptID">科室编号</param>
        /// <param name="itemID">项目编号</param>
        /// <returns>1,成功; -1,失败</returns>
        public int DeleteItem(string deptID, string itemID)
        {
            string strsql = "";
            if (this.Sql.GetSql("Manager.DeptItem.DeleteItem", ref strsql) == -1)
            {
                return -1;
            }
            try
            {
                strsql = String.Format(strsql, deptID, itemID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Source;
                return -1;
            }

            if (this.ExecNoQuery(strsql) <= 0)
            {
                return -1;
            }
            return 1;

        }

        /// <summary>
        /// 获取科室常用项目信息
        /// </summary>
        /// <param name="deptID">部门编号</param>
        /// <returns>成功返回一个集合, 否则返回null</returns>
        public ArrayList QueryItemByDeptID(string deptID)
        {
            ArrayList alItem = new ArrayList();

            string strsql = "";
            if (this.Sql.GetSql("Manager.DeptItem.SelectItemByDeptID", ref strsql) == -1)
            {
                return null;
            }
            try
            {
                strsql = String.Format(strsql, deptID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Source;
                return null;
            }
            if (this.ExecQuery(strsql) == -1)
            {
                return null;
            }
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Base.DeptItem item = new Neusoft.HISFC.Models.Base.DeptItem();
                item.ID = this.Reader[0].ToString();
                item.Name = this.Reader[1].ToString();
                item.UserCode = this.Reader[2].ToString();
                item.SpellCode = this.Reader[3].ToString();
                item.WBCode = this.Reader[4].ToString();
				item.CustomName = this.Reader[5].ToString();
                alItem.Add(item);
            }
            this.Reader.Close();
            return alItem;
        }

        /// <summary>
        /// 获取所有科室常用项目
        /// </summary>
        /// <returns>null失败</returns>
        public ArrayList QueryItems()
        {
            string strsql = "";
            if (this.Sql.GetSql("Manager.DeptItem.QueryItems", ref strsql) == -1)
            {
                return null;
            }
            if (this.ExecQuery(strsql) == -1)
            {
                return null;
            }
            ArrayList alItems = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Base.DeptItem di = new Neusoft.HISFC.Models.Base.DeptItem();
                di.ItemProperty.ID = this.Reader[0].ToString();
                di.ItemProperty.Name = this.Reader[1].ToString();
                di.UserCode = this.Reader[2].ToString();
                di.SpellCode = this.Reader[3].ToString();
                di.WBCode = this.Reader[4].ToString();
				di.CustomName = this.Reader[5].ToString();
                alItems.Add(di);
            }
            this.Reader.Close();
            return alItems;
        }

        /// <summary>
        /// 获取所有科常用部门
        /// </summary>
        /// <returns>null失败</returns>
        public ArrayList QueryDept()
        {
            string strsql = "";
            if (this.Sql.GetSql("Manager.DeptItem.QueryDepts", ref strsql) == -1)
            {
                return null;
            }
            if (this.ExecQuery(strsql) == -1)
            {
                return null;
            }
            ArrayList alDepts = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Base.DeptItem di = new Neusoft.HISFC.Models.Base.DeptItem();
                di.Dept.ID = this.Reader[0].ToString();
                di.Dept.Name = this.Reader[1].ToString();
                di.UserCode = this.Reader[2].ToString();
                di.SpellCode = this.Reader[3].ToString();
                di.WBCode = this.Reader[4].ToString();
                alDepts.Add(di);
            }
            this.Reader.Close();
            return alDepts;
        }
        
        /// <summary>
        /// 返回所有有效的药品项目
        /// </summary>
        /// <param name="ds">返回结果</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryPhaItem(ref System.Data.DataSet ds)
        {
            string strsql = "";
            if (this.Sql.GetSql("Manager.DeptItem.QueryAllPhaItem", ref strsql) == -1)
            {
                return -1;
            }
            if (this.ExecQuery(strsql, ref ds) == -1)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 返回所有有效非药品项目
        /// </summary>
        /// <param name="ds">返回结果</param>
        /// <returns></returns>
        public int QueryUndrugItem(ref System.Data.DataSet ds)
        {
            string strsql = "";
            if (this.Sql.GetSql("Manager.DeptItem.QueryAllUndrugItem", ref strsql) == -1)
            {
                return -1;
            }
            if (this.ExecQuery(strsql, ref ds) == -1)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 返回所有有效复合项目
        /// </summary>
        /// <param name="ds">返回结果</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryComboItem(ref System.Data.DataSet ds)
        {
            string strsql = "";
            if (this.Sql.GetSql("Manager.DeptItem.QueryAllComboItem", ref strsql) == -1)
            {
                return -1;
            }
            if (this.ExecQuery(strsql, ref ds) == -1)
            {
                return -1;
            }
            return 1;
        }

        #region addby xuewj 2010-9-30 科常用维护增加单价列，调整列显示 {ED623D57-EA44-4f5b-BE41-B127215F5428}
        /// <summary>
        /// 返回所有有效的药品项目
        /// </summary>
        /// <param name="ds">返回结果</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryPhaItemNew(ref System.Data.DataSet ds)
        {
            string strsql = "";
            if (this.Sql.GetSql("Manager.DeptItem.QueryAllPhaItemNew", ref strsql) == -1)
            {
                return -1;
            }
            if (this.ExecQuery(strsql, ref ds) == -1)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 返回所有有效非药品项目
        /// </summary>
        /// <param name="ds">返回结果</param>
        /// <returns></returns>
        public int QueryUndrugItemNew(ref System.Data.DataSet ds)
        {
            string strsql = "";
            if (this.Sql.GetSql("Manager.DeptItem.QueryAllUndrugItemNew", ref strsql) == -1)
            {
                return -1;
            }
            if (this.ExecQuery(strsql, ref ds) == -1)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 返回所有有效复合项目
        /// </summary>
        /// <param name="ds">返回结果</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryComboItemNew(ref System.Data.DataSet ds)
        {
            string strsql = "";
            if (this.Sql.GetSql("Manager.DeptItem.QueryAllComboItemNew", ref strsql) == -1)
            {
                return -1;
            }
            if (this.ExecQuery(strsql, ref ds) == -1)
            {
                return -1;
            }
            return 1;
        } 
        #endregion

        #region 暂时不用

        /// <summary>
        /// 获取科室常用项目信息
        /// </summary>
        /// <param name="lstItems">项目信息</param>
        /// <param name="deptID">科室编号</param>
        /// <returns>1,成功;  -1,失败</returns>
        public int SelectItem(ref List<Neusoft.HISFC.Models.Base.DeptItem> lstItems, string deptID)
        {
            string strsql = "";

            //
            // 如果是取得当前科室
            //
            if (this.Sql.GetSql("Manager.DeptItem.SelectItem.3", ref strsql) == -1)
            {
                return -1;
            }

            try
            {
                //这个地方用当前科室编号来代替
                strsql = String.Format(strsql, deptID);
            }
            catch
            {
                return -1;
            }

            if (this.ExecQuery(strsql) == -1)
            {
                return -1;
            }

            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Base.DeptItem di = new Neusoft.HISFC.Models.Base.DeptItem();

                di.Dept.ID = (this.Reader[0] == null ? "" : this.Reader[0].ToString());
                di.ItemProperty.ID = (this.Reader[1] == null ? "" : this.Reader[1].ToString());
                di.ItemProperty.Name = (this.Reader[2] == null ? "" : this.Reader[2].ToString());
                di.UnitFlag = (this.Reader[3] == null ? "" : this.Reader[3].ToString());
                di.BookLocate = (this.Reader[4] == null ? "" : this.Reader[4].ToString());
                di.BookTime = (this.Reader[5] == null ? "" : this.Reader[5].ToString());
                di.ExecuteLocate = (this.Reader[6] == null ? "" : this.Reader[6].ToString());
                di.ReportDate = (this.Reader[7] == null ? "" : this.Reader[7].ToString());
                di.HurtFlag = (this.Reader[8] == null ? "" : this.Reader[8].ToString());
                di.SelfBookFlag = (this.Reader[9] == null ? "" : this.Reader[9].ToString());
                di.ReasonableFlag = (this.Reader[10] == null ? "" : this.Reader[10].ToString());
                di.Speciality = (this.Reader[11] == null ? "" : this.Reader[11].ToString());
                di.ClinicMeaning = (this.Reader[12] == null ? "" : this.Reader[12].ToString());
                di.SampleKind = (this.Reader[13] == null ? "" : this.Reader[13].ToString());
                di.SampleWay = (this.Reader[14] == null ? "" : this.Reader[14].ToString());
                di.SampleUnit = (this.Reader[15] == null ? "" : this.Reader[15].ToString());
                di.SampleQty = (this.Reader[16] == null ? 0 : Convert.ToDecimal(this.Reader[16]));//decimal类型
                di.SampleContainer = (this.Reader[17] == null ? "" : this.Reader[17].ToString());
                di.Scope = (this.Reader[18] == null ? "" : this.Reader[18].ToString());
                di.IsStat = (this.Reader[19] == null ? "" : this.Reader[19].ToString());
                di.IsAutoBook = (this.Reader[20] == null ? "" : this.Reader[20].ToString());
                di.ItemTime = (this.Reader[21] == null ? "" : this.Reader[21].ToString());
                di.Memo = (this.Reader[22] == null ? "" : this.Reader[22].ToString());
                di.CustomName = (this.Reader[23] == null ? "" : this.Reader[23].ToString());

                lstItems.Add(di);
            }
            this.Reader.Close();

            return 1;
        }
        
        #endregion

        #region 一直没用
        ///// <summary>
        ///// 获取当前科室常用项目信息
        ///// </summary>
        ///// <param name="lstItems">项目信息</param>
        ///// <returns>1,成功;  -1,失败</returns>
        ///// <param name="bCurrent">是否查询当前科室的项目信息</param>
        //public int SelectItem(ref List<Neusoft.HISFC.Models.Base.DeptItem> lstItems)
        //{
        //    string strsql = "";

        //    //
        //    // 如果是取得当前科室
        //    //
        //    if (this.Sql.GetSql("Manager.DeptItem.SelectItem.2", ref strsql) == -1)
        //    {
        //        return -1;
        //    }

        //    try
        //    {
        //        strsql = String.Format(strsql, ((Neusoft.HISFC.Models.Base.Employee)this.Operator).Dept.ID);
        //    }
        //    catch
        //    {
        //        return -1;
        //    }

        //    if (this.ExecQuery(strsql) == -1)
        //    {
        //        return -1;
        //    }

        //    while (this.Reader.Read())
        //    {
        //        Neusoft.HISFC.Models.Base.DeptItem di = new Neusoft.HISFC.Models.Base.DeptItem();
        //        di.DeptCode.ID = this.Reader.IsDBNull(0) ? "" : this.Reader.GetString(0);
        //        di.DeptCode.Name = this.Reader.IsDBNull(1) ? "" : this.Reader.GetString(1);
        //        di.ItemProperty.ID = this.Reader.IsDBNull(2) ? "" : this.Reader.GetString(2);
        //        di.ItemProperty.Name = this.Reader.IsDBNull(3) ? "" : this.Reader.GetString(3);

        //        di.UnitFlag = this.Reader.IsDBNull(4) ? "" : this.Reader.GetString(4);

        //        di.BookLocate = this.Reader.IsDBNull(5) ? "" : this.Reader.GetString(5);

        //        di.BookTime = this.Reader.IsDBNull(6) ? "" : this.Reader.GetString(6);

        //        di.ExecuteLocate = this.Reader.IsDBNull(7) ? "" : this.Reader.GetString(7);

        //        di.ReportDate = this.Reader.IsDBNull(8) ? "" : this.Reader.GetString(8);

        //        di.HurtFlag = this.Reader.IsDBNull(9) ? "" : this.Reader.GetString(9);

        //        di.SelfBookFlag = this.Reader.IsDBNull(10) ? "" : this.Reader.GetString(10);

        //        di.ReasonableFlag = this.Reader.IsDBNull(11) ? "" : this.Reader.GetString(11);

        //        di.Speciality = this.Reader.IsDBNull(12) ? "" : this.Reader.GetString(12);

        //        di.ClinicMeaning = this.Reader.IsDBNull(13) ? "" : this.Reader.GetString(13);

        //        di.SampleKind = this.Reader.IsDBNull(14) ? "" : this.Reader.GetString(14);

        //        di.SampleWay = this.Reader.IsDBNull(15) ? "" : this.Reader.GetString(15);

        //        di.SampleUnit = this.Reader.IsDBNull(16) ? "" : this.Reader.GetString(16);

        //        di.SampleQty = this.Reader.IsDBNull(17) ? 0 : this.Reader.GetDecimal(17);//decimal类型

        //        di.SampleContainer = this.Reader.IsDBNull(18) ? "" : this.Reader.GetString(18);

        //        di.Scope = this.Reader.IsDBNull(19) ? "" : this.Reader.GetString(19);

        //        di.IsStat = this.Reader.IsDBNull(20) ? "" : this.Reader.GetString(20);

        //        di.IsAutoBook = this.Reader.IsDBNull(21) ? "" : this.Reader.GetString(21);

        //        di.ItemTime = this.Reader.IsDBNull(22) ? "" : this.Reader.GetString(22);

        //        di.Memo = this.Reader.IsDBNull(23) ? "" : this.Reader.GetString(23);

        //        lstItems.Add(di);
        //    }
        //    this.Reader.Close();

        //    return 1;
        //}
        #endregion
    }
}