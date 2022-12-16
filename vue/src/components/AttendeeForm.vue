<template>  
    <div>
        <form v-on:submit.prevent="addGuest()">
        <label for="guestName">Name:</label>
        <input type="text" id="guestName" name="guestName" v-model="guest.name">
        <button type="submit">Add Guest</button>
        </form>
        <h2>Guests:</h2>
        <ul>
            <li v-for="guest in guests" v-bind:key="guest.id">{{guest.name}}</li>
            <li v-for="guest in newGuests" v-bind:key="guest.id">{{guest.name}}</li>
        </ul>
    </div>
</template>

<script>
import partyService from '../services/PartyService.js';
export default {
    name: 'attendee-form',
    props: ['guests', 'partyId'],
    data() {
        return {
            guest: {},
            newGuests: [],
            rsvped: []
        }
    },
    methods: {
        addGuest() {
            partyService.inviteGuestToParty(this.guest.name, this.partyId)
                .then((response) => {this.newGuests.push(response.data)});
           // this.newGuests.push(this.guest);
            this.guest = {};
            //TODO: actually send to API here but for now we'll fake it 
        }
    }

}
</script>

<style>

</style>