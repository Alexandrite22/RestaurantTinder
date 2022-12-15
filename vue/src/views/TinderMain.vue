<template>
    <div>
        <row class = "row">
        <col-3 class="col-3">
            <h1>Name: {{party.name}}</h1>
            <h2>ID: {{party.partyId}}</h2>
            <h3>Date: {{party.date}}</h3>
            <h4>Time: {{party.time}}</h4>
            <h5>Location: {{party.location}}</h5>
            <h6>Description: {{party.description}}</h6>   
            <h6>Host: {{party.owner}}</h6>
            <h6>Attendees: </h6>
            <ol>
                <li v-for="guest in party.PartyRsvp" :key="guest.guest_Id">
                    {{guest.name}}
                </li>
            </ol>
            <h6>Restaurants: </h6>
            <ol>
                <li v-for="restaurant in party.restaurants" :key="restaurant.restaurantId" class = "li">
                    {{restaurant.yelpLink}}
                </li>
            </ol>
            <router-link to="#">Tind-RSVP (Haha get it like tinder but the r is rsvp)</router-link><!-- This is the link to voting and picking a name -->
        </col-3>
        <col-9 class = "col-9">
            <restaurant-card-v2/>
        </col-9>
        </row>
        <!-- this is where we view our restaurants and sort through their data -->
    </div>
</template>

<script>
import partyService from '../services/PartyService.js';
import RestaurantCardV2 from '../components/RestaurantCardV2.vue';
export default {
  components: { RestaurantCardV2 },
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
            // let partyId = this.$route.params.partyId;
            // console.log("I think this is the "+partyId);
            // let filteredParties = this.$store.state.currentParties.filter(party => {
            //     party.partyId==partyId;
                
            // });
            // this.party = filteredParties[0];
            // console.log(this.party);
            
            partyService.getParty(this.$route.params.partyId)
                .then(response => {
                    console.log("this is the response");
                    console.log(response);
                    // this.party = {
                    //     partyId: response.data.partyId,
                    //     name: response.data.name,
                    //     date: response.data.date,
                    //     time: response.data.date,
                    //     description: response.data.description,
                    //     inviteLink: response.data.inviteLink,
                    //     location: response.data.location,
                    //     partyRsvp: response.data.guestList,
                    //     restaurants: response.data.restaurantList,
                    // }
                    this.party = response.data;
                    console.log("this is the party");
                    console.log(this.party);
                });
        }
    }
}
</script>

<style>

</style>