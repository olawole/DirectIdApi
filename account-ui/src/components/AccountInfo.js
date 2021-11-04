import React from 'react'
import './AccountInfo.css'

const AccountInfo = (props) => {
    return (
        <div className='account-info'>
            <h4 className='title'>{props.title}</h4>
            <h4>{props.currency && <span>{props.currency}</span>}{props.data}</h4>
        </div>
    )
}

export default AccountInfo
