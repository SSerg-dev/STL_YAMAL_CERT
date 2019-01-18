<template>
    <div class="container-fluid py-4">
        <h2>Справочники</h2>
        <div class="row">
            <div class="col-sm-3 py-3 position-fixed sidebar" 
                 style="">             
                
                    <dx-list :data-source="reftablesDataSource"
                             :search-enabled="true"
                             page-load-mode="nextButton"
                             searchExpr="Title"
                             class="nav"
                             height="auto">
                        
                        <reftables-list-item slot="item"
                                      slot-scope="item"
                                      :item="item" />
                    </dx-list>
                
            </div>
            <div class="offset-3 col-sm-9">
                <div class="py-md-3">
                    <reftable-editor v-if="modelName"
                                     v-bind:model-name="modelName" />
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import ReftableEditor from "./reftable-editor";
    import ReftablesListItem from './reftables-list-item';
    import {DxScrollView} from 'devextreme-vue';
    import DxList from 'devextreme-vue/list';
    import {dataSourceConfs} from "./data";
    import DataSource from 'devextreme/data/data_source';

    export default {
        components: {
            DxList,
            DxScrollView,
            ReftableEditor,
            ReftablesListItem
        },
        props: {
            modelName: String,            
        },
        data: function () {
            var source = new DataSource(dataSourceConfs.reftables);
            source.filter(['UseDefaultEditor', '=', true]);
            
            return {
                reftablesDataSource: source
            }
        },
        methods: {
        }
    }
</script>

<style scoped>

    .sidebar{
        position: sticky;
        height: calc(100vh - 4rem);
        overflow-x: hidden; 
        overflow-y: auto;    
    }
        
</style>