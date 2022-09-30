using ExpenseWireDataManager.Library.DataAccess;
using ExpenseWireDataManager.Library.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ExpenseWireDataManager.Controllers
{
    [Authorize]
    public class ExpenseController : ApiController
    {
        public List<ExpenseModel> Get()
        {
            ExpenseData data = new ExpenseData();
            return data.GetExpenses();
        }
        public void Post(ExpenseModel item)
        {
            string userId = RequestContext.Principal.Identity.GetUserId();

            ExpenseData data = new ExpenseData();
            item.UserId = userId;
            data.SaveExpense(item);
        }
        [Route("api/Expense/GetById")]
        public List<ExpenseModel> GetById()
        {
            ExpenseData data = new ExpenseData();
            string userId = RequestContext.Principal.Identity.GetUserId();
            return data.GetExpensesById(userId);
        }
    }
}