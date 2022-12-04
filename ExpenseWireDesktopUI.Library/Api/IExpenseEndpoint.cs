using ExpenseWireDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseWireDesktopUI.Library.Api
{
    public interface IExpenseEndpoint
    {
        Task PostExpense(ExpenseModel expense);
        Task PostEditedExpense(ExpenseModel expense);
        Task DeleteExpense(Int32 id);
        Task<List<ExpenseModel>> GetAll();
        Task<List<ExpenseModel>> GetById();
    }
}