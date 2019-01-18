<template>
    <dx-chart
            :data-source="dataSource"
            title="Количество людей с НАКС">
        
        <dx-argument-axis title="Количество свидетельств">
            <dx-label :visible="true"
                      :customize-text="argumentAxisLabelCustomizeText" />
        </dx-argument-axis>
        
        <dx-series
                type="bar"
                argument-field="NaksCount"
                value-field="PersonCount">
            <dx-label :visible="true"
                      :customize-text="labelCustomizeText">
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
    import {
        DxArgumentAxis,
        DxChart,
        DxConnector,
        DxExport,
        DxLabel,
        DxLegend,
        DxSeries,
        DxSize
    } from 'devextreme-vue/chart'

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
            DxArgumentAxis,
            DxLegend
        },
        data() {
            return {
                dataSource: {
                    load(options) {
                        return axios({url: `${baseUrl}api/PermissionPersonStat/PersonNaksCount`})
                            .then(resp => resp.data);
                    },
                }
            }
        },
        methods: {
            argumentAxisLabelCustomizeText(pointInfo) {
                if (pointInfo.value === 0) {
                    return 'Нет';
                } else {
                    const pluralRules = new Intl.PluralRules('ru');
                    const naksPlurals = new Map([
                        ['one', 'свидетельство'],
                        ['few', 'свидетельства'],
                        ['many', 'свидетельств'],
                    ]);

                    return `${pointInfo.value} ${naksPlurals.get(pluralRules.select(pointInfo.value))}`
                }
            },
            labelCustomizeText(pointInfo) {
                return `${pointInfo.value} чел.`
            },
        }
    }
</script>

<style scoped>

</style>