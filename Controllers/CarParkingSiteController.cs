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
            IEnumerable<CarParkingBooking> carparkingBookings = carparkingsitedetails.GetCarParkingSiteDetails();
           // ViewBag.carparkingBookings = carparkingBookings;
            return View(carparkingsitedetails);

        }
        public ActionResult DataPassing()
        {
            IEnumerable<CarParkingBooking> carparkingBookings = carparkingsitedetails.GetCarParkingSiteDetails();
            ViewBag.carparkingBookings = carparkingBookings;
            ViewData["carparkingBookings"] = carparkingBookings;
            TempData["carparkingBookings"] = carparkingBookings;
            return RedirectToAction("TempDataChecking");
        }
        public ActionResult TempDataCheck()
        {
            IEnumerable<CarParkingBooking> carparkingBookings = carparkingsitedetails.GetCarParkingSiteDetails();
            TempData["carparkingBookings"] = carparkingBookings;
            return View();
        }
        public ActionResult Display()
        {
            IEnumerable<CarParkingBooking> carparkingBookings = carparkingsitedetails.GetCarParkingSiteDetails();
            TempData["carparkingBookings"] = carparkingBookings;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        //public ActionResult CreateCarParkingDetails()
        //{
        //    CarParkingBooking carParking = new CarParkingBooking();
        //    UpdateModel(carParking);
        //    carparkingsitedetails.Add(carParking);
        //    TempData["Result"] = "Added successfully";
        //    return RedirectToAction("TempDataCheck");
        //}
        public ActionResult CreateCarParkingDetails()
        {
            CarParkingBooking carParking = new CarParkingBooking();
            TryUpdateModel(carParking);
            carparkingsitedetails.Add(carParking);
            TempData["Result"] = "Added successfully";
            return RedirectToAction("TempDataCheck");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CarParkingBooking carParking = carparkingsitedetails.GetParkingSiteDetailsById(id);
            return View(carParking);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            CarParkingBooking carParking = carparkingsitedetails.GetParkingSiteDetailsById(id);
            carparkingsitedetails.DeleteCarParkingDetails(carParking);
            return RedirectToAction("TempDataCheck");
        }
        public ActionResult Update()
        {
            CarParkingBooking carParking = new CarParkingBooking();
            TryUpdateModel(carParking);
            carparkingsitedetails.UpdateCarParkingDetails(carParking);
            TempData["Result"] = "Added successfully";
            return RedirectToAction("TempDataCheck");
        }
    }
}