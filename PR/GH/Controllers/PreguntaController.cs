using AutoMapper;
using GH.Models;
using GH.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Controllers
{
    [Route("api/[controller]")]
    public class PreguntaController : Controller
    {
        private readonly PreguntasContext _dbContext;
        private readonly IMapper _mapper;

        public PreguntaController(PreguntasContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pregunta Pregunta)
        {
            Pregunta preg = new Pregunta(Pregunta.Texto);
            _dbContext.Preguntas.Add(preg);
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Opcion Opcion)
        {
            Opcion opcion = new Opcion(Opcion.Texto);
            _dbContext.Opciones.Add(opcion);
            return Ok();
        }

        [HttpPost]
        [Route("PostExamenes")]
        public IActionResult Post([FromBody] Examen Examen)
        {
            Examen examen = new Examen(Examen.Descripcion);
            _dbContext.Examenes.Add(Examen);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] PreguntaDto Preguntas)
        {
            #region preguntas

            ExamenPregunta exaPreg = new ExamenPregunta(Preguntas.ExamenId, Preguntas.Id);
            _dbContext.ExamenPregunta.Add(exaPreg);

            foreach (OpcionDto opc in Preguntas.Opciones)
            {
                OpcionPregunta opcPreg = new OpcionPregunta(opc.Id, Preguntas.Id);
                _dbContext.OpcionPregunta.Add(opcPreg);
            }

            foreach (RespuestaDto res in Preguntas.Respuestas)
            {
                if (_dbContext.Respuestas.Find(res.Id) == null)
                {
                    //create respuesta
                    Respuesta res2 = new Respuesta(res.Texto);
                    res.Id = res2.Id;
                    _dbContext.Respuestas.Add(res2);
                }

                RespuestaPregunta resPreg = new RespuestaPregunta(res.Id, Preguntas.Id);
                _dbContext.RespuestaPregunta.Add(resPreg);
            }



            #endregion
            _dbContext.SaveChanges();

            return Ok();
        }


        [HttpGet]
        [Route("GetExamenes")]
        public IActionResult GetExamenes()
        {
            var data =  _dbContext.Examenes.Include(x => x.ExamenPregunta).ThenInclude(v => v.Pregunta).ToList();
            var dataMapped = _mapper.Map<List<ExamenDto>>(data);
            return Ok(dataMapped);
        }

        [HttpGet]
        [Route("GetPreguntas")]
        public IActionResult GetPreguntas()
        {
            var data = _dbContext.Preguntas.Include(x => x.ExamenPregunta).ThenInclude(v => v.Examen).ToList();
            var dataMapped = _mapper.Map<List<PreguntaDto>>(data);
            return Ok(dataMapped);
        }

        [HttpGet]
        [Route("GetOpciones")]
        public IActionResult GetOpciones()
        {
            return Ok(_dbContext.Opciones.ToList());
        }
    }
}
