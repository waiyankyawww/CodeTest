<script setup>
import { ref } from "vue";

let searchValue = ref("");

const handleSearch = () => {
  alert(searchValue.value);
  searchValue.value = "";
};
</script>

<template>
  <div class="h-14 flex items-center">
    <input
      type="text"
      class="w-[30rem] border bg-grey-light h-full rounded-l-sm px-4 outline-1 outline-grey placeholder-grey placeholder-sm text-sm"
      placeholder="Search for a product or brand"
      v-model="searchValue"
    />
    <button
      class="w-14 h-14 bg-blue text-white rounded-r-sm flex items-center justify-center"
      @click.prevent="handleSearch()"
    >
      <img class="w-8 h-8" src="/icons/search.png" alt="search-btn" />
    </button>
  </div>
</template>
