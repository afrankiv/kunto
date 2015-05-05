using System;

namespace Kunto.ConsoleClient.DelegatesAndEvents
{
    /// <summary>
    /// A popular design pattern (a reusable solution for a recurring problem) in application 
    /// development is that of publish-subscribe. You can subscribe to an event and then you are 
    /// notified when the publisher of the event raises a new event. This is used to establish loose
    /// coupling between components in an application.
    /// </summary>
    public class EventsSample
    {
        public void SimulateEventViaDelegate()
        {
            var p = new PublisherSubscriber();
            p.OnChange += () => Console.WriteLine("Event raised to method 1");
            p.OnChange += () => Console.WriteLine("Event raised to method 2");
            p.Raise();
        }
    }

    /// <summary>
    /// If there would be no subscribers to an event, the OnChange property would be null. 
    /// This is why the Raise method checks to see whether OnChange is not null.
    /// Although this system works, there are a couple of weaknesses. If you change the 
    /// subscribe line for method 2 to the following, you would effectively remove the first subscriber by using = instead of +=
    /// </summary>
    internal class PublisherSubscriber
    {
        public Action OnChange { get; set; }

        public void Raise()
        {
            if (OnChange != null)
            {
                OnChange();
            }
        }
    }


    /// <summary>
    /// With the event syntax, the compiler protects your field from unwanted access.
    /// An event cannot be directly assigned to (with the = instead of +=) operator. 
    /// So you don’t have the risk of someone removing all previous subscriptions, as with the delegate syntax.
    /// Another change is that no outside users can raise your event. 
    /// It can be raised only by code that’s part of the class that defined the event.
    /// </summary>
    internal class EventPublisherSubscriber
    {
        /// <summary>
        /// Also uses some special syntax to initialize the event to an empty delegate. 
        /// This way, you can remove the null check around raising the event because you can be 
        /// certain that the event is never null. Outside users of your class can’t set the event to null;
        /// only members of your class can. As long as none of your other class members sets
        /// the event to null, you can safely assume that it will always have a value.
        /// </summary>
        public event Action OnChange = delegate { };

        public void Raise()
        {
            OnChange();
        }
    }
}
