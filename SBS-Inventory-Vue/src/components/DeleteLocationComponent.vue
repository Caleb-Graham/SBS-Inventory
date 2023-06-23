<template>
    <div>
      <Button @click="deleteLocation()">Delete Location</Button>
      <Dialog
      v-model:visible="deleteLocationDialog"
      modal
      header="Delete Location"
      :style="{ width: '60w' }"
    >
      <div style="display: flex; flex-direction: row; gap: 50px">
        <div class="input-text">
            <label>Location</label>
            <Dropdown
              v-model="location"
              placeholder="What location do you want to delete?"
              :options="['Springfield', 'Ash Grove']"
            ></Dropdown>
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
    name: "DeleteLocationComponent",
    data: function () {
      return {
        deleteLocationDialog: false,
      };
    },
    methods: {
      deleteLocation() {
        this.deleteLocationDialog = true;
      },
      closeDialog() {
      this.deleteLocationDialog = false;
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
  