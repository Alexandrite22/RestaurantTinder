<template>
    <div class="border" style="background-color: blue;">
        <h1>I am important but less so</h1>
        <!-- <party-list />
        <party-form /> -->
    </div>
</template>

<script>
// import PartyList from "../PartyList.vue";
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
        // NewPartyForm,
        // PartyList
    }
}
</script>

<style>

</style>