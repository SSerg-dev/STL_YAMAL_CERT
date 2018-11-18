<template>    
    <div>
        <router-link class="nav-link"                     
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
