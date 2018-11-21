using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuarterControl.Controllers.Helpers;
using QuarterControl.Models;
using QuarterControl.Models.DB;

namespace QuarterControl.Controllers
{
    public class HomeController : Controller
    {
        public NetworkStatus netstat = new NetworkStatus();

        private readonly QuarterControlDBContext _context;

        public HomeController(QuarterControlDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            DisplayInitial displayInitial = new DisplayInitial();
            
            displayInitial.networkStatus = netstat.NetworkUp();
            return View(displayInitial);
        }

        //Busca el garrón en función del codbar ingresado
        public ActionResult SearchCodbar(string codbar)
        {
            RepositoryControllers repository = new RepositoryControllers(_context);
            DisplayInitial repositoryGarron = new DisplayInitial
            {
                repository = repository.GetInformation(codbar)
            };

           
            repositoryGarron.networkStatus = netstat.NetworkUp();

            return View(repositoryGarron);
        }

        //TODO: Terminar de implementar este método
        public ActionResult SaveMarmoreo(int garronId, bool marmoreoApto)
        {
            AngusInspect garron = new AngusInspect();
            garron.GarronID = garronId;
            garron.MarmoreoApto = marmoreoApto;
            _context.AngusInspects.Add(garron);
            try
            {
                _context.SaveChanges();
                return PartialView();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
            
            

        }

    }
}
