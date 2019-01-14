<template>
    <div>
        <span v-for="(x, index) in values" :title="x.Description || ''">
            {{ x.Title }}<span v-if="index + 1  !== values.length">,</span>
        </span>
    </div>
</template>

<script>
    export default {
        name: "ValueDisplay",
        props: {
            value: {
                required: true
            }
        },   
        computed: {
            values() {
                if (this.value === null || this.value === undefined) return [];
                return Array.isArray(this.value) ? this.value : [this.value]
                    .map(x => typeof x === 'object' ? x : {Title: x});
            }
        }
        
    }
</script>

<style scoped>

</style>