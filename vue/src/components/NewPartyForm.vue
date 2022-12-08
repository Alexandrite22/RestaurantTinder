<template>
    <div class="border new-party-form">
        <h1>New Party Form</h1>
        <form @submit.prevent="create">
            <!-- <input type="text" v-model="partyName" placeholder="Party Name" />
            <input type="text" v-model="partyDescription" placeholder="Party Description" />
            <input type="text" v-model="partyDate" placeholder="Party Date" />
            <input type="text" v-model="partyTime" placeholder="Party Time" /> -->
            <input type="text" v-model="partyLocation" placeholder="Party Location City" />
            <b-button type="submit" variant="btn btn-default" @click="create">Create</b-button>
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
                partyName: 'partyName',
                partyDescription: 'partyDescription',
                partyDate: 'partyDate',
                partyTime: 'partyTime',
                partyLocation: 'partyLocation'
            },
        }
    },
    methods: {
        create() {
            console.log("Calling partyservice create method");
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