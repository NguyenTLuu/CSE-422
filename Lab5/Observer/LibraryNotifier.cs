using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Observer
{
    public class LibraryNotifier
    {
        private readonly List<ISubscriber> _subscribers =
            new List<ISubscriber>();

        public void Subscribe(ISubscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
            }
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void NotifySubscribers(string message)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(message);
            }
        }
    }
}
