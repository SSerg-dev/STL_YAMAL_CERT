<template>
    <dx-chart
        :data-source="dataSource"
        title="Количество людей с НАКС">
        <dx-series
            type="bar"
            argument-field="Label"
            value-field="PersonCount">
            <dx-label :visible="true">
                <dx-connector
                        :visible="true"
                        :width="1"
                />
            </dx-label>
        </dx-series>
        <dx-legend :visible="false"/>
        
        <dx-export :enabled="true"/>
    </dx-chart>     
</template>

<script>
    import {DxChart, DxConnector, DxExport, DxLabel, DxLegend, DxSeries, DxSize} from 'devextreme-vue/chart'

    import axios from 'axios'

    export default {
        name: "NaksPersonCountChart",
        components: {
            DxChart,
            DxSize,
            DxSeries,
            DxLabel,
            DxConnector,
            DxExport,
            DxLegend
        },
        data() {
            let pluralRules = new Intl.PluralRules('ru');
            let naksPlurals = new Map([
                ['one', 'свидетельство'],
                ['few', 'свидетельства'],
                ['many', 'свидетельств'],
            ]);
            
            return {
                dataSource: {
                    load(options) {
                        return axios({url: `${baseUrl}api/PermissionPersonStat/PersonNaksCount`})
                            .then(resp => resp.data.map(x => 
                                Object.assign(x, {'Label': `${x.NaksCount} ${naksPlurals.get(pluralRules.select(x.NaksCount))}`})
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