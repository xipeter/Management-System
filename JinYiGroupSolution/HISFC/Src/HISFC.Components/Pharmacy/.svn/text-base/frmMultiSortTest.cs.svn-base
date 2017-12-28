using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.UFC.Pharmacy
{
    public partial class frmMultiSortTest : Form
    {
        public frmMultiSortTest()
        {
            InitializeComponent();
        }

        private List<Neusoft.HISFC.Object.Pharmacy.Item> itemList = null;

        public void QueryItemList()
        {
            Neusoft.HISFC.Management.Pharmacy.Item itemManager = new Neusoft.HISFC.Management.Pharmacy.Item();
             itemList = itemManager.QueryItemList(true);

            this.neuSpread1_Sheet1.Rows.Count = itemList.Count;
            int i = 0;

            foreach (Neusoft.HISFC.Object.Pharmacy.Item item in itemList)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Text = item.ID;
                this.neuSpread1_Sheet1.Cells[i, 1].Text = item.Name + "[" + item.Specs + "]";
                this.neuSpread1_Sheet1.Cells[i, 2].Text = item.NameCollection.UserCode;
                this.neuSpread1_Sheet1.Cells[i, 3].Text = item.Product.Company.ID;
                this.neuSpread1_Sheet1.Cells[i, 4].Text = item.Type.ID;
                this.neuSpread1_Sheet1.Cells[i, 5].Text = item.DosageForm.ID;

                i++;
            }


        }

        public void MultiSort(List<Neusoft.HISFC.Object.Pharmacy.Item> subList,ref List<Neusoft.HISFC.Object.Pharmacy.Item> parentList, IComparer<Neusoft.HISFC.Object.Pharmacy.Item> compare,int compareLevel)
        {
            if (subList.Count == 1)     //只有一个项目
            {
                parentList.Add(subList[0]);
                return;
            }
            if (compare == null)
            {
                parentList.AddRange(subList);
                return;
            }

            subList.Sort(compare);

            List<List<Neusoft.HISFC.Object.Pharmacy.Item>> subListCollecte = this.QuerySubList(subList, compareLevel);

            compareLevel++;

            foreach (List<Neusoft.HISFC.Object.Pharmacy.Item> list in subListCollecte)
            {
                compare = this.GetCompare(compareLevel);

                MultiSort(list,ref parentList, compare,compareLevel);
            }            
        }        

        public List<List<Neusoft.HISFC.Object.Pharmacy.Item>> QuerySubList(List<Neusoft.HISFC.Object.Pharmacy.Item> parentList,int compareLevel)
        {
            List<List<Neusoft.HISFC.Object.Pharmacy.Item>> subList = new List<List<Neusoft.HISFC.Object.Pharmacy.Item>>();
            System.Collections.Hashtable hsSub = new System.Collections.Hashtable();

            switch (compareLevel)
            {
                case 1:                   
                    List<Neusoft.HISFC.Object.Pharmacy.Item> divList = new List<Neusoft.HISFC.Object.Pharmacy.Item>();

                    foreach (Neusoft.HISFC.Object.Pharmacy.Item item in parentList)
                    {
                        if (hsSub.ContainsKey(item.NameCollection.UserCode.Substring(0, 1)))
                        {
                            divList = hsSub[item.NameCollection.UserCode.Substring(0, 1)] as List<Neusoft.HISFC.Object.Pharmacy.Item>;
                            divList.Add(item);
                        }
                        else
                        {
                            divList = new List<Neusoft.HISFC.Object.Pharmacy.Item>();
                            divList.Add(item);
                            hsSub.Add(item.NameCollection.UserCode.Substring(0, 1), divList);
                        }
                    }
                    
                    break;
                case 0:
                    List<Neusoft.HISFC.Object.Pharmacy.Item> divTypeList = new List<Neusoft.HISFC.Object.Pharmacy.Item>();

                    foreach (Neusoft.HISFC.Object.Pharmacy.Item item in parentList)
                    {
                        if (hsSub.ContainsKey(item.Type.ID))
                        {
                            divTypeList = hsSub[item.Type.ID] as List<Neusoft.HISFC.Object.Pharmacy.Item>;
                            divTypeList.Add(item);
                        }
                        else
                        {
                            divTypeList = new List<Neusoft.HISFC.Object.Pharmacy.Item>();
                            divTypeList.Add(item);

                            hsSub.Add(item.Type.ID, divTypeList);
                        }
                    }
                    break;
                case 2:
                    List<Neusoft.HISFC.Object.Pharmacy.Item> divIDList = new List<Neusoft.HISFC.Object.Pharmacy.Item>();

                    foreach (Neusoft.HISFC.Object.Pharmacy.Item item in parentList)
                    {
                        if (hsSub.ContainsKey(item.ID))
                        {
                            divIDList = hsSub[item.ID] as List<Neusoft.HISFC.Object.Pharmacy.Item>;
                            divIDList.Add(item);
                        }
                        else
                        {
                            divIDList = new List<Neusoft.HISFC.Object.Pharmacy.Item>();
                            divIDList.Add(item);
                            hsSub.Add(item.ID, divIDList);
                        }
                    }
                    break;
            }
           
            foreach (List<Neusoft.HISFC.Object.Pharmacy.Item> list in hsSub.Values)
            {
                subList.Add(list);
            }

            if (subList.Count == 0)
            {
                subList.Add(parentList);
            }

            return subList;
        }

        public IComparer<Neusoft.HISFC.Object.Pharmacy.Item> GetCompare(int compareLevel)
        {
            if (compareLevel > 1)
            {
                return null;
            }
            CompareItem c = new CompareItem();
            c.compareLevel = compareLevel;

            return c;
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            this.QueryItemList();
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            List<Neusoft.HISFC.Object.Pharmacy.Item> sortList = new List<Neusoft.HISFC.Object.Pharmacy.Item>();

            IComparer<Neusoft.HISFC.Object.Pharmacy.Item> sortCom = this.GetCompare(0);
            this.MultiSort(this.itemList, ref sortList, sortCom, 0);

            this.neuSpread1_Sheet1.Rows.Count = sortList.Count;
            int i = 0;
            foreach (Neusoft.HISFC.Object.Pharmacy.Item item in sortList)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Text = item.ID;
                this.neuSpread1_Sheet1.Cells[i, 1].Text = item.Name + "[" + item.Specs + "]";
                this.neuSpread1_Sheet1.Cells[i, 2].Text = item.NameCollection.UserCode;
                this.neuSpread1_Sheet1.Cells[i, 3].Text = item.Product.Company.ID;
                this.neuSpread1_Sheet1.Cells[i, 4].Text = item.Type.ID;
                this.neuSpread1_Sheet1.Cells[i, 5].Text = item.DosageForm.ID;

                i++;
            }
        }
    }

    public class CompareItem : IComparer<Neusoft.HISFC.Object.Pharmacy.Item>
    {
        public int compareLevel = 0;

        #region IComparer<Item> 成员

        public int Compare(Neusoft.HISFC.Object.Pharmacy.Item x, Neusoft.HISFC.Object.Pharmacy.Item y)
        {
            string oX = null;
            string oY = null;
            int nComp = 0;
            switch (this.compareLevel)
            {
                case 0:
                    oX = x.NameCollection.UserCode;
                    oY = y.NameCollection.UserCode;                  
                    break;
                case 1:
                    oX = x.Type.ID;
                    oY = y.Type.ID;
                    break;
                case 2:
                    oX = x.ID;
                    oY = y.ID;
                    break;
            }

            if (oX == null) { nComp = (oY != null) ? -1 : 0; }
            else if (oY == null) { nComp = 1; }
            else { nComp = string.Compare(oX.ToString(), oY.ToString()); }
            return nComp;
        }

        #endregion
    }
}