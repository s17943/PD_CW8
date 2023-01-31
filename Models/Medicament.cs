using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW_PD8.Models
{
    public class Medicament
    {
        [Key]
        public int IdMedicament { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Type { get; set; }
        public ICollection<Perscription_Medicament> Prescrption_Medicaments { get; set; }
    }
}
