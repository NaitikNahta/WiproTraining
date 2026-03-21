using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesDemo.Models
{
    public class InventoryReport : Report
    {
        public override string GetReportContent()
        {
            return "Inventory Report Content";
        }
    }
}
