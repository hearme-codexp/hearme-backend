using System;
using System.Collections.Generic;
using System.Linq;
using hearme_backend.domain.Contracts;
using hearme_backend.repository.Context;
using Microsoft.EntityFrameworkCore;

namespace hearme_backend.repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly HearMeContext _dbContext;

        public BaseRepository(HearMeContext hearmecontext)
        {
            _dbContext = hearmecontext;
        }
        public int Atualizar(T dados)
        {
            try{
                _dbContext.Set<T>().Update(dados);
                return _dbContext.SaveChanges();
            }catch(System.Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public T Buscar(int id, string[] includes = null)
        {
            try{
                var chavePrimaria = _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];
                return _dbContext.Set<T>().FirstOrDefault(e => EF.Property<int>(e, chavePrimaria.Name) == id);
            }catch(System.Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public int Deletar(T dados)
        {
            try
            {
                _dbContext.Set<T>().Add(dados);
                return _dbContext.SaveChanges();
            }
            catch(System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Inserir(T dados)
        {
            try
            {
                _dbContext.Set<T>().Add(dados);
                return _dbContext.SaveChanges();
            }
            catch(System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public IEnumerable<T> Listar(string[] includes = null)
        {
            try
            {
                var query = _dbContext.Set<T>().AsQueryable();
                if(includes == null) return query.ToList();
                foreach (var item in includes)
                {
                    query = query.Include(item);    
                }

                return query.ToList();
            }
            catch(System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}