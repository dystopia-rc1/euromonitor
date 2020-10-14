using System;
using System.Collections.Generic;
using System.Text;

namespace Euromonitor.Assessment.Common
{
    public static class UserService
    {
        private static Dictionary<string, List<Book>> _subscriptions = new Dictionary<string, List<Book>>();

        public static IEnumerable<Book> GetSubscriptions(string user)
        {
            if (!_subscriptions.ContainsKey(user))
            {
                _subscriptions.Add(user, new List<Book>());
            }

            return _subscriptions[user];
        }

        public static void Add(string user, Book book)
        {
            if (!_subscriptions.ContainsKey(user))
            {
                _subscriptions.Add(user, new List<Book>());
            }

            _subscriptions[user].Add(book);
        }

        public static void Remove(string user, Book book)
        {
            if (_subscriptions.ContainsKey(user))
            {
                _subscriptions[user].Remove(book);
            }
        }
    }
}
