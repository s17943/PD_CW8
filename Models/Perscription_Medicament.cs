using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW_PD8.Models
{
    public class Perscription_Medicament
    {
        [Key]
        public int IdPerscriptionMedicament { get; set; }
        [ForeignKey("Medicament")]
        public int IdMedicament { get; set; }
        public Medicament Medicament { get; set; }
        [ForeignKey("Perscription")]
        public int IdPrescription { get; set; }
        public Perscription Prescription { get; set; }
        [Required]
        public int Dose { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Details { get; set; }
    }
}
