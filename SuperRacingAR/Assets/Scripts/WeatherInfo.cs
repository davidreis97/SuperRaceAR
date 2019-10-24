using System;
using System.Collections.Generic;

namespace Application
{
    [Serializable]
    public class WeatherInfo
    {
        public int id;
        public string name;
        public List<Weather> weather;
    }
}
