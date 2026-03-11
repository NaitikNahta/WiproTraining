using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesDemo.Models
{
    public class SalesReport : Report
    {
        public override string GetReportContent()
        {
            return "Sales Report Content";
        }
    }
}
