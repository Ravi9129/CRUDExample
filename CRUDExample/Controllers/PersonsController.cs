using System.Diagnostics;
using CRUDExample.Entities;
using CRUDExample.ServiceContracts;
using CRUDExample.ServiceContracts.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExample.Controllers
{
    public class PersonsController : Controller

    {
        // private fileds
        private readonly IPersonsService _personsService;

        //constructor
        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }

        [Route("persons/index")]
        [Route("/")]
        public IActionResult Index()
        {
           List<PersonResponse> persons= _personsService.GetAllPersons();
            return View(persons); // Views/Persons/Index.cshtml

        }
    }
}
