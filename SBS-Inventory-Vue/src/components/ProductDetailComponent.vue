<template>
  <div>
    <Toast></Toast>
    <ConfirmDialog></ConfirmDialog>
    <div class="delete">
      <Button @click="deleteProductConfirm()">Delete Inventory Item</Button>
    </div>
    <div>
      <h1>{{ product.productDescription }}</h1>
    </div>
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
};
</script>
<style scoped>
.delete {
  display: flex;
  justify-content: flex-end;
}
</style>
