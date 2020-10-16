using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PrivateClinicRegistration.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Report1()
        {
            return View();
        }

        public IActionResult Report2()
        {
            return View();
        }
    }
}

/*
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
