<template>
<<<<<<< HEAD
    <div id = "rest-card">
        <div id = "border">
            <b-row id = "name">
                Galucci's 
            </b-row>
            <b-row>
                <a h-ref="#">
                    <img id = "rest-image" src="../imgs/Bg_1.jpg" alt="Restaurant">
                </a>
            </b-row>
            <b-row id="status" class="closed">
                CLOSED
            </b-row>
            <b-row>
                <b-col class = "col-6">
                    <div class = "display-col">
                        <ul>
                            <li>Italian</li>
                            <li>Fast</li>
                            <li>Economic</li>
                        </ul>
                    </div>    
                </b-col>
                <b-col class = "col-6 display-col">
                    <div class = "display-col">
                        <ul>
                            <li>Italian</li>
                            <li>Fast</li>
                            <li>Economic</li>
                        </ul>
                    </div>
                </b-col>
            </b-row>
        </div>
    </div>
=======
  <div id="rest-card">
    <b-row id="name"> Galucci's </b-row>
    <b-row id="rest-image">
      <img src="" alt="Restaurant{{RestaurantName}}" /><!--V-if img exists -->
    </b-row>
    <b-row id="link">
      <a h-ref="#">Check us out on Yelp!</a>
    </b-row>
    <b-row>
      <b-col class="col-6">
        <ul>
          <li>Italian</li>
          <li>Fast</li>
          <li>Economic</li>
        </ul>
      </b-col>
      <b-col class="col-6">
        <b-row> </b-row>
      </b-col>
    </b-row>
  </div>
>>>>>>> 9896bd7b89e03db80e02c1403a4dfedc6fd1cbba
</template>

<script>
export default {};
</script>

<style>
<<<<<<< HEAD
#name
{
    font-size: 35px;
    font-weight: bolder;
    align-content: center;
    justify-content: center;
}
#rest-image
{
    display: block;
    max-height: 30vh;
    border-radius: 5px;
    margin: auto;
    object-fit: cover;
}
#status
{
    font-size: 35px;
    font-weight: bolder;
    align-content: center;
    justify-content: center;
}
.open
{
    color: rgba(39, 245, 76, 1);
}
.closed
{
    color: rgba(255, 29, 83, 1);
}
#rest-card
{
    padding: 15px;
}
#border
{
    background: rgba(255,255,255,0.5);
    border-radius: 5px;
    height: 91vh;
    box-shadow: 5px 5px 5px rgba(0,0,0,0.5);
}
.display-col
{
    background: rgba(255,255,255,0.5);
    border-radius: 5px;
    height: 91vh;
    box-shadow: 5px 5px 5px rgba(0,0,0,0.5);
}
=======
>>>>>>> 9896bd7b89e03db80e02c1403a4dfedc6fd1cbba
</style>