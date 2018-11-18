<template>
    <div class="pt-5">
        <h3>Удостоверение НАКС</h3>
        <dx-toolbar :items="toolbarItems" />        
        <dx-data-grid ref="dataGrid"
                      v-bind:dataSource="dataSource"
                      @editingStart="onEditingStart">

            <dx-editing :allow-updating="true"
                        :allow-deleting="true"                                                
                        mode="popup" />

            <dx-column data-field="Number"
                       caption="Номер" />

            <dx-column data-field="IssueDate"
                       caption="Дата выдачи" />

        </dx-data-grid>

        <dx-popup ref="editPopup"
                  :show-title="true"
                  :width="800"
                  :height="600"
                  title="НАКС"
                  @onHiding="onEditPopupHiding">

            <naks-edit :editModelKey="editModelKey"
                       :personId="personId"
                       @editSuccess="onEditSuccess" />

        </dx-popup>
    </div>
</template>

<script>
    import {
        DxDataGrid,
        DxColumn,        
        DxEditing,        
        DxPosition
    } from "devextreme-vue/data-grid";
    import { DxPopup } from 'devextreme-vue';
    import { DxButton } from "devextreme-vue/ui/button";
    import DxToolbar from 'devextreme-vue/toolbar';
    import DataSource from 'devextreme/data/data_source';
    import 'devextreme/data/odata/store';

    import NaksEdit from './naks-edit';

    import { dataSourceConfs } from './data.js'    

    export default {
        components: {
            DxDataGrid,
            DxEditing,
            DxColumn,            
            DxPopup,
            DxPosition,
            DxToolbar,
            DxButton,           
            NaksEdit,
        },
        props: {
            personId: String
        },
        created() {
            this.setDataSource()
        },
        data: function () {
            return {
                dataSource: {},
                editModelKey: null,               
                editPopup: {
                    showTitle: false,
                    width: 400,
                    height: 200,
                    position: {
                        my: "center",
                        at: "center",
                        of: window
                    }
                },
                toolbarItems: [                    
                    {
                        location: 'after',
                        widget: 'dxButton',
                        options: {
                            type: 'add',
                            icon: 'add',
                            text: 'Add',
                            onClick: () => {
                                this.editModelKey = null;
                                this.$refs.editPopup.instance.show();
                                }  
                            }
                        }
                ]

            }
        },
        methods: {
            setDataSource() {
                this.dataSource = new DataSource(dataSourceConfs.documentNaks);
                this.dataSource.filter([
                    'Person_ID', '=', new String(this.personId)
                ])
            },
            onEditingStart(event) {
                event.cancel = true;
                this.editModelKey = event.key.toString();
                this.$refs.editPopup.instance.show();
                console.log(event);                                
            },
            onEditSuccess() {                
                this.$refs.editPopup.instance.hide();
                this.$refs.dataGrid.instance.refresh();
            },
            onEditPopupHiding() {
                this.editModelKey = null;
            }

        }

    };
</script>
