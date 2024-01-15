using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Services;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectsRepository projectsRepository;
        private readonly IEmailService emailService;

        public HomeController(ILogger<HomeController> logger, IProjectsRepository projectsRepository, IEmailService emailService)
        {
            _logger = logger;
            this.projectsRepository = projectsRepository;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            var projects = projectsRepository.GetProjects().Take(3).ToList();
            var model = new HomeIndexViewModel() { Projects = projects };
            return View(model);
        }        

        public IActionResult Projects()
        {
            var projects = projectsRepository.GetProjects();

            return View(projects);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Contact contact)
        {
            await emailService.Send(contact);
            return RedirectToAction("Successful");
        }

        public IActionResult Successful()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}