import React, {useState} from 'react'
import './SearchAccount.css'
import DailyBalance from './DailyBalance';
import { baseApiUrl } from '../config';
import AccountInfo from './AccountInfo';

const SearchAccount = () => {
    const [accountId, setAccountId] = useState('');
    const [accountData, setAccountData] = useState(null);
    const [error, setError] = useState(null);
    const submitRequest = async (e) => {
        e.preventDefault();
        if (accountId.length === 0) {
            setError('Account ID is required')
        }
        else {
            await fetch(`${baseApiUrl}/Account`, 
        {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ AccountId: accountId })
        }).then((response) => {
            if (response.ok) {
                setError(null)
                return response.json()
            }
            setError('Account could not be found')
            setAccountData(null)
            throw response;
        }).then((data) => setAccountData(data));
        }
    }
    return (
        <div className='main-page'>
            <div className='search-section'>
                <form className='search-form'>
                    <input className='search-text' placeholder='Search by Account ID' type='text' value={accountId} onChange={(e) => setAccountId(e.target.value)}/>
                    <button className='btn-submit' onClick={submitRequest}>Submit</button>
                </form>   
            </div>
            <div className='result-section'>
                { accountData && (
                <div className='account-result'>
                    <h2>Account Information</h2>
                    <AccountInfo title='Account ID' data={accountData.accountId} />
                    <AccountInfo title='Account Type' data={accountData.accountType} />
                    <AccountInfo title='Total Credits' data={accountData.totalCredits} currency='£' />
                    <AccountInfo title='Total Debits' data={accountData.totalDebits} currency='£' />
                    <AccountInfo title='Currency Code' data={accountData.currencyCode} />
                    <h2>Daily Balances</h2>
                    <div className='balance-heading'>
                        <h3>Date</h3>
                        <h3>Balance (GBP)</h3>
                    </div>
                    <div>
                        {accountData.endOfDayBalances.map((dailyBalance) => (<DailyBalance key={dailyBalance.date} balance={dailyBalance} />))}
                    </div>
                </div>) 
                }
            </div>
            <div>
            { error && (<h4 className='no-result'>{error}</h4>)}
            </div>
        </div>
                    
    )
}

export default SearchAccount
