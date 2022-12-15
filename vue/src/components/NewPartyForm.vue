<template>
  <div class="border new-party-form">
    <h1 id = "title">Make a Party</h1>
    <form class = "col-6" v-on:submit.prevent="addNewParty" v-show="showForm === true">
      <div class="form-element ">
        <label for="name">Name:</label>
        <input
          class="input-field"
          id="name"
          type="text"
          v-model="party.name"
          placeholder="Party Name"
        />
      </div>

      <div class="form-element">
        <label for="description">Description:</label>
        <input 
          class="input-field"
          id="description"
          type="text"
          v-model="party.description"
          placeholder="Party Description"
        />
      </div>

      <div class="form-element">
        <label for="date">Date:</label>
        --><!--// TODO Make this a date picker and bind for="date" again-->
        <input
          class="input-field"
          id="date"
          type="date"
          v-model="party.date"
          placeholder="Party Date"
        />
      </div>

      <div class="form-element">
        <label for="time">Select a time:</label>
        <input type="time" id="time" name="time" v-model="party.time" placeholder="Party Time" />
      </div>
       <!-- <div class="form-group">
        <label class="control-label"><i class="fa fa-calendar"></i> Datetime picker</label><br>
        <div class="form-group">
          <input type="text" size="10" class="form-control" ng-model="sharedDate" data-autoclose="1" placeholder="Date" bs-datepicker>
        </div>
        <div class="form-group">
          <input type="text" size="8" class="form-control" ng-model="sharedDate" data-time-format="h:mm:ss a" data-autoclose="1" placeholder="Time" bs-timepicker>
        </div>
      </div> -->
      <div class="form-element">
        <label for="location">Location:</label>
        <!--// TODO Make this a location picker -->
        <input
          class="input-field"
          id="location"
          type="text"
          v-model="party.location"
          placeholder="Ex. Cleveland OH"
        />
      </div>
          <div class="form-element">
        <label for="location">Invite Code:</label>
        <input
          class="input-field"
          id="party_invite_code"
          type="text"
          v-model="party.partyInviteCode"
          placeholder="invitation code word"
        />
      </div>
      <input type="submit" value="Save" class="btn btn-success" />

      <!-- <b-button type="submit" variant="btn btn-default" >Create</b-button> -->
    </form>
    <div v-if="showForm === false">
      <h2>Party Created!</h2>
      <p>Click the button below to view your parties.</p>
      <router-link to="/dashboard" class="btn btn-default"
        >View all parties</router-link
      >
    </div>
  </div>
</template>

<script>
import NewPartyService from "../services/PartyService.js";
export default {
  name: "new-party-form",
  data() {
    return {
      party: {
        owner: 1, //TODO make this current user_id
      },
      showForm: true,

      // party: {
      //     name: 'name_placeholder_set_in_vue_Party_Form',
      //     description: 'description_placeholder_set_in_vue_Party_Form',
      //     date: 'date_placeholder_set_in_vue_Party_Form',
      //     time: 'time_placeholder_set_in_vue_Party_Form',
      //     location: 'location_placeholder_set_in_vue_Party_Form',
      //     owner: 1,//TODO make this current user_id
      // },
    };
  },
  methods: {
    addNewParty() {
      console.log("Calling partyservice create method on this object");
      console.log(this.party);
      this.party.owner = this.$store.state.user.id;
      let myVar;
      NewPartyService.create(this.party)
        .then((response) => {
          console.log(response);
          this.$emit("party-created", response.data);
          myVar = response.data;
        })
        .catch((error) => {
          console.log(error);
        });
      this.party = { owner: 1 }; //empty out the review
      console.log("Party created, closing form");
      console.log(myVar);
      console.log(myVar);
      console.log("Adding newParty to parties in dataStore");
      this.$store.commit("ADD_NEW_PARTY", myVar);
      console.log(this.$store.state.parties);

      this.showForm = false; //hide the form
    },
  },
};
</script>

<style>
#title
{
  margin: 5px;
  margin-bottom: 15px;
}
.form-element
{
  margin: 5px;
}
.input-field
{
  display: flex;
}

</style>