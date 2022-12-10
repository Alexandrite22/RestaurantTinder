<template>
    <div class="border">
        <h1>Menu Column</h1>
        <h4><router-link to="/">Home</router-link></h4>
        <h4><router-link to="/dashboard">dashboard</router-link></h4>
        <h4><a href="http://localhost:8080/newParty">Create a new event</a></h4>
        <br/>
        <br/>
        <h4><a href="http://localhost:8080/dashboard">My current plans</a></h4>
        <ul>
            <li><a href="#">Kevins pizza party</a></li>
            <li><a href="#">Kevins celabratory hiring party</a></li>
            <li><a href="#">Colin's birthday bash</a></li>
            <li><a href="#">Nick's birthday</a></li>
            <li><a href="#">Alex's birthday Party</a></li>
            <li><a href="#">Tax day</a></li>
            <li><a href="#">Peri's birthday</a></li>
            <li><a href="#">Kevins pizza party</a></li>
        </ul>
        <span id="username">
        </span>    
        <ul>
            <li>
                Userette Nameabelle
            </li>
            <li>
                <router-link to = "/home">Home</router-link>
            </li>
            <li>
                <router-link to = "/newParty">Create Party</router-link>
            </li>
            <li>
                <router-link to = "/dashboard">View Parties</router-link>
            </li>
            <li>
            
            </li>
        </ul>    
    </div>
</template>

<script>
export default {
 name: 'MenuColumn',    
    data() {
        return {};
    },
    created() {
        console.log("MenuColumn created");
    },
}
</script>

<style>
.border
{
    color:black;
    opacity: 100%;
}
</style>