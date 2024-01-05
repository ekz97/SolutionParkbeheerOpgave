using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuisHuurderEF
    {
        public int HuisEFId { get; set; }
        public virtual HuisEF Huis { get; set; }

        public int HuurderEFId { get; set; }
        public virtual HuurderEF Huurder { get; set; }
    }
}
