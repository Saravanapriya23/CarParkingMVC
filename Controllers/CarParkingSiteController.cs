using System.Collections.Generic;
using OnlineCarParking.Repository;
using OnlineCarParking.Entity;
using System.Web.Mvc;   
namespace OnlineCarParking.Controllers
{
    public class CarParkingSiteController : Controller
    {
        CarParkingSiteDetailsRepository carparkingsitedetails;
        public CarParkingSiteController()
        {
            carparkingsitedetails = new CarParkingSiteDetailsRepository();
        }
        // GET: CarParkingSite
        public ActionResult Index()
        {
            IEnumerable<CarParkingBooking> carparkingBookings = carparkingsitedetails.GetCarParkingBookingSiteDetails();
            return View(carparkingsitedetails);

        }
       
        public ActionResult DataPassing()
        {
            IEnumerable<CarParkingBooking> carparkingBookings = carparkingsitedetails.GetCarParkingBookingSiteDetails();
            ViewBag.Package = carparkingBookings;
            ViewData["carparkingBookings"] = carparkingBookings;
            return View();
        }
        public ActionResult TempDataChecking()
        {
            IEnumerable<CarParkingBooking> carparkingBookings = carparkingsitedetails.GetCarParkingBookingSiteDetails();
            TempData["carparkingBookings"] = carparkingBookings;
            return View();
        }
    }
}