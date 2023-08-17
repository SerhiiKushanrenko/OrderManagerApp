import React from 'react';
import './styles.css';
import { ApolloClient, ApolloProvider, InMemoryCache } from '@apollo/client';
import CustomersDashboard from '../../features/customers/customersDashboard/customersDashboard';


const client = new ApolloClient({
  cache: new InMemoryCache({
    typePolicies: {}
  }),
  uri: "http://localhost:5257/graphql/"
}); 


function App() {
  return (
    <ApolloProvider client={client}>
      <CustomersDashboard/>
    </ApolloProvider>
  );
}

export default App;
