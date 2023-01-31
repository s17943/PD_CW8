using System.ComponentModel.DataAnnotations;

namespace CW_PD8.Models
{
    public class Perscription
    {
        [Key]
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        
        public int IdPatient { get; set; }
        public Patient Patient { get; set; }
        public int IdDoctor { get; set; }
        public Doctor Doctor { get; set; }
        public virtual ICollection<Perscription_Medicament> Prescrption_Medicaments { get; set; }
    }
}
