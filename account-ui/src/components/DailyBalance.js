import React from 'react'
import './DailyBalance.css'

const DailyBalance = ({ balance }) => {
    return (
        <div className='daily-balance'>
            <h4>{balance.date}</h4>
            <h4>£{balance.balance}</h4>
        </div>
    )
}

export default DailyBalance
