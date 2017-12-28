using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.Server
{
    public static class OperationPool
    {
        private static Dictionary<string, Neusoft.FrameWork.Models.NeuObject> Operations = new Dictionary<string, Neusoft.FrameWork.Models.NeuObject>();

        public static Neusoft.FrameWork.Models.NeuObject GetOperation(string id)
        {
            if (Operations.ContainsKey(id))
            {
                return Operations[id];
            }
            else
            {
                return null;
            }
        }

        public static void SetOperation(string id, Neusoft.FrameWork.Models.NeuObject Operation)
        {
            Operations[id] = Operation;
        }

        public static void RemoveOperation(string id)
        {
            if (Operations.ContainsKey(id))
            {
                try
                {
                    Operations[id].Dispose();
                }
                catch { }
                Operations.Remove(id);
            }
        }

        public static Dictionary<string, Neusoft.FrameWork.Models.NeuObject> GetOperationList()
        {
            return Operations;
        }
    }
}
