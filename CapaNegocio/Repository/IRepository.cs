using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repository
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        Task<List<T>> GetList(string filter = "");
        Task<bool> Save(T model);
        Task<bool> Delete(int id);
    }
}
