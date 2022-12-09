<template>
    <div class="border new-party-form">
        <h1>New Party Form</h1>
        <form v-on:submit.prevent="addNewParty">
            <div class="form-element">
                <label for="name">Name:</label>
                <input id="name" type="text" v-model="party.name" placeholder="Party Name" />
            </div>

            <div class="form-element">
                <label for="description">Description:</label>
                <input id="description" type="text" v-model="party.description" placeholder="Party Description" />
            </div>

            <div class="form-element">
                 <label for="date">Date:</label> <!--// TODO Make this a date picker -->
                <input id="date" type="text" v-model="party.date" placeholder="Party Date" />
            </div>

            <div class="form-element">
                <label for="time">Party Time:</label>
                <input id="time" type="text" v-model="party.time" placeholder="Party Time" />
            </div>

            <div class="form-element">
                <label for="location">Location:</label> <!--// TODO Make this a location picker -->
                <input id="location" type="text" v-model="party.location" placeholder="Ex. Cleveland OH" />
            </div>
            <input type="submit" value="Save" variant="btn btn-default"  class="btn btn-default" >
            <input type="button" value="Cancel" v-on:click="resetForm($event)">

            <!-- <b-button type="submit" variant="btn btn-default" >Create</b-button> -->
        </form>
    </div>
</template>

<script>
import NewPartyService from '../services/PartyService.js'
export default {
    name: 'new-party-form',
    data() {
        return {
            party: {
                name: '',
                description: '',
                date: '',
                time: '',
                location: '',
                owner: 1,//TODO make this current user_id
            },

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
            console.log("Calling partyservice create method");
            console.log(this.party);
            this.party.owner = this.$store.state.user.id;
            NewPartyService.create(this.party)
                .then(response => {
                    console.log(response);
                    this.$emit('party-created', response.data);
                })
                .catch(error => {
                    console.log(error);
                });
        }
    }

}

</script>

<style>

</style>