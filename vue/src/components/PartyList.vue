<template>
  <div class="border">
    <h1>Party List</h1>
    <h3></h3>
    <div class="container">
      <b-table-lite :parties="parties"></b-table-lite>

      <table class="table">
        <tr>
          <th class="th-lg" style="width: 30%">Name</th>
          <th class="th-lg" style="width: 15%">Date</th>
          <th class="th-lg" style="width: 10%">Time</th>
          <th class="th-lg" style="width: 15%">Location</th>
          <th class="th-lg" style="width: 30%">Invite Link</th>
          <th class="th-lg" style="width: 10%">Details</th>
          <!--<th>RSVPs</th> should we have a count of guests as rsvp -->
        </tr>
        <tr v-for="party in parties" v-bind:key="party.Id">
          <td class="td">{{ party.Name }}</td>
          <td class="td-2">{{ party.Date }}</td>
          <td class="td">{{ party.Date }}</td>
          <td class="td-2">{{ party.Location }}</td>
          <td class="td">
            <router-link class="btn btn-success" :to="party.InviteLink">
              Invite Link
            </router-link>
            </td>
          <!-- TODO: FIX THE LINK ON THIS BUTTON TO GO TO THE PARTY DETAILS PAGE FOR THAT PARTY-->
          <td class="td-2"><router-link class="btn btn-success" :party="party-vote" to="/party/details/:partyId/vote">Vote</router-link></td>
          <!--<td>{{party.partyRsvp}}</td> should we have a count of guests as rsvp? -->
        </tr>
      </table>
    </div>
  </div>
</template>

<script>
import PartyService from "../services/PartyService.js";

export default {
  name: "party-list",
  data() {
    return {
      parties: [],
    };
  },
  created() {
    this.getParties();
  },
  methods: {
    getParties() {
      PartyService.getParties(1)
        .then((response) => {
          response.data.forEach((thing) => {
            let temp = {
              Id: thing.partyId,
              Name: thing.name,
              Date: thing.date,
              Time: thing.date,
              Description: thing.description,
              InviteLink: thing.inviteLink,
              Location: thing.location,
              PartyRsvp: thing.guestList,
              Restaurants: thing.restaurantList,
            };
            this.parties.push(temp);
          
            // console.log("This is the list of properties for a party");
            // console.log(temp);
          });
        })
        .catch((error) => {
          console.log(error);
        });
        console.log("This is the list of parties and all their properties");
        console.log(this.parties);
        this.$store.commit("SET_CURRENT_PARTIES", this.parties);
        console.log("This is the list of parties in the store");
        console.log(this.$store.state.currentParties);
    },
  },
};
</script>

<style>
.th-lg {
  font-size: 28px;
  text-align: left;
  background-color: rgba(0, 0, 0, 0.25);
}
</style>