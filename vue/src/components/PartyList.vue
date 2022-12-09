<template>
    <div class="border">
        <div v-for="party in parties" v-bind:key="party">
            {{party}}
        </div>
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
                    this.parties = response.data;
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