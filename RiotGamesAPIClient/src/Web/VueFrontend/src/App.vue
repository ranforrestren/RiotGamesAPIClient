<script setup>
import Searchbar from './components/Searchbar.vue';
import PlayerInfo from './components/PlayerInfo.vue';
import MatchHistory from './components/MatchHistory.vue';
import { ref } from 'vue';

const player = ref(null);
const matchList = ref(null);
</script>

<template>
  <div class="vflex">
    <div class="imgborder">
    <img src="./assets/Syndra_6.jpg">
    </div>
    <Searchbar @search="(p) => player = p"/>
    <PlayerInfo @search="(m) => matchList = m" :player="player" v-if="player != null"/>
    <MatchHistory :matchList="matchList" v-if="matchList != null">
    </MatchHistory>
  </div>
</template>

<style scoped>
  .vflex {
    display: flex;
    flex-direction: column;
    gap: 40px;
  }
  .imgborder {
    width: 760px;
    padding: 20px;
    border: 1px solid #a3a3a3a0;
    border-radius: 24px;
  }
  img {
    width: 100%;
    height: 100%;
    object-fit: cover;
    border-radius: 24px;
  }
</style>
