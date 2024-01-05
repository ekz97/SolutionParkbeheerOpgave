using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuisEF
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Straat { get; set; }

        [Required]
        public int Nr { get; set; }

        [Required]
        public bool Actief { get; set; }

        public virtual ICollection<HuisHuurderEF> HuisHuurders { get; set; }
        public string ParkId { get; set; }
        public virtual ParkEF Park{ get; set; }
    }
}
