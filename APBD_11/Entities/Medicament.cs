using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_11.Entities
{
    public class Medicament
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Prescription_Medication> Prescription_Medications { get; set; }
    }
}
