<template>
    <div>
        <h1>Party Details</h1>
        <div class="row">
            <div class="col-4">
                <h3>Party Details</h3>
                <h6>Name: {{party.Name}}</h6>
                <h6>Date: {{party.Date}}</h6>
                <h6>Time: {{party.Time}}</h6>
                <h6>Description: {{party.Description}}</h6>   
                <h6>Host: {{party.Owner}}</h6>
                <h6>Attendees: </h6>
                <ol>
                    <li v-for="guest in party.PartyRsvp" :key="guest.guest_Id">
                        {{guest.name}}
                    </li>
                </ol>
                <h6>Restaurants: </h6>
                <ol>
                    <li v-for="restaurant in party.Restaurants" :key="restaurant.restaurant_Id">
                        {{restaurant.api_address}}
                        <img :src="restaurant.api_image" alt="restaurant image">
                        <h3>Restaurant Details</h3>
                        <h6>Name: {{restaurant.Name}}</h6>
                        <h6>Address: {{restaurant.Address}}</h6>
                        <h6>Phone: {{restaurant.Phone}}</h6>
                        <h6>Website: {{restaurant.Website}}</h6>
                        <h6>Rating: {{restaurant.Rating}}</h6>
                        <h6>Price: {{restaurant.Price}}</h6>
                        <h6>Hours: {{restaurant.Hours}}</h6>
                        <h6>Menu: {{restaurant.Menu}}</h6>

                    </li>
                </ol>
            </div>
            <div class="col-4">
                <h3>Restaurant Details</h3>
                <h6>Name: {{restaurant.Name}}</h6>
                <h6>Address: {{restaurant.Address}}</h6>
                <h6>Phone: {{restaurant.Phone}}</h6>
                <h6>Website: {{restaurant.Website}}</h6>
                <h6>Rating: {{restaurant.Rating}}</h6>
                <h6>Price: {{restaurant.Price}}</h6>
                <h6>Hours: {{restaurant.Hours}}</h6>
                <h6>Menu: {{restaurant.Menu}}</h6>
            </div>
        </div>  
        <div class="row">
            <h1>Name: {{party.Name}}</h1>
            <h2>ID: {{party.Id}}</h2>
            <h3>Date: {{party.Date}}</h3>
            <h4>Time: {{party.Time}}</h4>
            <h5>Location: {{party.Location}}</h5>
            <h6>Description: {{party.Description}}</h6>   
            <h6>Host: {{party.Owner}}</h6>
            <h6>Attendees: </h6>
            <ol>
                <li v-for="guest in party.PartyRsvp" :key="guest.guest_Id">
                    {{guest.name}}
                </li>
            </ol>
            <h6>Restaurants: </h6>
            <ol>
                <li v-for="restaurant in party.Restaurants" :key="restaurant.restaurant_Id">
                    {{restaurant.api_address}}
                </li>
            </ol>
        </div>
    </div>
</template>

<script>

export default {
    name: 'general-party-details',
    data() {
    },
}
</script>

<style>

</style>