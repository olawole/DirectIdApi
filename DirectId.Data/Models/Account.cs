using System.Collections.Generic;

namespace DirectId.Data.Models
{
    public class Account
    {
        public string AccountId { get; set; }

        public string CurrencyCode { get; set; }

        public string DisplayName { get; set; }

        public string AccountType { get; set; }

        public string AccountSubType { get; set; }

        public AccountIdentifier Identifiers { get; set; }

        public IList<string> Parties { get; set; }

        public IList<string> StandingOrders { get; set; }

        public IList<string> DirectDebits { get; set; }

        public Balances Balances { get; set; }

        public IList<Transaction> Transactions { get; set; }
    }
}
