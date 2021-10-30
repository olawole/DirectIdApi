using System;

namespace DirectId.Data.Models
{
    public class Transaction
    {
        public string Description { get; set; }

        public int Amount { get; set; }

        public CreditDebitEnum CreditDebitIndicator { get; set; }

        public string Status { get; set; }

        public DateTime BookingDate { get; set; }

        public string MerchantDetails { get; set; }
    }
}