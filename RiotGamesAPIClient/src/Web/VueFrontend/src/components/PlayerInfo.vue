<script setup>
const props = defineProps(['player']);

const emits = defineEmits(['search']);

async function getByPuuid(puuid) {
    const response = await fetch(`https://localhost:7179/api/matches/bypuuid/${puuid}`);
    const matchList = await response.json();
    emits('search', matchList);
}
</script>

<template>
    <div class="playerInfo">
        <img :src="'https://ddragon.leagueoflegends.com/cdn/13.24.1/img/profileicon/' + player.playerProfileIconId + '.png'"
        @click="getByPuuid(player.playerRiotUUID)">
        <div class="vflex">
            <div class="name">
                {{ player.playerRiotName }} <span class="tag"># {{ player.playerRiotTagline }}</span>
            </div>
            <div class="level">
                Level: {{  player.playerSummonerLevel }}
            </div>
    </div>
    </div>
</template>

<style scoped>
    .playerInfo {
        display: flex;
        align-items: center;
        gap: 40px;
        width: 760px;
        margin: auto;
        padding: 20px;
        color: #171717a0;
        border: 1px solid #a3a3a3a0;
        border-radius: 24px;
    }
    .vflex {
        display: flex;
        flex-direction: column;
        align-items: start;
    }
    .name {
        font-size: 2rem;
    }
    .tag {
        color: #737373a0;
    }
    .level {
        color: #737373a0;
        font-size: 1.5rem;
    }
    img {
        width: 100px;
        border-radius: 50px;
        box-shadow: 0px 0px 4px #40404040;
    }
</style>