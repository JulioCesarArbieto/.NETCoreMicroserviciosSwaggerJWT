using System.ComponentModel.DataAnnotations;

namespace CONTINER.API.MANAGER.Account.Model
{
    public class Customer
    {
        [Key]
        public int IdCustomer { get; set; }
        public string FullName { get; set; }
    }
}
