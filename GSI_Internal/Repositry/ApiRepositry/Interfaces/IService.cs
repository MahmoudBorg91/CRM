using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSI_Internal.Repositry.ApiRepositry.Interfaces
{
    public interface IService<T>
    {
        public Task<List<T>> GetAllAsync();

        public Task<T> GetByIdAsync(int id);

        public Task<int> AddAsync(T t);

        public Task<int> UpdateAsync(T t);

        public Task<int> DeleteAsync(int id);
    }
}
