using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalAccountDetailed
    {
        public DalAccount AccountObject { get; set; }
        public IEnumerable<DalAccountOperation> Operations { get; set; }
    }
}
