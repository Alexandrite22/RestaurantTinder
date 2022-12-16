<template>
  <b-container id="padding" class="border">
    <b-card class="text-center h-100" style="background-color: transparent">
      <b-card-title
        class="d-flex align-items-center justify-content-center"
        style="height: 10rem"
      >
        <!-- <h2>Menu</h2> -->
        <img id="logo" src="../imgs/Me(4).png" />
      </b-card-title>

      <b-list-group>
        <b-button
          class="
            list-group-item list-group-item-action
            p-0
            m-0
            d-flex
            align-items-center
            justify-content-center
          "
          variant="outline-primary"
          style="background-color: transparent; height: 4rem; box-shadow: none"
          href="http://localhost:8080/"
        >
          <h5><b-icon-house-door-fill variant="light" /> &nbsp; Home</h5>
        </b-button>

        <router-link
          v-if="$store.state.token != ''"
          v-bind:to="{ name: 'logout' }"
          style="text-decoration: none"
        >
          <b-button
            class="
              list-group-item list-group-item-action
              p-0
              m-0
              d-flex
              align-items-center
              justify-content-center
            "
            variant="outline-primary"
            style="
              background-color: transparent;
              height: 4rem;
              box-shadow: none;
            "
          >
            <h5><b-icon-key-fill variant="light" /> &nbsp; Logout</h5>
          </b-button>
        </router-link>

        <b-button
          class="
            list-group-item list-group-item-action
            p-0
            m-0
            d-flex
            align-items-center
            justify-content-center
          "
          variant="outline-primary"
          style="background-color: transparent; height: 4rem; box-shadow: none"
          href="http://localhost:8080/about"
        >
          <h5><b-icon-info-circle-fill variant="light" /> &nbsp; About Us</h5>
        </b-button>

        <b-button
          class="
            list-group-item list-group-item-action
            p-0
            m-0
            d-flex
            align-items-center
            justify-content-center
          "
          variant="outline-primary"
          style="background-color: transparent; height: 4rem; box-shadow: none"
          href="http://localhost:8080/newParty"
        >
          <h5><b-icon-people-fill variant="light" /> &nbsp; Create party</h5>
        </b-button>

        <router-link
          v-bind:to="{ name: 'dashboard' }"
          style="text-decoration: none"
        >
          <b-button
            class="
              menu-button
              list-group-item list-group-item-action
              p-0
              m-0
              d-flex
              align-items-center
              justify-content-center
            "
            variant="outline-primary"
            style="
              background-color: transparent;
              height: 4rem;
              box-shadow: none;
            "
          >
            <h5><b-icon-eye-fill variant="light" /> &nbsp; View parties</h5>
          </b-button>
        </router-link>

        <b-button
          class="
            menu-button
            list-group-item list-group-item-action
            p-0
            m-0
            d-flex
            align-items-center
            justify-content-center
          "
          variant="outline-primary"
          style="background-color: transparent; height: 4rem; box-shadow: none"
          href="http://localhost:8080/dashboard"
        >
          <h5>
            <b-icon-calendar-check-fill variant="light" /> &nbsp; My current
            plans
          </h5>
        </b-button>

        <b-list-group class="sub-list">
          <router-link
            :to="party.InviteLink"
            v-for="party in this.$store.state.currentParties"
            v-bind:key="party.Id"
            style="text-decoration: none"
          >
            <b-list-group-item
              variant="outline-primary"
              style="background-color: transparent"
            >
              {{ party.Name }}
            </b-list-group-item>
          </router-link>
        </b-list-group>
      </b-list-group>
      <button @click="TestMethod()"></button>
    </b-card>
  </b-container>
</template>

<script>
import YelpService from "../services/YelpService.js";

export default {
  name: "MenuColumn",
  data() {
    return {};
  },
  methods: {
    TestMethod() {
      console.log(YelpService.getRestaurants());
    },
  },

  created() {
    console.log("MenuColumn created");
  },
};
</script>

<style>
.border {
  box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.25);
  border-style: hidden !important;
}
.menu-button {
  border-radius: 5px !important;
}

.border {
  box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.25);
}

.card-body {
  padding: 0 !important;
  background: rgba(255, 255, 255, 0.5);
  border-radius: 5px;
  box-shadow: rgba(0, 0, 0, 0.25);
}

#logo {
  max-height: 250px;
}
.sub-list {
  overflow: auto;
  white-space: nowrap;
}
</style>