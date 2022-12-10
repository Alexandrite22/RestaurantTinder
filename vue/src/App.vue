<template>
  <span id="app">
    <b-row id="nav-bar">
      <span id = "header">
        TESST
        <router-link class="solid-text" v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
        <router-link class="solid-text" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
      </span>
    </b-row>    
    <div id = "main-container">
      <b-row id = "sub-container">
        <b-col id="menuColumn"  class="col-2 panel">
          <div>
            <menu-column class = "content" id="menu" style = "  border:solid !important;
  border-color: black !important;
  border-radius: 15px !important;
  border-width: 3px !important;
  background: rgba(255,255,255,0.5);
  height: 80vh;"/>
          </div>
        </b-col>
        <b-col id="homeColumn" class="col-8 panel">
          <div>
            <router-view class = "content"/>
          </div>
        </b-col>
        <b-col id="detailsColumn" class="col-2 panel">
          <div>
            <details-column class = "content" id="details" style = "  border:solid !important;
  border-color: black !important;
  border-radius: 15px !important;
  border-width: 3px !important;
  background: rgba(255,255,255,0.5);
  height: 80vh;"/>
          </div>
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
  min-height: 95vh;
}
#header
{
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-content: center;
  background: rgba(255,255,255,0.5); 
  margin: 1vw;
  width: 100vw;
  margin-bottom: 0vw;
  border:solid;
  border-color: black;
  border-radius: 15px;
  border-width: 3px;
}
#app
{
  height: 100%;
  min-height: 100%;
}
.panel
{
  height: 80vh;
}
.content
{
  border:solid !important;
  border-color: black !important;
  border-radius: 15px !important;
  border-width: 3px !important;
  background: rgba(255,255,255,0.5);
  height: 80vh;
  padding:0.5em;
}
#main-container
{
  padding: 4vw;
  padding-top: 1vw;
  padding-bottom: 0vh;
  justify-content: center;
  align-content: center;
  height: 90vh;
}
#sub-container
{
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
#nav-bar
{
  margin: 3vw;
  width: 92vw;
  margin-bottom: 0vw;
}
.solid-text
{
  opacity: 100%;
  font-weight: bolder;
  color: black;
}
</style>