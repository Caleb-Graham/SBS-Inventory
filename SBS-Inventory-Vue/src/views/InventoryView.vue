<template>
  <div>
    <div class="add-inventory">
      <Button>Add Location placeholder</Button>
      <AddInventoryComponent/>
    </div>
  <InventoryTableComponent/>
  </div>
</template>

<script>
// @ is an alias to /src
import AddInventoryComponent from '/src/components/AddInventoryComponent.vue';
import InventoryTableComponent from '/src/components/InventoryTableComponent.vue';

export default {
  name: 'Inventory',
  components: {
    AddInventoryComponent,
    InventoryTableComponent
  }
}
</script>

<style scoped>
  .add-inventory {
    display: flex;
    justify-content: space-between;
    margin-bottom: 25px;
  }
</style>