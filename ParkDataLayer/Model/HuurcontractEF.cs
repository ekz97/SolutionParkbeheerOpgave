using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuurcontractEF
    {
        [Required]
        [StringLength(25)]
        public string Id { get; set; }

        [Required]
        public DateTime StartDatum { get; set; }

        [Required]
        public DateTime EindDatum { get; set; }

        [Required]
        public int AantalDagen { get; set; }
        public virtual HuurderEF Huurder { get; set; }
        public virtual HuisEF Huis { get; set; }

        public int HuisId { get; set; }
        public int HuurderId { get; set; }
    }
}
