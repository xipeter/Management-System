﻿using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.BizLogic.Privilege.Service;
using Neusoft.HISFC.BizLogic.Privilege.Model;
using System.Windows.Forms;
using Neusoft.FrameWork.Models;//{A93EE0CA-F50E-4142-8477-761E257AC974}

namespace HIS
{
    public class LoginFunction
    {
        private static int intLoginAttempts;
        public static  int Login(string account, string password)
        {
            NeuPrincipal _principal = null;
            NeuIdentity _identity = null;

            if (Program.isMessageShow == true)
            {
                Program.isMessageShow = false;
                return -1;
            }
            //认证
            PrivilegeService proxy = new PrivilegeService();
            try
            {
           
                _identity = proxy.Authenticate(account, password, "");
                   ///
                ///查询该用户拥有的角色
                IList<Role> _roles;

                using (proxy as IDisposable)
                {
                    //表更改了，所以修改了SQL语句（张凯钧）Security.Org.GetRoleByUserID
                    _roles = proxy.QueryRole(_identity.User.Id);
                }

                if (_roles == null | _roles.Count == 0)
                {
                    Program.isMessageShow = false;
                    MessageBox.Show("该用户没有进行角色授权!");
                    Program.isMessageShow = true;
                    return -1;
                }

                _principal = new NeuPrincipal(_identity, _roles);
            }
            catch (Exception ex)
            {

                if (ex.InnerException == null)
                {
                    Program.isMessageShow = false;
                    MessageBox.Show(ex.Message);
                    Program.isMessageShow = true;
                }
                else
                {
                    SystemErrorForm _error = new SystemErrorForm(ex);
                    _error.ShowDialog();
                }

                return -1;
            }

            if (_principal.Identity.IsAuthenticated)
            {
                //加载选择角色科室界面
                Role _role = SelectLoginRole((_principal.Identity as NeuIdentity).User, _principal.Roles);

                if (_role == null)
                {
                    Application.Exit();
                    //{AE0687E4-FE13-4b00-8865-738F84B74BB2}
                    return -1;
                }

                //通过认证以后，给当前角色赋值；
                _principal.CurrentRole = _role;


                //设置登录时间
                _principal.LoginTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(new Neusoft.FrameWork.Management.DataBaseManger().GetSysDateTime());

                //设置当前操作员信息
                SetLoginUser((_principal.Identity as NeuIdentity).User, (Neusoft.FrameWork.Models.NeuObject)_principal.CurrentRole, _principal.CurrentRole.UnitId);

            }
            return 0;
        }

        public static Role SelectLoginRole(User user, IList<Role> roles)
        {
            SelectRoleForm _frmSelectRole = null;
            Role _role = null;


            _frmSelectRole = new SelectRoleForm(user, roles);
            if (_frmSelectRole.ShowDialog() == DialogResult.OK)
            {
                _role = _frmSelectRole.SelectedRole;
            }

            _frmSelectRole.Dispose();

            return _role;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="currentGroup"></param>
        /// <param name="loginDept"></param>
        public static void SetLoginUser(User currentUser, Neusoft.FrameWork.Models.NeuObject currentGroup, string loginDeptId)
        {
            Neusoft.HISFC.Models.Base.Employee user = new Neusoft.HISFC.Models.Base.Employee();
            Neusoft.HISFC.BizLogic.Manager.Department manager = new Neusoft.HISFC.BizLogic.Manager.Department();
            Neusoft.HISFC.BizLogic.Manager.UserManager userManager = new Neusoft.HISFC.BizLogic.Manager.UserManager();

            //Neusoft.FrameWork.Public.ObjectHelper helper = new Neusoft.FrameWork.Public.ObjectHelper(manager.QueryValidDept());
            Neusoft.HISFC.Models.Base.Department dept = null;
            if (currentUser.Id.Trim().ToLower() == "admin")
            {
                user.ID = "admin";
                user.Name = "manager";
                user.IsManager = true;

            }
            else
            {
                user = userManager.GetPerson(currentUser.PersonId);
                if (user == null)
                {
                    MessageBox.Show("系统中已经没有该用户！");
                    Application.Exit();
                    return;
                }
                if (user.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                {
                    MessageBox.Show("该用户已经停用！");
                    Application.Exit();
                    return;
                }
                if (user.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Ignore)
                {
                    MessageBox.Show("该用户已经作废！");
                    Application.Exit();
                    return;
                }
                dept = manager.GetDeptmentById(loginDeptId);
                if (dept == null)
                {
                    MessageBox.Show("获得登录科室信息失败！");
                    Application.Exit();
                    return;
                }

                //if(manager.GetNurseStationFromDept(user.Dept).Count>0)
                //user.Nurse = manager.GetNurseStationFromDept(user.Dept)[0] as Neusoft.FrameWork.Models.NeuObject;


            }
            //user.IsManager = true;

            user.CurrentGroup = currentGroup;

            if (dept != null)
            {
                user.Dept = dept;
                if (dept.DeptType.ID.ToString() == "N")
                {
                    user.Nurse = dept;
                }
                else
                {
                    System.Collections.ArrayList al = manager.GetNurseStationFromDept(dept);
                    if (al != null && al.Count > 0)
                    {
                        user.Nurse = al[0] as Neusoft.FrameWork.Models.NeuObject;
                    }
                    else
                    {
                        user.Nurse = dept;
                    }

                }
            }

            //user.Dept = helper.GetObjectFromID(loginDeptId);
            //if (user.Dept == null)
            //    user.Dept = new Neusoft.FrameWork.Models.NeuObject();

            user.User01 = currentUser.Account;
            ////{D515E09B-E299-47e0-BF19-EDFDB6E4C775}
            //user.Password =Neusoft.HisDecrypt.Decrypt( currentUser.Password);
            user.Password = Neusoft.HisCrypto.DESCryptoService.DESDecrypt(currentUser.Password,Neusoft.FrameWork.Management.Connection.DESKey);
            Neusoft.FrameWork.Management.Connection.Operator = user;

           // #region 电子申请单初始化 addby zhangkj {A93EE0CA-F50E-4142-8477-761E257AC974}
           //// Neusoft.ApplyInterface.HisInterface applyInter = new Neusoft.ApplyInterface.HisInterface();
           // List<Neusoft.FrameWork.Models.NeuObject> parmsApply = new List<Neusoft.FrameWork.Models.NeuObject>();
           // NeuObject obj1 = new NeuObject();
           // obj1.ID = user.ID;
           // obj1.Name = user.Name;
           // parmsApply.Add(obj1);
           // parmsApply.Add(user.Dept);
           // parmsApply.Add(user.CurrentGroup);
           // //applyInter.InitHis50(parmsApply);
           // #endregion
            Neusoft.HISFC.Components.Manager.Classes.Function.HISMonitor();



        }

     
    }

  
}
