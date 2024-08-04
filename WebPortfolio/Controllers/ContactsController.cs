using Microsoft.AspNetCore.Mvc;
using WebPortfolio.Data;
using WebPortfolio.Models;

namespace WebPortfolio.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contact
        private readonly ILogger<ContactsController> _logger;
        private readonly WebPortfolioContext _context;

        public ContactsController(ILogger<ContactsController> logger, WebPortfolioContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(Contacts model)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(model);
                _context.SaveChanges();

                return RedirectToAction("AfterMsg");
            }

            return View("Index", model);
        }

        public IActionResult AfterMsg()
        {
            return View();
        }
    }
}
