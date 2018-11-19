// import { Component } from 'vue-property-decorator';
// import { UsuarioModel } from '../../Models/UsuarioModel';
// import { GenericComponent } from '../../Core/genericComponent';
// import MapClass from '../../Core/MapClass';
// import Vue from 'vue';
// import { UsuarioModelDto } from '../../Models/UsuarioModelDto';
// @Component({
//     components: {
//         LoadingComponent: require('../loading/loading.vue.html'),
//         Datatable: require('../datatable/datatable.vue.html')
//     }
// })
// export default class Usuario extends GenericComponent<UsuarioModelDto> {

//     usuarios: Array<UsuarioModel> = [];
//     modelDto: UsuarioModelDto = new UsuarioModelDto();
//     labelButton: string = "Enviar";
//     mappper: MapClass;
//     claveRepeat: any = null;
//     onOperationDone: boolean = false;

//     constructor() {
//         super('usuario', UsuarioModelDto);
//         this.mappper = new MapClass();
//     }

//     onSubmit() {
//         if (this.validateData()) {
//             if (this.model.usuarioGestId) {
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
//         return this.model.usuario.length && (this.model.usuarioGestId || (this.model.contraseña.length && this.claveRepeat.length))
//     }

//     editUser(model: UsuarioModelDto) {
//         this.mappper.mapTo(model, this.model);
//         this.labelButton = "Actualizar";
//     }

//     put(model: UsuarioModelDto) {
//         this.update(() => {
//             this.labelButton = "Enviar";
//             this.model.init();
//             this.onOperationDone = true;
//         });
//     }

//     deleteUser(model: UsuarioModelDto, callback: any) {
//         this.remove(model.usuarioGestId, () => {
//             this.model.init();
//             callback();
//             //  this.onGetPeople();
//         });
//     }
// }
