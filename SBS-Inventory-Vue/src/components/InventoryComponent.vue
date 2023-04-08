<template>
  <div>
    <button @click="loadInventory">Load Inventory</button>
    <ul v-if="inventoryItems.length">
      <li v-for="(item, index) in inventoryItems" :key="index">
        {{ item.inventoryItemName }} - {{ item.count }} - {{ item.price }}
      </li>
    </ul>
  </div>
</template>



<script>
import { getInventory } from "@/services/inventory.services.js";

export default {
  data() {
    return {
      inventoryItems: [],
    };
  }, 
  methods: {
    loadInventory() {
      getInventory().then((data) => {
        console.log('data', data)
        this.inventoryItems = data;
      });
    },
  },
};
</script>



<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
