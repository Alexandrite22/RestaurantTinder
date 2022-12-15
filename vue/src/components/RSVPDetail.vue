<template>
  <div>
      <h1>RSVP for {{party.name}}</h1>
      <p>{{party.description}}</p>
                <label for="guestSelect">Select Guest:</label>
                <select name="guestSelect" id="guestSelect">
                <option v-for="guest in party.guestList" v-bind:key="guest.guestId" v-bind:value="guest.name">{{guest.name}}</option>
                </select>
                <br>
                <label for="rsvpID">RSVP ID:</label>
                <input type="text" id="rsvpID" name="rsvpID"><br>

<hr> 

  </div>
</template>

<script>
import partyService from '../services/PartyService.js';
export default {
    name: 'rsvp-detail', 
    data() {return {
        party: {},
    }},
    created() {
        this.getParty();
    },
    methods: {
        getParty() {
         partyService.getParty(this.$route.params.partyId)
                .then(response => {

                    this.party = response.data;

                });
        }
    }
}
</script>

<style>

</style>