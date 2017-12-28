using System;
using System.Collections;
using Neusoft.HISFC.Models.Pharmacy;
using System.Collections.Generic;
using Neusoft.FrameWork.Function;
using System.Data;

namespace Neusoft.HISFC.BizLogic.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品管理中常数维护]<br></br>
    /// [创 建 者: Cuip]<br></br>
    /// [创建时间: 2005-02]<br></br>
    /// <修改记录>
    ///     1、屏蔽取药科室内部无用的函数
    /// </修改记录>
    /// </summary>
    public class Constant : Neusoft.FrameWork.Management.Database
    {
        public Constant()
        {

        }

        /// <summary>
        /// 取系统药品性质列表
        /// </summary>
        /// <returns>错误返回null，正确返回Quality数组</returns>
        public ArrayList QueryConstantQuality()
        {
            return Neusoft.HISFC.Models.Pharmacy.DrugQualityEnumService.List();
        }

        #region 三级药理作用

        /// <summary>
        /// 查询三级药理作用
        /// </summary>
        /// <returns>返回三级药理作用列表数组</returns>
        public ArrayList QueryPhaFunction()
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.all", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.all字段!";
                return null;
            }
            strSQL = string.Format(strSQL);
            //执行sql语句
            this.ExecQuery(strSQL);
            ArrayList alist = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.PhaFunction myFunction;
                while (this.Reader.Read())
                {

                    myFunction = new PhaFunction();
                    myFunction.ParentNode = this.Reader[0].ToString();							//0 父节点
                    myFunction.ID = this.Reader[1].ToString();								//1节点ID
                    myFunction.Name = this.Reader[2].ToString();								//2 节点名称
                    myFunction.NodeKind = NConvert.ToInt32(this.Reader[3].ToString());            //3节点类型
                    myFunction.GradeLevel = NConvert.ToInt32(this.Reader[4].ToString());        //4 级别
                    myFunction.SpellCode = this.Reader[5].ToString();							//5 拼音码
                    myFunction.WBCode = this.Reader[6].ToString();							//6 五笔码
                    myFunction.SortID = NConvert.ToInt32(this.Reader[7].ToString());           //7 自定义码
                    myFunction.IsValid = NConvert.ToBoolean(this.Reader[8].ToString());							//8 类型
                    myFunction.Memo = this.Reader[11].ToString();								//11备注      
                    this.ProgressBarValue++;
                    alist.Add(myFunction);
                }
            }
            catch (Exception ex)
            {
                this.Err = "取药品三级药理作用失败" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return alist;
        }

        /// <summary>
        /// 查询药理作用叶子节点数据
        /// </summary>
        /// <returns>返回药理作用叶子节点数组</returns>
        public ArrayList QueryPhaFunctionLeafage()
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.all", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.all字段!";
                return null;
            }
            string strSQL1 = "";
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.Where.1", ref strSQL1) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.Where.1字段!";
                return null;
            }

            strSQL = strSQL + " " + strSQL1;

            strSQL = string.Format(strSQL);
            //执行sql语句
            this.ExecQuery(strSQL);
            ArrayList alist = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.PhaFunction myFunction;
                while (this.Reader.Read())
                {

                    myFunction = new PhaFunction();
                    myFunction.ParentNode = this.Reader[0].ToString();							//0 父节点
                    myFunction.ID = this.Reader[1].ToString();								//1节点ID
                    myFunction.Name = this.Reader[2].ToString();								//2 节点名称
                    myFunction.NodeKind = NConvert.ToInt32(this.Reader[3].ToString());            //3节点类型
                    myFunction.GradeLevel = NConvert.ToInt32(this.Reader[4].ToString());        //4 级别
                    myFunction.SpellCode = this.Reader[5].ToString();							//5 拼音码
                    myFunction.WBCode = this.Reader[6].ToString();							//6 五笔码
                    myFunction.SortID = NConvert.ToInt32(this.Reader[7].ToString());           //7 自定义码
                    myFunction.IsValid = NConvert.ToBoolean(this.Reader[8].ToString());							//8 类型
                    myFunction.Memo = this.Reader[11].ToString();								//11备注      
                    this.ProgressBarValue++;
                    alist.Add(myFunction);
                }
            }
            catch (Exception ex)
            {
                this.Err = "取药品三级药理作用失败" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return alist;
        }

        /// <summary>
        /// 根据节点编号查询三级药理作用常数表中一条记录
        /// </summary>
        /// <param name="nodecode"> 表中节点的编号</param>
        /// <returns>返回arraylist 参数 </returns>
        public ArrayList QueryFunctionByNode(string nodecode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.ONE", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.ONE字段!";
                return null;
            }
            strSQL = string.Format(strSQL, nodecode);
            //执行sql语句
            this.ExecQuery(strSQL);
            ArrayList alist = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.PhaFunction myFunction;
                while (this.Reader.Read())
                {

                    myFunction = new PhaFunction();
                    myFunction.ParentNode = this.Reader[0].ToString();							//0 父节点
                    myFunction.ID = this.Reader[1].ToString();								//1节点ID
                    myFunction.Name = this.Reader[2].ToString();								//2 节点名称
                    myFunction.NodeKind = NConvert.ToInt32(this.Reader[3].ToString());            //3节点类型
                    myFunction.GradeLevel = NConvert.ToInt32(this.Reader[4].ToString());        //4 级别
                    myFunction.SpellCode = this.Reader[5].ToString();							//5 拼音码
                    myFunction.WBCode = this.Reader[6].ToString();							//6 五笔码
                    myFunction.SortID = NConvert.ToInt32(this.Reader[7].ToString());           //7 自定义码
                    myFunction.IsValid = NConvert.ToBoolean(this.Reader[8].ToString());							//8 类型
                    myFunction.Memo = this.Reader[11].ToString();								//11备注      
                    this.ProgressBarValue++;
                    alist.Add(myFunction);
                }
            }
            catch (Exception ex)
            {
                this.Err = "取药品药理作用失败" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return alist;
        }

        /// <summary>
        /// 查询最近插入的叶子节点
        /// </summary>
        /// <returns>叶子节点数组</returns>
        public ArrayList QueryPhaFunctionNodeName()
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.GETLASTNODENAME", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.GETLASTNODENAME字段!";
                return null;
            }
            strSQL = string.Format(strSQL);
            this.ExecQuery(strSQL);//替换SQL语句中的参数。
            ArrayList alist = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.PhaFunction myFunction;
                while (this.Reader.Read())
                {

                    myFunction = new PhaFunction();
                    myFunction.ParentNode = this.Reader[0].ToString();							//0 父节点
                    myFunction.ID = this.Reader[1].ToString();								//1节点ID
                    myFunction.Name = this.Reader[2].ToString();								//2 节点名   
                    this.ProgressBarValue++;
                    alist.Add(myFunction);
                }
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Constant.GetComPhaFunction.GETLASTNODENAME:" + ex.Message;
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return alist;
        }

        /// <summary>
        /// 根据节点编号查询药理作用常数表中一条记录 
        /// </summary>
        /// <param name="Pnodecode">表中节点的编号</param>
        /// <returns>返回叶子节点数组</returns>
        public ArrayList QueryFunctionByParentNode(string Pnodecode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.BYPARENTNODE", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.BYPARENTNODE 字段!";
                return null;
            }
            strSQL = string.Format(strSQL, Pnodecode);
            //执行sql语句
            this.ExecQuery(strSQL);
            ArrayList alist = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.PhaFunction myFunction;
                while (this.Reader.Read())
                {

                    myFunction = new PhaFunction();
                    myFunction.ParentNode = this.Reader[0].ToString();							//0 父节点
                    myFunction.ID = this.Reader[1].ToString();								//1节点ID
                    myFunction.Name = this.Reader[2].ToString();								//2 节点名称
                    myFunction.NodeKind = NConvert.ToInt32(this.Reader[3].ToString());            //3节点类型
                    myFunction.GradeLevel = NConvert.ToInt32(this.Reader[4].ToString());        //4 级别
                    myFunction.SpellCode = this.Reader[5].ToString();							//5 拼音码
                    myFunction.WBCode = this.Reader[6].ToString();							//6 五笔码
                    myFunction.SortID = NConvert.ToInt32(this.Reader[7].ToString());           //7 自定义码
                    myFunction.IsValid = NConvert.ToBoolean(this.Reader[8].ToString());							//8 类型
                    myFunction.Memo = this.Reader[11].ToString();								//11备注      
                    this.ProgressBarValue++;
                    alist.Add(myFunction);
                }
            }
            catch (Exception ex)
            {
                this.Err = "取药品药理作用值失败" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            //返回数组
            return alist;
        }

        /// <summary>
        /// 根据不同等级获取药理作用信息   {6E41A9CD-AEDC-4aae-8E46-1F312F0FA4C6}
        /// </summary>
        /// <param name="functionLevel">药理作用等级</param>
        /// <returns>成功返回药理作用</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.PhaFunction> QueryPhaFunctionByLevel(int functionLevel)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql( "Pharmacy.Constant.GetComPhaFunction", ref strSQL ) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction 字段!";
                return null;
            }
            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql( "Pharmacy.Constant.GetComPhaFunction.ByLevel", ref strWhere ) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.ByLevel字段!";
                return null;
            }

            strSQL = string.Format( strSQL + strWhere, functionLevel );

            //返回数组
            return this.ExecSqlForFunctionData( strSQL );
        }

        /// <summary>
        /// 更新节点类别
        /// </summary>
        ///<param name="NodeCode"> 节点编码</param>
        /// <param name="NodeKind">节点类别</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateFunctionnNodekind(string NodeCode, int NodeKind)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.UPDATEPARENTNODEKIND", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.UPDATEPARENTNODEKIND字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, NodeCode, NodeKind);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Constant.GetComPhaFunction.UPDATEPARENTNODEKIND:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新节点名称
        /// </summary>
        ///<param name="NodeCode">节点编码</param>
        /// <param name="NodeName">节点名称</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateFunctionnNodeName(string NodeCode, string NodeName)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.UPDATENODENAME", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.UPDATENODENAME字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, NodeCode, NodeName);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Constant.GetComPhaFunction.UPDATENODENAME:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新三级药理作用常数表中一条记录
        /// </summary>
        /// <param name="FunConstant">三级药理作用扩展属性类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateFunction(Neusoft.HISFC.Models.Pharmacy.PhaFunction FunConstant)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.UPDATE", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.UPDATE字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetFunConstant(FunConstant);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Constant.GetComPhaFunction.UPDATE:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 插入三级药理作用常数表中一条记录
        /// </summary>
        /// <param name="FunConstant">三级药理作用扩展属性类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertFunction(Neusoft.HISFC.Models.Pharmacy.PhaFunction FunConstant)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.INSERT", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.INSERT字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetFunConstant(FunConstant);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Constant.GetComPhaFunction.INSERT:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除三级药理作用常数表中一条记录
        /// </summary>
        /// <param name="ID">三级药理作用节点名称</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int DeleteFunction(string ID)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.DELETE", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.DELETE字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, ID);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Constant.GetComPhaFunction.DELETE:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 执行Sql语句获取 药理作用信息集合   {6E41A9CD-AEDC-4aae-8E46-1F312F0FA4C6}
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <returns>成功返回药理作用信息集合 失败返回null</returns>
        private List<Neusoft.HISFC.Models.Pharmacy.PhaFunction> ExecSqlForFunctionData(string strSql)
        {
            //执行sql语句
            if (this.ExecQuery( strSql ) == -1)
            {
                return null;
            }
            List<Neusoft.HISFC.Models.Pharmacy.PhaFunction> alist = new List<Neusoft.HISFC.Models.Pharmacy.PhaFunction>();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.PhaFunction myFunction;
                while (this.Reader.Read())
                {
                    myFunction = new PhaFunction();

                    myFunction.ParentNode = this.Reader[0].ToString();							//0 父节点
                    myFunction.ID = this.Reader[1].ToString();								    //1节点ID
                    myFunction.Name = this.Reader[2].ToString();								//2 节点名称
                    myFunction.NodeKind = NConvert.ToInt32( this.Reader[3].ToString() );          //3节点类型
                    myFunction.GradeLevel = NConvert.ToInt32( this.Reader[4].ToString() );        //4 级别
                    myFunction.SpellCode = this.Reader[5].ToString();							//5 拼音码
                    myFunction.WBCode = this.Reader[6].ToString();							    //6 五笔码
                    myFunction.SortID = NConvert.ToInt32( this.Reader[7].ToString() );            //7 自定义码
                    myFunction.IsValid = NConvert.ToBoolean( this.Reader[8].ToString() );			//8 类型
                    myFunction.Memo = this.Reader[11].ToString();								//11备注   

                    alist.Add( myFunction );
                }
            }
            catch (Exception ex)
            {
                this.Err = "取药品药理作用值失败" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return alist;
        }

        /// <summary>
        /// 获得update或者insert三级药理作用表的传入参数数组
        /// </summary>
        /// <param name="FunConstant">三级药理作用常数实体</param>
        /// <returns>字符串数组</returns>
        /// 
        public int SetFunction(Neusoft.HISFC.Models.Pharmacy.PhaFunction FunConstant, string ifInUpDel)
        {
            int parm = 0;
            //执行更新操作
            if (ifInUpDel == "UPDATE")
            {
                parm = this.UpdateFunction(FunConstant);   //更新操作 
                this.UpdateFunctionnNodekind(FunConstant.ParentNode, 1);
            }
            if (ifInUpDel == "DELETE")
            {
                string pnode;
                Neusoft.HISFC.Models.Pharmacy.PhaFunction functin = (Neusoft.HISFC.Models.Pharmacy.PhaFunction)this.QueryFunctionByNode(FunConstant.ID)[0];//找出父节点
                pnode = functin.ParentNode;
                int i;
                i = this.QueryFunctionByParentNode(pnode).Count;
                if (i >= 2)//大于等于2则删除后还有节点
                {
                    this.UpdateFunctionnNodekind(FunConstant.ParentNode, 1);
                }
                else
                {
                    this.UpdateFunctionnNodekind(FunConstant.ParentNode, 0);//<2则没有节点
                }
                parm = this.DeleteFunction(FunConstant.ID);//删除操作

            }
            if (ifInUpDel == "INSERT")
            {
                parm = this.InsertFunction(FunConstant);    //插入操作
                this.UpdateFunctionnNodekind(FunConstant.ParentNode, 1);
            }

            return parm;
        }

        /// <summary>
        /// 根据实体类获取参数数组
        /// </summary>
        /// <param name="FunConstant"></param>
        /// <returns></returns>
        private string[] myGetFunConstant(Neusoft.HISFC.Models.Pharmacy.PhaFunction FunConstant)
        {
            string[] strParm ={   
								 FunConstant.ID,						 //0 节点编码
								 FunConstant.ParentNode,                 //1 父节点
								 FunConstant.Name,                       //2 节点名称
								 FunConstant.NodeKind.ToString(),        //3 nodekind (未用)
								 FunConstant.GradeLevel.ToString(),       //4 节点级别 gradecode(未用)
								 FunConstant.SpellCode,                 //5 五笔
								 FunConstant.WBCode,                    //6拼音
								 FunConstant.SortID.ToString(),          //7排序
								 NConvert.ToInt32(FunConstant.IsValid).ToString(),                 //8有效标志
								 this.Operator.ID,		                 //9 操作员
								 FunConstant.Oper.OperTime.ToString(),        //10操作时间
								 FunConstant.Memo                        //备注
							 };
            return strParm;
        }
        
        /// <summary>
        /// 获取药理作用所属药品列表 by Sunjh 2009-6-2 {B11FB211-56F7-418e-A415-4B07617A0510}
        /// </summary>
        /// <param name="functionID">药理作用代码</param>
        /// <returns>成功 药品列表 失败 null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryItemListByFunctionID(string functionID, int functionLevl)
        {
            string sqlStr = "";

            if (this.Sql.GetSql("Pharmacy.Constant.QueryItemListByFunction", ref sqlStr) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryItemListByFunction字段!";
                return null;
            }

            sqlStr = string.Format(sqlStr, functionID, functionLevl);

            return this.myGetItemFunction(sqlStr);
        }

        /// <summary>
        /// 取药品部分基本信息列表 by Sunjh 2009-6-2 {B11FB211-56F7-418e-A415-4B07617A0510}
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>成功返回药品对象数组 失败返回null</returns>
        private List<Neusoft.HISFC.Models.Pharmacy.Item> myGetItemFunction(string sqlStr)
        {
            List<Neusoft.HISFC.Models.Pharmacy.Item> al = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
            if (this.ExecQuery(sqlStr) == -1)
            {
                return null;
            }

            try
            {
                Neusoft.HISFC.Models.Pharmacy.Item Item; //返回数组中的药品信息类

                while (this.Reader.Read())
                {
                    Item = new Neusoft.HISFC.Models.Pharmacy.Item();

                    Item.ID = this.Reader[0].ToString();                                  //0  药品编码
                    Item.Name = this.Reader[1].ToString();                                //1  商品名称
                    Item.NameCollection.RegularName = this.Reader[2].ToString();         //9  药品通用名
                    Item.PackQty = NConvert.ToDecimal(this.Reader[3].ToString());         //5  包装数量
                    Item.Specs = this.Reader[4].ToString();                               //6  规格
                    Item.SysClass.ID = this.Reader[5].ToString();                         //7  系统类别编码
                    Item.MinFee.ID = this.Reader[6].ToString();                           //8  最小费用代码
                    Item.PackUnit = this.Reader[7].ToString();                           //21 包装单位
                    Item.MinUnit = this.Reader[8].ToString();                            //22 最小单位
                    Item.Type.ID = this.Reader[9].ToString();                            //26 药品类别编码
                    Item.Quality.ID = this.Reader[10].ToString();                         //27 药品性质编码
                    Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[11].ToString());    //28 零售价
                    Item.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(NConvert.ToInt32(this.Reader[12]));
                    Item.UserCode = this.Reader[13].ToString();                           //4  自定义码
                    Item.NameCollection.EnglishName = this.Reader[14].ToString();        //16 英文商品名        
                    Item.PhyFunction1.ID = this.Reader[15].ToString();
                    Item.PhyFunction2.ID = this.Reader[16].ToString();
                    Item.PhyFunction3.ID = this.Reader[17].ToString();


                    al.Add(Item);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得药品基本信息时，执行SQL语句出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return al;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        #endregion

        #region 供货公司

          /// <summary>
        /// 根据类型查询药品公司（生产厂家或者供货公司）
        /// </summary>
        /// <param name="type">类型：0生产厂家，1供货公司</param>
        /// <param name="isValid">是否仅检索有效公司</param>
        /// <returns>错误返回null</returns>
        public ArrayList QueryCompany(string type,bool isValid)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetCompany", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetCompany字段!";
                return null;
            }

            if (isValid)
            {
                strSQL = string.Format(strSQL, type, "1");
            }
            else
            {
                strSQL = string.Format(strSQL, type, "A");
            }

            //执行sql语句
            this.ExecQuery(strSQL);
            ArrayList al = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.Company company;
                while (this.Reader.Read())
                {
                    company = new Company();
                    company.ID = this.Reader[0].ToString();             //0 公司编码
                    company.Name = this.Reader[1].ToString();             //1 公司名称
                    company.RelationCollection.Address = this.Reader[2].ToString();         //2 地址
                    company.RelationCollection.Relative = this.Reader[3].ToString();        //3 联系方式
                    company.GMPInfo = this.Reader[4].ToString();         //4 GMP信息
                    company.GSPInfo = this.Reader[5].ToString();         //5 GSP信息
                    company.SpellCode = this.Reader[6].ToString();       //6 拼音码
                    company.WBCode = this.Reader[7].ToString();          //7 五笔码
                    company.UserCode = this.Reader[8].ToString();        //8 自定义码
                    company.Type = this.Reader[9].ToString();            //9 类型
                    company.OpenBank = this.Reader[10].ToString();       //10 开户银行
                    company.OpenAccounts = this.Reader[11].ToString();   //11 开户帐号
                    company.ActualRate = NConvert.ToDecimal(this.Reader[12].ToString());//12 加价率
                    company.Memo = this.Reader[13].ToString();           //13备注      
                    company.IsValid = NConvert.ToBoolean(this.Reader[16].ToString());
                    this.ProgressBarValue++;
                    al.Add(company);
                }
            }
            catch (Exception ex)
            {
                this.Err = "取药品公司时出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return al;
        }

        /// <summary>
        /// 根据类型查询药品公司（生产厂家或者供货公司）
        /// </summary>
        /// <param name="type">类型：0生产厂家，1供货公司</param>
        /// <returns>错误返回null</returns>
        public ArrayList QueryCompany(string type)
        {
           return this.QueryCompany(type, true);
        }


        /// <summary>
        /// 根据供货公司编码获取供货公司实体
        /// </summary>
        /// <param name="companyID">供货公司编码</param>
        /// <returns>成功返回供货公司实体 失败返回null</returns>
        public Company QueryCompanyByCompanyID(string companyID)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetCompanyByID", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetCompanyByID字段!";
                return null;
            }

            strSQL = string.Format(strSQL, companyID);
            //执行sql语句
            this.ExecQuery(strSQL);
            try
            {
                Neusoft.HISFC.Models.Pharmacy.Company company = new Company();
                if (this.Reader.Read())
                {
                    company.ID = this.Reader[0].ToString();             //0 公司编码
                    company.Name = this.Reader[1].ToString();             //1 公司名称
                    company.RelationCollection.Address = this.Reader[2].ToString();         //2 地址
                    company.RelationCollection.Relative = this.Reader[3].ToString();        //3 联系方式
                    company.GMPInfo = this.Reader[4].ToString();         //4 GMP信息
                    company.GSPInfo = this.Reader[5].ToString();         //5 GSP信息
                    company.SpellCode = this.Reader[6].ToString();       //6 拼音码
                    company.WBCode = this.Reader[7].ToString();          //7 五笔码
                    company.UserCode = this.Reader[8].ToString();        //8 自定义码
                    company.Type = this.Reader[9].ToString();            //9 类型
                    company.OpenBank = this.Reader[10].ToString();       //10 开户银行
                    company.OpenAccounts = this.Reader[11].ToString();   //11 开户帐号
                    company.ActualRate = NConvert.ToDecimal(this.Reader[12].ToString());//12 加价率
                    company.Memo = this.Reader[13].ToString();           //13备注   
                    company.IsValid = NConvert.ToBoolean(this.Reader[16].ToString());
                }

                if (company.Name == "")
                {
                    this.Err = "供货公司不存在 编码：" + companyID;
                    return null;
                }

                return company;
            }
            catch (Exception ex)
            {
                this.Err = "取药品公司时出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

        }


        /// <summary>
        /// 更新公司信息，以公司编码为主键
        /// </summary>
        /// <param name="company">公司信息</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateCompany(Neusoft.HISFC.Models.Pharmacy.Company company)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.UpdateCompany", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.UpdateCompany字段!";
                return -1;
            }

            try
            {
                string[] strParm = myGetParmItem(company);  //取参数列表
                strSQL = string.Format(strSQL, strParm);       //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            //执行sql语句
            return this.ExecNoQuery(strSQL);
        }


        /// <summary>
        /// 向公司表中插入一条记录，公司编码采用oracle中的序列号
        /// </summary>
        /// <param name="company">公司信息</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertCompany(Neusoft.HISFC.Models.Pharmacy.Company company)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.InsertCompany", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.InsertCompany字段!";
                return -1;
            }

            try
            {
                //取流水号
                company.ID = this.GetSequence("Pharmacy.Constant.GetNewCompanyID");
                if (company.ID == null) return -1;

                string[] strParm = myGetParmItem(company);  //取参数列表
                strSQL = string.Format(strSQL, strParm);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }


        /// <summary>
        /// 保存公司数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
        /// </summary>
        /// <param name="company">公司实体</param>
        /// <returns>1成功 -1失败</returns>
        public int SetCompany(Neusoft.HISFC.Models.Pharmacy.Company company)
        {
            int parm;
            //执行更新操作
            parm = UpdateCompany(company);

            //如果没有找到可以更新的数据，则插入一条新记录
            if (parm == 0)
            {
                parm = InsertCompany(company);
            }
            return parm;
        }


        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="ID">药品编码</param>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int DeleteCompany(string ID)
        {
            string strSQL = ""; //根据药品编码删除某一药品信息的DELETE语句
            if (this.Sql.GetSql("Pharmacy.Constant.DeleteCompany", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DeleteCompany字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, ID);
            }
            catch
            {
                this.Err = "传入参数不对！Pharmacy.Constant.DeleteCompany";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }


        /// <summary>
        /// 获得update或者insert公司表的传入参数数组
        /// </summary>
        /// <param name="company">公司信息</param>
        /// <returns>参数数组</returns>
        private string[] myGetParmItem(Neusoft.HISFC.Models.Pharmacy.Company company)
        {

            string[] strParm ={   
								 company.ID,          //0 公司编码
								 company.Name,        //1 公司名称
								 company.RelationCollection.Address,     //2 地址
								 company.RelationCollection.Relative,    //3 联系方式
								 company.GMPInfo,     //4 GMP信息
								 company.GSPInfo,     //5 GSP信息
								 company.SpellCode,   //6 拼音码
								 company.WBCode,      //7 五笔码
								 company.UserCode,    //8 自定义码
								 company.Type,        //9 类型
								 company.OpenBank,    //10 开户银行
								 company.OpenAccounts,//11 开户帐号
								 company.ActualRate.ToString(),  //12 加价率
								 company.Memo,        //13 备注
								 this.Operator.ID,     //14 操作员
                                 NConvert.ToInt32(company.IsValid).ToString()
							 };
            return strParm;
        }

        #endregion

        #region 取药科室
        /// <summary>
        /// 根据药房药库编码获得取药科室名称
        /// </summary>
        /// <param name="ID">科室编码</param>
        /// <returns>neuObject数组，取药科室编号，取药科室名称，备注，操作员，操作时间</returns>
        public ArrayList QueryReciveDrugDept(string ID)
        {
            string strSQL = "";  //取某一取药科室名称获得可以取药的药房名称列表的SQL语句
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDrugRoomCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDrugRoomCode字段!";
                return null;
            }

            strSQL = string.Format(strSQL, ID);
            //根据SQL语句取数组并返回数组
            ArrayList arrayObject = new ArrayList();

            this.ProgressBarText = "正在检索取药科室名称信息...";
            this.ProgressBarValue = 0;

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "检索取药科室名称列表时出错：" + this.Err;
                return null;
            }
            try
            {
                //	{取药科室编号,取药科室名称,操作员编号,操作员姓名,操作日期,备注,rowid}
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                while (this.Reader.Read())
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();					//取药科室编号
                    obj.Name = this.Reader[1].ToString();				//取药科室名称
                    obj.Memo = this.Reader[2].ToString();				//备注
                    obj.User01 = this.Reader[3].ToString();				//开始时间
                    obj.User02 = this.Reader[4].ToString();				//结束时间
                    obj.User03 = this.Reader[5].ToString();				//药品类型
                    this.ProgressBarValue++;
                    arrayObject.Add(obj);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "取药药房名称列表时，执行SQL语句出错！myGetDrugRoomCode" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            this.ProgressBarValue = -1;
            return arrayObject;
        }


        /// <summary>
        /// 根据病区编码、药品类型获取发药科室
        /// </summary>
        /// <param name="roomCode">取药病区</param>
        /// <param name="drugType">药品类型</param>
        /// <returns>成功返回取药科室数组(ID 编码 Name 名称) 失败返回null</returns>
        public ArrayList QueryReciveDrugDept(string roomCode, string drugType)
        {
            string strSQL = "";
            ArrayList arrayObject = new ArrayList();
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDeptCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDeptCode字段!";
                return null;
            }

            strSQL = string.Format(strSQL, roomCode, drugType);
            //根据SQL语句取数组并返回数组

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获取发药药房出错：" + this.Err;
                return null;
            }
            try
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                while (this.Reader.Read())
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();					//取药科室编号
                    obj.Name = this.Reader[1].ToString();				//取药科室名称
                    arrayObject.Add(obj);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "取药药房名称列表时，执行SQL语句出错！myGetDrugRoomCode" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return arrayObject;
        }

        /// <summary>
        /// 根据病区编码、药品类型获取发药科室
        /// </summary>
        /// <param name="roomCode">取药病区</param>
        /// <param name="drugType">药品类型</param>
        /// <returns>成功返回取药科室数组(ID 编码 Name 名称) 失败返回null</returns>
        public ArrayList QueryReciveDrugDeptForClinicalPath(string roomCode, string drugType)
        {
            string strSQL = "";
            ArrayList arrayObject = new ArrayList();
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDeptCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDeptCode字段!";
                return null;
            }

            strSQL = string.Format(strSQL, roomCode, drugType);
            //根据SQL语句取数组并返回数组

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获取发药药房出错：" + this.Err;
                return null;
            }
            try
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                while (this.Reader.Read())
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();					//取药科室编号
                    obj.Name = this.Reader[1].ToString();				//取药科室名称
                    obj.Memo = this.Reader[3].ToString();//发药类别
                    arrayObject.Add(obj);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "取药药房名称列表时，执行SQL语句出错！myGetDrugRoomCode" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return arrayObject;
        }

        #region addby xuewj 2010-10-10 增加执行科室/发药药房显示 {313866E8-C672-44bd-9635-E3A3397A53EA}
        /// <summary>
        /// 根据病区编码获取发药科室
        /// </summary>
        /// <param name="roomCode">取药病区</param>
        /// <returns>成功返回取药科室数组(ID 编码 Name 名称) 失败返回null</returns>
        public ArrayList QueryReciveDrugDeptNew(string roomCode)
        {
            string strSQL = "";
            ArrayList arrayObject = new ArrayList();
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDeptCodeNew", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDeptCodeNew字段!";
                return null;
            }

            strSQL = string.Format(strSQL, roomCode);
            //根据SQL语句取数组并返回数组

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获取发药药房出错：" + this.Err;
                return null;
            }
            try
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                while (this.Reader.Read())
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();					//取药科室编号
                    obj.Name = this.Reader[1].ToString();				//取药科室名称
                    arrayObject.Add(obj);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "取药药房名称列表时，执行SQL语句出错！myGetDrugRoomCode" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return arrayObject;
        } 
        #endregion

        /// <summary>
        /// 根据病区编码、药品类型获取发药科室
        /// </summary>
        /// <param name="deptCode">取药病区</param>
        /// <param name="drugType">药品类型</param>
        /// <returns>成功返回取药科室信息(ID 编码 Name 名称) 失败返回null</returns>
        public List<Neusoft.FrameWork.Models.NeuObject> GetRecipeDrugDept(string deptCode, string drugType)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDeptCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDeptCode字段!";
                return null;
            }

            strSQL = string.Format(strSQL, deptCode, drugType);
            //根据SQL语句取数组并返回数组

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获取发药药房出错：" + this.Err;
                return null;
            }

            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            List<Neusoft.FrameWork.Models.NeuObject> alStockDept = new List<Neusoft.FrameWork.Models.NeuObject>();
            try
            {                
                while (this.Reader.Read())
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();					//发药科室编号
                    obj.Name = this.Reader[1].ToString();				//发药科室名称

                    alStockDept.Add(obj);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "取药药房名称列表时，执行SQL语句出错！myGetDrugRoomCode" + ex.Message;
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return alStockDept;
        }


        /// <summary>
        /// 数据提交筛选（插入、更新、删除）
        /// </summary>
        /// <param name="drugRoomList">科室列表</param>
        /// <param name="i">操作标志：0插入1删除2更新</param>
        [System.Obsolete("屏蔽无用函数",true)]
        public void DrugRoomControl(ArrayList drugRoomList, int i)
        {
            try
            {
                switch (i)
                {
                    case 0:
                        foreach (Neusoft.FrameWork.Models.NeuObject obj in drugRoomList)
                        {
                            this.InsertDrugRoom(obj);			//插入数据
                        }
                        break;
                    case 1:
                        foreach (Neusoft.FrameWork.Models.NeuObject obj in drugRoomList)
                        {
                            this.DelSpeDrugRoom(obj.User03);	//删除数据
                        }
                        break;
                    case 2:
                        foreach (Neusoft.FrameWork.Models.NeuObject obj in drugRoomList)
                        {
                            this.UpdateDrugRoom(obj);			//更新数据
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                this.Err = "数据保存出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
            }
        }


        /// <summary>
        /// 插入取药科室编号
        /// </summary>
        /// <param name="obj">科室实体</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertDrugRoom(Neusoft.FrameWork.Models.NeuObject obj)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.InsertDrugRoom", ref strSQL) == -1) return -1;
            try
            {
                //
                if (obj.ID == null) return -1;
                //替换SQL语句中的参数。
                strSQL = string.Format(strSQL,
                    obj.ID,				//药房药库编码
                    obj.Name,			//取药科室编码
                    this.Operator.ID,	//操作员
                    obj.Memo,			//备注
                    obj.User03,			//药品类型
                    obj.User01,			//开始时间
                    obj.User02);		//结束时间
            }
            catch (Exception ex)
            {
                this.Err = "数据增加时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }


        /// <summary>
        /// 删除指定取药科室编号
        /// </summary>
        /// <param name="rowid">rowid</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        [System.Obsolete("屏蔽无用函数", true)]
        public int DelSpeDrugRoom(string rowid)
        {
            string strSQL = "";
            //根据rowid删除某一条取药科室的DELETE语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelSpeDrugRoom", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.Constant.DelSpeDrugRoom";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, rowid);
            }
            catch
            {
                this.Err = "数据删除出错！Pharmacy.Constant.DelSpeDrugRoom";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }


        /// <summary>
        /// 删除某药房/药库下所有取药科室
        /// </summary>
        /// <param name="ID">取药科室编号</param>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int DelAllDrugRoom(string ID)
        {
            string strSQL = "";
            //根据药房/药库编号删除取药科室的DELETE语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelAllDrugRoom", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.Constant.DelAllDrugRoom";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, ID);
            }
            catch
            {
                this.Err = "数据删除出错！Pharmacy.Constant.DelAllDrugRoom";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }


        /// <summary>
        /// 更新取药科室信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        [System.Obsolete("屏蔽无用函数", true)]
        public int UpdateDrugRoom(Neusoft.FrameWork.Models.NeuObject obj)
        {
            string strSQL = "";
            //更新取药科室信息
            if (this.Sql.GetSql("Pharmacy.Constant.UpdateDrugRoom", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.Constant.UpdateDrugRoom";
                return -1;
            }
            if (obj.ID == null) return -1;
            string[] strParm = { obj.User03, obj.ID, obj.Name, this.Operator.ID, obj.Memo, obj.User01, obj.User02 };  //取参数列表
            try
            {
                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新出库记录的SQl参数赋值时出错！Pharmacy.Constant.UpdateDrugRoom" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        #endregion

        #region 科室常数  {59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 增加入出库单号维护

        /// <summary>
        /// 根据科室编码取一条科室常数信息
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns>科室常数</returns>
        public Neusoft.HISFC.Models.Pharmacy.DeptConstant QueryDeptConstant(string deptCode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDeptConstant", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDeptConstant字段!";
                return null;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDeptConstant.Where", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDeptConstant.Where字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, deptCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Constant.GetDeptConstant.Where:" + ex.Message;
                return null;
            }

            //取科室常数
            ArrayList al = this.myGetDeptConstant(strSQL);
            if (al == null)
                return null;

            if (al.Count == 0)
                return new Neusoft.HISFC.Models.Pharmacy.DeptConstant();

            return al[0] as Neusoft.HISFC.Models.Pharmacy.DeptConstant;
        }

        /// <summary>
        /// 取科室常数列表
        /// </summary>
        /// <returns>科室常数数组，出错返回null</returns>
        public ArrayList QueryDeptConstantList()
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDeptConstant", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDeptConstant字段!";
                return null;
            }

            //取科室常数数据
            return this.myGetDeptConstant(strSQL);
        }

        /// <summary>
        /// 是否按批号管理库存
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public bool IsManageBatch(string deptCode)
        {
            //取科室常数实体
            Neusoft.HISFC.Models.Pharmacy.DeptConstant constant = QueryDeptConstant(deptCode);
            if (constant == null)
                //出错返回false
                return false;
            else
                //返回是否按批号管理标记
                return constant.IsBatch;
        }

        /// <summary>
        /// 是否按批号管理库存
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public bool IsManageStore(string deptCode)
        {
            //取科室常数实体
            Neusoft.HISFC.Models.Pharmacy.DeptConstant constant = QueryDeptConstant(deptCode);
            if (constant == null)
                //出错返回false
                return false;
            else
                //返回是否按批号管理标记
                return constant.IsStore;
        }

        /// <summary>
        /// 向科室常数表中插入一条记录
        /// </summary>
        /// <param name="DeptConstant">科室扩展属性类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertDeptConstant(Neusoft.HISFC.Models.Pharmacy.DeptConstant DeptConstant)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.InsertDeptConstant", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.InsertDeptConstant字段!";
                return -1;
            }
            try
            {
                //取流水号
                ///DeptConstant.ID = this.GetSequence("Pharmacy.Constant.GetConstantID");
                //if (DeptConstant.ID == null) return -1;

                string[] strParm = myGetParmDeptConstant(DeptConstant);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Constant.InsertDeptConstant:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新科室常数表中一条记录
        /// </summary>
        /// <param name="DeptConstant">科室扩展属性类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateDeptConstant(Neusoft.HISFC.Models.Pharmacy.DeptConstant DeptConstant)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.UpdateDeptConstant", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.UpdateDeptConstant字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetParmDeptConstant(DeptConstant);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Constant.UpdateDeptConstant:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除科室常数表中一条记录
        /// </summary>
        /// <param name="ID">流水号</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int DeleteDeptConstant(string ID)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.DeleteDeptConstant", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DeleteDeptConstant字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, ID);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Constant.DeleteDeptConstant:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 保存人员属性变动数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
        /// </summary>
        /// <param name="DeptConstant">科室常数实体</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int SetDeptConstant(Neusoft.HISFC.Models.Pharmacy.DeptConstant DeptConstant)
        {
            int parm;
            //执行更新操作
            parm = UpdateDeptConstant(DeptConstant);

            //如果没有找到可以更新的数据，则插入一条新记录
            if (parm == 0)
            {
                parm = InsertDeptConstant(DeptConstant);
            }
            return parm;
        }

        /// <summary>
        /// 取科室常数列表，可能是一条或者多条
        /// 私有方法，在其他方法中调用
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>科室常数信息对象数组</returns>
        private ArrayList myGetDeptConstant(string SQLString)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.DeptConstant DeptConstant; //科室常数实体

            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得科室常数时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    //取查询结果中的记录
                    DeptConstant = new Neusoft.HISFC.Models.Pharmacy.DeptConstant();

                    DeptConstant.ID = this.Reader[0].ToString(); //0 部门编码
                    DeptConstant.Name = this.Reader[1].ToString(); //1 部门名称

                    DeptConstant.StoreMaxDays = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[2].ToString());   //2 库房最高库存量(天)
                    DeptConstant.StoreMinDays = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[3].ToString());   //3 库房最低库存量(天)
                    DeptConstant.ReferenceDays = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[4].ToString());   //4 库房最低库存量(天)
                    DeptConstant.IsBatch = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[5].ToString()); //5 是否按批号管理药品
                    DeptConstant.IsStore = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[6].ToString()); //6 是否管理药品库存
                    DeptConstant.UnitFlag = this.Reader[7].ToString(); //7 库存管理时默认的单位，1包装单位，0最小单位
                    DeptConstant.User01 = this.Reader[8].ToString(); //8 操作员代码
                    DeptConstant.User02 = this.Reader[9].ToString(); //9 操作时间
                    DeptConstant.IsArk = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[10]);

                    DeptConstant.InListNO = this.Reader[11].ToString();         //8 入库单据号
                    DeptConstant.OutListNO = this.Reader[12].ToString();        //9 出库单据号

                    al.Add(DeptConstant);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得科室常数信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                this.Reader.Close();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 获得update或者insert科室常数表的传入参数数组
        /// </summary>
        /// <param name="DeptConstant">科室常数实体</param>
        /// <returns>字符串数组</returns>
        private string[] myGetParmDeptConstant(Neusoft.HISFC.Models.Pharmacy.DeptConstant DeptConstant)
        {
            string[] strParm ={   
								 DeptConstant.ID,						 //0 科室编码
								 DeptConstant.StoreMaxDays.ToString(),   //1 库房最高库存量(天)
								 DeptConstant.StoreMinDays.ToString(),   //2 库房最低库存量(天)
								 DeptConstant.ReferenceDays.ToString(),  //3 参考天数
								 Neusoft.FrameWork.Function.NConvert.ToInt32(DeptConstant.IsBatch).ToString(), //4 是否按批号管理药品
								 Neusoft.FrameWork.Function.NConvert.ToInt32(DeptConstant.IsStore).ToString(), //5 是否管理药品库存
								 DeptConstant.UnitFlag,					//6 库存管理时默认的单位，1包装单位，0最小单位
								 this.Operator.ID,						//7 操作员（核准，作废）
                                 NConvert.ToInt32(DeptConstant.IsArk).ToString(),
                                 DeptConstant.InListNO,                 //9 入库单据号
                                 DeptConstant.OutListNO                 //10 出库单据号
							 };
            return strParm;
        }


        #endregion

        #region 药品模版

        /// <summary>
        /// 根据实体信息获取Insert或Update语句参数数组
        /// </summary>
        /// <param name="drugStencil">模版实体信息</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        private string[] myGetDrugStencilParam(Neusoft.HISFC.Models.Pharmacy.DrugStencil drugStencil)
        {
            string[] strParm = new string[]{
												drugStencil.Dept.ID,
												drugStencil.OpenType.ID.ToString(),
												drugStencil.Stencil.ID,
												drugStencil.Stencil.Name,
												drugStencil.Item.ID,
												drugStencil.Item.Name,
												drugStencil.Item.Specs,
												drugStencil.SortNO.ToString(),
												this.Operator.ID,
												drugStencil.Extend
										   };
            return strParm;
        }

        /// <summary>
        /// 执行Sql语句 获取实体信息数组
        /// </summary>
        /// <param name="strSql">需执行的Sql语句</param>
        /// <returns>成功返回实体信息数组 失败返回null</returns>
        private ArrayList myGetDrugStencil(string strSql)
        {
            ArrayList al = new ArrayList();
            DrugStencil drugStencil = new DrugStencil();

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行" + strSql + "发生错误" + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    drugStencil = new DrugStencil();
                    drugStencil.Dept.ID = this.Reader[0].ToString();
                    drugStencil.OpenType.ID = this.Reader[1].ToString();
                    drugStencil.Stencil.ID = this.Reader[2].ToString();
                    drugStencil.Stencil.Name = this.Reader[3].ToString();
                    drugStencil.Item.ID = this.Reader[4].ToString();
                    drugStencil.Item.Name = this.Reader[5].ToString();
                    drugStencil.Item.Specs = this.Reader[6].ToString();
                    drugStencil.SortNO = NConvert.ToInt32(this.Reader[7].ToString());
                    drugStencil.Oper.ID = this.Reader[8].ToString();
                    drugStencil.Oper.OperTime = NConvert.ToDateTime(this.Reader[9].ToString());
                    drugStencil.Extend = this.Reader[10].ToString();

                    al.Add(drugStencil);
                }
            }
            catch
            {
                this.Err = "由Reader内读取数据发生异常";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 执行Sql语句 获取实体信息数组
        /// </summary>
        /// <param name="strSql">需执行的Sql语句</param>
        /// <returns>成功返回实体信息数组 失败返回null</returns>
        private ArrayList myGetDrugStencilList(string strSql)
        {
            ArrayList al = new ArrayList();
            DrugStencil drugStencil = new DrugStencil();

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行" + strSql + "发生错误" + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    drugStencil = new DrugStencil();
                    drugStencil.Dept.ID = this.Reader[0].ToString();
                    drugStencil.OpenType.ID = this.Reader[1].ToString();
                    drugStencil.Stencil.ID = this.Reader[2].ToString();
                    drugStencil.Stencil.Name = this.Reader[3].ToString();

                    al.Add(drugStencil);
                }
            }
            catch
            {
                this.Err = "由Reader内读取数据发生异常";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 获取新模版编号
        /// </summary>
        /// <returns>成功返回新模版流水号 失败返回null</returns>
        public string GetNewStencilNO()
        {
            return this.GetSequence("Pharmacy.Constant.GetNewCompanyID");
        }

        /// <summary>
        /// 根据科室编码获取所有模版信息
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="openType">模版类型</param>
        /// <returns>成功返回科室模版信息</returns>
        public ArrayList QueryDrugStencilList(string deptCode, Neusoft.HISFC.Models.Pharmacy.EnumDrugStencil openType)
        {
            string strSQL = "";  //取某一取药科室名称获得可以取药的药房名称列表的SQL语句
            string strWhere = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDrugOpenList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDrugOpenList字段!";
                return null;
            }
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDrugOpenList.Type", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDrugOpenList.Type字段!";
                return null;
            }

            strSQL = string.Format(strSQL + strWhere, deptCode, openType.ToString());

            return this.myGetDrugStencilList(strSQL);
        }

        /// <summary>
        /// 根据科室编码获取所有模版信息
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回科室模版信息</returns>
        public ArrayList QueryDrugStencilList(string deptCode)
        {
            string strSQL = "";  //取某一取药科室名称获得可以取药的药房名称列表的SQL语句
            string strWhere = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDrugOpenList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDrugOpenList字段!";
                return null;
            }
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDrugOpenList.Type", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDrugOpenList.Type字段!";
                return null;
            }

            strSQL = string.Format(strSQL + strWhere, deptCode, "AAAA");

            return this.myGetDrugStencilList(strSQL);
        }

        /// <summary>
        /// 根据模版编码获取模版明细
        /// </summary>
        /// <param name="stencilCode">模版编码</param>
        /// <returns>成功返回模版明细信息</returns>
        public ArrayList QueryDrugStencil(string stencilCode)
        {
            string strSQL = "";  //取某一取药科室名称获得可以取药的药房名称列表的SQL语句
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDrugOpenDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDrugOpenDetail字段!";
                return null;
            }

            strSQL = string.Format(strSQL, stencilCode);

            return this.myGetDrugStencil(strSQL);
        }

        /// <summary>
        /// 模版删除  删除整个模版
        /// </summary>
        /// <param name="stencilCode">模版编码</param>
        /// <returns>成功返回受影响行数  失败返回-1</returns>
        public int DelDrugStencil(string stencilCode)
        {
            string strSQL = "";  //取某一取药科室名称获得可以取药的药房名称列表的SQL语句
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelDrugOpen.Stencil", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DelDrugOpen.Stencil字段!";
                return -1;
            }

            strSQL = string.Format(strSQL, stencilCode);

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 模版删除
        /// </summary>
        /// <param name="stencilCode">模版编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int DelDrugStencil(string stencilCode, string drugCode)
        {
            string strSQL = "";  //取某一取药科室名称获得可以取药的药房名称列表的SQL语句
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelDrugOpen.Detail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DelDrugOpen.Detail字段!";
                return -1;
            }

            strSQL = string.Format(strSQL, stencilCode, drugCode);

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="drugStencil">药品模版信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int InsertDrugStencil(Neusoft.HISFC.Models.Pharmacy.DrugStencil drugStencil)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.InsertDrugOpen", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = myGetDrugStencilParam(drugStencil);  //取参数列表
                strSQL = string.Format(strSQL, strParm);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="drugStencil">药品模版信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateDrugStencil(Neusoft.HISFC.Models.Pharmacy.DrugStencil drugStencil)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.UpdateDrugOpen", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = myGetDrugStencilParam(drugStencil);  //取参数列表
                strSQL = string.Format(strSQL, strParm);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据模版编码 修改模版名称
        /// </summary>
        /// <param name="stencilCode">模版编码</param>
        /// <param name="stencilName">模版名称</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateDrugStencilName(string stencilCode, string stencilName)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.UpdateDrugOpenStencilName", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, stencilCode, stencilName);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="drugStencil">药品模版信息</param>
        /// <returns></returns>
        public int SetDrugStencil(Neusoft.HISFC.Models.Pharmacy.DrugStencil drugStencil)
        {
            int parm = 0;
            parm = this.UpdateDrugStencil(drugStencil);
            if (parm == -1)
                return -1;
            if (parm == 0)
            {
                parm = this.InsertDrugStencil(drugStencil);
            }
            return parm;
        }
        #endregion

        #region 月结数据处理

        /// <summary>
        /// 月结记录删除
        /// </summary>
        /// <param name="dtBegin">月结记录起始时间</param>
        /// <param name="dtEnd">月结记录终止时间</param>
        /// <returns>成功删除大于1 失败返回－1 无操作记录返回0</returns>
        public int DelMonthStore(DateTime dtBegin,DateTime dtEnd)
        {
            string strHeadSql = "";         //删除月结汇总信息
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.MonthStore.DelMonthStore.Head", ref strHeadSql) == -1)
            {
                this.Err = "没有找到Pharmacy.MonthStore.DelMonthStore.Head字段!";
                return -1;
            }

            strHeadSql = string.Format(strHeadSql, dtBegin, dtEnd);

            int parm = this.ExecNoQuery(strHeadSql);
            if (parm == -1)
            {
                this.Err = "执行Sql语句发生错误 " + this.Err;
                return -1;
            }

            string strDetailSql = "";       //删除月结明细信息
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.MonthStore.DelMonthStore.Detail", ref strDetailSql) == -1)
            {
                this.Err = "没有找到Pharmacy.MonthStore.DelMonthStore.Detail字段!";
                return -1;
            }

            strDetailSql = string.Format(strDetailSql, dtBegin, dtEnd);

            parm = this.ExecNoQuery(strDetailSql);

            return parm;
        }

        /// <summary>
        /// 月结汇总信息获取
        /// </summary>
        /// <param name="drugDeptCode">库房编码</param>
        /// <param name="dsHead">月结汇总</param>
        /// <returns>成功返回1 失败返回－1 无数据返回0</returns>
        public int QueryMonthStoreHead(string drugDeptCode,ref System.Data.DataSet dsHead)
        {
            string strSql = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.MonthStore.StoreHead", ref strSql) == -1)
            {
                this.Err = "没有找到Pharmacy.MonthStore.StoreHead字段！";
                return -1;
            }

            try
            {
                strSql = string.Format(strSql, drugDeptCode);
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错Pharmacy.MonthStore.StoreHead" + ex.Message;
                this.WriteErr();
                return -1;
            }

            //根据SQL语句取查询结果
            if (this.ExecQuery(strSql, ref dsHead) == -1)
            {
                return -1;
            }
            if (dsHead == null)
            {
                return 1;
            }

            if (dsHead.Tables.Count == 0)
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// 月结明细信息获取
        /// </summary>
        /// <param name="drugDeptCode">库房编码</param>
        /// <param name="dsDetail">月结明细</param>
        /// <returns>成功返回1 失败返回－1 无数据返回0</returns>
        public int QueryMonthStoreDetail(string drugDeptCode, DateTime dtBegin,DateTime dtEnd,ref System.Data.DataSet dsDetail)
        {
            string strSql = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.MonthStore.StoreDetail", ref strSql) == -1)
            {
                this.Err = "没有找到Pharmacy.MonthStore.StoreDetail字段！";
                return -1;
            }

            try
            {
                strSql = string.Format(strSql, drugDeptCode,dtBegin.ToString(),dtEnd.ToString());
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错Pharmacy.MonthStore.StoreDetail" + ex.Message;
                this.WriteErr();
                return -1;
            }

            //根据SQL语句取查询结果
            if (this.ExecQuery(strSql, ref dsDetail) == -1)
            {
                return -1;
            }
            if (dsDetail == null)
            {
                return 1;
            }

            if (dsDetail.Tables.Count == 0)
            {
                return 0;
            }

            return 1;
        }

        #endregion

        #region 特限药品维护

        /// <summary>
        /// 根据实体信息获取Insert或Update语句参数数组
        /// </summary>
        /// <param name="drugSpe">特限药品信息</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        private string[] GetDrugSpecialParam(Neusoft.HISFC.Models.Pharmacy.DrugSpecial drugSpe)
        {
            string[] strParam = new string[] { 
                                                ((int)drugSpe.SpeType).ToString(),
                                                drugSpe.SpeItem.ID,
                                                drugSpe.SpeItem.Name,
                                                drugSpe.Item.ID,
                                                drugSpe.Item.Name,
                                                drugSpe.Item.Specs,
                                                drugSpe.Extend,
                                                drugSpe.Memo,
                                                drugSpe.Oper.ID,
                                                drugSpe.Oper.OperTime.ToString()                                                            
                                             };

            return strParam;
        }

        /// <summary>
        /// 执行Sql 获取DrugSpecial实体信息
        /// </summary>
        /// <param name="strSql">需执行的Sql</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private List<Neusoft.HISFC.Models.Pharmacy.DrugSpecial> ExecSqlForDrugSpecial(string strSql)
        {
            List<Neusoft.HISFC.Models.Pharmacy.DrugSpecial> al = new List<DrugSpecial>();
            DrugStencil drugStencil = new DrugStencil();

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行" + strSql + "发生错误" + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    DrugSpecial drugSpe = new DrugSpecial();

                    drugSpe.SpeType = (EnumDrugSpecialType)NConvert.ToInt32(this.Reader[0]);
                    drugSpe.SpeItem.ID = this.Reader[1].ToString();
                    drugSpe.SpeItem.Name = this.Reader[2].ToString();
                    drugSpe.Item.ID = this.Reader[3].ToString();
                    drugSpe.Item.Name = this.Reader[4].ToString();
                    drugSpe.Item.Specs = this.Reader[5].ToString();
                    drugSpe.Extend = this.Reader[6].ToString();
                    drugSpe.Memo = this.Reader[7].ToString();
                    drugSpe.Oper.ID = this.Reader[8].ToString();
                    drugSpe.Oper.OperTime = NConvert.ToDateTime(this.Reader[9]);

                    al.Add(drugSpe);
                }
            }
            catch
            {
                this.Err = "由Reader内读取数据发生异常";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 插入特限药品信息
        /// </summary>
        /// <param name="drugSpe">特限药品信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int InsertDrugSpecial(Neusoft.HISFC.Models.Pharmacy.DrugSpecial drugSpe)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.InsertDrugSpecial", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.GetDrugSpecialParam(drugSpe);   //取参数列表
                strSQL = string.Format(strSQL, strParm);                //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 特限药品信息删除
        /// </summary>
        /// <param name="drugSpe">特限药品信息</param>
        /// <returns>成功返回删除记录数 失败返回-1</returns>
        public int DelDrugSpecial(Neusoft.HISFC.Models.Pharmacy.DrugSpecial drugSpe)
        {
            string strSQL = "";  
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelDrugSpecial.Detail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DelDrugSpecial.Detail字段!";
                return -1;
            }

            strSQL = string.Format(strSQL,((int)drugSpe.SpeType).ToString(),drugSpe.SpeItem.ID,drugSpe.Item.ID);

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 按照类型删除药品特限信息
        /// </summary>
        /// <param name="speType">特限类型</param>
        /// <returns>成功返回影响记录数 失败返回-1</returns>
        public int DelDrugSpecial(Neusoft.HISFC.Models.Pharmacy.EnumDrugSpecialType speType)
        {
            string strSQL = "";  
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelDrugSpecial.Type", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DelDrugSpecial.Type字段!";
                return -1;
            }

            strSQL = string.Format(strSQL, ((int)speType).ToString());

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 获取所有特限药品列表
        /// </summary>
        /// <returns>成功返回所有特限药品 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.DrugSpecial> QueryDrugSpecialList()
        {
            string strSQL = "";  

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.QueryDrugSpecialList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryDrugSpecialList字段!";
                return null;
            }

            return this.ExecSqlForDrugSpecial(strSQL);
        }

        /// <summary>
        /// 根据类型获取所有特限药品
        /// </summary>
        /// <param name="speType">特限药品类型</param>
        /// <returns>成功返回所有特限药品 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.DrugSpecial> QueryDrugSpecialList(EnumDrugSpecialType speType)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.QueryDrugSpecialList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryDrugSpecialList字段!";
                return null;
            }

            //取where语句 
            string strWhere = "";
            if (this.Sql.GetSql("Pharmacy.Constant.QueryDrugSpecialList.Type", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryDrugSpecialList.Type字段!";
                return null;
            }

            strSQL = string.Format(strSQL + strWhere, ((int)speType).ToString());

            return this.ExecSqlForDrugSpecial(strSQL);
        }

        #endregion

        #region 病区基数药维护

        /// <summary>
        /// 获取Insert或Update参数
        /// </summary>
        /// <param name="deptRadix">病区基数药信息</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        private string[] GetParamForDeptRadix(Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix deptRadix)
        {
            string[] strParam = new string[]{
                                                deptRadix.StockDept.ID,
                                                deptRadix.Dept.ID,
                                                deptRadix.Item.ID,
                                                deptRadix.Item.Name,
                                                deptRadix.Item.Specs,
                                                deptRadix.Item.PackUnit,
                                                deptRadix.Item.PackQty.ToString(),
                                                deptRadix.Item.MinUnit,
                                                deptRadix.RadixQty.ToString(),          //药品基数
                                                deptRadix.SurplusQty.ToString(),        //盈余数量
                                                deptRadix.ExpendQty.ToString(),         //消耗量
                                                deptRadix.SupplyQty.ToString(),         //补充量
                                                deptRadix.Memo,
                                                deptRadix.BeginDate.ToString(),
                                                deptRadix.EndDate.ToString(),
                                                deptRadix.Oper.ID,
                                                deptRadix.Oper.OperTime.ToString(),
                                                deptRadix.DeptType
                                            };

            return strParam;
        }

        /// <summary>
        /// 执行Sql获取项目实体
        /// </summary>
        /// <param name="strSql">需执行的Sql</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        private List<Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix> ExecSqlForDeptRadix(string strSql)
        {
            List<Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix> al = new List<Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix>();
            Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix drugStencil = new Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix();

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行" + strSql + "发生错误" + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix deptRadix = new Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix();

                    deptRadix.StockDept.ID = this.Reader[0].ToString();
                    deptRadix.Dept.ID = this.Reader[1].ToString();
                    deptRadix.Item.ID = this.Reader[2].ToString();
                    deptRadix.Item.Name = this.Reader[3].ToString();
                    deptRadix.Item.Specs = this.Reader[4].ToString();
                    deptRadix.Item.PackUnit = this.Reader[5].ToString();
                    deptRadix.Item.PackQty = NConvert.ToDecimal(this.Reader[6].ToString());
                    deptRadix.Item.MinUnit = this.Reader[7].ToString();
                    deptRadix.RadixQty = NConvert.ToDecimal(this.Reader[8].ToString());
                    deptRadix.SurplusQty = NConvert.ToDecimal(this.Reader[9]);
                    deptRadix.ExpendQty = NConvert.ToDecimal(this.Reader[10]);
                    deptRadix.SupplyQty = NConvert.ToDecimal(this.Reader[11]);
                    deptRadix.Memo = this.Reader[12].ToString();
                    deptRadix.BeginDate = NConvert.ToDateTime(this.Reader[13]);
                    deptRadix.EndDate = NConvert.ToDateTime(this.Reader[14]);
                    deptRadix.Oper.ID = this.Reader[15].ToString();
                    deptRadix.Oper.OperTime = NConvert.ToDateTime(this.Reader[16]);
                    deptRadix.DeptType = this.Reader[17].ToString();

                    al.Add(deptRadix);
                }
            }
            catch
            {
                this.Err = "由Reader内读取数据发生异常";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 插入病区药品基数信息
        /// </summary>
        /// <param name="deptRadix">病区药品基数信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int InsertDeptRadix(Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix deptRadix)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.InsertDeptRadix", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.GetParamForDeptRadix(deptRadix);   //取参数列表
                strSQL = string.Format(strSQL, strParm);                //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 病区药品基数信息删除
        /// </summary>
        /// <param name="drugDeptCode">库存科室</param>
        /// <param name="deptCode">病区</param>
        /// <param name="drugCode">药品编码</param>
        /// <returns>成功返回删除记录数 失败返回-1</returns>
        public int DelDeptRadix(string drugDeptCode,string deptCode,string drugCode,DateTime beginDate)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelDeptRadix.Detail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DelDeptRadix.Detail字段!";
                return -1;
            }

            strSQL = string.Format(strSQL, drugDeptCode,deptCode, drugCode,beginDate.ToString());

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 按照科室删除病区药品基数信息
        /// </summary>
        /// <param name="drugDeptCode">库存科室</param>
        /// <param name="deptCode">科室</param>
        /// <returns>成功返回影响记录数 失败返回-1</returns>
        public int DelDeptRadix(string drugDeptCode,string deptCode,DateTime beginDate)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelDeptRadix.Dept", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DelDeptRadix.Dept字段!";
                return -1;
            }

            strSQL = string.Format(strSQL, drugDeptCode,deptCode,beginDate.ToString());

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据科室编码获取病区基数药信息
        /// </summary>
        /// <param name="drugDeptCode">库存科室</param>
        /// <param name="deptCode">病区编码</param>
        /// <param name="beginDate">起始时间</param>
        /// <returns>成功返回病区基数药信息 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Common.DeptRadix> QueryDeptRadix(string drugDeptCode,string deptCode,DateTime beginDate)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.QueryDeptRadix", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryDeptRadix字段!";
                return null;
            }

            string strWhere = "";
            if (this.Sql.GetSql("Pharmacy.Constant.QueryDeptRadix.Dept", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryDeptRadix.Dept字段!";
                return null;
            }

            strSQL = strSQL + strWhere;
            strSQL = string.Format(strSQL,drugDeptCode,deptCode,beginDate.ToString());

            return this.ExecSqlForDeptRadix(strSQL);
        }

        /// <summary>
        /// 获取设置了基数药品的病区信息
        /// </summary>
        /// <param name="drugDeptCode">库存科室</param>
        /// <returns>成功返回病区数组 失败返回null</returns>
        public List<Neusoft.FrameWork.Models.NeuObject> QueryDeptRadixDeptList(string drugDeptCode,DateTime beginTime)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.QueryDeptRadixList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryDeptRadixList字段!";
                return null;
            }

            strSQL = string.Format(strSQL, drugDeptCode,beginTime.ToString());

            List<Neusoft.FrameWork.Models.NeuObject> al = new List<Neusoft.FrameWork.Models.NeuObject>();
            Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "执行" + strSQL + "发生错误" + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();

                    info.ID = this.Reader[0].ToString();
                    info.Name = this.Reader[1].ToString();

                    al.Add(info);
                }
            }
            catch
            {
                this.Err = "由Reader内读取数据发生异常";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 获取基数药时间段列表信息
        /// </summary>
        /// <param name="drugDeptCode"></param>
        /// <returns>ID 时间段 Name 起始时间</returns>
        public List<Neusoft.FrameWork.Models.NeuObject> QueryDeptRadixDateList(string drugDeptCode)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.QueryDeptRadixDateList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryDeptRadixDateList字段!";
                return null;
            }

            strSQL = string.Format(strSQL, drugDeptCode);

            List<Neusoft.FrameWork.Models.NeuObject> al = new List<Neusoft.FrameWork.Models.NeuObject>();
            Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "执行" + strSQL + "发生错误" + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();

                    info.ID = this.Reader[0].ToString();
                    info.Name = this.Reader[1].ToString();

                    al.Add(info);
                }
            }
            catch
            {
                this.Err = "由Reader内读取数据发生异常";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }
        #endregion

        #region 药品自定义月结设置

        /// <summary>
        /// 根据实体信息获取Insert或Update语句参数数组
        /// </summary>
        /// <param name="msCustom">药品自定义月结项目维护信息</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        private string[] GetMSCustomParam(Neusoft.HISFC.Models.Pharmacy.MSCustom msCustom)
        {
            string[] strParam = new string[] {                                                
                                                msCustom.ID,
                                                msCustom.DeptType.ToString(),
                                                msCustom.CustomItem.ID,
                                                msCustom.CustomItem.Name,
                                                msCustom.ItemOrder.ToString(),
                                                Neusoft.HISFC.Models.Base.EnumMSCustomTypeService.GetNameFromEnum(msCustom.CustomType),
                                                msCustom.TypeItem,
                                                ((int)msCustom.Trans).ToString(),
                                                msCustom.PriceType,
                                                msCustom.Oper.ID,
                                                msCustom.Oper.OperTime.ToString()                                                            
                                             };

            return strParam;
        }

        /// <summary>
        /// 执行Sql 获取MSCustom实体信息
        /// </summary>
        /// <param name="strSql">需执行的Sql</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private List<Neusoft.HISFC.Models.Pharmacy.MSCustom> ExecSqlForMSCustom(string strSql)
        {
            List<Neusoft.HISFC.Models.Pharmacy.MSCustom> al = new List<MSCustom>();
            MSCustom msCustom = new MSCustom();

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行" + strSql + "发生错误" + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    msCustom = new MSCustom();

                    msCustom.ID = this.Reader[0].ToString();
                    msCustom.DeptType = (Neusoft.HISFC.Models.Base.EnumDepartmentType)(Enum.Parse(typeof(Neusoft.HISFC.Models.Base.EnumDepartmentType),this.Reader[1].ToString()));
                    msCustom.CustomItem.ID = this.Reader[2].ToString();
                    msCustom.CustomItem.Name = this.Reader[3].ToString();
                    msCustom.ItemOrder = NConvert.ToInt32(this.Reader[4].ToString());
                    msCustom.CustomType = Neusoft.HISFC.Models.Base.EnumMSCustomTypeService.GetEnumFromName(this.Reader[5].ToString());
                    msCustom.TypeItem = this.Reader[6].ToString();
                    msCustom.Trans = (Neusoft.HISFC.Models.Base.TransTypes)(Enum.Parse(typeof(Neusoft.HISFC.Models.Base.TransTypes),this.Reader[7].ToString()));
                    msCustom.PriceType = this.Reader[8].ToString();
                    msCustom.Oper.ID = this.Reader[8].ToString();
                    msCustom.Oper.OperTime = NConvert.ToDateTime(this.Reader[9]);

                    al.Add(msCustom);
                }
            }
            catch
            {
                this.Err = "由Reader内读取数据发生异常";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 插入药品自定义月结设置信息
        /// </summary>
        /// <param name="msCustom">药品自定义月结信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int InsertMSCustom(Neusoft.HISFC.Models.Pharmacy.MSCustom msCustom)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.InsertMSCustom", ref strSQL) == -1) return -1;
            try
            {
                if (msCustom.ID == "" || msCustom.ID == null)
                {
                    msCustom.ID = this.GetSequence("Pharmacy.Constant.GetNewCompanyID");
                }
                string[] strParm = this.GetMSCustomParam(msCustom);   //取参数列表
                strSQL = string.Format(strSQL, strParm);                //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 药品自定义月结设置信息删除
        /// </summary>
        /// <param name="deptType">科室类型</param>
        /// <returns>成功返回删除记录数 失败返回-1</returns>
        public int DelMSCustom(Neusoft.HISFC.Models.Base.EnumDepartmentType deptType)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelMSCustom.Type", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DelMSCustom.Type字段!";
                return -1;
            }

            strSQL = string.Format(strSQL, deptType.ToString());

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 药品自定义月结设置信息删除
        /// </summary>
        /// <param name="ID">设置信息流水号</param>
        /// <returns>成功返回影响记录数 失败返回-1</returns>
        public int DelMSCustom(string ID)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelMSCustom.Detail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DelMSCustom.Detail字段!";
                return -1;
            }

            strSQL = string.Format(strSQL, ID);

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据科室类型获取药品自定义月结设置信息
        /// </summary>
        /// <param name="deptType">科室类型</param>
        /// <returns>成功返回病区基数药信息 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.MSCustom> QueryMSCustom(Neusoft.HISFC.Models.Base.EnumDepartmentType deptType)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.QueryMSCustom", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryMSCustom字段!";
                return null;
            }

            string strWhere = "";
            if (this.Sql.GetSql("Pharmacy.Constant.QueryMSCustom.Type", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryMSCustom.Type字段!";
                return null;
            }

            strSQL = strSQL + strWhere;
            strSQL = string.Format(strSQL, deptType.ToString());

            return this.ExecSqlForMSCustom(strSQL);
        }
       
        #endregion

        #region 医嘱批次设置

        /// <summary>
        /// 根据实体信息获取Updete或Insert语句参数数组
        /// </summary>
        /// <param name="orderGroup">医嘱批次设置信息</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        private string[] GetOrderGroupParam(Neusoft.HISFC.Models.Pharmacy.OrderGroup orderGroup)
        {
            orderGroup.BeginTime = new DateTime(2000, 12, 12, orderGroup.BeginTime.Hour, orderGroup.BeginTime.Minute, orderGroup.BeginTime.Second);
            orderGroup.EndTime = new DateTime(2000, 12, 12, orderGroup.EndTime.Hour, orderGroup.EndTime.Minute, orderGroup.EndTime.Second);

            string[] strParam = new string[] {                                                
                                                orderGroup.ID,
                                                orderGroup.BeginTime.ToString(),
                                                orderGroup.EndTime.ToString(),
                                                orderGroup.Oper.ID,
                                                orderGroup.Oper.OperTime.ToString()
                                             };

            return strParam;
        }

        /// <summary>
        /// 执行Sql 获取OrderGroup信息
        /// </summary>
        /// <param name="strSql">需执行的Sql</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private List<Neusoft.HISFC.Models.Pharmacy.OrderGroup> ExecSqlForOrderGroup(string strSql)
        {
            List<Neusoft.HISFC.Models.Pharmacy.OrderGroup> al = new List<OrderGroup>();
            OrderGroup orderGroup = new OrderGroup();

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行" + strSql + "发生错误" + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    orderGroup = new OrderGroup();

                    orderGroup.ID = this.Reader[0].ToString();
                    orderGroup.BeginTime = NConvert.ToDateTime(this.Reader[1].ToString());
                    orderGroup.EndTime = NConvert.ToDateTime(this.Reader[2].ToString());       
                    orderGroup.Oper.ID = this.Reader[3].ToString();
                    orderGroup.Oper.OperTime = NConvert.ToDateTime(this.Reader[4]);

                    al.Add(orderGroup);
                }
            }
            catch
            {
                this.Err = "由Reader内读取数据发生异常";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 插入医嘱批次设置信息
        /// </summary>
        /// <param name="orderGroup">医嘱批次设置信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int InsertOrderGroup(Neusoft.HISFC.Models.Pharmacy.OrderGroup orderGroup)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.InsertOrderGroup", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.GetOrderGroupParam(orderGroup);   //取参数列表
                strSQL = string.Format(strSQL, strParm);                //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除所有医嘱批次设置信息
        /// </summary>
        /// <returns></returns>
        public int DelOrderGroup()
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelOrderGroup", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DelOrderGroup字段!";
                return -1;
            }

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除所有医嘱批次设置信息
        /// </summary>
        /// <returns></returns>
        public int DelOrderGroup(string groupCode,DateTime dtBegin,DateTime dtEnd)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelOrderGroup.GroupCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DelOrderGroup.GroupCode字段!";
                return -1;
            }

            dtBegin = new DateTime(2000, 12, 12, dtBegin.Hour, dtBegin.Minute, dtBegin.Second);
            dtEnd = new DateTime(2000, 12, 12, dtEnd.Hour, dtEnd.Minute, dtEnd.Second);

            strSQL = string.Format(strSQL, groupCode,dtBegin.ToString(),dtEnd.ToString());

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 获取所有医嘱批次设置信息
        /// </summary>
        /// <returns></returns>
        public List<OrderGroup> QueryOrderGroup()
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.QueryOrderGroup", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryOrderGroup字段!";
                return null;
            }

            return this.ExecSqlForOrderGroup(strSQL);
        }

        /// <summary>
        /// 根据医嘱执行时间获取医嘱批次
        /// </summary>
        /// <param name="execTime">医嘱执行时间</param>
        /// <returns>成功返回医嘱批次 失败返回null</returns>
        public string GetOrderGroup(DateTime execTime)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetOrderGroup", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetOrderGroup字段!";
                return null;
            }

            execTime = new DateTime(2000, 12, 12, execTime.Hour, execTime.Minute, execTime.Second);

            strSQL = string.Format(strSQL, execTime.ToString());

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "执行" + strSQL + "发生错误" + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    return this.Reader[0].ToString();
                }
            }
            catch
            {
                this.Err = "由Reader内读取数据发生异常";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return null;
        }

        #endregion

        #region 特殊取药药房设置(药品指定到具体的药房)

        /// <summary>
        /// 获取插入、更新参数
        /// </summary>
        /// <param name="speLocation"></param>
        /// <returns></returns>
        private string[] GetDrugSpeLocationParams(Neusoft.HISFC.Models.Pharmacy.DrugSpeLocation speLocation)
        {
            string[] strParams = new string[] { 
                                                    speLocation.ID,
                                                    speLocation.Item.ID,
                                                    speLocation.Item.Name,
                                                    speLocation.Item.Specs,
                                                    speLocation.RoomDept.ID,
                                                    speLocation.Oper.ID,
                                                    speLocation.Oper.OperTime.ToString()
                                                };

            return strParams;
        }

        /// <summary>
        /// 执行Sql语句获取数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private List<Neusoft.HISFC.Models.Pharmacy.DrugSpeLocation> ExecSqlForSpeLocation(string strSql)
        {
            List<Neusoft.HISFC.Models.Pharmacy.DrugSpeLocation> al = new List<DrugSpeLocation>();

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行" + strSql + "发生错误" + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    DrugSpeLocation speLocation = new DrugSpeLocation();

                    speLocation.ID = this.Reader[0].ToString();
                    speLocation.Item.ID = this.Reader[1].ToString();
                    speLocation.Item.Name = this.Reader[2].ToString();
                    speLocation.Item.Specs = this.Reader[3].ToString();
                    speLocation.RoomDept.ID = this.Reader[4].ToString();
                    speLocation.Oper.ID = this.Reader[5].ToString();
                    speLocation.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());

                    al.Add(speLocation);
                }
            }
            catch
            {
                this.Err = "由Reader内读取数据发生异常";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 插入特药品信息
        /// </summary>
        /// <param name="speLocation">特药品信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int InsertDrugSpeLocation(Neusoft.HISFC.Models.Pharmacy.DrugSpeLocation speLocation)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.InsertDrugSpeLocation", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.GetDrugSpeLocationParams(speLocation);   //取参数列表
                strSQL = string.Format(strSQL, strParm);                //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 特药品信息删除
        /// </summary>
        /// <param name="speLocation">特药品信息</param>
        /// <returns>成功返回删除记录数 失败返回-1</returns>
        public int DelDrugSpeLocation(Neusoft.HISFC.Models.Pharmacy.DrugSpeLocation speLocation)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.DelDrugSpeLocation", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.DelDrugSpeLocation字段!";
                return -1;
            }

            strSQL = string.Format(strSQL, speLocation.ID,speLocation.Item.ID,speLocation.RoomDept.ID);

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 获取所有设置
        /// </summary>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Pharmacy.DrugSpeLocation> QueryDrugSpeLocation()
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.QueryDrugSpeLocation", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryDrugSpeLocation字段!";
                return null;
            }

            return this.ExecSqlForSpeLocation(strSQL);
        }
        #endregion

        #region 药品常数

        /// <summary>
        /// 根据实体信息获取Updete或Insert语句参数数组
        /// </summary>
        /// <param name="drugConstant">药品常数设置信息</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        private string[] GetDrugConstantParam(Neusoft.HISFC.Models.Pharmacy.DrugConstant drugConstant)
        {
            string[] strParam = new string[] {                                                
                                                drugConstant.ConsType,
                                                drugConstant.Dept.ID,
                                                drugConstant.DrugType,
                                                drugConstant.Class2Priv.ID,
                                                drugConstant.Class3Priv.ID,
                                                drugConstant.Item.ID,
                                                drugConstant.Item.Name,
                                                NConvert.ToInt32(drugConstant.IsValid).ToString(),
                                                drugConstant.Memo,
                                                drugConstant.Oper.ID,
                                                drugConstant.Oper.OperTime.ToString()
                                             };

            return strParam;
        }

        /// <summary>
        /// 执行Sql 获取OrderGroup信息
        /// </summary>
        /// <param name="strSql">需执行的Sql</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private List<Neusoft.HISFC.Models.Pharmacy.DrugConstant> ExecSqlForDrugConstant(string strSql)
        {
            List<Neusoft.HISFC.Models.Pharmacy.DrugConstant> al = new List<DrugConstant>();
            DrugConstant drugConstant = new DrugConstant();

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行" + strSql + "发生错误" + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    drugConstant = new DrugConstant();

                    drugConstant.ConsType = this.Reader[0].ToString();
                    drugConstant.Dept.ID = this.Reader[1].ToString();
                    drugConstant.DrugType = this.Reader[2].ToString();
                    drugConstant.Class2Priv.ID = this.Reader[3].ToString();
                    drugConstant.Class3Priv.ID = this.Reader[4].ToString();
                    drugConstant.Item.ID = this.Reader[5].ToString();
                    drugConstant.Item.Name = this.Reader[6].ToString();
                    drugConstant.IsValid = NConvert.ToBoolean(this.Reader[7]);
                    drugConstant.Memo = this.Reader[8].ToString();
                    drugConstant.Oper.ID = this.Reader[9].ToString();
                    drugConstant.Oper.OperTime = NConvert.ToDateTime(this.Reader[10]);

                    al.Add(drugConstant);
                }
            }
            catch
            {
                this.Err = "由Reader内读取数据发生异常";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 插入药品常数设置信息
        /// </summary>
        /// <param name="drugConstant">药品常数设置信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int InsertDrugConstant(Neusoft.HISFC.Models.Pharmacy.DrugConstant drugConstant)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.InsertDrugConstant", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.GetDrugConstantParam(drugConstant);   //取参数列表
                strSQL = string.Format(strSQL, strParm);                //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除药品常数设置信息
        /// </summary>
        /// <param name="drugConstant">药品常数设置信息</param>
        /// <returns>成功返回删除行数 失败返回-1</returns>
        public int DeleteDrugConstant(Neusoft.HISFC.Models.Pharmacy.DrugConstant drugConstant)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.DeleteDrugConstant", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, drugConstant.ConsType, drugConstant.Dept.ID, drugConstant.DrugType, drugConstant.Item.ID);                //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除药品常数信息
        /// </summary>
        /// <param name="consType">药品常数设置信息</param>
        /// <returns>成功返回删除行数 失败返回-1</returns>
        public int DeleteDrugConstant(string consType)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Constant.DeleteDrugConstant.Type", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, consType);                //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据常数类别获取设置信息
        /// </summary>
        /// <param name="consType">常数类别</param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Pharmacy.DrugConstant> QueryDrugConstant(string consType)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.QueryDrugConstant", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryDrugConstant字段!";
                return null;
            }

            string strWhere = "";
            if (this.Sql.GetSql("Pharmacy.Constant.QueryDrugConstant.Type", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryDrugConstant.Type字段!";
                return null;
            }

            strSQL = strSQL + strWhere;
            strSQL = string.Format(strSQL, consType);

            return this.ExecSqlForDrugConstant(strSQL);
        }

        /// <summary>
        /// 根据常数类别/项目分类获取设置信息
        /// </summary>
        /// <param name="consType">常数类别</param>
        /// <param name="itemCode">项目分类编码</param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Pharmacy.DrugConstant> QueryDrugConstant(string consType, string itemCode)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.QueryDrugConstant", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryDrugConstant字段!";
                return null;
            }

            string strWhere = "";
            if (this.Sql.GetSql("Pharmacy.Constant.QueryDrugConstant.Item", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.QueryDrugConstant.Item字段!";
                return null;
            }

            strSQL = strSQL + strWhere;
            strSQL = string.Format(strSQL, consType, itemCode);

            return this.ExecSqlForDrugConstant(strSQL);
        }
        #endregion

        #region 作废

        /// <summary>
        /// 取药品性质列表
        /// </summary>
        /// <returns>错误返回null，正确返回Quality数组</returns>
        [System.Obsolete("系统重构作废，用QueryConstantQuality代替", true)]
        public ArrayList GetConstantQuality()
        {
            return null;
        }
        /// <summary>
        /// 查询三级药理作用
        /// </summary>
        /// <returns>arrayList</returns>
        [System.Obsolete("系统重构作废，用QueryPhaFunction代替", true)]
        public ArrayList GetPhaFunction()
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.all", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.all字段!";
                return null;
            }
            strSQL = string.Format(strSQL);
            //执行sql语句
            this.ExecQuery(strSQL);
            ArrayList alist = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.PhaFunction myFunction;
                while (this.Reader.Read())
                {

                    myFunction = new PhaFunction();
                    myFunction.ParentNode = this.Reader[0].ToString();							//0 父节点
                    myFunction.ID = this.Reader[1].ToString();								//1节点ID
                    myFunction.Name = this.Reader[2].ToString();								//2 节点名称
                    myFunction.NodeKind = NConvert.ToInt32(this.Reader[3].ToString());            //3节点类型
                    myFunction.GradeLevel = NConvert.ToInt32(this.Reader[4].ToString());        //4 级别
                    myFunction.SpellCode = this.Reader[5].ToString();							//5 拼音码
                    myFunction.WBCode = this.Reader[6].ToString();							//6 五笔码
                    myFunction.SortID = NConvert.ToInt32(this.Reader[7].ToString());           //7 自定义码
                    myFunction.IsValid = NConvert.ToBoolean(this.Reader[8].ToString());							//8 类型
                    myFunction.Memo = this.Reader[11].ToString();								//11备注      
                    this.ProgressBarValue++;
                    alist.Add(myFunction);
                }
            }
            catch (Exception ex)
            {
                this.Err = "取药品三级药理作用失败" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return alist;
        }

        [System.Obsolete("系统重构作废，用QueryPhaFunctionLeafage代替", true)]
        public ArrayList GetPhaFunctionLeafage()
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.all", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.all字段!";
                return null;
            }
            string strSQL1 = "";
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.Where.1", ref strSQL1) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.Where.1字段!";
                return null;
            }

            strSQL = strSQL + " " + strSQL1;

            strSQL = string.Format(strSQL);
            //执行sql语句
            this.ExecQuery(strSQL);
            ArrayList alist = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.PhaFunction myFunction;
                while (this.Reader.Read())
                {

                    myFunction = new PhaFunction();
                    myFunction.ParentNode = this.Reader[0].ToString();							//0 父节点
                    myFunction.ID = this.Reader[1].ToString();								//1节点ID
                    myFunction.Name = this.Reader[2].ToString();								//2 节点名称
                    myFunction.NodeKind = NConvert.ToInt32(this.Reader[3].ToString());            //3节点类型
                    myFunction.GradeLevel = NConvert.ToInt32(this.Reader[4].ToString());        //4 级别
                    myFunction.SpellCode = this.Reader[5].ToString();							//5 拼音码
                    myFunction.WBCode = this.Reader[6].ToString();							//6 五笔码
                    myFunction.SortID = NConvert.ToInt32(this.Reader[7].ToString());           //7 自定义码
                    myFunction.IsValid = NConvert.ToBoolean(this.Reader[8].ToString());							//8 类型
                    myFunction.Memo = this.Reader[11].ToString();								//11备注      
                    this.ProgressBarValue++;
                    alist.Add(myFunction);
                }
            }
            catch (Exception ex)
            {
                this.Err = "取药品三级药理作用失败" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return alist;
        }

        /// <summary>
        /// 取三级药理作用常数表中一条记录
        /// </summary>
        /// 返回arraylist 参数 nodecode 是表中节点的编号
        [System.Obsolete("系统重构作废，用QueryFunctionByNode代替", true)]
        public ArrayList GetFunctionByNode(string nodecode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.ONE", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.ONE字段!";
                return null;
            }
            strSQL = string.Format(strSQL, nodecode);
            //执行sql语句
            this.ExecQuery(strSQL);
            ArrayList alist = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.PhaFunction myFunction;
                while (this.Reader.Read())
                {

                    myFunction = new PhaFunction();
                    myFunction.ParentNode = this.Reader[0].ToString();							//0 父节点
                    myFunction.ID = this.Reader[1].ToString();								//1节点ID
                    myFunction.Name = this.Reader[2].ToString();								//2 节点名称
                    myFunction.NodeKind = NConvert.ToInt32(this.Reader[3].ToString());            //3节点类型
                    myFunction.GradeLevel = NConvert.ToInt32(this.Reader[4].ToString());        //4 级别
                    myFunction.SpellCode = this.Reader[5].ToString();							//5 拼音码
                    myFunction.WBCode = this.Reader[6].ToString();							//6 五笔码
                    myFunction.SortID = NConvert.ToInt32(this.Reader[7].ToString());           //7 自定义码
                    myFunction.IsValid = NConvert.ToBoolean(this.Reader[8].ToString());							//8 类型
                    myFunction.Memo = this.Reader[11].ToString();								//11备注      
                    this.ProgressBarValue++;
                    alist.Add(myFunction);
                }
            }
            catch (Exception ex)
            {
                this.Err = "取药品药理作用失败" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return alist;
        }
        /// <summary>
        /// 获取最近插入的叶子节点
        /// </summary>
        [System.Obsolete("系统重构作废，用QueryPhaFunctionNodeName代替", true)]
        public ArrayList GetPhaFunctionNodeName()
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.GETLASTNODENAME", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.GETLASTNODENAME字段!";
                return null;
            }
            strSQL = string.Format(strSQL);
            this.ExecQuery(strSQL);//替换SQL语句中的参数。
            ArrayList alist = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.PhaFunction myFunction;
                while (this.Reader.Read())
                {

                    myFunction = new PhaFunction();
                    myFunction.ParentNode = this.Reader[0].ToString();							//0 父节点
                    myFunction.ID = this.Reader[1].ToString();								//1节点ID
                    myFunction.Name = this.Reader[2].ToString();								//2 节点名   
                    this.ProgressBarValue++;
                    alist.Add(myFunction);
                }
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Constant.GetComPhaFunction.GETLASTNODENAME:" + ex.Message;
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return alist;
        }
        /// <summary>
        /// 取药理作用常数表中一条记录 通过 PARENTID 取值
        /// </summary>
        /// 返回arraylist 参数 nodecode 是表中节点的编号
        [System.Obsolete("系统重构作废，用QueryFunctionByParentNode代替", true)]
        public ArrayList GetFunctionByParentNode(string Pnodecode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetComPhaFunction.BYPARENTNODE", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetComPhaFunction.BYPARENTNODE 字段!";
                return null;
            }
            strSQL = string.Format(strSQL, Pnodecode);
            //执行sql语句
            this.ExecQuery(strSQL);
            ArrayList alist = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.PhaFunction myFunction;
                while (this.Reader.Read())
                {

                    myFunction = new PhaFunction();
                    myFunction.ParentNode = this.Reader[0].ToString();							//0 父节点
                    myFunction.ID = this.Reader[1].ToString();								//1节点ID
                    myFunction.Name = this.Reader[2].ToString();								//2 节点名称
                    myFunction.NodeKind = NConvert.ToInt32(this.Reader[3].ToString());            //3节点类型
                    myFunction.GradeLevel = NConvert.ToInt32(this.Reader[4].ToString());        //4 级别
                    myFunction.SpellCode = this.Reader[5].ToString();							//5 拼音码
                    myFunction.WBCode = this.Reader[6].ToString();							//6 五笔码
                    myFunction.SortID = NConvert.ToInt32(this.Reader[7].ToString());           //7 自定义码
                    myFunction.IsValid = NConvert.ToBoolean(this.Reader[8].ToString());							//8 类型
                    myFunction.Memo = this.Reader[11].ToString();								//11备注      
                    this.ProgressBarValue++;
                    alist.Add(myFunction);
                }
            }
            catch (Exception ex)
            {
                this.Err = "取药品药理作用值失败" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return alist;
        }

        /// <summary>
        /// 药品公司（生产厂家或者供货公司）
        /// </summary>
        /// <param name="type">类型：0生产厂家，1供货公司</param>
        /// <returns>错误返回null</returns>
        [System.Obsolete("系统重构作废，用QueryCompany代替", true)]
        public ArrayList GetCompany(string type)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetCompany", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetCompany字段!";
                return null;
            }

            strSQL = string.Format(strSQL, type);
            //执行sql语句
            this.ExecQuery(strSQL);
            ArrayList al = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.Company company;
                while (this.Reader.Read())
                {
                    company = new Company();
                    company.ID = this.Reader[0].ToString();             //0 公司编码
                    company.Name = this.Reader[1].ToString();             //1 公司名称
                    company.RelationCollection.Address = this.Reader[2].ToString();         //2 地址
                    company.RelationCollection.Relative = this.Reader[3].ToString();        //3 联系方式
                    company.GMPInfo = this.Reader[4].ToString();         //4 GMP信息
                    company.GSPInfo = this.Reader[5].ToString();         //5 GSP信息
                    company.SpellCode = this.Reader[6].ToString();       //6 拼音码
                    company.WBCode = this.Reader[7].ToString();          //7 五笔码
                    company.UserCode = this.Reader[8].ToString();        //8 自定义码
                    company.Type = this.Reader[9].ToString();            //9 类型
                    company.OpenBank = this.Reader[10].ToString();       //10 开户银行
                    company.OpenAccounts = this.Reader[11].ToString();   //11 开户帐号
                    company.ActualRate = NConvert.ToDecimal(this.Reader[12].ToString());//12 加价率
                    company.Memo = this.Reader[13].ToString();           //13备注      
                    this.ProgressBarValue++;
                    al.Add(company);
                }
            }
            catch (Exception ex)
            {
                this.Err = "取药品公司时出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return al;
        }
        /// <summary>
        /// 根据供货公司编码获取供货公司实体
        /// </summary>
        /// <param name="companyID">供货公司编码</param>
        /// <returns>成功返回供货公司实体 失败返回null</returns>
        [System.Obsolete("系统重构作废，用QueryCompanyByCompanyID代替", true)]
        public Company GetCompanyByID(string companyID)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetCompanyByID", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetCompanyByID字段!";
                return null;
            }

            strSQL = string.Format(strSQL, companyID);
            //执行sql语句
            this.ExecQuery(strSQL);
            try
            {
                Neusoft.HISFC.Models.Pharmacy.Company company = new Company();
                if (this.Reader.Read())
                {
                    company.ID = this.Reader[0].ToString();             //0 公司编码
                    company.Name = this.Reader[1].ToString();             //1 公司名称
                    company.RelationCollection.Address = this.Reader[2].ToString();         //2 地址
                    company.RelationCollection.Relative = this.Reader[3].ToString();        //3 联系方式
                    company.GMPInfo = this.Reader[4].ToString();         //4 GMP信息
                    company.GSPInfo = this.Reader[5].ToString();         //5 GSP信息
                    company.SpellCode = this.Reader[6].ToString();       //6 拼音码
                    company.WBCode = this.Reader[7].ToString();          //7 五笔码
                    company.UserCode = this.Reader[8].ToString();        //8 自定义码
                    company.Type = this.Reader[9].ToString();            //9 类型
                    company.OpenBank = this.Reader[10].ToString();       //10 开户银行
                    company.OpenAccounts = this.Reader[11].ToString();   //11 开户帐号
                    company.ActualRate = NConvert.ToDecimal(this.Reader[12].ToString());//12 加价率
                    company.Memo = this.Reader[13].ToString();           //13备注   
                }

                if (company.Name == "")
                {
                    this.Err = "供货公司不存在 编码：" + companyID;
                    return null;
                }

                return company;
            }
            catch (Exception ex)
            {
                this.Err = "取药品公司时出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 根据药房药库名称获得取药科室名称
        /// </summary>
        /// <returns>neuObject数组，取药科室编号，取药科室名称，备注，操作员，操作时间</returns>
        [System.Obsolete("系统重构，用函数QueryReciveDrugDept替代", true)]
        public ArrayList GetDrugRoomCode(string ID)
        {
            string strSQL = "";  //取某一取药科室名称获得可以取药的药房名称列表的SQL语句
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDrugRoomCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDrugRoomCode字段!";
                return null;
            }

            strSQL = string.Format(strSQL, ID);
            //根据SQL语句取数组并返回数组
            ArrayList arrayObject = new ArrayList();

            this.ProgressBarText = "正在检索取药科室名称信息...";
            this.ProgressBarValue = 0;

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "取药科室名称列表时出错：" + this.Err;
                return null;
            }
            try
            {
                //	{取药科室编号,取药科室名称,操作员编号,操作员姓名,操作日期,备注,rowid}
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                while (this.Reader.Read())
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();					//取药科室编号
                    obj.Name = this.Reader[1].ToString();				//取药科室名称
                    obj.Memo = this.Reader[2].ToString();				//备注
                    obj.User01 = this.Reader[3].ToString();				//开始时间
                    obj.User02 = this.Reader[4].ToString();				//结束时间
                    obj.User03 = this.Reader[5].ToString();				//药品类型
                    this.ProgressBarValue++;
                    arrayObject.Add(obj);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "取药药房名称列表时，执行SQL语句出错！myGetDrugRoomCode" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            this.ProgressBarValue = -1;
            return arrayObject;
        }

        /// <summary>
        /// 根据病区编码、药品类型获取发药科室
        /// </summary>
        /// <param name="roomCode">取药病区</param>
        /// <param name="drugType">药品类型</param>
        /// <returns>成功返回取药科室数组(ID 编码 Name 名称) 失败返回null</returns>
        [System.Obsolete("系统重构，用函数QueryReciveDrugDept替代", true)]
        public ArrayList GetDeptCode(string roomCode, string drugType)
        {
            string strSQL = "";
            ArrayList arrayObject = new ArrayList();
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDeptCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDeptCode字段!";
                return null;
            }

            strSQL = string.Format(strSQL, roomCode, drugType);
            //根据SQL语句取数组并返回数组

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获取发药药房出错：" + this.Err;
                return null;
            }
            try
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                while (this.Reader.Read())
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();					//取药科室编号
                    obj.Name = this.Reader[1].ToString();				//取药科室名称
                    arrayObject.Add(obj);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "取药药房名称列表时，执行SQL语句出错！myGetDrugRoomCode" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return arrayObject;
        }

        /// <summary>
        /// 数据提交筛选（插入、更新、删除）
        /// </summary>
        /// <param name="drugRoomList">科室列表</param>
        /// <param name="i">操作标志：0插入1删除2更新</param>
        [System.Obsolete("系统重构，用函数DrugRoomControl替代", true)]
        public void drugRoomControl(ArrayList drugRoomList, int i)
        {
            try
            {
                switch (i)
                {
                    case 0:
                        foreach (Neusoft.FrameWork.Models.NeuObject obj in drugRoomList)
                        {
                            this.InsertDrugRoom(obj);			//插入数据
                        }
                        break;
                    case 1:
                        foreach (Neusoft.FrameWork.Models.NeuObject obj in drugRoomList)
                        {
                            this.DelSpeDrugRoom(obj.User03);	//删除数据
                        }
                        break;
                    case 2:
                        foreach (Neusoft.FrameWork.Models.NeuObject obj in drugRoomList)
                        {
                            this.UpdateDrugRoom(obj);			//更新数据
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                this.Err = "数据保存出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
            }
        }

        /// <summary>
        /// 根据科室编码取一条科室常数信息
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns>科室常数</returns>
        [System.Obsolete("系统重构，用函数QueryDeptConstant替代", true)]
        public Neusoft.HISFC.Models.Pharmacy.DeptConstant GetDeptConstant(string deptCode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDeptConstant", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDeptConstant字段!";
                return null;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDeptConstant.Where", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDeptConstant.Where字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, deptCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Constant.GetDeptConstant.Where:" + ex.Message;
                return null;
            }

            //取科室常数
            ArrayList al = this.myGetDeptConstant(strSQL);
            if (al == null)
                return null;

            if (al.Count == 0)
                return new Neusoft.HISFC.Models.Pharmacy.DeptConstant();

            return al[0] as Neusoft.HISFC.Models.Pharmacy.DeptConstant;
        }

        /// <summary>
        /// 取科室常数列表
        /// </summary>
        /// <returns>科室常数数组，出错返回null</returns>
        [System.Obsolete("系统重构，用函数QueryDeptConstantList替代", true)]
        public ArrayList GetDeptConstantList()
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Constant.GetDeptConstant", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Constant.GetDeptConstant字段!";
                return null;
            }

            //取科室常数数据
            return this.myGetDeptConstant(strSQL);
        }
        #endregion

        #region 医疗权限

        /// <summary>
        /// 查询医疗权限 by Sunjh 2009-6-5 {B0F08F1A-3E14-4e6a-8EFC-F10BC0AD3E35}
        /// </summary>
        /// <param name="levelCode">职级代码</param>
        /// <param name="popedonCode">权限代码</param>
        /// <param name="popedomType">权限类型 0药品性质 1药理作用</param>
        /// <returns>-1失败 0无权限 大于0有权限</returns>
        public int QueryPopedom(string levelCode, string popedonCode, int popedomType)
        {
            int popedomReturn = -1;
            string sqlStr = "";

            if (this.Sql.GetSql("Medical.Popedom.QueryByType", ref sqlStr) == -1)
            {
                this.Err = "没有找到Medical.Popedom.QueryByType字段!";
                return -1;
            }

            if (popedomType == 0)
            {
                sqlStr = string.Format(sqlStr, levelCode, "药品性质", popedonCode);
            }
            else if (popedomType == 1)
            {
                sqlStr = string.Format(sqlStr, levelCode, "药理作用", popedonCode);
            }
            else
            {
                return -1;
            }                        

            if (this.ExecQuery(sqlStr) == -1)
            {
                this.Err = "获取权限信息失败：" + this.Err;
                return -1;
            }
            try
            {
                while (this.Reader.Read())
                {
                    popedomReturn = Convert.ToInt32(this.Reader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                this.Err = "获取权限信息时,执行SQL语句出错!" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return -1;
            }
            finally
            {
                this.Reader.Close();
            }

            return popedomReturn;
        }

        #endregion

    }

}
