using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Euromonitor.Assessment.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Euromonitor.Assessment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("AllBooks")]
        public IEnumerable<Book> GetAllBooks()
        {
            return BookService.GetAllBooks();
        }

        [HttpGet]
        [Route("Subscriptions")]
        public IEnumerable<Book> GetSubscriptions(string user)
        {
            return UserService.GetSubscriptions(user);
        }

        [HttpPost]
        [Route("Subscribe")]
        public IActionResult Subscribe(string user, string book)
        {
            UserService.Add(user, BookService.GetBook(book));

            return Ok();
        }

        [HttpPost]
        [Route("Unsubscribe")]
        public IActionResult Unsubscribe(string user, string book)
        {
            UserService.Remove(user, BookService.GetBook(book));

            return Ok();
        }
    }
}
