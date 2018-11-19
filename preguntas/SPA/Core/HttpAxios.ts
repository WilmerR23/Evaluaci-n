import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse } from 'axios';
import BaseModel from '../Models/BaseModel';


export default class Http {
    model?: BaseModel;
    apiUrl: string;
    

    Axios = axios.create({
        baseURL: `http://localhost:50794/api/`,
        headers: {
          Authorization: 'Bearer {token}'
        }
    })

    constructor(apiUrl: string, model?: BaseModel) {
        this.apiUrl = apiUrl;
        this.model = model;
    }
    
    findAll(callback: any) {
        this.Axios.get(this.apiUrl).then( res => {
            callback(res.data);
        });
    }

    post(model: BaseModel, callback: any) {
        //var el = JSON.stringify(model);
        var instance = this.AxiosBase("POST", null, null, JSON.stringify(model));
        this.request(instance, callback);
    }

    put(model: BaseModel, callback: any) {
        var instance = this.AxiosBase("PUT", null, null, JSON.stringify(model));
        this.request(instance, callback);
        // this.Axios.put(this.apiUrl, model).then( res => {
        //     callback(res.data);
        // });
    }

    custom(method: string, url: string, body: any, callback: any) {
        var instance = this.AxiosBase(method, null,null,JSON.stringify(body),url);
        this.request(instance, callback);
    }

    delete(id: Number, callback: any) {
        var instance = this.AxiosBase("DELETE", null);
        instance.url += `/${id}`;
        this.request(instance, callback);
    }

    request(config: AxiosRequestConfig, callback: (data: any, value?: AxiosResponse) => any, errorCallback?: (value?: any) => any) {
           axios.defaults.withCredentials = true;   
        return axios.request(config).then(function (value) {
            callback(value.data, value);
        }).catch(function (reason) {
            if (errorCallback) {
                errorCallback(reason);
            }
        });
    }

    AxiosBase(
        method: string,
        queryString?: any,
        headers?: any,
        body?: Object,
        url?: string,
        transFormRequest?: Function,
        transformResponse?: Function,
        contentType?: string,
        
    ): AxiosRequestConfig {
        return (({
            url: url ? url: this.apiUrl,
            method: method,
            baseURL: "http://localhost:50794/api/",
            transformRequest: [
                transFormRequest ||
                function (data: any, headers: any) {
                    return data;
                }
            ],
            transformResponse: [
                transformResponse ||
                function (data: any) {
                    try {
                        data = JSON.parse(data);
                        return data;
                    }
                    catch(err) {
                        return data;
                    }
                }
            ],
            headers: 
            {                   
                'Content-Type': 'application/json',                
                'Access-Control-Allow-Origin': '*',
            },
            params: queryString,
            data: body,
            validateStatus: function (status: any) {
                return status >= 200 && status < 300;
            }
        }) as any) as AxiosRequestConfig;                
    }
}