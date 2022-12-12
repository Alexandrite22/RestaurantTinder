import axios from 'axios';

export default {

  // create a new party using http://localhost:/party
    async create(party) {
        console.log("createParty() in PartyService.js with:")
        console.log(party)
        let response = axios.post('/Party', party)
        console.log("create party response:" + await response);
        return response;
    },
    getParties(userId) {
        console.log(`getParties(${{userId}}) in PartyService.js`)
        let allParties = axios.get('/Party/');
        console.log(allParties);
        return allParties;
    },
    getParty(partyId) {

        console.log(`getParty(${partyId}) in PartyService.js`)
        let party = axios.get(`/Party/${partyId}`);
        console.log(party);
        return party;
    },
    //update a party
    updateParty(party) {
        console.log(`updateParty(${party}) in PartyService.js`)
        let updatedParty = axios.put(`/Party/${party.id}`, party);
        console.log(updatedParty);
        return updatedParty;
    },
    //delete a party
    deleteParty(partyId) {
        console.log(`deleteParty(${partyId}) in PartyService.js`)
        let deletedParty = axios.delete(`/Party/${partyId}`);
        console.log(deletedParty);
        return deletedParty;
    },



    //get all restaurants for a party
    getRestaurants(partyId) {
        console.log(`getRestaurants(${partyId}) in PartyService.js`)
        let restaurants = axios.get(`/Party/${partyId}/Restaurant`);
        console.log(restaurants);
        return restaurants;
    },
    


}
