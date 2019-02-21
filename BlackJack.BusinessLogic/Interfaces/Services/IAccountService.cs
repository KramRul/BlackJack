﻿using BlackJack.ViewModels.AccountViews;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Interfaces.Services
{
    public interface IAccountService
    {
        Task<RegisterAccountResponseView> Register(RegisterAccountView playerModel);

        Task<LoginAccountResponseView> Login(LoginAccountView playerModel);
    }
}
