using SolidPrinciplesDemo.Interfaces;
using SolidPrinciplesDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesDemo.Services
{
    public class ReportGenerator : IReportGenerator
    {
        public string GenerateReport(Report report)
        {
            return report.GetReportContent();
        }
    }
}
