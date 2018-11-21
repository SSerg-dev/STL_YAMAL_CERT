<template>
    <div>
        hello!

        {{ qqq.toString() }}
    </div>
</template>

<script>

    export default {
        components: {

        },
        props: {
            qqq: {
                type: Object,
                default: () => { }
            }
        },
        created() {
            console.log(this.qqq);
        },
        data: function () {
            return {
             
            }
        },
        methods: {
            

        }

    };
</script>
