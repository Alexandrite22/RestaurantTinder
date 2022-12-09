<template>
    <div class="border">
        <h1>Party List</h1>
        <h3>TODO: Finish this component</h3>
        <!-- <b-table-lite striped hover :parties="parties"></b-table-lite> TODO: Figure out bootstrap-vue table --> 

        <table >
            <tr>
                <th>Name</th>
                <th>Date</th>
                <th>Time</th>
                <th>Location</th>
                <!--<th>RSVPs</th> should we have a count of guests as rsvp -->
            </tr>
            <tr v-for="party in parties" v-bind:key="party.Id">
                <td>{{party.Name}}</td>
                <td>{{party.Date}}</td>
                <td>{{party.Time}}</td>
                <td>{{party.Location}}</td>
                
                <!--<td>{{party.partyRsvp}}</td> should we have a count of guests as rsvp -->
            </tr>
        </table>
    </div>
</template>

<script>
import PartyService from '../services/PartyService.js';

export default {
    name: 'party-list',
    data() {
        return {
            parties: []
        };
    },
    created() {
        this.getParties();
    },
    methods: {
        getParties() {
            PartyService.getParties(1)
                .then(response => {
                    response.data.forEach(thing => {
                        let temp = {  Id: thing.partyId, Name: thing.name, Date: thing.date, Time: thing.Date, Location: thing.location };
                        this.parties.push(temp);
                        console.log(temp);
                    });
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