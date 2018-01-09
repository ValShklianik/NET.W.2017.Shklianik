using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class AccountOperation
    {
        public int Id { get; set; }

        [Required]
        public int ChangedAccountId { get; set; }

        public virtual Account ChangedAccount { get; set; }

        [Required]
        public int AccountOperationTypeId { get; set; }

        public virtual OperationType AccountOperationType { get; set; }

        [Required]
        public decimal OperationValue { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime OperationDate { get; set; }
    }
}
