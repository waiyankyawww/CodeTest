<script setup>
import { ref, onMounted, onUnmounted } from "vue";
const mission = ref(null);
const services = ref(null);

const calcParallax = () => {
  const scrollY = window.scrollY;

  if (scrollY > 560) {
    mission.value.style.opacity = 1;
  }
  if (scrollY > 700) {
    services.value.style.opacity = 1;
  }
};

onMounted(() => {
  window.addEventListener("resize", calcParallax);
  window.addEventListener("scroll", calcParallax);
});

onUnmounted(() => {
  window.removeEventListener("resize", calcParallax);
  window.removeEventListener("scroll", calcParallax);
});
</script>

<template>
  <section>
    <div
      ref="mission"
      class="my-14 px-14 gap-4 flex items-center justify-between opacity-0 ease-in-out duration-1000"
    >
      <div>
        <p class="text-2xl font-bold leading-[1.1em]">
          FRESH FOOD FOR A FRESHER YOU
        </p>
        <p class="mt-8 text-xl italic font-medium">
          Quality food, quality life.
        </p>
      </div>
      <img class="w-auto h-72" src="/screen2/Side image.png" alt="side-image" />
    </div>
    <div
      ref="services"
      class="my-24 flex items-center px-14 justify-center gap-32 opacity-0 ease-in-out duration-1000"
    >
      <div class="flex flex-col gap-10 items-center">
        <img class="w-44 h-44" src="/screen2/clock.png" alt="online-anywhere" />
        <p class="text-xl italic font-medium">Online anywhere</p>
      </div>
      <div class="flex flex-col gap-10 items-center">
        <img
          class="w-44 h-44"
          src="/screen2/delivery-truck.png"
          alt="fast-delivery"
        />
        <p class="text-xl italic font-medium">Fast Delivery</p>
      </div>
      <div class="flex flex-col gap-10 items-center">
        <img class="w-44 h-44" src="/screen2/support.png" alt="24/7-support" />
        <p class="text-xl italic font-medium">24/7 Support</p>
      </div>
    </div>
  </section>
</template>
