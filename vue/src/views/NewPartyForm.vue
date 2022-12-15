<template>
    <div class = "border">
        <new-party-form />
    </div>
</template>

<script>
import NewPartyForm from "../components/NewPartyForm.vue";
export default {
    components: {
        NewPartyForm
    }
    
}
</script>

<style>
.border
{
    border-radius: 5px;
    border-style: hidden !important;
    background: rgba(255,255,255,0.5);
}
</style>