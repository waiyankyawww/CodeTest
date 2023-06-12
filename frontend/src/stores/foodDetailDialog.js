import { defineStore } from "pinia";

export const useFoodDetailDialogStore = defineStore("food-detail-dialog", {
  state: () => ({ isOpen: false, data: null }),
  getters: {
    isDialogOpen: (state) => state.isOpen,
    dialogContent: (state) => state.data,
  },
  actions: {
    openDialog(data) {
      this.isOpen = true;
      this.data = data;
    },
    closeDialog() {
      this.isOpen = false;
      this.data = null;
    },
  },
});
