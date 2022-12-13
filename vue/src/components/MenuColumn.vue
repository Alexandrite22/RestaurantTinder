<template>
  <div>
    <h1>Menu</h1>
    <h6><router-link to="/">Home</router-link></h6>
    <h6><a href="http://localhost:8080/newParty">Create party</a></h6>

    <h6><router-link to="/dashboard">View parties</router-link></h6>
    <br />
    <br />
    <h6><a href="http://localhost:8080/dashboard">My current plans</a></h6>

    <div v-if="this.$store.parties">
      <ul>
        <li v-for="party in this.$store.parties" v-bind:key="party.Id">
          <router-link :to="party.InviteLink">{{ party.Name }}</router-link>
        </li>
      </ul>
    </div>
    <!-- <ul>
            <li>
                Userette Nameabelle
            </li>
            <li>
                <router-link to = "/home">Home</router-link>
            </li>
            <li>
                <router-link to = "/newParty">Create Party</router-link>
            </li>
            <li>
                <router-link to = "/dashboard">View Parties</router-link>
            </li>
            <li>
            
            </li>
        </ul>     -->
  </div>
</template>

<script>
export default {
  name: "MenuColumn",
  data() {
    return {};
  },
  created() {
    console.log("MenuColumn created");
  },
};
</script>

<style>
.border {
  box-shadow: 5px 5px 5px rgba(0,0,0,0.25);
  border-style: hidden !important;
}
</style>