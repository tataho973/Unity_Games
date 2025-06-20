using System.Collections.Generic;
using LTX.Singletons;

namespace Plant_Grow
{
    public class PlanteManager : MonoSingleton<PlanteManager>
    {
        private List<Plante> plantes;
        
        private void Update()
        {
            for (int i = 0; i < plantes.Count; i++)
            {
                Plante plante = plantes[i];
                plante.Refresh();
            }
        }
    }
}