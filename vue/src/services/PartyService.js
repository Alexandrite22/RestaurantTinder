import axios from 'axios';

export default {

  // create a new party using http://localhost:/party
    create(party) {
        console.log("createParty() in PartyService.js")
        return axios.post('/Party', party)
    },
    getParties(userId) {
        console.log("getParties() in PartyService.js")
        userId; //just getting rid of the warning
        return axios.get('/Party/')
    }

}
