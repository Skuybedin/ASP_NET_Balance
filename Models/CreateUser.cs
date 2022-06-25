using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BalanceTest.Models
{
    public class CreateUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Логин")]
        public string Login { get; set; }

        public int Balance { get; set; }
    }
}
