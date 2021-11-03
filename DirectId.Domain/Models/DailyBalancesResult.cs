using System;
using System.Collections.Generic;
using System.Text;

namespace DirectId.Data.Models
{
    public class DailyBalancesResult
    {
        public string AccountId { get; set; }

        public string CurrencyCode { get; set; }

        public string DisplayName { get; set; }

        public string AccountType { get; set; }

        public int TotalCredits { get; set; }

        public int TotalDebits { get; set; }

        public IList<DailyBalance> EndOfDayBalances { get; set; }
    }
}
