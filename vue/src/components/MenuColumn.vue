<template>
  <b-container class="border">

    <b-card class="text-center h-100" style="background-color: transparent;">

        <b-card-title class="d-flex align-items-center justify-content-center" style="height: 5rem;"><h2>Menu</h2></b-card-title>

            <b-list-group>

                <router-link to="/" style="text-decoration: none;">
                <b-button class="menu-button list-group-item list-group-item-action p-0 m-0 d-flex align-items-center justify-content-center" variant="outline-primary" style="background-color: transparent; height: 4rem; box-shadow:none;">
                  <h5><b-icon-house-door-fill variant="light"/> &nbsp; Home</h5>
                </b-button>
                </router-link>

                <router-link v-if="$store.state.token != ''" v-bind:to="{ name: 'logout' }" style="text-decoration: none;">
                <b-button class="menu-button list-group-item list-group-item-action p-0 m-0 d-flex align-items-center justify-content-center" variant="outline-primary" style="background-color: transparent; height: 4rem; box-shadow:none;">
                  <h5> <b-icon-key-fill variant="light"/> &nbsp; Logout</h5>
                </b-button>
                </router-link>

                 <router-link to="/about" style="text-decoration: none;">
                <b-button class="menu-button list-group-item list-group-item-action p-0 m-0 d-flex align-items-center justify-content-center" variant="outline-primary" style="background-color: transparent; height: 4rem; box-shadow:none;">
                  <h5> <b-icon-info-circle-fill variant="light"/> &nbsp; About Us</h5>
                </b-button>
                </router-link>


                <b-button class="list-group-item list-group-item-action p-0 m-0 d-flex align-items-center justify-content-center" variant="outline-primary" style="background-color: transparent; height: 4rem; box-shadow:none;" href="http://localhost:8080/newParty"  >
                <h5><b-icon-people-fill variant="light"/> &nbsp; Create party</h5>
                </b-button>
                        
                <router-link to="/dashboard" style="text-decoration: none;">
                <b-button class="menu-button list-group-item list-group-item-action p-0 m-0 d-flex align-items-center justify-content-center" variant="outline-primary" style="background-color: transparent; height: 4rem; box-shadow:none;">
                  <h5> <b-icon-eye-fill variant="light"/> &nbsp; View parties</h5>
                </b-button>
                </router-link>
                        
                <b-button class="menu-button list-group-item list-group-item-action p-0 m-0 d-flex align-items-center justify-content-center" variant="outline-primary" style="background-color: transparent; height: 4rem; box-shadow:none;" href="http://localhost:8080/dashboard">
                  <h5> <b-icon-calendar-check-fill variant="light"/> &nbsp; My current plans</h5>
                </b-button>

                  <b-list-group class="sub-list">
                    <router-link :to="party.InviteLink" v-for="party in this.$store.state.currentParties" v-bind:key="party.Id" style="text-decoration: none;">
                      <b-list-group-item  variant="outline-primary" style="background-color: transparent;" >
                      {{ party.Name }}
                    </b-list-group-item>
                    </router-link>
                    
                  </b-list-group>
                
            </b-list-group>
      
    </b-card>
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
.menu-button
{
  border-radius: 5px !important;
}

.border {
  box-shadow: 5px 5px 5px rgba(0,0,0,0.25);
}

.card-body {
  padding: 0 !important;
}
.sub-list
{
  overflow: auto;
  white-space: nowrap;
}
</style>