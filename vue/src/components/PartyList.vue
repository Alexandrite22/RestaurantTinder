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
          <th class="th-lg" style="width: 30%">Link</th>
          <!--<th>RSVPs</th> should we have a count of guests as rsvp -->
        </tr>
        <tr v-for="party in parties" v-bind:key="party.Id">
          <td class="td">{{ party.Name }}</td>
          <td class="td-2">{{ party.Date }}</td>
          <td class="td">{{ party.Time }}</td>
          <td class="td-2">{{ party.Location }}</td>
          <td class="td">{{ party.InviteLink }}</td>

          <!--<td>{{party.partyRsvp}}</td> should we have a count of guests as rsvp -->
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
              Time: thing.Date,
              Location: thing.location,
            };
            this.parties.push(temp);
            console.log(temp);
          });
        })
        .catch((error) => {
          console.log(error);
        });
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