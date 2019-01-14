<template>
    <div>
        <table class="table table-responsive table-bordered table-sm">
            <thead>
            <tr>
                <th scope="col">Номер</th>
                <th scope="col">Шифр</th>
                <th scope="col">Вид (способ)<br/> сварки (наплавки)</th>
                <th scope="col">Группа технических<br/>устройств</th>
                <th scope="col">Вид деталей</th>
                <th scope="col">Типы швов</th>
                <th scope="col">Тип<br/>соединения</th>
                <th scope="col">Группа<br/>свариваемого<br/>материала</th>
                <th scope="col">Сварочные<br/>материалы</th>
                <th scope="col">Толщина<br/>деталей, мм</th>
                <th scope="col">Наружный<br/>диаметр, мм</th>
                <th scope="col">Положение<br/>при сварке</th>
                <th scope="col">Вид<br/>соединения</th>
                <th scope="col">Обозначение<br/>по ГОСТ 14098</th>
                <th scope="col">Степень автоматизации<br/>сварочного оборудования</th>
            </tr>
            </thead>
            <tbody>
            <tr v-for="attest in rows">
                <td v-if="attest.rowspan" :rowspan="attest.rowspan">
                    <value-display :value="attest.DocumentNaks.Number"/>
                </td>
                <td v-if="attest.rowspan" :rowspan="attest.rowspan">
                    <value-display :value="attest.DocumentNaks.Schifr"/>
                </td>
                <td v-if="attest.rowspan" :rowspan="attest.rowspan">
                    <value-display :value="attest.DocumentNaks.WeldType"/>

                </td>
                <td v-if="attest.rowspan" :rowspan="attest.rowspan">
                    <value-display :value="attest.DocumentNaks.HIFGroupSet"/>
                </td>
                <td>
                    <value-display :value="attest.DetailsTypeSet"/>
                </td>
                <td>
                    <value-display :value="attest.SeamsTypeSet"/>
                </td>
                <td>
                    <value-display :value="attest.JointTypeSet"/>
                </td>
                <td>
                    <value-display :value="attest.WeldMaterialGroupSet"/>
                </td>
                <td>
                    <value-display :value="attest.WeldMaterialSet"/>
                </td>
                <td>
                    <value-display :value="attest.DetailWidth"/>
                </td>
                <td>
                    <value-display :value="attest.OuterDiameter"/>
                </td>
                <td>
                    <value-display :value="attest.WeldPositionSet"/>
                </td>
                <td>
                    <value-display :value="attest.JointKindSet"/>
                </td>
                <td>
                    <value-display :value="attest.WeldGOST14098Set"/>
                </td>
                <td>
                    <value-display :value="attest.WeldingEquipmentAutomationLevel"/>
                </td>
            </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import ValueDisplay from './value-display'

    export default {
        name: "NaksTable",
        components: {
            ValueDisplay
        },
        props: {
            data: {
                type: Array,
                required: true
            }
        },
        computed: {
            rows() {
                let sortedNaks = [].concat.apply([],
                    this.data
                        .filter(n => n.ParentDocumentNaks_ID === null)
                        .sort(n => n.Number)
                        .map(n => {
                            let children = this.data
                                .filter(child => child.ParentDocumentNaks_ID === n.ID)
                                .sort(child => child.Number);

                            return [n].concat(children);
                        })
                );

                let attestExpanded = [].concat.apply([],
                    sortedNaks.map(n => {
                        let attestList = n.DocumentNaksAttestSet.map(attest =>
                            Object.assign({DocumentNaks: n, rowspan: 0}, attest));


                        if (attestList.length !== 0) {
                            attestList[0].rowspan = attestList.length;
                        } else {
                            attestList = [{DocumentNaks: n, rowspan: 1}]
                        }
                        return attestList;
                    })
                );

                return attestExpanded;

            }
        }
    }
</script>

<style scoped>
    th {
        text-wrap: normal;
    }
</style>