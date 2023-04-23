<template>
  <div>
     <InventoryComponent/>
  <InventoryTableComponent/>
  </div>
</template>

<script>
// @ is an alias to /src
import InventoryComponent from '/src/components/InventoryComponent.vue';
import InventoryTableComponent from '/src/components/InventoryTableComponent.vue';

export default {
  name: 'Inventory',
  components: {
        InventoryComponent,
    InventoryTableComponent
  }
}
</script>
