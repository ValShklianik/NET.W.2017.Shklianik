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

    [Authorize]   
    [RoutePrefix("api/BankSystem")]
    public class BankSystemController : ApiController
    {
        // GET api/<controller>
        [Route("search"), HttpGet]
        public string GetAccounts([FromUri] string email)
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            return new JavaScriptSerializer().Serialize(service.GetAccounts(email));
        }

        // GET api/<controller>/5
        [Route("{accountNumber}/detail"), HttpGet]
        public string GetAccountInfo(string accountNumber)
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            return new JavaScriptSerializer().Serialize(service.GetAccountInfo(accountNumber));
        }

        // POST api/<controller>
        [Route("add"), HttpPost]
        public string Add([FromBody]InitAccount values)
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
            return service.OpenAccount(values.Email, accountTypes[values.AccountType], resolver.Get<IAccountNumberCreator>());
        }

        // PUT api/<controller>/5
        [Route("{accountNumber}/update"), HttpPost]
        public void Update(string accountNumber, [FromBody]UpdteAccount value)
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            if (value.Value > 0)
            {
                service.Deposit(accountNumber, value.Value);
            }
            else
            {
                service.Withdraw(accountNumber, -value.Value);
            }
        }

        // DELETE api/<controller>/5
        [Route("{accountNumber}/delete"), HttpGet]
        public bool Remove(string accountNumber)
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            service.DeleteAccount(accountNumber);

            return true;
        }
    }
}