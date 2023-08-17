
import React from 'react';
import { useGetCustomersQuery } from '../../../graphql/generated/schema';

export default function CustomersDashboard() {
    const { data:customersData, loading, error } = useGetCustomersQuery();
    if(loading) {
        return <div>Loading ...</div>
    }

    if(error || !customersData){
        return <div>Error</div>
    }

    return (
        <div>
            <h2>Customers</h2>
            <ul>
                {customersData.customers?.map(custoner => (
                    <li key={custoner?.id}>{custoner?.firstName}</li>
                ))}
            </ul>
        </div>
    )
}