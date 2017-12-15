using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bot.Models;
using Bot.Services;

namespace Bot.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index([FromServices] BotService botService)
    {
      return View();
    }

    public IActionResult About([FromQuery] string message, [FromServices] BotService botService)
    {
      if(!string.IsNullOrEmpty(message)) botService.Broadcast(message);
      return View();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
