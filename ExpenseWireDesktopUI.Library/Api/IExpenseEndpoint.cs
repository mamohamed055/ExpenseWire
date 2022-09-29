using ExpenseWireDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace ExpenseWireDesktopUI.Library.Api
{
    public interface IExpenseEndpoint
    {
        Task PostExpense(ExpenseModel expense);
    }
}