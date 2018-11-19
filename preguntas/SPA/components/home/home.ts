import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { GenericComponent } from '../../Core/genericComponent';
import PreguntasModel from '../../Models/PreguntasModel';
import OpcionModel from '../../Models/OpcionModel';
import Multiselect from 'vue-multiselect';
import ExamenModel from '../../Models/ExamenModel';

@Component({
    
})
export default class Home extends GenericComponent<PreguntasModel> {

    examen: ExamenModel = new ExamenModel();
    options = [];
    val: any = "";

    mounted() {
        this.custom('GET','http://localhost:50794/api/pregunta/GetExamenes',null,(data: any) => {
             this.options = data;
        });
    }

    addExam() {
        console.log(this.val);
        this.custom('POST','http://localhost:50794/api/pregunta/PostExamenes',this.examen,(data: any) => {
            console.log(data);
       });
    }

    constructor() {
        super("Pregunta", PreguntasModel);
    }

    onClick() {
        this.model.opciones.push(new OpcionModel());
    }

    nameWithLang (texto: any) {
        return `${name}`;
    }

    onQuit(idx: number) {
        this.model.opciones.splice(idx,1);
    }

    onCheck(id: any) {
        if (this.model.respuestas.some((e) => e == this.model.opciones[id])) {
            this.model.respuestas = this.model.respuestas.filter(item => item !== this.model.opciones[id])
        } else {
            this.model.respuestas.push(this.model.opciones[id]);
        }
    }

    send() {
       this.save(() => {
           alert("Exito");
       });
    }

}
