<script setup>
import { ref } from "vue";

let isSubMenuOpen = ref(false);

const props = defineProps({
  category: Object,
});

const handleSubMenuToggle = () => {
  isSubMenuOpen.value = !isSubMenuOpen.value;
};
</script>

<template>
  <p
    :class="[
      'text-base font-medium px-14 py-3 hover:bg-grey-lightTertiary cursor-pointer',
      isSubMenuOpen
        ? 'bg-grey-lightTertiary text-white'
        : 'bg-transparent text-grey',
    ]"
    @click="category.subMenu && handleSubMenuToggle()"
  >
    {{ category.title }}
  </p>
  <div
    v-if="category.subMenu && isSubMenuOpen"
    class="absolute left-[100%] top-0 bg-grey-lightTertiary py-2 w-full text-base text-medium text-white"
  >
    <li
      v-for="item in category.subMenu"
      class="px-4 py-2 text-white cursor-pointer"
    >
      {{ item }}
    </li>
  </div>
</template>
