using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseWireDesktopUI.Library.Models
{
    public class ExpenseModel
    {
        public string UserId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        //This to view the expense details on the HomePage (all in the same line)
        public string DisplayText
        {
            get
            {
                return $"{Type} {Description} {Amount.ToString()}";
            }
        }
    }
}
