<template>
    <div class="border new-party-form">
        <h1>New Party Form</h1>
        <form v-on:submit.prevent="addNewParty" v-show="showForm === true">
            <div class="form-element">
                <label for="name">Name:</label>
                <input id="name" type="text" v-model="party.name" placeholder="Party Name" />
            </div>

            <div class="form-element">
                <label for="description">Description:</label>
                <input id="description" type="text" v-model="party.description" placeholder="Party Description" />
            </div>

           <!-- <div class="form-element">
                 <label for="">Date:</label> --><!--// TODO Make this a date picker and bind for="date" again-->
               <!--  <input id="date" type="text" v-model="party.date" placeholder="Party Date" />
            </div>-->

            <div class="form-element">
                <label for="time">Party Time:</label>
                <input id="time" type="text" v-model="party.time" placeholder="Party Time" />
            </div>

            <div class="form-element">
                <label for="location">Location:</label> <!--// TODO Make this a location picker -->
                <input id="location" type="text" v-model="party.location" placeholder="Ex. Cleveland OH" />
            </div>
            <input type="submit" value="Save" class="btn btn-success"/>
            
            <!-- <b-button type="submit" variant="btn btn-default" >Create</b-button> -->
        </form>
        <div v-if="showForm === false">
            <h2>Party Created!</h2>
            <p> Click the button below to view your parties.</p>
            <router-link to="/dashboard" class="btn btn-default">View all parties</router-link>
        </div>
    </div>
</template>

<script>
import NewPartyService from '../services/PartyService.js'
export default {
    name: 'new-party-form',
    data() {
        return {
            party: {
                owner: 1,//TODO make this current user_id
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
        }
    },
    methods: {
        addNewParty() {
            console.log("Calling partyservice create method on this object");
            console.log(this.party);
            this.party.owner = this.$store.state.user.id;
            NewPartyService.create(this.party)
                .then(response => {
                    console.log("Party created, response below");
                    console.log(response);
                    this.$emit('party-created', response.data);
                })
                .catch(error => {
                    console.log(error);
                });
            this.party = { owner: 1 }; //empty out the review 
            console.log("Party created, closing form" );
            this.showForm = false; //hide the form

        },

    }

}

</script>

<style>

</style>