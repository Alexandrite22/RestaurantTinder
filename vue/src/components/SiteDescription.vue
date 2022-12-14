<template>


<b-container>
  <b-card>
    <b-card-title>Our mission</b-card-title>
      <b-list-group>
        <b-list-group-item>
        </b-list-group-item>
      </b-list-group>
  </b-card>



  <div>
    <!-- <div>
      <b-col class="col-12" id="main-title"> ME-n-U </b-col>
    </div> -->
    <div class="col-12">
      <div id="box">
        <span id="about-us">
        Our Mission: Whether a simple date, a group outing, or a corporate event, we aim to revolutionize how groups select restaurants 
         <br/> Use our
        service to let everyone decide which restaurant will let your event be a
        smash hit!
        </span>
      </div>
    </div>
    <!-- <div class="row">
      <v-btn class="btn btn-primary col-3"> LOGIN </v-btn>
      <div class="col-2"></div>
      <v-btn class="btn btn-secondary col-3"> SIGN-UP </v-btn>
    </div> -->
  </div>
</b-container>
</template>

<script>
export default {
  name: 'home-description',
  data() {
    return {
      msg: 'Welcome to Your Vue.js App'
    }
  }
}
</script>

<style>
#main-title {
  font-size: 42px;
  font-weight: bolder;
}

#box {
  font-size: 25px;
  width: 98%;
  margin: 1%;
  padding: 1%;
  background: rgba(122, 122, 122, 0.25);
  box-shadow: 5px 5px 5px rgba(0,0,0,0.5);;
}
</style>