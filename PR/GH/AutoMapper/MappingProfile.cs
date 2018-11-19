using AutoMapper;
using GH.Models;
using GH.Models.DTOs;
using GH.Resolvers;
//using GH.Models.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExamenPregunta, ExamenPreguntaDto>();

            CreateMap<Examen, ExamenDto>()
              .ForMember(x => x.Preguntas, opt => opt.MapFrom(y => y.ExamenPregunta.Select(v => v.Pregunta)));

            CreateMap<Pregunta, PreguntaDto>();
              //.ForMember(dest => dest.Examenes, opt => opt.ResolveUsing<PreguntaResolver>());
        }
    }
}
