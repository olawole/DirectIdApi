import React, {useState} from 'react'
import './SearchAccount.css'
import DailyBalance from './DailyBalance';
import { baseApiUrl } from '../config';

const SearchAccount = () => {
    const [accountId, setAccountId] = useState('');
    const [accountData, setAccountData] = useState(null);
    const submitRequest = async (e) => {
        e.preventDefault();
        await fetch(`${baseApiUrl}/Account`, 
        {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ AccountId: accountId })
        }).then((response) => {
            if (response.ok) {
                return response.json()
            }
            throw response;
        }).then((data) => setAccountData(data));

        console.log(accountData);
    }
    return (
        <div className='main-page'>
            <div className='search-section'>
                <form className='search-form'>
                    <input className='search-text' placeholder='Search Account' type='text' value={accountId} onChange={(e) => setAccountId(e.target.value)}/>
                    <button className='btn-submit' onClick={submitRequest}>Submit</button>
                </form>   
            </div>
            <div className='result-section'>
                { accountData && (
                <div className='account-result'>
                    <h2>Account Information</h2>
                    <div className='account-info'>
                        <h4 className='title'>Account ID </h4>
                        <h4>{accountData.accountId}</h4>
                    </div>
                    <div className='account-info'>
                        <h4 className='title'>Account Type</h4>
                        <h4>{accountData.accountType}</h4>
                    </div>
                    <div className='account-info'>
                        <h4 className='title'>Display Name </h4>
                        <h4>{accountData.displayName}</h4>
                    </div>
                    <div className='account-info'>
                        <h4 className='title'>Total Credits </h4>
                        <h4>£{accountData.totalCredits}</h4>
                    </div>
                    <div className='account-info'>
                        <h4 className='title'>Total Debits </h4>
                        <h4>£{accountData.totalDebits}</h4>
                    </div>
                    <div className='account-info'>
                        <h4 className='title'>Currency Code</h4>
                        <h4>£{accountData.currencyCode}</h4>
                    </div>
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
                { !accountData && (<h4 className='no-result'>No result</h4>)}
            </div>
        </div>
                    
    )
}

export default SearchAccount
