using Microsoft.AspNetCore.Mvc;
using WebPortfolio.Controllers;
using WebPortfolio.Data;
using WebPortfolio.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

[Authorize]
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
        ModelState.Remove(nameof(Feedback.UserId));

        if (ModelState.IsValid)
        {
            feedback.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            feedback.Date = DateTime.Now;
            _context.Feedback.Add(feedback);
            _context.SaveChanges();

            return Json(new
            {
                name = feedback.Name,
                date = feedback.Date,
                comment = feedback.Comment
            });
        } else
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { error = "Invalid feedback data.", details = errors });
        }
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var feedback = _context.Feedback.FirstOrDefault(f => f.Id == id);

        if (feedback == null)
        {
            return Json(new { success = false, message = "Feedback not found." });
        }

        if (feedback.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            return Json(new { success = false, message = "You are not authorized to delete this feedback." });
        }

        _context.Feedback.Remove(feedback);
        _context.SaveChanges();

        return Json(new { success = true, message = "Feedback deleted successfully." });
    }
}
