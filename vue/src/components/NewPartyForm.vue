<template>
    <div class="new-party-form">
        <h1>New Party Form</h1>
        <form @submit.prevent="create">
            <input type="text" v-model="partyName" placeholder="Party Name" />
            <input type="text" v-model="partyDescription" placeholder="Party Description" />
            <input type="text" v-model="partyDate" placeholder="Party Date" />
            <input type="text" v-model="partyTime" placeholder="Party Time" />
            <input type="text" v-model="partyLocation" placeholder="Party Location City" />
            <b-button type="submit" variant="btn btn-default">Create</b-button>
        </form>
    </div>
</template>

<script>
export default {
    name: 'new-party-form',
}
</script>

<style>

</style>