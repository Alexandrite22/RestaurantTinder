<template>
    <div class="border" style="background-color: blue;">
        <h1>I am important but less so</h1>
        <create-event/>
    </div>
</template>

<script>
import CreateEvent from "../CreateEvent.vue";
import CreateEventCard from './CreateEventCard.vue';
// import NewPartyForm from "../NewPartyForm.vue";
export default {
 name: 'MainColumn',
    data() {
        return {
            newPartyId: -1,
        };
    },
    created() {
        console.log("MainColumn created");
    },
    components: {
        CreateEvent
        // NewPartyForm,
        // PartyList
    }
}
        CreateEventCard
</script>

<style>

</style>