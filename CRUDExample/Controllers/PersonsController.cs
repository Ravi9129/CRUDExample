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
        public IActionResult Index(string SearchBy, string? searchString)
        {
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                { nameof(PersonResponse.PersonName), "Person Name" },
                { nameof(PersonResponse.Email), "Email" },
                { nameof(PersonResponse.DateOfBirth), "Date of Birth" },
                { nameof(PersonResponse.Gender), "Gender" },
                { nameof(PersonResponse.CountryID), "Country" },
                { nameof(PersonResponse.Address), "Address" },

            };
           List<PersonResponse> persons= _personsService.GetFilteredPersons(SearchBy, searchString);
            ViewBag.CurrentSearchBy = SearchBy;
            ViewBag.CurrentSearchString = searchString;
            return View(persons); // Views/Persons/Index.cshtml

        }
    }
}
