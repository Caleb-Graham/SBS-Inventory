<template>
    <div>
      <Button @click="addLocation()">Add Location</Button>
      <Dialog
      v-model:visible="addLocationDialog"
      modal
      header="Add New Location"
      :style="{ width: '60w' }"
    >
      <div style="display: flex; flex-direction: row; gap: 50px">
        <div class="input-text">
            <label>Location</label>
            <InputText required v-model="locationName" type="text"></InputText>
          </div>
      </div>
      <div class="button-row">
        <Button
          @click="closeDialog()"
          label="Cancel"
          icon="pi pi-times"
        ></Button>
        <Button
          label="Save"
          icon="pi pi-check"
        ></Button>
      </div>
    </Dialog>
    </div>
  </template>
  
  <script>
  
  export default {
    name: "AddLocationComponent",
    data: function () {
      return {
        addLocationDialog: false,
        locationName: '',
      };
    },
    methods: {
      addLocation() {
        this.addLocationDialog = true;
      },
      closeDialog() {
      this.addProductDialog = false;
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
  