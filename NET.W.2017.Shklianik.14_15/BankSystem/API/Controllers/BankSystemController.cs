using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject;
using DependencyResolver;
using BLL.Interface.AccountService;
using System.Web.Script.Serialization;
using BLL.Interface.Account;
using BLL.Interface.AccountIdCreatorService;

namespace API.Controllers
{
    public class InitAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AccountType { get; set; }
    }

    public class UpdteAccount
    {
        public decimal Value { get; set; }
    }

    //[Authorize]   
    public class BankSystemController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            return new JavaScriptSerializer().Serialize(service.GetAccounts("segennikita@gmail.com"));
        }

        // GET api/<controller>/5
        public string Get(string accountId)
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            return new JavaScriptSerializer().Serialize(service.GetAccountInfo(accountId));
        }

        // POST api/<controller>
        public void Post([FromBody]InitAccount values)
        {
            Dictionary<string, AccountType> accountTypes = new Dictionary<string, AccountType>
            {
                {"base", AccountType.Base},
                {"gold", AccountType.Gold},
                {"platinum", AccountType.Platinum}
            };
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            service.OpenAccount(values.FirstName, values.LastName, values.Email, accountTypes[values.AccountType], resolver.Get<IAccountNumberCreator>());
        }

        // PUT api/<controller>/5
        public void Put(string accounntNumber, [FromBody]UpdteAccount value)
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            if (value.Value > 0)
            {
                service.Deposit(accounntNumber, value.Value);
            }
            else
            {
                service.Withdraw(accounntNumber, -value.Value);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(string accounntNumber)
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            service.DeleteAccount(accounntNumber);
        }
    }
}