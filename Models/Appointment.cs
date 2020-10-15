using System;
using System.Collections.Generic;

namespace PrivateClinicRegistration.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime DateTimeStart { get; set; }
        public int ServiceId { get; set; }
        public int DoctorId { get; set; }
        public string PatientFullname { get; set; }
        public string PatientPhone { get; set; }

        public Doctor Doctor { get; set; }
        public Service Service { get; set; }
    }
}
