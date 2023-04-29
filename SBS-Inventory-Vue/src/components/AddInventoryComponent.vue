<template>
  <div>
    <Button @click="addProducts()">Add Inventory</Button>
    <Dialog
      v-model:visible="addProductDialog"
      modal
      header="Add New Inventory Item"
      :style="{ width: '75vw' }"
    >
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
      </div>
      <div class="row-container row-divider">
        <div class="input-text">
          <label>Model ID</label>
          <InputText v-model="modelID" type="number"></InputText>
        </div>
        <div class="input-text">
          <label>Count</label>
          <InputText v-model="counts" type="number"></InputText>
        </div>
        <div class="input-text">
          <label>Price</label>
          <InputText v-model="price" type="number"></InputText>
        </div>
      </div>
      <div class="row-container row-divider">
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
      </div>
      <div class="button-row row-divider">
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

export default {
  name: "AddInventoryComponent",
  data: function () {
    return {
      newInventoryItem: {},
      newInventoryItems: [],
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
      source: "idk",
    };
  },
  methods: {
    addProducts() {
      this.addProductDialog = true;
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
        Source: this.source,
      };
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
      this.source = "idk";
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
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.row-container {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  gap: 50px;
}
.input-text {
  display: flex;
  flex-direction: column;
  gap: 10px;
  width: 100%;
}

.row-divider {
  margin-top: 25px;
}

.button-row {
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
  gap: 15px;
}
</style>
