<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
	<b-container>
      <b-row >
        <b-col id="menuColumn"  cols="1">
          <menu-column id="menu"/>
        </b-col>
        <b-col id="homeColumn" cols="10">
          <router-view />
        </b-col>
        <b-col id="detailsColumn" cols="1">
          <details-column id="details" />
        </b-col>
      </b-row>
    </b-container>

  </div>
</template>
<script>
import MenuColumn from "./components/MenuColumn.vue";
import DetailsColumn from "./components/DetailsColumn.vue";
export default {
  name: "app",
  components: {
	MenuColumn,
	DetailsColumn,
  }
};
</script>
<style >
body {
	background: linear-gradient(-45deg, #ee7752, #e73c7e, #23a6d5, #23d5ab);
	background-size: 400% 400%;
	animation: gradient 15s ease infinite;
	height: 100vh;
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

</style>