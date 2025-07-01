namespace CryptoWalletApi.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }

        public string Type { get; set; } // Deposit / Withdrawal
        public string Status { get; set; } // Pending / Completed / Failed

        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }

        public User User { get; set; }
    }
}
