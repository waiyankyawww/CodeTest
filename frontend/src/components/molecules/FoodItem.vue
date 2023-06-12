<script setup>
import { useFoodDetailDialogStore } from "../../stores/foodDetailDialog";
const foodDetailDialog = useFoodDetailDialogStore();

const props = defineProps({
  food: Object,
});
</script>

<template>
  <div @click.prevent="foodDetailDialog.openDialog(food)">
    <div class="h-72 w-72 bg-white rounded-3xl">
      <img
        class="w-full h-full rounded-3xl object-cover cursor-pointer hover:shadow-card"
        :src="'/screen3/' + food.images[0]"
        alt=""
      />
    </div>

    <p class="mt-2 text-base font-bold text-grey-dark">{{ food.name }}</p>
    <p class="text-base font-bold text-grey">{{ food.type }}</p>
  </div>
</template>
