using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse
{
    public class Function
    {
        public Function()
        {
        }

        /// <summary>
        /// 获取午别
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static string GetNoon(DateTime current)
        {
            Neusoft.HISFC.BizProcess.Integrate.Registration.Registration schemaMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

            ArrayList alNoon = schemaMgr.Query();
            if (alNoon == null) return "";
            /*
             * 实际午别为医生出诊时间段,上午可能为08~11:30，下午为14~17:30
             * 所以挂号员如果不在这个时间段挂号,就有可能提示午别未维护
             * 所以改为根据传人时间所在的午别例如：9：30在06~12之间，那么就判断是否有午别在
             * 06~12之间，全包含就说明9:30是那个午别代码
             */

            int[,] zones = new int[,] { { 0, 120000 }, { 120000, 180000 }, { 180000, 235959 } };
            int time = int.Parse(current.ToString("HHmmss"));
            int begin = 0, end = 0;

            for (int i = 0; i < 3; i++)
            {
                if (zones[i, 0] <= time && zones[i, 1] > time)
                {
                    begin = zones[i, 0];
                    end = zones[i, 1];
                    break;
                }
            }

            foreach (Neusoft.HISFC.Models.Registration.Noon obj in alNoon)
            {
                if (int.Parse(obj.BeginTime.ToString("HHmmss")) >= begin &&
                    int.Parse(obj.EndTime.ToString("HHmmss")) <= end)
                {
                    return obj.ID;
                }
            }

            return "";
        }

        /// <summary>
        /// 分诊
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="assign"></param>
        /// <param name="TrigeWhereFlag">分诊标志 1.分到队列  2.分到诊台</param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static int Triage( Neusoft.HISFC.Models.Nurse.Assign assign,
            string TrigeWhereFlag, ref string error)
        {

            Neusoft.HISFC.BizLogic.Nurse.Assign assignMgr = new Neusoft.HISFC.BizLogic.Nurse.Assign();
            
            Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

            try
            {
                //assignMgr.SetTrans(trans.Trans);
                //regMgr.SetTrans(trans.Trans);

                //1、获取队列最大看诊序号
                assign.SeeNO = assignMgr.Query((assign.Queue as Neusoft.FrameWork.Models.NeuObject));
                if (assign.SeeNO == -1)
                {
                    error = assignMgr.Err;
                    return -1;
                }

                assign.SeeNO = assign.SeeNO + 1;
                //专家的直接取 时间段内的看诊序号
                //				if(neusoft.neNeusoft.HISFC.Components.Function.NConvert.ToInt32(assign.Register.IsPre) == 1)
                if (assign.Register.DoctorInfo.Templet.Doct.ID != null && assign.Register.DoctorInfo.Templet.Doct.ID != "")
                {
                    assign.SeeNO = assign.Register.DoctorInfo.SeeNO;
                }

                //2、插入分诊信息表
                if (assignMgr.Insert(assign) == -1)
                {
                    error = assignMgr.Err;
                    return -1;
                }

                //3、更新挂号信息表，置分诊标志
                Neusoft.HISFC.BizLogic.Nurse.Assign a = new Neusoft.HISFC.BizLogic.Nurse.Assign();
                //a.SetTrans(trans.Trans);
                if (regMgr.Update(assign.Register.ID, Neusoft.FrameWork.Management.Connection.Operator.ID,
                    a.GetDateTimeFromSysDateTime()/*regMgr.GetDateTimeFromSysDateTime()*/) == -1)
                {
                    error = regMgr.Err;                    
                    return -1;
                }
                //4.队列数量增加1
                if (assignMgr.UpdateQueue(assign.Queue.ID, "1") == -1)
                {
                    error = assignMgr.Err;
                    return -1;
                }

            }
            catch (Exception e)
            {
                error = e.Message;
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 取消分诊
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="assign"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static int CancelTriage(Neusoft.HISFC.Models.Nurse.Assign assign, ref string error)
        {
            Neusoft.HISFC.BizLogic.Nurse.Assign assignMgr = new Neusoft.HISFC.BizLogic.Nurse.Assign();

            Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

            try
            {
                //assignMgr.SetTrans(trans.Trans);
                //regMgr.SetTrans(trans.Trans);

                //删除分诊信息
                int rtn = assignMgr.Delete(assign);
                if (rtn == -1)//出错
                {
                    error = assignMgr.Err;
                    return -1;
                }

                if (rtn == 0)
                {
                    error = "该分诊信息状态已经发生改变,请刷新屏幕!";
                    return -1;
                }
                //恢复挂号信息的分诊状态
                rtn = regMgr.CancelTriage(assign.Register.ID);
                if (rtn == -1)
                {
                    error = regMgr.Err;
                    return -1;
                }
                //4.队列数量-1
                if (assignMgr.UpdateQueue(assign.Queue.ID, "-1") == -1)
                {
                    error = assignMgr.Err;
                    return -1;
                }
            }
            catch (Exception e)
            {
                error = e.Message;
                return -1;
            }

            return 0;
        }
    }

    [System.Xml.Serialization.XmlRoot()]
    public struct RefreshFrequence
    {
        /// <summary>
        /// 如果为:10则代表十秒
        /// 
        /// 默认为:"no"不刷新
        /// </summary>
        public string RefreshTime;

        /// <summary>
        /// 是否允许自动分诊
        /// </summary>
        public bool IsAutoTriage;
    }
}