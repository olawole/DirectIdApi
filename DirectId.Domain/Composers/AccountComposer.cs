using DirectId.Data.Interfaces;
using DirectId.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectId.Data.Services
{
    public class AccountComposer : IAccountComposer
    {
        private readonly IAccountDataService accountDataService;

        public AccountComposer(IAccountDataService accountDataService)
        {
            this.accountDataService = accountDataService;
        }

        public async Task<DailyBalancesResult> CalculateDailyBalancesAsync(string accountId)
        {
            var account = await accountDataService.GetByIdAsync(accountId);

            SortedDictionary<DateTime, int> dailyTransactionAggregates = new SortedDictionary<DateTime, int>(new SortDescendingComparer<DateTime>());

            int totalCredits = 0, totalDebits = 0;

            foreach (var transaction in account.Transactions)
            {
                switch (transaction.CreditDebitIndicator)
                {
                    case CreditDebitEnum.Credit:
                        totalCredits += transaction.Amount;
                        break;
                    case CreditDebitEnum.Debit:
                        totalDebits += transaction.Amount;
                        break;
                }

                if (dailyTransactionAggregates.ContainsKey(transaction.BookingDate.Date))
                {
                    dailyTransactionAggregates[transaction.BookingDate.Date] += GetTransactionAmount(transaction);
                }
                else
                {
                    dailyTransactionAggregates.Add(transaction.BookingDate.Date, GetTransactionAmount(transaction));
                }
            }

            List<DailyBalance> dailyBalances = CalculateDailyBalances(account, dailyTransactionAggregates);

            return new DailyBalancesResult
            {
                AccountId = account.AccountId,
                AccountType = account.AccountType,
                CurrencyCode = account.CurrencyCode,
                DisplayName = account.DisplayName,
                TotalCredits = totalCredits,
                TotalDebits = totalDebits,
                EndOfDayBalances = dailyBalances
            };
        }

        private List<DailyBalance> CalculateDailyBalances(Account account, SortedDictionary<DateTime, int> dailyTransactionAggregates)
        {
            int currentBalance = account.Balances.Current.Amount;

            var dailyBalances = new List<DailyBalance>();

            foreach (var dailyAggregation in dailyTransactionAggregates)
            {
                dailyBalances.Add(new DailyBalance
                {
                    Date = dailyAggregation.Key.ToString("MM-dd-yyyy"),
                    Balance = currentBalance
                });

                currentBalance -= dailyAggregation.Value;
            }

            return dailyBalances;
        }

        private static int GetTransactionAmount(Transaction transaction)
        {
            return transaction.CreditDebitIndicator == CreditDebitEnum.Debit ? -transaction.Amount : transaction.Amount;
        }
    }
}
