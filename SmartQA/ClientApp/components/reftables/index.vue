<template>
    <div class="row">
        <div class="col-sm-3">
            <div class="py-md-3">
                <dx-list :data-source="reftablesDataSource"
                         class="nav"
                         height="100%">
                    <reftables-list-item slot="item"
                                  slot-scope="item"
                                  :item="item" />
                </dx-list>
            </div>
        </div>
        <div class="col-sm-9">
            <div class="py-md-3">
                <reftable-editor v-if="modelName"
                                 v-bind:model-name="modelName" />
            </div>
        </div>
    </div>
</template>

<script>
    import ReftableEditor from "./reftable-editor";
    import ReftablesListItem from './reftables-list-item';
    import DxMenu from 'devextreme-vue';
    import DxList from 'devextreme-vue/list';
    import { dataSourceConfs } from "./data";
    
    export default {
        components: {
            DxMenu,
            DxList,
            ReftableEditor,
            ReftablesListItem
        },
        props: {
            modelName: String,            
        },
        data: function () {
            return {
                reftablesDataSource: dataSourceConfs.reftables
            }
        },
        methods: {            
        }
    }
</script>

