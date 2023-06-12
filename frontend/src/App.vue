<script setup>
import Navbar from "./components/organisms/Navbar.vue";
import LoadingPage from "./components/pages/LoadingPage.vue";
import PromotionalPage from "./components/pages/PromotionalPage.vue";
import ShoppingPage from "./components/pages/ShoppingPage.vue";
</script>

<template>
  <div class="font-sans">
    <Navbar />
    <div class="pt-[12vh]">
      <LoadingPage />
    </div>
    <PromotionalPage />
    <ShoppingPage />
  </div>
</template>
