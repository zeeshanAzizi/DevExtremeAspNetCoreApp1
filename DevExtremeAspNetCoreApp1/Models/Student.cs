using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevExtremeAspNetCoreApp1.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int Fee { get; set; }
        public bool IsDeleted { get; set; }
        public int CountryID { get; set; }
        [ForeignKey(nameof(CountryID))]
        public virtual Country Country { get; set; }
        public int StateID { get; set; }
        [ForeignKey(nameof(StateID))]
        public virtual State State { get; set; }
        public int SkillID { get; set; }
        [ForeignKey(nameof(SkillID))]
        public virtual Skill Skill{ get; set; }
    }
}
