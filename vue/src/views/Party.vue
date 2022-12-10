<template>
  <div>
    <h1>WIP Party</h1>
    <p>
      This is where you can view your party details for a specific party.
    </p>
    <party-details props="party"
     />
  </div>
</template>

<script>
import PartyDetails from '../components/PartyDetails.vue';
import PartyService from '../services/PartyService.js';
export default {
    name: 'party-details',
    components: {
        PartyDetails
    },
    computed: {
        product() {
            return this.$store.getters.product;
            //use the getter for product in the store so that it always
            //gives me the product with the active product ID 
        }
    },

    //I want to set the 'active product' in the store to the id in my route
    created() {
        //get the product id from the route
        const activePartyId = this.$route.params.id;
        //commit a mutation to change the value in the store 
        PartyService.getParty(activePartyId);
    }
    //created() is a lifecycle hook that runs when the view is being made
    //so that this code runs before the view gets displayed in the DOM
}
</script>

<style>

</style>