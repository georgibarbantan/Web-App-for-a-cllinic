using System;
using System.Collections.Generic;

namespace HealthTech331.Models
{
    public partial class Speciality
    {
        public Speciality()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int SpecialityId { get; set; }
        public string? SpecialityName { get; set; }
        public string? SpecialityDescription { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
