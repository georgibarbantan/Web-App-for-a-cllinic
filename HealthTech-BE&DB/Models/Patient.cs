using System;
using System.Collections.Generic;

namespace HealthTech331.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
