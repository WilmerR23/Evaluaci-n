using AutoMapper;
using GH.Models;
using GH.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Resolvers
{
    public class PreguntaResolver : IValueResolver<Pregunta, PreguntaDto, object>
    {
        private readonly IMapper _mapper;
        public PreguntaResolver(IMapper mapper)
        {
            _mapper = mapper;
        }

        public object Resolve(Pregunta source, PreguntaDto destination, object destMember, ResolutionContext context)
        {
            return null;
        }
    }
    }
