export class QueryOptionModel {
    Where: String;
    Page: Number;
    PageSize: Number;


    constructor() {
        this.init();
    }

    init() {
        this.Where = "";
        this.Page = 0;
        this.PageSize = 0;
    }

}