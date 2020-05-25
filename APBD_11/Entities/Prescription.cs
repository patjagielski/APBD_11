using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_11.Entities
{
    public class Prescription
    {
        public int IdPresciption { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<Prescription_Medication> Prescription_Medications { get; set; }
    }
}
