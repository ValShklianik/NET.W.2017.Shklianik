using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalAccountOperation
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public string Operation { get; set; }

        public decimal OperationValue { get; set; }

        public DateTime OperationDate { get; set; }
    }
}
