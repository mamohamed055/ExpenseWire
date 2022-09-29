using Caliburn.Micro;
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
    public class AddExpenseViewModel : Screen
    {
        IExpenseEndpoint _expenseEndpoint;
        public AddExpenseViewModel(IExpenseEndpoint expenseEndpoint)
        {
            _expenseEndpoint = expenseEndpoint;
        }

        public string Description { get; set;}

        public string Type { get; set; }

        public decimal Amount { get; set; }
        public void Submit()
        {
            ExpenseModel expense = new ExpenseModel();

            expense.Description = Description;
            expense.Type = Type;    
            expense.Amount = Amount;

            _expenseEndpoint.PostExpense(expense);
        }
    }
}
