<template>
  <div>
    <div class="border">
      <h6>this Could be the restaurant viewing component</h6>
        <div class="border">
            <h6>this Could be the restaurant Image</h6>  
        </div>
        <div class="border">
            <h6>this Could be the restaurant Details</h6>  
        </div>
        <ul class="border" style="padding: 0.5em;">
            <h6>this Could be the Menu</h6>
            <li class="border row">
                <h6  class="col-3">Food's name</h6>
                <div class="border col-6">
                    <p>this Could be the restaurant Menu Item Details</p>
                </div>
                <div class="border col-1">
                    <p><i>$ Price</i></p>
                </div>
            </li>
        </ul>

    </div>
</div>
</template>

<script>
import partyService from '../services/PartyService.js';

export default {
  name: 'current-restaurant',
  data() {
    return {
      restaurant: {}
    };
  },
  created() {
    this.getParty();
  },
  methods: {
    getRestarant() {
      partyService.getRestaurant
  }
  }
}
</script>

<style>

</style>