using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_11.Entities
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }

    }
}
