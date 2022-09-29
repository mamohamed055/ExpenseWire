using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseWireDesktopUI.Library.Models
{
    public class ExpenseModel
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string DisplayText
        {
            get
            {
                return $"{Type} {Description} {Amount.ToString()}";
            }
        }
    }
}
