<template>
    <div>
        <h4>Области аттестации</h4>
        
        <table v-if="model != null">

            <tr>
                <th>Степень автоматизации сварочного оборудования</th>
                <td v-for="item in model.DocumentNaksAttestSet">                    
                    <p v-if="item.WeldingEquipmentAutomationLevel">
                        {{ item.WeldingEquipmentAutomationLevel.Title }}
                    </p>
                </td>
            </tr>

            <tr>
                <th>Вид деталей</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <p v-for="val in item.DetailsTypeSet">
                        {{ val.Title }}
                    </p>
                </td>
            </tr>
            
            <tr>
                <th>Типы швов</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <p v-for="val in item.SeamsTypeSet">
                        {{ val.Title }}
                    </p>
                </td>
            </tr>

            <tr>
                <th>Тип соединения</th>
                <td v-for="item in model.DocumentNaksAttestSet">          
                    <p v-if="item.JointType">
                        {{ item.JointType.Title }}
                    </p>                          
                </td>
            </tr>
            <tr>
                <th>Группа свариваемого материала</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <p v-for="val in item.WeldMaterialGroupSet">
                        {{ val.Title }}
                    </p>
                </td>
            </tr>          

            <tr>
                <th>Сварочные материалы</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <p v-for="val in item.WeldMaterialSet">
                        {{ val.Title }}
                    </p>
                </td>
            </tr>
            <tr>
                <th>Толщина деталей, мм</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <p v-if="item.JointType">
                        {{ item.DetailWidth.Title }}
                    </p>                       
                    
                </td>
            </tr>
            <tr>
                <th>Наружный диаметр, мм</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    {{ item.OuterDiameter }}
                </td>
            </tr>
            <tr>
                <th>SDR</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    {{ item.SDR }}
                </td>
            </tr>
            <tr>
                <th>Положение при сварке</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <p v-for="val in item.WeldPositionSet">
                        {{ val.Title }}
                    </p>
                </td>
            </tr>           

            <tr>
                <th>Вид соединения</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <p v-for="val in item.JointKindSet">
                        {{ val.Title }}
                    </p>
                </td>
            </tr>

            <tr>
                <th>Обозначение по ГОСТ 14098</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <p v-if="item.WeldGOST14098">
                        {{ item.WeldGOST14098.Title }}
                    </p>                         
                </td>
            </tr>


        </table>
    </div>
</template>


<script>    
    import DataSource from 'devextreme/data/data_source';    

    import { dataSourceConfs } from './data.js';

    export default {
        components: {
            DataSource
        },
        props: {
            'modelKey': String,            
        },
        watch: {
            'modelKey': 'fetchData'                   
        },
        created() {
            this.fetchData();
        },
        data: function () {
            return {
                
               loading: false,
                model: null,
                error: null,
                dataSource: dataSourceConfs.documentNaks,              
            }
        },
        methods: {
            fetchData() {   
                console.log(this.modelKey);
                this.error = this.model = null;

                if (!this.modelKey) {
                    this.loading = false;
                    return;
                }
                this.loading = true;
                var component = this;
                var source = new DataSource(this.dataSource);
                source.filter([source.key(), "=", new String(component.modelKey.toString())]);

                source
                    .load()
                    .done(function (data) {
                        component.loading = false;
                        component.model = data[0];
                    })
                    .fail(function (error) {
                        component.loading = false;
                        component.error = error;
                    });
            }
        }
    };

</script>
