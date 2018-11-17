<template>    
        <router-link class="nav-item" 
                     :to="'/reftables/' + item.ModelName">
            <a class="nav-link">
                {{ item.Title }}
            </a>            
        </router-link>            
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
