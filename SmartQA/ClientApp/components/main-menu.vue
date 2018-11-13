<template>
           
        <dx-menu :items="menuItems" />
    
</template>

<script>
    import { DxMenu } from "devextreme-vue/ui/menu";

    export default {
        components: {
            
            DxMenu
        },
        data: function() {
            return {
                menuItems: [
                    { text: "Hide" },
                    { text: "Delete" },
                    {
                        text: "Clipboard",
                        items: [
                            { text: "Copy" },
                            { text: "Clear" },
                            { text: "Paste" }
                        ]
                    }
                ]
           }
        }
};
</script>
