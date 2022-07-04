using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevExtremeAspNetCoreApp1.Models
{
    public class State
    {
        [Key]
        public int ID { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
        [ForeignKey(nameof(CountryID))]
        public virtual Country Country { get; set; }
    }
}
