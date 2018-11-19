import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { GenericComponent } from '../../Core/genericComponent';
import PreguntasModel from '../../Models/PreguntasModel';
import OpcionModel from '../../Models/OpcionModel';
import Multiselect from 'vue-multiselect';
import ExamenModel from '../../Models/ExamenModel';

@Component({
    
})
export default class Examen extends GenericComponent<PreguntasModel> {

    examen: ExamenModel = new ExamenModel();
    options = [];
    val: any = "";
    currentQuestion: any = null;

    mounted() {
        this.custom('GET','http://localhost:50794/api/pregunta/GetExamenes',null,(data: any) => {
             this.options = data;
        });
    }

    addExam() {
        this.custom('POST','http://localhost:50794/api/pregunta/PostExamenes',this.examen,(data: any) => {
            console.log(data);
       });
    }

    constructor() {
        super("Pregunta", PreguntasModel);
    }

    onSelect(data: any, id: any) {
        this.currentQuestion = data;
        alert(this.currentQuestion);
    }
}
