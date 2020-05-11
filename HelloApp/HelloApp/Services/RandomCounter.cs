using System;

namespace HelloApp.Services
{
    public class RandomCounter : ICounter
    {
        int _value;
        static Lazy<Random> _random = new Lazy<Random>();
        
        public int Value {
            get => _value;
        }

        public RandomCounter()
        {
            _value = _random.Value.Next(0, 1000);
        }
    }
}
