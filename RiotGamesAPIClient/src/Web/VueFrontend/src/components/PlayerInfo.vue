<script setup>
const props = defineProps(['player'])
</script>

<template>
    <div class="playerInfo">
        {{ player }}
    </div>
</template>

<style scoped>
    .playerInfo {
        display: flex;
        width: 760px;
        margin: auto;
        padding: 20px;
        color: #171717a0;
        border: 1px solid #a3a3a3a0;
        border-radius: 24px;
    }
</style>