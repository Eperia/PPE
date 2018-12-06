using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Class
{
    class HistoriquePack
    {
        public DateTime dt_Achat { get; set; }
        public Pack pack { get; set; }
        public Professionnel professionnel { get; set; }

        public HistoriquePack()
        {
            pack = new Pack();
            dt_Achat = new DateTime();
            professionnel = new Professionnel();
        }
    }
}
