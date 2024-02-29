using System;
using System.Collections.Generic;

namespace HealthTech331.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int UserId { get; set; }
        public int? SpecialityId { get; set; }
        public int? BusinessIntervalId { get; set; }

        public virtual BusinessInterval? BusinessInterval { get; set; }
        public virtual Speciality? Speciality { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
