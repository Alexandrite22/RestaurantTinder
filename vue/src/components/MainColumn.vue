<template>
    <div style="background-color: blue;">
        <h1>I am important but less so</h1>
        <party-form />
    </div>
</template>

<script>
import PartyForm from "./NewPartyForm.vue";
export default {
 name: 'MainColumn',
    data() {
        return {};
    },
    created() {
        console.log("MainColumn created");
    },
    components: {
        PartyForm,
    }
}
</script>

<style>

</style>