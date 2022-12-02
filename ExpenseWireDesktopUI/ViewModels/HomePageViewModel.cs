using Caliburn.Micro;
using ExpenseWireDesktopUI.EventModels;
using ExpenseWireDesktopUI.Library.Api;
using ExpenseWireDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseWireDesktopUI.ViewModels
{
    public class HomePageViewModel : Screen
    {
        private IEventAggregator _events;
        private ObservableCollection<ExpenseModel> _expenses;
        
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
            
            var expenseList = await _expenseEndpoint.GetById();
            Expenses = new ObservableCollection<ExpenseModel>(expenseList);

        }

        public ObservableCollection<ExpenseModel> Expenses 
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
        public string Description { get; set; }

        public string Type { get; set; }

        public decimal Amount { get; set; }

        public async void Submit()
        {
            ExpenseModel expense = new ExpenseModel();

            expense.Description = Description;
            expense.Type = Type;
            expense.Amount = Amount;

            await _expenseEndpoint.PostExpense(expense);
            await LoadExpenses();
            _events.PublishOnUIThread(new SubmitExpenseEvent());
        }


    }
}
