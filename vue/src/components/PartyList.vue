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
          <td class="td">{{ party.name }}</td>
          <td class="td-2">{{ party.date }}</td>
          <td class="td">{{ party.date }}</td>
          <td class="td-2">{{ party.location }}</td>
          <td class="td">
            <router-link
              class="btn btn-success"
              v-bind:to="party.PartyInviteLink"
            >
              Invite Link
            </router-link>
          </td>
          <!-- TODO: FIX THE LINK ON THIS BUTTON TO GO TO THE PARTY DETAILS PAGE FOR THAT PARTY-->
          <td class="td-2">
            <router-link
              class="btn btn-success"
              :party="party"
              v-bind:to="party.PartyInviteLink"
              ><strike>Details</strike></router-link
            >
          </td>
          <!--<td>{{party.partyRsvp}}</td> should we have a count of guests as rsvp? -->
        </tr>
      </table>
    </div>
  </div>
</template>

<script>
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
      this.parties = this.$store.state.currentParties;
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