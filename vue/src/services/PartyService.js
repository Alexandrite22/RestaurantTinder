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
    }

}
