<template>
    <div>
       <ProductDetailComponent/>
    </div>
  </template>
  
  <script>
  // @ is an alias to /src
  import ProductDetailComponent from '/src/components/ProductDetailComponent.vue';
  
  export default {
    name: 'ProductDetailView',
    components: {
        ProductDetailComponent,
    }
  }
  </script>
  