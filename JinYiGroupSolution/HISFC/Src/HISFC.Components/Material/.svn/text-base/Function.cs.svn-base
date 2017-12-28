using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Xml;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Material
{
    public class Function
    {
        public Function()
        {

        }

        #region 单据打印接口

        /// <summary>
        /// 单据打印接口
        /// </summary>
        public static Neusoft.HISFC.BizProcess.Interface.Material.IBillPrint IPrint = null;

        #endregion

        /// <summary>
        /// 根据Xml文件配置 返回 DataTable
        /// </summary>
        /// <param name="xmlFilePath">Xml配置文件路径</param>
        /// <returns>成功返回DataTable 发生错误返回Null</returns>
        public static DataTable GetDataTableFromXml(string xmlFilePath)
        {
            DataTable dt = new DataTable();
            if (System.IO.File.Exists(xmlFilePath))
            {
                XmlDocument doc = new XmlDocument();
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(xmlFilePath, System.Text.Encoding.Default);
                    string streamXml = sr.ReadToEnd();
                    sr.Close();
                    doc.LoadXml(streamXml);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(Language.Msg("读取Xml配置文件发生错误 请检查配置文件是否正确") + ex.Message);
                    return null;
                }

                try
                {

                    XmlNodeList nodes = doc.SelectNodes("//Column");

                    string tempString = "";

                    foreach (XmlNode node in nodes)
                    {
                        switch (node.Attributes["type"].Value)
                        {
                            case "TextCellType":
                            case "ComboBoxCellType":
                                tempString = "System.String";
                                break;
                            case "CheckBoxCellType":
                                tempString = "System.Boolean";
                                break;
                            case "DateTimeCellType":
                                tempString = "System.DateTime";
                                break;
                            case "NumberCellType":
                                tempString = "System.Decimal";
                                break;
                        }

                        dt.Columns.Add(new DataColumn(node.Attributes["displayname"].Value,
                            System.Type.GetType(tempString)));
                    }
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show(Language.Msg("Xml文件格式不正确"));
                    return null;
                }
            }

            return dt;
        }

        /// <summary>
        /// 根据药品名称的默认过滤字段 返回过滤字符串
        /// </summary>
        /// <param name="dv">需过滤的DataView</param>
        /// <param name="queryCode">过滤数据字符串</param>
        /// <returns>成功返回过滤字符串 失败返回null</returns>
        public static string GetFilterStr(DataView dv, string queryCode)
        {
            string filterStr = "";
            if (dv.Table.Columns.Contains("拼音码"))
                filterStr = Function.ConnectFilterStr(filterStr, string.Format("拼音码 like '{0}'", queryCode), "or");
            if (dv.Table.Columns.Contains("五笔码"))
                filterStr = Function.ConnectFilterStr(filterStr, string.Format("五笔码 like '{0}'", queryCode), "or");
            if (dv.Table.Columns.Contains("自定义码"))
                filterStr = Function.ConnectFilterStr(filterStr, string.Format("自定义码 like '{0}'", queryCode), "or");
            if (dv.Table.Columns.Contains("物品名称"))
                filterStr = Function.ConnectFilterStr(filterStr, string.Format("物品名称 like '{0}'", queryCode), "or");
            return filterStr;
        }

        /// <summary>
        /// 返回过滤字符串
        /// </summary>
        /// <param name="dv">需过滤的DataView</param>
        /// <param name="queryCode">过滤数据字符串</param>
        /// <param name="filterIndex">需过滤的列索引</param>
        /// <returns>成功返回过滤字符串</returns>
        public static string GetFilterStr(DataView dv, string queryCode, params int[] filterIndex)
        {
            string filterStr = "";

            for (int i = 0; i < filterIndex.Length; i++)
            {
                filterStr = Function.ConnectFilterStr(filterStr, string.Format(dv.Table.Columns[filterIndex[i]] + " like '{0}'", queryCode), "or");
            }

            return filterStr;
        }

        /// <summary>
        /// 连接过滤字符串
        /// </summary>
        /// <param name="filterStr">原始过滤字符串</param>
        /// <param name="newFilterStr">新增加的过滤条件</param>
        /// <param name="logicExpression">逻辑运算符</param>
        /// <returns>成功返回连接后的过滤字符串</returns>
        public static string ConnectFilterStr(string filterStr, string newFilterStr, string logicExpression)
        {
            string connectStr = "";
            if (filterStr == "")
                connectStr = newFilterStr;
            else
                connectStr = filterStr + " " + logicExpression + " " + newFilterStr;

            return connectStr;
        }

        /// <summary>
        /// 快速查询窗口
        /// </summary>
        /// <param name="arrayList">传入数据</param>
        /// <param name="farPointLabel">FarPoint内列名显示 最大为6列</param>
        /// <param name="farPointWidth">FarPoint内各列宽度 数组最大为6</param>
        /// <param name="farPointVisible">FarPoint内各列是否隐藏 数组最大为6</param>
        /// <param name="NeuObject">NeuObject对象</param>
        /// <returns>1选择新数据，0没有选择</returns>
        public static int ChooseItem(ArrayList arrayList, string[] farPointLabel, float[] farPointWidth, bool[] farPointVisible, ref Neusoft.FrameWork.Models.NeuObject NeuObject)
        {
            //frmUserDefineEasyChoose form = new frmUserDefineEasyChoose(arrayList);
            //form.FarPointLabel = farPointLabel;
            //form.FarPointWidth = farPointWidth;
            //form.FarPointVisible = farPointVisible;

            ////调用查询窗口
            //System.Windows.Forms.DialogResult Result = form.ShowDialog();
            ////取窗口返回的起始日期和终止日期
            //if (Result == DialogResult.OK)
            //{
            //    NeuObject = form.Object;
            //    //取到新数据，则返回1
            //    return 1;
            //}

            ////如果没有选择数据，则返回0
            return 0;
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="errStr">提示信息</param>
        public static void ShowMsg(string strMsg)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            System.Windows.Forms.MessageBox.Show(Language.Msg(strMsg));
        }

        /// <summary>
        /// 模版选择
        /// </summary>
        /// <param name="privDept">权限科室</param>
        /// <param name="openType">模版类型</param>
        /// <returns>成功返回模版信息  失败返回null</returns>
        /*
        internal static ArrayList ChooseDrugStencil(string privDept, Neusoft.HISFC.Models.Pharmacy.EnumDrugStencil stencilType)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

            ArrayList alList = consManager.QueryDrugStencilList(privDept, stencilType);
            if (alList == null)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("获取该类型模版发生错误" + consManager.Err));
                return null;
            }
            if (alList.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("无该类型模版数据"));
                return null;
            }

            ArrayList alSelect = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject selectObj = new Neusoft.FrameWork.Models.NeuObject();
            foreach (Neusoft.HISFC.Models.Pharmacy.DrugStencil temp in alList)
            {
                selectObj = new Neusoft.FrameWork.Models.NeuObject();
                selectObj.ID = temp.Stencil.ID;
                selectObj.Name = temp.Stencil.Name;
                selectObj.Memo = temp.OpenType.Name;

                alSelect.Add(selectObj);
            }

            string[] label = { "模版编码", "模版名称", "模版类型" };
            float[] width = { 60F, 100F, 120F };
            bool[] visible = { true, true, true, false, false, false };
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alSelect, ref selectObj) == 0)
            {
                return new ArrayList();
            }
            else
            {
                ArrayList alOpenDetail = new ArrayList();

                alOpenDetail = consManager.QueryDrugStencil(selectObj.ID);
                if (alOpenDetail == null)
                {
                    System.Windows.Forms.MessageBox.Show(Language.Msg(consManager.Err));
                    return null;
                }

                return alOpenDetail;
            }
        }
        */
        /// <summary>
        /// 获取提示信息
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public static string GetNote(string itemCode)
        {
            Neusoft.HISFC.BizLogic.Material.MetItem myItem = new Neusoft.HISFC.BizLogic.Material.MetItem();

            Neusoft.HISFC.BizLogic.Material.ComCompany myCom = new Neusoft.HISFC.BizLogic.Material.ComCompany();

            Neusoft.HISFC.Models.Material.MaterialItem item = myItem.GetMetItemByMetID(itemCode);

            Neusoft.HISFC.Models.Material.MaterialCompany company = myCom.QueryCompanyByCompanyID(item.Company.ID,"A","A");

            DateTime dtNow = myItem.GetDateTimeFromSysDateTime();

            string note = "";

            if (company != null)
            {
                if (company.BusinessDate < dtNow)
                {
                    note += "营业执照已经到期!" + "\n";
                }
                if (company.DutyDate < dtNow)
                {
                    note += "税务登记证已经到期!" + "\n";
                }
                if (company.OrgDate < dtNow)
                {
                    note += "组织机构代码证已经到期!" + "\n";
                }
            }

            return note;
        }

        internal static FarPoint.Win.Spread.CellType.ICellType GetReadOnlyCellType()
        {
            FarPoint.Win.Spread.CellType.TextCellType t = new FarPoint.Win.Spread.CellType.TextCellType();
            t.ReadOnly = true;

            return t;
        }

    }
    
}
