using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Material
{
    public interface IFactory
    {
        Neusoft.HISFC.Components.Material.IMatManager GetInInstance(Neusoft.FrameWork.Models.NeuObject inPrivType, Neusoft.HISFC.Components.Material.In.ucMatIn ucMatManager);


        Neusoft.HISFC.Components.Material.IMatManager GetOutInstance(Neusoft.FrameWork.Models.NeuObject outPrivType, Neusoft.HISFC.Components.Material.Out.ucMatOut ucMatManager);      
    }
}
