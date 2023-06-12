import { defineStore } from "pinia";

export const useCartStore = defineStore("cart", {
  state: () => ({ allFood: [] }),
  getters: {
    foodInCart: (state) => state.allFood,
  },
  actions: {
    addFoodToCart(data) {
      this.allFood = [...this.allFood, data];
    },
    removeFoodFromCart(id) {
      this.allFood = this.allFood.filter((item) => item.id !== id);
    },
  },
});
