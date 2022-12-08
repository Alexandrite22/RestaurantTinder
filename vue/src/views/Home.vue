<template>
  <div class="home">
    <b-container>
      <b-row >
        <b-col id="menuColumn"  cols="1">
          <menu-column id="menu"/>
        </b-col>
        <b-col id="homeColumn" cols="10">
          <main-column />
        </b-col>
        <b-col id="detailsColumn" cols="1">
          <details-column id="details" />
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import MainColumn from "../components/MainColumn.vue";
import DetailsColumn from "../components/DetailsColumn.vue";
import MenuColumn from "../components/MenuColumn.vue";



export default {
  name: "home",
  components: {
    MainColumn,
    DetailsColumn,
    MenuColumn
    }
};
</script>
<style >
.menuColumn {
    border: 1px solid black;

    background-color: yellow;
}
.mainColumn {
    border: 1px solid black;

    background-color: aqua;
}
.detailsColumn {
  border: 1px solid black;
    background-color: pink;
}
</style>