using Euromonitor.Assessment.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euromonitor.Assessment.Web.Models
{
    public class IndexModel
    {
        public string Username { get; set; }

        public IEnumerable<Book> Subscriptions { get; set; }

        public IEnumerable<Book> AllBooks { get; set; }
    }
}
