<script setup>
import { ref } from 'vue';
    let gameName = null;
    let tagLine = null;

const emits = defineEmits(['search']);

async function getByName(name, tag) {
    const response = await fetch(`https://localhost:7179/api/Players/byName/${name}/${tag}`);
    const player = await response.json();
    emits('search', player);
}
</script>

<template>
    <div class="hflex" method="GET" action="https://localhost:7179/api/Players/byName/">
        <input class="gameName" type="text" placeholder="GAMENAME" v-model="gameName">
        <div class="spacing">#</div>
        <input class="tagLine" type="text" placeholder="TAGLINE" v-model="tagLine">
        <input class="submit" type="submit" @click="getByName(gameName, tagLine)">
    </div>
</template>

<style scoped>
    .hflex {
        display: flex;
        background-color: #d4d4d4;
        border-radius: 100px;
        align-items: center;
        color: #171717a0;
        transition: filter 300ms;
        width: 800px;
        margin: auto;
        margin-bottom: 40px;
    }
    input {
        border: none;
        background-color: transparent;
        border: 1px solid transparent;
        font-size: 1rem;
        padding: 14px;
        color: #171717a0;
        transition: border-color 300ms;
    }
    input:focus {
        outline: none;
    }
    input:hover {
        border-color: #a3a3a3a0;
    }
    .gameName {
        flex-grow: 4;
        border-radius: 100px 0px 0px 100px;
    }
    .tagLine {
        flex-grow: 1;
    }
    .submit {
        flex-grow: 2;
        background-color: #a3a3a360;
        color: #171717a0;
        border-radius: 0px 100px 100px 0px;
    }
    .spacing {
        padding: 10px;
    }
    .hflex:hover {
        filter: drop-shadow(0 0 0.5em #40404040);
    }
</style>