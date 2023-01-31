using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW_PD8.Models
{
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Email { get; set; }
        public virtual ICollection<Perscription> Prescriptions { get; set; }
    }
}
