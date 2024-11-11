using Microsoft.AspNetCore.Mvc;
using WebPortfolio.Controllers;
using WebPortfolio.Data;
using WebPortfolio.Models;
using System;

public class FeedbackController : Controller
{
    private readonly ILogger<FeedbackController> _logger;
    private readonly WebPortfolioContext _context;

    public FeedbackController(ILogger<FeedbackController> logger, WebPortfolioContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var feedback = _context.Feedback.ToList();
        ViewData["Feedback"] = feedback;
        return View(new Feedback());
    }

    [HttpPost]
    public JsonResult Submit([FromBody] Feedback feedback)
    {
        if (ModelState.IsValid)
        {
            feedback.Date = DateTime.Now;
            _context.Feedback.Add(feedback);
            _context.SaveChanges();

            return Json(new
            {
                name = feedback.Name,
                date = feedback.Date,
                comment = feedback.Comment
            });
        }

        return Json(new { error = "Invalid feedback data." });
    }
}
