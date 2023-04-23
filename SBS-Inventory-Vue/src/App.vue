<template>
  <InventoryComponent/>
  <InventoryTableComponent/>
</template>

<script>
import InventoryComponent from './components/InventoryComponent.vue';
import InventoryTableComponent from './components/InventoryTableComponent.vue';


export default {
  name: 'App',
  components: {
    InventoryComponent,
    InventoryTableComponent
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
