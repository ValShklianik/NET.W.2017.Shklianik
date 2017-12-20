using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DAL.EF.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [DefaultValue(0)]
        public decimal CurrentSum { get; set; }

        [DefaultValue(0)]
        public int BonusPoints { get; set; }

        [Required]
        public int AccountOwnerId { get; set; }

        public virtual Owner AccountOwner { get; set; }

        [Required]
        public int AccountTypeId { get; set; }

        public virtual AccountType AccountType { get; set; }
    }
}
