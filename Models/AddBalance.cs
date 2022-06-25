using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalanceTest.Models
{
    public enum Statuses
    {
        Processing,
        Approved,
        Rejected,
        Refund

    }
    public class AddBalance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Id транзакции")]
        public string TransactionId { get; set; }

        [DisplayName("ID пользователя")]
        public int UserId { get; set; }

        [Required]
        [Range(1, 10000000, ErrorMessage = "Баланс должен быть от 1 до 10 000 000")]
        [DisplayName("Баланс пополнения")]
        public int Balance { get; set; }

        [Required]
        [DisplayName("Статус")]
        public Statuses Status { get; set; }

        [Required]
        [DisplayName("Дата запроса")]
        public string CreateData { get; set; }

        [DisplayName("Дата решения")]
        public string UpdateData { get; set; }

        [ForeignKey("UserId")]
        public virtual CreateUser CreateUser { get; set; }
    }
}
