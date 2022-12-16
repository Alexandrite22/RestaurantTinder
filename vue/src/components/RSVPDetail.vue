<template>
  <div>
      <h1>RSVP for {{party.name}}</h1>
      <p>{{party.description}}</p>
                <label for="guestSelect">Select Guest:</label>
                <select name="guestSelect" id="guestSelect" v-model="name">
                <option v-for="guest in party.guestList" v-bind:key="guest.guestId" v-bind:value="guest.name">{{guest.name}}</option>
                </select>
                <br>
                <label for="rsvpID">RSVP ID:</label>
                <input type="text" id="rsvpID" name="rsvpID"><br>

                <p>Current Likes:</p>
                <ul>
                    <li v-for="restuarant in $store.state.current_likes" v-bind:key="restuarant.restuarantId">{{restuarant.name}}</li>
                </ul>
                <p>Current Dislikes:</p>
                <ul>
                    <li v-for="restuarant in $store.state.current_dislikes" v-bind:key="restuarant.restuarantId">{{restuarant.name}}</li>
                </ul>
                <button v-on:click="submitRsvp()">Submit RSVP</button>
            <hr> 

    <restuarant-card-v-2  />

  </div>
</template>

<script>
import partyService from '../services/PartyService.js';
import restuarantCardV2 from '../components/RestaurantCardV2.vue';
export default {
    name: 'rsvp-detail', 
    components: { restuarantCardV2 },
    data() {return {
        name: '',
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
        },
        submitRsvp() { 
            let entry = {
                user: this.name,
                likes: this.$store.state.current_likes,
                dislikes: this.$store.state.current_dislikes
            };
            this.$store.commit('ADD_USER_LIKES_ENTRY', entry);
            this.$router.push({ name: 'home'});
        }
    }
}
</script>

<style>

</style>