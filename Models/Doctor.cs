using System;
using System.Collections.Generic;

namespace PrivateClinicRegistration.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Profile { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
