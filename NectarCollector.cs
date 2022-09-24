using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive
{
    internal class NectarCollector : Bee
    {
        const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;
        public override float CostPerShift
        {
            get
            {
                return 1.95f;
            }
        }

        public NectarCollector():base("Zbieraczka nektaru")
        {

        }

        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
}
