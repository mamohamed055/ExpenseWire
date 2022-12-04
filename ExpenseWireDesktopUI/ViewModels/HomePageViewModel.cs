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

        private string _description;
        private string _type;
        private decimal _amount;
        public string Description { get { return _description; } set { _description = value; NotifyOfPropertyChange(() => Description); NotifyOfPropertyChange(() => CanSubmit); NotifyOfPropertyChange(() => CanEdit); } }

        public string Type { get { return _type; } set { _type = value; NotifyOfPropertyChange(() => Type); NotifyOfPropertyChange(() => CanSubmit); NotifyOfPropertyChange(() => CanEdit); } }
        public decimal Amount { get { return _amount; } set { _amount = value; NotifyOfPropertyChange(() => Amount); NotifyOfPropertyChange(() => CanSubmit); NotifyOfPropertyChange(() => CanEdit); } }


        private ExpenseModel _selectedExpense;

        public ExpenseModel SelectedExpense {
            get
            {
                return _selectedExpense;
            }
            set
            {
                _selectedExpense = value;
                NotifyOfPropertyChange(() => SelectedExpense);
                NotifyOfPropertyChange(() => CanEdit);
                NotifyOfPropertyChange(() => CanDelete);

            }
        }

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

        public bool CanEdit
        {
            get
            {
                bool output = false;

                if (SelectedExpense?.Id > 0 && Description?.Length > 0 && Type?.Length > 0 && Amount > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        public async void Edit()
        {
            SelectedExpense.Amount = Amount;
            SelectedExpense.Type = Type;
            SelectedExpense.Description = Description;

            await _expenseEndpoint.PostEditedExpense(SelectedExpense);
            await LoadExpenses();
            _events.PublishOnUIThread(new EditExpenseEvent());
        }

        public async void Delete()
        {
            Int32 id;
            id = SelectedExpense.Id;

            await _expenseEndpoint.DeleteExpense(id);
            await LoadExpenses();
            _events.PublishOnUIThread(new DeleteExpenseEvent());
        }

        public bool CanDelete
        {
            get
            {
                bool output = false;

                if (SelectedExpense?.Id > 0)
                {
                    output = true;
                }

                return output;
            }
            

        }
        public bool CanSubmit
        {
            get
            {
                bool output = false;

                if (Description?.Length > 0 && Type?.Length > 0 && Amount > 0)
                {
                    output = true;
                }

                return output;
            }
        }
       

    }
}
