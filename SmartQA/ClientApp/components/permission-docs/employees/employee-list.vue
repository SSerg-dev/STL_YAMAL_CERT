﻿<template>
    <div>
        <dx-toolbar :items="toolbarItems" />
        <dx-data-grid ref="dataGrid"
                      :dataSource="employeeDataSource"
                      :selection="{ mode: 'single' }"
                      :filterRow="{ visible: true }"                      
                      @selection-changed="onSelectionChanged">

            <dx-column
                       :allowFiltering="true"
                       :allowSearch="true"
                       :allow-sorting="true"
                       sort-order="asc"
                       :calculate-cell-value="calculatePersonCellValue"
                       :calculate-sort-value="'Person.LastName'"
                       :calculate-filter-expression="(f, o, t) => ['Person.LastName', 'startswith', f]"
                       />
        </dx-data-grid>
    </div>
</template>

<script>
    import {
        DxColumn,
        DxDataGrid,
        DxEditing,
        DxLookup,
        DxPaging,
        DxPopup,
        DxPosition,
        DxSearchPanel
    } from "devextreme-vue/data-grid";
    import DxToolbar from 'devextreme-vue/toolbar';
    import {employeeDataSourceSettings} from './employee-data.js'

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
                employeeDataSource: employeeDataSourceSettings,
                selectedEmployee: null,
                toolbarItems: [{
                    location: 'before',
                    widget: 'dxButton',
                    options: {
                        type: 'add',   
                        icon: 'add',
                        text: 'Добавить сотрудника',
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
                if (data) {
                    this.$router.push({
                        params: { employeeId: data.ID.toString() }
                    })
                }
            },
            reload() {
                this.$refs.dataGrid.instance.refresh();
            }
        }
    };
</script>
