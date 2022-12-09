<template>
    <div class="border">
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