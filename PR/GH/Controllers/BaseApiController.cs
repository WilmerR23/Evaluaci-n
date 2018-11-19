using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GH.Extensions;
using GH.Repository;
using GH.Services;
using Microsoft.AspNetCore.Mvc;

namespace GH.Controllers
{
    public class BaseApiController<TEntity, TDto> : ControllerBase where TEntity : class
    {
        public readonly IRepository<TEntity,TDto> _repository;
        public readonly IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;
        private readonly IApiDbQuery _apiDbQuery;

        public BaseApiController(IRepository<TEntity,TDto> repository, IUnitOfWork IUnitOfWork, IMapper mapper, IApiDbQuery apiDbQuery)
        {
            _repository = repository;
            _IUnitOfWork = IUnitOfWork;
            _mapper = mapper;
            _apiDbQuery = apiDbQuery;
        }

        [HttpGet]
        public IActionResult Get()
        {
             return Ok(_mapper.Map<List<TDto>>(_repository.GetAll()));
        }
        
        [HttpPost]
        public Task<IActionResult> Post([FromBody]TDto Model)
        {
            return _IUnitOfWork.InApiRequestTransactionAsync(() =>
            {
                _repository.Post(Model);
                return Ok(StatusCode(204, "Post"));
            });
        }
        
        [HttpPut]
        public Task<IActionResult> Put([FromBody]TDto Model)
        {
            return _IUnitOfWork.InApiRequestTransactionAsync(() =>
            {
                _repository.Put(Model);
                return Ok(StatusCode(204, "Put"));
            });
        }
        
        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            return _IUnitOfWork.InApiRequestTransactionAsync(() =>
            {
                _repository.Delete(id);
                return Ok(StatusCode(204, "Delete"));
            });
        }

        [HttpPost("search")]
        public Task<IActionResult> Search([FromBody] ApiQueryOption option)
        {
            return _IUnitOfWork.InApiRequestTransactionAsync(() =>
            {
                return Ok(_apiDbQuery.Get<TEntity>(option));
            });
        }
    }
}
