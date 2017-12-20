using System.Collections.Generic;

namespace DAL.EF.Models
{
    public class Owner
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
