<template>
    <div>
        <dx-data-grid 
            :dataSource="employeeDataSource"
            :selection="{ mode: 'single' }"
            @selection-changed="onSelectionChanged">
           
            <dx-column :calculate-cell-value="calculatePersonCellValue" />

        </dx-data-grid>
    </div>
</template>

<script>
    import { DxDataGrid, DxColumn } from "devextreme-vue/data-grid";

    import 'devextreme/data/odata/store';

    export default {
        components: {
            DxDataGrid,
            DxColumn
        },
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
                selectedEmployee: null
            }

        },
        methods: {
            calculatePersonCellValue(data) {
                return [data.Person.LastName, data.Person.FirstName, data.Person.SecondName].join(' ');
            },
            onSelectionChanged({ selectedRowsData }) {
                const data = selectedRowsData[0];                
                this.selectedEmployee = data;
                this.$emit('employee-selected', data);
            }
        }
    };
</script>
