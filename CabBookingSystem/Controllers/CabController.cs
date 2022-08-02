using CabBookingSystem.Models;
using CabBookingSystem.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CabBookingSystem.Controllers
{
    public class CabController : Controller
    {
        private readonly ICabService _cs;
        public CabController(ICabService cs)
        {
            _cs = cs;
        }

        public IActionResult Index()
        {
                    
            ViewBag.data = new SelectList(_cs.GetAllLocations(),"Id","Name");
            return View();
        }

        [HttpPost]
        public IActionResult GetDistance(Distance distance)
        {
            Distance result= _cs.GetDistance(distance.FromLocation,distance.ToLocation);
            ViewBag.distance = result.Distanceinkm;
            var cabs = _cs.GetCabs(distance.FromLocation);
            TempData["distance"] =JsonConvert.SerializeObject(result);
            

            return View(cabs);
        }
        
        public IActionResult Confirmed(int bookingid)
        {
            var res = _cs.GetBooking(bookingid);
            return View(res);
        }
        [HttpGet("{id}")]
        public IActionResult Book(int id)
        {
            var cab = _cs.GetCabbyid(id);
            object o;
            TempData.TryGetValue("distance", out o);
            var distance = 0 == null ? null : JsonConvert.DeserializeObject<Distance>((string)o);
            //Bookingid, mobileno, cabid, fare, Gst, DistanceId, Otp, TotalFare, Status, Rating
            Booking b = new Booking();
            Random r1 = new Random();
            Random r2 = new Random();
            b.Bookingid = r1.Next(1000, 3000);
            b.Otp = r2.Next(1000, 9999);
            b.Mobileno =long.Parse(HttpContext.Session.GetString("mobile"));
            b.Cabid = id;
            b.DistanceId = distance.DistanceId;
            b.Fare = cab.Fareperkm;
            b.Gst = 18;
            b.TotalFare =(decimal)(b.Fare*distance.Distanceinkm)+ (decimal)(0.18 *(b.Fare * distance.Distanceinkm));
            _cs.bookCab(b);
            
            return RedirectToAction("Confirmed", "Cab", new {bookingid=b.Bookingid});
        }

    }
}
