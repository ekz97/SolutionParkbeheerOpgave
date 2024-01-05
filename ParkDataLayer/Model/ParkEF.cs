using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class ParkEF
    {
        [Required]
        [StringLength(20)]
        public string Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Naam { get; set; }

        [StringLength(500)]
        public string Locatie { get; set; }

        public virtual ICollection<HuisEF> Huizen { get; set; }
    }
}
