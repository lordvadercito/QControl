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

        /// <summary>
        /// Busca el garrón en función del codbar ingresado
        /// </summary>
        /// <param name="codbar">Código de barras del garrón pickeado</param>
        /// <returns>Redirige a la vista apropiada</returns>
        public ActionResult SearchCodbar(string codbar)
        {
            RepositoryControllers repository = new RepositoryControllers(_context);
            DisplayInitial repositoryGarron = new DisplayInitial
            {
                repository = repository.GetInformation(codbar)
            };

            bool queryCodbar = _context.AngusInspects.Any(x => x.GarronID == repositoryGarron.repository.GarronId);


            if (!queryCodbar)
            {
                repositoryGarron.Codbar = codbar;
                repositoryGarron.networkStatus = netstat.NetworkUp();

                return View(repositoryGarron);
            }
            else
            {
                int state = 0;
                string error = "El codbar ya fue procesado";

                return RedirectToAction("ResultOperation", new { state, errorMessage = error});
            }

        }

        /// <summary>
        /// Guarda el valor del marmoreo en la base AngusInspect
        /// </summary>
        /// <param name="garronId">Int ID del garrón en la base PalcoDevesaTest</param>
        /// <param name="marmoreoApto">String Valor del marmoreo (Apto o No apto)</param>
        /// <returns></returns>
        public ActionResult SaveMarmoreo(int garronId, string marmoreoApto)
        {
            AngusInspect garron = new AngusInspect();
            garron.GarronID = garronId;
            if (marmoreoApto.Equals("Apto"))
            {
                garron.MarmoreoApto = true;
            }
            else
            {
                garron.MarmoreoApto = false;
            }

            int state = 0;
            string error = null;
            int errorCode = 0;

            _context.AngusInspects.Add(garron);

            try
            {
                state = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                errorCode = ex.HResult;
            }
             
            return RedirectToAction("ResultOperation", new { state, errorMessage = error, errorCode});



        }

        /// <summary>
        /// Redirecciona a la vista de error o sucess según corresponda
        /// </summary>
        /// <param name="state">Estado de la operación (1 = Exitosa)</param>
        /// <param name="errorMessage">Descripción de la excepción</param>
        /// <param name="errorCode">Código del error</param>
        /// <returns>Vista correspondiente</returns>
        public ActionResult ResultOperation(int state, string errorMessage, int errorCode)
        {
            if(state == 1)
            {
                return View("Success");
            }
            else
            {
                Error error = new Error
                {
                    ErrorMessage = errorMessage,
                    ErrorCode = errorCode
            };
                return View("Error", error);
            }
            
        }

    }
}
