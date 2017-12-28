using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.Privilege.BizLogic.Model;
using Neusoft.Privilege.BizLogic.Service;
using Neusoft.Privilege;



namespace Neusoft.UFC.Privilege
{
    public partial class AuthorizeOrganizationControl : UserControl
    {
        public string pageJudge = "OrgRes";
        public Role currentRole = null;
        private List<RoleResourceMapping> currentRoleResourcList = null;
        private List<RoleResourceMapping> saveRoleResourcList = new List<RoleResourceMapping>();

        public AuthorizeOrganizationControl()
        {
            InitializeComponent();

        }

        public void SaveRoleOrg()
        {
            saveRoleResourcList.Clear();
            SetRoleOrgValue();
            PrivilegeService proxy = Common.Util.CreateProxy();
            using (proxy as IDisposable)
            {
                try
                {
                    NFC.Management.PublicTrans.BeginTransaction();
                    int ret = proxy.SaveRoleOrg(saveRoleResourcList, currentRoleResourcList);
                    if (ret == 1)
                    {
                        MessageBox.Show("保存成功！");
                    }
                    NFC.Management.PublicTrans.Commit();
                }
                catch (Exception e)
                {
                    NFC.Management.PublicTrans.RollBack();
                    throw e;
                       
                }
            }
        }


        private void SetRoleOrgValue()
        {
            foreach (TreeListViewItem newItem in nTreeListView1.Items)
            {
                RoleResourceMapping newRoleRes = new RoleResourceMapping();
                if (newItem.Checked == true)
                {
                    string[] orgTypeArray = newItem.Tag as string[];
                    newRoleRes.Id = new NFC.Management.DataBaseManger().GetSequence("PRIV.SEQ_ROLE_RESOURCE ");
                    newRoleRes.Type = pageJudge;
                    newRoleRes.OperCode = ((Context.Operator as NeuPrincipal).Identity as NeuIdentity).User.Id;
                    newRoleRes.OperDate = NFC.Function.NConvert.ToDateTime(new NFC.Management.DataBaseManger().GetSysDateTime());
                    newRoleRes.Resource.Id = orgTypeArray[0];
                    newRoleRes.Name = orgTypeArray[1];
                    newRoleRes.Parameter = orgTypeArray[2];
                    newRoleRes.Role.Id = currentRole.Id;
                    //newRoleRes.Parameter=newItem.

                    saveRoleResourcList.Add(newRoleRes);
                }
            }
        }

        private void LoadTreeListView()
        {
            List<String> orgTypeList = new List<string>();
            PrivilegeService _proxy = Common.Util.CreateProxy();
            using (_proxy as IDisposable)
            {
                IList<String> keys = null;
                keys = _proxy.QueryAppID();
                if (keys != null)
                {
                    foreach (string key in keys)
                    {
                        List<String> orgType = _proxy.GetOrgType(key);
                        if (orgType != null)
                        {
                            foreach (String orgtypeone in orgType)
                            {
                                orgTypeList.Add(orgtypeone);
                            }
                        }
                    }
                }
                //orgTypeList = _proxy.GetOrgType("HIS");

                currentRoleResourcList = _proxy.QueryByTypeRoleId(pageJudge, currentRole.Id);
            }

            foreach (string orgType in orgTypeList)
            {
                string[] orgTypeArray = orgType.Split('|');
                TreeListViewItem item = new TreeListViewItem();
                item.Text = orgTypeArray[1].ToString();
                item.Name = orgTypeArray[0].ToString();
                item.Tag = orgTypeArray;
                item.ImageIndex = 0;
                item.SubItems.AddRange(new string[] { orgTypeArray[0], orgTypeArray[2] == "isDepTrue" ? "是" : "否" });

                nTreeListView1.Items.Add(item);
            }

            if (currentRoleResourcList != null || currentRoleResourcList.Count != 0)
            {
                for (int item = 0; item < nTreeListView1.ItemsCount; item++)
                {
                    foreach (RoleResourceMapping roleRes in currentRoleResourcList)
                    {
                        if (nTreeListView1.Items[item].Name == roleRes.Resource.Id)
                        {
                            nTreeListView1.Items[item].Checked = true;
                        }
                    }
                }
            }


        }

        private void AuthorizeOrganizationControl_Load(object sender, EventArgs e)
        {
            LoadTreeListView();
        }



    }
}
