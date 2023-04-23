<template>
      <div>
        <DataTable
          :value="inventoryItems"
          paginator
          :rows="10"
          :rowsPerPageOptions="[5, 10, 20, 50]"
          tableStyle="min-width: 50rem"
        >
          <Column field="sbsID" header="SBS ID" sortable></Column>
          <Column field="ncrID" header="NCR ID" sortable></Column>
          <Column
            field="productDescription"
            header="Product Description"
            sortable
          ></Column>
          <Column field="modelID" header="Model ID" sortable></Column>
          <Column field="price" header="Price" sortable></Column>
          <Column field="cost" header="Cost" sortable></Column>
          <Column field="advEA" header="Advance EA" sortable></Column>
          <Column field="discontinued" header="Discontinued" sortable></Column>
        </DataTable>
      </div>
  </template>
  
  <script>
  import { getProducts } from "@/services/inventory.services.js";
  
  export default {
    name: "InventoryTableComponent",
    data: function () {
      return {
        inventoryItems: [],
        addProductDialog: false,
      };
    },
    async created() {
      try {
        const data = await getProducts();
        this.inventoryItems = data;
      } catch (error) {
        console.error(error);
      }
    },
  };
  </script>
  
  <!-- Add "scoped" attribute to limit CSS to this component only -->
  <style scoped>
  </style>
  