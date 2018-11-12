import React from 'react';
import ReactDOM from 'react-dom';
import {MileStoneModel} from '../Models/MileStoneModel.js';
import {TimeLine} from '../SharedComponents/TimeLine.jsx';

export function startPage(){
    var response = {
        blocks:
        [
            {
                name:'Ведется итоговая комплектация', date:'22.07.2017', color:'#f8696b', subBlock:[{name:'subStatus1', date:'22.07.2017'},{name:'subStatus2',date:'23.07.2017'}]
            },
            {
                name:'ПОДРЯДЧИК проверка', date:'35.09.2017', color:'#f8696b', subBlock:[{name:'subStatus4', date:'22.07.2017'},{name:'subStatus5',date:'23.07.2017'}]
            },
            {
                name:'Прогноз. Первый выпуск еще не получен', date:'23.32.2330', color:'#fcc57b', subBlock:[{name:'subStatus4', date:'22.07.2017'},{name:'subStatus5',date:'23.07.2017'}]
            },
            {
                name:'Предоставлено (ожидаются указания касательно статуса и рассылки)', date:'35.09.2017', color:'#ffeb84', subBlock:[{name:'subStatus4', date:'22.07.2017'},{name:'subStatus5',date:'23.07.2017'}]
            },
            {
                name:'КОМПАНИЯ (РУСЛАБ) проверка', date:'35.09.2017', color:'#ccdd82', subBlock:[{name:'subStatus4', date:'22.07.2017'},{name:'subStatus5',date:'23.07.2017'}]
            },
            {
                name:'КОМПАНИЯ первичная проверка', date:'35.09.2017', color:'#63be7b', subBlock:[]
            }
        ]
    }
    var modelUnderTest = new MileStoneModel(response);
    modelUnderTest.selectBlock(0);

    ReactDOM.render(
        <TimeLine inValue={modelUnderTest} />
        , document.getElementsByTagName("body")[0]);
}