<script setup>
import { ref, onMounted, onUnmounted } from "vue";
const background = ref(null);
const initialBgSize = 110;

const calcParallax = () => {
  const scrollY = window.scrollY;

  background.value.style.backgroundSize = initialBgSize - scrollY / 80 + "%";
};

onMounted(() => {
  background.value.style.backgroundSize = initialBgSize + "%";
  window.addEventListener("resize", calcParallax);
  window.addEventListener("scroll", calcParallax);
});

onUnmounted(() => {
  window.removeEventListener("resize", calcParallax);
  window.removeEventListener("scroll", calcParallax);
});
</script>

<template>
  <section
    class="bg-screen-1-bg w-screen h-screen bg-center bg-no-repeat bg-fixed"
    ref="background"
  ></section>
</template>
