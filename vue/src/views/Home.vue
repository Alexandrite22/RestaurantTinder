<template>
  <div class="home">
    <h1>Home</h1>
    <p>
      Welcome to the home page. This is where you can create a new party, view your current parties, and view your party details.
    </p>
    <description />
  </div>
</template>

<script>
import Description from "../components/Description.vue";
export default {
  name: "home",
  components: {
    Description
    }
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