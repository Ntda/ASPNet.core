using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelBinding.Models;
using static ModelBinding.Models.Repository;

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        readonly IRepository repository;
        readonly ILogger<HomeController> _logger;

        public HomeController(IRepository repo, ILogger<HomeController> logger)
        {
            _logger = logger;
            repository = repo;
        }
        public ViewResult Index([FromQuery]int id)
        {
            _logger.Log(LogLevel.Information, "Id: [{0}]", id);
            return View(repository[id]);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public ViewResult Create(Person person) => View("Index", person);

        public ViewResult Names(string[] names)
        {
            foreach (var name in names)
            {
                _logger.LogInformation("Names: [{0}]", name);
            }
            return View(names ?? new string[0]);
        }
    }
}
