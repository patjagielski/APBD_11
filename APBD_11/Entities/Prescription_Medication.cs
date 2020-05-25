using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_11.Entities
{
    public class Prescription_Medication
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }
        public virtual ICollection<Prescription_Medication> Prescription_Medications { get; set; }
        public virtual Prescription Prescriptions { get; set; }
        public virtual Medicament Medicaments { get; set; }

    }
}
