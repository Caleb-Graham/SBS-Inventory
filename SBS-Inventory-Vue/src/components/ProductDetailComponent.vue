<template>
  <div>
    <Toast></Toast>
    <ConfirmDialog></ConfirmDialog>
    <div class="delete">
      <h2 v-ripple class="p-ripple" @click="routeToInventory()">&lt; Back</h2>
      <Button style="height: fit-content" @click="deleteProductConfirm()"
        >Delete Inventory Item</Button
      >
    </div>
    <Card class="card">
      <template #header>
        <div class="header-row">
          <i @click="toggleEditingProduct()" class="pi pi-pencil edit-icon"></i>
        </div>
      </template>
      <template #title> {{ product.productDescription }} </template>
      <template #content>
        <div class="prod-details-container">
          <div class="product-details-div">
            <div class="prod-details-row">
              <p class="p-font-weight">SBS ID: &nbsp;</p>
              <p v-if="!editingProduct">{{ product.sbsID }}</p>
              <InputText
                v-if="editingProduct"
                v-model="product.sbsID"
                required
                type="number"
              ></InputText>
            </div>

            <div class="prod-details-row">
              <p class="p-font-weight">NCR ID: &nbsp;</p>
              <p v-if="!editingProduct">{{ product.ncrID }}</p>
              <InputText
                v-if="editingProduct"
                v-model="product.ncrID"
                required
                type="number"
              ></InputText>
            </div>

            <div class="prod-details-row">
              <p class="p-font-weight">Description: &nbsp;</p>
              <p v-if="!editingProduct">{{ product.productDescription }}</p>
              <InputText
                v-if="editingProduct"
                v-model="product.productDescription"
                required
                type="text"
              ></InputText>
            </div>

            <div class="prod-details-row">
              <p class="p-font-weight">Location: &nbsp;</p>
              <p v-if="!editingProduct">{{ product.locationName }}</p>
              <Dropdown
                v-if="editingProduct"
                v-model="product.locationName"
                placeholder="Where is this product"
                :options="['Springfield', 'Ash Grove']"
              ></Dropdown>
            </div>

            <div class="prod-details-row">
              <p class="p-font-weight">Status: &nbsp;</p>
              <p v-if="!editingProduct">{{ product.statusName }}</p>
              <Dropdown
                v-if="editingProduct"
                v-model="product.statusName"
                placeholder="Status"
                :options="['In Warehouse', 'In Vehicle']"
              ></Dropdown>
            </div>

            <div class="prod-details-row">
              <p class="p-font-weight">Source: &nbsp;</p>
              <p v-if="!editingProduct">{{ product.source }}</p>
              <InputText
                v-if="editingProduct"
                v-model="product.source"
                required
                type="text"
              ></InputText>
            </div>
          </div>

          <div class="prod-details-div">
            <div class="prod-details-row">
              <p class="p-font-weight">Model ID: &nbsp;</p>
              <p v-if="!editingProduct">{{ product.modelID }}</p>
              <InputText
                v-if="editingProduct"
                v-model="product.modelID"
                required
                type="number"
              ></InputText>
            </div>

            <div class="prod-details-row">
              <p class="p-font-weight">Count: &nbsp;</p>
              <p v-if="!editingProduct">{{ product.counts }}</p>
              <InputText
                v-if="editingProduct"
                v-model="product.counts"
                required
                type="number"
              ></InputText>
            </div>

            <div class="prod-details-row">
              <p class="p-font-weight">Price: &nbsp;</p>
              <p v-if="!editingProduct">{{ product.price }}</p>
              <InputText
                v-if="editingProduct"
                v-model="product.price"
                required
                type="number"
              ></InputText>
            </div>

            <div class="prod-details-row">
              <p class="p-font-weight">Cost: &nbsp;</p>
              <p v-if="!editingProduct">{{ product.cost }}</p>
              <InputText
                v-if="editingProduct"
                v-model="product.cost"
                required
                type="number"
              ></InputText>
            </div>

            <div class="prod-details-row">
              <p class="p-font-weight">Advanced Ea: &nbsp;</p>
              <p v-if="!editingProduct">{{ product.advEA }}</p>
              <Dropdown
                v-if="editingProduct"
                v-model="product.advEA"
                placeholder="True or False"
                :options="['True', 'False']"
              ></Dropdown>
            </div>

            <div class="prod-details-row">
              <p class="p-font-weight">Discontinued: &nbsp;</p>
              <p v-if="!editingProduct">{{ product.discontinued }}</p>
              <Dropdown
                v-if="editingProduct"
                v-model="product.discontinued"
                placeholder="True or False"
                :options="['True', 'False']"
              ></Dropdown>
            </div>
          </div>
        </div>
      </template>
      <template #footer>
        <div v-if="editingProduct">
          <Button style="margin-right: 10px" @click="toggleEditingProduct()"
            >Cancel</Button
          >
          <Button @click="updateProduct()">Save</Button>
        </div>
      </template>
    </Card>
  </div>
</template>
<script>
import {
  getProductById,
  deleteProductById,
  updateProduct,
} from "@/services/inventory.services.js";
import { useConfirm } from "primevue/useconfirm";
import { useToast } from "primevue/usetoast";
import { onMounted, ref } from "vue";
import { useRoute, useRouter } from "vue-router";

export default {
  name: "ProductDetailComponent",
  data: function () {
    return {
      editingProduct: false,
    };
  },
  setup() {
    const confirm = useConfirm();
    const toast = useToast();
    const route = useRoute();
    const router = useRouter();
    const product = ref({});

    const deleteProductConfirm = () => {
      confirm.require({
        message: "Are you sure you want to proceed?",
        header: "Confirmation",
        icon: "pi pi-exclamation-triangle",
        accept: async () => {
          try {
            await deleteProductById(route.params.id);
          } catch (error) {
            console.error(error);
          }

          // TODO figure out how to show toast in a different component
          toast.add({
            severity: "info",
            summary: "Confirmed",
            detail: "You have accepted",
            life: 3000,
          });

          router.push("/inventory");
        },
      });
    };

    onMounted(async () => {
      try {
        const data = await getProductById(route.params.id);
        product.value = data;
      } catch (error) {
        console.error(error);
      }
    });

    return {
      deleteProductConfirm,
      product,
    };
  },
  mounted() {
    this.$primevue.config.ripple = true;
  },
  methods: {
    routeToInventory() {
      this.$router.push("/inventory");
    },
    toggleEditingProduct() {
      this.editingProduct = !this.editingProduct;
    },
    async getProductByIdTest() {
      try {
        const data = await getProductById(this.route.params.id);
        console.log('data', data)
        this.product = data;
      } catch (error) {
        console.error(error);
      }
    },
    async updateProduct() {
      console.log('product', this.product)
      await updateProduct(this.product);
      await getProductById(this.route.params.id);
    },
  },
};
</script>
<style scoped>
.delete {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.card {
  margin-top: 25px;
  margin-left: 50px;
  margin-right: 50px;
  background-color: lightgray;
}

.product-details-div {
  display: flex;
  flex-direction: column;
  /* align-items: flex-start; */
}

.p-font-weight {
  font-weight: 500;
}

.prod-details-row {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.prod-details-container {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
}

h2 {
  cursor: pointer;
}

.header-row {
  display: flex;
  justify-content: flex-end;
}

.edit-icon {
  font-size: 1.3rem;
  margin-right: 10px;
  margin-top: 10px;
  cursor: pointer;
}

.cancel-button {
  margin-right: 10px;
}
</style>
