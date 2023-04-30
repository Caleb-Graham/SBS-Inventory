<template>
  <div>
    <Toast></Toast>
    <ConfirmDialog></ConfirmDialog>
    <div class="delete">
      <h2 v-ripple class="p-ripple" @click="routeToInventory()">&lt; Back</h2>
      <Button @click="deleteProductConfirm()">Delete Inventory Item</Button>
    </div>
      <Card class="card">
        <template #title> {{ product.productDescription }} </template>
        <template #content>
          <div class="product-details-div">
            <div class="prod-details-row">
              <p class="p-font-weight">Items in Inventory: &nbsp;</p>
              <p>{{ product.counts }}</p>
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
  }
}
};
</script>
<style scoped>
.delete {
  display: flex;
  justify-content: space-between;
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

h1 {
  cursor: pointer;
}

</style>
