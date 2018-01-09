using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Account
{
    public class DetailedAccount
    {
        public Account AccountObject { get; set; }
        public IEnumerable<AccountOperation> Operations { get; set; }
    }
}
