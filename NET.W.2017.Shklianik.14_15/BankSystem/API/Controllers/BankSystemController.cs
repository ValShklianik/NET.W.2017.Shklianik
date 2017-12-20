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
    //[Authorize]
    public class BankSystemController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            return service.GetAccounts(acc => true).Select(acc => new JavaScriptSerializer().Serialize(acc));
        }

        // GET api/<controller>/5
        public string Get(string accountId)
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            return new JavaScriptSerializer().Serialize(service.GetAccountInfo(accountId)));
        }

        // POST api/<controller>
        public void Post([FromBody]string value, [FromBody]string accountType)
        {
            Dictionary<string, AccountType> accountTypes = new Dictionary<string, AccountType>();
            accountTypes.Add("base", AccountType.Base);
            accountTypes.Add("gold", AccountType.Gold);
            accountTypes.Add("platinum", AccountType.Platinum);
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            service.OpenAccount(value, accountTypes[accountType], resolver.Get<IAccountNumberCreator>());
        }

        // PUT api/<controller>/5
        public void Put(string accounntNumber, [FromBody]decimal value)
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            var service = resolver.Get<IAccountService>();
            service.Deposit(accounntNumber, value);
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