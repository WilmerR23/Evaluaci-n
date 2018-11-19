using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GH.Extensions;
using GH.Models;
using GH.Models.Enum;
using GH.Models.Persona;
using GH.Repository;
using GH.Services;
using Microsoft.AspNetCore.Mvc;

namespace GH.Controllers
{
    [Route("api/[controller]")]
    public class RegistroController : BaseApiController<DatosGenerales, DatosGeneralesDto>
    {
        public RegistroController(IRepository<DatosGenerales,DatosGeneralesDto> _repository, IUnitOfWork _unitOfWork, IMapper _mapper, IApiDbQuery _apiDbQuery) : base(_repository, _unitOfWork, _mapper, _apiDbQuery) { }
        
    }
}
