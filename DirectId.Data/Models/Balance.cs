namespace DirectId.Data.Models
{
    public class Balance
    {
        public int Amount { get; set; }

        public CreditDebitEnum CreditDebitIndicator { get; set; }

        public string CreditLines { get; set; }
    }
}