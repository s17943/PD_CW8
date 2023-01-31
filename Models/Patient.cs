using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW_PD8.Models
{
    public class Patient
    {
        [Key]
        public int IdPatient { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Perscription> Prescriptions { get; set; }
    }
}
