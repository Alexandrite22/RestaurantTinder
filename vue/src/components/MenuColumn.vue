<template>
  <b-container class="border">
      <b-row>
        <h1>Menu</h1>
      </b-row>
        <b-row class="text-center" align-v="center">
          <b-col>
            <router-link to="/">
            <b-button variant="outline-primary">
              <h6><b-icon-house-door-fill variant="light"/> &nbsp; Home</h6>
            </b-button>
            </router-link>
          </b-col>
        </b-row>
    
      <b-row class="text-center" align-v="center">
        <b-col>
          <b-button variant="outline-primary" href="http://localhost:8080/newParty" >
            <h6>Create party</h6>
          </b-button>
        </b-col>
      </b-row>
    

    <b-row class="text-center" align-v="center">
      <b-col>
        <router-link to="/dashboard">
        <b-button variant="outline-primary">
          <h6>View parties</h6>
        </b-button>
        </router-link>
      </b-col>
    </b-row>


  
    <b-row class="text-center" align-v="center">
      <b-col>
        <b-button variant="outline-primary" href="http://localhost:8080/dashboard">
          <h6>My current plans</h6>
        </b-button>
      </b-col>
    </b-row>

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
  </b-container>
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
  color: black;
  opacity: 100%;
}
</style>