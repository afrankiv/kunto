using System;

namespace Kunto.ConsoleClient.DelegatesAndEvents
{
    public class EventsFinalSample
    {
        public void CreateAndRaise()
        {
            var eventClass = new EventClass();

            // event handler
            eventClass.OnChange += (sender, e) =>
            {
                Console.WriteLine("Event raised: {0}", e.Value);
            };

            eventClass.Raise();
        }
    }

    internal class CustomArgs : EventArgs
    {
        public CustomArgs(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
    }

    internal class EventClass
    {
        private event EventHandler<CustomArgs> onChange = delegate { };

        public event EventHandler<CustomArgs> OnChange
        {
            add
            {
                lock (onChange)
                {
                    onChange += value;
                }
            }
            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }

        public void Raise()
        {
            onChange(this, new CustomArgs(42));
        }
    }
}
