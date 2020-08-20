using System.ComponentModel.DataAnnotations;

namespace CONTINER.API.MANAGER.Account.Model
{
    public class Account
    {
        [Key]
        public int IdAccount { get; set; }
        public decimal TotalAmount { get; set; }
        public int IdCustomer { get; set; }
        public Customer Customer { get; set; }
    }
}
