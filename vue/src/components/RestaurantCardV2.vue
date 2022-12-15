<template>
    <div>
        <div id = "rest-card">
            <div id = "border">
            <b-row id = "name">
                {{currentParty.name}} 
            </b-row>
            <b-row>
                <a h-ref="#">
                    <img id = "rest-image" src="{{}}" alt="Restaurant">
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
                <b-col class = "col-6">
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
    height: 75vh;
    width:95%;
    margin: 2.5%;
    box-shadow: 5px 5px 5px rgba(0,0,0,0.5);
}
</style>