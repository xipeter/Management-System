using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.EPR
{
	/// <summary>
	/// QCInfo 的摘要说明。
	/// </summary>
	public class QCInfo:Neusoft.FrameWork.Management.Database
	{
		public QCInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 质控信息查询监控

		private string myInpatientNo ="";
        /// <summary>
        /// 病历信息数据库
        /// </summary>
        public string DataStoreEMR = "DataStore_emr";
        //EMR EMRManager = new EMR();//病历结点用的管理层
		QC  QCManager = new QC(); //质控病历管理层
		//private ArrayList alConditions =null; //条件
		/// <summary>
		/// 执行质控信息 -
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="iSql"></param>
		/// <param name="QC"></param>
		/// <returns></returns>
		public bool ExecQCInfo(string inpatientNo,Neusoft.FrameWork.Management.Interface iSql,Neusoft.HISFC.Models.EPR.QCConditions  QC)
		{
			int i =0;
			if(myInpatientNo != inpatientNo)//没有变更患者不更新患者的信息
			{
				myInpatientNo = inpatientNo;
				//更新常用变量
                i = iSql.GetPosition("[HIS_INPATIENT_NO]");
                if (i == -1)
                {
                    this.Err = "没有找到[HIS_INPATIENT_NO]";
                    return false;
                }
                iSql.SetValue("[HIS_INPATIENT_NO]", inpatientNo);
				iSql.RefreshVariant(Neusoft.FrameWork.Models.NeuInfo.infoType.Temp,i);
			}
            ArrayList alInputs = this.QCManager.GetQCInputCondition(inpatientNo);//输入数值
			for(i =0;i<QC.AlConditions.Count;i++)//查找每条质控条件-编写
			{
				Neusoft.HISFC.Models.EPR.QCCondition condition = QC.AlConditions[i] as Neusoft.HISFC.Models.EPR.QCCondition;//条件
				
				if(condition == null || condition.InfoName =="" || condition.InfoCondition =="") 
				{
					this.Err ="质控基础数据有问题！";
					this.WriteErr();
					return false;
				}
				//	"若输入 \'信息\'，符合\'条件\'", 0
				//	"若HIS\'信息\'，符合\'条件\'",  1
				//	"若病历 \'名称\'，已经\'建立\'", 2
				//	"若病历-\'名称\'，已经\'签名\'", 3
				//	"若病历+\'名称\'，建立时间,不在\'时间\'内", 4
				//	"若控件 \'名称\'，符合\'条件\'" 5
				string sTemp = condition.InfoName + " "+ condition.InfoCondition;

                Neusoft.FrameWork.Management.Caculation caculation = new Neusoft.FrameWork.Management.Caculation();
				bool bResult = false;
				Neusoft.HISFC.Models.EPR.QC data = null;
				bool bOld = false;
				bool bNew = false;
				string a = "",b = "";
				ArrayList al = null;
				switch(condition.ID)
				{
					case "0"://输入的控件结点
						//a = EMRManager.GetNodeValue("datastore_emr",inpatientNo,condition.InfoName);
                        #region 输入控件节点
                        a = "-1";
                        foreach (Neusoft.FrameWork.Models.NeuObject obj in alInputs)
                        {
                            if (obj.Name.Trim() == condition.InfoName.Trim())
                            {
                                a = obj.User01;
                                break;
                            }
                        }
						if(a =="-1" || a =="") 
							a ="";

						sTemp = a + " "+ condition.InfoCondition;

						if(condition.InfoCondition.ToLower()=="true" )//只是有数值
						{
							if( a.Trim()!="")
								bResult = true;
							else
								bResult = false;
						}
						else
						{
							sTemp = iSql.TransSql(sTemp);
							bResult = caculation._condition(sTemp);
                        }
                        #endregion
                        break;
					case "1"://his
						sTemp = iSql.TransSql(sTemp);
						bResult = caculation._condition(sTemp);
						break;
					case "2"://病历 建立
						 al = QCManager.GetQCData(inpatientNo,condition.InfoName);
						if(condition.InfoCondition =="建立" || condition.InfoCondition.ToUpper()=="TRUE") bNew = true;
						if(al !=null && al.Count>0)
						{
							data  =al[0] as Neusoft.HISFC.Models.EPR.QC;
							if(data !=null)
							{
								if(data.QCData.Creater.ID =="") bOld = false;
								else bOld = true;
								sTemp = data.QCData.Saver.ID;
							}
							else
							{
								bOld = false;
							}
						}
						else
						{
							bOld = false;
						}
						if(bNew == bOld ) 
							bResult = true;
						else
							bResult = false;
						
						sTemp = sTemp + bOld.ToString() + "&" + bNew.ToString();
						break;
					case "3"://病历 签名
						 al = QCManager.GetQCData(inpatientNo,condition.InfoName);
						if(condition.InfoCondition =="签名" || condition.InfoCondition.ToUpper()=="TRUE") bNew = true;
						if(al !=null && al.Count>0)
						{
							data  =al[0] as Neusoft.HISFC.Models.EPR.QC;
							if(data !=null)
							{
								if(data.QCData.Saver.ID =="") bOld = false;
								else bOld = true;

								sTemp = data.QCData.Saver.ID;
							}
							else
							{
								bOld = false;
							}
						}
						else
						{
							bOld = false;
						}

						if(bNew == bOld ) 
							bResult = true;
						else
							bResult = false;

						sTemp = sTemp + bOld.ToString() +"&"+ bNew.ToString();
						break;
					case "4"://病历建立时间
						al = QCManager.GetQCData(inpatientNo,condition.InfoName);
						sTemp ="{0} - {1} <= {2}";
						string[] sconditions = condition.InfoCondition.Split(',');
						if(al == null) return false;		
						//病程记录等需要连续记录的
						if(sconditions.Length>1)
						{
							for(int iCondtitions =0;iCondtitions<sconditions.Length;iCondtitions++)
							{
								foreach(Neusoft.HISFC.Models.EPR.QC data1 in al)
								{	
									if(data1 !=null)
									{
										sTemp = string.Format(sTemp,data1.QCData.Creater.Memo, caculation.f_cal(sconditions[iCondtitions]),24);
										sTemp = iSql.TransSql(sTemp);
										bResult = caculation._condition(sTemp);
										if(bResult)//成功
											break;
									}
									else
									{
										bResult = false;
									}
								}
								if(bResult == false) break;
							}
						}
						else //时间在上一个条件内
						{
							if(i >=1)
							{
								sTemp = "{0} - {1} <= {2}";
                                //a = EMRManager.GetNodeValue(DataStoreEMR, inpatientNo, ((Neusoft.HISFC.Models.EPR.QCCondition)QC.AlConditions[i - 1]).InfoName);
                                //b = EMRManager.GetNodeValue(DataStoreEMR, inpatientNo, condition.InfoName);					
								if(a =="-1") 
									a ="";
								if(b =="-1") 
									b ="";
								sTemp = string.Format(sTemp,a,b,condition.InfoCondition);
								bResult = caculation._condition(sTemp);
							}
							else
							{
								sTemp = "[NOW] - {0} <= {1}";
                                //a = EMRManager.GetNodeValue(DataStoreEMR, inpatientNo, condition.InfoName);
								if(a =="-1") 
									a ="";
								a = a+ condition.InfoCondition;
								sTemp = string.Format(sTemp,a,condition.InfoCondition);
								bResult = caculation._condition(sTemp);
							}
						}
						break;
					case "5"://控件结点符合
                        //a = EMRManager.GetNodeValue(DataStoreEMR, inpatientNo, condition.InfoName);
						if(a =="-1") 
							a ="";
						sTemp = a + condition.InfoCondition;
						bResult = caculation._condition(sTemp);
						break;
					default:
						break;
				}
				if(bResult== false) 
				{
					condition.Memo = sTemp +"结果："+bResult;
					return false;
				}
				condition.Memo = sTemp +"结果："+bResult;
			}
			return true;
		}
		#endregion
	}
}
