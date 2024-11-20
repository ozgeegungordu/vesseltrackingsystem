using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VesselTrackingSystem.Models;

namespace VesselTrackingSystem.Controllers
{
    public class HomeController : Controller
    {
        private LimakPortContext _context;

        public HomeController(LimakPortContext context)
        {
            _context = context;
        }

        public IActionResult Map()
        {
            //var serviceRouteLocations = _context.Services.ToList();
            //var viewModel = new Services
            //{
            //    ServiceList = new SelectList(services, "Id", "Name"),
            //};

            return View(/*viewModel*/);

        }

        [HttpPost]
        //public IActionResult Map(Services viewModel)
        //{
        //    int selectedServiceId = viewModel.SelectedServiceId;

        //    return View(viewModel);
        //}


        public IActionResult AddVessel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddVessel(Vessels model)
        {
            if (ModelState.IsValid)
            {
                _context.Vessels.Add(model);
                _context.SaveChanges();
            }
            return View();
        }

        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(Services model)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(model);
                _context.SaveChanges();
            }

            return View();
        }

        public IActionResult AddPort()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddPort(Ports model)
        {
            if (ModelState.IsValid)
            {
                _context.Ports.Add(model);
                _context.SaveChanges();
            }

            return View();
        }

        public IActionResult VesselList()
        {
            var vessels = _context.Vessels.ToList();

            return View(vessels);

        }

        public IActionResult PortList()
        {
            var ports = _context.Ports.ToList();

            return View(ports);
        }

        public IActionResult ServiceList()
        {
            var services = _context.Services.ToList();

            return View(services);
        }
    }
}