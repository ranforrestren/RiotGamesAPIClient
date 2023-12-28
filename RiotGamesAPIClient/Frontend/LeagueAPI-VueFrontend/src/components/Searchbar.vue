<script setup>
import { ref } from 'vue';

defineProps({
    gameName: String,
    tagLine: String,
});
</script>

<template>
    <form class="hflex" method="GET" action="https://localhost:7179/api/Players/byName/">
        <input class="gameName" type="text" placeholder="LAGAVULIN">
        #<input class="tagLine" type="text" placeholder="10SIX">
        <input class="submit" type="submit">
    </form>
</template>

<style scoped>
    .hflex {
        display: flex;
        background-color: #d4d4d4;
        border-radius: 100px;
        align-items: center;
        color: #171717a0;
    }
    input {
        border: none;
        background-color: transparent;
        font-size: 1rem;
        padding: 14px;
        color: #171717a0;
    }
    .gameName {
        flex-grow: 4;
    }
    .tagLine {
        flex-grow: 1;
    }
    .submit {
        flex-grow: 2;
        background-color: #a3a3a360;
        border-radius: 0px 100px 100px 0px;
    }
</style>