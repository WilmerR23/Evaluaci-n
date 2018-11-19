import BaseModel from "../Models/BaseModel";

export default class MapClass {

    mapTo(model: any, modelType: any) {
        Object.keys(model).forEach(function (key) {
            if (modelType.hasOwnProperty(key.charAt(0).toLocaleLowerCase() + key.slice(1)))
                modelType[key] = model[key];
        });
        return modelType;
    }
}