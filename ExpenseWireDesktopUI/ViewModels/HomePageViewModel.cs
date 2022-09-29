using Caliburn.Micro;
using ExpenseWireDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseWireDesktopUI.ViewModels
{
    public class HomePageViewModel
    {
        private IEventAggregator _events;

        public HomePageViewModel(IEventAggregator events)
        {
            _events = events;
        }
        public void NewExpense()
        {
            _events.PublishOnUIThread(new NewExpenseEvent());
        }
    }
}
