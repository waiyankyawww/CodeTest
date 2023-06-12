<script setup>
import { ref } from "vue";
import { useFoodDetailDialogStore } from "../../stores/foodDetailDialog";

import FoodItem from "../molecules/FoodItem.vue";
import SideNavItem from "../molecules/SideNavItem.vue";
import FoodDetailDialog from "../organisms/FoodDetailDialog.vue";

const foodDetail = useFoodDetailDialogStore();
let allFood = ref([]);
let categories = ref([]);

const getAllFood = async () => {
  let res = await fetch("/mockData/food.json");
  let data = await res.json();

  allFood.value = data;
};

const getCategories = async () => {
  let res = await fetch("/mockData/categories.json");
  let data = await res.json();

  categories.value = data;
};

getAllFood();
getCategories();
</script>

<template>
  <section
    v-if="allFood.length > 0 && categories.length > 0"
    class="grid grid-cols-12 w-screen h-[88vh]"
  >
    <ul class="col-span-3 bg-grey-light py-8 flex flex-col">
      <li v-for="category in categories" class="relative">
        <SideNavItem :category="category" />
      </li>
    </ul>
    <div
      class="col-span-9 bg-grey-lightSecondary grid grid-cols-3 gap-10 px-14 py-10 overflow-y-scroll"
    >
      <div v-for="food in allFood"><FoodItem :food="food" /></div>
    </div>
  </section>
  <FoodDetailDialog
    v-if="foodDetail.isDialogOpen"
    :foodDetail="foodDetail.data"
  />
</template>
