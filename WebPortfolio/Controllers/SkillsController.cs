using Microsoft.AspNetCore.Mvc;

namespace WebPortfolio.Controllers
{
    public class SkillsController : Controller
    {

        private readonly ILogger<SkillsController> _logger;

        public SkillsController(ILogger<SkillsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
