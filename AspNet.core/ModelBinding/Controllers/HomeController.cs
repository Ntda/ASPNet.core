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
        public ViewResult Index(int id) => View(repository[id]);

        public ViewResult Create() => View();

        [HttpPost]
        public ViewResult Create(Person person) => View("Index", person);
    }
}
