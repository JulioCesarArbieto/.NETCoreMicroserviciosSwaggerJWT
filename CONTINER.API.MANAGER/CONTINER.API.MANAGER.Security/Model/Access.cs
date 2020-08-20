using System.ComponentModel.DataAnnotations;

namespace CONTINER.API.MANAGER.Security.Model
{
    public class Access
    {
        [Key]
        public int UserId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
