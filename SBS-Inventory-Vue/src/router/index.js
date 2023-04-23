import { createRouter, createWebHashHistory } from 'vue-router'
import InventoryView from '../views/InventoryView.vue'
import ProductDetailView from '../views/ProductDetailView.vue'

const routes = [
  {
    path: '/',
    redirect: '/inventory'
  },
  {
    path: '/inventory',
    name: 'inventory',
    component: InventoryView
  },
  {
    path: '/inventory/productdetail/:id',
    name: 'productdetail',
    component: ProductDetailView
  },
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
