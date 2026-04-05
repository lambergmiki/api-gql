import { ApolloClient, InMemoryCache, HttpLink } from '@apollo/client/core'

// Defines the HTTP connection to the GraphQL endpoint.
const httpLink = new HttpLink({
    uri: 'http://localhost:5293/graphql',
})

/*
* Apollo Client instance is created to be used throughout the app.
* InMemoryCache stores query results to avoid redundant network requests.
* */ 
export const apolloClient = new ApolloClient({
    link: httpLink,
    cache: new InMemoryCache(),
})