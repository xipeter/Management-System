using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Interface.Equipment
{
    /// <summary>
    /// IApplyPrint<br></br>
    /// [��������: �豸���ⵥ��ӡ�ӿ�]<br></br>
    /// [�� �� ��: ������]<br></br>
    /// [����ʱ��: 2007-12-9]<br></br>
    /// <�޸ļ�¼
    ///		�޸���=''
    ///		�޸�ʱ��='yyyy-mm-dd'
    ///		�޸�Ŀ��=''
    ///		�޸�����=''
    ///  />
    /// </summary>
    public interface IOutPrint
    {
        void SetPrintData(List<Neusoft.HISFC.Models.Equipment.Output> outputList);

        /// <summary>
        /// ��ӡԤ��
        /// </summary>
        /// <returns>>�ɹ� 1 ʧ�� -1</returns>
        int PrintView();

        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <returns>�ɹ� 1 ʧ�� -1</returns>
        int Print();
    }
}