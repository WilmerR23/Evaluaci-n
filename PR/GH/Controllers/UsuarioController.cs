using AutoMapper;
using GH.Extensions;
using GH.Models.Persona;
using GH.Repository;
using GH.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : BaseApiController<UsuarioGestion, UsuarioGestionDto>
    {
        public UsuarioController(IRepository<UsuarioGestion,UsuarioGestionDto> _repository, IUnitOfWork _unitOfWork, IMapper _mapper, IApiDbQuery _apiDbQuery) : base(_repository, _unitOfWork, _mapper, _apiDbQuery) { }
        
    }
}
