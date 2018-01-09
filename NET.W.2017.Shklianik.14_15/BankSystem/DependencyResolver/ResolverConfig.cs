using BLL.Interface;
using BLL.Interface.AccountIdCreatorService;
using BLL.Interface.AccountService;
using BLL.ServiceImplementation;
using DAL.EF;
using DAL.Interface.Interfaces;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IEmailService>().To<MailService>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            //kernel.Bind<IRepository>().To<FakeRepository>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountNumberCreator>().To<AccountNumberCreator>();
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
