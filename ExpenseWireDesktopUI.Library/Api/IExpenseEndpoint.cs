using ExpenseWireDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseWireDesktopUI.Library.Api
{
    public interface IExpenseEndpoint
    {
        Task PostExpense(ExpenseModel expense);
        Task<List<ExpenseModel>> GetAll();
        Task<List<ExpenseModel>> GetById();
    }
}