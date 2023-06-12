<script setup>
import { ref, defineProps } from "vue";
import { useFoodDetailDialogStore } from "../../stores/foodDetailDialog";
import { useCartStore } from "../../stores/cart";
const foodDetailDialog = useFoodDetailDialogStore();
const cart = useCartStore();

const props = defineProps({
  foodDetail: Object,
});

let isShowMore = ref(false);
let currentImageIndex = ref(0);
let quantity = ref(0);

const handleShowMore = () => {
  isShowMore.value = !isShowMore.value;
};

const handleRightArrowImagesChange = () => {
  if (currentImageIndex.value < foodDetailDialog.data.images.length - 1) {
    currentImageIndex.value += 1;
  } else {
    currentImageIndex.value = 0;
  }
};

const handleLeftArrowImagesChange = () => {
  if (currentImageIndex.value <= 0) {
    currentImageIndex.value = foodDetailDialog.data.images.length - 1;
  } else {
    currentImageIndex.value -= 1;
  }
};

const handleAddToCart = () => {
  const item = { ...foodDetailDialog.data, quantity: quantity.value };
  if (quantity.value > 0) {
    cart.addFoodToCart(item);
  }
  foodDetailDialog.closeDialog();
};

const checkCurrentFoodIsInCart = () => {
  const allFoodId = cart.allFood.map((item) => item.id);
  return allFoodId.includes(foodDetailDialog.data.id);
};
</script>

<template>
  <div
    class="fixed top-0 left-0 z-20 w-screen h-screen bg-black bg-opacity-50 flex items-center justify-center"
  >
    <div
      class="w-[85vw] h-[85vh] bg-white rounded-lg py-24 px-8 grid grid-cols-5 gap-12 relative"
    >
      <!-- modal hidden cross -->
      <div
        class="absolute top-6 right-8 cursor-pointer"
        @click="foodDetailDialog.closeDialog"
      >
        <img class="w-8 h-8" src="/icons/cross.png" alt="cross" />
      </div>

      <!-- images carousel -->
      <div class="col-span-2 relative flex items-center justify-center border">
        <img
          class="w-96 h-96 object-cover"
          :src="'/screen3/' + foodDetail.images[currentImageIndex]"
          alt=""
        />
        <div
          v-if="foodDetail.images.length > 1"
          class="absolute left-2 w-10 h-10 bg-white rounded-full flex items-center justify-center cursor-pointer"
          @click="handleLeftArrowImagesChange"
        >
          <img class="w-6 h-6" src="/icons/left-arrow.png" alt="cross" />
        </div>
        <div
          v-if="foodDetail.images.length > 1"
          class="absolute right-2 w-10 h-10 bg-white rounded-full flex items-center justify-center cursor-pointer"
          @click="handleRightArrowImagesChange"
        >
          <img class="w-6 h-6" src="/icons/right-arrow.png" alt="cross" />
        </div>
      </div>

      <div class="col-span-3 flex flex-col justify-between">
        <!-- product information -->
        <div>
          <p class="text-lg font-bold text-grey-dark">{{ foodDetail.name }}</p>
          <p class="text-sm font-bold text-grey">
            {{ foodDetail.type }} of 1 bundle
          </p>

          <div class="mt-12 flex flex-col gap-4">
            <div class="grid grid-cols-12">
              <p class="col-span-3 text-xs text-base text-grey">
                Key information
              </p>
              <p class="col-span-9 text-xs text-base text-grey">
                Packet of 1 Bundle of {{ foodDetail.name }}
              </p>
            </div>

            <div class="grid grid-cols-12">
              <p class="col-span-3 text-xs text-base text-grey">
                About the product
              </p>
              <p class="col-span-9 text-xs text-base text-grey">
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Error
                numquam vero excepturi laborum necessitatibus blanditiis,
                <span
                  v-if="!isShowMore"
                  class="text-red cursor-pointer"
                  @click="handleShowMore"
                  >More</span
                >
                <span v-else>
                  culpa porro quam tempore nisi rem temporibus placeat expedita
                  voluptates enim atque nemo eum! Sunt!</span
                >
              </p>
            </div>

            <div class="grid grid-cols-12">
              <p class="col-span-3 text-xs text-base text-grey">
                Country of origin
              </p>
              <p class="col-span-9 text-xs text-base text-grey">France</p>
            </div>
          </div>
        </div>

        <!-- add to cart action -->
        <div class="flex items-center gap-2">
          <p class="p-2 bg-red rounded-md text-white text-xs">Qty</p>

          <input
            type="number"
            class="border bg-grey-light h-full rounded-md px-4 outline-1 outline-grey placeholder-grey placeholder-xs text-xs"
            v-model="quantity"
          />

          <button
            class="p-2 px-4 bg-red rounded-md text-white text-xs uppercase disabled:bg-grey"
            :disabled="checkCurrentFoodIsInCart()"
            @click.prevent="handleAddToCart"
          >
            Add to cart
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
