<template>
  <div>
    <div class="add-inventory">
      <div class="location-row">
        <AddLocationComponent/>
        <DeleteLocationComponent/>
      </div>
      <AddInventoryComponent/>
    </div>
  <InventoryTableComponent/>
  </div>
</template>

<script>
// @ is an alias to /src
import AddInventoryComponent from '/src/components/AddInventoryComponent.vue';
import AddLocationComponent from '/src/components/AddLocationComponent.vue';
import DeleteLocationComponent from '/src/components/DeleteLocationComponent.vue';
import InventoryTableComponent from '/src/components/InventoryTableComponent.vue';

export default {
  name: 'Inventory',
  components: {
    AddInventoryComponent,
    AddLocationComponent,
    DeleteLocationComponent,
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

  .location-row {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    min-width: 300px;
  }
</style>