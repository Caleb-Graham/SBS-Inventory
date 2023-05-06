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
        <div class="product-details-div">
          <div class="prod-details-row">
            <p class="p-font-weight">Items in Inventory: &nbsp;</p>
            <p v-if="!editingProduct">{{ product.counts }}</p>
            <InputText v-if="editingProduct" required type="number"></InputText>
          </div>

          <div class="prod-details-row">
            <p class="p-font-weight">Price: &nbsp;</p>
            <p>{{ product.price }}</p>
          </div>

          <div class="prod-details-row">
            <p class="p-font-weight">Cost: &nbsp;</p>
            <p>{{ product.cost }}</p>
          </div>
        </div>
      </template>
      <template #footer>
        <div v-if="editingProduct">
          <Button style="margin-right: 10px" @click="toggleEditingProduct()">Cancel</Button>
        <Button >Save</Button>
        </div>
      </template>
    </Card>
  </div>
</template>
<script>
import {
  getProductById,
  deleteProductById,
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
  align-items: flex-start;
}

.p-font-weight {
  font-weight: 500;
}

.prod-details-row {
  display: flex;
  flex-direction: row;
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
