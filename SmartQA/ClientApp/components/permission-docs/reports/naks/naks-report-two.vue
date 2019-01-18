<template>
    <div class="p-2" style="
            display:flex; 
            flex-direction:column;
            flex-grow: 1;
            overflow: hidden;
        ">
        <div class="naks-report" style="order: 2;">
            <dx-data-grid
                    class="naks-report-data-grid mt-2"
                    ref="dataGrid"
                    :data-source="dataSource"
                    :filter-value="filterValue"
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

        <!-- Если форму поставить перед гридом, то грид глючит -->
        <div class="my-2" style="order: 1;">
            <dx-form
                    :items="formItems"
                    :form-data="formData"
                    @fieldDataChanged="formDataChanged"/>
        </div>
    </div>
</template>

<script>
    import DxForm from 'devextreme-vue/form'
    import NaksReport from './naks-report'
    import {reftableFormItem} from "components/forms/reftables";

    export default {
        name: "NaksReportTwo",
        extends: NaksReport,
        components: {
            DxForm
        },
        watch: {
            filterValue(val) {
                console.log(val)
            }
            
        },
        data() {
            return {
                formData: {},
                formItems: [
                    {
                        label: {text: 'ФИО'},
                        dataField: 'Person_FullName',
                        required: false
                    },
                    reftableFormItem('WeldType', 'Вид (способ) сварки (наплавки)', false, false),
                    reftableFormItem('DetailsType', 'Вид деталей', true, false),
                ]

            }
        },
        methods: {
            formDataChanged(event) {
                console.log('formDataChanged');

                let filters = [];

                function addFilter(f) {
                    if (filters.length > 0) {
                        filters.push('and')
                    }
                    filters.push(f);
                }

                let FullName = this.formData.Person_FullName;
                if (FullName) {
                    addFilter(['Person.FullName', 'contains', FullName])
                }

                let WeldType = this.formData.WeldType_ID;
                if (WeldType) {
                    addFilter(['WeldType', '=', WeldType])
                }

                let DetailsType = this.formData.DetailsType_IDs;
                if (DetailsType && DetailsType.length > 0) {
                    let dtFilter = [];
                    DetailsType.forEach(x => {
                        dtFilter.push(['DetailsType', '=', x]);
                        dtFilter.push('or');
                    });
                    dtFilter.pop();
                    addFilter(dtFilter);
                }
                
                this.$refs.dataGrid.instance.filter(filters);
            },

        }
    }

</script>

