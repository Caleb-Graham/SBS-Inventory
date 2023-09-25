<template>
  <div>
    <Button @click="addProducts()">Add Inventory</Button>
    <Dialog
      v-model:visible="addProductDialog"
      modal
      header="Add New Inventory Item"
      :style="{ width: '60w' }"
    >
      <div style="display: flex; flex-direction: row; gap: 50px">
        <div class="row-container">
          <div class="input-text">
            <label>SBS ID</label>
            <InputText required v-model="sbsID" type="number"></InputText>
          </div>
          <div class="input-text">
            <label>NCR ID</label>
            <InputText required v-model="ncrID" type="number"></InputText>
          </div>
          <div class="input-text">
            <label>Product Description</label>
            <InputText v-model="productDescription" type="text"></InputText>
          </div>
          <div class="input-text">
            <label>Model ID</label>
            <InputText v-model="modelID" type="number"></InputText>
          </div>
          <div class="input-text">
            <label>Count</label>
            <InputText v-model="counts" type="number"></InputText>
          </div>
          <div class="input-text">
            <label>Source</label>
            <InputText v-model="source" type="text"></InputText>
          </div>
        </div>
        <div class="row-container">
          <div class="input-text">
            <label>Price</label>
            <InputText v-model="price" type="number"></InputText>
          </div>
          <div class="input-text">
            <label>Cost</label>
            <InputText v-model="cost" type="number"></InputText>
          </div>
          <div class="input-text">
            <label>Advanced EA</label>
            <Dropdown
            v-model="advancedEA"
            placeholder="True or False"
            :options="['True', 'False']"
            ></Dropdown>
          </div>
          <div class="input-text">
            <label>Discontinued</label>
            <Dropdown
            v-model="discontinued"
            placeholder="True or False"
            :options="['True', 'False']"
            ></Dropdown>
          </div>
          <div class="input-text">
            <label>Location</label>
            <Dropdown
              v-model="location"
              placeholder="Where is this product"
              :options="locationsArry"
            ></Dropdown>
          </div>
          <div class="input-text">
            <label>Status</label>
            <Dropdown
              v-model="status"
              placeholder="Status"
              :options="['In Warehouse', 'In Vehicle']"
            ></Dropdown>
          </div>
        </div>
      </div>
      <div class="button-row">
        <Button
          @click="closeDialog()"
          label="Cancel"
          icon="pi pi-times"
        ></Button>
        <Button
          @click="saveNewProduct()"
          label="Save"
          icon="pi pi-check"
        ></Button>
      </div>
    </Dialog>
  </div>
</template>

<script>
import { addProduct } from "@/services/inventory.services.js";
import { getProducts } from "@/services/inventory.services.js";
import { getLocations } from "@/services/inventory.services.js";


export default {
  name: "AddInventoryComponent",
  data: function () {
    return {
      newInventoryItem: {},
      newInventoryItems: [],
      locations: [],
      locationsArry: [],
      addProductDialog: false,

      // form values
      sbsID: null,
      ncrID: null,
      productDescription: null,
      modelID: null,
      counts: null,
      price: null,
      cost: null,
      advancedEA: null,
      discontinued: null,
      status: null,
      location: null,
      source: null,
    };
  },
  methods: {
    addProducts() {
      this.addProductDialog = true;
      this.getLocations();
    },
    closeDialog() {
      this.addProductDialog = false;
    },
    setNewInventoryObject() {
      this.newInventoryItem = {
        SbsID: this.sbsID,
        NcrID: this.ncrID,
        ProductDescription: this.productDescription,
        ModelID: this.modelID,
        Counts: this.counts,
        Price: this.price,
        Cost: this.cost,
        AdvEA:
          this.advancedEA != null && this.advancedEA == "True"
            ? true
            : this.advancedEA != null && this.advancedEA == "False"
            ? false
            : this.advancedEA,
        Discontinued:
          this.discontinued != null && this.discontinued == "True"
            ? true
            : this.discontinued != null && this.discontinued == "False"
            ? false
            : this.discontinued,
        StatusID: this.status == "In Warehouse" ? '1' : '2',
        LocationID: this.getLocationID(this.location),
        Source: this.source,
      };
    },
    getLocationID(locationName) {
      var locationID;
        this.locations.forEach((x) => {
          if (locationName == x.locationName)
          {
            locationID = x.locationID.toString();
          }
        });
        return locationID;
    },
    resetInventoryObject() {
      this.sbsID = null;
      this.ncrID = null;
      this.productDescription = null;
      this.modelID = null;
      this.counts = null;
      this.price = null;
      this.cost = null;
      this.advancedEA = null;
      this.discontinued = null;
      this.location = null;
      this.source = null;
    },
    saveNewProduct() {
      this.setNewInventoryObject();
      for (const key in this.newInventoryItem) {
        if (this.newInventoryItem[key] == null) {
          return;
        }
      }

      addProduct(this.newInventoryItem)
        .then(async () => {
          this.addProductDialog = false;
          this.resetInventoryObject();
          const data = await getProducts();
          this.newInventoryItems = data;
          this.emitter.emit("new-inventory-list", this.newInventoryItems);
        })
        .catch((error) => {
          console.error(error.message);
        });
    },
    async getLocations() {
      this.locations = [];
      try {
        const data = await getLocations();
        data.forEach(x => {
          this.locations.push(x);
          this.locationsArry.push(x.locationName);
        });
      }
     catch (error) {
      console.error(error);
    }
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.row-container {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  gap: 40px;
}
.input-text {
  display: flex;
  flex-direction: column;
  gap: 10px;
  width: 100%;
  max-width: 199px;
}

.button-row {
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
  gap: 15px;
  margin-top: 35px;
}
</style>
