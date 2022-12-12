<template>
    <div>
        <!-- this is where we view a single party's data -->
        <h1>Party Details</h1>
        <ul>
            <li>
                <b-row>
                    <b-col cols="6">
                        <strong><h2>Name</h2></strong>
                    </b-col>
                    <b-col cols="6">
                        <h2>{{party.name}}</h2>
                    </b-col>
                </b-row>
            </li>
            <li>
                <b-row>
                    <b-col cols="6">
                        <strong><h2>Date</h2></strong>
                    </b-col>
                    <b-col cols="6">
                        <h2>{{party.date}}</h2>
                    </b-col>
                </b-row>
            </li>
            <li>
                <b-row>
                    <b-col cols="6">
                        <strong><h2>fill in other details or something etc...</h2></strong>
                    </b-col>
                    <b-col cols="6">
                        <h2>{{party.name}}</h2>
                    </b-col>
                </b-row>
            </li>
        </ul>        
    </div>
</template>

<script>
import partyService from '../services/PartyService.js';


export default {
    name: 'party-details',
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
            partyService.getParty(this.$route.params.id)
                .then(party => {
                    this.party = party;
                });
        }
    }
}
</script>

<style>

</style>