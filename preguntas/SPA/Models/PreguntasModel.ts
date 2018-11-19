import OpcionModel from "./OpcionModel";
import RespuestaModel from "./RespuestaModel";

export default class PreguntasModel {

  id: any;
  texto: string;
  opciones: Array<OpcionModel>;
  respuestas: Array<RespuestaModel>;

  constructor() {
    this.init();
  }

  init() {
    this.id = 0;
    this.texto = '';
    this.opciones = new Array<OpcionModel>();
    this.respuestas = new Array<RespuestaModel>();
  }
}