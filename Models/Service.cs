using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PrivateClinicRegistration.Models
{
    public partial class Service
    {
        public Service()
        {
            Appointment = new HashSet<Appointment>();
        }
        public int Id { get; set; }
        
        [DisplayName("Назва послуги")]
        public string Name { get; set; }

        [DisplayName("Ціна")]
        public decimal Price { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
