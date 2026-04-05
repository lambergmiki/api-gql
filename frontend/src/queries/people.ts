import gql from 'graphql-tag'

export interface Person {
    id: number
    firstName: string
    lastName: string
    age: number
    gender: string
}

export const GET_PEOPLE  = gql`
    query GetPeople {
    people {
    id
    firstName
    lastName
    age
    gender
    }
  }  
`