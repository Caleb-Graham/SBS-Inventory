<template>
  <div>
    <Button @click="addProducts()">Add Inventory</Button>
    <Dialog
      v-model:visible="addProductDialog"
      modal
      header="Header"
      :style="{ width: '50vw' }"
    >
      <p>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
        tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim
        veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
        commodo consequat. Duis aute irure dolor in reprehenderit in voluptate
        velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint
        occaecat cupidatat non proident, sunt in culpa qui officia deserunt
        mollit anim id est laborum.
      </p>
    </Dialog>
  </div>
</template>

<script>

export default {
  name: "InventoryComponent",
  data: function () {
    return {
      inventoryItems: [],
      addProductDialog: false,
    };
  },
  methods: {
    addProducts() {
      this.addProductDialog = true;
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
button {
  margin-right: 10px;
}
</style>
