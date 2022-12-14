<template>
  <span id="app">
    <!-- <b-row id="nav-bar">
      <span id="header" v-if="$store.state.token != ''">
        <router-link
          class="btn btn-primary solid-text"
          v-bind:to="'/'"
          style="margin-right: 0.7em"
          >Home</router-link
        >
        <router-link
          class="btn btn-primary solid-text"
          v-bind:to="{ name: 'logout' }"
          v-if="$store.state.token != ''"
          >Logout</router-link
        >
      </span>
    </b-row> -->
    <div id="main-container">
      <b-row id="sub-container">
        <b-col id="menuColumn" class="col-2 panel">
          <div>
            <menu-column
              class="content"
              id="menu"
              style="
                box-shadow: 5px 5px 5px rgba(0,0,0,0.25);
                background: rgba(255, 255, 255, 0.5);
              "
            />
          </div>
        </b-col>
        <b-col id="homeColumn" class="col-8 panel">
          <div>
            <router-view class="content" />
          </div>
        </b-col>
        <b-col id="detailsColumn" class="col-2 panel">
          <div>
            <details-column
              class="content"
              id="details"
              style="
                box-shadow: 5px 5px 5px rgba(0,0,0,0.25);
                background: rgba(255, 255, 255, 0.5);
              "
            />
          </div>
        </b-col>
      </b-row>
    </div>
  </span>
</template>
<script>
import PartyService from "./services/PartyService.js";
import MenuColumn from "./components/MenuColumn.vue";
import DetailsColumn from "./components/DetailsColumn.vue";
export default {
  data() {
    return {
      parties: [], 
    };
  },
  name: "app",
  components: {
    MenuColumn,
    DetailsColumn,
  },
  methods: {
    getParties() {
      PartyService.getParties(1)
        .then((response) => {
          response.data.forEach((thing) => {
            console.log("LOGGING MY THING BROOOSKI");
            console.log(thing);
            let tempBusinessList= thing.yelpBusinesses.businessesBusinesses;
            let temp = {
              PartyId: thing.partyId,
              PartyLocation: thing.location,
              PartyDate: thing.date,
              PartyOwner: thing.owner,
              PartyDescription: thing.description,
              PartyName: thing.name,
              PartyTime: thing.date,
              PartyInviteLink: thing.inviteLink,
              PartyRsvp: thing.guestList,
              PartyRestaurants: tempBusinessList,
            };
          console.log(tempBusinessList);
          this.parties.push(temp);
        
          // console.log("This is the list of properties for a party");
          // console.log(temp);
        });
      })
      .catch((error) => {
        console.log(error);
      });
      console.log("This is the list of parties and all their properties");
      console.log(this.parties);
      this.$store.commit("SET_CURRENT_PARTIES", this.parties);
      console.log("This is the list of parties in the store");
      console.log(this.$store.state.currentParties);
    }
  },
  created() {
    this.getParties();
  }
};
</script>
<style >
body {
  /* background: linear-gradient(-45deg, #ee7752, #e73c7e, #23a6d5, #23d5ab);
	background-size: 400% 400%;
	animation: gradient 15s ease infinite;
	height: 100vh; */
  font-family: "Poppins", Helvetica, sans-serif;
  background-image: url("./imgs/MainBack.jpg");
  background-repeat: no-repeat;
  background-size: 100vw;
  margin: 1vw;
  min-height: 95vh;
}
#header {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-content: center;
  background: rgba(255, 255, 255, 0.5);
  margin: 1vw;
  width: 92vw;
  margin-bottom: 0vw;
  box-shadow: 5px 5px 5px rgba(0,0,0,0.5);

}
.btn {
    box-shadow: 5px 5px 5px rgba(0,0,0,0.5);
    margin: 0.3rem;
}
#app {
  height: 100%;
  min-height: 100%;
}
.panel {
  height: 80vh;
}

.content {
  box-shadow: 5px 5px 5px rgba(0,0,0,0.25);
  background: rgba(255, 255, 255, 0.5);
  min-height: 70vh;
  height: 95vh;
  overflow: auto;
  padding: 0.5em;
}
#main-container {
  padding: 4vw;
  padding-top: 1vw;
  padding-bottom: 0vh;
  justify-content: center;
  align-content: center;
  height: auto;
}
#sub-container {
  height: 85vh;
}
@keyframes gradient {
  0% {
    background-position: 0% 50%;
  }
  50% {
    background-position: 100% 50%;
  }
  100% {
    background-position: 0% 50%;
  }
}
#nav-bar {
  margin: 3vw;
  width: 92vw;
  margin-bottom: 0vw;
}
.solid-text {
  opacity: 100%;
  font-weight: bolder;
  color: black;
}

::-webkit-scrollbar {
  width: 10px;
}
::-webkit-scrollbar-track {
  background: rgb(179, 177, 177);
  box-shadow: 5px 5px 5px rgba(0,0,0,0.25);
}

::-webkit-scrollbar-thumb {
  background: rgb(136, 136, 136);
  box-shadow: 5px 5px 5px rgba(0,0,0,0.25);
  
}

::-webkit-scrollbar-thumb:hover {
  background: rgb(100, 100, 100);
  box-shadow: 5px 5px 5px rgba(0,0,0,0.25);
}

::-webkit-scrollbar-thumb:active {
  background: rgb(68, 68, 68);
  box-shadow: 5px 5px 5px rgba(0,0,0,0.25);
  
}
</style>