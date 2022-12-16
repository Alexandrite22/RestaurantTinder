<template>
  <div class="home">
    <h1><center>Home</center></h1>
    <p id = "text">
      Here at Me-n-U we aim to revolutionize how groups select restaurants for
      anything from dates to large parties to corporate events! Use our service
      to let everyone decide which restaurant will let your event be a smash
      hit!
    </p>
    <div id = "parody-content">
      <img id = "HWPE" src="../imgs/happy-white-people-eating.jpg">
    </div>
    <!-- <button @click="TestMethod()"></button> -->
  </div>
</template>

<script>
// import YelpService from "../services/YelpService.js";
// export default {
//   methods: {
//     TestMethod() {
//       YelpService.getRestaurants();
//     },
//   },
// };
</script>
<style >
#parody-content
{
  display: flex;
  align-content: center;
  justify-content: center;
}
#text
{
  font-size: large;
  margin: 15px;
  background: rgba(255,255,255,0.5);
  padding: 5px;
  border-radius: 5px;
  box-shadow: 5px 5px 5px rgba(0,0,0,0.5);
}
#HWPE
{
  border-radius: 5px;
  box-shadow: 5px 5px 5px rgba(0,0,0,0.5);
}
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