<template>
    <dx-pie-chart
        :data-source="dataSource"
        palette="Bright"
        title="Действующие свидетельства">
        <dx-series
            argument-field="Label"
            value-field="Count">
            <dx-label :visible="true">
                <dx-connector
                        :visible="true"
                        :width="1"
                />
            </dx-label>
        </dx-series>
        <dx-export :enabled="true"/>
    </dx-pie-chart>     
</template>

<script>
    import DxPieChart, {DxConnector, DxExport, DxLabel, DxSeries, DxSize} from 'devextreme-vue/pie-chart'

    import axios from 'axios'

    export default {
        name: "NaksValidChart",
        components: {
            DxPieChart,
            DxSize,
            DxSeries,
            DxLabel,
            DxConnector,
            DxExport
        },
        data() {
            return {
                dataSource: {
                    load(options) {
                        return axios({url: `${baseUrl}api/PermissionPersonStat/NaksValidCount`})
                            .then(resp => resp.data.map(x => 
                                Object.assign(x, {'Label': x.IsValid ? 'Действует' : 'Просрочено'})
                            ));
                    },
                }
               
            }
        },
        methods: {
          
        }
        
        
    }
</script>

<style scoped>

</style>