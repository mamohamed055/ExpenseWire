using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseWireDataManager.Library.Internal.DataAccess;
using ExpenseWireDataManager.Library.Models;

namespace ExpenseWireDataManager.Library.DataAccess
{
    public class ExpenseData
    {
        public void SaveExpense(ExpenseModel item)
        {
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spAddExpense", item, "ExpenseWireData");
        }
    }
}
