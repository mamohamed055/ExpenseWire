﻿using ExpenseWireDesktopUI.Library.Models;
using ExpenseWireDesktopUI.Models;
using System.Threading.Tasks;

namespace ExpenseWireDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}