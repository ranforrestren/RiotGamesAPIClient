<script setup>
import HelloWorld from './components/HelloWorld.vue';
import Searchbar from './components/Searchbar.vue';
import PlayerInfo from './components/PlayerInfo.vue';
import { ref } from 'vue';

const player = ref(null);
</script>

<template>
  <Searchbar @search="(p) => player = p"/>
  <PlayerInfo :player="player" v-if="player != null"/>
</template>

<style scoped>
</style>
