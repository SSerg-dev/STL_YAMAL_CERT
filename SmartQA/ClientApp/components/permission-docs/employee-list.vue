<template>
    <div>
        <dx-toolbar :items="toolbarItems" />
        <dx-data-grid ref="dataGrid"
                      :dataSource="employeeDataSource"
                      :selection="{ mode: 'single' }"
                      :filterRow="{ visible: true }",                      
                      @selection-changed="onSelectionChanged">

            <dx-column
                       :allowFiltering="true"
                       :allowSearch="true"
                       :calculate-cell-value="calculatePersonCellValue" />
        </dx-data-grid>
    </div>
</template>

<script>
    import {
        DxDataGrid,
        DxColumn,
        DxSearchPanel,
        DxPaging,
        DxEditing,
        DxPopup,
        DxLookup,
        DxPosition
    } from "devextreme-vue/data-grid";    
    import DxToolbar from 'devextreme-vue/toolbar';

    import 'devextreme/data/odata/store';

    export default {
        components: {
            DxDataGrid,
            DxColumn,      
            DxSearchPanel,
            DxPaging,
            DxEditing,
            DxPopup,
            DxLookup,
            DxPosition,
            DxToolbar
        },
        props: ['employeeId'],
        data: function() {
            return {
                employeeDataSource: {
                    store: {
                        type: 'odata',
                        url: '/odata/Employee',
                        version: 4
                    },
                    expand: [
                        'Person'
                    ]
                },
                selectedEmployee: null,
                toolbarItems: [{
                    location: 'before',
                    widget: 'dxButton',
                    options: {
                        type: 'add',   
                        icon: 'add',
                        text: 'Add employee',
                        onClick: () => {
                            this.$router.push({
                                params: { employeeId: null },
                                query: { edit: true }
                            })
                        }
                    }
                }]
                
            }

        },
        methods: {
            calculatePersonCellValue(data) {
                return [data.Person.LastName, data.Person.FirstName, data.Person.SecondName].join(' ');
            },
            onSelectionChanged({ selectedRowsData }) {
                const data = selectedRowsData[0];
                this.$router.push({
                    params: { employeeId: data.Employee_ID }                    
                })
            },
            reload() {
                this.$refs.dataGrid.instance.refresh();
            }
        }
    };
</script>
