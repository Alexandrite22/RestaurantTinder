<template>
    <div>
        <div>
            <h1>Name: {{party.Name}}</h1>
            <h2>ID: {{party.Id}}</h2>
            <h3>Date: {{party.Date}}</h3>
            <h4>Time: {{party.Time}}</h4>
            <h5>Location: {{party.Location}}</h5>
            <h6>Description: {{party.Description}}</h6>   
            <h6>Host: {{party.Owner}}</h6>
            <h6>Attendees: </h6>
            <ol>
                <li v-for="guest in party.PartyRsvp" :key="guest.guest_Id">
                    {{guest.name}}
                </li>
            </ol>
            <h6>Restaurants: </h6>
            <ol>
                <li v-for="restaurant in party.Restaurants" :key="restaurant.restaurant_Id">
                    {{restaurant.api_address}}
                </li>
            </ol>
        </div>
        <router-link to="#">Tind-RSVP (Haha get it like tinder but the r is rsvp)</router-link><!-- This is the link to voting and picking a name -->
    
        <!-- this is where we view our restaurants and sort through their data -->
    </div>
</template>

<script>
import partyService from '../services/PartyService.js';
export default {
    name: 'tinder-main',
    data() {
        return {
            party: {}
        };
    },
    created() {
        this.getParty();
    },
    methods: {
        getParty() {
            partyService.getParty(this.$route.params.partyId)
                .then(response => {
                    console.log("this is the response");
                    console.log(response);
                    this.party = {
                        Id: response.data.partyId,
                        Name: response.data.name,
                        Date: response.data.date,
                        Time: response.data.date,
                        Description: response.data.description,
                        InviteLink: response.data.inviteLink,
                        Location: response.data.location,
                        PartyRsvp: response.data.guestList,
                        Restaurants: response.data.restaurantList,
                    }
                    console.log("this is the party");
                    console.log(this.party);
                });
        }
    }
}
</script>

<style>

</style>