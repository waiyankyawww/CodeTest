<script setup>
import { ref } from "vue";
import { useCartStore } from "../../stores/cart";
import SearchField from "../molecules/SearchField.vue";
import CartDialog from "./CartDialog.vue";

const cart = useCartStore();

const isCartDialogOpen = ref(false);

const handleCartDialogToggle = () => {
  isCartDialogOpen.value = !isCartDialogOpen.value;
};
</script>

<template>
  <div
    class="fixed mt-0 z-10 w-screen h-[12vh] bg-white border px-10 flex items-center justify-between bg-white"
  >
    <div class="flex items-center gap-10">
      <img
        class="w-56 h-auto"
        src="/screen1/FarmFresh Logo.png"
        alt="brand-logo"
      />
      <SearchField />
    </div>
    <div class="relative cursor-pointer" @click="handleCartDialogToggle">
      <img
        class="w-10 h-10"
        src="/screen1/shopping-cart.png"
        alt="shopping-cart"
      />
      <div
        class="absolute -top-2 -right-2 bg-red rounded-full w-7 h-7 flex items-center justify-center"
      >
        <p class="text-xs text-white">{{ cart.allFood.length }}</p>
      </div>
    </div>
  </div>
  <CartDialog
    v-if="isCartDialogOpen"
    :handleCartDialogToggle="handleCartDialogToggle"
  />
</template>
