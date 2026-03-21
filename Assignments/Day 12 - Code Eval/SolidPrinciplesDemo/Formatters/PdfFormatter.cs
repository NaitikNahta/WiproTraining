using SolidPrinciplesDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesDemo.Formatters
{
    public class PdfFormatter : IReportFormatter
    {
        public string Format(string content)
        {
            return $"Formatted as PDF: {content}";
        }
    }
}
