using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_11.Entities
{
    public class Doctor
    {
        
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
