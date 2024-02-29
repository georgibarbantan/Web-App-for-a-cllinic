using System;
using System.Collections.Generic;

namespace HealthTech331.Models
{
    public partial class ApplicationUser
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int? Cnp { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
