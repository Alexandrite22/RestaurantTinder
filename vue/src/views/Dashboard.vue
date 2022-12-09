<template>
  <div>
    <h2>Dashboard</h2>
    <party-list />
  </div>
</template>

<script>
import PartyList from "../components/PartyList.vue";
export default {
    name: "Dashboard",
    components: {
        PartyList
    }
}
</script>

<style>

</style>