namespace CryptoWalletApi.Models
{
    public class Wallet
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public decimal Balance => LedgerEntries.Sum(e => e.Amount); // read-only

        public ICollection<LedgerEntry> LedgerEntries { get; set; }
        public User User { get; set; }
    }
}
