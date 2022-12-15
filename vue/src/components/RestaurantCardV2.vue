<template>
    <div>
        <div id = "rest-card" v-bind:key="restaurant.restaurantId" v-for="restaurant in currentParty.restaurants">
            <div id = "border">
            <b-row id = "name">
                {{restaurant.name}} 
            </b-row>
            <b-row>
                <a v-bind:href = "restaurant.yelpLink">
                    <img v-bind:src = "restaurant.imageLink" id = "rest-image" alt="Restaurant">
                </a>
            </b-row>
            <b-row id="status" class="closed">
                CLOSED
            </b-row>
            <b-row>
                <b-col class = "col-12">
                    <div class = "display-col">
                        <ul>
                            <li>ADDRESS: {{restaurant.address1}}</li>
                        </ul>
                    </div>    
                </b-col>
            </b-row>
            <b-row>
                <b-col id="up-parent" class = "col-6"><div id = "thumb-down"><b-icon-hand-thumbs-down-fill id="thumb-down-icon"/></div></b-col>
                <b-col id="down-parent" class = "col-6"><div id = "thumb-up"><b-icon-hand-thumbs-up-fill id="thumb-up-icon"/></div></b-col>
            </b-row>
        </div>
    </div>
</div>
</template>

<script>
export default {
    name: "restaurant-card-v2",
    data()
    {
        return{
        parties:[],
        currentParty:{},
    }},
    created(){
        this.getParties();
    },
    methods:{
        getParties()
            {
                let partyId = this.$route.params.partyId;
                this.parties=this.$store.state.currentParties;
                this.currentParty=this.parties.find(party => {return party.partyId==partyId});
            }
    }
};
</script>

<style>
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
    max-height: 20vh;
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
    height: 85vh;
    box-shadow: 5px 5px 5px rgba(0,0,0,0.5);
}
.display-col
{
    background: rgba(255,255,255,0.5);
    border-radius: 5px;
    height: 5vh;
    width:95%;
    margin: 2.5%;
    box-shadow: 5px 5px 5px rgba(0,0,0,0.5);
}
#thumb-down
{
    background: crimson;
    border-radius: 50%;
    padding: 10px;
    height: 7vh;
    width: 7vh;
    margin: 5%;
    box-shadow: 5px 5px 5px rgba(0,0,0,0.5);
}
#thumb-down-icon
{
    height: 5vh;
    width: 5vh;
}
#thumb-up
{
    background: rgb(105,145,255);
    border-radius: 50%;
    padding: 10px;
    height: 7vh;
    width: 7vh;
    margin: 5%;
    box-shadow: 5px 5px 5px rgba(0,0,0,0.5);

}
#thumb-up-icon
{
    height: 5vh;
    width: 5vh;
}
</style>