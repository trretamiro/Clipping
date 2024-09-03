using Clipping.Domain.DomainObjects;
using System.Linq.Expressions;

namespace Clipping.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : Entity
    {        
        Task<TEntity> ObterPorId(int id);
        Task<List<TEntity>> ObterTodos();
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Remover(int id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
