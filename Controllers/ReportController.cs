using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Nancy.Json;
using Newtonsoft.Json;
using PrivateClinicRegistration.Models;

namespace PrivateClinicRegistration.Controllers
{
    public class ReportRow
    {
        public string Doctor;
        public int AppointmentCount;
    }

    public class ReportController : Controller
    {
        private readonly PrivateClinicRegistrationContext db;

        public ReportController(PrivateClinicRegistrationContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Report1()
        {
            var data = db.Appointment
                .Join(
                    db.Doctor,
                    a => a.DoctorId,
                    d => d.Id,
                    (a, d) => new {
                        AppointmentId = a.Id,
                        DoctorId = a.DoctorId,
                        Profile = d.Profile,
                        Fullname = d.Fullname
                    }
                )
                .GroupBy(da => new { da.Profile, da.Fullname })
                .Select(
                    g => new ReportRow {
                        Doctor = g.Key.Fullname + " (" + g.Key.Profile + ")",
                        AppointmentCount = g.Count()
                    }
                ).OrderByDescending( x => x.AppointmentCount).ToList();
            return View(data);
        }

        public IActionResult Report2()
        {
            var data = db.Appointment
                .Join(
                    db.Doctor,
                    a => a.DoctorId,
                    d => d.Id,
                    (a, d) => new {
                        AppointmentId = a.Id,
                        DoctorId = a.DoctorId,
                        Profile = d.Profile,
                        Fullname = d.Fullname
                    }
                )
                .GroupBy(da => new { da.Profile, da.Fullname })
                .Select(
                    g => new ReportRow
                    {
                        Doctor = g.Key.Fullname + " (" + g.Key.Profile + ")",
                        AppointmentCount = g.Count()
                    }
                ).OrderByDescending(x => x.AppointmentCount).ToList();
            return View(data);
        }
    }
}

/*
 * 
 * var phoneGroups2 = from phone in phones
                   group phone by phone.Company into g
                   select new { Name = g.Key, Count = g.Count() };
 SELECT Profile, Fullname, COUNT(*) as Cnt
FROM Appointment
JOIN Doctor ON DoctorID = Doctor.ID
GROUP BY Profile, Fullname
ORDER BY Cnt DESC

SELECT MONTH(DateTimeStart) as AppointmentMonth, COUNT(*) as Cnt
FROM Appointment
GROUP BY MONTH(DateTimeStart)
ORDER BY Cnt DESC
 */
