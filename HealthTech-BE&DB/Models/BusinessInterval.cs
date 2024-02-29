using System;
using System.Collections.Generic;

namespace HealthTech331.Models
{
    public partial class BusinessInterval
    {
        public BusinessInterval()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int BusinessIntervalId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? Day { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
