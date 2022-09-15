using ExpenseWireDesktopUI.Models;
using System.Threading.Tasks;

namespace ExpenseWireDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}