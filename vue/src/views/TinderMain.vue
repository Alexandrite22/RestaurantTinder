<template>
    <div>
        <row class = "row">
        <col-3 id = "static" class="col-3">
            <h2>Name: {{party.name}}</h2>
            <h3>ID: {{party.partyId}}</h3>
            <h4>Date: {{party.date}}</h4>
            <h5>Time: {{party.time}}</h5>
            <h5>Location: {{party.location}}</h5>
            <h6>Description: {{party.description}}</h6>   
            <h6>Host: {{party.owner}}</h6>
            <h6>Attendees: {{party.guestList.length}} </h6>
            <attendee-form  v-bind:guests="party.guestList" v-bind:partyId="party.partyId"/>

            <h6>Restaurants: </h6>
            <ol>
                <!-- <li v-for="restaurant in party.restaurants" :key="restaurant.restaurantId" class = "li">
                    {{restaurant.yelpLink}}
                </li> -->
            </ol>
            <!--<router-link class="btn btn-success" v-bind:to="{name: 'rsvp', params:{partyId: party.partyId}}">Tind-RSVP (Haha get it like tinder but the r is rsvp)</router-link>--><!-- This is the link to voting and picking a name -->
        </col-3>
        <col-9 id = "rest-list" class = "col-9">
            <restaurant-card-v2/>
        </col-9>
        </row>
        <!-- this is where we view our restaurants and sort through their data -->
    </div>
</template>

<script>
import partyService from '../services/PartyService.js';
import RestaurantCardV2 from '../components/RestaurantCardV2.vue';
import attendeeForm from '../components/AttendeeForm.vue';
export default {
  components: { RestaurantCardV2, attendeeForm },
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
#static
{
    border-radius: 5px;
    background: rgba(255,255,255,0.5);
    width: 13vw;
    margin: 10px;
    position: fixed;
    margin-top: 0px;
}
#rest-list
{
    margin-left: 15vw;
}
</style>