using ExpenseWireDataManager.Library.DataAccess;
using ExpenseWireDataManager.Library.Models;
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
        public void Post(ExpenseModel item)
        {
            ExpenseData data = new ExpenseData();
            data.SaveExpense(item);
        }
    }
}