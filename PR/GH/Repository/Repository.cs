using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GH.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;

namespace GH.Repository
{
    public interface IRepository<T,TDto> where T : class
    {
        ICollection<TDto> GetAll();

        Task<IEnumerable<TDto>> FindBy(Expression<Func<T, bool>> predicate);

        void Post(TDto entity);

        void Put(TDto entity);

        void Delete(int id);

        IQueryable<TDto> Search(string name);
    }

    public class Repository<T, TDto> : IRepository<T, TDto> where T : class
    {
        private dynamic _context;
        private DbSet<T> _entity;
        private readonly IMapper _mapper;

        public Repository(dynamic context, IMapper mapper)
        {
            _context = context;
            _entity = _context.Set<T>();
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _entity.Remove(_entity.Find(id));
        }

        public async Task<IEnumerable<TDto>> FindBy(Expression<Func<T, bool>> predicate)
        {
            var data = await _entity.Where(predicate).ToListAsync();
            return _mapper.Map<IEnumerable<TDto>>(data);
        }

        public ICollection<TDto> GetAll()
        {
           return _mapper.Map<ICollection<TDto>>(_entity);
        }

        public void Post(TDto entity)
        {
            var data = _mapper.Map<T>(entity);
            _entity.Add(data);
        }

        public void Put(TDto entity)
        {
            var data = _mapper.Map<T>(entity);
            _entity.Update(data);
        }

        public IQueryable<TDto> Search(string sql)
        {
            return _mapper.Map<IQueryable<TDto>>(_entity.FromSql(sql));
        }
    }
}
