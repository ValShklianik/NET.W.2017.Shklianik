using System;
using BLL.Interface.AccountIdCreatorService;

namespace BLL.ServiceImplementation
{
    public class AccountNumberCreator : IAccountNumberCreator
    {
        public string Create() => Guid.NewGuid().ToString();
    }
}
