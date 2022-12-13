<template>
  <b-container class="border">

        <b-row class="text-center">
          <h1>Menu</h1>
        </b-row>

        <b-container class="d-flex" style="height: 35%; flex-direction:column; justify-content: space-between; white-space:nowrap; padding:0px 0px !important;" >
          <b-row class="text-center">
            <b-col>
              <router-link to="/">
              <b-button variant="outline-primary">
                <h6><b-icon-house-door-fill variant="light"/> &nbsp; Home</h6>
              </b-button>
              </router-link>
            </b-col>
          </b-row>
        <b-row class="text-center">
          <b-col>
            <b-button variant="outline-primary" href="http://localhost:8080/newParty" >
              <h6><b-icon-people-fill variant="light"/> &nbsp; Create party</h6>
            </b-button>
          </b-col>
        </b-row>
            
        
            <b-row class="text-center">
        <b-col>
          <router-link to="/dashboard">
          <b-button variant="outline-primary">
            <h6> <b-icon-eye-fill variant="light"/> &nbsp; View parties</h6>
          </b-button>
          </router-link>
        </b-col>
            </b-row>
        
        
          
            <b-row class="text-center">
        <b-col>
          <b-button variant="outline-primary" href="http://localhost:8080/dashboard">
            <h6>My current plans</h6>
          </b-button>
        </b-col>
            </b-row>
      </b-container>


    <div>
      <ul>
        <li v-for="party in this.$store.state.parties" v-bind:key="party.Id">
          test
          <router-link :to="party.InviteLink">{{ party.Name }}</router-link>
        </li>
      </ul>
    </div>


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
  box-shadow: 5px 5px 5px rgba(0,0,0,0.25);
  border-style: hidden !important;
}
</style>