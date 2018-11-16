<template>
    <div class="product">
        <router-link class="nav-item nav-link" 
                     :to="'/reftables/' + item.ModelName">
            {{ item.Title }}

        </router-link>        
    </div>
</template>
<script>

export default {
  filters: {
    
  },
  props: {
    item: {
      type: Object,
      default: () => {}
    }
  },
};
</script>
