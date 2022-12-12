<template>
  <div class="home">
    <h1><center>Home</center></h1>
    <description />
    <p>
      Create a new party, view your current parties, and view your party details
      in the left menu.
    </p>
  </div>
</template>

<script>
import Description from "../components/SiteDescription.vue";
export default {
  name: "home",
  components: {
    Description,
  },
};
</script>
<style >
/* .menuColumn {
    border: 1px solid black;
    border-ra
} */
/* .mainColumn {

}
.detailsColumn {
  border: 1px solid black;
    background-color: pink;
} */
</style>