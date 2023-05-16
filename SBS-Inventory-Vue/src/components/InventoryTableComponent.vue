<template>
  <div>
    <DataTable
      v-model:filters="filters"
      :value="inventoryItems"
      paginator
      :rows="10"
      :rowsPerPageOptions="[5, 10, 20, 50]"
      tableStyle="min-width: 50rem"
      @row-click="onRowClick($event.data.sbsID)"
    >
      <template #header>
        <div class="flex justify-content-end">
          <span class="p-input-icon-left">
            <i class="pi pi-search"></i>
            <InputText
              v-model="filters['global'].value"
              placeholder="Search for inventory..."
            />
          </span>
        </div>
      </template>
      <template #empty> No inventory found. </template>
      <template #loading> Loading inventory data. Please wait. </template>

      <Column field="sbsID" header="SBS ID" sortable></Column>
      <Column field="ncrID" header="NCR ID" sortable></Column>
      <Column
        field="productDescription"
        header="Product Description"
        sortable
      ></Column>
      <Column field="locationID" header="Location" sortable></Column>
      <Column field="statusID" header="Status" sortable></Column>
      <Column field="modelID" header="Model ID" sortable></Column>
      <Column field="counts" header="Count" sortable></Column>
      <Column field="advEA" header="Advanced EA" sortable></Column>
      <Column field="discontinued" header="Discontinued" sortable></Column>
    </DataTable>
  </div>
</template>

<script>
import { getProducts } from "@/services/inventory.services.js";
import { FilterMatchMode } from "primevue/api";

export default {
  name: "InventoryTableComponent",
  data: function () {
    return {
      inventoryItems: [],
      addProductDialog: false,
      filters: {
        global: { value: null, matchMode: FilterMatchMode.CONTAINS },
      },
    };
  },
  // TODO need to convert this to a setup when I get a chance
  async created() {
    try {
      const data = await getProducts();
      this.inventoryItems = data;
    } catch (error) {
      console.error(error);
    }

    this.emitter.on("new-inventory-list", (res) => {
      this.inventoryItems = res;
    });
  },
  methods: {
    onRowClick(sbsID) {
      this.$router.push({ name: "productdetail", params: { id: sbsID } });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped></style>
