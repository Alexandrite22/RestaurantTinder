<template>
  <div>
    <div class="border">
      <h6>this will be the restaurant viewing component</h6>
      <current-restaurant />
    </div>
    <div class="border">
      <h6>this will be the restaurant viewing component</h6>  
    </div>
  </div>
</template>

<script>
import CurrentRestaurant from "../components/CurrentRestaurant.vue";
export default {
  name: "restaurant",
  components: {
    CurrentRestaurant,

  },
  data() {
    return {
      restaurant: {
        name: "",
        restaurantID: "",
      },
    };
  },
};
</script>

<style>
</style>