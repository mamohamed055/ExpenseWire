using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseWireDataManager.Library.Internal.DataAccess;
using ExpenseWireDataManager.Library.Models;
using System.Web;

namespace ExpenseWireDataManager.Library.DataAccess
{
    public class ExpenseData
    {
        public void SaveExpense(ExpenseModel item)
        {
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spAddExpense", item, "ExpenseWireData");
        }

        public void SaveEditedExpense(ExpenseModel item)
        {
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spEditExpense", item, "ExpenseWireData");
        }
        public void DeleteExpense(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new {Id = id};
            sql.DeleteData("dbo.spDeleteExpense", p , "ExpenseWireData");
        }

        public List<ExpenseModel> GetExpenses()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<ExpenseModel, dynamic>("dbo.spExpenseGetAll", new { }, "ExpenseWireData");

            return output;
        }

        public List<ExpenseModel> GetExpensesById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { Id = Id };
            var output = sql.LoadData<ExpenseModel, dynamic>("dbo.spExpenseGetById", p, "ExpenseWireData");
            return output;
        }
    }
}
