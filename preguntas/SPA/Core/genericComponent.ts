import Vue from 'vue';
import HttpAxios from './HttpAxios';
import BaseModel from '../Models/BaseModel';

export class GenericComponent<T extends BaseModel> extends Vue {
    model: T;
    public axios: HttpAxios;

    constructor(apiUrl: string, model: any) {
        super();
        this.model = new model();
        this.axios = new HttpAxios(apiUrl, model);
    }

    findAll(callback: any) {
        this.axios.findAll((data: any) => {
            callback(data);
        });
    }

    save(callback: any) {
        this.axios.post(this.model, (data: any) => {
            callback(data);
        });
    }

    update(callback: any) {
        this.axios.put(this.model, (data: any) => {
            callback(data);
        });
    }

    remove(id: Number, callback: any) {
        if (confirm("Estas seguro?")) {
            this.axios.delete(id, () => {
                callback();
            });
        }
    }

    custom(method: string, url: string, data: any, callback: any) {
        this.axios.custom(method, url, data, (data: any) => {
            callback(data);
        });
    }

    setAxios(httpAxios: HttpAxios) {
       this.axios = httpAxios;
    }

}