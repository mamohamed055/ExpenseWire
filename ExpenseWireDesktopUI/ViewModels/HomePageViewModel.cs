using Caliburn.Micro;
using ExpenseWireDesktopUI.EventModels;
using ExpenseWireDesktopUI.Library.Api;
using ExpenseWireDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseWireDesktopUI.ViewModels
{
    public class HomePageViewModel : Screen
    {
        private IEventAggregator _events;
        private BindingList<ExpenseModel> _expenses;
        
        IExpenseEndpoint _expenseEndpoint;

        public HomePageViewModel(IEventAggregator events, IExpenseEndpoint expenseEndpoint)
        {
            _events = events;
            _expenseEndpoint = expenseEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadExpenses();
        }

        public async Task LoadExpenses()
        {
            var expenseList = await _expenseEndpoint.GetAll();
            Expenses = new BindingList<ExpenseModel>(expenseList);
        }

        public BindingList<ExpenseModel> Expenses 
        {
            get
            {
                return _expenses;
            }
            set
            {
                _expenses = value;
                //Need to understand why I need the line below in order to view the 
                //expenses
                NotifyOfPropertyChange(() => Expenses);
            }
        }

        public void NewExpense()
        {
            _events.PublishOnUIThread(new NewExpenseEvent());
        }
    }
}
