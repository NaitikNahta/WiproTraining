using SolidPrinciplesDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesDemo.Services
{
    
        public class ReportSaver : IReportSaver
        {
            public void SaveToFile(string content)
            {
                Console.WriteLine("Saving report to file...");
            }
        }
    }

