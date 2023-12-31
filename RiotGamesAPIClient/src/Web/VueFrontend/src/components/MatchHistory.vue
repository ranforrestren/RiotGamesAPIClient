<script setup>
const props = defineProps(['matchList']);

console.log(props.matchList);
</script>

<template>
    <div class="matchList">
        <div class="matchInfo" v-for="match in matchList">
            <img :src="'https://ddragon.leagueoflegends.com/cdn/13.24.1/img/champion/' + match.championName + '.png'">
            <div class="name"> 
                {{ match.championName }}
            </div> |
            <div class="kda">
                {{ match.kills }} / 
                {{ match.deaths }} / 
                {{ match.assists }}
            </div> |
            <div class="dmg">
                damage: {{  match.totalDamageDealtToChampions }}
            </div> |
            <div class="gold">
                gold: {{ match.goldEarned }}
            </div>
        </div>
    </div>
</template>

<style scoped>
    .matchInfo {
        display: flex;
        align-items: center;
        gap: 20px;
        width: 760px;
        margin: auto;
        padding: 10px;
        color: #171717a0;
        border: 1px solid #a3a3a3a0;
        border-radius: 24px;
    }
    .matchList {
        display: flex;
        flex-direction: column;
        gap: 10px;
    }
    .name {
        font-size: 1.5rem;
        text-align: left;
        width: 100px;
    }
    .kda {
        font-size: 1.5rem;
        text-align: left;
        width: 150px;
        color: #737373a0;
    }
    .dmg, .gold {
        color: #737373a0;
    }
    img {
        width: 48px;
        border-radius: 24px;
        box-shadow: 0px 0px 4px #40404040;
    }
</style>