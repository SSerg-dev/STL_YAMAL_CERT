<template>
    <div class="naks-report">

        <dx-data-grid
                class="naks-report-data-grid mt-2"
                ref="dataGrid"
                :data-source="dataSource"
                :remote-operations="true"
                :sorting="{mode: 'none'}"
                :column-auto-width="true"
                :show-borders="true"
                :show-row-lines="true"
                :word-wrap-enabled="true"
                width="100%">
            
            <!--<dx-state-storing-->
            <!--:enabled="true"/>-->

            <dx-column-fixing
                    :enabled="true"/>

            <dx-scrolling
                    mode="virtual"/>

            <dx-pager
                    :visible="true"
                    :show-info="true"
                    :show-page-size-selector="true"
                    :allowed-page-sizes="[20, 50, 100, 200]"/>

            <!--<dx-selection-->
            <!--:allow-select-all="true"-->
            <!--:deferred="true"-->
            <!--mode="multiple"-->
            <!--select-all-mode="allPages"/>-->

            <dx-filter-row
                    :visible="true"/>

            <dx-export
                    :enabled="true"
                    file-name="NaksReport"/>

            <dx-header-filter
                    :visible="true"/>

            <dx-filter-panel
                    :visible="true"/>

            <dx-filter-builder/>

            <dx-column data-field="Person.FullName"
                       caption="ФИО"
                       :width="250"
                       :allow-filtering="true"
                       :allow-header-filtering="false"
                       :fixed="true"/>

            <dx-column data-field="Person.BirthYear"
                       data-type="number"
                       :allow-filtering="true"
                       :allow-header-filtering="false"
                       caption="Год рождения"/>

            <dx-column data-field="Person.Organization"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{
                           allowSearch: true, 
                           dataSource: getReftableDataSource('Contragent', fieldName='Person.Organization')
                           }"
                       caption="Место работы"/>

            <dx-column data-field="Person.Position"
                       :allow-filtering="false"
                       :allow-header-filtering="false"
                       caption="Должность"/>

            <dx-column data-field="Number"
                       :allow-sorting="false"
                       :width="150"
                       :allow-filtering="true"
                       :allow-header-filtering="false"
                       caption="Номер удостоверения / вкладыша"/>

            <dx-column data-field="IssueDate"
                       data-type="date"
                       format="shortDate"
                       :allow-filtering="true"
                       :allow-header-filtering="false"
                       caption="Дата выдачи"/>

            <dx-column data-field="ValidUntil"
                       data-type="date"
                       format="shortDate"
                       :allow-filtering="true"
                       :allow-header-filtering="false"
                       caption="Срок действия"/>

            <dx-column data-field="IsValid"
                       data-type="boolean"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{ allowSearch: false, dataSource: [
                        {text: 'Да', value: ['IsValid', '=', true]},
                        {text: 'Нет', value: ['IsValid', '=', false]},
                       ]}"
                       caption="Действует"/>

            <dx-column data-field="Schifr"
                       :allow-filtering="true"
                       :allow-header-filtering="false"
                       caption="Шифр"/>

            <dx-column data-field="WeldType"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{ allowSearch: true, dataSource: getReftableDataSource('WeldType')}"
                       :filter-operations="['anyof']"
                       caption="Вид (способ) сварки (наплавки)"/>

            <dx-column data-field="HIFGroup"
                       :width="200"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{ allowSearch: true, dataSource: getReftableDataSource('HIFGroup')}"
                       :filter-operations="['anyof']"
                       :calculate-display-value="calculateDisplayValueFunc('HIFGroup')"
                       caption="Группа технических устройств"/>

            <dx-column data-field="DetailsType"
                       caption="Вид деталей"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{ allowSearch: true, dataSource: getReftableDataSource('DetailsType')}"
                       :filter-operations="['anyof']"
                       :calculate-display-value="calculateDisplayValueFunc('DetailsType')"/>

            <dx-column data-field="SeamsType"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{ allowSearch: true, dataSource: getReftableDataSource('SeamsType')}"
                       :filter-operations="['anyof']"
                       :calculate-display-value="calculateDisplayValueFunc('SeamsType')"
                       caption="Типы швов"/>

            <dx-column data-field="JointType"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{ allowSearch: true, dataSource: getReftableDataSource('JointType')}"
                       :filter-operations="['anyof']"
                       caption="Тип соединения"/>

            <dx-column data-field="WeldMaterialGroup"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{ allowSearch: true, dataSource: getReftableDataSource('WeldMaterialGroup')}"
                       :filter-operations="['anyof']"
                       :calculate-display-value="calculateDisplayValueFunc('WeldMaterialGroup')"
                       caption="Группа свариваемого материала"/>

            <dx-column data-field="WeldMaterial"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{ allowSearch: true, dataSource: getReftableDataSource('WeldMaterial')}"
                       :filter-operations="['anyof']"
                       :calculate-display-value="displayValueWeldMaterial"
                       caption="Сварочные материалы"/>

            <dx-column data-field="DetailWidth"
                       :allow-filtering="true"
                       :allow-header-filtering="false"
                       caption="Толщина деталей, мм"/>

            <dx-column data-field="OuterDiameter"
                       :allow-filtering="true"
                       :allow-header-filtering="false"
                       caption="Наружный диаметр, мм"/>

            <dx-column data-field="WeldPosition"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{ allowSearch: true, dataSource: getReftableDataSource('WeldPosition')}"
                       :filter-operations="['anyof']"
                       :calculate-display-value="displayValueWeldPosition"
                       caption="Положение при сварке"/>

            <dx-column data-field="JointKind"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{ allowSearch: true, dataSource: getReftableDataSource('JointKind')}"
                       :filter-operations="['anyof']"
                       :calculate-display-value="calculateDisplayValueFunc('JointKind')"
                       caption="Вид соединения"/>

            <dx-column data-field="WeldGOST14098"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{ allowSearch: true, dataSource: getReftableDataSource('WeldGOST14098')}"
                       :filter-operations="['anyof']"
                       :calculate-display-value="calculateDisplayValueFunc('WeldGOST14098')"
                       caption="Обозначение по ГОСТ 14098"/>

            <dx-column data-field="WeldingEquipmentAutomationLevel"
                       :allow-filtering="false"
                       :allow-header-filtering="true"
                       :header-filter="{ allowSearch: true, dataSource: getReftableDataSource('WeldingEquipmentAutomationLevel')}"
                       :filter-operations="['anyof']"
                       caption="Степень автоматизации сварочного оборудования"/>

        </dx-data-grid>

    </div>
</template>

<script>
    import {
        DxColumn,
        DxColumnFixing,
        DxColumnHeaderFilter,
        DxDataGrid,
        DxExport,
        DxFilterBuilder,
        DxFilterPanel,
        DxFilterRow,
        DxHeaderFilter,
        DxMasterDetail,
        DxPager,
        DxPaging,
        DxScrolling,
        DxSelection,
        DxStateStoring
    } from 'devextreme-vue/data-grid'
    import DxDrawer from 'devextreme-vue/drawer'
    import NaksPersonStore from './store'

    import context from 'api/odata-context'
    import CustomStore from "devextreme/data/custom_store";

    export default {
        name: "NaksReportTwo",
        components: {
            DxDataGrid,
            DxStateStoring,
            DxColumn,
            DxColumnFixing,
            DxMasterDetail,
            DxScrolling,
            DxPaging,
            DxPager,
            DxExport,
            DxSelection,
            DxHeaderFilter,
            DxColumnHeaderFilter,
            DxFilterRow,
            DxFilterPanel,
            DxFilterBuilder,
            DxDrawer
        },
        data() {
            return {
                dataSource: {
                    store: NaksPersonStore(),
                },
            }
        },
        methods: {
            getReftableDataSource(reftableName, fieldName = null) {
                if (fieldName === null) {
                    fieldName = reftableName;
                }

                // we wrap odata store here with a little hacking
                // because using odata store directly causes some weird errors :(  
                var store = new CustomStore({
                    load(loadOptions) {
                        if (loadOptions.searchValue) {
                            loadOptions.filter = [
                                ['Title', 'contains', loadOptions.searchValue],
                                'or',
                                ['Description', 'contains', loadOptions.searchValue]
                            ]
                        }
                        return context[reftableName]
                            .load(loadOptions)
                            .then(data => data.map(
                                item => Object({
                                    text: item.Description ? `${item.Title} (${item.Description})` : item.Title,
                                    value: [fieldName, '=', item.ID.toString()]
                                })));
                    },
                });

                return {
                    sort: 'Title',
                    store: store,
                };
            },
            displayValueWeldPosition(data) {
                if (data['WeldPosition'].includes('Ручнойввод')) {
                    return data['WeldPositionCustom']
                } else {
                    return data['WeldPosition']
                        .map(x => x.replace(/ /g, '\u00a0'))
                        .join(', ');
                }
            },
            displayValueWeldMaterial(data) {
                if (data['WeldMaterial'].includes('Ручной ввод')) {
                    return [data['WeldingWire'], data['ShieldingGasFlux']]
                        .filter(x => !!x)
                        .join('; ')
                } else {
                    return data['WeldMaterial']
                        .map(x => x.replace(/ /g, '\u00a0'))
                        .join(', ');
                }
            },
            calculateDisplayValueFunc(fieldName) {
                return function (data) {
                    // make display string for array cell
                    // replace spaces with non-breaking spaces for better presentation
                    return data[fieldName]
                        .map(x => x.replace(/ /g, '\u00a0'))
                        .join(', ');
                }
            }
        }
    }
</script>

<style scoped lang="scss">
    @import "~bootstrap/scss/bootstrap";
    
    .naks-report {
        @extend .px-2;
        height: calc(100vh - 8rem);
        max-width: 100%;
        overflow: hidden;
    }
    
    .naks-report-data-grid {
        height: 100%;
    }
</style>