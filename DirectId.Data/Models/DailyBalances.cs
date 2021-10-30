using System.Collections.Generic;

namespace DirectId.Data.Models
{
    public class DailyBalances
    {
        public int TotalCredits { get; set; }

        public int TotalDebits { get; set; }

        public IList<DailyBalance> EndOfDayBalances { get; set; }
    }
}
