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
          <td class="td">{{ party.time }}</td>
          <td class="td-2">{{ party.location }}</td>
          <td class="td">
            <router-link
              class="btn btn-success"
              v-bind:to="party.inviteLink"
            >
              Invite Link
            </router-link>
          </td>

          <td class="td-2"><router-link class="btn btn-success" v-bind:to="{name: 'rsvp', params:{partyId: party.partyId}}">Vote</router-link></td>

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
      // foreach party in this.parties set party.time to a string with the format "hour:minute" ie "8:45"
      this.parties.forEach(party => {
        party.time = party.date.substring(11, 16);
      });
      // foreach party in this.parties set party.date to a string with the format "month day" ie "Jan 1"
      this.parties.forEach(party => {
        party.date = party.date.substring(5, 7) + " " + party.date.substring(8, 10);
      });
    console.log(this.parties);
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