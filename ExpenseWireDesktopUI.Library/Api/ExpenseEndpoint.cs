using ExpenseWireDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseWireDesktopUI.Library.Api
{
    public class ExpenseEndpoint : IExpenseEndpoint
    {
        private IAPIHelper _apiHelper;

        public ExpenseEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task PostExpense(ExpenseModel expense)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Expense", expense))
            {
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task PostEditedExpense(ExpenseModel expense)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("api/Expense/SaveEditedExpense", expense))
            {
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task DeleteExpense(Int32 id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.DeleteAsync("/api/Expense/DeleteExpense/" + Convert.ToString(id)))
            {
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

        public async Task<List<ExpenseModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Expense"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ExpenseModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<ExpenseModel>> GetById()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/Expense/GetById"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ExpenseModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


    }
}
