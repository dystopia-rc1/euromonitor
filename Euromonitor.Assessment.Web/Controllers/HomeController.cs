using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Euromonitor.Assessment.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Euromonitor.Assessment.Common;

namespace Euromonitor.Assessment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new IndexModel()
            {
                Username = User.Identity.Name,
                Subscriptions = UserService.GetSubscriptions(User.Identity.Name),
                AllBooks = BookService.GetAllBooks()
            };
            return View("Index", model);
        }

        [Authorize]
        public IActionResult Add(string book)
        {
            UserService.Add(User.Identity.Name, BookService.GetBook(book));

            return Index();
        }

        [Authorize]
        public IActionResult Remove(string book)
        {
            UserService.Remove(User.Identity.Name, BookService.GetBook(book));

            return Index();
        }

        public IActionResult Privacy()
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
