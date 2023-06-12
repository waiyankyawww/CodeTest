<script setup>
import { useCartStore } from "../../stores/cart";

const props = defineProps({
  handleCartDialogToggle: Function,
});

const cart = useCartStore();

const handleRemove = (id) => {
  cart.removeFoodFromCart(id);
};
</script>

<template>
  <div
    class="fixed top-0 left-0 z-20 w-screen h-screen bg-black bg-opacity-50 flex items-center justify-center"
  >
    <div
      class="w-[60vw] h-[70vh] bg-white rounded-lg py-24 px-8 relative overflow-y-auto"
    >
      <!-- modal hidden cross -->
      <div
        class="absolute top-6 right-8 cursor-pointer"
        @click="props.handleCartDialogToggle"
      >
        <img class="w-8 h-8" src="/icons/cross.png" alt="cross" />
      </div>
      <div v-if="cart.allFood.length > 0" class="grid grid-cols-2 gap-5">
        <div
          v-for="food in cart.allFood"
          :key="food.id"
          class="grid grid-cols-12 shadow-sm border border-gray-100 rounded-lg overflow-hidden p-2"
        >
          <!-- <img :src="'/screen3/' + food.images[0]" alt="image" class="w-600" /> -->
          <div class="col-span-4">
            <img
              :src="'/screen3/' + food.images[0]"
              alt="image"
              class="h-28 w-28 object-cover rounded-lg"
            />
          </div>
          <div class="col-span-7 px-3 my-auto">
            <p class="text-[14pt] text-gray-700 font-semibold">
              {{ food.name }}
            </p>
            <p class="text-gray-700">{{ food.type }}</p>
            <p class="text-gray-500">Qty : {{ food.quantity }}</p>
          </div>
          <img
            class="w-8 h-8 my-auto cursor-pointer"
            src="/icons/delete.png"
            alt="cross"
            @click="handleRemove(food.id)"
          />
        </div>
      </div>
      <div v-else class="w-full h-full flex items-center justify-center">
        <p class="text-sm text-grey-dark font-bold">No food in the cart.</p>
      </div>
    </div>
  </div>
</template>
