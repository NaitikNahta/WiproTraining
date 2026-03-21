using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesDemo.Services
{
    public class Logger
    {
        private static Logger _instance;

        // Private constructor prevents direct object creation
        private Logger()
        {
        }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }

            return _instance;
        }

        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }
}
