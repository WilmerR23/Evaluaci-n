// import Vue from 'vue';
// import { Component, Watch } from 'vue-property-decorator';
// import MapClass from '../../Core/MapClass';
// import { GenericComponent } from '../../Core/genericComponent';
// import HttpAxios from '../../Core/HttpAxios';
// import BaseModel from '../../Models/BaseModel';
// import { DynamicClass } from '../../Core/DynamicClass';
// import { QueryOptionModel } from '../../Models/QueryOptionModel';
// @Component({
//     components: {
//         LoadingComponent: require('../loading/loading.vue.html')
//     },
//     props: ['modelDtoName', 'apiControllerName', 'notShow', 'hasToGetData', 'propNamesArray'],
// })
// export default class DataTable extends GenericComponent<BaseModel> {

//     mappper: MapClass;
//     doLoading: boolean = false;
//     searchText: string = "";
//     options: any = [];
//     selectOption: any = "Seleccionar";
//     data: any = [];
//     apiControllerName: any;
//     modelDtoName: any;
//     primaryKeyName: any;
//     hasToGetData: boolean;
//     notShow: any;
//     queryOptionModel: QueryOptionModel;
//     propNamesArray: Array<any>;


//     constructor() {
//         super('', BaseModel);
//         this.setAxios(new HttpAxios(this.apiControllerName));
//         this.mappper = new MapClass();
//         let that = this;
//         this.propNamesArray.forEach(function (element, index) {
//             if (element != that.notShow[index]) {
//                 that.options.push(element);
//             }
//         });
//     }

//     mounted() {
//         let self = this;
//         console.log(self.$options.filters);
//         self.options
//       //  this.onGetData();
//     }

//     onGetData() {
//         this.doLoading = true;
//         this.findAll((data: any) => {
//             this.fillData(data);
//         });
//     }

//     fillData(data: any) {
//         this.data = [];
//         if (data.length) {
//             for (let x = 0; x < data.length; x++) {
//                 let ele: any = new DynamicClass(this.modelDtoName);
//                 let item = this.mappper.mapTo(data[x], ele);
//                 this.data.push(item);
//             }
//         }
//         this.doLoading = !this.doLoading;
//     }

//     editItem(model: any) {
//         this.$emit('onEdit', model);
//     }

//     deleteItem(id: Number) {
//         this.$emit('onDelete', id, () => {
//             this.onGetData();
//         });
//     }

//     buscarData() {
//         if (this.searchText.trim() != "") {
//             this.doLoading = true;
//             this.queryOptionModel = new QueryOptionModel();
//             this.queryOptionModel.Where = `${this.propNamesArray[this.selectOption]} = ${this.searchText}`;
//             this.custom("POST", `${this.apiControllerName}/search`, this.queryOptionModel, (data: any) => {
//                 this.fillData(data);
//             });
//         }
//     }

//     @Watch('hasToGetData')
//     onWatch(value: boolean) {
//         if (value)
//             this.onGetData();
//     }

//     showColumnData(columnInfo: string) {
//         if (this.notShow.length) {
//             let data = this.notShow.filter((x: any) => {
//                 return x == columnInfo;
//             });
//             return !data.length;
//         }
//         return true;
//     }
// }
