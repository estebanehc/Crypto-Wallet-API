namespace CryptoWalletApi.Models
{
    public class LedgerEntry
    {
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }

        public decimal Amount { get; set; } // positivo o negativo
        public DateTime Timestamp { get; set; }

        public string OperationType { get; set; } // Deposit, Withdrawal, Transfer, Correction
        public string ReferenceId { get; set; } // UUID de la transacción que originó esto

        public Wallet Wallet { get; set; }
    }
}
