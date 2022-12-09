<template>
  <span id="app">
    <b-row id="nav-bar">
      <span id = "header">
        <router-link class="solid-text" v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
        <router-link class="solid-text" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
      </span>
    </b-row>    
    <div id = "main-container">
      <b-row >
        <b-col id="menuColumn"  class="col-2 panel">
          <menu-column id="menu"/>
        </b-col>
        <b-col id="homeColumn" class="col-8 panel">
          <router-view />
        </b-col>
        <b-col id="detailsColumn" class="col-2 panel">
          <details-column id="details" />
        </b-col>
      </b-row>
    </div>
  </span>
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
	/* background: linear-gradient(-45deg, #ee7752, #e73c7e, #23a6d5, #23d5ab);
	background-size: 400% 400%;
	animation: gradient 15s ease infinite;
	height: 100vh; */
  background-image: url("./imgs/MainBack.jpg");
  background-repeat: no-repeat;
  background-size: 100vw;
  margin: 1vw;

}
#header
{
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-content: center;
  background: white;
  opacity: 50%;
  margin: 1vw;
  width: 90vw;
  border:solid;
  border-color: black;
  border-radius: 15px;
  border-width: 3px;
}
.panel
{
  border:solid;
  border-color: black;
  border-radius: 15px;
  border-width: 3px;
  background-color: white;
  opacity: 50%;
}
#main-container
{
  padding: 2vw;
  justify-content: center;
  align-content: center;
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
#nav-bar
{
  margin: 2vw;
  width: 94vw;
}
.solid-text
{
  opacity: 100%;
  font-weight: bolder;
}
</style>