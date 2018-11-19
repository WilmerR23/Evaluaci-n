// import Vue from 'vue';
// import { Component } from 'vue-property-decorator';
// import { DatosGeneralesModel } from '../../../Models/DatosGeneralesModel';
// import { GenericComponent } from '../../../Core/genericComponent';
// import MapClass from '../../../Core/MapClass';
// import { DatosGeneralesModelDto } from '../../../Models/DatosGeneralesModelDto';
// @Component({
//     components: {
//         LoadingComponent: require('../../loading/loading.vue.html'),
//         Datatable: require('../../datatable/datatable.vue.html')
//     }
// })
// export default class Registro extends GenericComponent<DatosGeneralesModel> {

//     personas: Array<DatosGeneralesModel> = [];
//     labelButton: string = "Enviar";
//     mappper: MapClass;
//     modelDto = new DatosGeneralesModelDto();
//     onOperationDone: boolean = false;

//     constructor() {
//         super('registro', DatosGeneralesModel);
//         this.mappper = new MapClass();
//     }

//     onSubmit() {
//         if (this.validateData()) {
//             if (this.model.datosGenId) {
//                 this.put(this.model);
//             } else {
//                 this.save(() => {
//                     this.model.init();
//                     this.onOperationDone = true;
//                 });
//             }
//         } else {
//             alert("Is not valid");
//         }
//     }

//     validateData() {
//         return this.model.nombres.length && this.model.apellidos.length && this.model.cedula.length
//             && this.model.celular.length && this.model.email.length && this.model.calle.length;
//     }

//     edit(model: DatosGeneralesModel) {
//         this.mappper.mapTo(model, this.model);
//         this.labelButton = "Actualizar";
//     }

//     put(model: DatosGeneralesModel) {
//         this.update(() => {
//             this.labelButton = "Enviar";
//             this.model.init();
//             this.onOperationDone = true;
//         });
//     }

//     eliminate(model: DatosGeneralesModel, callback: any) {
//         this.remove(model.datosGenId, () => {
//             this.model.init();
//             callback();
//             //  this.onGetPeople();
//         });
//     }
// }
