<template>
  <div>
    <div class="border">
      <h6>this will be the restaurant viewing component FOR THE GUESTS</h6>
      <current-restaurant />
    </div>
    <div class="border">
      <h6>this will be the restaurant VOTING component</h6>  
    </div>
  </div>
</template>

<script>
export default {
    name: 'Home',
    components: {
        'current-restaurant': () => import('@/components/CurrentRestaurant') // The @ is an alias to /src. This is a lazy load.
    } // This is a lazy load. It will only load the component when it is needed.

}
</script>

<style>

</style>