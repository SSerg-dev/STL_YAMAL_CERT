<template>
    <dx-pie-chart
        :data-source="dataSource"
        palette="Bright"
        title="Действующие свидетельства"
        :on-point-click="onPointClick">
        <dx-series
            argument-field="IsValid"
            value-field="Count">
            <dx-label :visible="true">
                <dx-connector
                        :visible="true"
                        :width="1"
                />
            </dx-label>
        </dx-series>
        <dx-legend :customize-text="legendCustomizeText" />
        <dx-export :enabled="true"/>
    </dx-pie-chart>     
</template>

<script>
    import DxPieChart, {DxConnector, DxExport, DxLabel, DxLegend, DxSeries, DxSize} from 'devextreme-vue/pie-chart'

    import axios from 'axios'

    export default {
        name: "NaksValidChart",
        components: {
            DxPieChart,
            DxSize,
            DxSeries,
            DxLabel,
            DxConnector,
            DxExport,
            DxLegend
        },
        data() {
            return {
                dataSource: {
                    load(options) {
                        return axios({url: `${baseUrl}api/PermissionPersonStat/NaksValidCount`})
                            .then(resp => resp.data);
                    },
                }
               
            }
        },
        methods: {
            legendCustomizeText(pointInfo) {
                if (pointInfo.pointName === true) {
                    return 'Действует';
                } else {
                    return 'Просрочено';
                }                 
            },
            onPointClick(event) {
                let naksIsValid = event.target.argument;
                this.$router.push({
                    name: 'permission-reports-naks',
                    params: {
                        dataGridSettings: {
                            filter: [
                                ['IsValid', '=', naksIsValid]
                            ]
                        }
                    }
                })
            }
        }
    }
</script>

<style scoped>

</style>